using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 登陆面板
/// </summary>
public class LandPlane : GUIBase
{
    //   private AudioSource _audioClick;

    //   private Dictionary<SystemTag, GameObject> m_prefabList = new Dictionary<SystemTag, GameObject>();

    //   private Dictionary<SystemTag, SystemTag> m_systemTagList = new Dictionary<SystemTag, SystemTag>();

    //   private Dictionary<SystemTag, SaveInfo> m_saveInfo = new Dictionary<SystemTag, SaveInfo>();

    public GameObject LoadPlane;

    public GameObject SystemPlane;

    //   protected POINTER_INFO m_loadPtEv = default(POINTER_INFO);

    //   // Token: 0x04000A88 RID: 2696
    //   private string fLastKey = "nokey";

    //   // Token: 0x04000A89 RID: 2697
    //   private float fLastTimer;

    //   // Token: 0x04000A8A RID: 2698
    //   private float fSpaceTimer = 0.3f;

    //   // Token: 0x04000A8C RID: 2700
    //   private string _str = string.Empty;

    //   // Token: 0x04000A8D RID: 2701
    //   private POINTER_INFO _ptCmd;

    //   // Token: 0x04000A8E RID: 2702
    //   private AudioSource m_click;

    //   // Token: 0x04000A8F RID: 2703
    //   protected string m_screenMode;

    //   // Token: 0x04000A90 RID: 2704
    //   protected int m_saveIndex;

    //   // Token: 0x04000A91 RID: 2705
    //   private UIButton m_resolutionsBtn;

    //   // Token: 0x04000A92 RID: 2706
    //   private UIButton m_qualityBtn;

    //   // Token: 0x04000A93 RID: 2707
    //   private UIButton m_screenModeBtn;

    //   // Token: 0x04000A94 RID: 2708
    //   private SpriteText m_resource;

    //   // Token: 0x04000A95 RID: 2709
    //   private static List<Resolution> m_resolutions = new List<Resolution>();

    //   // Token: 0x04000A96 RID: 2710
    //   protected Resolution m_resolution;

    //   // Token: 0x04000A97 RID: 2711
    //   protected QualityLevels m_qualityLevel;

    //   // Token: 0x04000A98 RID: 2712
    //   protected Camera _uiCam;

    //   // Token: 0x04000A99 RID: 2713
    //   private static UIScrollList m_resScrolList;

    //   // Token: 0x04000A9A RID: 2714
    //   private static UIScrollList m_qualityScrolList;

    //   // Token: 0x04000A9B RID: 2715
    //   private static UIScrollList m_modeScrolList;

    //   // Token: 0x04000A9C RID: 2716
    //   private UIPanelTab m_resTab;

    //   // Token: 0x04000A9D RID: 2717
    //   private UIPanelTab m_qualityTab;

    //   // Token: 0x04000A9E RID: 2718
    //   private UIPanelTab m_modeTab;

    //   // Token: 0x04000A9F RID: 2719
    //   private UIListItem m_resList;

    //   // Token: 0x04000AA0 RID: 2720
    //   private UIListItem m_qualityList;

    //   // Token: 0x04000AA1 RID: 2721
    //   private UIListItem m_modeList;

    //   // Token: 0x04000AA2 RID: 2722
    //   private UIStateToggleBtn m_backgroundVolumeToggle;

    //   // Token: 0x04000AA3 RID: 2723
    //   private UIStateToggleBtn m_gameVolumeToggle;

    //   // Token: 0x04000AA4 RID: 2724
    //   private UIStateToggleBtn m_dubTabToggle;

    //   // Token: 0x04000AA5 RID: 2725
    //   private UISlider m_backgroundVolumeSlider;

    //   // Token: 0x04000AA6 RID: 2726
    //   private UISlider m_gameVolumeSlider;

    //   // Token: 0x04000AA7 RID: 2727
    //   private UISlider m_dubVolumeSlider;

    //   // Token: 0x04000AA8 RID: 2728
    //   private UISlider m_qualitySlider;

    //   // Token: 0x04000AA9 RID: 2729
    //   private bool m_bBackgroundVolume;

    //   // Token: 0x04000AAA RID: 2730
    //   private bool m_bGameVolume;

    //   // Token: 0x04000AAB RID: 2731
    //   private bool m_bDubVolume;

    //   // Token: 0x04000AAC RID: 2732
    //   private string m_iResolution;

    //   // Token: 0x04000AAD RID: 2733
    //   private int m_iQuality;

    //   // Token: 0x04000AAE RID: 2734
    //   private int m_iMode;

    //   // Token: 0x04000AAF RID: 2735
    //   protected string[] m_strs = new string[]
    //   {
    //       "窗口",
    //       "全屏"
    //   };

    //   public static bool m_bAddInput = true;

    //   private static bool m_bDoShow = false;

    //   public static bool m_bDoChange = false;

    public override bool Init()
    {
        //foreach (SystemTag systemTag in this.m_buttonList.Keys)
        //{
        //    UIButton uibutton;
        //    if (this.m_buttonList.TryGetValue(systemTag, out uibutton))
        //    {
        //        int num = (int)systemTag;
        //        EventEZMsg @object = base.RegisterChildEZMsg(GUI_TYPE.UICMD_NONE, num.ToString());
        //        uibutton.AddInputDelegate(new EZInputDelegate(@object.OnCallBackMethod));
        //    }
        //}
        //this.m_loadItemAutoPrefab = this._landMiddleContiune.transform.FindChild("ItemChild_Save_1").gameObject;
        //if (this.m_loadItemAutoPrefab != null)
        //{
        //    this.m_prefabList.Add(SystemTag.LOAD_CHILD_AUTO, this.m_loadItemAutoPrefab);
        //}
        //this.m_loadItemOnePrefab = this._landMiddleContiune.transform.FindChild("ItemChild_Save_2").gameObject;
        //if (this.m_loadItemOnePrefab != null)
        //{
        //    this.m_prefabList.Add(SystemTag.LOAD_CHILD_ONE, this.m_loadItemOnePrefab);
        //}
        //this.m_loadItemTwoPrefab = this._landMiddleContiune.transform.FindChild("ItemChild_Save_3").gameObject;
        //if (this.m_loadItemTwoPrefab != null)
        //{
        //    this.m_prefabList.Add(SystemTag.LOAD_CHILD_TWO, this.m_loadItemTwoPrefab);
        //}
        //this.m_loadItemThreePrefab = this._landMiddleContiune.transform.FindChild("ItemChild_Save_4").gameObject;
        //if (this.m_loadItemThreePrefab != null)
        //{
        //    this.m_prefabList.Add(SystemTag.LOAD_CHILD_THREE, this.m_loadItemThreePrefab);
        //}
        //this.m_loadItemFourPrefab = this._landMiddleContiune.transform.FindChild("ItemChild_Save_5").gameObject;
        //if (this.m_loadItemFourPrefab != null)
        //{
        //    this.m_prefabList.Add(SystemTag.LOAD_CHILD_FOUR, this.m_loadItemFourPrefab);
        //}
        //base.SetParentEx(this._landPlane);
        //this.AddData();
        //this.PushData();
        //base.StartCoroutine(this.ResolutionListEx());
        return true;
    }

    private void Start()
    {
        KeyManager.hotKeyEnabled = false;
        SingletonMono<AudioManager>.GetInstance().PauseAll(false);//播放音乐
        MouseManager.ShowCursor(true);//显示鼠标
    }

    public void OnNewGameBtn()
    {
        GameData.Instance.ScrMan.Exec(31, 10110);
    }

    public void OnLoadBtn()
    {
        LoadPlane.SetActive(true);
    }

    public void OnSystemBtn()
    {
        SystemPlane.SetActive(true);
    }

    public void OnLoadbackBtn()
    {
        LoadPlane.SetActive(false);
    }

    public void OnSystembackBtn()
    {
        SystemPlane.SetActive(false);
    }

