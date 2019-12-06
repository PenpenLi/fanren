using System;
using System.Collections.Generic;

// Token: 0x02000180 RID: 384
[Serializable]
public class ItemSaveData
{
	//public void PrintDate()
	//{
	//	Logger.Log(new object[]
	//	{
	//		string.Concat(new object[]
	//		{
	//			"************ item info:",
	//			this.itemType,
	//			",itemOwner:",
	//			this.itemOwner,
	//			" *****************"
	//		})
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strItemTypeName:" + this.dynamicProperty.ITEM_TYPE_NAME
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strItemChildTypeName:" + this.dynamicProperty.ITEM_CHILDTYPE_NAME
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"nItemChildTypeID:" + this.dynamicProperty.ITEM_CHILDTYPE_ID
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"ItemID:" + this.dynamicProperty.ITEM_STATIC_ID
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strName:" + this.dynamicProperty.ITEM_NAME
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strUnitName:" + this.dynamicProperty.ITEM_UNITNAME
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strDesc:" + this.dynamicProperty.ITEM_DESC
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strIntro:" + this.dynamicProperty.ITEM_INTRO
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strSmallIcoPath:" + this.dynamicProperty.ITEM_ICOPATH_SMALL
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strBigIcoPath:" + this.dynamicProperty.ITEM_ICOPATH_BIG
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strPrebPath:" + this.dynamicProperty.ITEM_RES_PREB
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"strExtendPropertyPath:" + this.dynamicProperty.ITEM_EXTEND_PROPERTY
	//	});
	//	Logger.Log(new object[]
	//	{
	//		"nAttributesCount:" + this.dynamicProperty.ITEM_ATTRIBUTE_COUNT
	//	});
	//	foreach (KeyValuePair<ATTRIBUTE_TYPE, float> keyValuePair in this.dynamicProperty.ITEM_ATTRIBUTES_MAP)
	//	{
	//		Logger.Log(new object[]
	//		{
	//			string.Concat(new object[]
	//			{
	//				"BaseAtt:",
	//				keyValuePair.Key,
	//				"-",
	//				keyValuePair.Value
	//			})
	//		});
	//	}
	//	Logger.Log(new object[]
	//	{
	//		"nModelCount:" + this.dynamicProperty.ITEM_TO_MODEL_COUNT
	//	});
	//	foreach (KeyValuePair<ScrModType, string> keyValuePair2 in this.dynamicProperty.ITEM_TO_MODELS)
	//	{
	//		Logger.Log(new object[]
	//		{
	//			string.Concat(new object[]
	//			{
	//				"Models:",
	//				keyValuePair2.Key,
	//				"-",
	//				keyValuePair2.Value
	//			})
	//		});
	//	}
	//	Logger.Log(new object[]
	//	{
	//		"nItemAttributesCount:" + this.dynamicProperty.ITEM_ITEMATT_COUNT
	//	});
	//	foreach (KeyValuePair<ITEM_ATTRIBUTE_TYPE, float> keyValuePair3 in this.dynamicProperty.ITEM_ITEMATT_MAP)
	//	{
	//		Logger.Log(new object[]
	//		{
	//			string.Concat(new object[]
	//			{
	//				"ItemAttr:",
	//				keyValuePair3.Key,
	//				"-",
	//				keyValuePair3.Value
	//			})
	//		});
	//	}
	//	Logger.Log(new object[]
	//	{
	//		"nItemAddAttributesCount:" + this.dynamicProperty.ITEM_ADDATTRIBUTES_COUNT
	//	});
	//	foreach (KeyValuePair<ITEM_ADD_ATTRIBUTE, float> keyValuePair4 in this.dynamicProperty.ITEM_ADDATTRIBUTES_MAP)
	//	{
	//		Logger.Log(new object[]
	//		{
	//			string.Concat(new object[]
	//			{
	//				"ItemAddAttr:",
	//				keyValuePair4.Key,
	//				"-",
	//				keyValuePair4.Value
	//			})
	//		});
	//	}
	//	Logger.Log(new object[]
	//	{
	//		"************ item info end ************************"
	//	});
	//}

	// Token: 0x0400066C RID: 1644
	public ItemOwner itemOwner;

	// Token: 0x0400066D RID: 1645
	public ulong itemType;

	// Token: 0x0400066E RID: 1646
	public ItemPropertyConfig dynamicProperty;

	// Token: 0x0400066F RID: 1647
	public bool IsUsed;

	// Token: 0x04000670 RID: 1648
	public bool IsReserveWeapon;
}
