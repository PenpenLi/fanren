using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

/// <summary>
/// 熟练度系统
/// </summary>
public class AdeptTalent
{
    private Player _OwnerPlayer;

    //private SortedDictionary<int, AdeptTalent.AdeptData> _AdeptTalentConfig = new SortedDictionary<int, AdeptTalent.AdeptData>();

    //private ModAttribute _OwnerMod;

    //private AdeptTalent.AddValue _AddCount;

    //// Token: 0x04001B01 RID: 6913
    //public int LeftSoulHelpID;

    //// Token: 0x04001B02 RID: 6914
    //private Dictionary<EquipCfgType, AdeptTalent.AdeptData> _lastAdeptData = new Dictionary<EquipCfgType, AdeptTalent.AdeptData>();

    //// Token: 0x02000483 RID: 1155
    //public enum CheckUnLockType
    //{
    //	// Token: 0x04001B04 RID: 6916
    //	CUT_LIANJI,
    //	// Token: 0x04001B05 RID: 6917
    //	CUT_XULI,
    //	// Token: 0x04001B06 RID: 6918
    //	CUT_ZHUIJI
    //}

    /// <summary>
    /// 拥有者
    /// </summary>
    public Player OwnerPlayer
    {
        get
        {
            if (this._OwnerPlayer == null)
            {
                this._OwnerPlayer = Player.Instance;
            }
            return this._OwnerPlayer;
        }
        set
        {
            this._OwnerPlayer = value;
        }
    }

    //// Token: 0x1700033C RID: 828
    //// (get) Token: 0x06001DE3 RID: 7651 RVA: 0x000D054C File Offset: 0x000CE74C
    //// (set) Token: 0x06001DE4 RID: 7652 RVA: 0x000D056C File Offset: 0x000CE76C
    //public SortedDictionary<int, AdeptTalent.AdeptData> AdeptTalentConfig
    //{
    //	get
    //	{
    //		if (this._AdeptTalentConfig == null)
    //		{
    //			this._AdeptTalentConfig = new SortedDictionary<int, AdeptTalent.AdeptData>();
    //		}
    //		return this._AdeptTalentConfig;
    //	}
    //	set
    //	{
    //		this._AdeptTalentConfig = value;
    //	}
    //}

    //// Token: 0x1700033D RID: 829
    //// (get) Token: 0x06001DE5 RID: 7653 RVA: 0x000D0578 File Offset: 0x000CE778
    //// (set) Token: 0x06001DE6 RID: 7654 RVA: 0x000D0598 File Offset: 0x000CE798
    //public AdeptTalent.AddValue AddCount
    //{
    //	get
    //	{
    //		if (this._AddCount == null)
    //		{
    //			this._AddCount = new AdeptTalent.AddValue();
    //		}
    //		return this._AddCount;
    //	}
    //	private set
    //	{
    //		this._AddCount = value;
    //	}
    //}

    //// Token: 0x1700033E RID: 830
    //// (get) Token: 0x06001DE7 RID: 7655 RVA: 0x000D05A4 File Offset: 0x000CE7A4
    //// (set) Token: 0x06001DE8 RID: 7656 RVA: 0x000D05AC File Offset: 0x000CE7AC
    //public Dictionary<EquipCfgType, AdeptTalent.AdeptData> LastAdeptData
    //{
    //	get
    //	{
    //		return this._lastAdeptData;
    //	}
    //	set
    //	{
    //		this._lastAdeptData = value;
    //	}
    //}

    //// Token: 0x06001DE9 RID: 7657 RVA: 0x000D05B8 File Offset: 0x000CE7B8
    //public AdeptTalent.AdeptData GetAdeptData(EquipCfgType type)
    //{
    //	if (this.LastAdeptData.ContainsKey(type))
    //	{
    //		return this.LastAdeptData[type];
    //	}
    //	return null;
    //}

    //// Token: 0x06001DEA RID: 7658 RVA: 0x000D05E4 File Offset: 0x000CE7E4
    //public int GetAmbitID()
    //{
    //	foreach (KeyValuePair<EquipCfgType, AdeptTalent.AdeptData> keyValuePair in this.LastAdeptData)
    //	{
    //		if (keyValuePair.Key == Player.Instance.weaponManager.currentWeaponType)
    //		{
    //			return keyValuePair.Value.AmbitID;
    //		}
    //	}
    //	return 0;
    //}

