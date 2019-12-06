using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200017E RID: 382
public class DynamicData : MonoBehaviour
{
	// Token: 0x06000797 RID: 1943 RVA: 0x000216E8 File Offset: 0x0001F8E8
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

	// Token: 0x06000798 RID: 1944 RVA: 0x00021760 File Offset: 0x0001F960
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

	// Token: 0x06000799 RID: 1945 RVA: 0x000217FC File Offset: 0x0001F9FC
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

	// Token: 0x0400066B RID: 1643
	public static List<SaveData.SDMoiveDate> MoiveInfoList = new List<SaveData.SDMoiveDate>();
}
