using System;
using UnityEngine;

// Token: 0x020004C6 RID: 1222
public class ControlStateDie : ControlStateBase
{
	// Token: 0x06001F8D RID: 8077 RVA: 0x000D72B8 File Offset: 0x000D54B8
	public ControlStateDie(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.DIE)
	{
		this.modFight = (this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight);
	}

	// Token: 0x06001F8E RID: 8078 RVA: 0x000D72DC File Offset: 0x000D54DC
	//public override bool Update()
	//{
	//	if (!base.Update())
	//	{
	//		return false;
	//	}
	//	if (this.dieBev != null)
	//	{
	//		if (!this.dieBev.Update())
	//		{
	//			SceneManager.RoleMan.DelRole(this.m_cRole);
	//			this.m_cRole = null;
	//		}
	//		return true;
	//	}
	//	SceneManager.RoleMan.DelRole(this.m_cRole);
	//	this.m_cRole = null;
	//	return false;
	//}

	//// Token: 0x06001F8F RID: 8079 RVA: 0x000D734C File Offset: 0x000D554C
	//public override bool OnEnter(ControlEventBase ceb)
	//{
	//	base.OnEnter(ceb);
	//	if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
	//	{
	//		PlayerDieBev playerDieBev = new PlayerDieBev();
	//		playerDieBev.SetActor(this.m_cRole);
	//		this.dieBev = playerDieBev;
	//		return true;
	//	}
	//	Monster monster = null;
	//	if (this.m_cRole._roleType == ROLE_TYPE.RT_MONSTER)
	//	{
	//		monster = (this.m_cRole as Monster);
	//	}
	//	ControlEventDie controlEventDie = (ControlEventDie)ceb;
	//	DieRuleData.Data data = Singleton<DieRuleData>.GetInstance().GetData(controlEventDie.dieRule);
	//	if (data == null)
	//	{
	//		return true;
	//	}
	//	FightInfo lastHurtInfo = this.modFight.LastHurtInfo;
	//	if (lastHurtInfo == null || lastHurtInfo.attackForce == Vector3.zero)
	//	{
	//		if (data.DefaultDieBev == 1)
	//		{
	//			RoleAnimationDie roleAnimationDie = new RoleAnimationDie();
	//			roleAnimationDie.SetActor(this.m_cRole);
	//			roleAnimationDie.bodyStayTime = data.BodyStayTime;
	//			roleAnimationDie.AniIndex = data.DieAniIndex;
	//			this.CreatFigureDieEffect(lastHurtInfo);
	//			this.dieBev = roleAnimationDie;
	//		}
	//		else if (data.DefaultDieBev == 2)
	//		{
	//			RoleRagdolDie roleRagdolDie = new RoleRagdolDie();
	//			if (monster != null)
	//			{
	//				roleRagdolDie.DieSoundID = monster._monsterInfo.DieSound;
	//			}
	//			roleRagdolDie.SetActor(this.m_cRole);
	//			roleRagdolDie.bodyStayTime = data.BodyStayTime;
	//			this.m_cAnimation.StopAnimation();
	//			this.CreatFigureDieEffect(lastHurtInfo);
	//			this.dieBev = roleRagdolDie;
	//		}
	//		else
	//		{
	//			RoleEffectDie roleEffectDie = new RoleEffectDie();
	//			roleEffectDie.SetActor(this.m_cRole);
	//			roleEffectDie.IsPhyBreak = data.IsPhyBreak;
	//			roleEffectDie.bodyStayTime = data.BodyStayTime;
	//			roleEffectDie.bodyStayTime = data.BodyStayTime;
	//			if (this.m_cRole is Monster)
	//			{
	//				roleEffectDie.EffectId = ((Monster)this.m_cRole)._monsterInfo.DieEffect;
	//			}
	//			this.m_cAnimation.StopAnimation();
	//			this.dieBev = roleEffectDie;
	//		}
	//		return true;
	//	}
	//	Vector3 a = lastHurtInfo.attackForce;
	//	if (a.y >= data.BreakForce || a.z > data.BreakForce)
	//	{
	//		RoleEffectDie roleEffectDie2 = new RoleEffectDie();
	//		roleEffectDie2.SetActor(this.m_cRole);
	//		roleEffectDie2.IsPhyBreak = data.IsPhyBreak;
	//		roleEffectDie2.bodyStayTime = data.BodyStayTime;
	//		if (this.m_cRole is Monster)
	//		{
	//			roleEffectDie2.EffectId = ((Monster)this.m_cRole)._monsterInfo.DieEffect;
	//		}
	//		Vector3 force = this.m_cRole.GetPos() - lastHurtInfo.attackPoint;
	//		force.y = 0f;
	//		force = force.normalized * a.z;
	//		force.y = a.y;
	//		roleEffectDie2.Force = force;
	//		this.dieBev = roleEffectDie2;
	//		this.m_cAnimation.StopAnimation();
	//		return true;
	//	}
	//	if (a.y >= data.FlyForce || a.z > data.FlyForce)
	//	{
	//		a *= this.m_cRole.GetMassNumber();
	//		RoleRagdolDie roleRagdolDie2 = new RoleRagdolDie();
	//		if (monster != null)
	//		{
	//			roleRagdolDie2.DieSoundID = monster._monsterInfo.DieSound;
	//		}
	//		roleRagdolDie2.SetActor(this.m_cRole);
	//		roleRagdolDie2.bodyStayTime = data.BodyStayTime;
	//		Vector3 vector = this.m_cRole.GetPos() - lastHurtInfo.attackPoint;
	//		vector.y = 0f;
	//		vector = vector.normalized * a.z;
	//		vector.y = a.y;
	//		vector *= 1000f;
	//		roleRagdolDie2.Force = vector;
	//		this.dieBev = roleRagdolDie2;
	//		this.m_cAnimation.StopAnimation();
	//		this.CreatFigureDieEffect(lastHurtInfo);
	//		return true;
	//	}
	//	RoleAnimationDie roleAnimationDie2 = new RoleAnimationDie();
	//	roleAnimationDie2.SetActor(this.m_cRole);
	//	roleAnimationDie2.bodyStayTime = data.BodyStayTime;
	//	roleAnimationDie2.AniIndex = data.DieAniIndex;
	//	this.CreatFigureDieEffect(lastHurtInfo);
	//	this.dieBev = roleAnimationDie2;
	//	return true;
	//}

