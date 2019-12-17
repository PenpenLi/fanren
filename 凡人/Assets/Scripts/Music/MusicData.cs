using System;

[Serializable]
public class MusicData
{
    public int ID;

    public float FadeTime;

    public float StartTime;

    public float Volume;

    public bool loop;

    public MusicData()
	{
	}

	public MusicData(int id, float fadeTime, float volume, float starTime)
	{
		this.ID = id;
		this.FadeTime = fadeTime;
		this.StartTime = starTime;
		this.Volume = volume;
	}
}
