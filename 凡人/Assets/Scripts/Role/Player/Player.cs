using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Role
{
    private const string strBaseRoleCfg = "BasePlayerProperty";

    private const string strBaseAdeptCfg = "AdeptConfig";

    private const string strBaseMixtureCfg = "MixtureConfig";

    public Character m_cCharacter;

    public ModAttribute m_cModAttribute;

    public PlayerPropertyInfo m_cfgBaseInfo = new PlayerPropertyInfo();

    public ModCamera m_cModCamera;

    public AdeptTalent m_cAdeptSystem = new AdeptTalent();

    public MixtureSmelt m_cMixtureSmelt = new MixtureSmelt();

    public BottleSystem m_BottleSystem = new BottleSystem();

    private AmbitSystem m_cAmbitSystem = new AmbitSystem();

    private FigureSystem m_cFigureSystem = new FigureSystem();

    //private Handbook m_cHandbook = new Handbook();

    public RoleGrowData m_RoleGrowDatas = new RoleGrowData();

    //public TargetQuadrant targetQuadrant = TargetQuadrant.NONE;

    /// <summary>
    /// 任务模块
    /// </summary>
    private ModMission m_cModMission;

    //private Hbar hpBar;

    //private Mbar mpBar;

    private GameObject _currentMob;

    //public HelpBase _helpBase = new HelpBase();

    //private MobCharacter Mob;

    /// <summary>
    /// 动画模块
    /// </summary>
    public ModAnimation modAnimation;

    private int playerId;

    /// <summary>
    /// 当前玩家ID
    /// </summary>
    public static int currentPlayerId = 1;

    /// <summary>
    /// 玩家信息
    /// </summary>
    public PlayerInfo playerInfo;

    public RoleBaseInfo roleinfo;

    private static Player instance;

    public WeaponManager weaponManager = new WeaponManager();

    /// <summary>
    /// 装备替换
    /// </summary>
    public EquipReplace equipReplace;

    /// <summary>
    /// 物品背包
    /// </summary>
    public ItemFolderContainer ItemFolder;

    //public Dictionary<int, OperableItemBase> EnableOperableList = new Dictionary<int, OperableItemBase>();

    private SoundData fightSD = new SoundData();

    private bool m_bFightingSound;

    public Player()
    {
        this._roleType = ROLE_TYPE.RT_PLAYER;
    }

    public ModPlayerControl ModPlayerControl { get; private set; }

    //	public AmbitSystem SystemAmbit
    //	{
    //		get
    //		{
    //			return this.m_cAmbitSystem;
    //		}
    //	}

    //	public FigureSystem SystemFigure
    //	{
    //		get
    //		{
    //			return this.m_cFigureSystem;
    //		}
    //	}

    //	public Handbook SystemHandbook
    //	{
    //		get
    //		{
    //			return this.m_cHandbook;
    //		}
    //	}

    public GameObject CurrentMob
    {
        get
        {
            return this._currentMob;
        }
        set
        {
            this._currentMob = value;
        }
    }

    public ModMission ModMis
    {
        get
        {
            return this.m_cModMission;
        }
        set
        {
            this.m_cModMission = value;
        }
    }

    public ModMutualPlayer ModMutual { get; private set; }

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

    public override float GetTurnSpeed()
    {
        return 1000f;
    }

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

    /// <summary>
    /// 可操作
    /// </summary>
    public void Operable()
    {
        Debug.Log("按下F");
        //float num = float.MaxValue;
        //List<OperableItemBase> list = new List<OperableItemBase>();
        //List<OperableItemBase> list2 = new List<OperableItemBase>();
        //foreach (KeyValuePair<int, OperableItemBase> keyValuePair in this.EnableOperableList)
        //{
        //    if (!keyValuePair.Value.useAble)
        //    {
        //        list.Add(keyValuePair.Value);
        //    }
        //    else
        //    {
        //        float num2 = Vector3.Distance(base.GetPos(), keyValuePair.Value.GetPos());
        //        if (num2 <= num && num2 < 2f)
        //        {
        //            num = num2;
        //            OperableItemBase value = keyValuePair.Value;
        //            list2.Add(value);
        //        }
        //    }
        //}
        //foreach (OperableItemBase item in list)
        //{
        //    //this.RemoveEnableOperable(item);
        //}
        //foreach (OperableItemBase operableItemBase in list2)
        //{
        //    operableItemBase.Call();
        //}
    }

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

    /// <summary>
    /// 每帧执行
    /// </summary>
    public override void RoleProcess()
    {
        base.RoleProcess();
        this.CheckDead();
        FanrenSceneManager.RoleMan.CheckRoleInView(this);
        //if (Application.isEditor && UnityEngine.Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    GameData.Instance.ItemMan.CreateItem(4010001UL, 3, ItemOwner.ITO_HEROFOLDER);
        //    GameData.Instance.ItemMan.CreateItem(1010001UL, 3, ItemOwner.ITO_HEROFOLDER);
        //    Dictionary<ulong, CItemBase> dictionary = null;
        //    this.ItemFolder.TryGetEquipData(EquipCfgType.EQCHILD_CT_WEAPON, out dictionary);
        //    List<ItemWeapon> list = new List<ItemWeapon>();
        //    foreach (CItemBase citemBase in dictionary.Values)
        //    {
        //        list.Add((ItemWeapon)citemBase);
        //    }
        //    Dictionary<ulong, ItemMagicFigure> dictionary2 = null;
        //    this.ItemFolder.TryGetAmuletData(out dictionary2);
        //    List<ItemMagicFigure> list2 = new List<ItemMagicFigure>();
        //    foreach (ItemMagicFigure item in dictionary2.Values)
        //    {
        //        list2.Add(item);
        //    }
        //    list2[0].AttachToWeapon(list[1].ID, true);
        //    this.ItemFolder.WearOperate.TakeOn(RoleWearEquipPos.WEAR_WEAPON, list[1]);
        //}
        //this.m_cAmbitSystem.Update();
        //this.weaponManager.DrawLine();
        //this.m_BottleSystem.Update();
    }

    private void CheckFighting()
    {
    }

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
        int id = this.playerId;//玩家ID 1
        base.ID = id;
        Player.currentPlayerId = id;
        this.playerInfo = GameData.Instance.userData.getPlayerInfo(this.playerId);//主角信息 模型位置 头像
        if (this.playerInfo == null)
        {
            Debug.LogWarning("not find playerInfo by id: " + this.playerId);
            return;
        }
        this.roleinfo = GameData.Instance.RoleBaseCfg[this.playerId];//角色基本信息 应该是装备或模型
        if (this.playerInfo == null)
        {
            Debug.LogWarning("not find RoleBaseInfo by id: " + this.playerId);
            return;
        }
        PlayerInfo.PLAYER_POSITION.y = PlayerInfo.PLAYER_POSITION.y + 1f;//玩家位置 为了防止角色坠落
        base.roleGameObject.Init(this);
        base.roleGameObject.CreatGO(1, PlayerInfo.PLAYER_POSITION, Quaternion.Euler(PlayerInfo.PLAYER_ROTATION));//创建角色物体

        base.roleGameObject.RoleBind.SetRole(this);
        this.CreateModule();//创建模块
        this.addPlayerHotKey();//添加热键
        this.hatred.selfRole = Player.Instance;
        KeyManager.controlRole = this;
        this.equipReplace = new EquipReplace(this);//装备
        this.ItemFolder = new ItemFolderContainer(base.ID);//物品
        this.m_cAmbitSystem.Init(this);
        this.InitRoleBaseInfo();
        this.m_RoleGrowDatas.Init();
        GameData.Instance.ItemMan.CreateItem(1020001UL, 1, ItemOwner.ITO_HEROFOLDER);
        GameData.Instance.ItemMan.CreateItem(1030001UL, 1, ItemOwner.ITO_HEROFOLDER);
        this.m_cFigureSystem.Init(this);
        this.m_cModAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED_ORIGN, 6f, true);
        this.m_cModAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED, 6f, true);
        this.modMFS.ChangeState(new ControlEventIdle(false));
        if (!base.roleGameObject.RoleController.isGrounded)//让角色着地
        {
            base.roleGameObject.RoleController.Move(-Vector3.up * 20f);
        }
    }

    /// <summary>
    /// 创建模块
    /// </summary>
    public override void CreateModule()
    {
        base.CreateModule();
        this._roleType = ROLE_TYPE.RT_PLAYER;//设置角色类型
        this.AddMod(MODULE_TYPE.MT_MOTION);
        this.AddMod(MODULE_TYPE.MT_CAMERA);
        this.AddMod(MODULE_TYPE.MT_ORGANIZATION);
        this.AddMod(MODULE_TYPE.MT_ATTRIBUTE);
        this.AddMod(MODULE_TYPE.MT_COLLIDER);
        this.AddMod(MODULE_TYPE.MT_MISSION);
        this.AddMod(MODULE_TYPE.MT_CONTROL_MFS);
        this.AddMod(MODULE_TYPE.MT_PLAYERCONTROL);
        this.AddMod(MODULE_TYPE.MT_PLAYERMUTUAL);
        this.AddMod(MODULE_TYPE.MT_VOICE);
        this.ReadPlayerPropertyInfoConfig();
        base.InitRole();
        this.Init();
        this.m_cAdeptSystem.LoadAdeptConfig(this.m_cModAttribute, "AdeptConfig");//精通系统
        this.m_cMixtureSmelt.LoadConfig("MixtureConfig");//合成
        this.m_BottleSystem.LoadConfig();//瓶子
    }

    public Module AddMod(MODULE_TYPE mt)
    {
        Module module = null;
        switch (mt)
        {
            case MODULE_TYPE.MT_CAMERA:
                module = ModCamera.Create(base.roleGameObject.RoleBody, this);
                this.m_cModCamera = (ModCamera)module;
                break;
            case MODULE_TYPE.MT_MOTION:
                module = new ModAnimation(this, base.roleGameObject.RoleAnimator, base.roleGameObject.RoleController);
                this.modAnimation = (ModAnimation)module;
                break;
            case MODULE_TYPE.MT_ORGANIZATION:
                module = new ModOrganization(this);
                break;
            case MODULE_TYPE.MT_ATTRIBUTE:
                module = new ModAttribute(this);
                this.m_cModAttribute = (ModAttribute)module;
                break;
            case MODULE_TYPE.MT_MISSION:
                module = new ModMission(this);
                this.m_cModMission = (module as ModMission);
                break;
            case MODULE_TYPE.MT_COLLIDER:
                module = new ModColliderProperty(this);
                break;
            case MODULE_TYPE.MT_CONTROL_MFS:
                module = new ModControlMFS(base.gameObject, this);
                this.modMFS = (ModControlMFS)module;
                break;
            case MODULE_TYPE.MT_QTE:
                //module = new ModQTEProperty(this);
                break;
            case MODULE_TYPE.MT_MULTIVERSESPACE:
                //module = new ModMultiverseSpace(this);
                break;
            case MODULE_TYPE.MT_PLAYERCONTROL:
                module = new ModPlayerControl(this);
                this.ModPlayerControl = (ModPlayerControl)module;
                break;
            case MODULE_TYPE.MT_PLAYERMUTUAL:
                module = new ModMutualPlayer(this);
                this.ModMutual = (ModMutualPlayer)module;
                break;
            case MODULE_TYPE.MT_VOICE:
                module = new ModVoice(this);
                break;
        }

        if (base.AddModule(module))
        {
            return module;
        }
        return null;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        base.roleGameObject.EnableRagdoll(false);
        base.RunSpeed = this.playerInfo.runSpeed;
        this.weaponManager.initialize(this);
        base.SetRat(PlayerInfo.PLAYER_ROTATION);
        this.m_cAdeptSystem.OwnerPlayer = this;
        CameraEffectManager.GetAllCameraEffectComponent();
    }

    /// <summary>
    /// 自动构建任务
    /// </summary>
    public void BindAutoMisson()
    {
        ModAttribute modAttribute = base.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
        if (modAttribute == null || modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_BORN) == 0f)
        {
            ModMission modMission = base.GetModule(MODULE_TYPE.MT_MISSION) as ModMission;
            if (modMission == null)
            {
                return;
            }
            for (int i = 0; i < GameData.Instance.RoleData.MissionInfoList.Count; i++)
            {
                MissionInfo missionInfo = GameData.Instance.RoleData.MissionInfoList[i];
                if (missionInfo != null)
                {
                    if (missionInfo.MissType == 0)
                    {
                        modMission.AcceptMission(missionInfo.ID);
                    }
                }
            }
            modAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_BORN, 1f, true);
        }
    }

    /// <summary>
    /// 添加热键
    /// </summary>
    private void addPlayerHotKey()
    {          
        //KeyManager.addNormalKey(KeyCode.Q, new Callback(this.ChangeWeapon));//改成切换角色
        //KeyManager.addNormalKey(KeyCode.BackQuote, new Callback(this.EnterFly));    
        //KeyManager.addNormalKey(KeyCode.F4, new Callback(Main.Quit));
        KeyManager.addNormalKey(KeyCode.F, new Callback(this.Operable));
    }

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

    private void CheckDead()
    {
        if (base.IsDead())
        {
            this.Die(false);
        }
    }

    public override void Die(bool qte)
    {
        if (this.modMFS.GetCurrentStateId() == CONTROL_STATE.DIE)
        {
            return;
        }
        base.Die(qte);
        //this.modMFS.ChangeState(new ControlEventDie(false));
        //CameraEffectManager.MainGrayscaleEffect.enabled = true;
        //Singleton<EZGUIManager>.GetInstance().GetGUI<DieGUI>().Show();
        GameTime.PauseGame();
    }

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

    /// <summary>
    /// 按键输入
    /// </summary>
    /// <param name="VerInput"></param>
    /// <param name="HorInput"></param>
    public override void Input(float VerInput, float HorInput)
    {
        if (base.IsDead())
        {
            return;
        }

        Vector3 a = this.m_cModCamera.cameraTransform.forward;//摄像机前方
        Vector3 vector = VerInput * a + HorInput * this.m_cModCamera.cameraTransform.right;
        Vector3 vector2 = base.GetPos() + vector;//移动目标点
        CONTROL_STATE currentStateId = this.modMFS.GetCurrentStateId();//获得当前状态枚举
        if (currentStateId != CONTROL_STATE.WALK_FORWARD)//当前状态不等于向前步行
        {
            if (currentStateId != CONTROL_STATE.SWIM)//当前状态不等于游泳
            {
                if (currentStateId != CONTROL_STATE.FLY)//当前状态不等于飞
                {
                    if (!(vector == Vector3.zero))//移动目标点不等于0点
                    {
                        this.modMFS.ChangeState(new ControlEventMoveForward(false, vector2, ACTION_INDEX.AN_RUN, base.RunSpeed, true));
                    }
                }
                else if (UnityEngine.Input.GetKey(KeyCode.Space))
                {
                    this.modMFS.ChangeState(new ControlEventFly(true, true, vector2, ACTION_INDEX.AN_FLY, 10f, true));
                }
                else
                {
                    //当前状态等于飞
                    this.modMFS.ChangeState(new ControlEventFly(true, false, vector2, ACTION_INDEX.AN_RUN, 30f, true));
                }
            }
            else
            {
                //当前状态等于游泳
                this.modMFS.ChangeState(new ControlEventSwim(true, base.GetTrans().position.y, vector2, ACTION_INDEX.AN_RUN, 3f, true));//游泳
            }
        }
        else if (vector == Vector3.zero)
        {
            this.modMFS.ChangeState(new ControlEventIdle(false));
        }
        else
        {
            this.modMFS.ChangeState(new ControlEventMoveForward(false, vector2, ACTION_INDEX.AN_RUN, base.RunSpeed, true));
        }
    }

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

    /// <summary>
    /// 读取玩家信息
    /// </summary>
    public void ReadPlayerPropertyInfoConfig()
    {
        List<string> list = RoleBaseFun.LoadConfInAssets("BasePlayerProperty");
        if (list == null)
        {
            return;
        }
        List<ATTRIBUTE_TYPE> list2 = new List<ATTRIBUTE_TYPE>();
        foreach (string text in list)
        {
            string[] array = text.Split(CacheData.separator);
            if (array != null)
            {
                if (array.Length >= 2)
                {
                    ATTRIBUTE_TYPE attribute_TYPE = (ATTRIBUTE_TYPE)Convert.ToInt32(array[0]);
                    if (this.m_cfgBaseInfo.IsHaveKey(attribute_TYPE))
                    {
                        this.m_cfgBaseInfo.dyPropertyKey[attribute_TYPE] = (float)Convert.ToDouble(array[1]);
                        list2.Add(attribute_TYPE);
                    }
                }
            }
        }
        this.m_cModAttribute.m_cfgBaseInfo = this.m_cfgBaseInfo;
        for (int i = 0; i < list2.Count; i++)
        {
            this.m_cModAttribute.SetAttributeNum(list2[i], this.m_cfgBaseInfo.dyPropertyKey[list2[i]], true);
        }
        this.m_cModAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_CHAPTER, 1f, true);//章
        this.m_cModAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_BORN, 0f, true);//出生
    }

    /// <summary>
    /// 初始化角色基础信息
    /// </summary>
    public void InitRoleBaseInfo()
    {
        if (this.roleinfo == null)
        {
            return;
        }
        //GameData.Instance.ItemMan.CreateItem(1910001UL, 1, ItemOwner.ITO_HEROFOLDER);
        foreach (KeyValuePair<RoleWearEquipPos, ulong> keyValuePair in this.roleinfo.DefultEquip)
        {
            if (GameData.Instance.ItemMan.CreateItem(keyValuePair.Value, 1, ItemOwner.ITO_HEROFOLDER))
            {
                Dictionary<ulong, CItemBase> dictionary = new Dictionary<ulong, CItemBase>();
                if (GameData.Instance.ItemMan.TryGetItemsByID(keyValuePair.Value, out dictionary))
                {
                    foreach (CItemBase item in dictionary.Values)
                    {
                        this.ItemFolder.WearOperate.TakeOn(item);
                    }
                }
            }
        }
    }

    public static void LoadPlayerRes(Player player)
    {
        //RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(player.SystemAmbit.ModelChangeID);
        //if (roleModelInfo != null)
        //{
        //    Debug.Log(roleModelInfo.Path);
        //    ResourceLoader.Load(roleModelInfo.Path, typeof(GameObject));
        //    //KeyValuePair<string, Type>[] effectResPath = UtilityRoleResource.GetEffectResPath(663);
        //    //if (effectResPath != null)
        //    //{
        //    //    foreach (KeyValuePair<string, Type> keyValuePair in effectResPath)
        //    //    {
        //    //        Debug.Log(keyValuePair.Key);
        //    //        ResourceLoader.Load(keyValuePair.Key, keyValuePair.Value);
        //    //    }
        //    //}
        //    //effectResPath = UtilityRoleResource.GetEffectResPath(780);
        //    //if (effectResPath != null)
        //    //{
        //    //    foreach (KeyValuePair<string, Type> keyValuePair2 in effectResPath)
        //    //    {
        //    //        Debug.Log(keyValuePair2.Key);
        //    //        ResourceLoader.Load(keyValuePair2.Key, keyValuePair2.Value);
        //    //    }
        //    //}
        //}
        //foreach (AdeptTalent.AdeptData adeptData in player.m_cAdeptSystem.AdeptTalentConfig.Values)
        //{
        //    if (!adeptData.IsLock)
        //    {
        //        if (adeptData.IsUnLockAnimation == 1)
        //        {
        //            Player.LoadAttackRes(adeptData.WeaponType, adeptData.AmbitID);
        //        }
        //    }
        //}
    }

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
