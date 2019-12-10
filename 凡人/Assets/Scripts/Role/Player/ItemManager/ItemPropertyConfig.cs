using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品属性
/// </summary>
[Serializable]
public class ItemPropertyConfig
{
    private const int TYPE_ID_MIN = 1;

    private const int TYPE_ID_MAX = 9;

    private const int CHILDTYPE_ID_MIN = 1;

    private const int CHILDTYPE_ID_MAX = 99;

    private const int SELF_ID_MIN = 0;

    private const int SELF_ID_MAX = 9999;

    public static int TYPEID_MASK = 100;

    public static int CHILDID_MASK = 10;

    private string strItemTypeName;

    private int nItemTypeID;

    private string strItemChildTypeName;

    private int nItemChildTypeID;

    private ulong ItemID;

    private string strName;

    private string strUnitName;

    private string strDesc;

    private string strIntro;

    private string strSmallIcoPath;

    private string strBigIcoPath;

    private string strPrebPath;

    private string strExtendPropertyPath;

    private int nAttributesCount;

    private Dictionary<ATTRIBUTE_TYPE, float> mapBaseAttributes;

    private int nModelCount;

    private Dictionary<ScrModType, string> mapModels;

    private int nItemAttributesCount;

    private Dictionary<ITEM_ATTRIBUTE_TYPE, float> mapItemAttributes;

    private int nItemAddAttributesCount;

    private Dictionary<ITEM_ADD_ATTRIBUTE, float> mapItemAddAttributes;

    public string ITEM_TYPE_NAME
	{
		get
		{
			return this.strItemTypeName;
		}
		set
		{
			this.strItemTypeName = value;
		}
	}

	public string ITEM_CHILDTYPE_NAME
	{
		get
		{
			return this.strItemChildTypeName;
		}
		set
		{
			this.strItemChildTypeName = value;
		}
	}

	public int ITEM_TYPE_ID
	{
		get
		{
			return this.nItemTypeID;
		}
		set
		{
			if (value < 1 || value > 9)
			{
				Debug.LogWarning("ItemPropertyConfig: Property file try set overstep,Code :" + value.ToString());
			}
			this.nItemTypeID = value;
		}
	}

	public int ITEM_CHILDTYPE_ID
	{
		get
		{
			return this.nItemChildTypeID;
		}
		set
		{
			if (value < 1 || value > 99)
			{
				Debug.LogWarning("ItemPropertyConfig: Property file try set overstep,Code :" + value.ToString());
			}
			this.nItemChildTypeID = value;
		}
	}

	public ulong ITEM_STATIC_ID
	{
		get
		{
			return this.ItemID;
		}
		set
		{
			this.ItemID = value;
		}
	}

	public string ITEM_NAME
	{
		get
		{
			return this.strName;
		}
		set
		{
			this.strName = value;
		}
	}

	public string ITEM_UNITNAME
	{
		get
		{
			return this.strUnitName;
		}
		set
		{
			this.strUnitName = value;
		}
	}

	public string ITEM_DESC
	{
		get
		{
			return this.strDesc;
		}
		set
		{
			this.strDesc = value;
		}
	}

	public string ITEM_INTRO
	{
		get
		{
			return this.strIntro;
		}
		set
		{
			this.strIntro = value;
		}
	}

	public string ITEM_ICOPATH_SMALL
	{
		get
		{
			return this.strSmallIcoPath;
		}
		set
		{
			this.strSmallIcoPath = value;
		}
	}

	public string ITEM_ICOPATH_BIG
	{
		get
		{
			return this.strBigIcoPath;
		}
		set
		{
			this.strBigIcoPath = value;
		}
	}

	public string ITEM_RES_PREB
	{
		get
		{
			return this.strPrebPath;
		}
		set
		{
			this.strPrebPath = value;
		}
	}

	public string ITEM_EXTEND_PROPERTY
	{
		get
		{
			return this.strExtendPropertyPath;
		}
		set
		{
			this.strExtendPropertyPath = value;
		}
	}

	public int ITEM_ATTRIBUTE_COUNT
	{
		get
		{
			return this.nAttributesCount;
		}
		set
		{
			this.nAttributesCount = value;
		}
	}

	public Dictionary<ATTRIBUTE_TYPE, float> ITEM_ATTRIBUTES_MAP
	{
		get
		{
			if (this.mapBaseAttributes == null)
			{
				this.mapBaseAttributes = new Dictionary<ATTRIBUTE_TYPE, float>();
			}
			return this.mapBaseAttributes;
		}
		set
		{
			this.mapBaseAttributes = value;
		}
	}

	public int ITEM_ADDATTRIBUTES_COUNT
	{
		get
		{
			return this.nItemAddAttributesCount;
		}
		set
		{
			this.nItemAddAttributesCount = value;
		}
	}

	public Dictionary<ITEM_ADD_ATTRIBUTE, float> ITEM_ADDATTRIBUTES_MAP
	{
		get
		{
			if (this.mapItemAddAttributes == null)
			{
				this.mapItemAddAttributes = new Dictionary<ITEM_ADD_ATTRIBUTE, float>();
			}
			return this.mapItemAddAttributes;
		}
		set
		{
			this.mapItemAddAttributes = value;
		}
	}

	public int ITEM_TO_MODEL_COUNT
	{
		get
		{
			return this.nModelCount;
		}
		set
		{
			this.nModelCount = value;
		}
	}

	public Dictionary<ScrModType, string> ITEM_TO_MODELS
	{
		get
		{
			if (this.mapModels == null)
			{
				this.mapModels = new Dictionary<ScrModType, string>();
			}
			return this.mapModels;
		}
		set
		{
			this.mapModels = value;
		}
	}

	public int ITEM_ITEMATT_COUNT
	{
		get
		{
			return this.nItemAttributesCount;
		}
		set
		{
			this.nItemAttributesCount = value;
		}
	}

	public Dictionary<ITEM_ATTRIBUTE_TYPE, float> ITEM_ITEMATT_MAP
	{
		get
		{
			if (this.mapItemAttributes == null)
			{
				this.mapItemAttributes = new Dictionary<ITEM_ATTRIBUTE_TYPE, float>();
			}
			return this.mapItemAttributes;
		}
		set
		{
			this.mapItemAttributes = value;
		}
	}

	public ItemPropertyConfig Clone()
	{
		return (ItemPropertyConfig)base.MemberwiseClone();
	}
}
