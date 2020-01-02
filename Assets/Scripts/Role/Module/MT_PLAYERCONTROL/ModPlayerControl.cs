using System;
using UnityEngine;


/// <summary>
/// 玩家控制模块
/// </summary>
public class ModPlayerControl : Module
{
    private Player player;

    public ModPlayerControl(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_PLAYERCONTROL;
		this.player = (Player)role;
	}

	public void DirectionInput(float VerInput, float HorInput)
	{
	}

	public override void Process()
	{
		base.Process();
		if (!KeyManager.hotKeyEnabled)
		{
			return;
		}
		//ControlStateBase currentState = this._role.modMFS.CurrentState;
		//if (currentState != null)
		//{
		//	if (currentState.GetState() == CONTROL_STATE.ATTACK)
		//	{
		//		this.AttackHandle(currentState);
		//	}
		//	else if (currentState.GetState() == CONTROL_STATE.ROLL)
		//	{
		//		this.AttackHandle(currentState);
		//	}
		//}
	}

	private void AttackHandle(ControlStateBase state)
	{
		if (GameTime.time - state.StartTime > state.GetBeforTime())
		{
			if (Input.GetMouseButtonDown(0))
			{
				//if (state.OverCall == null || state.OverCall != new Callback(this.player.Roll))
				//{
				//	state.OverCall = new Callback(this.player.Fight);
				//}
			}
			else
			{
				//if (Input.GetMouseButtonUp(0) && state.OverCall == new Callback(this.player.m_cModFight.StartGatherStrength))
				//{
				//	state.OverCall = null;
				//}
				//if (Input.GetMouseButton(0) && KeyManager.pressedTime > 0.3f)
				//{
				//	state.OverCall = new Callback(this.player.m_cModFight.StartGatherStrength);
				//}
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				//state.OverCall = new Callback(this.player.Roll);
			}
		}
	}
}
