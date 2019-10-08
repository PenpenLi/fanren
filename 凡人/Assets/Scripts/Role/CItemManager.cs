using System;
using System.Collections.Generic;


public class CItemManager
{

    //   public const int ITEM_SORT_START_INDEX = 0;

    //   public const int ITEM_SORT_END_INDEX = 9999;

    //   // Token: 0x04001504 RID: 5380
    //   private Dictionary<ulong, CItemBase> m_mapItemInfo = new Dictionary<ulong, CItemBase>();

    //   // Token: 0x04001505 RID: 5381
    //   private Dictionary<ulong, int> m_mapItemDynamicID = new Dictionary<ulong, int>();

    //   // Token: 0x04001506 RID: 5382
    //   private Dictionary<ItemOwner, Dictionary<ulong, CItemBase>> m_mapFolderContainer = new Dictionary<ItemOwner, Dictionary<ulong, CItemBase>>();

    //   public Dictionary<ulong, CItemBase> ITEM_PACKAGE
    //{
    //	get
    //	{
    //		return this.m_mapItemInfo;
    //	}
    //	set
    //	{
    //		this.m_mapItemInfo = value;
    //	}
    //}

    //// Token: 0x17000244 RID: 580
    //// (get) Token: 0x060014BD RID: 5309 RVA: 0x000A6838 File Offset: 0x000A4A38
    //// (set) Token: 0x060014BE RID: 5310 RVA: 0x000A6840 File Offset: 0x000A4A40
    //public Dictionary<ulong, int> ItemDynamicID
    //{
    //	get
    //	{
    //		return this.m_mapItemDynamicID;
    //	}
    //	set
    //	{
    //		this.m_mapItemDynamicID = value;
    //	}
    //}

    //// Token: 0x17000245 RID: 581
    //// (get) Token: 0x060014BF RID: 5311 RVA: 0x000A684C File Offset: 0x000A4A4C
    //public Dictionary<ItemOwner, Dictionary<ulong, CItemBase>> OWNER_CONTAINER_DATA
    //{
    //	get
    //	{
    //		return this.m_mapFolderContainer;
    //	}
    //}

    //// Token: 0x060014C0 RID: 5312 RVA: 0x000A6854 File Offset: 0x000A4A54
    //public bool CreateItem(ulong ItemStaticID, int nCount, ItemOwner Ower)
    //{
    //	return this.CreateItem(ItemStaticID, nCount, Ower, null);
    //}

    //// Token: 0x060014C1 RID: 5313 RVA: 0x000A6860 File Offset: 0x000A4A60
    //public bool CreateItem(ulong ItemSaticID, int nCount, ItemOwner Ower, ItemPropertyConfig ipc)
    //{
    //	List<CItemBase> list = new List<CItemBase>();
    //	return this.CreateItem(ItemSaticID, nCount, Ower, ipc, ref list);
    //}

