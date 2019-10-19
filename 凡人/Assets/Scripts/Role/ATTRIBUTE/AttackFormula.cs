using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻击方程
/// </summary>
public class AttackFormula
{
    private int count;

    private float fBaseValue;

    private float fSkillValue;

    private float fWeaponFactor;

    private float fEquipPercent;

    private float fAdeptPercent;

    private float fFEPercent;

    private float fEquipValue;

    private float fBuffAndOtherPercent;

    private float fBuffAndOtherValue;

    private float _fValue;

    private float _fStaticValue;

    private bool _IsPhyAttack;

    private Role _role;

   // private Dictionary<RoleWearEquipPos, CItemBase> table = new Dictionary<RoleWearEquipPos, CItemBase>();

    public AttackFormula(Role role, bool bPhy)
	{
		this._role = role;
		this._IsPhyAttack = bPhy;
	}

	public float Value
	{
		get
		{
			return this.GetStaticAttackValue();
		}
	}

	public bool IsPhyAttack
	{
		get
		{
			return this._IsPhyAttack;
		}
	}

	public void ClearData()
	{
		this.fBaseValue = 0f;
		this.fSkillValue = 0f;
		this.fWeaponFactor = 0f;
		this.fEquipPercent = 0f;
		this.fAdeptPercent = 0f;
		this.fFEPercent = 0f;
		this.fEquipValue = 0f;
		this.fBuffAndOtherPercent = 0f;
		this.fBuffAndOtherValue = 0f;
	}

    //public float GetSupposeValue(CItemBase pItem)
    //{
    //	if (this._role == null)
    //	{
    //		return 0f;
    //	}
    //	ModAttribute modAttribute = this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //	if (modAttribute == null)
    //	{
    //		return 0f;
    //	}
    //	Player player = null;
    //	if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
    //	{
    //		player = (Player)this._role;
    //	}
    //	RoleWearEquipPos wearPos = player.ItemFolder.WearOperate.GetWearPos(pItem);
    //	if (pItem == null || player == null || wearPos == RoleWearEquipPos.WEAR_UNKNOWN)
    //	{
    //		return 0f;
    //	}
    //	float num = 0f;
    //	float num2 = 0f;
    //	float num3 = 0f;
    //	float num4 = 0f;
    //	float num5 = 0f;
    //	float num6 = 0f;
    //	ATTRIBUTE_TYPE attribute_TYPE = this._IsPhyAttack ? ATTRIBUTE_TYPE.ATT_PHY_ATK : ATTRIBUTE_TYPE.ATT_MAG_ATK;
    //	float num7 = modAttribute.GetAttributeBaseNum(attribute_TYPE);
    //	this.table.Clear();
    //	this.table = new Dictionary<RoleWearEquipPos, CItemBase>(player.ItemFolder.WearOperate._WearTable);
    //	this.table[wearPos] = pItem;
    //	if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
    //	{
    //		num7 += player.ItemFolder.WearOperate.GetSupposeEquipBaseValue(attribute_TYPE, this.table);
    //	}
    //	float num8 = 1f;
    //	if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
    //	{
    //		if (this._IsPhyAttack)
    //		{
    //			num = player.ItemFolder.WearOperate.GetSupposeEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_PHYATK_PERCENT, this.table);
    //		}
    //		else
    //		{
    //			num = player.ItemFolder.WearOperate.GetSupposeEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_MAGATK_PERCENT, this.table);
    //		}
    //		num2 = ((!this._IsPhyAttack) ? player.m_cAdeptSystem.AddCount.MagAtk : player.m_cAdeptSystem.AddCount.PhyAtk);
    //		num3 = ((!this._IsPhyAttack) ? this.GetFiveAddValue(ATTRIBUTE_TYPE.ATT_WOOD_ELEMENT) : this.GetFiveAddValue(ATTRIBUTE_TYPE.ATT_METAL_ELEMENT));
    //	}
    //	ModBuffProperty modBuffProperty = (ModBuffProperty)this._role.GetModule(MODULE_TYPE.MT_BUFF);
    //	if (modBuffProperty != null)
    //	{
    //		num5 = ((!this._IsPhyAttack) ? modBuffProperty.GetMAttackPercent() : modBuffProperty.GetAttackPercent());
    //		if (this._role._roleType == ROLE_TYPE.RT_PLAYER && player.SystemAmbit != null)
    //		{
    //			num5 += player.SystemAmbit.GetAddAttackPer(this._IsPhyAttack);
    //		}
    //		this.fBuffAndOtherValue = (float)((!this._IsPhyAttack) ? modBuffProperty.GetMAttackValues() : modBuffProperty.GetAttackValues());
    //	}
    //	return (num7 * num8 * (1f + num + num2 + num3) + num4) * (1f + num5) + num6;
    //}

    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="fight"></param>
    private void UpdateData(FightInfo fight)
    {
        if (this._role == null)
        {
            return;
        }
        ModAttribute modAttribute = this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
        if (modAttribute == null)
        {
            return;
        }
        this.ClearData();
        Player player = null;
        if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
        {
            player = (Player)this._role;
        }
        ATTRIBUTE_TYPE attribute_TYPE = this._IsPhyAttack ? ATTRIBUTE_TYPE.ATT_PHY_ATK : ATTRIBUTE_TYPE.ATT_MAG_ATK;
        //this.fBaseValue = modAttribute.GetAttributeBaseNum(attribute_TYPE);
        if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
        {
            // this.fBaseValue += player.ItemFolder.WearOperate.GetDependEquipBaseValue(attribute_TYPE);
        }
        if (fight != null)
        {
            this.fSkillValue = Mathf.Abs(fight._damage);
        }
        this.fWeaponFactor = 1f;
        if (this._role._roleType == ROLE_TYPE.RT_PLAYER && this._IsPhyAttack && fight != null && player != null)
        {
            //this.fWeaponFactor = player.ItemFolder.WearOperate.GetWearWeaponFactor((int)player.ItemFolder.WearOperate.GetWearWeaponType());
        }
        if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
        {
            if (this._IsPhyAttack)
            {
                // this.fEquipPercent = player.ItemFolder.WearOperate.GetDependEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_PHYATK_PERCENT);
            }
            else
            {
                //this.fEquipPercent = player.ItemFolder.WearOperate.GetDependEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_MAGATK_PERCENT);
            }
            //this.fAdeptPercent = ((!this._IsPhyAttack) ? player.m_cAdeptSystem.AddCount.MagAtk : player.m_cAdeptSystem.AddCount.PhyAtk);
            this.fFEPercent = ((!this._IsPhyAttack) ? this.GetFiveAddValue(ATTRIBUTE_TYPE.ATT_WOOD_ELEMENT) : this.GetFiveAddValue(ATTRIBUTE_TYPE.ATT_METAL_ELEMENT));
        }
        //ModBuffProperty modBuffProperty = (ModBuffProperty)this._role.GetModule(MODULE_TYPE.MT_BUFF);
        //if (modBuffProperty != null)
        //{
        //    this.fBuffAndOtherPercent = ((!this._IsPhyAttack) ? modBuffProperty.GetMAttackPercent() : modBuffProperty.GetAttackPercent());
        //    //if (this._role._roleType == ROLE_TYPE.RT_PLAYER && player.SystemAmbit != null)
        //    //{
        //    //    this.fBuffAndOtherPercent += player.SystemAmbit.GetAddAttackPer(this._IsPhyAttack);
        //    //}
        //    this.fBuffAndOtherValue = (float)((!this._IsPhyAttack) ? modBuffProperty.GetMAttackValues() : modBuffProperty.GetAttackValues());
        //}
    }

