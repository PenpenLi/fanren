using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色成长数据
/// </summary>
public class RoleGrowData
{
    public bool bFirstPickPill;

    public bool m_bFirstPickWeapon;

    public bool bFirstPickClothes;

    public bool bFirstPropsPlane;

    public bool bFirstAdeptTalentPlane;

    public bool bFirstEquipPlane;

    public bool bFirstGUIPlayerSkill;

    public bool bFirstSynopsisPlane;

    public bool bFirstSystemPlane;

    public bool bFirstHerbal;

    public bool bFirstPickMagicWeapon;

    public bool bFirstPickZWeapon;

    public bool m_bFirstTask;

    public bool bFuZhi;

    public bool bSkill;

    public bool bNQ;

    public bool bHunZhi;

    public int dan_count;

    public Dictionary<int, bool> _dicNPC = new Dictionary<int, bool>();

    public List<string> m_EquipItmeInfo_NEW = new List<string>();

    public List<string> m_PropItmeInfo_NEW = new List<string>();

    public List<string> m_GBItmeInfo_NEW = new List<string>();

    public List<string> m_GFItmeInfo_NEW = new List<string>();

    public List<string> _Pick = new List<string>();

    public string m_proE = "EZGUI/Main/AlphaTrans";

    public string m_proR = "EZGUI/Main/AlphaTrans";

    public string m_proECount = string.Empty;

    public string m_proRCount = string.Empty;

    public float FuNum;

    public float MaxFuNum = 1f;

    public bool bFirstMission;

    public bool bAmulet;

    public bool bWare;

    public bool bCQQ;

    public bool bLZKL;

    public bool bSJH;

    public bool bKL;

    public float HP = 7.15f;

    public float HPBK = 7.89f;

    public float MP = 6.35f;

    public float MPBK = 7.25f;

    public float HP_pos = 1.326496f;

    public float HPBK_pos = 1.670865f;

    public float MP_pos = 0.940154f;

    public float MPBK_pos = 1.336201f;

    public int JINGJIE_Shen;

    public int JINGJIE_Ti;

    public float Skill_enager;

    public bool NQTip;

    public ulong E;

    public ulong R;

    public bool bFirstPickWeapon
	{
		get
		{
			return this.m_bFirstPickWeapon;
		}
		set
		{
			this.m_bFirstPickWeapon = value;
		}
	}

	public void Init()
	{
		this.bFirstPickPill = true;
		this.bFirstPickWeapon = true;
		this.bFirstPickClothes = true;
		this.bFirstPropsPlane = true;
		this.bFirstAdeptTalentPlane = true;
		this.bFirstEquipPlane = true;
		this.bFirstGUIPlayerSkill = true;
		this.bFirstSynopsisPlane = true;
		this.bFirstSystemPlane = true;
		this.bFirstHerbal = true;
		this.dan_count = 0;
		this.bFirstMission = true;
		this.bAmulet = true;
		this.bWare = true;
		this.bFirstPickMagicWeapon = true;
		this.bFirstPickZWeapon = true;
		this.bCQQ = true;
		this.bLZKL = true;
		this.bSJH = true;
		this.bKL = true;
		this.bFuZhi = false;
		this.bNQ = false;
		this.bSkill = false;
		this.bHunZhi = false;
		this._dicNPC = new Dictionary<int, bool>();
		this.m_EquipItmeInfo_NEW = new List<string>();
		this.m_PropItmeInfo_NEW = new List<string>();
		this.m_GBItmeInfo_NEW = new List<string>();
		this.m_GFItmeInfo_NEW = new List<string>();
		this._Pick = new List<string>();
		this.HP = 7.15f;
		this.HPBK = 7.89f;
		this.MP = 6.35f;
		this.MPBK = 7.25f;
		this.HP_pos = 1.326496f;
		this.HPBK_pos = 1.670865f;
		this.MP_pos = 0.940154f;
		this.MPBK_pos = 1.336201f;
		this.JINGJIE_Shen = 0;
		this.JINGJIE_Ti = 0;
		this.m_proE = "EZGUI/Main/AlphaTrans";
		this.m_proR = "EZGUI/Main/AlphaTrans";
		this.m_proECount = string.Empty;
		this.m_proRCount = string.Empty;
		this.FuNum = 0f;
		this.MaxFuNum = 1f;
		this.Skill_enager = 0f;
		this.NQTip = false;
		this.E = 0UL;
		this.R = 0UL;
	}

