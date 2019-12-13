using System;
using System.Collections.Generic;

/// <summary>
/// 任务信息
/// </summary>
public class MissionInfo
{
    public const int LinkIdOffId = 1000;

    public const int LINKIDOFFSET = 100000;

    public const int STEPOFFSET = 100;

    public const int TRIGGERTYPE_MAX = 7;

    /// <summary>
    /// ID
    /// </summary>
    public int ID;

    /// <summary>
    /// 步骤
    /// </summary>
    public int step;

    /// <summary>
    /// 步骤数量
    /// </summary>
    public int StepAmount;

    /// <summary>
    /// 掩码
    /// </summary>
    public int Mask;

    /// <summary>
    /// 任务名
    /// </summary>
    public string Name;

    /// <summary>
    /// 任务剧情文字
    /// </summary>
    public string AimDescribe;

    /// <summary>
    /// 任务要求
    /// </summary>
    public string AimRequire;

    /// <summary>
    /// 任务图片路径
    /// </summary>
    public string PicPath;

    /// <summary>
    /// 任务大图片路径
    /// </summary>
    public string PicBigPath;

    public int MissType;

    public int MissValCount;

    public List<int> MissVal = new List<int>();

    public int CompleteNpc;

    public int GoldReward;

    public int ExpReward;

    public List<MissionInfo.ItemInfo> RewardItemList = new List<MissionInfo.ItemInfo>();

    public ScrModType ComSMT;

    public int ComSMTDate;

    public List<MissionInfo.MissionAimInfo> MissionAimList = new List<MissionInfo.MissionAimInfo>();

    public List<MissionContent> MissionConList = new List<MissionContent>();

    public class ItemInfo
    {

        public int itemType;


        public int itemAmount;
    }


    [Serializable]
    public class MissionAimInfo
    {

        public MissionInfo.MissionAimInfo Clone()
        {
            return new MissionInfo.MissionAimInfo
            {
                AimType = this.AimType,
                AimDis = this.AimDis,
                AimData = this.AimData,
                Count = this.Count
            };
        }


        public int AimType;


        public string AimDis;


        public int AimData;


        public int Count;
    }


    public enum eMissTypes
    {

        MISS_MIN = -2,

        MISS_IGNORE,

        MISS_AUTOTRIGGER,

        MISS_SKIPMISS,

        MISS_MONSTERDIE,

        MISS_MAX
    }


    public int LinkID
	{
		get
		{
			return this.ID / 1000 % 1000;
		}
		set
		{
		}
	}

    public MissionType Type
    {
        get
        {
            return (MissionType)(this.ID / 100000 - 40);
        }
        set
        {
        }
    }

    public string GetMissionContent(int index)
    {
        foreach (MissionContent missionContent in this.MissionConList)
        {
            if (missionContent.StrStep % 100 == index % 100)
            {
                return missionContent.Str;
            }
        }
        return null;
    }

    public bool IsMissionContentEnd(int index)
    {
        return index % 100 == this.MissionConList.Count - 4;
    }

    public bool IsMisContUnComplete(int index)
	{
		return index % 100 == 99;
	}

	public bool IsMisContComplete(int index)
	{
		return index % 100 == 98;
	}

    public string GetCompleteStr()
    {
        return this.GetMissionContent(98);
    }

    public string GetUnCompleteStr()
    {
        return this.GetMissionContent(99);
    }

    public string GetDetailStr()
    {
        return this.GetMissionContent(97);
    }

    public bool InvalidMissType(int type)
	{
		return type <= -2 || type >= 3;
	}
}
