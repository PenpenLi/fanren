using System;
using System.Collections.Generic;
using NS_RoleBaseFun;


public class SoundTable
{
    public Dictionary<int, SoundsInfo> soundsList = new Dictionary<int, SoundsInfo>();

    public void initialize()
	{
		if (this.soundsList.Count > 0)
		{
			return;
		}
		this.readSoundsList();
	}

	public void readSoundsList()
	{
		this.soundsList.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets("SoundTable");
		foreach (string text in list)
		{
			if (text.Length != 0)
			{
				string[] array = text.Split(CacheData.separator);
				if (array.Length < 4)
				{
					//.LogWarning(new object[]
					//{
					//	"This line: \"" + text + "\" has some error format!"
					//});
				}
				else
				{
					SoundsInfo soundsInfo = new SoundsInfo();
					soundsInfo.ReadData(array);
					if (!this.soundsList.ContainsKey(soundsInfo.id))
					{
						this.soundsList.Add(soundsInfo.id, soundsInfo);
					}
				}
			}
		}
	}


	public SoundsInfo getSoundsInfo(int id)
	{
		if (this.soundsList.ContainsKey(id))
		{
			return this.soundsList[id];
		}
		//Logger.Log(new object[]
		//{
		//	"not find SoundsInfo id =" + id
		//});
		return null;
	}
}
