using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;
using UnityUtility;

public class SkillUpdateHZC : CSkillBase
{
    private const short SKILL_VALUE_COUNT = 1;

    private const short SKILL_STATUS_NONE = 0;

    private const short SKILL_STATUS_BEGIN = 1;

    private const short SKILL_STATUS_SHOOT_BEGIN = 2;

    private const short SKILL_STATUS_SHOOT_MIDDLE = 3;

    private const short SKILL_STATUS_SHOOT_END = 4;

    private const short SKILL_STATUS_END = 5;

    private int m_iAnimation;

    private int m_iEffectId;

    private float m_fBreakTime;

    private int m_iMonsterId;

    private int m_iMonsterAppearEff;

    private float m_fRadius;

    private int m_iCount;

    private float m_fCTime;

    private List<Vector3> m_lisPos = new List<Vector3>();

    private bool m_bIsCall;

    private int m_iNowEffectId;

    private List<Vector3> nodes = new List<Vector3>();

    private Vector3[] pathNotes;

    private List<Vector3> m_lstMonsterPos = new List<Vector3>();

    public SkillUpdateHZC()
	{
		this.m_sTargetType = 4;
		this.m_sRangeType = 4;
		this.m_sStopAnimateState = 4;
	}

	public SkillUpdateHZC(SkillUpdateHZC suc) : base(suc)
	{
		this.m_iAnimation = suc.m_iAnimation;
		this.m_iEffectId = suc.m_iEffectId;
		this.m_fBreakTime = suc.m_fBreakTime;
		this.m_iMonsterId = suc.m_iMonsterId;
		this.m_iMonsterAppearEff = suc.m_iMonsterAppearEff;
		this.m_fRadius = suc.m_fRadius;
		this.m_iCount = suc.m_iCount;
		this.m_fCTime = suc.m_fCTime;
	}

	public override KeyValuePair<string, Type>[] GetRes()
	{
		List<KeyValuePair<string, Type>> list = new List<KeyValuePair<string, Type>>();
		if (base.GetRes() != null)
		{
			list.AddRange(base.GetRes());
		}
		//KeyValuePair<string, Type>[] effectResPath = UtilityRoleResource.GetEffectResPath(723);
		//if (effectResPath != null)
		//{
		//	list.AddRange(effectResPath);
		//}
		//KeyValuePair<string, Type>[] effectResPath2 = UtilityRoleResource.GetEffectResPath(724);
		//if (effectResPath2 != null)
		//{
		//	list.AddRange(effectResPath2);
		//}
		//KeyValuePair<string, Type>[] effectResPath3 = UtilityRoleResource.GetEffectResPath(725);
		//if (effectResPath3 != null)
		//{
		//	list.AddRange(effectResPath3);
		//}
		//KeyValuePair<string, Type>[] monsterRes = UtilityRoleResource.GetMonsterRes(this.m_iMonsterId);
		//if (monsterRes != null)
		//{
		//	list.AddRange(monsterRes);
		//}
		return list.ToArray();
	}

	public override CSkillBase Clone()
	{
		return new SkillUpdateHZC(this);
	}

	public override void Init(Role sourceRole, Role targetRole, Vector3 targetPos)
	{
		this.m_lisPos.Clear();
		base.Init(sourceRole, targetRole, targetPos);
		this.m_bIsCall = false;
		this.m_iNowEffectId = 0;
		this.m_lstMonsterPos.Clear();
	}

	public override void Write(CSerializer cs)
	{
		base.Write(cs);
		cs.Write(this.m_iAnimation);
		cs.Write(this.m_iEffectId);
		cs.Write(this.m_fBreakTime);
		cs.Write(this.m_iMonsterId);
		cs.Write(this.m_iMonsterAppearEff);
		cs.Write(this.m_fRadius);
		cs.Write(this.m_iCount);
		cs.Write(this.m_fCTime);
	}

	public override void Read(CSerializer cs)
	{
		base.Read(cs);
		this.m_iAnimation = cs.ReadInt32();
		this.m_iEffectId = cs.ReadInt32();
		this.m_fBreakTime = cs.ReadFloat();
		this.m_iMonsterId = cs.ReadInt32();
		this.m_iMonsterAppearEff = cs.ReadInt32();
		this.m_fRadius = cs.ReadFloat();
		this.m_iCount = cs.ReadInt32();
		this.m_fCTime = cs.ReadFloat();
	}

