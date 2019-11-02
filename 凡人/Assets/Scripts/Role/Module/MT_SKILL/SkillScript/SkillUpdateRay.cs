using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;
using UnityUtility;


public class SkillUpdateRay : CSkillBase
{
    private const short SKILL_VALUE_COUNT = 1;

    private const short SKILL_STATUS_NONE = 0;

    private const short SKILL_STATUS_BEGIN = 1;

    private const short SKILL_STATUS_SHOOT_BEGIN = 2;

    private const short SKILL_STATUS_SHOOT_MIDDLE = 3;

    private const short SKILL_STATUS_SHOOT_END = 4;

    private const short SKILL_STATUS_END = 5;

    private int m_iAnimation;

    private float m_fAnimationSpeed;

    private string m_strReadyEffectPart;

    private int m_iReadyEffect;

    private float m_fBreakTime;

    private string m_strShootEffectPart;

    private float m_fOffsetTime;

    private Vector3 m_vecOffsetPos;

    private int m_iShootEffect;
    
    private int m_iBoomEffect;

    private float m_fSpeed;

    private int m_iBuffId;

    private int m_iAreaId;

    private int m_iFaetureId;

    private int m_iInitalId;

    private bool m_bIsOffsetTime;

    private bool m_bIsBreak;

    private int m_iNowEffectId;

    private Vector3 m_vecShootTarget;

    private GameObject Go;

    private FightCameraArea fca;

    public SkillUpdateRay()
	{
		this.m_sTargetType = 2;
		this.m_sRangeType = 3;
		this.m_sStopAnimateState = 4;
	}

	// Token: 0x06002B8C RID: 11148 RVA: 0x00148FF4 File Offset: 0x001471F4
	public SkillUpdateRay(SkillUpdateRay sur) : base(sur)
	{
		this.m_iAnimation = sur.m_iAnimation;
		this.m_fAnimationSpeed = sur.m_fAnimationSpeed;
		this.m_strReadyEffectPart = sur.m_strReadyEffectPart;
		this.m_fOffsetTime = sur.m_fOffsetTime;
		this.m_iReadyEffect = sur.m_iReadyEffect;
		this.m_fBreakTime = sur.m_fBreakTime;
		this.m_strShootEffectPart = sur.m_strShootEffectPart;
		this.m_vecOffsetPos = sur.m_vecOffsetPos;
		this.m_iShootEffect = sur.m_iShootEffect;
		this.m_iBoomEffect = sur.m_iBoomEffect;
		this.m_fSpeed = sur.m_fSpeed;
		this.m_iBuffId = sur.m_iBuffId;
		this.m_iAreaId = sur.m_iAreaId;
		this.m_iFaetureId = sur.m_iFaetureId;
		this.m_iInitalId = sur.m_iInitalId;
	}

	// Token: 0x06002B8D RID: 11149 RVA: 0x001490BC File Offset: 0x001472BC
	public override KeyValuePair<string, Type>[] GetRes()
	{
		List<KeyValuePair<string, Type>> list = new List<KeyValuePair<string, Type>>();
		if (base.GetRes() != null)
		{
			list.AddRange(base.GetRes());
		}
		//KeyValuePair<string, Type>[] effectResPath = UtilityRoleResource.GetEffectResPath(this.m_iReadyEffect);
		//if (effectResPath != null)
		//{
		//	list.AddRange(effectResPath);
		//}
		//KeyValuePair<string, Type>[] effectResPath2 = UtilityRoleResource.GetEffectResPath(this.m_iShootEffect);
		//if (effectResPath2 != null)
		//{
		//	list.AddRange(effectResPath2);
		//}
		//KeyValuePair<string, Type>[] effectResPath3 = UtilityRoleResource.GetEffectResPath(this.m_iBoomEffect);
		//if (effectResPath3 != null)
		//{
		//	list.AddRange(effectResPath3);
		//}
		//KeyValuePair<string, Type>[] effectResPath4 = UtilityRoleResource.GetEffectResPath(291);
		//if (effectResPath4 != null)
		//{
		//	list.AddRange(effectResPath4);
		//}
		//KeyValuePair<string, Type>[] effectResPath5 = UtilityRoleResource.GetEffectResPath(760);
		//if (effectResPath5 != null)
		//{
		//	list.AddRange(effectResPath5);
		//}
		return list.ToArray();
	}

