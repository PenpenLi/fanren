using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;


public class RoleManager : MonoBehaviour
{
    //    private int[] id = new int[]
    //    {
    //        1,
    //        5017,
    //        5001,
    //        5013,
    //        5031
    //    };

    //    private int currentId;

          public List<Role> RoleObjList = new List<Role>();

    //    [HideInInspector]
    //    public List<Role> StageRoleList = new List<Role>();

          private GameObject _roleRootGO;

          private GameObject _playerRootGo;
  
          private GameObject _monsterRootGo;

          private GameObject operableRootGo;

          private GameObject monsterHpRoot;

    //    // Token: 0x040020D4 RID: 8404
    //    private List<Role> ignoreColliderRole = new List<Role>();


    private GameObject _npcRootGo;


      private GameObject _chestRootGo;

        private Player _player;

       [HideInInspector]
       public List<GameObjSpawn> MobSpawnList = new List<GameObjSpawn>();

    //    // Token: 0x040020D9 RID: 8409
    //    [HideInInspector]
    //    public List<SpawnManager> SpawnManList = new List<SpawnManager>();

    //    // Token: 0x040020DA RID: 8410
    //    [HideInInspector]
    //    public List<OperableItemBase> OperableItemList = new List<OperableItemBase>();

    //    // Token: 0x040020DB RID: 8411
    //    [HideInInspector]
    //    public List<HelpManager> HelpList = new List<HelpManager>();

    //    public GameObject MonsterHpRoot
    //	{
    //		get
    //		{
    //			if (this.monsterHpRoot == null)
    //			{
    //				this.monsterHpRoot = new GameObject();
    //				this.monsterHpRoot.name = "Hp";
    //			}
    //			return this.monsterHpRoot;
    //		}
    //	}

    private void Start()
    {
        GameData.CreatGameData();
        //this.ReadSpawnInfo();
        this.CreateRootObject();
        //this.UpdateSceneBySave();
        this.CreateRole();
        //this.UpdatePlayerBySave();
        this.InitPlayer();
        //this.InitOther();
        //SingletonMono<StageManager>.GetInstance().Read();
        //Singleton<EZGUIManager>.GetInstance().GetGUI<DieGUI>().AfterLoad();
        //Singleton<HpCautionEffect>.GetInstance().AdjustSize();
    }

    //	// Token: 0x0600244E RID: 9294 RVA: 0x000F6790 File Offset: 0x000F4990
    //	private void InitOther()
    //	{
    //		FantasyWorld.Instance.Assist.TimerMan.TimePause(false);
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().Show();
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>().Show();
    //	}


    private void CreateRole()
    {
        this.CreatePlayer();
        //this.CreateObject();
    }

    private void CreateRootObject()
    {
        if (this._roleRootGO == null)
        {
            this._roleRootGO = this.CreateRootGo("Role");
        }
        if (this.operableRootGo == null)
        {
            this.operableRootGo = new GameObject();
            this.operableRootGo.name = "Operable";
        }
        if (this._playerRootGo == null)
        {
            this._playerRootGo = this.CreateRootGo(this._roleRootGO, "Player");
        }
        if (this._monsterRootGo == null)
        {
            this._monsterRootGo = this.CreateRootGo(this._roleRootGO, "Monster");
        }
        if (this._npcRootGo == null)
        {
            this._npcRootGo = this.CreateRootGo(this._roleRootGO, "Npc");
        }
    }

    //	// Token: 0x06002451 RID: 9297 RVA: 0x000F68B4 File Offset: 0x000F4AB4
    //	private void CreateObject()
    //	{
    //		foreach (GameObjSpawn gameObjSpawn in this.MobSpawnList)
    //		{
    //			if (gameObjSpawn.transform.active && gameObjSpawn.SpawnManID == -1)
    //			{
    //				gameObjSpawn.Enable();
    //			}
    //		}
    //	}

    private void UpdateSceneBySave()
    {
        GameData.Instance.ItemMan.Clear();
        SaveData.SDSceneDate curSceneDate = SDManager.GetCurSceneDate();
        //if (curSceneDate != null)
        //{
        //    foreach (SaveData.SDMonsterDate sdmonsterDate in curSceneDate.MonsterList)
        //    {
        //        GameObjSpawn spawnInfoByID = this.GetSpawnInfoByID(sdmonsterDate.SpawnID);
        //        if (!(spawnInfoByID == null))
        //        {
        //            Role role = SceneManager.RoleMan.CreateRoleGO(spawnInfoByID.spawnInfo, true);
        //            if (role == null)
        //            {
        //                Debug.LogWarning(DU.Warning(new object[]
        //                {
        //                        spawnInfoByID.spawnInfo.ID
        //                }));
        //            }
        //            else
        //            {
        //                spawnInfoByID.LinkRole = role;
        //                Vector3 pos = new Vector3(sdmonsterDate.PosRat.PosX, sdmonsterDate.PosRat.PosY, sdmonsterDate.PosRat.PosZ);
        //                role.SetPos(pos);
        //                Vector3 rat = new Vector3(sdmonsterDate.PosRat.RatX, sdmonsterDate.PosRat.RatY, sdmonsterDate.PosRat.RatZ);
        //                role.SetRat(rat);
        //                ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
        //                if (modAttribute != null)
        //                {
        //                    modAttribute.SetAttList(sdmonsterDate.AttrList);
        //                }
        //            }
        //        }
        //    }
        //    foreach (OperableSaveDataBase osdb in curSceneDate.OperableList)
        //    {
        //        this.CreateOperItemGo(osdb);
        //    }
        //    foreach (SaveData.SDSpawn sdspawn in curSceneDate.SpawnList)
        //    {
        //        foreach (GameObjSpawn gameObjSpawn in this.MobSpawnList)
        //        {
        //            if (gameObjSpawn.ID == sdspawn.ID)
        //            {
        //                gameObjSpawn.transform.gameObject.active = sdspawn.Active;
        //                break;
        //            }
        //        }
        //    }
        //    foreach (SaveData.SDSpawnMan sdspawnMan in curSceneDate.SpawnManList)
        //    {
        //        foreach (SpawnManager spawnManager in this.SpawnManList)
        //        {
        //            if (spawnManager.ID == sdspawnMan.ID)
        //            {
        //                spawnManager.bPlayedMovieid = sdspawnMan.Active;
        //                break;
        //            }
        //        }
        //    }
        //    if (SceneManager.loadingFromSave)
        //    {
        //        SingletonMono<MusicManager>.GetInstance().PlayMusic(curSceneDate.musicData);
        //    }
        //    if (curSceneDate.FantasyData != null)
        //    {
        //        FantasyGod.Instance.Actor.PushSaveData(curSceneDate.FantasyData);
        //    }
        //}
    }

