using System;
using UnityEngine;

/// <summary>
/// 向前以前移动
/// </summary>
public class ControlEventMoveForward : ControlEventBase
{
    private Vector3 m_vecTarget;

    private ACTION_INDEX m_actIdx;

    private float m_speed;

    private bool m_rotate;

    private Vector3[] path;

    public Vector3 TargetPos
    {
        get
        {
            return this.m_vecTarget;
        }
    }

    public ACTION_INDEX ActIdx
    {
        get
        {
            return this.m_actIdx;
        }
    }

    public float Speed
    {
        get
        {
            return this.m_speed;
        }
    }

    public bool Rotate
    {
        get
        {
            return this.m_rotate;
        }
    }

    public Vector3[] Path
    {
        get
        {
            return this.path;
        }
    }

    public ControlEventMoveForward(bool Forced, Vector3 target, ACTION_INDEX act, float speed, bool rot) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.WALK_FORWARD;
		this.m_bForced = Forced;
		this.m_vecTarget = target;
		this.m_actIdx = act;
		this.m_rotate = rot;
		this.m_speed = speed;
	}

	public ControlEventMoveForward(bool Forced, ACTION_INDEX act, float speed, bool rot, Vector3[] paths) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.WALK_FORWARD;
		this.m_bForced = Forced;
		this.m_actIdx = act;
		this.m_rotate = rot;
		this.m_speed = speed;
		this.path = paths;
	}
}
