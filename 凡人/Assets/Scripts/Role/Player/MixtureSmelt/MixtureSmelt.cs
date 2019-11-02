using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

/// <summary>
/// 合成系统
/// </summary>
public class MixtureSmelt
{
    private const string ABILITY_CFG_PATH = "MixtureElements";

    public const int MsgDanOpen = 1000;

    public const int MsgFuOpen = 2000;

    public const int MsgFuYingke = 2002;

    public const int MsgFuJinzhuan = 2003;

    public const int MsgQiOpen = 3000;

    public const int MsgQi3 = 3003;

    public const int MsgQi4 = 3004;

    public const int MsgQi5 = 3005;

    public const int MsgQi6 = 3006;

    public Dictionary<ulong, MixtureSmelt.AbilityData> AbilityDatas = new Dictionary<ulong, MixtureSmelt.AbilityData>();

    public List<MixtureSmelt.MixtureAbility> MixtureDatas = new List<MixtureSmelt.MixtureAbility>();

    public MixtureSmelt.MianLock m_MianLock = new MixtureSmelt.MianLock();

    private List<int> StuffToProductByAbilityCnts;

    public void ClearMixtureSmelt()
	{
		this.MixtureDatas.Clear();
		this.AbilityDatas.Clear();
	}

	public List<MixtureSmelt.StuffData> GetAbilityStuffs(MixtureSmelt.MixtureAbility mixtureAbility)
	{
		ulong id = mixtureAbility.ID;
		int number = mixtureAbility.Number;
		MixtureSmelt.AbilityData abilityData = this.GetAbilityData(id);
		if (abilityData == null || number > abilityData._Stuffs.Count)
		{
			return null;
		}
		return abilityData._Stuffs[number - 1].Stuffs;
	}

	public MixtureSmelt.AbilityData GetAbilityData(ulong id)
	{
		if (!this.AbilityDatas.ContainsKey(id))
		{
			return null;
		}
		return this.AbilityDatas[id];
	}

	public MixtureSmelt.MixtureAbility GetMixture(MixtureType type, MixtureChildType ctype, int uipos)
	{
		if (this.MixtureDatas == null || this.MixtureDatas.Count < 1)
		{
			return null;
		}
		foreach (MixtureSmelt.MixtureAbility mixtureAbility in this.MixtureDatas)
		{
			if (mixtureAbility.Type == type && mixtureAbility.ChildType == ctype && mixtureAbility.UIPos == uipos)
			{
				return mixtureAbility;
			}
		}
		return null;
	}

	public MixtureSmelt.MixtureAbility GetMixture(MixtureType type, MixtureChildType ctype, ulong id)
	{
		if (this.MixtureDatas == null || this.MixtureDatas.Count < 1)
		{
			return null;
		}
		foreach (MixtureSmelt.MixtureAbility mixtureAbility in this.MixtureDatas)
		{
			if (mixtureAbility.Type == type && mixtureAbility.ChildType == ctype && mixtureAbility.ID == id)
			{
				return mixtureAbility;
			}
		}
		return null;
	}

	public void UnlockCmd(int msg)
	{
	}

	public List<MixtureSmelt.MixtureAbility> GetMixtureByChildType(MixtureChildType ctype)
	{
		if (this.MixtureDatas == null || this.MixtureDatas.Count < 1)
		{
			return null;
		}
		List<MixtureSmelt.MixtureAbility> list = new List<MixtureSmelt.MixtureAbility>();
		foreach (MixtureSmelt.MixtureAbility mixtureAbility in this.MixtureDatas)
		{
			if (mixtureAbility.ChildType == ctype)
			{
				list.Add(mixtureAbility);
			}
		}
		return list;
	}

	//public static int GetPropCount(ulong staticid)
	//{
	//	ItemPropertyConfig itemPropertyConfig = null;
	//	if (!GameData.Instance.ItemStaticMan.TryGetItemInfoByID(staticid, out itemPropertyConfig))
	//	{
	//		return 0;
	//	}
	//	Dictionary<ulong, CItemBase> dictionary = Player.Instance.ItemFolder.FolderData();
	//	if (dictionary == null || dictionary.Count < 1)
	//	{
	//		return 0;
	//	}
	//	int num = 0;
	//	foreach (CItemBase citemBase in dictionary.Values)
	//	{
	//		if (citemBase.ITEM_STATIC_ID == staticid)
	//		{
	//			num++;
	//		}
	//	}
	//	return num;
	//}

