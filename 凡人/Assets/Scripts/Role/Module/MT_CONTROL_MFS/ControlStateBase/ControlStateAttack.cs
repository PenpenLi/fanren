using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlStateAttack : ControlStateBase
{

    public ControlStateAttack(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.ATTACK)
    {
        //this.rotate = new Rotate(role.GetTrans(), 720f, Vector3.zero);
        //this.m_cModFight = (role.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight);
    }

    //// Token: 0x06001F52 RID: 8018 RVA: 0x000D62A8 File Offset: 0x000D44A8
    //public override bool Update()
    //{
    //	if (!base.Update())
    //	{
    //		return false;
    //	}
    //	if (this.currentAttackBev == null)
    //	{
    //		return false;
    //	}
    //	if (!this.currentAttackBev.Update())
    //	{
    //		return false;
    //	}
    //	if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
    //	{
    //		if (!Player.Instance.weaponManager.weaponeActive)
    //		{
    //			return false;
    //		}
    //		if (this.currentAttackBev.IsCanBeIgnore() && !base.BreakEvent.Contains(CONTROL_INPUT.ROLL))
    //		{
    //			base.BreakEvent.Add(CONTROL_INPUT.ROLL);
    //		}
    //	}
    //	if (!this.currentAttackBev.IsAttacking)
    //	{
    //		this.m_cModFight.IsAttacking = false;
    //		this.isFree = true;
    //		base.CallOverMethod();
    //	}
    //	else
    //	{
    //		this.m_cModFight.IsAttacking = true;
    //	}
    //	return true;
    //}

    //// Token: 0x06001F53 RID: 8019 RVA: 0x000D6374 File Offset: 0x000D4574
    //public override bool OnEnter(ControlEventBase ceb)
    //{
    //	base.OnEnter(ceb);
    //	this.cea = (ControlEventAttack)ceb;
    //	Transform target = null;
    //	Vector3 targetDir = this.cea.TargetDir;
    //	if (this.cea.Target != null)
    //	{
    //		target = this.cea.Target.GetTrans();
    //	}
    //	int num = 0;
    //	//if (this.cea.comboNum >= 0)
    //	//{
    //	//	num = (int)this.m_cRole.GetWeaponIdx();
    //	//	int comboID = this.cea.m_comboID;
    //	//	int num2 = this.cea.comboNum + 1;
    //	//	List<AttackAnimationInfo.ComboInfo> list = new List<AttackAnimationInfo.ComboInfo>();
    //	//	for (int i = 1; i <= num2; i++)
    //	//	{
    //	//		string text = string.Empty;
    //	//		for (int j = 0; j < i; j++)
    //	//		{
    //	//			text += "0";
    //	//		}
    //	//		AttackAnimationInfo.ComboInfo attackAniCombInfo = GameData.Instance.attackTable.getAttackAniCombInfo(text, num, comboID);
    //	//		if (attackAniCombInfo != null)
    //	//		{
    //	//			list.Add(attackAniCombInfo);
    //	//		}
    //	//	}
    //	//	if ((float)list.Count == 0f)
    //	//	{
    //	//		return false;
    //	//	}
    //	//	AttackNormalWeaponCombo attackNormalWeaponCombo = new AttackNormalWeaponCombo(this.m_cRole);
    //	//	attackNormalWeaponCombo.SetActor(this.m_cRole);
    //		attackNormalWeaponCombo.Init(list.ToArray(), target, targetDir, 0);
    //		this.currentAttackBev = attackNormalWeaponCombo;
    //		return true;
    //	}
    //	else
    //	{
    //		if (this.cea.m_imouseFlag > 0)
    //		{
    //			this.attackArray.Clear();
    //			for (int k = 0; k < this.cea.m_imouseFlag; k++)
    //			{
    //				this.attackArray.Add(0);
    //			}
    //		}
    //		if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
    //		{
    //			CONTROL_STATE currentStateId = this.m_cRole.modMFS.GetCurrentStateId();
    //			if (currentStateId != CONTROL_STATE.ATTACK)
    //			{
    //				this.attackArray.Clear();
    //				this.m_iCurrentAttackCount = 0;
    //			}
    //			float num3 = GameTime.time - this.m_fAttackStartTime;
    //			if (num3 > this.m_currentAttackTime + this.m_fWeaponTime)
    //			{
    //				this.attackArray.Clear();
    //				this.m_iCurrentAttackCount = 0;
    //			}
    //			Player player = (Player)this.m_cRole;
    //			if (this.attackArray.Count != this.m_iCurrentAttackCount)
    //			{
    //				return false;
    //			}
    //			this.attackArray.Add(this.cea.m_imouseFlag);
    //			this.m_iCurrentAttackCount++;
    //			int ambitID = player.m_cAdeptSystem.GetAmbitID();
    //			if (ambitID != 0)
    //			{
    //				this.cea.m_comboID = ambitID;
    //			}
    //			if (player.weaponManager.currentWeaponType == EquipCfgType.EQCHILD_CT_DWEAPON)
    //			{
    //				this.m_iAttackMaxCount = 4;
    //			}
    //			else
    //			{
    //				this.m_iAttackMaxCount = 3;
    //			}
    //			if (this.m_iCurrentAttackCount > this.m_iAttackMaxCount && !player.m_cAdeptSystem.IsAdeptUnLock(AdeptTalent.CheckUnLockType.CUT_LIANJI, this.m_iCurrentAttackCount))
    //			{
    //				this.attackArray.Clear();
    //				this.attackArray.Add(0);
    //			}
    //			this.effect = player.SystemFigure.SkillID;
    //			num = (int)player.weaponManager.currentWeaponType;
    //		}
    //		if (num <= 0)
    //		{
    //			num = (int)this.m_cRole.GetWeaponIdx();
    //		}
    //		this.m_iCurrentAttackCount = this.attackArray.Count;
    //		string attackList = Static_Utils.ArrayToString(this.attackArray);
    //		this.currentAttackInfo = GameData.Instance.attackTable.getAttackAniCombInfo(attackList, num, this.cea.m_comboID);
    //		if (this.currentAttackInfo == null)
    //		{
    //			return false;
    //		}
    //		if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER && !Player.Instance.weaponManager.weaponeActive)
    //		{
    //			Player.Instance.weaponManager.OpenWeapon();
    //		}
    //		AttackAnimationInfo attackAniInfo = GameData.Instance.attackTable.getAttackAniInfo(num, this.cea.m_comboID);
    //		if (attackAniInfo != null)
    //		{
    //			this.curComboAmount = attackAniInfo.ComboInfoList.Count;
    //			this.curComboIndex = this.cea.m_imouseFlag;
    //		}
    //		this.currentAttackBev = AttackUpdateBase.CreatAttackBev(this.currentAttackInfo.AttackType);
    //		this.currentAttackBev.SetActor(this.m_cRole);
    //		this.currentAttackBev.Init(this.currentAttackInfo, target, targetDir, this.effect);
    //		this.currentAttackBev.Reset();
    //		this.m_fAttackStartTime = GameTime.time;
    //		this.m_fAttackLifeTime = this.currentAttackBev.GetAniTime();
    //		this.m_currentAttackTime = this.currentAttackBev.GetAttackTime();
    //		return true;
    //	}
    //}

    //// Token: 0x06001F54 RID: 8020 RVA: 0x000D67D4 File Offset: 0x000D49D4
    //public override float GetBeforTime()
    //{
    //	if (this.currentAttackBev != null && this.currentAttackInfo != null)
    //	{
    //		return this.currentAttackBev.GetAttackTime() - this.currentAttackInfo.StartInputTime;
    //	}
    //	return 0f;
    //}

    //// Token: 0x06001F55 RID: 8021 RVA: 0x000D680C File Offset: 0x000D4A0C
    //public override void OnExit()
    //{
    //	this.attackArray.Clear();
    //	this.m_iCurrentAttackCount = 0;
    //	if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
    //	{
    //		Player.Instance.weaponManager.SetWeaponEmit(false);
    //	}
    //	base.OnExit();
    //	this.m_cControlMfs.ChangeStateToIdle();
    //	this.m_cModFight.IsAttacking = false;
    //}

    //// Token: 0x06001F56 RID: 8022 RVA: 0x000D686C File Offset: 0x000D4A6C
    //public override bool Destory()
    //{
    //	base.Destory();
    //	CONTROL_STATE currentStateId = this.m_cRole.modMFS.GetCurrentStateId();
    //	if (this.currentAttackBev != null)
    //	{
    //		this.currentAttackBev.Quit();
    //	}
    //	this.m_cModFight.IsAttacking = false;
    //	return true;
    //}

    //// Token: 0x06001F57 RID: 8023 RVA: 0x000D68B4 File Offset: 0x000D4AB4
    //public override void EnterProcess()
    //{
    //	base.EnterProcess();
    //	if (this.modBevAi != null)
    //	{
    //		this.modBevAi.bPause = true;
    //	}
    //}

    //// Token: 0x06001F58 RID: 8024 RVA: 0x000D68D4 File Offset: 0x000D4AD4
    //public override void ExitProcess()
    //{
    //	base.ExitProcess();
    //	if (this.modBevAi != null)
    //	{
    //		this.modBevAi.bPause = false;
    //	}
    //}

    //// Token: 0x04001BDF RID: 7135
    //private const float REMAIN_TIME = 0.7f;

    //// Token: 0x04001BE0 RID: 7136
    //private const float RESET_TIME = 2f;

    //// Token: 0x04001BE1 RID: 7137
    //private const float FORBID_TIME = 0.2f;

    //// Token: 0x04001BE2 RID: 7138
    //private int m_iAttackMaxCount = 3;

    //// Token: 0x04001BE3 RID: 7139
    //private int m_iCurrentAttackCount;

    //// Token: 0x04001BE4 RID: 7140
    //private float m_fAttackLifeTime;

    //// Token: 0x04001BE5 RID: 7141
    //private float m_fAttackStartTime;

    //// Token: 0x04001BE6 RID: 7142
    //private float m_currentAttackTime;

    //// Token: 0x04001BE7 RID: 7143
    //private float m_fWeaponTime = 0.25f;

    //// Token: 0x04001BE8 RID: 7144
    //private float emitTime = 0.3f;

    //// Token: 0x04001BE9 RID: 7145
    //private ArrayList attackArray = new ArrayList();

    //// Token: 0x04001BEA RID: 7146
    //private int m_comboIdx;

    //// Token: 0x04001BEB RID: 7147
    //private int effect;

    //// Token: 0x04001BEC RID: 7148
    //private ModFight m_cModFight;

    //// Token: 0x04001BED RID: 7149
    //private AttackAnimationInfo.ComboInfo currentAttackInfo;

    //// Token: 0x04001BEE RID: 7150
    //private ControlEventAttack cea;

    //// Token: 0x04001BEF RID: 7151
    //private int curComboAmount;

    //// Token: 0x04001BF0 RID: 7152
    //private int curComboIndex;

    //// Token: 0x04001BF1 RID: 7153
    //private float AI_UNPAUSE_TIME = 0.8f;

    //// Token: 0x04001BF2 RID: 7154
    //private TimeLineEvent timeEvent = new TimeLineEvent();

    //// Token: 0x04001BF3 RID: 7155
    //private Rotate rotate;

    //// Token: 0x04001BF4 RID: 7156
    //private AttackUpdateBase currentAttackBev;
}
