using System;
using System.Collections.Generic;
using UnityEngine;


public class EZGUIManager : Singleton<EZGUIManager>
{
    public static bool IsShowDialog = true;

    public static bool IsShowMovie;

    private static GameObject _cObj;

    public static GUIBind _BindRunTimeObj;

    private static bool _bFuntion;

    private static Camera _uiCamera;

    //private Dictionary<string, EventEZMsg> _EventList = new Dictionary<string, EventEZMsg>();

    private Dictionary<string, GUIBase> _mapGuiGroup = new Dictionary<string, GUIBase>();

    private Dictionary<string, GameObject> _menuList = new Dictionary<string, GameObject>();

    private string[] _escChild = new string[]
    {
        "EquipPlane",
        "PropsPlane",
        "AdeptTalentPlane",
        "GUIPlayerSkill",
        "MixtureSmeltPlane",
        "SynopsisPlane",
        "SystemPlane",
        "GreenBottle"
    };

    public static AudioSource _aEscOpen;

    public static AudioSource _aEscClose;

    // Token: 0x0400085E RID: 2142
    public static AudioSource _aEscClick;

    // Token: 0x0400085F RID: 2143
    public static AudioSource _aEscOver;

    // Token: 0x04000860 RID: 2144
    public static AudioSource _aPickOpen;

    // Token: 0x04000861 RID: 2145
    public static AudioSource _aMap;

    // Token: 0x04000862 RID: 2146
    public static AudioSource _aWeapon;

    // Token: 0x04000863 RID: 2147
    public static AudioSource _aPickAllPick;

    // Token: 0x04000864 RID: 2148
    public static AudioSource _aTagOne;

    // Token: 0x04000865 RID: 2149
    public static AudioSource _aTagTwo;

    // Token: 0x04000866 RID: 2150
    public static AudioSource _aDragWeapon;

    // Token: 0x04000867 RID: 2151
    public static AudioSource _aDragPills;

    // Token: 0x04000868 RID: 2152
    public static AudioSource _aDragItem;

    // Token: 0x04000869 RID: 2153
    public static AudioSource _aButtonTwoOver;

    // Token: 0x0400086A RID: 2154
    public static AudioSource _aButtonTwoClick;

    // Token: 0x0400086B RID: 2155
    public static AudioSource _aButtonThreeOver;

    // Token: 0x0400086C RID: 2156
    public static AudioSource _aButtonThreeClick;

    // Token: 0x0400086D RID: 2157
    public static AudioSource _aButtoFiveClick;

    // Token: 0x0400086E RID: 2158
    public static AudioSource _aRight;

    // Token: 0x0400086F RID: 2159
    public static AudioSource _aGou;

    // Token: 0x04000870 RID: 2160
    public static AudioSource _aClickMenu;

    // Token: 0x04000871 RID: 2161
    public static AudioSource _aClick;

    // Token: 0x04000872 RID: 2162
    public static AudioSource _aQuest;

    // Token: 0x04000873 RID: 2163
    public static AudioSource _aSkillCancel;

    // Token: 0x04000874 RID: 2164
    public static AudioSource _aSkill;

    // Token: 0x04000875 RID: 2165
    public static AudioSource _aFuMan;

    // Token: 0x04000876 RID: 2166
    public static AudioSource _aNuqiMan;

    // Token: 0x04000877 RID: 2167
    public static AudioSource _aSucces;

    // Token: 0x04000878 RID: 2168
    public static AudioSource _aLianTi;

    // Token: 0x04000879 RID: 2169
    public static AudioSource _aLianShen;

    // Token: 0x0400087A RID: 2170
    public static AudioSource _aJTSuccse;

    // Token: 0x0400087B RID: 2171
    public static AudioSource _aHpMpGrow;

    // Token: 0x0400087C RID: 2172
    public static AudioSource _aTiShiKuang;

    public Transform ParentTrans
	{
		get
		{
			return EZGUIManager._cObj.transform;
		}
	}

	public static Camera UiCamera
	{
		get
		{
			if (EZGUIManager._uiCamera == null)
			{
				GameObject gameObject = GameObject.FindWithTag("UICam");
				if (gameObject != null)
				{
					EZGUIManager._uiCamera = gameObject.GetComponent<Camera>();
				}
				if (EZGUIManager._uiCamera == null)
				{
					Debug.LogError("UICam is no find!");
				}
			}
			return EZGUIManager._uiCamera;
		}
	}

