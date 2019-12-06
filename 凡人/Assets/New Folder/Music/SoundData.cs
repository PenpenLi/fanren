using System;
using UnityEngine;

public class SoundData
{
    public int soundIndex;

    public SoundType soundType;

    public AudioSource audioSource;

    public int soundID;

    public float lifeTime;

    public bool isPausing;

    public bool isStarted;

    public SoundFadeEffect audioBind;

    public bool autoDestroy;

    public float orignVolume;

    public float maxVolum;

    public void SetMaxVolumeScale(float scale)
	{
		if (this.orignVolume == 0f)
		{
			this.audioSource.volume = 0f;
			return;
		}
		float num = this.maxVolum / this.orignVolume;
		this.maxVolum = this.orignVolume * scale;
		if (num == 0f)
		{
			this.audioSource.volume = this.orignVolume * scale;
		}
		else
		{
			float num2 = this.audioSource.volume / num;
			this.audioSource.volume = num2 * scale;
		}
		if (this.audioBind != null)
		{
			this.audioBind.SetMaxSound(this.maxVolum);
		}
		if (this.audioSource.volume > this.maxVolum)
		{
			this.audioSource.volume = this.maxVolum;
		}
	}

	public void PlayOneShot(int soundID)
	{
		SoundsInfo soundInfo = SingletonMono<AudioManager>.GetInstance().GetSoundInfo(soundID);
		if (soundInfo == null)
		{
			return;
		}
		float volume = soundInfo.volume;
		AudioClip audioClip = SingletonMono<AudioManager>.GetInstance().LoadAudioClip(soundInfo);
		if (audioClip == null)
		{
			return;
		}
		this.audioSource.PlayOneShot(audioClip, volume);
	}

	public void StopFadeEffect()
	{
		if (this.audioBind != null)
		{
			this.audioBind.StopFade();
		}
		if (this.audioSource != null)
		{
			this.audioSource.volume = this.maxVolum;
		}
	}

	public void Play(int soundID, bool loop)
	{
		SoundsInfo soundInfo = SingletonMono<AudioManager>.GetInstance().GetSoundInfo(soundID);
		if (soundInfo == null)
		{
			return;
		}
		AudioClip audioClip = SingletonMono<AudioManager>.GetInstance().LoadAudioClip(soundInfo);
		if (audioClip == null)
		{
			return;
		}
		this.audioSource.Stop();
		this.audioSource.clip = audioClip;
		this.audioSource.loop = loop;
		this.audioSource.Play();
	}

	public void Play()
	{
		if (this.audioSource != null && this.audioSource.clip != null)
		{
			this.audioSource.Play();
		}
	}

	public void Play(float startTime)
	{
		if (this.audioSource != null && this.audioSource.clip != null)
		{
			this.audioSource.Play();
			startTime = Mathf.Clamp(startTime, 0f, this.audioSource.clip.length);
			this.audioSource.time = startTime;
		}
	}
}