    //// Token: 0x060014C2 RID: 5314 RVA: 0x000A6880 File Offset: 0x000A4A80
    //public bool CreateItem(ulong ItemSaticID, int nCount, ItemOwner Ower, ItemPropertyConfig ipc, ref List<CItemBase> itemList)
    //{
    //	if (nCount <= 0)
    //	{
    //		return false;
    //	}
    //	ItemPropertyConfig itemPropertyConfig;
    //	if (!GameData.Instance.ItemStaticMan.TryGetItemInfoByID(ItemSaticID, out itemPropertyConfig))
    //	{
    //		return false;
    //	}
    //	int num = 0;
    //	itemList.Clear();
    //	int i = 0;
    //	while (i < nCount)
    //	{
    //		if (!this.ItemDynamicID.ContainsKey(ItemSaticID))
    //		{
    //			num++;
    //			this.ItemDynamicID.Add(ItemSaticID, num);
    //			goto IL_B8;
    //		}
    //		if (this.ItemDynamicID[ItemSaticID] + 1 <= 9999)
    //		{
    //			Dictionary<ulong, int> itemDynamicID;
    //			Dictionary<ulong, int> dictionary = itemDynamicID = this.ItemDynamicID;
    //			int num2 = itemDynamicID[ItemSaticID];
    //			dictionary[ItemSaticID] = num2 + 1;
    //			num = this.ItemDynamicID[ItemSaticID];
    //			goto IL_B8;
    //		}
    //		Logger.LogWarning(new object[]
    //		{
    //			"CItemManager: Create Item failed! Insert item id Error , continue!"
    //		});
    //		IL_1E6:
    //		i++;
    //		continue;
    //		IL_B8:
    //		CItemBase citemBase;
    //		if (itemPropertyConfig.ITEM_TYPE_ID == 1)
    //		{
    //			if (itemPropertyConfig.ITEM_CHILDTYPE_ID >= 1 && itemPropertyConfig.ITEM_CHILDTYPE_ID <= 3)
    //			{
    //				citemBase = new ItemWeapon();
    //			}
    //			else
    //			{
    //				citemBase = new CItemBase();
    //			}
    //		}
    //		else if (itemPropertyConfig.ITEM_TYPE_ID == 4 && itemPropertyConfig.ITEM_CHILDTYPE_ID == 1)
    //		{
    //			citemBase = new ItemMagicFigure();
    //		}
    //		else
    //		{
    //			citemBase = new CItemBase();
    //		}
    //		citemBase.Owner = Ower;
    //		citemBase.OriginalData = itemPropertyConfig.Clone();
    //		if (ipc == null)
    //		{
    //			citemBase.DynamicData = itemPropertyConfig.Clone();
    //		}
    //		else
    //		{
    //			citemBase.DynamicData = ipc.Clone();
    //		}
    //		citemBase.SmartDynamicID = num;
    //		this.ITEM_PACKAGE.Add(citemBase.ID, citemBase);
    //		if (this.m_mapFolderContainer.ContainsKey(Ower))
    //		{
    //			this.m_mapFolderContainer[Ower].Add(citemBase.ID, citemBase);
    //		}
    //		else
    //		{
    //			Dictionary<ulong, CItemBase> dictionary2 = new Dictionary<ulong, CItemBase>();
    //			dictionary2.Add(citemBase.ID, citemBase);
    //			this.m_mapFolderContainer.Add(Ower, dictionary2);
    //		}
    //		itemList.Add(citemBase);
    //		PropsPlane.m_bType = false;
    //		GameData.Instance.ScrMan.Exec(34, (ItemCfgType)citemBase.TYPE_ID, ItemSaticID);
    //		goto IL_1E6;
    //	}
    //	return true;
    //}

    //// Token: 0x060014C3 RID: 5315 RVA: 0x000A6A80 File Offset: 0x000A4C80
    //public string GetItemCount(ulong itemStaticID)
    //{
    //	if (!GameData.Instance.ItemStaticMan.IsHaveClassify(itemStaticID))
    //	{
    //		return string.Empty;
    //	}
    //	int num = 1;
    //	List<int> list = new List<int>();
    //	List<CItemBase> list2 = new List<CItemBase>(this.ITEM_PACKAGE.Values);
    //	for (int i = 0; i < list2.Count; i++)
    //	{
    //		if (list2[i].ITEM_STATIC_ID == itemStaticID)
    //		{
    //			list.Add(num);
    //			num++;
    //		}
    //	}
    //	return list.Count.ToString();
    //}

    public void Clear()
    {
        //this.ITEM_PACKAGE.Clear();
        //this.ItemDynamicID.Clear();
        //this.m_mapFolderContainer.Clear();
    }

