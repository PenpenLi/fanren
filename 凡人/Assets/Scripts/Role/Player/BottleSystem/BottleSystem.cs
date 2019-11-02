using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

/// <summary>
/// 瓶子系统
/// </summary>
public class BottleSystem
{
    public const string BottleSubTagConfig = "BottleSubTag";

    public const string BottleConfig = "BottleConfig";

    public const int MaxDstFix = 5;

    private const float DeltaTimeSpawnIchor = 1800f;

    private const int DeltaAddIchor = 1;

    private int m_LingyeNum;

    private Dictionary<ulong, BottleSystem.BottleElement> m_BottleData = new Dictionary<ulong, BottleSystem.BottleElement>();

    private List<BottleSystem.BottleSubTag> m_BottleTags = new List<BottleSystem.BottleSubTag>();

    private float m_LeftTime = 1800f;

    public int LingyeNum
	{
		get
		{
			return this.m_LingyeNum;
		}
		set
		{
			this.m_LingyeNum = value;
		}
	}

	public bool LoadConfig()
	{
		List<string> list = RoleBaseFun.LoadConfInAssets("BottleSubTag");
		if (list == null || list.Count <= 0)
		{
			Debug.LogWarning("BottleConfig config  no found!");
			return false;
		}
		this.m_BottleTags.Clear();
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			if (array != null)
			{
				List<string> list2 = new List<string>();
				foreach (string text2 in array)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						list2.Add(text2);
					}
				}
				if (list2 != null && list2.Count >= 3)
				{
					int num = 0;
					BottleSystem.BottleSubTag bottleSubTag = new BottleSystem.BottleSubTag();
					bottleSubTag.UIPos = Convert.ToInt32(list2[num]);
					num++;
					bottleSubTag.UISubPos = Convert.ToInt32(list2[num]);
					num++;
					bottleSubTag.SubTagName = list2[num];
					num++;
					this.m_BottleTags.Add(bottleSubTag);
				}
			}
		}
		list = RoleBaseFun.LoadConfInAssets("BottleConfig");
		if (list == null || list.Count <= 0)
		{
			Debug.LogWarning("Compose config  no found!");
			return false;
		}
		this.m_BottleData.Clear();
		foreach (string text3 in list)
		{
			string[] array3 = text3.Split(CacheData.separator);
			if (array3 != null)
			{
				List<string> list3 = new List<string>();
				foreach (string text4 in array3)
				{
					if (!string.IsNullOrEmpty(text4))
					{
						list3.Add(text4);
					}
				}
				if (list3 != null && list3.Count >= 38)
				{
					int num = 0;
					BottleSystem.BottleElement bottleElement = new BottleSystem.BottleElement();
					bottleElement.UIPos = Convert.ToInt32(list3[num]);
					num++;
					bottleElement.UISubPos = Convert.ToInt32(list3[num]);
					num++;
					bottleElement.SrcId = Convert.ToUInt64(list3[num]);
					num++;
					bottleElement.SrcNum = Convert.ToInt32(list3[num]);
					num++;
					bottleElement.IchorNum = Convert.ToInt32(list3[num]);
					num++;
					for (int k = 0; k < 5; k++)
					{
						bottleElement.DstFixIds[k] = Convert.ToUInt64(list3[num]);
						num++;
						bottleElement.DstFixNums[k] = Convert.ToInt32(list3[num]);
						num++;
					}
					for (int l = 0; l < 8; l++)
					{
						bottleElement.DstUnfixIds[l] = Convert.ToUInt64(list3[num]);
						num++;
						bottleElement.DstUnfixNums[l] = Convert.ToInt32(list3[num]);
						num++;
						bottleElement.DstUnfixRate[l] = Convert.ToSingle(list3[num]);
						num++;
					}
					this.m_BottleData.Add(bottleElement.SrcId, bottleElement);
				}
			}
		}
		return true;
	}

	public string GetSubTagName(int uipos, int uisubpos)
	{
		string result = null;
		foreach (BottleSystem.BottleSubTag bottleSubTag in this.m_BottleTags)
		{
			if (bottleSubTag.UIPos == uipos && bottleSubTag.UISubPos == uisubpos)
			{
				result = bottleSubTag.SubTagName;
			}
		}
		return result;
	}

	// Token: 0x06001E88 RID: 7816 RVA: 0x000D3B0C File Offset: 0x000D1D0C
	public List<BottleSystem.BottleElement> GetListElement(int uipos, int uisubpos)
	{
		List<BottleSystem.BottleElement> list = new List<BottleSystem.BottleElement>();
		foreach (KeyValuePair<ulong, BottleSystem.BottleElement> keyValuePair in this.m_BottleData)
		{
			if (keyValuePair.Value.UIPos == uipos && keyValuePair.Value.UISubPos == uisubpos)
			{
				list.Add(keyValuePair.Value);
			}
		}
		return list;
	}

	// Token: 0x06001E89 RID: 7817 RVA: 0x000D3BA4 File Offset: 0x000D1DA4
	public List<BottleSystem.BottleElement> GetListElementEx(int uipos)
	{
		List<BottleSystem.BottleElement> list = new List<BottleSystem.BottleElement>();
		foreach (KeyValuePair<ulong, BottleSystem.BottleElement> keyValuePair in this.m_BottleData)
		{
			if (keyValuePair.Value.UIPos == uipos)
			{
				list.Add(keyValuePair.Value);
			}
		}
		return list;
	}

	// Token: 0x06001E8A RID: 7818 RVA: 0x000D3C2C File Offset: 0x000D1E2C
	public BottleSystem.BottleElement GetElement(ulong id)
	{
		foreach (KeyValuePair<ulong, BottleSystem.BottleElement> keyValuePair in this.m_BottleData)
		{
			if (keyValuePair.Key == id)
			{
				return keyValuePair.Value;
			}
		}
		return null;
	}

	// Token: 0x06001E8B RID: 7819 RVA: 0x000D3CA8 File Offset: 0x000D1EA8
	public void PushSDData(BottleSystem.BottleSaveData data)
	{
		if (data == null)
		{
			Debug.LogError("PushSDData failed!");
			return;
		}
		this.m_LingyeNum = data.m_LingyeNum;
		this.m_LeftTime = data.m_LeftTime;
	}

	// Token: 0x06001E8C RID: 7820 RVA: 0x000D3CD4 File Offset: 0x000D1ED4
	public void Update()
	{
		//if (this.m_LeftTime < 0f)
		//{
		//	this.m_LeftTime = 1800f;
		//	this.m_LingyeNum++;
		//	Singleton<EZGUIManager>.GetInstance().GetGUI<GreenBottle>().UpdateLingye(0f);
		//}
		//else
		//{
		//	Singleton<EZGUIManager>.GetInstance().GetGUI<GreenBottle>().UpdateLingye(this.m_LeftTime);
		//	this.m_LeftTime -= Time.deltaTime;
		//}
	}

	public class BottleElement
	{
		public int UIPos
		{
			get
			{
				return this.m_UIPos;
			}
			set
			{
				this.m_UIPos = value;
			}
		}

		public int UISubPos
		{
			get
			{
				return this.m_UISubPos;
			}
			set
			{
				this.m_UISubPos = value;
			}
		}

		public ulong SrcId
		{
			get
			{
				return this.m_SrcId;
			}
			set
			{
				this.m_SrcId = value;
			}
		}

		public int SrcNum
		{
			get
			{
				return this.m_SrcNum;
			}
			set
			{
				this.m_SrcNum = value;
			}
		}

		public int IchorNum
		{
			get
			{
				return this.m_IchorNum;
			}
			set
			{
				this.m_IchorNum = value;
			}
		}

		public ulong[] DstFixIds
		{
			get
			{
				return this.m_DstFixIds;
			}
			set
			{
				this.m_DstFixIds = value;
			}
		}

		public int[] DstFixNums
		{
			get
			{
				return this.m_DstFixNums;
			}
			set
			{
				this.m_DstFixNums = value;
			}
		}

		public ulong[] DstUnfixIds
		{
			get
			{
				return this.m_DstUnfixIds;
			}
			set
			{
				this.m_DstUnfixIds = value;
			}
		}

		public int[] DstUnfixNums
		{
			get
			{
				return this.m_DstUnfixNums;
			}
			set
			{
				this.m_DstUnfixNums = value;
			}
		}

		public float[] DstUnfixRate
		{
			get
			{
				return this.m_DstUnfixRate;
			}
			set
			{
				this.m_DstUnfixRate = value;
			}
		}

		public bool ComposeFix(int dstPos, int rate, out ulong resultID)
		{
			resultID = this.m_DstFixIds[dstPos];
			if (dstPos < 0 || dstPos > 4)
			{
				return false;
			}
			if (rate < 1)
			{
				return false;
			}
			//if (MixtureSmelt.GetPropCount(this.m_SrcId) < rate * this.m_SrcNum || Player.Instance.m_BottleSystem.LingyeNum < rate * this.m_IchorNum)
			//{
			//	return false;
			//}
			//if (!GameData.Instance.ItemMan.CreateItem(this.m_DstFixIds[dstPos], this.m_DstFixNums[dstPos] * rate, ItemOwner.ITO_HEROFOLDER))
			//{
			//	Debug.LogWarning(DU.Warning(new object[]
			//	{
			//		"mixture CreateItem prop failed ! id=" + this.m_DstFixIds[dstPos]
			//	}));
			//	return false;
			//}
			Player.Instance.m_BottleSystem.LingyeNum -= this.m_IchorNum * rate;
			this.RemoveItem(this.m_SrcId, this.m_SrcNum * rate);
			return true;
		}

		// Token: 0x06001EA3 RID: 7843 RVA: 0x000D3F54 File Offset: 0x000D2154
		public bool RemoveItem(ulong staticid, int cnt)
		{
			int i = 0;
			while (i < cnt)
			{
				bool flag = false;
				//foreach (KeyValuePair<ulong, CItemBase> keyValuePair in Player.Instance.ItemFolder.FolderData())
				//{
				//	if (keyValuePair.Value.ITEM_STATIC_ID == staticid)
				//	{
				//		if (!GameData.Instance.ItemMan.RemoveItemByID(keyValuePair.Key))
				//		{
				//			Debug.LogWarning("mixture del prop failed ! id=" + keyValuePair.Key);
				//		}
				//		i++;
				//		flag = true;
				//		break;
				//	}
				//}
				if (!flag)
				{
					break;
				}
			}
			return i == cnt;
		}

		//public bool ComposeUnfix(out ulong resultID)
		//{
		//	//if (MixtureSmelt.GetPropCount(this.m_SrcId) < this.m_SrcNum || Player.Instance.m_BottleSystem.LingyeNum < this.m_IchorNum + 1)
		//	//{
		//	//	resultID = 0UL;
		//	//	return false;
		//	//}
		//	//int num = BottleSystem.BottleElement.Choose(this.m_DstUnfixRate);
		//	//resultID = this.m_DstUnfixIds[num];
		//	//if (num < 0)
		//	//{
		//	//	Debug.LogWarning(DU.Warning(new object[]
		//	//	{
		//	//		num
		//	//	}));
		//	//	return false;
		//	//}
		//	//if (!GameData.Instance.ItemMan.CreateItem(this.m_DstUnfixIds[num], this.m_DstUnfixNums[num], ItemOwner.ITO_HEROFOLDER))
		//	//{
		//	//	Debug.LogWarning(DU.Warning(new object[]
		//	//	{
		//	//		"mixture CreateItem prop failed ! id=" + this.m_DstUnfixIds[num]
		//	//	}));
		//	//	return false;
		//	//}
		//	Player.Instance.m_BottleSystem.LingyeNum -= this.m_IchorNum + 1;
		//	this.RemoveItem(this.m_SrcId, this.m_SrcNum);
		//	return true;
		//}

		private static int Choose(float[] src)
		{
			if (src == null || src.Length < 1)
			{
				return -1;
			}
			float[] array = new float[src.Length];
			float num = 0f;
			for (int i = 0; i < src.Length; i++)
			{
				num += src[i];
			}
			if (num <= 0f)
			{
				return 0;
			}
			array[0] = src[0] / num;
			for (int j = 1; j < src.Length - 1; j++)
			{
				array[j] = array[j - 1] + src[j] / num;
			}
			array[src.Length - 1] = 1f;
			float num2 = UnityEngine.Random.Range(0f, 1f);
			for (int k = 0; k < src.Length; k++)
			{
				if (num2 <= array[k])
				{
					return k;
				}
			}
			return -2;
		}

		// Token: 0x04001B68 RID: 7016
		private int m_UIPos;

		// Token: 0x04001B69 RID: 7017
		private int m_UISubPos;

		// Token: 0x04001B6A RID: 7018
		private ulong m_SrcId;

		// Token: 0x04001B6B RID: 7019
		private int m_SrcNum;

		// Token: 0x04001B6C RID: 7020
		private int m_IchorNum;

		// Token: 0x04001B6D RID: 7021
		private ulong[] m_DstFixIds = new ulong[5];

		// Token: 0x04001B6E RID: 7022
		private int[] m_DstFixNums = new int[5];

		// Token: 0x04001B6F RID: 7023
		private ulong[] m_DstUnfixIds = new ulong[8];

		// Token: 0x04001B70 RID: 7024
		private int[] m_DstUnfixNums = new int[8];

		// Token: 0x04001B71 RID: 7025
		private float[] m_DstUnfixRate = new float[8];
	}

	// Token: 0x02000493 RID: 1171
	public class BottleSubTag
	{
		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06001EA7 RID: 7847 RVA: 0x000D4200 File Offset: 0x000D2400
		// (set) Token: 0x06001EA8 RID: 7848 RVA: 0x000D4208 File Offset: 0x000D2408
		public int UIPos
		{
			get
			{
				return this.m_UIPos;
			}
			set
			{
				this.m_UIPos = value;
			}
		}

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06001EA9 RID: 7849 RVA: 0x000D4214 File Offset: 0x000D2414
		// (set) Token: 0x06001EAA RID: 7850 RVA: 0x000D421C File Offset: 0x000D241C
		public int UISubPos
		{
			get
			{
				return this.m_UISubPos;
			}
			set
			{
				this.m_UISubPos = value;
			}
		}

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06001EAB RID: 7851 RVA: 0x000D4228 File Offset: 0x000D2428
		// (set) Token: 0x06001EAC RID: 7852 RVA: 0x000D4230 File Offset: 0x000D2430
		public string SubTagName
		{
			get
			{
				return this.m_SubTagName;
			}
			set
			{
				this.m_SubTagName = value;
			}
		}

		// Token: 0x04001B72 RID: 7026
		private int m_UIPos;

		// Token: 0x04001B73 RID: 7027
		private int m_UISubPos;

		// Token: 0x04001B74 RID: 7028
		private string m_SubTagName;
	}

	// Token: 0x02000494 RID: 1172
	[Serializable]
	public class BottleSaveData
	{
		// Token: 0x06001EAE RID: 7854 RVA: 0x000D4250 File Offset: 0x000D2450
		public static BottleSystem.BottleSaveData GetData(Player player)
		{
			if (player == null)
			{
				return null;
			}
			return new BottleSystem.BottleSaveData
			{
				m_LingyeNum = player.m_BottleSystem.m_LingyeNum,
				m_LeftTime = player.m_BottleSystem.m_LeftTime
			};
		}

		// Token: 0x04001B75 RID: 7029
		public int m_LingyeNum;

		// Token: 0x04001B76 RID: 7030
		public float m_LeftTime = 1800f;
	}
}
