using System;
using UnityEngine;


public class ControlEventAttackIdle : ControlEventBase
{
    public Transform Target { get; private set; }

    public int AniIndex { get; private set; }

    public float LastTime { get; private set; }

    public ControlEventAttackIdle(bool Forced) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK_IDLE;
		this.m_bForced = Forced;
	}

	public ControlEventAttackIdle(bool Forced, Transform target, int aniIndex) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK_IDLE;
		this.m_bForced = Forced;
		this.Target = target;
		this.AniIndex = aniIndex;
	}

	public ControlEventAttackIdle(bool Forced, Transform target, int aniIndex, float lastTime) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK_IDLE;
		this.m_bForced = Forced;
		this.Target = target;
		this.AniIndex = aniIndex;
		this.LastTime = lastTime;
	}
}