	public bool Init()
	{
		//if (EZGUIManager._bFuntion)
		//{
		//	return false;
		//}
		EZGUIManager._cObj = new GameObject();
		EZGUIManager._cObj.name = "EZGUI";
		EZGUIManager._cObj = (UnityEngine.Object.Instantiate(EZGUIManager._cObj, Vector3.zero, Quaternion.identity) as GameObject);
		EZGUIManager._cObj.layer = 10;
		EZGUIManager._cObj.transform.parent = GameObject.FindWithTag("UICam").transform;
		EZGUIManager._BindRunTimeObj = EZGUIManager._cObj.AddComponent<GUIBind>();
		//this.SetSound();
		return true;
	}

    //public void SetSound()
    //{
    //	GameData.Instance.soundTable.initialize();
    //	EZGUIManager._aEscOpen = EZGUIManager.CreatAudio(5004);
    //	EZGUIManager._aEscClose = EZGUIManager.CreatAudio(5005);
    //	EZGUIManager._aEscClick = EZGUIManager.CreatAudio(5024);
    //	EZGUIManager._aEscOver = EZGUIManager.CreatAudio(5025);
    //	EZGUIManager._aPickOpen = EZGUIManager.CreatAudio(5012);
    //	EZGUIManager._aMap = EZGUIManager.CreatAudio(5013);
    //	EZGUIManager._aWeapon = EZGUIManager.CreatAudio(5003);
    //	EZGUIManager._aPickAllPick = EZGUIManager.CreatAudio(5026);
    //	EZGUIManager._aTagOne = EZGUIManager.CreatAudio(5007);
    //	EZGUIManager._aTagTwo = EZGUIManager.CreatAudio(5006);
    //	EZGUIManager._aDragWeapon = EZGUIManager.CreatAudio(5014);
    //	EZGUIManager._aDragPills = EZGUIManager.CreatAudio(5015);
    //	EZGUIManager._aDragItem = EZGUIManager.CreatAudio(5016);
    //	EZGUIManager._aButtonTwoOver = EZGUIManager.CreatAudio(5023);
    //	EZGUIManager._aButtonTwoClick = EZGUIManager.CreatAudio(5022);
    //	EZGUIManager._aButtonThreeOver = EZGUIManager.CreatAudio(5021);
    //	EZGUIManager._aButtonThreeClick = EZGUIManager.CreatAudio(5020);
    //	EZGUIManager._aButtoFiveClick = EZGUIManager.CreatAudio(5019);
    //	EZGUIManager._aRight = EZGUIManager.CreatAudio(5002);
    //	EZGUIManager._aGou = EZGUIManager.CreatAudio(5011);
    //	EZGUIManager._aClickMenu = EZGUIManager.CreatAudio(5017);
    //	EZGUIManager._aClick = EZGUIManager.CreatAudio(5018);
    //	EZGUIManager._aQuest = EZGUIManager.CreatAudio(5010);
    //	EZGUIManager._aSkillCancel = EZGUIManager.CreatAudio(5032);
    //	EZGUIManager._aSkill = EZGUIManager.CreatAudio(5033);
    //	EZGUIManager._aFuMan = EZGUIManager.CreatAudio(5028);
    //	EZGUIManager._aNuqiMan = EZGUIManager.CreatAudio(5031);
    //	EZGUIManager._aSucces = EZGUIManager.CreatAudio(5035);
    //	EZGUIManager._aLianShen = EZGUIManager.CreatAudio(5036);
    //	EZGUIManager._aLianTi = EZGUIManager.CreatAudio(5037);
    //	EZGUIManager._aJTSuccse = EZGUIManager.CreatAudio(5034);
    //	EZGUIManager._aHpMpGrow = EZGUIManager.CreatAudio(5029);
    //	EZGUIManager._aTiShiKuang = EZGUIManager.CreatAudio(5027);
    //}

    //// Token: 0x06000947 RID: 2375 RVA: 0x0002F400 File Offset: 0x0002D600
    //public static AudioSource CreatAudio(int id)
    //{
    //	if (SceneManager.Instance == null)
    //	{
    //		return null;
    //	}
    //	SoundData soundData = SingletonMono<AudioManager>.GetInstance().CreatNewSound(SoundType.gameSound, id, false);
    //	if (soundData == null)
    //	{
    //		return null;
    //	}
    //	AudioSource audioSource = soundData.audioSource;
    //	audioSource.transform.parent = SceneManager.Instance.transform;
    //	audioSource.transform.localPosition = Vector3.zero;
    //	return audioSource;
    //}

