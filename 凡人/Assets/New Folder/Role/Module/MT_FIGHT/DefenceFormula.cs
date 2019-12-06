using System;
using System.Collections.Generic;


public class DefenceFormula
{
    private float fBaseValue;

    // Token: 0x04001E0B RID: 7691
    private float fEquipPercent;

    // Token: 0x04001E0C RID: 7692
    private float fFEPercent;

    // Token: 0x04001E0D RID: 7693
    private float fEquipValue;

    // Token: 0x04001E0E RID: 7694
    private float fBuffAndOtherPercent;

    // Token: 0x04001E0F RID: 7695
    private float ffBuffAndOtherValue;

    // Token: 0x04001E10 RID: 7696
    private float _fValue;

    // Token: 0x04001E11 RID: 7697
    private float _fBeforeValue;

    // Token: 0x04001E12 RID: 7698
    private bool _IsPhyDefence;

    // Token: 0x04001E13 RID: 7699
    private Role _role;

    // Token: 0x04001E14 RID: 7700
    private Dictionary<RoleWearEquipPos, CItemBase> table = new Dictionary<RoleWearEquipPos, CItemBase>();

    public DefenceFormula(Role role, bool bPhy)
	{
		this._role = role;
		this._IsPhyDefence = bPhy;
	}

	// Token: 0x170003E3 RID: 995
	// (get) Token: 0x060020E8 RID: 8424 RVA: 0x000E18A4 File Offset: 0x000DFAA4
	public float Value
	{
		get
		{
			return this.GetDefenceValue();
		}
	}

	// Token: 0x170003E4 RID: 996
	// (get) Token: 0x060020E9 RID: 8425 RVA: 0x000E18AC File Offset: 0x000DFAAC
	public bool IsPhyDefence
	{
		get
		{
			return this._IsPhyDefence;
		}
	}

