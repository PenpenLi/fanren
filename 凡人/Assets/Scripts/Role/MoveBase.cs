using System;
using UnityEngine;

public class MoveBase
{
    public const float DAMP_DIS = 3f;

    public const float NORMAL_SPEED = 2f;

    public const float GRAVITY = 17f;

    public const float AIR_DAMP = 1f;

    public const float GROUND_DAMP = 15f;

    protected float m_fDis;

    protected float m_fSpeed;

    protected float m_fJumpHight;

    protected Transform m_cTarget;

    protected Vector3 m_vecTarget;

    protected ACTION_INDEX m_eAction;

    protected bool m_bEnbale;

    protected bool m_bGravity;

    protected bool m_bRotate;

    protected CharacterController m_cController;

    protected ModAnimation m_cAnimation;

    protected Role m_cRole;

    protected bool isStart;

    public MoveBase(Role role, CharacterController cc)
	{
		this.m_cRole = role;
		this.m_cAnimation = (ModAnimation)role.GetModule(MODULE_TYPE.MT_MOTION);
		this.m_cController = cc;
	}

	public bool Enable
	{
		get
		{
			return this.m_bEnbale;
		}
		set
		{
			this.m_bEnbale = value;
		}
	}

	public float Speed
	{
		get
		{
			return this.m_fSpeed;
		}
		set
		{
			this.m_fSpeed = value;
		}
	}

	public virtual bool Update()
	{
        //if (!this.m_bEnbale)
        //{
        //	return false;
        //}
        if (this.m_cRole == null)
        {
            return false;
        }
        if (this.m_cController == null)
        {
            return false;
        }
        if (this.m_cRole._roleType != ROLE_TYPE.RT_NPC)
		{
			//ModBuffProperty modBuffProperty = this.m_cRole.GetModule(MODULE_TYPE.MT_BUFF) as ModBuffProperty;
			//float num = (float)modBuffProperty.GetValue(BUFF_VALUE_TYPE.BIND);
			//if (num != 0f)
			//{
			//	return false;
			//}
		}
        if (this.m_bGravity)
        {
            this.m_cController.Move(Vector3.up * -17f);
        }
        if (!this.isStart)
        {
            if (this.m_eAction != ACTION_INDEX.AN_NONE)
            {
                //Debug.Log(m_eAction);
                //this.m_cAnimation.PlayAnimation(this.m_eAction, 1f, WrapMode.Loop, false, false, AnimationCullingType.BasedOnUserBounds, 0.2f);
            }
            this.isStart = true;
        }
        return true;
	}

	public virtual void Reset(ACTION_INDEX ai, float speed)
	{
		this.m_eAction = ai;
		this.m_fSpeed = speed;
		this.m_cTarget = null;
		this.m_vecTarget = Vector3.zero;
		this.m_bEnbale = true;
		this.m_bGravity = true;
		this.m_bRotate = true;
		this.m_fDis = 0f;
		this.isStart = false;
	}

	public virtual void Reset()
	{
		this.m_eAction = ACTION_INDEX.AN_WALK;
		this.m_fSpeed = 2f;
		this.m_cTarget = null;
		this.m_vecTarget = Vector3.zero;
		this.m_bEnbale = true;
		this.m_bGravity = true;
		this.m_bRotate = true;
		this.m_fDis = 0f;
		this.isStart = false;
	}

	public virtual void Stop()
	{
		this.m_bEnbale = false;
	}

	public void SetTargetTrans(Transform target)
	{
		this.m_cTarget = target;
	}

	public virtual void SetTargetPos(Vector3 target)
	{
		this.m_vecTarget = target;
	}

	public void SwitchGravity(bool b)
	{
		this.m_bGravity = b;
	}

	public void SwitchRotate(bool b)
	{
		this.m_bRotate = b;
	}

	public void SetDistance(float value)
	{
		this.m_fDis = value;
	}

	public void SetJumpHeight(float height)
	{
		this.m_fJumpHight = height;
	}
}