    //// Token: 0x06001DEB RID: 7659 RVA: 0x000D0674 File Offset: 0x000CE874
    //public int ApplyUnLock(EquipCfgType type, int _AmbitID, int _PhaseID)
    //{
    //	if (this._AdeptTalentConfig == null || this._AdeptTalentConfig.Count <= 0 || this._OwnerMod == null)
    //	{
    //		return 0;
    //	}
    //	int adeptID = this.GetAdeptID(type, _AmbitID, _PhaseID);
    //	if (!this._AdeptTalentConfig.ContainsKey(adeptID))
    //	{
    //		return 0;
    //	}
    //	if (!this.IsLocked(type, _AmbitID, _PhaseID))
    //	{
    //		return 2;
    //	}
    //	foreach (KeyValuePair<int, AdeptTalent.AdeptData> keyValuePair in this._AdeptTalentConfig)
    //	{
    //		if (keyValuePair.Value.WeaponType == type)
    //		{
    //			if (keyValuePair.Key < adeptID)
    //			{
    //				if (keyValuePair.Value.IsLock)
    //				{
    //					return 0;
    //				}
    //			}
    //			else if (keyValuePair.Key == adeptID)
    //			{
    //				if (this.GetAdeptValue() < keyValuePair.Value.Count)
    //				{
    //					return 0;
    //				}
    //				if (this.GetLevel() < keyValuePair.Value.Level)
    //				{
    //					return 0;
    //				}
    //				this.AddCount.Clear();
    //				foreach (AdeptTalent.AdeptData.AddRoleAttribute addRoleAttribute in keyValuePair.Value.AddAttributesList)
    //				{
    //					this.UpDateAdeptAttribute(keyValuePair.Value.WeaponType, addRoleAttribute._Type, addRoleAttribute._fVal);
    //				}
    //				this._OwnerMod.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HunVal, (float)(-(float)keyValuePair.Value.Count), true);
    //				keyValuePair.Value.IsLock = false;
    //				if (keyValuePair.Value.IsUnLockAnimation == 1 && Singleton<RoleAnimationManager>.GetInstance().AttachAnimationAdeptTalent(keyValuePair.Value.WeaponType, keyValuePair.Value.AmbitID, Player.Instance))
    //				{
    //					Player.LoadAttackRes(keyValuePair.Value.WeaponType, keyValuePair.Value.AmbitID);
    //				}
    //				if (this._lastAdeptData.ContainsKey(keyValuePair.Value.WeaponType))
    //				{
    //					this._lastAdeptData[keyValuePair.Value.WeaponType] = keyValuePair.Value;
    //				}
    //				else
    //				{
    //					this._lastAdeptData.Add(keyValuePair.Value.WeaponType, keyValuePair.Value);
    //				}
    //				if (GameData.Instance != null && GameData.Instance.ScrMan != null && keyValuePair.Value.HelpID != -1)
    //				{
    //					GameData.Instance.ScrMan.Exec(44, keyValuePair.Value.HelpID);
    //				}
    //				Singleton<EZGUIManager>.GetInstance().OnCommandGUIMessage(GUI_TYPE.UICMD_ALL_ATTRIBUTEUPDATE, ATTRIBUTE_TYPE.ATT_PHY_ATK, 0);
    //				return 1;
    //			}
    //		}
    //	}
    //	return 0;
    //}

    //// Token: 0x06001DEC RID: 7660 RVA: 0x000D0980 File Offset: 0x000CEB80
    //public float GetAdpetPercent(AdeptTalent.AdeptData adept)
    //{
    //	if (adept == null)
    //	{
    //		return 0f;
    //	}
    //	if (!adept.IsLock)
    //	{
    //		return 1f;
    //	}
    //	if (this.GetLevel() < adept.Level)
    //	{
    //		return 0f;
    //	}
    //	if (adept.Count <= 0)
    //	{
    //		return 1f;
    //	}
    //	float num = (float)adept.PourSoul / (float)adept.Count;
    //	if (num > 1f)
    //	{
    //		return 1f;
    //	}
    //	if (num < 0f)
    //	{
    //		return 0f;
    //	}
    //	return num;
    //}

    //// Token: 0x06001DED RID: 7661 RVA: 0x000D0A08 File Offset: 0x000CEC08
    //private int ApplyUnLockEx(AdeptTalent.AdeptData pRet)
    //{
    //	if (!pRet.IsLock)
    //	{
    //		return 2;
    //	}
    //	if (this.GetLevel() < pRet.Level)
    //	{
    //		return 0;
    //	}
    //	this.AddCount.Clear();
    //	foreach (AdeptTalent.AdeptData.AddRoleAttribute addRoleAttribute in pRet.AddAttributesList)
    //	{
    //		this.UpDateAdeptAttribute(pRet.WeaponType, addRoleAttribute._Type, addRoleAttribute._fVal);
    //	}
    //	pRet.IsLock = false;
    //	if (pRet.IsUnLockAnimation == 1 && Singleton<RoleAnimationManager>.GetInstance().AttachAnimationAdeptTalent(pRet.WeaponType, pRet.AmbitID, Player.Instance))
    //	{
    //		Player.LoadAttackRes(pRet.WeaponType, pRet.AmbitID);
    //	}
    //	if (this._lastAdeptData.ContainsKey(pRet.WeaponType))
    //	{
    //		this._lastAdeptData[pRet.WeaponType] = pRet;
    //	}
    //	else
    //	{
    //		this._lastAdeptData.Add(pRet.WeaponType, pRet);
    //	}
    //	Singleton<EZGUIManager>.GetInstance().OnCommandGUIMessage(GUI_TYPE.UICMD_ALL_ATTRIBUTEUPDATE, ATTRIBUTE_TYPE.ATT_PHY_ATK, 0);
    //	return 1;
    //}

