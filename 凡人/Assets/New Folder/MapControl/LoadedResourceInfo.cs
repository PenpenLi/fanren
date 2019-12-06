using System;
using UnityEngine;

public class LoadedResourceInfo
{
	public void Clear()
	{
		this.Obj = null;
	}

	public int ResId;

	public UnityEngine.Object Obj;

	public RES_TYPE rt;
}
