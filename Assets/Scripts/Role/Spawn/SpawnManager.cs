using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 刷怪点管理
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public int ID;

    public int moiveId = -1;

    [HideInInspector]
    public bool bPlayedMovieid;

    //public TriggerType triggerType;

    public int ExecScriptCondition = -1;

    public int ScriptMoudle = -1;

    public int ScriptData = -1;

    public bool bActived;

    private List<Role> _linkRoleList = new List<Role>();

    public int BevTreeID;

    public void ResetIt()
	{
		this.bActived = false;
		this._linkRoleList.Clear();
	}

	public void SpawnAllRole()
	{
		if (this.bActived)
		{
			return;
		}
		this.bActived = true;
		this._linkRoleList.Clear();
		//List<GameObjSpawn> spawnListByAdminId = SceneManager.RoleMan.GetSpawnListByAdminId(this.ID);
		//for (int i = 0; i < spawnListByAdminId.Count; i++)
		//{
		//	GameObjSpawn gameObjSpawn = spawnListByAdminId[i];
		//	if (gameObjSpawn != null && gameObjSpawn.gameObject.active)
		//	{
		//		gameObjSpawn.Enable();
		//		if (gameObjSpawn.LinkRole != null)
		//		{
		//			this._linkRoleList.Add(gameObjSpawn.LinkRole);
		//		}
		//	}
		//}
		if (this.moiveId != -1 && !this.bPlayedMovieid)
		{
			//MovieManager.MovieMag.PlayMovie(this.moiveId);
			this.bPlayedMovieid = true;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		//if (this.triggerType != TriggerType.collision)
		//{
		//	return;
		//}
		if (other.tag == "Player")
		{
			this.SpawnAllRole();
		}
	}


	private void EnableSpawn(int id)
	{
		//SceneManager.RoleMan.MakeMobByAdminID(id);
	}

	private void Update()
	{
		if (this.ExecScriptCondition == -1)
		{
			return;
		}
		if (this._linkRoleList.Count == 0)
		{
			return;
		}
		if (this.GetLiveRoleCount() <= this.ExecScriptCondition)
		{
			if (this.ScriptMoudle != -1 && this.ScriptData != -1)
			{
				GameData.Instance.ScrMan.Exec(this.ScriptMoudle, this.ScriptData);
			}
			base.gameObject.SetActiveRecursively(false);
		}
	}

	public void OnTriggerExit(Collider other)
	{
	}

	private int GetLiveRoleCount()
	{
		if (this._linkRoleList.Count == 0)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < this._linkRoleList.Count; i++)
		{
			if (this._linkRoleList[i] != null)
			{
				//if (!this._linkRoleList[i].IsDead())
				//{
				//	num++;
				//}
			}
		}
		return num;
	}
}
