using System;
using System.Collections.Generic;
using UnityEngine;


public class HelpManager : MonoBehaviour
{
    //private TimeOutManager m_TimeOutManager;

    public bool _bPlayedMovieid;

    public GameObject _scriptGo;

    public static float _time;

    public static bool _bChange;

   // public HelpType _helpType;

    private bool _bActive = true;

    public static int m_Keycode;

    public static int m_Mouse = -1;

    public static int _helpID = -1;

    public string m_Move = "null";

    public static bool m_isHelp;

    public static bool m_IsKey = true;

   // public HelpInfo m_Info;

    public static HelpManager _instance;

    public void Awake()
	{
		//HelpManager._instance = this;
	}

	public void OnTriggerEnter(Collider other)
	{
		//if (this._helpType != HelpType.collision)
		//{
		//	return;
		//}
		//if (!this._bActive)
		//{
		//	return;
		//}
		//if (other.tag == "Player")
		//{
			//if (!Player.Instance._helpBase.m_HelpGroup.ContainsKey(this.m_Info.m_ID))
			//{
			//	Player.Instance._helpBase.m_HelpGroup.Add(this.m_Info.m_ID, new HelpBase.HelpItem
			//	{
			//		manager = this
			//	});
			//}
			//if (!MovieManager.MovieMag.IsPlaying())
			//{
			//	GameData.Instance.ScrMan.Exec(44, this.m_Info.m_ID);
			//}
		//}
	}