    //	// Token: 0x06002453 RID: 9299 RVA: 0x000F6CD0 File Offset: 0x000F4ED0
    //	private void UpdatePlayerBySave()
    //	{
    //		Player player = SceneManager.RoleMan.GetPlayer();
    //		if (player != null)
    //		{
    //			foreach (SaveData.SDPlayerDate sdplayerDate in SDManager.SDSave.SaveDateGame.PlayerList)
    //			{
    //				if (sdplayerDate.ID == player.ID)
    //				{
    //					if (!SDManager.SDSave.BeLoaded)
    //					{
    //						SDManager.SDSave.BeLoaded = true;
    //						Vector3 pos = new Vector3(sdplayerDate.PosRat.PosX, sdplayerDate.PosRat.PosY, sdplayerDate.PosRat.PosZ);
    //						player.SetPos(pos);
    //						Vector3 rat = new Vector3(sdplayerDate.PosRat.RatX, sdplayerDate.PosRat.RatY, sdplayerDate.PosRat.RatZ);
    //						player.SetRat(rat);
    //					}
    //					ModCamera modCamera = player.GetModule(MODULE_TYPE.MT_CAMERA) as ModCamera;
    //					modCamera.InitPosition();
    //					ModAttribute modAttribute = player.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //					if (modAttribute != null)
    //					{
    //						modAttribute.SetAttList(sdplayerDate.AttrList);
    //					}
    //					GameData.Instance.ItemMan.Clear();
    //					for (int i = 0; i < sdplayerDate.itemList.Count; i++)
    //					{
    //						ItemSaveData itemSaveData = sdplayerDate.itemList[i];
    //						if (itemSaveData != null)
    //						{
    //							List<CItemBase> list = new List<CItemBase>();
    //							GameData.Instance.ItemMan.CreateItem(itemSaveData.itemType, 1, itemSaveData.itemOwner, itemSaveData.dynamicProperty, ref list);
    //							if (list.Count >= 1)
    //							{
    //								list[0].SetItemFromSaveData(itemSaveData);
    //							}
    //						}
    //					}
    //					player.ItemFolder.WearOperate.ResetUsedEquip();
    //					player.ItemFolder.WearOperate.UpdateUsedEquip(true);
    //					ModSkillProperty modSkillProperty = player.GetModule(MODULE_TYPE.MT_SKILL) as ModSkillProperty;
    //					if (modSkillProperty != null)
    //					{
    //						modSkillProperty.SetSkillList(sdplayerDate.Skill.m_cSkills);
    //					}
    //					ModMission modMission = player.GetModule(MODULE_TYPE.MT_MISSION) as ModMission;
    //					if (modMission != null)
    //					{
    //						modMission.MisMask = sdplayerDate.Mission.misMask;
    //						modMission.misLinkList.Clear();
    //						for (int j = 0; j < sdplayerDate.Mission.misLinkList.Count; j++)
    //						{
    //							modMission.misLinkList.Add(sdplayerDate.Mission.misLinkList[j].Clone());
    //						}
    //						for (int k = 0; k < sdplayerDate.Mission.accMisList.Count; k++)
    //						{
    //							ModMission.AccMisInfo accMisInfo = sdplayerDate.Mission.accMisList[k].Clone2Nor();
    //							MissionInfo missionInfo = GameData.Instance.RoleData.GetMissionInfo(accMisInfo.ID);
    //							if (missionInfo != null)
    //							{
    //								accMisInfo.MisInfo = missionInfo;
    //								modMission.accMisList.Add(accMisInfo);
    //							}
    //						}
    //					}
    //					player.SystemHandbook.GetSDNote(sdplayerDate.Note);
    //					player.SystemAmbit.GetSaveData(sdplayerDate.Ambit);
    //					player.SystemFigure.GetSDFigure(sdplayerDate.Figure);
    //					player.SystemAmbit.GetSaveData(sdplayerDate.Ambit);
    //					player.m_cAdeptSystem.PushSDData(sdplayerDate.AdpTlnt, player, sdplayerDate.AdpTlnt._AddCount, sdplayerDate.AdpTlnt._AdeptTalentConfig, sdplayerDate.AdpTlnt._lastAdeptData);
    //					player.m_cMixtureSmelt.PushSDData(sdplayerDate.MxtSmlt._MixtureDataLst, sdplayerDate.MxtSmlt._MixtureFinalDataLst, sdplayerDate.MxtSmlt._MianLock);
    //					player.m_BottleSystem.PushSDData(sdplayerDate.BottleData);
    //					player._helpBase.PushData(sdplayerDate.HelpSave);
    //					player.m_RoleGrowDatas.PushData(sdplayerDate.RoleGrowDatas);
    //					GameData.Instance.ShopMan.ShopDataPush(sdplayerDate.ShopData);
    //				}
    //			}
    //			if (SDManager.SDSave.SaveDateGame.PlayerList.Count == 0)
    //			{
    //				GameData.Instance.ItemMan.Clear();
    //			}
    //			Singleton<HpCautionEffect>.GetInstance().Check();
    //		}
    //	}

    //	// Token: 0x06002454 RID: 9300 RVA: 0x000F70FC File Offset: 0x000F52FC
    //	public Role GetRoleByType(ROLE_TYPE roleType, int type)
    //	{
    //		for (int i = 0; i < this.RoleObjList.Count; i++)
    //		{
    //			Role role = this.RoleObjList[i];
    //			if (role != null)
    //			{
    //				if (role._roleType == roleType && role.GetDetailType() == type)
    //				{
    //					return role;
    //				}
    //			}
    //		}
    //		Debug.LogWarning("not find role id:" + type);
    //		return null;
    //	}

    /// <summary>
    /// 读取刷怪信息
    /// </summary>
    private void ReadSpawnInfo()
    {
        this.MobSpawnList.Clear();
        GameObject gameObject = GameObject.Find("MobSpawn");
        if (gameObject == null)
        {
            Debug.Log("Can't find MobSpawn");
        }
        else
        {
            foreach (object obj in gameObject.transform)
            {
                Transform transform = (Transform)obj;
                if (transform.gameObject.activeSelf)
                {
                    GameObjSpawn component = transform.GetComponent<GameObjSpawn>();
                    if (!(component == null))
                    {
                        this.MobSpawnList.Add(component);
                    }
                }
            }
        }
    }

    private void Update()
    {
        //Debug.Log(MobSpawnList.Count);
    }

    //	// Token: 0x06002456 RID: 9302 RVA: 0x000F72A0 File Offset: 0x000F54A0
    //	public SpawnManager GetSMById(int id)
    //	{
    //		for (int i = 0; i < this.SpawnManList.Count; i++)
    //		{
    //			if (id == this.SpawnManList[i].ID)
    //			{
    //				return this.SpawnManList[i];
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06002457 RID: 9303 RVA: 0x000F72F0 File Offset: 0x000F54F0
    //	public List<GameObjSpawn> GetSpawnListByAdminId(int id)
    //	{
    //		List<GameObjSpawn> list = new List<GameObjSpawn>();
    //		for (int i = 0; i < this.MobSpawnList.Count; i++)
    //		{
    //			if (this.MobSpawnList[i] != null && this.MobSpawnList[i].SpawnManID == id)
    //			{
    //				list.Add(this.MobSpawnList[i]);
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06002458 RID: 9304 RVA: 0x000F7360 File Offset: 0x000F5560
    //	public GameObjSpawn GetSpawnInfoByID(int ID)
    //	{
    //		foreach (GameObjSpawn gameObjSpawn in this.MobSpawnList)
    //		{
    //			if (gameObjSpawn != null && gameObjSpawn.ID == ID)
    //			{
    //				return gameObjSpawn;
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06002459 RID: 9305 RVA: 0x000F73E4 File Offset: 0x000F55E4
    //	public int GetSpawnInfoCount()
    //	{
    //		return this.MobSpawnList.Count;
    //	}

