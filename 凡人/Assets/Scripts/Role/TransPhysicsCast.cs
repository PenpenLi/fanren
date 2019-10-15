using System;
using UnityEngine;

public class TransPhysicsCast : TransBevBase
{
    public float Gravity = 17f;

    public float AirDamp = 1f;

    private float costTime;

    private Vector3 targetPos;

    public Vector3 OrignForce { get; private set; }

	public Vector3 Force { get; private set; }

	public void SetValue(Transform actor, Vector3 force)
	{
		base.Trans = actor;
		this.SetForce(force);
	}

	public void SetForce(Vector3 force)
	{
		this.Force = force;
		this.OrignForce = this.Force;
	}

	public void SetTargetPos(Vector3 pos, float time)
	{
		this.costTime = time;
		this.targetPos = pos;
	}

	public override void SetCostTime(float time)
	{
		this.costTime = time;
	}

	public override void SetTargetPos(Vector3 target)
	{
		this.targetPos = target;
	}

	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		if (!this.isStarted)
		{
			//Vector3 force = MoveFunction.CalculateJumpFoceBetweenPointsByTime(this.costTime, this.Gravity, this.AirDamp, base.Trans.position, this.targetPos);
			//this.SetForce(force);
			//if (base.Trans.rigidbody != null)
			//{
			//	base.Trans.rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			//}
			this.isStarted = true;
		}
		if (this.Force == Vector3.zero)
		{
			return false;
		}
		base.Trans.Translate(this.Force * GameTime.deltaTime, Space.World);
		Vector3 a = this.Force;
		a.y = 0f;
		a = a.normalized * this.AirDamp;
		a.y = this.Gravity;
		this.Force -= a * GameTime.deltaTime;
		return true;
	}

	public bool IsFallDown()
	{
		return !(base.Trans == null) && this.Force.y < 0f;
	}

	public override void Reset()
	{
		base.Reset();
		this.Force = this.OrignForce;
	}

	public override void Destroy()
	{
		base.Destroy();
	}
}
