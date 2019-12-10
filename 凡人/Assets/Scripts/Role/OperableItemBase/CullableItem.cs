using System;
using UnityEngine;


public class CullableItem : MonoBehaviour
{
    public float lifeTime;

    public CullType cullType = CullType.Cull;

    public CullState State;

    public Transform myTransform;

    protected bool bProcess = true;

    private static int OBJ_ARY_LENGTH = 5;

    public ObjectState[] objArray = new ObjectState[CullableItem.OBJ_ARY_LENGTH];

    public virtual Vector3 GetPos()
	{
		if (this.myTransform != null)
		{
			return this.myTransform.position;
		}
		return Vector3.zero;
	}

	public void ClearObjArray()
	{
		for (int i = 0; i < this.objArray.Length; i++)
		{
			if (this.objArray[i] == null)
			{
				this.objArray[i] = new ObjectState();
			}
			this.objArray[i].ClearDate();
		}
	}

	public void AddObjToArray(int idx, GameObject obj, bool state)
	{
		if (idx < 0 || idx >= this.objArray.Length)
		{
			return;
		}
		this.objArray[idx].Obj = obj;
		this.objArray[idx].ObjState = state;
	}

	public virtual void LogicEnable()
	{
		foreach (ObjectState objectState in this.objArray)
		{
			if (objectState != null && !(objectState.Obj == null) && objectState.Obj.active != objectState.ObjState)
			{
				objectState.Obj.SetActiveRecursively(objectState.ObjState);
			}
		}
	}

	public virtual void LogicDiable()
	{
	}

	public void Start()
	{
		this.myTransform = base.transform;
	}
}