    private GameObject CreateRootGo(string name)
    {
        return new GameObject
        {
            name = name
        };
    }

    private GameObject CreateRootGo(GameObject parent, string name)
    {
        GameObject gameObject = this.CreateRootGo(name);
        gameObject.transform.parent = parent.transform;
        return gameObject;
    }

    private void CreatePlayer()
    {
        Player player = new Player();
        player.Create();
        player.GetTrans().parent = this._playerRootGo.transform;
        if (player.ID == 1)
        {
            this._player = player;
        }
        this.AddRole(player);
    }

    private void InitPlayer()
    {
        Player player = this.GetPlayer();
        if (player == null)
        {
            return;
        }
        //player.BindAutoMisson();
        //Player.LoadPlayerRes(player);
    }

    public Player GetPlayer()
    {
        return this._player;
    }

    //	// Token: 0x0600245F RID: 9311 RVA: 0x000F74B4 File Offset: 0x000F56B4
    //	private void CreateOperableRootGo()
    //	{
    //		if (this.operableRootGo == null)
    //		{
    //			this.operableRootGo = new GameObject();
    //			this.operableRootGo.name = "Operable";
    //		}
    //	}

    //	// Token: 0x06002460 RID: 9312 RVA: 0x000F74F0 File Offset: 0x000F56F0
    //	public Role GetCurControlRole()
    //	{
    //		for (int i = 0; i < this.RoleObjList.Count; i++)
    //		{
    //			if (this.RoleObjList[i] != null)
    //			{
    //				if (this.RoleObjList[i].GetModule(MODULE_TYPE.MT_CONTROLLER) != null)
    //				{
    //					return this.RoleObjList[i];
    //				}
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06002461 RID: 9313 RVA: 0x000F7554 File Offset: 0x000F5754
    //	public ModCamera GetCurPlayerCamera()
    //	{
    //		Role curControlRole = this.GetCurControlRole();
    //		if (curControlRole == null)
    //		{
    //			return null;
    //		}
    //		ModCamera modCamera = curControlRole.GetModule(MODULE_TYPE.MT_CAMERA) as ModCamera;
    //		if (modCamera == null)
    //		{
    //			return null;
    //		}
    //		return modCamera;
    //	}

    //    // Token: 0x06002462 RID: 9314 RVA: 0x000F7588 File Offset: 0x000F5788
    //    //private OperableChest CreateChestGo(GameObjSpawn.SpawnInfo spawnInfo)
    //    //{
    //    //	OperableChestInfo chestInfo = GameData.Instance.chest.GetChestInfo(spawnInfo.ObjectType);
    //    //	if (chestInfo == null)
    //    //	{
    //    //		return null;
    //    //	}
    //    //	GameObject gameObject = new GameObject(chestInfo.Name);
    //    //	gameObject.transform.parent = this.operableRootGo.transform;
    //    //	GameObject original = (GameObject)ResourceLoader.Load("Prefabs/Operable/" + chestInfo.Name, typeof(GameObject));
    //    //	GameObject gameObject2 = LoadMachine.InstantiateObject(original, Vector3.zero, Quaternion.identity) as GameObject;
    //    //	gameObject2.name = "Phy";
    //    //	gameObject2.transform.parent = gameObject.transform;
    //    //	gameObject2.transform.position = spawnInfo.position;
    //    //	gameObject2.transform.rotation = spawnInfo.rotation;
    //    //	OperableChest operableChest = gameObject2.AddComponent<OperableChest>();
    //    //	operableChest.Create(spawnInfo, chestInfo);
    //    //	this.AddOperable(operableChest);
    //    //	return operableChest;
    //    //}

    //    //// Token: 0x06002463 RID: 9315 RVA: 0x000F7670 File Offset: 0x000F5870
    //    //private OperableChest CreateChestGo(OperableSaveDataBase ocsd)
    //    //{
    //    //	GameObject gameObject = new GameObject("Chest");
    //    //	gameObject.transform.parent = this.operableRootGo.transform;
    //    //	OperableChestSaveData operableChestSaveData = ocsd as OperableChestSaveData;
    //    //	GameObjSpawn spawnInfoByID = SceneManager.RoleMan.GetSpawnInfoByID(operableChestSaveData.SpawnInfoId);
    //    //	if (spawnInfoByID == null)
    //    //	{
    //    //		return null;
    //    //	}
    //    //	GameObjSpawn.SpawnInfo spawnInfo = spawnInfoByID.spawnInfo;
    //    //	OperableChestInfo chestInfo = GameData.Instance.chest.GetChestInfo(operableChestSaveData.id);
    //    //	if (chestInfo == null)
    //    //	{
    //    //		return null;
    //    //	}
    //    //	GameObject original = (GameObject)ResourceLoader.Load("Prefabs/Operable/" + chestInfo.Name, typeof(GameObject));
    //    //	GameObject gameObject2 = LoadMachine.InstantiateObject(original, Vector3.zero, Quaternion.identity) as GameObject;
    //    //	gameObject2.name = "Phy";
    //    //	gameObject2.transform.parent = gameObject.transform;
    //    //	gameObject2.transform.position = spawnInfo.position;
    //    //	gameObject2.transform.rotation = spawnInfo.rotation;
    //    //	OperableChest operableChest = gameObject2.AddComponent<OperableChest>();
    //    //	operableChest.CreateBySaveData(operableChestSaveData);
    //    //	this.AddOperable(operableChest);
    //    //	return operableChest;
    //    //}

    //    //// Token: 0x06002464 RID: 9316 RVA: 0x000F778C File Offset: 0x000F598C
    //    //private OperableHerbal CreateHerbalGo(GameObjSpawn.SpawnInfo spawnInfo)
    //    //{
    //    //	OperableHerbalInfo herbalInfo = GameData.Instance.herbal.GetHerbalInfo(spawnInfo.ObjectType);
    //    //	if (herbalInfo == null)
    //    //	{
    //    //		Debug.LogWarning(DU.Warning(new object[]
    //    //		{
    //    //			"herbalInfo",
    //    //			spawnInfo.ObjectType
    //    //		}));
    //    //		return null;
    //    //	}
    //    //	OperableHerbal operableHerbal = new GameObject(herbalInfo.Name)
    //    //	{
    //    //		transform = 
    //    //		{
    //    //			parent = this.operableRootGo.transform
    //    //		}
    //    //	}.AddComponent<OperableHerbal>();
    //    //	operableHerbal.Create(spawnInfo, herbalInfo);
    //    //	this.AddOperable(operableHerbal);
    //    //	return operableHerbal;
    //    //}

