using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 属性模块
/// </summary>
public class ModAttribute : Module
{
    //public List<ModAttribute.HpReduceInfo> HpReduceList = new List<ModAttribute.HpReduceInfo>();

    public float TotalReduceHp;

    private float fLastTimer = GameTime.time;

    public static List<ATTRIBUTE_TYPE> lstVerifyAttributeList = new List<ATTRIBUTE_TYPE>();

    public PlayerPropertyInfo m_cfgBaseInfo = new PlayerPropertyInfo();

    [HideInInspector]
    public List<ModAttribute.Attribute> AttList = new List<ModAttribute.Attribute>();

    //private List<ModAttribute.Attribute> AttPercentType = new List<ModAttribute.Attribute>();

    private AttackFormula _PhyAttackMan;

    private AttackFormula _MagAttackMan;

    private DefenceFormula _PhyDefenceMan;

    private DefenceFormula _MagDefenceMan;

    private Player player;

    public ModAttribute(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_ATTRIBUTE;
	}

    public AttackFormula PhyAttackMan
    {
        get
        {
            if (this._PhyAttackMan == null)
            {
                this._PhyAttackMan = new AttackFormula(this._role, true);
            }
            return this._PhyAttackMan;
        }
        private set
        {
            this._PhyAttackMan = value;
        }
    }

    public AttackFormula MagAttackMan
    {
        get
        {
            if (this._MagAttackMan == null)
            {
                this._MagAttackMan = new AttackFormula(this._role, false);
            }
            return this._MagAttackMan;
        }
        private set
        {
            this._MagAttackMan = value;
        }
    }

    public DefenceFormula PhyDefenceMan
    {
        get
        {
            if (this._PhyDefenceMan == null)
            {
                this._PhyDefenceMan = new DefenceFormula(this._role, true);
            }
            return this._PhyDefenceMan;
        }
        private set
        {
            this._PhyDefenceMan = value;
        }
    }

    public DefenceFormula MagDefenceMan
    {
        get
        {
            if (this._MagDefenceMan == null)
            {
                this._MagDefenceMan = new DefenceFormula(this._role, false);
            }
            return this._MagDefenceMan;
        }
        private set
        {
            this._MagDefenceMan = value;
        }
    }

    public override bool Init()
    {
        return base.Init();
    }

    //public void SetAttList(List<ModAttribute.Attribute> al)
    //{
    //	this.AttList.Clear();
    //	this.AttList = al;
    //}

    //public void RemoveAttribute(ATTRIBUTE_TYPE attType)
    //{
    //	ModAttribute.Attribute attribute = this.GetAttribute(attType);
    //	if (attribute == null)
    //	{
    //		return;
    //	}
    //	if (attType < ATTRIBUTE_TYPE.ATT_NUMERICAL_END)
    //	{
    //		ModAttribute.Att_Numerical att_Numerical = attribute as ModAttribute.Att_Numerical;
    //		att_Numerical.AddValue = 0f;
    //		att_Numerical.BaseValue = 0f;
    //	}
    //	else
    //	{
    //		ModAttribute.Att_StringIndex att_StringIndex = attribute as ModAttribute.Att_StringIndex;
    //		att_StringIndex.ClearStrList();
    //	}
    //	this.AttList.Remove(attribute);
    //}

    /// <summary>
    /// 设置属性数值
    /// </summary>
    /// <param name="attType"></param>
    /// <param name="value"></param>
    /// <param name="bBase"></param>
    public void SetAttributeNum(ATTRIBUTE_TYPE attType, float value, bool bBase)
    {
        ModAttribute.Att_Numerical att_Numerical = this.GetAttributeCreate(attType) as ModAttribute.Att_Numerical;
        if (this.IsFightType(attType) && !bBase)
        {
            return;
        }
        att_Numerical.Reset();
        if (attType == ATTRIBUTE_TYPE.ATT_HP)
        {
            bBase = true;
        }
        if (attType == ATTRIBUTE_TYPE.ATT_LEVEL)
        {
            bBase = true;
            int num = (int)value;
            if (num < 0)
            {
                num = 0;
            }
            if (num > 6)
            {
                num = 6;
            }
            value = (float)num;
        }
        if (bBase)
        {
            att_Numerical.BaseValue = value;
        }
        else
        {
            att_Numerical.AddValue = value;
        }
        this.UpdateFiveAttribute(attType);
        //this.UpdateCriticalAttribute(attType);
        //if (this._role._roleType == ROLE_TYPE.RT_PLAYER && (attType == ATTRIBUTE_TYPE.ATT_HP || attType == ATTRIBUTE_TYPE.ATT_MAXHP))
        //{
        //    Singleton<HpCautionEffect>.GetInstance().Check();
        //}
    }

