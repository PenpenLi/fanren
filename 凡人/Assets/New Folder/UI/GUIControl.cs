using System;
using System.Collections.Generic;
using UnityEngine;

public class GUIControl : MonoBehaviour
{
    public static GameObject playerPanelInstant;

    // Token: 0x0400095E RID: 2398
    public static GameObject pausePanelInstant;

    // Token: 0x0400095F RID: 2399
    public static GameObject monsterPanelInstant;

    // Token: 0x04000960 RID: 2400
    public static GameObject moviePanelInstant;

    // Token: 0x04000961 RID: 2401
    public static GameObject skillPanelInstant;

    // Token: 0x04000962 RID: 2402
    public static GameObject monsterPerfab;

    // Token: 0x04000963 RID: 2403
    public static GameObject contiuGameobject;

    // Token: 0x04000964 RID: 2404
    public static GameObject itemGameobject;

    // Token: 0x04000965 RID: 2405
    public static GameObject attributeGameObject;

    // Token: 0x04000966 RID: 2406
    private static GameObject monsterNameGameobject;

    // Token: 0x04000967 RID: 2407
    //private UIProgress playerBar;

    //// Token: 0x04000968 RID: 2408
    //private UIProgressBar monsterBar;

    //// Token: 0x04000969 RID: 2409
    //private UIProgressBar monsterBar2;

    // Token: 0x0400096A RID: 2410
    private static GameObject bloodProtagonist;

    // Token: 0x0400096B RID: 2411
    private static GameObject mpProtagonist;

    // Token: 0x0400096C RID: 2412
    private static GameObject monsterBarGameobject;

    // Token: 0x0400096D RID: 2413
    private static GameObject monsterBarGameobject2;

    // Token: 0x0400096E RID: 2414
    //private UIStateToggleBtn loadPoint;

    // Token: 0x0400096F RID: 2415
    private Camera cameraGUI;

    // Token: 0x04000970 RID: 2416
    public static bool pointIsUI;

    // Token: 0x04000971 RID: 2417
    public static bool pauseIsAuto;

    // Token: 0x04000972 RID: 2418
    public static bool monsterIsShow;

    // Token: 0x04000973 RID: 2419
    public static bool uiIsControl;

    // Token: 0x04000974 RID: 2420
    public static AudioSource click;

    // Token: 0x04000975 RID: 2421
    public static int mouseNumber;

    // Token: 0x04000976 RID: 2422
    public static Texture2D monsterHead;

    // Token: 0x04000977 RID: 2423
    public static Texture2D monsterName;

    // Token: 0x04000978 RID: 2424
    public Monster monsterScript;

    // Token: 0x04000979 RID: 2425
    //public SpriteText nameMonster;

    // Token: 0x0400097A RID: 2426
    public static bool MovieIsShow;

    // Token: 0x0400097B RID: 2427
    public List<GameObject> hideGoList = new List<GameObject>();

    // Token: 0x0400097C RID: 2428
    public static GameObject OpeText;

    // Token: 0x0400097D RID: 2429
    public static GameObject SceneName;

    // Token: 0x0400097E RID: 2430
    public SceneInfo sceneInfo;

    // Token: 0x0400097F RID: 2431
    public float creatTime;

    // Token: 0x04000980 RID: 2432
    public static GUIControl instance;

    // Token: 0x04000981 RID: 2433
    //private UIProgress playerMP;

    // Token: 0x04000982 RID: 2434
    public static GameObject hpGameObject;

    // Token: 0x04000983 RID: 2435
    public static GameObject mpGameObject;