    //public void PushData()
    //{
    //	this.m_resolutionsBtn = this._landMiddleSystem.transform.FindChild("ResManager/showButton").GetComponent<UIButton>();
    //	this.m_buttonSound.Clear();
    //	this.m_buttonSound.Add(this.m_resolutionsBtn);
    //	this.m_resTab = this._landMiddleSystem.transform.FindChild("Res").GetComponent<UIPanelTab>();
    //	this.m_resTab.AddInputDelegate(new EZInputDelegate(this.OnCallBackResolution));
    //	LandPlane.m_resScrolList = this._landMiddleSystem.transform.FindChild("ResManager/ResPanel/Scrollist").GetComponent<UIScrollList>();
    //	LandPlane.m_resScrolList.scriptWithMethodToInvoke = Singleton<EZGUIManager>.GetInstance().GetGUI("LandPlane");
    //	LandPlane.m_resScrolList.methodToInvokeOnSelect = "ResolutionListSelect";
    //	this.m_resList = this._landMiddleSystem.transform.FindChild("Item").GetComponent<UIListItem>();
    //	this.m_resList.scriptWithMethodToInvoke = Singleton<EZGUIManager>.GetInstance().GetGUI("LandPlane");
    //	this.m_resList.methodToInvoke = "HideScroll";
    //	this.m_screenModeBtn = this._landMiddleSystem.transform.FindChild("ModeManager/showMode").GetComponent<UIButton>();
    //	this.m_buttonSound.Add(this.m_screenModeBtn);
    //	this.m_modeTab = this._landMiddleSystem.transform.FindChild("Mode").GetComponent<UIPanelTab>();
    //	this.m_modeTab.AddInputDelegate(new EZInputDelegate(this.OnCallBackScreenMode));
    //	LandPlane.m_modeScrolList = this._landMiddleSystem.transform.FindChild("ModeManager/ModePanel/ModeScrollist").GetComponent<UIScrollList>();
    //	LandPlane.m_modeScrolList.scriptWithMethodToInvoke = Singleton<EZGUIManager>.GetInstance().GetGUI("LandPlane");
    //	LandPlane.m_modeScrolList.methodToInvokeOnSelect = "ScreenModeListSelect";
    //	this.m_modeList = this._landMiddleSystem.transform.FindChild("Item").GetComponent<UIListItem>();
    //	this.m_modeList.scriptWithMethodToInvoke = Singleton<EZGUIManager>.GetInstance().GetGUI("LandPlane");
    //	this.m_modeList.methodToInvoke = "HideScroll";
    //	this.m_qualitySlider = this._landMiddleSystem.transform.FindChild("Background").GetComponent<UISlider>();
    //	this.m_qualitySlider.AddInputDelegate(new EZInputDelegate(this.OnCallBackQualitySlider));
    //	this.m_backgroundVolumeToggle = this._landMiddleSystem.transform.FindChild("AudioOption").GetComponent<UIStateToggleBtn>();
    //	this.m_backgroundVolumeToggle.AddInputDelegate(new EZInputDelegate(this.OnCallBackBgSound));
    //	this.m_gameVolumeToggle = this._landMiddleSystem.transform.FindChild("SoundOption").GetComponent<UIStateToggleBtn>();
    //	this.m_gameVolumeToggle.AddInputDelegate(new EZInputDelegate(this.OnCallBackGameSound));
    //	this.m_dubTabToggle = this._landMiddleSystem.transform.FindChild("VoiceOption").GetComponent<UIStateToggleBtn>();
    //	this.m_dubTabToggle.AddInputDelegate(new EZInputDelegate(this.OnCallBackVoiceSound));
    //	this.m_backgroundVolumeSlider = this._landMiddleSystem.transform.FindChild("BackgroundSound").GetComponent<UISlider>();
    //	this.m_gameVolumeSlider = this._landMiddleSystem.transform.FindChild("Game").GetComponent<UISlider>();
    //	this.m_dubVolumeSlider = this._landMiddleSystem.transform.FindChild("Voice").GetComponent<UISlider>();
    //	this.m_backgroundVolumeSlider.AddInputDelegate(new EZInputDelegate(this.OnCallBackBJSlider));
    //	this.m_gameVolumeSlider.AddInputDelegate(new EZInputDelegate(this.OnCallBackGameSlider));
    //	this.m_dubVolumeSlider.AddInputDelegate(new EZInputDelegate(this.OnCallBackAudioSlider));
    //	this.m_resTab.panel.Dismiss();
    //	this.m_modeTab.panel.Dismiss();
    //}

    //public void AddData()
    //{
    //	if (this._buttonList.Count <= 0)
    //	{
    //		this._buttonList.Add(0, this._lLanding);
    //		this._buttonList.Add(4, this._lQuit);
    //		this._buttonList.Add(1, this._lContiune);
    //		this._buttonList.Add(3, this._lPlayer);
    //		this._buttonList.Add(2, this._lSystem);
    //	}
    //	if (this._goList.Count <= 0)
    //	{
    //		this._goList.Add(0, this._landMiddleBegin);
    //		this._goList.Add(1, this._landMiddleContiune);
    //		this._goList.Add(3, this._landMiddlePlayer);
    //		this._goList.Add(4, this._landMiddleQuit);
    //		this._goList.Add(2, this._landMiddleSystem);
    //	}
    //	foreach (int key in this._buttonList.Keys)
    //	{
    //		UIButton uibutton;
    //		if (this._buttonList.TryGetValue(key, out uibutton))
    //		{
    //			EventEZMsg @object = base.RegisterChildEZMsg(GUI_TYPE.UICMD_NONE, key.ToString());
    //			uibutton.AddInputDelegate(new EZInputDelegate(@object.OnCallBackMethod));
    //		}
    //	}
    //	EventEZMsg object2 = base.RegisterChildEZMsg(GUI_TYPE.UICMD_NONE, "8");
    //	this._buttonReturn.AddInputDelegate(new EZInputDelegate(object2.OnCallBackMethod));
    //	EventEZMsg object3 = base.RegisterChildEZMsg(GUI_TYPE.UICMD_NONE, "6");
    //	this._buttonNo.AddInputDelegate(new EZInputDelegate(object3.OnCallBackMethod));
    //	EventEZMsg object4 = base.RegisterChildEZMsg(GUI_TYPE.UICMD_NONE, "5");
    //	this._buttonYes.AddInputDelegate(new EZInputDelegate(object4.OnCallBackMethod));
    //	EventEZMsg object5 = base.RegisterChildEZMsg(GUI_TYPE.UICMD_NONE, "7");
    //	this._buttonFixOn.AddInputDelegate(new EZInputDelegate(object5.OnCallBackMethod));
    //}

    //// Token: 0x06000AE5 RID: 2789 RVA: 0x0004AFCC File Offset: 0x000491CC
    //private void AddLoadData()
    //{
    //	foreach (SystemTag systemTag in this.m_prefabList.Keys)
    //	{
    //		GameObject gameObject;
    //		SaveInfo saveInfo;
    //		if (this.m_prefabList.TryGetValue(systemTag, out gameObject) && this.m_saveInfo.TryGetValue(systemTag, out saveInfo) && saveInfo != SDManager.GetSaveInfo(SaveLoadManager.SystemtagToSL(systemTag)))
    //		{
    //			this.m_saveInfo[systemTag] = SDManager.GetSaveInfo(SaveLoadManager.SystemtagToSL(systemTag));
    //			if (this.m_saveInfo[systemTag] != null)
    //			{
    //				Transform transform = gameObject.transform.FindChild("MapName");
    //				if (transform != null)
    //				{
    //					SpriteText component = transform.GetComponent<SpriteText>();
    //					if (component != null)
    //					{
    //						component.Text = this.m_saveInfo[systemTag].MapName;
    //					}
    //				}
    //				Transform transform2 = gameObject.transform.FindChild("Time");
    //				if (transform2 != null)
    //				{
    //					SpriteText component2 = transform2.GetComponent<SpriteText>();
    //					if (component2 != null)
    //					{
    //					}
    //				}
    //				Transform transform3 = gameObject.transform.FindChild("Ico");
    //				if (transform3 != null)
    //				{
    //					MeshRenderer component3 = transform3.GetComponent<MeshRenderer>();
    //					if (component3 != null)
    //					{
    //						component3.material.mainTexture = SDManager.GetSaveInfo(SaveLoadManager.SystemtagToSL(systemTag)).Capture;
    //					}
    //				}
    //				Transform transform4 = gameObject.transform.FindChild("Date");
    //				if (transform4 != null)
    //				{
    //					SpriteText component4 = transform4.GetComponent<SpriteText>();
    //					if (component4 != null)
    //					{
    //						component4.Text = this.m_saveInfo[systemTag].SaveTime;
    //					}
    //				}
    //			}
    //		}
    //	}
    //}

