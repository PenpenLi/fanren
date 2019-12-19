using System;
using UnityEngine;

public class MusicManager : SingletonMono<MusicManager>
{
    private const float MUSIC_IDLE_TIME = 3f;

    private MusicData currentMusicData;

    private MusicData currentThemeMusicData;

    private SoundData musicObject;

    private MusicManager.PLAY_STATE state;

    private int crossState;

    private bool themeOverAutoTurn;

    private float timeCountReplay;

    public enum PLAY_STATE
    {
        NONE,
        PLAY_MUSIC,
        PLAY_THEME,
        CROSS_TO_MUSIC,
        CROSS_TO_THEME,
        CROSS_MUSIC_VOLUME
    }

    public SoundData MusicObject
	{
		get
		{
			if (this.musicObject == null || this.musicObject.audioSource == null)
			{
				this.musicObject = SingletonMono<AudioManager>.GetInstance().CreatNewSound(SoundType.bgSound, null, 1f, 100f, true);
			}
			return this.musicObject;
		}
	}

	private void Update()
	{
		if (this.state == MusicManager.PLAY_STATE.CROSS_TO_MUSIC && !this.CrossToNewMusic(this.currentMusicData))
		{
			this.state = MusicManager.PLAY_STATE.PLAY_MUSIC;
		}
		if (this.state == MusicManager.PLAY_STATE.CROSS_TO_THEME && !this.CrossToNewMusic(this.currentThemeMusicData))
		{
			this.state = MusicManager.PLAY_STATE.PLAY_THEME;
		}
		if (this.state == MusicManager.PLAY_STATE.PLAY_THEME)
		{
			if (this.currentThemeMusicData == null)
			{
				return;
			}
			if (this.themeOverAutoTurn && !this.currentThemeMusicData.loop && !this.MusicObject.isPausing && !this.MusicObject.audioSource.isPlaying)
			{
				this.PlayCurrentMusic(1f);
			}
		}
		if (this.state == MusicManager.PLAY_STATE.CROSS_MUSIC_VOLUME)
		{
		}
		if (this.state == MusicManager.PLAY_STATE.PLAY_MUSIC)
		{
			if (this.currentMusicData == null)
			{
				return;
			}
			if (!this.currentMusicData.loop && !this.MusicObject.audioSource.isPlaying && !this.MusicObject.isPausing)
			{
				this.timeCountReplay += GameTime.deltaTime;
				if (this.timeCountReplay >= 3f)
				{
					this.state = MusicManager.PLAY_STATE.NONE;
					this.PlayCurrentMusic(1f);
					this.timeCountReplay = 0f;
				}
			}
		}
	}

	private bool CrossToNewMusic(MusicData data)
	{
		if (data.FadeTime > 0f)
		{
			if (this.crossState == 0)
			{
				bool flag = false;
				if (this.MusicObject.audioSource.isPlaying)
				{
					if (this.MusicObject.audioSource.volume > 0f)
					{
						this.MusicObject.audioSource.volume -= this.TransFadeSpeed(data.FadeTime, this.MusicObject.maxVolum);
						if (this.MusicObject.audioSource.volume <= 0f)
						{
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					this.SetMusicObject(data);
					this.MusicObject.audioSource.volume = 0f;
					this.MusicObject.Play(data.StartTime);
					this.crossState = 1;
				}
			}
			if (this.crossState == 1)
			{
				this.MusicObject.audioSource.volume += this.TransFadeSpeed(data.FadeTime, this.MusicObject.maxVolum);
				if (this.MusicObject.audioSource.volume > this.MusicObject.maxVolum)
				{
					this.MusicObject.audioSource.volume = this.MusicObject.maxVolum;
					return false;
				}
			}
			return true;
		}
		this.SetMusicObject(data);
		this.MusicObject.audioSource.volume = this.MusicObject.maxVolum;
		this.MusicObject.Play(data.StartTime);
		return false;
	}

	private float TransFadeSpeed(float fadeTime, float maxVolume)
	{
		return maxVolume * GameTime.deltaTime / fadeTime;
	}

	private void SetMusicObject(MusicData data)
	{
		AudioClip audioClip = SingletonMono<AudioManager>.GetInstance().GetAudioClip(data.ID);
		if (audioClip != null)
		{
			this.MusicObject.audioSource.clip = audioClip;
			this.MusicObject.audioSource.loop = data.loop;
			this.MusicObject.orignVolume = data.Volume;
			this.MusicObject.maxVolum = this.MusicObject.orignVolume * this.GetMusicBaseVolume();
		}
	}

	public void PlayMusic(int id, float fadeTime, float volume, float starTime, bool loop)
	{
		SoundsInfo soundInfo = SingletonMono<AudioManager>.GetInstance().GetSoundInfo(id);
		if (soundInfo == null)
		{
			return;
		}
		this.currentMusicData = new MusicData(id, fadeTime, volume * soundInfo.volume, starTime);
		this.currentMusicData.loop = true;
		this.state = MusicManager.PLAY_STATE.CROSS_TO_MUSIC;
		this.ResetTempValue();
	}

	public void PauseMusic(bool pause)
	{
	}

	public void PlayMusic(int id, float fadeTime, float volume, float starTime)
	{
		this.PlayMusic(id, fadeTime, volume, starTime, false);
	}

	public void PlayThemeMusic(int id, float fadeTime, float volume, float starTime, bool loop, bool autoTurn)
	{
		SoundsInfo soundInfo = SingletonMono<AudioManager>.GetInstance().GetSoundInfo(id);
		if (soundInfo == null)
		{
			return;
		}
		this.currentThemeMusicData = new MusicData(id, fadeTime, volume * soundInfo.volume, starTime);
		this.currentThemeMusicData.loop = loop;
		this.state = MusicManager.PLAY_STATE.CROSS_TO_THEME;
		this.themeOverAutoTurn = autoTurn;
		this.ResetTempValue();
	}

	public void PlayThemeMusic(int id, float fadeTime, float volume, float starTime)
	{
		this.PlayThemeMusic(id, fadeTime, volume, starTime, true, true);
	}

	public MusicData GetCurrentMusicData()
	{
		return this.currentMusicData;
	}

	public void PlayMusic(MusicData data)
	{
		if (data == null)
		{
			return;
		}
		this.currentMusicData = data;
		this.currentMusicData.loop = true;
		this.state = MusicManager.PLAY_STATE.CROSS_TO_MUSIC;
		this.ResetTempValue();
	}

	private void ResetTempValue()
	{
		this.crossState = 0;
		this.timeCountReplay = 0f;
	}

	public void PlayCurrentMusic(float fadeTime)
	{
		if (this.state == MusicManager.PLAY_STATE.PLAY_MUSIC || this.state == MusicManager.PLAY_STATE.CROSS_TO_MUSIC)
		{
			return;
		}
		if (this.currentMusicData == null)
		{
			return;
		}
		this.currentMusicData.FadeTime = fadeTime;
		this.state = MusicManager.PLAY_STATE.CROSS_TO_MUSIC;
		this.ResetTempValue();
	}

	private float GetMusicBaseVolume()
	{
		return AudioManager.GetCurrentSoundVolumSet(SoundType.bgSound);
	}
}