    private void Start()
	{
		this.SetSound();
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x0003FD04 File Offset: 0x0003DF04
	private void SetSound()
	{
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x0003FD08 File Offset: 0x0003DF08
	private void OnGUI()
	{
	}

	// Token: 0x06000A22 RID: 2594 RVA: 0x0003FD0C File Offset: 0x0003DF0C
	private void Awake()
	{
		GUIControl.instance = this;
		//UnityEngine.Object.DontDestroyOnLoad(this);
		GameObject original = (GameObject)ResourceLoader.Load("EZGUI/SceneName", typeof(GameObject));
		GUIControl.SceneName = (UnityEngine.Object.Instantiate(original, new Vector3(0f, 122.8469f, 5f), Quaternion.identity) as GameObject);
		GUIControl.SceneName.transform.parent = GameObject.FindWithTag("UICam").transform;
		//SpriteText component = GUIControl.SceneName.transform.FindChild("Name").GetComponent<SpriteText>();
		//if (SceneManager.scenenInfo.mapName != "登陆界面" && SceneManager.scenenInfo.name != "Start")
		//{
		//	component.Text = SceneManager.scenenInfo.mapName;
		//}
		//this.creatTime = Time.time;
		//GameObject original2 = (GameObject)ResourceLoader.Load("EZGUI/QuickTimeButton/OnceButton", typeof(GameObject));
		////GUIControl.OpeText = (UnityEngine.Object.Instantiate(original2, StageUIShowOneKey.m_ShowPos, Quaternion.identity) as GameObject);
		//GUIControl.OpeText.transform.parent = GameObject.FindWithTag("UICam").transform;
		//GUIControl.OpeText.active = false;
		//this.Panel();
		//this.cameraGUI = GameObject.FindWithTag("UICam").transform.GetComponent<Camera>();
		Singleton<EZGUIManager>.GetInstance().Init();
	}

	private void Update()
	{
		if (Time.time > this.creatTime + 2.5f && GUIControl.SceneName != null)
		{
			UnityEngine.Object.Destroy(GUIControl.SceneName.gameObject);
		}
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x0003FEB0 File Offset: 0x0003E0B0
	public void Panel()
	{
		UnityEngine.Object original = ResourceLoader.Load("EZGUI/MoviePanel", typeof(GameObject));
		GUIControl.moviePanelInstant = (UnityEngine.Object.Instantiate(original, new Vector3(0f, 122.8469f, 5f), Quaternion.identity) as GameObject);
		GUIControl.moviePanelInstant.transform.parent = GameObject.FindWithTag("UICam").transform;
		GUIControl.moviePanelInstant.transform.FindChild("FadePanel").gameObject.active = false;
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x0003FF38 File Offset: 0x0003E138
	public static void SetChildrenLevel(Transform root, int layer)
	{
		root.gameObject.layer = layer;
		foreach (object obj in root)
		{
			Transform transform = (Transform)obj;
			Transform transform2 = root.FindChild(transform.name);
			if (transform2 != null)
			{
				GUIControl.SetChildrenLevel(transform2, layer);
			}
		}
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x0003FFC8 File Offset: 0x0003E1C8
	public static void MovieReveal(float time, Color color)
	{
		//GUIControl.moviePanelInstant.transform.FindChild("FadePanel").gameObject.active = true;
		//GUIControl.moviePanelInstant.transform.FindChild("FadePanel").gameObject.GetComponent<BoxCollider>().size = new Vector3(100f, 100f, 0f);
		//UIBistateInteractivePanel component = GUIControl.moviePanelInstant.GetComponent<UIBistateInteractivePanel>();
		//component.GetTransition(UIPanelManager.SHOW_MODE.BringInForward).animParams[0].duration = time;
		//component.GetTransition(UIPanelManager.SHOW_MODE.BringInForward).animParams[0].color = Color.clear;
		//component.GetTransition(UIPanelManager.SHOW_MODE.BringInForward).animParams[0].color2 = color;
		//component.Reveal();
		GUIControl.SetChildrenLevel(GUIControl.moviePanelInstant.transform, 10);
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x00040090 File Offset: 0x0003E290
	public static void MovieHide(float time, Color color)
	{
		GUIControl.MovieReveal(0f, Color.black);
		GUIControl.moviePanelInstant.transform.FindChild("FadePanel").gameObject.active = true;
		//UIBistateInteractivePanel component = GUIControl.moviePanelInstant.GetComponent<UIBistateInteractivePanel>();
		//component.GetTransition(UIPanelManager.SHOW_MODE.DismissForward).animParams[0].duration = time;
		//component.GetTransition(UIPanelManager.SHOW_MODE.DismissForward).animParams[0].color = color;
		//component.GetTransition(UIPanelManager.SHOW_MODE.DismissForward).animParams[0].color2 = Color.clear;
		//component.Hide();
		GUIControl.SetChildrenLevel(GUIControl.moviePanelInstant.transform, 14);
		GUIControl.moviePanelInstant.transform.FindChild("FadePanel").gameObject.GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x00040164 File Offset: 0x0003E364
	public static void MovieClose()
	{
		if (GUIControl.moviePanelInstant == null || GUIControl.moviePanelInstant.transform == null)
		{
			return;
		}
		GameObject gameObject = GUIControl.moviePanelInstant.transform.FindChild("FadePanel").gameObject;
		if (gameObject == null)
		{
			return;
		}
		gameObject.active = false;
	}
}
