using System;
using UnityEngine;

public class HurtGameObject : MonoBehaviour
{
    public float HurtScale = 1f;

    protected virtual void Start()
	{
		base.enabled = false;
	}

	//public virtual void Hurt(FightInfo info)
	//{
	//}

	public virtual int GetOwnerID()
	{
		return 0;
	}

	public virtual int GetBodyMaterialType()
	{
		return 0;
	}

	public virtual Collider[] GetCollider()
	{
		return null;
	}	
}
