using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;


/// <summary>
/// 境界系统
/// </summary>
public class AmbitSystem
{
    private Dictionary<AMBITLEVEL, AmbitData> ambitData = new Dictionary<AMBITLEVEL, AmbitData>();

    private float currentRage;

    private Player player;

    private ModAttribute modAtt;

    private AmbitData currentData;

    private bool m_bIsRage;

    private int effectId = -1;

    private float timeCount;

    private float lastTime;

    public bool IsInRage
	{
		get
		{
			return this.m_bIsRage;
		}
	}

	public float RageNum
	{
		get
		{
			return this.currentRage;
		}
	}

	//public float RagePecent
	//{
	//	get
	//	{
	//		return this.currentRage / this.GetCurrentData().MaxRage;
	//	}
	//}

	public int ModelChangeID
	{
		get
		{
			return this.currentData.BodyId;
		}
	}

	public void Init(Player owner)
	{
		this.ambitData = Singleton<AmbitStaticData>.GetInstance().GetAmbitData(1);
		if (owner == null)
		{
			return;
		}
		this.player = owner;
		this.modAtt = (this.player.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute);
		//this.CorrectLevel();
		//this.currentData = this.GetCurrentData();
		//int level = (int)this.AmbitLevel - 1;
		//AmbitData lastData = null;
		//if (this.IsLevelEffective(level))
		//{
		//	lastData = this.GetAmbitData((AMBITLEVEL)level);
		//}
		//this.SetPlayerAtt(this.currentData, lastData);
		//this.SetRageBar();
	}

