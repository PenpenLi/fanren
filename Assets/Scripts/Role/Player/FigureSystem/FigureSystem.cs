using System;
using System.Collections.Generic;
using UnityEngine;

public class FigureSystem
{
    private Player m_cPlayer;

    // Token: 0x04001D22 RID: 7458
    private int leftEffectId;

    // Token: 0x04001D23 RID: 7459
    private int rightEffectId;

    // Token: 0x04001D24 RID: 7460
    private List<int> learnedSkill = new List<int>();

    // Token: 0x04001D25 RID: 7461
    //private FigureSkillData.Data currentSkill;

    // Token: 0x04001D26 RID: 7462
    private float energy;

    // Token: 0x04001D27 RID: 7463
    private float maxEnergy;

    // Token: 0x04001D28 RID: 7464
    private float lastSkillTime;

    // Token: 0x04001D29 RID: 7465
    private int nextSkillIndex;

    public List<int> LearnedSkillID
	{
		get
		{
			return this.learnedSkill;
		}
	}

	// Token: 0x170003D6 RID: 982
	// (get) Token: 0x06002061 RID: 8289 RVA: 0x000DDEC0 File Offset: 0x000DC0C0
	public float Energy
	{
		get
		{
			return this.energy;
		}
	}

	// Token: 0x06002062 RID: 8290 RVA: 0x000DDEC8 File Offset: 0x000DC0C8
	public void Init(Player player)
	{
		this.m_cPlayer = player;
		//ModAttribute modAttribute = player.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
		Dictionary<AMBITLEVEL, AmbitData> ambitData = Singleton<AmbitStaticData>.GetInstance().GetAmbitData(1);
		//AmbitData ambitData2 = ambitData[AmbitSystem.ConvertLevel(modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_LEVEL))];
		//this.maxEnergy = ambitData2.MaxEnergy;
	}

	// Token: 0x06002063 RID: 8291 RVA: 0x000DDF14 File Offset: 0x000DC114
	//public void ResetSkill(int id)
	//{
	//	FigureSkillData.Data data = this.currentSkill;
	//	if (id == this.SkillID)
	//	{
	//		return;
	//	}
	//	FigureSkillData.Data figureSkillData = Singleton<FigureSkillData>.GetInstance().GetFigureSkillData(id);
	//	if (figureSkillData == null)
	//	{
	//		return;
	//	}
	//	this.currentSkill = figureSkillData;
	//	this.nextSkillIndex = 0;
	//	this.BindWeaponEffect();
	//}

	//// Token: 0x06002064 RID: 8292 RVA: 0x000DDF60 File Offset: 0x000DC160
	//public bool LearnSkill(int id)
	//{
	//	if (Singleton<FigureSkillData>.GetInstance().GetFigureSkillData(id) == null)
	//	{
	//		return false;
	//	}
	//	if (this.learnedSkill.Contains(id))
	//	{
	//		return false;
	//	}
	//	this.learnedSkill.Add(id);
	//	Debug.Log("learned figure skill " + id);
	//	return true;
	//}

	//// Token: 0x06002065 RID: 8293 RVA: 0x000DDFB8 File Offset: 0x000DC1B8
	//public void DetachSkill()
	//{
	//	this.StopSkill();
	//	this.currentSkill = null;
	//	this.DeleteWeaponEffect();
	//}

	//// Token: 0x06002066 RID: 8294 RVA: 0x000DDFD0 File Offset: 0x000DC1D0
	//public bool HasSkill(int id)
	//{
	//	return this.learnedSkill != null && this.learnedSkill.Contains(id);
	//}

	//// Token: 0x170003D7 RID: 983
	//// (get) Token: 0x06002067 RID: 8295 RVA: 0x000DDFF4 File Offset: 0x000DC1F4
	//public int SkillID
	//{
	//	get
	//	{
	//		return (this.currentSkill != null) ? this.currentSkill.ID : 0;
	//	}
	//}

	//// Token: 0x06002068 RID: 8296 RVA: 0x000DE014 File Offset: 0x000DC214
	//private void SetEnergyNum(float energyNum)
	//{
	//	if (this.maxEnergy <= 0f)
	//	{
	//		return;
	//	}
	//	this.energy = energyNum;
	//	if (this.energy < 0f)
	//	{
	//		this.energy = 0f;
	//		return;
	//	}
	//	if (this.energy > this.maxEnergy)
	//	{
	//		this.energy = this.maxEnergy;
	//	}
	//}

	//// Token: 0x06002069 RID: 8297 RVA: 0x000DE074 File Offset: 0x000DC274
	//private void SetEnergyNumToMax()
	//{
	//	this.SetEnergyNum(this.maxEnergy);
	//}