    //// Token: 0x060014C5 RID: 5317 RVA: 0x000A6B34 File Offset: 0x000A4D34
    //public bool RemoveItemsByOwner(ItemOwner Owner)
    //{
    //	List<CItemBase> list = new List<CItemBase>(this.ITEM_PACKAGE.Values);
    //	for (int i = 0; i < list.Count; i++)
    //	{
    //		if (list[i].Owner == Owner && !this.RemoveItemByID(list[i].ID))
    //		{
    //			return false;
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x060014C6 RID: 5318 RVA: 0x000A6B98 File Offset: 0x000A4D98
    //public bool RemoveItemByID(ulong ItemID)
    //{
    //	if (this.ITEM_PACKAGE.ContainsKey(ItemID))
    //	{
    //		Player.Instance.ItemFolder.WearOperate.TakeOff(this.ITEM_PACKAGE[ItemID]);
    //	}
    //	if (this.ITEM_PACKAGE.Remove(ItemID))
    //	{
    //		this.RemoveItemOwnerData(ItemID);
    //		Singleton<EZGUIManager>.GetInstance().OnCommandGUIMessage(GUI_TYPE.UICMD_ALL_ATTRIBUTEUPDATE, ATTRIBUTE_TYPE.ATT_PHY_ATK, 0);
    //		return true;
    //	}
    //	return false;
    //}

    //// Token: 0x060014C7 RID: 5319 RVA: 0x000A6C0C File Offset: 0x000A4E0C
    //public bool RemoveItemsType(int nTypeID)
    //{
    //	if (!GameData.Instance.ItemStaticMan.IsHaveTypeByID(nTypeID))
    //	{
    //		return false;
    //	}
    //	List<CItemBase> list = new List<CItemBase>(this.ITEM_PACKAGE.Values);
    //	for (int i = 0; i < list.Count; i++)
    //	{
    //		if (list[i].TYPE_ID == nTypeID && !this.RemoveItemByID(list[i].ID))
    //		{
    //			return false;
    //		}
    //	}
    //	return true;
    //}

    //// Token: 0x060014C8 RID: 5320 RVA: 0x000A6C84 File Offset: 0x000A4E84
    //public bool RemoveItemsChildType(int nTypeID, int nChildTypeID)
    //{
    //	if (!GameData.Instance.ItemStaticMan.IsHaveChildTypeByID(nTypeID, nChildTypeID))
    //	{
    //		return false;
    //	}
    //	List<CItemBase> list = new List<CItemBase>(this.ITEM_PACKAGE.Values);
    //	for (int i = 0; i < list.Count; i++)
    //	{
    //		if (list[i].TYPE_ID == nTypeID && list[i].CHILD_TYPE_ID == nChildTypeID && !this.RemoveItemByID(list[i].ID))
    //		{
    //			return false;
    //		}
    //	}
    //	return true;
    //}

    //// Token: 0x060014C9 RID: 5321 RVA: 0x000A6D10 File Offset: 0x000A4F10
    //public bool RemoveItemsBySortID(ulong ItemStaticID)
    //{
    //	if (!GameData.Instance.ItemStaticMan.IsHaveClassify(ItemStaticID))
    //	{
    //		return false;
    //	}
    //	List<CItemBase> list = new List<CItemBase>(this.ITEM_PACKAGE.Values);
    //	for (int i = 0; i < list.Count; i++)
    //	{
    //		if (list[i].ITEM_STATIC_ID == ItemStaticID && !this.RemoveItemByID(list[i].ID))
    //		{
    //			return false;
    //		}
    //	}
    //	return true;
    //}

    //// Token: 0x060014CA RID: 5322 RVA: 0x000A6D88 File Offset: 0x000A4F88
    //private void RemoveItemOwnerData(ulong itemid)
    //{
    //	List<ItemOwner> list = new List<ItemOwner>(this.m_mapFolderContainer.Keys);
    //	for (int i = 0; i < list.Count; i++)
    //	{
    //		this.m_mapFolderContainer[list[i]].Remove(itemid);
    //	}
    //}

    //// Token: 0x060014CB RID: 5323 RVA: 0x000A6DD8 File Offset: 0x000A4FD8
    //public bool IsHaveItemByID(ulong ItemID)
    //{
    //	return this.ITEM_PACKAGE.ContainsKey(ItemID);
    //}

    //// Token: 0x060014CC RID: 5324 RVA: 0x000A6DE8 File Offset: 0x000A4FE8
    //public Dictionary<ulong, CItemBase> GetOwnerItem(ItemOwner Owner)
    //{
    //	if (!this.OWNER_CONTAINER_DATA.ContainsKey(Owner))
    //	{
    //		return null;
    //	}
    //	return this.OWNER_CONTAINER_DATA[Owner];
    //}