	//public static void HelpEnter(int id, HelpType type, HelpInfo info)
	//{
	//	if (Player.Instance._helpBase.m_HelpGroup.ContainsKey(id) && Player.Instance._helpBase.m_HelpGroup[id].finished)
	//	{
	//		return;
	//	}
	//	GameObject gameObject = new GameObject();
	//	gameObject.name = "ScriptHelp__" + id;
	//	Player.Instance._helpBase._helpGo.Add(gameObject);
	//	gameObject.layer = 10;
	//	gameObject.transform.parent = GameObject.FindWithTag("UICam").transform;
	//	HelpManager helpManager = gameObject.AddComponent<HelpManager>();
	//	if (!Player.Instance._helpBase.m_HelpGroup.ContainsKey(id))
	//	{
	//		Player.Instance._helpBase.m_HelpGroup.Add(id, new HelpBase.HelpItem
	//		{
	//			manager = helpManager
	//		});
	//	}
	//	else
	//	{
	//		HelpManager manager = Player.Instance._helpBase.m_HelpGroup[id].manager;
	//		if (manager != null)
	//		{
	//			Debug.LogWarning(DU.Warning(new object[]
	//			{
	//				"call some times",
	//				info.m_ID
	//			}));
	//		}
	//		Player.Instance._helpBase.m_HelpGroup[id] = new HelpBase.HelpItem
	//		{
	//			manager = helpManager
	//		};
	//	}
	//	HelpBase._iId = id;
	//	helpManager.m_Info = info;
	//	helpManager._helpType = type;
	//	if (helpManager._helpType != HelpType.Script)
	//	{
	//		return;
	//	}
	//	HelpManager.m_Keycode = helpManager.m_Info._iKey;
	//	HelpManager.m_Mouse = helpManager.m_Info._iMouse;
	//	helpManager.m_Move = helpManager.m_Info._sMove;
	//	if (helpManager.m_Info.m_Stop)
	//	{
	//		GameTime.Stop();
	//		if (HelpManager.m_Keycode == 0 && HelpManager.m_Mouse == -1 && helpManager.m_Move == "null")
	//		{
	//			HelpManager.m_IsKey = false;
	//		}
	//		HelpManager.m_isHelp = true;
	//		PlayerUIManager._bIsUI = true;
	//	}
	//	HelpManager._time = GameTime.time;
	//	PlayerUIManager._help = info._escType;
	//	HelpManager._helpID = info._helpID;
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>().Show();
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.transform.position = new Vector3(Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.transform.position.x, Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.transform.position.y, info._zOffset);
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlaneT.transform.position = new Vector3(Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlaneT.transform.position.x, Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlaneT.transform.position.y, info._zOffset);
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrF.Text = helpManager.m_Info._sStrF;
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrB.Text = helpManager.m_Info._sStrB;
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrFT.Text = helpManager.m_Info._sStrF;
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrBT.Text = helpManager.m_Info._sStrB;
	//	float num = 0f;
	//	char[] array = info._sStrF.ToCharArray();
	//	for (int i = 0; i < info._sStrF.Length; i++)
	//	{
	//		if (array[i] >= '一' && array[i] <= '龥')
	//		{
	//			num = num;
	//		}
	//		else if (array[i] == ' ')
	//		{
	//			num += 0.75f;
	//		}
	//		else
	//		{
	//			num += 1f;
	//		}
	//	}
	//	HelpManager.SetImage(helpManager.m_Info._path, num, id);
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrF.transform.parent.position = new Vector3(Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.transform.position.x + 1f, Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrF.transform.parent.position.y, Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrF.transform.parent.position.z);
	//	if (helpManager.m_Info._sStrF == "null")
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrF.active = false;
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrFT.active = false;
	//	}
	//	else
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrF.active = true;
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrFT.active = true;
	//	}
	//	if (helpManager.m_Info._sStrB == "null")
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrB.active = false;
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrBT.active = false;
	//	}
	//	else
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrB.active = true;
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helStrBT.active = true;
	//	}
	//	if (id == 1001011 && PlayerUIManager.m_effIndex == -1)
	//	{
	//		PlayerUIManager.m_effIndex = Singleton<GUIEffectManager>.GetInstance().AddEffect(12, PlayerUIManager._buttonSkill.transform, true);
	//	}
	//	if (id == 1000074)
	//	{
	//		Dictionary<ulong, CItemBase> dictionary;
	//		if (GameData.Instance.ItemMan.TryGetItemsByID(1011000UL, out dictionary))
	//		{
	//			if (dictionary == null || dictionary.Count < 1)
	//			{
	//				Debug.LogWarning(DU.Warning(new object[]
	//				{
	//					"Wrong"
	//				}));
	//			}
	//			else
	//			{
	//				foreach (KeyValuePair<ulong, CItemBase> keyValuePair in dictionary)
	//				{
	//					if (Player.Instance.ItemFolder.WearOperate.SetSpareWeapon(keyValuePair.Value))
	//					{
	//						break;
	//					}
	//					Debug.LogWarning(DU.Warning(new object[]
	//					{
	//						"Fail"
	//					}));
	//				}
	//			}
	//		}
	//		else
	//		{
	//			Debug.LogWarning(DU.Warning(new object[]
	//			{
	//				"wrong"
	//			}));
	//		}
	//	}
	//	if (info._HelpPrefabType == 3.ToString() && Player.Instance._helpBase._helpArrowPos.ContainsKey(info.m_ID) && Player.Instance._helpBase._helpArrowRect.ContainsKey(info.m_ID))
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>().SetPos(Player.Instance._helpBase._helpArrowPos[id], Player.Instance._helpBase._helpArrowRect[id], info._HelpArrowType);
	//	}
	//	if (id == 1000049)
	//	{
	//		Player.Instance.m_RoleGrowDatas.bNQ = true;
	//		SkillUIManager.uiObject.transform.FindChild("Top/ITEM2").active = true;
	//		SkillUIManager.uiObject.transform.FindChild("Top/ITEM2").transform.GetComponent<UIBistateInteractivePanel>().Reveal();
	//		TimeOutManager.SetTimeOut(Main.Instance.transform, 0.3f, new Callback(HelpManager.NQBar));
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().m_uHead.transform.FindChild("Head").GetComponent<UIButton>().Color = new Color(0.4f, 0.4f, 0.4f);
	//	}
	//	if (id == 1000382)
	//	{
	//		Player.Instance.m_RoleGrowDatas.bSkill = true;
	//		SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/skill").active = true;
	//		SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/skill").transform.GetComponent<UIBistateInteractivePanel>().Reveal();
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_1.material.mainTexture = (ResourceLoader.Load(helpManager.m_Info._path, typeof(Texture2D)) as Texture2D);
	//	}
	//	if (id == 1000022)
	//	{
	//		Player.Instance.m_RoleGrowDatas.bFuZhi = true;
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cFLProtagonist.SetActiveRecursively(true);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cFLProtagonist.transform.GetComponent<UIBistateInteractivePanel>().Reveal();
	//	}
	//	if (id == 1000100)
	//	{
	//		Player.Instance.m_RoleGrowDatas.bHunZhi = true;
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cPlayerPanel.transform.FindChild("Player/Back/QH_Value").gameObject.SetActiveRecursively(true);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cPlayerPanel.transform.FindChild("Player/Back/QH_Value").transform.GetComponent<UIBistateInteractivePanel>().Reveal();
	//	}
	//	if (id == 1000403)
	//	{
	//		Player.Instance.m_RoleGrowDatas.NQTip = true;
	//	}
	//	if (info.m_ID == 1000023 || info.m_ID == 1000206)
	//	{
	//		HelpBase.Instance().SetTecState(1000023, 0);
	//		ModAttribute modAttribute = Player.Instance.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
	//		modAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_GROW, 1f, true);
	//	}
	//	if (info.m_ID == 1000016)
	//	{
	//		HelpBase.Instance().SetTecState(1000016, 0);
	//	}
	//	if (info.m_ID == 1000029)
	//	{
	//		HelpBase.Instance().SetTecState(1000029, 0);
	//	}
	//	if (info.m_ID == 1000031)
	//	{
	//		HelpBase.Instance().SetTecState(1000031, 0);
	//	}
	//	if (info.m_ID == 1000080)
	//	{
	//		HelpBase.Instance().SetTecState(1000016, -1);
	//	}
	//	if (info.m_ID == 1000250)
	//	{
	//		HelpBase.Instance().SetTecState(1000029, -1);
	//	}
	//	if (info.m_ID == 1000253)
	//	{
	//		HelpBase.Instance().SetTecState(1000031, -1);
	//	}
	//	if (helpManager.m_Info.m_ID == 1000042 || helpManager.m_Info.m_ID == 1000003)
	//	{
	//		KeyManager.hotKeyEnabled = false;
	//		helpManager.m_TimeOutManager = TimeOutManager.SetTimeOut(Main.Instance.transform, helpManager.m_Info._fDelTime, new Callback(helpManager.ExitEx));
	//	}
	//	else if (helpManager.m_Info.m_ID != 1000011)
	//	{
	//		helpManager.m_TimeOutManager = TimeOutManager.SetTimeOut(Main.Instance.transform, helpManager.m_Info._fDelTime, new Callback(helpManager.ExitEx));
	//	}
	//}

