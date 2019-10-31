using System;
using UnityEngine;


public class ControlStateHurt : ControlStateBase
{
    //private HurtRuleData.Data lastHurtRule;

    private int currentCount;

    private int attackID;

    //private RoleHurtBev hurtBev;

    private float lastExitTime;

    private ModFight modFight;

    public ControlStateHurt(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.HURT)
	{
		this.modFight = (role.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight);
	}

	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		if (this.attackID < 20)
		{
		}
		//if (this.hurtBev == null)
		//{
		//	return false;
		//}
		//if (!this.hurtBev.Update())
		//{
		//	return false;
		//}
		//if (this.hurtBev.IsRecover)
		//{
		//	this.isFree = true;
		//}
		return true;
	}

	//public override bool IsEffectTive(ControlEventBase tmpEvent)
	//{
	//	ControlEventHurt controlEventHurt = (ControlEventHurt)tmpEvent;
	//	int num = controlEventHurt.Info.hurtBev;
	//	if (num > 20)
	//	{
	//		num = 2;
	//	}
	//	HurtRuleData.Data data = this.CalculateCount(num);
	//	if (data == null)
	//	{
	//		return false;
	//	}
	//	controlEventHurt.hutData = data;
	//	return true;
	//}

	//// Token: 0x06001FB1 RID: 8113 RVA: 0x000D8424 File Offset: 0x000D6624
	//public override bool OnEnter(ControlEventBase ceb)
	//{
	//	base.OnEnter(ceb);
	//	if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
	//	{
	//		Player.Instance.weaponManager.CloseWeapon();
	//	}
	//	ControlEventHurt controlEventHurt = (ControlEventHurt)ceb;
	//	this.attackID = controlEventHurt.Info.hurtBev;
	//	if (this.attackID > 20)
	//	{
	//		this.attackID = 2;
	//	}
	//	if (this.attackID > 20)
	//	{
	//		RoleAttackBevData data = Singleton<AttackEffectData>.GetInstance().GetData(controlEventHurt.Info.hurtBev, this.m_cRole.GetHurtID(), 1);
	//		if (data == null)
	//		{
	//			if (controlEventHurt.Info.attackForce.x < 0f && controlEventHurt.Info.attackForce.y < 0f)
	//			{
	//				return false;
	//			}
	//			RoleHurtPhysics roleHurtPhysics = new RoleHurtPhysics();
	//			roleHurtPhysics.SetActor(this.m_cRole);
	//			controlEventHurt.Info.attackForce *= this.m_cRole.GetMassNumber();
	//			roleHurtPhysics.SetBev(controlEventHurt.Info);
	//			this.hurtBev = roleHurtPhysics;
	//			if (controlEventHurt.Info.attackForce.y != 0f)
	//			{
	//				this.m_cRole.GetTrans().LookAt(new Vector3(controlEventHurt.Info.attackPoint.x, this.m_cRole.GetPos().y, controlEventHurt.Info.attackPoint.z));
	//			}
	//		}
	//		else
	//		{
	//			this.hurtBev = Singleton<RoleHurtBevFactory>.GetInstance().GetHurtBev(data.HurtType);
	//			if (this.hurtBev == null)
	//			{
	//				return false;
	//			}
	//			this.hurtBev.SetActor(this.m_cRole);
	//			this.hurtBev.GetData(data, controlEventHurt.Info);
	//			if (data.EnableRotate && (this.hurtBev is RoleHurtFly || this.hurtBev is RoleHurtDown))
	//			{
	//				this.m_cRole.GetTrans().LookAt(new Vector3(controlEventHurt.Info.attackPoint.x, this.m_cRole.GetPos().y, controlEventHurt.Info.attackPoint.z));
	//			}
	//		}
	//	}
	//	else if (controlEventHurt.hutData != null)
	//	{
	//		this.HandlehurtData(controlEventHurt.hutData, controlEventHurt.Info);
	//	}
	//	else
	//	{
	//		HurtRuleData.Data data2 = this.CalculateCount(this.attackID);
	//		if (data2 == null)
	//		{
	//			return false;
	//		}
	//		this.HandlehurtData(data2, controlEventHurt.Info);
	//	}
	//	return true;
	//}

	//private void HandlehurtData(HurtRuleData.Data data, FightInfo fightInfo)
	//{
	//	this.lastHurtRule = data;
	//	this.hurtBev = Singleton<HurtBevData>.GetInstance().GetData(this.lastHurtRule.HurtBevID);
	//	this.hurtBev.SetActor(this.m_cRole);
	//	this.hurtBev.Reset();
	//	this.hurtBev.AttackSourcePoint = fightInfo.attackPoint;
	//	if (this.lastHurtRule.IsInvincible)
	//	{
	//		this.modFight.Invincible(true);
	//	}
	//	else
	//	{
	//		this.modFight.Invincible(false);
	//	}
	//	if (this.lastHurtRule.MaxHurtAmount > 0 && this.currentCount >= this.lastHurtRule.MaxHurtAmount && this.lastHurtRule.BuffID > 0)
	//	{
	//		ModBuffProperty modBuffProperty = (ModBuffProperty)this.m_cRole.GetModule(MODULE_TYPE.MT_BUFF);
	//		modBuffProperty.AddBuff(this.lastHurtRule.BuffID);
	//	}
	//}

	//// Token: 0x06001FB3 RID: 8115 RVA: 0x000D878C File Offset: 0x000D698C
	//public override void OnExit()
	//{
	//	base.OnExit();
	//	this.lastExitTime = GameTime.time;
	//	this.m_cControlMfs.ChangeStateToIdle();
	//}

	//// Token: 0x06001FB4 RID: 8116 RVA: 0x000D87AC File Offset: 0x000D69AC
	//public override bool Destory()
	//{
	//	base.Destory();
	//	if (this.lastHurtRule != null && this.lastHurtRule.IsInvincible)
	//	{
	//		this.modFight.Invincible(false);
	//	}
	//	this.lastExitTime = GameTime.time;
	//	return true;
	//}

	//// Token: 0x06001FB5 RID: 8117 RVA: 0x000D87F4 File Offset: 0x000D69F4
	//public override void EnterProcess()
	//{
	//	base.EnterProcess();
	//	if (this.modBevAi != null)
	//	{
	//		this.modBevAi.bPause = true;
	//	}
	//}

	//// Token: 0x06001FB6 RID: 8118 RVA: 0x000D8814 File Offset: 0x000D6A14
	//public override void ExitProcess()
	//{
	//	base.ExitProcess();
	//	if (this.modBevAi != null)
	//	{
	//		this.modBevAi.bPause = false;
	//	}
	//}

	//// Token: 0x06001FB7 RID: 8119 RVA: 0x000D8834 File Offset: 0x000D6A34
	//private HurtRuleData.Data CalculateCount(int attackID)
	//{
	//	HurtRuleData.Data data = Singleton<HurtRuleData>.GetInstance().GetData(this.m_cRole.GetHurtID(), attackID);
	//	if (data == null)
	//	{
	//		return null;
	//	}
	//	if (data.SkipID > 0)
	//	{
	//		data = Singleton<HurtRuleData>.GetInstance().GetData(this.m_cRole.GetHurtID(), data.SkipID);
	//	}
	//	if (data.HurtBevID <= 0)
	//	{
	//		return null;
	//	}
	//	if (this.lastHurtRule != null)
	//	{
	//		if (this.lastHurtRule.MaxHurtAmount > 0)
	//		{
	//			if (this.m_cControlMfs.GetCurrentStateId() != CONTROL_STATE.HURT && GameTime.time - this.lastExitTime > this.lastHurtRule.ClearHurtCountTime)
	//			{
	//				this.currentCount = 0;
	//			}
	//			if (this.lastHurtRule.Level >= data.Level)
	//			{
	//				if (this.currentCount >= this.lastHurtRule.MaxHurtAmount)
	//				{
	//					if (this.lastHurtRule.HurtChangeRule.ContainsKey(attackID))
	//					{
	//						data = Singleton<HurtRuleData>.GetInstance().GetData(this.m_cRole.GetHurtID(), this.lastHurtRule.HurtChangeRule[attackID]);
	//					}
	//					this.currentCount = 0;
	//				}
	//			}
	//			else
	//			{
	//				this.currentCount = 0;
	//			}
	//		}
	//		else if (data.Level < this.lastHurtRule.Level && this.m_cControlMfs.GetCurrentStateId() == CONTROL_STATE.HURT)
	//		{
	//			return null;
	//		}
	//	}
	//	if (data != null && data.MaxHurtAmount > 0)
	//	{
	//		this.currentCount++;
	//	}
	//	return data;
	//}
}
