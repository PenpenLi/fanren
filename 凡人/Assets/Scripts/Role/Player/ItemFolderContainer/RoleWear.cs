using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色穿戴
/// </summary>
public class RoleWear
{
    private int host_id = 1;

    public Dictionary<RoleWearEquipPos, CItemBase> _WearTable = new Dictionary<RoleWearEquipPos, CItemBase>();

    public RoleWear()
	{
	}

	public RoleWear(int playerid)
	{
		this.Host_id = playerid;
	}

	public CItemBase this[RoleWearEquipPos pos]
	{
		get
		{
			if (pos == RoleWearEquipPos.WEAR_UNKNOWN)
			{
				return null;
			}
			if (!this._WearTable.ContainsKey(pos))
			{
				return null;
			}
			return this._WearTable[pos];
		}
	}

	// Token: 0x17000242 RID: 578
	// (get) Token: 0x0600149F RID: 5279 RVA: 0x000A5780 File Offset: 0x000A3980
	// (set) Token: 0x060014A0 RID: 5280 RVA: 0x000A5788 File Offset: 0x000A3988
	public int Host_id
	{
		get
		{
			return this.host_id;
		}
		private set
		{
			this.host_id = value;
		}
	}

	public void TakeOff(RoleWearEquipPos pos)
	{
		//this.TakeOff(pos, true);
	}

	// Token: 0x060014A2 RID: 5282 RVA: 0x000A57A0 File Offset: 0x000A39A0
	//public void TakeOff(RoleWearEquipPos pos, bool bIsNoAddAtt)
	//{
	//	if (pos >= RoleWearEquipPos.WEAR_UNKNOWN)
	//	{
	//		return;
	//	}
	//	if (this._WearTable.ContainsKey(pos))
	//	{
	//		this._WearTable[pos].IS_USED = false;
	//		if (bIsNoAddAtt)
	//		{
	//			this.UpdateDependAttribute(this._WearTable[pos], false);
	//		}
	//		this._WearTable.Remove(pos);
	//		Singleton<EZGUIManager>.GetInstance().OnCommandGUIMessage(GUI_TYPE.UICMD_ALL_ATTRIBUTEUPDATE, ATTRIBUTE_TYPE.ATT_PHY_ATK, 0);
	//		Player.Instance.equipReplace.TakeOff(pos);
	//		if (PuppetRole.Instance.equipReplace != null)
	//		{
	//			PuppetRole.Instance.equipReplace.TakeOff(pos);
	//		}
	//	}
	//}

	//// Token: 0x060014A3 RID: 5283 RVA: 0x000A5840 File Offset: 0x000A3A40
	//public void TakeOff(CItemBase item)
	//{
	//	this.TakeOff(item, true);
	//}

	//// Token: 0x060014A4 RID: 5284 RVA: 0x000A584C File Offset: 0x000A3A4C
	//public void TakeOff(CItemBase item, bool bIsNoAddAtt)
	//{
	//	RoleWearEquipPos pos = RoleWearEquipPos.WEAR_UNKNOWN;
	//	foreach (KeyValuePair<RoleWearEquipPos, CItemBase> keyValuePair in this._WearTable)
	//	{
	//		if (keyValuePair.Key != RoleWearEquipPos.WEAR_SPAREWEAPON && keyValuePair.Value == item)
	//		{
	//			pos = keyValuePair.Key;
	//			break;
	//		}
	//	}
	//	this.TakeOff(pos, bIsNoAddAtt);
	//}

	//// Token: 0x060014A5 RID: 5285 RVA: 0x000A58E0 File Offset: 0x000A3AE0
	//public void TakeOffAll()
	//{
	//	foreach (CItemBase citemBase in this._WearTable.Values)
	//	{
	//		citemBase.IS_USED = false;
	//	}
	//	this._WearTable.Clear();
	//}

	//// Token: 0x060014A6 RID: 5286 RVA: 0x000A5958 File Offset: 0x000A3B58
	//public void ClearSpareWeapon()
	//{
	//	if (this._WearTable.ContainsKey(RoleWearEquipPos.WEAR_SPAREWEAPON))
	//	{
	//		this._WearTable[RoleWearEquipPos.WEAR_SPAREWEAPON].IS_USED = false;
	//		ItemWeapon itemWeapon = (ItemWeapon)this._WearTable[RoleWearEquipPos.WEAR_SPAREWEAPON];
	//		if (itemWeapon != null)
	//		{
	//			itemWeapon.IsReserveWeapon = false;
	//		}
	//		this._WearTable.Remove(RoleWearEquipPos.WEAR_SPAREWEAPON);
	//	}
	//}

