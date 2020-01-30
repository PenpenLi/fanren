using System;
using System.Collections.Generic;

/// <summary>
/// 任务信息
/// </summary>
public class MissionInfo
{
    //	public int LinkID
    //	{
    //		get
    //		{
    //			return this.ID / 1000 % 1000;
    //		}
    //		set
    //		{
    //		}
    //	}

    //	// Token: 0x170000E8 RID: 232
    //	// (get) Token: 0x06000680 RID: 1664 RVA: 0x0001CCF8 File Offset: 0x0001AEF8
    //	// (set) Token: 0x0600067F RID: 1663 RVA: 0x0001CCF4 File Offset: 0x0001AEF4
    //	public MissionType Type
    //	{
    //		get
    //		{
    //			return (MissionType)(this.ID / 100000 - 40);
    //		}
    //		set
    //		{
    //		}
    //	}

    //	// Token: 0x06000681 RID: 1665 RVA: 0x0001CD0C File Offset: 0x0001AF0C
    //	public string GetMissionContent(int index)
    //	{
    //		foreach (MissionContent missionContent in this.MissionConList)
    //		{
    //			if (missionContent.StrStep % 100 == index % 100)
    //			{
    //				return missionContent.Str;
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06000682 RID: 1666 RVA: 0x0001CD8C File Offset: 0x0001AF8C
    //	public bool IsMissionContentEnd(int index)
    //	{
    //		return index % 100 == this.MissionConList.Count - 4;
    //	}

    //	// Token: 0x06000683 RID: 1667 RVA: 0x0001CDA8 File Offset: 0x0001AFA8
    //	public bool IsMisContUnComplete(int index)
    //	{
    //		return index % 100 == 99;
    //	}

    //	// Token: 0x06000684 RID: 1668 RVA: 0x0001CDB8 File Offset: 0x0001AFB8
    //	public bool IsMisContComplete(int index)
    //	{
    //		return index % 100 == 98;
    //	}

    //	// Token: 0x06000685 RID: 1669 RVA: 0x0001CDC8 File Offset: 0x0001AFC8
    //	public string GetCompleteStr()
    //	{
    //		return this.GetMissionContent(98);
    //	}

    //	// Token: 0x06000686 RID: 1670 RVA: 0x0001CDD4 File Offset: 0x0001AFD4
    //	public string GetUnCompleteStr()
    //	{
    //		return this.GetMissionContent(99);
    //	}

    //	// Token: 0x06000687 RID: 1671 RVA: 0x0001CDE0 File Offset: 0x0001AFE0
    //	public string GetDetailStr()
    //	{
    //		return this.GetMissionContent(97);
    //	}

    //	// Token: 0x06000688 RID: 1672 RVA: 0x0001CDEC File Offset: 0x0001AFEC
    //	public bool InvalidMissType(int type)
    //	{
    //		return type <= -2 || type >= 3;
    //	}

    //	// Token: 0x04000526 RID: 1318
    //	public const int LinkIdOffId = 1000;

    //	// Token: 0x04000527 RID: 1319
    //	public const int LINKIDOFFSET = 100000;

    //	// Token: 0x04000528 RID: 1320
    //	public const int STEPOFFSET = 100;

    //	// Token: 0x04000529 RID: 1321
    //	public const int TRIGGERTYPE_MAX = 7;

    //	// Token: 0x0400052A RID: 1322
    //	public int ID;

    //	// Token: 0x0400052B RID: 1323
    //	public int step;

    //	// Token: 0x0400052C RID: 1324
    //	public int StepAmount;

    //	// Token: 0x0400052D RID: 1325
    //	public int Mask;

    //	// Token: 0x0400052E RID: 1326
    //	public string Name;

    //	// Token: 0x0400052F RID: 1327
    //	public string AimDescribe;

    //	// Token: 0x04000530 RID: 1328
    //	public string AimRequire;

    //	// Token: 0x04000531 RID: 1329
    //	public string PicPath;

    //	// Token: 0x04000532 RID: 1330
    //	public string PicBigPath;

    //	// Token: 0x04000533 RID: 1331
    //	public int MissType;

    //	// Token: 0x04000534 RID: 1332
    //	public int MissValCount;

    //	// Token: 0x04000535 RID: 1333
    //	public List<int> MissVal = new List<int>();

    //	// Token: 0x04000536 RID: 1334
    //	public int CompleteNpc;

    //	// Token: 0x04000537 RID: 1335
    //	public int GoldReward;

    //	// Token: 0x04000538 RID: 1336
    //	public int ExpReward;

    //	// Token: 0x04000539 RID: 1337
    //	public List<MissionInfo.ItemInfo> RewardItemList = new List<MissionInfo.ItemInfo>();

    //	// Token: 0x0400053A RID: 1338
    //	public ScrModType ComSMT;

    //	// Token: 0x0400053B RID: 1339
    //	public int ComSMTDate;

    //	// Token: 0x0400053C RID: 1340
    //	public List<MissionInfo.MissionAimInfo> MissionAimList = new List<MissionInfo.MissionAimInfo>();

    //	// Token: 0x0400053D RID: 1341
    //	public List<MissionContent> MissionConList = new List<MissionContent>();

    //	// Token: 0x0200014E RID: 334
    //	public class ItemInfo
    //	{
    //		// Token: 0x0400053E RID: 1342
    //		public int itemType;

    //		// Token: 0x0400053F RID: 1343
    //		public int itemAmount;
    //	}

    /// <summary>
    /// 任务目标信息
    /// </summary>
    [Serializable]
    public class MissionAimInfo
    {
        /// <summary>
        /// 目标类型
        /// </summary>
        public int AimType;

        /// <summary>
        /// 任务完成提示
        /// </summary>
        public string AimDis;

        /// <summary>
        /// 目标数据
        /// </summary>
        public int AimData;

        /// <summary>
        /// 达成目标次数
        /// </summary>
        public int Count;

        /// <summary>
        /// 当前数量目标次数
        /// </summary>
        public int CurCount;

        public MissionInfo.MissionAimInfo Clone()
        {
            return new MissionInfo.MissionAimInfo
            {
                AimType = this.AimType,
                AimDis = this.AimDis,
                AimData = this.AimData,
                Count = this.Count,
                CurCount =this.CurCount
            };
        }
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
}