	// Token: 0x06002B8E RID: 11150 RVA: 0x00149170 File Offset: 0x00147370
	public override void Write(CSerializer cs)
	{
		base.Write(cs);
		for (int i = 0; i < 1; i++)
		{
			cs.Write(this.m_lstValueScope[i]);
			//string value = UtilityFunction.AnalyticalIntValue(this.m_lstValue[i]);
			//cs.Write(value);
		}
		cs.Write(this.m_iAnimation);
		cs.Write(this.m_fAnimationSpeed);
		cs.Write(this.m_strReadyEffectPart);
		cs.Write(this.m_fOffsetTime);
		cs.Write(this.m_vecOffsetPos);
		cs.Write(this.m_iReadyEffect);
		cs.Write(this.m_fBreakTime);
		cs.Write(this.m_strShootEffectPart);
		cs.Write(this.m_iShootEffect);
		cs.Write(this.m_iBoomEffect);
		cs.Write(this.m_fSpeed);
		cs.Write(this.m_iBuffId);
		cs.Write(this.m_iAreaId);
		cs.Write(this.m_iFaetureId);
		cs.Write(this.m_iInitalId);
	}

	// Token: 0x06002B8F RID: 11151 RVA: 0x00149278 File Offset: 0x00147478
	public override void Read(CSerializer cs)
	{
		base.Read(cs);
		this.m_lstValue.Clear();
		this.m_lstValueScope.Clear();
		for (int i = 0; i < 1; i++)
		{
			this.m_lstValueScope.Add(cs.ReadFloat());
			string str = cs.ReadStr();
			//List<List<int>> list = UtilityFunction.AnalyticalStringValue(str);
			//if (list.Count > 0)
			//{
			//	this.m_lstValue.Add(list);
			//}
		}
		this.m_iAnimation = cs.ReadInt32();
		this.m_fAnimationSpeed = cs.ReadFloat();
		this.m_strReadyEffectPart = cs.ReadStr();
		this.m_fOffsetTime = cs.ReadFloat();
		this.m_vecOffsetPos = cs.ReadVector3();
		this.m_iReadyEffect = cs.ReadInt32();
		this.m_fBreakTime = cs.ReadFloat();
		this.m_strShootEffectPart = cs.ReadStr();
		this.m_iShootEffect = cs.ReadInt32();
		this.m_iBoomEffect = cs.ReadInt32();
		this.m_fSpeed = cs.ReadFloat();
		this.m_iBuffId = cs.ReadInt32();
		this.m_iAreaId = cs.ReadInt32();
		this.m_iFaetureId = cs.ReadInt32();
		this.m_iInitalId = cs.ReadInt32();
	}

	// Token: 0x06002B90 RID: 11152 RVA: 0x001493A0 File Offset: 0x001475A0
	public override void TextRead(List<string> infoList, ref int index)
	{
		base.TextRead(infoList, ref index);
		this.m_lstValue.Clear();
		this.m_lstValueScope.Clear();
		for (int i = 0; i < 1; i++)
		{
			this.m_lstValueScope.Add(Convert.ToSingle(infoList[index++]));
			string str = infoList[index++];
			//List<List<int>> list = UtilityFunction.AnalyticalStringValue(str);
			//if (list.Count > 0)
			//{
			//	this.m_lstValue.Add(list);
			//}
		}
		this.m_iAnimation = Convert.ToInt32(infoList[index++]);
		this.m_fAnimationSpeed = Convert.ToSingle(infoList[index++]);
		this.m_strReadyEffectPart = infoList[index++];
		this.m_fOffsetTime = Convert.ToSingle(infoList[index++]);
		float x = Convert.ToSingle(infoList[index++]);
		float y = Convert.ToSingle(infoList[index++]);
		float z = Convert.ToSingle(infoList[index++]);
		this.m_vecOffsetPos = new Vector3(x, y, z);
		this.m_iReadyEffect = Convert.ToInt32(infoList[index++]);
		this.m_fBreakTime = Convert.ToSingle(infoList[index++]);
		this.m_strShootEffectPart = infoList[index++];
		this.m_iShootEffect = Convert.ToInt32(infoList[index++]);
		this.m_iBoomEffect = Convert.ToInt32(infoList[index++]);
		this.m_fSpeed = Convert.ToSingle(infoList[index++]);
		this.m_iBuffId = Convert.ToInt32(infoList[index++]);
		this.m_iAreaId = Convert.ToInt32(infoList[index++]);
		this.m_iFaetureId = Convert.ToInt32(infoList[index++]);
		this.m_iInitalId = Convert.ToInt32(infoList[index++]);
	}