	//// Token: 0x060013FD RID: 5117 RVA: 0x000A31AC File Offset: 0x000A13AC
	//private static void NQBar()
	//{
	//	for (float num = 1f; num <= 20f; num += 1f)
	//	{
	//		TimeOutManager.SetTimeOut<float>(Main.Instance.transform, num / 15f, new Callback<float>(Player.Instance.SystemAmbit.SetRageSoulePecent), num / 20f);
	//	}
	//	TimeOutManager.SetTimeOut(Main.Instance.transform, 1.2f, new Callback(HelpManager.SetHeadColor));
	//}

	//// Token: 0x060013FE RID: 5118 RVA: 0x000A322C File Offset: 0x000A142C
	//private static void SetHeadColor()
	//{
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().m_uHead.transform.FindChild("Head").GetComponent<UIButton>().Color = new Color(0.8f, 0.8f, 0.8f);
	//}

	//// Token: 0x060013FF RID: 5119 RVA: 0x000A3278 File Offset: 0x000A1478
	//public void HelpExit(bool helpinvokehelp)
	//{
	//	if (this.m_Info._scriptM != -1 && HelpManager._helpID == -1)
	//	{
	//		GameData.Instance.ScrMan.Exec(this.m_Info._scriptM, this.m_Info._mID);
	//	}
	//	PlayerUIManager._bIsUI = false;
	//	if (this.m_Info.m_Stop && Singleton<EZGUIManager>.GetInstance().GetGUI("PlayerUIManager") != null && !Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>().pausePanelInstant.active)
	//	{
	//		HelpManager.m_IsKey = true;
	//		GameTime.Start();
	//	}
	//	if (this.m_Info.m_Stop)
	//	{
	//		HelpManager.m_IsKey = true;
	//	}
	//	HelpManager.m_Keycode = 0;
	//	HelpManager.m_Mouse = -1;
	//	this.m_Move = "null";
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>().Hide();
	//	if (this.m_Info.m_Once)
	//	{
	//		this._bActive = false;
	//		Player.Instance._helpBase.m_HelpGroup[this.m_Info.m_ID].finished = true;
	//	}
	//	HelpManager.m_isHelp = false;
	//	if (Player.Instance._helpBase._helpGo.Contains(base.gameObject))
	//	{
	//		Player.Instance._helpBase._helpGo.Remove(base.gameObject);
	//	}
	//	if (base.gameObject != null)
	//	{
	//		UnityEngine.Object.Destroy(base.gameObject);
	//	}
	//	if (this.m_TimeOutManager != null)
	//	{
	//		UnityEngine.Object.Destroy(this.m_TimeOutManager);
	//		this.m_TimeOutManager = null;
	//	}
	//	HelpManager.m_Keycode = 0;
	//	if (helpinvokehelp && HelpManager._helpID != -1)
	//	{
	//		SM_HelpEnable.ExecHelp(HelpManager._helpID);
	//	}
	//	HelpBase._iId = 0;
	//}