    //    //// Token: 0x06002465 RID: 9317 RVA: 0x000F781C File Offset: 0x000F5A1C
    //    //private OperableHerbal CreateHerbalGo(OperableSaveDataBase ocsd)
    //    //{
    //    //	OperableHerbalSaveData operableHerbalSaveData = ocsd as OperableHerbalSaveData;
    //    //	GameObjSpawn spawnInfoByID = this.GetSpawnInfoByID(operableHerbalSaveData.SpawnInfoId);
    //    //	if (spawnInfoByID == null)
    //    //	{
    //    //		Debug.LogWarning(DU.Warning(new object[]
    //    //		{
    //    //			"SpawnObj null"
    //    //		}));
    //    //		return null;
    //    //	}
    //    //	OperableHerbalInfo herbalInfo = GameData.Instance.herbal.GetHerbalInfo(operableHerbalSaveData.id);
    //    //	if (herbalInfo == null)
    //    //	{
    //    //		Debug.LogWarning(DU.Warning(new object[]
    //    //		{
    //    //			"herbalInfo"
    //    //		}));
    //    //		return null;
    //    //	}
    //    //	OperableHerbal operableHerbal = new GameObject(herbalInfo.Name)
    //    //	{
    //    //		transform = 
    //    //		{
    //    //			parent = this.operableRootGo.transform
    //    //		}
    //    //	}.AddComponent<OperableHerbal>();
    //    //	operableHerbal.CreateBySaveData(operableHerbalSaveData);
    //    //	this.AddOperable(operableHerbal);
    //    //	return operableHerbal;
    //    //}

    //    //// Token: 0x06002466 RID: 9318 RVA: 0x000F78D8 File Offset: 0x000F5AD8
    //    //private OperableOrgan CreateOrganGo(GameObjSpawn.SpawnInfo spawnInfo)
    //    //{
    //    //	OperableOrganInfo organInfo = GameData.Instance.organ.GetOrganInfo(spawnInfo.ObjectType);
    //    //	if (organInfo == null)
    //    //	{
    //    //		return null;
    //    //	}
    //    //	OperableOrgan operableOrgan = OperableOrgan.Create(this.operableRootGo, spawnInfo, organInfo);
    //    //	this.AddOperable(operableOrgan);
    //    //	return operableOrgan;
    //    //}

    //    //// Token: 0x06002467 RID: 9319 RVA: 0x000F791C File Offset: 0x000F5B1C
    //    //private OperableCorpse CreateCorpse(GameObjSpawn.SpawnInfo spawnInfo, List<int> itemIdList)
    //    //{
    //    //	OperableCorpse operableCorpse = OperableCorpse.Create(this.operableRootGo, spawnInfo, itemIdList);
    //    //	if (operableCorpse != null)
    //    //	{
    //    //		this.AddOperable(operableCorpse);
    //    //	}
    //    //	return operableCorpse;
    //    //}

    //    //// Token: 0x06002468 RID: 9320 RVA: 0x000F794C File Offset: 0x000F5B4C
    //    //public OperableCorpse CreateCorpse(Vector3 pos, List<int> itemIdList)
    //    //{
    //    //	return this.CreateCorpse(new GameObjSpawn.SpawnInfo
    //    //	{
    //    //		position = pos,
    //    //		rotation = Quaternion.identity,
    //    //		ObjectType = 0,
    //    //		SType = GameObjSpawn.SpawnType.CORPSE
    //    //	}, itemIdList);
    //    //}

    //    // Token: 0x06002469 RID: 9321 RVA: 0x000F7990 File Offset: 0x000F5B90
    //    //private OpeSoulBall CreateSoulBall(GameObjSpawn.SpawnInfo spawnInfo)
    //    //{
    //    //    SoulBallInfo soulBallInfoById = GameData.Instance.RoleData.GetSoulBallInfoById(spawnInfo.ObjectType);
    //    //    if (soulBallInfoById == null)
    //    //    {
    //    //        return null;
    //    //    }
    //    //    OpeSoulBall opeSoulBall = OpeSoulBall.Create(this.operableRootGo, spawnInfo, soulBallInfoById);
    //    //    this.AddOperable(opeSoulBall);
    //    //    return opeSoulBall;
    //    //}

    //    //// Token: 0x0600246A RID: 9322 RVA: 0x000F79D4 File Offset: 0x000F5BD4
    //    //public OpeSoulBall CreateSoulBall(int nType, Vector3 pos)
    //    //{
    //    //    return this.CreateSoulBall(new GameObjSpawn.SpawnInfo
    //    //    {
    //    //        position = pos,
    //    //        rotation = Quaternion.identity,
    //    //        ObjectType = nType,
    //    //        SType = GameObjSpawn.SpawnType.SOULBALL
    //    //    });
    //    //}

    //    // Token: 0x0600246B RID: 9323 RVA: 0x000F7A14 File Offset: 0x000F5C14
    //    public Role CreateMonsterGO(GameObjSpawn.SpawnInfo spawnInfo)
    //	{
    //		MonsterInfo monsterInfoByID = GameData.Instance.RoleData.GetMonsterInfoByID(spawnInfo.ObjectType);
    //		if (monsterInfoByID == null)
    //		{
    //			return null;
    //		}
    //		Monster monster = Monster.Create(this._monsterRootGo, spawnInfo, monsterInfoByID);
    //		this.AddRole(monster);
    //		return monster;
    //	}

    //	// Token: 0x0600246C RID: 9324 RVA: 0x000F7A58 File Offset: 0x000F5C58
    //	private Role CreateNpcGo(GameObjSpawn.SpawnInfo spawnInfo)
    //	{
    //		NpcInfo npcByType = GameData.Instance.RoleData.GetNpcByType(spawnInfo.ObjectType);
    //		if (npcByType == null)
    //		{
    //			return null;
    //		}
    //		Npc npc = Npc.Create(this._npcRootGo, spawnInfo, npcByType);
    //		this.AddRole(npc);
    //		return npc;
    //	}

    //	// Token: 0x0600246D RID: 9325 RVA: 0x000F7A9C File Offset: 0x000F5C9C
    //	public bool HaveObjectOnPos(Vector3 pos)
    //	{
    //		for (int i = 0; i < this.RoleObjList.Count; i++)
    //		{
    //			if (this.RoleObjList[i] != null && (pos - this.RoleObjList[i].GetPos()).sqrMagnitude < 1f)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	//// Token: 0x0600246E RID: 9326 RVA: 0x000F7B04 File Offset: 0x000F5D04
    //	//public OperableItemBase CreateOperItemGo(GameObjSpawn.SpawnInfo spawnInfo)
    //	//{
    //	//	while (this.HaveObjectOnPos(spawnInfo.position))
    //	//	{
    //	//		spawnInfo.position = RoleBaseFun.GetRandomPosInRadius(spawnInfo.position, 3f);
    //	//	}
    //	//	if (spawnInfo.SType == GameObjSpawn.SpawnType.CHEST)
    //	//	{
    //	//		return this.CreateChestGo(spawnInfo);
    //	//	}
    //	//	if (spawnInfo.SType == GameObjSpawn.SpawnType.HERBAL)
    //	//	{
    //	//		return this.CreateHerbalGo(spawnInfo);
    //	//	}
    //	//	if (spawnInfo.SType == GameObjSpawn.SpawnType.SOULBALL)
    //	//	{
    //	//		return this.CreateSoulBall(spawnInfo);
    //	//	}
    //	//	if (spawnInfo.SType == GameObjSpawn.SpawnType.ORGAN)
    //	//	{
    //	//		return this.CreateOrganGo(spawnInfo);
    //	//	}
    //	//	return null;
    //	//}

