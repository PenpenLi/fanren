using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;
using UnityUtility;

/// <summary>
/// 技能基类
/// </summary>
public class CSkillBase
{
    protected int m_iTypeId;

    protected string m_strName;

    protected short m_sSkillType;

    protected short m_sTargetType;

    protected short m_sRangeType;

    protected short m_sStopAnimateState;

    protected float m_fSpellTime;

    protected float m_fCoolTime;

    protected short m_sDamageType;

    protected float m_fDistance;

    protected List<float> m_lstValueScope = new List<float>();

    protected List<List<List<int>>> m_lstValue = new List<List<List<int>>>();

    protected float m_fMpValue;

    protected short m_sHateType;

    protected float m_fHateValue;

    protected string m_strIconFile;

    protected string m_strToolTip;

    protected string m_strVideoFile;

    protected int[] m_queInfluenceID = new int[1];

    protected float m_fHForce;

    protected float m_fVForce;

    protected int m_iSkillHitID;

    protected Role m_cSourceRole;

    protected Role m_cTargetRole;

    protected Vector3 m_vecTargetPos;

    protected float m_fCreateTime;

    protected short m_sUpdateStatus;

    protected List<int> m_lstNowEffects = new List<int>();

    protected bool m_bCanChangeState;

    private static bool m_bStopLoop = false;

    protected bool isAnimationOver;

    private static bool m_bBossStopLoop = false;

    public static List<Role> SJMonsters = new List<Role>();

    public CSkillBase()
	{
		this.m_sSkillType = 2;
	}

	public CSkillBase(CSkillBase csb)
	{
		this.m_iTypeId = csb.m_iTypeId;
		this.m_strName = csb.m_strName;
		this.m_sSkillType = csb.m_sSkillType;
		this.m_sTargetType = csb.m_sTargetType;
		this.m_sRangeType = csb.m_sRangeType;
		this.m_sStopAnimateState = csb.m_sStopAnimateState;
		this.m_fSpellTime = csb.m_fSpellTime;
		this.m_fCoolTime = csb.m_fCoolTime;
		this.m_sDamageType = csb.m_sDamageType;
		this.m_fDistance = csb.m_fDistance;
		this.m_lstValueScope.Clear();
		this.m_lstValue.Clear();
		for (int i = 0; i < csb.m_lstValue.Count; i++)
		{
			this.m_lstValueScope.Add(csb.m_lstValueScope[i]);
			this.m_lstValue.Add(csb.m_lstValue[i]);
		}
		this.m_fMpValue = csb.m_fMpValue;
		this.m_sHateType = csb.m_sHateType;
		this.m_fHateValue = csb.m_fHateValue;
		this.m_strIconFile = csb.m_strIconFile;
		this.m_strToolTip = csb.m_strToolTip;
		this.m_strVideoFile = csb.m_strVideoFile;
		for (int j = 0; j < this.m_queInfluenceID.Length; j++)
		{
			this.m_queInfluenceID[j] = csb.m_queInfluenceID[j];
		}
		this.m_fHForce = csb.m_fHForce;
		this.m_fVForce = csb.m_fVForce;
		this.m_iSkillHitID = csb.m_iSkillHitID;
	}

	public string VideoFile
	{
		get
		{
			return this.m_strVideoFile;
		}
	}

	public int InfluenceId
	{
		get
		{
			return this.m_queInfluenceID[0];
		}
	}

	public int GetInfluenceId(int index)
	{
		if (index < 0 || index >= this.m_queInfluenceID.Length)
		{
			return 0;
		}
		return this.m_queInfluenceID[index];
	}

	public float HForce
	{
		get
		{
			return this.m_fHForce;
		}
	}

	public float VForce
	{
		get
		{
			return this.m_fVForce;
		}
	}

	public int SkillHitID
	{
		get
		{
			return this.m_iSkillHitID;
		}
	}

	public virtual KeyValuePair<string, Type>[] GetRes()
	{
		return null;
	}

	public virtual CSkillBase Clone()
	{
		return new CSkillBase(this);
	}