    //// Token: 0x06000948 RID: 2376 RVA: 0x0002F464 File Offset: 0x0002D664
    //public static void SetSoundEx(int id, AudioSource audio)
    //{
    //	if (audio != null)
    //	{
    //		audio.PlayOneShot(audio.clip);
    //	}
    //	else
    //	{
    //		GameData.Instance.soundTable.initialize();
    //		audio = EZGUIManager.CreatAudio(id);
    //		if (audio != null && audio.clip != null)
    //		{
    //			audio.PlayOneShot(audio.clip);
    //		}
    //	}
    //}

    public bool Register(GUIBase guiObj)
    {
        if (guiObj == null)
        {
            Debug.LogError(
                "EZGUIManager"+
                "Try Register UI Object is null"
);
            return false;
        }
        string name = guiObj.GetType().Name;
        if (!this._mapGuiGroup.ContainsKey(name))
        {
            if (!guiObj.IsInited)
            {
                if (!guiObj.Init())
                {
                    Debug.LogError(
                        "EZGUIManager"
                        +guiObj.GetType().Name + " Init Failed !"
                    );
                    return false;
                }
                guiObj.IsInited = true;
            }
            this._mapGuiGroup.Add(name, guiObj);
            return true;
        }
        return false;
    }

    //// Token: 0x0600094A RID: 2378 RVA: 0x0002F590 File Offset: 0x0002D790
    //public bool MenuGUI(string name, GameObject go)
    //{
    //	if (!this._menuList.ContainsKey(name))
    //	{
    //		this._menuList.Add(name, go);
    //		return true;
    //	}
    //	return false;
    //}

    //// Token: 0x0600094B RID: 2379 RVA: 0x0002F5B4 File Offset: 0x0002D7B4
    //public bool UnRegister(string strKey)
    //{
    //	if (!this._mapGuiGroup.ContainsKey(strKey))
    //	{
    //		return false;
    //	}
    //	this._mapGuiGroup.Remove(strKey);
    //	this.DeleteUIMessage(strKey);
    //	return true;
    //}

    //// Token: 0x0600094C RID: 2380 RVA: 0x0002F5E0 File Offset: 0x0002D7E0
    //public bool DeleteUIMessage(string strParentKey)
    //{
    //	if (!this._mapGuiGroup.ContainsKey(strParentKey))
    //	{
    //		return false;
    //	}
    //	string key = strParentKey + strParentKey;
    //	if (this._EventList.ContainsKey(key))
    //	{
    //		this._EventList.Remove(key);
    //		return true;
    //	}
    //	return false;
    //}

    //// Token: 0x0600094D RID: 2381 RVA: 0x0002F62C File Offset: 0x0002D82C
    //public bool DeleteUIChildMessage(string strParentKey, string strChildKey)
    //{
    //	if (!this._mapGuiGroup.ContainsKey(strParentKey))
    //	{
    //		return false;
    //	}
    //	string key = strParentKey + strChildKey;
    //	if (this._EventList.ContainsKey(key))
    //	{
    //		this._EventList.Remove(key);
    //		return true;
    //	}
    //	return false;
    //}

    //// Token: 0x0600094E RID: 2382 RVA: 0x0002F678 File Offset: 0x0002D878
    //public void Clear()
    //{
    //	this._mapGuiGroup.Clear();
    //	this._EventList.Clear();
    //}

    //// Token: 0x0600094F RID: 2383 RVA: 0x0002F690 File Offset: 0x0002D890
    //public GUIBase GetGUI(string strParentKey)
    //{
    //	if (this._mapGuiGroup.ContainsKey(strParentKey))
    //	{
    //		return this._mapGuiGroup[strParentKey];
    //	}
    //	return null;
    //}

    public T GetGUI<T>() where T : GUIBase
    {
        if (this._mapGuiGroup.ContainsKey(typeof(T).Name))
        {
            return (T)((object)this._mapGuiGroup[typeof(T).Name]);
        }
        return (T)((object)null);
    }

    //// Token: 0x06000951 RID: 2385 RVA: 0x0002F708 File Offset: 0x0002D908
    //public void HideAllActiveGO()
    //{
    //	foreach (GUIBase guibase in this._mapGuiGroup.Values)
    //	{
    //		guibase.Hide();
    //	}
    //}

    public void HideActiveGOEx(string name)
    {
        foreach (string text in this._mapGuiGroup.Keys)
        {
            GUIBase guibase;
            if (text != name && this._mapGuiGroup.TryGetValue(text, out guibase))
            {
                guibase.Hide();
            }
        }
    }