	public void ClearData()
	{
		this.fBaseValue = 0f;
		this.fEquipPercent = 0f;
		this.fFEPercent = 0f;
		this.fEquipValue = 0f;
		this.fBuffAndOtherPercent = 0f;
		this.ffBuffAndOtherValue = 0f;
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
	//	this.ClearData();
	//	Player player = null;
	//	if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
	//	{
	//		player = (Player)this._role;
	//	}
	//	float num = 0f;
	//	float num2 = 0f;
	//	float num3 = 0f;
	//	float num4 = 0f;
	//	float num5 = 0f;
	//	ATTRIBUTE_TYPE attribute_TYPE = this._IsPhyDefence ? ATTRIBUTE_TYPE.ATT_PHY_DEF : ATTRIBUTE_TYPE.ATT_MAG_DEF;
	//	//float num6 = modAttribute.GetAttributeBaseNum(attribute_TYPE);
	//	//RoleWearEquipPos wearPos = player.ItemFolder.WearOperate.GetWearPos(pItem);
	//	//if (pItem == null || player == null || wearPos == RoleWearEquipPos.WEAR_UNKNOWN)
	//	//{
	//	//	return 0f;
	//	//}
	//	//this.table.Clear();
	//	////this.table = new Dictionary<RoleWearEquipPos, CItemBase>(player.ItemFolder.WearOperate._WearTable);
	//	//this.table[wearPos] = pItem;
	//	//if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
	//	//{
	//	//	num6 += player.ItemFolder.WearOperate.GetSupposeEquipBaseValue(attribute_TYPE, this.table);
	//	//}
	//	//if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
	//	//{
	//	//	if (this._IsPhyDefence)
	//	//	{
	//	//		num = player.ItemFolder.WearOperate.GetSupposeEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_PERCENT, this.table);
	//	//		num3 = player.ItemFolder.WearOperate.GetSupposeEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_VALUE, this.table);
	//	//	}
	//	//	else
	//	//	{
	//	//		num = player.ItemFolder.WearOperate.GetSupposeEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_PERCENT, this.table);
	//	//		num3 = player.ItemFolder.WearOperate.GetSupposeEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_VALUE, this.table);
	//	//	}
	//	//	num2 = ((!this._IsPhyDefence) ? this.GetFiveAddValue(ATTRIBUTE_TYPE.ATT_WATER_ELEMENT) : this.GetFiveAddValue(ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT));
	//	//}
	//	//ModBuffProperty modBuffProperty = (ModBuffProperty)this._role.GetModule(MODULE_TYPE.MT_BUFF);
	//	//if (modBuffProperty != null)
	//	//{
	//	//	num4 = ((!this._IsPhyDefence) ? modBuffProperty.GetDefPercent() : modBuffProperty.GetDefPercent());
	//	//	if (this._role._roleType == ROLE_TYPE.RT_PLAYER && player.SystemAmbit != null)
	//	//	{
	//	//		num4 += player.SystemAmbit.GetAddDefPer(this._IsPhyDefence);
	//	//	}
	//	//}
	//	//return (num6 * (1f + num + num2) + num3) * (1f + num4) + num5;
	//}

	//private void UpdateData()
	//{
	//	if (this._role == null)
	//	{
	//		return;
	//	}
	//	ModAttribute modAttribute = this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
	//	if (modAttribute == null)
	//	{
	//		return;
	//	}
	//	this.ClearData();
	//	Player player = null;
	//	if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
	//	{
	//		player = (Player)this._role;
	//	}
	//	ATTRIBUTE_TYPE attribute_TYPE = this._IsPhyDefence ? ATTRIBUTE_TYPE.ATT_PHY_DEF : ATTRIBUTE_TYPE.ATT_MAG_DEF;
	//	this.fBaseValue = modAttribute.GetAttributeBaseNum(attribute_TYPE);
	//	if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
	//	{
	//		this.fBaseValue += player.ItemFolder.WearOperate.GetDependEquipBaseValue(attribute_TYPE);
	//	}
	//	if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
	//	{
	//		if (this._IsPhyDefence)
	//		{
	//			this.fEquipPercent = player.ItemFolder.WearOperate.GetDependEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_PERCENT);
	//			this.fEquipValue = player.ItemFolder.WearOperate.GetDependEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_VALUE);
	//		}
	//		else
	//		{
	//			this.fEquipPercent = player.ItemFolder.WearOperate.GetDependEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_PERCENT);
	//			this.fEquipValue = player.ItemFolder.WearOperate.GetDependEquipAddValue(ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_VALUE);
	//		}
	//		this.fFEPercent = ((!this._IsPhyDefence) ? this.GetFiveAddValue(ATTRIBUTE_TYPE.ATT_WATER_ELEMENT) : this.GetFiveAddValue(ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT));
	//	}
	//	ModBuffProperty modBuffProperty = (ModBuffProperty)this._role.GetModule(MODULE_TYPE.MT_BUFF);
	//	if (modBuffProperty != null)
	//	{
	//		this.fBuffAndOtherPercent = ((!this._IsPhyDefence) ? modBuffProperty.GetDefPercent() : modBuffProperty.GetDefPercent());
	//		if (this._role._roleType == ROLE_TYPE.RT_PLAYER && player.SystemAmbit != null)
	//		{
	//			this.fBuffAndOtherPercent += player.SystemAmbit.GetAddDefPer(this._IsPhyDefence);
	//		}
	//	}
	//}

	public float GetDefenceValue()
	{
		if (this._role == null)
		{
			return 0f;
		}
		//this.UpdateData();
		this.CalculateData();
		if (this._fBeforeValue != this._fValue)
		{
			ModAttribute modAttribute = this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			if (modAttribute != null)
			{
				float num = 0.0015f;
				float num2 = 0.6f;
				float num3 = 230f;
				float num4 = 0.35f;
				float num5 = num * (this._fValue + num3) / (num2 + num * (this._fValue + num3)) - num4;
				float value = (float)Math.Round((double)num5, 4);
				ATTRIBUTE_TYPE attType = (!this._IsPhyDefence) ? ATTRIBUTE_TYPE.ATT_MAG_HURTLESS : ATTRIBUTE_TYPE.ATT_PHY_HURTLESS;
				modAttribute.SetAttributeNum(attType, value, true);
			}
		}
		this._fBeforeValue = this._fValue;
		return this._fValue;
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
				return 0.002f;
			}
			if (attributeValue > 50f && attributeValue <= 100f)
			{
				return 0.003f;
			}
			if (attributeValue > 100f && attributeValue <= 99999f)
			{
				return 0.004f;
			}
		}
		else if (fivetype == ATTRIBUTE_TYPE.ATT_WATER_ELEMENT)
		{
			if (attributeValue > 0f && attributeValue <= 50f)
			{
				return 0.001f;
			}
			if (attributeValue > 50f && attributeValue <= 100f)
			{
				return 0.002f;
			}
			if (attributeValue > 100f && attributeValue <= 99999f)
			{
				return 0.003f;
			}
		}
		return 0f;
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x000E1EFC File Offset: 0x000E00FC
	private void CalculateData()
	{
		this._fValue = (this.fBaseValue * (1f + this.fEquipPercent + this.fFEPercent) + this.fEquipValue) * (1f + this.fBuffAndOtherPercent) + this.ffBuffAndOtherValue;
	}

	// Token: 0x060020F0 RID: 8432 RVA: 0x000E1F3C File Offset: 0x000E013C
	public override string ToString()
	{
		string text = "DefenceFormula: ";
		text += ((!this._IsPhyDefence) ? ("法术防御 :" + this._fValue.ToString()) : "物理防御 :");
		text += " = ";
		string text2 = text;
		text = string.Concat(new object[]
		{
			text2,
			"人物基础值+装备基础值=>",
			this.fBaseValue,
			" ** ( 1+  装备附加%=>",
			this.fEquipPercent,
			" 五行附加%=>",
			this.fFEPercent,
			") +  装备附加值=>",
			this.fEquipValue,
			" )"
		});
		text += "* ( 1 + ";
		text2 = text;
		return string.Concat(new object[]
		{
			text2,
			" buffer%和境界%=>",
			this.fBuffAndOtherPercent,
			" ) +  buffer和境界附加=>",
			this.ffBuffAndOtherValue
		});
	}
}
