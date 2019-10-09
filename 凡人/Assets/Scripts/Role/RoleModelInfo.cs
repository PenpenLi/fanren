using System;
using System.Collections.Generic;

// Token: 0x02000571 RID: 1393
public class RoleModelInfo
{
	// Token: 0x0600253D RID: 9533 RVA: 0x000F9780 File Offset: 0x000F7980
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

	// Token: 0x0600253E RID: 9534 RVA: 0x000193DE File Offset: 0x000175DE
	public RoleModelInfo()
	{
	}

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x0600253F RID: 9535 RVA: 0x000193F1 File Offset: 0x000175F1
	public int ID
	{
		get
		{
			return this.m_iID;
		}
	}

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x06002540 RID: 9536 RVA: 0x000193F9 File Offset: 0x000175F9
	public string Name
	{
		get
		{
			return this.m_strName;
		}
	}

	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x06002541 RID: 9537 RVA: 0x00019401 File Offset: 0x00017601
	public string Path
	{
		get
		{
			return this.m_strModelPath;
		}
	}

	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x06002542 RID: 9538 RVA: 0x00019409 File Offset: 0x00017609
	public int ChildInfoID
	{
		get
		{
			return this.m_iChildInfoID;
		}
	}

	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x06002543 RID: 9539 RVA: 0x00019411 File Offset: 0x00017611
	public int MaterialType
	{
		get
		{
			return this.m_iMaterialType;
		}
	}

	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x06002544 RID: 9540 RVA: 0x00019419 File Offset: 0x00017619
	public int AnimationIndex
	{
		get
		{
			return this.m_iAniIndex;
		}
	}

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06002545 RID: 9541 RVA: 0x00019421 File Offset: 0x00017621
	public List<int> AttackTable
	{
		get
		{
			return this.m_lstAttack;
		}
	}

	// Token: 0x06002546 RID: 9542 RVA: 0x000F9844 File Offset: 0x000F7A44
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

	// Token: 0x04002159 RID: 8537
	private const int ATTACK_NUM = 5;

	// Token: 0x0400215A RID: 8538
	private int m_iID;

	// Token: 0x0400215B RID: 8539
	private string m_strName;

	// Token: 0x0400215C RID: 8540
	private string m_strModelPath;

	// Token: 0x0400215D RID: 8541
	private int m_iChildInfoID;

	// Token: 0x0400215E RID: 8542
	private int m_iMaterialType;

	// Token: 0x0400215F RID: 8543
	private int m_iAniIndex;

	// Token: 0x04002160 RID: 8544
	private List<int> m_lstAttack = new List<int>();
}
