using System;
using UnityEngine;

/// <summary>
/// 打击事件参数
/// </summary>
public class HitEventArgs : EventArgs
{
    public Collider collider { get; private set; }

    public Vector3 hitPoint { get; private set; }

    public Vector3 hitNormal { get; private set; }

    public Vector3 relativeSpeed { get; private set; }

    public HitEventArgs(Collider otherCollider)
	{
		this.collider = otherCollider;
	}

	public HitEventArgs(Collider otherCollider, Vector3 HitPoint)
	{
		this.collider = otherCollider;
		this.hitPoint = HitPoint;
	}

	public HitEventArgs(Collider otherCollider, Vector3 HitPoint, Vector3 HitNormal)
	{
		this.collider = otherCollider;
		this.hitPoint = HitPoint;
		this.hitNormal = HitNormal;
	}

	public HitEventArgs(Collider otherCollider, Vector3 HitPoint, Vector3 HitNormal, Vector3 RelativeSpeed)
	{
		this.collider = otherCollider;
		this.hitPoint = HitPoint;
		this.hitNormal = HitNormal;
		this.relativeSpeed = RelativeSpeed;
	}
}
