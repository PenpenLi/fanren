using System;
using System.Collections.Generic;
using UnityEngine;


public class ItemFolderContainer
{
    private ItemOwner _pOwner = ItemOwner.ITO_HEROFOLDER;

    private RoleWear _WearOperate;

    private int host_id = 1;

    public ItemFolderContainer()
	{
		this._WearOperate = new RoleWear(this.Host_id);
	}

	public ItemFolderContainer(int playerid)
	{
		this.Host_id = playerid;
		this._WearOperate = new RoleWear(this.Host_id);
	}

	// Token: 0x1700023D RID: 573
	//public CItemBase this[ulong id]
	//{
	//	get
	//	{
	//		if (!this.FolderData().ContainsKey(id))
	//		{
	//			return null;
	//		}
	//		return this.FolderData()[id];
	//	}
	//}

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

	// Token: 0x1700023F RID: 575
	// (get) Token: 0x0600148D RID: 5261 RVA: 0x000A51D8 File Offset: 0x000A33D8
	// (set) Token: 0x0600148E RID: 5262 RVA: 0x000A5208 File Offset: 0x000A3408
	public RoleWear WearOperate
	{
		get
		{
			if (this._WearOperate == null)
			{
				this._WearOperate = new RoleWear(this.Host_id);
			}
			return this._WearOperate;
		}
		set
		{
			this._WearOperate = value;
		}
	}

	//public ItemOwner Owner
	//{
	//	get
	//	{
	//		return this._pOwner;
	//	}
	//	set
	//	{
	//		this._pOwner = value;
	//	}
	//}

	// Token: 0x06001491 RID: 5265 RVA: 0x000A5228 File Offset: 0x000A3428
	//public Dictionary<ulong, CItemBase> FolderData()
	//{
	//	Dictionary<ulong, CItemBase> result;
	//	try
	//	{
	//		result = GameData.Instance.ItemMan.GetOwnerItem(this.Owner);
	//	}
	//	catch
	//	{
	//		Debug.LogError("ItemFolderContainer unknown  error!");
	//		result = null;
	//	}
	//	return result;
	//}

	//// Token: 0x06001492 RID: 5266 RVA: 0x000A528C File Offset: 0x000A348C
	//public bool TryGetEquipData(EquipCfgType type, out Dictionary<ulong, CItemBase> pData)
	//{
	//	pData = new Dictionary<ulong, CItemBase>();
	//	pData.Clear();
	//	return GameData.Instance.ItemMan.TryGetItemChildType(1, (int)type, out pData) && pData.Count > 0;
	//}

	//// Token: 0x06001493 RID: 5267 RVA: 0x000A52CC File Offset: 0x000A34CC
	//public bool TryGetWeaponData(out Dictionary<ulong, ItemWeapon> pData)
	//{
	//	pData = new Dictionary<ulong, ItemWeapon>();
	//	pData.Clear();
	//	Dictionary<ulong, CItemBase> dictionary = new Dictionary<ulong, CItemBase>();
	//	for (int i = 1; i < 11; i++)
	//	{
	//		if (dictionary == null)
	//		{
	//			dictionary = new Dictionary<ulong, CItemBase>();
	//		}
	//		dictionary.Clear();
	//		if (GameData.Instance.ItemMan.TryGetItemChildType(1, i, out dictionary))
	//		{
	//			foreach (KeyValuePair<ulong, CItemBase> keyValuePair in dictionary)
	//			{
	//				pData.Add(keyValuePair.Key, (ItemWeapon)keyValuePair.Value);
	//			}
	//		}
	//	}
	//	return pData.Count > 0;
	//}

	//// Token: 0x06001494 RID: 5268 RVA: 0x000A539C File Offset: 0x000A359C
	//public bool TryGetPelletData(PelletCfgType type, out Dictionary<ulong, CItemBase> pData)
	//{
	//	pData = new Dictionary<ulong, CItemBase>();
	//	pData.Clear();
	//	return GameData.Instance.ItemMan.TryGetItemChildType(2, (int)type, out pData) && pData.Count > 0;
	//}

	//// Token: 0x06001495 RID: 5269 RVA: 0x000A53DC File Offset: 0x000A35DC
	//public bool TryGetStuffData(StuffCfgType type, out Dictionary<ulong, CItemBase> pData)
	//{
	//	pData = new Dictionary<ulong, CItemBase>();
	//	pData.Clear();
	//	return GameData.Instance.ItemMan.TryGetItemChildType(3, (int)type, out pData) && pData.Count > 0;
	//}

