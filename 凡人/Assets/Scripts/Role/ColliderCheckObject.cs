using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public class ColliderCheckObject : MonoBehaviour
{
    public LayerMask EffectiveLayer = -1;

    //public ColliderCheckHandle OnHitEnter;

    //// Token: 0x0400138B RID: 5003
    //public ColliderCheckHandle OnHitExit;

    //// Token: 0x0400138C RID: 5004
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
