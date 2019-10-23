using System;
using System.Collections.Generic;
using UnityUtility;

// Token: 0x0200023B RID: 571
public class CEffectData
{
	// Token: 0x170001BE RID: 446
	// (get) Token: 0x06000EF6 RID: 3830 RVA: 0x0000B18F File Offset: 0x0000938F
	public int TypeId
	{
		get
		{
			return this.m_iTypeId;
		}
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x0000B197 File Offset: 0x00009397
	public string Name
	{
		get
		{
			return this.m_strName;
		}
	}

	// Token: 0x170001C0 RID: 448
	// (get) Token: 0x06000EF8 RID: 3832 RVA: 0x0000B19F File Offset: 0x0000939F
	// (set) Token: 0x06000EF9 RID: 3833 RVA: 0x0000B1A7 File Offset: 0x000093A7
	public int ResId
	{
		get
		{
			return this.m_iResID;
		}
		set
		{
			this.m_iResID = value;
		}
	}

	// Token: 0x170001C1 RID: 449
	// (get) Token: 0x06000EFA RID: 3834 RVA: 0x0000B1B0 File Offset: 0x000093B0
	// (set) Token: 0x06000EFB RID: 3835 RVA: 0x0000B1B8 File Offset: 0x000093B8
	public short Type
	{
		get
		{
			return this.m_sType;
		}
		set
		{
			this.m_sType = value;
		}
	}

	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x06000EFC RID: 3836 RVA: 0x0000B1C1 File Offset: 0x000093C1
	public short MovementType
	{
		get
		{
			return this.m_sMovementType;
		}
	}

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06000EFD RID: 3837 RVA: 0x0000B1C9 File Offset: 0x000093C9
	// (set) Token: 0x06000EFE RID: 3838 RVA: 0x0000B1D1 File Offset: 0x000093D1
	public float LastTime
	{
		get
		{
			return this.m_fLastTime;
		}
		set
		{
			this.m_fLastTime = value;
		}
	}

	public EffectSoundData effectSoundData { get; private set; }

	// Token: 0x06000F01 RID: 3841 RVA: 0x0000B1EB File Offset: 0x000093EB
	public void Write(CSerializer cs)
	{
		cs.Write(this.m_iTypeId);
		cs.Write(this.m_strName);
		cs.Write(this.m_iResID);
		cs.Write(this.m_sType);
		cs.Write(this.m_fLastTime);
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x00096294 File Offset: 0x00094494
	public string GetInfoLine()
	{
		return string.Concat(new string[]
		{
			this.m_iTypeId.ToString(),
			"\t",
			this.m_strName,
			"\t",
			this.m_iResID.ToString(),
			"\t",
			this.m_sType.ToString(),
			"\t",
			this.m_fLastTime.ToString()
		});
	}

	// Token: 0x06000F03 RID: 3843 RVA: 0x0000B229 File Offset: 0x00009429
	public void Read(CSerializer cs)
	{
		this.m_iTypeId = cs.ReadInt32();
		this.m_strName = cs.ReadStr();
		this.m_iResID = cs.ReadInt32();
		this.m_sType = cs.ReadInt16();
		this.m_fLastTime = cs.ReadFloat();
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x00096310 File Offset: 0x00094510
	public void TextRead(List<string> infoList, ref int index)
	{
		this.m_iTypeId = Convert.ToInt32(infoList[index++]);
		this.m_strName = new string(infoList[index++].ToCharArray());
		this.m_iResID = Convert.ToInt32(infoList[index++]);
		this.m_sType = Convert.ToInt16(infoList[index++]);
		this.m_fLastTime = Convert.ToSingle(infoList[index++]);
		this.effectSoundData = new EffectSoundData();
		this.effectSoundData.ReadData(infoList, ref index);
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x000963BC File Offset: 0x000945BC
	public void TextRead(string[] infoList)
	{
		this.m_iTypeId = Convert.ToInt32(infoList[0]);
		this.m_strName = new string(infoList[1].ToCharArray());
		this.m_iResID = Convert.ToInt32(infoList[2]);
		this.m_sType = Convert.ToInt16(infoList[3]);
		this.m_fLastTime = Convert.ToSingle(infoList[4]);
	}

	// Token: 0x04001023 RID: 4131
	private int m_iTypeId;

	// Token: 0x04001024 RID: 4132
	private string m_strName;

	// Token: 0x04001025 RID: 4133
	private int m_iResID;

	// Token: 0x04001026 RID: 4134
	private short m_sType;

	// Token: 0x04001027 RID: 4135
	private short m_sMovementType;

	// Token: 0x04001028 RID: 4136
	private float m_fLastTime;
}