	//// Token: 0x060014A7 RID: 5287 RVA: 0x000A59B8 File Offset: 0x000A3BB8
	//public bool SetSpareWeapon(CItemBase item)
	//{
	//	RoleWearEquipPos wearPos = this.GetWearPos(item);
	//	if (wearPos == RoleWearEquipPos.WEAR_WEAPON)
	//	{
	//		item.IS_USED = false;
	//		((ItemWeapon)item).IsReserveWeapon = false;
	//		ItemWeapon itemWeapon = (ItemWeapon)item;
	//		if (itemWeapon != null)
	//		{
	//			itemWeapon.IsReserveWeapon = true;
	//		}
	//		if (this._WearTable.ContainsKey(RoleWearEquipPos.WEAR_SPAREWEAPON))
	//		{
	//			this._WearTable[RoleWearEquipPos.WEAR_SPAREWEAPON] = item;
	//		}
	//		else
	//		{
	//			this._WearTable.Add(RoleWearEquipPos.WEAR_SPAREWEAPON, item);
	//		}
	//		return true;
	//	}
	//	return false;
	//}

	//// Token: 0x060014A8 RID: 5288 RVA: 0x000A5A34 File Offset: 0x000A3C34
	//public bool SwitchWeapon()
	//{
	//	if (this._WearTable.ContainsKey(RoleWearEquipPos.WEAR_SPAREWEAPON))
	//	{
	//		if (this._WearTable.ContainsKey(RoleWearEquipPos.WEAR_WEAPON))
	//		{
	//			CItemBase spareWeapon = null;
	//			GameData.Instance.ItemMan.TryGetItemByID(this._WearTable[RoleWearEquipPos.WEAR_WEAPON].ID, out spareWeapon);
	//			bool result = this.TakeOn(this._WearTable[RoleWearEquipPos.WEAR_SPAREWEAPON]);
	//			this.SetSpareWeapon(spareWeapon);
	//			return result;
	//		}
	//		bool result2 = this.TakeOn(this._WearTable[RoleWearEquipPos.WEAR_SPAREWEAPON]);
	//		this.ClearSpareWeapon();
	//		return result2;
	//	}
	//	else
	//	{
	//		if (this._WearTable.ContainsKey(RoleWearEquipPos.WEAR_WEAPON))
	//		{
	//			CItemBase spareWeapon2 = null;
	//			GameData.Instance.ItemMan.TryGetItemByID(this._WearTable[RoleWearEquipPos.WEAR_WEAPON].ID, out spareWeapon2);
	//			this.TakeOff(this._WearTable[RoleWearEquipPos.WEAR_WEAPON]);
	//			this.SetSpareWeapon(spareWeapon2);
	//			return true;
	//		}
	//		return false;
	//	}
	//}

	//// Token: 0x060014A9 RID: 5289 RVA: 0x000A5B18 File Offset: 0x000A3D18
	//public bool TakeOn(CItemBase item, bool bIsNoAddAtt)
	//{
	//	return this.TakeOn(this.GetWearPos(item), item, bIsNoAddAtt);
	//}

	//// Token: 0x060014AA RID: 5290 RVA: 0x000A5B2C File Offset: 0x000A3D2C
	//public bool TakeOn(CItemBase item)
	//{
	//	return this.TakeOn(this.GetWearPos(item), item);
	//}

	//// Token: 0x060014AB RID: 5291 RVA: 0x000A5B3C File Offset: 0x000A3D3C
	//public bool TakeOn(RoleWearEquipPos pos, CItemBase item)
	//{
	//	return this.TakeOn(pos, item, true);
	//}