    //// Token: 0x06001DEE RID: 7662 RVA: 0x000D0B44 File Offset: 0x000CED44
    //public bool IsCanEnergy(EquipCfgType eType)
    //{
    //	if (this.GetAdeptValue() <= 0)
    //	{
    //		return false;
    //	}
    //	List<AdeptTalent.AdeptData> list = new List<AdeptTalent.AdeptData>();
    //	foreach (KeyValuePair<int, AdeptTalent.AdeptData> keyValuePair in this._AdeptTalentConfig)
    //	{
    //		if (keyValuePair.Value.WeaponType == eType)
    //		{
    //			list.Add(keyValuePair.Value);
    //		}
    //	}
    //	foreach (AdeptTalent.AdeptData adeptData in list)
    //	{
    //		if (adeptData.IsLock)
    //		{
    //			if (this.GetLevel() < adeptData.Level)
    //			{
    //				return false;
    //			}
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06001DEF RID: 7663 RVA: 0x000D0C58 File Offset: 0x000CEE58
    //public AdeptTalent.AdeptData GetPreviousData(AdeptTalent.AdeptData data)
    //{
    //	List<AdeptTalent.AdeptData> list = new List<AdeptTalent.AdeptData>();
    //	foreach (KeyValuePair<int, AdeptTalent.AdeptData> keyValuePair in this._AdeptTalentConfig)
    //	{
    //		if (keyValuePair.Value.WeaponType == data.WeaponType)
    //		{
    //			list.Add(keyValuePair.Value);
    //		}
    //	}
    //	int num = list.IndexOf(data);
    //	if (num == 0)
    //	{
    //		return null;
    //	}
    //	return list[num - 1];
    //}

    //// Token: 0x06001DF0 RID: 7664 RVA: 0x000D0D00 File Offset: 0x000CEF00
    //public int UpdateSeqSoul(EquipCfgType eType, out AdeptTalent.AdeptData retData)
    //{
    //	retData = null;
    //	List<AdeptTalent.AdeptData> list = new List<AdeptTalent.AdeptData>();
    //	foreach (KeyValuePair<int, AdeptTalent.AdeptData> keyValuePair in this._AdeptTalentConfig)
    //	{
    //		if (keyValuePair.Value.WeaponType == eType)
    //		{
    //			list.Add(keyValuePair.Value);
    //		}
    //	}
    //	foreach (AdeptTalent.AdeptData adeptData in list)
    //	{
    //		if (adeptData.IsLock)
    //		{
    //			if (this.GetLevel() < adeptData.Level)
    //			{
    //				return 0;
    //			}
    //			retData = adeptData;
    //			if (adeptData.PourSoul >= adeptData.Count)
    //			{
    //				adeptData.PourSoul = adeptData.Count;
    //				this.ApplyUnLockEx(adeptData);
    //				return 2;
    //			}
    //			if (this.GetAdeptValue() <= 0)
    //			{
    //				return 0;
    //			}
    //			int num = (int)((float)adeptData.DeltaCount * Time.deltaTime);
    //			num = TransformUtility.Clamp(num, 1, this.GetAdeptValue());
    //			num = TransformUtility.Clamp(num, 1, adeptData.Count - adeptData.PourSoul);
    //			adeptData.PourSoul += num;
    //			this._OwnerMod.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HunVal, (float)(-(float)num), true);
    //			if (adeptData.PourSoul >= adeptData.Count)
    //			{
    //				adeptData.PourSoul = adeptData.Count;
    //				this.ApplyUnLockEx(adeptData);
    //				return 2;
    //			}
    //			return 1;
    //		}
    //	}
    //	return 0;
    //}

    //// Token: 0x06001DF1 RID: 7665 RVA: 0x000D0ED0 File Offset: 0x000CF0D0
    //public bool IsLocked(EquipCfgType type, int _AmbitID, int _PhaseID)
    //{
    //	int adeptID = this.GetAdeptID(type, _AmbitID, _PhaseID);
    //	return !this._AdeptTalentConfig.ContainsKey(adeptID) || this._AdeptTalentConfig[adeptID].IsLock;
    //}

    //// Token: 0x06001DF2 RID: 7666 RVA: 0x000D0F0C File Offset: 0x000CF10C
    //public bool IsAdeptUnLock(AdeptTalent.CheckUnLockType eUnLockType, int level)
    //{
    //	return this.IsAdeptUnLock(Player.Instance.weaponManager.currentWeaponType, eUnLockType, level);
    //}

    //// Token: 0x06001DF3 RID: 7667 RVA: 0x000D0F28 File Offset: 0x000CF128
    //public bool IsAdeptUnLock(EquipCfgType eWeaponType, AdeptTalent.CheckUnLockType eUnLockType, int level)
    //{
    //	AdeptTalent.AdeptData adeptData = null;
    //	foreach (AdeptTalent.AdeptData adeptData2 in this._AdeptTalentConfig.Values)
    //	{
    //		if (adeptData2.WeaponType == eWeaponType && !adeptData2.IsLock)
    //		{
    //			adeptData = adeptData2;
    //		}
    //	}
    //	if (adeptData == null)
    //	{
    //		return false;
    //	}
    //	if (eUnLockType == AdeptTalent.CheckUnLockType.CUT_ZHUIJI)
    //	{
    //		return adeptData.ZhuijiLev >= level;
    //	}
    //	if (eUnLockType == AdeptTalent.CheckUnLockType.CUT_XULI)
    //	{
    //		return adeptData.XuliLev >= level;
    //	}
    //	return eUnLockType == AdeptTalent.CheckUnLockType.CUT_LIANJI && adeptData.LianjiLev >= level;
    //}