	public virtual void Write(CSerializer cs)
	{
		cs.Write(this.m_iTypeId);
		cs.Write(this.m_strName);
		cs.Write(this.m_sSkillType);
		cs.Write(this.m_sTargetType);
		cs.Write(this.m_sStopAnimateState);
		cs.Write(this.m_sRangeType);
		cs.Write(this.m_fSpellTime);
		cs.Write(this.m_fCoolTime);
		cs.Write(this.m_sDamageType);
		cs.Write(this.m_fDistance);
		cs.Write(this.m_fMpValue);
		cs.Write(this.m_sHateType);
		cs.Write(this.m_fHateValue);
		cs.Write(this.m_strIconFile);
		cs.Write(this.m_strToolTip);
		cs.Write(this.m_strVideoFile);
		for (int i = 0; i < this.m_queInfluenceID.Length; i++)
		{
			cs.Write(this.m_queInfluenceID[i]);
		}
		cs.Write(this.m_fHForce);
		cs.Write(this.m_fVForce);
		cs.Write(this.m_iSkillHitID);
	}

	public virtual void Read(CSerializer cs)
	{
		this.m_iTypeId = cs.ReadInt32();
		this.m_strName = cs.ReadStr();
		this.m_sSkillType = cs.ReadInt16();
		this.m_sTargetType = cs.ReadInt16();
		this.m_sStopAnimateState = cs.ReadInt16();
		this.m_sRangeType = cs.ReadInt16();
		this.m_fSpellTime = cs.ReadFloat();
		this.m_fCoolTime = cs.ReadFloat();
		this.m_sDamageType = cs.ReadInt16();
		this.m_fDistance = cs.ReadFloat();
		this.m_fMpValue = cs.ReadFloat();
		this.m_sHateType = cs.ReadInt16();
		this.m_fHateValue = cs.ReadFloat();
		this.m_strIconFile = cs.ReadStr();
		this.m_strToolTip = cs.ReadStr();
		this.m_strVideoFile = cs.ReadStr();
		for (int i = 0; i < this.m_queInfluenceID.Length; i++)
		{
			this.m_queInfluenceID[i] = cs.ReadInt32();
		}
		this.m_fHForce = cs.ReadFloat();
		this.m_fVForce = cs.ReadFloat();
		this.m_iSkillHitID = cs.ReadInt32();
	}

	public virtual void TextRead(List<string> infoList, ref int index)
	{
		this.m_iTypeId = Convert.ToInt32(infoList[index++]);
		this.m_strName = new string(infoList[index++].ToCharArray());
		this.m_sSkillType = Convert.ToInt16(infoList[index++]);
		this.m_sTargetType = Convert.ToInt16(infoList[index++]);
		this.m_sStopAnimateState = Convert.ToInt16(infoList[index++]);
		this.m_sRangeType = Convert.ToInt16(infoList[index++]);
		this.m_fSpellTime = Convert.ToSingle(infoList[index++]);
		this.m_fCoolTime = Convert.ToSingle(infoList[index++]);
		this.m_sDamageType = Convert.ToInt16(infoList[index++]);
		this.m_fDistance = Convert.ToSingle(infoList[index++]);
		this.m_fMpValue = Convert.ToSingle(infoList[index++]);
		this.m_sHateType = Convert.ToInt16(infoList[index++]);
		this.m_fHateValue = Convert.ToSingle(infoList[index++]);
		this.m_strIconFile = new string(infoList[index++].ToCharArray());
		this.m_strToolTip = new string(infoList[index++].ToCharArray());
		this.m_strVideoFile = infoList[index++];
		for (int i = 0; i < this.m_queInfluenceID.Length; i++)
		{
			this.m_queInfluenceID[i] = Convert.ToInt32(infoList[index++]);
		}
		this.m_fHForce = Convert.ToSingle(infoList[index++]);
		this.m_fVForce = Convert.ToSingle(infoList[index++]);
		this.m_iSkillHitID = Convert.ToInt32(infoList[index++]);
	}