	//// Token: 0x060014AC RID: 5292 RVA: 0x000A5B48 File Offset: 0x000A3D48
	//public bool TakeOn(RoleWearEquipPos pos, CItemBase item, bool bIsNoAddAtt)
	//{
	//	if (item == null || this.GetWearPos(item) >= RoleWearEquipPos.WEAR_UNKNOWN || pos >= RoleWearEquipPos.WEAR_UNKNOWN)
	//	{
	//		return false;
	//	}
	//	this.TakeOff(pos, bIsNoAddAtt);
	//	item.IS_USED = true;
	//	this._WearTable.Add(pos, item);
	//	if (bIsNoAddAtt)
	//	{
	//		this.UpdateDependAttribute(item, true);
	//	}
	//	Singleton<EZGUIManager>.GetInstance().OnCommandGUIMessage(GUI_TYPE.UICMD_ALL_ATTRIBUTEUPDATE, ATTRIBUTE_TYPE.ATT_PHY_ATK, 0);
	//	Player.Instance.equipReplace.TakeOn(pos, item);
	//	if (PuppetRole.Instance.equipReplace != null)
	//	{
	//		PuppetRole.Instance.equipReplace.TakeOn(pos, item);
	//	}
	//	PuppetRole.Instance.AdjustFlush = true;
	//	return true;
	//}

	//// Token: 0x060014AD RID: 5293 RVA: 0x000A5BEC File Offset: 0x000A3DEC
	//public void UpdateUsedEquip(bool bTakeOn)
	//{
	//	Player player = (Player)SceneManager.RoleMan.GetRole(this.Host_id);
	//	if (player == null)
	//	{
	//		return;
	//	}
	//	List<CItemBase> list = new List<CItemBase>();
	//	if (player.ItemFolder.TryGetUsedEquipData(out list))
	//	{
	//		foreach (CItemBase citemBase in list)
	//		{
	//			if (!citemBase.IS_USED)
	//			{
	//				if (citemBase.CHILD_TYPE_ID >= 1 && citemBase.CHILD_TYPE_ID <= 3)
	//				{
	//					ItemWeapon itemWeapon = (ItemWeapon)citemBase;
	//					Debug.Log(DU.Info(new object[]
	//					{
	//						itemWeapon.Name,
	//						itemWeapon.IsReserveWeapon
	//					}));
	//					if (itemWeapon != null && itemWeapon.IsReserveWeapon)
	//					{
	//						this.SetSpareWeapon(itemWeapon);
	//					}
	//				}
	//			}
	//			else
	//			{
	//				Debug.Log(DU.Info(new object[]
	//				{
	//					citemBase.Name,
	//					bTakeOn
	//				}));
	//				if (bTakeOn)
	//				{
	//					this.TakeOn(citemBase, false);
	//				}
	//				else
	//				{
	//					this.TakeOff(citemBase, false);
	//				}
	//			}
	//		}
	//	}
	//}

	//// Token: 0x060014AE RID: 5294 RVA: 0x000A5D30 File Offset: 0x000A3F30
	//public void ResetUsedEquip()
	//{
	//	Player player = (Player)SceneManager.RoleMan.GetRole(this.Host_id);
	//	if (player == null)
	//	{
	//		return;
	//	}
	//	List<CItemBase> list = new List<CItemBase>();
	//	if (player.ItemFolder.TryGetUsedEquipData(out list))
	//	{
	//		foreach (CItemBase citemBase in list)
	//		{
	//			if (!citemBase.IS_USED)
	//			{
	//				if (citemBase.CHILD_TYPE_ID >= 1 && citemBase.CHILD_TYPE_ID <= 3)
	//				{
	//					ItemWeapon itemWeapon = (ItemWeapon)citemBase;
	//					if (itemWeapon != null && itemWeapon.IsReserveWeapon)
	//					{
	//						this.SetSpareWeapon(itemWeapon);
	//					}
	//				}
	//			}
	//			else
	//			{
	//				RoleWearEquipPos wearPos = this.GetWearPos(citemBase);
	//				Debug.Log("take on_" + wearPos);
	//				if (wearPos != RoleWearEquipPos.WEAR_UNKNOWN)
	//				{
	//					this._WearTable[wearPos] = citemBase;
	//				}
	//			}
	//		}
	//	}
	//}

	//// Token: 0x060014AF RID: 5295 RVA: 0x000A5E40 File Offset: 0x000A4040
	//public int GetWeaponHeldByHand()
	//{
	//	if (!this._WearTable.ContainsKey(RoleWearEquipPos.WEAR_WEAPON))
	//	{
	//		return -1;
	//	}
	//	CItemBase citemBase = this._WearTable[RoleWearEquipPos.WEAR_WEAPON];
	//	if (citemBase.DynamicData.ITEM_ITEMATT_MAP.ContainsKey(ITEM_ATTRIBUTE_TYPE.IAT_HOLD_WEAPON))
	//	{
	//		return (int)citemBase.DynamicData.ITEM_ITEMATT_MAP[ITEM_ATTRIBUTE_TYPE.IAT_HOLD_WEAPON];
	//	}
	//	return 0;
	//}