	//// Token: 0x06001400 RID: 5120 RVA: 0x000A3438 File Offset: 0x000A1638
	//public void ExitEx()
	//{
	//	if (this == null || base.gameObject == null)
	//	{
	//		return;
	//	}
	//	if (Player.Instance == null)
	//	{
	//		return;
	//	}
	//	HelpBase.HelpItem helpItem;
	//	if (Player.Instance._helpBase.m_HelpGroup.TryGetValue(this.m_Info.m_ID, out helpItem) && !helpItem.finished)
	//	{
	//		PlayerUIManager._bIsUI = false;
	//		if (this.m_Info.m_Once)
	//		{
	//			this._bActive = false;
	//			Player.Instance._helpBase.m_HelpGroup[this.m_Info.m_ID].finished = true;
	//		}
	//		this.HelpExit(true);
	//		int num = 0;
	//		if ((this.m_Info.m_Stop || num == 114) && this.m_Info._zOffset > 10f && Singleton<EZGUIManager>.GetInstance().GetGUI("PlayerUIManager") != null && !Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>().pausePanelInstant.active)
	//		{
	//			GameTime.Start();
	//		}
	//		if (Singleton<DrillSystem>.GetInstance().IsDrillState)
	//		{
	//			KeyManager.hotKeyEnabled = true;
	//		}
	//	}
	//}

	//// Token: 0x06001401 RID: 5121 RVA: 0x000A3568 File Offset: 0x000A1768
	//public void HelpExitEx()
	//{
	//	HelpBase.HelpItem helpItem;
	//	if (Player.Instance._helpBase.m_HelpGroup.TryGetValue(this.m_Info.m_ID, out helpItem))
	//	{
	//		int num = 0;
	//		if (!helpItem.finished)
	//		{
	//			if (PropsPlane.m_keyB != 0UL)
	//			{
	//				num = 114;
	//			}
	//			if (HelpManager.m_Keycode == 101 && (PropsPlane.m_keyA == 0UL || PropsPlane.m_AValue.Text == "0"))
	//			{
	//				HelpManager.m_Keycode = 0;
	//			}
	//			if (Input.GetKey((KeyCode)HelpManager.m_Keycode) || (num != 0 && Input.GetKey((KeyCode)num)) || (!this.m_Info.m_Stop && HelpManager._time + this.m_Info._fDelTime < GameTime.time) || (this.m_Info._zOffset < 30f && Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.active && !PlayerUIManager.pauseIsHide) || (this.m_Info._zOffset < 30f && Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlaneT.active && !PlayerUIManager.pauseIsHide) || LoadingMain.loadingIsShow)
	//			{
	//				Debug.Log(DU.Info(new object[]
	//				{
	//					Input.GetKey((KeyCode)HelpManager.m_Keycode),
	//					num != 0 && Input.GetKey((KeyCode)num),
	//					!this.m_Info.m_Stop && HelpManager._time + this.m_Info._fDelTime < GameTime.time,
	//					this.m_Info._zOffset < 30f && Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.active && !PlayerUIManager.pauseIsHide,
	//					this.m_Info._zOffset < 30f && Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlaneT.active && !PlayerUIManager.pauseIsHide,
	//					LoadingMain.loadingIsShow
	//				}));
	//				if ((this.m_Info.m_Stop || num == 114) && this.m_Info._zOffset > 10f && Singleton<EZGUIManager>.GetInstance().GetGUI("PlayerUIManager") != null && !Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>().pausePanelInstant.active)
	//				{
	//					GameTime.Start();
	//				}
	//				if (Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlane.active || Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>()._helpPlaneT.active)
	//				{
	//					if (this.m_Info._scriptM != -1 && HelpManager._helpID == -1)
	//					{
	//						GameData.Instance.ScrMan.Exec(this.m_Info._scriptM, this.m_Info._mID);
	//					}
	//					if (this.m_Info.m_Once)
	//					{
	//						this._bActive = false;
	//						Player.Instance._helpBase.m_HelpGroup[this.m_Info.m_ID].finished = true;
	//					}
	//					this.HelpExit(true);
	//				}
	//				else
	//				{
	//					this.HelpExit(false);
	//				}
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06001402 RID: 5122 RVA: 0x000A38D8 File Offset: 0x000A1AD8
	//public static void SetImage(string path, float t, int id)
	//{
	//	if (path != "null")
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>().SetImage(1, path, t);
	//	}
	//	else if (path == "null")
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<HelpPlane>().SetImage(0, path, t);
	//	}
	//	if (id == 2000029 || id == 2000030 || id == 2000031 || id == 2000129)
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_1.material.mainTexture = (ResourceLoader.Load(path, typeof(Texture2D)) as Texture2D);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_1.transform.GetComponent<UIBistateInteractivePanel>().Reveal();
	//	}
	//	if (id == 2000017 || id == 2000018 || id == 2000019 || id == 2000020)
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_2.material.mainTexture = (ResourceLoader.Load(path, typeof(Texture2D)) as Texture2D);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_2.transform.GetComponent<UIBistateInteractivePanel>().Reveal();
	//	}
	//	if (id == 2000021 || id == 2000022 || id == 2000023 || id == 2000024)
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_3.material.mainTexture = (ResourceLoader.Load(path, typeof(Texture2D)) as Texture2D);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_3.transform.GetComponent<UIBistateInteractivePanel>().Reveal();
	//	}
	//	if (id == 2000025 || id == 2000026 || id == 2000027 || id == 2000028)
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_4.material.mainTexture = (ResourceLoader.Load(path, typeof(Texture2D)) as Texture2D);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().skill_4.transform.GetComponent<UIBistateInteractivePanel>().Reveal();
	//	}
	//}

