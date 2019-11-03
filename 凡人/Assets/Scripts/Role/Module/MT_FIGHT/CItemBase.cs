using System;

/// <summary>
/// 物品基类
/// </summary>
public class CItemBase
{
    //private ItemPropertyConfig _pOriginalData = new ItemPropertyConfig();

    //private ItemPropertyConfig _pDynamicData = new ItemPropertyConfig();

    private ulong _RealID;

    private bool _IsUsed;

    private bool _IsNew = true;

    //private ItemOwner _pItemOwner;

    private bool _IsTrash;

    public bool IsTrash
	{
		get
		{
			return this._IsTrash;
		}
		set
		{
			this._IsTrash = value;
		}
	}

	//public ItemOwner Owner
	//{
	//	get
	//	{
	//		return this._pItemOwner;
	//	}
	//	set
	//	{
	//		this._pItemOwner = value;
	//	}
	//}

	//public ItemPropertyConfig OriginalData
	//{
	//	get
	//	{
	//		return this._pOriginalData;
	//	}
	//	set
	//	{
	//		this._pOriginalData = value;
	//	}
	//}

	//public ItemPropertyConfig DynamicData
	//{
	//	get
	//	{
	//		return this._pDynamicData;
	//	}
	//	set
	//	{
	//		this._pDynamicData = value;
	//	}
	//}

	//public string Name
	//{
	//	get
	//	{
	//		return this._pDynamicData.ITEM_NAME;
	//	}
	//	set
	//	{
	//		this._pDynamicData.ITEM_NAME = value;
	//	}
	//}

	//public int TYPE_ID
	//{
	//	get
	//	{
	//		return this._pDynamicData.ITEM_TYPE_ID;
	//	}
	//	set
	//	{
	//		this._pDynamicData.ITEM_TYPE_ID = value;
	//	}
	//}

	//public int CHILD_TYPE_ID
	//{
	//	get
	//	{
	//		return this._pDynamicData.ITEM_CHILDTYPE_ID;
	//	}
	//	set
	//	{
	//		this._pDynamicData.ITEM_CHILDTYPE_ID = value;
	//	}
	//}

	//public ulong ITEM_STATIC_ID
	//{
	//	get
	//	{
	//		return this._pDynamicData.ITEM_STATIC_ID;
	//	}
	//}

	//// Token: 0x1700022D RID: 557
	//// (get) Token: 0x06001461 RID: 5217 RVA: 0x000A4CF4 File Offset: 0x000A2EF4
	//public ulong ID
	//{
	//	get
	//	{
	//		return this._RealID;
	//	}
	//}

	//// Token: 0x1700022E RID: 558
	//// (get) Token: 0x06001462 RID: 5218 RVA: 0x000A4CFC File Offset: 0x000A2EFC
	//// (set) Token: 0x06001463 RID: 5219 RVA: 0x000A4D04 File Offset: 0x000A2F04
	//public bool IS_USED
	//{
	//	get
	//	{
	//		return this._IsUsed;
	//	}
	//	set
	//	{
	//		this._IsUsed = value;
	//	}
	//}

	//// Token: 0x1700022F RID: 559
	//// (get) Token: 0x06001464 RID: 5220 RVA: 0x000A4D10 File Offset: 0x000A2F10
	//// (set) Token: 0x06001465 RID: 5221 RVA: 0x000A4D18 File Offset: 0x000A2F18
	//public bool IS_NEW
	//{
	//	get
	//	{
	//		return this._IsNew;
	//	}
	//	set
	//	{
	//		this._IsNew = value;
	//	}
	//}

	//// Token: 0x17000230 RID: 560
	//// (get) Token: 0x06001466 RID: 5222 RVA: 0x000A4D24 File Offset: 0x000A2F24
	//// (set) Token: 0x06001467 RID: 5223 RVA: 0x000A4D34 File Offset: 0x000A2F34
	//public string Desc
	//{
	//	get
	//	{
	//		return this._pDynamicData.ITEM_DESC;
	//	}
	//	set
	//	{
	//		this._pDynamicData.ITEM_DESC = value;
	//	}
	//}

	//// Token: 0x17000231 RID: 561
	//// (get) Token: 0x06001468 RID: 5224 RVA: 0x000A4D44 File Offset: 0x000A2F44
	//// (set) Token: 0x06001469 RID: 5225 RVA: 0x000A4D54 File Offset: 0x000A2F54
	//public string BigIco
	//{
	//	get
	//	{
	//		return this._pDynamicData.ITEM_ICOPATH_BIG;
	//	}
	//	set
	//	{
	//		this._pDynamicData.ITEM_ICOPATH_BIG = value;
	//	}
	//}

	//// Token: 0x17000232 RID: 562
	//// (get) Token: 0x0600146A RID: 5226 RVA: 0x000A4D64 File Offset: 0x000A2F64
	//// (set) Token: 0x0600146B RID: 5227 RVA: 0x000A4D74 File Offset: 0x000A2F74
	//public string SmallIco
	//{
	//	get
	//	{
	//		return this._pDynamicData.ITEM_ICOPATH_SMALL;
	//	}
	//	set
	//	{
	//		this._pDynamicData.ITEM_ICOPATH_SMALL = value;
	//	}
	//}

	//// Token: 0x17000233 RID: 563
	//// (get) Token: 0x0600146C RID: 5228 RVA: 0x000A4D84 File Offset: 0x000A2F84
	//// (set) Token: 0x0600146D RID: 5229 RVA: 0x000A4D94 File Offset: 0x000A2F94
	//public string Intro
	//{
	//	get
	//	{
	//		return this._pDynamicData.ITEM_INTRO;
	//	}
	//	set
	//	{
	//		this._pDynamicData.ITEM_INTRO = value;
	//	}
	//}

	//// Token: 0x17000234 RID: 564
	//// (set) Token: 0x0600146E RID: 5230 RVA: 0x000A4DA4 File Offset: 0x000A2FA4
	//public int SmartDynamicID
	//{
	//	set
	//	{
	//		ulong realID = 0UL;
	//		if (ulong.TryParse(this._pDynamicData.ITEM_STATIC_ID.ToString() + value.ToString(), out realID))
	//		{
	//			this._RealID = realID;
	//		}
	//	}
	//}

	//// Token: 0x0600146F RID: 5231 RVA: 0x000A4DE8 File Offset: 0x000A2FE8
	//public virtual ItemSaveData GetItemSaveData()
	//{
	//	return new ItemSaveData
	//	{
	//		itemOwner = this.Owner,
	//		IsUsed = this.IS_USED,
	//		itemType = this.OriginalData.ITEM_STATIC_ID,
	//		dynamicProperty = this.DynamicData,
	//		IsReserveWeapon = false
	//	};
	//}

	//public virtual void SetItemFromSaveData(ItemSaveData isd)
	//{
	//	this.Owner = isd.itemOwner;
	//	this.IS_USED = isd.IsUsed;
	//	this.OriginalData.ITEM_STATIC_ID = isd.itemType;
	//	this.DynamicData = isd.dynamicProperty;
	//}
}