	public int ID
	{
		get
		{
			return this.m_iTypeId;
		}
	}

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x060025CB RID: 9675 RVA: 0x00102580 File Offset: 0x00100780
	public string Name
	{
		get
		{
			return this.m_strName;
		}
	}

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x060025CC RID: 9676 RVA: 0x00102588 File Offset: 0x00100788
	public short SkillType
	{
		get
		{
			return this.m_sSkillType;
		}
	}

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x060025CD RID: 9677 RVA: 0x00102590 File Offset: 0x00100790
	public short TargetType
	{
		get
		{
			return this.m_sTargetType;
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x060025CE RID: 9678 RVA: 0x00102598 File Offset: 0x00100798
	public short RangeType
	{
		get
		{
			return this.m_sRangeType;
		}
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x060025CF RID: 9679 RVA: 0x001025A0 File Offset: 0x001007A0
	public short StopAnimateState
	{
		get
		{
			return this.m_sStopAnimateState;
		}
	}

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x060025D0 RID: 9680 RVA: 0x001025A8 File Offset: 0x001007A8
	public float SpellTime
	{
		get
		{
			return this.m_fSpellTime;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x060025D1 RID: 9681 RVA: 0x001025B0 File Offset: 0x001007B0
	public float CoolTime
	{
		get
		{
			return this.m_fCoolTime;
		}
	}

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x060025D2 RID: 9682 RVA: 0x001025B8 File Offset: 0x001007B8
	public float Distance
	{
		get
		{
			return this.m_fDistance;
		}
	}

	// Token: 0x060025D3 RID: 9683 RVA: 0x001025C0 File Offset: 0x001007C0
	public float GetScope(int index)
	{
		if (index >= 0 && index < this.m_lstValueScope.Count)
		{
			return this.m_lstValueScope[index];
		}
		Debug.LogError("Out of Range.");
		return 0f;
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x060025D4 RID: 9684 RVA: 0x00102604 File Offset: 0x00100804
	public float MpValue
	{
		get
		{
			return this.m_fMpValue;
		}
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x060025D5 RID: 9685 RVA: 0x0010260C File Offset: 0x0010080C
	public short HateType
	{
		get
		{
			return this.m_sHateType;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x060025D6 RID: 9686 RVA: 0x00102614 File Offset: 0x00100814
	public float HateValue
	{
		get
		{
			return this.m_fHateValue;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x060025D7 RID: 9687 RVA: 0x0010261C File Offset: 0x0010081C
	public string Icon
	{
		get
		{
			return this.m_strIconFile;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x060025D8 RID: 9688 RVA: 0x00102624 File Offset: 0x00100824
	public string ToolTip
	{
		get
		{
			return this.m_strToolTip;
		}
	}

	// Token: 0x060025D9 RID: 9689 RVA: 0x0010262C File Offset: 0x0010082C
	public List<List<int>> GetValue(int index)
	{
		if (index >= 0 && index < this.m_lstValue.Count)
		{
			return this.m_lstValue[index];
		}
		Debug.LogError("The index exceed the total number");
		return null;
	}

	// Token: 0x060025DA RID: 9690 RVA: 0x0010266C File Offset: 0x0010086C
	public List<int> GetBuffValue()
	{
		List<int> list = new List<int>();
		foreach (List<List<int>> list2 in this.m_lstValue)
		{
			foreach (List<int> list3 in list2)
			{
				if (list3[0] == 6)
				{
					list.Add(list3[1]);
				}
			}
		}
		return list;
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x060025DB RID: 9691 RVA: 0x00102738 File Offset: 0x00100938
	// (set) Token: 0x060025DC RID: 9692 RVA: 0x00102740 File Offset: 0x00100940
	public static bool StopLoop
	{
		get
		{
			return CSkillBase.m_bStopLoop;
		}
		set
		{
			CSkillBase.m_bStopLoop = value;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x060025DD RID: 9693 RVA: 0x00102748 File Offset: 0x00100948
	// (set) Token: 0x060025DE RID: 9694 RVA: 0x00102750 File Offset: 0x00100950
	public static bool BossStopLoop
	{
		get
		{
			return CSkillBase.m_bBossStopLoop;
		}
		set
		{
			CSkillBase.m_bBossStopLoop = value;
		}
	}

	// Token: 0x060025DF RID: 9695 RVA: 0x00102758 File Offset: 0x00100958
	public virtual void Init(Role sourceRole, Role targetRole, Vector3 targetPos)
	{
		this.m_fCreateTime = GameTime.time;
		this.m_sUpdateStatus = 1;
		this.m_bCanChangeState = false;
		this.m_cSourceRole = sourceRole;
		this.m_cTargetRole = targetRole;
		this.m_vecTargetPos = targetPos;
	}

	// Token: 0x060025E0 RID: 9696 RVA: 0x00102794 File Offset: 0x00100994
	protected void JudgeStopAnimateState()
	{
		if (this.m_sUpdateStatus >= this.StopAnimateState)
		{
			this.m_bCanChangeState = true;
		}
	}

	// Token: 0x060025E1 RID: 9697 RVA: 0x001027B0 File Offset: 0x001009B0
	public bool CanChangeState()
	{
		return this.isAnimationOver || this.m_bCanChangeState;
	}

	// Token: 0x060025E2 RID: 9698 RVA: 0x001027C8 File Offset: 0x001009C8
	public int GetUpdateStatus()
	{
		return (int)this.m_sUpdateStatus;
	}

	// Token: 0x060025E3 RID: 9699 RVA: 0x001027D0 File Offset: 0x001009D0
	public virtual bool Update()
	{
		this.JudgeStopAnimateState();
		return true;
	}

	// Token: 0x060025E4 RID: 9700 RVA: 0x001027DC File Offset: 0x001009DC
	public virtual void Destory()
	{
		this.m_sUpdateStatus = 23;
		foreach (int num in this.m_lstNowEffects)
		{
			if (num != 0)
			{
				SingletonMono<EffectManager>.GetInstance().Delete(num);
			}
		}
	}

	// Token: 0x060025E5 RID: 9701 RVA: 0x00102854 File Offset: 0x00100A54
	protected Vector3 GetMeshPosByBone(Role role, string bone)
	{
		if (role == null)
		{
			return Vector3.zero;
		}
		Transform transform = role.GetTrans().FindChild(bone);
		if (transform == null)
		{
			return Vector3.zero;
		}
		return transform.position;
	}

	// Token: 0x060025E6 RID: 9702 RVA: 0x00102894 File Offset: 0x00100A94
	protected Transform GetMeshObjByBone(Role role, string bone)
	{
		if (role == null)
		{
			return null;
		}
		Transform transform = role.GetTrans().FindChild(bone);
		if (transform == null)
		{
			return role.GetTrans();
		}
		return transform;
	}

	// Token: 0x060025E7 RID: 9703 RVA: 0x001028CC File Offset: 0x00100ACC
	//protected void CalculationValue(int index, Role sourceRole, Role targetRole, Vector3 targetPos)
	//{
	//	List<Role> list = new List<Role>();
	//	List<List<int>> value = this.GetValue(index);
	//	for (int i = 0; i < value.Count; i++)
	//	{
	//		short num = (short)value[i][0];
	//		List<int> list2 = new List<int>();
	//		for (int j = 1; j < value[i].Count; j++)
	//		{
	//			list2.Add(value[i][j]);
	//		}
	//		list.Clear();
	//		switch (this.RangeType)
	//		{
	//		case 1:
	//			if (sourceRole == null)
	//			{
	//				Debug.LogError("Source Role Error");
	//			}
	//			else
	//			{
	//				switch (num)
	//				{
	//				case 5:
	//				{
	//					ModFight modFight = (ModFight)sourceRole.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = 2,
	//						attackPoint = targetPos,
	//						screenShakeID = 1,
	//						timeScaleID = 1,
	//						skillID = this.ID,
	//						attackForce = new Vector3(0f, this.m_fVForce, this.m_fHForce)
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//					break;
	//				}
	//				case 6:
	//				{
	//					ModBuffProperty modBuffProperty = (ModBuffProperty)sourceRole.GetModule(MODULE_TYPE.MT_BUFF);
	//					modBuffProperty.AddBuff(list2[0]);
	//					break;
	//				}
	//				case 7:
	//				{
	//					ModFight modFight2 = (ModFight)sourceRole.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight2.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = 0f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						_percentDamage = (float)list2[0] / 100f * -1f
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//					break;
	//				}
	//				case 8:
	//					for (int k = 0; k < list2[1]; k++)
	//					{
	//						if (this.m_sTargetType == 1)
	//						{
	//							Vector3 randomPosInRadius = RoleBaseFun.GetRandomPosInRadius(sourceRole.GetPos(), (float)list2[2]);
	//							SDM_SpawnMonster.SD_SpawnMonster agrs = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//							GameData.Instance.ScrMan.Exec(12, agrs);
	//						}
	//						else if (this.m_sTargetType == 2)
	//						{
	//							Vector3 randomPosInRadius2 = RoleBaseFun.GetRandomPosInRadius(targetRole.GetPos(), (float)list2[2]);
	//							SDM_SpawnMonster.SD_SpawnMonster agrs2 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius2, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//							GameData.Instance.ScrMan.Exec(12, agrs2);
	//						}
	//					}
	//					break;
	//				case 9:
	//				{
	//					ModFight modFight3 = (ModFight)sourceRole.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight3.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[1] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = list2[0]
	//					}, ACTION_INDEX.AN_NONE);
	//					break;
	//				}
	//				case 10:
	//				{
	//					ModFight modFight4 = (ModFight)sourceRole.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight4.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType
	//					});
	//					break;
	//				}
	//				}
	//				list.Add(sourceRole);
	//			}
	//			break;
	//		case 2:
	//			if (targetRole == null)
	//			{
	//				Debug.LogError("Target Role Error");
	//			}
	//			else
	//			{
	//				switch (num)
	//				{
	//				case 5:
	//					if (targetRole == null)
	//					{
	//						Debug.LogError("Target Role Error");
	//					}
	//					else
	//					{
	//						ModFight modFight5 = (ModFight)targetRole.GetModule(MODULE_TYPE.MT_FIGHT);
	//						modFight5.Hurt(new FightInfo
	//						{
	//							_role = sourceRole,
	//							_damage = (float)list2[0] * -1f,
	//							_fightType = (FightInfo.FightType)this.m_sDamageType,
	//							hurtBev = 2,
	//							attackPoint = targetPos,
	//							screenShakeID = 1,
	//							timeScaleID = 1,
	//							skillID = this.ID,
	//							attackForce = new Vector3(0f, this.m_fVForce, this.m_fHForce)
	//						}, ACTION_INDEX.AN_BEATTACK_0);
	//					}
	//					break;
	//				case 6:
	//				{
	//					ModBuffProperty modBuffProperty2 = (ModBuffProperty)targetRole.GetModule(MODULE_TYPE.MT_BUFF);
	//					modBuffProperty2.AddBuff(list2[0]);
	//					break;
	//				}
	//				case 7:
	//				{
	//					ModFight modFight6 = (ModFight)targetRole.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight6.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = 0f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						_percentDamage = (float)list2[0] / 100f * -1f
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//					break;
	//				}
	//				case 8:
	//					for (int l = 0; l < list2[1]; l++)
	//					{
	//						if (this.m_sTargetType == 1)
	//						{
	//							Vector3 randomPosInRadius3 = RoleBaseFun.GetRandomPosInRadius(sourceRole.GetPos(), (float)list2[2]);
	//							SDM_SpawnMonster.SD_SpawnMonster agrs3 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius3, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//							GameData.Instance.ScrMan.Exec(12, agrs3);
	//						}
	//						else if (this.m_sTargetType == 2)
	//						{
	//							Vector3 randomPosInRadius4 = RoleBaseFun.GetRandomPosInRadius(targetRole.GetPos(), (float)list2[2]);
	//							SDM_SpawnMonster.SD_SpawnMonster agrs4 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius4, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//							GameData.Instance.ScrMan.Exec(12, agrs4);
	//						}
	//					}
	//					break;
	//				case 9:
	//				{
	//					ModFight modFight7 = (ModFight)targetRole.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight7.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[1] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = this.SkillHitID
	//					}, ACTION_INDEX.AN_NONE);
	//					break;
	//				}
	//				case 10:
	//				{
	//					ModFight modFight8 = (ModFight)targetRole.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight8.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = this.SkillHitID
	//					});
	//					break;
	//				}
	//				}
	//				list.Add(targetRole);
	//			}
	//			break;
	//		case 3:
	//			list = SceneManager.RoleMan.GetNearestEnmitys(sourceRole, targetPos, this.GetScope(index));
	//			switch (num)
	//			{
	//			case 5:
	//				foreach (Role role in list)
	//				{
	//					ModFight modFight9 = (ModFight)role.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight9.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = 3,
	//						attackPoint = targetPos,
	//						screenShakeID = 1,
	//						timeScaleID = 1,
	//						skillID = this.ID,
	//						attackForce = new Vector3(0f, this.m_fVForce, this.m_fHForce)
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//				}
	//				break;
	//			case 6:
	//				foreach (Role role2 in list)
	//				{
	//					ModBuffProperty modBuffProperty3 = (ModBuffProperty)role2.GetModule(MODULE_TYPE.MT_BUFF);
	//					modBuffProperty3.AddBuff(list2[0]);
	//				}
	//				break;
	//			case 7:
	//				foreach (Role role3 in list)
	//				{
	//					ModFight modFight10 = (ModFight)role3.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight10.Hurt(new FightInfo
	//					{
	//						_role = role3,
	//						_damage = 0f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						_percentDamage = (float)list2[0] / 100f * -1f
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//				}
	//				break;
	//			case 8:
	//				for (int m = 0; m < list2[1]; m++)
	//				{
	//					if (this.m_sTargetType == 1)
	//					{
	//						Vector3 randomPosInRadius5 = RoleBaseFun.GetRandomPosInRadius(sourceRole.GetPos(), (float)list2[2]);
	//						SDM_SpawnMonster.SD_SpawnMonster agrs5 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius5, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//						GameData.Instance.ScrMan.Exec(12, agrs5);
	//					}
	//					else if (this.m_sTargetType == 2)
	//					{
	//						Vector3 randomPosInRadius6 = RoleBaseFun.GetRandomPosInRadius(targetRole.GetPos(), (float)list2[2]);
	//						SDM_SpawnMonster.SD_SpawnMonster agrs6 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius6, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//						GameData.Instance.ScrMan.Exec(12, agrs6);
	//					}
	//				}
	//				break;
	//			case 9:
	//				foreach (Role role4 in list)
	//				{
	//					ModFight modFight11 = (ModFight)role4.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight11.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[1] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = list2[0]
	//					}, ACTION_INDEX.AN_NONE);
	//				}
	//				break;
	//			case 10:
	//				foreach (Role role5 in list)
	//				{
	//					ModFight modFight12 = (ModFight)role5.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight12.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType
	//					});
	//				}
	//				break;
	//			}
	//			break;
	//		case 6:
	//			list = SceneManager.RoleMan.GetNearestEnmitys(sourceRole, sourceRole.GetPos(), this.GetScope(index));
	//			switch (num)
	//			{
	//			case 5:
	//				foreach (Role role6 in list)
	//				{
	//					ModFight modFight13 = (ModFight)role6.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight13.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = 3,
	//						attackPoint = targetPos,
	//						screenShakeID = 1,
	//						timeScaleID = 1,
	//						skillID = this.ID,
	//						attackForce = new Vector3(0f, this.m_fVForce, this.m_fHForce)
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//				}
	//				break;
	//			case 6:
	//				foreach (Role role7 in list)
	//				{
	//					ModBuffProperty modBuffProperty4 = (ModBuffProperty)role7.GetModule(MODULE_TYPE.MT_BUFF);
	//					modBuffProperty4.AddBuff(list2[0]);
	//				}
	//				break;
	//			case 7:
	//				foreach (Role role8 in list)
	//				{
	//					ModFight modFight14 = (ModFight)role8.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight14.Hurt(new FightInfo
	//					{
	//						_role = role8,
	//						_damage = 0f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						_percentDamage = (float)list2[0] / 100f * -1f
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//				}
	//				break;
	//			case 8:
	//				for (int n = 0; n < list2[1]; n++)
	//				{
	//					if (this.m_sTargetType == 1)
	//					{
	//						Vector3 randomPosInRadius7 = RoleBaseFun.GetRandomPosInRadius(sourceRole.GetPos(), (float)list2[2]);
	//						SDM_SpawnMonster.SD_SpawnMonster agrs7 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius7, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//						GameData.Instance.ScrMan.Exec(12, agrs7);
	//					}
	//					else if (this.m_sTargetType == 2)
	//					{
	//						Vector3 randomPosInRadius8 = RoleBaseFun.GetRandomPosInRadius(targetRole.GetPos(), (float)list2[2]);
	//						SDM_SpawnMonster.SD_SpawnMonster agrs8 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius8, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//						GameData.Instance.ScrMan.Exec(12, agrs8);
	//					}
	//				}
	//				break;
	//			case 9:
	//				foreach (Role role9 in list)
	//				{
	//					ModFight modFight15 = (ModFight)role9.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight15.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[1] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = list2[0]
	//					}, ACTION_INDEX.AN_NONE);
	//				}
	//				break;
	//			case 10:
	//				foreach (Role role10 in list)
	//				{
	//					ModFight modFight16 = (ModFight)role10.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight16.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType
	//					});
	//				}
	//				break;
	//			}
	//			break;
	//		case 7:
	//			list = SceneManager.RoleMan.GetNearestParty(sourceRole, sourceRole.GetPos(), this.GetScope(index));
	//			switch (num)
	//			{
	//			case 5:
	//				foreach (Role role11 in list)
	//				{
	//					ModFight modFight17 = (ModFight)role11.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight17.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = 2,
	//						attackPoint = targetPos,
	//						screenShakeID = 1,
	//						timeScaleID = 1,
	//						skillID = this.ID,
	//						attackForce = new Vector3(0f, this.m_fVForce, this.m_fHForce)
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//				}
	//				break;
	//			case 6:
	//				foreach (Role role12 in list)
	//				{
	//					ModBuffProperty modBuffProperty5 = (ModBuffProperty)role12.GetModule(MODULE_TYPE.MT_BUFF);
	//					modBuffProperty5.AddBuff(list2[0]);
	//				}
	//				break;
	//			case 7:
	//				foreach (Role role13 in list)
	//				{
	//					ModFight modFight18 = (ModFight)role13.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight18.Hurt(new FightInfo
	//					{
	//						_role = role13,
	//						_damage = 0f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						_percentDamage = (float)list2[0] / 100f * -1f
	//					}, ACTION_INDEX.AN_BEATTACK_0);
	//				}
	//				break;
	//			case 8:
	//				for (int num2 = 0; num2 < list2[1]; num2++)
	//				{
	//					if (this.m_sTargetType == 1)
	//					{
	//						Vector3 randomPosInRadius9 = RoleBaseFun.GetRandomPosInRadius(sourceRole.GetPos(), (float)list2[2]);
	//						SDM_SpawnMonster.SD_SpawnMonster agrs9 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius9, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//						GameData.Instance.ScrMan.Exec(12, agrs9);
	//					}
	//					else if (this.m_sTargetType == 2)
	//					{
	//						Vector3 randomPosInRadius10 = RoleBaseFun.GetRandomPosInRadius(targetRole.GetPos(), (float)list2[2]);
	//						SDM_SpawnMonster.SD_SpawnMonster agrs10 = SDM_SpawnMonster.CreateSpawnData(list2[0], randomPosInRadius10, sourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, sourceRole.SpawnInfo.areaName, sourceRole);
	//						GameData.Instance.ScrMan.Exec(12, agrs10);
	//					}
	//				}
	//				break;
	//			case 9:
	//				foreach (Role role14 in list)
	//				{
	//					ModFight modFight19 = (ModFight)role14.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight19.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[1] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType,
	//						hurtBev = list2[0]
	//					}, ACTION_INDEX.AN_NONE);
	//				}
	//				break;
	//			case 10:
	//				foreach (Role role15 in list)
	//				{
	//					ModFight modFight20 = (ModFight)role15.GetModule(MODULE_TYPE.MT_FIGHT);
	//					modFight20.Hurt(new FightInfo
	//					{
	//						_role = sourceRole,
	//						_damage = (float)list2[0] * -1f,
	//						_fightType = (FightInfo.FightType)this.m_sDamageType
	//					});
	//				}
	//				break;
	//			}
	//			break;
	//		}
	//	}
	//}

	private bool IsActorDead()
	{
		return false;
	}
}
