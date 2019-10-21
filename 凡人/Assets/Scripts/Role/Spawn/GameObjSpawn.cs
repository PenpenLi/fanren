using System;
using UnityEngine;

/// <summary>
/// 物品生成点
/// </summary>
public class GameObjSpawn : MonoBehaviour
{
    public string className = "MobSpawn";

    public int ID;

    public int ObjectType;

    public string partroName;

    public ORG_TYPE orgType;

    [Header("生成类型")]
    public GameObjSpawn.SpawnType spaType;

    public int SpawnManID;

    public string areaName;

    public int hatredRuleID;

    public GameObjSpawn.SpawnInfo spawnInfo = default(GameObjSpawn.SpawnInfo);

    private Role _linkRole;

    private OperableItemBase _operable;

    private SpawnManager sm;

    private bool bMadeMob;

    public int bevTreeID;

    /// <summary>
    /// 生成类型
    /// </summary>
    public enum SpawnType
    {
        /// <summary>
        /// 怪物
        /// </summary>
        MONSTER,
        NPC,
        CHEST,
        HERBAL,
        OBSTACLE,
        SOULBALL,
        ORGAN,
        CORPSE
    }

    /// <summary>
    /// 生成信息
    /// </summary>
    public struct SpawnInfo
    {
        public int ID;

        public GameObjSpawn.SpawnType SType;

        public int ObjectType;

        public string partroName;

        public Vector3 position;

        public Quaternion rotation;

        public ORG_TYPE orgType;

        public Vector3 forward;

        public string areaName;

        public int spawnManID;

        public int bevTreeID;

        public Role parentRole;

        public int hatredRuleID;

        public int BornBev;
    }

    /// <summary>
    /// 连接角色
    /// </summary>
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
		this.spawnInfo.orgType = this.orgType;
		this.spawnInfo.areaName = this.areaName;
		this.spawnInfo.SType = this.spaType;
		this.spawnInfo.spawnManID = this.SpawnManID;
		this.spawnInfo.bevTreeID = this.bevTreeID;
		this.spawnInfo.hatredRuleID = this.hatredRuleID;
	}

    /// <summary>
    /// 缓存预设
    /// </summary>
	private void CachePrefab()
	{
        if (this.spawnInfo.orgType == ORG_TYPE.OT_MONSTER)
        {
            MonsterInfo monsterInfoByID = GameData.Instance.RoleData.GetMonsterInfoByID(this.spawnInfo.ObjectType);
            if (monsterInfoByID != null)
            {
                RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(monsterInfoByID.ModelID);
            }
        }
        else if (this.spawnInfo.orgType == ORG_TYPE.OT_NPC)
        {
            NpcInfo npcByType = GameData.Instance.RoleData.GetNpcByType(this.spawnInfo.ObjectType);
            if (npcByType != null)
            {
                RoleModelInfo roleModelInfo2 = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(npcByType.ModelID);
            }
        }
    }

	private void Start()
	{
        if (this.sm == null && this.SpawnManID != -1)
        {
            this.sm = FanrenSceneManager.RoleMan.GetSMById(this.SpawnManID);
        }
        if (this.sm != null && this.spawnInfo.bevTreeID == -1)
        {
            this.spawnInfo.bevTreeID = this.sm.BevTreeID;
        }
    }

	private void OnDrawGizmos()
	{
		Gizmos.DrawIcon(base.transform.position + Vector3.up, "RedFlag32.png");
	}

    /// <summary>
    /// 是否创建
    /// </summary>
    /// <returns></returns>
	public bool IsCreated()
	{
		return this.bMadeMob;
	}

    /// <summary>
    /// 激活
    /// </summary>
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
			this._linkRole = FanrenSceneManager.RoleMan.CreateRoleGO(this.spawnInfo, true);
		}
		if (this.spawnInfo.SType == GameObjSpawn.SpawnType.SOULBALL || this.spawnInfo.SType == GameObjSpawn.SpawnType.CHEST || this.spawnInfo.SType == GameObjSpawn.SpawnType.HERBAL || this.spawnInfo.SType == GameObjSpawn.SpawnType.ORGAN)
		{
            if (this._operable != null)
            {
                this._operable = null;
            }
            this._operable = FanrenSceneManager.RoleMan.CreateOperItemGo(this.spawnInfo);
        }
        if ((this._linkRole != null || this._operable != null) && this.SpawnManID < 1000)
        {
            this.bMadeMob = true;
            base.gameObject.SetActive(false);
        }
    }

	public void OnDisable()
	{
	}
}