    //// Token: 0x060014CD RID: 5325 RVA: 0x000A6E14 File Offset: 0x000A5014
    //public bool TryGetItemsByOwner(ItemOwner owner, out Dictionary<ulong, CItemBase> pItems)
    //{
    //	pItems = new Dictionary<ulong, CItemBase>();
    //	foreach (KeyValuePair<ulong, CItemBase> keyValuePair in this.ITEM_PACKAGE)
    //	{
    //		if (keyValuePair.Value.Owner == owner)
    //		{
    //			pItems.Add(keyValuePair.Key, keyValuePair.Value);
    //		}
    //	}
    //	return pItems.Count > 0;
    //}

    //// Token: 0x060014CE RID: 5326 RVA: 0x000A6EAC File Offset: 0x000A50AC
    //public bool TryGetItemByID(ulong ItemID, out CItemBase pItem)
    //{
    //	return this.ITEM_PACKAGE.TryGetValue(ItemID, out pItem);
    //}

    //// Token: 0x060014CF RID: 5327 RVA: 0x000A6EBC File Offset: 0x000A50BC
    //public bool TryGetItemType(int nTypeID, out Dictionary<ulong, CItemBase> pItems)
    //{
    //	pItems = null;
    //	if (!GameData.Instance.ItemStaticMan.IsHaveTypeByID(nTypeID))
    //	{
    //		return false;
    //	}
    //	pItems = new Dictionary<ulong, CItemBase>();
    //	foreach (CItemBase citemBase in this.ITEM_PACKAGE.Values)
    //	{
    //		if (citemBase.TYPE_ID == nTypeID)
    //		{
    //			pItems.Add(citemBase.ID, citemBase);
    //		}
    //	}
    //	return pItems.Count > 0;
    //}

    //// Token: 0x060014D0 RID: 5328 RVA: 0x000A6F68 File Offset: 0x000A5168
    //public bool TryGetAllItem(out Dictionary<ulong, CItemBase> pItems)
    //{
    //	pItems = null;
    //	pItems = new Dictionary<ulong, CItemBase>();
    //	foreach (CItemBase citemBase in this.ITEM_PACKAGE.Values)
    //	{
    //		pItems.Add(citemBase.ID, citemBase);
    //	}
    //	return pItems.Count > 0;
    //}

    //// Token: 0x060014D1 RID: 5329 RVA: 0x000A6FF0 File Offset: 0x000A51F0
    //public bool TryGetItemChildType(int nTypeID, int nChildTypeID, out Dictionary<ulong, CItemBase> pItems)
    //{
    //	pItems = null;
    //	if (!GameData.Instance.ItemStaticMan.IsHaveChildTypeByID(nTypeID, nChildTypeID))
    //	{
    //		return false;
    //	}
    //	pItems = new Dictionary<ulong, CItemBase>();
    //	foreach (CItemBase citemBase in this.ITEM_PACKAGE.Values)
    //	{
    //		if (citemBase.TYPE_ID == nTypeID && citemBase.CHILD_TYPE_ID == nChildTypeID)
    //		{
    //			pItems.Add(citemBase.ID, citemBase);
    //		}
    //	}
    //	return pItems.Count > 0;
    //}

    //// Token: 0x060014D2 RID: 5330 RVA: 0x000A70A8 File Offset: 0x000A52A8
    //public bool TryGetItemsByID(ulong ItemStaticID, out Dictionary<ulong, CItemBase> pItems)
    //{
    //	pItems = null;
    //	if (!GameData.Instance.ItemStaticMan.IsHaveClassify(ItemStaticID))
    //	{
    //		return false;
    //	}
    //	pItems = new Dictionary<ulong, CItemBase>();
    //	foreach (CItemBase citemBase in this.ITEM_PACKAGE.Values)
    //	{
    //		if (citemBase.ITEM_STATIC_ID == ItemStaticID)
    //		{
    //			pItems.Add(citemBase.ID, citemBase);
    //		}
    //	}
    //	return pItems.Count > 0;
    //}
}