    //// Token: 0x06000953 RID: 2387 RVA: 0x0002F800 File Offset: 0x0002DA00
    //public void ShowBack()
    //{
    //	foreach (GUIBase guibase in this._mapGuiGroup.Values)
    //	{
    //		guibase.Show();
    //	}
    //}

    //// Token: 0x06000954 RID: 2388 RVA: 0x0002F86C File Offset: 0x0002DA6C
    //public bool HideActiveMenu()
    //{
    //	foreach (string text in this._menuList.Keys)
    //	{
    //		GameObject gameObject;
    //		if (this._menuList.TryGetValue(text, out gameObject))
    //		{
    //			if (gameObject.active && text != "BigMap")
    //			{
    //				if (this._mapGuiGroup.ContainsKey(text))
    //				{
    //					this._mapGuiGroup[text].Hide();
    //				}
    //				if (gameObject.active)
    //				{
    //					gameObject.SetActiveRecursively(false);
    //				}
    //				return true;
    //			}
    //			if (gameObject.transform.position.y != -1000f && text == "BigMap")
    //			{
    //				if (this._mapGuiGroup.ContainsKey(text))
    //				{
    //					this._mapGuiGroup[text].Hide();
    //				}
    //				return true;
    //			}
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06000955 RID: 2389 RVA: 0x0002F994 File Offset: 0x0002DB94
    //public bool HideActiveGO(string key, int type)
    //{
    //	if (type == 1)
    //	{
    //		string text = string.Empty;
    //		for (int i = 0; i < this._escChild.Length; i++)
    //		{
    //			if (this._escChild[i] != key)
    //			{
    //				if (this._escChild[i] != "MonsterGUI" && this._escChild[i] != "MinMap" && this._escChild[i] != "SkillUIManager" && this._escChild[i] != "BuffGUI" && this._escChild[i] != "PickPlane" && this._escChild[i] != "MinMapEz" && this._escChild[i] != "HelpPlane" && this._escChild[i] != "PlayerGUI" && this._escChild[i] != "TaskTrackPlane" && this._mapGuiGroup.ContainsKey(this._escChild[i]))
    //				{
    //					this._mapGuiGroup[this._escChild[i]].Hide();
    //				}
    //			}
    //			else
    //			{
    //				text = this._escChild[i];
    //			}
    //		}
    //		if (!string.IsNullOrEmpty(text) && text != "LoadingMain")
    //		{
    //			this._mapGuiGroup[text].Show();
    //		}
    //	}
    //	else if (type == 0)
    //	{
    //		foreach (string text2 in this._mapGuiGroup.Keys)
    //		{
    //			if (text2 != key)
    //			{
    //				if (text2 != "MonsterGUI" && text2 != "MinMap" && text2 != "SkillUIManager" && text2 != "BuffGUI" && text2 != "PickPlane" && text2 != "MinMapEz" && text2 != "HelpPlane" && text2 != "PlayerGUI" && text2 != "TaskTrackPlane")
    //				{
    //					this._mapGuiGroup[text2].Hide();
    //				}
    //			}
    //			else if (text2 != "LoadingMain")
    //			{
    //				this._mapGuiGroup[text2].Show();
    //			}
    //		}
    //	}
    //	MouseManager.ShowCursor(true);
    //	KeyManager.hotKeyEnabled = false;
    //	GameTime.Stop();
    //	return true;
    //}

    //// Token: 0x06000956 RID: 2390 RVA: 0x0002FC5C File Offset: 0x0002DE5C
    //public bool GUIForMovie(bool isShow)
    //{
    //	EZGUIManager.IsShowMovie = isShow;
    //	if (isShow)
    //	{
    //		foreach (string text in this._mapGuiGroup.Keys)
    //		{
    //			if (text == "MonsterGUI" || text == "SkillUIManager" || text == "MinMap" || text == "BuffGUI" || text == "MinMapEz" || text == "PlayerGUI")
    //			{
    //				this._mapGuiGroup[text].Show();
    //				if (GameObject.Find("Hp") != null)
    //				{
    //					GameObject.Find("Hp").SetActiveRecursively(true);
    //				}
    //			}
    //		}
    //		return true;
    //	}
    //	foreach (string text2 in this._mapGuiGroup.Keys)
    //	{
    //		if (text2 == "MonsterGUI" || text2 == "SkillUIManager" || text2 == "MinMap" || text2 == "BuffGUI" || text2 == "MinMapEz" || text2 == "PlayerGUI" || text2 == "TaskTrackPlane" || text2 == "BigMap" || text2 == "DieGUI")
    //		{
    //			this._mapGuiGroup[text2].Hide();
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06000957 RID: 2391 RVA: 0x0002FE5C File Offset: 0x0002E05C
    //public EventEZMsg RegisterEZMsg(GUI_TYPE cmd, string parentkey)
    //{
    //	EventEZMsg eventEZMsg = new EventEZMsg(cmd, parentkey, parentkey, false);
    //	string key = parentkey + parentkey;
    //	if (this._EventList.ContainsKey(key))
    //	{
    //		return this._EventList[key];
    //	}
    //	this._EventList.Add(key, eventEZMsg);
    //	return eventEZMsg;
    //}

