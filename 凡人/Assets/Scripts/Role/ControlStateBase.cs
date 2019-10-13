using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlStateBase
{
    protected CONTROL_STATE m_eStateId;

    protected Role m_cRole;

    protected CharacterController m_cControl;

    protected ModAnimation m_cAnimation;

    protected ModControlMFS m_cControlMfs;

    //protected ModBehaviorAI modBevAi;

    //protected ModAttribute modAtt;

    protected float m_fStateStartTime;

    protected bool isLocked;

    protected bool isFree;

    private List<CONTROL_INPUT> m_lstBreakEvent = new List<CONTROL_INPUT>();

    public Callback OverCall;

    protected ControlEventBase m_cNextEvent;

    public ControlStateBase(Role role, CharacterController control, ModControlMFS mcm, CONTROL_STATE cs)
	{
		this.m_cRole = role;
		this.m_cControl = control;
		this.m_cAnimation = (ModAnimation)this.m_cRole.GetModule(MODULE_TYPE.MT_MOTION);
		//this.modBevAi = (this.m_cRole.GetModule(MODULE_TYPE.MT_AI_BEHAVIOR) as ModBehaviorAI);
		//this.modAtt = (this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute);
		this.m_cControlMfs = mcm;
		this.m_eStateId = cs;
	}

    //public List<CONTROL_INPUT> BreakEvent
    //{
    //	get
    //	{
    //		return this.m_lstBreakEvent;
    //	}
    //}

    public ControlEventBase NextEvent
    {
        get
        {
            return this.m_cNextEvent;
        }
        set
        {
            this.m_cNextEvent = value;
        }
    }

    public bool IsLocked
	{
		get
		{
			return this.isLocked;
		}
		set
		{
			this.isLocked = value;
		}
	}

	public bool IsFree
	{
		get
		{
			return this.isFree;
		}
		set
		{
			this.isFree = value;
		}
	}

	public float StartTime
	{
		get
		{
			return this.m_fStateStartTime;
		}
	}

	protected void CallOverMethod()
	{
		if (this.OverCall != null)
		{
			this.OverCall();
		}
		this.OverCall = null;
	}

	public virtual float GetBeforTime()
	{
		return 0f;
	}

	public virtual bool Update()
	{
		return this.m_cRole != null && this.m_cAnimation != null;
	}

	public CONTROL_STATE GetState()
	{
		return this.m_eStateId;
	}

    public virtual bool OnEnter(ControlEventBase tmpEvent)
    {
        this.m_fStateStartTime = GameTime.time;
        this.ResetEnterState();
        return true;
    }

    public virtual bool IsEffectTive(ControlEventBase tmpEvent)
    {
        return true;
    }

    public virtual void OnExit()
	{
	}

	public virtual bool Destory()
	{
		return true;
	}

	public virtual void EnterProcess()
	{
	}

	public virtual void ExitProcess()
	{
	}

	private void ResetEnterState()
	{
		this.isLocked = false;
		this.isFree = false;
		this.NextEvent = null;
		this.OverCall = null;
		this.m_lstBreakEvent.Clear();
	}

	protected void CheckToFallingState()
	{
		//if (this.m_cControl == null || !this.m_cControl.active)
		//{
		//	return;
		//}
		//this.m_cControl.Move(Vector3.up * -17f);
		//if (!this.m_cControl.isGrounded)
		//{
		//	this.m_cControlMfs.ChangeState(new ControlEventFalling(false));
		//}
	}
}