	//// Token: 0x06001496 RID: 5270 RVA: 0x000A541C File Offset: 0x000A361C
	//public bool TryGetAmuletData(out Dictionary<ulong, ItemMagicFigure> pData)
	//{
	//	pData = new Dictionary<ulong, ItemMagicFigure>();
	//	pData.Clear();
	//	Dictionary<ulong, CItemBase> dictionary = new Dictionary<ulong, CItemBase>();
	//	dictionary.Clear();
	//	if (!GameData.Instance.ItemMan.TryGetItemChildType(4, 1, out dictionary))
	//	{
	//		return false;
	//	}
	//	foreach (KeyValuePair<ulong, CItemBase> keyValuePair in dictionary)
	//	{
	//		pData.Add(keyValuePair.Key, (ItemMagicFigure)keyValuePair.Value);
	//	}
	//	return pData.Count > 0;
	//}

	//// Token: 0x06001497 RID: 5271 RVA: 0x000A54D0 File Offset: 0x000A36D0
	//public bool TryGetOtherData(OtherCfgType type, out Dictionary<ulong, CItemBase> pData)
	//{
	//	pData = new Dictionary<ulong, CItemBase>();
	//	pData.Clear();
	//	return GameData.Instance.ItemMan.TryGetItemChildType(4, (int)type, out pData) && pData.Count > 0;
	//}

	//// Token: 0x06001498 RID: 5272 RVA: 0x000A5510 File Offset: 0x000A3710
	//public bool TryGetItemsData(ItemCfgType type, out Dictionary<ulong, CItemBase> pData)
	//{
	//	return GameData.Instance.ItemMan.TryGetItemType((int)type, out pData) && pData.Count > 0;
	//}

	//// Token: 0x06001499 RID: 5273 RVA: 0x000A5540 File Offset: 0x000A3740
	//public bool TryGetUsedEquipData(EquipCfgType type, out CItemBase pData)
	//{
	//	pData = null;
	//	Dictionary<ulong, CItemBase> dictionary = new Dictionary<ulong, CItemBase>();
	//	if (!this.TryGetEquipData(type, out dictionary))
	//	{
	//		return false;
	//	}
	//	if (dictionary == null || dictionary.Count <= 0)
	//	{
	//		return false;
	//	}
	//	foreach (CItemBase citemBase in dictionary.Values)
	//	{
	//		if (citemBase.IS_USED)
	//		{
	//			pData = citemBase;
	//			return true;
	//		}
	//	}
	//	return false;
	//}

	//// Token: 0x0600149A RID: 5274 RVA: 0x000A55E4 File Offset: 0x000A37E4
	//public bool TryGetUsedEquipData(out List<CItemBase> pData)
	//{
	//	pData = new List<CItemBase>();
	//	pData.Clear();
	//	Dictionary<ulong, CItemBase> dictionary = new Dictionary<ulong, CItemBase>();
	//	if (!this.TryGetItemsData(ItemCfgType.ITCT_EQUIP, out dictionary))
	//	{
	//		return false;
	//	}
	//	if (dictionary == null || dictionary.Count <= 0)
	//	{
	//		return false;
	//	}
	//	foreach (CItemBase citemBase in dictionary.Values)
	//	{
	//		bool flag = false;
	//		if (citemBase.CHILD_TYPE_ID >= 1 && citemBase.CHILD_TYPE_ID <= 3)
	//		{
	//			ItemWeapon itemWeapon = (ItemWeapon)citemBase;
	//			if (itemWeapon != null)
	//			{
	//				flag = itemWeapon.IsReserveWeapon;
	//			}
	//		}
	//		if (citemBase.IS_USED || flag)
	//		{
	//			pData.Add(citemBase);
	//		}
	//	}
	//	return pData.Count > 0;
	//}

	//// Token: 0x0600149B RID: 5275 RVA: 0x000A56D0 File Offset: 0x000A38D0
	//public T GetFolderItem<T>(ulong id) where T : CItemBase
	//{
	//	if (this.FolderData().ContainsKey(id))
	//	{
	//		return (T)((object)this.FolderData()[id]);
	//	}
	//	return (T)((object)null);
	//}
}