	//// Token: 0x06001F90 RID: 8080 RVA: 0x000D7740 File Offset: 0x000D5940
	//private void CreatFigureDieEffect(FightInfo info)
	//{
	//	if (info == null)
	//	{
	//		return;
	//	}
	//	int figureID = info.figureID;
	//	if (figureID == 0)
	//	{
	//		return;
	//	}
	//	//FigureEffectData.Data effectInfo = Singleton<FigureEffectData>.GetInstance().GetEffectInfo(figureID);
	//	//if (effectInfo == null)
	//	//{
	//	//	return;
	//	//}
	//	//if (effectInfo.EffectMaterialId > 0)
	//	//{
	//	//	//this.m_cRole.roleGameObject.AddMaterialeffect(effectInfo.EffectMaterialId, 1f);
	//	//}
	//	//if (effectInfo.AttackedDeadId > 0)
	//	//{
	//	//	this.m_cRole.roleGameObject.BindEffect(CHILD_EFFECT_POINT.CHEST, effectInfo.AttackedDeadId, Vector3.zero, Vector3.zero);
	//	//}
	//}

	// Token: 0x06001F91 RID: 8081 RVA: 0x000D77CC File Offset: 0x000D59CC
	public override void OnExit()
	{
		base.OnExit();
		this.m_cControlMfs.ChangeStateToIdle();
	}

	// Token: 0x04001C5D RID: 7261
	private const float forceScale = 1000f;

	// Token: 0x04001C5E RID: 7262
	//private RoleDieBev dieBev;

	// Token: 0x04001C5F RID: 7263
	private ModFight modFight;
}
