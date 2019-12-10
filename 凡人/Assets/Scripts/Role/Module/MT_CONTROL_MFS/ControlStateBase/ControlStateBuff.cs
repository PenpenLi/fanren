using System;
using UnityEngine;

// Token: 0x020004C0 RID: 1216
public class ControlStateBuff : ControlStateBase
{
	// Token: 0x06001F83 RID: 8067 RVA: 0x000D712C File Offset: 0x000D532C
	public ControlStateBuff(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.BUFF)
	{
	}

	// Token: 0x06001F84 RID: 8068 RVA: 0x000D713C File Offset: 0x000D533C
	public override bool Update()
	{
		return base.Update();
	}

	// Token: 0x06001F85 RID: 8069 RVA: 0x000D714C File Offset: 0x000D534C
	public override bool OnEnter(ControlEventBase ceb)
	{
		base.OnEnter(ceb);
		ControlEventBuff controlEventBuff = (ControlEventBuff)ceb;
		this.m_iAnimation = controlEventBuff.Ani;
		this.m_cAnimation.PlayAnimation((ACTION_INDEX)this.m_iAnimation, 1f, WrapMode.Loop, false, false);
		return true;
	}

	// Token: 0x06001F86 RID: 8070 RVA: 0x000D7190 File Offset: 0x000D5390
	public override void OnExit()
	{
		base.OnExit();
		this.m_cControlMfs.ChangeStateToIdle();
	}

	// Token: 0x06001F87 RID: 8071 RVA: 0x000D71A4 File Offset: 0x000D53A4
	public override bool Destory()
	{
		ModBuffProperty modBuffProperty = (ModBuffProperty)this.m_cRole.GetModule(MODULE_TYPE.MT_BUFF);
		if (modBuffProperty.GetValue(BUFF_VALUE_TYPE.DIZZY) > 0)
		{
			return false;
		}
		if (modBuffProperty.GetValue(BUFF_VALUE_TYPE.FROZEN) > 0)
		{
			return false;
		}
		base.Destory();
		return true;
	}

	// Token: 0x04001C0E RID: 7182
	private int m_iAnimation;
}
