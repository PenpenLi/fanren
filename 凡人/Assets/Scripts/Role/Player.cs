﻿using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Role
{
//    private const string strBaseRoleCfg = "BasePlayerProperty";

//    private const string strBaseAdeptCfg = "AdeptConfig";

//    private const string strBaseMixtureCfg = "MixtureConfig";

//    // Token: 0x04001F8E RID: 8078
//    public Character m_cCharacter;

//    // Token: 0x04001F8F RID: 8079
//    public ModAttribute m_cModAttribute;

//    // Token: 0x04001F90 RID: 8080
//    public PlayerPropertyInfo m_cfgBaseInfo = new PlayerPropertyInfo();

//    // Token: 0x04001F91 RID: 8081
//    public ModCamera m_cModCamera;

//    // Token: 0x04001F92 RID: 8082
//    public ModFight m_cModFight;

//    // Token: 0x04001F93 RID: 8083
//    public AdeptTalent m_cAdeptSystem = new AdeptTalent();

//    // Token: 0x04001F94 RID: 8084
//    public MixtureSmelt m_cMixtureSmelt = new MixtureSmelt();

//    // Token: 0x04001F95 RID: 8085
//    public BottleSystem m_BottleSystem = new BottleSystem();

//    // Token: 0x04001F96 RID: 8086
//    private AmbitSystem m_cAmbitSystem = new AmbitSystem();

//    // Token: 0x04001F97 RID: 8087
//    private FigureSystem m_cFigureSystem = new FigureSystem();

//    // Token: 0x04001F98 RID: 8088
//    private Handbook m_cHandbook = new Handbook();

//    // Token: 0x04001F99 RID: 8089
//    public RoleGrowData m_RoleGrowDatas = new RoleGrowData();

//    // Token: 0x04001F9A RID: 8090
//    public TargetQuadrant targetQuadrant = TargetQuadrant.NONE;

//    // Token: 0x04001F9B RID: 8091
//    private ModMission m_cModMission;

//    // Token: 0x04001F9C RID: 8092
//    private Hbar hpBar;

//    // Token: 0x04001F9D RID: 8093
//    private Mbar mpBar;

//    // Token: 0x04001F9E RID: 8094
//    private GameObject _currentMob;

//    // Token: 0x04001F9F RID: 8095
//    public HelpBase _helpBase = new HelpBase();

//    // Token: 0x04001FA0 RID: 8096
//    private MobCharacter Mob;

//    // Token: 0x04001FA1 RID: 8097
//    public ModAnimation modAnimation;

      private int playerId;

      public static int currentPlayerId = 1;

    public PlayerInfo playerInfo;

    public RoleBaseInfo roleinfo;

    private static Player instance;

    //    public WeaponManager weaponManager = new WeaponManager();

    //    // Token: 0x04001FA8 RID: 8104
    //    public EquipReplace equipReplace;

    //    // Token: 0x04001FA9 RID: 8105
    //    public ItemFolderContainer ItemFolder;

    //    // Token: 0x04001FAA RID: 8106
    //    public Dictionary<int, OperableItemBase> EnableOperableList = new Dictionary<int, OperableItemBase>();

    //    // Token: 0x04001FAB RID: 8107
    //    private SoundData fightSD = new SoundData();

    //    // Token: 0x04001FAC RID: 8108
    //    private bool m_bFightingSound;

    public Player()
    {
        this._roleType = ROLE_TYPE.RT_PLAYER;
    }

    //	public ModPlayerControl ModPlayerControl { get; private set; }

    //	public AmbitSystem SystemAmbit
    //	{
    //		get
    //		{
    //			return this.m_cAmbitSystem;
    //		}
    //	}

    //	// Token: 0x17000418 RID: 1048
    //	// (get) Token: 0x060022A6 RID: 8870 RVA: 0x000EC5AC File Offset: 0x000EA7AC
    //	public FigureSystem SystemFigure
    //	{
    //		get
    //		{
    //			return this.m_cFigureSystem;
    //		}
    //	}

    //	// Token: 0x17000419 RID: 1049
    //	// (get) Token: 0x060022A7 RID: 8871 RVA: 0x000EC5B4 File Offset: 0x000EA7B4
    //	public Handbook SystemHandbook
    //	{
    //		get
    //		{
    //			return this.m_cHandbook;
    //		}
    //	}

    //	// Token: 0x1700041A RID: 1050
    //	// (get) Token: 0x060022A8 RID: 8872 RVA: 0x000EC5BC File Offset: 0x000EA7BC
    //	// (set) Token: 0x060022A9 RID: 8873 RVA: 0x000EC5C4 File Offset: 0x000EA7C4
    //	public GameObject CurrentMob
    //	{
    //		get
    //		{
    //			return this._currentMob;
    //		}
    //		set
    //		{
    //			this._currentMob = value;
    //		}
    //	}

    //	// Token: 0x1700041B RID: 1051
    //	// (get) Token: 0x060022AA RID: 8874 RVA: 0x000EC5D0 File Offset: 0x000EA7D0
    //	// (set) Token: 0x060022AB RID: 8875 RVA: 0x000EC5D8 File Offset: 0x000EA7D8
    //	public ModMission ModMis
    //	{
    //		get
    //		{
    //			return this.m_cModMission;
    //		}
    //		set
    //		{
    //			this.m_cModMission = value;
    //		}
    //	}

    //	// Token: 0x1700041C RID: 1052
    //	// (get) Token: 0x060022AC RID: 8876 RVA: 0x000EC5E4 File Offset: 0x000EA7E4
    //	// (set) Token: 0x060022AD RID: 8877 RVA: 0x000EC5EC File Offset: 0x000EA7EC
    //	public ModMutualPlayer ModMutual { get; private set; }

    public static Player Instance
    {
        get
        {
            if (Player.instance == null)
            {
                if (SceneManager.GetActiveScene().name != "Start" && SceneManager.GetActiveScene().name != "Landing" && SceneManager.GetActiveScene().name != "End")
                {
                    Debug.Log("Player Instance is null");
                }
            }
            else if (Player.instance.gameObject == null)
            {
                Player.instance = null;
            }
            return Player.instance;
        }
    }

    //	// Token: 0x060022AF RID: 8879 RVA: 0x000EC698 File Offset: 0x000EA898
    //	public override float GetTurnSpeed()
    //	{
    //		return 1000f;
    //	}

    //	// Token: 0x060022B0 RID: 8880 RVA: 0x000EC6A0 File Offset: 0x000EA8A0
    //	public override float GetMassNumber()
    //	{
    //		return 1f;
    //	}

    //	// Token: 0x060022B1 RID: 8881 RVA: 0x000EC6A8 File Offset: 0x000EA8A8
    //	public void AddEnableOperable(OperableItemBase item)
    //	{
    //		if (this.EnableOperableList.ContainsKey(item.index))
    //		{
    //			return;
    //		}
    //		this.EnableOperableList.Add(item.index, item);
    //	}

    //	// Token: 0x060022B2 RID: 8882 RVA: 0x000EC6D4 File Offset: 0x000EA8D4
    //	public void RemoveEnableOperable(OperableItemBase item)
    //	{
    //		if (this.EnableOperableList.ContainsKey(item.index))
    //		{
    //			this.EnableOperableList.Remove(item.index);
    //		}
    //	}

    //	// Token: 0x060022B3 RID: 8883 RVA: 0x000EC70C File Offset: 0x000EA90C
    //	public void Operable()
    //	{
    //		float num = float.MaxValue;
    //		List<OperableItemBase> list = new List<OperableItemBase>();
    //		List<OperableItemBase> list2 = new List<OperableItemBase>();
    //		foreach (KeyValuePair<int, OperableItemBase> keyValuePair in this.EnableOperableList)
    //		{
    //			if (!keyValuePair.Value.useAble)
    //			{
    //				list.Add(keyValuePair.Value);
    //			}
    //			else
    //			{
    //				float num2 = Vector3.Distance(base.GetPos(), keyValuePair.Value.GetPos());
    //				if (num2 <= num && num2 < 2f)
    //				{
    //					num = num2;
    //					OperableItemBase value = keyValuePair.Value;
    //					list2.Add(value);
    //				}
    //			}
    //		}
    //		foreach (OperableItemBase item in list)
    //		{
    //			this.RemoveEnableOperable(item);
    //		}
    //		foreach (OperableItemBase operableItemBase in list2)
    //		{
    //			operableItemBase.Call();
    //		}
    //	}

    //	// Token: 0x060022B4 RID: 8884 RVA: 0x000EC88C File Offset: 0x000EAA8C
    //	public override long GetWeaponIdx()
    //	{
    //		if (base.roleGameObject.ModelInfo == null)
    //		{
    //			return -1L;
    //		}
    //		if (!this.weaponManager.weaponeActive)
    //		{
    //			return -1L;
    //		}
    //		return (long)this.weaponManager.currentWeaponType;
    //	}

    //	// Token: 0x060022B5 RID: 8885 RVA: 0x000EC8CC File Offset: 0x000EAACC
    //	public override int GetHurtID()
    //	{
    //		return 999;
    //	}

    //	// Token: 0x060022B6 RID: 8886 RVA: 0x000EC8D4 File Offset: 0x000EAAD4
    //	public override string GetHeadPath()
    //	{
    //		return this.playerInfo.headPath;
    //	}

    //	// Token: 0x060022B7 RID: 8887 RVA: 0x000EC8E4 File Offset: 0x000EAAE4
    //	public override void RoleProcess()
    //	{
    //		base.RoleProcess();
    //		this.CheckDead();
    //		SceneManager.RoleMan.CheckRoleInView(this);
    //		if (Application.isEditor && UnityEngine.Input.GetKeyDown(KeyCode.Alpha9))
    //		{
    //			GameData.Instance.ItemMan.CreateItem(4010001UL, 3, ItemOwner.ITO_HEROFOLDER);
    //			GameData.Instance.ItemMan.CreateItem(1010001UL, 3, ItemOwner.ITO_HEROFOLDER);
    //			Dictionary<ulong, CItemBase> dictionary = null;
    //			this.ItemFolder.TryGetEquipData(EquipCfgType.EQCHILD_CT_WEAPON, out dictionary);
    //			List<ItemWeapon> list = new List<ItemWeapon>();
    //			foreach (CItemBase citemBase in dictionary.Values)
    //			{
    //				list.Add((ItemWeapon)citemBase);
    //			}
    //			Dictionary<ulong, ItemMagicFigure> dictionary2 = null;
    //			this.ItemFolder.TryGetAmuletData(out dictionary2);
    //			List<ItemMagicFigure> list2 = new List<ItemMagicFigure>();
    //			foreach (ItemMagicFigure item in dictionary2.Values)
    //			{
    //				list2.Add(item);
    //			}
    //			list2[0].AttachToWeapon(list[1].ID, true);
    //			this.ItemFolder.WearOperate.TakeOn(RoleWearEquipPos.WEAR_WEAPON, list[1]);
    //		}
    //		this.m_cAmbitSystem.Update();
    //		this.weaponManager.DrawLine();
    //		this.m_BottleSystem.Update();
    //	}

    //	// Token: 0x060022B8 RID: 8888 RVA: 0x000ECA8C File Offset: 0x000EAC8C
    //	private void Update()
    //	{
    //		if (Application.isEditor)
    //		{
    //			if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha8))
    //			{
    //				this.m_cAmbitSystem.AddRageSoule(5f);
    //			}
    //			if (UnityEngine.Input.GetKeyDown(KeyCode.N))
    //			{
    //				this.m_cAmbitSystem.SkillHotKey();
    //			}
    //			if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha0))
    //			{
    //				this.m_cAmbitSystem.LevelUp();
    //			}
    //		}
    //	}

    //	// Token: 0x060022B9 RID: 8889 RVA: 0x000ECAF0 File Offset: 0x000EACF0
    //	private void CheckFighting()
    //	{
    //	}

    //	// Token: 0x060022BA RID: 8890 RVA: 0x000ECAF4 File Offset: 0x000EACF4
    //	public virtual bool ChangeModelByRole(int modelID, bool destroyOld)
    //	{
    //		return base.ChangeModel(modelID, destroyOld);
    //	}

    //	// Token: 0x060022BB RID: 8891 RVA: 0x000ECB00 File Offset: 0x000EAD00
    //	public override bool ChangeModel(int modelID, bool destroyOld)
    //	{
    //		Vector3 position = base.GetTrans().position;
    //		Quaternion rotation = base.GetTrans().rotation;
    //		if (base.ChangeModel(modelID, destroyOld))
    //		{
    //			if (base.roleGameObject.RoleAnimation == null)
    //			{
    //				Animation animation = base.roleGameObject.RoleBody.AddComponent<Animation>();
    //				animation.playAutomatically = true;
    //				animation.animatePhysics = false;
    //				animation.cullingType = AnimationCullingType.BasedOnUserBounds;
    //				animation.localBounds = new Bounds(Vector3.zero, new Vector3(100f, 100f, 100f));
    //				AnimationClip clip = base.roleGameObject.RoleAnimation.GetClip("zhanli");
    //				if (clip != null)
    //				{
    //					base.roleGameObject.RoleAnimation.clip = clip;
    //					base.roleGameObject.RoleAnimation.Play("zhanli");
    //				}
    //			}
    //			base.roleGameObject.RoleBind.SetRole(this);
    //			ModAnimation modAnimation = (ModAnimation)this.AddMod(MODULE_TYPE.MT_MOTION);
    //			ModControlMFS modControlMFS = (ModControlMFS)this.AddMod(MODULE_TYPE.MT_CONTROL_MFS);
    //			ModCamera modCamera = base.GetModule(MODULE_TYPE.MT_CAMERA) as ModCamera;
    //			modCamera.SetOrignTarget(base.GetTrans());
    //			modAnimation.Init();
    //			modControlMFS.Init();
    //			base.GetTrans().position = position;
    //			base.GetTrans().rotation = rotation;
    //			this.weaponManager.initialize(this);
    //			if (base.roleGameObject.ModelID == 1)
    //			{
    //				TimeOutManager.SetTimeOut(null, 0.2f, new Callback(this.equipReplace.ReGenerateAll));
    //			}
    //			else
    //			{
    //				this.equipReplace.ReGenerateWeapon();
    //			}
    //			return true;
    //		}
    //		return false;
    //	}

    /// <summary>
    ///创建玩家
    /// </summary>
    public override void Create()
    {
        Player.instance = this;
        this.playerId++;
        int id = this.playerId;
        base.ID = id;
        Player.currentPlayerId = id;
        this.playerInfo = GameData.Instance.userData.getPlayerInfo(this.playerId);
        if (this.playerInfo == null)
        {
            Debug.LogWarning("not find playerInfo by id: " + this.playerId);
            return;
        }
        this.roleinfo = GameData.Instance.RoleBaseCfg[this.playerId];
        if (this.playerInfo == null)
        {
            Debug.LogWarning("not find RoleBaseInfo by id: " + this.playerId);
            return;
        }
        PlayerInfo.PLAYER_POSITION.y = PlayerInfo.PLAYER_POSITION.y + 1f;
        base.roleGameObject.Init(this);
        base.roleGameObject.CreatGO(1, PlayerInfo.PLAYER_POSITION, Quaternion.Euler(PlayerInfo.PLAYER_ROTATION));
        //if ((!Application.isEditor || ResourcePath.IS_PUBLISH) && Singleton<RoleAnimationManager>.GetInstance().IsSwitch)
        //{
        //    Animation roleAnimation = base.roleGameObject.RoleAnimation;
        //    if (null != roleAnimation)
        //    {
        //        UnityEngine.Object.DestroyImmediate(roleAnimation, false);
        //    }
        //    for (RoleAnimationType roleAnimationType = RoleAnimationType.Normal; roleAnimationType < RoleAnimationType.Movie; roleAnimationType++)
        //    {
        //        if (roleAnimationType != RoleAnimationType.Movie)
        //        {
        //            Singleton<RoleAnimationManager>.GetInstance().AttachAnimation(roleAnimationType, this);
        //        }
        //    }
        //}
        base.roleGameObject.RoleBind.SetRole(this);
        this.SetChildrenGameObj(base.roleGameObject.RoleBody);
        this.CreateModule();
        //this.addPlayerHotKey();
        //this.hatred.selfRole = Player.Instance;
        //KeyManager.controlRole = this;
        //this.equipReplace = new EquipReplace(this);
        //this.ItemFolder = new ItemFolderContainer(base.ID);
        //this.m_cAmbitSystem.Init(this);
        //this.InitRoleBaseInfo();
        //this.m_RoleGrowDatas.Init();
        //GameData.Instance.ItemMan.CreateItem(1020001UL, 1, ItemOwner.ITO_HEROFOLDER);
        //GameData.Instance.ItemMan.CreateItem(1030001UL, 1, ItemOwner.ITO_HEROFOLDER);
        //this.m_cFigureSystem.Init(this);
        //this.m_cModAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED_ORIGN, 6f, true);
        //this.m_cModAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED, 6f, true);
        //if (!base.roleGameObject.RoleController.isGrounded)
        //{
        //    base.roleGameObject.RoleController.Move(-Vector3.up * 20f);
        //}
    }

    public override void CreateModule()
    {
        base.CreateModule();
        this._roleType = ROLE_TYPE.RT_PLAYER;
        this.AddMod(MODULE_TYPE.MT_MOTION);
        //this.AddMod(MODULE_TYPE.MT_MOVE);
        //this.AddMod(MODULE_TYPE.MT_CAMERA);
        //this.AddMod(MODULE_TYPE.MT_FIGHT);
        //this.AddMod(MODULE_TYPE.MT_ORGANIZATION);
        //this.AddMod(MODULE_TYPE.MT_ATTRIBUTE);
        //this.AddMod(MODULE_TYPE.MT_BUFF);
        //this.AddMod(MODULE_TYPE.MT_COLLIDER);
        //this.AddMod(MODULE_TYPE.MT_MISSION);
        //this.AddMod(MODULE_TYPE.MT_CONTROL_MFS);
        //this.AddMod(MODULE_TYPE.MT_SKILL);
        //this.AddMod(MODULE_TYPE.MT_PLAYERCONTROL);
        //this.AddMod(MODULE_TYPE.MT_PLAYERMUTUAL);
        //this.AddMod(MODULE_TYPE.MT_VOICE);
        //this.ReadPlayerPropertyInfoConfig();
        //base.InitRole();
        //this.Init();
        //this.m_cAdeptSystem.LoadAdeptConfig(this.m_cModAttribute, "AdeptConfig");
        //this.m_cMixtureSmelt.LoadConfig("MixtureConfig");
        //this.m_BottleSystem.LoadConfig();
    }

    public Module AddMod(MODULE_TYPE mt)
    {
        Module module = null;
        switch (mt)
        {
        //    case MODULE_TYPE.MT_CAMERA:
        //        module = ModCamera.Create(base.roleGameObject.RoleBody, this);
        //        this.m_cModCamera = (ModCamera)module;
        //        break;
        //    case MODULE_TYPE.MT_MOTION:
        //        module = new ModAnimation(this, base.roleGameObject.RoleAnimation, base.roleGameObject.RoleController);
        //        this.modAnimation = (ModAnimation)module;
        //        break;
        //    case MODULE_TYPE.MT_ORGANIZATION:
        //        module = new ModOrganization(this);
        //        break;
        //    case MODULE_TYPE.MT_ATTRIBUTE:
        //        module = new ModAttribute(this);
        //        this.m_cModAttribute = (ModAttribute)module;
        //        break;
        //    case MODULE_TYPE.MT_FIGHT:
        //        module = new ModFight(this);
        //        this.m_cModFight = (ModFight)module;
        //        break;
        //    case MODULE_TYPE.MT_SKILL:
        //        module = new ModSkillProperty(this);
        //        break;
        //    case MODULE_TYPE.MT_BUFF:
        //        module = new ModBuffProperty(this);
        //        break;
        //    case MODULE_TYPE.MT_MISSION:
        //        module = new ModMission(this);
        //        this.m_cModMission = (module as ModMission);
        //        break;
        //    case MODULE_TYPE.MT_COLLIDER:
        //        module = new ModColliderProperty(this);
        //        break;
        //    case MODULE_TYPE.MT_CONTROL_MFS:
        //        module = new ModControlMFS(base.gameObject, this);
        //        this.modMFS = (ModControlMFS)module;
        //        break;
        //    case MODULE_TYPE.MT_QTE:
        //        module = new ModQTEProperty(this);
        //        break;
        //    case MODULE_TYPE.MT_MULTIVERSESPACE:
        //        module = new ModMultiverseSpace(this);
        //        break;
        //    case MODULE_TYPE.MT_PLAYERCONTROL:
        //        module = new ModPlayerControl(this);
        //        this.ModPlayerControl = (ModPlayerControl)module;
        //        break;
        //    case MODULE_TYPE.MT_PLAYERMUTUAL:
        //        module = new ModMutualPlayer(this);
        //        this.ModMutual = (ModMutualPlayer)module;
        //        break;
        //    case MODULE_TYPE.MT_VOICE:
        //        module = new ModVoice(this);
        //        break;
        }
        //if (base.AddModule(module))
        //{
        //    return module;
        //}
        return null;
    }

    //	// Token: 0x060022BF RID: 8895 RVA: 0x000ED19C File Offset: 0x000EB39C
    //	private void Init()
    //	{
    //		base.roleGameObject.EnableRagdoll(false);
    //		base.RunSpeed = this.playerInfo.runSpeed;
    //		this.weaponManager.initialize(this);
    //		base.SetRat(PlayerInfo.PLAYER_ROTATION);
    //		this.m_cAdeptSystem.OwnerPlayer = this;
    //		ModSkillProperty modSkillProperty = base.GetModule(MODULE_TYPE.MT_SKILL) as ModSkillProperty;
    //		modSkillProperty.AddSkill(2025);
    //		CameraEffectManager.GetAllCameraEffectComponent();
    //	}

    //	// Token: 0x060022C0 RID: 8896 RVA: 0x000ED208 File Offset: 0x000EB408
    //	public void BindAutoMisson()
    //	{
    //		ModAttribute modAttribute = base.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (modAttribute == null || modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_BORN) == 0f)
    //		{
    //			ModMission modMission = base.GetModule(MODULE_TYPE.MT_MISSION) as ModMission;
    //			if (modMission == null)
    //			{
    //				return;
    //			}
    //			for (int i = 0; i < GameData.Instance.RoleData.MissionInfoList.Count; i++)
    //			{
    //				MissionInfo missionInfo = GameData.Instance.RoleData.MissionInfoList[i];
    //				if (missionInfo != null)
    //				{
    //					if (missionInfo.MissType == 0)
    //					{
    //						modMission.AcceptMission(missionInfo.ID);
    //					}
    //				}
    //			}
    //			modAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_BORN, 1f, true);
    //		}
    //	}

    //	// Token: 0x060022C1 RID: 8897 RVA: 0x000ED2BC File Offset: 0x000EB4BC
    //	private void addPlayerHotKey()
    //	{
    //		if (Config.DEBUG)
    //		{
    //			KeyManager.addNormalKey(KeyCode.Tab, new Callback(this.KillAllEnemy));
    //		}
    //		KeyManager.addNormalKey(KeyCode.Q, new Callback(this.ChangeWeapon));
    //		if (Config.DEBUG)
    //		{
    //			KeyManager.addNormalKey(KeyCode.BackQuote, new Callback(this.EnterFly));
    //		}
    //		KeyManager.addNormalKey(KeyCode.Z, new Callback(this.Rage));
    //		KeyManager.addNormalKey(KeyCode.Space, new Callback(this.Roll));
    //		KeyManager.addNormalKey(KeyCode.Alpha1, new Callback(this.UseSkillA));
    //		KeyManager.addNormalKey(KeyCode.Alpha2, new Callback(this.UseSkillB));
    //		KeyManager.addNormalKey(KeyCode.Alpha3, new Callback(this.UseSkillC));
    //		KeyManager.addNormalKey(KeyCode.Alpha4, new Callback(this.UseSkillD));
    //		if (Application.isEditor)
    //		{
    //			KeyManager.addNormalKey(KeyCode.Alpha5, new Callback(this.UseSkillE));
    //			KeyManager.addNormalKey(KeyCode.Alpha6, new Callback(this.UseSkillF));
    //			KeyManager.addNormalKey(KeyCode.Alpha7, new Callback(this.UseSkillG));
    //		}
    //		KeyManager.addNormalKey(KeyCode.F4, new Callback(Main.Quit));
    //		KeyManager.addNormalKey(KeyCode.F, new Callback(this.Operable));
    //	}

    //	// Token: 0x060022C2 RID: 8898 RVA: 0x000ED3F4 File Offset: 0x000EB5F4
    //	private void Test()
    //	{
    //	}

    //	// Token: 0x060022C3 RID: 8899 RVA: 0x000ED3F8 File Offset: 0x000EB5F8
    //	private void UseSkillA()
    //	{
    //		this.UseSkill(0);
    //	}

    //	// Token: 0x060022C4 RID: 8900 RVA: 0x000ED404 File Offset: 0x000EB604
    //	private void UseSkillB()
    //	{
    //		this.UseSkill(1);
    //	}

    //	// Token: 0x060022C5 RID: 8901 RVA: 0x000ED410 File Offset: 0x000EB610
    //	private void UseSkillC()
    //	{
    //		this.UseSkill(2);
    //	}

    //	// Token: 0x060022C6 RID: 8902 RVA: 0x000ED41C File Offset: 0x000EB61C
    //	private void UseSkillD()
    //	{
    //		this.UseSkill(3);
    //	}

    //	// Token: 0x060022C7 RID: 8903 RVA: 0x000ED428 File Offset: 0x000EB628
    //	private void UseSkillE()
    //	{
    //		this.UseSkill(4);
    //	}

    //	// Token: 0x060022C8 RID: 8904 RVA: 0x000ED434 File Offset: 0x000EB634
    //	private void UseSkillF()
    //	{
    //		this.UseSkill(5);
    //	}

    //	// Token: 0x060022C9 RID: 8905 RVA: 0x000ED440 File Offset: 0x000EB640
    //	private void UseSkillG()
    //	{
    //		this.UseSkill(6);
    //	}

    //	// Token: 0x060022CA RID: 8906 RVA: 0x000ED44C File Offset: 0x000EB64C
    //	private void UseSkill(int index)
    //	{
    //		ModSkillProperty modSkillProperty = (ModSkillProperty)Player.Instance.GetModule(MODULE_TYPE.MT_SKILL);
    //		ModFight modFight = base.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
    //		int skillID = modSkillProperty.GetSkillID(index);
    //		if (skillID <= 0)
    //		{
    //			return;
    //		}
    //		CSkillBase skill = Singleton<CSkillStaticManager>.GetInstance().GetSkill(skillID);
    //		if (skill == null)
    //		{
    //			return;
    //		}
    //		Role targetRole = null;
    //		Vector3 zero = Vector3.zero;
    //		this.GetSkillTarget(skill, out targetRole, out zero);
    //		modSkillProperty.UseSkill(index, targetRole, zero);
    //	}

    //	// Token: 0x060022CB RID: 8907 RVA: 0x000ED4BC File Offset: 0x000EB6BC
    //	public void GetSkillTarget(CSkillBase skill, out Role target, out Vector3 targetPos)
    //	{
    //		target = SceneManager.RoleMan.GetNearestEnmity(Player.Instance);
    //		targetPos = Vector3.zero;
    //		if (skill is SkillPlayer)
    //		{
    //			this.m_cModFight.TargetRole = null;
    //			this.SetTarget(((SkillPlayer)skill).GetDistance());
    //			target = this.m_cModFight.TargetRole;
    //		}
    //		if (target != null)
    //		{
    //			targetPos = target.GetTrans().position;
    //		}
    //	}

    //	// Token: 0x060022CC RID: 8908 RVA: 0x000ED534 File Offset: 0x000EB734
    //	public void ChangeWeapon()
    //	{
    //		if (!this.m_cModFight.IsAttacking)
    //		{
    //			CONTROL_STATE currentStateId = this.modMFS.GetCurrentStateId();
    //			if (currentStateId != CONTROL_STATE.IDLE && currentStateId != CONTROL_STATE.ATTACK && currentStateId != CONTROL_STATE.WALK_FORWARD && currentStateId != CONTROL_STATE.ATTACK_IDLE && currentStateId != CONTROL_STATE.ROLL)
    //			{
    //				return;
    //			}
    //			this.weaponManager.autoChangeWeapon();
    //			if (currentStateId == CONTROL_STATE.ATTACK)
    //			{
    //				this.modMFS.ChangeStateToIdle();
    //			}
    //			if (currentStateId == CONTROL_STATE.ATTACK_IDLE)
    //			{
    //				this.modMFS.ChangeState(new ControlEventAttackIdle(false));
    //			}
    //		}
    //	}

    //	// Token: 0x060022CD RID: 8909 RVA: 0x000ED5B8 File Offset: 0x000EB7B8
    //	public void Rage()
    //	{
    //		CONTROL_STATE currentStateId = this.modMFS.GetCurrentStateId();
    //		if (currentStateId != CONTROL_STATE.QTE)
    //		{
    //			if (!this.SystemAmbit.IsInRage && this.SystemAmbit.RageNum > 0f)
    //			{
    //				this.SystemAmbit.UseRageSkill();
    //			}
    //			else if (this.SystemAmbit.IsInRage)
    //			{
    //				this.SystemAmbit.StopRageSkill();
    //			}
    //		}
    //	}

    //	// Token: 0x060022CE RID: 8910 RVA: 0x000ED62C File Offset: 0x000EB82C
    //	private void LockCamera()
    //	{
    //		this.m_cModCamera.SetCameraState(ModCamera.CameraState.FollowPositionAutoRotation);
    //	}

    //	// Token: 0x060022CF RID: 8911 RVA: 0x000ED63C File Offset: 0x000EB83C
    //	private void OrbitCamera()
    //	{
    //		this.m_cModCamera.SetCameraState(ModCamera.CameraState.MouseOrbit);
    //	}

    //	// Token: 0x060022D0 RID: 8912 RVA: 0x000ED64C File Offset: 0x000EB84C
    //	public void UpdateHP(float hp)
    //	{
    //		if (this.m_cModAttribute != null)
    //		{
    //			this.m_cModAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, hp, true);
    //		}
    //	}

    //	// Token: 0x060022D1 RID: 8913 RVA: 0x000ED668 File Offset: 0x000EB868
    //	public void UpdateMP(float mp)
    //	{
    //		if (this.m_cModAttribute != null)
    //		{
    //			this.m_cModAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_MP, mp, true);
    //		}
    //	}

    //	// Token: 0x060022D2 RID: 8914 RVA: 0x000ED684 File Offset: 0x000EB884
    //	private void EnterFly()
    //	{
    //		if (this.modMFS.GetCurrentStateId() != CONTROL_STATE.FLY)
    //		{
    //			this.modMFS.ChangeState(new ControlEventFly(true, false, Vector3.zero, ACTION_INDEX.AN_FLY, 10f, true));
    //		}
    //		else
    //		{
    //			this.modMFS.ChangeStateToIdle();
    //		}
    //	}

    //	// Token: 0x060022D3 RID: 8915 RVA: 0x000ED6D8 File Offset: 0x000EB8D8
    //	private void LeftInput()
    //	{
    //		this.Fight();
    //	}

    //	// Token: 0x060022D4 RID: 8916 RVA: 0x000ED6E0 File Offset: 0x000EB8E0
    //	private void RightInput()
    //	{
    //	}

    //	// Token: 0x060022D5 RID: 8917 RVA: 0x000ED6E4 File Offset: 0x000EB8E4
    //	private void KillAllEnemy()
    //	{
    //		for (int i = 0; i < this.hatred.HatredList.Count; i++)
    //		{
    //			if (!(this.hatred.HatredList[i] == null | this.hatred.HatredList[i].RoleObj.IsDead()))
    //			{
    //				Role roleObj = this.hatred.HatredList[i].RoleObj;
    //				if (roleObj != null)
    //				{
    //					if (roleObj._roleType == ROLE_TYPE.RT_MONSTER)
    //					{
    //						ModAttribute modAttribute = roleObj.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //						if (modAttribute != null)
    //						{
    //							modAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_HP, 0f, true);
    //							roleObj.Die(false);
    //						}
    //					}
    //				}
    //			}
    //		}
    //		Main.Instance.DelayGC(15f);
    //	}

    //	// Token: 0x060022D6 RID: 8918 RVA: 0x000ED7BC File Offset: 0x000EB9BC
    //	public void Fight()
    //	{
    //		if (this.m_cModFight == null)
    //		{
    //			return;
    //		}
    //		this.SetTargetRoleByInput();
    //		this.m_cModFight.Attack(0, 1);
    //	}

    //	// Token: 0x060022D7 RID: 8919 RVA: 0x000ED7EC File Offset: 0x000EB9EC
    //	public void ChargeAttack()
    //	{
    //		if (this.modMFS.GetCurrentStateId() == CONTROL_STATE.ATTACK)
    //		{
    //			return;
    //		}
    //		Role nearestEnmity = SceneManager.RoleMan.GetNearestEnmity(this);
    //		ControlEventAttack tmpEvent = new ControlEventAttack(false, this.m_cModFight.AttackDir, nearestEnmity);
    //		this.modMFS.ChangeState(tmpEvent);
    //	}

    //	// Token: 0x060022D8 RID: 8920 RVA: 0x000ED838 File Offset: 0x000EBA38
    //	private void CheckDead()
    //	{
    //		if (base.IsDead())
    //		{
    //			this.Die(false);
    //		}
    //	}

    //	// Token: 0x060022D9 RID: 8921 RVA: 0x000ED84C File Offset: 0x000EBA4C
    //	public override void Die(bool qte)
    //	{
    //		if (this.modMFS.GetCurrentStateId() == CONTROL_STATE.DIE)
    //		{
    //			return;
    //		}
    //		base.Die(qte);
    //		this.modMFS.ChangeState(new ControlEventDie(false));
    //		CameraEffectManager.MainGrayscaleEffect.enabled = true;
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<DieGUI>().Show();
    //		GameTime.PauseGame();
    //	}

    //	// Token: 0x060022DA RID: 8922 RVA: 0x000ED8A4 File Offset: 0x000EBAA4
    //	public void Revive()
    //	{
    //		CameraEffectManager.MainGrayscaleEffect.enabled = false;
    //		ModAttribute modAttribute = base.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (modAttribute != null)
    //		{
    //			modAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_HP, modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP), true);
    //		}
    //		base.roleGameObject.RoleController.enabled = true;
    //		this.modMFS.ChangeState(new ControlEventIdle(true));
    //	}

    //	// Token: 0x060022DB RID: 8923 RVA: 0x000ED904 File Offset: 0x000EBB04
    //	public void OnMouseClick(int mouseFlag)
    //	{
    //	}

    //	// Token: 0x060022DC RID: 8924 RVA: 0x000ED908 File Offset: 0x000EBB08
    //	public void OnAttacked(int hp)
    //	{
    //	}

    //	// Token: 0x060022DD RID: 8925 RVA: 0x000ED90C File Offset: 0x000EBB0C
    //	public override bool ChangeMeshColor(Color col)
    //	{
    //		if (!base.BRagdoll)
    //		{
    //			GameObject[] array = new GameObject[]
    //			{
    //				base.RoleChildObj.GetGoByType(RoleChildType.RCT_PLAYER_MESH_BODY),
    //				base.RoleChildObj.GetGoByType(RoleChildType.RCT_PLAYER_MESH_HAND),
    //				base.RoleChildObj.GetGoByType(RoleChildType.RCT_PLAYER_MESH_FOOT),
    //				base.RoleChildObj.GetGoByType(RoleChildType.RCT_PLAYER_MESH_OBJECT001),
    //				base.RoleChildObj.GetGoByType(RoleChildType.RCT_PLAYER_MESH_TOU),
    //				base.RoleChildObj.GetGoByType(RoleChildType.RCT_PLAYER_MESH_TOUFA),
    //				base.RoleChildObj.GetGoByType(RoleChildType.RCT_PLAYER_MESH_RIGHT_WEAPON)
    //			};
    //			for (int i = 0; i < 7; i++)
    //			{
    //				if (array[i] != null)
    //				{
    //					array[i].renderer.material.SetColor("_Color", col);
    //				}
    //			}
    //			return true;
    //		}
    //		return false;
    //	}

    //	// Token: 0x060022DE RID: 8926 RVA: 0x000ED9D8 File Offset: 0x000EBBD8
    //	public void Roll()
    //	{
    //		CONTROL_STATE currentStateId = this.modMFS.GetCurrentStateId();
    //		if (currentStateId != CONTROL_STATE.FLY)
    //		{
    //			if (Player.Instance != null)
    //			{
    //				this.modMFS.ChangeState(new ControlEventRoll(false, ACTION_INDEX.AN_SHANBI_NAME, this.m_cModFight.AttackDir));
    //			}
    //		}
    //	}

    //	// Token: 0x060022DF RID: 8927 RVA: 0x000EDA2C File Offset: 0x000EBC2C
    //	public override void Input(float VerInput, float HorInput)
    //	{
    //		if (base.IsDead())
    //		{
    //			return;
    //		}
    //		this.SetTargetByKey(VerInput, HorInput, this.GetSelectDistance());
    //		Vector3 a = this.m_cModCamera.cameraTransform.forward;
    //		if (this.m_cModCamera.cameraState == ModCamera.CameraState.FollowPositionAutoRotation)
    //		{
    //			if (Mathf.Abs(this.m_cModCamera.cameraTransform.rotation.eulerAngles.x - 90f) <= 5f)
    //			{
    //				a = this.m_cModCamera.cameraTransform.up;
    //			}
    //			a.y = 0f;
    //		}
    //		Vector3 vector = VerInput * a + HorInput * this.m_cModCamera.cameraTransform.right;
    //		Vector3 vector2 = base.GetPos() + vector;
    //		Debug.DrawLine(base.GetPos() + Vector3.up, vector2, Color.white);
    //		CONTROL_STATE currentStateId = this.modMFS.GetCurrentStateId();
    //		if (currentStateId != CONTROL_STATE.ATTACK_IDLE)
    //		{
    //			if (currentStateId != CONTROL_STATE.WALK_FORWARD)
    //			{
    //				if (currentStateId != CONTROL_STATE.SWIM)
    //				{
    //					if (currentStateId != CONTROL_STATE.FLY)
    //					{
    //						if (!(vector == Vector3.zero))
    //						{
    //							this.modMFS.ChangeState(new ControlEventMoveForward(false, vector2, ACTION_INDEX.AN_RUN, base.RunSpeed, true));
    //						}
    //					}
    //					else if (UnityEngine.Input.GetKey(KeyCode.Space))
    //					{
    //						this.modMFS.ChangeState(new ControlEventFly(true, true, vector2, ACTION_INDEX.AN_FLY, 10f, true));
    //					}
    //					else
    //					{
    //						this.modMFS.ChangeState(new ControlEventFly(true, false, vector2, ACTION_INDEX.AN_RUN, 30f, true));
    //					}
    //				}
    //				else
    //				{
    //					this.modMFS.ChangeState(new ControlEventSwim(true, base.GetTrans().position.y, vector2, ACTION_INDEX.AN_RUN, 3f, true));
    //				}
    //			}
    //			else if (vector == Vector3.zero)
    //			{
    //				if (this.weaponManager.weaponeActive)
    //				{
    //					this.modMFS.ChangeState(new ControlEventAttackIdle(false));
    //				}
    //				else
    //				{
    //					this.modMFS.ChangeState(new ControlEventIdle(false));
    //				}
    //			}
    //			else
    //			{
    //				this.modMFS.ChangeState(new ControlEventMoveForward(false, vector2, ACTION_INDEX.AN_RUN, base.RunSpeed, true));
    //			}
    //		}
    //		else
    //		{
    //			if (!this.weaponManager.weaponeActive)
    //			{
    //				this.modMFS.ChangeState(new ControlEventIdle(false));
    //			}
    //			if (vector != Vector3.zero)
    //			{
    //				this.modMFS.ChangeState(new ControlEventMoveForward(false, vector2, ACTION_INDEX.AN_RUN, base.RunSpeed, true));
    //			}
    //		}
    //	}

    //	// Token: 0x060022E0 RID: 8928 RVA: 0x000EDCC4 File Offset: 0x000EBEC4
    //	public void SetTarget(float distance)
    //	{
    //		Role role;
    //		if (this.m_cModFight.AttackDir != Vector3.zero)
    //		{
    //			role = this.GetEnemyByAngleAndArea(distance, Singleton<PlayerFightData>.GetInstance().MoveSelectAngle * 0.5f, this.m_cModFight.AttackDir);
    //			this.m_cModFight.TargetRole = role;
    //			return;
    //		}
    //		if (this.m_cModFight.TargetRole != null && !this.m_cModFight.TargetRole.IsDieing())
    //		{
    //			return;
    //		}
    //		this.m_cModFight.TargetRole = null;
    //		List<Role> nearestEnmitys = SceneManager.RoleMan.GetNearestEnmitys(this, base.GetTrans().position, distance);
    //		if (nearestEnmitys.Count == 0)
    //		{
    //			return;
    //		}
    //		role = this.GetEnemyByAngleAndArea(nearestEnmitys, distance, Singleton<PlayerFightData>.GetInstance().StaySelectAngle_1 * 0.5f, base.GetTrans().forward);
    //		if (role == null)
    //		{
    //			role = this.GetEnemyByAngleAndArea(nearestEnmitys, distance, Singleton<PlayerFightData>.GetInstance().StaySelectAngle_2 * 0.5f, base.GetTrans().forward);
    //			if (role == null)
    //			{
    //				role = nearestEnmitys[0];
    //				for (int i = 1; i < nearestEnmitys.Count; i++)
    //				{
    //					float sqrMagnitude = (role.GetPos() - base.GetPos()).sqrMagnitude;
    //					float sqrMagnitude2 = (nearestEnmitys[i].GetPos() - base.GetPos()).sqrMagnitude;
    //					if (sqrMagnitude2 < sqrMagnitude)
    //					{
    //						role = nearestEnmitys[i];
    //					}
    //				}
    //			}
    //		}
    //		this.m_cModFight.TargetRole = role;
    //	}

    //	// Token: 0x060022E1 RID: 8929 RVA: 0x000EDE40 File Offset: 0x000EC040
    //	public void SetTargetRoleByInput()
    //	{
    //		this.SetTarget(this.GetSelectDistance());
    //	}

    //	// Token: 0x060022E2 RID: 8930 RVA: 0x000EDE50 File Offset: 0x000EC050
    //	private Role GetEnemyByAngleAndArea(float r, float angle, Vector3 direction)
    //	{
    //		List<Role> nearestEnmitys = SceneManager.RoleMan.GetNearestEnmitys(this, base.GetTrans().position, r);
    //		return this.GetEnemyByAngleAndArea(nearestEnmitys, r, angle, direction);
    //	}

    //	// Token: 0x060022E3 RID: 8931 RVA: 0x000EDE80 File Offset: 0x000EC080
    //	private Role GetEnemyByAngleAndArea(List<Role> roleLst, float r, float angle, Vector3 direction)
    //	{
    //		if (roleLst.Count == 0)
    //		{
    //			return null;
    //		}
    //		direction.y = 0f;
    //		List<Role> list = new List<Role>();
    //		foreach (Role role in roleLst)
    //		{
    //			Vector3 from = role.GetPos() - base.GetPos();
    //			from.y = 0f;
    //			float num = Vector3.Angle(from, direction);
    //			if (num <= angle)
    //			{
    //				list.Add(role);
    //			}
    //		}
    //		if (list.Count == 0)
    //		{
    //			return null;
    //		}
    //		Role role2 = list[0];
    //		for (int i = 1; i < list.Count; i++)
    //		{
    //			Vector3 from2 = role2.GetPos() - base.GetPos();
    //			from2.y = 0f;
    //			float num2 = Vector3.Angle(from2, direction);
    //			Vector3 from3 = list[i].GetPos() - base.GetPos();
    //			from3.y = 0f;
    //			float num3 = Vector3.Angle(from3, direction);
    //			if (num3 < num2)
    //			{
    //				role2 = list[i];
    //			}
    //		}
    //		return role2;
    //	}

    //	// Token: 0x060022E4 RID: 8932 RVA: 0x000EDFD8 File Offset: 0x000EC1D8
    //	private float GetSelectDistance()
    //	{
    //		float result = 4f;
    //		if (this.weaponManager.currentWeaponType == EquipCfgType.EQCHILD_CT_MAGICWEAPON)
    //		{
    //			result = Singleton<PlayerFightData>.GetInstance().MagicSelectDistance;
    //		}
    //		else if (this.weaponManager.currentWeaponType == EquipCfgType.EQCHILD_CT_WEAPON)
    //		{
    //			result = Singleton<PlayerFightData>.GetInstance().SwordSelectDistance;
    //		}
    //		else if (this.weaponManager.currentWeaponType == EquipCfgType.EQCHILD_CT_DWEAPON)
    //		{
    //			result = Singleton<PlayerFightData>.GetInstance().DaggerSelectDistance;
    //		}
    //		return result;
    //	}

    //	// Token: 0x060022E5 RID: 8933 RVA: 0x000EE04C File Offset: 0x000EC24C
    //	public void SetTargetByKey(float VerInput, float HorInput, float distance)
    //	{
    //		this.m_cModFight.VerInput = VerInput;
    //		this.m_cModFight.HorInput = HorInput;
    //		if (this.m_cModFight.VerInput == 0f && this.m_cModFight.HorInput == 0f)
    //		{
    //			this.m_cModFight.AttackDir = Vector3.zero;
    //		}
    //		else
    //		{
    //			Vector3 a = Singleton<ActorManager>.GetInstance().MainCamera.transform.forward;
    //			a.y = 0f;
    //			a = a.normalized;
    //			Vector3 a2 = Singleton<ActorManager>.GetInstance().MainCamera.transform.right;
    //			a2.y = 0f;
    //			a2 = a2.normalized;
    //			Vector3 attackDir = a * this.m_cModFight.VerInput + a2 * this.m_cModFight.HorInput;
    //			this.m_cModFight.AttackDir = attackDir;
    //		}
    //		if (this.m_cModFight.AttackDir != Vector3.zero)
    //		{
    //			this.m_cModFight.TargetRole = null;
    //		}
    //	}

    //	// Token: 0x060022E6 RID: 8934 RVA: 0x000EE15C File Offset: 0x000EC35C
    //	public void ReadPlayerPropertyInfoConfig()
    //	{
    //		List<string> list = RoleBaseFun.LoadConfInAssets("BasePlayerProperty");
    //		if (list == null)
    //		{
    //			return;
    //		}
    //		List<ATTRIBUTE_TYPE> list2 = new List<ATTRIBUTE_TYPE>();
    //		foreach (string text in list)
    //		{
    //			string[] array = text.Split(CacheData.separator);
    //			if (array != null)
    //			{
    //				if (array.Length >= 2)
    //				{
    //					ATTRIBUTE_TYPE attribute_TYPE = (ATTRIBUTE_TYPE)Convert.ToInt32(array[0]);
    //					if (this.m_cfgBaseInfo.IsHaveKey(attribute_TYPE))
    //					{
    //						this.m_cfgBaseInfo.dyPropertyKey[attribute_TYPE] = (float)Convert.ToDouble(array[1]);
    //						list2.Add(attribute_TYPE);
    //					}
    //				}
    //			}
    //		}
    //		this.m_cModAttribute.m_cfgBaseInfo = this.m_cfgBaseInfo;
    //		for (int i = 0; i < list2.Count; i++)
    //		{
    //			this.m_cModAttribute.SetAttributeNum(list2[i], this.m_cfgBaseInfo.dyPropertyKey[list2[i]], true);
    //		}
    //		this.m_cModAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_CHAPTER, 1f, true);
    //		this.m_cModAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_BORN, 0f, true);
    //	}

    //	// Token: 0x060022E7 RID: 8935 RVA: 0x000EE2BC File Offset: 0x000EC4BC
    //	public void InitRoleBaseInfo()
    //	{
    //		if (this.roleinfo == null)
    //		{
    //			return;
    //		}
    //		GameData.Instance.ItemMan.CreateItem(1910001UL, 1, ItemOwner.ITO_HEROFOLDER);
    //		foreach (KeyValuePair<RoleWearEquipPos, ulong> keyValuePair in this.roleinfo.DefultEquip)
    //		{
    //			if (GameData.Instance.ItemMan.CreateItem(keyValuePair.Value, 1, ItemOwner.ITO_HEROFOLDER))
    //			{
    //				Dictionary<ulong, CItemBase> dictionary = new Dictionary<ulong, CItemBase>();
    //				if (GameData.Instance.ItemMan.TryGetItemsByID(keyValuePair.Value, out dictionary))
    //				{
    //					foreach (CItemBase item in dictionary.Values)
    //					{
    //						this.ItemFolder.WearOperate.TakeOn(item);
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x060022E8 RID: 8936 RVA: 0x000EE3E8 File Offset: 0x000EC5E8
    //	public static void LoadPlayerRes(Player player)
    //	{
    //		RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(player.SystemAmbit.ModelChangeID);
    //		if (roleModelInfo != null)
    //		{
    //			Debug.Log(roleModelInfo.Path);
    //			ResourceLoader.Load(roleModelInfo.Path, typeof(GameObject));
    //			KeyValuePair<string, Type>[] effectResPath = UtilityRoleResource.GetEffectResPath(663);
    //			if (effectResPath != null)
    //			{
    //				foreach (KeyValuePair<string, Type> keyValuePair in effectResPath)
    //				{
    //					Debug.Log(keyValuePair.Key);
    //					ResourceLoader.Load(keyValuePair.Key, keyValuePair.Value);
    //				}
    //			}
    //			effectResPath = UtilityRoleResource.GetEffectResPath(780);
    //			if (effectResPath != null)
    //			{
    //				foreach (KeyValuePair<string, Type> keyValuePair2 in effectResPath)
    //				{
    //					Debug.Log(keyValuePair2.Key);
    //					ResourceLoader.Load(keyValuePair2.Key, keyValuePair2.Value);
    //				}
    //			}
    //		}
    //		foreach (AdeptTalent.AdeptData adeptData in player.m_cAdeptSystem.AdeptTalentConfig.Values)
    //		{
    //			if (!adeptData.IsLock)
    //			{
    //				if (adeptData.IsUnLockAnimation == 1)
    //				{
    //					Player.LoadAttackRes(adeptData.WeaponType, adeptData.AmbitID);
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x060022E9 RID: 8937 RVA: 0x000EE580 File Offset: 0x000EC780
    //	public static void LoadAttackRes(EquipCfgType equipType, int level)
    //	{
    //		KeyValuePair<string, Type>[] attackTableResource = UtilityRoleResource.GetAttackTableResource((int)equipType, level);
    //		if (attackTableResource != null)
    //		{
    //			foreach (KeyValuePair<string, Type> keyValuePair in attackTableResource)
    //			{
    //				ResourceLoader.Load(keyValuePair.Key, keyValuePair.Value);
    //			}
    //		}
    //	}
}