    //// Token: 0x06000AE6 RID: 2790 RVA: 0x0004B1B0 File Offset: 0x000493B0
    //public void SetSound(int id)
    //{
    //	GameData.Instance.soundTable.initialize();
    //	this._audioClick = EZGUIManager.CreatAudio(id);
    //	foreach (UIButton uibutton in this._buttonList.Values)
    //	{
    //		uibutton.soundOnClick = this._audioClick;
    //	}
    //}

    //// Token: 0x06000AE7 RID: 2791 RVA: 0x0004B23C File Offset: 0x0004943C
    //public void AdjustPosition()
    //{
    //	this._lLanding.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_RIGHT, this._lLanding.width, this._lLanding.height);
    //	this._lLanding.transform.position = new Vector3(this._lLanding.transform.position.x, this._lLanding.transform.position.y - this._lLanding.height / 2f, this._lLanding.transform.position.z - 0.2f);
    //	this._lContiune.transform.position = new Vector3(this._lLanding.transform.position.x, this._lLanding.transform.position.y - this._lLanding.height - this._lLanding.height / 3f, this._lLanding.transform.position.z - 0.2f);
    //	this._lSystem.transform.position = new Vector3(this._lLanding.transform.position.x, this._lContiune.transform.position.y - this._lContiune.height - this._lContiune.height / 3f, this._lLanding.transform.position.z - 0.2f);
    //	this._lPlayer.transform.position = new Vector3(this._lLanding.transform.position.x, this._lSystem.transform.position.y - this._lLanding.height - this._lSystem.height / 3f, this._lLanding.transform.position.z - 0.2f);
    //	this._lQuit.transform.position = new Vector3(this._lLanding.transform.position.x, this._lPlayer.transform.position.y - this._lPlayer.height - this._lPlayer.height / 3f, this._lLanding.transform.position.z - 0.2f);
    //	this._landMiddleBegin.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //	this._landMiddleBegin.transform.position = new Vector3(this._landMiddleBegin.transform.position.x - 1f, this._landMiddleBegin.transform.position.y, this._landMiddleBegin.transform.position.z);
    //	this._landMiddleContiune.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //	this._landMiddleContiune.transform.position = new Vector3(this._landMiddleContiune.transform.position.x - 2f, this._landMiddleContiune.transform.position.y, this._landMiddleContiune.transform.position.z);
    //	this._landMiddlePlayer.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //	this._landMiddlePlayer.transform.position = new Vector3(this._landMiddlePlayer.transform.position.x - 2.5f, this._landMiddlePlayer.transform.position.y, this._landMiddlePlayer.transform.position.z);
    //	this._landMiddleQuit.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //	this._landMiddleQuit.transform.position = new Vector3(this._landMiddleQuit.transform.position.x - 1f, this._landMiddleQuit.transform.position.y, this._landMiddleQuit.transform.position.z);
    //	this._landMiddleSystem.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //	this._landMiddleSystem.transform.position = new Vector3(this._landMiddleSystem.transform.position.x - 1f, this._landMiddleSystem.transform.position.y, this._landMiddleSystem.transform.position.z);
    //}

    //// Token: 0x06000AE8 RID: 2792 RVA: 0x0004B7A4 File Offset: 0x000499A4
    //public void AdjustPositionEx()
    //{
    //	this._lLanding.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_RIGHT, this._lLanding.width, this._lLanding.height);
    //	this._lLanding.transform.position = new Vector3(this._lLanding.transform.position.x, this._lLanding.transform.position.y - this._lLanding.height / 2f, this._lLanding.transform.position.z - 2f);
    //	this._lContiune.transform.position = new Vector3(this._lLanding.transform.position.x, this._lLanding.transform.position.y - this._lLanding.height - this._lLanding.height / 3f, this._lLanding.transform.position.z);
    //	this._lSystem.transform.position = new Vector3(this._lLanding.transform.position.x, this._lContiune.transform.position.y - this._lContiune.height - this._lContiune.height / 3f, this._lLanding.transform.position.z);
    //	this._lPlayer.transform.position = new Vector3(this._lLanding.transform.position.x, this._lSystem.transform.position.y - this._lLanding.height - this._lSystem.height / 3f, this._lLanding.transform.position.z);
    //	this._lQuit.transform.position = new Vector3(this._lLanding.transform.position.x, this._lPlayer.transform.position.y - this._lPlayer.height - this._lPlayer.height / 3f, this._lLanding.transform.position.z);
    //	this._lLanding.transform.FindChild("bk").position = new Vector3(this._lLanding.transform.position.x + this._lLanding.width / 2f, this._lLanding.transform.position.y + 6f, this._lLanding.transform.position.z + 3f);
    //}

    //// Token: 0x06000AE9 RID: 2793 RVA: 0x0004BAD4 File Offset: 0x00049CD4
    //public IEnumerator ResolutionList()
    //{
    //	yield return new WaitForFixedUpdate();
    //	this.AdjustPosition();
    //	yield break;
    //}

    //// Token: 0x06000AEA RID: 2794 RVA: 0x0004BAF0 File Offset: 0x00049CF0
    //public IEnumerator ResolutionListEx()
    //{
    //	yield return new WaitForFixedUpdate();
    //	this.AdjustPositionEx();
    //	yield break;
    //}

    //// Token: 0x06000AEB RID: 2795 RVA: 0x0004BB0C File Offset: 0x00049D0C
    //public IEnumerator UpSize()
    //{
    //	yield return new WaitForFixedUpdate();
    //	this.UpdateSize();
    //	base.StartCoroutine(this.ResolutionListEx());
    //	yield break;
    //}

    //// Token: 0x06000AEC RID: 2796 RVA: 0x0004BB28 File Offset: 0x00049D28
    //public IEnumerator PosForButton(int index)
    //{
    //	yield return new WaitForFixedUpdate();
    //	this.AdjustForButton(index);
    //	yield break;
    //}

    //// Token: 0x06000AED RID: 2797 RVA: 0x0004BB54 File Offset: 0x00049D54
    //public void AdjustForButton(int index)
    //{
    //	switch (index)
    //	{
    //	case 0:
    //		this._buttonFixOn.transform.position = new Vector3(this._landMiddleBegin.transform.position.x - this._landMiddleBegin.width / 2f + this._buttonFixOn.width, this._landMiddleBegin.transform.position.y - this._landMiddleBegin.height / 2f + this._buttonFixOn.height + 1f, 0.5f);
    //		this._buttonReturn.transform.position = new Vector3(this._landMiddleBegin.transform.position.x + this._landMiddleBegin.width / 2f - this._buttonReturn.width, this._landMiddleBegin.transform.position.y - this._landMiddleBegin.height / 2f + this._buttonReturn.height + 1f, 0.5f);
    //		this._tText.transform.position = new Vector3(-1f, 122.8469f, 0.5f);
    //		this._tText.maxWidth = this._landMiddleBegin.width - 3f;
    //		this._tText.Text = "本游戏主要采用自动存档与手动存档的方式，在游戏过程中可以随时对存档进行覆盖和读取。";
    //		break;
    //	case 1:
    //		this._buttonFixOn.transform.position = new Vector3(this._landMiddleContiune.transform.position.x - this._landMiddleContiune.width / 2f + this._buttonFixOn.width, this._landMiddleContiune.transform.position.y - this._landMiddleContiune.height / 2f + this._buttonFixOn.height + 1f, 0.5f);
    //		this._buttonReturn.transform.position = new Vector3(this._landMiddleContiune.transform.position.x + this._landMiddleContiune.width / 2f - this._buttonReturn.width, this._landMiddleContiune.transform.position.y - this._landMiddleContiune.height / 2f + this._buttonReturn.height + 1f, 0.5f);
    //		break;
    //	case 2:
    //		this._buttonFixOn.transform.position = new Vector3(this._landMiddleSystem.transform.position.x - this._landMiddleSystem.width / 2f + this._buttonFixOn.width, this._landMiddleSystem.transform.position.y - this._landMiddleSystem.height / 2f + this._buttonFixOn.height + 1f, 0.5f);
    //		this._buttonReturn.transform.position = new Vector3(this._landMiddleSystem.transform.position.x + this._landMiddleSystem.width / 2f - this._buttonReturn.width, this._landMiddleSystem.transform.position.y - this._landMiddleSystem.height / 2f + this._buttonReturn.height + 1f, 0.5f);
    //		break;
    //	case 3:
    //		this._buttonReturn.transform.position = new Vector3(this._landMiddlePlayer.transform.position.x, this._landMiddlePlayer.transform.position.y - this._landMiddlePlayer.height / 2f + this._buttonReturn.height + 1f, 0.5f);
    //		break;
    //	case 4:
    //		this._buttonYes.transform.position = new Vector3(this._landMiddleQuit.transform.position.x - this._landMiddleQuit.width / 2f + this._buttonYes.width - 1.3f + 0.5f, this._landMiddleQuit.transform.position.y - 0.8f - this._landMiddleQuit.height / 2f + this._buttonYes.height + 1.1f, 0.5f);
    //		this._buttonNo.transform.position = new Vector3(this._landMiddleQuit.transform.position.x + this._landMiddleQuit.width / 2f - this._buttonNo.width + 1.3f - 0.5f, this._landMiddleQuit.transform.position.y - 0.8f - this._landMiddleQuit.height / 2f + this._buttonNo.height + 1.1f, 0.5f);
    //		this._tText.transform.position = new Vector3(-1f, 122.8469f, 0.5f);
    //		this._tText.maxWidth = this._landMiddleQuit.width - 3f;
    //		this._tText.Text = "确定退出游戏吗？";
    //		break;
    //	}
    //}

