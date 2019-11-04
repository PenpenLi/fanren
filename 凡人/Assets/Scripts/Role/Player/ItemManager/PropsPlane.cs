using System;
using System.Collections.Generic;
using UnityEngine;

public class PropsPlane : GUIBase
{
	private void Awake()
	{
		//base.RegisterGUI();
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x00063B10 File Offset: 0x00061D10
	//public override bool Init()
	//{
	//	UnityEngine.Object original = ResourceLoader.Load("EZGUI/PropsPlane", typeof(GameObject));
	//	PropsPlane.m_PlaneObject = (UnityEngine.Object.Instantiate(original, Vector3.zero, Quaternion.identity) as GameObject);
	//	this.m_ListParentPrefab = (ResourceLoader.Load("EZGUI/ItemParent_prop", typeof(GameObject)) as GameObject);
	//	this.m_ListChildPrefab = (ResourceLoader.Load("EZGUI/ItemChild_prop", typeof(GameObject)) as GameObject);
	//	if (this.m_ListChildPrefab == null)
	//	{
	//		Logger.LogError(new object[]
	//		{
	//			"Prefab : EZGUI/ItemChild_prop no found!"
	//		});
	//	}
	//	PropsPlane.m_PropsList = PropsPlane.m_PlaneObject.transform.FindChild("RightLayer/PP_List").GetComponent<UIScrollList>();
	//	if (PropsPlane.m_PropsList != null && PropsPlane.m_PropsList.slider != null)
	//	{
	//		PropsPlane.m_PropsList.slider.AddValueChangedDelegate(new EZValueChangedDelegate(this.SliderMoved));
	//		PropsPlane.m_PropsList.AddValueChangedDelegate(new EZValueChangedDelegate(this.SliderMoved));
	//	}
	//	Transform transform = PropsPlane.m_PlaneObject.transform.FindChild("RightLayer");
	//	if (transform != null)
	//	{
	//		this.m_UIBT_Dan = transform.FindChild("PPLST_BT_DAN").GetComponent<UIButton>();
	//		if (null != this.m_UIBT_Dan)
	//		{
	//			this.m_UIBT_Dan.AddInputDelegate(new EZInputDelegate(this.OnCallBackDan));
	//			if (!this.m_topButton.ContainsValue(this.m_UIBT_Dan))
	//			{
	//				this.m_topButton.Add(1, this.m_UIBT_Dan);
	//			}
	//		}
	//		this.m_UIBT_Cai = transform.FindChild("PPLST_BT_CAI").GetComponent<UIButton>();
	//		if (null != this.m_UIBT_Cai)
	//		{
	//			this.m_UIBT_Cai.AddInputDelegate(new EZInputDelegate(this.OnCallBackCai));
	//			if (!this.m_topButton.ContainsValue(this.m_UIBT_Cai))
	//			{
	//				this.m_topButton.Add(2, this.m_UIBT_Cai);
	//			}
	//		}
	//		this.m_UIBT_Ta = transform.FindChild("PPLST_BT_ZA").GetComponent<UIButton>();
	//		if (null != this.m_UIBT_Ta)
	//		{
	//			this.m_UIBT_Ta.AddInputDelegate(new EZInputDelegate(this.OnCallBackTa));
	//			if (!this.m_topButton.ContainsValue(this.m_UIBT_Ta))
	//			{
	//				this.m_topButton.Add(3, this.m_UIBT_Ta);
	//			}
	//		}
	//		this.m_UIC_TopSlider = transform.FindChild("Top").GetComponent<UIButton>();
	//		if (null != this.m_UIC_TopSlider)
	//		{
	//			this.m_UIC_TopSlider.AddInputDelegate(new EZInputDelegate(this.OnCallTop));
	//		}
	//		this.m_UIC_BottomSlider = transform.FindChild("Bottom").GetComponent<UIButton>();
	//		if (null != this.m_UIC_BottomSlider)
	//		{
	//			this.m_UIC_BottomSlider.AddInputDelegate(new EZInputDelegate(this.OnCallBootom));
	//		}
	//		this.m_slider = transform.FindChild("PP_List/Slider").GetComponent<UISlider>();
	//	}
	//	BoxCollider component = PropsPlane.m_PlaneObject.GetComponent<BoxCollider>();
	//	if (component != null)
	//	{
	//		component.enabled = false;
	//	}
	//	PropsPlane.m_PropsList.scriptWithMethodToInvoke = GameObject.FindWithTag("UICam").GetComponent<PropsPlane>();
	//	PropsPlane.m_PropsList.methodToInvokeOnSelect = "OnEZCallBack";
	//	if (this.IsBuild)
	//	{
	//		return false;
	//	}
	//	if (null == PropsPlane.m_PlaneMid)
	//	{
	//		PropsPlane.m_PlaneMid = PropsPlane.m_PlaneObject.transform.FindChild("MidLayer").gameObject;
	//	}
	//	if (null == PropsPlane.m_PlaneLeft)
	//	{
	//		PropsPlane.m_PlaneLeft = PropsPlane.m_PlaneObject.transform.FindChild("LeftLayer").gameObject;
	//	}
	//	if (null == PropsPlane.m_PlaneRight)
	//	{
	//		PropsPlane.m_PlaneRight = PropsPlane.m_PlaneObject.transform.FindChild("RightLayer").gameObject;
	//	}
	//	if (null == this.m_BigIco)
	//	{
	//		this.m_BigIco = PropsPlane.m_PlaneLeft.transform.FindChild("DescIco").gameObject;
	//		this.m_BigIco.GetComponent<MeshRenderer>().material.mainTexture = null;
	//		this.m_BigIco.GetComponent<MeshRenderer>().material.mainTexture = (Texture)ResourceLoader.Load("GameLegend/Icon/Item/biglock", typeof(Texture));
	//	}
	//	if (null == this.m_UIDescTitle)
	//	{
	//		this.m_UIDescTitle = PropsPlane.m_PlaneLeft.transform.FindChild("DescTitle").GetComponent<SpriteText>();
	//	}
	//	if (null == this.m_UISkillAttText)
	//	{
	//		this.m_UISkillAttText = PropsPlane.m_PlaneLeft.transform.FindChild("DescSkillText").GetComponent<SpriteText>();
	//	}
	//	if (null == this.m_UIDescText)
	//	{
	//		this.m_UIDescText = PropsPlane.m_PlaneLeft.transform.FindChild("DescText").GetComponent<SpriteText>();
	//	}
	//	if (null == this.m_UIDescText0)
	//	{
	//		this.m_UIDescText0 = PropsPlane.m_PlaneLeft.transform.FindChild("DescText0").GetComponent<SpriteText>();
	//	}
	//	if (null == this.m_UIIntro)
	//	{
	//		this.m_UIIntro = PropsPlane.m_PlaneLeft.transform.FindChild("DescIntro").GetComponent<SpriteText>();
	//	}
	//	if (null == this.m_UIBT_JoyKeyA)
	//	{
	//		this.m_UIBT_JoyKeyA = PropsPlane.m_PlaneMid.transform.FindChild("JoyKeyA").GetComponent<UIButton>();
	//		this.m_UIBT_JoyKeyA.transform.FindChild("BK").GetComponent<UIButton>().AddInputDelegate(new EZInputDelegate(this.EChoose));
	//	}
	//	if (null == this.m_UIBT_JoyKeyB)
	//	{
	//		this.m_UIBT_JoyKeyB = PropsPlane.m_PlaneMid.transform.FindChild("JoyKeyB").GetComponent<UIButton>();
	//		this.m_UIBT_JoyKeyB.transform.FindChild("BK").GetComponent<UIButton>().AddInputDelegate(new EZInputDelegate(this.RChoose));
	//	}
	//	if (null == PropsPlane.m_MecJoyKeyA)
	//	{
	//		PropsPlane.m_MecJoyKeyA = this.m_UIBT_JoyKeyA.transform.FindChild("KeyA").GetComponent<MeshRenderer>();
	//	}
	//	if (null == PropsPlane.m_MecJoyKeyB)
	//	{
	//		PropsPlane.m_MecJoyKeyB = this.m_UIBT_JoyKeyB.transform.FindChild("KeyB").GetComponent<MeshRenderer>();
	//	}
	//	if (null == PropsPlane.m_AValue)
	//	{
	//		PropsPlane.m_AValue = this.m_UIBT_JoyKeyA.transform.FindChild("Value").GetComponent<SpriteText>();
	//	}
	//	if (null == PropsPlane.m_BValue)
	//	{
	//		PropsPlane.m_BValue = this.m_UIBT_JoyKeyB.transform.FindChild("Value").GetComponent<SpriteText>();
	//	}
	//	UnityEngine.Object original2 = ResourceLoader.Load("EZGUI/DragItemChild_prop", typeof(GameObject));
	//	PropsPlane.m_MedicineObject = (UnityEngine.Object.Instantiate(original2, Vector3.zero, Quaternion.identity) as GameObject);
	//	PropsPlane.m_MedicineObject.transform.parent = GameObject.FindWithTag("UICam").transform;
	//	this.m_MecRenderer = PropsPlane.m_MedicineObject.transform.FindChild("DanYao").GetComponent<MeshRenderer>();
	//	PropsPlane.m_MedicineObject.transform.position = new Vector3(0f, 0f, 0.5f);
	//	base.SetParentEx(PropsPlane.m_PlaneObject);
	//	this.IsBuild = true;
	//	this.AdjustPosition();
	//	this.InitRightMenu();
	//	KeyManager.addUIKey(KeyCode.E, new Callback(this.CallE));
	//	KeyManager.addUIKey(KeyCode.R, new Callback(this.CallR));
	//	PropsPlane.m_MedicineObject.SetActiveRecursively(false);
	//	this.Hide();
	//	return true;
	//}

	//// Token: 0x06000CB2 RID: 3250 RVA: 0x000642A0 File Offset: 0x000624A0
	//public void SliderMoved(IUIObject slider)
	//{
	//	if (slider == null)
	//	{
	//		return;
	//	}
	//	if (this._list_new.Count > 0)
	//	{
	//		for (int i = 1; i <= this._list_new.Count; i++)
	//		{
	//			this._list_new[i - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = true;
	//			this._list_new[i - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//			this._list_new[i - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = false;
	//			if (this.m_mapItmeInfo_NEW.Count > 0)
	//			{
	//				foreach (IUIListObject iuilistObject in this.m_mapItmeInfo_NEW.Values)
	//				{
	//					if (iuilistObject == this._list_new[i - 1])
	//					{
	//						iuilistObject.transform.FindChild("ItemNew").active = false;
	//					}
	//				}
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06000CB3 RID: 3251 RVA: 0x000643EC File Offset: 0x000625EC
	//public void SetSound(bool isClick, int clickID, AudioSource audio, UIButton button, List<UIButton> buttons, UIStateToggleBtn toggle)
	//{
	//	if (audio == null)
	//	{
	//		GameData.Instance.soundTable.initialize();
	//		audio = EZGUIManager.CreatAudio(clickID);
	//	}
	//	if (clickID == 5002 || clickID == 5018 || clickID == 5007)
	//	{
	//		if (audio != null)
	//		{
	//			audio.PlayOneShot(audio.clip);
	//		}
	//	}
	//	else if (toggle != null)
	//	{
	//		toggle.soundToPlay = audio;
	//	}
	//	else if (button != null)
	//	{
	//		button.soundOnClick = audio;
	//	}
	//	else if (isClick)
	//	{
	//		if (button != null)
	//		{
	//			for (int i = 0; i < buttons.Count; i++)
	//			{
	//				buttons[i].soundOnClick = audio;
	//			}
	//		}
	//	}
	//	else if (buttons != null)
	//	{
	//		for (int j = 0; j < buttons.Count; j++)
	//		{
	//			buttons[j].soundOnOver = audio;
	//		}
	//	}
	//}

	//// Token: 0x06000CB4 RID: 3252 RVA: 0x000644FC File Offset: 0x000626FC
	//private void EChoose(ref POINTER_INFO pt)
	//{
	//	POINTER_INFO.INPUT_EVENT evt = pt.evt;
	//	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
	//	{
	//		if (PropsPlane.m_MecJoyKeyA.material.mainTexture != (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture)))
	//		{
	//			this.m_UIBT_JoyKeyA.transform.FindChild("BK").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//			this.m_UIBT_JoyKeyA.transform.FindChild("BK").GetComponent<UIButton>().controlIsEnabled = false;
	//			this.m_UIBT_JoyKeyB.transform.FindChild("BK").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//			this.m_UIBT_JoyKeyB.transform.FindChild("BK").GetComponent<UIButton>().controlIsEnabled = true;
	//		}
	//	}
	//}

	//// Token: 0x06000CB5 RID: 3253 RVA: 0x000645D4 File Offset: 0x000627D4
	//private void RChoose(ref POINTER_INFO pt)
	//{
	//	POINTER_INFO.INPUT_EVENT evt = pt.evt;
	//	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
	//	{
	//		if (PropsPlane.m_MecJoyKeyB.material.mainTexture != (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture)))
	//		{
	//			this.m_UIBT_JoyKeyB.transform.FindChild("BK").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//			this.m_UIBT_JoyKeyB.transform.FindChild("BK").GetComponent<UIButton>().controlIsEnabled = false;
	//			this.m_UIBT_JoyKeyA.transform.FindChild("BK").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//			this.m_UIBT_JoyKeyA.transform.FindChild("BK").GetComponent<UIButton>().controlIsEnabled = true;
	//		}
	//	}
	//}

	//// Token: 0x06000CB6 RID: 3254 RVA: 0x000646AC File Offset: 0x000628AC
	//private void InitRightMenu()
	//{
	//	this.m_rightFourMenu.CreateMenu("PropsMenu", Singleton<EZGUIManager>.GetInstance().ParentTrans, "EZGUI/PropsPlane/PropsRightMenuItem", new OnMenuMsgDelegate(this.RightFourMenuCall));
	//}

	//// Token: 0x06000CB7 RID: 3255 RVA: 0x000646E8 File Offset: 0x000628E8
	//private void RightFourMenuCall(POINTER_INFO pt, int index, string menuname, object data)
	//{
	//	if (pt.evt == POINTER_INFO.INPUT_EVENT.TAP)
	//	{
	//		if (index == 0)
	//		{
	//			this.OnDLCick(PropsPlane.m_pointer, PropsPlane.m_Index.ToString());
	//			this.m_rightFourMenu.CloseMenu(false);
	//		}
	//		else if (index == 1)
	//		{
	//			if (PropsPlane.m_keyB == PropsPlane.m_Index)
	//			{
	//				PropsPlane.m_MecJoyKeyB.material.mainTexture = (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture));
	//				Player.Instance.m_RoleGrowDatas.m_proR = "NULL";
	//				PropsPlane.m_keyB = 0UL;
	//				PropsPlane.m_BValue.Text = string.Empty;
	//				if (SkillUIManager.instance != null)
	//				{
	//					SkillUIManager.m_BValue.Text = string.Empty;
	//					SkillUIManager.instance.SetOneItemTexture(1, "EZGUI/Main/AlphaTrans", false, TYPE.ALL);
	//					PropsPlane.m_keyBPath = "EZGUI/Main/AlphaTrans";
	//				}
	//				if (PropsPlane.m_effBIndex != -1)
	//				{
	//					Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effBIndex, true);
	//					PropsPlane.m_effBIndex = -1;
	//				}
	//			}
	//			PropsPlane.m_MecJoyKeyA.material.mainTexture = (Texture)ResourceLoader.Load(this.m_info.IcoPath, typeof(Texture));
	//			Player.Instance.m_RoleGrowDatas.m_proE = this.m_info.IcoPath;
	//			Player.Instance.m_RoleGrowDatas.m_proECount = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.E);
	//			PropsPlane.m_AValue.Text = this.m_info.Count.ToString();
	//			TimeOutManager.SetTimeOut(Main.Instance.transform, 0.2f, new Callback(PropsPlane.m_MecJoyKeyA.transform.GetComponent<UIBistateInteractivePanel>().Reveal));
	//			TimeOutManager.SetTimeOut(Main.Instance.transform, 0.7f, new Callback(PropsPlane.m_MecJoyKeyA.transform.GetComponent<UIBistateInteractivePanel>().Hide));
	//			if (PropsPlane.m_effAIndex != -1)
	//			{
	//				Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effAIndex, true);
	//				PropsPlane.m_effAIndex = -1;
	//			}
	//			if (SkillUIManager.instance != null)
	//			{
	//				SkillUIManager.m_AValue.Text = this.m_info.Count.ToString();
	//				SkillUIManager.instance.SetOneItemTexture(0, this.m_info.IcoPath, true, TYPE.ALL);
	//				PropsPlane.m_keyAPath = this.m_info.IcoPath;
	//			}
	//			Color color = PropsPlane.m_MecJoyKeyA.material.color;
	//			if (PropsPlane.m_pointerA.targetObj != null && ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID != ((PropsPlane.PropItemInfo)PropsPlane.m_pointer.targetObj.Data).ITEM_STATIC_ID && color == PropsPlane.m_proA)
	//			{
	//				Color color2 = new Color(0.43f, 0.43f, 0.43f, 255f);
	//				PropsPlane.m_MecJoyKeyA.material.SetColor("_Color", color2);
	//				if (SkillUIManager.instance != null)
	//				{
	//					SM_UpdateProp.m_bColorForA = true;
	//					PropsPlane.m_keyAPath = this.m_info.IcoPath;
	//					SkillUIManager.m_AValue.Text = this.m_info.Count.ToString();
	//					SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/item1").GetComponent<MeshRenderer>().material.SetColor("_Color", color2);
	//				}
	//			}
	//			else
	//			{
	//				SM_UpdateProp.m_bColorForA = false;
	//			}
	//			PropsPlane.m_keyA = PropsPlane.m_Index;
	//			PropsPlane.m_pointerA = PropsPlane.m_pointer;
	//			Player.Instance.m_RoleGrowDatas.E = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID;
	//			if (PropsPlane.m_effAIndex == -1)
	//			{
	//				PropsPlane.m_effAIndex = Singleton<GUIEffectManager>.GetInstance().AddEffect(5, this.m_UIBT_JoyKeyA.transform, true);
	//			}
	//			this.m_rightFourMenu.CloseMenu(false);
	//		}
	//		else if (index == 2)
	//		{
	//			if (PropsPlane.m_keyA == PropsPlane.m_Index)
	//			{
	//				PropsPlane.m_MecJoyKeyA.material.mainTexture = (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture));
	//				Player.Instance.m_RoleGrowDatas.m_proE = "NULL";
	//				PropsPlane.m_keyA = 0UL;
	//				PropsPlane.m_AValue.Text = string.Empty;
	//				if (SkillUIManager.instance != null)
	//				{
	//					SkillUIManager.m_AValue.Text = string.Empty;
	//					SkillUIManager.instance.SetOneItemTexture(0, "EZGUI/Main/AlphaTrans", false, TYPE.ALL);
	//					PropsPlane.m_keyAPath = "EZGUI/Main/AlphaTrans";
	//				}
	//				if (PropsPlane.m_effAIndex != -1)
	//				{
	//					Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effAIndex, true);
	//					PropsPlane.m_effAIndex = -1;
	//				}
	//			}
	//			Color color3 = PropsPlane.m_MecJoyKeyB.material.color;
	//			PropsPlane.m_MecJoyKeyB.material.mainTexture = (Texture)ResourceLoader.Load(this.m_info.IcoPath, typeof(Texture));
	//			Player.Instance.m_RoleGrowDatas.m_proR = this.m_info.IcoPath;
	//			Player.Instance.m_RoleGrowDatas.m_proRCount = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.R);
	//			TimeOutManager.SetTimeOut(Main.Instance.transform, 0.2f, new Callback(PropsPlane.m_MecJoyKeyB.transform.GetComponent<UIBistateInteractivePanel>().Reveal));
	//			TimeOutManager.SetTimeOut(Main.Instance.transform, 0.7f, new Callback(PropsPlane.m_MecJoyKeyB.transform.GetComponent<UIBistateInteractivePanel>().Hide));
	//			PropsPlane.m_BValue.Text = this.m_info.Count.ToString();
	//			if (PropsPlane.m_effBIndex != -1)
	//			{
	//				Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effBIndex, true);
	//				PropsPlane.m_effBIndex = -1;
	//			}
	//			if (SkillUIManager.instance != null && PropsPlane.m_keyB == 0UL)
	//			{
	//				SkillUIManager.m_BValue.Text = this.m_info.Count.ToString();
	//				SkillUIManager.instance.SetOneItemTexture(1, this.m_info.IcoPath, true, TYPE.ALL);
	//				PropsPlane.m_keyBPath = this.m_info.IcoPath;
	//			}
	//			else if (SkillUIManager.instance != null && PropsPlane.m_keyB != 0UL && PropsPlane.m_keyBPath != this.m_info.IcoPath)
	//			{
	//				SkillUIManager.m_BValue.Text = this.m_info.Count.ToString();
	//				SkillUIManager.instance.SetOneItemTexture(1, this.m_info.IcoPath, false, TYPE.ALL);
	//				PropsPlane.m_keyBPath = this.m_info.IcoPath;
	//			}
	//			if (PropsPlane.m_pointerB.targetObj != null && ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID != ((PropsPlane.PropItemInfo)PropsPlane.m_pointer.targetObj.Data).ITEM_STATIC_ID && color3 == PropsPlane.m_proB)
	//			{
	//				Color color4 = new Color(0.43f, 0.43f, 0.43f, 255f);
	//				PropsPlane.m_MecJoyKeyB.material.SetColor("_Color", color4);
	//				if (SkillUIManager.instance != null && SM_UpdateProp.m_bColorForB)
	//				{
	//					SM_UpdateProp.m_bColorForB = false;
	//					SkillUIManager.m_BValue.Text = this.m_info.Count.ToString();
	//					SkillUIManager.instance.SetOneItemTexture(1, this.m_info.IcoPath, false, TYPE.ITEM_TYPE);
	//					PropsPlane.m_keyBPath = this.m_info.IcoPath;
	//				}
	//			}
	//			PropsPlane.m_keyB = PropsPlane.m_Index;
	//			PropsPlane.m_pointerB = PropsPlane.m_pointer;
	//			Player.Instance.m_RoleGrowDatas.R = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID;
	//			if (PropsPlane.m_effBIndex == -1)
	//			{
	//				PropsPlane.m_effBIndex = Singleton<GUIEffectManager>.GetInstance().AddEffect(5, this.m_UIBT_JoyKeyB.transform, true);
	//			}
	//			this.m_rightFourMenu.CloseMenu(false);
	//		}
	//		else if (index == 3)
	//		{
	//			if (PropsPlane.m_pointer.targetObj == null)
	//			{
	//				return;
	//			}
	//			PropsPlane.PropItemInfo propItemInfo = (PropsPlane.PropItemInfo)PropsPlane.m_pointer.targetObj.Data;
	//			this.Remove(propItemInfo);
	//			GameData.Instance.ItemMan.RemoveItemsBySortID(propItemInfo.ITEM_STATIC_ID);
	//			ulong item_STATIC_ID = ((PropsPlane.PropItemInfo)PropsPlane.m_pointer.targetObj.Data).ITEM_STATIC_ID;
	//			this.m_bChuck = ((PropsPlane.PropItemInfo)PropsPlane.m_pointer.targetObj.Data).ChildTypeID;
	//			if (item_STATIC_ID == PropsPlane.m_keyA)
	//			{
	//				PropsPlane.m_MecJoyKeyA.material.mainTexture = (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture));
	//				Player.Instance.m_RoleGrowDatas.m_proE = "NULL";
	//				PropsPlane.m_pointerA.targetObj = null;
	//				Player.Instance.m_RoleGrowDatas.E = 0UL;
	//				PropsPlane.m_AValue.Text = string.Empty;
	//				if (SkillUIManager.instance != null)
	//				{
	//					SkillUIManager.instance.SetOneItemTexture(0, "EZGUI/Main/AlphaTrans", true, TYPE.ALL);
	//				}
	//			}
	//			if (item_STATIC_ID == PropsPlane.m_keyB)
	//			{
	//				PropsPlane.m_MecJoyKeyB.material.mainTexture = (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture));
	//				Player.Instance.m_RoleGrowDatas.m_proR = "NULL";
	//				Player.Instance.m_RoleGrowDatas.R = 0UL;
	//				PropsPlane.m_pointerB.targetObj = null;
	//				PropsPlane.m_BValue.Text = string.Empty;
	//				if (SkillUIManager.instance != null)
	//				{
	//					SkillUIManager.instance.SetOneItemTexture(1, "EZGUI/Main/AlphaTrans", true, TYPE.ALL);
	//				}
	//			}
	//			if (!this.m_mapItemInfo_DiuQi.ContainsKey(item_STATIC_ID))
	//			{
	//				this.m_mapItemInfo_DiuQi.Add(item_STATIC_ID, (PropsPlane.PropItemInfo)PropsPlane.m_pointer.targetObj.Data);
	//			}
	//			List<IUIListObject> list;
	//			if (this.m_mapUINowGroup.TryGetValue(propItemInfo.ChildTypeID, out list))
	//			{
	//				this.UpdateListPos(propItemInfo.ChildTypeID, list);
	//			}
	//			PropsPlane.m_PropsList.RemoveItem((IUIListObject)PropsPlane.m_pointer.targetObj, true);
	//			if (this._list_new.Contains((IUIListObject)PropsPlane.m_pointer.targetObj))
	//			{
	//				this._list_new.Remove((IUIListObject)PropsPlane.m_pointer.targetObj);
	//			}
	//			foreach (KeyValuePair<int, GameObject> keyValuePair in this.m_mapUITypeNode)
	//			{
	//				Transform transform = keyValuePair.Value.transform.FindChild("ItemCount");
	//				if (transform != null)
	//				{
	//					SpriteText component = transform.gameObject.GetComponent<SpriteText>();
	//					if (component != null && this.m_mapUINowGroup.ContainsKey(keyValuePair.Key))
	//					{
	//						component.Text = ((this.m_mapUINowGroup[keyValuePair.Key].Count <= 0) ? string.Empty : ("(" + this.m_mapUINowGroup[keyValuePair.Key].Count + ")"));
	//					}
	//				}
	//			}
	//			PropsPlane.m_pointer.targetObj = null;
	//			this.m_ptCmd.targetObj = null;
	//			this.SelectOneItem();
	//			this.m_rightFourMenu.CloseMenu(false);
	//			if (PropsPlane.m_PropsList.Count == 0)
	//			{
	//				GameObject obj;
	//				if (this.m_mapUITypeNode.TryGetValue(propItemInfo.ChildTypeID, out obj))
	//				{
	//					UnityEngine.Object.Destroy(obj);
	//					this.m_mapUITypeNode.Remove(propItemInfo.ChildTypeID);
	//				}
	//				this.UpdateParentPos();
	//			}
	//			if (list.Count < 6)
	//			{
	//				PropsPlane.m_PropsList.slider.transform.active = false;
	//				this.m_UIC_TopSlider.active = false;
	//				this.m_UIC_BottomSlider.active = false;
	//			}
	//			else
	//			{
	//				PropsPlane.m_PropsList.slider.transform.active = true;
	//				this.m_UIC_TopSlider.active = true;
	//				this.m_UIC_BottomSlider.active = true;
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06000CB8 RID: 3256 RVA: 0x00065344 File Offset: 0x00063544
	//private void Remove(PropsPlane.PropItemInfo infos)
	//{
	//	int num = -1;
	//	int num2 = -1;
	//	foreach (KeyValuePair<int, List<IUIListObject>> keyValuePair in this.m_mapUINowGroup)
	//	{
	//		for (int i = 0; i < keyValuePair.Value.Count; i++)
	//		{
	//			if (((PropsPlane.PropItemInfo)keyValuePair.Value[i].Data).ITEM_STATIC_ID == infos.ITEM_STATIC_ID)
	//			{
	//				num = keyValuePair.Key;
	//				num2 = i;
	//				break;
	//			}
	//		}
	//	}
	//	if (num != -1 && num2 != -1)
	//	{
	//		IUIListObject iuilistObject = this.m_mapUINowGroup[num][num2];
	//		UnityEngine.Object.Destroy(iuilistObject.gameObject);
	//		this.m_mapUINowGroup[num].RemoveAt(num2);
	//	}
	//}

	//// Token: 0x06000CB9 RID: 3257 RVA: 0x00065440 File Offset: 0x00063640
	//public bool AddData(ItemCfgType tag, CItemBase info)
	//{
	//	if (info == null)
	//	{
	//		return false;
	//	}
	//	Dictionary<ulong, PropsPlane.PropItemInfo> dictionary;
	//	if (tag == ItemCfgType.ITCT_PELLET)
	//	{
	//		dictionary = this.m_mapItemInfo_Dan;
	//	}
	//	else if (tag == ItemCfgType.ITCT_STUFF)
	//	{
	//		dictionary = this.m_mapItemInfo_Cai;
	//	}
	//	else
	//	{
	//		if (tag != ItemCfgType.ITCT_OTHER)
	//		{
	//			return false;
	//		}
	//		dictionary = this.m_mapItemInfo_Ta;
	//	}
	//	PropsPlane.PropItemInfo propItemInfo;
	//	PropsPlane.PropItemInfo propItemInfo2;
	//	if (!dictionary.TryGetValue(info.ITEM_STATIC_ID, out propItemInfo))
	//	{
	//		if (!this.m_mapItemInfo_DiuQi.TryGetValue(info.ITEM_STATIC_ID, out propItemInfo))
	//		{
	//			propItemInfo = new PropsPlane.PropItemInfo();
	//			propItemInfo.Add(info);
	//			dictionary.Add(propItemInfo.ITEM_STATIC_ID, propItemInfo);
	//		}
	//	}
	//	else if (!this.m_mapItemInfo_DiuQi.TryGetValue(info.ITEM_STATIC_ID, out propItemInfo2))
	//	{
	//		propItemInfo.Add(info);
	//	}
	//	return true;
	//}

	//// Token: 0x06000CBA RID: 3258 RVA: 0x000654FC File Offset: 0x000636FC
	//public void ClearData(ItemCfgType tag, bool bIsFull)
	//{
	//	if (bIsFull)
	//	{
	//		this.m_mapItemInfo_Dan.Clear();
	//		this.m_mapItemInfo_Cai.Clear();
	//		this.m_mapItemInfo_Ta.Clear();
	//	}
	//	else if (tag == ItemCfgType.ITCT_PELLET)
	//	{
	//		this.m_mapItemInfo_Dan.Clear();
	//	}
	//	else if (tag == ItemCfgType.ITCT_STUFF)
	//	{
	//		this.m_mapItemInfo_Cai.Clear();
	//	}
	//	else if (tag == ItemCfgType.ITCT_OTHER)
	//	{
	//		this.m_mapItemInfo_Ta.Clear();
	//	}
	//	this.m_mapNowTypeGroup.Clear();
	//}

	//// Token: 0x06000CBB RID: 3259 RVA: 0x00065580 File Offset: 0x00063780
	//public void ClearList()
	//{
	//	PropsPlane.m_PropsList.ClearList(true);
	//	foreach (List<IUIListObject> list in this.m_mapUINowGroup.Values)
	//	{
	//		foreach (IUIListObject iuilistObject in list)
	//		{
	//			if (iuilistObject != null)
	//			{
	//				UnityEngine.Object.Destroy(iuilistObject.gameObject);
	//				iuilistObject.Delete();
	//				UnityEngine.Object.Destroy(iuilistObject.gameObject);
	//			}
	//		}
	//	}
	//	this.m_mapUINowGroup.Clear();
	//	foreach (GameObject gameObject in this.m_mapUITypeNode.Values)
	//	{
	//		UnityEngine.Object.Destroy(gameObject.gameObject);
	//	}
	//	this.m_mapUITypeNode.Clear();
	//	this.m_ptCmd.targetObj = null;
	//}

	//// Token: 0x06000CBC RID: 3260 RVA: 0x000656E0 File Offset: 0x000638E0
	//private void UpdateList(ItemCfgType tag)
	//{
	//	Dictionary<ulong, PropsPlane.PropItemInfo> dictionary;
	//	if (tag == ItemCfgType.ITCT_PELLET)
	//	{
	//		dictionary = this.m_mapItemInfo_Dan;
	//	}
	//	else if (tag == ItemCfgType.ITCT_STUFF)
	//	{
	//		dictionary = this.m_mapItemInfo_Cai;
	//	}
	//	else
	//	{
	//		if (tag != ItemCfgType.ITCT_OTHER)
	//		{
	//			return;
	//		}
	//		dictionary = this.m_mapItemInfo_Ta;
	//	}
	//	if (dictionary == null)
	//	{
	//		return;
	//	}
	//	this.m_mapNowTypeGroup.Clear();
	//	Color color = SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/item1").GetComponent<MeshRenderer>().material.color;
	//	Color color2 = SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/item2").GetComponent<MeshRenderer>().material.color;
	//	if (PropsPlane.m_keyAPath != "null" && PropsPlane.m_keyAPath != "GameLegend/Icon/Item/biglock")
	//	{
	//		PropsPlane.m_MecJoyKeyA.material.mainTexture = (Texture)ResourceLoader.Load(PropsPlane.m_keyAPath, typeof(Texture));
	//		if (PropsPlane.m_effAIndex == -1)
	//		{
	//			PropsPlane.m_effAIndex = Singleton<GUIEffectManager>.GetInstance().AddEffect(5, this.m_UIBT_JoyKeyA.transform, true);
	//		}
	//	}
	//	PropsPlane.m_MecJoyKeyA.material.SetColor("_Color", color);
	//	PropsPlane.m_MecJoyKeyB.material.SetColor("_Color", color2);
	//	if (dictionary == null || dictionary.Count <= 0)
	//	{
	//		return;
	//	}
	//	foreach (PropsPlane.PropItemInfo propItemInfo in dictionary.Values)
	//	{
	//		if (this.m_mapNowTypeGroup.ContainsKey(propItemInfo.ChildTypeID))
	//		{
	//			this.m_mapNowTypeGroup[propItemInfo.ChildTypeID].Add(propItemInfo);
	//			PropsPlane.PropItemInfo item;
	//			if (this.m_mapItemInfo_DiuQi.TryGetValue(propItemInfo.ITEM_STATIC_ID, out item))
	//			{
	//				this.m_mapNowTypeGroup[propItemInfo.ChildTypeID].Remove(item);
	//			}
	//		}
	//		else
	//		{
	//			List<PropsPlane.PropItemInfo> list = new List<PropsPlane.PropItemInfo>();
	//			list.Add(propItemInfo);
	//			this.m_mapNowTypeGroup.Add(propItemInfo.ChildTypeID, list);
	//			PropsPlane.PropItemInfo item;
	//			if (this.m_mapItemInfo_DiuQi.TryGetValue(propItemInfo.ITEM_STATIC_ID, out item))
	//			{
	//				this.m_mapNowTypeGroup[propItemInfo.ChildTypeID].Remove(item);
	//			}
	//		}
	//	}
	//	PropsPlane.m_PropsList.viewableArea.y = 11f - (float)this.m_mapNowTypeGroup.Count * 1.2f;
	//	PropsPlane.m_PropsList.SetupCameraAndSizes();
	//	foreach (KeyValuePair<int, List<PropsPlane.PropItemInfo>> keyValuePair in this.m_mapNowTypeGroup)
	//	{
	//		this.AddItem(keyValuePair.Key, keyValuePair.Value);
	//	}
	//	List<IUIListObject> list2 = new List<IUIListObject>();
	//	list2.Clear();
	//	foreach (KeyValuePair<int, GameObject> keyValuePair2 in this.m_mapUITypeNode)
	//	{
	//		Transform transform = keyValuePair2.Value.transform.FindChild("ItemCount");
	//		UIButton component = transform.transform.parent.FindChild("ItemNew").GetComponent<UIButton>();
	//		List<IUIListObject> list3;
	//		if (this.m_mapUINowGroup.ContainsKey(keyValuePair2.Key) && this.m_mapUINowGroup.TryGetValue(keyValuePair2.Key, out list3))
	//		{
	//			for (int i = 1; i <= list3.Count; i++)
	//			{
	//				IUIListObject iuilistObject = list3[list3.Count - i];
	//				char[] array = iuilistObject.name.ToCharArray();
	//				string text = string.Empty;
	//				for (int j = 0; j < iuilistObject.name.Length; j++)
	//				{
	//					if (j >= 8)
	//					{
	//						text += array[j];
	//					}
	//				}
	//				if (iuilistObject != null && !Player.Instance.m_RoleGrowDatas.m_PropItmeInfo_NEW.Contains(text))
	//				{
	//					list2.Add(iuilistObject);
	//				}
	//			}
	//			if (list2.Count > 0)
	//			{
	//				component.controlIsEnabled = true;
	//				component.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//				component.controlIsEnabled = false;
	//			}
	//			else
	//			{
	//				component.controlIsEnabled = true;
	//				component.SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//				component.controlIsEnabled = false;
	//				component.active = false;
	//			}
	//		}
	//		if (transform != null)
	//		{
	//			SpriteText component2 = transform.gameObject.GetComponent<SpriteText>();
	//			if (component2 != null && this.m_mapUINowGroup.ContainsKey(keyValuePair2.Key))
	//			{
	//				component2.Text = ((this.m_mapUINowGroup[keyValuePair2.Key].Count <= 0) ? string.Empty : ("(" + this.m_mapUINowGroup[keyValuePair2.Key].Count + ")"));
	//			}
	//		}
	//	}
	//	this.m_NowTag = tag;
	//	this.SelectOneItem();
	//}

	//// Token: 0x06000CBD RID: 3261 RVA: 0x00065C40 File Offset: 0x00063E40
	//private void PushData()
	//{
	//	Player player = (Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId);
	//	if (player == null)
	//	{
	//		return;
	//	}
	//	List<ItemCfgType> itemEnumGroup = GameData.Instance.ItemStaticMan.GetItemEnumGroup();
	//	if (itemEnumGroup == null || itemEnumGroup.Count <= 0)
	//	{
	//		return;
	//	}
	//	List<ulong> list = new List<ulong>();
	//	List<ATTRIBUTE_TYPE> list2 = new List<ATTRIBUTE_TYPE>();
	//	if (!this._isnew1)
	//	{
	//		this.m_UIBT_Cai.transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//	}
	//	if (!this._isnew2)
	//	{
	//		this.m_UIBT_Ta.transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//	}
	//	for (int i = 0; i < itemEnumGroup.Count; i++)
	//	{
	//		Dictionary<ulong, CItemBase> dictionary;
	//		if (player.ItemFolder.TryGetItemsData(itemEnumGroup[i], out dictionary))
	//		{
	//			if (dictionary != null && dictionary.Count > 0)
	//			{
	//				list.Clear();
	//				list.AddRange(dictionary.Keys);
	//				for (int j = 0; j < list.Count; j++)
	//				{
	//					list2.Clear();
	//					CItemBase citemBase = dictionary[list[j]];
	//					list2.Clear();
	//					string text = string.Empty;
	//					char[] array = list[j].ToString().ToCharArray();
	//					for (int k = 0; k < list[j].ToString().Length - 1; k++)
	//					{
	//						text += array[k];
	//					}
	//					if (text != "5030070")
	//					{
	//						this.AddData(GameData.Instance.ItemStaticMan.GetItemCfgTpyeByID(citemBase.TYPE_ID), citemBase);
	//						if (!this.m_addAtt.ContainsKey(text))
	//						{
	//							this.m_addAtt.Add(text, citemBase);
	//							if (GameData.Instance.ItemStaticMan.GetItemCfgTpyeByID(citemBase.TYPE_ID).ToString() == "ITCT_STUFF" && !Player.Instance.m_RoleGrowDatas.m_PropItmeInfo_NEW.Contains(citemBase.ITEM_STATIC_ID.ToString()))
	//							{
	//								this.m_UIBT_Cai.transform.FindChild("ItemNew").GetComponent<UIButton>().active = true;
	//								this.m_UIBT_Cai.transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = true;
	//								this.m_UIBT_Cai.transform.FindChild("ItemNew").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//								this.m_UIBT_Cai.transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = false;
	//							}
	//							else if (GameData.Instance.ItemStaticMan.GetItemCfgTpyeByID(citemBase.TYPE_ID).ToString() == "ITCT_OTHER" && !Player.Instance.m_RoleGrowDatas.m_PropItmeInfo_NEW.Contains(citemBase.ITEM_STATIC_ID.ToString()))
	//							{
	//								this.m_UIBT_Ta.transform.FindChild("ItemNew").GetComponent<UIButton>().active = true;
	//								this.m_UIBT_Ta.transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = true;
	//								this.m_UIBT_Ta.transform.FindChild("ItemNew").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//								this.m_UIBT_Ta.transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = false;
	//							}
	//						}
	//					}
	//				}
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06000CBE RID: 3262 RVA: 0x00065FF0 File Offset: 0x000641F0
	//public void ShowText(string force, string bourn, string postRecovery, string postAttack, string theuRecovery, string theuAttack, string metal, string wood, string water, string fire, string earth)
	//{
	//	if (PropsPlane.m_PlaneMid == null)
	//	{
	//		return;
	//	}
	//	PropsPlane.m_PlaneMid.transform.FindChild("JingJie").GetComponent<SpriteText>().Text = bourn;
	//	Player player = (Player)SceneManager.RoleMan.GetRole(1);
	//	if (player != null)
	//	{
	//		float num = (float)player.GetCurHp();
	//		float num2 = (float)player.GetMaxHp();
	//		int curHp = player.GetCurHp();
	//		PropsPlane.m_PlaneMid.transform.FindChild("HP").GetComponent<UIProgress>().Value = num / num2;
	//	}
	//	PropsPlane.m_PlaneMid.transform.FindChild("MP").GetComponent<UIProgress>().Value = Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._pMP.Value;
	//}

	//// Token: 0x06000CBF RID: 3263 RVA: 0x000660B0 File Offset: 0x000642B0
	//public void PushTextData()
	//{
	//	Player player = (Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId);
	//	if (player == null)
	//	{
	//		return;
	//	}
	//	if (!PropsPlane.m_PlaneObject.activeSelf)
	//	{
	//		return;
	//	}
	//	this.ShowText(Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_CRITICAL)).ToString() + "(" + Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_CRITCHANCE) * 100f).ToString() + "%)", AmbitSystem.GetLevelName(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_LEVEL)), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_PHY_DEF)).ToString(), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_PHY_ATK)).ToString(), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAG_DEF)).ToString(), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAG_ATK)).ToString(), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_METAL_ELEMENT)).ToString(), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_WOOD_ELEMENT)).ToString(), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_WATER_ELEMENT)).ToString(), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_FIRE_ELEMENT)).ToString(), Mathf.RoundToInt(player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT)).ToString());
	//}

	//// Token: 0x06000CC0 RID: 3264 RVA: 0x0006623C File Offset: 0x0006443C
	//public void OnJoyKeyLayer()
	//{
	//}

	//// Token: 0x06000CC1 RID: 3265 RVA: 0x00066240 File Offset: 0x00064440
	//public void OnEZCallBack()
	//{
	//}

	//// Token: 0x06000CC2 RID: 3266 RVA: 0x00066244 File Offset: 0x00064444
	//public void AdjustPosition()
	//{
	//	if (null == PropsPlane.m_PlaneObject)
	//	{
	//		return;
	//	}
	//	float width = PropsPlane.m_PlaneObject.transform.GetComponent<UIButton>().width;
	//	float height = PropsPlane.m_PlaneObject.transform.GetComponent<UIButton>().height;
	//	PropsPlane.m_PlaneObject.transform.position = base.Position(GUI_LAYER.UILAYER_ESC_CHILDPLANE, GUI_POS.UIPOS_MIDDLE, width, height);
	//	if (PropsPlane.m_PlaneMid != null)
	//	{
	//		float width2 = PropsPlane.m_PlaneMid.transform.GetComponent<UIButton>().width;
	//		float height2 = PropsPlane.m_PlaneMid.transform.GetComponent<UIButton>().height;
	//		PropsPlane.m_PlaneMid.transform.position = base.Position(GUI_LAYER.UILAYER_ESC_CHILD_CHILDPLANE, GUI_POS.UIPOS_MIDDLE, width2, height2);
	//	}
	//	Transform transform = PropsPlane.m_PlaneObject.transform.FindChild("RightLayer");
	//	if (transform != null)
	//	{
	//		float width3 = transform.GetComponent<UIButton>().width;
	//		float height3 = transform.GetComponent<UIButton>().height;
	//		transform.position = base.Position(GUI_LAYER.UILAYER_ESC_RL_CHILDPLANE, GUI_POS.UIPOS_RIGHT, width3, height3);
	//		transform.position = new Vector3(transform.position.x - 3.7f, transform.position.y - 0.07f, transform.position.z);
	//	}
	//	if (PropsPlane.m_PlaneLeft != null)
	//	{
	//		float width4 = PropsPlane.m_PlaneLeft.GetComponent<UIButton>().width;
	//		float height4 = PropsPlane.m_PlaneLeft.GetComponent<UIButton>().height;
	//		PropsPlane.m_PlaneLeft.transform.position = base.Position(GUI_LAYER.UILAYER_ESC_RL_CHILDPLANE, GUI_POS.UIPOS_LEFT, width4, height4);
	//		PropsPlane.m_PlaneLeft.transform.position = new Vector3(PropsPlane.m_PlaneLeft.transform.position.x + 6.5f, PropsPlane.m_PlaneLeft.transform.position.y - 0.07f, PropsPlane.m_PlaneLeft.transform.position.z);
	//	}
	//}

	//// Token: 0x06000CC3 RID: 3267 RVA: 0x0006644C File Offset: 0x0006464C
	//private void ChangeTag(ItemCfgType tag)
	//{
	//	this.ClearList();
	//	this.UpdateList(tag);
	//	this.m_rightFourMenu.CloseMenu(false);
	//}

	//// Token: 0x06000CC4 RID: 3268 RVA: 0x00066468 File Offset: 0x00064668
	//public void AddItem(int nTypeID, List<PropsPlane.PropItemInfo> infos)
	//{
	//	if ((Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId) == null)
	//	{
	//		return;
	//	}
	//	if (infos.Count <= 0)
	//	{
	//		return;
	//	}
	//	for (int i = 0; i < infos.Count; i++)
	//	{
	//		List<IUIListObject> list = this.LocateTypeNode(infos[i], i);
	//		if (list == null)
	//		{
	//			Logger.Log(new object[]
	//			{
	//				"null :" + infos.Count
	//			});
	//		}
	//		else
	//		{
	//			IUIListObject iuilistObject = this.AddItemChild(infos[i]);
	//			if (iuilistObject != null)
	//			{
	//				list.Add(iuilistObject);
	//				PropsPlane.m_PropsList.RemoveItem(iuilistObject, false);
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06000CC5 RID: 3269 RVA: 0x00066520 File Offset: 0x00064720
	//private IUIListObject AddItemChild(PropsPlane.PropItemInfo infos)
	//{
	//	if (null == this.m_ListChildPrefab)
	//	{
	//		Logger.LogError(new object[]
	//		{
	//			"Prop Plane List Child Prefab Error!"
	//		});
	//		return null;
	//	}
	//	string name = "Child_" + infos.ChildTypeID.ToString() + "_" + infos.ITEM_STATIC_ID.ToString();
	//	IUIListObject iuilistObject = PropsPlane.m_PropsList.CreateItem(this.m_ListChildPrefab);
	//	iuilistObject.Data = infos;
	//	iuilistObject.gameObject.name = name;
	//	EventEZMsg @object = base.RegisterChildEZMsg(GUI_TYPE.UICMD_NONE, infos.ITEM_STATIC_ID.ToString());
	//	iuilistObject.AddInputDelegate(new EZInputDelegate(@object.OnCallBackMethod));
	//	Transform transform = iuilistObject.transform.FindChild("ItemCount");
	//	if (transform != null)
	//	{
	//		SpriteText component = transform.GetComponent<SpriteText>();
	//		if (component != null)
	//		{
	//			component.Text = infos.Count.ToString();
	//		}
	//	}
	//	Transform transform2 = iuilistObject.transform.FindChild("ItemName");
	//	if (transform2 != null)
	//	{
	//		SpriteText component2 = transform2.GetComponent<SpriteText>();
	//		if (component2 != null)
	//		{
	//			component2.Text = infos.Name;
	//		}
	//		iuilistObject.transform.FindChild("ItemIcoBack").GetComponent<MeshRenderer>().material.color = new Color(0.2f, 0.9f, 0.8f);
	//		component2.GetComponent<MeshRenderer>().material.color = new Color(0.2f, 0.9f, 0.8f);
	//		if (infos.TypeID == 4)
	//		{
	//			iuilistObject.transform.FindChild("ItemIcoBack").GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f);
	//			component2.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f);
	//		}
	//		for (int i = 0; i < Player.Instance.m_cMixtureSmelt.MixtureDatas.Count; i++)
	//		{
	//			if (infos.ITEM_STATIC_ID.ToString().Contains(Player.Instance.m_cMixtureSmelt.MixtureDatas[i].ID.ToString()) && Player.Instance.m_cMixtureSmelt.MixtureDatas[i].Type.ToString() == "MIT_PILL")
	//			{
	//				iuilistObject.transform.FindChild("ItemIcoBack").GetComponent<MeshRenderer>().material.color = new Color(0.2f, 0.7f, 0.2f);
	//				component2.GetComponent<MeshRenderer>().material.color = new Color(0.2f, 0.7f, 0.2f);
	//			}
	//			if (infos.ITEM_STATIC_ID.ToString().Contains(Player.Instance.m_cMixtureSmelt.MixtureDatas[i].ID.ToString()) && Player.Instance.m_cMixtureSmelt.MixtureDatas[i].Type.ToString() == "MIT_AMULET")
	//			{
	//				iuilistObject.transform.FindChild("ItemIcoBack").GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.9f);
	//				component2.GetComponent<MeshRenderer>().material.color = new Color(0.3f, 0.3f, 0.9f);
	//			}
	//		}
	//	}
	//	Transform transform3 = iuilistObject.transform.FindChild("IcoPar").FindChild("Ico");
	//	if (transform3 != null)
	//	{
	//		Material material = transform3.renderer.material;
	//		GameData.Instance.ItemStaticMan.ItemAtlasMan.SetImgInAtlasByEZGUI(infos.ITEM_STATIC_ID, ref material);
	//		transform3.renderer.material = material;
	//	}
	//	ulong item_STATIC_ID = infos.ITEM_STATIC_ID;
	//	Color color = PropsPlane.m_MecJoyKeyA.material.color;
	//	Color color2 = PropsPlane.m_MecJoyKeyB.material.color;
	//	if (item_STATIC_ID == PropsPlane.m_keyA)
	//	{
	//		PropsPlane.m_pointerA.targetObj = iuilistObject;
	//		PropsPlane.m_pointerA.targetObj.Data = infos;
	//		PropsPlane.m_AValue.Text = infos.Count.ToString();
	//		Player.Instance.m_RoleGrowDatas.E = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID;
	//	}
	//	else if (item_STATIC_ID == PropsPlane.m_keyB)
	//	{
	//		PropsPlane.m_pointerB.targetObj = iuilistObject;
	//		PropsPlane.m_pointerB.targetObj.Data = infos;
	//		PropsPlane.m_BValue.Text = infos.Count.ToString();
	//		Player.Instance.m_RoleGrowDatas.R = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID;
	//	}
	//	if (PropsPlane.m_pointerA.targetObj != null && item_STATIC_ID == ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID && color == PropsPlane.m_proA)
	//	{
	//		PropsPlane.m_pointerA.targetObj.Data = infos;
	//		if (((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).Count > 0)
	//		{
	//			PropsPlane.m_AValue.Text = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).Count.ToString();
	//			PropsPlane.m_pointerA.targetObj = iuilistObject;
	//			Color color3 = new Color(0.43f, 0.43f, 0.43f, 255f);
	//			PropsPlane.m_MecJoyKeyA.material.SetColor("_Color", color3);
	//			PropsPlane.m_keyA = infos.ITEM_STATIC_ID;
	//			Player.Instance.m_RoleGrowDatas.E = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID;
	//			if (SkillUIManager.instance != null)
	//			{
	//				SkillUIManager.instance.SetOneItemTexture(0, infos.IcoPath, false, TYPE.ITEM_TYPE);
	//				PropsPlane.m_keyAPath = infos.IcoPath;
	//			}
	//		}
	//	}
	//	if (PropsPlane.m_pointerB.targetObj != null && item_STATIC_ID == ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID && color2 == PropsPlane.m_proB)
	//	{
	//		PropsPlane.m_pointerB.targetObj.Data = infos;
	//		if (((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).Count > 0)
	//		{
	//			PropsPlane.m_BValue.Text = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).Count.ToString();
	//			PropsPlane.m_pointerB.targetObj = iuilistObject;
	//			Color color4 = new Color(0.43f, 0.43f, 0.43f, 255f);
	//			PropsPlane.m_MecJoyKeyB.material.SetColor("_Color", color4);
	//			PropsPlane.m_keyB = infos.ITEM_STATIC_ID;
	//			Player.Instance.m_RoleGrowDatas.R = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID;
	//			if (SkillUIManager.instance != null)
	//			{
	//				SkillUIManager.instance.SetOneItemTexture(1, infos.IcoPath, false, TYPE.ITEM_TYPE);
	//				PropsPlane.m_keyBPath = infos.IcoPath;
	//			}
	//		}
	//	}
	//	return iuilistObject;
	//}

	//// Token: 0x06000CC6 RID: 3270 RVA: 0x00066C9C File Offset: 0x00064E9C
	//private List<IUIListObject> LocateTypeNode(PropsPlane.PropItemInfo typeinfos, int i)
	//{
	//	if (null == this.m_ListParentPrefab)
	//	{
	//		Logger.LogError(new object[]
	//		{
	//			"Prop Plane List Child Prefab Error!"
	//		});
	//		return null;
	//	}
	//	GameObject gameObject = null;
	//	List<IUIListObject> list;
	//	if (!this.m_mapUINowGroup.TryGetValue(typeinfos.ChildTypeID, out list))
	//	{
	//		string text = typeinfos.ChildTypeID.ToString() + "_" + typeinfos.ITEM_STATIC_ID.ToString();
	//		if (typeinfos.ChildTypeID == 1)
	//		{
	//			gameObject = (UnityEngine.Object.Instantiate(this.m_ListParentPrefab) as GameObject);
	//			gameObject.transform.parent = PropsPlane.m_PlaneObject.transform.FindChild("RightLayer").transform;
	//			gameObject.transform.FindChild("ItemName").GetComponent<SpriteText>().Text = typeinfos.ParName;
	//			gameObject.transform.position = new Vector3(gameObject.transform.parent.transform.position.x - 0.03799438f, gameObject.transform.parent.transform.position.y + 4.63f, gameObject.transform.parent.transform.position.z - 0.5f);
	//		}
	//		else if (typeinfos.ChildTypeID == 2)
	//		{
	//			gameObject = (UnityEngine.Object.Instantiate(this.m_ListParentPrefab) as GameObject);
	//			gameObject.transform.parent = PropsPlane.m_PlaneObject.transform.FindChild("RightLayer").transform;
	//			gameObject.transform.FindChild("ItemName").GetComponent<SpriteText>().Text = typeinfos.ParName;
	//			gameObject.transform.position = new Vector3(gameObject.transform.parent.transform.position.x - 0.03799438f, gameObject.transform.parent.transform.position.y + 3.945f, gameObject.transform.parent.transform.position.z - 0.5f);
	//		}
	//		else if (typeinfos.ChildTypeID == 3)
	//		{
	//			gameObject = (UnityEngine.Object.Instantiate(this.m_ListParentPrefab) as GameObject);
	//			gameObject.transform.parent = PropsPlane.m_PlaneObject.transform.FindChild("RightLayer").transform;
	//			gameObject.transform.FindChild("ItemName").GetComponent<SpriteText>().Text = typeinfos.ParName;
	//			gameObject.transform.position = new Vector3(gameObject.transform.parent.transform.position.x - 0.03799438f, gameObject.transform.parent.transform.position.y + 3.26f, gameObject.transform.parent.transform.position.z - 0.5f);
	//		}
	//		if (gameObject == null)
	//		{
	//			Logger.LogError(new object[]
	//			{
	//				"Prop CreatParentItem failed! Info: " + text
	//			});
	//			return null;
	//		}
	//		gameObject.gameObject.name = text;
	//		this.m_mapUITypeNode.Add(typeinfos.ChildTypeID, gameObject);
	//		Transform transform = gameObject.transform.FindChild("ItemBtn");
	//		if (transform != null)
	//		{
	//			UIStateToggleBtn component = transform.GetComponent<UIStateToggleBtn>();
	//			if (component != null)
	//			{
	//				component.data = typeinfos;
	//				component.AddValueChangedDelegate(new EZValueChangedDelegate(this.ToggleParent));
	//			}
	//		}
	//		list = new List<IUIListObject>();
	//		this.m_mapUINowGroup.Add(typeinfos.ChildTypeID, list);
	//	}
	//	return list;
	//}

	//// Token: 0x06000CC7 RID: 3271 RVA: 0x00067060 File Offset: 0x00065260
	//private void UpdateParentPos()
	//{
	//	Vector3 position = PropsPlane.m_PlaneObject.transform.FindChild("RightLayer").transform.position;
	//	Dictionary<int, GameObject> dictionary = new Dictionary<int, GameObject>();
	//	if (this.m_mapUITypeNode.Count == 3)
	//	{
	//		GameObject value;
	//		if (this.m_mapUITypeNode.ContainsKey(1) && this.m_mapUITypeNode.TryGetValue(1, out value))
	//		{
	//			dictionary.Add(1, value);
	//		}
	//		if (this.m_mapUITypeNode.ContainsKey(2) && this.m_mapUITypeNode.TryGetValue(2, out value))
	//		{
	//			dictionary.Add(2, value);
	//		}
	//		if (this.m_mapUITypeNode.ContainsKey(3) && this.m_mapUITypeNode.TryGetValue(3, out value))
	//		{
	//			dictionary.Add(3, value);
	//		}
	//	}
	//	if (this.m_mapUITypeNode.Count == 2)
	//	{
	//		GameObject value;
	//		if (this.m_mapUITypeNode.ContainsKey(1) && this.m_mapUITypeNode.TryGetValue(1, out value))
	//		{
	//			dictionary.Add(1, value);
	//		}
	//		if (this.m_mapUITypeNode.ContainsKey(2) && this.m_mapUITypeNode.TryGetValue(2, out value))
	//		{
	//			if (dictionary.ContainsKey(1))
	//			{
	//				dictionary.Add(2, value);
	//			}
	//			else
	//			{
	//				dictionary.Add(1, value);
	//			}
	//		}
	//		if (this.m_mapUITypeNode.ContainsKey(3) && this.m_mapUITypeNode.TryGetValue(3, out value))
	//		{
	//			dictionary.Add(2, value);
	//		}
	//	}
	//	if (this.m_mapUITypeNode.Count == 1)
	//	{
	//		GameObject value;
	//		if (this.m_mapUITypeNode.ContainsKey(1) && this.m_mapUITypeNode.TryGetValue(1, out value))
	//		{
	//			dictionary.Add(1, value);
	//		}
	//		if (this.m_mapUITypeNode.ContainsKey(2) && this.m_mapUITypeNode.TryGetValue(2, out value))
	//		{
	//			dictionary.Add(1, value);
	//		}
	//		if (this.m_mapUITypeNode.ContainsKey(3) && this.m_mapUITypeNode.TryGetValue(3, out value))
	//		{
	//			dictionary.Add(1, value);
	//		}
	//	}
	//	for (int i = 1; i <= dictionary.Count; i++)
	//	{
	//		if (dictionary.ContainsKey(i))
	//		{
	//			dictionary[i].transform.position = new Vector3(position.x - 0.03799438f, position.y + (4.63f - 0.685f * (float)(i - 1)), position.z - 0.5f);
	//		}
	//	}
	//}

	//// Token: 0x06000CC8 RID: 3272 RVA: 0x000672E0 File Offset: 0x000654E0
	//private void UpdateListPos(int childId, List<IUIListObject> parentLists)
	//{
	//	GameObject gameObject;
	//	if (this.m_mapUITypeNode.TryGetValue(childId, out gameObject))
	//	{
	//		PropsPlane.m_PropsList.viewableArea.y = 11f - (float)this.m_mapUITypeNode.Count * 0.685f;
	//		PropsPlane.m_PropsList.SetupCameraAndSizes();
	//		PropsPlane.m_PropsList.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.3425f - PropsPlane.m_PropsList.viewableArea.y / 2f, gameObject.transform.position.z + 0.2f);
	//		for (int i = 1; i <= this.m_mapUITypeNode.Count; i++)
	//		{
	//			GameObject gameObject2;
	//			if (this.m_mapUITypeNode.TryGetValue(i, out gameObject2))
	//			{
	//				if (i > childId && i <= childId + 1)
	//				{
	//					GameObject gameObject3;
	//					if (this.m_mapUITypeNode.TryGetValue(i - 1, out gameObject3))
	//					{
	//						if ((float)parentLists.Count * (1.3f + PropsPlane.m_PropsList.itemSpacing) < PropsPlane.m_PropsList.viewableArea.y)
	//						{
	//							if (parentLists.Count == 5)
	//							{
	//								gameObject2.transform.localPosition = new Vector3(gameObject3.transform.localPosition.x, gameObject3.transform.localPosition.y - (float)(parentLists.Count + 1) * (1.3f + PropsPlane.m_PropsList.itemSpacing) - 1.3f, gameObject3.transform.localPosition.z);
	//							}
	//							if (parentLists.Count == 4)
	//							{
	//								gameObject2.transform.localPosition = new Vector3(gameObject3.transform.localPosition.x, gameObject3.transform.localPosition.y - (float)(parentLists.Count + 1) * (1.3f + PropsPlane.m_PropsList.itemSpacing) - 1f, gameObject3.transform.localPosition.z);
	//							}
	//							if (parentLists.Count == 3)
	//							{
	//								gameObject2.transform.localPosition = new Vector3(gameObject3.transform.localPosition.x, gameObject3.transform.localPosition.y - (float)(parentLists.Count + 1) * (1.3f + PropsPlane.m_PropsList.itemSpacing) - 0.5f, gameObject3.transform.localPosition.z);
	//							}
	//							else if (parentLists.Count != 5 && parentLists.Count != 4 && parentLists.Count != 3)
	//							{
	//								gameObject2.transform.localPosition = new Vector3(gameObject3.transform.localPosition.x, gameObject3.transform.localPosition.y - (float)(parentLists.Count + 1) * (1.3f + PropsPlane.m_PropsList.itemSpacing), gameObject3.transform.localPosition.z);
	//							}
	//						}
	//						else
	//						{
	//							gameObject2.transform.localPosition = new Vector3(gameObject3.transform.localPosition.x, gameObject3.transform.localPosition.y - 0.685f - PropsPlane.m_PropsList.viewableArea.y, gameObject3.transform.localPosition.z);
	//						}
	//					}
	//				}
	//				else
	//				{
	//					GameObject gameObject4;
	//					if (this.m_mapUITypeNode.TryGetValue(i - 1, out gameObject4))
	//					{
	//						gameObject2.transform.localPosition = new Vector3(gameObject4.transform.localPosition.x, gameObject4.transform.localPosition.y - 0.685f, gameObject4.transform.localPosition.z);
	//					}
	//					if ((childId < 3 && this.m_mapUITypeNode.ContainsKey(i + 1) && this.m_mapUITypeNode.TryGetValue(i + 1, out gameObject4)) || (childId < 3 && this.m_mapUITypeNode.ContainsKey(i + 2) && this.m_mapUITypeNode.TryGetValue(i + 2, out gameObject4)))
	//					{
	//						if ((float)parentLists.Count * (1.3f + PropsPlane.m_PropsList.itemSpacing) < PropsPlane.m_PropsList.viewableArea.y)
	//						{
	//							if (parentLists.Count == 5)
	//							{
	//								gameObject4.transform.localPosition = new Vector3(gameObject4.transform.localPosition.x, gameObject2.transform.localPosition.y - (float)(parentLists.Count + 1) * (1.3f + PropsPlane.m_PropsList.itemSpacing) - 1.4f, gameObject4.transform.localPosition.z);
	//							}
	//							if (parentLists.Count == 4)
	//							{
	//								gameObject4.transform.localPosition = new Vector3(gameObject4.transform.localPosition.x, gameObject2.transform.localPosition.y - (float)(parentLists.Count + 1) * (1.3f + PropsPlane.m_PropsList.itemSpacing) - 1.1f, gameObject4.transform.localPosition.z);
	//							}
	//							if (parentLists.Count == 3)
	//							{
	//								gameObject4.transform.localPosition = new Vector3(gameObject4.transform.localPosition.x, gameObject2.transform.localPosition.y - (float)(parentLists.Count + 1) * (1.3f + PropsPlane.m_PropsList.itemSpacing) - 0.5f, gameObject4.transform.localPosition.z);
	//							}
	//							else if (parentLists.Count != 5 && parentLists.Count != 4 && parentLists.Count != 3)
	//							{
	//								gameObject4.transform.localPosition = new Vector3(gameObject4.transform.localPosition.x, gameObject2.transform.localPosition.y - (float)(parentLists.Count + 1) * (1.3f + PropsPlane.m_PropsList.itemSpacing), gameObject4.transform.localPosition.z);
	//							}
	//						}
	//						else
	//						{
	//							gameObject4.transform.localPosition = new Vector3(gameObject4.transform.localPosition.x, gameObject2.transform.localPosition.y - 0.685f - PropsPlane.m_PropsList.viewableArea.y, gameObject4.transform.localPosition.z);
	//						}
	//					}
	//				}
	//			}
	//		}
	//	}
	//	PropsPlane.m_PropsList.viewableArea.y = 11f - (float)this.m_mapUITypeNode.Count * 0.685f;
	//	PropsPlane.m_PropsList.SetupCameraAndSizes();
	//	PropsPlane.m_PropsList.slider.transform.position = new Vector3(this.m_UIC_TopSlider.transform.position.x, this.m_UIC_TopSlider.transform.position.y - this.m_UIC_TopSlider.height - PropsPlane.m_PropsList.slider.width / 2f, this.m_UIC_TopSlider.transform.position.z);
	//}

	//// Token: 0x06000CC9 RID: 3273 RVA: 0x00067AA4 File Offset: 0x00065CA4
	//private void ToggleParent(IUIObject parentitem)
	//{
	//	if (parentitem == null || parentitem.gameObject == null)
	//	{
	//		return;
	//	}
	//	UIStateToggleBtn component = parentitem.gameObject.GetComponent<UIStateToggleBtn>();
	//	if (component == null)
	//	{
	//		return;
	//	}
	//	PropsPlane.PropItemInfo propItemInfo = (PropsPlane.PropItemInfo)component.Data;
	//	this.SetSound(true, 5006, EZGUIManager._aTagTwo, null, null, component);
	//	List<IUIListObject> list;
	//	if (this.m_mapUINowGroup.TryGetValue(propItemInfo.ChildTypeID, out list))
	//	{
	//		if (component.StateNum == 1)
	//		{
	//			foreach (IUIListObject item in list)
	//			{
	//				this.m_rightFourMenu.CloseMenu(false);
	//				PropsPlane.m_PropsList.RemoveItem(item, false);
	//			}
	//			this.UpdateParentPos();
	//			this.m_bPos = false;
	//		}
	//		else
	//		{
	//			UIButton component2 = component.gameObject.transform.parent.FindChild("ItemNew").GetComponent<UIButton>();
	//			if (component2.active)
	//			{
	//				component2.active = false;
	//			}
	//			this.m_count = list.Count;
	//			PropsPlane.m_PropsList.viewableArea.y = 11f - (float)this.m_mapUITypeNode.Count * 0.685f;
	//			PropsPlane.m_PropsList.SetupCameraAndSizes();
	//			this.UpdateParentPos();
	//			foreach (int num in this.m_mapUINowGroup.Keys)
	//			{
	//				List<IUIListObject> list2;
	//				if (num != propItemInfo.ChildTypeID && this.m_mapUINowGroup.TryGetValue(num, out list2))
	//				{
	//					foreach (IUIListObject item2 in list2)
	//					{
	//						this.m_rightFourMenu.CloseMenu(false);
	//						PropsPlane.m_PropsList.RemoveItem(item2, false);
	//						foreach (int num2 in this.m_mapUITypeNode.Keys)
	//						{
	//							GameObject gameObject;
	//							if (num2 != propItemInfo.ChildTypeID && this.m_mapUITypeNode.TryGetValue(num2, out gameObject))
	//							{
	//								UIStateToggleBtn component3 = gameObject.gameObject.transform.FindChild("ItemBtn").GetComponent<UIStateToggleBtn>();
	//								component3.curStateIndex = 1;
	//								component3.SetToggleState(1);
	//								this.SetSound(true, 5006, EZGUIManager._aTagTwo, null, null, component3);
	//							}
	//						}
	//					}
	//				}
	//			}
	//			this._list_new.Clear();
	//			this._list_old.Clear();
	//			for (int i = 1; i <= list.Count; i++)
	//			{
	//				IUIListObject iuilistObject = list[list.Count - i];
	//				if (iuilistObject != null)
	//				{
	//					char[] array = iuilistObject.name.ToCharArray();
	//					string text = string.Empty;
	//					for (int j = 0; j < iuilistObject.name.Length; j++)
	//					{
	//						if (j >= 8)
	//						{
	//							text += array[j];
	//						}
	//					}
	//					if (Player.Instance.m_RoleGrowDatas.m_PropItmeInfo_NEW.Contains(text))
	//					{
	//						this._list_old.Add(iuilistObject);
	//					}
	//					else
	//					{
	//						this._list_new.Add(iuilistObject);
	//					}
	//				}
	//			}
	//			if (this._list_new.Count > 0)
	//			{
	//				for (int k = 1; k <= this._list_new.Count; k++)
	//				{
	//					PropsPlane.m_PropsList.InsertItem(this._list_new[k - 1], k);
	//					this._list_new[k - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = true;
	//					this._list_new[k - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//					this._list_new[k - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = false;
	//				}
	//				for (int l = 1; l <= this._list_old.Count; l++)
	//				{
	//					PropsPlane.m_PropsList.InsertItem(this._list_old[l - 1], this._list_new.Count + l);
	//					this._list_old[l - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = true;
	//					this._list_old[l - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//					this._list_old[l - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = false;
	//					this._list_old[l - 1].transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//				}
	//			}
	//			else
	//			{
	//				for (int m = 1; m <= list.Count; m++)
	//				{
	//					IUIListObject iuilistObject2 = list[m - 1];
	//					if (iuilistObject2 != null)
	//					{
	//						iuilistObject2.transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = true;
	//						iuilistObject2.transform.FindChild("ItemNew").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//						iuilistObject2.transform.FindChild("ItemNew").GetComponent<UIButton>().controlIsEnabled = false;
	//						iuilistObject2.transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//						PropsPlane.m_PropsList.InsertItem(iuilistObject2, m);
	//					}
	//				}
	//			}
	//			if (list.Count != 0)
	//			{
	//				this.UpdateListPos(propItemInfo.ChildTypeID, list);
	//			}
	//			this.m_bPos = true;
	//		}
	//	}
	//	if (list.Count < 6)
	//	{
	//		PropsPlane.m_PropsList.slider.transform.active = false;
	//		this.m_UIC_TopSlider.active = false;
	//		this.m_UIC_BottomSlider.active = false;
	//	}
	//	else
	//	{
	//		PropsPlane.m_PropsList.slider.transform.active = true;
	//		this.m_UIC_TopSlider.active = true;
	//		this.m_UIC_BottomSlider.active = true;
	//	}
	//}

	//// Token: 0x06000CCA RID: 3274 RVA: 0x00068170 File Offset: 0x00066370
	//public void SelectOneItem()
	//{
	//	if (null == PropsPlane.m_PropsList)
	//	{
	//		return;
	//	}
	//	PropsPlane.PropItemInfo propItemInfo = null;
	//	Dictionary<ulong, PropsPlane.PropItemInfo> dictionary;
	//	if (this.m_NowTag == ItemCfgType.ITCT_PELLET)
	//	{
	//		dictionary = this.m_mapItemInfo_Dan;
	//	}
	//	else if (this.m_NowTag == ItemCfgType.ITCT_STUFF)
	//	{
	//		dictionary = this.m_mapItemInfo_Cai;
	//	}
	//	else
	//	{
	//		if (this.m_NowTag != ItemCfgType.ITCT_OTHER)
	//		{
	//			return;
	//		}
	//		dictionary = this.m_mapItemInfo_Ta;
	//	}
	//	if (dictionary == null || dictionary.Count <= 0)
	//	{
	//		return;
	//	}
	//	using (Dictionary<ulong, PropsPlane.PropItemInfo>.ValueCollection.Enumerator enumerator = dictionary.Values.GetEnumerator())
	//	{
	//		if (enumerator.MoveNext())
	//		{
	//			PropsPlane.PropItemInfo propItemInfo2 = enumerator.Current;
	//			propItemInfo = propItemInfo2;
	//		}
	//	}
	//	if (PropsPlane.m_PropsList.Count > 0)
	//	{
	//		POINTER_INFO ptCmd = default(POINTER_INFO);
	//		ptCmd.targetObj = PropsPlane.m_PropsList.GetItem(0);
	//		this.m_ptCmd.targetObj = null;
	//		this.OnLCick(ptCmd, propItemInfo.Name);
	//		this.m_ptCmd = ptCmd;
	//	}
	//}

	//// Token: 0x06000CCB RID: 3275 RVA: 0x00068294 File Offset: 0x00066494
	//private void setTopButton()
	//{
	//	foreach (UIButton uibutton in this.m_topButton.Values)
	//	{
	//		uibutton.controlIsEnabled = true;
	//		uibutton.SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//	}
	//}

	//// Token: 0x06000CCC RID: 3276 RVA: 0x00068308 File Offset: 0x00066508
	//private void OnCallBackDan(ref POINTER_INFO pt)
	//{
	//	POINTER_INFO.INPUT_EVENT evt = pt.evt;
	//	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
	//	{
	//		this.ChangeTag(ItemCfgType.ITCT_PELLET);
	//		this.setTopButton();
	//		this.m_UIBT_Dan.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//		this.m_UIBT_Dan.controlIsEnabled = false;
	//		this.SetSound(true, 5007, EZGUIManager._aTagOne, null, null, null);
	//	}
	//}

	//// Token: 0x06000CCD RID: 3277 RVA: 0x00068368 File Offset: 0x00066568
	//private void OnCallBackCai(ref POINTER_INFO pt)
	//{
	//	POINTER_INFO.INPUT_EVENT evt = pt.evt;
	//	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
	//	{
	//		this.ChangeTag(ItemCfgType.ITCT_STUFF);
	//		this.setTopButton();
	//		this.m_UIBT_Cai.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//		this.m_UIBT_Cai.controlIsEnabled = false;
	//		this.m_UIBT_Cai.transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//		this._isnew1 = false;
	//		this.SetSound(true, 5007, EZGUIManager._aTagOne, null, null, null);
	//	}
	//}

	//// Token: 0x06000CCE RID: 3278 RVA: 0x000683F0 File Offset: 0x000665F0
	//private void OnCallBackTa(ref POINTER_INFO pt)
	//{
	//	POINTER_INFO.INPUT_EVENT evt = pt.evt;
	//	if (evt == POINTER_INFO.INPUT_EVENT.TAP)
	//	{
	//		this.ChangeTag(ItemCfgType.ITCT_OTHER);
	//		this.setTopButton();
	//		this.m_UIBT_Ta.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//		this.m_UIBT_Ta.controlIsEnabled = false;
	//		this.m_UIBT_Ta.transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//		this._isnew2 = false;
	//		this.SetSound(true, 5007, EZGUIManager._aTagOne, null, null, null);
	//	}
	//}

	//// Token: 0x06000CCF RID: 3279 RVA: 0x00068478 File Offset: 0x00066678
	//public override int OnChildEZMessage(GUI_TYPE type, string key, POINTER_INFO ptCmd)
	//{
	//	if (key == null || ptCmd.targetObj == null)
	//	{
	//		return 0;
	//	}
	//	switch (ptCmd.evt)
	//	{
	//	case POINTER_INFO.INPUT_EVENT.PRESS:
	//		PropsPlane.m_PropsList.touchScroll = true;
	//		if (PropsPlane.m_MedicineObject.active)
	//		{
	//			PropsPlane.m_MedicineObject.SetActiveRecursively(false);
	//		}
	//		this.m_bDragSound = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.TAP:
	//	{
	//		if (PropsPlane.m_MedicineObject.active)
	//		{
	//			PropsPlane.m_MedicineObject.SetActiveRecursively(false);
	//		}
	//		bool flag = Time.fixedTime - this.fLastTimer <= this.fSpaceTimer && key == this.fLastKey;
	//		this.OnLCick(ptCmd, key);
	//		if (flag)
	//		{
	//			foreach (List<IUIListObject> list in this.m_mapUINowGroup.Values)
	//			{
	//				for (int i = 0; i < list.Count; i++)
	//				{
	//					if (list[i].transform.name == ptCmd.targetObj.transform.name)
	//					{
	//						PropsPlane.PropItemInfo propItemInfo = (PropsPlane.PropItemInfo)list[i].Data;
	//						if (propItemInfo.ParName == "仙符" || propItemInfo.ParName == "强攻" || propItemInfo.ParName == "刚御")
	//						{
	//							this.OnDLCick(ptCmd, key);
	//						}
	//					}
	//				}
	//			}
	//		}
	//		this.fLastKey = key;
	//		this.fLastTimer = Time.fixedTime;
	//		this.m_rightFourMenu.CloseMenu(false);
	//		break;
	//	}
	//	case POINTER_INFO.INPUT_EVENT.MOVE:
	//		foreach (List<IUIListObject> list2 in this.m_mapUINowGroup.Values)
	//		{
	//			for (int j = 0; j < list2.Count; j++)
	//			{
	//				if (list2[j].transform.name == ptCmd.targetObj.transform.name)
	//				{
	//					list2[j].transform.FindChild("IcoPar").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.OVER);
	//					Transform transform = list2[j].transform.FindChild("ItemNew");
	//					if (!(transform == null))
	//					{
	//						UIButton component = transform.GetComponent<UIButton>();
	//						PropsPlane.PropItemInfo propItemInfo2 = (PropsPlane.PropItemInfo)list2[j].Data;
	//						component.controlIsEnabled = true;
	//						component.SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//						component.controlIsEnabled = false;
	//						component.active = false;
	//						if (!this.m_mapItmeInfo_NEW.ContainsKey(ptCmd.targetObj.transform.name))
	//						{
	//							this.m_mapItmeInfo_NEW.Add(ptCmd.targetObj.transform.name, list2[j]);
	//							Player.Instance.m_RoleGrowDatas.m_PropItmeInfo_NEW.Add(propItemInfo2.ITEM_STATIC_ID.ToString());
	//							if (this._list_new.Contains(list2[j]))
	//							{
	//								this._list_new.Remove(list2[j]);
	//							}
	//						}
	//					}
	//				}
	//				else
	//				{
	//					list2[j].transform.FindChild("IcoPar").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//				}
	//			}
	//		}
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.MOVE_OFF:
	//		PropsPlane.m_PropsList.touchScroll = true;
	//		if (PropsPlane.m_MedicineObject.active)
	//		{
	//			PropsPlane.m_MedicineObject.SetActiveRecursively(false);
	//		}
	//		this.m_bDragSound = false;
	//		foreach (List<IUIListObject> list3 in this.m_mapUINowGroup.Values)
	//		{
	//			for (int k = 0; k < list3.Count; k++)
	//			{
	//				if (list3[k].transform.name == ptCmd.targetObj.transform.name)
	//				{
	//					list3[k].transform.FindChild("IcoPar").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//				}
	//			}
	//		}
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.RELEASE_OFF:
	//		PropsPlane.m_PropsList.touchScroll = true;
	//		this.TextureShow(ptCmd);
	//		if (PropsPlane.m_MedicineObject.active)
	//		{
	//			PropsPlane.m_MedicineObject.SetActiveRecursively(false);
	//		}
	//		this.m_bDragSound = false;
	//		EZGUIManager.SetSoundEx(5016, EZGUIManager._aDragItem);
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.DRAG:
	//		PropsPlane.m_PropsList.touchScroll = false;
	//		this.OnLDrag(ptCmd);
	//		if (!this.m_bDragSound)
	//		{
	//			EZGUIManager.SetSoundEx(5016, EZGUIManager._aDragItem);
	//			this.m_bDragSound = true;
	//		}
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.MOUSE_RIGHT_TAP:
	//	{
	//		ulong num = ulong.Parse(key);
	//		Vector3 point = ptCmd.hitInfo.point;
	//		PropsPlane.m_pointer = ptCmd;
	//		if (this.m_ptCmd.targetObj != ptCmd.targetObj)
	//		{
	//			if (ptCmd.targetObj.transform.FindChild("IcoPar") != null)
	//			{
	//				UIButton component2 = ptCmd.targetObj.transform.FindChild("IcoPar").GetComponent<UIButton>();
	//				component2.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//				ptCmd.targetObj.transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//				component2.controlIsEnabled = false;
	//				ptCmd.targetObj.transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().controlIsEnabled = false;
	//			}
	//			if (this.m_ptCmd.targetObj != null && this.m_ptCmd.targetObj.transform != null && this.m_ptCmd.targetObj.gameObject != null && this.m_ptCmd.targetObj.transform != null && this.m_ptCmd.targetObj.transform.FindChild("IcoPar") != null)
	//			{
	//				UIButton component3 = this.m_ptCmd.targetObj.transform.FindChild("IcoPar").GetComponent<UIButton>();
	//				component3.controlIsEnabled = true;
	//				component3.SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//				ptCmd.targetObj.transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//				ptCmd.targetObj.transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().controlIsEnabled = true;
	//			}
	//			this.m_ptCmd = ptCmd;
	//		}
	//		if (num < 3000000UL)
	//		{
	//			this.OpenRightMenu("4", ptCmd, num);
	//		}
	//		else if (num > 3000000UL && num < 4000000UL)
	//		{
	//			this.OpenRightMenu("1", ptCmd, num);
	//		}
	//		else
	//		{
	//			this.OpenRightMenu("2", ptCmd, num);
	//		}
	//		this.m_rightFourMenu.SetPos(point, 0.1f);
	//		break;
	//	}
	//	}
	//	return base.OnChildEZMessage(type, key, ptCmd);
	//}

	//// Token: 0x06000CD0 RID: 3280 RVA: 0x00068C10 File Offset: 0x00066E10
	//private void CloseRightMenu()
	//{
	//	if (this.m_rightFourMenu.MenuButtonMsg.Count == 2)
	//	{
	//		this.m_rightFourMenu.RemoveMenu(0, true);
	//		this.m_rightFourMenu.RemoveMenu(3, true);
	//	}
	//	if (this.m_rightFourMenu.MenuButtonMsg.Count == 1)
	//	{
	//		this.m_rightFourMenu.RemoveMenu(3, true);
	//	}
	//	if (this.m_rightFourMenu.MenuButtonMsg.Count == 4)
	//	{
	//		this.m_rightFourMenu.RemoveMenu(0, true);
	//		this.m_rightFourMenu.RemoveMenu(1, true);
	//		this.m_rightFourMenu.RemoveMenu(2, true);
	//		this.m_rightFourMenu.RemoveMenu(3, true);
	//	}
	//}

	//// Token: 0x06000CD1 RID: 3281 RVA: 0x00068CBC File Offset: 0x00066EBC
	//private void OpenRightMenu(string type, POINTER_INFO ptCmd, ulong id)
	//{
	//	if ((Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId) == null)
	//	{
	//		return;
	//	}
	//	this.SetSound(true, 5002, EZGUIManager._aRight, null, null, null);
	//	PropsPlane.m_Index = id;
	//	if (type == "4")
	//	{
	//		this.m_info = (PropsPlane.PropItemInfo)ptCmd.targetObj.Data;
	//		this.CloseRightMenu();
	//		this.m_rightFourMenu.MenuInfos.Clear();
	//		this.m_rightFourMenu.AddMenuItem(0, "使用", 0);
	//		this.m_rightFourMenu.AddMenuItem(1, "放入快捷栏E", 0);
	//		this.m_rightFourMenu.AddMenuItem(2, "放入快捷栏R", 0);
	//		this.m_rightFourMenu.AddMenuItem(3, "摧毁", 0);
	//		this.m_rightFourMenu.ShowMenu();
	//		if (this.m_rightFourMenu.MenuButtonMsg.Count >= 4)
	//		{
	//			this.m_rightFourMenu.MenuButtonMsg[0]._Data = "1";
	//			this.m_rightFourMenu.MenuButtonMsg[1]._Data = "2";
	//			this.m_rightFourMenu.MenuButtonMsg[2]._Data = "3";
	//			this.m_rightFourMenu.MenuButtonMsg[3]._Data = "4";
	//		}
	//		this.m_rightFourMenu.SetButtonContorlState(0, UIButton.CONTROL_STATE.NORMAL);
	//		if (PropsPlane.m_keyA != id)
	//		{
	//			this.m_rightFourMenu.SetButtonContorlState(1, UIButton.CONTROL_STATE.NORMAL);
	//		}
	//		else
	//		{
	//			this.m_rightFourMenu.SetButtonContorlState(1, UIButton.CONTROL_STATE.DISABLED);
	//		}
	//		if (PropsPlane.m_keyB != id)
	//		{
	//			this.m_rightFourMenu.SetButtonContorlState(2, UIButton.CONTROL_STATE.NORMAL);
	//		}
	//		else
	//		{
	//			this.m_rightFourMenu.SetButtonContorlState(2, UIButton.CONTROL_STATE.DISABLED);
	//		}
	//		this.m_rightFourMenu.SetButtonContorlState(3, UIButton.CONTROL_STATE.NORMAL);
	//		if (id < 3000000UL && id >= 2000000UL)
	//		{
	//			this.m_pType = ItemCfgType.ITCT_PELLET;
	//		}
	//		if (PropsPlane.m_pointerA.targetObj != null && this.m_info.ITEM_STATIC_ID == ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID)
	//		{
	//			PropsPlane.m_pointerA = ptCmd;
	//			Player.Instance.m_RoleGrowDatas.E = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID;
	//		}
	//		if (PropsPlane.m_pointerB.targetObj != null && this.m_info.ITEM_STATIC_ID == ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID)
	//		{
	//			PropsPlane.m_pointerB = ptCmd;
	//			Player.Instance.m_RoleGrowDatas.R = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID;
	//		}
	//	}
	//	else if (type == "2")
	//	{
	//		this.m_info = (PropsPlane.PropItemInfo)ptCmd.targetObj.Data;
	//		this.CloseRightMenu();
	//		this.m_rightFourMenu.MenuInfos.Clear();
	//		this.m_rightFourMenu.AddMenuItem(0, "使用", 0);
	//		this.m_rightFourMenu.AddMenuItem(3, "摧毁", 0);
	//		this.m_rightFourMenu.ShowMenu();
	//		if (this.m_rightFourMenu.MenuButtonMsg.Count >= 2)
	//		{
	//			this.m_rightFourMenu.MenuButtonMsg[0]._Data = "1";
	//			this.m_rightFourMenu.MenuButtonMsg[1]._Data = "2";
	//		}
	//		this.m_rightFourMenu.SetButtonContorlState(0, UIButton.CONTROL_STATE.NORMAL);
	//		this.m_rightFourMenu.SetButtonContorlState(3, UIButton.CONTROL_STATE.NORMAL);
	//		if (id < 4000000UL && id >= 3000000UL)
	//		{
	//			this.m_pType = ItemCfgType.ITCT_STUFF;
	//		}
	//		if (id >= 5000000UL || id >= 4000000UL)
	//		{
	//		}
	//		if (id < 6000000UL && id >= 5000000UL)
	//		{
	//			this.m_pType = ItemCfgType.ITCT_OTHER;
	//		}
	//	}
	//	else
	//	{
	//		this.m_info = (PropsPlane.PropItemInfo)ptCmd.targetObj.Data;
	//		this.CloseRightMenu();
	//		this.m_rightFourMenu.MenuInfos.Clear();
	//		this.m_rightFourMenu.AddMenuItem(3, "摧毁", true);
	//		this.m_rightFourMenu.ShowMenu();
	//		if (this.m_rightFourMenu.MenuButtonMsg.Count >= 1)
	//		{
	//			this.m_rightFourMenu.MenuButtonMsg[0]._Data = "1";
	//		}
	//		this.m_rightFourMenu.SetButtonContorlState(0, UIButton.CONTROL_STATE.NORMAL);
	//		if (id < 4000000UL && id >= 3000000UL)
	//		{
	//			this.m_pType = ItemCfgType.ITCT_STUFF;
	//		}
	//	}
	//}

	//// Token: 0x06000CD2 RID: 3282 RVA: 0x0006916C File Offset: 0x0006736C
	//private void TextureShow(POINTER_INFO ptCmd)
	//{
	//	if (ptCmd.targetObj == null)
	//	{
	//		return;
	//	}
	//	PropsPlane.PropItemInfo propItemInfo = (PropsPlane.PropItemInfo)ptCmd.targetObj.Data;
	//	if (propItemInfo.TypeID == 2)
	//	{
	//		if (PropsPlane.m_MedicineObject.transform.position.x <= this.m_UIBT_JoyKeyA.transform.position.x + 0.6f && PropsPlane.m_MedicineObject.transform.position.x > this.m_UIBT_JoyKeyA.transform.position.x - 0.6f && PropsPlane.m_MedicineObject.transform.position.y <= this.m_UIBT_JoyKeyA.transform.position.y + 0.6f && PropsPlane.m_MedicineObject.transform.position.y > this.m_UIBT_JoyKeyA.transform.position.y - 0.6f)
	//		{
	//			if (PropsPlane.m_keyB == propItemInfo.ITEM_STATIC_ID)
	//			{
	//				PropsPlane.m_MecJoyKeyB.material.mainTexture = (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture));
	//				Player.Instance.m_RoleGrowDatas.m_proR = "NULL";
	//				PropsPlane.m_keyB = 0UL;
	//				PropsPlane.m_BValue.Text = string.Empty;
	//				if (SkillUIManager.instance != null)
	//				{
	//					SkillUIManager.m_BValue.Text = string.Empty;
	//					SkillUIManager.instance.SetOneItemTexture(1, "EZGUI/Main/AlphaTrans", true, TYPE.ALL);
	//					PropsPlane.m_keyBPath = "EZGUI/Main/AlphaTrans";
	//				}
	//				if (PropsPlane.m_effBIndex != -1)
	//				{
	//					Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effBIndex, true);
	//					PropsPlane.m_effBIndex = -1;
	//				}
	//			}
	//			PropsPlane.m_MecJoyKeyA.material.mainTexture = (Texture)ResourceLoader.Load(propItemInfo.IcoPath, typeof(Texture));
	//			Player.Instance.m_RoleGrowDatas.m_proE = propItemInfo.IcoPath;
	//			Player.Instance.m_RoleGrowDatas.m_proECount = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.E);
	//			TimeOutManager.SetTimeOut(Main.Instance.transform, 0.2f, new Callback(PropsPlane.m_MecJoyKeyA.transform.GetComponent<UIBistateInteractivePanel>().Reveal));
	//			TimeOutManager.SetTimeOut(Main.Instance.transform, 0.7f, new Callback(PropsPlane.m_MecJoyKeyA.transform.GetComponent<UIBistateInteractivePanel>().Hide));
	//			PropsPlane.m_AValue.Text = propItemInfo.Count.ToString();
	//			if (PropsPlane.m_effAIndex != -1)
	//			{
	//				Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effAIndex, true);
	//				PropsPlane.m_effAIndex = -1;
	//			}
	//			Color color = PropsPlane.m_MecJoyKeyA.material.color;
	//			PropsPlane.m_keyA = propItemInfo.ITEM_STATIC_ID;
	//			if (PropsPlane.m_pointerA.targetObj != null && ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID != ((PropsPlane.PropItemInfo)ptCmd.targetObj.Data).ITEM_STATIC_ID && color == PropsPlane.m_proA)
	//			{
	//				Color color2 = new Color(0.43f, 0.43f, 0.43f, 255f);
	//				PropsPlane.m_MecJoyKeyA.material.SetColor("_Color", color2);
	//			}
	//			PropsPlane.m_pointerA = ptCmd;
	//			Player.Instance.m_RoleGrowDatas.E = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID;
	//			if (SkillUIManager.instance != null && PropsPlane.m_keyA != 0UL)
	//			{
	//				Color color3 = SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/item1").GetComponent<MeshRenderer>().material.color;
	//				SkillUIManager.m_AValue.Text = propItemInfo.Count.ToString();
	//				if (color3 != PropsPlane.m_MecJoyKeyA.material.color)
	//				{
	//					SkillUIManager.instance.SetOneItemTexture(0, propItemInfo.IcoPath, false, TYPE.ITEM_TYPE);
	//				}
	//				else
	//				{
	//					SkillUIManager.instance.SetOneItemTexture(0, propItemInfo.IcoPath, false, TYPE.ALL);
	//				}
	//				PropsPlane.m_keyAPath = propItemInfo.IcoPath;
	//			}
	//			else if (SkillUIManager.instance != null && PropsPlane.m_keyA == 0UL)
	//			{
	//				SkillUIManager.m_AValue.Text = propItemInfo.Count.ToString();
	//				SkillUIManager.instance.SetOneItemTexture(0, propItemInfo.IcoPath, true, TYPE.ALL);
	//				PropsPlane.m_keyAPath = propItemInfo.IcoPath;
	//			}
	//			PropsPlane.m_MedicineObject.SetActiveRecursively(false);
	//			if (PropsPlane.m_effAIndex == -1)
	//			{
	//				PropsPlane.m_effAIndex = Singleton<GUIEffectManager>.GetInstance().AddEffect(5, this.m_UIBT_JoyKeyA.transform, true);
	//			}
	//			return;
	//		}
	//		if (PropsPlane.m_MedicineObject.transform.position.x <= this.m_UIBT_JoyKeyB.transform.position.x + 0.6f && PropsPlane.m_MedicineObject.transform.position.x > this.m_UIBT_JoyKeyB.transform.position.x - 0.6f && PropsPlane.m_MedicineObject.transform.position.y <= this.m_UIBT_JoyKeyB.transform.position.y + 0.6f && PropsPlane.m_MedicineObject.transform.position.y > this.m_UIBT_JoyKeyB.transform.position.y - 0.6f)
	//		{
	//			if (PropsPlane.m_keyA == propItemInfo.ITEM_STATIC_ID)
	//			{
	//				PropsPlane.m_MecJoyKeyA.material.mainTexture = (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture));
	//				Player.Instance.m_RoleGrowDatas.m_proE = "NULL";
	//				PropsPlane.m_keyA = 0UL;
	//				PropsPlane.m_AValue.Text = string.Empty;
	//				if (SkillUIManager.instance != null)
	//				{
	//					SkillUIManager.m_AValue.Text = string.Empty;
	//					SkillUIManager.instance.SetOneItemTexture(0, "EZGUI/Main/AlphaTrans", true, TYPE.ALL);
	//					PropsPlane.m_keyAPath = "EZGUI/Main/AlphaTrans";
	//				}
	//				if (PropsPlane.m_effAIndex != -1)
	//				{
	//					Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effAIndex, true);
	//					PropsPlane.m_effAIndex = -1;
	//				}
	//			}
	//			PropsPlane.m_MecJoyKeyB.material.mainTexture = (Texture)ResourceLoader.Load(propItemInfo.IcoPath, typeof(Texture));
	//			Player.Instance.m_RoleGrowDatas.m_proR = propItemInfo.IcoPath;
	//			Player.Instance.m_RoleGrowDatas.m_proRCount = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.R);
	//			TimeOutManager.SetTimeOut(Main.Instance.transform, 0.2f, new Callback(PropsPlane.m_MecJoyKeyB.transform.GetComponent<UIBistateInteractivePanel>().Reveal));
	//			TimeOutManager.SetTimeOut(Main.Instance.transform, 0.7f, new Callback(PropsPlane.m_MecJoyKeyB.transform.GetComponent<UIBistateInteractivePanel>().Hide));
	//			PropsPlane.m_BValue.Text = propItemInfo.Count.ToString();
	//			if (PropsPlane.m_effBIndex != -1)
	//			{
	//				Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effBIndex, true);
	//				PropsPlane.m_effBIndex = -1;
	//			}
	//			if (SkillUIManager.instance != null && PropsPlane.m_keyB != 0UL)
	//			{
	//				SkillUIManager.m_BValue.Text = propItemInfo.Count.ToString();
	//				SkillUIManager.instance.SetOneItemTexture(1, propItemInfo.IcoPath, false, TYPE.ITEM_TYPE);
	//				PropsPlane.m_keyBPath = propItemInfo.IcoPath;
	//			}
	//			else if (SkillUIManager.instance != null && PropsPlane.m_keyB == 0UL)
	//			{
	//				SkillUIManager.m_BValue.Text = propItemInfo.Count.ToString();
	//				SkillUIManager.instance.SetOneItemTexture(1, propItemInfo.IcoPath, false, TYPE.ALL);
	//				PropsPlane.m_keyBPath = propItemInfo.IcoPath;
	//			}
	//			Color color4 = PropsPlane.m_MecJoyKeyB.material.color;
	//			PropsPlane.m_keyB = propItemInfo.ITEM_STATIC_ID;
	//			if (PropsPlane.m_pointerB.targetObj != null && ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID != ((PropsPlane.PropItemInfo)ptCmd.targetObj.Data).ITEM_STATIC_ID && color4 == PropsPlane.m_proB)
	//			{
	//				Color color5 = new Color(0.43f, 0.43f, 0.43f, 255f);
	//				PropsPlane.m_MecJoyKeyB.material.SetColor("_Color", color5);
	//			}
	//			PropsPlane.m_pointerB = ptCmd;
	//			Player.Instance.m_RoleGrowDatas.R = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID;
	//			if (PropsPlane.m_effBIndex == -1)
	//			{
	//				PropsPlane.m_effBIndex = Singleton<GUIEffectManager>.GetInstance().AddEffect(5, this.m_UIBT_JoyKeyB.transform, true);
	//			}
	//			PropsPlane.m_MedicineObject.SetActiveRecursively(false);
	//			return;
	//		}
	//	}
	//}

	//// Token: 0x06000CD3 RID: 3283 RVA: 0x00069AAC File Offset: 0x00067CAC
	//public void OnLDrag(POINTER_INFO ptCmd)
	//{
	//	if (ptCmd.targetObj == null)
	//	{
	//		return;
	//	}
	//	this.m_rightFourMenu.CloseMenu(false);
	//	PropsPlane.PropItemInfo propItemInfo = (PropsPlane.PropItemInfo)ptCmd.targetObj.Data;
	//	if (propItemInfo.TypeID == 2)
	//	{
	//		PropsPlane.m_MedicineObject.SetActiveRecursively(true);
	//		Camera component = GameObject.FindWithTag("UICam").transform.GetComponent<Camera>();
	//		PropsPlane.m_MedicineObject.transform.position = component.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, PropsPlane.m_MedicineObject.transform.position.z));
	//		this.m_MecRenderer.material.mainTexture = (Texture)ResourceLoader.Load(propItemInfo.IcoPath, typeof(Texture));
	//	}
	//}

	//// Token: 0x06000CD4 RID: 3284 RVA: 0x00069B88 File Offset: 0x00067D88
	//public void SetButtonState()
	//{
	//	foreach (List<IUIListObject> list in this.m_mapUINowGroup.Values)
	//	{
	//		for (int i = 0; i < list.Count; i++)
	//		{
	//			if (list[i] != null && list[i].gameObject != null && list.Contains(list[i]))
	//			{
	//				list[i].transform.FindChild("IcoPar/Item").GetComponent<UIButton>().controlIsEnabled = true;
	//				list[i].transform.FindChild("IcoPar/Item").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//				list[i].transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.NORMAL);
	//				list[i].transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().controlIsEnabled = true;
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06000CD5 RID: 3285 RVA: 0x00069CBC File Offset: 0x00067EBC
	//public void SetKeyA(ulong key, string path, string count)
	//{
	//	PropsPlane.m_keyA = key;
	//	PropsPlane.m_keyAPath = path;
	//	Player.Instance.m_RoleGrowDatas.E = key;
	//	if (SkillUIManager.instance != null && key != 0UL)
	//	{
	//		SkillUIManager.m_AValue.Text = count;
	//		SkillUIManager.instance.SetOneItemTexture(0, path, false, TYPE.ALL);
	//		PropsPlane.m_keyAPath = path;
	//	}
	//}

	//// Token: 0x06000CD6 RID: 3286 RVA: 0x00069D1C File Offset: 0x00067F1C
	//private void OnLCick(POINTER_INFO ptCmd, string key)
	//{
	//	if (key == null || ptCmd.targetObj == null)
	//	{
	//		return;
	//	}
	//	PropsPlane.PropItemInfo propItemInfo = (PropsPlane.PropItemInfo)ptCmd.targetObj.Data;
	//	if (propItemInfo == null)
	//	{
	//		return;
	//	}
	//	if (null == PropsPlane.m_PlaneMid)
	//	{
	//		return;
	//	}
	//	this.SetSound(true, 5018, EZGUIManager._aClick, null, null, null);
	//	if (this.m_ptCmd.targetObj != ptCmd.targetObj)
	//	{
	//		if (ptCmd.targetObj.transform.FindChild("IcoPar") != null && ptCmd.targetObj.transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().controlState != UIButton.CONTROL_STATE.ACTIVE)
	//		{
	//			this.SetButtonState();
	//			UIButton component = ptCmd.targetObj.transform.FindChild("IcoPar/Item").GetComponent<UIButton>();
	//			component.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//			ptCmd.targetObj.transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//			component.controlIsEnabled = false;
	//			ptCmd.targetObj.transform.FindChild("IcoPar/ItemBK").GetComponent<UIButton>().controlIsEnabled = false;
	//		}
	//		this.m_ptCmd = ptCmd;
	//	}
	//	if (null != this.m_BigIco)
	//	{
	//		this.m_BigIco.GetComponent<MeshRenderer>().material.mainTexture = null;
	//		this.m_BigIco.GetComponent<MeshRenderer>().material.mainTexture = (Texture)ResourceLoader.Load(propItemInfo.BigIcoPath, typeof(Texture));
	//	}
	//	if (null != this.m_UIDescTitle)
	//	{
	//		this.m_UIDescTitle.Text = propItemInfo.Name;
	//		this.m_UIDescTitle.transform.position = new Vector3(this.m_BigIco.transform.position.x, this.m_UIDescTitle.transform.position.y, this.m_UIDescTitle.transform.position.z);
	//	}
	//	if (null != this.m_UIIntro)
	//	{
	//		if (propItemInfo.TypeID == 3)
	//		{
	//			this.m_UIIntro.Text = propItemInfo.ParName + "材料";
	//		}
	//		else
	//		{
	//			this.m_UIIntro.Text = string.Empty;
	//		}
	//		this.m_UIIntro.transform.position = new Vector3(this.m_BigIco.transform.position.x, this.m_UIDescTitle.transform.position.y - 0.7f, this.m_UIDescTitle.transform.position.z);
	//	}
	//	if (null != this.m_UISkillAttText)
	//	{
	//		if (propItemInfo.TypeID == 2)
	//		{
	//			this.m_UISkillAttText.Text = propItemInfo.Intro;
	//		}
	//		else
	//		{
	//			this.m_UISkillAttText.Text = string.Empty;
	//		}
	//		this.m_UISkillAttText.transform.position = new Vector3(this.m_BigIco.transform.position.x, this.m_UIDescTitle.transform.position.y - 0.7f, this.m_UIDescTitle.transform.position.z);
	//	}
	//	if (null != this.m_UIDescText)
	//	{
	//		this.m_UIDescText0.transform.position = new Vector3(this.m_BigIco.transform.position.x, this.m_UIDescTitle.transform.position.y - 1.5f, this.m_UIDescTitle.transform.position.z);
	//		this.m_UIDescText.transform.position = new Vector3(this.m_BigIco.transform.position.x - 2.7f, this.m_UIDescTitle.transform.position.y - 1.8f, this.m_UIDescTitle.transform.position.z);
	//		char[] array = propItemInfo.Desc.ToCharArray();
	//		string text = string.Empty;
	//		string text2 = string.Empty;
	//		string text3 = string.Empty;
	//		int num = 0;
	//		for (int i = 0; i < propItemInfo.Desc.Length; i++)
	//		{
	//			if (array[i] == '。')
	//			{
	//				num = i;
	//			}
	//		}
	//		if (propItemInfo.ParName.ToString() != "仙符")
	//		{
	//			for (int j = 0; j < propItemInfo.Desc.Length; j++)
	//			{
	//				if (j <= 7)
	//				{
	//					text += array[j];
	//				}
	//				else if (j == 17 || j == 27 || j == 37 || j == 47 || j == 57 || j == 67 || j == 77)
	//				{
	//					text2 = text2 + array[j] + "\n";
	//				}
	//				else
	//				{
	//					text2 += array[j];
	//				}
	//			}
	//			this.m_UIDescText0.Text = "       " + text;
	//			this.m_UIDescText.Text = text2;
	//		}
	//		else
	//		{
	//			for (int k = 0; k < propItemInfo.Desc.Length; k++)
	//			{
	//				if (k <= 7)
	//				{
	//					text += array[k];
	//				}
	//				else
	//				{
	//					if (k == 17 || k == 27)
	//					{
	//						text2 = text2 + array[k] + "\n";
	//					}
	//					else
	//					{
	//						text2 += array[k];
	//					}
	//					if (array[k] == '。')
	//					{
	//						break;
	//					}
	//				}
	//			}
	//			for (int l = num + 1; l < propItemInfo.Desc.Length; l++)
	//			{
	//				if (array[l] == '术')
	//				{
	//					text3 = text3 + array[l] + "\n";
	//				}
	//				else
	//				{
	//					text3 += array[l];
	//				}
	//			}
	//			this.m_UIDescText0.Text = "       " + text;
	//			this.m_UIDescText.Text = text2 + "\n\n" + text3;
	//		}
	//	}
	//	if (this.m_UIIntro != null)
	//	{
	//		this.m_UIIntro.transform.position = this.m_UISkillAttText.transform.position;
	//	}
	//}

	//// Token: 0x06000CD7 RID: 3287 RVA: 0x0006A3F8 File Offset: 0x000685F8
	//private void OnDLCickER(ulong id)
	//{
	//	if (id == 0UL)
	//	{
	//		return;
	//	}
	//	ItemPropertyConfig itemPropertyConfig = null;
	//	PropsPlane.PropItemInfo propItemInfo = null;
	//	IUIListObject iuilistObject = null;
	//	List<PropsPlane.PropItemInfo> list;
	//	if (GameData.Instance.ItemStaticMan.TryGetItemInfoByID(id, out itemPropertyConfig) && this.m_mapNowTypeGroup.TryGetValue(itemPropertyConfig.ITEM_CHILDTYPE_ID, out list))
	//	{
	//		for (int i = 0; i < list.Count; i++)
	//		{
	//			if (itemPropertyConfig.ITEM_STATIC_ID == list[i].ITEM_STATIC_ID)
	//			{
	//				propItemInfo = list[i];
	//			}
	//		}
	//	}
	//	foreach (List<IUIListObject> list2 in this.m_mapUINowGroup.Values)
	//	{
	//		for (int j = 0; j < list2.Count; j++)
	//		{
	//			char[] array = list2[j].transform.name.ToCharArray();
	//			string text = string.Empty;
	//			for (int k = 0; k < list2[j].transform.name.Length; k++)
	//			{
	//				if (k >= 8)
	//				{
	//					text += array[k];
	//				}
	//			}
	//			if (text == propItemInfo.ITEM_STATIC_ID.ToString())
	//			{
	//				iuilistObject = list2[j];
	//			}
	//		}
	//	}
	//	PropsPlane.m_infoDel = propItemInfo;
	//	if (propItemInfo == null || propItemInfo.Count <= 0)
	//	{
	//		return;
	//	}
	//	if (propItemInfo.TypeID.ToString() == "4")
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>()._buttonGB.transform.parent.FindChild("Skill/ItemNew").GetComponent<UIButton>().active = true;
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>()._buttonGB.transform.parent.FindChild("Skill/ItemNew").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//	}
	//	if (propItemInfo.ITEM_STATIC_ID == 4010001UL)
	//	{
	//		GameData.Instance.ScrMan.Exec(44, 1001011);
	//	}
	//	if (propItemInfo.ScriptID != -1)
	//	{
	//		GameData.Instance.ScrMan.Exec(59, propItemInfo.ScriptID);
	//	}
	//	int childTypeID = propItemInfo.ChildTypeID;
	//	CItemBase citemBase = propItemInfo.Items[0];
	//	ItemCfgType itemCfgTpyeByID = GameData.Instance.ItemStaticMan.GetItemCfgTpyeByID(citemBase.TYPE_ID);
	//	List<ATTRIBUTE_TYPE> list3 = new List<ATTRIBUTE_TYPE>(citemBase.DynamicData.ITEM_ATTRIBUTES_MAP.Keys);
	//	List<ITEM_ADD_ATTRIBUTE> list4 = new List<ITEM_ADD_ATTRIBUTE>(citemBase.DynamicData.ITEM_ADDATTRIBUTES_MAP.Keys);
	//	List<ITEM_ATTRIBUTE_TYPE> list5 = new List<ITEM_ATTRIBUTE_TYPE>(citemBase.DynamicData.ITEM_ITEMATT_MAP.Keys);
	//	Player player = (Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId);
	//	if (player == null)
	//	{
	//		return;
	//	}
	//	if (player.m_cModAttribute == null)
	//	{
	//		return;
	//	}
	//	float attributeValue = player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXMP);
	//	float attributeValue2 = player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MP);
	//	float num = (float)player.GetMaxHp();
	//	float num2 = (float)player.GetCurHp();
	//	this.m_bCount = false;
	//	if (list3 != null)
	//	{
	//		for (int l = 0; l < list3.Count; l++)
	//		{
	//			ATTRIBUTE_TYPE attribute_TYPE = list3[l];
	//			ATTRIBUTE_TYPE attribute_TYPE2 = ATTRIBUTE_TYPE.ATT_MP;
	//			ATTRIBUTE_TYPE attribute_TYPE3 = ATTRIBUTE_TYPE.ATT_HP;
	//			if (attribute_TYPE != attribute_TYPE2 && attribute_TYPE != attribute_TYPE3)
	//			{
	//				player.m_cModAttribute.UpdateAttributeNum(attribute_TYPE, citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE], false);
	//				string text2 = (citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE] <= 0f) ? " 减少" : " 增加";
	//				string strText = string.Concat(new object[]
	//				{
	//					"属性更新 : ",
	//					ModAttribute.GetAttributeName(attribute_TYPE),
	//					text2,
	//					" : ",
	//					citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE]
	//				});
	//				GameData.Instance.RadioCenter.PushRadioQueue(strText, Color.green);
	//				GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
	//				if (!this.m_bCount)
	//				{
	//					propItemInfo.Items.RemoveAt(0);
	//					this.m_bCount = true;
	//				}
	//			}
	//			else if (attributeValue2 < attributeValue || num2 < num)
	//			{
	//				player.m_cModAttribute.UpdateAttributeNum(attribute_TYPE, citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE], false);
	//				string text3 = (citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE] <= 0f) ? " 减少" : " 增加";
	//				string strText2 = string.Concat(new object[]
	//				{
	//					"属性更新 : ",
	//					ModAttribute.GetAttributeName(attribute_TYPE),
	//					text3,
	//					" : ",
	//					citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE]
	//				});
	//				GameData.Instance.RadioCenter.PushRadioQueue(strText2, Color.green);
	//				GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
	//				if (!this.m_bCount)
	//				{
	//					propItemInfo.Items.RemoveAt(0);
	//					this.m_bCount = true;
	//				}
	//			}
	//		}
	//	}
	//	if (list4 != null)
	//	{
	//		for (int m = 0; m < list4.Count; m++)
	//		{
	//			ITEM_ADD_ATTRIBUTE item_ADD_ATTRIBUTE = list4[m];
	//			player.m_cModAttribute.UpdateItemAddAttribute(item_ADD_ATTRIBUTE, citemBase.DynamicData.ITEM_ADDATTRIBUTES_MAP[item_ADD_ATTRIBUTE]);
	//			GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
	//			if (!this.m_bCount)
	//			{
	//				propItemInfo.Items.RemoveAt(0);
	//				this.m_bCount = true;
	//			}
	//		}
	//	}
	//	if (list5 != null)
	//	{
	//		for (int n = 0; n < list5.Count; n++)
	//		{
	//			ITEM_ATTRIBUTE_TYPE item_ATTRIBUTE_TYPE = list5[n];
	//			if (item_ATTRIBUTE_TYPE == ITEM_ATTRIBUTE_TYPE.IAT_HAVESKILLID)
	//			{
	//				if (player.SystemFigure.LearnSkill((int)citemBase.DynamicData.ITEM_ITEMATT_MAP[item_ATTRIBUTE_TYPE]))
	//				{
	//					SM_HelpEnable.ExecHelp(1000835);
	//					GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
	//					if (!this.m_bCount)
	//					{
	//						propItemInfo.Items.RemoveAt(0);
	//						this.m_bCount = true;
	//					}
	//				}
	//				else
	//				{
	//					SM_HelpEnable.ExecHelp(1000836);
	//				}
	//			}
	//		}
	//	}
	//	if (PropsPlane.m_keyA == propItemInfo.ITEM_STATIC_ID)
	//	{
	//		PropsPlane.m_AValue.Text = propItemInfo.Count.ToString();
	//		SkillUIManager.m_AValue.Text = propItemInfo.Count.ToString();
	//	}
	//	if (PropsPlane.m_keyB == propItemInfo.ITEM_STATIC_ID)
	//	{
	//		PropsPlane.m_BValue.Text = propItemInfo.Count.ToString();
	//		SkillUIManager.m_BValue.Text = propItemInfo.Count.ToString();
	//	}
	//	if (propItemInfo.Count <= 0)
	//	{
	//		PropsPlane.m_PropsList.RemoveItem(iuilistObject, true);
	//		if (this._list_new.Contains(iuilistObject))
	//		{
	//			this._list_new.Remove(iuilistObject);
	//		}
	//		this.Remove(PropsPlane.m_infoDel);
	//		this.m_mapItemInfo_DiuQi.Add(PropsPlane.m_infoDel.ITEM_STATIC_ID, PropsPlane.m_infoDel);
	//		foreach (KeyValuePair<int, GameObject> keyValuePair in this.m_mapUITypeNode)
	//		{
	//			Transform transform = keyValuePair.Value.transform.FindChild("ItemCount");
	//			if (transform != null)
	//			{
	//				SpriteText component = transform.gameObject.GetComponent<SpriteText>();
	//				if (component != null && this.m_mapUINowGroup.ContainsKey(keyValuePair.Key))
	//				{
	//					component.Text = ((this.m_mapUINowGroup[keyValuePair.Key].Count <= 0) ? string.Empty : ("(" + this.m_mapUINowGroup[keyValuePair.Key].Count + ")"));
	//				}
	//			}
	//		}
	//		this.m_ptCmd.targetObj = null;
	//		if (this.m_NowTag == ItemCfgType.ITCT_PELLET)
	//		{
	//			Dictionary<ulong, PropsPlane.PropItemInfo> dictionary = this.m_mapItemInfo_Dan;
	//		}
	//		else if (this.m_NowTag == ItemCfgType.ITCT_STUFF)
	//		{
	//			Dictionary<ulong, PropsPlane.PropItemInfo> dictionary = this.m_mapItemInfo_Cai;
	//		}
	//		else
	//		{
	//			if (this.m_NowTag != ItemCfgType.ITCT_OTHER)
	//			{
	//				return;
	//			}
	//			Dictionary<ulong, PropsPlane.PropItemInfo> dictionary = this.m_mapItemInfo_Ta;
	//		}
	//		if (PropsPlane.m_keyA == propItemInfo.ITEM_STATIC_ID)
	//		{
	//			Color color = new Color(PropsPlane.m_MecJoyKeyA.material.color.r * 0.2f, PropsPlane.m_MecJoyKeyA.material.color.g * 0.2f, PropsPlane.m_MecJoyKeyA.material.color.b * 0.2f, 255f);
	//			PropsPlane.m_MecJoyKeyA.material.SetColor("_Color", color);
	//			PropsPlane.m_keyA = propItemInfo.ITEM_STATIC_ID;
	//			PropsPlane.m_proA = color;
	//			PropsPlane.m_AValue.Text = propItemInfo.Count.ToString();
	//			SkillUIManager.m_AValue.Text = propItemInfo.Count.ToString();
	//			if (SkillUIManager.instance != null)
	//			{
	//				SkillUIManager.m_AValue.Text = "0";
	//				SkillUIManager.instance.SetOneItemTexture(0, PropsPlane.m_keyAPath, true, TYPE.ITEM_TYPE);
	//			}
	//			if (PropsPlane.m_effAIndex != -1)
	//			{
	//				Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effAIndex, true);
	//				PropsPlane.m_effAIndex = -1;
	//			}
	//		}
	//		if (PropsPlane.m_keyB == propItemInfo.ITEM_STATIC_ID)
	//		{
	//			Color color2 = new Color(PropsPlane.m_MecJoyKeyB.material.color.r * 0.2f, PropsPlane.m_MecJoyKeyB.material.color.g * 0.2f, PropsPlane.m_MecJoyKeyB.material.color.b * 0.2f, 255f);
	//			PropsPlane.m_MecJoyKeyB.material.SetColor("_Color", color2);
	//			PropsPlane.m_keyB = propItemInfo.ITEM_STATIC_ID;
	//			PropsPlane.m_proB = color2;
	//			PropsPlane.m_BValue.Text = propItemInfo.Count.ToString();
	//			SkillUIManager.m_BValue.Text = propItemInfo.Count.ToString();
	//			if (SkillUIManager.instance != null)
	//			{
	//				SkillUIManager.m_BValue.Text = "0";
	//				SkillUIManager.instance.SetOneItemTexture(1, PropsPlane.m_keyBPath, true, TYPE.ITEM_TYPE);
	//			}
	//			if (PropsPlane.m_effBIndex != -1)
	//			{
	//				Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effBIndex, true);
	//				PropsPlane.m_effBIndex = -1;
	//			}
	//		}
	//		this.ClearLeftDesc();
	//		List<IUIListObject> list6;
	//		if (this.m_mapUINowGroup.TryGetValue(childTypeID, out list6))
	//		{
	//			this.UpdateListPos(childTypeID, list6);
	//		}
	//		if (PropsPlane.m_PropsList.Count == 0)
	//		{
	//			GameObject obj;
	//			if (this.m_mapUITypeNode.TryGetValue(childTypeID, out obj))
	//			{
	//				UnityEngine.Object.Destroy(obj);
	//				this.m_mapUITypeNode.Remove(childTypeID);
	//			}
	//			this.UpdateParentPos();
	//		}
	//		if (propItemInfo.TypeID.ToString() == "4")
	//		{
	//			if (list6.Count < 6)
	//			{
	//				PropsPlane.m_PropsList.slider.transform.active = false;
	//				this.m_UIC_TopSlider.active = false;
	//				this.m_UIC_BottomSlider.active = false;
	//			}
	//			else
	//			{
	//				PropsPlane.m_PropsList.slider.transform.active = true;
	//				this.m_UIC_TopSlider.active = true;
	//				this.m_UIC_BottomSlider.active = true;
	//			}
	//		}
	//	}
	//	else
	//	{
	//		if (!PropsPlane.m_PlaneObject.active || propItemInfo.Count <= 0)
	//		{
	//			return;
	//		}
	//		IUIListObject iuilistObject2 = iuilistObject;
	//		if (iuilistObject2 == null)
	//		{
	//			return;
	//		}
	//		Transform transform2 = iuilistObject2.transform.FindChild("ItemCount");
	//		if (transform2 != null)
	//		{
	//			SpriteText component2 = transform2.GetComponent<SpriteText>();
	//			if (component2 != null)
	//			{
	//				component2.Text = propItemInfo.Count.ToString();
	//			}
	//			if (PropsPlane.m_keyA == propItemInfo.ITEM_STATIC_ID)
	//			{
	//				PropsPlane.m_proA = Color.gray;
	//			}
	//			if (PropsPlane.m_keyB == propItemInfo.ITEM_STATIC_ID)
	//			{
	//				PropsPlane.m_proB = Color.gray;
	//			}
	//		}
	//	}
	//	this.PushTextData();
	//}

	//// Token: 0x06000CD8 RID: 3288 RVA: 0x0006B0A4 File Offset: 0x000692A4
	//private void OnDLCick(POINTER_INFO ptCmd, string key)
	//{
	//	if (key == null || ptCmd.targetObj == null)
	//	{
	//		return;
	//	}
	//	PropsPlane.PropItemInfo propItemInfo = (PropsPlane.PropItemInfo)ptCmd.targetObj.Data;
	//	PropsPlane.m_infoDel = propItemInfo;
	//	if (propItemInfo == null || propItemInfo.Count <= 0)
	//	{
	//		return;
	//	}
	//	if (propItemInfo.TypeID.ToString() == "4")
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>()._buttonGB.transform.parent.FindChild("Skill/ItemNew").GetComponent<UIButton>().active = true;
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>()._buttonGB.transform.parent.FindChild("Skill/ItemNew").GetComponent<UIButton>().SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//	}
	//	if (propItemInfo.ITEM_STATIC_ID == 4010001UL)
	//	{
	//		GameData.Instance.ScrMan.Exec(44, 1001011);
	//	}
	//	if (propItemInfo.ScriptID != -1)
	//	{
	//		GameData.Instance.ScrMan.Exec(59, propItemInfo.ScriptID);
	//	}
	//	int childTypeID = propItemInfo.ChildTypeID;
	//	CItemBase citemBase = propItemInfo.Items[0];
	//	ItemCfgType itemCfgTpyeByID = GameData.Instance.ItemStaticMan.GetItemCfgTpyeByID(citemBase.TYPE_ID);
	//	List<ATTRIBUTE_TYPE> list = new List<ATTRIBUTE_TYPE>(citemBase.DynamicData.ITEM_ATTRIBUTES_MAP.Keys);
	//	List<ITEM_ADD_ATTRIBUTE> list2 = new List<ITEM_ADD_ATTRIBUTE>(citemBase.DynamicData.ITEM_ADDATTRIBUTES_MAP.Keys);
	//	List<ITEM_ATTRIBUTE_TYPE> list3 = new List<ITEM_ATTRIBUTE_TYPE>(citemBase.DynamicData.ITEM_ITEMATT_MAP.Keys);
	//	Player player = (Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId);
	//	if (player == null)
	//	{
	//		return;
	//	}
	//	if (player.m_cModAttribute == null)
	//	{
	//		return;
	//	}
	//	float attributeValue = player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXMP);
	//	float attributeValue2 = player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MP);
	//	float num = (float)player.GetMaxHp();
	//	float num2 = (float)player.GetCurHp();
	//	this.m_bCount = false;
	//	if (list != null)
	//	{
	//		for (int i = 0; i < list.Count; i++)
	//		{
	//			ATTRIBUTE_TYPE attribute_TYPE = list[i];
	//			ATTRIBUTE_TYPE attribute_TYPE2 = ATTRIBUTE_TYPE.ATT_MP;
	//			ATTRIBUTE_TYPE attribute_TYPE3 = ATTRIBUTE_TYPE.ATT_HP;
	//			if (attribute_TYPE != attribute_TYPE2 && attribute_TYPE != attribute_TYPE3)
	//			{
	//				player.m_cModAttribute.UpdateAttributeNum(attribute_TYPE, citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE], false);
	//				string text = (citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE] <= 0f) ? " 减少" : " 增加";
	//				string strText = string.Concat(new object[]
	//				{
	//					"属性更新 : ",
	//					ModAttribute.GetAttributeName(attribute_TYPE),
	//					text,
	//					" : ",
	//					citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE]
	//				});
	//				GameData.Instance.RadioCenter.PushRadioQueue(strText, Color.green);
	//				GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
	//				if (!this.m_bCount)
	//				{
	//					propItemInfo.Items.RemoveAt(0);
	//					this.m_bCount = true;
	//				}
	//			}
	//			else if (attributeValue2 < attributeValue || num2 < num)
	//			{
	//				player.m_cModAttribute.UpdateAttributeNum(attribute_TYPE, citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE], false);
	//				string text2 = (citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE] <= 0f) ? " 减少" : " 增加";
	//				string strText2 = string.Concat(new object[]
	//				{
	//					"属性更新 : ",
	//					ModAttribute.GetAttributeName(attribute_TYPE),
	//					text2,
	//					" : ",
	//					citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE]
	//				});
	//				GameData.Instance.RadioCenter.PushRadioQueue(strText2, Color.green);
	//				GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
	//				if (!this.m_bCount)
	//				{
	//					propItemInfo.Items.RemoveAt(0);
	//					this.m_bCount = true;
	//				}
	//			}
	//		}
	//	}
	//	if (list2 != null)
	//	{
	//		for (int j = 0; j < list2.Count; j++)
	//		{
	//			ITEM_ADD_ATTRIBUTE item_ADD_ATTRIBUTE = list2[j];
	//			player.m_cModAttribute.UpdateItemAddAttribute(item_ADD_ATTRIBUTE, citemBase.DynamicData.ITEM_ADDATTRIBUTES_MAP[item_ADD_ATTRIBUTE]);
	//			GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
	//			if (!this.m_bCount)
	//			{
	//				propItemInfo.Items.RemoveAt(0);
	//				this.m_bCount = true;
	//			}
	//		}
	//	}
	//	if (list3 != null)
	//	{
	//		for (int k = 0; k < list3.Count; k++)
	//		{
	//			ITEM_ATTRIBUTE_TYPE item_ATTRIBUTE_TYPE = list3[k];
	//			if (item_ATTRIBUTE_TYPE == ITEM_ATTRIBUTE_TYPE.IAT_HAVESKILLID)
	//			{
	//				if (player.SystemFigure.LearnSkill((int)citemBase.DynamicData.ITEM_ITEMATT_MAP[item_ATTRIBUTE_TYPE]))
	//				{
	//					SM_HelpEnable.ExecHelp(1000835);
	//					GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
	//					if (!this.m_bCount)
	//					{
	//						propItemInfo.Items.RemoveAt(0);
	//						this.m_bCount = true;
	//					}
	//				}
	//				else
	//				{
	//					SM_HelpEnable.ExecHelp(1000836);
	//				}
	//			}
	//		}
	//	}
	//	if (PropsPlane.m_keyA == propItemInfo.ITEM_STATIC_ID)
	//	{
	//		PropsPlane.m_AValue.Text = propItemInfo.Count.ToString();
	//		SkillUIManager.m_AValue.Text = propItemInfo.Count.ToString();
	//	}
	//	if (PropsPlane.m_keyB == propItemInfo.ITEM_STATIC_ID)
	//	{
	//		PropsPlane.m_BValue.Text = propItemInfo.Count.ToString();
	//		SkillUIManager.m_BValue.Text = propItemInfo.Count.ToString();
	//	}
	//	if (propItemInfo.Count <= 0)
	//	{
	//		PropsPlane.m_PropsList.RemoveItem((IUIListObject)ptCmd.targetObj, true);
	//		if (this._list_new.Contains((IUIListObject)ptCmd.targetObj))
	//		{
	//			this._list_new.Remove((IUIListObject)ptCmd.targetObj);
	//		}
	//		this.Remove(PropsPlane.m_infoDel);
	//		this.m_mapItemInfo_DiuQi.Add(PropsPlane.m_infoDel.ITEM_STATIC_ID, PropsPlane.m_infoDel);
	//		foreach (KeyValuePair<int, GameObject> keyValuePair in this.m_mapUITypeNode)
	//		{
	//			Transform transform = keyValuePair.Value.transform.FindChild("ItemCount");
	//			if (transform != null)
	//			{
	//				SpriteText component = transform.gameObject.GetComponent<SpriteText>();
	//				if (component != null && this.m_mapUINowGroup.ContainsKey(keyValuePair.Key))
	//				{
	//					component.Text = ((this.m_mapUINowGroup[keyValuePair.Key].Count <= 0) ? string.Empty : ("(" + this.m_mapUINowGroup[keyValuePair.Key].Count + ")"));
	//				}
	//			}
	//		}
	//		this.m_ptCmd.targetObj = null;
	//		if (this.m_NowTag == ItemCfgType.ITCT_PELLET)
	//		{
	//			Dictionary<ulong, PropsPlane.PropItemInfo> dictionary = this.m_mapItemInfo_Dan;
	//		}
	//		else if (this.m_NowTag == ItemCfgType.ITCT_STUFF)
	//		{
	//			Dictionary<ulong, PropsPlane.PropItemInfo> dictionary = this.m_mapItemInfo_Cai;
	//		}
	//		else
	//		{
	//			if (this.m_NowTag != ItemCfgType.ITCT_OTHER)
	//			{
	//				return;
	//			}
	//			Dictionary<ulong, PropsPlane.PropItemInfo> dictionary = this.m_mapItemInfo_Ta;
	//		}
	//		if (PropsPlane.m_keyA == propItemInfo.ITEM_STATIC_ID)
	//		{
	//			Color color = new Color(PropsPlane.m_MecJoyKeyA.material.color.r * 0.2f, PropsPlane.m_MecJoyKeyA.material.color.g * 0.2f, PropsPlane.m_MecJoyKeyA.material.color.b * 0.2f, 255f);
	//			PropsPlane.m_MecJoyKeyA.material.SetColor("_Color", color);
	//			PropsPlane.m_pointerA = ptCmd;
	//			Player.Instance.m_RoleGrowDatas.E = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerA.targetObj.Data).ITEM_STATIC_ID;
	//			PropsPlane.m_keyA = propItemInfo.ITEM_STATIC_ID;
	//			PropsPlane.m_proA = color;
	//			PropsPlane.m_AValue.Text = propItemInfo.Count.ToString();
	//			SkillUIManager.m_AValue.Text = propItemInfo.Count.ToString();
	//			if (SkillUIManager.instance != null)
	//			{
	//				SkillUIManager.m_AValue.Text = "0";
	//				SkillUIManager.instance.SetOneItemTexture(0, PropsPlane.m_keyAPath, true, TYPE.ITEM_TYPE);
	//			}
	//			if (PropsPlane.m_effAIndex != -1)
	//			{
	//				Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effAIndex, true);
	//				PropsPlane.m_effAIndex = -1;
	//			}
	//		}
	//		if (PropsPlane.m_keyB == propItemInfo.ITEM_STATIC_ID)
	//		{
	//			Color color2 = new Color(PropsPlane.m_MecJoyKeyB.material.color.r * 0.2f, PropsPlane.m_MecJoyKeyB.material.color.g * 0.2f, PropsPlane.m_MecJoyKeyB.material.color.b * 0.2f, 255f);
	//			PropsPlane.m_MecJoyKeyB.material.SetColor("_Color", color2);
	//			PropsPlane.m_pointerB = ptCmd;
	//			Player.Instance.m_RoleGrowDatas.R = ((PropsPlane.PropItemInfo)PropsPlane.m_pointerB.targetObj.Data).ITEM_STATIC_ID;
	//			PropsPlane.m_keyB = propItemInfo.ITEM_STATIC_ID;
	//			PropsPlane.m_proB = color2;
	//			PropsPlane.m_BValue.Text = propItemInfo.Count.ToString();
	//			SkillUIManager.m_BValue.Text = propItemInfo.Count.ToString();
	//			if (SkillUIManager.instance != null)
	//			{
	//				SkillUIManager.m_BValue.Text = "0";
	//				SkillUIManager.instance.SetOneItemTexture(1, PropsPlane.m_keyBPath, true, TYPE.ITEM_TYPE);
	//			}
	//			if (PropsPlane.m_effBIndex != -1)
	//			{
	//				Singleton<GUIEffectManager>.GetInstance().RemoveEffect(PropsPlane.m_effBIndex, true);
	//				PropsPlane.m_effBIndex = -1;
	//			}
	//		}
	//		this.ClearLeftDesc();
	//		List<IUIListObject> list4;
	//		if (this.m_mapUINowGroup.TryGetValue(childTypeID, out list4))
	//		{
	//			this.UpdateListPos(childTypeID, list4);
	//		}
	//		if (PropsPlane.m_PropsList.Count == 0)
	//		{
	//			GameObject obj;
	//			if (this.m_mapUITypeNode.TryGetValue(childTypeID, out obj))
	//			{
	//				UnityEngine.Object.Destroy(obj);
	//				this.m_mapUITypeNode.Remove(childTypeID);
	//			}
	//			this.UpdateParentPos();
	//		}
	//		if (propItemInfo.TypeID.ToString() == "4")
	//		{
	//			if (list4.Count < 6)
	//			{
	//				PropsPlane.m_PropsList.slider.transform.active = false;
	//				this.m_UIC_TopSlider.active = false;
	//				this.m_UIC_BottomSlider.active = false;
	//			}
	//			else
	//			{
	//				PropsPlane.m_PropsList.slider.transform.active = true;
	//				this.m_UIC_TopSlider.active = true;
	//				this.m_UIC_BottomSlider.active = true;
	//			}
	//		}
	//	}
	//	else
	//	{
	//		if (!PropsPlane.m_PlaneObject.active || propItemInfo.Count <= 0)
	//		{
	//			return;
	//		}
	//		IUIListObject iuilistObject = (IUIListObject)ptCmd.targetObj;
	//		if (iuilistObject == null)
	//		{
	//			return;
	//		}
	//		Transform transform2 = iuilistObject.transform.FindChild("ItemCount");
	//		if (transform2 != null)
	//		{
	//			SpriteText component2 = transform2.GetComponent<SpriteText>();
	//			if (component2 != null)
	//			{
	//				component2.Text = propItemInfo.Count.ToString();
	//			}
	//			if (PropsPlane.m_keyA == propItemInfo.ITEM_STATIC_ID)
	//			{
	//				PropsPlane.m_proA = Color.gray;
	//			}
	//			if (PropsPlane.m_keyB == propItemInfo.ITEM_STATIC_ID)
	//			{
	//				PropsPlane.m_proB = Color.gray;
	//			}
	//		}
	//	}
	//	this.PushTextData();
	//}

	//// Token: 0x06000CD9 RID: 3289 RVA: 0x0006BC70 File Offset: 0x00069E70
	//private void ClearLeftDesc()
	//{
	//	if (null != this.m_UIDescTitle)
	//	{
	//		this.m_UIDescTitle.Text = string.Empty;
	//	}
	//	if (null != this.m_UISkillAttText)
	//	{
	//		this.m_UISkillAttText.maxWidth = 50f;
	//		this.m_UISkillAttText.Text = string.Empty;
	//	}
	//	if (null != this.m_UIDescText)
	//	{
	//		this.m_UIDescText.Text = string.Empty;
	//	}
	//	if (null != this.m_UIDescText0)
	//	{
	//		this.m_UIDescText0.Text = string.Empty;
	//	}
	//	if (null != this.m_UIIntro)
	//	{
	//		this.m_UIIntro.Text = string.Empty;
	//	}
	//	if (null != this.m_BigIco)
	//	{
	//		this.m_BigIco.GetComponent<MeshRenderer>().material.mainTexture = null;
	//		this.m_BigIco.GetComponent<MeshRenderer>().material.mainTexture = (Texture)ResourceLoader.Load("GameLegend/Icon/Item/biglock", typeof(Texture));
	//	}
	//}

	//// Token: 0x06000CDA RID: 3290 RVA: 0x0006BD88 File Offset: 0x00069F88
	//public override void Hide()
	//{
	//	if (null == PropsPlane.m_PlaneObject || null == PropsPlane.m_PropsList)
	//	{
	//		return;
	//	}
	//	this.ClearList();
	//	Vector3 zero = Vector3.zero;
	//	if (PropsPlane.m_PlaneObject.activeSelf && Singleton<EZGUIManager>.GetInstance().GetGUI<BuffGUI>() != null && Singleton<EZGUIManager>.GetInstance().GetGUI<BuffGUI>()._buffPanel != null && PropsPlane.m_postion != zero)
	//	{
	//		BuffGUI gui = Singleton<EZGUIManager>.GetInstance().GetGUI<BuffGUI>();
	//		gui._buffPanel.transform.FindChild("Buff1").position = PropsPlane.m_postionBuff1;
	//		gui._buffPanel.transform.FindChild("Buff2").position = PropsPlane.m_postionBuff2;
	//		gui._buffPanel.transform.FindChild("Buff3").position = PropsPlane.m_postionBuff3;
	//		gui._buffPanel.transform.FindChild("Buff4").position = PropsPlane.m_postionBuff4;
	//		PropsPlane.m_postion = Vector3.zero;
	//	}
	//	this.ClearData(ItemCfgType.ITCT_PELLET, true);
	//	this.m_rightFourMenu.CloseMenu(false);
	//	PropsPlane.m_PlaneObject.SetActiveRecursively(false);
	//}

	//// Token: 0x06000CDB RID: 3291 RVA: 0x0006BEC0 File Offset: 0x0006A0C0
	//public override void Show()
	//{
	//	if (null == PropsPlane.m_PlaneObject || null == PropsPlane.m_PropsList)
	//	{
	//		return;
	//	}
	//	this.ClearData(ItemCfgType.ITCT_PELLET, true);
	//	Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>()._buttonProp.transform.FindChild("ItemNew").active = false;
	//	BoxCollider component = PropsPlane.m_PlaneObject.GetComponent<BoxCollider>();
	//	if (component != null)
	//	{
	//		component.enabled = false;
	//	}
	//	PropsPlane.m_listCount = false;
	//	this.m_ListParentPrefab = (ResourceLoader.Load("EZGUI/ItemParent_prop", typeof(GameObject)) as GameObject);
	//	this.m_ListChildPrefab = (ResourceLoader.Load("EZGUI/ItemChild_prop", typeof(GameObject)) as GameObject);
	//	PropsPlane.m_PlaneObject.SetActiveRecursively(true);
	//	if (Singleton<EZGUIManager>.GetInstance().GetGUI("SystemPlane") != null)
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SystemPlane>().ResetText(PropsPlane.m_PlaneObject.transform, 1);
	//	}
	//	this.AdjustPosition();
	//	this.PushData();
	//	this.PushTextData();
	//	if (Player.Instance._helpBase.m_HelpGroup.ContainsKey(1001009))
	//	{
	//		if (!Player.Instance._helpBase.m_HelpGroup.ContainsKey(1001010))
	//		{
	//			this.ChangeTag(ItemCfgType.ITCT_OTHER);
	//		}
	//		else
	//		{
	//			this.ChangeTag(ItemCfgType.ITCT_PELLET);
	//		}
	//	}
	//	else
	//	{
	//		this.ChangeTag(ItemCfgType.ITCT_PELLET);
	//	}
	//	this.setTopButton();
	//	if (Player.Instance._helpBase.m_HelpGroup.ContainsKey(1001009))
	//	{
	//		if (!Player.Instance._helpBase.m_HelpGroup.ContainsKey(1001010))
	//		{
	//			this.m_UIBT_Ta.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//			this.m_UIBT_Ta.controlIsEnabled = false;
	//			this.m_UIBT_Ta.transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//		}
	//		else
	//		{
	//			this.m_UIBT_Dan.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//			this.m_UIBT_Dan.controlIsEnabled = false;
	//			this.m_UIBT_Dan.transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//		}
	//	}
	//	else
	//	{
	//		this.m_UIBT_Dan.SetControlState(UIButton.CONTROL_STATE.ACTIVE);
	//		this.m_UIBT_Dan.controlIsEnabled = false;
	//		this.m_UIBT_Dan.transform.FindChild("ItemNew").GetComponent<UIButton>().active = false;
	//	}
	//	if (PropsPlane.m_PropsList.items.Count < 6)
	//	{
	//		PropsPlane.m_PropsList.slider.transform.active = false;
	//		this.m_UIC_TopSlider.active = false;
	//		this.m_UIC_BottomSlider.active = false;
	//	}
	//	this.UpdateParentPos();
	//	if (Player.Instance._helpBase.m_HelpGroup.ContainsKey(1001009) && !Player.Instance._helpBase.m_HelpGroup.ContainsKey(1001010))
	//	{
	//		GameData.Instance.ScrMan.Exec(44, 1001010);
	//	}
	//	SkillUIManager.m_AValue.Text = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.E);
	//	SkillUIManager.m_BValue.Text = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.R);
	//	PropsPlane.m_AValue.Text = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.E);
	//	PropsPlane.m_BValue.Text = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.R);
	//}

	//// Token: 0x06000CDC RID: 3292 RVA: 0x0006C258 File Offset: 0x0006A458
	//public void ShowBuff()
	//{
	//}

	//// Token: 0x06000CDD RID: 3293 RVA: 0x0006C25C File Offset: 0x0006A45C
	//public void CallE()
	//{
	//	if (PropsPlane.m_PlaneObject.active)
	//	{
	//		this.OnDLCickER(Player.Instance.m_RoleGrowDatas.E);
	//	}
	//	else if (!PropsPlane.m_PlaneObject.active)
	//	{
	//		PropsPlane.m_bType = true;
	//		GameData.Instance.ScrMan.Exec(34, ItemCfgType.ITCT_PELLET, Player.Instance.m_RoleGrowDatas.E);
	//	}
	//}

	//// Token: 0x06000CDE RID: 3294 RVA: 0x0006C2C8 File Offset: 0x0006A4C8
	//public void CallR()
	//{
	//	if (PropsPlane.m_PlaneObject.active)
	//	{
	//		this.OnDLCickER(Player.Instance.m_RoleGrowDatas.R);
	//	}
	//	if (!PropsPlane.m_PlaneObject.active)
	//	{
	//		PropsPlane.m_bType = true;
	//		GameData.Instance.ScrMan.Exec(34, ItemCfgType.ITCT_PELLET, Player.Instance.m_RoleGrowDatas.R);
	//	}
	//}

	//// Token: 0x06000CDF RID: 3295 RVA: 0x0006C330 File Offset: 0x0006A530
	//private void OnCallBootom(ref POINTER_INFO pt)
	//{
	//	switch (pt.evt)
	//	{
	//	case POINTER_INFO.INPUT_EVENT.PRESS:
	//		PropsPlane.m_bRotate = true;
	//		this.m_slider.Value += 0.005f;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.RELEASE:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.TAP:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.MOVE:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.MOVE_OFF:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.RELEASE_OFF:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	}
	//	if (PropsPlane.m_bRotate)
	//	{
	//		this.m_slider.Value += 0.005f;
	//	}
	//}

	//// Token: 0x06000CE0 RID: 3296 RVA: 0x0006C3E4 File Offset: 0x0006A5E4
	//private void OnCallTop(ref POINTER_INFO pt)
	//{
	//	switch (pt.evt)
	//	{
	//	case POINTER_INFO.INPUT_EVENT.PRESS:
	//		PropsPlane.m_bRotate = true;
	//		this.m_slider.Value -= 0.005f;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.RELEASE:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.TAP:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.MOVE:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.MOVE_OFF:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	case POINTER_INFO.INPUT_EVENT.RELEASE_OFF:
	//		PropsPlane.m_bRotate = false;
	//		break;
	//	}
	//	if (PropsPlane.m_bRotate)
	//	{
	//		this.m_slider.Value -= 0.005f;
	//	}
	//}

	//// Token: 0x04000D1F RID: 3359
	//public const string KEY_OBJ = "EZGUI/PropsPlane";

	//// Token: 0x04000D20 RID: 3360
	//public const string MED_OBJ = "EZGUI/DragItemChild_prop";

	//// Token: 0x04000D21 RID: 3361
	//public const string KEY_M_LAYER = "MidLayer";

	//// Token: 0x04000D22 RID: 3362
	//public const string KEY_R_LAYER = "RightLayer";

	//// Token: 0x04000D23 RID: 3363
	//public const string KEY_L_LAYER = "LeftLayer";

	//// Token: 0x04000D24 RID: 3364
	//public const string KEY_PP_LIST = "RightLayer/PP_List";

	//// Token: 0x04000D25 RID: 3365
	//public const string KEY_LIST_PB_CHILD = "EZGUI/ItemChild_prop";

	//// Token: 0x04000D26 RID: 3366
	//public const string KEY_LIST_PB_PARENT = "EZGUI/ItemParent_prop";

	//// Token: 0x04000D27 RID: 3367
	//private const string rightMenuItemPath = "EZGUI/PropsPlane/PropsRightMenuItem";

	//// Token: 0x04000D28 RID: 3368
	//public const string IMAGEPATH = "GameLegend/Icon/Item/biglock";

	//// Token: 0x04000D29 RID: 3369
	//public static PropsPlane m_Inst;

	//// Token: 0x04000D2A RID: 3370
	//public static GameObject m_PlaneObject;

	//// Token: 0x04000D2B RID: 3371
	//public static GameObject m_PlaneMid;

	//// Token: 0x04000D2C RID: 3372
	//public static GameObject m_PlaneLeft;

	//// Token: 0x04000D2D RID: 3373
	//public static GameObject m_PlaneRight;

	//// Token: 0x04000D2E RID: 3374
	//public static GameObject m_MedicineObject;

	//// Token: 0x04000D2F RID: 3375
	//private SpriteText m_UIDescTitle;

	//// Token: 0x04000D30 RID: 3376
	//private SpriteText m_UISkillAttText;

	//// Token: 0x04000D31 RID: 3377
	//private SpriteText m_UIDescText;

	//// Token: 0x04000D32 RID: 3378
	//private SpriteText m_UIDescText0;

	//// Token: 0x04000D33 RID: 3379
	//private SpriteText m_UIIntro;

	//// Token: 0x04000D34 RID: 3380
	//private GameObject m_BigIco;

	//// Token: 0x04000D35 RID: 3381
	//private GameObject m_ListChildPrefab;

	//// Token: 0x04000D36 RID: 3382
	//public static UIScrollList m_PropsList;

	//// Token: 0x04000D37 RID: 3383
	//public Dictionary<ulong, PropsPlane.PropItemInfo> m_mapItemInfo_Dan = new Dictionary<ulong, PropsPlane.PropItemInfo>();

	//// Token: 0x04000D38 RID: 3384
	//public Dictionary<ulong, PropsPlane.PropItemInfo> m_mapItemInfo_Cai = new Dictionary<ulong, PropsPlane.PropItemInfo>();

	//// Token: 0x04000D39 RID: 3385
	//public Dictionary<ulong, PropsPlane.PropItemInfo> m_mapItemInfo_Ta = new Dictionary<ulong, PropsPlane.PropItemInfo>();

	//// Token: 0x04000D3A RID: 3386
	//private Dictionary<int, List<PropsPlane.PropItemInfo>> m_mapNowTypeGroup = new Dictionary<int, List<PropsPlane.PropItemInfo>>();

	//// Token: 0x04000D3B RID: 3387
	//private Dictionary<int, List<IUIListObject>> m_mapUINowGroup = new Dictionary<int, List<IUIListObject>>();

	//// Token: 0x04000D3C RID: 3388
	//private Dictionary<int, GameObject> m_mapUITypeNode = new Dictionary<int, GameObject>();

	//// Token: 0x04000D3D RID: 3389
	//private Dictionary<string, IUIListObject> m_mapItmeInfo_NEW = new Dictionary<string, IUIListObject>();

	//// Token: 0x04000D3E RID: 3390
	//public Dictionary<ulong, PropsPlane.PropItemInfo> m_mapItemInfo_DiuQi = new Dictionary<ulong, PropsPlane.PropItemInfo>();

	//// Token: 0x04000D3F RID: 3391
	//public Dictionary<string, CItemBase> m_addAtt = new Dictionary<string, CItemBase>();

	//// Token: 0x04000D40 RID: 3392
	//private Dictionary<int, UIButton> m_topButton = new Dictionary<int, UIButton>();

	//// Token: 0x04000D41 RID: 3393
	//private List<IUIListObject> _list_new = new List<IUIListObject>();

	//// Token: 0x04000D42 RID: 3394
	//private List<IUIListObject> _list_old = new List<IUIListObject>();

	//// Token: 0x04000D43 RID: 3395
	//private bool IsBuild;

	//// Token: 0x04000D44 RID: 3396
	//private string fLastKey = "nokey";

	//// Token: 0x04000D45 RID: 3397
	//private float fLastTimer;

	//// Token: 0x04000D46 RID: 3398
	//private float fSpaceTimer = 0.3f;

	//// Token: 0x04000D47 RID: 3399
	//public UIButton m_UIBT_Dan;

	//// Token: 0x04000D48 RID: 3400
	//public UIButton m_UIBT_Cai;

	//// Token: 0x04000D49 RID: 3401
	//public UIButton m_UIBT_Ta;

	//// Token: 0x04000D4A RID: 3402
	//public UIButton m_UIBT_JoyKeyA;

	//// Token: 0x04000D4B RID: 3403
	//public UIButton m_UIBT_JoyKeyB;

	//// Token: 0x04000D4C RID: 3404
	//public UIButton m_UIC_TopSlider;

	//// Token: 0x04000D4D RID: 3405
	//public UIButton m_UIC_BottomSlider;

	//// Token: 0x04000D4E RID: 3406
	//private ItemCfgType m_NowTag;

	//// Token: 0x04000D4F RID: 3407
	//private MeshRenderer m_MecRenderer;

	//// Token: 0x04000D50 RID: 3408
	//public static MeshRenderer m_MecJoyKeyA;

	//// Token: 0x04000D51 RID: 3409
	//public static MeshRenderer m_MecJoyKeyB;

	//// Token: 0x04000D52 RID: 3410
	//private UISimpleMenu m_rightFourMenu = new UISimpleMenu();

	//// Token: 0x04000D53 RID: 3411
	//private GameObject m_ListParentPrefab;

	//// Token: 0x04000D54 RID: 3412
	//private ItemCfgType m_pType;

	//// Token: 0x04000D55 RID: 3413
	//private static ulong m_Index;

	//// Token: 0x04000D56 RID: 3414
	//public static ulong m_keyA = 0UL;

	//// Token: 0x04000D57 RID: 3415
	//public static ulong m_keyB = 0UL;

	//// Token: 0x04000D58 RID: 3416
	//private PropsPlane.PropItemInfo m_info;

	//// Token: 0x04000D59 RID: 3417
	//private static POINTER_INFO m_pointer;

	//// Token: 0x04000D5A RID: 3418
	//public static POINTER_INFO m_pointerA;

	//// Token: 0x04000D5B RID: 3419
	//public static POINTER_INFO m_pointerB;

	//// Token: 0x04000D5C RID: 3420
	//private POINTER_INFO m_ptCmd;

	//// Token: 0x04000D5D RID: 3421
	//private static bool m_listCount = false;

	//// Token: 0x04000D5E RID: 3422
	//public static Color m_proA = Color.black;

	//// Token: 0x04000D5F RID: 3423
	//public static Color m_proB = Color.black;

	//// Token: 0x04000D60 RID: 3424
	//private static Vector3 m_postion = Vector3.zero;

	//// Token: 0x04000D61 RID: 3425
	//private static Vector3 m_postionBuff1 = Vector3.zero;

	//// Token: 0x04000D62 RID: 3426
	//private static Vector3 m_postionBuff2 = Vector3.zero;

	//// Token: 0x04000D63 RID: 3427
	//private static Vector3 m_postionBuff3 = Vector3.zero;

	//// Token: 0x04000D64 RID: 3428
	//private static Vector3 m_postionBuff4 = Vector3.zero;

	//// Token: 0x04000D65 RID: 3429
	//private bool m_bCount;

	//// Token: 0x04000D66 RID: 3430
	//private static string m_keyAPath = "null";

	//// Token: 0x04000D67 RID: 3431
	//private static string m_keyBPath;

	//// Token: 0x04000D68 RID: 3432
	//private static bool m_bKeyA = false;

	//// Token: 0x04000D69 RID: 3433
	//private static bool m_bKeyB = false;

	//// Token: 0x04000D6A RID: 3434
	//public static bool m_bType = false;

	//// Token: 0x04000D6B RID: 3435
	//private static bool m_bRotate = false;

	//// Token: 0x04000D6C RID: 3436
	//private UISlider m_slider;

	//// Token: 0x04000D6D RID: 3437
	//private int m_bChuck;

	//// Token: 0x04000D6E RID: 3438
	//private bool m_bPos;

	//// Token: 0x04000D6F RID: 3439
	//private int m_count;

	//// Token: 0x04000D70 RID: 3440
	//private static PropsPlane.PropItemInfo m_infoDel;

	//// Token: 0x04000D71 RID: 3441
	//private static int m_effAIndex = -1;

	//// Token: 0x04000D72 RID: 3442
	//private static int m_effBIndex = -1;

	//// Token: 0x04000D73 RID: 3443
	//public static SpriteText m_AValue;

	//// Token: 0x04000D74 RID: 3444
	//public static SpriteText m_BValue;

	//// Token: 0x04000D75 RID: 3445
	//private bool _isnew1 = true;

	//// Token: 0x04000D76 RID: 3446
	//private bool _isnew2 = true;

	//// Token: 0x04000D77 RID: 3447
	//private bool m_bDragSound;

	//// Token: 0x020001FC RID: 508
	//public class PropItemInfo
	//{
	//	// Token: 0x06000CE1 RID: 3297 RVA: 0x0006C498 File Offset: 0x0006A698
	//	public PropItemInfo()
	//	{
	//		this.Clear();
	//	}

	//	// Token: 0x1700018A RID: 394
	//	// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x0006C4F0 File Offset: 0x0006A6F0
	//	public ulong ITEM_STATIC_ID
	//	{
	//		get
	//		{
	//			return this.nStaticID;
	//		}
	//	}

	//	// Token: 0x1700018B RID: 395
	//	// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x0006C4F8 File Offset: 0x0006A6F8
	//	public int Count
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return 0;
	//			}
	//			return this.Items.Count;
	//		}
	//	}

	//	// Token: 0x1700018C RID: 396
	//	// (get) Token: 0x06000CE4 RID: 3300 RVA: 0x0006C524 File Offset: 0x0006A724
	//	public string ParName
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			return this.Items[0].OriginalData.ITEM_CHILDTYPE_NAME;
	//		}
	//	}

	//	// Token: 0x1700018D RID: 397
	//	// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x0006C56C File Offset: 0x0006A76C
	//	public string Name
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			return this.Items[0].OriginalData.ITEM_NAME;
	//		}
	//	}

	//	// Token: 0x1700018E RID: 398
	//	// (get) Token: 0x06000CE6 RID: 3302 RVA: 0x0006C5B4 File Offset: 0x0006A7B4
	//	public string IcoPath
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			return this.Items[0].OriginalData.ITEM_ICOPATH_SMALL;
	//		}
	//	}

	//	// Token: 0x1700018F RID: 399
	//	// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x0006C5FC File Offset: 0x0006A7FC
	//	public string BigIcoPath
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			return this.Items[0].OriginalData.ITEM_ICOPATH_BIG;
	//		}
	//	}

	//	// Token: 0x17000190 RID: 400
	//	// (get) Token: 0x06000CE8 RID: 3304 RVA: 0x0006C644 File Offset: 0x0006A844
	//	public string SmallIcoPath
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			return this.Items[0].OriginalData.ITEM_ICOPATH_SMALL;
	//		}
	//	}

	//	// Token: 0x17000191 RID: 401
	//	// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x0006C68C File Offset: 0x0006A88C
	//	public string Unit
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			return this.Items[0].OriginalData.ITEM_UNITNAME;
	//		}
	//	}

	//	// Token: 0x17000192 RID: 402
	//	// (get) Token: 0x06000CEA RID: 3306 RVA: 0x0006C6D4 File Offset: 0x0006A8D4
	//	public int TypeID
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return 0;
	//			}
	//			return this.Items[0].OriginalData.ITEM_TYPE_ID;
	//		}
	//	}

	//	// Token: 0x17000193 RID: 403
	//	// (get) Token: 0x06000CEB RID: 3307 RVA: 0x0006C718 File Offset: 0x0006A918
	//	public int ChildTypeID
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return 0;
	//			}
	//			return this.Items[0].OriginalData.ITEM_CHILDTYPE_ID;
	//		}
	//	}

	//	// Token: 0x17000194 RID: 404
	//	// (get) Token: 0x06000CEC RID: 3308 RVA: 0x0006C75C File Offset: 0x0006A95C
	//	public string AttDesc1
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			if (this.Items[0].OriginalData.ITEM_ATTRIBUTES_MAP.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			this.lstKeys.Clear();
	//			if (this.Items[0].OriginalData.ITEM_ATTRIBUTE_COUNT > 0)
	//			{
	//				this.lstKeys.AddRange(this.Items[0].OriginalData.ITEM_ATTRIBUTES_MAP.Keys);
	//				for (int i = 0; i < this.lstKeys.Count; i++)
	//				{
	//					if (i <= 1)
	//					{
	//						this.strAttributeDesc[i] = ModAttribute.GetAttributeName(this.lstKeys[i]);
	//						string[] array = this.strAttributeDesc;
	//						int num = i;
	//						array[num] += this.strDivMark;
	//						float num2 = this.Items[0].OriginalData.ITEM_ATTRIBUTES_MAP[this.lstKeys[i]];
	//						string[] array2 = this.strAttributeDesc;
	//						int num3 = i;
	//						array2[num3] += ((num2 <= 0f) ? "-" : "+");
	//						string[] array3 = this.strAttributeDesc;
	//						int num4 = i;
	//						array3[num4] += num2.ToString();
	//					}
	//				}
	//			}
	//			return this.strAttributeDesc[0];
	//		}
	//	}

	//	// Token: 0x17000195 RID: 405
	//	// (get) Token: 0x06000CED RID: 3309 RVA: 0x0006C8D4 File Offset: 0x0006AAD4
	//	public int ScriptID
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return -1;
	//			}
	//			if (this.Items[0].OriginalData.ITEM_TO_MODEL_COUNT <= 0)
	//			{
	//				return -1;
	//			}
	//			string s;
	//			if (this.Items[0].OriginalData.ITEM_TO_MODELS.ContainsKey(ScrModType.SMT_Culture) && this.Items[0].OriginalData.ITEM_TO_MODELS.TryGetValue(ScrModType.SMT_Culture, out s))
	//			{
	//				return int.Parse(s);
	//			}
	//			return -1;
	//		}
	//	}

	//	// Token: 0x17000196 RID: 406
	//	// (get) Token: 0x06000CEE RID: 3310 RVA: 0x0006C96C File Offset: 0x0006AB6C
	//	public string AttDesc2
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			if (this.Items[0].OriginalData.ITEM_ATTRIBUTES_MAP.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			this.lstKeys.Clear();
	//			if (this.Items[0].OriginalData.ITEM_ATTRIBUTE_COUNT > 0)
	//			{
	//				this.lstKeys.AddRange(this.Items[0].OriginalData.ITEM_ATTRIBUTES_MAP.Keys);
	//				for (int i = 0; i < this.lstKeys.Count; i++)
	//				{
	//					if (i <= 1)
	//					{
	//						this.strAttributeDesc[i] = ModAttribute.GetAttributeName(this.lstKeys[i]);
	//						string[] array = this.strAttributeDesc;
	//						int num = i;
	//						array[num] += this.strDivMark;
	//						float num2 = this.Items[0].OriginalData.ITEM_ATTRIBUTES_MAP[this.lstKeys[i]];
	//						string[] array2 = this.strAttributeDesc;
	//						int num3 = i;
	//						array2[num3] += ((num2 <= 0f) ? "-" : "+");
	//						string[] array3 = this.strAttributeDesc;
	//						int num4 = i;
	//						array3[num4] += num2.ToString();
	//					}
	//				}
	//			}
	//			return this.strAttributeDesc[1];
	//		}
	//	}

	//	// Token: 0x17000197 RID: 407
	//	// (get) Token: 0x06000CEF RID: 3311 RVA: 0x0006CAE4 File Offset: 0x0006ACE4
	//	public string Desc
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			return this.Items[0].OriginalData.ITEM_DESC;
	//		}
	//	}

	//	// Token: 0x17000198 RID: 408
	//	// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x0006CB2C File Offset: 0x0006AD2C
	//	public string Intro
	//	{
	//		get
	//		{
	//			if (this.Items == null || this.Items.Count <= 0)
	//			{
	//				return string.Empty;
	//			}
	//			return this.Items[0].OriginalData.ITEM_INTRO;
	//		}
	//	}

	//	// Token: 0x06000CF1 RID: 3313 RVA: 0x0006CB74 File Offset: 0x0006AD74
	//	public void Add(CItemBase item)
	//	{
	//		if (item == null)
	//		{
	//			return;
	//		}
	//		this.Items.Add(item);
	//		this.nStaticID = item.ITEM_STATIC_ID;
	//	}

	//	// Token: 0x06000CF2 RID: 3314 RVA: 0x0006CB98 File Offset: 0x0006AD98
	//	public void Clear()
	//	{
	//		this.Items.Clear();
	//	}

	//	// Token: 0x04000D78 RID: 3448
	//	private string[] strAttributeDesc = new string[]
	//	{
	//		string.Empty,
	//		string.Empty
	//	};

	//	// Token: 0x04000D79 RID: 3449
	//	private string strDivMark = ":";

	//	// Token: 0x04000D7A RID: 3450
	//	private ulong nStaticID;

	//	// Token: 0x04000D7B RID: 3451
	//	public List<CItemBase> Items = new List<CItemBase>();

	//	// Token: 0x04000D7C RID: 3452
	//	private List<ATTRIBUTE_TYPE> lstKeys = new List<ATTRIBUTE_TYPE>();
	//}
}