    //// Token: 0x06001DF4 RID: 7668 RVA: 0x000D0FEC File Offset: 0x000CF1EC
    //public bool IsLocked(int _ID)
    //{
    //	return !this._AdeptTalentConfig.ContainsKey(_ID) || this._AdeptTalentConfig[_ID].IsLock;
    //}

    //// Token: 0x06001DF5 RID: 7669 RVA: 0x000D1020 File Offset: 0x000CF220
    //public void ClearAdeptTalent()
    //{
    //	if (this._AdeptTalentConfig != null)
    //	{
    //		this._AdeptTalentConfig.Clear();
    //	}
    //}

    //// Token: 0x06001DF6 RID: 7670 RVA: 0x000D1038 File Offset: 0x000CF238
    //public int GetAdeptValue()
    //{
    //	return (this._OwnerMod != null) ? ((int)this._OwnerMod.GetAttributeValue(ATTRIBUTE_TYPE.ATT_HunVal)) : -1;
    //}

    //// Token: 0x06001DF7 RID: 7671 RVA: 0x000D105C File Offset: 0x000CF25C
    //public int GetLevel()
    //{
    //	return (this._OwnerMod != null) ? ((int)this._OwnerMod.GetAttributeValue(ATTRIBUTE_TYPE.ATT_LEVEL)) : -1;
    //}

    //// Token: 0x06001DF8 RID: 7672 RVA: 0x000D107C File Offset: 0x000CF27C
    //public int GetAdeptID(EquipCfgType type, int _AmbitID, int _PhaseID)
    //{
    //	int num = -1;
    //	int num2 = (int)type;
    //	string value = num2.ToString() + _AmbitID.ToString() + _PhaseID.ToString();
    //	int result;
    //	try
    //	{
    //		num = Convert.ToInt32(value);
    //		result = num;
    //	}
    //	catch
    //	{
    //		result = num;
    //	}
    //	return result;
    //}

    //// Token: 0x06001DF9 RID: 7673 RVA: 0x000D10E8 File Offset: 0x000CF2E8
    //public AdeptTalent.AdeptData GetAdeptData(int idx)
    //{
    //	if (!this._AdeptTalentConfig.ContainsKey(idx))
    //	{
    //		return null;
    //	}
    //	return this._AdeptTalentConfig[idx];
    //}

    //// Token: 0x06001DFA RID: 7674 RVA: 0x000D110C File Offset: 0x000CF30C
    //public void CheckAdeptSkill()
    //{
    //	if (this._lastAdeptData == null || this.OwnerPlayer == null || !this._lastAdeptData.ContainsKey(this.OwnerPlayer.weaponManager.currentWeaponType))
    //	{
    //		return;
    //	}
    //	EquipCfgType currentWeaponType = this.OwnerPlayer.weaponManager.currentWeaponType;
    //	foreach (AdeptTalent.AdeptData.AddRoleAttribute addRoleAttribute in this._lastAdeptData[currentWeaponType].AddAttributesList)
    //	{
    //		if (addRoleAttribute._Type == ADEPT_ATTRIBUTE.AAT_WEAPON_SKILL && UnityEngine.Random.Range(0f, 1f) < addRoleAttribute.probability)
    //		{
    //			Debug.Log("======CheckAdeptSkill=============Push Skill===========>" + (int)addRoleAttribute._fVal);
    //			CSkillManager.Instance.CreateSkill((int)addRoleAttribute._fVal, this.OwnerPlayer);
    //		}
    //	}
    //}

