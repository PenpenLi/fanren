using System;
using UnityEngine;

/// <summary>
/// 幻境世界
/// </summary>
public class FantasyWorld : MonoBehaviour
{
    private const string FANTASY_VERSION = "1.0.0 beta";

    public static FantasyWorld Instance;

    public bool IsCreated;

    //public FantasyGod Creator = new FantasyGod();

    //public FantasyAssist Assist = new FantasyAssist();

    // Token: 0x040011E6 RID: 4582
    private GameObject _excuteObject;

    public GameObject ExcuteObject
	{
		get
		{
			if (this._excuteObject == null)
			{
				this._excuteObject = new GameObject("ExcuteCenter");
			}
			return this._excuteObject;
		}
	}

	public bool Create()
	{
		//this._excuteObject = new GameObject("ExcuteCenter");
		//if (!this.Assist.Create())
		//{
		//	Debug.LogError("FantasyAssist created failed!");
		//	return false;
		//}
		//if (!this.Creator.Create())
		//{
		//	Debug.LogError("FantasyGod created failed!");
		//	return false;
		//}
		//this.IsCreated = true;
		return true;
	}

	private void Awake()
	{
		FantasyWorld.Instance = this;
	}

	private void FixUpdate()
	{
		if (!this.IsCreated)
		{
			return;
		}
		//if (this.Assist != null && this.Assist.IsCreated)
		//{
		//	this.Assist.FixUpdate();
		//}
		//if (this.Creator != null && this.Creator.IsCreated)
		//{
		//	this.Creator.FixUpdate();
		//}
	}

	private void Update()
	{
		if (!this.IsCreated)
		{
			return;
		}
		//if (this.Assist != null && this.Assist.IsCreated)
		//{
		//	this.Assist.Update();
		//}
		//if (this.Creator != null && this.Creator.IsCreated)
		//{
		//	this.Creator.Update();
		//}
	}

	public static string GetVersion()
	{
		return "1.0.0 beta";
	}
}