    //// Token: 0x06000AEE RID: 2798 RVA: 0x0004C13C File Offset: 0x0004A33C
    //public void ButtonState(int i)
    //{
    //	switch (i)
    //	{
    //	case 0:
    //		this._buttonFixOn.gameObject.active = true;
    //		this._buttonReturn.gameObject.active = true;
    //		this._tText.gameObject.active = true;
    //		this._tText.Text = string.Empty;
    //		if (Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>() != null)
    //		{
    //			Texture2D mainTexture = ResourceLoader.Load("GameLegend/Icon/Item/lock", typeof(Texture2D)) as Texture2D;
    //			Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cPlayerPanel.transform.FindChild("Player/Back/head").GetComponent<MeshRenderer>().material.mainTexture = mainTexture;
    //			Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_2.material.mainTexture = mainTexture;
    //			Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_3.material.mainTexture = mainTexture;
    //			Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_4.material.mainTexture = mainTexture;
    //		}
    //		break;
    //	case 1:
    //		this._buttonFixOn.gameObject.active = true;
    //		this._buttonReturn.gameObject.active = true;
    //		break;
    //	case 2:
    //		this._buttonFixOn.gameObject.active = true;
    //		this._buttonReturn.gameObject.active = true;
    //		break;
    //	case 3:
    //		this._buttonReturn.gameObject.active = true;
    //		break;
    //	case 4:
    //		this._buttonYes.gameObject.active = true;
    //		this._buttonNo.gameObject.active = true;
    //		this._tText.gameObject.active = true;
    //		this._tText.Text = string.Empty;
    //		break;
    //	}
    //}

    //public void UpdateSize()
    //{
    //	this._lLanding.CalcPixelToUV();
    //	this._lLanding.SetCamera();
    //	this._lContiune.CalcPixelToUV();
    //	this._lContiune.SetCamera();
    //	this._lSystem.CalcPixelToUV();
    //	this._lSystem.SetCamera();
    //	this._lPlayer.CalcPixelToUV();
    //	this._lPlayer.SetCamera();
    //	this._lQuit.CalcPixelToUV();
    //	this._lQuit.SetCamera();
    //	this._buttonYes.CalcPixelToUV();
    //	this._buttonYes.SetCamera();
    //	this._buttonNo.CalcPixelToUV();
    //	this._buttonNo.SetCamera();
    //	this._buttonReturn.CalcPixelToUV();
    //	this._buttonReturn.SetCamera();
    //	this._buttonFixOn.CalcPixelToUV();
    //	this._buttonFixOn.SetCamera();
    //	if (Singleton<EZGUIManager>.GetInstance().GetGUI("SystemPlane") != null)
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<SystemPlane>().ResetText(this._landPlane.transform, 26);
    //	}
    //}

    //// Token: 0x06000AF0 RID: 2800 RVA: 0x0004C418 File Offset: 0x0004A618
    //public override int OnChildEZMessage(GUI_TYPE type, string key, POINTER_INFO ptCmd)
    //{
    //	if (key == null || ptCmd.targetObj == null)
    //	{
    //		return 0;
    //	}
    //	POINTER_INFO.INPUT_EVENT evt = ptCmd.evt;
    //	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
    //	{
    //		int num = int.Parse(key);
    //		if (num < 10)
    //		{
    //			if (this.m_resTab != null && this.m_resTab.active && this.m_resTab.panelIsShowing)
    //			{
    //				this.m_resTab.panelIsShowing = false;
    //				this.m_resTab.DoPanelStuff();
    //			}
    //			if (this.m_modeTab != null && this.m_modeTab.active && this.m_modeTab.panelIsShowing)
    //			{
    //				this.m_modeTab.panelIsShowing = false;
    //				this.m_modeTab.DoPanelStuff();
    //			}
    //			if (LandPlane.m_bAddInput)
    //			{
    //				this.PushData();
    //				LandPlane.m_bAddInput = false;
    //			}
    //			this.OnCallSelect(ptCmd, key);
    //			foreach (int key2 in this._buttonList.Keys)
    //			{
    //				UIButton uibutton;
    //				if (this._buttonList.TryGetValue(key2, out uibutton))
    //				{
    //					if (key2.ToString() == key)
    //					{
    //						uibutton.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
    //						uibutton.controlIsEnabled = false;
    //						EZGUIManager.SetSoundEx(5022, EZGUIManager._aButtonTwoClick);
    //					}
    //					else
    //					{
    //						uibutton.controlIsEnabled = true;
    //						uibutton.SetControlState(UIButton.CONTROL_STATE.NORMAL);
    //					}
    //				}
    //			}
    //		}
    //		else
    //		{
    //			if (this.fLastKey != key)
    //			{
    //				this._bDL = false;
    //			}
    //			SystemTag key3 = (SystemTag)num;
    //			foreach (SystemTag key4 in this.m_buttonList.Keys)
    //			{
    //				UIButton uibutton2;
    //				if (this.m_buttonList.TryGetValue(key4, out uibutton2))
    //				{
    //					uibutton2.transform.GetComponent<UIButton>().controlIsEnabled = true;
    //					uibutton2.transform.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
    //				}
    //			}
    //			UIButton uibutton3;
    //			if (this.m_buttonList.TryGetValue(key3, out uibutton3))
    //			{
    //				uibutton3.soundOnClick = this.m_click;
    //				if (this.m_click != null)
    //				{
    //					this.m_click.PlayOneShot(this.m_click.clip);
    //				}
    //				uibutton3.transform.GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
    //				uibutton3.transform.GetComponent<UIButton>().controlIsEnabled = false;
    //			}
    //			this._bDL = true;
    //			this.OnCallSelectEx(ptCmd, key, false);
    //			this._str = key;
    //			this._ptCmd = ptCmd;
    //			this.fLastKey = key;
    //			this.fLastTimer = Time.fixedTime;
    //		}
    //	}
    //	return base.OnChildEZMessage(type, key, ptCmd);
    //}

    //// Token: 0x06000AF2 RID: 2802 RVA: 0x0004C7E0 File Offset: 0x0004A9E0
    //private bool LoadDate(POINTER_INFO pt)
    //{
    //	if (pt.targetObj == null || pt.targetObj.Data == null)
    //	{
    //		return false;
    //	}
    //	SaveInfo saveInfo = pt.targetObj.Data as SaveInfo;
    //	if (saveInfo != null)
    //	{
    //		this.Hide();
    //		return SaveLoadManager.Load(saveInfo.ShowIndex);
    //	}
    //	return false;
    //}