	//// Token: 0x0600206A RID: 8298 RVA: 0x000DE084 File Offset: 0x000DC284
	//private void UpdateEnergyNum(float energyNum)
	//{
	//	this.SetEnergyNum(this.energy + energyNum);
	//}

	//// Token: 0x0600206B RID: 8299 RVA: 0x000DE094 File Offset: 0x000DC294
	//private void UpdateEnergyPer(float pecent)
	//{
	//	float energyNum = pecent * this.maxEnergy;
	//	this.UpdateEnergyNum(energyNum);
	//}

	//// Token: 0x0600206C RID: 8300 RVA: 0x000DE0B4 File Offset: 0x000DC2B4
	//private void SetEnergyPer(float pecent)
	//{
	//	float energyNum = pecent * this.maxEnergy;
	//	this.SetEnergyNum(energyNum);
	//}

	//// Token: 0x0600206D RID: 8301 RVA: 0x000DE0D4 File Offset: 0x000DC2D4
	//public void AddFigureEnergy(float value)
	//{
	//	if (this.currentSkill == null)
	//	{
	//		return;
	//	}
	//	if (this.IsFull())
	//	{
	//		return;
	//	}
	//	float num = this.energy;
	//	this.UpdateEnergyNum(value);
	//	if (this.currentSkill.UseType != SKILL_USE_TYPE.LOOP)
	//	{
	//		float num2 = this.currentSkill.EnergyCost[0];
	//		if (this.energy >= num2 && num < num2)
	//		{
	//			SingletonMono<AudioManager>.GetInstance().PlaySound(SoundType.gameSound, Vector3.zero, 5028, false);
	//		}
	//	}
	//	PlayerGUI.Instance.SetFULUBarProgress(this.energy, this.maxEnergy);
	//}

	//// Token: 0x0600206E RID: 8302 RVA: 0x000DE168 File Offset: 0x000DC368
	//public bool IsFull()
	//{
	//	return this.energy == this.maxEnergy;
	//}

	//// Token: 0x0600206F RID: 8303 RVA: 0x000DE184 File Offset: 0x000DC384
	//public void ClearFigureEnergy()
	//{
	//	PlayerGUI.Instance.SetFULUBarProgress(0f, 1f);
	//	this.energy = 0f;
	//}

	//// Token: 0x06002070 RID: 8304 RVA: 0x000DE1A8 File Offset: 0x000DC3A8
	//public bool UseSkill()
	//{
	//	if (this.currentSkill == null)
	//	{
	//		return false;
	//	}
	//	if (this.currentSkill.UseType == SKILL_USE_TYPE.ONCE)
	//	{
	//		return this.UseFigureSkill(0);
	//	}
	//	if (this.currentSkill.UseType == SKILL_USE_TYPE.LOOP)
	//	{
	//		return this.UseFigureSkill(0);
	//	}
	//	if (this.currentSkill.UseType == SKILL_USE_TYPE.COMBO)
	//	{
	//		if (GameTime.time - this.lastSkillTime > 5f)
	//		{
	//			this.nextSkillIndex = 0;
	//		}
	//		else if (this.nextSkillIndex >= this.currentSkill.SkillID.Length)
	//		{
	//			this.nextSkillIndex = 0;
	//		}
	//		if (this.UseFigureSkill(this.nextSkillIndex++))
	//		{
	//			this.lastSkillTime = GameTime.time;
	//			return true;
	//		}
	//	}
	//	return false;
	//}

	//// Token: 0x06002071 RID: 8305 RVA: 0x000DE270 File Offset: 0x000DC470
	//public void StopSkill()
	//{
	//	if (this.currentSkill == null)
	//	{
	//		return;
	//	}
	//	if (this.currentSkill.UseType == SKILL_USE_TYPE.LOOP)
	//	{
	//		CSkillBase.StopLoop = true;
	//	}
	//}

	//// Token: 0x06002072 RID: 8306 RVA: 0x000DE298 File Offset: 0x000DC498
	//public void Update()
	//{
	//}

	//// Token: 0x06002073 RID: 8307 RVA: 0x000DE29C File Offset: 0x000DC49C
	//public bool UseFigureSkill()
	//{
	//	return this.UseFigureSkill(0);
	//}

