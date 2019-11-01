using System;
using System.Collections.Generic;
using UnityUtility;

/// <summary>
/// 玩家技能数据
/// </summary>
public class PlayerSkillData : Singleton<PlayerSkillData>
{
    private const string CONFIG_PATH = "conf/DataFile/PlayerSkill/PlayerSkill";

    private Dictionary<int, PlayerSkillData.Data> _data = new Dictionary<int, PlayerSkillData.Data>();

    public PlayerSkillData()
	{
		this.ReadData();
	}

	public Dictionary<int, PlayerSkillData.Data> SkillData
	{
		get
		{
			return this._data;
		}
	}

	public int[] GetSortedSkillID(PLAYER_SKILL_TYPE type)
	{
		List<PlayerSkillData.Data> list = new List<PlayerSkillData.Data>();
		foreach (PlayerSkillData.Data data in this._data.Values)
		{
			if (data.Type == type)
			{
				list.Add(data);
			}
		}
		list.Sort(new Comparison<PlayerSkillData.Data>(this.CompareData));
		int[] array = new int[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = list[i].ID;
		}
		return array;
	}

	public int[] GetSortedSkillId()
	{
		List<PlayerSkillData.Data> list = new List<PlayerSkillData.Data>();
		List<PlayerSkillData.Data> list2 = new List<PlayerSkillData.Data>();
		List<PlayerSkillData.Data> list3 = new List<PlayerSkillData.Data>();
		List<PlayerSkillData.Data> list4 = new List<PlayerSkillData.Data>();
		foreach (PlayerSkillData.Data data in this._data.Values)
		{
			switch (data.Type)
			{
			case PLAYER_SKILL_TYPE.PUPPET:
				list.Add(data);
				break;
			case PLAYER_SKILL_TYPE.SWORD:
				list2.Add(data);
				break;
			case PLAYER_SKILL_TYPE.FIRE:
				list3.Add(data);
				break;
			case PLAYER_SKILL_TYPE.SHIELD:
				list4.Add(data);
				break;
			}
		}
		list.Sort(new Comparison<PlayerSkillData.Data>(this.CompareData));
		list2.Sort(new Comparison<PlayerSkillData.Data>(this.CompareData));
		list3.Sort(new Comparison<PlayerSkillData.Data>(this.CompareData));
		list4.Sort(new Comparison<PlayerSkillData.Data>(this.CompareData));
		list.AddRange(list2);
		list.AddRange(list3);
		list.AddRange(list4);
		int[] array = new int[list.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = list[i].ID;
		}
		return array;
	}

	private int CompareData(PlayerSkillData.Data x, PlayerSkillData.Data y)
	{
		return x.Compare(x, y);
	}

	private void ReadData()
	{
		List<string> list = UtilityLoader.LoadConfText("conf/DataFile/PlayerSkill/PlayerSkill");
		if (list.Count == 0)
		{
			return;
		}
		int i = 0;
		while (i < list.Count)
		{
			PlayerSkillData.Data data = new PlayerSkillData.Data();
			data.ReadData(list, ref i);
			this._data.Add(data.ID, data);
		}
	}

	public class Data : IComparer<PlayerSkillData.Data>
	{
        private int id;

        private int type;

        private int _index;

        public int Compare(PlayerSkillData.Data x, PlayerSkillData.Data y)
		{
			if (x.Index == y.Index)
			{
				return 0;
			}
			return (x.Index <= y.Index) ? -1 : 1;
		}

		public int ID
		{
			get
			{
				return this.id;
			}
		}

		public PLAYER_SKILL_TYPE Type
		{
			get
			{
				return (PLAYER_SKILL_TYPE)this.type;
			}
		}

		public int Index
		{
			get
			{
				return this._index;
			}
		}

		public void ReadData(List<string> info, ref int index)
		{
			this.id = int.Parse(info[index++]);
			this.type = int.Parse(info[index++]);
			this._index = int.Parse(info[index++]);
		}
	}
}
