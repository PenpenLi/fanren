using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景管理
/// </summary>
public class FanrenSceneManager : MonoBehaviour
{
    public const string SceneEnd = "End";

    public const string SceneLanding = "Landing";

    public string ClassName = "FanrenSceneManager";

    /// <summary>
    /// 当前场景信息
    /// </summary>
    public static SceneInfo currScenenInfo;

    public static TeleportInfo currentTeleport;

    private static RoleManager _roleManager;

    public static FanrenSceneManager Instance;

    public static bool loading;

    public static bool showLogo;

    public static bool loadingFromSave;

    private Color col = new Color(0f, 0f, 0f, 0f);

    public static RoleManager RoleMan
    {
        get
        {
            return FanrenSceneManager._roleManager;
        }
        set
        {
            FanrenSceneManager._roleManager = value;
        }
    }

    private void Awake()
	{
        FanrenSceneManager.Instance = this;
        FanrenSceneManager.loading = false;
        this.GameStart();
    }

    /// <summary>
    /// 游戏开始
    /// </summary>
	public void GameStart()
	{
        this.Init();

        if (SceneManager.GetActiveScene().name != "Start" && SceneManager.GetActiveScene().name != "Landing" && SceneManager.GetActiveScene().name != "End")
        {
            this.InitScene();
            GameTime.Init();
        }

        if (SceneManager.GetActiveScene().name == "Landing")
        {
            this.PlayGameBgSound();
        }

        //if (Application.loadedLevelName != "Start" && Application.loadedLevelName != "Landing" && Application.loadedLevelName != "End" && Application.loadedLevelName != "Credits")
        //{
        //    //GUIControl.MovieClose();
        //    //this.EnterScene();
        //    //Singleton<CResourcesStaticManager>.GetInstance();
        //    //EZGUIManager._BindRunTimeObj.AddRunGUIEx();
        //}
        //if (Application.loadedLevelName == "Landing")
        //{
        //    //EZGUIManager._BindRunTimeObj.AddLandUI();
        //    //this.ReStartGame(true);
        //}
        //else
        //{
        //    //EZGUIManager._BindRunTimeObj.RemoveLandUI();
        //}
        //if (Application.loadedLevelName == "End" || Application.loadedLevelName == "Credits")
        //{
        //    //this.ReStartGame(false);
        //}
        //Main.Instance.DelayGC(20f);
    }

    //private void ReStartGame(bool show)
    //{
    //	UICamera.Instance.uiCamera.gameObject.SetActive(show);
    //	KeyManager.hotKeyEnabled = show;
    //}

    public static void LoadLevel(string name, bool isShow, bool bLoadSave, bool fromSave)
    {
        if (FanrenSceneManager.loading)
        {
            Debug.LogWarning("Load twice");
            return;
        }
        FanrenSceneManager.loading = true;
        //LandPlane.m_bAddInput = true;
        //Singleton<HpCautionEffect>.GetInstance().SetRender(false, false);
        if (isShow && name != "Landing")
        {
            //Singleton<EZGUIManager>.GetInstance().GetGUI<LoadingMain>().Show();
        }
        if (bLoadSave)
        {
            //SDManager.SetRoleDate();
            //SDManager.AddCurSceneDate();
        }
        FanrenSceneManager.loadingFromSave = fromSave;
        Main.Instance.StartCoroutine(FanrenSceneManager.WaitToLoad(name));
    }

    private static IEnumerator WaitToLoad(string name)
    {
        yield return new WaitForFixedUpdate();
        //LoadMachine.ClearLoadedObj();
        if (name == "Landing")
        {
            //SceneManager.ResetSaveData();
        }
        SceneManager.LoadScene(name);
        yield break;
    }

    //public static void LoadLevel(int levIdx, bool isShow, bool bLoadSave)
    //{
    //	if (SceneManager.loading)
    //	{
    //		Debug.LogWarning(DU.Warning(new object[]
    //		{
    //			"Load twice"
    //		}));
    //		return;
    //	}
    //	SceneManager.loading = true;
    //	LoadMachine.isLoadCompleted = false;
    //	Singleton<HpCautionEffect>.GetInstance().SetRender(false, false);
    //	LandPlane.m_bAddInput = true;
    //	if (HelpManager._instance != null)
    //	{
    //		HelpManager._instance.HelpExitEx();
    //	}
    //	if (isShow && levIdx != 1)
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<LoadingMain>().Show();
    //	}
    //	if (bLoadSave)
    //	{
    //		SDManager.SetRoleDate();
    //		SDManager.AddCurSceneDate();
    //	}
    //	SceneManager.loadingFromSave = !bLoadSave;
    //	Main.Instance.StartCoroutine(SceneManager.WaitToLoad(levIdx));
    //}

    //private static IEnumerator WaitToLoad(int levelindex)
    //{
    //	yield return new WaitForFixedUpdate();
    //	LoadMachine.ClearLoadedObj();
    //	if (levelindex == 1)
    //	{
    //		SceneManager.ResetSaveData();
    //	}
    //	Application.LoadLevel(levelindex);
    //	yield break;
    //}

    //public static void ResetSaveData()
    //{
    //	SDManager.SDSave.Reset();
    //	SDManager.SDSave = new SaveData();
    //	DynamicData.SetDate(SDManager.SDSave.SaveDateGame.MoiveInfoList);
    //}

    //public static void LoadLanding()
    //{
    //	SceneManager.LoadLevel("Landing", false, false, false);
    //	if (Singleton<EZGUIManager>.GetInstance().GetGUI("LandPlane") != null)
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<LandPlane>().StartCoroutine(SceneManager.ShowLand());
    //	}
    //}

