using System;
using UnityEngine;

// Token: 0x020004BC RID: 1212
public class ControlStateBackWeapon : ControlStateBase
{
	// Token: 0x06001F5E RID: 8030 RVA: 0x000D6B04 File Offset: 0x000D4D04
	public ControlStateBackWeapon(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.BACK_WEAPON)
	{
		//this.play = new PlayRoleAnimationOnce(this.m_cAnimation, 660);
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x000D6B34 File Offset: 0x000D4D34
	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		//if (!this.play.Update())
		//{
		//	return false;
		//}
		if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER && GameTime.time - this.m_fStateStartTime > Singleton<PlayerFightData>.GetInstance().GetCloseWeaponTime(Player.Instance.weaponManager.currentWeaponType))
		{
			Player.Instance.weaponManager.SmoothClose();
		}
		return true;
	}

	// Token: 0x06001F60 RID: 8032 RVA: 0x000D6BAC File Offset: 0x000D4DAC
	public override bool OnEnter(ControlEventBase ceb)
	{
		this.m_fStateStartTime = GameTime.time;
		if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
		{
			Player.Instance.weaponManager.OpenWeapon();
		}
		//this.play.Reset();
		return true;
	}

	// Token: 0x06001F61 RID: 8033 RVA: 0x000D6BE8 File Offset: 0x000D4DE8
	public override bool Destory()
	{
		base.Destory();
		return true;
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x000D6BF4 File Offset: 0x000D4DF4
	public override void OnExit()
	{
		base.OnExit();
		this.m_cControlMfs.ChangeStateToIdle();
	}

	// Token: 0x04001BF9 RID: 7161
	//private PlayRoleAnimationOnce play;
}
