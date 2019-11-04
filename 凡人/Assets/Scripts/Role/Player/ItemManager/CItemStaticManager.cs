using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;


public class CItemStaticManager
{
    private const string ITEM_FILE_KEY = "DataFile/ItemData/ItemInfoConfig";
    
    private static Dictionary<ulong, ItemPropertyConfig> m_mapTotalItemInfos = new Dictionary<ulong, ItemPropertyConfig>();

    private List<EquipCfgType> EquipCfgIndexGroup = new List<EquipCfgType>();

    private List<ItemCfgType> ItemCfgIndexGroup = new List<ItemCfgType>();

    private static ImageGroupManager ItemAtlas = new ImageGroupManager();

    public CItemStaticManager()
	{
		this.ResetData();
	}

	public ImageGroupManager ItemAtlasMan
	{
		get
		{
			return CItemStaticManager.ItemAtlas;
		}
		set
		{
			CItemStaticManager.ItemAtlas = value;
		}
	}

	public Dictionary<ulong, ItemPropertyConfig> ItemInfoTotalData
	{
		get
		{
			return CItemStaticManager.m_mapTotalItemInfos;
		}
		private set
		{
			CItemStaticManager.m_mapTotalItemInfos = value;
		}
	}

	public bool TryGetItemInfoByID(ulong ItemStaticID, out ItemPropertyConfig info)
	{
		info = null;
		return CItemStaticManager.m_mapTotalItemInfos.TryGetValue(ItemStaticID, out info);
	}

	public bool TryGetItemInfoByTypeID(int nTypeID, out List<ItemPropertyConfig> infos)
	{
		infos = null;
		if (CItemStaticManager.m_mapTotalItemInfos.Count <= 0)
		{
			return false;
		}
		infos = new List<ItemPropertyConfig>();
		infos.Clear();
		foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		{
			if (itemPropertyConfig.ITEM_TYPE_ID == nTypeID)
			{
				infos.Add(itemPropertyConfig);
			}
		}
		return infos.Count > 0;
	}

	public bool TryGetItemInfoByChildTypeID(int nTypeID, int nChildTypeID, out List<ItemPropertyConfig> infos)
	{
		infos = null;
		if (CItemStaticManager.m_mapTotalItemInfos.Count <= 0)
		{
			return false;
		}
		infos = new List<ItemPropertyConfig>();
		infos.Clear();
		foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		{
			if (itemPropertyConfig.ITEM_TYPE_ID == nTypeID && itemPropertyConfig.ITEM_CHILDTYPE_ID == nChildTypeID)
			{
				infos.Add(itemPropertyConfig);
			}
		}
		return infos.Count > 0;
	}