	//public void PushData(RoleGrowDataSaveData data)
	//{
	//	if (data == null)
	//	{
	//		return;
	//	}
	//	this.Clear();
	//	this.bFirstPickPill = data.bFirstPickPill;
	//	this.bFirstPickWeapon = data.bFirstPickWeapon;
	//	this.bFirstPickClothes = data.bFirstPickClothes;
	//	this.bFirstPropsPlane = data.bFirstPropsPlane;
	//	this.bFirstAdeptTalentPlane = data.bFirstAdeptTalentPlane;
	//	this.bFirstEquipPlane = data.bFirstEquipPlane;
	//	this.bFirstGUIPlayerSkill = data.bFirstGUIPlayerSkill;
	//	this.bFirstSynopsisPlane = data.bFirstSynopsisPlane;
	//	this.bFirstSystemPlane = data.bFirstSystemPlane;
	//	this.bFirstHerbal = data.bFirstHerbal;
	//	this.dan_count = data.dan_count;
	//	this.bFirstMission = data.bFirstMission;
	//	this.bAmulet = data.bAmulet;
	//	this.bWare = data.bWare;
	//	this.bFirstPickMagicWeapon = data.bFirstPickMagicWeapon;
	//	this.bFirstPickZWeapon = data.bFirstPickZWeapon;
	//	this.bCQQ = data.bCQQ;
	//	this.bLZKL = data.bLZKL;
	//	this.bSJH = data.bSJH;
	//	this.bKL = data.bKL;
	//	this._dicNPC = data._dicNPC;
	//	this.bNQ = data.bNQ;
	//	this.bSkill = data.bSkill;
	//	this.bHunZhi = data.bHunzhi;
	//	this.bFuZhi = data.bFuzhi;
	//	this.m_EquipItmeInfo_NEW = data.m_EquipItmeInfo_NEW;
	//	this.m_PropItmeInfo_NEW = data.m_PropItmeInfo_NEW;
	//	this.m_GBItmeInfo_NEW = data.m_GBItmeInfo_NEW;
	//	this.m_GFItmeInfo_NEW = data.m_GFItmeInfo_NEW;
	//	this._Pick = data._Pick;
	//	this.HP = data.HP;
	//	this.HPBK = data.HPBK;
	//	this.MP = data.MP;
	//	this.MPBK = data.MPBK;
	//	this.HP_pos = data.HP_pos;
	//	this.HPBK_pos = data.HPBK_pos;
	//	this.MP_pos = data.MP_pos;
	//	this.MPBK_pos = data.MPBK_pos;
	//	this.JINGJIE_Shen = data.JINGJIE_Shen;
	//	this.JINGJIE_Ti = data.JINGJIE_Ti;
	//	this.m_proE = data.m_proE;
	//	this.m_proR = data.m_proR;
	//	this.m_proRCount = data.m_proRCount;
	//	this.m_proECount = data.m_proECount;
	//	this.FuNum = data.FuNum;
	//	this.MaxFuNum = data.MaxFuNum;
	//	this.Skill_enager = data.Skill_enager;
	//	this.NQTip = data.NQTip;
	//	this.E = data.E;
	//	this.R = data.R;
	//	if (data.bNQ)
	//	{
	//		SkillUIManager.uiObject.transform.FindChild("Top/ITEM2").active = true;
	//	}
	//	else
	//	{
	//		SkillUIManager.uiObject.transform.FindChild("Top/ITEM2").active = false;
	//	}
	//	if (data.bSkill)
	//	{
	//		SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/skill").active = true;
	//	}
	//	else
	//	{
	//		SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/skill").active = false;
	//	}
	//	if (data.bFuzhi)
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cFLProtagonist.active = true;
	//	}
	//	else
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cFLProtagonist.active = false;
	//	}
	//	if (data.bHunzhi)
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cPlayerPanel.transform.FindChild("Player/Back/QH_Value").gameObject.active = true;
	//	}
	//	else
	//	{
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerGUI>()._cPlayerPanel.transform.FindChild("Player/Back/QH_Value").gameObject.active = false;
	//	}
	//	PlayerGUI.Instance._pBar.width = this.HP;
	//	PlayerGUI.Instance._pBarBK.width = this.HPBK;
	//	PlayerGUI.Instance._pBarBK.SetCamera(GameObject.FindWithTag("UICam").GetComponent<Camera>());
	//	PlayerGUI.Instance._pBar.transform.localPosition = new Vector3(this.HP_pos, PlayerGUI.Instance._pBar.transform.localPosition.y, PlayerGUI.Instance._pBar.transform.localPosition.z);
	//	PlayerGUI.Instance._pBarBK.transform.localPosition = new Vector3(this.HPBK_pos, PlayerGUI.Instance._pBarBK.transform.localPosition.y, PlayerGUI.Instance._pBarBK.transform.localPosition.z);
	//	PlayerGUI.Instance._pMP.width = this.MP;
	//	PlayerGUI.Instance._pMPBK.width = this.MPBK;
	//	PlayerGUI.Instance._pMPBK.SetCamera(GameObject.FindWithTag("UICam").GetComponent<Camera>());
	//	PlayerGUI.Instance._pMP.transform.localPosition = new Vector3(this.MP_pos, PlayerGUI.Instance._pMP.transform.localPosition.y, PlayerGUI.Instance._pMP.transform.localPosition.z);
	//	PlayerGUI.Instance._pMPBK.transform.localPosition = new Vector3(this.MPBK_pos, PlayerGUI.Instance._pMPBK.transform.localPosition.y, PlayerGUI.Instance._pMPBK.transform.localPosition.z);
	//	PlayerGUI.Instance.SetFULUBarProgress(this.FuNum, this.MaxFuNum);
	//	if (this.m_proE != "NULL" && this.m_proE != "EZGUI/Main/AlphaTrans")
	//	{
	//		SkillUIManager.m_AValue.Text = this.m_proECount;
	//		SkillUIManager.instance.SetOneItemTexture(0, this.m_proE, true, TYPE.ALL);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().E_mesh.material.mainTexture = (Texture)ResourceLoader.Load(this.m_proE, typeof(Texture));
	//		PropsPlane.m_MecJoyKeyA.material.mainTexture = (Texture)ResourceLoader.Load(this.m_proE, typeof(Texture));
	//		PropsPlane.m_AValue.Text = this.m_proECount;
	//		PropsPlane.m_AValue.Text = GameData.Instance.ItemMan.GetItemCount(this.E);
	//	}
	//	else
	//	{
	//		SkillUIManager.m_AValue.Text = string.Empty;
	//		SkillUIManager.instance.SetOneItemTexture(0, "GameLegend/Icon/Item/lock", true, TYPE.ALL);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().E_mesh.material.mainTexture = (Texture)ResourceLoader.Load("GameLegend/Icon/Item/lock", typeof(Texture));
	//		PropsPlane.m_MecJoyKeyA.material.mainTexture = (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture));
	//		PropsPlane.m_AValue.Text = string.Empty;
	//	}
	//	if (this.m_proR != "NULL" && this.m_proR != "EZGUI/Main/AlphaTrans")
	//	{
	//		SkillUIManager.m_BValue.Text = this.m_proRCount;
	//		SkillUIManager.instance.SetOneItemTexture(1, this.m_proR, true, TYPE.ALL);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().R_mesh.material.mainTexture = (Texture)ResourceLoader.Load(this.m_proR, typeof(Texture));
	//		PropsPlane.m_MecJoyKeyB.material.mainTexture = (Texture)ResourceLoader.Load(this.m_proR, typeof(Texture));
	//		PropsPlane.m_BValue.Text = this.m_proRCount;
	//		PropsPlane.m_BValue.Text = GameData.Instance.ItemMan.GetItemCount(this.R);
	//	}
	//	else
	//	{
	//		SkillUIManager.m_BValue.Text = string.Empty;
	//		SkillUIManager.instance.SetOneItemTexture(1, "GameLegend/Icon/Item/lock", true, TYPE.ALL);
	//		Singleton<EZGUIManager>.GetInstance().GetGUI<SkillUIManager>().R_mesh.material.mainTexture = (Texture)ResourceLoader.Load("GameLegend/Icon/Item/lock", typeof(Texture));
	//		PropsPlane.m_MecJoyKeyB.material.mainTexture = (Texture)ResourceLoader.Load("EZGUI/Main/AlphaTrans", typeof(Texture));
	//		PropsPlane.m_BValue.Text = string.Empty;
	//	}
	//}

