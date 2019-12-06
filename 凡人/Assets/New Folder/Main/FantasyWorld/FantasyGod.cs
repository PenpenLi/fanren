using System;
using UnityEngine;


public class FantasyGod
{
    public static FantasyGod Instance;

    public bool IsCreated;

    //public FantasyExecute Actor = new FantasyExecute();

    private Camera _sceneCamera;

    public Camera SceneCamera
	{
		get
		{
			if (this._sceneCamera == null)
			{
				GameObject mainCamera = Singleton<ActorManager>.GetInstance().MainCamera;
				if (mainCamera != null)
				{
					this._sceneCamera = mainCamera.GetComponent<Camera>();
				}
			}
			if (this._sceneCamera == null)
			{
				Debug.LogError("FantasyGod : SceneCamera error!");
			}
			return this._sceneCamera;
		}
	}

	public bool Create()
	{
		FantasyGod.Instance = this;
		this.IsCreated = true;
		return true;
	}

	public void FixUpdate()
	{
		//if (this.Actor != null)
		//{
		//	this.Actor.FixUpdate();
		//}
	}

	public void Update()
	{
		//if (this.Actor != null)
		//{
		//	this.Actor.Update();
		//}
	}
}
