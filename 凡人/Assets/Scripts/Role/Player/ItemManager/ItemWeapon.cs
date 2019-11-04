using System;

/// <summary>
/// 武器
/// </summary>
public class ItemWeapon : CItemBase
{
    public bool IsReserveWeapon;

    public ItemWeapon()
	{
		this.HasMagicFigure = false;
	}

	// Token: 0x17000223 RID: 547
	// (get) Token: 0x06001447 RID: 5191 RVA: 0x000A4A14 File Offset: 0x000A2C14
	// (set) Token: 0x06001448 RID: 5192 RVA: 0x000A4A1C File Offset: 0x000A2C1C
	public ulong MagicFigureId { get; private set; }

	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06001449 RID: 5193 RVA: 0x000A4A28 File Offset: 0x000A2C28
	// (set) Token: 0x0600144A RID: 5194 RVA: 0x000A4A30 File Offset: 0x000A2C30
	public bool HasMagicFigure { get; private set; }

	// Token: 0x0600144B RID: 5195 RVA: 0x000A4A3C File Offset: 0x000A2C3C
	public void AttachMagicFigure(ulong magicFigureId, bool changeFigure)
	{
		CItemBase citemBase = null;
		//if (GameData.Instance.ItemMan.TryGetItemByID(magicFigureId, out citemBase))
		//{
		//	this.HasMagicFigure = true;
		//	this.MagicFigureId = magicFigureId;
		//	if (changeFigure)
		//	{
		//		((ItemMagicFigure)citemBase).AttachToWeapon(base.ID, false);
		//	}
		//}
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x000A4A88 File Offset: 0x000A2C88
	public void DetachMagicFigure(bool changeFigure)
	{
		if (this.HasMagicFigure)
		{
			if (changeFigure)
			{
				CItemBase citemBase = null;
				//if (GameData.Instance.ItemMan.TryGetItemByID(this.MagicFigureId, out citemBase))
				//{
				//	((ItemMagicFigure)citemBase).RemoveFromWeapon(false);
				//}
			}
			this.HasMagicFigure = false;
			this.MagicFigureId = 0UL;
		}
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x000A4AE0 File Offset: 0x000A2CE0
	//public ItemMagicFigure GetMagicFigure()
	//{
	//	if (this.HasMagicFigure)
	//	{
	//		CItemBase citemBase = null;
	//		if (GameData.Instance.ItemMan.TryGetItemByID(this.MagicFigureId, out citemBase))
	//		{
	//			return (ItemMagicFigure)citemBase;
	//		}
	//	}
	//	return null;
	//}

	// Token: 0x0600144E RID: 5198 RVA: 0x000A4B20 File Offset: 0x000A2D20
	//public override ItemSaveData GetItemSaveData()
	//{
	//	return new ItemSaveDataWeapon
	//	{
	//		itemOwner = base.Owner,
	//		itemType = base.OriginalData.ITEM_STATIC_ID,
	//		IsUsed = base.IS_USED,
	//		IsReserveWeapon = this.IsReserveWeapon,
	//		dynamicProperty = base.DynamicData,
	//		HasMagicFigure = this.HasMagicFigure,
	//		MagicFigureId = this.MagicFigureId
	//	};
	//}

	//// Token: 0x0600144F RID: 5199 RVA: 0x000A4B90 File Offset: 0x000A2D90
	//public override void SetItemFromSaveData(ItemSaveData isd)
	//{
	//	ItemSaveDataWeapon itemSaveDataWeapon = isd as ItemSaveDataWeapon;
	//	if (itemSaveDataWeapon == null)
	//	{
	//		return;
	//	}
	//	base.Owner = itemSaveDataWeapon.itemOwner;
	//	base.IS_USED = itemSaveDataWeapon.IsUsed;
	//	this.IsReserveWeapon = itemSaveDataWeapon.IsReserveWeapon;
	//	base.OriginalData.ITEM_STATIC_ID = itemSaveDataWeapon.itemType;
	//	base.DynamicData = itemSaveDataWeapon.dynamicProperty;
	//	this.HasMagicFigure = itemSaveDataWeapon.HasMagicFigure;
	//	this.MagicFigureId = itemSaveDataWeapon.MagicFigureId;
	//}
}
