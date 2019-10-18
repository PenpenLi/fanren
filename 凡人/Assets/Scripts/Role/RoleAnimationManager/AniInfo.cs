using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动画信息
/// </summary>
public class AniInfo
{
	public AniInfo()
	{
	}

	public AniInfo(AniInfo clone)
	{
		foreach (AniInfo.AniInfoNode clone2 in clone.AniNameList)
		{
			this.aniNameList.Add(new AniInfo.AniInfoNode(clone2));
		}
	}

	public List<AniInfo.AniInfoNode> AniNameList
	{
		get
		{
			return this.aniNameList;
		}
	}

	public int GetAniAmount()
	{
		return this.aniNameList.Count;
	}

	public AniInfo.AniInfoNode GetAniNameByIndex(int nIndex)
	{
		if (nIndex < 0 || nIndex > this.GetAniAmount())
		{
			return null;
		}
		return this.aniNameList[nIndex];
	}

	public AniInfo.AniInfoNode GetRandAniName()
	{
		int nIndex = UnityEngine.Random.Range(0, this.GetAniAmount());
		return this.GetAniNameByIndex(nIndex);
	}

	public bool HaveAnyMove()
	{
		foreach (AniInfo.AniInfoNode aniInfoNode in this.aniNameList)
		{
			foreach (AniInfo.AniMoveInfo aniMoveInfo in aniInfoNode.AniMoveList)
			{
				if (aniMoveInfo.Distance != 0f)
				{
					return true;
				}
			}
		}
		return false;
	}

	private List<AniInfo.AniInfoNode> aniNameList = new List<AniInfo.AniInfoNode>();

	public class AtkExAniInfo
	{
        private float startTime;

        private float endTime;

        public AtkExAniInfo()
		{
		}

		public AtkExAniInfo(AniInfo.AtkExAniInfo clone)
		{
			this.startTime = clone.StartTime;
			this.endTime = clone.EndTime;
		}

		public float StartTime
		{
			get
			{
				return this.startTime;
			}
		}

		public float EndTime
		{
			get
			{
				return this.endTime;
			}
		}

		public void TextLoad(List<string> infoList, ref int index)
		{
			this.startTime = Convert.ToSingle(infoList[index++]);
			this.endTime = Convert.ToSingle(infoList[index++]);
		}
	}

	public class AniMoveInfo
	{
        private float startTime;

        private float endTime;

        private int moveType;

        private float distance;

        private float height;

        private bool bMoved;

        public AniMoveInfo()
		{
		}

		public AniMoveInfo(AniInfo.AniMoveInfo clone)
		{
			this.startTime = clone.StartTime;
			this.endTime = clone.EndTime;
			this.moveType = clone.MoveType;
			this.distance = clone.Distance;
			this.height = clone.Height;
			this.bMoved = clone.BMoved;
		}

		public float StartTime
		{
			get
			{
				return this.startTime;
			}
		}

		public float EndTime
		{
			get
			{
				return this.endTime;
			}
		}

		public int MoveType
		{
			get
			{
				return this.moveType;
			}
		}

		public float Distance
		{
			get
			{
				return this.distance;
			}
		}

		public float Height
		{
			get
			{
				return this.height;
			}
		}

		public bool BMoved
		{
			get
			{
				return this.bMoved;
			}
		}

		public void TextLoad(List<string> infoList, ref int index)
		{
			this.startTime = Convert.ToSingle(infoList[index++]);
			this.endTime = Convert.ToSingle(infoList[index++]);
			this.moveType = Convert.ToInt32(infoList[index++]);
			this.distance = Convert.ToSingle(infoList[index++]);
			this.height = Convert.ToSingle(infoList[index++]);
			this.bMoved = false;
		}
	}

	public class AniEffectInfo
	{
        private int effectId;

        private float startTime;

        private string boneName;

        public AniEffectInfo()
		{
		}

		public AniEffectInfo(AniInfo.AniEffectInfo clone)
		{
			this.effectId = clone.EffectId;
			this.startTime = clone.StartTime;
			this.boneName = clone.BoneName;
		}

		public int EffectId
		{
			get
			{
				return this.effectId;
			}
		}

		public float StartTime
		{
			get
			{
				return this.startTime;
			}
		}

