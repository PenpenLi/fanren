using System;
using UnityEngine;

public class ControlStateIdle : ControlStateBase
{
	public ControlStateIdle(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.IDLE)
	{
	}

	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		base.CheckToFallingState();
		return true;
	}

	public override bool OnEnter(ControlEventBase ceb)
	{
		//this.m_cAnimation.PlayAnimation(ACTION_INDEX.AN_IDLE, WrapMode.Loop);
		return true;
	}

	public override void OnExit()
	{
		base.OnExit();
		this.m_cControlMfs.ChangeStateToIdle();
	}
}
