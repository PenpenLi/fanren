using System;
using UnityEngine;
using UnityUtility;


public class ControlStateJump : ControlStateBase
{
   // private MoveJump m_cMove;

    private GameObject m_cSceneObj;

    //private ControlEventJump m_cEvent;

    private float m_fStartTime;

    public ControlStateJump(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.JUMP)
	{
		//this.m_cMove = new MoveJump(role, control);
	}

	//// Token: 0x06001FBD RID: 8125 RVA: 0x000D8A1C File Offset: 0x000D6C1C
	//public override bool Update()
	//{
	//	if (!base.Update())
	//	{
	//		return false;
	//	}
	//	if (!this.m_cEvent.P2P)
	//	{
	//		return this.m_cMove.Update();
	//	}
	//	float num = GameTime.time - this.m_fStartTime;
	//	if (num > this.m_cEvent.JumpTime)
	//	{
	//		this.m_cRole.GetTrans().position = this.m_cEvent.End;
	//		return false;
	//	}
	//	float t = num / this.m_cEvent.JumpTime;
	//	Vector3 position = Vector3.Lerp(this.m_cEvent.Start, this.m_cEvent.End, t);
	//	float num2 = num / (this.m_cEvent.JumpTime / 2f);
	//	float y;
	//	if (num2 > 1f)
	//	{
	//		num2 = 2f - num2;
	//		num2 = CMath.CubicOut(num2, 0f, 1f, 1f);
	//		y = Mathf.Lerp(this.m_cEvent.End.y, this.m_cEvent.Start.y + this.m_cEvent.JumpHeight, num2);
	//	}
	//	else
	//	{
	//		num2 = CMath.CubicOut(num2, 0f, 1f, 1f);
	//		y = Mathf.Lerp(this.m_cEvent.Start.y, this.m_cEvent.Start.y + this.m_cEvent.JumpHeight, num2);
	//	}
	//	position.y = y;
	//	this.m_cRole.GetTrans().position = position;
	//	return true;
	//}

	//// Token: 0x06001FBE RID: 8126 RVA: 0x000D8BB4 File Offset: 0x000D6DB4
	//public override bool OnEnter(ControlEventBase ceb)
	//{
	//	base.OnEnter(ceb);
	//	ControlEventJump controlEventJump = (ControlEventJump)ceb;
	//	this.m_cEvent = controlEventJump;
	//	this.m_fStartTime = GameTime.time;
	//	this.m_cSceneObj = null;
	//	if (controlEventJump.P2P)
	//	{
	//		this.m_cRole.GetTrans().rotation = Quaternion.LookRotation(controlEventJump.End - controlEventJump.Start);
	//		ModAnimation modAnimation = (ModAnimation)this.m_cRole.GetModule(MODULE_TYPE.MT_MOTION);
	//		modAnimation.PlayAnimation(ACTION_INDEX.AN_JUMP, 1f, WrapMode.ClampForever, false, true);
	//	}
	//	else
	//	{
	//		this.m_cMove.Reset(controlEventJump.JumpHeight, 0f, this.m_cRole.GetTrans().forward);
	//	}
	//	return true;
	//}

	// Token: 0x06001FBF RID: 8127 RVA: 0x000D8C6C File Offset: 0x000D6E6C
	public override void OnExit()
	{
		base.OnExit();
		if (this.m_cSceneObj != null)
		{
			this.m_cSceneObj.active = true;
		}
		this.m_cControlMfs.ChangeStateToIdle();
	}
}