    public void SetAttributeNumEx(ATTRIBUTE_TYPE attType, float value, bool bBase)
    {
        //ModAttribute.Att_Numerical att_Numerical = this.GetAttributeCreate(attType) as ModAttribute.Att_Numerical;
        //if (this.IsFightType(attType) && !bBase)
        //{
        //    return;
        //}
        //if (attType == ATTRIBUTE_TYPE.ATT_HP)
        //{
        //    bBase = true;
        //}
        //if (attType == ATTRIBUTE_TYPE.ATT_LEVEL)
        //{
        //    bBase = true;
        //    int num = (int)value;
        //    if (num < 0)
        //    {
        //        num = 0;
        //    }
        //    if (num > 6)
        //    {
        //        num = 6;
        //    }
        //    value = (float)num;
        //}
        //if (bBase)
        //{
        //    att_Numerical.BaseValue = value;
        //}
        //else
        //{
        //    att_Numerical.AddValue = value;
        //}
        //this.UpdateFiveAttribute(attType);
        //this.UpdateCriticalAttribute(attType);
        //if (this._role._roleType == ROLE_TYPE.RT_PLAYER && (attType == ATTRIBUTE_TYPE.ATT_HP || attType == ATTRIBUTE_TYPE.ATT_MAXHP))
        //{
        //    Singleton<HpCautionEffect>.GetInstance().Check();
        //}
    }