	public void SetPlayerLevel(AMBITLEVEL level)
	{
		if (this.modAtt == null)
		{
			return;
		}
		//if (this.AmbitLevel == (float)level)
		//{
		//	return;
		//}
		if (level < AMBITLEVEL.LIANQI_MIDDLE || level > AMBITLEVEL.ZHUJI_MIDDLE)
		{
			return;
		}
		//AmbitData ambitData = this.GetCurrentData();
		if (level > AMBITLEVEL.LIANQI_MIDDLE && level <= AMBITLEVEL.ZHUJI_MIDDLE)
		{
			float num = 0f;
			while ((double)num <= 1.5)
			{
				//TimeOutManager.SetTimeOut(Main.Instance.transform, num, new Callback(this.GrowHP_MP));
				num += 0.15f;
			}
		}
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 0.3f, new Callback(PlayerGUI.Instance._pBar.GetComponent<UIBistateInteractivePanel>().Reveal));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 0.3f, new Callback(PlayerGUI.Instance._pBarBK.GetComponent<UIBistateInteractivePanel>().Reveal));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.1f, new Callback(PlayerGUI.Instance._pBar.GetComponent<UIBistateInteractivePanel>().Hide));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.1f, new Callback(PlayerGUI.Instance._pBarBK.GetComponent<UIBistateInteractivePanel>().Hide));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.9f, new Callback(PlayerGUI.Instance._pBar.GetComponent<UIBistateInteractivePanel>().Reveal));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.9f, new Callback(PlayerGUI.Instance._pBarBK.GetComponent<UIBistateInteractivePanel>().Reveal));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.9f, new Callback(PlayerGUI.Instance._pBar.GetComponent<UIBistateInteractivePanel>().Hide));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.9f, new Callback(PlayerGUI.Instance._pBarBK.GetComponent<UIBistateInteractivePanel>().Hide));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 0.3f, new Callback(PlayerGUI.Instance._pMP.GetComponent<UIBistateInteractivePanel>().Reveal));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 0.3f, new Callback(PlayerGUI.Instance._pMPBK.GetComponent<UIBistateInteractivePanel>().Reveal));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.1f, new Callback(PlayerGUI.Instance._pMP.GetComponent<UIBistateInteractivePanel>().Hide));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.1f, new Callback(PlayerGUI.Instance._pMPBK.GetComponent<UIBistateInteractivePanel>().Hide));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.9f, new Callback(PlayerGUI.Instance._pMP.GetComponent<UIBistateInteractivePanel>().Reveal));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.9f, new Callback(PlayerGUI.Instance._pMPBK.GetComponent<UIBistateInteractivePanel>().Reveal));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.9f, new Callback(PlayerGUI.Instance._pMP.GetComponent<UIBistateInteractivePanel>().Hide));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 1.9f, new Callback(PlayerGUI.Instance._pMPBK.GetComponent<UIBistateInteractivePanel>().Hide));
		//TimeOutManager.SetTimeOut(Main.Instance.transform, 2f, new Callback(PlayerGUI.Instance.SaveDATE));
		//this.AmbitLevel = (float)level;
		if (level == AMBITLEVEL.LIANQI_UPPER)
		{
			GameData.Instance.ScrMan.Exec(44, 1000049);
		}
		else if (level == AMBITLEVEL.ZHUJI_LOWER)
		{
			GameData.Instance.ScrMan.Exec(44, 1000052);
		}
		else if (level == AMBITLEVEL.ZHUJI_MIDDLE)
		{
			GameData.Instance.ScrMan.Exec(44, 1000056);
		}
		SingletonMono<EffectManager>.GetInstance().AddEffect(759, this.player.GetPos(), this.player.GetPos(), this.player.GetPos(), Quaternion.identity, null, false);
		//this.currentData = this.GetCurrentData();
		//if (ambitData.BodyId != this.currentData.BodyId && ambitData.BodyId != 1)
		//{
		//	RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(ambitData.BodyId);
		//	if (roleModelInfo != null)
		//	{
		//		//LoadMachine.DeleteAsset(roleModelInfo.Path, typeof(GameObject), false);
		//	}
		//	roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(this.currentData.BodyId);
		//	if (roleModelInfo != null)
		//	{
		//		ResourceLoader.Load(roleModelInfo.Path, typeof(GameObject));
		//	}
		//}
		//this.SetPlayerAtt(this.currentData, ambitData);
	}

	public void GrowHP_MP()
	{
		//PlayerGUI.Instance._pBar.width = PlayerGUI.Instance._pBar.width + 0.045f;
		//PlayerGUI.Instance._pBarBK.width = PlayerGUI.Instance._pBar.width * 1.11f;
		//PlayerGUI.Instance._pBarBK.SetCamera(GameObject.FindWithTag("UICam").GetComponent<Camera>());
		//PlayerGUI.Instance._cBloodProtagonist.transform.position = new Vector3(PlayerGUI.Instance._cBloodProtagonist.transform.position.x + 0.0162f, PlayerGUI.Instance._cBloodProtagonist.transform.position.y, PlayerGUI.Instance._cBloodProtagonist.transform.position.z);
		//PlayerGUI.Instance.__cBloodBK.transform.position = new Vector3(PlayerGUI.Instance.__cBloodBK.transform.position.x + 0.01705f, PlayerGUI.Instance.__cBloodBK.transform.position.y, PlayerGUI.Instance.__cBloodBK.transform.position.z);
		//PlayerGUI.Instance._pMP.width = PlayerGUI.Instance._pMP.width + 0.045f;
		//PlayerGUI.Instance._pMPBK.width = PlayerGUI.Instance._pMP.width * 1.135f;
		//PlayerGUI.Instance._pMPBK.SetCamera(GameObject.FindWithTag("UICam").GetComponent<Camera>());
		//PlayerGUI.Instance._cMpProtagonist.transform.position = new Vector3(PlayerGUI.Instance._cMpProtagonist.transform.position.x + 0.0145f, PlayerGUI.Instance._cMpProtagonist.transform.position.y, PlayerGUI.Instance._cMpProtagonist.transform.position.z);
		//PlayerGUI.Instance._cMPBK.transform.position = new Vector3(PlayerGUI.Instance._cMPBK.transform.position.x + 0.01705f, PlayerGUI.Instance._cMPBK.transform.position.y, PlayerGUI.Instance._cMPBK.transform.position.z);
	}

	private void SetPlayerAtt(AmbitData data, AmbitData lastData)
	{
		float num = 0f;
		float num2 = 0f;
		//float attributeBaseNum = this.modAtt.GetAttributeBaseNum(ATTRIBUTE_TYPE.ATT_MAXHP);
		//float attributeBaseNum2 = this.modAtt.GetAttributeBaseNum(ATTRIBUTE_TYPE.ATT_MAXMP);
		if (lastData != null)
		{
			//if (lastData.BaseHP <= attributeBaseNum)
			//{
			//	num = attributeBaseNum - lastData.BaseHP;
			//}
			//if (lastData.BaseMP <= attributeBaseNum2)
			//{
			//	num2 = attributeBaseNum2 - lastData.BaseMP;
			//}
		}
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_MAXHP, num + data.BaseHP, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_MAXMP, num2 + data.BaseMP, true);
		this.modAtt.SetAttributeNum(ATTRIBUTE_TYPE.ATT_HP, this.modAtt.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP), false);
		//this.modAtt.UpdateAttributePercent(ATTRIBUTE_TYPE.ATT_MP, 1f, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_MAG_ATK, data.BaseMagicAttack, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_MAG_DEF, data.BaseMagicDefense, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_PHY_ATK, data.BaseAttack, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_PHY_DEF, data.BaseDefense, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_METAL_ELEMENT, data.ElementMetal, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_WOOD_ELEMENT, data.ElementWood, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_WATER_ELEMENT, data.ElementWater, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_FIRE_ELEMENT, data.ElementFire, true);
		this.modAtt.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT, data.ElementEarth, true);
	}

	public void LevelUp()
	{
		this.LevelUp(1);
	}

	public void LevelUp(int num)
	{
		//float level = this.AmbitLevel + (float)num;
		//AMBITLEVEL playerLevel = AmbitSystem.ConvertLevel(level);
		//this.SetPlayerLevel(playerLevel);
		//GameData.Instance.ScrMan.Exec(10, "升级到：" + this.ambitData[AmbitSystem.ConvertLevel(this.AmbitLevel)].Name, 0);
	}

	public void AddRageSoule(float rageNum)
	{
		if (this.IsInRage)
		{
			return;
		}
		if (this.currentData.MaxRage <= 0f)
		{
			return;
		}
		float ragePer = this.GetRagePer();
		this.UpdateRageNum(rageNum);
		if (this.GetRagePer() >= 1f && ragePer < 1f)
		{
			SingletonMono<AudioManager>.GetInstance().PlaySound(SoundType.gameSound, Vector3.zero, 5031, false);
			//if (Player.Instance.m_RoleGrowDatas.NQTip)
			//{
			//	GameData.Instance.ScrMan.Exec(44, 1000834);
			//}
			//Player.Instance.m_RoleGrowDatas.NQTip = true;
		}
		//this.SetRageBar();
	}

	// Token: 0x06001E53 RID: 7763 RVA: 0x000D2C74 File Offset: 0x000D0E74
	public void SetRageSoulePecent(float pecent)
	{
		if (this.IsInRage)
		{
			return;
		}
		if (this.currentData.MaxRage <= 0f)
		{
			return;
		}
		float rageNum = pecent * this.currentData.MaxRage;
		this.SetRageNum(rageNum);
		//this.SetRageBar();
	}

	// Token: 0x06001E54 RID: 7764 RVA: 0x000D2CC0 File Offset: 0x000D0EC0
	private void SetRageNum(float rageNum)
	{
		if (this.currentData.MaxRage <= 0f)
		{
			return;
		}
		this.currentRage = rageNum;
		if (this.currentRage < 0f)
		{
			this.currentRage = 0f;
			return;
		}
		float maxRage = this.currentData.MaxRage;
		if (this.currentRage > maxRage)
		{
			this.currentRage = maxRage;
		}
	}

	// Token: 0x06001E55 RID: 7765 RVA: 0x000D2D28 File Offset: 0x000D0F28
	private void SetRageNumToMax()
	{
		this.SetRageNum(this.currentData.MaxRage);
	}

	// Token: 0x06001E56 RID: 7766 RVA: 0x000D2D3C File Offset: 0x000D0F3C
	private void UpdateRageNum(float rageNum)
	{
		this.SetRageNum(this.currentRage + rageNum);
	}

	// Token: 0x06001E57 RID: 7767 RVA: 0x000D2D4C File Offset: 0x000D0F4C
	private void UpdateRagePer(float pecent)
	{
		float rageNum = pecent * this.currentData.MaxRage;
		this.UpdateRageNum(rageNum);
	}

	// Token: 0x06001E58 RID: 7768 RVA: 0x000D2D70 File Offset: 0x000D0F70
	private void SetRagePer(float pecent)
	{
		float rageNum = pecent * this.currentData.MaxRage;
		this.SetRageNum(rageNum);
	}

	// Token: 0x06001E59 RID: 7769 RVA: 0x000D2D94 File Offset: 0x000D0F94
	public bool IsRageFull()
	{
		return this.currentRage == this.currentData.MaxRage;
	}

	// Token: 0x06001E5A RID: 7770 RVA: 0x000D2DB4 File Offset: 0x000D0FB4
	public float GetRagePer()
	{
		if (this.currentData.MaxRage > 0f)
		{
			return this.currentRage / this.currentData.MaxRage;
		}
		return 0f;
	}

	// Token: 0x06001E5B RID: 7771 RVA: 0x000D2DE4 File Offset: 0x000D0FE4
	//public bool UseRageSkill()
	//{
	//	return this.currentRage > 0f && !this.m_bIsRage && this.ChangeState(true);
	//}

	// Token: 0x06001E5C RID: 7772 RVA: 0x000D2E20 File Offset: 0x000D1020
	public void StartRageTime()
	{
		this.m_bIsRage = true;
		this.lastTime = this.currentData.RageTime;
		if (this.lastTime <= 0f)
		{
			return;
		}
		this.RageStartPower();
		//this.SetBarNoEnd();
		this.timeCount = this.currentData.RageTime;
	}

	// Token: 0x06001E5D RID: 7773 RVA: 0x000D2E74 File Offset: 0x000D1074
	public void StopRageTime()
	{
		this.RageOverPower();
		//this.HideBar();
		this.timeCount = 0f;
	}

	// Token: 0x06001E5E RID: 7774 RVA: 0x000D2E90 File Offset: 0x000D1090
	public void StopRageImidiate()
	{
		this.StopRageTime();
		this.RecoverBody();
		this.m_bIsRage = false;
	}

	// Token: 0x06001E5F RID: 7775 RVA: 0x000D2EA8 File Offset: 0x000D10A8
	public void ForceStopRage()
	{
		if (this.IsInRage)
		{
			this.StopRageImidiate();
		}
	}

	// Token: 0x06001E60 RID: 7776 RVA: 0x000D2EBC File Offset: 0x000D10BC
	public bool StopRageSkill()
	{
		if (!this.m_bIsRage)
		{
			return false;
		}
		//if (!this.ChangeState(false))
		//{
		//	return false;
		//}
		this.StopRageTime();
		this.m_bIsRage = false;
		return true;
	}

	// Token: 0x06001E61 RID: 7777 RVA: 0x000D2EE8 File Offset: 0x000D10E8
	//private bool ChangeState(bool isEnter)
	//{
	//	QTERoleTransformer qteroleTransformer = new QTERoleTransformer();
	//	qteroleTransformer.IsEnter = isEnter;
	//	qteroleTransformer.Init(this.player);
	//	ControlEventQTE tmpEvent = new ControlEventQTE(false, qteroleTransformer);
	//	return this.player.modMFS.ChangeState(tmpEvent);
	//}

	// Token: 0x06001E62 RID: 7778 RVA: 0x000D2F30 File Offset: 0x000D1130
	public void SkillHotKey()
	{
		if (this.m_bIsRage)
		{
			this.StopRageSkill();
			return;
		}
		//this.UseRageSkill();
	}

	// Token: 0x06001E63 RID: 7779 RVA: 0x000D2F4C File Offset: 0x000D114C
	private void RageStartPower()
	{
	}

	// Token: 0x06001E64 RID: 7780 RVA: 0x000D2F50 File Offset: 0x000D1150
	private void RageOverPower()
	{
	}

	// Token: 0x06001E65 RID: 7781 RVA: 0x000D2F54 File Offset: 0x000D1154
	private void CreatEffect()
	{
		if (this.player == null)
		{
			return;
		}
		AmbitData ambitData = this.currentData;
		this.effectId = this.player.roleGameObject.BindEffect(CHILD_EFFECT_POINT.TOP, ambitData.EffectId, new Vector3(0f, -1f, 0f), Vector3.zero);
	}

	// Token: 0x06001E66 RID: 7782 RVA: 0x000D2FAC File Offset: 0x000D11AC
	private void DestroyEffect()
	{
		if (this.effectId >= 0)
		{
			SingletonMono<EffectManager>.GetInstance().Delete(this.effectId);
			this.effectId = -1;
		}
	}

	// Token: 0x06001E67 RID: 7783 RVA: 0x000D2FD4 File Offset: 0x000D11D4
	public void ChangeBody()
	{
		if (this.player.roleGameObject.ModelID == this.currentData.BodyId)
		{
			return;
		}
		GameObject roleBody = this.player.roleGameObject.RoleBody;
        Animator roleAnimator = this.player.roleGameObject.RoleAnimator;
		if (this.player.ChangeModel(this.currentData.BodyId, false))
		{
			//RoleBaseFun.CopyAnimation(roleAnimation, this.player.roleGameObject.RoleAnimation);
			UnityEngine.Object.Destroy(roleBody);
		}
	}

	// Token: 0x06001E68 RID: 7784 RVA: 0x000D305C File Offset: 0x000D125C
	public void RecoverBody()
	{
		if (this.player.roleGameObject.ModelID == 1)
		{
			return;
		}
		GameObject roleBody = this.player.roleGameObject.RoleBody;
        Animator roleAnimator = this.player.roleGameObject.RoleAnimator;
		if (this.player.ChangeModel(1, false))
		{
			//RoleBaseFun.CopyAnimation(roleAnimation, this.player.roleGameObject.RoleAnimation);
			UnityEngine.Object.Destroy(roleBody);
		}
	}

	//// Token: 0x06001E69 RID: 7785 RVA: 0x000D30D0 File Offset: 0x000D12D0
	//private AmbitData GetCurrentData()
	//{
	//	int key = (int)this.AmbitLevel;
	//	return this.ambitData[(AMBITLEVEL)key];
	//}

	//// Token: 0x06001E6A RID: 7786 RVA: 0x000D30F4 File Offset: 0x000D12F4
	//private AmbitData GetAmbitData(AMBITLEVEL level)
	//{
	//	if (this.ambitData.ContainsKey(level))
	//	{
	//		return this.ambitData[level];
	//	}
	//	return null;
	//}

	//// Token: 0x06001E6B RID: 7787 RVA: 0x000D3118 File Offset: 0x000D1318
	//private bool IsLevelEffective(int level)
	//{
	//	return level >= 1 && level <= 4;
	//}

	//// Token: 0x1700036C RID: 876
	//// (get) Token: 0x06001E6C RID: 7788 RVA: 0x000D312C File Offset: 0x000D132C
	//// (set) Token: 0x06001E6D RID: 7789 RVA: 0x000D314C File Offset: 0x000D134C
	////private float AmbitLevel
	////{
	////	get
	////	{
	////		if (this.modAtt == null)
	////		{
	////			return -1f;
	////		}
	////		return this.modAtt.GetAttributeBaseNum(ATTRIBUTE_TYPE.ATT_LEVEL);
	////	}
	////	set
	////	{
	////		if (this.modAtt == null)
	////		{
	////			return;
	////		}
	////		this.modAtt.SetAttributeNum(ATTRIBUTE_TYPE.ATT_LEVEL, value, true);
	////	}
	////}

	//// Token: 0x06001E6E RID: 7790 RVA: 0x000D3168 File Offset: 0x000D1368
	//private void CorrectLevel()
	//{
	//	AMBITLEVEL ambitlevel = AmbitSystem.ConvertLevel(this.AmbitLevel);
	//	this.AmbitLevel = (float)ambitlevel;
	//}

	//// Token: 0x06001E6F RID: 7791 RVA: 0x000D318C File Offset: 0x000D138C
	//public void Update()
	//{
	//	if (this.player == null)
	//	{
	//		return;
	//	}
	//	if (this.m_bIsRage)
	//	{
	//		this.UpdateRageNum(-(this.currentData.MaxRage / this.currentData.RageTime) * GameTime.deltaTime);
	//		this.UpdateUiProcess();
	//		if (this.currentRage <= 0f)
	//		{
	//			this.currentRage = 0f;
	//			if (this.player.modMFS.GetCurrentStateId() != CONTROL_STATE.QTE)
	//			{
	//				this.StopRageSkill();
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06001E70 RID: 7792 RVA: 0x000D3214 File Offset: 0x000D1414
	//public static AMBITLEVEL ConvertLevel(float level)
	//{
	//	int num = (int)level;
	//	if (num < 1)
	//	{
	//		num = 1;
	//	}
	//	else if (num > 4)
	//	{
	//		num = 4;
	//	}
	//	return (AMBITLEVEL)num;
	//}

	//// Token: 0x06001E71 RID: 7793 RVA: 0x000D323C File Offset: 0x000D143C
	//public AMBITLEVEL GetAmbitLevel()
	//{
	//	return AmbitSystem.ConvertLevel(this.AmbitLevel);
	//}

	//// Token: 0x06001E72 RID: 7794 RVA: 0x000D324C File Offset: 0x000D144C
	//public static string GetLevelName(float level)
	//{
	//	Dictionary<AMBITLEVEL, AmbitData> dictionary = Singleton<AmbitStaticData>.GetInstance().GetAmbitData(1);
	//	if (dictionary == null)
	//	{
	//		return string.Empty;
	//	}
	//	AmbitData ambitData = dictionary[AmbitSystem.ConvertLevel(level)];
	//	return ambitData.Name;
	//}

	//// Token: 0x06001E73 RID: 7795 RVA: 0x000D3284 File Offset: 0x000D1484
	//private void SetRageBar()
	//{
	//	if (SkillUIManager.instance != null)
	//	{
	//		SkillUIManager.instance.SetRageBarProgress(this.GetRagePer());
	//	}
	//}

	//// Token: 0x06001E74 RID: 7796 RVA: 0x000D32B4 File Offset: 0x000D14B4
	//public void SetBarNoEnd()
	//{
	//	if (this.currentData.RageTime <= 0f)
	//	{
	//		return;
	//	}
	//	AmbitRagePlane gui = Singleton<EZGUIManager>.GetInstance().GetGUI<AmbitRagePlane>();
	//	if (gui == null)
	//	{
	//		return;
	//	}
	//	gui.ShowBar(true);
	//}

	//// Token: 0x06001E75 RID: 7797 RVA: 0x000D32F8 File Offset: 0x000D14F8
	//public void SetBarTime()
	//{
	//	if (this.currentData.RageTime <= 0f)
	//	{
	//		return;
	//	}
	//	AmbitRagePlane gui = Singleton<EZGUIManager>.GetInstance().GetGUI<AmbitRagePlane>();
	//	if (gui == null)
	//	{
	//		return;
	//	}
	//	gui.ResetBarTime(10f);
	//}

	//// Token: 0x06001E76 RID: 7798 RVA: 0x000D3340 File Offset: 0x000D1540
	//public void HideBar()
	//{
	//	if (this.currentData.RageTime <= 0f)
	//	{
	//		return;
	//	}
	//	AmbitRagePlane gui = Singleton<EZGUIManager>.GetInstance().GetGUI<AmbitRagePlane>();
	//	if (gui == null)
	//	{
	//		return;
	//	}
	////	gui.HideBar();
	////}

	//// Token: 0x06001E77 RID: 7799 RVA: 0x000D3384 File Offset: 0x000D1584
	//private void UpdateUiProcess()
	//{
	//	this.SetRageBar();
	//}

	//// Token: 0x06001E78 RID: 7800 RVA: 0x000D338C File Offset: 0x000D158C
	//private bool TryGetAddPecent(ref Dictionary<ATTRIBUTE_TYPE, float> addPecent)
	//{
	//	addPecent.Clear();
	//	if (!this.IsInRage)
	//	{
	//		addPecent.Add(ATTRIBUTE_TYPE.ATT_MAG_ATK, 0f);
	//		addPecent.Add(ATTRIBUTE_TYPE.ATT_MAG_DEF, 0f);
	//		addPecent.Add(ATTRIBUTE_TYPE.ATT_PHY_ATK, 0f);
	//		addPecent.Add(ATTRIBUTE_TYPE.ATT_PHY_DEF, 0f);
	//		return false;
	//	}
	//	addPecent.Add(ATTRIBUTE_TYPE.ATT_MAG_ATK, this.currentData.AddMagicAttackPer);
	//	addPecent.Add(ATTRIBUTE_TYPE.ATT_MAG_DEF, this.currentData.AddMagicDefensePer);
	//	addPecent.Add(ATTRIBUTE_TYPE.ATT_PHY_ATK, this.currentData.AddAttackPer);
	//	addPecent.Add(ATTRIBUTE_TYPE.ATT_PHY_DEF, this.currentData.AddDefensePer);
	//	return true;
	//}

	//// Token: 0x06001E79 RID: 7801 RVA: 0x000D3438 File Offset: 0x000D1638
	//public float GetAddAttackPer(bool isPhy)
	//{
	//	if (this.currentData == null)
	//	{
	//		return 0f;
	//	}
	//	if (isPhy)
	//	{
	//		return (!this.IsInRage) ? 0f : this.currentData.AddAttackPer;
	//	}
	//	return (!this.IsInRage) ? 0f : this.currentData.AddMagicAttackPer;
	//}

	//// Token: 0x06001E7A RID: 7802 RVA: 0x000D34A0 File Offset: 0x000D16A0
	//public float GetAddDefPer(bool isPhy)
	//{
	//	if (this.currentData == null)
	//	{
	//		return 0f;
	//	}
	//	if (isPhy)
	//	{
	//		return (!this.IsInRage) ? 0f : this.currentData.AddDefensePer;
	//	}
	//	return (!this.IsInRage) ? 0f : this.currentData.AddMagicDefensePer;
	//}

	//// Token: 0x06001E7B RID: 7803 RVA: 0x000D3508 File Offset: 0x000D1708
	//public void GetSaveData(SaveData.SDAmbit data)
	//{
	//	this.SetRageNum(data.Energy);
	//	this.CorrectLevel();
	//	this.currentData = this.GetCurrentData();
	//	this.SetRageBar();
	//}
}