	//// Token: 0x060014B0 RID: 5296 RVA: 0x000A5E9C File Offset: 0x000A409C
	//public List<CItemBase> GetWearTable()
	//{
	//	if (this._WearTable.Count <= 0)
	//	{
	//		return null;
	//	}
	//	List<CItemBase> list = new List<CItemBase>();
	//	foreach (KeyValuePair<RoleWearEquipPos, CItemBase> keyValuePair in this._WearTable)
	//	{
	//		if (keyValuePair.Key != RoleWearEquipPos.WEAR_SPAREWEAPON && keyValuePair.Key != RoleWearEquipPos.WEAR_UNKNOWN)
	//		{
	//			list.Add(keyValuePair.Value);
	//		}
	//	}
	//	return list;
	//}

	//// Token: 0x060014B1 RID: 5297 RVA: 0x000A5F40 File Offset: 0x000A4140
	//public float GetDependEquipBaseValue(ATTRIBUTE_TYPE type)
	//{
	//	float num = 0f;
	//	foreach (KeyValuePair<RoleWearEquipPos, CItemBase> keyValuePair in this._WearTable)
	//	{
	//		if (keyValuePair.Key != RoleWearEquipPos.WEAR_SPAREWEAPON && keyValuePair.Key != RoleWearEquipPos.WEAR_UNKNOWN)
	//		{
	//			foreach (KeyValuePair<ATTRIBUTE_TYPE, float> keyValuePair2 in keyValuePair.Value.DynamicData.ITEM_ATTRIBUTES_MAP)
	//			{
	//				if (keyValuePair2.Key == type)
	//				{
	//					num += keyValuePair2.Value;
	//				}
	//			}
	//		}
	//	}
	//	return num;
	//}

	//// Token: 0x060014B2 RID: 5298 RVA: 0x000A6038 File Offset: 0x000A4238
	//public float GetDependEquipAddValue(ITEM_ADD_ATTRIBUTE type)
	//{
	//	float num = 0f;
	//	foreach (KeyValuePair<RoleWearEquipPos, CItemBase> keyValuePair in this._WearTable)
	//	{
	//		if (keyValuePair.Key != RoleWearEquipPos.WEAR_SPAREWEAPON && keyValuePair.Key != RoleWearEquipPos.WEAR_UNKNOWN)
	//		{
	//			foreach (KeyValuePair<ITEM_ADD_ATTRIBUTE, float> keyValuePair2 in keyValuePair.Value.DynamicData.ITEM_ADDATTRIBUTES_MAP)
	//			{
	//				if (keyValuePair2.Key == type)
	//				{
	//					num += keyValuePair2.Value;
	//				}
	//			}
	//		}
	//	}
	//	return num;
	//}