    //	//// Token: 0x0600246F RID: 9327 RVA: 0x000F7B98 File Offset: 0x000F5D98
    //	//public OperableItemBase CreateOperItemGo(OperableSaveDataBase osdb)
    //	//{
    //	//	if (osdb.type == OperableItemBase.OperableItemType.Op_ChestOpe)
    //	//	{
    //	//		return this.CreateChestGo(osdb);
    //	//	}
    //	//	if (osdb.type == OperableItemBase.OperableItemType.Op_HerbalOpe)
    //	//	{
    //	//		return this.CreateHerbalGo(osdb);
    //	//	}
    //	//	if (osdb.type == OperableItemBase.OperableItemType.Op_SoulBall)
    //	//	{
    //	//	}
    //	//	if (osdb.type == OperableItemBase.OperableItemType.Op_OrganOpe)
    //	//	{
    //	//	}
    //	//	return null;
    //	//}

    //	// Token: 0x06002470 RID: 9328 RVA: 0x000F7BE8 File Offset: 0x000F5DE8
    //	public Role CreateRoleGO(GameObjSpawn.SpawnInfo spawnInfo, bool isSave)
    //	{
    //		Role role = null;
    //		while (this.HaveObjectOnPos(spawnInfo.position))
    //		{
    //			spawnInfo.position = RoleBaseFun.GetRandomPosInRadius(spawnInfo.position, 3f);
    //		}
    //		if (spawnInfo.SType == GameObjSpawn.SpawnType.MONSTER)
    //		{
    //			role = this.CreateMonsterGO(spawnInfo);
    //		}
    //		if (spawnInfo.SType == GameObjSpawn.SpawnType.NPC)
    //		{
    //			role = this.CreateNpcGo(spawnInfo);
    //		}
    //		if (!isSave && role != null)
    //		{
    //			if (this.StageRoleList.Contains(role))
    //			{
    //				Debug.Log(DU.Err(new object[]
    //				{
    //					role.name
    //				}));
    //			}
    //			else
    //			{
    //				this.StageRoleList.Add(role);
    //			}
    //		}
    //		return role;
    //	}

    //	// Token: 0x06002471 RID: 9329 RVA: 0x000F7C98 File Offset: 0x000F5E98
    //	public void ClearRole()
    //	{
    //		this.RoleObjList.Clear();
    //		this.ignoreColliderRole.Clear();
    //	}


    public void AddRole(Role role)
    {
        this.RoleObjList.Add(role);
        //foreach (Role role2 in this.ignoreColliderRole)
        //{
        //    if (role2 != null)
        //    {
        //        if (role.roleGameObject.RoleController.enabled)
        //        {
        //            if (role2.roleGameObject.RoleController.enabled)
        //            {
        //                if (role.roleGameObject.RoleController.active && role2.roleGameObject.RoleController.active)
        //                {
        //                    Physics.IgnoreCollision(role.roleGameObject.RoleController, role2.roleGameObject.RoleController, true);
        //                }
        //            }
        //        }
        //    }
        //}
    }

    //	// Token: 0x06002473 RID: 9331 RVA: 0x000F7DA0 File Offset: 0x000F5FA0
    //	public void DestroyAllRole()
    //	{
    //		foreach (Role role in this.RoleObjList)
    //		{
    //			if (role._roleType == ROLE_TYPE.RT_PLAYER)
    //			{
    //				Singleton<RoleAnimationManager>.GetInstance().DetachAllAnimation(role);
    //			}
    //			if (role != null)
    //			{
    //				role.DestroyRole();
    //			}
    //		}
    //		this.ClearRole();
    //	}

    //	// Token: 0x06002474 RID: 9332 RVA: 0x000F7E28 File Offset: 0x000F6028
    //	public List<Role> GetRoleList()
    //	{
    //		return this.RoleObjList;
    //	}

    //	// Token: 0x06002475 RID: 9333 RVA: 0x000F7E30 File Offset: 0x000F6030
    //	public Role GetRole(int roleId)
    //	{
    //		foreach (Role role in this.RoleObjList)
    //		{
    //			if (role.ID == roleId)
    //			{
    //				return role;
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06002476 RID: 9334 RVA: 0x000F7EA8 File Offset: 0x000F60A8
    //	public bool DelRole(Role role)
    //	{
    //		if (role == null)
    //		{
    //			return false;
    //		}
    //		role.DestroyRole();
    //		this.RoleObjList.Remove(role);
    //		if (this.ignoreColliderRole.Contains(role))
    //		{
    //			this.ignoreColliderRole.Remove(role);
    //		}
    //		return true;
    //	}

    //	// Token: 0x06002477 RID: 9335 RVA: 0x000F7EF0 File Offset: 0x000F60F0
    //	public bool DelRole(int roleId)
    //	{
    //		foreach (Role role in this.RoleObjList)
    //		{
    //			if (role.ID == roleId)
    //			{
    //				return this.DelRole(role);
    //			}
    //		}
    //		return false;
    //	}

    //	// Token: 0x06002478 RID: 9336 RVA: 0x000F7F6C File Offset: 0x000F616C
    //	public void ClearOperable()
    //	{
    //		foreach (OperableItemBase operableItemBase in this.OperableItemList)
    //		{
    //			if (!(operableItemBase == null))
    //			{
    //				GameObject gameObject = operableItemBase.gameObject;
    //				if (!(gameObject == null))
    //				{
    //					if (operableItemBase is OperableChest)
    //					{
    //						gameObject = operableItemBase.transform.parent.gameObject;
    //					}
    //					UnityEngine.Object.Destroy(gameObject);
    //				}
    //			}
    //		}
    //		this.OperableItemList.Clear();
    //	}

    //	// Token: 0x06002479 RID: 9337 RVA: 0x000F8024 File Offset: 0x000F6224
    //	public void AddOperable(OperableItemBase operable)
    //	{
    //		this.OperableItemList.Add(operable);
    //	}

    //	// Token: 0x0600247A RID: 9338 RVA: 0x000F8034 File Offset: 0x000F6234
    //	public List<OperableItemBase> GetOperableList()
    //	{
    //		return this.OperableItemList;
    //	}

