using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

public class RoleBaseConfig
{
    private string strFileName = "RoleBaseConfig";

    public Dictionary<int, RoleBaseInfo> _PlayerInfos = new Dictionary<int, RoleBaseInfo>();

    public RoleBaseConfig()
	{
		this.LoadConfig(this.strFileName);
	}

	public int Count
	{
		get
		{
			return this._PlayerInfos.Count;
		}
	}

	public RoleBaseInfo this[int id]
	{
		get
		{
			if (!this._PlayerInfos.ContainsKey(id))
			{
				return null;
			}
			return this._PlayerInfos[id];
		}
	}

	public void LoadConfig(string file)
	{
        if (string.IsNullOrEmpty(file))
		{
			return;
		}
		this._PlayerInfos.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets(file);
		if (list == null || list.Count <= 0)
		{
			return;
		}
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			if (array != null)
			{
				if (array.Length != 10)
				{
                    Debug.Log("RoleBaseConfig: Read " + file + " failed!");
				}
				else
				{
					int i = 0;
					RoleBaseInfo roleBaseInfo = new RoleBaseInfo();
					roleBaseInfo.ID = Convert.ToInt32(array[i]);
					if (this._PlayerInfos.ContainsKey(roleBaseInfo.ID))
					{
                        Debug.Log("RoleBaseConfig: Player ID " + roleBaseInfo.ID + " failed!");
					}
					else
					{
						i++;
						roleBaseInfo.Name = array[i];
						i++;
						roleBaseInfo.PrefabName = array[i];
						i++;
						roleBaseInfo.DefultEquip.Clear();
						int num = 0;
						while (i < array.Length)
						{
							ulong num2 = Convert.ToUInt64(array[i]);
							if (num2 == 0UL)
							{
                                num++;
							}
							else
							{
								roleBaseInfo.DefultEquip.Add((RoleWearEquipPos)num, num2);
								num++;
							}
							i++;
						}
						this._PlayerInfos.Add(roleBaseInfo.ID, roleBaseInfo);
					}
				}
			}
		}
	}
}
