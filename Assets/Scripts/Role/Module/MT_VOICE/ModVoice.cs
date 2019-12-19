using System;
using UnityEngine;


public class ModVoice : Module
{
    private SoundData voice;

    private SoundData sound;

    public ModVoice(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_VOICE;
	}

	public SoundData Voice
	{
		get
		{
			if (this.voice == null || this.voice.audioSource == null)
			{
				this.voice = SingletonMono<AudioManager>.GetInstance().CreatNewSound(SoundType.dubSound, null, 1f, 50f, false);
				this.voice.audioSource.transform.parent = base.Role.GetTrans();
				this.voice.audioSource.transform.localPosition = Vector3.zero;
			}
			return this.voice;
		}
	}

	public SoundData Sound
	{
		get
		{
			if (this.sound == null || this.sound.audioSource == null)
			{
				this.sound = SingletonMono<AudioManager>.GetInstance().CreatNewSound(SoundType.gameSound, null, 1f, 50f, false);
				this.sound.audioSource.transform.parent = base.Role.GetTrans();
				this.sound.audioSource.transform.localPosition = Vector3.zero;
			}
			return this.sound;
		}
	}

	public void PlayVoice(int id, bool loop)
	{
		this.Voice.Play(id, loop);
	}

	public void StopVoice()
	{
		this.Voice.audioSource.Stop();
	}

	public void PlaySound(int id, bool loop)
	{
		this.Sound.Play(id, loop);
	}

	public void PlayOneShotSound(int id)
	{
		this.Sound.PlayOneShot(id);
	}
}