	//// Token: 0x06002074 RID: 8308 RVA: 0x000DE2A8 File Offset: 0x000DC4A8
	//public bool UseFigureSkill(int index)
	//{
	//	if (this.currentSkill != null && this.currentSkill.SkillID.Length > index)
	//	{
	//		if (this.energy >= this.currentSkill.EnergyCost[index])
	//		{
	//			int num = this.currentSkill.SkillID[index];
	//			if (num <= 0)
	//			{
	//				return false;
	//			}
	//			CSkillBase skill = Singleton<CSkillStaticManager>.GetInstance().GetSkill(num);
	//			if (skill == null)
	//			{
	//				return false;
	//			}
	//			ModControlMFS modControlMFS = this.m_cPlayer.GetModule(MODULE_TYPE.MT_CONTROL_MFS) as ModControlMFS;
	//			Role targetRole = null;
	//			Vector3 zero = Vector3.zero;
	//			this.m_cPlayer.GetSkillTarget(skill, out targetRole, out zero);
	//			if (modControlMFS.ChangeState(new ControlEventSkill(false, this.currentSkill.SkillID[index], targetRole, zero, true)))
	//			{
	//				this.UpdateEnergyNum(-this.currentSkill.EnergyCost[index]);
	//				PlayerGUI.Instance.SetFULUBarProgress(this.energy, this.maxEnergy);
	//				return true;
	//			}
	//		}
	//		else
	//		{
	//			SM_HelpEnable.ExecHelp(1000828);
	//		}
	//	}
	//	return false;
	//}

	//// Token: 0x06002075 RID: 8309 RVA: 0x000DE3A0 File Offset: 0x000DC5A0
	//public void ReduceEnergyPerFram(float value)
	//{
	//	this.UpdateEnergyNum(-value);
	//	PlayerGUI.Instance.SetFULUBarProgress(this.energy, this.maxEnergy);
	//}

	//// Token: 0x06002076 RID: 8310 RVA: 0x000DE3C0 File Offset: 0x000DC5C0
	//public ItemMagicFigure GetWeaponFigure()
	//{
	//	return null;
	//}

	//// Token: 0x06002077 RID: 8311 RVA: 0x000DE3C4 File Offset: 0x000DC5C4
	//public bool BindWeaponEffect()
	//{
	//	if (this.currentSkill == null)
	//	{
	//		return false;
	//	}
	//	FigureEffectData.Data effectInfo = Singleton<FigureEffectData>.GetInstance().GetEffectInfo(this.currentSkill.ID);
	//	if (effectInfo == null)
	//	{
	//		return false;
	//	}
	//	CItemBase citemBase = this.m_cPlayer.ItemFolder.WearOperate[RoleWearEquipPos.WEAR_WEAPON];
	//	if (citemBase == null)
	//	{
	//		return false;
	//	}
	//	int num = effectInfo.EffectID[(EquipCfgType)citemBase.CHILD_TYPE_ID];
	//	if (num < 0)
	//	{
	//		return false;
	//	}
	//	GameObject attachGO = this.m_cPlayer.roleGameObject.GetAttachGO(ATTACHMENT.LEFT_WEAPON);
	//	GameObject attachGO2 = this.m_cPlayer.roleGameObject.GetAttachGO(ATTACHMENT.RIGHT_WEAPON);
	//	this.DeleteWeaponEffect();
	//	if (attachGO != null)
	//	{
	//		this.leftEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectBind(num, attachGO);
	//	}
	//	if (attachGO2 != null)
	//	{
	//		this.rightEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectBind(num, attachGO2);
	//	}
	//	this.m_cPlayer.roleGameObject.ResetRender();
	//	return true;
	//}

	//// Token: 0x06002078 RID: 8312 RVA: 0x000DE4B4 File Offset: 0x000DC6B4
	//public bool DeleteWeaponEffect()
	//{
	//	SingletonMono<EffectManager>.GetInstance().Delete(this.leftEffectId);
	//	SingletonMono<EffectManager>.GetInstance().Delete(this.rightEffectId);
	//	return true;
	//}

	//// Token: 0x06002079 RID: 8313 RVA: 0x000DE4D8 File Offset: 0x000DC6D8
	//public FigureSkillData.Data GetFigureSkillData(int id)
	//{
	//	return Singleton<FigureSkillData>.GetInstance().GetFigureSkillData(id);
	//}

	//// Token: 0x0600207A RID: 8314 RVA: 0x000DE4E8 File Offset: 0x000DC6E8
	//public void GetSDFigure(SaveData.SDFigure figure)
	//{
	//	this.learnedSkill = figure.learnedID;
	//	this.ResetSkill(figure.currentID);
	//	this.SetEnergyNum(figure.currentEnergy);
	//	if (this.m_cPlayer != null)
	//	{
	//		ModAttribute modAttribute = this.m_cPlayer.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
	//		Dictionary<AMBITLEVEL, AmbitData> ambitData = Singleton<AmbitStaticData>.GetInstance().GetAmbitData(1);
	//		AmbitData ambitData2 = ambitData[AmbitSystem.ConvertLevel(modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_LEVEL))];
	//		this.maxEnergy = ambitData2.MaxEnergy;
	//	}
	//	PlayerGUI.Instance.SetFULUBarProgress(figure.currentEnergy, this.maxEnergy);
	//}
}