    public float GetAttackValue(FightInfo fight)
    {
        if (this._role == null)
        {
            return 0f;
        }
        this.UpdateData(fight);
        this.CalculateData();
        return this._fValue;
    }

    public float GetStaticAttackValue()
    {
        if (this._role == null)
        {
            return 0f;
        }
        this.UpdateData(null);
        this.CalculateStaticData();
        return this._fStaticValue;
    }

    private float GetFiveAddValue(ATTRIBUTE_TYPE fivetype)
	{
		if (this._role == null)
		{
			return 0f;
		}
		ModAttribute modAttribute = this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
		if (modAttribute == null)
		{
			return 0f;
		}
		float attributeValue = modAttribute.GetAttributeValue(fivetype);
		if (fivetype == ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT)
		{
			if (attributeValue > 0f && attributeValue <= 50f)
			{
				return 0.02f;
			}
			if (attributeValue > 50f && attributeValue <= 100f)
			{
				return 0.03f;
			}
			if (attributeValue > 100f && attributeValue <= 99999f)
			{
				return 0.04f;
			}
		}
		else if (fivetype == ATTRIBUTE_TYPE.ATT_WATER_ELEMENT)
		{
			if (attributeValue > 0f && attributeValue <= 50f)
			{
				return 0.01f;
			}
			if (attributeValue > 50f && attributeValue <= 100f)
			{
				return 0.02f;
			}
			if (attributeValue > 100f && attributeValue <= 99999f)
			{
				return 0.03f;
			}
		}
		return 0f;
	}

	private void CalculateData()
	{
		this._fValue = ((this.fBaseValue + this.fSkillValue) * this.fWeaponFactor * (1f + this.fEquipPercent + this.fAdeptPercent + this.fFEPercent) + this.fEquipValue) * (1f + this.fBuffAndOtherPercent) + this.fBuffAndOtherValue;
	}

	private void CalculateStaticData()
	{
		this._fStaticValue = (this.fBaseValue * this.fWeaponFactor * (1f + this.fEquipPercent + this.fAdeptPercent + this.fFEPercent) + this.fEquipValue) * (1f + this.fBuffAndOtherPercent) + this.fBuffAndOtherValue;
	}

	public override string ToString()
	{
		string text = "AttackFormula: ";
		text += ((!this._IsPhyAttack) ? ("法术攻击 :" + this._fValue.ToString()) : "物理攻击 :");
		text += " = ";
		string text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"((人物基础值+装备基础值=>",
			this.fBaseValue,
			" 技能攻击=>",
			this.fSkillValue,
			" ) * 武器系数=>",
			this.fWeaponFactor,
			"* ( 1+  装备附加%=>",
			this.fEquipPercent,
			" 精通附加%=>",
			this.fAdeptPercent,
			" 五行附加%=>",
			this.fFEPercent,
			") +  装备附加值=>",
			this.fEquipValue,
			" )"
		});
		text += " * ( 1 + ";
		text2 = text;
		return string.Concat(new object[]
		{
			text2,
			" buffer%和境界%=>",
			this.fBuffAndOtherPercent,
			" ) +  buffer和境界附加=>",
			this.fBuffAndOtherValue
		});
	}
}
