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
    public static SceneInfo curScenenInfo;

    /// <summary>
    /// 传送信息
    /// </summary>
    public static TeleportInfo curentTeleport;

    /// <summary>
    /// 角色管理
    /// </summary>
    private static RoleManager _roleManager;
    
    /// <summary>
    /// 场景管理
    /// </summary>
    public static FanrenSceneManager Instance;

    public static bool loading;

    public static bool showLogo;

    public static bool loadingFromSave;

    private Color col = new Color(0f, 0f, 0f, 0f);

    string currSceneName;

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
        currSceneName = SceneManager.GetActiveScene().name;

        this.Init();

        if (currSceneName != "Start" && currSceneName != "Landing" && currSceneName != "End")
        {
            this.InitScene();
            GameTime.Init();
        }

        if (currSceneName == "Landing")
        {
            //this.PlayGameBgSound();//播放背景音乐
        }

        if (currSceneName != "Start" && currSceneName != "Landing" && currSceneName != "End" && currSceneName != "Credits")
        {
            //this.EnterScene();
           //加载UI
        }

        //if (Application.loadedLevelName == "Landing")
        //{
        //    EZGUIManager._BindRunTimeObj.AddLandUI();
        //    this.ReStartGame(true);
        //}
        //else
        //{
        //    EZGUIManager._BindRunTimeObj.RemoveLandUI();
        //}

        //if (Application.loadedLevelName == "End" || Application.loadedLevelName == "Credits")
        //{
        //    this.ReStartGame(false);
        //}

        //Main.Instance.DelayGC(20f);//延迟GC
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
            Debug.LogWarning("加载两次");
            return;
        }
        FanrenSceneManager.loading = true;
        //Singleton<HpCautionEffect>.GetInstance().SetRender(false, false);//血量警告特效
        if (isShow && name != "Landing")
        {
            //Singleton<EZGUIManager>.GetInstance().GetGUI<LoadingMain>().Show();//显示加载UI
        }

        if (bLoadSave)//加载存档
        {
            SDManager.SetRoleDate();
            SDManager.AddCurSceneDate();
        }

        FanrenSceneManager.loadingFromSave = fromSave;
        Main.Instance.StartCoroutine(FanrenSceneManager.WaitToLoad(name));
    }

    private static IEnumerator WaitToLoad(string name)
    {
        yield return new WaitForFixedUpdate();
        if (name == "Landing")
        {
            FanrenSceneManager.ResetSaveData();
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

    /// <summary>
    /// 重置存档数据
    /// </summary>
    public static void ResetSaveData()
    {
        SDManager.SDSave.Reset();
        SDManager.SDSave = new SaveData();
        DynamicData.SetDate(SDManager.SDSave.SaveDateGame.MoiveInfoList);
    }

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

    private void Init()
    {
        this.GetSceneInfo();
        Main.InitMain();

        //SystemSetting.initialize();//加载系统设置
        //Singleton<ActorManager>.GetInstance().Clear();//清空演员

        if (currSceneName == "Start")
        {
            GameData.Instance.ScrMan.Exec(31, 10099);
        }

        if (currSceneName == "End")
        {
            //Main.Instance.StartCoroutine(this.GameOverCG());
        }

        if (currSceneName == "Credits")
        {
            //Main.Instance.StartCoroutine(this.Credits());
        }
    }

    /// <summary>
    /// 获得当前场景信息
    /// </summary>
    private void GetSceneInfo()
    {
        FanrenSceneManager.curScenenInfo = GameData.Instance.cacheData.getSceneInfo(SceneManager.GetActiveScene().name);
        if (FanrenSceneManager.curScenenInfo == null)
        {
            Debug.LogError("not find scene info:" + SceneManager.GetActiveScene().name);
        }
    }

    /// <summary>
    /// 初始化场景
    /// </summary>
    private void InitScene()
    {
        ////出生点
        if (FanrenSceneManager.curentTeleport != null)
        {
            PlayerInfo.PLAYER_POSITION = new Vector3(FanrenSceneManager.curentTeleport.playerX, FanrenSceneManager.curentTeleport.playerY, FanrenSceneManager.curentTeleport.playerZ);
            PlayerInfo.PLAYER_ROTATION = new Vector3(0f, FanrenSceneManager.curentTeleport.rotY, 0f);
        }
        else
        {
            PlayerInfo.PLAYER_POSITION = new Vector3(FanrenSceneManager.curScenenInfo.posX, FanrenSceneManager.curScenenInfo.posY, FanrenSceneManager.curScenenInfo.posZ);
            PlayerInfo.PLAYER_ROTATION = new Vector3(0f, FanrenSceneManager.curScenenInfo.rotY, 0f);
        }
        //复活点
        PlayerInfo.PLAYER_REVIVE_POSITION = new Vector3(FanrenSceneManager.curScenenInfo.revive_x, FanrenSceneManager.curScenenInfo.revive_y, FanrenSceneManager.curScenenInfo.revive_z);
        PlayerInfo.PLAYER_REVIVE_ROTATION = new Vector3(0f, FanrenSceneManager.curScenenInfo.revive_rot_y, 0f);
        this.AddComponentMaker();//添加组件
        
        this.DoScriptMoudle(); //执行脚本模块        
    }

    public void DoScriptMoudle()
    {
        Debug.Log("执行");
        //TimeOutManager.SetTimeOut(Main.Instance.transform, 0.5f, new Callback(this.HideLoading));//关闭UI
        if (FanrenSceneManager.curScenenInfo != null && FanrenSceneManager.curScenenInfo.scriptModId != -1)
        {
            Debug.Log("执行");
            GameData.Instance.ScrMan.Exec(27, FanrenSceneManager.curScenenInfo.scriptModId);
        }
        //TimeOutManager.SetTimeOut(Main.Instance.transform, 1f, new Callback(Singleton<EZGUIManager>.GetInstance().GetGUI<LoadingMain>().Hide));
    }

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
    }

    /// <summary>
    /// 进入场景
    /// </summary>
    private void EnterScene()
    {
        //this.PlayGameBgSound();
        //TeleportManager.InitTeleport(SceneManager.scenenInfo.id);
        //SystemSetting.SceneSetting();
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    private void PlayGameBgSound()
    {
        SingletonMono<MusicManager>.GetInstance().PlayMusic(FanrenSceneManager.curScenenInfo.bgSoundId, 0f, 1f, 0f);
        SingletonMono<AudioManager>.GetInstance().PauseAll(true);
    }
}
