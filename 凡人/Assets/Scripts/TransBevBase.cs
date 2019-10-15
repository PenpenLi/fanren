using System;
using UnityEngine;


public class TransBevBase : GameObjectBevBase
{
    protected EASING_TYPE easingType;

    public Transform Trans { get; protected set; }

	public EASING_TYPE EasingType
	{
		get
		{
			return this.easingType;
		}
		set
		{
			this.easingType = value;
		}
	}

	public virtual void SetActor(Transform trans)
	{
		this.Trans = trans;
		this.gameObject = trans.gameObject;
	}

	public override bool Update()
	{
		return base.Update() && !(this.Trans == null);
	}

	public override void Destroy()
	{
		base.Destroy();
		this.Trans = null;
	}

	public virtual void SetSpeed(float speed)
	{
	}

	public virtual void SetCostTime(float time)
	{
	}

	public virtual void SetTargetPos(Vector3 target)
	{
	}

	public virtual void SetTargetTrans(Transform target)
	{
	}

	public static TransBevBase CreatTransMove(MOVE_CLASS type)
	{
		TransBevBase result = null;
		if (type == MOVE_CLASS.CAST)
		{
			result = new TransPhysicsCast();
		}
		return result;
	}
}
