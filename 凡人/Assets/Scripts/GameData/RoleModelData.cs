using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;


public class RoleModelData : Singleton<RoleModelData>
{
    private const string MODEL_CONFIG = "conf/RoleModelConfig";

    private Dictionary<int, RoleModelInfo> m_mapRoleModelInfos = new Dictionary<int, RoleModelInfo>();

    public RoleModelData()
	{
		this.ReadConfig();
	}

	public Dictionary<int, RoleModelInfo> MapRoleModelInfos
	{
		get
		{
			return this.m_mapRoleModelInfos;
		}
		set
		{
			this.m_mapRoleModelInfos = value;
		}
	}

	public void ReadConfig()
	{
		this.m_mapRoleModelInfos.Clear();
		List<string> list = new List<string>();
		list = UtilityLoader.LoadConfText("conf/RoleModelConfig");
		int i = 0;
		i = 0;
		while (i < list.Count)
		{
			RoleModelInfo roleModelInfo = new RoleModelInfo();
			roleModelInfo.ReadConfig(list, ref i);
			this.m_mapRoleModelInfos.Add(roleModelInfo.ID, roleModelInfo);
		}
	}

	public RoleModelInfo GetRoleModelInfo(int modelId)
	{
		if (this.m_mapRoleModelInfos.ContainsKey(modelId))
		{
			return this.m_mapRoleModelInfos[modelId];
		}
		Debug.LogWarning("Error From:conf/RoleModelConfig");
		return null;
	}
}