    //// Token: 0x06000AF3 RID: 2803 RVA: 0x0004C838 File Offset: 0x0004AA38
    //public void SelectPlane(int key)
    //{
    //	this._buttonNo.transform.position = new Vector3(-100000f, -10000f, -90000f);
    //	this._buttonReturn.transform.position = new Vector3(-100000f, -10000f, -90000f);
    //	this._buttonFixOn.transform.position = new Vector3(-100000f, -10000f, -90000f);
    //	this._buttonYes.transform.position = new Vector3(-100000f, -10000f, -90000f);
    //	this._tText.transform.position = new Vector3(-100000f, -10000f, -90000f);
    //	foreach (int key2 in this._goList.Keys)
    //	{
    //		this._goList[key2].transform.position = new Vector3(-100000f, -10000f, -9000000f);
    //	}
    //}

    //// Token: 0x06000AF4 RID: 2804 RVA: 0x0004C97C File Offset: 0x0004AB7C
    //public void OnCallSelect(POINTER_INFO pt, string key)
    //{
    //	if (key == null)
    //	{
    //		return;
    //	}
    //	switch (key)
    //	{
    //	case "0":
    //		this.SelectPlane(0);
    //		this.ButtonState(0);
    //		this._landMiddleBegin.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //		this._landMiddleBegin.transform.position = new Vector3(this._landMiddleBegin.transform.position.x - 1f, this._landMiddleBegin.transform.position.y, this._landMiddleBegin.transform.position.z);
    //		this.AdjustForButton(0);
    //		if (this._landMiddleSystem.active)
    //		{
    //			this.m_resTab.panel.Dismiss();
    //			this.m_resTab.panelIsShowing = false;
    //			this.m_modeTab.panel.Dismiss();
    //			this.m_modeTab.panelIsShowing = false;
    //		}
    //		LandPlane.m_bDoShow = true;
    //		break;
    //	case "1":
    //		this.SelectPlane(1);
    //		this.ButtonState(1);
    //		this._landMiddleContiune.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //		this._landMiddleContiune.transform.position = new Vector3(this._landMiddleContiune.transform.position.x - 1f, this._landMiddleContiune.transform.position.y, this._landMiddleContiune.transform.position.z);
    //		this.AdjustForButton(1);
    //		this.AddLoadData();
    //		if (this._landMiddleSystem.active)
    //		{
    //			this.m_resTab.panel.Dismiss();
    //			this.m_resTab.panelIsShowing = false;
    //			this.m_modeTab.panel.Dismiss();
    //			this.m_modeTab.panelIsShowing = false;
    //		}
    //		LandPlane.m_bDoShow = true;
    //		break;
    //	case "2":
    //	{
    //		this._landMiddleSystem.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //		this._landMiddleSystem.transform.position = new Vector3(this._landMiddleSystem.transform.position.x - 1f, this._landMiddleSystem.transform.position.y, this._landMiddleSystem.transform.position.z);
    //		SystemSetting.initialize();
    //		this._uiCam = GameObject.FindWithTag("UICam").GetComponent<Camera>();
    //		this.SelectPlane(2);
    //		this.ButtonState(2);
    //		this._landMiddleSystem.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //		this._landMiddleSystem.transform.position = new Vector3(this._landMiddleSystem.transform.position.x - 1f, this._landMiddleSystem.transform.position.y, this._landMiddleSystem.transform.position.z);
    //		this.AdjustForButton(2);
    //		for (int i = 0; i < Screen.resolutions.Length; i++)
    //		{
    //			if (Screen.resolutions[i].width >= 1024 && !LandPlane.m_resolutions.Contains(Screen.resolutions[i]))
    //			{
    //				LandPlane.m_resolutions.Add(Screen.resolutions[i]);
    //			}
    //		}
    //		if (LandPlane.m_resolutions.Count != 0)
    //		{
    //			this.m_resolutionsBtn.Text = SystemSetting.resolutionIndex;
    //			this.m_iResolution = SystemSetting.resolutionIndex;
    //		}
    //		this.m_iQuality = SystemSetting.quality;
    //		if (this.m_iQuality == 0)
    //		{
    //			this.m_qualitySlider.UpdateAppearance(0f);
    //			this.m_qualitySlider.knob.SetPosition(0f);
    //		}
    //		if (this.m_iQuality == 1)
    //		{
    //			this.m_qualitySlider.UpdateAppearance(0.25f);
    //			this.m_qualitySlider.knob.SetPosition(0.25f);
    //		}
    //		if (this.m_iQuality == 2)
    //		{
    //			this.m_qualitySlider.UpdateAppearance(0.5f);
    //			this.m_qualitySlider.knob.SetPosition(0.5f);
    //		}
    //		if (this.m_iQuality == 3)
    //		{
    //			this.m_qualitySlider.UpdateAppearance(0.75f);
    //			this.m_qualitySlider.knob.SetPosition(0.75f);
    //		}
    //		if (this.m_iQuality == 4)
    //		{
    //			this.m_qualitySlider.UpdateAppearance(1f);
    //			this.m_qualitySlider.knob.SetPosition(1f);
    //		}
    //		int fullScreen = SystemSetting.fullScreen;
    //		bool flag = fullScreen == 1;
    //		if (flag)
    //		{
    //			this.m_screenMode = "全屏";
    //		}
    //		else
    //		{
    //			this.m_screenMode = "窗口";
    //		}
    //		this.m_iMode = fullScreen;
    //		this.m_screenModeBtn.Text = this.m_screenMode;
    //		this.m_backgroundVolumeSlider.m_value = SystemSetting.bgSoundValue;
    //		this.m_gameVolumeSlider.m_value = SystemSetting.gameSoundValue;
    //		this.m_dubVolumeSlider.m_value = SystemSetting.dubSoundValue;
    //		this.m_bBackgroundVolume = SystemSetting.bgSoundMute;
    //		if (this.m_bBackgroundVolume)
    //		{
    //			this.m_backgroundVolumeToggle.curStateIndex = 0;
    //			this.m_backgroundVolumeToggle.SetToggleState(0);
    //		}
    //		else
    //		{
    //			this.m_backgroundVolumeToggle.curStateIndex = 1;
    //			this.m_backgroundVolumeToggle.SetToggleState(1);
    //		}
    //		this.m_bGameVolume = SystemSetting.gameSoundMute;
    //		if (this.m_bGameVolume)
    //		{
    //			this.m_gameVolumeToggle.curStateIndex = 0;
    //			this.m_gameVolumeToggle.SetToggleState(0);
    //		}
    //		else
    //		{
    //			this.m_gameVolumeToggle.curStateIndex = 1;
    //			this.m_gameVolumeToggle.SetToggleState(1);
    //		}
    //		this.m_bDubVolume = SystemSetting.dubSoundMute;
    //		if (this.m_bDubVolume)
    //		{
    //			this.m_dubTabToggle.curStateIndex = 0;
    //			this.m_dubTabToggle.SetToggleState(0);
    //		}
    //		else
    //		{
    //			this.m_dubTabToggle.curStateIndex = 1;
    //			this.m_dubTabToggle.SetToggleState(1);
    //		}
    //		this.SoundState(0);
    //		this.SoundState(1);
    //		this.SoundState(2);
    //		break;
    //	}
    //	case "3":
    //		this.SelectPlane(3);
    //		this.ButtonState(3);
    //		if (this._landMiddleSystem.active)
    //		{
    //			this.m_resTab.panel.Dismiss();
    //			this.m_resTab.panelIsShowing = false;
    //			this.m_modeTab.panel.Dismiss();
    //			this.m_modeTab.panelIsShowing = false;
    //		}
    //		UICamera.Instance.uiCamera.gameObject.SetActive(false);
    //		LandPlane.m_bAddInput = true;
    //		GameData.Instance.ScrMan.Exec(31, 11000);
    //		LandPlane.m_bDoShow = true;
    //		break;
    //	case "4":
    //		this.SelectPlane(4);
    //		this.ButtonState(4);
    //		this._landMiddleQuit.transform.position = base.Position(GUI_LAYER.UILAYER_LAND, GUI_POS.UIPOS_MIDDLE, 0f, 0f);
    //		this._landMiddleQuit.transform.position = new Vector3(this._landMiddleQuit.transform.position.x - 1f, this._landMiddleQuit.transform.position.y, this._landMiddleQuit.transform.position.z);
    //		this.AdjustForButton(4);
    //		if (this._landMiddleSystem.active)
    //		{
    //			this.m_resTab.panel.Dismiss();
    //			this.m_resTab.panelIsShowing = false;
    //			this.m_modeTab.panel.Dismiss();
    //			this.m_modeTab.panelIsShowing = false;
    //		}
    //		LandPlane.m_bDoShow = true;
    //		break;
    //	case "5":
    //		this._landMiddlePlane.SetActive(false);
    //		EZGUIManager.SetSoundEx(5019, EZGUIManager._aButtoFiveClick);
    //		Main.KillQuit();
    //		break;
    //	case "6":
    //		this.DisButton();
    //		EZGUIManager.SetSoundEx(5019, EZGUIManager._aButtoFiveClick);
    //		break;
    //	case "7":
    //		if (this._landMiddleBegin.transform.position.z > -10f)
    //		{
    //			SingletonMono<AudioManager>.GetInstance().StopAllSound();
    //			SceneManager.LoadLevel(0, false, false);
    //			this._landPlane.SetActiveRecursively(false);
    //		}
    //		if (this._landMiddleContiune.transform.position.z > -10f)
    //		{
    //			if (this.LoadDate(this.m_loadPtEv))
    //			{
    //				this._landPlane.SetActiveRecursively(false);
    //			}
    //			else
    //			{
    //				this.DisButton();
    //			}
    //		}
    //		if (this._landMiddleSystem.gameObject.active && this._landMiddleSystem.transform.position.z > -10f)
    //		{
    //			this.HideScroll();
    //			SystemSetting.SetResolution(this.m_iResolution);
    //			SystemSetting.SetFullScreen(this.m_iMode);
    //			SystemSetting.QualitySetting(this.m_iQuality);
    //			SystemSetting.SetTerrainLevel(this.m_iQuality);
    //			SystemSetting.SetViewDistance(this.m_iQuality);
    //			SystemSetting.SetWaterLevel(this.m_iQuality);
    //			SystemSetting.SetShadowResolution(this.m_iQuality);
    //			SystemSetting.SetTextureQuality(this.m_iQuality);
    //			base.StartCoroutine(this.UpSize());
    //			SystemSetting.SaveSystemSetting();
    //			this.DisButton();
    //		}
    //		EZGUIManager.SetSoundEx(5019, EZGUIManager._aButtoFiveClick);
    //		break;
    //	case "8":
    //		this.DisButton();
    //		EZGUIManager.SetSoundEx(5019, EZGUIManager._aButtoFiveClick);
    //		break;
    //	}
    //	if (this._audioClick != null && this._audioClick.clip != null)
    //	{
    //		this._audioClick.PlayOneShot(this._audioClick.clip);
    //	}
    //}