    //// Token: 0x06002194 RID: 8596 RVA: 0x000E51D4 File Offset: 0x000E33D4
    //public void UpdateItemAddAttribute(ITEM_ADD_ATTRIBUTE itemtype, float fVal)
    //{
    //	if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_MAG_REPLY)
    //	{
    //		this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAGICREGAIN, fVal);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_MAXHP_PERCENT)
    //	{
    //		this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAXHP, fVal);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_MAXMP_PERCENT)
    //	{
    //		this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAXMP, fVal);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_PHYATK_PERCENT || itemtype == ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_PERCENT)
    //	{
    //		ModBuffProperty modBuffProperty = (ModBuffProperty)this._role.GetModule(MODULE_TYPE.MT_BUFF);
    //		if (modBuffProperty != null)
    //		{
    //			modBuffProperty.AddBuff((int)fVal);
    //		}
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_MAGATK_PERCENT)
    //	{
    //		this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAG_ATK, fVal);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_PERCENT)
    //	{
    //		this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAG_DEF, fVal);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_VALUE)
    //	{
    //		this.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_PHY_DEF, fVal, true);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_VALUE)
    //	{
    //		this.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_MAG_DEF, fVal, true);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_CRITICAL_PERCENT)
    //	{
    //		this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_CRITICAL, fVal);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_PHYHURTLESS_PERCENT)
    //	{
    //		this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_PHY_HURTLESS, fVal);
    //	}
    //	else if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_MAGHURTLESS_PERCENT)
    //	{
    //		this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAG_HURTLESS, fVal);
    //	}
    //	else if (itemtype != ITEM_ADD_ATTRIBUTE.IAAT_ABSORB_PERCENT)
    //	{
    //		if (itemtype == ITEM_ADD_ATTRIBUTE.IAAT_FEATK_PERCENT)
    //		{
    //			this.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK, fVal);
    //		}
    //	}
    //}

    //// Token: 0x06002195 RID: 8597 RVA: 0x00017453 File Offset: 0x00015653
    //public void UpdateAttributeNum(ATTRIBUTE_TYPE attType, float value, bool bBase)
    //{
    //	this.UpdateAttribute(attType, value, bBase, true);
    //}

    //// Token: 0x06002196 RID: 8598 RVA: 0x0001745F File Offset: 0x0001565F
    //public void UpdateAttributePercent(ATTRIBUTE_TYPE attType, float percent, bool bBase)
    //{
    //	this.UpdateAttribute(attType, percent, bBase, false);
    //}

    //// Token: 0x06002197 RID: 8599 RVA: 0x000E5304 File Offset: 0x000E3504
    //public void UpdateAttributePercentByBase(ATTRIBUTE_TYPE attType, float percent)
    //{
    //	if (attType == ATTRIBUTE_TYPE.ATT_LEVEL)
    //	{
    //		return;
    //	}
    //	ModAttribute.Att_Numerical att_Numerical = this.GetAttributeCreate(attType) as ModAttribute.Att_Numerical;
    //	if (attType == ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK)
    //	{
    //		float num = att_Numerical.AddValue + percent;
    //		if (num < 0f)
    //		{
    //			percent = 0f;
    //		}
    //		att_Numerical.AddValue += percent;
    //	}
    //	else
    //	{
    //		float num = att_Numerical.BaseValue * Math.Abs(percent);
    //		if (percent < 0f)
    //		{
    //			num = -num;
    //		}
    //		percent = num;
    //		percent = this.VerifyAttributeRang(attType, att_Numerical, percent);
    //		att_Numerical.BaseValue += percent;
    //	}
    //	if (attType == ATTRIBUTE_TYPE.ATT_LEVEL)
    //	{
    //		if (att_Numerical.Value > 6f)
    //		{
    //			return;
    //		}
    //		int num2 = (int)percent;
    //		percent += (float)num2;
    //	}
    //	if (attType == ATTRIBUTE_TYPE.ATT_MAXHP)
    //	{
    //		float attributeValue = this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_HP);
    //		if (attributeValue > att_Numerical.Value)
    //		{
    //			this.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, att_Numerical.Value - attributeValue, false);
    //		}
    //	}
    //	this.UpdateFiveAttribute(attType);
    //	this.UpdateCriticalAttribute(attType);
    //	if (this._role._roleType == ROLE_TYPE.RT_PLAYER && (attType == ATTRIBUTE_TYPE.ATT_HP || attType == ATTRIBUTE_TYPE.ATT_MAXHP))
    //	{
    //		Singleton<HpCautionEffect>.GetInstance().Check();
    //	}
    //}

    //// Token: 0x06002198 RID: 8600 RVA: 0x000E541C File Offset: 0x000E361C
    //public void UpdateStrAttribute(ATTRIBUTE_TYPE attType, int strIdx, bool bRemoveOld)
    //{
    //	ModAttribute.Att_StringIndex att_StringIndex = this.GetAttributeCreate(attType) as ModAttribute.Att_StringIndex;
    //	if (bRemoveOld)
    //	{
    //		att_StringIndex.ClearStrList();
    //	}
    //	att_StringIndex.AddStr(strIdx);
    //}

    /// <summary>
    /// 获取属性值
    /// </summary>
    /// <param name="attType"></param>
    /// <returns></returns>
    public float GetAttributeValue(ATTRIBUTE_TYPE attType)
    {
        if (attType == ATTRIBUTE_TYPE.ATT_PHY_ATK)
        {
            return this.PhyAttackMan.GetStaticAttackValue();
        }
        if (attType == ATTRIBUTE_TYPE.ATT_MAG_ATK)
        {
            return this.MagAttackMan.GetStaticAttackValue();
        }
        if (attType == ATTRIBUTE_TYPE.ATT_PHY_DEF)
        {
            return this.PhyDefenceMan.GetDefenceValue();
        }
        if (attType == ATTRIBUTE_TYPE.ATT_MAG_DEF)
        {
            return this.MagDefenceMan.GetDefenceValue();
        }
        if (attType == ATTRIBUTE_TYPE.ATT_PHY_HURTLESS)
        {
            float defenceValue = this.PhyDefenceMan.GetDefenceValue();
        }
        if (attType == ATTRIBUTE_TYPE.ATT_MAG_HURTLESS)
        {
            float defenceValue2 = this.MagDefenceMan.GetDefenceValue();
        }
        if (attType == ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK)
        {
            this.UpdateFiveAttribute(attType);
        }
        ModAttribute.Att_Numerical att_Numerical = this.GetAttribute(attType) as ModAttribute.Att_Numerical;
        if (att_Numerical == null)
        {
            return 0f;
        }
        if (attType == ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK)
        {
            return att_Numerical.BaseValue * (1f + att_Numerical.AddValue);
        }
        return att_Numerical.Value;
    }

    //// Token: 0x0600219A RID: 8602 RVA: 0x000E551C File Offset: 0x000E371C
    //public float GetAttributeBaseNum(ATTRIBUTE_TYPE attType)
    //{
    //	ModAttribute.Att_Numerical att_Numerical = this.GetAttribute(attType) as ModAttribute.Att_Numerical;
    //	if (att_Numerical == null)
    //	{
    //		return 0f;
    //	}
    //	return att_Numerical.BaseValue;
    //}

    //// Token: 0x0600219B RID: 8603 RVA: 0x000E5548 File Offset: 0x000E3748
    //public float GetAttributeAddNum(ATTRIBUTE_TYPE attType)
    //{
    //	ModAttribute.Att_Numerical att_Numerical = this.GetAttribute(attType) as ModAttribute.Att_Numerical;
    //	if (att_Numerical == null)
    //	{
    //		return 0f;
    //	}
    //	return att_Numerical.AddValue;
    //}

    //// Token: 0x0600219C RID: 8604 RVA: 0x000E5574 File Offset: 0x000E3774
    //public int GetAttributeStrByIndex(ATTRIBUTE_TYPE attType, int idx)
    //{
    //	ModAttribute.Att_StringIndex att_StringIndex = this.GetAttribute(attType) as ModAttribute.Att_StringIndex;
    //	if (att_StringIndex == null)
    //	{
    //		return -1;
    //	}
    //	return att_StringIndex.GetStrByIndex(idx);
    //}

    //// Token: 0x0600219D RID: 8605 RVA: 0x0001746B File Offset: 0x0001566B
    //public int GetAttributeString(ATTRIBUTE_TYPE attType)
    //{
    //	return this.GetAttributeStrByIndex(attType, 0);
    //}

    //// Token: 0x0600219E RID: 8606 RVA: 0x000E55A0 File Offset: 0x000E37A0
    //public int GetAttributeStrRandom(ATTRIBUTE_TYPE attType)
    //{
    //	ModAttribute.Att_StringIndex att_StringIndex = this.GetAttribute(attType) as ModAttribute.Att_StringIndex;
    //	if (att_StringIndex == null)
    //	{
    //		return -1;
    //	}
    //	int nIdx = UnityEngine.Random.Range(0, att_StringIndex.GetStrListCount());
    //	return att_StringIndex.GetStrByIndex(nIdx);
    //}

    //// Token: 0x0600219F RID: 8607 RVA: 0x000E55D8 File Offset: 0x000E37D8
    //public float GetLastReduceHp(float sec)
    //{
    //	float time = GameTime.time;
    //	float num = 0f;
    //	for (int i = 0; i < this.HpReduceList.Count; i++)
    //	{
    //		if (time - this.HpReduceList[i].time <= sec)
    //		{
    //			num += this.HpReduceList[i].value;
    //		}
    //	}
    //	return Math.Abs(num);
    //}

    //// Token: 0x060021A0 RID: 8608 RVA: 0x000E5648 File Offset: 0x000E3848
    //public static string GetAttributeName(ATTRIBUTE_TYPE type)
    //{
    //	string result = string.Empty;
    //	if (type == ATTRIBUTE_TYPE.ATT_LEVEL)
    //	{
    //		result = "境界";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_HP)
    //	{
    //		result = "生命";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MAXHP)
    //	{
    //		result = "最大生命";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MP)
    //	{
    //		result = "灵力";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MAXMP)
    //	{
    //		result = "最大灵力";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_CRITICAL)
    //	{
    //		result = "会心";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_CRITCHANCE)
    //	{
    //		result = "暴击率";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_PHY_HURTLESS)
    //	{
    //		result = "物理减伤率";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MAG_HURTLESS)
    //	{
    //		result = "法术减伤率";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_PHY_ATK)
    //	{
    //		result = "攻击";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_PHY_DEF)
    //	{
    //		result = "防御";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MAG_ATK)
    //	{
    //		result = "法术攻击力";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MAG_DEF)
    //	{
    //		result = "法术防御力";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_BGILITY)
    //	{
    //		result = "敏捷";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_BLOODREGAIN)
    //	{
    //		result = "生命回复";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MAGICREGAIN)
    //	{
    //		result = "灵力回复";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_SUPERARMOR)
    //	{
    //		result = "霸体";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_HITRECOVER)
    //	{
    //		result = "硬直";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_METAL_ELEMENT)
    //	{
    //		result = "五行属性·金";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_WOOD_ELEMENT)
    //	{
    //		result = "五行属性·木";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_WATER_ELEMENT)
    //	{
    //		result = "五行属性·水";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_FIRE_ELEMENT)
    //	{
    //		result = "五行属性·火";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT)
    //	{
    //		result = "五行属性·土";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK)
    //	{
    //		result = "五行伤害";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_HunVal)
    //	{
    //		result = "魂值";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MONEY)
    //	{
    //		result = "持有货币";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_VIEW_RANGE)
    //	{
    //		result = " 视野范围";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_ATTACK_RANGE)
    //	{
    //		result = " 攻击范围";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_ATTACK_INTERVAL)
    //	{
    //		result = " 攻击间隔";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_MOVESPEED)
    //	{
    //		result = " 移动速度";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_TRUNSPEED)
    //	{
    //		result = " 转向速度";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_ATTACK_FLEE)
    //	{
    //		result = "逃跑指数";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_PREPARE_TIME)
    //	{
    //		result = "观望时间";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_ATTACK_TIMES)
    //	{
    //		result = "连续攻击次数 -1代表无限次";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_CUR_ATK_TIMES)
    //	{
    //		result = "当前攻击次数";
    //	}
    //	else if (type == ATTRIBUTE_TYPE.ATT_FEEBLE)
    //	{
    //		result = "虚弱";
    //	}
    //	return result;
    //}

    //// Token: 0x060021A1 RID: 8609 RVA: 0x000E58FC File Offset: 0x000E3AFC
    //public KeyValuePair<float, bool> AttackCalculate(Role StufferObj, FightInfo AttObj)
    //{
    //	KeyValuePair<float, bool> result = new KeyValuePair<float, bool>(0f, false);
    //	if (StufferObj == null || AttObj == null || AttObj._role == null)
    //	{
    //		return result;
    //	}
    //	ModAttribute modAttribute = (ModAttribute)AttObj._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE);
    //	if (modAttribute == null)
    //	{
    //		return result;
    //	}
    //	ModAttribute modAttribute2 = (ModAttribute)StufferObj.GetModule(MODULE_TYPE.MT_ATTRIBUTE);
    //	if (modAttribute2 == null)
    //	{
    //		return result;
    //	}
    //	float num = AttObj._calculatedDamage;
    //	if (num == -1f)
    //	{
    //		num = ((AttObj._fightType != FightInfo.FightType.FT_PHY) ? modAttribute.MagAttackMan.GetAttackValue(AttObj) : modAttribute.PhyAttackMan.GetAttackValue(AttObj));
    //	}
    //	float num2 = (AttObj._fightType != FightInfo.FightType.FT_PHY) ? modAttribute2.MagDefenceMan.GetDefenceValue() : modAttribute2.PhyDefenceMan.GetDefenceValue();
    //	ATTRIBUTE_TYPE attType = (AttObj._fightType != FightInfo.FightType.FT_PHY) ? ATTRIBUTE_TYPE.ATT_MAG_HURTLESS : ATTRIBUTE_TYPE.ATT_PHY_HURTLESS;
    //	float num3 = modAttribute2.GetAttributeValue(attType);
    //	if (num3 < 0f)
    //	{
    //		num3 = 0f;
    //	}
    //	float num4 = UnityEngine.Random.Range(0.9f, 1.1f);
    //	bool value = false;
    //	float num5 = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_CRITCHANCE);
    //	if (UnityEngine.Random.Range(0f, 1f) <= num5)
    //	{
    //		value = true;
    //		num5 = 1f;
    //	}
    //	else
    //	{
    //		num5 = 1f;
    //	}
    //	float num6 = 0f;
    //	if (AttObj._fightType == FightInfo.FightType.FT_PHY)
    //	{
    //		num6 = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK);
    //		ModBuffProperty modBuffProperty = (ModBuffProperty)this._role.GetModule(MODULE_TYPE.MT_BUFF);
    //		if (modBuffProperty != null)
    //		{
    //			num6 *= ((AttObj._fightType != FightInfo.FightType.FT_PHY) ? modBuffProperty.GetMAttackPercent() : modBuffProperty.GetAttackPercent());
    //		}
    //	}
    //	float num7 = num * (1f - num3) * num4 * num5 + num6;
    //	num7 *= AttObj.harmScale;
    //	ModBuffProperty modBuffProperty2 = (ModBuffProperty)this._role.GetModule(MODULE_TYPE.MT_BUFF);
    //	if (modBuffProperty2 != null && modBuffProperty2.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE) != 0)
    //	{
    //		modBuffProperty2.AddAbsorbDamage(num7, AttObj, this._role);
    //		return new KeyValuePair<float, bool>(0f, false);
    //	}
    //	if (modBuffProperty2 != null && modBuffProperty2.GetValue(BUFF_VALUE_TYPE.COUNT) != 0)
    //	{
    //		if (!modBuffProperty2.ContainBuff(251))
    //		{
    //			modBuffProperty2.AddAbsorbCount(num7, AttObj, this._role);
    //			return new KeyValuePair<float, bool>(0f, false);
    //		}
    //		Vector3 to = AttObj._role.GetPos() - this._role.GetPos();
    //		to.y = 0f;
    //		Vector3 forward = this._role.GetTrans().forward;
    //		forward.y = 0f;
    //		float num8 = Vector3.Angle(forward, to);
    //		if ((num8 >= 270f && num8 <= 0f) || (num8 >= 0f && num8 <= 90f))
    //		{
    //			modBuffProperty2.AddAbsorbCount(num7, AttObj, this._role);
    //			return new KeyValuePair<float, bool>(0f, false);
    //		}
    //	}
    //	if (modBuffProperty2 != null && modBuffProperty2.GetValue(BUFF_VALUE_TYPE.DEL_DAMAGE_PER) != 0)
    //	{
    //		float num9 = (float)modBuffProperty2.GetValue(BUFF_VALUE_TYPE.DEL_DAMAGE_PER);
    //		float num10 = 0f;
    //		if (num9 > 0f)
    //		{
    //			num10 = num7 * num9 / 100f;
    //		}
    //		modAttribute2.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, -(num7 - num10), false);
    //		return new KeyValuePair<float, bool>(-(num7 - num10), value);
    //	}
    //	if (modBuffProperty2 != null && modBuffProperty2.GetValue(BUFF_VALUE_TYPE.DAMAGE_BACK) != 0)
    //	{
    //		modBuffProperty2.addDamageBack(num7, AttObj);
    //	}
    //	if (modBuffProperty2 != null && modBuffProperty2.GetValue(BUFF_VALUE_TYPE.CHAIN_HURT) != 0)
    //	{
    //		modBuffProperty2.addChainHurt(num7, this._role, AttObj);
    //	}
    //	ModBuffProperty modBuffProperty3 = (ModBuffProperty)AttObj._role.GetModule(MODULE_TYPE.MT_BUFF);
    //	if (modBuffProperty3 != null && modBuffProperty3.GetValue(BUFF_VALUE_TYPE.ATTACK_HP) != 0 && UnityEngine.Random.RandomRange(1, 100) <= 5)
    //	{
    //		modBuffProperty3.addAttackHp(Mathf.Abs(num7));
    //	}
    //	if (modBuffProperty3 != null && modBuffProperty3.GetValue(BUFF_VALUE_TYPE.BLOOD_BLADE) != 0)
    //	{
    //		modBuffProperty3.addBloodBladeAttackHp(Mathf.Abs(num7));
    //	}
    //	if (modBuffProperty3 != null && modBuffProperty3.GetValue(BUFF_VALUE_TYPE.XUE_LONG) != 0)
    //	{
    //		modBuffProperty3.addBlood(Mathf.Abs(num7));
    //	}
    //	if (modBuffProperty3 != null && modBuffProperty3.GetValue(BUFF_VALUE_TYPE.HIT_FROZEN) != 0)
    //	{
    //		modBuffProperty3.addAttackBing(AttObj);
    //	}
    //	if (modBuffProperty3 != null && modBuffProperty3.GetValue(BUFF_VALUE_TYPE.FIREBLADE) != 0)
    //	{
    //		modBuffProperty2.AddBuff(277);
    //		modBuffProperty3.DelBuff(260);
    //	}
    //	if (modBuffProperty2 != null && modBuffProperty2.GetValue(BUFF_VALUE_TYPE.HIT_SLOW) != 0)
    //	{
    //		Debug.Log("HIT_SLOW ");
    //		modBuffProperty3.addHitSlow(AttObj);
    //	}
    //	if (modBuffProperty2 != null && modBuffProperty2.GetValue(BUFF_VALUE_TYPE.HIT_DEL_ATTACK) != 0)
    //	{
    //		Debug.Log("HIT_DEL_ATTACK ");
    //		modBuffProperty3.addHitDelAttack(AttObj);
    //	}
    //	if (modBuffProperty2 != null && modBuffProperty2.GetValue(BUFF_VALUE_TYPE.THUNDER_ZONE) != 0)
    //	{
    //		modBuffProperty3.addThunderZone(AttObj, this._role);
    //	}
    //	if (modBuffProperty3 != null && modBuffProperty3.GetValue(BUFF_VALUE_TYPE.YRYY_ZR) != 0 && UnityEngine.Random.RandomRange(1, 100) <= 10)
    //	{
    //		modBuffProperty3.addYRYYZR();
    //	}
    //	float attributeValue = modAttribute2.GetAttributeValue(ATTRIBUTE_TYPE.ATT_FEEBLE);
    //	float num11 = 0f;
    //	if (attributeValue > 0f)
    //	{
    //		num11 = attributeValue * num7;
    //	}
    //	modAttribute2.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, -(num7 + num11), false);
    //	if (AttObj._role._roleType == ROLE_TYPE.RT_PLAYER)
    //	{
    //		Singleton<DrillSystem>.GetInstance().CheckMissionStateAttack(AttObj, StufferObj);
    //	}
    //	return new KeyValuePair<float, bool>(-num7, value);
    //}

    private ModAttribute.Attribute GetAttributeCreate(ATTRIBUTE_TYPE attType)
    {
        ModAttribute.Attribute attribute = this.GetAttribute(attType);
        if (attribute == null)
        {
            if (attType < ATTRIBUTE_TYPE.ATT_NUMERICAL_END)
            {
                attribute = new ModAttribute.Att_Numerical();
            }
            else
            {
                attribute = new ModAttribute.Att_StringIndex();
            }
            attribute.attType = attType;
            this.AttList.Add(attribute);
        }
        if (attribute == null)
        {
            Debug.Log("Attribute is also null");
        }
        return attribute;
    }

    public ModAttribute.Attribute GetAttribute(ATTRIBUTE_TYPE attType)
    {
        for (int i = 0; i < this.AttList.Count; i++)
        {
            if (this.AttList[i].attType == attType)
            {
                return this.AttList[i];
            }
        }
        return null;
    }

    //private Player MainPlayer
    //{
    //	get
    //	{
    //		if (this.player == null)
    //		{
    //			this.player = (Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId);
    //			if (this.player == null)
    //			{
    //				Debug.Log("no find player.");
    //			}
    //		}
    //		return this.player;
    //	}
    //}

    //// Token: 0x060021A5 RID: 8613 RVA: 0x000E5F5C File Offset: 0x000E415C
    //private void UpdateAttribute(ATTRIBUTE_TYPE attType, float value, bool bBase, bool bNum)
    //{
    //	if ((attType == ATTRIBUTE_TYPE.ATT_HP || attType == ATTRIBUTE_TYPE.ATT_MAXHP) && !bNum && attType == ATTRIBUTE_TYPE.ATT_LEVEL)
    //	{
    //		return;
    //	}
    //	if (attType == ATTRIBUTE_TYPE.ATT_HP)
    //	{
    //		bBase = true;
    //	}
    //	if (!bBase)
    //	{
    //		if (this.IsFightType(attType))
    //		{
    //			return;
    //		}
    //		if (attType == ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK && bNum)
    //		{
    //			Debug.LogError("UpdateAttribute not allow set addvalue and non num types: " + attType);
    //			return;
    //		}
    //	}
    //	ModAttribute.Att_Numerical att_Numerical = this.GetAttributeCreate(attType) as ModAttribute.Att_Numerical;
    //	if (!bNum)
    //	{
    //		float num = att_Numerical.Value * Math.Abs(value);
    //		if (value < 0f)
    //		{
    //			num = -num;
    //		}
    //		value = num;
    //	}
    //	value = this.VerifyAttributeRang(attType, att_Numerical, value);
    //	if (attType == ATTRIBUTE_TYPE.ATT_LEVEL)
    //	{
    //		bBase = true;
    //		if (att_Numerical.Value > 6f)
    //		{
    //			return;
    //		}
    //		int num2 = (int)value;
    //		value += (float)num2;
    //	}
    //	if (bBase)
    //	{
    //		att_Numerical.BaseValue += value;
    //	}
    //	else
    //	{
    //		att_Numerical.AddValue += value;
    //	}
    //	if (attType == ATTRIBUTE_TYPE.ATT_MAXHP)
    //	{
    //		float attributeValue = this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_HP);
    //		if (attributeValue > att_Numerical.Value)
    //		{
    //			this.SetAttributeNum(ATTRIBUTE_TYPE.ATT_HP, att_Numerical.Value, true);
    //		}
    //	}
    //	if (attType == ATTRIBUTE_TYPE.ATT_HP && value < 0f)
    //	{
    //		this.TotalReduceHp += value;
    //		ModAttribute.HpReduceInfo hpReduceInfo = new ModAttribute.HpReduceInfo();
    //		hpReduceInfo.value = value;
    //		hpReduceInfo.time = GameTime.time;
    //		this.HpReduceList.Add(hpReduceInfo);
    //	}
    //	this.UpdateFiveAttribute(attType);
    //	this.UpdateCriticalAttribute(attType);
    //	if (this._role._roleType == ROLE_TYPE.RT_PLAYER && (attType == ATTRIBUTE_TYPE.ATT_HP || attType == ATTRIBUTE_TYPE.ATT_MAXHP))
    //	{
    //		Singleton<HpCautionEffect>.GetInstance().Check();
    //	}
    //	if (this._role._roleType == ROLE_TYPE.RT_PLAYER && attType == ATTRIBUTE_TYPE.ATT_HP)
    //	{
    //		if (this.MainPlayer.m_RoleGrowDatas.dan_count <= 2 && (float)this.player.GetCurHp() < (float)this.player.GetMaxHp() * 0.3f && (PropsPlane.m_keyA > 0UL || PropsPlane.m_keyB > 0UL))
    //		{
    //			this.MainPlayer.m_RoleGrowDatas.dan_count++;
    //			GameData.Instance.ScrMan.Exec(44, 1000011);
    //			return;
    //		}
    //		if (this.MainPlayer.m_RoleGrowDatas.dan_count > 2 && (float)this.player.GetCurHp() < (float)this.player.GetMaxHp() * 0.3f && (PropsPlane.m_keyA > 0UL || PropsPlane.m_keyB > 0UL))
    //		{
    //			GameData.Instance.ScrMan.Exec(44, 1000012);
    //		}
    //	}
    //	if ((attType == ATTRIBUTE_TYPE.ATT_LIANTI || attType == ATTRIBUTE_TYPE.ATT_LIANSHEN) && att_Numerical.Value >= 3f)
    //	{
    //		att_Numerical.BaseValue = 0f;
    //	}
    //}

    private void UpdateFiveAttribute(ATTRIBUTE_TYPE attType)
    {
        if (this.eFiveTypes == null)
        {
            return;
        }
        bool flag = false;
        for (int i = 0; i < this.eFiveTypes.Length; i++)
        {
            if (attType == this.eFiveTypes[i])
            {
                flag = true;
                break;
            }
        }
        if (!flag)
        {
            return;
        }
        float num = 0f;
        for (int j = 0; j < this.eFiveTypes.Length; j++)
        {
            num += this.GetAttributeValue(this.eFiveTypes[j]);
        }
        num /= 5f;
        this.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK, num, true);
    }

    //// Token: 0x060021A7 RID: 8615 RVA: 0x000E62B8 File Offset: 0x000E44B8
    //private void UpdateCriticalAttribute(ATTRIBUTE_TYPE attType)
    //{
    //	if (attType != ATTRIBUTE_TYPE.ATT_CRITICAL)
    //	{
    //		return;
    //	}
    //	float attributeValue = this.GetAttributeValue(attType);
    //	float value = attributeValue / (attributeValue + 16.4f * attributeValue / 10f + 173f);
    //	this.SetAttributeNumEx(ATTRIBUTE_TYPE.ATT_CRITCHANCE, value, true);
    //}

    //// Token: 0x060021A8 RID: 8616 RVA: 0x000E62F8 File Offset: 0x000E44F8
    //private float VerifyAttributeRang(ATTRIBUTE_TYPE type, ModAttribute.Att_Numerical att, float value)
    //{
    //	if (type == ATTRIBUTE_TYPE.ATT_HP)
    //	{
    //		float num = this.GetAttributeValue(type) + value;
    //		float attributeValue = this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP);
    //		if (num > attributeValue)
    //		{
    //			return attributeValue - att.Value;
    //		}
    //	}
    //	if (type == ATTRIBUTE_TYPE.ATT_MP)
    //	{
    //		float num2 = this.GetAttributeValue(type) + value;
    //		float attributeValue2 = this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXMP);
    //		if (num2 > attributeValue2)
    //		{
    //			return attributeValue2 - att.Value;
    //		}
    //	}
    //	return value;
    //}

    //// Token: 0x060021A9 RID: 8617 RVA: 0x000E6358 File Offset: 0x000E4558
    //private float GetAllAttributeForEquip(ATTRIBUTE_TYPE type)
    //{
    //	float num = 0f;
    //	if (this._role._roleType != ROLE_TYPE.RT_PLAYER)
    //	{
    //		return num;
    //	}
    //	Player player = this._role as Player;
    //	List<CItemBase> list;
    //	if (player.ItemFolder.TryGetUsedEquipData(out list))
    //	{
    //		foreach (CItemBase citemBase in list)
    //		{
    //			foreach (KeyValuePair<ATTRIBUTE_TYPE, float> keyValuePair in citemBase.DynamicData.ITEM_ATTRIBUTES_MAP)
    //			{
    //				if (keyValuePair.Key == type)
    //				{
    //					num += keyValuePair.Value;
    //				}
    //			}
    //		}
    //	}
    //	return num;
    //}

    private bool IsFightType(ATTRIBUTE_TYPE type)
    {
        return type == ATTRIBUTE_TYPE.ATT_PHY_ATK || type == ATTRIBUTE_TYPE.ATT_MAG_ATK || type == ATTRIBUTE_TYPE.ATT_PHY_DEF || type == ATTRIBUTE_TYPE.ATT_MAG_DEF;
    }

    //// Token: 0x060021AB RID: 8619 RVA: 0x000E6444 File Offset: 0x000E4644
    //private float GetReferLevel(float boundary)
    //{
    //	if (boundary == 0f)
    //	{
    //		return 1f;
    //	}
    //	if (boundary == 1f)
    //	{
    //		return 7f;
    //	}
    //	if (boundary == 2f)
    //	{
    //		return 15f;
    //	}
    //	if (boundary == 3f)
    //	{
    //		return 22f;
    //	}
    //	if (boundary == 4f)
    //	{
    //		return 30f;
    //	}
    //	if (boundary == 5f)
    //	{
    //		return 38f;
    //	}
    //	if (boundary == 6f)
    //	{
    //		return 45f;
    //	}
    //	return 0f;
    //}

    public override void Process()
    {
        if (this._role._roleType != ROLE_TYPE.RT_PLAYER)
        {
            return;
        }
        //if (this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_HP) < this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP))
        //{
        //    float attributeValue = this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_BLOODREGAIN);
        //    if (attributeValue > 0f)
        //    {
        //        float num = this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP) * attributeValue;
        //        this.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, num * GameTime.deltaTime, false);
        //    }
        //}
        //if (this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MP) < this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXMP))
        //{
        //    float attributeValue2 = this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAGICREGAIN);
        //    if (attributeValue2 > 0f)
        //    {
        //        float num2 = this.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXMP) * attributeValue2;
        //        this.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_MP, num2 * GameTime.deltaTime, false);
        //    }
        //}
    }

    //private float GetFiveAddValue(ATTRIBUTE_TYPE fivetype)
    //{
    //	float attributeValue = this.GetAttributeValue(fivetype);
    //	if (fivetype == ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT)
    //	{
    //		if (attributeValue > 0f && attributeValue <= 50f)
    //		{
    //			return 0.02f;
    //		}
    //		if (attributeValue > 50f && attributeValue <= 100f)
    //		{
    //			return 0.03f;
    //		}
    //		if (attributeValue > 100f && attributeValue <= 99999f)
    //		{
    //			return 0.04f;
    //		}
    //	}
    //	else if (fivetype == ATTRIBUTE_TYPE.ATT_WATER_ELEMENT)
    //	{
    //		if (attributeValue > 0f && attributeValue <= 50f)
    //		{
    //			return 0.01f;
    //		}
    //		if (attributeValue > 50f && attributeValue <= 100f)
    //		{
    //			return 0.02f;
    //		}
    //		if (attributeValue > 100f && attributeValue <= 99999f)
    //		{
    //			return 0.03f;
    //		}
    //	}
    //	return 0f;
    //}

    public const int ATTACK_DESIRE_CRITICAL = 100;

    private ATTRIBUTE_TYPE[] eFiveTypes = new ATTRIBUTE_TYPE[]
    {
        ATTRIBUTE_TYPE.ATT_METAL_ELEMENT,
        ATTRIBUTE_TYPE.ATT_WOOD_ELEMENT,
        ATTRIBUTE_TYPE.ATT_WATER_ELEMENT,
        ATTRIBUTE_TYPE.ATT_FIRE_ELEMENT,
        ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT
    };

    public class HpReduceInfo
    {
        public float time;

        public float value;
    }

    [Serializable]
    public class Attribute
    {
        public ATTRIBUTE_TYPE attType;
    }

    /// <summary>
    /// 数值
    /// </summary>
    [Serializable]
    public class Att_Numerical : ModAttribute.Attribute
    {
        private float _fTotalValue;

        private float _fBaseValue;

        private float _fAddValue;

        public float Value
    	{
    		get
    		{
    			return this._fTotalValue;
    		}
    	}

        public float BaseValue
        {
            get
            {
                return this._fBaseValue;
            }
            set
            {
                this._fBaseValue = value;
                this._fTotalValue = this._fBaseValue + this._fAddValue;
            }
        }

        public float AddValue
        {
            get
            {
                return this._fAddValue;
            }
            set
            {
                this._fAddValue = value;
                this._fTotalValue = this._fBaseValue + this._fAddValue;
            }
        }

        public void Reset()
        {
            this._fTotalValue = 0f;
            this._fBaseValue = 0f;
            this._fAddValue = 0f;
        }
    }

    [Serializable]
    public class Att_StringIndex : ModAttribute.Attribute
    {
        private List<int> _strIdxList = new List<int>();

        public bool AddStr(int strIdx)
        {
            if (this._strIdxList.Contains(strIdx))
            {
                return false;
            }
            this._strIdxList.Add(strIdx);
            return true;
        }

        public void ClearStrList()
        {
            this._strIdxList.Clear();
        }

        public int GetStrListCount()
        {
            return this._strIdxList.Count;
        }

        public int GetRandomStrIdx()
        {
            int nIdx = UnityEngine.Random.Range(0, this.GetStrListCount());
            return this.GetStrByIndex(nIdx);
        }

        public int GetStrByIndex(int nIdx)
        {
            if (nIdx < 0 || nIdx >= this._strIdxList.Count)
            {
                return -1;
            }
            return this._strIdxList[nIdx];
        }

        public int GetStrIdx()
        {
            if (this._strIdxList.Count <= 0)
            {
                return -1;
            }
            return this.GetStrByIndex(0);
        }
    }
    }