    //// Token: 0x06000958 RID: 2392 RVA: 0x0002FEA8 File Offset: 0x0002E0A8
    //public EventEZMsg RegisterChildEZMsg(GUI_TYPE cmd, string parentkey, string childkey)
    //{
    //	if (parentkey == childkey)
    //	{
    //		return null;
    //	}
    //	EventEZMsg eventEZMsg = new EventEZMsg(cmd, parentkey, childkey, false);
    //	eventEZMsg._bIsChild = true;
    //	string key = parentkey + childkey;
    //	if (this._EventList.ContainsKey(key))
    //	{
    //		return this._EventList[key];
    //	}
    //	this._EventList.Add(key, eventEZMsg);
    //	return eventEZMsg;
    //}

    //// Token: 0x06000959 RID: 2393 RVA: 0x0002FF08 File Offset: 0x0002E108
    //public bool PostGUIEZMsg(GUI_TYPE type, string strParentKey, POINTER_INFO pt)
    //{
    //	if (!this._mapGuiGroup.ContainsKey(strParentKey))
    //	{
    //		return false;
    //	}
    //	this.GetGUI(strParentKey).OnEZMessage(type, pt);
    //	return true;
    //}

    //// Token: 0x0600095A RID: 2394 RVA: 0x0002FF38 File Offset: 0x0002E138
    //public bool PostGUIChildEZMsg(GUI_TYPE type, string strParentKey, string strChildKey, POINTER_INFO pt)
    //{
    //	if (!this._mapGuiGroup.ContainsKey(strParentKey))
    //	{
    //		return false;
    //	}
    //	this.GetGUI(strParentKey).OnChildEZMessage(type, strChildKey, pt);
    //	return true;
    //}

    //// Token: 0x0600095B RID: 2395 RVA: 0x0002FF6C File Offset: 0x0002E16C
    //public bool PostGUIMessage(GUI_TYPE type, string strParentKey, UnityEngine.Object pData)
    //{
    //	if (!this._mapGuiGroup.ContainsKey(strParentKey))
    //	{
    //		return false;
    //	}
    //	this.GetGUI(strParentKey).OnHandMessage(type, pData);
    //	return true;
    //}

    //// Token: 0x0600095C RID: 2396 RVA: 0x0002FF9C File Offset: 0x0002E19C
    //public bool PostGUIChildMessage(GUI_TYPE type, string strParentKey, string strChildKey, UnityEngine.Object pData)
    //{
    //	if (!this._mapGuiGroup.ContainsKey(strParentKey))
    //	{
    //		return false;
    //	}
    //	this.GetGUI(strParentKey).OnChildHandMessage(type, strChildKey, pData);
    //	return true;
    //}

    //// Token: 0x0600095D RID: 2397 RVA: 0x0002FFD0 File Offset: 0x0002E1D0
    //public void OnCommandGUIMessage(GUI_TYPE type, ATTRIBUTE_TYPE attributetype, object pData)
    //{
    //	if (this._mapGuiGroup.ContainsKey("EquipPlane"))
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<EquipPlane>().SetItemInfo(null, true, false);
    //	}
    //	if (this._mapGuiGroup.ContainsKey("PropsPlane") && PropsPlane.m_PlaneObject.activeSelf)
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<PropsPlane>().PushTextData();
    //	}
    //	if (this._mapGuiGroup.ContainsKey("ShopBuyPlane") && ShopBuyPlane.planeObj.activeSelf)
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<ShopBuyPlane>().PushData();
    //	}
    //	if (this._mapGuiGroup.ContainsKey("ShopSellPlane") && ShopSellPlane.planeObj.activeSelf)
    //	{
    //		Singleton<EZGUIManager>.GetInstance().GetGUI<ShopSellPlane>().PushData();
    //	}
    //}
}