	//// Token: 0x06001403 RID: 5123 RVA: 0x000A3B10 File Offset: 0x000A1D10
	//public void OnGUI()
	//{
	//	Event current = Event.current;
	//	if (HelpBase._iId == this.m_Info.m_ID && current.isMouse && Singleton<EZGUIManager>.GetInstance().GetGUI("PlayerUIManager") != null && Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>().pausePanelInstant.active && HelpManager.m_Mouse == 0)
	//	{
	//		if (current.type == EventType.MouseDown)
	//		{
	//			int button = current.button;
	//			if (button == 0)
	//			{
	//				this.HelpExit(true);
	//			}
	//		}
	//		return;
	//	}
	//	HelpType helpType = this._helpType;
	//	if (helpType != HelpType.collision)
	//	{
	//		if (helpType == HelpType.Script)
	//		{
	//			if (HelpManager.m_Keycode == 27)
	//			{
	//				PlayerUIManager._bIsUI = false;
	//			}
	//			if (Player.Instance != null)
	//			{
	//				this.HelpExitEx();
	//			}
	//		}
	//	}
	//	else
	//	{
	//		if (this._helpType == HelpType.collision && !MovieManager.MovieMag.IsPlaying() && this._bPlayedMovieid)
	//		{
	//			HelpManager.m_isHelp = true;
	//			if (this.m_Info.m_Stop)
	//			{
	//				if (HelpManager.m_Keycode == 0 && HelpManager.m_Mouse == -1 && this.m_Move == "null")
	//				{
	//					HelpManager.m_IsKey = false;
	//				}
	//				GameTime.Stop();
	//			}
	//			Singleton<EZGUIManager>.GetInstance().GetGUI("HelpPlane").Show();
	//			float t = 0f;
	//			HelpManager.SetImage(this.m_Info._path, t, this.m_Info.m_ID);
	//			this._bPlayedMovieid = false;
	//		}
	//		if (MovieManager.MovieMag.IsPlaying())
	//		{
	//			return;
	//		}
	//		if (KeyManager._bScript)
	//		{
	//			if (this.m_Info._scriptM != -1 || this.m_Info._mID != -1)
	//			{
	//				GameData.Instance.ScrMan.Exec(this.m_Info._scriptM, this.m_Info._mID);
	//			}
	//			KeyManager._bScript = false;
	//		}
	//	}
	//}
}