    //private static IEnumerator ShowLand()
    //{
    //	yield return new WaitForFixedUpdate();
    //	Singleton<EZGUIManager>.GetInstance().GetGUI<LandPlane>().Show();
    //	yield break;
    //}

    //public static void LoadPrevLevel()
    //{
    //	int num = Application.loadedLevel;
    //	if (num > 1)
    //	{
    //		num--;
    //		SceneManager.currentTeleport = null;
    //		SceneManager.LoadLevel(num, true, true);
    //	}
    //}

    //public static void LoadNextLevel()
    //{
    //	int num = Application.loadedLevel;
    //	if (num < Application.levelCount - 1)
    //	{
    //		num++;
    //		SceneManager.currentTeleport = null;
    //		SceneManager.LoadLevel(num, true, true);
    //	}
    //}
     
    private void Init()
    {
        this.GetSceneInfo();
        Main.InitMain();
        //UICamera.InitUICamera();
        //SystemSetting.initialize();
        //Singleton<ActorManager>.GetInstance().Clear();

        //if (SceneManager.GetActiveScene().name== "Start")
        //{
        //    GameData.Instance.ScrMan.Exec(31, 10110);
        //}
    }

    /// <summary>
    /// 获得当前场景信息
    /// </summary>
    private void GetSceneInfo()
    {
        FanrenSceneManager.currScenenInfo = GameData.Instance.cacheData.getSceneInfo(SceneManager.GetActiveScene().name);
        if (FanrenSceneManager.currScenenInfo == null)
        {
            Debug.LogError("not find scene info:" + SceneManager.GetActiveScene().name);
        }
    }

    private void InitScene()
    {
        ////出生点
        if (FanrenSceneManager.currentTeleport != null)
        {
            PlayerInfo.PLAYER_POSITION = new Vector3(FanrenSceneManager.currentTeleport.playerX, FanrenSceneManager.currentTeleport.playerY, FanrenSceneManager.currentTeleport.playerZ);
            PlayerInfo.PLAYER_ROTATION = new Vector3(0f, FanrenSceneManager.currentTeleport.rotY, 0f);
        }
        else
        {
            PlayerInfo.PLAYER_POSITION = new Vector3(FanrenSceneManager.currScenenInfo.posX, FanrenSceneManager.currScenenInfo.posY, FanrenSceneManager.currScenenInfo.posZ);
            PlayerInfo.PLAYER_ROTATION = new Vector3(0f, FanrenSceneManager.currScenenInfo.rotY, 0f);
        }
        //复活点
        PlayerInfo.PLAYER_REVIVE_POSITION = new Vector3(FanrenSceneManager.currScenenInfo.revive_x, FanrenSceneManager.currScenenInfo.revive_y, FanrenSceneManager.currScenenInfo.revive_z);
        PlayerInfo.PLAYER_REVIVE_ROTATION = new Vector3(0f, FanrenSceneManager.currScenenInfo.revive_rot_y, 0f);
        this.AddComponentMaker();
        
           // this.DoScriptMoudle();
        
    }

    //public void DoScriptMoudle()
    //{
    //	if (!GUIBind.binded || Player.Instance == null)
    //	{
    //		TimeOutManager.SetTimeOut(Main.Instance.transform, 0.02f, new Callback(this.DoScriptMoudle));
    //	}
    //	else
    //	{
    //		TimeOutManager.SetTimeOut(Main.Instance.transform, 0.5f, new Callback(this.HideLoading));
    //		if (SceneManager.scenenInfo != null && SceneManager.scenenInfo.scriptModId != -1)
    //		{
    //			GameData.Instance.ScrMan.Exec(27, SceneManager.scenenInfo.scriptModId);
    //		}
    //		TimeOutManager.SetTimeOut(Main.Instance.transform, 1f, new Callback(Singleton<EZGUIManager>.GetInstance().GetGUI<LoadingMain>().Hide));
    //	}
    //}

    //private void HideLoading()
    //{
    //	if (Singleton<EZGUIManager>.GetInstance().GetGUI<LoadingMain>())
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<LoadingMain>().Hide();
    //	}
    //	else
    //	{
    //		Debug.LogWarning("not find LoadingMain!");
    //	}
    //}

    private void AddComponentMaker()
    {
        FanrenSceneManager._roleManager = base.gameObject.AddComponent<RoleManager>();
        //Singleton<ActorManager>.GetInstance().MainCamera = base.gameObject;
        //GameObject gameObject = new GameObject("MovieManager");
        //MovieManager movieMag = gameObject.AddComponent<MovieManager>();
        //MovieManager.MovieMag = movieMag;
        //Singleton<ActorManager>.GetInstance().MainCamera = base.gameObject;
        //GameObject gameObject2 = new GameObject("SkillManager");
        //CSkillManager.Instance = gameObject2.AddComponent<CSkillManager>();
    }

    //private void EnterScene()
    //{
    //	this.PlayGameBgSound();
    //	TeleportManager.InitTeleport(SceneManager.scenenInfo.id);
    //	SystemSetting.SceneSetting();
    //}

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    private void PlayGameBgSound()
    {
        SingletonMono<MusicManager>.GetInstance().PlayMusic(FanrenSceneManager.currScenenInfo.bgSoundId, 0f, 1f, 0f);
        SingletonMono<AudioManager>.GetInstance().PauseAll(true);
    }
}
