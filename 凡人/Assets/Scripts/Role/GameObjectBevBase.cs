using System;
using UnityEngine;

public class GameObjectBevBase : UpdateBevBase
{
    protected GameObject gameObject;

    public virtual void SetGameObject(GameObject go)
	{
		this.gameObject = go;
	}

	public override bool Update()
	{
		return base.Update();
	}

	public override void Destroy()
	{
		base.Destroy();
		this.gameObject = null;
	}
}