    //private bool UpDateAdeptAttribute(EquipCfgType weapontype, ADEPT_ATTRIBUTE type, float value)
    //{
    //	if (type == ADEPT_ATTRIBUTE.AAT_ALL_ATK)
    //	{
    //		this.AddCount.PhyAtk += value;
    //		this.AddCount.MagAtk += value;
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_ALL_DEF)
    //	{
    //		this.AddCount.PhyDef += value;
    //		this.AddCount.MagDef += value;
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_PHY_ATK)
    //	{
    //		this.AddCount.PhyAtk += value;
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_MAG_ATK)
    //	{
    //		this.AddCount.MagAtk += value;
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_PHY_DEF)
    //	{
    //		this.AddCount.PhyDef += value;
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_MAG_DEF)
    //	{
    //		this.AddCount.MagDef += value;
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_ATK_RANG)
    //	{
    //		this._OwnerMod.UpdateAttributePercent(ATTRIBUTE_TYPE.ATT_ATTACK_RANGE, value, true);
    //	}
    //	else if (type != ADEPT_ATTRIBUTE.AAT_ATK_DIS)
    //	{
    //		if (type == ADEPT_ATTRIBUTE.AAT_ATK_SPEED)
    //		{
    //			this._OwnerMod.UpdateAttributePercent(ATTRIBUTE_TYPE.ATT_ATTACK_INTERVAL, value, true);
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06001DFC RID: 7676 RVA: 0x000D1344 File Offset: 0x000CF544
    //public static KeyValuePair<string, string> GetAttributeName(ADEPT_ATTRIBUTE type)
    //{
    //	string key = string.Empty;
    //	string value = "%";
    //	if (type == ADEPT_ATTRIBUTE.AAT_ALL_ATK)
    //	{
    //		key = "伤害提高";
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_ALL_DEF)
    //	{
    //		key = "防御提高";
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_PHY_ATK)
    //	{
    //		key = "物理伤害提高";
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_MAG_ATK)
    //	{
    //		key = "法术伤害提高";
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_PHY_DEF)
    //	{
    //		key = "物理防御提高";
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_MAG_DEF)
    //	{
    //		key = "法术防御提高";
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_ATK_RANG)
    //	{
    //		key = "攻击范围增加";
    //		value = string.Empty;
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_ATK_DIS)
    //	{
    //		key = "攻击距离增加";
    //		value = string.Empty;
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_ATK_SPEED)
    //	{
    //		key = "攻击速度增加";
    //		value = "ms";
    //	}
    //	else if (type == ADEPT_ATTRIBUTE.AAT_WEAPON_SKILL)
    //	{
    //		key = "武器效果";
    //		value = " Lv.";
    //	}
    //	return new KeyValuePair<string, string>(key, value);
    //}

    //// Token: 0x06001DFD RID: 7677 RVA: 0x000D142C File Offset: 0x000CF62C
    //public string GetAttributeNameEx(ADEPT_ATTRIBUTE type, float value)
    //{
    //	string text = AdeptTalent.GetAttributeName(type).Key;
    //	if (type == ADEPT_ATTRIBUTE.AAT_WEAPON_SKILL)
    //	{
    //		text += AdeptTalent.GetAttributeName(type).Value;
    //		text += " ";
    //		text += (int)value;
    //	}
    //	else
    //	{
    //		text += ":";
    //		if (type == ADEPT_ATTRIBUTE.AAT_ALL_ATK || type == ADEPT_ATTRIBUTE.AAT_ALL_DEF || type == ADEPT_ATTRIBUTE.AAT_PHY_ATK || type == ADEPT_ATTRIBUTE.AAT_MAG_ATK || type == ADEPT_ATTRIBUTE.AAT_PHY_DEF || type == ADEPT_ATTRIBUTE.AAT_MAG_DEF)
    //		{
    //			text += (value * 100f).ToString();
    //		}
    //		else
    //		{
    //			text += value.ToString();
    //		}
    //		text += AdeptTalent.GetAttributeName(type).Value;
    //	}
    //	return text;
    //}

    //// Token: 0x06001DFE RID: 7678 RVA: 0x000D14FC File Offset: 0x000CF6FC
    //public void PushSDData(AdeptTalentSaveData data, Player pHost, AdeptTalent.AddValue addCount, Dictionary<int, AdeptTalent.AdeptData> adeptTalentConfig, Dictionary<EquipCfgType, AdeptTalent.AdeptData> lastAdeptData)
    //{
    //	if (pHost == null || pHost.m_cModAttribute == null || adeptTalentConfig == null)
    //	{
    //		Debug.LogError("PushSDData failed!");
    //		return;
    //	}
    //	this.ClearAdeptTalent();
    //	this._OwnerPlayer = pHost;
    //	this._OwnerMod = pHost.m_cModAttribute;
    //	this.AdeptTalentConfig = new SortedDictionary<int, AdeptTalent.AdeptData>();
    //	foreach (KeyValuePair<int, AdeptTalent.AdeptData> keyValuePair in adeptTalentConfig)
    //	{
    //		this.AdeptTalentConfig.Add(keyValuePair.Key, keyValuePair.Value);
    //	}
    //	this.LastAdeptData = new Dictionary<EquipCfgType, AdeptTalent.AdeptData>(lastAdeptData);
    //	if (this.AdeptTalentConfig.Count > 0)
    //	{
    //		foreach (AdeptTalent.AdeptData adeptData in this.AdeptTalentConfig.Values)
    //		{
    //			if (!adeptData.IsLock && adeptData.IsUnLockAnimation == 1)
    //			{
    //				Singleton<RoleAnimationManager>.GetInstance().AttachAnimationAdeptTalent(adeptData.WeaponType, adeptData.AmbitID, Player.Instance);
    //			}
    //		}
    //	}
    //	Singleton<EZGUIManager>.GetInstance().GetGUI<AdeptTalentPlane>().SetLeftSoul(data._LeftSoulHelpID);
    //}

    //// Token: 0x06001DFF RID: 7679 RVA: 0x000D1670 File Offset: 0x000CF870
    //public bool LoadAdeptConfig(ModAttribute pMod, string strFilePath)
    //{
    //	if (strFilePath == null || pMod == null)
    //	{
    //		return false;
    //	}
    //	List<string> list = RoleBaseFun.LoadConfInAssets(strFilePath);
    //	if (list.Count <= 0)
    //	{
    //		Debug.LogWarning("Adept Config no found!");
    //		return false;
    //	}
    //	this.ClearAdeptTalent();
    //	foreach (string text in list)
    //	{
    //		string[] array = text.Split(CacheData.separator);
    //		if (array.Length >= 8)
    //		{
    //			int i = 0;
    //			AdeptTalent.AdeptData adeptData = new AdeptTalent.AdeptData();
    //			adeptData.WeaponType = (EquipCfgType)Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.IsLock = (Convert.ToInt32(array[i]) == 0);
    //			i++;
    //			adeptData.AmbitID = Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.PhaseID = Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.Level = Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.Count = Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.IsUnLockAnimation = Convert.ToInt32(array[i]);
    //			if (!adeptData.IsLock && adeptData.IsUnLockAnimation == 1)
    //			{
    //				Singleton<RoleAnimationManager>.GetInstance().AttachAnimationAdeptTalent(adeptData.WeaponType, adeptData.AmbitID, Player.Instance);
    //			}
    //			i++;
    //			adeptData.DeltaCount = Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.Name = array[i];
    //			i++;
    //			adeptData.Desc = array[i];
    //			i++;
    //			adeptData.Desc2 = array[i];
    //			i++;
    //			adeptData.HelpID = Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.LianjiLev = Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.XuliLev = Convert.ToInt32(array[i]);
    //			i++;
    //			adeptData.ZhuijiLev = Convert.ToInt32(array[i]);
    //			for (i++; i < array.Length; i++)
    //			{
    //				int num = Convert.ToInt32(array[i]);
    //				if (num == -1)
    //				{
    //					i++;
    //				}
    //				else
    //				{
    //					ADEPT_ATTRIBUTE adept_ATTRIBUTE = (ADEPT_ATTRIBUTE)num;
    //					i++;
    //					string text2 = array[i];
    //					if (adept_ATTRIBUTE == ADEPT_ATTRIBUTE.AAT_WEAPON_SKILL && text2.IndexOf('/') != -1)
    //					{
    //						string[] array2 = text2.Split(AdeptTalent.separator);
    //						if (array2.Length >= 3)
    //						{
    //							float val = (float)Convert.ToDouble(array2[0]);
    //							int level = Convert.ToInt32(array2[1]);
    //							float probability = (float)Convert.ToDouble(array2[2]);
    //							AdeptTalent.AdeptData.AddRoleAttribute addRoleAttribute = new AdeptTalent.AdeptData.AddRoleAttribute(adept_ATTRIBUTE, val);
    //							addRoleAttribute.level = level;
    //							addRoleAttribute.probability = probability;
    //							adeptData.AddAttributesList.Add(addRoleAttribute);
    //						}
    //					}
    //					else
    //					{
    //						float val2 = (float)Convert.ToDouble(text2);
    //						AdeptTalent.AdeptData.AddRoleAttribute item = new AdeptTalent.AdeptData.AddRoleAttribute(adept_ATTRIBUTE, val2);
    //						adeptData.AddAttributesList.Add(item);
    //					}
    //				}
    //			}
    //			if (this._AdeptTalentConfig.ContainsKey(adeptData.ID))
    //			{
    //				Logger.LogWarning(new object[]
    //				{
    //					"LoadAdeptConfig failed! ContainsKey error : " + adeptData.ID
    //				});
    //			}
    //			else
    //			{
    //				this._AdeptTalentConfig.Add(adeptData.ID, adeptData);
    //			}
    //		}
    //	}
    //	this._OwnerMod = pMod;
    //	return true;
    //}

    //public static char[] separator = new char[]
    //{
    //	'/'
    //};

    //// Token: 0x02000484 RID: 1156
    //[Serializable]
    //public class AddValue
    //{
    //	// Token: 0x06001E01 RID: 7681 RVA: 0x000D19C8 File Offset: 0x000CFBC8
    //	public void Clear()
    //	{
    //		this.PhyAtk = 0f;
    //		this.MagAtk = 0f;
    //		this.PhyDef = 0f;
    //		this.MagDef = 0f;
    //	}

    //	// Token: 0x04001B07 RID: 6919
    //	public float PhyAtk;

    //	// Token: 0x04001B08 RID: 6920
    //	public float MagAtk;

    //	// Token: 0x04001B09 RID: 6921
    //	public float PhyDef;

    //	// Token: 0x04001B0A RID: 6922
    //	public float MagDef;
    //}

    //[Serializable]
    //public class AdeptData
    //{
    //	// Token: 0x1700033F RID: 831
    //	// (get) Token: 0x06001E03 RID: 7683 RVA: 0x000D1A48 File Offset: 0x000CFC48
    //	// (set) Token: 0x06001E04 RID: 7684 RVA: 0x000D1A50 File Offset: 0x000CFC50
    //	public EquipCfgType WeaponType
    //	{
    //		get
    //		{
    //			return this._WeaponType;
    //		}
    //		set
    //		{
    //			this._WeaponType = value;
    //		}
    //	}

    //	// Token: 0x17000340 RID: 832
    //	// (get) Token: 0x06001E05 RID: 7685 RVA: 0x000D1A5C File Offset: 0x000CFC5C
    //	// (set) Token: 0x06001E06 RID: 7686 RVA: 0x000D1A64 File Offset: 0x000CFC64
    //	public int Level
    //	{
    //		get
    //		{
    //			return this._Level;
    //		}
    //		set
    //		{
    //			this._Level = value;
    //		}
    //	}

    //	// Token: 0x17000341 RID: 833
    //	// (get) Token: 0x06001E07 RID: 7687 RVA: 0x000D1A70 File Offset: 0x000CFC70
    //	// (set) Token: 0x06001E08 RID: 7688 RVA: 0x000D1A78 File Offset: 0x000CFC78
    //	public int AmbitID
    //	{
    //		get
    //		{
    //			return this._AmbitID;
    //		}
    //		set
    //		{
    //			this._AmbitID = value;
    //			int weaponType = (int)this._WeaponType;
    //			if (!int.TryParse(weaponType.ToString() + this._AmbitID.ToString() + this._PhaseID.ToString(), out this._ID))
    //			{
    //				this._ID = 0;
    //			}
    //		}
    //	}

    //	// Token: 0x17000342 RID: 834
    //	// (get) Token: 0x06001E09 RID: 7689 RVA: 0x000D1ACC File Offset: 0x000CFCCC
    //	// (set) Token: 0x06001E0A RID: 7690 RVA: 0x000D1AD4 File Offset: 0x000CFCD4
    //	public int PhaseID
    //	{
    //		get
    //		{
    //			return this._PhaseID;
    //		}
    //		set
    //		{
    //			this._PhaseID = value;
    //			int weaponType = (int)this._WeaponType;
    //			if (!int.TryParse(weaponType.ToString() + this._AmbitID.ToString() + this._PhaseID.ToString(), out this._ID))
    //			{
    //				this._ID = 0;
    //			}
    //		}
    //	}

    //	// Token: 0x17000343 RID: 835
    //	// (get) Token: 0x06001E0B RID: 7691 RVA: 0x000D1B28 File Offset: 0x000CFD28
    //	// (set) Token: 0x06001E0C RID: 7692 RVA: 0x000D1B30 File Offset: 0x000CFD30
    //	public int Count
    //	{
    //		get
    //		{
    //			return this._Count;
    //		}
    //		set
    //		{
    //			this._Count = value;
    //		}
    //	}

    //	// Token: 0x17000344 RID: 836
    //	// (get) Token: 0x06001E0D RID: 7693 RVA: 0x000D1B3C File Offset: 0x000CFD3C
    //	// (set) Token: 0x06001E0E RID: 7694 RVA: 0x000D1B44 File Offset: 0x000CFD44
    //	public int IsUnLockAnimation
    //	{
    //		get
    //		{
    //			return this._IsUnLockAnimation;
    //		}
    //		set
    //		{
    //			this._IsUnLockAnimation = value;
    //		}
    //	}

    //	// Token: 0x17000345 RID: 837
    //	// (get) Token: 0x06001E0F RID: 7695 RVA: 0x000D1B50 File Offset: 0x000CFD50
    //	// (set) Token: 0x06001E10 RID: 7696 RVA: 0x000D1B58 File Offset: 0x000CFD58
    //	public int DeltaCount
    //	{
    //		get
    //		{
    //			return this._DeltaCount;
    //		}
    //		set
    //		{
    //			this._DeltaCount = value;
    //		}
    //	}

    //	// Token: 0x17000346 RID: 838
    //	// (get) Token: 0x06001E11 RID: 7697 RVA: 0x000D1B64 File Offset: 0x000CFD64
    //	// (set) Token: 0x06001E12 RID: 7698 RVA: 0x000D1B6C File Offset: 0x000CFD6C
    //	public bool IsLock
    //	{
    //		get
    //		{
    //			return this._IsLock;
    //		}
    //		set
    //		{
    //			this._IsLock = value;
    //		}
    //	}

    //	// Token: 0x17000347 RID: 839
    //	// (get) Token: 0x06001E13 RID: 7699 RVA: 0x000D1B78 File Offset: 0x000CFD78
    //	// (set) Token: 0x06001E14 RID: 7700 RVA: 0x000D1B80 File Offset: 0x000CFD80
    //	public string Name
    //	{
    //		get
    //		{
    //			return this._strName;
    //		}
    //		set
    //		{
    //			this._strName = value;
    //		}
    //	}

    //	// Token: 0x17000348 RID: 840
    //	// (get) Token: 0x06001E15 RID: 7701 RVA: 0x000D1B8C File Offset: 0x000CFD8C
    //	// (set) Token: 0x06001E16 RID: 7702 RVA: 0x000D1B94 File Offset: 0x000CFD94
    //	public string Desc
    //	{
    //		get
    //		{
    //			return this._strDesc;
    //		}
    //		set
    //		{
    //			this._strDesc = value;
    //		}
    //	}

    //	// Token: 0x17000349 RID: 841
    //	// (get) Token: 0x06001E17 RID: 7703 RVA: 0x000D1BA0 File Offset: 0x000CFDA0
    //	// (set) Token: 0x06001E18 RID: 7704 RVA: 0x000D1BA8 File Offset: 0x000CFDA8
    //	public string Desc2
    //	{
    //		get
    //		{
    //			return this._strDesc2;
    //		}
    //		set
    //		{
    //			this._strDesc2 = value;
    //		}
    //	}

    //	// Token: 0x1700034A RID: 842
    //	// (get) Token: 0x06001E19 RID: 7705 RVA: 0x000D1BB4 File Offset: 0x000CFDB4
    //	// (set) Token: 0x06001E1A RID: 7706 RVA: 0x000D1BBC File Offset: 0x000CFDBC
    //	public List<AdeptTalent.AdeptData.AddRoleAttribute> AddAttributesList
    //	{
    //		get
    //		{
    //			return this._lstAddAttributes;
    //		}
    //		set
    //		{
    //			this._lstAddAttributes = value;
    //		}
    //	}

    //	// Token: 0x1700034B RID: 843
    //	// (get) Token: 0x06001E1B RID: 7707 RVA: 0x000D1BC8 File Offset: 0x000CFDC8
    //	// (set) Token: 0x06001E1C RID: 7708 RVA: 0x000D1BD0 File Offset: 0x000CFDD0
    //	public int ID
    //	{
    //		get
    //		{
    //			return this._ID;
    //		}
    //		set
    //		{
    //			this._ID = value;
    //		}
    //	}

    //	// Token: 0x1700034C RID: 844
    //	// (get) Token: 0x06001E1D RID: 7709 RVA: 0x000D1BDC File Offset: 0x000CFDDC
    //	// (set) Token: 0x06001E1E RID: 7710 RVA: 0x000D1BE4 File Offset: 0x000CFDE4
    //	public int LianjiLev
    //	{
    //		get
    //		{
    //			return this._Lianji;
    //		}
    //		set
    //		{
    //			this._Lianji = value;
    //		}
    //	}

    //	// Token: 0x1700034D RID: 845
    //	// (get) Token: 0x06001E1F RID: 7711 RVA: 0x000D1BF0 File Offset: 0x000CFDF0
    //	// (set) Token: 0x06001E20 RID: 7712 RVA: 0x000D1BF8 File Offset: 0x000CFDF8
    //	public int XuliLev
    //	{
    //		get
    //		{
    //			return this._Xuli;
    //		}
    //		set
    //		{
    //			this._Xuli = value;
    //		}
    //	}

    //	// Token: 0x1700034E RID: 846
    //	// (get) Token: 0x06001E21 RID: 7713 RVA: 0x000D1C04 File Offset: 0x000CFE04
    //	// (set) Token: 0x06001E22 RID: 7714 RVA: 0x000D1C0C File Offset: 0x000CFE0C
    //	public int ZhuijiLev
    //	{
    //		get
    //		{
    //			return this._Zhuiji;
    //		}
    //		set
    //		{
    //			this._Zhuiji = value;
    //		}
    //	}

    //	// Token: 0x1700034F RID: 847
    //	// (get) Token: 0x06001E23 RID: 7715 RVA: 0x000D1C18 File Offset: 0x000CFE18
    //	// (set) Token: 0x06001E24 RID: 7716 RVA: 0x000D1C20 File Offset: 0x000CFE20
    //	public int HelpID
    //	{
    //		get
    //		{
    //			return this._helpID;
    //		}
    //		set
    //		{
    //			this._helpID = value;
    //		}
    //	}

    //	// Token: 0x17000350 RID: 848
    //	// (get) Token: 0x06001E25 RID: 7717 RVA: 0x000D1C2C File Offset: 0x000CFE2C
    //	// (set) Token: 0x06001E26 RID: 7718 RVA: 0x000D1C34 File Offset: 0x000CFE34
    //	public int PourSoul
    //	{
    //		get
    //		{
    //			return this._PourSoul;
    //		}
    //		set
    //		{
    //			this._PourSoul = value;
    //		}
    //	}

    //	// Token: 0x04001B0B RID: 6923
    //	private EquipCfgType _WeaponType;

    //	// Token: 0x04001B0C RID: 6924
    //	private int _Level;

    //	// Token: 0x04001B0D RID: 6925
    //	private int _AmbitID;

    //	// Token: 0x04001B0E RID: 6926
    //	private int _PhaseID;

    //	// Token: 0x04001B0F RID: 6927
    //	private int _ID;

    //	// Token: 0x04001B10 RID: 6928
    //	private int _Count;

    //	// Token: 0x04001B11 RID: 6929
    //	private int _IsUnLockAnimation;

    //	// Token: 0x04001B12 RID: 6930
    //	private int _DeltaCount;

    //	// Token: 0x04001B13 RID: 6931
    //	private int _Lianji = -1;

    //	// Token: 0x04001B14 RID: 6932
    //	private int _Xuli = -1;

    //	// Token: 0x04001B15 RID: 6933
    //	private int _Zhuiji = -1;

    //	// Token: 0x04001B16 RID: 6934
    //	private bool _IsLock = true;

    //	// Token: 0x04001B17 RID: 6935
    //	private string _strName;

    //	// Token: 0x04001B18 RID: 6936
    //	private string _strDesc;

    //	// Token: 0x04001B19 RID: 6937
    //	private string _strDesc2;

    //	// Token: 0x04001B1A RID: 6938
    //	private int _helpID = -1;

    //	// Token: 0x04001B1B RID: 6939
    //	private int _PourSoul;

    //	// Token: 0x04001B1C RID: 6940
    //	private List<AdeptTalent.AdeptData.AddRoleAttribute> _lstAddAttributes = new List<AdeptTalent.AdeptData.AddRoleAttribute>();

    //	// Token: 0x02000486 RID: 1158
    //	[Serializable]
    //	public class AddRoleAttribute
    //	{
    //		// Token: 0x06001E27 RID: 7719 RVA: 0x000D1C40 File Offset: 0x000CFE40
    //		public AddRoleAttribute(ADEPT_ATTRIBUTE type, float val)
    //		{
    //			this._Type = type;
    //			this._fVal = val;
    //		}

    //		// Token: 0x04001B1D RID: 6941
    //		public ADEPT_ATTRIBUTE _Type;

    //		// Token: 0x04001B1E RID: 6942
    //		public float _fVal;

    //		// Token: 0x04001B1F RID: 6943
    //		public int level;

    //		// Token: 0x04001B20 RID: 6944
    //		public float probability;
    //	}
    //}
}
