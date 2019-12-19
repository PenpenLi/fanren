using System;
using UnityEngine;


public class ObjectState
{
    public GameObject Obj;

    public bool ObjState;

    public void ClearDate()
	{
		this.Obj = null;
		this.ObjState = true;
	}
}
