using System;
using UnityEngine;

public class GameObjSpawn : MonoBehaviour
{

    public string className = "MobSpawn";

    // Token: 0x04001088 RID: 4232
    public int ID;

    // Token: 0x04001089 RID: 4233
    public int ObjectType;

    // Token: 0x0400108A RID: 4234
    public string partroName;

    //public ORG_TYPE orgType;

    // Token: 0x0400108C RID: 4236
    public GameObjSpawn.SpawnType spaType;

    // Token: 0x0400108D RID: 4237
    public int SpawnManID;

    // Token: 0x0400108E RID: 4238
    public string areaName;

    // Token: 0x0400108F RID: 4239
    public int hatredRuleID;

    // Token: 0x04001090 RID: 4240
    public GameObjSpawn.SpawnInfo spawnInfo = default(GameObjSpawn.SpawnInfo);

    // Token: 0x04001091 RID: 4241
    private Role _linkRole;

    // Token: 0x04001092 RID: 4242
    //private OperableItemBase _operable;

    // Token: 0x04001093 RID: 4243
    //private SpawnManager sm;

    // Token: 0x04001094 RID: 4244
    private bool bMadeMob;

    // Token: 0x04001095 RID: 4245
    public int bevTreeID;

    // Token: 0x02000243 RID: 579
    public enum SpawnType
    {
        // Token: 0x04001097 RID: 4247
        MONSTER,
        // Token: 0x04001098 RID: 4248
        NPC,
        // Token: 0x04001099 RID: 4249
        CHEST,
        // Token: 0x0400109A RID: 4250
        HERBAL,
        // Token: 0x0400109B RID: 4251
        OBSTACLE,
        // Token: 0x0400109C RID: 4252
        SOULBALL,
        // Token: 0x0400109D RID: 4253
        ORGAN,
        // Token: 0x0400109E RID: 4254
        CORPSE
    }

    // Token: 0x02000244 RID: 580
    public struct SpawnInfo
    {
        // Token: 0x0400109F RID: 4255
        public int ID;

        // Token: 0x040010A0 RID: 4256
        public GameObjSpawn.SpawnType SType;

        // Token: 0x040010A1 RID: 4257
        public int ObjectType;

        // Token: 0x040010A2 RID: 4258
        public string partroName;

        // Token: 0x040010A3 RID: 4259
        public Vector3 position;

        // Token: 0x040010A4 RID: 4260
        public Quaternion rotation;

        // Token: 0x040010A5 RID: 4261
        //public ORG_TYPE orgType;

        // Token: 0x040010A6 RID: 4262
        public Vector3 forward;

        // Token: 0x040010A7 RID: 4263
        public string areaName;

        // Token: 0x040010A8 RID: 4264
        public int spawnManID;

        // Token: 0x040010A9 RID: 4265
        public int bevTreeID;

        // Token: 0x040010AA RID: 4266
        public Role parentRole;

        // Token: 0x040010AB RID: 4267
        public int hatredRuleID;

        // Token: 0x040010AC RID: 4268
        public int BornBev;
    }

    public Role LinkRole
	{
		get
		{
			return this._linkRole;
		}
		set
		{
			this._linkRole = value;
		}
	}

	private void Awake()
	{
		this.spawnInfo.ID = this.ID;
		this.spawnInfo.ObjectType = this.ObjectType;
		this.spawnInfo.partroName = this.partroName;
		this.spawnInfo.position = base.transform.position;
		this.spawnInfo.rotation = base.transform.rotation;
		this.spawnInfo.forward = base.transform.forward;
		//this.spawnInfo.orgType = this.orgType;
		this.spawnInfo.areaName = this.areaName;
		this.spawnInfo.SType = this.spaType;
		this.spawnInfo.spawnManID = this.SpawnManID;
		this.spawnInfo.bevTreeID = this.bevTreeID;
		this.spawnInfo.hatredRuleID = this.hatredRuleID;
	}

	private void CachePrefab()
	{
		//if (this.spawnInfo.orgType == ORG_TYPE.OT_MONSTER)
		//{
		//	MonsterInfo monsterInfoByID = GameData.Instance.RoleData.GetMonsterInfoByID(this.spawnInfo.ObjectType);
		//	if (monsterInfoByID != null)
		//	{
		//		RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(monsterInfoByID.ModelID);
		//	}
		//}
		//else if (this.spawnInfo.orgType == ORG_TYPE.OT_NPC)
		//{
		//	NpcInfo npcByType = GameData.Instance.RoleData.GetNpcByType(this.spawnInfo.ObjectType);
		//	if (npcByType != null)
		//	{
		//		RoleModelInfo roleModelInfo2 = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(npcByType.ModelID);
		//	}
		//}
	}

	private void Start()
	{
		//if (this.sm == null && this.SpawnManID != -1)
		//{
		//	this.sm = SceneManager.RoleMan.GetSMById(this.SpawnManID);
		//}
		//if (this.sm != null && this.spawnInfo.bevTreeID == -1)
		//{
		//	this.spawnInfo.bevTreeID = this.sm.BevTreeID;
		//}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawIcon(base.transform.position + Vector3.up, "RedFlag32.png");
	}

	public bool IsCreated()
	{
		return this.bMadeMob;
	}

	public void Enable()
	{
		if (this.bMadeMob)
		{
			return;
		}
		if (this.spawnInfo.SType == GameObjSpawn.SpawnType.MONSTER || this.spawnInfo.SType == GameObjSpawn.SpawnType.NPC)
		{
			if (this._linkRole != null)
			{
				this._linkRole = null;
			}
			//this._linkRole = FanrenSceneManager.RoleMan.CreateRoleGO(this.spawnInfo, true);
		}
		if (this.spawnInfo.SType == GameObjSpawn.SpawnType.SOULBALL || this.spawnInfo.SType == GameObjSpawn.SpawnType.CHEST || this.spawnInfo.SType == GameObjSpawn.SpawnType.HERBAL || this.spawnInfo.SType == GameObjSpawn.SpawnType.ORGAN)
		{
			//if (this._operable != null)
			//{
			//	this._operable = null;
			//}
			//this._operable = FanrenSceneManager.RoleMan.CreateOperItemGo(this.spawnInfo);
		}
		//if ((this._linkRole != null || this._operable != null) && this.SpawnManID < 1000)
		//{
		//	this.bMadeMob = true;
		//	base.gameObject.active = false;
		//}
	}

	public void OnDisable()
	{
	}
}