    //// Token: 0x06000AF6 RID: 2806 RVA: 0x0004D57C File Offset: 0x0004B77C
    //public void SoundState(int type)
    //{
    //	if (type == 0)
    //	{
    //		if (this.m_bBackgroundVolume)
    //		{
    //			this.m_backgroundVolumeSlider.UpdateAppearance(0f);
    //			this.m_backgroundVolumeSlider.knob.SetPosition(0f);
    //			this.m_backgroundVolumeSlider.transform.FindChild("BackgroundSound - Knob").GetComponent<BoxCollider>().size = Vector3.zero;
    //		}
    //		else
    //		{
    //			this.m_backgroundVolumeSlider.transform.FindChild("BackgroundSound - Knob").GetComponent<BoxCollider>().size = new Vector3(30f, this.m_backgroundVolumeSlider.knobSize.y, 0f);
    //			this.m_backgroundVolumeSlider.UpdateAppearance(SystemSetting.bgSoundValue);
    //			this.m_backgroundVolumeSlider.knob.SetPosition(SystemSetting.bgSoundValue);
    //		}
    //	}
    //	else if (type == 1)
    //	{
    //		if (this.m_bGameVolume)
    //		{
    //			this.m_gameVolumeSlider.UpdateAppearance(0f);
    //			this.m_gameVolumeSlider.knob.SetPosition(0f);
    //			this.m_gameVolumeSlider.transform.FindChild("Game - Knob").GetComponent<BoxCollider>().size = Vector3.zero;
    //		}
    //		else
    //		{
    //			this.m_gameVolumeSlider.transform.FindChild("Game - Knob").GetComponent<BoxCollider>().size = new Vector3(30f, this.m_gameVolumeSlider.knobSize.y, 0f);
    //			this.m_gameVolumeSlider.UpdateAppearance(SystemSetting.gameSoundValue);
    //			this.m_gameVolumeSlider.knob.SetPosition(SystemSetting.gameSoundValue);
    //		}
    //	}
    //	else if (type == 2)
    //	{
    //		if (this.m_bDubVolume)
    //		{
    //			this.m_dubVolumeSlider.UpdateAppearance(0f);
    //			this.m_dubVolumeSlider.knob.SetPosition(0f);
    //			this.m_dubVolumeSlider.transform.FindChild("Voice - Knob").GetComponent<BoxCollider>().size = Vector3.zero;
    //		}
    //		else
    //		{
    //			this.m_dubVolumeSlider.transform.FindChild("Voice - Knob").GetComponent<BoxCollider>().size = new Vector3(30f, this.m_dubVolumeSlider.knobSize.y, 0f);
    //			this.m_dubVolumeSlider.UpdateAppearance(SystemSetting.dubSoundValue);
    //			this.m_dubVolumeSlider.knob.SetPosition(SystemSetting.dubSoundValue);
    //		}
    //	}
    //}

    //// Token: 0x06000AF7 RID: 2807 RVA: 0x0004D7DC File Offset: 0x0004B9DC
    //public void ResolutionListSelect()
    //{
    //	this.m_resolution = LandPlane.m_resolutions[LandPlane.m_resScrolList.SelectedItem.Index];
    //	this.m_resolutionsBtn.Text = this.m_resolution.width.ToString() + "x" + this.m_resolution.height.ToString();
    //	this.m_iResolution = this.m_resolution.width.ToString() + "x" + this.m_resolution.height.ToString();
    //	this.HideScroll();
    //}

    //// Token: 0x06000AF8 RID: 2808 RVA: 0x0004D880 File Offset: 0x0004BA80
    //public void OnCallBackResolution(ref POINTER_INFO pt)
    //{
    //	POINTER_INFO.INPUT_EVENT evt = pt.evt;
    //	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
    //	{
    //		for (int i = 0; i < Screen.resolutions.Length; i++)
    //		{
    //			if (Screen.resolutions[i].width >= 1024 && !LandPlane.m_resolutions.Contains(Screen.resolutions[i]))
    //			{
    //				LandPlane.m_resolutions.Add(Screen.resolutions[i]);
    //			}
    //		}
    //		this.ClearList();
    //		GameObject gameObject = this._landMiddleSystem.transform.Find("Item").gameObject;
    //		LandPlane.m_resScrolList.repositionOnEnable = false;
    //		LandPlane.m_resScrolList.sceneItems = new GameObject[LandPlane.m_resolutions.Count];
    //		for (int j = 0; j < LandPlane.m_resolutions.Count; j++)
    //		{
    //			Resolution resolution = LandPlane.m_resolutions[j];
    //			LandPlane.m_resScrolList.CreateItem(gameObject, j, resolution.width.ToString() + "x" + resolution.height.ToString());
    //			LandPlane.m_resScrolList.sceneItems[j] = gameObject;
    //		}
    //		this.Tab(this.m_resTab);
    //	}
    //}

    //// Token: 0x06000AF9 RID: 2809 RVA: 0x0004D9D0 File Offset: 0x0004BBD0
    //public void OnCallBackScreenMode(ref POINTER_INFO pt)
    //{
    //	POINTER_INFO.INPUT_EVENT evt = pt.evt;
    //	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
    //	{
    //		this.ClearList();
    //		GameObject gameObject = this._landMiddleSystem.transform.FindChild("Item").gameObject;
    //		LandPlane.m_modeScrolList.repositionOnEnable = false;
    //		LandPlane.m_modeScrolList.sceneItems = new GameObject[this.m_strs.Length];
    //		for (int i = 0; i < this.m_strs.Length; i++)
    //		{
    //			LandPlane.m_modeScrolList.CreateItem(gameObject, this.m_strs[i]);
    //			LandPlane.m_modeScrolList.sceneItems[i] = gameObject;
    //		}
    //		this.Tab(this.m_modeTab);
    //	}
    //}