	// Token: 0x06002434 RID: 9268 RVA: 0x000F53E0 File Offset: 0x000F35E0
	public void Clear()
	{
		this.bFirstPickPill = false;
		this.bFirstPickWeapon = false;
		this.bFirstPickClothes = false;
		this.bFirstPropsPlane = false;
		this.bFirstAdeptTalentPlane = false;
		this.bFirstEquipPlane = false;
		this.bFirstGUIPlayerSkill = false;
		this.bFirstSynopsisPlane = false;
		this.bFirstSystemPlane = false;
		this.bFirstHerbal = false;
		this.dan_count = 0;
		this.bFirstMission = false;
		this.bAmulet = false;
		this.bWare = false;
		this.bFirstPickZWeapon = false;
		this.bFirstPickMagicWeapon = false;
		this.bCQQ = false;
		this.bLZKL = false;
		this.bSJH = false;
		this.bKL = false;
		this.bSkill = false;
		this.bNQ = false;
		this.bFuZhi = false;
		this.bHunZhi = false;
		this._dicNPC.Clear();
		this.m_EquipItmeInfo_NEW.Clear();
		this.m_PropItmeInfo_NEW.Clear();
		this.m_GBItmeInfo_NEW.Clear();
		this.m_GFItmeInfo_NEW.Clear();
		this._Pick.Clear();
		this.HP = 7.15f;
		this.HPBK = 7.89f;
		this.MP = 6.35f;
		this.MPBK = 7.25f;
		this.HP_pos = 1.326496f;
		this.HPBK_pos = 1.670865f;
		this.MP_pos = 0.940154f;
		this.MPBK_pos = 1.336201f;
		this.JINGJIE_Shen = 0;
		this.JINGJIE_Ti = 0;
		this.m_proE = "EZGUI/Main/AlphaTrans";
		this.m_proR = "EZGUI/Main/AlphaTrans";
		this.m_proECount = string.Empty;
		this.m_proRCount = string.Empty;
		this.FuNum = 0f;
		this.MaxFuNum = 1f;
		this.Skill_enager = 0f;
		this.NQTip = false;
		this.E = 0UL;
		this.R = 0UL;
	}
}
