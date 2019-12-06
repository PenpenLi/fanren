using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMono<AudioManager>
{
    private const AudioRolloffMode FADE_MOD = AudioRolloffMode.Custom;

    private GameObject soundColection;

    private int currentBGMuscic;

    private List<int> currentBGSound = new List<int>();

    private float bgMusicSoundVolum = 1f;

    private Dictionary<int, float> lastPlayTime = new Dictionary<int, float>();

    private Dictionary<int, AudioClip> tempClips = new Dictionary<int, AudioClip>();

    private Dictionary<int, SoundData> soundData = new Dictionary<int, SoundData>();

    private int currentSoundIndex = 1;

    public GameObject SoundCollection
	{
		get
		{
			if (this.soundColection == null)
			{
				this.soundColection = new GameObject("SoundCollection");
			}
			return this.soundColection;
		}
	}

	public void ClearObject()
	{
		this.tempClips.Clear();
		this.soundData.Clear();
	}

	private void OnDestroy()
	{
		this.ClearObject();
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (this.soundData.Count <= 0)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (SoundData soundData in this.soundData.Values)
		{
			if (soundData.audioSource == null)
			{
				list.Add(soundData.soundIndex);
			}
			else if (!soundData.audioSource.loop)
			{
				if (soundData.autoDestroy)
				{
					if (soundData.isStarted)
					{
						if (!soundData.isPausing)
						{
							soundData.lifeTime -= Time.deltaTime;
							if (soundData.lifeTime <= 0f && !soundData.audioSource.isPlaying)
							{
								list.Add(soundData.soundIndex);
							}
						}
					}
				}
			}
		}
		foreach (int index in list)
		{
			this.RemoveSound(index);
		}
	}

	public AudioClip LoadAudioClip(SoundsInfo soundsInfo)
	{
		AudioClip audioClip = null;
		if (this.tempClips.ContainsKey(soundsInfo.id))
		{
			audioClip = this.tempClips[soundsInfo.id];
		}
		if (audioClip != null)
		{
			return audioClip;
		}
		audioClip = (AudioClip)ResourceLoader.Load(soundsInfo.path, typeof(AudioClip));
		if (audioClip != null && !this.tempClips.ContainsKey(soundsInfo.id))
		{
			this.tempClips.Add(soundsInfo.id, audioClip);
		}
		if (audioClip == null)
		{
			Debug.Log("cant load audioclip");
		}
		return audioClip;
	}

	public AudioClip GetAudioClip(int id)
	{
		SoundsInfo soundInfo = this.GetSoundInfo(id);
		if (soundInfo == null)
		{
			return null;
		}
		return this.LoadAudioClip(soundInfo);
	}

	public SoundsInfo GetSoundInfo(int id)
	{
		return GameData.Instance.soundTable.getSoundsInfo(id);
	}

	private void AddSound(SoundData data)
	{
		if (this.soundData.ContainsKey(data.soundIndex))
		{
			return;
		}
		this.soundData.Add(data.soundIndex, data);
	}

	private SoundData GetSound(int index)
	{
		if (!this.soundData.ContainsKey(index))
		{
			return null;
		}
		return this.soundData[index];
	}

	public void RemoveSound(int index)
	{
		if (!this.soundData.ContainsKey(index))
		{
			return;
		}
		SoundData soundData = this.soundData[index];
		if (soundData.audioSource != null)
		{
			UnityEngine.Object.Destroy(soundData.audioSource.gameObject);
		}
		this.soundData.Remove(index);
	}

	public void SetAudioVolume(SoundType type, float volume)
	{
		foreach (SoundData soundData in this.soundData.Values)
		{
			if (soundData.soundType == type)
			{
				soundData.SetMaxVolumeScale(volume);
			}
		}
	}

	public SoundData PlaySound(SoundType type, AudioClip clip, float volume, float maxDistance, bool loop, bool autoDestroy, float fadeTime)
	{
		if (clip == null)
		{
			return null;
		}
		if (!clip.isReadyToPlay)
		{
			return null;
		}
		SoundData soundData = this.CreatNewSound(type, clip, volume, maxDistance, loop);
		soundData.autoDestroy = autoDestroy;
		if (fadeTime > 0f)
		{
			soundData.audioBind = SoundFadeEffect.AddFadeInEffect(soundData.audioSource, fadeTime, soundData.maxVolum);
		}
		SoundStartPlay soundStartPlay = soundData.audioSource.gameObject.AddComponent<SoundStartPlay>();
		soundStartPlay.sound = soundData;
		return soundData;
	}

	public SoundData CreatNewSound(SoundType type, AudioClip clip, float volume, float maxDistance, bool loop)
	{
		int num = this.CreatSoundIndex();
		GameObject gameObject = new GameObject("Sound_" + num);
		gameObject.transform.parent = this.SoundCollection.transform;
		float num2 = AudioManager.GetCurrentSoundVolumSet(type) * volume;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
		audioSource.clip = clip;
		audioSource.volume = num2;
		audioSource.loop = loop;
		audioSource.minDistance = 3f;
		audioSource.maxDistance = maxDistance;
		audioSource.rolloffMode = AudioRolloffMode.Custom;
		SoundData soundData = new SoundData();
		soundData.audioSource = audioSource;
		soundData.soundIndex = num;
		soundData.soundType = type;
		soundData.orignVolume = volume;
		soundData.maxVolum = num2;
		if (clip != null)
		{
			soundData.lifeTime = clip.length;
		}
		soundData.autoDestroy = false;
		this.AddSound(soundData);
		return soundData;
	}

	public SoundData CreatNewSound(SoundType type, int soundID, float volume, float maxDistance, bool loop)
	{
		SoundsInfo soundInfo = this.GetSoundInfo(soundID);
		if (soundInfo == null)
		{
			return null;
		}
		AudioClip audioClip = this.LoadAudioClip(soundInfo);
		if (audioClip == null)
		{
			return null;
		}
		return this.CreatNewSound(type, audioClip, volume, maxDistance, loop);
	}

	public SoundData CreatNewSound(SoundType type, int soundID, bool loop)
	{
		SoundsInfo soundInfo = this.GetSoundInfo(soundID);
		if (soundInfo == null)
		{
			return null;
		}
		AudioClip audioClip = this.LoadAudioClip(soundInfo);
		if (audioClip == null)
		{
			return null;
		}
		return this.CreatNewSound(type, audioClip, soundInfo.volume, soundInfo.distance, loop);
	}

	// Token: 0x06002EC4 RID: 11972 RVA: 0x0016886C File Offset: 0x00166A6C
	public void StopSound(int index, float fadeTime)
	{
		if (fadeTime > 0f)
		{
			if (this.soundData.ContainsKey(index) && this.soundData[index].audioSource != null)
			{
				this.soundData[index].audioBind = SoundFadeEffect.AddFadeOutEffect(this.soundData[index].audioSource, index, fadeTime, this.soundData[index].maxVolum, true);
			}
		}
		else
		{
			this.RemoveSound(index);
		}
	}

	// Token: 0x06002EC5 RID: 11973 RVA: 0x001688F8 File Offset: 0x00166AF8
	public void StopAllSound()
	{
		foreach (SoundData soundData in this.soundData.Values)
		{
			if (!(soundData.audioSource == null))
			{
				UnityEngine.Object.Destroy(soundData.audioSource.gameObject);
			}
		}
		this.soundData.Clear();
	}

	public void PauseSound(int index, bool pause)
	{
		if (!this.soundData.ContainsKey(index))
		{
			return;
		}
		this.PauseSound(this.soundData[index], pause);
	}

	private void PauseSound(SoundData data, bool pause)
	{
		if (data.audioSource == null)
		{
			return;
		}
		if (pause)
		{
			if (data.audioSource.isPlaying)
			{
				data.audioSource.Pause();
				data.isPausing = true;
				if (data.audioBind != null)
				{
					data.audioBind.Pause = pause;
				}
			}
		}
		else if (data.isPausing)
		{
			data.audioSource.Play();
			data.isPausing = false;
			if (data.audioBind != null)
			{
				data.audioBind.Pause = pause;
			}
		}
	}

	public void PlaySound(int index)
	{
		if (this.soundData.ContainsKey(index))
		{
			this.PauseSound(this.soundData[index], false);
		}
	}

    /// <summary>
    /// 暂停所有音乐
    /// </summary>
    /// <param name="pause"></param>
	public void PauseAll(bool pause)
	{
		foreach (SoundData data in this.soundData.Values)
		{
			this.PauseSound(data, pause);
		}
	}

	public void PauseSound(SoundType type, bool pause)
	{
		foreach (SoundData soundData in this.soundData.Values)
		{
			if (soundData.soundType == type)
			{
				this.PauseSound(soundData, pause);
			}
		}
	}

	// Token: 0x06002ECB RID: 11979 RVA: 0x00168AFC File Offset: 0x00166CFC
	public void PauseEnviromentSound(bool pause)
	{
		foreach (SoundData soundData in this.soundData.Values)
		{
			if (soundData.soundIndex != this.currentBGMuscic)
			{
				this.PauseSound(soundData, pause);
			}
		}
	}

	// Token: 0x06002ECC RID: 11980 RVA: 0x00168B74 File Offset: 0x00166D74
	public SoundData PlaySound(SoundType type, Vector3 pos, int soundID, float volume, float maxDistance, bool loop, bool autoDestroy, float fadeTime)
	{
		SoundsInfo soundInfo = this.GetSoundInfo(soundID);
		if (soundInfo == null)
		{
			return null;
		}
		if (soundInfo.minTime > 0f && this.lastPlayTime.ContainsKey(soundID) && GameTime.time - this.lastPlayTime[soundID] < soundInfo.minTime)
		{
			return null;
		}
		AudioClip audioClip = this.LoadAudioClip(soundInfo);
		if (audioClip == null)
		{
			return null;
		}
		float volume2 = (volume < 0f) ? soundInfo.volume : volume;
		float maxDistance2 = (maxDistance < 0f) ? soundInfo.distance : maxDistance;
		SoundData soundData = this.PlaySound(type, audioClip, volume2, maxDistance2, loop, autoDestroy, fadeTime);
		soundData.soundID = soundID;
		soundData.audioSource.transform.position = pos;
		if (soundInfo.minTime > 0f)
		{
			if (this.lastPlayTime.ContainsKey(soundID))
			{
				this.lastPlayTime[soundID] = GameTime.time;
			}
			else
			{
				this.lastPlayTime.Add(soundID, GameTime.time);
			}
		}
		return soundData;
	}

	// Token: 0x06002ECD RID: 11981 RVA: 0x00168C94 File Offset: 0x00166E94
	public SoundData PlaySound(SoundType type, Vector3 pos, int soundID, bool loop, bool autoDestroy, float fadeTime)
	{
		return this.PlaySound(type, pos, soundID, -1f, -1f, loop, autoDestroy, fadeTime);
	}

	// Token: 0x06002ECE RID: 11982 RVA: 0x00168CBC File Offset: 0x00166EBC
	public SoundData PlaySound(SoundType type, Vector3 pos, int soundID, bool loop, bool autoDestroy)
	{
		return this.PlaySound(type, pos, soundID, -1f, -1f, loop, autoDestroy, 0f);
	}

	// Token: 0x06002ECF RID: 11983 RVA: 0x00168CE8 File Offset: 0x00166EE8
	public SoundData PlaySound(SoundType type, Vector3 pos, int soundID, bool loop)
	{
		return this.PlaySound(type, pos, soundID, -1f, -1f, loop, true, 0f);
	}

	// Token: 0x06002ED0 RID: 11984 RVA: 0x00168D10 File Offset: 0x00166F10
	public SoundData PlaySound(SoundType type, Transform parent, int soundID, float volume, float maxDistance, bool loop, bool autoDestroy, float fadeTime)
	{
		SoundData soundData = this.PlaySound(type, Vector3.zero, soundID, volume, maxDistance, loop, autoDestroy, fadeTime);
		if (soundData == null)
		{
			return null;
		}
		soundData.audioSource.transform.parent = parent;
		soundData.audioSource.transform.localPosition = Vector3.zero;
		return soundData;
	}

	// Token: 0x06002ED1 RID: 11985 RVA: 0x00168D64 File Offset: 0x00166F64
	public SoundData PlaySound(SoundType type, Transform parent, int soundID, bool loop, bool autoDestroy, float fadeTime)
	{
		return this.PlaySound(type, parent, soundID, -1f, -1f, loop, autoDestroy, fadeTime);
	}

	// Token: 0x06002ED2 RID: 11986 RVA: 0x00168D8C File Offset: 0x00166F8C
	public SoundData PlaySound(SoundType type, Transform parent, int soundID, bool autoDestroy, bool loop)
	{
		return this.PlaySound(type, parent, soundID, -1f, -1f, loop, autoDestroy, 0f);
	}

	// Token: 0x06002ED3 RID: 11987 RVA: 0x00168DB8 File Offset: 0x00166FB8
	public SoundData PlaySound(SoundType type, Transform parent, int soundID, bool loop)
	{
		return this.PlaySound(type, parent, soundID, -1f, -1f, loop, true, 0f);
	}

	// Token: 0x06002ED4 RID: 11988 RVA: 0x00168DE0 File Offset: 0x00166FE0
	public void PlayBackGroundMusic(int soundID, float volum, float progress, float fadeTime)
	{
		SoundsInfo soundInfo = this.GetSoundInfo(soundID);
		if (soundInfo == null)
		{
			return;
		}
		AudioClip x = this.LoadAudioClip(soundInfo);
		if (x == null)
		{
			return;
		}
		SoundData soundData;
		if (fadeTime > 0f)
		{
			soundData = this.GetSound(this.currentBGMuscic);
			if (soundData != null)
			{
				soundData.audioBind = SoundFadeEffect.AddFadeOutEffect(soundData.audioSource, soundData.soundIndex, fadeTime, this.GetBGMusicVolum(soundData), false);
				soundData.audioBind.NextMusicID = soundID;
				soundData.audioBind.NextProgress = progress;
				soundData.audioBind.NextSoundVolume = volum;
				return;
			}
		}
		this.StopBackGroundMusic(0f);
		soundData = this.PlaySound(SoundType.bgSound, Vector3.zero, soundID, volum, 100f, true, false, fadeTime);
		if (progress > 0f)
		{
			soundData.audioSource.time = soundData.audioSource.clip.length * progress;
		}
		this.currentBGMuscic = soundData.soundIndex;
		if (soundData.audioBind != null)
		{
			soundData.audioBind.SetMaxSound(this.GetBGMusicVolum(soundData));
		}
		else
		{
			soundData.audioSource.volume = this.GetBGMusicVolum(soundData);
		}
	}

	// Token: 0x06002ED5 RID: 11989 RVA: 0x0001C2E3 File Offset: 0x0001A4E3
	public void PauseBackGroundMusic(bool pause)
	{
		if (this.soundData.ContainsKey(this.currentBGMuscic))
		{
			this.PauseSound(this.soundData[this.currentBGMuscic], pause);
		}
	}

	// Token: 0x06002ED6 RID: 11990 RVA: 0x00168F0C File Offset: 0x0016710C
	public void PlayBackGroundSound(int soundID)
	{
		if (this.GetBGSoundData(soundID) != null)
		{
			return;
		}
		SoundData soundData = this.PlaySound(SoundType.gameSound, Vector3.zero, soundID, true);
		this.currentBGSound.Add(soundData.soundIndex);
	}

	// Token: 0x06002ED7 RID: 11991 RVA: 0x00168F48 File Offset: 0x00167148
	public void PauseBackGroundSound(int soundID, bool pause)
	{
		SoundData bgsoundData = this.GetBGSoundData(soundID);
		if (bgsoundData != null)
		{
			this.PauseSound(bgsoundData, pause);
		}
	}

	// Token: 0x06002ED8 RID: 11992 RVA: 0x00168F6C File Offset: 0x0016716C
	private SoundData GetBGSoundData(int soundID)
	{
		SoundData result = null;
		for (int i = 0; i < this.currentBGSound.Count; i++)
		{
			SoundData sound = this.GetSound(this.currentBGSound[i]);
			if (sound != null && sound.soundID == soundID)
			{
				result = sound;
				break;
			}
		}
		return result;
	}

	// Token: 0x06002ED9 RID: 11993 RVA: 0x00168FC4 File Offset: 0x001671C4
	public void StopBackGroundSound(int soundID)
	{
		SoundData bgsoundData = this.GetBGSoundData(soundID);
		if (bgsoundData != null)
		{
			this.StopSound(bgsoundData.soundIndex, 0f);
			this.currentBGSound.Remove(bgsoundData.soundIndex);
		}
	}

	// Token: 0x06002EDA RID: 11994 RVA: 0x00169004 File Offset: 0x00167204
	public void StopAllBackGroundSound()
	{
		for (int i = 0; i < this.currentBGSound.Count; i++)
		{
			SoundData sound = this.GetSound(this.currentBGSound[i]);
			if (sound != null)
			{
				this.StopSound(sound.soundIndex, 0f);
			}
		}
		this.currentBGSound.Clear();
	}

	// Token: 0x06002EDB RID: 11995 RVA: 0x00169064 File Offset: 0x00167264
	public void StopBackGroundMusic(float fadeTime)
	{
		if (fadeTime == 0f)
		{
			this.RemoveSound(this.currentBGMuscic);
			return;
		}
		if (this.soundData.ContainsKey(this.currentBGMuscic) && this.soundData[this.currentBGMuscic] != null)
		{
			SoundFadeEffect.AddFadeOutEffect(this.soundData[this.currentBGMuscic].audioSource, this.currentBGMuscic, fadeTime, this.soundData[this.currentBGMuscic].audioSource.volume, true);
		}
	}

	// Token: 0x06002EDC RID: 11996 RVA: 0x001690F4 File Offset: 0x001672F4
	public void SetBackGroundMusicVolum(float volum)
	{
		this.bgMusicSoundVolum = volum;
		if (this.soundData.ContainsKey(this.currentBGMuscic))
		{
			this.soundData[this.currentBGMuscic].SetMaxVolumeScale(this.bgMusicSoundVolum * AudioManager.GetCurrentSoundVolumSet(SoundType.bgSound));
		}
	}

	// Token: 0x06002EDD RID: 11997 RVA: 0x0001C313 File Offset: 0x0001A513
	private float GetBGMusicVolum(SoundData data)
	{
		return data.orignVolume * this.bgMusicSoundVolum * AudioManager.GetCurrentSoundVolumSet(SoundType.bgSound);
	}

	// Token: 0x06002EDE RID: 11998 RVA: 0x00169144 File Offset: 0x00167344
	public static float GetCurrentSoundVolumSet(SoundType type)
	{
		if (type == SoundType.bgSound)
		{
			if (SystemSetting.bgSoundMute)
			{
				return 0f;
			}
			return SystemSetting.bgSoundValue;
		}
		else if (type == SoundType.gameSound)
		{
			if (SystemSetting.gameSoundMute)
			{
				return 0f;
			}
			return SystemSetting.gameSoundValue;
		}
		else
		{
			if (type != SoundType.dubSound)
			{
				return 1f;
			}
			if (SystemSetting.dubSoundMute)
			{
				return 0f;
			}
			return SystemSetting.dubSoundValue;
		}
	}

	private int CreatSoundIndex()
	{
		this.currentSoundIndex++;
		if (this.currentSoundIndex > 2147483647)
		{
			this.currentSoundIndex = 0;
		}
		return this.currentSoundIndex;
	}
}
