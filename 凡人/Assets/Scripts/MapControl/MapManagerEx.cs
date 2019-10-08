using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

public class MapManagerEx
{
    public List<MapEx> mapList = new List<MapEx>();

    public RndSetMan m_rndSetMan = new RndSetMan();

    public void LoadMapInfo(bool bEditor)
	{
		if (!bEditor)
		{
			this.m_rndSetMan.LoadRndSetInfo();
		}
		this.mapList.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets("res/mapinfo");
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			if (array.Length != 5)
			{
                Debug.Log("MapInfo.txt 格式错误");
				break;
			}
			MapEx mapEx = new MapEx();
			int num = 0;
			mapEx.ID = Convert.ToInt32(array[num]);
			num++;
			mapEx.Name = array[num];
			num++;
			mapEx.ScenePath = array[num];
			num++;
			mapEx.MapFilePath = array[num];
			num++;
			mapEx.ShadowBackFilePath = array[num];
			mapEx.RndSetInfo = this.m_rndSetMan.GetRndSetInfo(mapEx.ID);
			this.mapList.Add(mapEx);
		}
	}

	public void CreateMap(int mapID)
	{
		for (int i = 0; i < this.mapList.Count; i++)
		{
			if (this.mapList[i].ID == mapID)
			{
				this.mapList[i].LoadObj();
				this.mapList[i].LoadCache();
				this.mapList[i].InitMap();
				return;
			}
		}
        Debug.Log("Create failed:can't find the map info id is " + mapID);
	}

	public bool ContainMap(int id)
	{
		foreach (MapEx mapEx in this.mapList)
		{
			if (mapEx.ID == id)
			{
				return true;
			}
		}
		return false;
	}
}
