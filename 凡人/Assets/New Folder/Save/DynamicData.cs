using System;
using System.Collections.Generic;
using UnityEngine;


public class DynamicData : MonoBehaviour
{
    public static List<SaveData.SDMoiveDate> MoiveInfoList = new List<SaveData.SDMoiveDate>();

    public static void SetDate(List<SaveData.SDMoiveDate> moiveInfoList)
	{
		DynamicData.MoiveInfoList.Clear();
		if (moiveInfoList == null)
		{
			return;
		}
		foreach (SaveData.SDMoiveDate item in moiveInfoList)
		{
			DynamicData.MoiveInfoList.Add(item);
		}
	}

	public static void PlayMoive(int id)
	{
		foreach (SaveData.SDMoiveDate sdmoiveDate in DynamicData.MoiveInfoList)
		{
			if (sdmoiveDate.ID == id)
			{
				sdmoiveDate.PlayCount++;
				return;
			}
		}
		SaveData.SDMoiveDate sdmoiveDate2 = new SaveData.SDMoiveDate();
		sdmoiveDate2.ID = id;
		sdmoiveDate2.PlayCount = 1;
		DynamicData.MoiveInfoList.Add(sdmoiveDate2);
	}

	public static int GetMoivePlayCount(int id)
	{
		foreach (SaveData.SDMoiveDate sdmoiveDate in DynamicData.MoiveInfoList)
		{
			if (sdmoiveDate.ID == id)
			{
				return sdmoiveDate.PlayCount;
			}
		}
		return -1;
	}
}
