using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemPropertyConfig
{
    private const int TYPE_ID_MIN = 1;

    // Token: 0x0400150C RID: 5388
    private const int TYPE_ID_MAX = 9;

    // Token: 0x0400150D RID: 5389
    private const int CHILDTYPE_ID_MIN = 1;

    // Token: 0x0400150E RID: 5390
    private const int CHILDTYPE_ID_MAX = 99;

    // Token: 0x0400150F RID: 5391
    private const int SELF_ID_MIN = 0;

    // Token: 0x04001510 RID: 5392
    private const int SELF_ID_MAX = 9999;

    // Token: 0x04001511 RID: 5393
    public static int TYPEID_MASK = 100;

    // Token: 0x04001512 RID: 5394
    public static int CHILDID_MASK = 10;

    // Token: 0x04001513 RID: 5395
    private string strItemTypeName;

    // Token: 0x04001514 RID: 5396
    private int nItemTypeID;

    // Token: 0x04001515 RID: 5397
    private string strItemChildTypeName;

    // Token: 0x04001516 RID: 5398
    private int nItemChildTypeID;

    // Token: 0x04001517 RID: 5399
    private ulong ItemID;

    // Token: 0x04001518 RID: 5400
    private string strName;

    // Token: 0x04001519 RID: 5401
    private string strUnitName;

    // Token: 0x0400151A RID: 5402
    private string strDesc;

    // Token: 0x0400151B RID: 5403
    private string strIntro;

    // Token: 0x0400151C RID: 5404
    private string strSmallIcoPath;

    // Token: 0x0400151D RID: 5405
    private string strBigIcoPath;

    // Token: 0x0400151E RID: 5406
    private string strPrebPath;

    // Token: 0x0400151F RID: 5407
    private string strExtendPropertyPath;

    // Token: 0x04001520 RID: 5408
    private int nAttributesCount;

    // Token: 0x04001521 RID: 5409
    private Dictionary<ATTRIBUTE_TYPE, float> mapBaseAttributes;

    // Token: 0x04001522 RID: 5410
    private int nModelCount;

    // Token: 0x04001523 RID: 5411
    private Dictionary<ScrModType, string> mapModels;

    // Token: 0x04001524 RID: 5412
    private int nItemAttributesCount;

    // Token: 0x04001525 RID: 5413
    private Dictionary<ITEM_ATTRIBUTE_TYPE, float> mapItemAttributes;

    // Token: 0x04001526 RID: 5414
    private int nItemAddAttributesCount;

    // Token: 0x04001527 RID: 5415
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

	// Token: 0x17000247 RID: 583
	// (get) Token: 0x060014D8 RID: 5336 RVA: 0x000A7188 File Offset: 0x000A5388
	// (set) Token: 0x060014D9 RID: 5337 RVA: 0x000A7190 File Offset: 0x000A5390
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

	// Token: 0x17000248 RID: 584
	// (get) Token: 0x060014DA RID: 5338 RVA: 0x000A719C File Offset: 0x000A539C
	// (set) Token: 0x060014DB RID: 5339 RVA: 0x000A71A4 File Offset: 0x000A53A4
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

	// Token: 0x17000249 RID: 585
	// (get) Token: 0x060014DC RID: 5340 RVA: 0x000A71E0 File Offset: 0x000A53E0
	// (set) Token: 0x060014DD RID: 5341 RVA: 0x000A71E8 File Offset: 0x000A53E8
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

	// Token: 0x1700024A RID: 586
	// (get) Token: 0x060014DF RID: 5343 RVA: 0x000A7230 File Offset: 0x000A5430
	// (set) Token: 0x060014DE RID: 5342 RVA: 0x000A7224 File Offset: 0x000A5424
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

	// Token: 0x1700024B RID: 587
	// (get) Token: 0x060014E0 RID: 5344 RVA: 0x000A7238 File Offset: 0x000A5438
	// (set) Token: 0x060014E1 RID: 5345 RVA: 0x000A7240 File Offset: 0x000A5440
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

	// Token: 0x1700024C RID: 588
	// (get) Token: 0x060014E2 RID: 5346 RVA: 0x000A724C File Offset: 0x000A544C
	// (set) Token: 0x060014E3 RID: 5347 RVA: 0x000A7254 File Offset: 0x000A5454
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

	// Token: 0x1700024D RID: 589
	// (get) Token: 0x060014E4 RID: 5348 RVA: 0x000A7260 File Offset: 0x000A5460
	// (set) Token: 0x060014E5 RID: 5349 RVA: 0x000A7268 File Offset: 0x000A5468
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

	// Token: 0x1700024E RID: 590
	// (get) Token: 0x060014E6 RID: 5350 RVA: 0x000A7274 File Offset: 0x000A5474
	// (set) Token: 0x060014E7 RID: 5351 RVA: 0x000A727C File Offset: 0x000A547C
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

	// Token: 0x1700024F RID: 591
	// (get) Token: 0x060014E8 RID: 5352 RVA: 0x000A7288 File Offset: 0x000A5488
	// (set) Token: 0x060014E9 RID: 5353 RVA: 0x000A7290 File Offset: 0x000A5490
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

	// Token: 0x17000250 RID: 592
	// (get) Token: 0x060014EA RID: 5354 RVA: 0x000A729C File Offset: 0x000A549C
	// (set) Token: 0x060014EB RID: 5355 RVA: 0x000A72A4 File Offset: 0x000A54A4
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

	// Token: 0x17000251 RID: 593
	// (get) Token: 0x060014EC RID: 5356 RVA: 0x000A72B0 File Offset: 0x000A54B0
	// (set) Token: 0x060014ED RID: 5357 RVA: 0x000A72B8 File Offset: 0x000A54B8
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

	// Token: 0x17000252 RID: 594
	// (get) Token: 0x060014EE RID: 5358 RVA: 0x000A72C4 File Offset: 0x000A54C4
	// (set) Token: 0x060014EF RID: 5359 RVA: 0x000A72CC File Offset: 0x000A54CC
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

	// Token: 0x17000253 RID: 595
	// (get) Token: 0x060014F0 RID: 5360 RVA: 0x000A72D8 File Offset: 0x000A54D8
	// (set) Token: 0x060014F1 RID: 5361 RVA: 0x000A72E0 File Offset: 0x000A54E0
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

	// Token: 0x17000254 RID: 596
	// (get) Token: 0x060014F2 RID: 5362 RVA: 0x000A72EC File Offset: 0x000A54EC
	// (set) Token: 0x060014F3 RID: 5363 RVA: 0x000A730C File Offset: 0x000A550C
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

	// Token: 0x17000255 RID: 597
	// (get) Token: 0x060014F4 RID: 5364 RVA: 0x000A7318 File Offset: 0x000A5518
	// (set) Token: 0x060014F5 RID: 5365 RVA: 0x000A7320 File Offset: 0x000A5520
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

	// Token: 0x17000256 RID: 598
	// (get) Token: 0x060014F6 RID: 5366 RVA: 0x000A732C File Offset: 0x000A552C
	// (set) Token: 0x060014F7 RID: 5367 RVA: 0x000A734C File Offset: 0x000A554C
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

	// Token: 0x17000257 RID: 599
	// (get) Token: 0x060014F8 RID: 5368 RVA: 0x000A7358 File Offset: 0x000A5558
	// (set) Token: 0x060014F9 RID: 5369 RVA: 0x000A7360 File Offset: 0x000A5560
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

	// Token: 0x17000258 RID: 600
	// (get) Token: 0x060014FA RID: 5370 RVA: 0x000A736C File Offset: 0x000A556C
	// (set) Token: 0x060014FB RID: 5371 RVA: 0x000A738C File Offset: 0x000A558C
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

	// Token: 0x17000259 RID: 601
	// (get) Token: 0x060014FC RID: 5372 RVA: 0x000A7398 File Offset: 0x000A5598
	// (set) Token: 0x060014FD RID: 5373 RVA: 0x000A73A0 File Offset: 0x000A55A0
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

	// Token: 0x1700025A RID: 602
	// (get) Token: 0x060014FE RID: 5374 RVA: 0x000A73AC File Offset: 0x000A55AC
	// (set) Token: 0x060014FF RID: 5375 RVA: 0x000A73CC File Offset: 0x000A55CC
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

	// Token: 0x06001500 RID: 5376 RVA: 0x000A73D8 File Offset: 0x000A55D8
	public ItemPropertyConfig Clone()
	{
		return (ItemPropertyConfig)base.MemberwiseClone();
	}
}