    //// Token: 0x06000AFA RID: 2810 RVA: 0x0004DA80 File Offset: 0x0004BC80
    //public void ScreenModeListSelect()
    //{
    //	this.m_screenMode = this.m_strs[LandPlane.m_modeScrolList.SelectedItem.Index];
    //	this.m_screenModeBtn.Text = this.m_screenMode;
    //	this.m_iMode = LandPlane.m_modeScrolList.SelectedItem.Index;
    //}

    //// Token: 0x06000AFB RID: 2811 RVA: 0x0004DAD0 File Offset: 0x0004BCD0
    //public void OnCallBackQualitySlider(ref POINTER_INFO pt)
    //{
    //	switch (pt.evt)
    //	{
    //	case POINTER_INFO.INPUT_EVENT.RELEASE:
    //		this.HideScroll();
    //		if (this._uiCam != null)
    //		{
    //			Vector3 pos = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.QualityPos(pos, this.m_qualitySlider.transform.position, this.m_qualitySlider.width);
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.TAP:
    //		this.HideScroll();
    //		if (this._uiCam != null)
    //		{
    //			this.m_qualitySlider.transform.FindChild("Background - Knob").GetComponent<BoxCollider>().size = new Vector3(30f, this.m_qualitySlider.knobSize.y, 0f);
    //			Vector3 pos2 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.QualityPos(pos2, this.m_qualitySlider.transform.position, this.m_qualitySlider.width);
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.RELEASE_OFF:
    //		this.HideScroll();
    //		if (this._uiCam != null)
    //		{
    //			Vector3 pos3 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.QualityPos(pos3, this.m_qualitySlider.transform.position, this.m_qualitySlider.width);
    //		}
    //		break;
    //	}
    //}

    //// Token: 0x06000AFC RID: 2812 RVA: 0x0004DC54 File Offset: 0x0004BE54
    //public void QualityPos(Vector3 pos, Vector3 transPos, float x)
    //{
    //	if (pos.x <= transPos.x + x / 2f && pos.x > transPos.x + x / 8f * 3f)
    //	{
    //		this.m_qualitySlider.UpdateAppearance(1f);
    //		this.m_qualitySlider.knob.SetPosition(1f);
    //		this.m_iQuality = 4;
    //		return;
    //	}
    //	if (pos.x <= transPos.x + x / 2f - x / 8f * 1f && pos.x > transPos.x + x / 8f * 1f)
    //	{
    //		this.m_qualitySlider.UpdateAppearance(0.75f);
    //		this.m_qualitySlider.knob.SetPosition(0.75f);
    //		this.m_iQuality = 3;
    //		return;
    //	}
    //	if (pos.x <= transPos.x + x / 2f - x / 8f * 3f && pos.x > transPos.x + x / 8f * -1f)
    //	{
    //		this.m_qualitySlider.UpdateAppearance(0.5f);
    //		this.m_qualitySlider.knob.SetPosition(0.5f);
    //		this.m_iQuality = 2;
    //		return;
    //	}
    //	if (pos.x <= transPos.x - x / 2f + x / 8f * 3f && pos.x > transPos.x - x / 2f + x / 8f * 1f)
    //	{
    //		this.m_qualitySlider.UpdateAppearance(0.25f);
    //		this.m_qualitySlider.knob.SetPosition(0.25f);
    //		this.m_iQuality = 1;
    //		return;
    //	}
    //	if (pos.x >= transPos.x - x / 2f && pos.x < transPos.x - x / 2f + x / 8f * 1f)
    //	{
    //		this.m_qualitySlider.UpdateAppearance(0f);
    //		this.m_qualitySlider.knob.SetPosition(0f);
    //		this.m_iQuality = 0;
    //		return;
    //	}
    //	if (pos.x < transPos.x - x / 2f + x / 8f * 1f)
    //	{
    //		this.m_qualitySlider.UpdateAppearance(0f);
    //		this.m_qualitySlider.knob.SetPosition(0f);
    //		this.m_iQuality = 0;
    //		return;
    //	}
    //	if (pos.x > transPos.x + x / 8f * 3f)
    //	{
    //		this.m_qualitySlider.UpdateAppearance(1f);
    //		this.m_qualitySlider.knob.SetPosition(1f);
    //		this.m_iQuality = 4;
    //		return;
    //	}
    //}

    //// Token: 0x06000AFD RID: 2813 RVA: 0x0004DF4C File Offset: 0x0004C14C
    //public void OnCallBackGameSound(ref POINTER_INFO pt)
    //{
    //	POINTER_INFO.INPUT_EVENT evt = pt.evt;
    //	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
    //	{
    //		this.m_bGameVolume = (this.m_gameVolumeToggle.curStateIndex == 1);
    //		SystemSetting.SetGameSoundMute(this.m_bGameVolume);
    //		this.SoundState(1);
    //		LandPlane.m_bDoChange = true;
    //	}
    //}

    //// Token: 0x06000AFE RID: 2814 RVA: 0x0004DFA8 File Offset: 0x0004C1A8
    //public void OnCallBackBgSound(ref POINTER_INFO pt)
    //{
    //	POINTER_INFO.INPUT_EVENT evt = pt.evt;
    //	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
    //	{
    //		this.m_bBackgroundVolume = (this.m_backgroundVolumeToggle.curStateIndex == 1);
    //		SystemSetting.SetBgSoundMute(this.m_bBackgroundVolume);
    //		this.SoundState(0);
    //		LandPlane.m_bDoChange = true;
    //	}
    //}

    //// Token: 0x06000AFF RID: 2815 RVA: 0x0004E004 File Offset: 0x0004C204
    //public void OnCallBackVoiceSound(ref POINTER_INFO pt)
    //{
    //	POINTER_INFO.INPUT_EVENT evt = pt.evt;
    //	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
    //	{
    //		this.m_bDubVolume = (this.m_dubTabToggle.curStateIndex == 1);
    //		SystemSetting.SetDubSoundMute(this.m_bDubVolume);
    //		this.SoundState(2);
    //		LandPlane.m_bDoChange = true;
    //	}
    //}

    //// Token: 0x06000B00 RID: 2816 RVA: 0x0004E060 File Offset: 0x0004C260
    //public void OnCallBackBJSlider(ref POINTER_INFO pt)
    //{
    //	switch (pt.evt)
    //	{
    //	case POINTER_INFO.INPUT_EVENT.PRESS:
    //		if (this._uiCam != null && !this.m_bBackgroundVolume)
    //		{
    //			Vector3 pos = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos, this.m_backgroundVolumeSlider.transform.position, this.m_backgroundVolumeSlider.width, this.m_backgroundVolumeSlider, "背景");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.RELEASE:
    //		if (this._uiCam != null && !this.m_bBackgroundVolume)
    //		{
    //			Vector3 pos2 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos2, this.m_backgroundVolumeSlider.transform.position, this.m_backgroundVolumeSlider.width, this.m_backgroundVolumeSlider, "背景");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.TAP:
    //		if (this._uiCam != null && !this.m_bBackgroundVolume)
    //		{
    //			Vector3 pos3 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos3, this.m_backgroundVolumeSlider.transform.position, this.m_backgroundVolumeSlider.width, this.m_backgroundVolumeSlider, "背景");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.RELEASE_OFF:
    //		if (this._uiCam != null && !this.m_bBackgroundVolume)
    //		{
    //			Vector3 pos4 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos4, this.m_backgroundVolumeSlider.transform.position, this.m_backgroundVolumeSlider.width, this.m_backgroundVolumeSlider, "背景");
    //		}
    //		break;
    //	}
    //}

