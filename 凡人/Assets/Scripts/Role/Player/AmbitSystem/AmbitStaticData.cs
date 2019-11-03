using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;


public class AmbitStaticData : Singleton<AmbitStaticData>
{
    private const string CONFIG_PATH = "conf/AmbitConfig";

    private Dictionary<int, Dictionary<AMBITLEVEL, AmbitData>> m_mapAmbitData = new Dictionary<int, Dictionary<AMBITLEVEL, AmbitData>>();

    public AmbitStaticData()
	{
		this.ReadConfig();
	}

	private void ReadConfig()
	{
		this.m_mapAmbitData.Clear();
		List<string> list = new List<string>();
		list = UtilityLoader.LoadConfText("conf/AmbitConfig");
		if (list.Count == 0)
        {
            Debug.LogWarning("path error or file has no content");
            return;
		}
		int i = 0;
		i = 0;
		while (i < list.Count)
		{
			int key = int.Parse(list[i++]);
			int num = int.Parse(list[i++]);
			Dictionary<AMBITLEVEL, AmbitData> dictionary = new Dictionary<AMBITLEVEL, AmbitData>();
			for (int j = 0; j < num; j++)
			{
				int key2 = int.Parse(list[i++]);
				AmbitData ambitData = new AmbitData();
				ambitData.ReadConfig(list, ref i);
				dictionary.Add((AMBITLEVEL)key2, ambitData);
			}
			this.m_mapAmbitData.Add(key, dictionary);
		}
	}

	// Token: 0x06001E2D RID: 7725 RVA: 0x000D1E54 File Offset: 0x000D0054
	public Dictionary<AMBITLEVEL, AmbitData> GetAmbitData(int id)
	{
		if (this.m_mapAmbitData.ContainsKey(id))
		{
			return this.m_mapAmbitData[id];
		}
		return null;
	}
}