	public bool IsHaveClassify(ulong ItemStaticID)
	{
		foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		{
			if (itemPropertyConfig.ITEM_STATIC_ID == ItemStaticID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001513 RID: 5395 RVA: 0x000A7954 File Offset: 0x000A5B54
	public bool IsHaveTypeByID(int nTypeID)
	{
		foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		{
			if (itemPropertyConfig.ITEM_TYPE_ID == nTypeID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001514 RID: 5396 RVA: 0x000A79D0 File Offset: 0x000A5BD0
	public bool IsHaveChildTypeByID(int nTypeID, int nChildTypeID)
	{
		foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		{
			if (itemPropertyConfig.ITEM_TYPE_ID == nTypeID && itemPropertyConfig.ITEM_CHILDTYPE_ID == nChildTypeID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001515 RID: 5397 RVA: 0x000A7A58 File Offset: 0x000A5C58
	public string GetTypeNameByID(int nTypeID)
	{
		if (this.IsHaveTypeByID(nTypeID))
		{
			foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
			{
				if (itemPropertyConfig.ITEM_TYPE_ID == nTypeID)
				{
					return itemPropertyConfig.ITEM_TYPE_NAME;
				}
			}
		}
		return null;
	}


	public string GetChildTypeNameByID(int nTypeID, int nChildTypeID)
	{
		foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		{
			if (itemPropertyConfig.ITEM_TYPE_ID == nTypeID && itemPropertyConfig.ITEM_CHILDTYPE_ID == nChildTypeID)
			{
				return itemPropertyConfig.ITEM_CHILDTYPE_NAME;
			}
		}
		return null;
	}

	public string GetItemNameByID(ulong ItemStaticID)
	{
		foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		{
			if (itemPropertyConfig.ITEM_STATIC_ID == ItemStaticID)
			{
				return itemPropertyConfig.ITEM_NAME;
			}
		}
		return null;
	}

	public string GetItemUnitNameByID(ulong ItemStaticID)
	{
		foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		{
			if (itemPropertyConfig.ITEM_STATIC_ID == ItemStaticID)
			{
				return itemPropertyConfig.ITEM_UNITNAME;
			}
		}
		return null;
	}

	public bool Load()
	{
		if (this.ItemInfoLoad())
		{
			if (!CItemStaticManager.ItemAtlas.Init())
			{
				return false;
			}
			if (CItemStaticManager.ItemAtlas._isNeedBuild)
			{
				Dictionary<ulong, ImgSrcData> dictionary = new Dictionary<ulong, ImgSrcData>();
				foreach (ItemPropertyConfig itemPropertyConfig in this.ItemInfoTotalData.Values)
				{
					if (!dictionary.ContainsKey(itemPropertyConfig.ITEM_STATIC_ID))
					{
						dictionary.Add(itemPropertyConfig.ITEM_STATIC_ID, new ImgSrcData(itemPropertyConfig.ITEM_STATIC_ID, itemPropertyConfig.ITEM_NAME, itemPropertyConfig.ITEM_ICOPATH_SMALL));
					}
					else
					{
                        Debug.LogWarning("ItemPropertyConfig id error : " + itemPropertyConfig.ITEM_STATIC_ID);
                    }
				}
				if (dictionary.Count > 0)
				{
					if (!CItemStaticManager.ItemAtlas.ReadyData(dictionary))
					{
						return false;
					}
					if (!CItemStaticManager.ItemAtlas.ExecuteBuild())
					{
						return false;
					}
				}
			}
			else if (!CItemStaticManager.ItemAtlas.ExecuteLoad())
			{
				return false;
			}
		}
		return false;
	}

	public bool ItemInfoLoad()
	{
		List<string> list = RoleBaseFun.LoadConfInAssets("DataFile/ItemData/ItemInfoConfig");
		if (list.Count <= 0)
		{
			Debug.LogWarning("ItemConfig no found!");
			return false;
		}
		this.ResetData();
		int num = 0;
		int item_ITEMATT_COUNT = 0;
		int item_ATTRIBUTE_COUNT = 0;
		int item_ADDATTRIBUTES_COUNT = 0;
		int item_TO_MODEL_COUNT = 0;
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			if (array.Length > 1)
			{
				ItemPropertyConfig itemPropertyConfig = new ItemPropertyConfig();
				int num2 = 0;
				if (num < 4)
				{
					if (array[num2] == "MaxPropCount")
					{
						num2++;
						item_ITEMATT_COUNT = Convert.ToInt32(array[num2]);
					}
					else if (array[num2] == "MaxBaseEffectCount")
					{
						num2++;
						item_ATTRIBUTE_COUNT = Convert.ToInt32(array[num2]);
					}
					else if (array[num2] == "MaxAddEffectCount")
					{
						num2++;
						item_ADDATTRIBUTES_COUNT = Convert.ToInt32(array[num2]);
					}
					else if (array[num2] == "MaxRunCount")
					{
						num2++;
						item_TO_MODEL_COUNT = Convert.ToInt32(array[num2]);
					}
					num2++;
					num++;
				}
				else
				{
					if (array.Length < 10)
					{
						Debug.LogWarning("ItemConfig line data may be flawed!");
					}
					itemPropertyConfig.ITEM_TYPE_NAME = array[num2];
					num2++;
					itemPropertyConfig.ITEM_TYPE_ID = Convert.ToInt32(array[num2]);
					string str = array[num2];
					num2++;
					itemPropertyConfig.ITEM_CHILDTYPE_NAME = array[num2];
					num2++;
					itemPropertyConfig.ITEM_CHILDTYPE_ID = Convert.ToInt32(array[num2]);
					str += array[num2];
					num2++;
					itemPropertyConfig.ITEM_STATIC_ID = Convert.ToUInt64(array[num2]);
					num2++;
					if (CItemStaticManager.m_mapTotalItemInfos.ContainsKey(itemPropertyConfig.ITEM_STATIC_ID))
					{
						Debug.LogWarning("ItemConfig List is have ITEM_ID!");
					}
					else
					{
						itemPropertyConfig.ITEM_NAME = array[num2];
						num2++;
						itemPropertyConfig.ITEM_UNITNAME = array[num2];
						num2++;
						itemPropertyConfig.ITEM_DESC = array[num2];
						num2++;
						itemPropertyConfig.ITEM_INTRO = array[num2];
						num2++;
						itemPropertyConfig.ITEM_ICOPATH_SMALL = array[num2];
						num2++;
						itemPropertyConfig.ITEM_ICOPATH_BIG = array[num2];
						num2++;
						itemPropertyConfig.ITEM_RES_PREB = array[num2];
						num2++;
						itemPropertyConfig.ITEM_ITEMATT_COUNT = item_ITEMATT_COUNT;
						itemPropertyConfig.ITEM_ATTRIBUTE_COUNT = item_ATTRIBUTE_COUNT;
						itemPropertyConfig.ITEM_ADDATTRIBUTES_COUNT = item_ADDATTRIBUTES_COUNT;
						itemPropertyConfig.ITEM_TO_MODEL_COUNT = item_TO_MODEL_COUNT;
						if (array.Length < itemPropertyConfig.ITEM_ITEMATT_COUNT + num2)
						{
							Debug.LogWarning("ItemConfig ITEM_TO_MODEL_COUNT Error!");
						}
						else
						{
							itemPropertyConfig.ITEM_ITEMATT_MAP.Clear();
							for (int i = 0; i < itemPropertyConfig.ITEM_ITEMATT_COUNT; i++)
							{
								if (array[num2] == "null")
								{
									num2 += 2;
								}
								else
								{
									ITEM_ATTRIBUTE_TYPE key = (ITEM_ATTRIBUTE_TYPE)Convert.ToInt32(array[num2]);
									num2++;
									itemPropertyConfig.ITEM_ITEMATT_MAP.Add(key, (float)Convert.ToDouble(array[num2]));
									num2++;
								}
							}
							if (array.Length < itemPropertyConfig.ITEM_ATTRIBUTE_COUNT + num2)
							{
								Debug.LogWarning("Name : " + itemPropertyConfig.ITEM_NAME + "ItemConfig ITEM_ATTRIBUTE_COUNT Error!");
							}
							else
							{
								itemPropertyConfig.ITEM_ATTRIBUTES_MAP.Clear();
								for (int j = 0; j < itemPropertyConfig.ITEM_ATTRIBUTE_COUNT; j++)
								{
									if (array[num2] == "null")
									{
										num2 += 2;
									}
									else
									{
										ATTRIBUTE_TYPE key2 = (ATTRIBUTE_TYPE)Convert.ToInt32(array[num2]);
										num2++;
										itemPropertyConfig.ITEM_ATTRIBUTES_MAP.Add(key2, (float)Convert.ToDouble(array[num2]));
										num2++;
									}
								}
								if (array.Length < itemPropertyConfig.ITEM_ADDATTRIBUTES_COUNT + num2)
								{
									Debug.LogWarning("Name : " + itemPropertyConfig.ITEM_NAME + "ItemConfig ITEM_ADDATTRIBUTES_COUNT Error!");
								}
								else
								{
									itemPropertyConfig.ITEM_ADDATTRIBUTES_MAP.Clear();
									for (int k = 0; k < itemPropertyConfig.ITEM_ADDATTRIBUTES_COUNT; k++)
									{
										if (array[num2] == "null")
										{
											num2 += 2;
										}
										else
										{
											ITEM_ADD_ATTRIBUTE key3 = (ITEM_ADD_ATTRIBUTE)Convert.ToInt32(array[num2]);
											num2++;
											itemPropertyConfig.ITEM_ADDATTRIBUTES_MAP.Add(key3, (float)Convert.ToDouble(array[num2]));
											num2++;
										}
									}
									if (array.Length < itemPropertyConfig.ITEM_TO_MODEL_COUNT + num2)
									{
										Debug.LogWarning("ItemConfig ITEM_TO_MODEL_COUNT Error!");
									}
									else
									{
										itemPropertyConfig.ITEM_TO_MODELS.Clear();
										for (int l = 0; l < itemPropertyConfig.ITEM_TO_MODEL_COUNT; l++)
										{
											if (array[num2] == "null")
											{
												num2 += 2;
											}
											else
											{
												ScrModType key4 = (ScrModType)Convert.ToInt32(array[num2]);
												num2++;
												itemPropertyConfig.ITEM_TO_MODELS.Add(key4, array[num2]);
												num2++;
											}
										}
										CItemStaticManager.m_mapTotalItemInfos.Add(itemPropertyConfig.ITEM_STATIC_ID, itemPropertyConfig);
									}
								}
							}
						}
					}
				}
			}
		}
		if (CItemStaticManager.m_mapTotalItemInfos.Count <= 0)
		{
			Debug.LogWarning("ItemConfig is empty!");
		}
		return true;
	}

	public void ResetData()
	{
		CItemStaticManager.m_mapTotalItemInfos.Clear();
	}

	public void PrintfForDebug()
	{
		//Logger.Log(new object[]
		//{
		//	"============= CItemStaticManager Debug Log printf Start ============="
		//});
		//Logger.Log(new object[]
		//{
		//	"*Item Data File  : DataFile/ItemData/ItemInfoConfig"
		//});
		//Logger.Log(new object[]
		//{
		//	"*Find Item Count : " + CItemStaticManager.m_mapTotalItemInfos.Count
		//});
		//Logger.Log(new object[]
		//{
		//	"*Start Retrieve Info..."
		//});
		//foreach (ItemPropertyConfig itemPropertyConfig in CItemStaticManager.m_mapTotalItemInfos.Values)
		//{
		//	Logger.Log(new object[]
		//	{
		//		string.Concat(new object[]
		//		{
		//			"Item Name : ",
		//			itemPropertyConfig.ITEM_NAME,
		//			" ID : ",
		//			itemPropertyConfig.ITEM_STATIC_ID
		//		})
		//	});
		//	Logger.Log(new object[]
		//	{
		//		string.Concat(new object[]
		//		{
		//			"  Type Name : ",
		//			itemPropertyConfig.ITEM_TYPE_NAME,
		//			" Type ID : ",
		//			itemPropertyConfig.ITEM_TYPE_ID
		//		})
		//	});
		//	Logger.Log(new object[]
		//	{
		//		string.Concat(new object[]
		//		{
		//			"  Child Name : ",
		//			itemPropertyConfig.ITEM_CHILDTYPE_NAME,
		//			" Child Type ID : ",
		//			itemPropertyConfig.ITEM_CHILDTYPE_ID
		//		})
		//	});
		//}
		//Logger.Log(new object[]
		//{
		//	"*Retrieve End."
		//});
		//Logger.Log(new object[]
		//{
		//	"============= CItemStaticManager Debug Log printf End   ============="
		//});
	}

	// Token: 0x0600151D RID: 5405 RVA: 0x000A8488 File Offset: 0x000A6688
	public List<EquipCfgType> GetEquipEnumGroup()
	{
		if (this.EquipCfgIndexGroup.Count <= 0)
		{
			this.EquipCfgIndexGroup.Clear();
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_WEAPON);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_MAGICWEAPON);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_DWEAPON);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_SHOULDER);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_CLOTHES);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_CUFF);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_FOOT);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_RING);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_SHELTER);
			this.EquipCfgIndexGroup.Add(EquipCfgType.EQCHILD_CT_FASHION);
		}
		return this.EquipCfgIndexGroup;
	}

	// Token: 0x0600151E RID: 5406 RVA: 0x000A8538 File Offset: 0x000A6738
	public List<ItemCfgType> GetItemEnumGroup()
	{
		if (this.ItemCfgIndexGroup.Count <= 0)
		{
			this.ItemCfgIndexGroup.Clear();
			this.ItemCfgIndexGroup.Add(ItemCfgType.ITCT_PELLET);
			this.ItemCfgIndexGroup.Add(ItemCfgType.ITCT_STUFF);
			this.ItemCfgIndexGroup.Add(ItemCfgType.ITCT_OTHER);
		}
		return this.ItemCfgIndexGroup;
	}

	// Token: 0x0600151F RID: 5407 RVA: 0x000A858C File Offset: 0x000A678C
	public ItemCfgType GetItemCfgTpyeByID(int id)
	{
		if (id == 1)
		{
			return ItemCfgType.ITCT_EQUIP;
		}
		if (id == 2)
		{
			return ItemCfgType.ITCT_PELLET;
		}
		if (id == 3)
		{
			return ItemCfgType.ITCT_STUFF;
		}
		if (id == 4)
		{
			return ItemCfgType.ITCT_OTHER;
		}
		return ItemCfgType.ITCT_UNKNOWN;
	}

	// Token: 0x06001520 RID: 5408 RVA: 0x000A85B4 File Offset: 0x000A67B4
	public EquipCfgType GetEquipCfgTpyeByID(int childid)
	{
		if (childid == 1)
		{
			return EquipCfgType.EQCHILD_CT_WEAPON;
		}
		if (childid == 2)
		{
			return EquipCfgType.EQCHILD_CT_MAGICWEAPON;
		}
		if (childid == 3)
		{
			return EquipCfgType.EQCHILD_CT_DWEAPON;
		}
		if (childid == 11)
		{
			return EquipCfgType.EQCHILD_CT_SHOULDER;
		}
		if (childid == 12)
		{
			return EquipCfgType.EQCHILD_CT_CLOTHES;
		}
		if (childid == 13)
		{
			return EquipCfgType.EQCHILD_CT_CUFF;
		}
		if (childid == 14)
		{
			return EquipCfgType.EQCHILD_CT_FOOT;
		}
		if (childid == 15)
		{
			return EquipCfgType.EQCHILD_CT_RING;
		}
		if (childid == 21)
		{
			return EquipCfgType.EQCHILD_CT_SHELTER;
		}
		if (childid == 91)
		{
			return EquipCfgType.EQCHILD_CT_FASHION;
		}
		return EquipCfgType.EQCHILD_CT_UNKNOWN;
	}

	// Token: 0x06001521 RID: 5409 RVA: 0x000A862C File Offset: 0x000A682C
	public PelletCfgType GetPelletCfgTpyeByID(int childid)
	{
		if (childid == 1)
		{
			return PelletCfgType.PLCHILD_CT_RECOVER;
		}
		return PelletCfgType.PLCHILD_CT_UNKNOWN;
	}

	// Token: 0x06001522 RID: 5410 RVA: 0x000A8638 File Offset: 0x000A6838
	public StuffCfgType GetStuffCfgTpyeByID(int childid)
	{
		if (childid == 1)
		{
			return StuffCfgType.SFCHILD_CT_WARE;
		}
		if (childid == 2)
		{
			return StuffCfgType.SFCHILD_CT_PLT;
		}
		if (childid == 3)
		{
			return StuffCfgType.SFCHILD_CT_AML;
		}
		return StuffCfgType.SFCHILD_CT_UNKNOWN;
	}

	// Token: 0x06001523 RID: 5411 RVA: 0x000A8658 File Offset: 0x000A6858
	public OtherCfgType GetOtherCfgTpyeByID(int childid)
	{
		if (childid == 1)
		{
			return OtherCfgType.OCCHILD_CT_AMULET;
		}
		if (childid == 2)
		{
			return OtherCfgType.OCCHILD_CT_ANECDOTES;
		}
		if (childid == 3)
		{
			return OtherCfgType.OCCHILD_CT_MISS;
		}
		return OtherCfgType.OCCHILD_CT_UNKNOWN;
	}

	// Token: 0x06001524 RID: 5412 RVA: 0x000A8678 File Offset: 0x000A6878
	public static KeyValuePair<string, string> GetItemAddAttributeName(ITEM_ADD_ATTRIBUTE type)
	{
		string key = string.Empty;
		string value = "%";
		if (type == ITEM_ADD_ATTRIBUTE.IAAT_MAG_REPLY)
		{
			key = "灵力回复增加";
			value = " /ms";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_MAXHP_PERCENT)
		{
			key = "生命上限增加";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_MAXMP_PERCENT)
		{
			key = "灵力上限增加";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_PHYATK_PERCENT)
		{
			key = "物理攻击力提升";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_MAGATK_PERCENT)
		{
			key = "法术攻击力提升";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_PERCENT)
		{
			key = "物理防御力提升";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_PERCENT)
		{
			key = "法术防御力提升";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_PHYDEF_VALUE)
		{
			key = "物理防御力提升";
			value = string.Empty;
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_MAGDEF_VALUE)
		{
			key = "法术防御力提升";
			value = string.Empty;
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_CRITICAL_PERCENT)
		{
			key = "会心值增加";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_PHYHURTLESS_PERCENT)
		{
			key = "物理减伤";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_MAGHURTLESS_PERCENT)
		{
			key = "法术减伤";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_ABSORB_PERCENT)
		{
			key = "吸血";
		}
		else if (type == ITEM_ADD_ATTRIBUTE.IAAT_FEATK_PERCENT)
		{
			key = "伤害增加";
		}
		else
		{
			value = string.Empty;
		}
		return new KeyValuePair<string, string>(key, value);
	}

	// Token: 0x06001525 RID: 5413 RVA: 0x000A87B0 File Offset: 0x000A69B0
	public static string GetItemTypeName(Type type, int value)
	{
		if (type == typeof(ItemCfgType))
		{
			if (value == 1)
			{
				return "装备";
			}
			if (value == 2)
			{
				return "丹药";
			}
			if (value == 3)
			{
				return "材料";
			}
			if (value == 4)
			{
				return "其他";
			}
		}
		else if (type == typeof(EquipCfgType))
		{
			if (value == 1)
			{
				return "装备-重兵";
			}
			if (value == 2)
			{
				return "装备-法器";
			}
			if (value == 3)
			{
				return "装备-双刃";
			}
			if (value == 11)
			{
				return "装备-肩部";
			}
			if (value == 12)
			{
				return "装备-衣服";
			}
			if (value == 13)
			{
				return "装备-护腕";
			}
			if (value == 14)
			{
				return "装备-足履";
			}
			if (value == 15)
			{
				return "装备-戒指";
			}
			if (value == 21)
			{
				return "装备-护符";
			}
			if (value == 91)
			{
				return "装备-时装";
			}
		}
		else if (type == typeof(PelletCfgType))
		{
			if (value == 1)
			{
				return "丹药-恢复";
			}
			if (value == 2)
			{
				return "丹药-攻击";
			}
			if (value == 3)
			{
				return "丹药-防御";
			}
		}
		else if (type == typeof(StuffCfgType))
		{
			if (value == 1)
			{
				return "材料-炼器";
			}
			if (value == 2)
			{
				return "材料-炼丹";
			}
			if (value == 3)
			{
				return "材料-炼符";
			}
		}
		else if (type == typeof(OtherCfgType))
		{
			if (value == 1)
			{
				return "其他-符箓";
			}
			if (value == 2)
			{
				return "其他-轶闻";
			}
			if (value == 3)
			{
				return "其他-剧情";
			}
		}
		return string.Empty;
	}
}
