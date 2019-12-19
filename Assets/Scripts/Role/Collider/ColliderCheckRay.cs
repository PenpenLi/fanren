using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 检查射线
/// </summary>
public class ColliderCheckRay : ColliderCheckObject
{
    public override bool IsChecking()
    {
        return base.enabled;
    }

    private Dictionary<int, HitEventArgs> lastHit = new Dictionary<int, HitEventArgs>();

    private Dictionary<int, HitEventArgs> currentHit = new Dictionary<int, HitEventArgs>();

    public override void OpenCheck()
	{
		base.OpenCheck();
		base.enabled = true;
		this.Update();
	}

	public override void CloseCheck()
	{
		base.CloseCheck();
		base.enabled = false;
        this.lastHit.Clear();
        this.currentHit.Clear();
    }

	protected override void Start()
	{
		base.Start();
	}


	protected virtual void Update()
	{
	}

    protected HitEventArgs CreatEvent(RaycastHit hit)
    {
        return new HitEventArgs(hit.collider, hit.point, hit.normal);
    }


    protected HitEventArgs CreatEvent(Collider collider, Vector3 hitPoint, Vector3 hitNormal)
    {
        return new HitEventArgs(collider, hitPoint, hitNormal);
    }


    protected void StartHandle()
	{
        this.currentHit.Clear();
    }


    protected void TouchAGameObject(Collider collider, Vector3 hitPoint, Vector3 hitNormal)
	{
		if (collider == null)
		{
			return;
		}
		int instanceID = collider.gameObject.GetInstanceID();
        if (this.lastHit.ContainsKey(instanceID))
        {
            if (!this.currentHit.ContainsKey(instanceID))
            {
                HitEventArgs value = this.CreatEvent(collider, hitPoint, hitNormal);
                this.currentHit.Add(instanceID, value);
            }
        }
        else
        {
            HitEventArgs hitEventArgs = this.CreatEvent(collider, hitPoint, hitNormal);
            this.lastHit.Add(instanceID, hitEventArgs);
            this.currentHit.Add(instanceID, hitEventArgs);
            base.EventCall(this.OnHitEnter, this, hitEventArgs);
        }
    }

	protected void LastHandle()
	{
		List<int> list = new List<int>();
        foreach (int num in this.lastHit.Keys)
        {
            if (!this.currentHit.ContainsKey(num))
            {
                list.Add(num);
            }
            else
            {
                base.EventCall(this.OnHitStay, this, this.currentHit[num]);
            }
        }
        foreach (int key in list)
        {
            if (this.lastHit[key].collider != null)
            {
                base.EventCall(this.OnHitExit, this, this.lastHit[key]);
            }
            this.lastHit.Remove(key);
        }
    }
	
	protected Vector3[] GetPoints(Vector3 starsPosition, Vector3 endPosition, int amount)
	{
		if (amount == 0)
		{
			return null;
		}
		if (amount == 1)
		{
			return new Vector3[]
			{
				endPosition
			};
		}
		Vector3[] array = new Vector3[amount];
		Vector3 a = (endPosition - starsPosition) / (float)(amount - 1);
		for (int i = 0; i < amount; i++)
		{
			array[i] = starsPosition + a * (float)i;
		}
		return array;
	}
}