    //	// Token: 0x0600247B RID: 9339 RVA: 0x000F803C File Offset: 0x000F623C
    //	public OperableItemBase GetOperableByResID(int nType, int id)
    //	{
    //		foreach (OperableItemBase operableItemBase in this.OperableItemList)
    //		{
    //			if (operableItemBase.id == id && operableItemBase.type == (OperableItemBase.OperableItemType)nType)
    //			{
    //				return operableItemBase;
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x0600247C RID: 9340 RVA: 0x000F80C0 File Offset: 0x000F62C0
    //	public OperableItemBase GetOperable(int OperableId)
    //	{
    //		foreach (OperableItemBase operableItemBase in this.OperableItemList)
    //		{
    //			if (operableItemBase.index == OperableId)
    //			{
    //				return operableItemBase;
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x0600247D RID: 9341 RVA: 0x000F8138 File Offset: 0x000F6338
    //	public bool DelOperable(OperableItemBase Operable)
    //	{
    //		return this.OperableItemList.Remove(Operable);
    //	}

    //	// Token: 0x0600247E RID: 9342 RVA: 0x000F8148 File Offset: 0x000F6348
    //	public bool DelOperable(int OperableId)
    //	{
    //		foreach (OperableItemBase operableItemBase in this.OperableItemList)
    //		{
    //			if (operableItemBase.index == OperableId)
    //			{
    //				return this.OperableItemList.Remove(operableItemBase);
    //			}
    //		}
    //		return false;
    //	}

    //	// Token: 0x0600247F RID: 9343 RVA: 0x000F81C8 File Offset: 0x000F63C8
    //	private List<Role> GetRoleListByOrg(Role role, int nType)
    //	{
    //		ModOrganization modOrganization = role.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //		if (modOrganization == null)
    //		{
    //			return null;
    //		}
    //		List<Role> list = new List<Role>();
    //		list.Clear();
    //		for (int i = 0; i < role.hatred.HatredList.Count; i++)
    //		{
    //			Role roleObj = role.hatred.HatredList[i].RoleObj;
    //			if (roleObj != null && roleObj.isAlive())
    //			{
    //				if (role.ID != roleObj.ID)
    //				{
    //					ModOrganization modOrganization2 = roleObj.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //					if (modOrganization2 != null)
    //					{
    //						if (nType == 0 && modOrganization.IsEnmity(modOrganization2.OrgType))
    //						{
    //							list.Add(roleObj);
    //						}
    //						if (nType == 1 && modOrganization.OrgType == modOrganization2.OrgType)
    //						{
    //							list.Add(roleObj);
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06002480 RID: 9344 RVA: 0x000F82BC File Offset: 0x000F64BC
    //	public List<Role> GetAllyRole(Role role)
    //	{
    //		return this.GetRoleListByOrg(role, 1);
    //	}

    //	// Token: 0x06002481 RID: 9345 RVA: 0x000F82C8 File Offset: 0x000F64C8
    //	public void CheckRoleInView(Role role)
    //	{
    //		if (role == null)
    //		{
    //			return;
    //		}
    //		ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (modAttribute == null)
    //		{
    //			return;
    //		}
    //		float attributeValue = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_VIEW_RANGE);
    //		for (int i = 0; i < this.RoleObjList.Count; i++)
    //		{
    //			Role role2 = this.RoleObjList[i];
    //			if (role2 != null && role2.ID != role.ID && !role2.IsDead())
    //			{
    //				float num = Vector3.Distance(role.GetPos(), role2.GetPos());
    //				if (num <= attributeValue)
    //				{
    //					if (role.hatred.GetHatredInfo(role2) == null)
    //					{
    //						float num2;
    //						if (!role.IsEnemy(role2))
    //						{
    //							num2 = 0f;
    //						}
    //						else
    //						{
    //							num2 = RoleHatred.GetInitialHatredValue(role, role2);
    //						}
    //						if (role2 is Player && role is Monster && num2 > 0f)
    //						{
    //							Monster monster = (Monster)role;
    //							monster.FindPlayer = true;
    //						}
    //						role.hatred.SetHatred(role2, num2);
    //					}
    //				}
    //				else if (num > attributeValue * 1.5f)
    //				{
    //					role.hatred.RemoveRoleFromHatred(role2);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06002482 RID: 9346 RVA: 0x000F83FC File Offset: 0x000F65FC
    //	public List<Role> GetEnmityRole(Role role)
    //	{
    //		return this.GetRoleListByOrg(role, 0);
    //	}

    //	// Token: 0x06002483 RID: 9347 RVA: 0x000F8408 File Offset: 0x000F6608
    //	public int GetAttackingAlly(Role role, Role targetRole)
    //	{
    //		List<Role> allyRole = this.GetAllyRole(role);
    //		int num = 0;
    //		foreach (Role role2 in allyRole)
    //		{
    //			if (role2 != null)
    //			{
    //				if (role2.GetModule(MODULE_TYPE.MT_AI_BEHAVIOR) is ModBehaviorAI)
    //				{
    //					if (role2.modMFS.GetCurrentStateId() == CONTROL_STATE.ATTACK)
    //					{
    //						num++;
    //					}
    //				}
    //			}
    //		}
    //		return num;
    //	}

    //	// Token: 0x06002484 RID: 9348 RVA: 0x000F84A8 File Offset: 0x000F66A8
    //	public Role GetAllyInViewTarget(Role role)
    //	{
    //		List<Role> allyRole = this.GetAllyRole(role);
    //		if (allyRole == null)
    //		{
    //			return null;
    //		}
    //		foreach (Role role2 in allyRole)
    //		{
    //			if (role2 != null)
    //			{
    //				ModBehaviorAI modBehaviorAI = role2.GetModule(MODULE_TYPE.MT_AI_BEHAVIOR) as ModBehaviorAI;
    //				if (modBehaviorAI != null)
    //				{
    //					if (modBehaviorAI._enmityTarget != null)
    //					{
    //						float sqrMagnitude = (role2.GetPos() - modBehaviorAI._enmityTarget.GetPos()).sqrMagnitude;
    //						ModAttribute modAttribute = role2.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //						if (modAttribute != null)
    //						{
    //							float attributeValue = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_VIEW_RANGE);
    //							if (sqrMagnitude < attributeValue * attributeValue)
    //							{
    //								return modBehaviorAI._enmityTarget;
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06002485 RID: 9349 RVA: 0x000F85AC File Offset: 0x000F67AC
    //	public List<Role> GetNearestParty(Role role, Vector3 pos, float range)
    //	{
    //		if (role == null)
    //		{
    //			return null;
    //		}
    //		List<Role> allyRole = this.GetAllyRole(role);
    //		if (allyRole == null)
    //		{
    //			return null;
    //		}
    //		List<Role> list = new List<Role>();
    //		for (int i = 0; i < allyRole.Count; i++)
    //		{
    //			Role role2 = allyRole[i];
    //			if (role2 != null)
    //			{
    //				if ((pos - role2.GetPos()).sqrMagnitude < range * range)
    //				{
    //					list.Add(role2);
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06002486 RID: 9350 RVA: 0x000F8628 File Offset: 0x000F6828
    //	public List<Role> GetNearestPartyEx(Role role, Vector3 pos, float range)
    //	{
    //		if (role == null)
    //		{
    //			return null;
    //		}
    //		List<Role> allyRole = this.GetAllyRole(role);
    //		if (allyRole == null)
    //		{
    //			return null;
    //		}
    //		List<Role> list = new List<Role>();
    //		for (int i = 0; i < allyRole.Count; i++)
    //		{
    //			Role role2 = allyRole[i];
    //			if (role2 != null)
    //			{
    //				if ((pos - role2.GetPos()).sqrMagnitude < range * range && role.isAlive())
    //				{
    //					list.Add(role2);
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06002487 RID: 9351 RVA: 0x000F86B0 File Offset: 0x000F68B0
    //	public List<Role> GetAllRoles()
    //	{
    //		List<Role> list = new List<Role>();
    //		foreach (Role role in this.RoleObjList)
    //		{
    //			if (!role.IsDieing())
    //			{
    //				list.Add(role);
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06002488 RID: 9352 RVA: 0x000F8728 File Offset: 0x000F6928
    //	public List<Role> GetAllMonsters(ROLE_TYPE type)
    //	{
    //		List<Role> list = new List<Role>();
    //		foreach (Role role in this.RoleObjList)
    //		{
    //			if (role._roleType == type)
    //			{
    //				list.Add(role);
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06002489 RID: 9353 RVA: 0x000F87A4 File Offset: 0x000F69A4
    //	public Role GetMonster(ROLE_TYPE type, int monsterID)
    //	{
    //		Role result = null;
    //		foreach (Role role in this.RoleObjList)
    //		{
    //			if (role._roleType == type && role.GetDetailType() == monsterID)
    //			{
    //				result = role;
    //			}
    //		}
    //		return result;
    //	}

