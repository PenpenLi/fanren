using System;

// Token: 0x0200033F RID: 831
public class ItemMagicFigure : CItemBase
{
	// Token: 0x1700021F RID: 543
	// (get) Token: 0x06001437 RID: 5175 RVA: 0x000A4724 File Offset: 0x000A2924
	// (set) Token: 0x06001438 RID: 5176 RVA: 0x000A472C File Offset: 0x000A292C
	public ulong WeaponId { get; private set; }

	// Token: 0x17000220 RID: 544
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000A4738 File Offset: 0x000A2938
	// (set) Token: 0x0600143A RID: 5178 RVA: 0x000A4740 File Offset: 0x000A2940
	public float FigureEnergy { get; private set; }

	// Token: 0x17000221 RID: 545
	// (get) Token: 0x0600143B RID: 5179 RVA: 0x000A474C File Offset: 0x000A294C
	// (set) Token: 0x0600143C RID: 5180 RVA: 0x000A4760 File Offset: 0x000A2960
	//public float MaxFigureEnergy
	//{
	//	get
	//	{
	//		return base.DynamicData.ITEM_ITEMATT_MAP[ITEM_ATTRIBUTE_TYPE.IAT_MAXENERGY];
	//	}
	//	set
	//	{
	//		base.DynamicData.ITEM_ITEMATT_MAP[ITEM_ATTRIBUTE_TYPE.IAT_MAXENERGY] = value;
	//	}
	//}

	//// Token: 0x17000222 RID: 546
	//// (get) Token: 0x0600143D RID: 5181 RVA: 0x000A4774 File Offset: 0x000A2974
	//public int SkillId
	//{
	//	get
	//	{
	//		if (base.DynamicData.ITEM_ITEMATT_MAP.ContainsKey(ITEM_ATTRIBUTE_TYPE.IAT_HAVESKILLID))
	//		{
	//			return (int)base.DynamicData.ITEM_ITEMATT_MAP[ITEM_ATTRIBUTE_TYPE.IAT_HAVESKILLID];
	//		}
	//		return -1;
	//	}
	//}

	//// Token: 0x0600143E RID: 5182 RVA: 0x000A47AC File Offset: 0x000A29AC
	//public void AttachToWeapon(ulong weaponId, bool changeWeapon)
	//{
	//	CItemBase citemBase = null;
	//	if (GameData.Instance.ItemMan.TryGetItemByID(weaponId, out citemBase))
	//	{
	//		this.WeaponId = weaponId;
	//		base.IS_USED = true;
	//		if (changeWeapon)
	//		{
	//			((ItemWeapon)citemBase).AttachMagicFigure(base.ID, false);
	//		}
	//	}
	//}

	//// Token: 0x0600143F RID: 5183 RVA: 0x000A47F8 File Offset: 0x000A29F8
	//public void RemoveFromWeapon(bool changeWeapon)
	//{
	//	if (base.IS_USED)
	//	{
	//		if (changeWeapon)
	//		{
	//			CItemBase citemBase = null;
	//			if (GameData.Instance.ItemMan.TryGetItemByID(this.WeaponId, out citemBase))
	//			{
	//				((ItemWeapon)citemBase).DetachMagicFigure(false);
	//			}
	//		}
	//		base.IS_USED = false;
	//		this.ClearFigureEnergy();
	//		this.WeaponId = 0UL;
	//	}
	//}

	//// Token: 0x06001440 RID: 5184 RVA: 0x000A4858 File Offset: 0x000A2A58
	//public ItemWeapon GetMagicFigure()
	//{
	//	if (base.IS_USED)
	//	{
	//		CItemBase citemBase = null;
	//		if (GameData.Instance.ItemMan.TryGetItemByID(this.WeaponId, out citemBase))
	//		{
	//			return (ItemWeapon)citemBase;
	//		}
	//	}
	//	return null;
	//}

	//// Token: 0x06001441 RID: 5185 RVA: 0x000A4898 File Offset: 0x000A2A98
	//public void AddFigureEnergy(float figureEnergy)
	//{
	//	this.FigureEnergy += figureEnergy;
	//	if (this.FigureEnergy > this.MaxFigureEnergy)
	//	{
	//		this.FigureEnergy = this.MaxFigureEnergy;
	//	}
	//	else if (this.FigureEnergy < 0f)
	//	{
	//		this.FigureEnergy = 0f;
	//	}
	//}

	//// Token: 0x06001442 RID: 5186 RVA: 0x000A48F0 File Offset: 0x000A2AF0
	//public bool IsFull()
	//{
	//	return this.MaxFigureEnergy > 0f && this.FigureEnergy == this.MaxFigureEnergy;
	//}

	//// Token: 0x06001443 RID: 5187 RVA: 0x000A4924 File Offset: 0x000A2B24
	//public void ClearFigureEnergy()
	//{
	//	this.FigureEnergy = 0f;
	//}

	//// Token: 0x06001444 RID: 5188 RVA: 0x000A4934 File Offset: 0x000A2B34
	//public override ItemSaveData GetItemSaveData()
	//{
	//	return new ItemSaveDataFigure
	//	{
	//		itemOwner = base.Owner,
	//		itemType = base.OriginalData.ITEM_STATIC_ID,
	//		IsUsed = base.IS_USED,
	//		dynamicProperty = base.DynamicData,
	//		WeaponId = this.WeaponId,
	//		FigureEnergy = this.FigureEnergy,
	//		IsReserveWeapon = false
	//	};
	//}

	//// Token: 0x06001445 RID: 5189 RVA: 0x000A499C File Offset: 0x000A2B9C
	//public override void SetItemFromSaveData(ItemSaveData isd)
	//{
	//	ItemSaveDataFigure itemSaveDataFigure = isd as ItemSaveDataFigure;
	//	if (itemSaveDataFigure == null)
	//	{
	//		return;
	//	}
	//	base.Owner = itemSaveDataFigure.itemOwner;
	//	base.IS_USED = itemSaveDataFigure.IsUsed;
	//	base.OriginalData.ITEM_STATIC_ID = itemSaveDataFigure.itemType;
	//	base.DynamicData = itemSaveDataFigure.dynamicProperty;
	//	this.WeaponId = itemSaveDataFigure.WeaponId;
	//	this.FigureEnergy = itemSaveDataFigure.FigureEnergy;
	//}
}