		public string BoneName
		{
			get
			{
				return this.boneName;
			}
		}

		public void TextLoad(List<string> infoList, ref int index)
		{
			this.effectId = Convert.ToInt32(infoList[index++]);
			this.startTime = Convert.ToSingle(infoList[index++]);
			this.boneName = infoList[index++];
		}
	}

	public class AniInfoNode
	{
        public int animatioIndex;

        public int meshIndex;

        public int weapoIndex;

        private string name;

        private int scriptIdx = -1;

        private int soundIdx;

        private List<AniInfo.AniMoveInfo> aniMoveList = new List<AniInfo.AniMoveInfo>();

        private List<AniInfo.AtkExAniInfo> aniAtkExInfoList = new List<AniInfo.AtkExAniInfo>();

        private List<AniInfo.AniEffectInfo> aniEffectInfoList = new List<AniInfo.AniEffectInfo>();

        private float speedRateBase;

        public AniInfoNode()
		{
		}

		public AniInfoNode(AniInfo.AniInfoNode clone)
		{
			this.name = clone.Name;
			this.soundIdx = clone.SoundIdx;
			this.scriptIdx = clone.ScriptIdx;
			this.speedRateBase = clone.SpeedRateBase;
			this.aniAtkExInfoList.Clear();
			foreach (AniInfo.AtkExAniInfo clone2 in clone.AniAtkExInfoList)
			{
				this.aniAtkExInfoList.Add(new AniInfo.AtkExAniInfo(clone2));
			}
			this.aniEffectInfoList.Clear();
			foreach (AniInfo.AniEffectInfo clone3 in clone.AniEffectInfoList)
			{
				this.aniEffectInfoList.Add(new AniInfo.AniEffectInfo(clone3));
			}
			this.aniMoveList.Clear();
			foreach (AniInfo.AniMoveInfo clone4 in clone.AniMoveList)
			{
				this.aniMoveList.Add(new AniInfo.AniMoveInfo(clone4));
			}
		}

		public float SpeedRateBase
		{
			get
			{
				return this.speedRateBase;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public int ScriptIdx
		{
			get
			{
				return this.scriptIdx;
			}
		}

		public int SoundIdx
		{
			get
			{
				return this.soundIdx;
			}
		}

		public List<AniInfo.AniMoveInfo> AniMoveList
		{
			get
			{
				return this.aniMoveList;
			}
		}

		public List<AniInfo.AtkExAniInfo> AniAtkExInfoList
		{
			get
			{
				return this.aniAtkExInfoList;
			}
		}

		public List<AniInfo.AniEffectInfo> AniEffectInfoList
		{
			get
			{
				return this.aniEffectInfoList;
			}
		}

		public void TextLoad(List<string> infoList, ref int index)
		{
			this.soundIdx = Convert.ToInt32(infoList[index++]);
			this.name = infoList[index++];
			this.scriptIdx = Convert.ToInt32(infoList[index++]);
			this.speedRateBase = Convert.ToSingle(infoList[index++]);
			for (int i = 0; i < 3; i++)
			{
				AniInfo.AniMoveInfo aniMoveInfo = new AniInfo.AniMoveInfo();
				aniMoveInfo.TextLoad(infoList, ref index);
				if (aniMoveInfo.Distance != 0f || aniMoveInfo.Height != 0f)
				{
					this.aniMoveList.Add(aniMoveInfo);
				}
			}
			for (int j = 0; j < 3; j++)
			{
				AniInfo.AtkExAniInfo atkExAniInfo = new AniInfo.AtkExAniInfo();
				atkExAniInfo.TextLoad(infoList, ref index);
				if (atkExAniInfo.StartTime != 0f || atkExAniInfo.EndTime != 0f)
				{
					this.aniAtkExInfoList.Add(atkExAniInfo);
				}
			}
			for (int k = 0; k < 3; k++)
			{
				AniInfo.AniEffectInfo aniEffectInfo = new AniInfo.AniEffectInfo();
				aniEffectInfo.TextLoad(infoList, ref index);
				this.aniEffectInfoList.Add(aniEffectInfo);
			}
		}

		public AniInfo.AniInfoNode Clone()
		{
			return new AniInfo.AniInfoNode(this);
		}
	}
}