    //// Token: 0x06000B01 RID: 2817 RVA: 0x0004E244 File Offset: 0x0004C444
    //public void OnCallBackGameSlider(ref POINTER_INFO pt)
    //{
    //	switch (pt.evt)
    //	{
    //	case POINTER_INFO.INPUT_EVENT.PRESS:
    //		if (this._uiCam != null && !this.m_bGameVolume)
    //		{
    //			Vector3 pos = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos, this.m_gameVolumeSlider.transform.position, this.m_gameVolumeSlider.width, this.m_gameVolumeSlider, "游戏");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.RELEASE:
    //		if (this._uiCam != null && !this.m_bGameVolume)
    //		{
    //			Vector3 pos2 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos2, this.m_gameVolumeSlider.transform.position, this.m_gameVolumeSlider.width, this.m_gameVolumeSlider, "游戏");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.TAP:
    //		if (this._uiCam != null && !this.m_bGameVolume)
    //		{
    //			Vector3 pos3 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos3, this.m_gameVolumeSlider.transform.position, this.m_gameVolumeSlider.width, this.m_gameVolumeSlider, "游戏");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.RELEASE_OFF:
    //		if (this._uiCam != null && !this.m_bGameVolume)
    //		{
    //			Vector3 pos4 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos4, this.m_gameVolumeSlider.transform.position, this.m_gameVolumeSlider.width, this.m_gameVolumeSlider, "游戏");
    //		}
    //		break;
    //	}
    //}

    //// Token: 0x06000B02 RID: 2818 RVA: 0x0004E428 File Offset: 0x0004C628
    //public void OnCallBackAudioSlider(ref POINTER_INFO pt)
    //{
    //	switch (pt.evt)
    //	{
    //	case POINTER_INFO.INPUT_EVENT.PRESS:
    //		if (this._uiCam != null && !this.m_bDubVolume)
    //		{
    //			Vector3 pos = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos, this.m_dubVolumeSlider.transform.position, this.m_dubVolumeSlider.width, this.m_dubVolumeSlider, "配音");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.RELEASE:
    //		if (this._uiCam != null && !this.m_bDubVolume)
    //		{
    //			Vector3 pos2 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos2, this.m_dubVolumeSlider.transform.position, this.m_dubVolumeSlider.width, this.m_dubVolumeSlider, "配音");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.TAP:
    //		if (this._uiCam != null && !this.m_bDubVolume)
    //		{
    //			Vector3 pos3 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos3, this.m_dubVolumeSlider.transform.position, this.m_dubVolumeSlider.width, this.m_dubVolumeSlider, "配音");
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.RELEASE_OFF:
    //		if (this._uiCam != null && !this.m_bDubVolume)
    //		{
    //			Vector3 pos4 = this._uiCam.transform.InverseTransformPoint(pt.hitInfo.point);
    //			this.soundPos(pos4, this.m_dubVolumeSlider.transform.position, this.m_dubVolumeSlider.width, this.m_dubVolumeSlider, "配音");
    //		}
    //		break;
    //	}
    //}

    //public void soundPos(Vector3 pos, Vector3 transPos, float x, UISlider slider, string type)
    //{
    //	if (pos.x <= transPos.x + x / 2f && pos.x > transPos.x + x / 20f * 9f)
    //	{
    //		slider.UpdateAppearance(1f);
    //		slider.knob.SetPosition(1f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(1f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(1f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(1f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x + x / 2f - x / 20f * 1f && pos.x > transPos.x + x / 20f * 7f)
    //	{
    //		slider.UpdateAppearance(0.9f);
    //		slider.knob.SetPosition(0.9f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.9f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.9f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.9f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x + x / 2f - x / 20f * 3f && pos.x > transPos.x + x / 20f * 5f)
    //	{
    //		slider.UpdateAppearance(0.8f);
    //		slider.knob.SetPosition(0.8f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.8f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.8f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.8f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x + x / 2f - x / 20f * 5f && pos.x > transPos.x + x / 20f * 3f)
    //	{
    //		slider.UpdateAppearance(0.7f);
    //		slider.knob.SetPosition(0.7f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.7f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.7f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.7f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x + x / 2f - x / 20f * 3f && pos.x > transPos.x + x / 20f * 1f)
    //	{
    //		slider.UpdateAppearance(0.6f);
    //		slider.knob.SetPosition(0.6f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.6f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.6f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.6f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x + x / 20f * 1f && pos.x > transPos.x - x / 20f * 1f)
    //	{
    //		slider.UpdateAppearance(0.5f);
    //		slider.knob.SetPosition(0.5f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.5f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.5f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.5f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x - x / 20f * 1f && pos.x > transPos.x - x / 20f * 3f)
    //	{
    //		slider.UpdateAppearance(0.4f);
    //		slider.knob.SetPosition(0.4f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.4f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.4f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.4f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x - x / 20f * 3f && pos.x > transPos.x - x / 20f * 5f)
    //	{
    //		slider.UpdateAppearance(0.3f);
    //		slider.knob.SetPosition(0.3f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.3f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.3f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.3f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x - x / 20f * 5f && pos.x > transPos.x - x / 20f * 7f)
    //	{
    //		slider.UpdateAppearance(0.2f);
    //		slider.knob.SetPosition(0.2f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.2f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.2f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.2f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x <= transPos.x - x / 20f * 7f && pos.x > transPos.x - x / 20f * 9f)
    //	{
    //		slider.UpdateAppearance(0.1f);
    //		slider.knob.SetPosition(0.1f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0.1f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0.1f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0.1f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //	if (pos.x >= transPos.x - x / 2f && pos.x <= transPos.x - x / 20f * 9f)
    //	{
    //		slider.UpdateAppearance(0f);
    //		slider.knob.SetPosition(0f);
    //		if (type == "背景")
    //		{
    //			SystemSetting.SetBgSoundValue(0f);
    //		}
    //		else if (type == "游戏")
    //		{
    //			SystemSetting.SetGameSoundValue(0f);
    //		}
    //		else if (type == "配音")
    //		{
    //			SystemSetting.SetDubSoundValue(0f);
    //		}
    //		LandPlane.m_bDoChange = true;
    //		return;
    //	}
    //}

    //private void Tab(UIPanelTab tab)
    //{
    //	if (tab != this.m_resTab && this.m_resTab.panelIsShowing)
    //	{
    //		this.m_resTab.panelIsShowing = false;
    //		this.m_resTab.DoPanelStuff();
    //	}
    //	else if (tab != this.m_modeTab && this.m_modeTab.panelIsShowing)
    //	{
    //		this.m_modeTab.panelIsShowing = false;
    //		this.m_modeTab.DoPanelStuff();
    //	}
    //}

    //private void HideScroll()
    //{
    //	if (this.m_resTab.panelIsShowing)
    //	{
    //		this.m_resTab.panelIsShowing = false;
    //		this.m_resTab.DoPanelStuff();
    //	}
    //	if (this.m_modeTab.panelIsShowing)
    //	{
    //		this.m_modeTab.panelIsShowing = false;
    //		this.m_modeTab.DoPanelStuff();
    //	}
    //}

    //public void ClearList()
    //{
    //	if (LandPlane.m_resScrolList != null)
    //	{
    //		LandPlane.m_resScrolList.ClearList(true);
    //	}
    //	if (LandPlane.m_modeScrolList != null)
    //	{
    //		LandPlane.m_modeScrolList.ClearList(true);
    //	}
    //}

    //public override void Hide()
    //{
    //	if (this._landPlane.active)
    //	{
    //		this._landPlane.SetActive(false);
    //		MouseManager.ShowCursor(false);
    //	}
    //}

    //public override void Show()
    //{
    //	Singleton<EZGUIManager>.GetInstance().HideActiveGOEx("LoadingMain");
    //	if (!this._landPlane.active)
    //	{
    //		this._landPlane.SetActiveRecursively(true);
    //		if (LandPlane.m_bAddInput)
    //		{
    //			this.PushData();
    //			LandPlane.m_bAddInput = false;
    //		}
    //		this.UpdateSize();
    //		base.StartCoroutine(this.ResolutionListEx());
    //		this.m_resTab.panel.Dismiss();
    //		this.m_modeTab.panel.Dismiss();
    //		this.DisButton();
    //		MouseManager.ShowCursor(true);
    //	}
    //	if (this._uiCam == null)
    //	{
    //		this._uiCam = GameObject.FindWithTag("UICam").GetComponent<Camera>();
    //	}
    //}
}