	//public int GetStuffToProductByAbility(MixtureSmelt.MixtureAbility pData)
	//{
	//	if (pData == null)
	//	{
	//		return 0;
	//	}
	//	List<MixtureSmelt.StuffData> abilityStuffs = this.GetAbilityStuffs(pData);
	//	if (abilityStuffs == null || abilityStuffs.Count < 1)
	//	{
	//		return 0;
	//	}
	//	if (this.StuffToProductByAbilityCnts == null)
	//	{
	//		this.StuffToProductByAbilityCnts = new List<int>();
	//	}
	//	else
	//	{
	//		this.StuffToProductByAbilityCnts.Clear();
	//	}
	//	foreach (MixtureSmelt.StuffData stuffData in abilityStuffs)
	//	{
	//		this.StuffToProductByAbilityCnts.Add(MixtureSmelt.GetPropCount(stuffData.ID));
	//	}
	//	this.StuffToProductByAbilityCnts.Sort();
	//	return this.StuffToProductByAbilityCnts[0];
	//}

	private bool LoadAbilityDatas()
	{
		List<string> list = RoleBaseFun.LoadConfInAssets("MixtureElements");
		if (list.Count <= 0)
		{
			Debug.LogWarning("MixtureSmelt LoadAbilityDatas no found!");
			return false;
		}
		this.AbilityDatas.Clear();
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			if (array != null && array.Length >= 3)
			{
				List<string> list2 = new List<string>();
				foreach (string text2 in array)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						list2.Add(text2);
					}
				}
				if (list2 != null && list2.Count >= 2)
				{
					int j = 0;
					MixtureSmelt.AbilityData abilityData = new MixtureSmelt.AbilityData();
					abilityData.ID = Convert.ToUInt64(list2[j]);
					j++;
					j++;
					MixtureSmelt.StuffGroup stuffGroup = new MixtureSmelt.StuffGroup();
					while (j < list2.Count)
					{
						if (j + 1 < list2.Count)
						{
							MixtureSmelt.StuffData stuffData = new MixtureSmelt.StuffData();
							stuffData.ID = Convert.ToUInt64(list2[j]);
							j++;
							stuffData.Count = Convert.ToInt32(list2[j]);
							stuffGroup.Stuffs.Add(stuffData);
						}
						j++;
					}
					List<MixtureSmelt.StuffGroup> list3 = (!this.AbilityDatas.ContainsKey(abilityData.ID)) ? abilityData._Stuffs : this.AbilityDatas[abilityData.ID]._Stuffs;
					list3.Add(stuffGroup);
					if (!this.AbilityDatas.ContainsKey(abilityData.ID))
					{
						this.AbilityDatas.Add(abilityData.ID, abilityData);
					}
				}
			}
		}
		return true;
	}

	private bool LoadMixtureInfo(string path)
	{
		List<string> list = RoleBaseFun.LoadConfInAssets(path);
		if (list.Count <= 0)
		{
			Debug.LogWarning("MixtureSmelt LoadMixtureInfo no found!");
			return false;
		}
		this.MixtureDatas.Clear();
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			if (array != null && array.Length >= 3)
			{
				List<string> list2 = new List<string>();
				foreach (string text2 in array)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						list2.Add(text2);
					}
				}
				if (list2 != null && list2.Count >= 8)
				{
					int num = 0;
					MixtureSmelt.MixtureAbility mixtureAbility = new MixtureSmelt.MixtureAbility();
					mixtureAbility.Type = (MixtureType)Convert.ToInt32(list2[num]);
					num++;
					mixtureAbility.ChildType = (MixtureChildType)Convert.ToInt32(list2[num]);
					num++;
					mixtureAbility.UIPos = Convert.ToInt32(list2[num]);
					num++;
					mixtureAbility.ID = Convert.ToUInt64(list2[num]);
					num++;
					mixtureAbility.Number = Convert.ToInt32(list2[num]);
					num++;
					mixtureAbility.LotteryRatio = Convert.ToSingle(list2[num]);
					num++;
					mixtureAbility.PrizeID = Convert.ToUInt64(list2[num]);
					num++;
					mixtureAbility.PrizeMaxCount = Convert.ToInt32(list2[num]);
					num++;
					string text3 = list2[num];
					if (text3.IndexOf('/') != -1)
					{
						string[] array3 = text3.Split(new char[]
						{
							'/'
						});
						if (array3 != null && array3.Length > 0)
						{
							mixtureAbility.NeedMixtureCount.Clear();
							for (int j = 0; j < array3.Length; j++)
							{
								int value = Convert.ToInt32(array3[j]);
								mixtureAbility.NeedMixtureCount.Add(this.MixtureDatas[this.MixtureDatas.Count - (j + 1)].ID, value);
							}
						}
					}
					num++;
					mixtureAbility.HelpID = Convert.ToInt32(list2[num]);
					this.MixtureDatas.Add(mixtureAbility);
				}
			}
		}
		return true;
	}

    /// <summary>
    /// 加载配置信息
    /// </summary>
    /// <param name="strFilePath"></param>
    /// <returns></returns>
	public bool LoadConfig(string strFilePath)
	{
		return strFilePath != null && this.LoadMixtureInfo(strFilePath) && this.LoadAbilityDatas();
	}

	public void PushSDData(Dictionary<ulong, MixtureSmelt.AbilityData> abilityDatas, List<MixtureSmelt.MixtureAbility> mixtureDatas, MixtureSmelt.MianLock mianlock)
	{
		if (abilityDatas == null || mixtureDatas == null)
		{
			Debug.LogError("PushSDData failed!");
			return;
		}
		this.ClearMixtureSmelt();
		this.AbilityDatas = new Dictionary<ulong, MixtureSmelt.AbilityData>(abilityDatas);
		this.MixtureDatas = new List<MixtureSmelt.MixtureAbility>(mixtureDatas);
		this.m_MianLock = mianlock;
	}

	[Serializable]
	public class StuffData
	{
		public ulong ID;

		public int Count;
	}

	[Serializable]
	public class StuffGroup
	{
		public List<MixtureSmelt.StuffData> Stuffs = new List<MixtureSmelt.StuffData>();
	}

	[Serializable]
	public class AbilityData
	{
		public ulong ID;

		public List<MixtureSmelt.StuffGroup> _Stuffs = new List<MixtureSmelt.StuffGroup>();
	}

	[Serializable]
	public class MianLock
	{
		public bool IsUnlockTagAmulet = true;

		public bool IsUnlockTagWare = true;

		public bool IsUnlockListItem3 = true;

		public bool IsUnlockListItem4 = true;

		public bool IsUnlockListItem5 = true;

		public bool IsUnlockListItem6 = true;

		public bool IsFirstOpenPill;

		public bool IsFirstOpenAmulet;

		public bool IsFirstOpenWare;

		public List<MixtureSmelt.MixtureActualPos> HaveNewIcon = new List<MixtureSmelt.MixtureActualPos>();

		public List<MixtureChildType> HaveNewQiListItem = new List<MixtureChildType>();
	}

	[Serializable]
	public class MixtureActualPos
	{
		public MixtureType m_Type;

		public MixtureChildType m_ChildType;

		public int m_UIPos;
	}

	[Serializable]
	public class MixtureAbility
	{
		public MixtureType Type;

		public MixtureChildType ChildType;

		public int UIPos;

		public ulong ID;

		public int Number;

		public float LotteryRatio;

		public ulong PrizeID;

		public int PrizeMaxCount;

		public bool IsUnLock = true;

		public Dictionary<ulong, int> NeedMixtureCount = new Dictionary<ulong, int>();

		public Dictionary<ulong, int> FinishMixtureCount = new Dictionary<ulong, int>();

		public int HelpID = -1;
	}
}