	public override void TextRead(List<string> infoList, ref int index)
	{
		base.TextRead(infoList, ref index);
		this.m_iAnimation = Convert.ToInt32(infoList[index++]);
		this.m_iEffectId = Convert.ToInt32(infoList[index++]);
		this.m_fBreakTime = Convert.ToSingle(infoList[index++]);
		this.m_iMonsterId = Convert.ToInt32(infoList[index++]);
		this.m_iMonsterAppearEff = Convert.ToInt32(infoList[index++]);
		this.m_fRadius = Convert.ToSingle(infoList[index++]);
		this.m_iCount = Convert.ToInt32(infoList[index++]);
		this.m_fCTime = Convert.ToSingle(infoList[index++]);
	}

	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		ModAnimation modAnimation = (ModAnimation)this.m_cSourceRole.GetModule(MODULE_TYPE.MT_MOTION);
		switch (this.m_sUpdateStatus)
		{
		case 1:
			this.m_sUpdateStatus += 1;
			break;
		case 2:
			modAnimation.PlayAnimation((ACTION_INDEX)this.m_iAnimation);
			SingletonMono<EffectManager>.GetInstance().AddEffectFixure(723, this.m_cSourceRole.GetPos(), this.m_cSourceRole.GetTrans().rotation);
			this.m_lstMonsterPos.Clear();
			this.m_bIsCall = false;
			this.m_fCreateTime = GameTime.time;
			this.m_sUpdateStatus += 1;
			break;
		case 3:
			if (GameTime.time - this.m_fCreateTime > 1.8f && !this.m_bIsCall)
			{
				this.m_bIsCall = true;
				for (int i = 0; i < 3; i++)
				{
					Vector3 vector = new Vector3(this.m_cSourceRole.GetPos().x, this.m_cSourceRole.GetPos().y + 2.4f, this.m_cSourceRole.GetPos().z);
					this.nodes.Add(vector);
					//Vector3 randomPosOnAngleRadius = RoleBaseFun.GetRandomPosOnAngleRadius(this.m_cSourceRole.GetPos(), 1.5f, this.m_cSourceRole, 120f * (float)i, 120f * (float)i);
					//this.nodes.Add(new Vector3(randomPosOnAngleRadius.x, randomPosOnAngleRadius.y + 1.3f, randomPosOnAngleRadius.z));
					//Vector3 randomPosOnAngleRadius2 = RoleBaseFun.GetRandomPosOnAngleRadius(this.m_cSourceRole.GetPos(), 2.4f, this.m_cSourceRole, 120f * (float)i, 120f * (float)i);
					//this.nodes.Add(randomPosOnAngleRadius2);
					//this.m_lstMonsterPos.Add(randomPosOnAngleRadius2);
					Vector3 pos = vector;
					this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectRay(725, pos, Quaternion.identity, Vector3.zero);
					GameObject @object = Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId);
					//FlyEffect flyEffect = @object.AddComponent<FlyEffect>();
					//flyEffect.Init(this.nodes.ToArray(), this.m_cSourceRole, this.m_cTargetRole, false, false);
					//Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId).GetComponent<EffectRadial>().SetCallBackFun(new Callback<int, GameObject, ContactPoint[]>(this.EffCollisionEnter));
					Collider component = Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId).GetComponent<Collider>();
					//List<Role> allyRole = FanrenSceneManager.RoleMan.GetAllyRole(this.m_cSourceRole);
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
					this.nodes.Clear();
				}
			}
			if (GameTime.time - this.m_fCreateTime > 3.2f)
			{
				for (int j = 0; j < 3; j++)
				{
					//SDM_SpawnMonster.SD_SpawnMonster agrs = SDM_SpawnMonster.CreateSpawnData(this.m_iMonsterId, this.m_lstMonsterPos[j] + new Vector3(0f, 0.2f, 0f), this.m_cSourceRole.GetTrans().rotation, GameObjSpawn.SpawnType.MONSTER, ORG_TYPE.OT_MONSTER, this.m_cSourceRole.SpawnInfo.areaName, this.m_cSourceRole);
					//GameData.Instance.ScrMan.Exec(12, agrs);
				}
				this.m_sUpdateStatus += 1;
			}
			break;
		case 4:
			this.m_sUpdateStatus += 1;
			break;
		case 5:
			return false;
		}
		return true;
	}

	public override void Destory()
	{
		base.Destory();
	}

	private void EffCollisionEnter(int id, GameObject go, ContactPoint[] contactPoints)
	{
		//Role roleScriptFromGo = RoleBaseFun.GetRoleScriptFromGo(go);
		//if (roleScriptFromGo == null)
		//{
		//	SingletonMono<EffectManager>.GetInstance().Delete(id);
		//	SingletonMono<EffectManager>.GetInstance().AddEffectFixure(724, contactPoints[0].point, Quaternion.identity);
		//}
	}
}
