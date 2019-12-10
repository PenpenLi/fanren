using System;

/// <summary>
/// 穿戴物品基类
/// </summary>
public class CItemBase
{
    private ItemPropertyConfig _pOriginalData = new ItemPropertyConfig();

    private ItemPropertyConfig _pDynamicData = new ItemPropertyConfig();

    private ulong _RealID;

    private bool _IsUsed;

    private bool _IsNew = true;

    private ItemOwner _pItemOwner;

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

    /// <summary>
    /// 拥有者
    /// </summary>
    public ItemOwner Owner
    {
        get
        {
            return this._pItemOwner;
        }
        set
        {
            this._pItemOwner = value;
        }
    }

    /// <summary>
    /// 原始数据
    /// </summary>
    public ItemPropertyConfig OriginalData
    {
        get
        {
            return this._pOriginalData;
        }
        set
        {
            this._pOriginalData = value;
        }
    }

    public ItemPropertyConfig DynamicData
    {
        get
        {
            return this._pDynamicData;
        }
        set
        {
            this._pDynamicData = value;
        }
    }

    public string Name
    {
        get
        {
            return this._pDynamicData.ITEM_NAME;
        }
        set
        {
            this._pDynamicData.ITEM_NAME = value;
        }
    }

    public int TYPE_ID
    {
        get
        {
            return this._pDynamicData.ITEM_TYPE_ID;
        }
        set
        {
            this._pDynamicData.ITEM_TYPE_ID = value;
        }
    }

    public int CHILD_TYPE_ID
    {
        get
        {
            return this._pDynamicData.ITEM_CHILDTYPE_ID;
        }
        set
        {
            this._pDynamicData.ITEM_CHILDTYPE_ID = value;
        }
    }

    public ulong ITEM_STATIC_ID
    {
        get
        {
            return this._pDynamicData.ITEM_STATIC_ID;
        }
    }

    public ulong ID
    {
        get
        {
            return this._RealID;
        }
    }

    public bool IS_USED
    {
        get
        {
            return this._IsUsed;
        }
        set
        {
            this._IsUsed = value;
        }
    }

    public bool IS_NEW
    {
        get
        {
            return this._IsNew;
        }
        set
        {
            this._IsNew = value;
        }
    }

    public string Desc
    {
        get
        {
            return this._pDynamicData.ITEM_DESC;
        }
        set
        {
            this._pDynamicData.ITEM_DESC = value;
        }
    }

    public string BigIco
    {
        get
        {
            return this._pDynamicData.ITEM_ICOPATH_BIG;
        }
        set
        {
            this._pDynamicData.ITEM_ICOPATH_BIG = value;
        }
    }

    public string SmallIco
    {
        get
        {
            return this._pDynamicData.ITEM_ICOPATH_SMALL;
        }
        set
        {
            this._pDynamicData.ITEM_ICOPATH_SMALL = value;
        }
    }

    public string Intro
    {
        get
        {
            return this._pDynamicData.ITEM_INTRO;
        }
        set
        {
            this._pDynamicData.ITEM_INTRO = value;
        }
    }

    public int SmartDynamicID
    {
        set
        {
            ulong realID = 0UL;
            if (ulong.TryParse(this._pDynamicData.ITEM_STATIC_ID.ToString() + value.ToString(), out realID))
            {
                this._RealID = realID;
            }
        }
    }

    public virtual ItemSaveData GetItemSaveData()
    {
        return new ItemSaveData
        {
            itemOwner = this.Owner,
            IsUsed = this.IS_USED,
            itemType = this.OriginalData.ITEM_STATIC_ID,
            dynamicProperty = this.DynamicData,
            IsReserveWeapon = false
        };
    }

    public virtual void SetItemFromSaveData(ItemSaveData isd)
    {
        this.Owner = isd.itemOwner;
        this.IS_USED = isd.IsUsed;
        this.OriginalData.ITEM_STATIC_ID = isd.itemType;
        this.DynamicData = isd.dynamicProperty;
    }
}
