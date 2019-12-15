using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制
/// </summary>
public class GUIControl : MonoBehaviour
{
    public static GameObject playerPanelInstant;

    public static GameObject pausePanelInstant;

    public static GameObject monsterPanelInstant;

    public static GameObject moviePanelInstant;

    public static GameObject skillPanelInstant;

    public static GameObject monsterPerfab;

    public static GameObject contiuGameobject;

    public static GameObject itemGameobject;

    public static GameObject attributeGameObject;

    private static GameObject monsterNameGameobject;

    //private UIProgress playerBar;

    //private UIProgressBar monsterBar;

    //private UIProgressBar monsterBar2;

    private static GameObject bloodProtagonist;

    private static GameObject mpProtagonist;

    private static GameObject monsterBarGameobject;

    private static GameObject monsterBarGameobject2;

    //private UIStateToggleBtn loadPoint;

    private Camera cameraGUI;

    public static bool pointIsUI;

    public static bool pauseIsAuto;

    public static bool monsterIsShow;

    public static bool uiIsControl;

    public static AudioSource click;

    public static int mouseNumber;

    public static Texture2D monsterHead;

    public static Texture2D monsterName;

    public Monster monsterScript;

    //public SpriteText nameMonster;

    public static bool MovieIsShow;

    public List<GameObject> hideGoList = new List<GameObject>();

    public static GameObject OpeText;

    public static GameObject SceneName;

    public SceneInfo sceneInfo;

    public float creatTime;

    public static GUIControl instance;

    //private UIProgress playerMP;

    public static GameObject hpGameObject;

    public static GameObject mpGameObject;

    private void Start()
	{
		//this.SetSound();
	}

	private void SetSound()
	{
	}

	private void OnGUI()
	{
	}

	private void Awake()
	{
		//GUIControl.instance = this;
		////UnityEngine.Object.DontDestroyOnLoad(this);
		//GameObject original = (GameObject)ResourceLoader.Load("EZGUI/SceneName", typeof(GameObject));
		//GUIControl.SceneName = (UnityEngine.Object.Instantiate(original, new Vector3(0f, 122.8469f, 5f), Quaternion.identity) as GameObject);
		//GUIControl.SceneName.transform.parent = GameObject.FindWithTag("UICam").transform;
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
		//Singleton<EZGUIManager>.GetInstance().Init();
	}

	private void Update()
	{
		//if (Time.time > this.creatTime + 2.5f && GUIControl.SceneName != null)
		//{
		//	UnityEngine.Object.Destroy(GUIControl.SceneName.gameObject);
		//}
	}

	public void Panel()
	{
		UnityEngine.Object original = ResourceLoader.Load("EZGUI/MoviePanel", typeof(GameObject));
		GUIControl.moviePanelInstant = (UnityEngine.Object.Instantiate(original, new Vector3(0f, 122.8469f, 5f), Quaternion.identity) as GameObject);
		GUIControl.moviePanelInstant.transform.parent = GameObject.FindWithTag("UICam").transform;
		GUIControl.moviePanelInstant.transform.FindChild("FadePanel").gameObject.active = false;
	}

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
