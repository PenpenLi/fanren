using System;

public class SoundsInfo
{
	public int id { get; private set; }

	public string path { get; private set; }

	public float distance { get; private set; }

	public float volume { get; private set; }

	public float minTime { get; private set; }

	public void ReadData(string[] parameter)
	{
		int num = 0;
		this.id = Convert.ToInt32(parameter[num]);
		num++;
		this.path = Convert.ToString(parameter[num]);
		num++;
		this.distance = Convert.ToSingle(parameter[num]);
		num++;
		this.volume = Convert.ToSingle(parameter[num]);
		num++;
		this.minTime = Convert.ToSingle(parameter[num]);
	}
}
