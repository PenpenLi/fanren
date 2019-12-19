using System;
using UnityEngine;

// Token: 0x020004C7 RID: 1223
public class ControlStateFalling : ControlStateBase
{
	// Token: 0x06001F92 RID: 8082 RVA: 0x000D77E0 File Offset: 0x000D59E0
	public ControlStateFalling(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.FALLING)
	{
		//this.move = new ControllerMovePhysics(control, Vector3.zero, true);
	}

	// Token: 0x06001F93 RID: 8083 RVA: 0x000D7800 File Offset: 0x000D5A00
	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		if (this.m_cRole is Monster)
		{
			this.timeCount += GameTime.deltaTime;
			if (this.timeCount >= 3f)
			{
				this.m_cRole.Die(false);
			}
		}
		//this.move.Update();
		//if (this.move.IsGrounded())
		//{
		//	this.timeCount = 0f;
		//	return false;
		//}
		return true;
	}

	// Token: 0x06001F94 RID: 8084 RVA: 0x000D7884 File Offset: 0x000D5A84
	public override bool OnEnter(ControlEventBase ceb)
	{
		base.OnEnter(ceb);
		//this.move.Reset();
		return true;
	}

	// Token: 0x06001F95 RID: 8085 RVA: 0x000D789C File Offset: 0x000D5A9C
	public override void OnExit()
	{
		base.OnExit();
		this.m_cControlMfs.ChangeStateToIdle();
	}

	// Token: 0x04001C60 RID: 7264
	private const float MAX_FALL_TIME = 3f;

	// Token: 0x04001C61 RID: 7265
	//private ControllerMovePhysics move;

	// Token: 0x04001C62 RID: 7266
	private float timeCount;
}