    //	// Token: 0x0600248A RID: 9354 RVA: 0x000F8820 File Offset: 0x000F6A20
    //	public List<Role> GetNearestNPC(Role role, Vector3 pos, float range)
    //	{
    //		if (role == null)
    //		{
    //			return null;
    //		}
    //		List<Role> allRoles = this.GetAllRoles();
    //		if (allRoles == null)
    //		{
    //			return null;
    //		}
    //		List<Role> list = new List<Role>();
    //		List<Role> list2 = new List<Role>();
    //		foreach (Role role2 in allRoles)
    //		{
    //			if (role2._roleType == ROLE_TYPE.RT_NPC)
    //			{
    //				list2.Add(role2);
    //			}
    //		}
    //		for (int i = 0; i < list2.Count; i++)
    //		{
    //			Role role3 = list2[i];
    //			if (role3 != null)
    //			{
    //				if ((pos - role3.GetPos()).sqrMagnitude < range * range)
    //				{
    //					list.Add(role3);
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x0600248B RID: 9355 RVA: 0x000F890C File Offset: 0x000F6B0C
    //	public Role GetNearestRole(Role role, List<Role> roleList)
    //	{
    //		float num = float.MaxValue;
    //		Role result = null;
    //		foreach (Role role2 in roleList)
    //		{
    //			if (role2 != null && role2.isAlive())
    //			{
    //				Vector3 vector = new Vector3(role.GetPos().x, 0f, role.GetPos().z) - new Vector3(role2.GetPos().x, 0f, role2.GetPos().z);
    //				if (vector.magnitude < num)
    //				{
    //					num = vector.magnitude;
    //					result = role2;
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	// Token: 0x0600248C RID: 9356 RVA: 0x000F89F4 File Offset: 0x000F6BF4
    //	public Role GetPriorAttackRole(Role role)
    //	{
    //		if (role.hatred == null)
    //		{
    //			return null;
    //		}
    //		List<Role> maxHatredRole = role.hatred.GetMaxHatredRole(role);
    //		return this.GetNearestRole(role, maxHatredRole);
    //	}

    //	// Token: 0x0600248D RID: 9357 RVA: 0x000F8A24 File Offset: 0x000F6C24
    //	public Role GetNearestEnmity(Role role)
    //	{
    //		if (role == null)
    //		{
    //			return null;
    //		}
    //		ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (modAttribute != null)
    //		{
    //			float attributeValue = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_VIEW_RANGE);
    //		}
    //		List<Role> enmityRole = this.GetEnmityRole(role);
    //		if (enmityRole == null)
    //		{
    //			return null;
    //		}
    //		return this.GetNearestRole(role, enmityRole);
    //	}

    //	// Token: 0x0600248E RID: 9358 RVA: 0x000F8A78 File Offset: 0x000F6C78
    //	public List<Role> GetNearestEnmitys(Role role)
    //	{
    //		if (role == null)
    //		{
    //			return null;
    //		}
    //		ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		float num = 0f;
    //		if (modAttribute != null)
    //		{
    //			num = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_VIEW_RANGE);
    //		}
    //		List<Role> enmityRole = this.GetEnmityRole(role);
    //		if (enmityRole == null)
    //		{
    //			Debug.LogWarning(" error ");
    //			return null;
    //		}
    //		List<Role> list = new List<Role>();
    //		for (int i = 0; i < enmityRole.Count; i++)
    //		{
    //			Role role2 = enmityRole[i];
    //			if (role2 != null)
    //			{
    //				if ((role.GetPos() - role2.GetPos()).sqrMagnitude <= num * num)
    //				{
    //					list.Add(role2);
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x0600248F RID: 9359 RVA: 0x000F8B34 File Offset: 0x000F6D34
    //	public List<Role> GetNearestEnmitys(Role role, Vector3 pos, float range)
    //	{
    //		if (role == null)
    //		{
    //			return null;
    //		}
    //		List<Role> enmityRole = this.GetEnmityRole(role);
    //		if (enmityRole == null)
    //		{
    //			Debug.LogWarning("error");
    //			return null;
    //		}
    //		List<Role> list = new List<Role>();
    //		for (int i = 0; i < enmityRole.Count; i++)
    //		{
    //			Role role2 = enmityRole[i];
    //			if (role2 != null && !role2.IsDieing())
    //			{
    //				Vector3 a = pos;
    //				Vector3 pos2 = role2.GetPos();
    //				a.y = 0f;
    //				pos2.y = 0f;
    //				if ((a - pos2).sqrMagnitude < range * range)
    //				{
    //					list.Add(role2);
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06002490 RID: 9360 RVA: 0x000F8BE4 File Offset: 0x000F6DE4
    //	public Role GetNearestDirEnemy(Role role, TargetQuadrant inputQuadrant)
    //	{
    //		if (role == null || role.IsDead())
    //		{
    //			return null;
    //		}
    //		ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		float num = 10f;
    //		if (modAttribute != null)
    //		{
    //			num = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_VIEW_RANGE);
    //		}
    //		List<Role> enmityRole = this.GetEnmityRole(role);
    //		if (enmityRole == null)
    //		{
    //			return null;
    //		}
    //		float num2 = num;
    //		Role role2 = null;
    //		List<Role> list = new List<Role>();
    //		list.Clear();
    //		for (int i = 0; i < enmityRole.Count; i++)
    //		{
    //			Role item = enmityRole[i];
    //			Transform trans = enmityRole[i].GetTrans();
    //			Vector3 to = trans.position - Singleton<ActorManager>.GetInstance().MainCamera.transform.position;
    //			to.y = 0f;
    //			Vector3 forward = Singleton<ActorManager>.GetInstance().MainCamera.transform.forward;
    //			forward.y = 0f;
    //			float num3 = Vector3.Angle(forward, to);
    //			switch (inputQuadrant)
    //			{
    //			case TargetQuadrant.FIRST:
    //				if ((num3 >= 315f && num3 <= 0f) || (num3 >= 0f && num3 <= 45f))
    //				{
    //					list.Add(item);
    //				}
    //				break;
    //			case TargetQuadrant.SECOND:
    //				if (num3 >= 45f && num3 <= 135f)
    //				{
    //					list.Add(item);
    //				}
    //				break;
    //			case TargetQuadrant.THIRD:
    //				if (num3 >= 135f && num3 <= 225f)
    //				{
    //					list.Add(item);
    //				}
    //				break;
    //			case TargetQuadrant.FORTH:
    //				if (num3 >= 225f && num3 <= 360f)
    //				{
    //					list.Add(item);
    //				}
    //				break;
    //			case TargetQuadrant.FIRST_SECOND:
    //				if (num3 >= 0f && num3 <= 90f)
    //				{
    //					list.Add(item);
    //				}
    //				break;
    //			case TargetQuadrant.SECOND_THIRD:
    //				if (num3 >= 90f && num3 <= 180f)
    //				{
    //					list.Add(item);
    //				}
    //				break;
    //			case TargetQuadrant.THIRD_FORTH:
    //				if (num3 >= 180f && num3 <= 270f)
    //				{
    //					list.Add(item);
    //				}
    //				break;
    //			case TargetQuadrant.FORTH_FIRST:
    //				if (num3 >= 270f && num3 <= 359.9999f)
    //				{
    //					list.Add(item);
    //				}
    //				break;
    //			default:
    //				list.Add(item);
    //				break;
    //			}
    //		}
    //		for (int j = 0; j < list.Count; j++)
    //		{
    //			Role role3 = list[j];
    //			if (role3 != null)
    //			{
    //				float num4 = Vector3.Distance(new Vector3(role.GetPos().x, 0f, role.GetPos().z), new Vector3(role3.GetPos().x, 0f, role3.GetPos().z));
    //				if (num4 <= num)
    //				{
    //					if (num4 < num2)
    //					{
    //						num2 = num4;
    //						role2 = role3;
    //					}
    //				}
    //			}
    //		}
    //		if (role2 != null && role2.IsDead())
    //		{
    //			return null;
    //		}
    //		return role2;
    //	}

