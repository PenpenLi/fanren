using System;
//using Funfia.File;
using SoftStar.Pal6;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private static ScenesManager instance;

    //	public int loadedLevel;

    //	// Token: 0x040031FD RID: 12797
    //	public static bool IsChanging;

    //	// Token: 0x040031FE RID: 12798
    //	private static ShowLoading m_showLoading;

    //	// Token: 0x040031FF RID: 12799
    //	private static int m_loadLevel = -1;

    //	// Token: 0x04003200 RID: 12800
    //	public string flashPath = string.Empty;

    //	// Token: 0x04003201 RID: 12801
    //	private FlashStruct flashStruct;

    //	// Token: 0x04003202 RID: 12802
    //	private string nextDestObjName = string.Empty;

    //	// Token: 0x04003203 RID: 12803
    //	private int NextLevelIndex = -1;

    //	// Token: 0x04003204 RID: 12804
    //	public static float curSceneBeforeTime;

    public static int CurLoadedLevel = -1;

    public event Action<int> OnLevelLoaded;

    //	// Token: 0x1400002C RID: 44
    //	// (add) Token: 0x060037C6 RID: 14278 RVA: 0x00194A1C File Offset: 0x00192C1C
    //	// (remove) Token: 0x060037C7 RID: 14279 RVA: 0x00194A38 File Offset: 0x00192C38
    //	public event Action<int> OnChangeMap;

    public static ScenesManager Instance
    {
        get
        {
            if (ScenesManager.instance == null)
            {
                ScenesManager.Initialize();
            }
            return ScenesManager.instance;
        }
    }

    public static void Initialize()
    {
        PalMain gameMain = PalMain.GameMain;
        if (gameMain != null)
        {
            ScenesManager.instance = gameMain.GetComponent<ScenesManager>();
            if (ScenesManager.instance == null)
            {
                ScenesManager.instance = gameMain.gameObject.AddComponent<ScenesManager>();
            }
        }
    }

    private void Start()
    {
        UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
    }

    //	// Token: 0x060037CB RID: 14283 RVA: 0x00194ACC File Offset: 0x00192CCC
    //	public void ChangeMap(string DestName, int LevelIndex, Action<int> _OnLevelLoaded)
    //	{
    //		if (PalBattleManager.Instance() != null)
    //		{
    //			PalBattleManager.Instance().bEnableGoToBattle = true;
    //			PalBattleManager.Instance().m_bEnterBattle = false;
    //		}
    //		this.loadedLevel = LevelIndex;
    //		if (this.OnChangeMap != null)
    //		{
    //			this.OnChangeMap(LevelIndex);
    //		}
    //		int num = UnityEngine.Random.Range(0, 2);
    //		MapData data = MapData.GetData(this.loadedLevel);
    //		string text = string.Empty;
    //		if (data != null)
    //		{
    //			if (num == 0)
    //			{
    //				text = data.LoadingImage0;
    //			}
    //			else
    //			{
    //				text = data.LoadingImage1;
    //			}
    //		}
    //		ShowLoading showLoading;
    //		if (string.IsNullOrEmpty(text))
    //		{
    //			Debug.LogError("imagePath == null or empty");
    //			showLoading = ShowLoading.Initialize("1");
    //		}
    //		else
    //		{
    //			showLoading = ShowLoading.Initialize(text);
    //		}
    //		if (showLoading != null)
    //		{
    //			string text2 = this.flashPath.ToLanguagePath();
    //			System.Console.WriteLine("Play flash: " + text2);
    //			this.flashStruct = FlashManager.Instance.Play(text2, null, new Action<UnityEngine.Object, EventArgs>(this.flashLoadFinish), true, false, ShowLoading.LoadingCamera, null);
    //			EntityManager.OnLoadOverEnd = (EntityManager.void_fun)Delegate.Remove(EntityManager.OnLoadOverEnd, new EntityManager.void_fun(this.EntityLoadOver));
    //			EntityManager.OnLoadOverEnd = (EntityManager.void_fun)Delegate.Combine(EntityManager.OnLoadOverEnd, new EntityManager.void_fun(this.EntityLoadOver));
    //		}
    //		this.OnLevelLoaded = (Action<int>)Delegate.Remove(this.OnLevelLoaded, _OnLevelLoaded);
    //		this.OnLevelLoaded = (Action<int>)Delegate.Combine(this.OnLevelLoaded, _OnLevelLoaded);
    //		if (string.IsNullOrEmpty(DestName))
    //		{
    //			DestName = "SceneEnter";
    //		}
    //		this.NextDestObjName = DestName;
    //		GameStateManager.ClearState();
    //		GameStateManager.CurGameState = GameState.Loading;
    //		if (LevelIndex == -1)
    //		{
    //			Debug.LogError("[Error] : LevelIndex = -1 on ChangeMap");
    //		}
    //		ScenesManager.m_loadLevel = LevelIndex;
    //		ScenesManager.m_showLoading = showLoading;
    //	}

    //	// Token: 0x060037CC RID: 14284 RVA: 0x00194C80 File Offset: 0x00192E80
    //	public void flashLoadFinish(UnityEngine.Object obj, EventArgs args)
    //	{
    //		if (ScenesManager.m_showLoading != null)
    //		{
    //			ScenesManager.m_showLoading.setDepth(obj, args);
    //		}
    //		this.LoadLevel(ScenesManager.m_loadLevel);
    //	}

    //	// Token: 0x060037CD RID: 14285 RVA: 0x00194CAC File Offset: 0x00192EAC
    //	public void RandomFlash()
    //	{
    //		bool flag = true;
    //		int flag2 = PalMain.GetFlag(1);
    //		do
    //		{
    //			int num = UnityEngine.Random.Range(0, FlashManager.FlashScenePaths.Length);
    //			if ((num != 5 || flag2 >= 224020) && !this.flashPath.Equals(FlashManager.FlashScenePaths[num]))
    //			{
    //				this.flashPath = FlashManager.FlashScenePaths[num];
    //				flag = false;
    //			}
    //		}
    //		while (flag);
    //	}

    //	// Token: 0x060037CE RID: 14286 RVA: 0x00194D10 File Offset: 0x00192F10
    //	private void EntityLoadOver()
    //	{
    //		EntityManager.OnLoadOverEnd = (EntityManager.void_fun)Delegate.Remove(EntityManager.OnLoadOverEnd, new EntityManager.void_fun(this.EntityLoadOver));
    //		if (this.flashStruct != null)
    //		{
    //			this.flashStruct.DestroyFlash();
    //			this.flashStruct = null;
    //		}
    //		this.RandomFlash();
    //	}

    //	// Token: 0x17000446 RID: 1094
    //	// (get) Token: 0x060037CF RID: 14287 RVA: 0x00194D60 File Offset: 0x00192F60
    //	// (set) Token: 0x060037D0 RID: 14288 RVA: 0x00194D68 File Offset: 0x00192F68
    //	public string NextDestObjName
    //	{
    //		get
    //		{
    //			return this.nextDestObjName;
    //		}
    //		set
    //		{
    //			this.nextDestObjName = value;
    //		}
    //	}

    //	// Token: 0x060037D1 RID: 14289 RVA: 0x00194D74 File Offset: 0x00192F74
    //	public void LoadLevel(int LevelIndex)
    //	{
    //		this.NextLevelIndex = LevelIndex;
    //		base.StartCoroutine(UtilFun.LoadLevelAsync("empty"));
    //	}

    //	// Token: 0x060037D2 RID: 14290 RVA: 0x00194D90 File Offset: 0x00192F90
    //	private void OnLevelWasLoaded(int level)
    //	{
    //		ScenesManager.curSceneBeforeTime = Time.time;
    //		if (SceneManager.GetActiveScene().name == "empty")
    //		{
    //			FileLoader.UnloadAllAssetBundles();
    //			base.StartCoroutine(UtilFun.LoadLevelAsync(this.NextLevelIndex));
    //			PalMain.LoadingValue = 0.05f;
    //		}
    //		else
    //		{
    //			GC.Collect();
    //			UtilFun.DestroyGhostCamera();
    //			ScenesManager.CurLoadedLevel = UtilFun.GetPalMapLevel(level);
    //			PalMain.LoadingValue = 0.15f;
    //			if (this.OnLevelLoaded != null)
    //			{
    //				this.OnLevelLoaded(level);
    //			}
    //		}
    //	}
}
