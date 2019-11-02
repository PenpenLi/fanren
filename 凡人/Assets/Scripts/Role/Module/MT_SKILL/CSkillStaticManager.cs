using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

/// <summary>
/// 技能状态管理
/// </summary>
public class CSkillStaticManager : Singleton<CSkillStaticManager>
{
    private Dictionary<int, CSkillBase> m_mapSkillData = new Dictionary<int, CSkillBase>();

    public CSkillStaticManager()
	{
		this.TextLoad();
	}

	public CSkillBase GetSkill(int id)
	{
		if (this.m_mapSkillData.ContainsKey(id))
		{
			return this.m_mapSkillData[id].Clone();
		}
		return null;
	}

	private bool AddSkillData(CSkillBase sd)
	{
		if (sd.ID == 0)
		{
			return false;
		}
		if (!this.m_mapSkillData.ContainsKey(sd.ID))
		{
			return false;
		}
		this.m_mapSkillData.Add(sd.ID, sd);
		return true;
	}

	public void Save()
	{
		CSerializer cserializer = new CSerializer();
		cserializer.BeginWrite();
		cserializer.Write(this.m_mapSkillData.Count);
		foreach (KeyValuePair<int, CSkillBase> keyValuePair in this.m_mapSkillData)
		{
			keyValuePair.Value.Write(cserializer);
		}
		//CFile cfile = new CFile(Application.dataPath + "/Data/Skill.dt");
		//cfile.WriteBytesAll(cserializer.GetWriteBytes());
		cserializer.EndWrite();
	}

	public void Load()
	{
		this.m_mapSkillData.Clear();
		CSerializer cserializer = new CSerializer();
		//CFile cfile = new CFile(Application.dataPath + "/Data/Skill.dt");
		//cserializer.BeginRead(cfile.ReadBytesAll());
		int num = cserializer.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			string typeName = cserializer.ReadStr();
			Type type = Type.GetType(typeName);
			CSkillBase cskillBase = (CSkillBase)Activator.CreateInstance(type);
			cskillBase.Read(cserializer);
			if (cskillBase != null)
			{
				this.m_mapSkillData.Add(cskillBase.ID, cskillBase);
			}
		}
		cserializer.EndRead();
	}

	public void TextLoad()
	{
		List<string> list = new List<string>();
		list = UtilityLoader.LoadConfText("conf/DataFile/Skill/SkillScript");
		this.m_mapSkillData.Clear();
		int i = 0;
		while (i < list.Count)
		{
			string typeName = list[i++];
			Type type = Type.GetType(typeName);
            if (type!=null)
            {
                CSkillBase cskillBase = (CSkillBase)Activator.CreateInstance(type);
                cskillBase.TextRead(list, ref i);
                if (cskillBase != null)
                {
                    this.m_mapSkillData.Add(cskillBase.ID, cskillBase);
                }
            }          
        }
	}
}
