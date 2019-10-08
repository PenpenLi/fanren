using System;

/// <summary>
/// 游戏数据
/// </summary>
public class GameData
{
    public ScriptManager ScrMan = new ScriptManager();

    //public AreaManager AreaMan = new AreaManager();

    //public NpcTalk_1_DataMan NpcTalk1Data = new NpcTalk_1_DataMan();

    //public NpcTalk_2_DataMan NpcTalk2Data = new NpcTalk_2_DataMan();

    //public NpcTalk_3_DataMan NpcTalk3Data = new NpcTalk_3_DataMan();

    //public NpcTalk_MultiAniMan NpcTalkMultiAniMan = new NpcTalk_MultiAniMan();

    //public SDM_SpawnMonster SDM_SpawnMon = new SDM_SpawnMonster();

    //public RoleDateInfo RoleData = new RoleDateInfo();

    //public SDM_ScriptsGroup SDM_ScrGro = new SDM_ScriptsGroup();

    //public TriggerData triggerData = new TriggerData();

    //public ReadOperableChestInfo chest = new ReadOperableChestInfo();

    //public ReadOperableHerbalInfo herbal = new ReadOperableHerbalInfo();

    //public ReadOperableOrganInfo organ = new ReadOperableOrganInfo();

    //public AttackTable attackTable = new AttackTable();

    //public ColliderTable colliderTable = new ColliderTable();

    //public SoundTable soundTable = new SoundTable();

    public CacheData cacheData = new CacheData();

    //public UserData userData = new UserData();

    //public CItemStaticManager ItemStaticMan = new CItemStaticManager();

    public CItemManager ItemMan = new CItemManager();

    //public ShopManager ShopMan = new ShopManager();

    //public RadioMessageManager RadioCenter = new RadioMessageManager();

    //public EZGUIManager GUIMan = new EZGUIManager();

    //public RoleBaseConfig RoleBaseCfg = new RoleBaseConfig();

    public ArtResourceConfig ArtResConf = new ArtResourceConfig();

    //public WeaponInfo weaponInfo = new WeaponInfo();

    //public PopInfo popInfo = new PopInfo();

    //public WalkPathInfo walkPathInfo = new WalkPathInfo();

    //public HelpInfo helpInfo = new HelpInfo();

    //public LoadingInfo LoadInfo = new LoadingInfo();

    //public MapNameInfo mapNameInfo = new MapNameInfo();

    //public CultureInfo cultureInfo = new CultureInfo();

    //public BundleInfo bundleInfo = new BundleInfo();

    private static GameData instance;

    public static int GAME_VERSION = 1001001;

    public static GameData Instance
	{
		get
		{
			GameData.CreatGameData();
			return GameData.instance;
		}
	}

	public static void CreatGameData()
	{
		if (GameData.instance != null)
		{
			return;
		}
		GameData.instance = new GameData();
		GameData.Start();
	}

	//public string GetStr(int id)
	//{
	//	return this.RoleData.GetStr(id);
	//}

	//public int GetHash(int id)
	//{
	//	return this.RoleData.GetMonsterHash(id);
	//}

	//public void HashChange(int id, int tag)
	//{
	//	this.RoleData.ChangeHash(id, tag);
	//}

	private static void Start()
	{
		//GameData.instance.bundleInfo.initialize();
		GameData.Instance.ArtResConf.LoadConf();
		GameData.Instance.ScrMan.ReadScrModInfo();
		//GameData.Instance.NpcTalk1Data.ReadData();
		//GameData.Instance.NpcTalk2Data.ReadTextInf();
		//GameData.Instance.NpcTalk3Data.ReadTextInf();
		//GameData.Instance.NpcTalkMultiAniMan.ReadTextInf();
		//GameData.Instance.RoleData.LoadConf();
		//GameData.Instance.triggerData.ReadData();
		//GameData.Instance.SDM_SpawnMon.ReadData();
		//GameData.Instance.SDM_ScrGro.ReadData();
		//GameData.Instance.walkPathInfo.ReadWalkPathInfo();
		//GameData.Instance.helpInfo.ReadHelpInfo();
		//GameData.Instance.mapNameInfo.ReadMapNameInfo();
		//GameData.Instance.attackTable.initialize();
		//GameData.Instance.colliderTable.initialize();
		//GameData.Instance.soundTable.initialize();
		GameData.Instance.cacheData.initialize();
		//GameData.Instance.userData.initialize();
		//GameData.Instance.chest.ReadInfo();
		//GameData.Instance.herbal.ReadInfo();
		//GameData.Instance.organ.ReadInfo();
		//GameData.Instance.ItemStaticMan.Load();
		GameData.Instance.ItemMan.Clear();
		//GameData.Instance.weaponInfo.initialize();
		//GameData.Instance.popInfo.initialize();
		//GameData.Instance.ShopMan.ShopDataLoad();
		//GameData.Instance.LoadInfo.ReadLoadInfo();
		//GameData.instance.cultureInfo.ReadCultureInfo();
	}

	public static void NpcTalkOne()
	{
		//GameData.Instance.ScrMan.Exec(1, 1);
	}
}