	//// Token: 0x060014B3 RID: 5299 RVA: 0x000A6130 File Offset: 0x000A4330
	//public EquipCfgType GetWearWeaponType()
	//{
	//	if (!this._WearTable.ContainsKey(RoleWearEquipPos.WEAR_WEAPON) || this._WearTable[RoleWearEquipPos.WEAR_WEAPON] == null)
	//	{
	//		return EquipCfgType.EQCHILD_CT_UNKNOWN;
	//	}
	//	int child_TYPE_ID = this._WearTable[RoleWearEquipPos.WEAR_WEAPON].CHILD_TYPE_ID;
	//	EquipCfgType equipCfgTpyeByID = GameData.Instance.ItemStaticMan.GetEquipCfgTpyeByID(child_TYPE_ID);
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_WEAPON)
	//	{
	//		return EquipCfgType.EQCHILD_CT_WEAPON;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_MAGICWEAPON)
	//	{
	//		return EquipCfgType.EQCHILD_CT_MAGICWEAPON;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_DWEAPON)
	//	{
	//		return EquipCfgType.EQCHILD_CT_DWEAPON;
	//	}
	//	return EquipCfgType.EQCHILD_CT_UNKNOWN;
	//}

	//// Token: 0x060014B4 RID: 5300 RVA: 0x000A61A0 File Offset: 0x000A43A0
	//public float GetWearWeaponFactor(int weapon)
	//{
	//	float result = 1f;
	//	if (!this._WearTable.ContainsKey(RoleWearEquipPos.WEAR_WEAPON) || this._WearTable[RoleWearEquipPos.WEAR_WEAPON] == null || this.GetWearWeaponType() == EquipCfgType.EQCHILD_CT_UNKNOWN)
	//	{
	//		return result;
	//	}
	//	if (weapon == 1)
	//	{
	//		return 1.15f;
	//	}
	//	if (weapon == 2)
	//	{
	//		return 0.8f;
	//	}
	//	if (weapon == 3)
	//	{
	//		return 1f;
	//	}
	//	return result;
	//}

	//// Token: 0x060014B5 RID: 5301 RVA: 0x000A620C File Offset: 0x000A440C
	//public RoleWearEquipPos GetWearPos(CItemBase item)
	//{
	//	if (item == null || GameData.Instance.ItemStaticMan.GetItemCfgTpyeByID(item.TYPE_ID) != ItemCfgType.ITCT_EQUIP)
	//	{
	//		return RoleWearEquipPos.WEAR_UNKNOWN;
	//	}
	//	EquipCfgType equipCfgTpyeByID = GameData.Instance.ItemStaticMan.GetEquipCfgTpyeByID(item.CHILD_TYPE_ID);
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_UNKNOWN)
	//	{
	//		return RoleWearEquipPos.WEAR_UNKNOWN;
	//	}
	//	if (equipCfgTpyeByID >= EquipCfgType.EQCHILD_CT_WEAPON && equipCfgTpyeByID <= EquipCfgType.EQCHILD_CT_DWEAPON)
	//	{
	//		return RoleWearEquipPos.WEAR_WEAPON;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_SHOULDER)
	//	{
	//		return RoleWearEquipPos.WEAR_SHOULDER;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_CLOTHES)
	//	{
	//		return RoleWearEquipPos.WEAR_CLOTHES;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_CUFF)
	//	{
	//		return RoleWearEquipPos.WEAR_CUFF;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_FOOT)
	//	{
	//		return RoleWearEquipPos.WEAR_FOOT;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_SHELTER)
	//	{
	//		return RoleWearEquipPos.WEAR_SHELTER;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_RING)
	//	{
	//		return RoleWearEquipPos.WEAR_RING;
	//	}
	//	if (equipCfgTpyeByID == EquipCfgType.EQCHILD_CT_FASHION)
	//	{
	//		return RoleWearEquipPos.WEAR_FASHION;
	//	}
	//	return RoleWearEquipPos.WEAR_UNKNOWN;
	//}

	//// Token: 0x060014B6 RID: 5302 RVA: 0x000A62B4 File Offset: 0x000A44B4
	//public override string ToString()
	//{
	//	string str = "RoleWear \n";
	//	for (RoleWearEquipPos roleWearEquipPos = RoleWearEquipPos.WEAR_CLOTHES; roleWearEquipPos <= RoleWearEquipPos.WEAR_FASHION; roleWearEquipPos++)
	//	{
	//		str = str + " ==> " + roleWearEquipPos.ToString() + ((!this._WearTable.ContainsKey(roleWearEquipPos)) ? "(null)" : string.Concat(new object[]
	//		{
	//			this._WearTable[roleWearEquipPos].Name,
	//			"(",
	//			this._WearTable[roleWearEquipPos].ID,
	//			")"
	//		}));
	//		str += "\n";
	//	}
	//	return str + "\n";
	//}

	//// Token: 0x060014B7 RID: 5303 RVA: 0x000A636C File Offset: 0x000A456C
	//private void UpdateDependAttribute(CItemBase item, bool bIsTakeOn)
	//{
	//	Player player = (Player)SceneManager.RoleMan.GetRole(this.Host_id);
	//	if (player == null)
	//	{
	//		return;
	//	}
	//	ModAttribute cModAttribute = player.m_cModAttribute;
	//	if (cModAttribute == null)
	//	{
	//		return;
	//	}
	//	foreach (KeyValuePair<ATTRIBUTE_TYPE, float> keyValuePair in item.DynamicData.ITEM_ATTRIBUTES_MAP)
	//	{
	//		float num = keyValuePair.Value;
	//		if (!bIsTakeOn)
	//		{
	//			num = -num;
	//		}
	//		if (!bIsTakeOn && keyValuePair.Key == ATTRIBUTE_TYPE.ATT_HP)
	//		{
	//			Debug.LogError("Equip config error , it is" + keyValuePair.Key);
	//		}
	//		else
	//		{
	//			cModAttribute.UpdateAttributeNum(keyValuePair.Key, num, false);
	//		}
	//	}
	//	foreach (KeyValuePair<ITEM_ADD_ATTRIBUTE, float> keyValuePair2 in item.DynamicData.ITEM_ADDATTRIBUTES_MAP)
	//	{
	//		float num2 = keyValuePair2.Value;
	//		if (!bIsTakeOn)
	//		{
	//			num2 = -num2;
	//		}
	//		if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_MAG_REPLY)
	//		{
	//			cModAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAGICREGAIN, num2);
	//		}
	//		else if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_MAXHP_PERCENT)
	//		{
	//			cModAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAXHP, num2);
	//		}
	//		else if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_MAXMP_PERCENT)
	//		{
	//			cModAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAXMP, num2);
	//		}
	//		else if (keyValuePair2.Key != ITEM_ADD_ATTRIBUTE.IAAT_PHYATK_PERCENT)
	//		{
	//			if (keyValuePair2.Key != ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_PERCENT)
	//			{
	//				if (keyValuePair2.Key != ITEM_ADD_ATTRIBUTE.IAAT_MAGATK_PERCENT)
	//				{
	//					if (keyValuePair2.Key != ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_PERCENT)
	//					{
	//						if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_VALUE)
	//						{
	//							cModAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_PHY_DEF, num2, true);
	//						}
	//						else if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_VALUE)
	//						{
	//							cModAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_MAG_DEF, num2, true);
	//						}
	//						else if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_CRITICAL_PERCENT)
	//						{
	//							cModAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_CRITICAL, num2);
	//						}
	//						else if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_PHYHURTLESS_PERCENT)
	//						{
	//							cModAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_PHY_HURTLESS, num2);
	//						}
	//						else if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_MAGHURTLESS_PERCENT)
	//						{
	//							cModAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAG_HURTLESS, num2);
	//						}
	//						else if (keyValuePair2.Key != ITEM_ADD_ATTRIBUTE.IAAT_ABSORB_PERCENT)
	//						{
	//							if (keyValuePair2.Key == ITEM_ADD_ATTRIBUTE.IAAT_FEATK_PERCENT)
	//							{
	//								cModAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_FIVE_ELEMENT_ATK, num2);
	//							}
	//						}
	//					}
	//				}
	//			}
	//		}
	//	}
	//}

	//// Token: 0x060014B8 RID: 5304 RVA: 0x000A6610 File Offset: 0x000A4810
	//public float GetSupposeEquipBaseValue(ATTRIBUTE_TYPE type, Dictionary<RoleWearEquipPos, CItemBase> table)
	//{
	//	float num = 0f;
	//	foreach (KeyValuePair<RoleWearEquipPos, CItemBase> keyValuePair in table)
	//	{
	//		if (keyValuePair.Key != RoleWearEquipPos.WEAR_SPAREWEAPON && keyValuePair.Key != RoleWearEquipPos.WEAR_UNKNOWN)
	//		{
	//			foreach (KeyValuePair<ATTRIBUTE_TYPE, float> keyValuePair2 in keyValuePair.Value.DynamicData.ITEM_ATTRIBUTES_MAP)
	//			{
	//				if (keyValuePair2.Key == type)
	//				{
	//					num += keyValuePair2.Value;
	//				}
	//			}
	//		}
	//	}
	//	return num;
	//}

	//// Token: 0x060014B9 RID: 5305 RVA: 0x000A6704 File Offset: 0x000A4904
	//public float GetSupposeEquipAddValue(ITEM_ADD_ATTRIBUTE type, Dictionary<RoleWearEquipPos, CItemBase> table)
	//{
	//	float num = 0f;
	//	foreach (KeyValuePair<RoleWearEquipPos, CItemBase> keyValuePair in table)
	//	{
	//		if (keyValuePair.Key != RoleWearEquipPos.WEAR_SPAREWEAPON && keyValuePair.Key != RoleWearEquipPos.WEAR_UNKNOWN)
	//		{
	//			foreach (KeyValuePair<ITEM_ADD_ATTRIBUTE, float> keyValuePair2 in keyValuePair.Value.DynamicData.ITEM_ADDATTRIBUTES_MAP)
	//			{
	//				if (keyValuePair2.Key == type)
	//				{
	//					num += keyValuePair2.Value;
	//				}
	//			}
	//		}
	//	}
	//	return num;
	//}
}
