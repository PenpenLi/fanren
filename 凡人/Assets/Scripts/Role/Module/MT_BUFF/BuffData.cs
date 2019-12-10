using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

// Token: 0x02000589 RID: 1417
public class BuffData
{
	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x060025BE RID: 9662 RVA: 0x0001982D File Offset: 0x00017A2D
	public int ID
	{
		get
		{
			return this.m_iId;
		}
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x060025BF RID: 9663 RVA: 0x00019835 File Offset: 0x00017A35
	public string Name
	{
		get
		{
			return this.m_strName;
		}
	}

	// Token: 0x060025C0 RID: 9664 RVA: 0x0001983D File Offset: 0x00017A3D
	public int GetValueType(int index)
	{
		if (index >= this.m_queValueType.Length)
		{
			Debug.LogWarning("The Index is Exceed the Que.");
			return 0;
		}
		return (int)this.m_queValueType[index];
	}

	// Token: 0x060025C1 RID: 9665 RVA: 0x00019861 File Offset: 0x00017A61
	public int GetValue(int index)
	{
		if (index >= this.m_queValue.Length)
		{
			Debug.LogWarning("The Index is Exceed the Que.");
			return 0;
		}
		return this.m_queValue[index];
	}

	// Token: 0x1700048F RID: 1167
	// (get) Token: 0x060025C2 RID: 9666 RVA: 0x00019885 File Offset: 0x00017A85
	public bool Show
	{
		get
		{
			return this.m_bShow;
		}
	}

	// Token: 0x17000490 RID: 1168
	// (get) Token: 0x060025C3 RID: 9667 RVA: 0x0001988D File Offset: 0x00017A8D
	public float TotalHitTime
	{
		get
		{
			return this.m_fTotalHitTime;
		}
	}

	// Token: 0x17000491 RID: 1169
	// (get) Token: 0x060025C4 RID: 9668 RVA: 0x00019895 File Offset: 0x00017A95
	public float IntervalHitTime
	{
		get
		{
			return this.m_fIntervalHitTime;
		}
	}

	// Token: 0x17000492 RID: 1170
	// (get) Token: 0x060025C5 RID: 9669 RVA: 0x0001989D File Offset: 0x00017A9D
	public bool IsBuff
	{
		get
		{
			return this.m_bIsBuff;
		}
	}

	// Token: 0x17000493 RID: 1171
	// (get) Token: 0x060025C6 RID: 9670 RVA: 0x000198A5 File Offset: 0x00017AA5
	public bool IsMedicine
	{
		get
		{
			return this.m_bIsMedicine;
		}
	}

	// Token: 0x17000494 RID: 1172
	// (get) Token: 0x060025C7 RID: 9671 RVA: 0x000198AD File Offset: 0x00017AAD
	public bool Overlying
	{
		get
		{
			return this.m_bOverlying;
		}
	}

	// Token: 0x17000495 RID: 1173
	// (get) Token: 0x060025C8 RID: 9672 RVA: 0x000198B5 File Offset: 0x00017AB5
	public int MaxOverlyingNum
	{
		get
		{
			return this.m_iMaxOverlyingNum;
		}
	}

	// Token: 0x17000496 RID: 1174
	// (get) Token: 0x060025C9 RID: 9673 RVA: 0x000198BD File Offset: 0x00017ABD
	public int ReachNum
	{
		get
		{
			return this.m_iReachNum;
		}
	}

	// Token: 0x060025CA RID: 9674 RVA: 0x000198C5 File Offset: 0x00017AC5
	public string GetBone(int index)
	{
		if (index >= this.m_queBones.Length)
		{
			Debug.LogWarning("The Index is Exceed the Que.");
			return string.Empty;
		}
		return this.m_queBones[index];
	}

	// Token: 0x060025CB RID: 9675 RVA: 0x000198ED File Offset: 0x00017AED
	public Vector3 GetOffsetPos(int index)
	{
		if (index >= this.m_queOffsetPos.Length)
		{
			Debug.LogWarning("The index is Exceed the Que");
			return Vector3.zero;
		}
		return this.m_queOffsetPos[index];
	}

	// Token: 0x060025CC RID: 9676 RVA: 0x0001991E File Offset: 0x00017B1E
	public Vector3 GetOffsetRotate(int index)
	{
		if (index >= this.m_queOffsetRotate.Length)
		{
			Debug.LogWarning("The index is Exceed the Que");
			return Vector3.zero;
		}
		return this.m_queOffsetRotate[index];
	}

	// Token: 0x060025CD RID: 9677 RVA: 0x0001994F File Offset: 0x00017B4F
	public int GetEffect(int index)
	{
		if (index >= this.m_queEffects.Length)
		{
			Debug.LogWarning("The Index is Exceed the Que.");
			return 0;
		}
		return this.m_queEffects[index];
	}

	// Token: 0x060025CE RID: 9678 RVA: 0x00019973 File Offset: 0x00017B73
	public int GetDisEffect(int index)
	{
		if (index >= this.m_queDisEffects.Length)
		{
			Debug.LogWarning("The Index is Exceed the Que.");
			return 0;
		}
		return this.m_queDisEffects[index];
	}

	// Token: 0x17000497 RID: 1175
	// (get) Token: 0x060025CF RID: 9679 RVA: 0x00019997 File Offset: 0x00017B97
	public string ToolTip
	{
		get
		{
			return this.m_strToolTip;
		}
	}

	// Token: 0x17000498 RID: 1176
	// (get) Token: 0x060025D0 RID: 9680 RVA: 0x0001999F File Offset: 0x00017B9F
	public string IconPath
	{
		get
		{
			return this.m_strIconPath;
		}
	}

	// Token: 0x17000499 RID: 1177
	// (get) Token: 0x060025D1 RID: 9681 RVA: 0x000199A7 File Offset: 0x00017BA7
	public int ScriptModID
	{
		get
		{
			return this.m_iscriptModID;
		}
	}

	// Token: 0x1700049A RID: 1178
	// (get) Token: 0x060025D2 RID: 9682 RVA: 0x000199AF File Offset: 0x00017BAF
	public int ScriptDataID
	{
		get
		{
			return this.m_iscriptDataID;
		}
	}

	public int ScriptDataIDi
	{
		get
		{
			return this.m_iscriptDataIDi;
		}
	}

	public void Read(CSerializer cs)
	{
		this.m_iId = cs.ReadInt32();
		this.m_strName = cs.ReadStr();
		for (int i = 0; i < 4; i++)
		{
			this.m_queValueType[i] = cs.ReadInt16();
			this.m_queValue[i] = cs.ReadInt32();
		}
		this.m_bShow = cs.ReadBool();
		this.m_fTotalHitTime = cs.ReadFloat();
		this.m_fIntervalHitTime = cs.ReadFloat();
		this.m_bIsBuff = cs.ReadBool();
		this.m_bIsMedicine = cs.ReadBool();
		this.m_bOverlying = cs.ReadBool();
		this.m_iMaxOverlyingNum = cs.ReadInt32();
		this.m_iReachNum = cs.ReadInt32();
		for (int j = 0; j < 3; j++)
		{
			this.m_queBones[j] = cs.ReadStr();
			this.m_queEffects[j] = cs.ReadInt32();
			this.m_queDisEffects[j] = cs.ReadInt32();
		}
		this.m_strToolTip = cs.ReadStr();
		this.m_strIconPath = cs.ReadStr();
		this.m_iscriptModID = cs.ReadInt32();
		this.m_iscriptDataID = cs.ReadInt32();
		this.m_iscriptDataIDi = cs.ReadInt32();
	}

	// Token: 0x060025D5 RID: 9685 RVA: 0x000FD848 File Offset: 0x000FBA48
	public void Write(CSerializer cs)
	{
		cs.Write(this.m_iId);
		cs.Write(this.m_strName);
		for (int i = 0; i < 4; i++)
		{
			cs.Write(this.m_queValueType[i]);
			cs.Write(this.m_queValue[i]);
		}
		cs.Write(this.m_bShow);
		cs.Write(this.m_fTotalHitTime);
		cs.Write(this.m_fIntervalHitTime);
		cs.Write(this.m_bIsBuff);
		cs.Write(this.m_bIsMedicine);
		cs.Write(this.m_bOverlying);
		cs.Write(this.m_iMaxOverlyingNum);
		cs.Write(this.m_iReachNum);
		for (int j = 0; j < 3; j++)
		{
			cs.Write(this.m_queBones[j]);
			cs.Write(this.m_queEffects[j]);
			cs.Write(this.m_queDisEffects[j]);
		}
		cs.Write(this.m_strToolTip);
		cs.Write(this.m_strIconPath);
		cs.Write(this.m_iscriptModID);
		cs.Write(this.m_iscriptDataID);
		cs.Write(this.m_iscriptDataIDi);
	}

	// Token: 0x060025D6 RID: 9686 RVA: 0x000FD974 File Offset: 0x000FBB74
	public void TextRead(List<string> infoList, ref int index)
	{
		this.m_iId = Convert.ToInt32(infoList[index++]);
		this.m_strName = infoList[index++];
		for (int i = 0; i < 4; i++)
		{
			this.m_queValueType[i] = Convert.ToInt16(infoList[index++]);
			this.m_queValue[i] = Convert.ToInt32(infoList[index++]);
		}
		this.m_bShow = Convert.ToBoolean(infoList[index++]);
		this.m_fTotalHitTime = Convert.ToSingle(infoList[index++]);
		this.m_fIntervalHitTime = Convert.ToSingle(infoList[index++]);
		this.m_bIsBuff = Convert.ToBoolean(infoList[index++]);
		this.m_bIsMedicine = Convert.ToBoolean(infoList[index++]);
		this.m_bOverlying = Convert.ToBoolean(infoList[index++]);
		this.m_iMaxOverlyingNum = Convert.ToInt32(infoList[index++]);
		this.m_iReachNum = Convert.ToInt32(infoList[index++]);
		for (int j = 0; j < 3; j++)
		{
			this.m_queBones[j] = infoList[index++];
			float x = Convert.ToSingle(infoList[index++]);
			float y = Convert.ToSingle(infoList[index++]);
			float z = Convert.ToSingle(infoList[index++]);
			this.m_queOffsetPos[j] = new Vector3(x, y, z);
			x = Convert.ToSingle(infoList[index++]);
			y = Convert.ToSingle(infoList[index++]);
			z = Convert.ToSingle(infoList[index++]);
			this.m_queOffsetRotate[j] = new Vector3(x, y, z);
			this.m_queEffects[j] = Convert.ToInt32(infoList[index++]);
			this.m_queDisEffects[j] = Convert.ToInt32(infoList[index++]);
		}
		this.m_strToolTip = infoList[index++];
		this.m_strIconPath = infoList[index++];
		this.m_iscriptModID = Convert.ToInt32(infoList[index++]);
		this.m_iscriptDataID = Convert.ToInt32(infoList[index++]);
		this.m_iscriptDataIDi = Convert.ToInt32(infoList[index++]);
	}

	// Token: 0x04002263 RID: 8803
	private int m_iId;

	// Token: 0x04002264 RID: 8804
	private string m_strName;

	// Token: 0x04002265 RID: 8805
	private short[] m_queValueType = new short[4];

	// Token: 0x04002266 RID: 8806
	private int[] m_queValue = new int[4];

	// Token: 0x04002267 RID: 8807
	private bool m_bShow;

	// Token: 0x04002268 RID: 8808
	private float m_fTotalHitTime;

	// Token: 0x04002269 RID: 8809
	private float m_fIntervalHitTime;

	// Token: 0x0400226A RID: 8810
	private bool m_bIsBuff;

	// Token: 0x0400226B RID: 8811
	private bool m_bIsMedicine;

	// Token: 0x0400226C RID: 8812
	private bool m_bOverlying;

	// Token: 0x0400226D RID: 8813
	private int m_iMaxOverlyingNum;

	// Token: 0x0400226E RID: 8814
	private int m_iReachNum;

	// Token: 0x0400226F RID: 8815
	private string[] m_queBones = new string[3];

	// Token: 0x04002270 RID: 8816
	private Vector3[] m_queOffsetPos = new Vector3[3];

	// Token: 0x04002271 RID: 8817
	private Vector3[] m_queOffsetRotate = new Vector3[3];

	// Token: 0x04002272 RID: 8818
	private int[] m_queEffects = new int[3];

	// Token: 0x04002273 RID: 8819
	private int[] m_queDisEffects = new int[3];

	// Token: 0x04002274 RID: 8820
	private string m_strToolTip;

	// Token: 0x04002275 RID: 8821
	private string m_strIconPath;

	// Token: 0x04002276 RID: 8822
	private int m_iscriptModID;

	// Token: 0x04002277 RID: 8823
	private int m_iscriptDataID;

	// Token: 0x04002278 RID: 8824
	private int m_iscriptDataIDi;
}
