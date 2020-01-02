using System;
using UnityEngine;

/// <summary>
/// 旋转
/// </summary>
public class Rotate : TransBevBase
{
    public float RotateSpeed;

    public Vector3 LookDirection;

    public Rotate(Transform transform, float speed, Vector3 direction)
	{
		base.Trans = transform;
		this.RotateSpeed = speed;
		this.LookDirection = direction;
		this.CurrentAngle = Vector3.Angle(this.LookDirection, base.Trans.forward);
	}


	public float CurrentAngle { get; private set; }


	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		if (this.LookDirection == Vector3.zero)
		{
			return false;
		}
		Quaternion quaternion = Quaternion.LookRotation(this.LookDirection);
		this.CurrentAngle = Quaternion.Angle(quaternion, base.Trans.rotation);
		if (this.CurrentAngle <= GameTime.deltaTime * this.RotateSpeed)
		{
			this.CurrentAngle = 0f;
			base.Trans.rotation = quaternion;
			this.Enable = false;
			return false;
		}
		Quaternion rotation = Quaternion.RotateTowards(base.Trans.rotation, quaternion, this.RotateSpeed * GameTime.deltaTime);
		base.Trans.rotation = rotation;
		return true;
	}

	public override void Reset()
	{
		base.Reset();
	}

	public float GetCurrentAngle()
	{
		return this.CurrentAngle;
	}

	public override void Destroy()
	{
		base.Destroy();
	}
}
