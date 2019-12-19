using System;
using UnityEngine;

public class SoundFadeEffect : MonoBehaviour
{
    private float fadeTime;

    public float min;

    public float max;

    private AudioSource audioSource;

    public int soundIndex;

    public bool fadeOutDestroy;

    private float timeCount;

    private float currentVolum;

    public float delyTime;

    private SoundFadeEffect.State state;

    public bool Pause;

    public int NextMusicID;

    public float NextSoundVolume;

    public float NextProgress;

    private enum State
    {
        NORMAL,
        FADEIN,
        FADEOUT
    }

    private void Update()
	{
		if (this.Pause)
		{
			return;
		}
		if (this.audioSource == null)
		{
			base.enabled = false;
			return;
		}
		switch (this.state)
		{
		case SoundFadeEffect.State.NORMAL:
			base.enabled = false;
			break;
		case SoundFadeEffect.State.FADEIN:
			this.timeCount += GameTime.deltaTime;
			this.audioSource.volume = Mathf.Lerp(this.currentVolum, this.max, this.timeCount / this.fadeTime);
			if (this.audioSource.volume == this.max)
			{
				this.state = SoundFadeEffect.State.NORMAL;
			}
			break;
		case SoundFadeEffect.State.FADEOUT:
			this.timeCount += GameTime.deltaTime;
			this.audioSource.volume = Mathf.Lerp(this.currentVolum, this.min, this.timeCount / this.fadeTime);
			if (this.audioSource.volume == this.min)
			{
				this.audioSource.Stop();
				if (this.fadeOutDestroy)
				{
					this.DestroySound();
				}
				if (this.NextMusicID > 0)
				{
					SingletonMono<AudioManager>.GetInstance().StopBackGroundMusic(0f);
					SingletonMono<AudioManager>.GetInstance().PlayBackGroundMusic(this.NextMusicID, this.NextSoundVolume, this.NextProgress, this.fadeTime);
				}
				this.state = SoundFadeEffect.State.NORMAL;
			}
			break;
		}
	}

	public static SoundFadeEffect AddFadeOutEffect(AudioSource target, int soundIndex, float fadeTime, float maxVolum, bool destroy)
	{
		SoundFadeEffect soundFadeEffect = target.gameObject.GetComponent<SoundFadeEffect>();
		if (soundFadeEffect == null)
		{
			soundFadeEffect = target.gameObject.AddComponent<SoundFadeEffect>();
		}
		soundFadeEffect.SetValue(target, fadeTime, maxVolum);
		soundFadeEffect.soundIndex = soundIndex;
		soundFadeEffect.fadeOutDestroy = destroy;
		soundFadeEffect.FadeOut();
		return soundFadeEffect;
	}

	public static SoundFadeEffect AddFadeInEffect(AudioSource target, float fadeTime, float maxVolum)
	{
		SoundFadeEffect soundFadeEffect = target.gameObject.GetComponent<SoundFadeEffect>();
		if (soundFadeEffect == null)
		{
			soundFadeEffect = target.gameObject.AddComponent<SoundFadeEffect>();
		}
		soundFadeEffect.SetValue(target, fadeTime, maxVolum);
		soundFadeEffect.FadeIn();
		return soundFadeEffect;
	}

	public void DestroySound()
	{
		SingletonMono<AudioManager>.GetInstance().RemoveSound(this.soundIndex);
	}

	public void SetValue(AudioSource source, float fadeLength, float maxVolum)
	{
		this.audioSource = source;
		this.fadeTime = fadeLength;
		this.max = maxVolum;
	}

	public void SetMaxSound(float maxSound)
	{
		this.max = maxSound;
		if (this.audioSource.volume > maxSound)
		{
			this.audioSource.volume = maxSound;
		}
		if (this.state == SoundFadeEffect.State.NORMAL)
		{
			this.audioSource.volume = maxSound;
		}
	}

	public void FadeIn()
	{
		this.audioSource.volume = 0f;
		this.Fade(SoundFadeEffect.State.FADEIN);
	}

	private void Fade(SoundFadeEffect.State fadeState)
	{
		if (this.fadeTime <= 0f)
		{
			this.state = SoundFadeEffect.State.NORMAL;
			return;
		}
		this.timeCount = 0f;
		this.currentVolum = this.audioSource.volume;
		this.state = fadeState;
		base.enabled = true;
	}

	public void FadeOut()
	{
		this.Fade(SoundFadeEffect.State.FADEOUT);
	}

	public void StopFade()
	{
		this.state = SoundFadeEffect.State.NORMAL;
	}
}