	// Token: 0x06002B91 RID: 11153 RVA: 0x00149608 File Offset: 0x00147808
	public override CSkillBase Clone()
	{
		return new SkillUpdateRay(this);
	}

	// Token: 0x06002B92 RID: 11154 RVA: 0x00149620 File Offset: 0x00147820
	public override void Init(Role sourceRole, Role targetRole, Vector3 targetPos)
	{
		base.Init(sourceRole, targetRole, targetPos);
		this.m_bIsBreak = false;
		this.m_bIsOffsetTime = false;
		this.m_iNowEffectId = 0;
	}

	// Token: 0x06002B93 RID: 11155 RVA: 0x00149640 File Offset: 0x00147840
	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		switch (this.m_sUpdateStatus)
		{
		case 1:
		{
			//this.fca = BroadcastManager.Instance.GetArea(this.m_iAreaId);
			if (this.fca != null)
			{
				//this.fca.ApplyFeature(this.m_iFaetureId, null);
			}
			else
			{
				Debug.LogWarning("*****can't find  Camera  AreaId");
			}
			Role cTargetRole = this.m_cTargetRole;
			if (cTargetRole != null)
			{
				Vector3 pos = cTargetRole.GetPos();
				pos.y = this.m_cSourceRole.GetPos().y;
				this.m_cSourceRole.GetTrans().LookAt(pos);
				this.m_vecShootTarget = cTargetRole.GetPos() + Vector3.up * 0.5f;
			}
			else
			{
				this.m_vecShootTarget = Vector3.zero;
			}
			this.m_sUpdateStatus += 1;
			break;
		}
		case 2:
			if (this.m_cSourceRole != null)
			{
				ModAnimation modAnimation = (ModAnimation)this.m_cSourceRole.GetModule(MODULE_TYPE.MT_MOTION);
				modAnimation.PlayAnimation((ACTION_INDEX)this.m_iAnimation, this.m_fAnimationSpeed);
			}
			this.m_fCreateTime = GameTime.time;
			this.m_sUpdateStatus += 1;
			break;
		case 3:
		{
			ModAnimation modAnimation2 = (ModAnimation)this.m_cSourceRole.GetModule(MODULE_TYPE.MT_MOTION);
			float num = GameTime.time - this.m_fCreateTime;
			if (num >= this.m_fOffsetTime && !this.m_bIsOffsetTime)
			{
				this.m_bIsOffsetTime = true;
				CEffectData effectInfo = Singleton<EffectTableManager>.GetInstance().GetEffectInfo(this.m_iReadyEffect);
				if (this.m_iReadyEffect != 0)
				{
					if (effectInfo.Type == 2)
					{
						GameObject gameObject = base.GetMeshObjByBone(this.m_cSourceRole, this.m_strReadyEffectPart).gameObject;
						this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectBind(this.m_iReadyEffect, gameObject);
						Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId).transform.Translate(this.m_vecOffsetPos);
					}
					else
					{
						this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectFixure(this.m_iReadyEffect, this.m_cSourceRole.GetPos(), this.m_cSourceRole.GetTrans().rotation);
					}
				}
			}
			if (GameTime.time - this.m_fCreateTime > this.m_fBreakTime && !this.m_bIsBreak)
			{
				this.m_bIsBreak = true;
				SingletonMono<EffectManager>.GetInstance().Delete(this.m_iNowEffectId);
				CEffectData effectInfo2 = Singleton<EffectTableManager>.GetInstance().GetEffectInfo(this.m_iShootEffect);
				if (effectInfo2 != null && effectInfo2.Type == 4)
				{
					Vector3 meshPosByBone = base.GetMeshPosByBone(this.m_cSourceRole, this.m_strShootEffectPart);
					Role cTargetRole2 = this.m_cTargetRole;
					if (cTargetRole2 != null)
					{
						Vector3 forward = this.m_vecShootTarget - meshPosByBone;
						this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectRay(this.m_iShootEffect, meshPosByBone, Quaternion.LookRotation(forward), Vector3.forward * this.m_fSpeed);
					}
					else
					{
						this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectRay(this.m_iShootEffect, meshPosByBone, this.m_cSourceRole.GetTrans().rotation, Vector3.forward * this.m_fSpeed);
					}
					//Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId).GetComponent<EffectRadial>().SetCallBackFun(new Callback<int, GameObject, ContactPoint[]>(this.EffCollisionEnter));
					//if (base.ID == 210)
					//{
					//	Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId).AddComponent<KeepFloatOnGround>();
					//}
					Collider component = Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId).GetComponent<Collider>();
					//List<Role> allyRole = SceneManager.RoleMan.GetAllyRole(this.m_cSourceRole);
					if (this.m_cSourceRole.GetTrans().GetComponent<Collider>() != null && this.m_cSourceRole.GetTrans().GetComponent<Collider>().enabled && this.m_cSourceRole.GetTrans().gameObject.activeSelf)
					{
						Physics.IgnoreCollision(component, this.m_cSourceRole.GetTrans().GetComponent<Collider>());
						//foreach (Role role in allyRole)
						//{
						//	Collider component2 = role.GetTrans().GetComponent<Collider>();
						//	if (component2 != null && component2.enabled && role.GetTrans().gameObject.activeSelf)
						//	{
						//		Physics.IgnoreCollision(component, component2);
						//	}
						//}
					}
				}
				else
				{
					Debug.LogError("The Effect type is Error or there is no Effect." + effectInfo2.Name);
				}
			}
			//if (!modAnimation2.IsPlaying((ACTION_INDEX)this.m_iAnimation) && this.m_bIsBreak)
			//{
			//	if (this.fca != null)
			//	{
			//		this.fca.ApplyFeature(this.m_iInitalId, null);
			//	}
			//	else
			//	{
			//		Debug.LogWarning("** FightCameraArea  is  Null**");
			//	}
			//	this.m_sUpdateStatus += 1;
			//}
			break;
		}
		case 4:
			this.m_sUpdateStatus += 1;
			break;
		case 5:
			return false;
		}
		return true;
	}

	private void EffCollisionEnter(int id, GameObject go, ContactPoint[] contactPoints)
	{
		SingletonMono<EffectManager>.GetInstance().Delete(id);
		if (this.m_cSourceRole.IsDead())
		{
			return;
		}
		//Role roleScriptFromGo = RoleBaseFun.GetRoleScriptFromGo(go);
		//if (roleScriptFromGo == null)
		//{
		//	if (base.ID == 220)
		//	{
		//		SingletonMono<EffectManager>.GetInstance().AddEffectFixure(760, contactPoints[0].point, this.m_cSourceRole.GetTrans().rotation);
		//	}
		//	else
		//	{
		//		SingletonMono<EffectManager>.GetInstance().AddEffectFixure(this.m_iBoomEffect, contactPoints[0].point, this.m_cSourceRole.GetTrans().rotation);
		//	}
		//}
		//else if (roleScriptFromGo._roleType != this.m_cSourceRole._roleType)
		//{
		//	base.CalculationValue(0, this.m_cSourceRole, roleScriptFromGo, contactPoints[0].point);
		//	if (this.m_iBuffId != 0)
		//	{
		//		ModBuffProperty modBuffProperty = (ModBuffProperty)roleScriptFromGo.GetModule(MODULE_TYPE.MT_BUFF);
		//		if (modBuffProperty != null)
		//		{
		//			modBuffProperty.AddBuff(this.m_iBuffId);
		//		}
		//	}
		//	if (base.ID == 211 || base.ID == 210)
		//	{
		//		GameObject gameObject = base.GetMeshObjByBone(roleScriptFromGo, "MobMesh/Bip001").gameObject;
		//		SingletonMono<EffectManager>.GetInstance().AddEffectBind(291, gameObject);
		//	}
		//	if (base.ID == 220)
		//	{
		//		GameObject gameObject2 = base.GetMeshObjByBone(roleScriptFromGo, "Bip01").gameObject;
		//		SingletonMono<EffectManager>.GetInstance().AddEffectBind(310, gameObject2);
		//	}
		//	else
		//	{
		//		SingletonMono<EffectManager>.GetInstance().AddEffectFixure(this.m_iBoomEffect, contactPoints[0].point, this.m_cSourceRole.GetTrans().rotation);
		//	}
		//}
	}

	public override void Destory()
	{
		base.Destory();
	}
}
