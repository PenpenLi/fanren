using System;
using System.Collections.Generic;

/// <summary>
/// 角色模型信息
/// </summary>
public class RoleModelInfo
{
    private const int ATTACK_NUM = 5;

    private int m_iID;

    private string m_strName;

    private string m_strModelPath;

    private int m_iChildInfoID;

    private int m_iMaterialType;

    private int m_iAniIndex;

    private List<int> m_lstAttack = new List<int>();

    public RoleModelInfo(RoleModelInfo clone)
	{
		this.m_iChildInfoID = clone.ID;
		this.m_iChildInfoID = clone.ChildInfoID;
		this.m_iMaterialType = clone.m_iMaterialType;
		this.m_strModelPath = clone.Path;
		this.m_strName = clone.Name;
		this.m_iAniIndex = clone.AnimationIndex;
		this.m_lstAttack.Clear();
		foreach (int item in clone.AttackTable)
		{
			this.m_lstAttack.Add(item);
		}
	}

	public RoleModelInfo()
	{
	}

	public int ID
	{
		get
		{
			return this.m_iID;
		}
	}

	public string Name
	{
		get
		{
			return this.m_strName;
		}
	}

	public string Path
	{
		get
		{
			return this.m_strModelPath;
		}
	}

	public int ChildInfoID
	{
		get
		{
			return this.m_iChildInfoID;
		}
	}

	public int MaterialType
	{
		get
		{
			return this.m_iMaterialType;
		}
	}

	public int AnimationIndex
	{
		get
		{
			return this.m_iAniIndex;
		}
	}

	public List<int> AttackTable
	{
		get
		{
			return this.m_lstAttack;
		}
	}

	public void ReadConfig(List<string> infoList, ref int index)
	{
		string text = string.Empty;
		this.m_iID = int.Parse(infoList[index++]);
		this.m_strName = infoList[index++];
		this.m_strModelPath = infoList[index++];
		text = infoList[index++];
		if (text.StartsWith("null"))
		{
			this.m_iChildInfoID = -1;
		}
		else
		{
			this.m_iChildInfoID = int.Parse(text);
		}
		this.m_iMaterialType = int.Parse(infoList[index++]);
		text = infoList[index++];
		if (text.StartsWith("null"))
		{
			this.m_iAniIndex = -1;
		}
		else
		{
			this.m_iAniIndex = int.Parse(text);
		}
		this.m_lstAttack.Clear();
		for (int i = 0; i < 5; i++)
		{
			string text2 = infoList[index++];
			if (!text2.StartsWith("null"))
			{
				this.m_lstAttack.Add(int.Parse(text2));
			}
		}
	}
}
