using System;
using UnityEngine;


public class ColliderCheckObject : MonoBehaviour
{
    public LayerMask EffectiveLayer = -1;

    //public ColliderCheckHandle OnHitEnter;

    //public ColliderCheckHandle OnHitExit;

    //public ColliderCheckHandle OnHitStay;

    public virtual void OpenCheck()
	{
	}

	public virtual void CloseCheck()
	{
	}

	protected virtual void Start()
	{
	}

	//protected void EventCall(ColliderCheckHandle handle, object sender, HitEventArgs e)
	//{
	//	if (handle != null)
	//	{
	//		handle(sender, e);
	//	}
	//}

	public void ClearHandle()
	{
		//this.OnHitEnter = null;
		//this.OnHitExit = null;
		//this.OnHitStay = null;
	}

	public virtual Collider[] GetAllCollider()
	{
		return null;
	}

	public virtual bool IsChecking()
	{
		return false;
	}
}
