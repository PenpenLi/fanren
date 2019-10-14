using System;
using UnityEngine;

public class SoundStartPlay : MonoBehaviour
{
    public SoundData sound;

    private void Start()
	{
		if (this.sound != null)
		{
			this.sound.audioSource.Play();
			this.sound.isStarted = true;
		}
	}
}