    //	// Token: 0x06002491 RID: 9361 RVA: 0x000F8F1C File Offset: 0x000F711C
    //	public Role GetNearestAlly(Role role)
    //	{
    //		if (role == null)
    //		{
    //			return null;
    //		}
    //		ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		float num = 0f;
    //		if (modAttribute != null)
    //		{
    //			num = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_VIEW_RANGE);
    //		}
    //		List<Role> allyRole = this.GetAllyRole(role);
    //		if (allyRole == null)
    //		{
    //			return null;
    //		}
    //		int num2 = 100000;
    //		Role result = null;
    //		for (int i = 0; i < allyRole.Count; i++)
    //		{
    //			Role role2 = allyRole[i];
    //			if (role2 != null)
    //			{
    //				if ((role.GetPos() - role2.GetPos()).sqrMagnitude <= num * num)
    //				{
    //					if (role.GetCurHp() < num2)
    //					{
    //						num2 = role.GetCurHp();
    //						result = role;
    //					}
    //				}
    //			}
    //		}
    //		return result;
    //	}

    //	// Token: 0x06002492 RID: 9362 RVA: 0x000F8FE0 File Offset: 0x000F71E0
    //	public void MakeMob(int id)
    //	{
    //		GameObjSpawn spawnInfoByID = this.GetSpawnInfoByID(id);
    //		if (spawnInfoByID != null && spawnInfoByID.gameObject.active)
    //		{
    //			spawnInfoByID.Enable();
    //		}
    //	}

    //	// Token: 0x06002493 RID: 9363 RVA: 0x000F9018 File Offset: 0x000F7218
    //	public void MakeMobByAdminID(int id)
    //	{
    //		List<GameObjSpawn> spawnListByAdminId = this.GetSpawnListByAdminId(id);
    //		for (int i = 0; i < spawnListByAdminId.Count; i++)
    //		{
    //			GameObjSpawn gameObjSpawn = spawnListByAdminId[i];
    //			if (gameObjSpawn != null && gameObjSpawn.gameObject.active)
    //			{
    //				gameObjSpawn.Enable();
    //			}
    //		}
    //	}

    //	// Token: 0x06002494 RID: 9364 RVA: 0x000F9070 File Offset: 0x000F7270
    //	private void Update()
    //	{
    //		List<Role> list = new List<Role>();
    //		for (int i = 0; i < this.RoleObjList.Count; i++)
    //		{
    //			if (this.RoleObjList[i] != null)
    //			{
    //				this.RoleObjList[i].RoleProcess();
    //			}
    //			else
    //			{
    //				list.Add(this.RoleObjList[i]);
    //			}
    //		}
    //		foreach (Role item in list)
    //		{
    //			this.RoleObjList.Remove(item);
    //		}
    //		if (Config.DEBUG && Input.GetKeyDown(KeyCode.Return))
    //		{
    //			if (GMConsole.instance == null)
    //			{
    //				GMConsole.OpenConsole();
    //			}
    //			else
    //			{
    //				GMConsole.CloseConsole();
    //			}
    //		}
    //	}

    //	// Token: 0x06002495 RID: 9365 RVA: 0x000F9168 File Offset: 0x000F7368
    //	public void AddIgnoreColliderRole(Role role)
    //	{
    //		if (this.ignoreColliderRole.Contains(role))
    //		{
    //			return;
    //		}
    //		this.IgnoreRoleCollider(role, true);
    //		this.ignoreColliderRole.Add(role);
    //	}

    //	// Token: 0x06002496 RID: 9366 RVA: 0x000F919C File Offset: 0x000F739C
    //	public void RemoveIgnoreColliderRole(Role role)
    //	{
    //		if (!this.ignoreColliderRole.Contains(role))
    //		{
    //			return;
    //		}
    //		this.IgnoreRoleCollider(role, false);
    //		this.ignoreColliderRole.Remove(role);
    //	}

    //	// Token: 0x06002497 RID: 9367 RVA: 0x000F91C8 File Offset: 0x000F73C8
    //	private void IgnoreRoleCollider(Role role, bool ignore)
    //	{
    //		for (int i = 0; i < this.RoleObjList.Count; i++)
    //		{
    //			if (this.RoleObjList[i] != null && this.RoleObjList[i] != role)
    //			{
    //				if (role.roleGameObject.RoleController.enabled)
    //				{
    //					if (!(this.RoleObjList[i].roleGameObject.RoleBody == null))
    //					{
    //						if (this.RoleObjList[i].roleGameObject.RoleController.enabled)
    //						{
    //							if (role.roleGameObject.RoleController.active && this.RoleObjList[i].roleGameObject.RoleController.active)
    //							{
    //								Physics.IgnoreCollision(role.roleGameObject.RoleController, this.RoleObjList[i].roleGameObject.RoleController, ignore);
    //							}
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}
}
