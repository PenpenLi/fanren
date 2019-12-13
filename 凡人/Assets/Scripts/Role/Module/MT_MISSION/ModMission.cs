using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 任务模块
/// </summary>
public class ModMission : Module
{
    private int _id;

    private long misMask;

    /// <summary>
    /// 任务链表清空
    /// </summary>
    public List<ModMission.MisLinkInfo> misLinkList = new List<ModMission.MisLinkInfo>();

    public List<ModMission.AccMisInfo> accMisList = new List<ModMission.AccMisInfo>();

    //public ModMission.MisEndInfo m_MisEndInfo = new ModMission.MisEndInfo();

    public Dictionary<int, Color> m_tTypeColor = new Dictionary<int, Color>();

    /// <summary>
    /// 任务结束信息数据
    /// </summary>
    public Dictionary<string, ModMission.MisEndInfoData> m_lstMisEndInfo = new Dictionary<string, ModMission.MisEndInfoData>();

    public ModMission(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_MISSION;
	}

    public long MisMask
    {
        get
        {
            return this.misMask;
        }
        set
        {
            this.misMask = value;
        }
    }

    public override bool Init()
    {
        this.misLinkList.Clear();
        this.accMisList.Clear();
        return base.Init();
    }

    public ModMission.MisLinkInfo GetInMisLinkList(int linkId)
    {
        for (int i = 0; i < this.misLinkList.Count; i++)
        {
            if (this.misLinkList[i].linkId == linkId)
            {
                return this.misLinkList[i];
            }
        }
        return null;
    }

    //public void DelMisLink(int linkId)
    //{
    //	for (int i = 0; i < this.misLinkList.Count; i++)
    //	{
    //		if (this.misLinkList[i].linkId == linkId)
    //		{
    //			this.misLinkList.RemoveAt(i);
    //			return;
    //		}
    //	}
    //}

    public bool IsInAccLinkList(int ID)
    {
        foreach (ModMission.AccMisInfo accMisInfo in this.accMisList)
        {
            if (accMisInfo.ID == ID)
            {
                return true;
            }
        }
        return false;
    }

    //public void CompleteMission(int ID)
    //{
    //	ModMission.AccMisInfo accMisInfo = this.GetAccMisInfo(ID);
    //	if (accMisInfo == null)
    //	{
    //		return;
    //	}
    //	MissionInfo misInfo = accMisInfo.MisInfo;
    //	this.accMisList.Remove(accMisInfo);
    //	this.m_MisEndInfo.AddInfo(new ModMission.MisEndInfoData(accMisInfo, new Color(1f, 1f, 1f)));
    //	if (accMisInfo.Step >= misInfo.StepAmount)
    //	{
    //		this.DelMisLink(accMisInfo.LinkId);
    //		this.SetMisMask(misInfo.Mask);
    //		if (accMisInfo.MisInfo.Type == MissionType.Main)
    //		{
    //			GameData.Instance.ScrMan.Exec(33, 1);
    //		}
    //	}
    //	else
    //	{
    //		ModMission.MisLinkInfo inMisLinkList = this.GetInMisLinkList(accMisInfo.LinkId);
    //		inMisLinkList.curStep = accMisInfo.Step + 1;
    //	}
    //	GameData.Instance.ScrMan.Exec((int)misInfo.ComSMT, misInfo.ComSMTDate);
    //	this.CheckSkipMission(ID);
    //}

    /// <summary>
    /// 接受任务
    /// </summary>
    /// <param name="ID"></param>
    public void AcceptMission(int ID)
    {
        Debug.Log( "Mission Accept ! ID:" + ID.ToString());
        if (!this.CheckMissionCondition(ID))
        {
            return;
        }
        ModMission.AccMisInfo accMisInfo = new ModMission.AccMisInfo();
        accMisInfo.ID = ID;
        accMisInfo.AimList.Clear();
        MissionInfo missionInfo = GameData.Instance.RoleData.GetMissionInfo(ID);
        if (missionInfo != null)
        {
            foreach (MissionInfo.MissionAimInfo missionAimInfo in missionInfo.MissionAimList)
            {
                if (missionAimInfo.Count != 0)
                {
                    MissionInfo.MissionAimInfo missionAimInfo2 = new MissionInfo.MissionAimInfo();
                    missionAimInfo2.AimType = missionAimInfo.AimType;
                    missionAimInfo2.AimDis = missionAimInfo.AimDis;
                    missionAimInfo2.AimData = missionAimInfo.AimData;
                    missionAimInfo2.Count = 0;
                    accMisInfo.AimList.Add(missionAimInfo2);
                }
            }
        }
        accMisInfo.MisInfo = missionInfo;
        this.accMisList.Add(accMisInfo);
        if (this.GetInMisLinkList(accMisInfo.LinkId) == null)
        {
            ModMission.MisLinkInfo misLinkInfo = new ModMission.MisLinkInfo();
            misLinkInfo.linkId = accMisInfo.LinkId;
            misLinkInfo.curStep = accMisInfo.Step;
            this.misLinkList.Add(misLinkInfo);
        }
        ShowTask();
    }

    public void ShowTask()
    {     
        if (Singleton<EZGUIManager>.GetInstance().GetGUI<TaskTrackPlane>() != null)
        {
            Debug.Log("显示UI");
            Singleton<EZGUIManager>.GetInstance().GetGUI<TaskTrackPlane>().Show();
        }
    }

    public bool IsLinkCompleted(int ID)
    {
        MissionInfo missionInfo = GameData.Instance.RoleData.GetMissionInfo(ID);
        return missionInfo != null && this.IsMisMask(missionInfo.Mask);
    }

    public bool IsMisMask(int bityIdx)
    {
        return bityIdx >= 0 && bityIdx < 64 && (1L << bityIdx & this.misMask) != 0L;
    }

    //// Token: 0x0600219E RID: 8606 RVA: 0x000E6DA0 File Offset: 0x000E4FA0
    //public void SetMisMask(int bityIdx)
    //{
    //	if (bityIdx < 0 || bityIdx >= 64)
    //	{
    //		return;
    //	}
    //	this.misMask |= 1L << bityIdx;
    //}

    public MissionState GetMissionState(int ID)
    {
        //if (this.IsLinkCompleted(ID))
        //{
        //    return MissionState.MS_Completed;
        //}
        //ModMission.AccMisInfo accMisInfo = this.GetAccMisInfo(ID);
        //if (accMisInfo != null)
        //{
        //    if (this.IsAccMisInfoComplete(accMisInfo))
        //    {
        //        return MissionState.MS_Doing_Cmp;
        //    }
        //    return MissionState.MS_Doing;
        //}
        //else
        //{
        //    int linkId = ID / 1000;
        //    //MissionInfo missionInfo = GameData.Instance.RoleData.GetMissionInfo(ID);
        //    //if (missionInfo == null)
        //    //{
        //    //    Debug.LogWarning("Can't find mission config:" + ID);
        //    //    return MissionState.MS_UnAccept;
        //    //}
        //    //int step = missionInfo.step;
        //    //ModMission.MisLinkInfo inMisLinkList = this.GetInMisLinkList(linkId);
        //    if (inMisLinkList == null)
        //    {
        //        if (step == 1)
        //        {
        //            return MissionState.MS_UnAccept;
        //        }
        //        return MissionState.MS_UnAccept_Canot;
        //    }
        //    else
        //    {
        //        if (inMisLinkList.curStep > step)
        //        {
        //            return MissionState.MS_Completed;
        //        }
        //        if (inMisLinkList.curStep < step)
        //        {
        //            return MissionState.MS_UnAccept_Canot;
        //        }
        //        return MissionState.MS_UnAccept;
        //    }
        //}
        return 0;
    }

    //// Token: 0x060021A0 RID: 8608 RVA: 0x000E6E90 File Offset: 0x000E5090
    //public ModMission.AccMisInfo GetAccMisInfo(int ID)
    //{
    //	for (int i = 0; i < this.accMisList.Count; i++)
    //	{
    //		if (this.accMisList[i].ID == ID)
    //		{
    //			return this.accMisList[i];
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x060021A1 RID: 8609 RVA: 0x000E6EE0 File Offset: 0x000E50E0
    //public ModMission.MisEndInfo GetAccMisEndInfo()
    //{
    //	return this.m_MisEndInfo;
    //}

    //// Token: 0x060021A2 RID: 8610 RVA: 0x000E6EE8 File Offset: 0x000E50E8
    //public void UpdateMissionProgress(int aimType, int aimData)
    //{
    //	for (int i = 0; i < this.accMisList.Count; i++)
    //	{
    //		ModMission.AccMisInfo accMisInfo = this.accMisList[i];
    //		if (accMisInfo == null)
    //		{
    //			return;
    //		}
    //		if (this.IsAccMisInfoComplete(accMisInfo))
    //		{
    //			return;
    //		}
    //		int num = 0;
    //		for (int j = 0; j < accMisInfo.MisInfo.MissionAimList.Count; j++)
    //		{
    //			if (aimData == accMisInfo.MisInfo.MissionAimList[j].AimData && aimType == accMisInfo.MisInfo.MissionAimList[j].AimType)
    //			{
    //				num = accMisInfo.MisInfo.MissionAimList[j].Count;
    //				break;
    //			}
    //		}
    //		if (num == 0)
    //		{
    //			return;
    //		}
    //		string[] completeStateStr = accMisInfo.GetCompleteStateStr();
    //		if (completeStateStr.Length != accMisInfo.AimList.Count)
    //		{
    //			Logger.LogWarning(new object[]
    //			{
    //				"AimStr's Length is not match the ami.AimList.Count."
    //			});
    //		}
    //		for (int k = 0; k < accMisInfo.AimList.Count; k++)
    //		{
    //			if (aimType == accMisInfo.AimList[k].AimType && accMisInfo.AimList[k].Count < num)
    //			{
    //				accMisInfo.AimList[k].Count++;
    //				string text = string.Concat(new object[]
    //				{
    //					completeStateStr[k],
    //					" ",
    //					accMisInfo.AimList[k].Count,
    //					"/",
    //					num
    //				});
    //				if (accMisInfo.AimList[k].Count >= num)
    //				{
    //					accMisInfo.Complete = true;
    //				}
    //				else
    //				{
    //					accMisInfo.Complete = false;
    //				}
    //				break;
    //			}
    //		}
    //		if (accMisInfo.MisInfo.CompleteNpc == -1)
    //		{
    //			Logger.Log(new object[]
    //			{
    //				"完成任务 : " + accMisInfo.ID.ToString() + "名称 : " + accMisInfo.MisInfo.Name
    //			});
    //			GameData.Instance.ScrMan.Exec(5, accMisInfo.ID);
    //		}
    //	}
    //}

    //// Token: 0x060021A3 RID: 8611 RVA: 0x000E711C File Offset: 0x000E531C
    //public bool IsAccMisInfoComplete(ModMission.AccMisInfo ami)
    //{
    //	if (ami.Complete)
    //	{
    //		return true;
    //	}
    //	for (int i = 0; i < ami.MisInfo.MissionAimList.Count; i++)
    //	{
    //		MissionInfo.MissionAimInfo missionAimInfo = ami.MisInfo.MissionAimList[i];
    //		if (missionAimInfo.Count > 0)
    //		{
    //			if (missionAimInfo.AimType == 7)
    //			{
    //				int num = 10000;
    //				if (num < missionAimInfo.Count)
    //				{
    //					return false;
    //				}
    //			}
    //			else
    //			{
    //				bool flag = false;
    //				int j = 0;
    //				while (j < ami.AimList.Count)
    //				{
    //					if (missionAimInfo.AimType == ami.AimList[j].AimType)
    //					{
    //						flag = true;
    //						if (ami.AimList[j].Count < missionAimInfo.Count)
    //						{
    //							return false;
    //						}
    //						break;
    //					}
    //					else
    //					{
    //						j++;
    //					}
    //				}
    //				if (!flag)
    //				{
    //					Logger.LogWarning(new object[]
    //					{
    //						"错误：接受的任务数据和静态任务数据不匹配。"
    //					});
    //					return false;
    //				}
    //			}
    //		}
    //	}
    //	return true;
    //}

    /// <summary>
    /// 检查任务条件
    /// </summary>
    /// <param name="nID"></param>
    /// <returns></returns>
    public bool CheckMissionCondition(int nID)
    {
        if (GameData.Instance.RoleData.GetMissionInfo(nID) == null)
        {
            return false;
        }
        if (this.IsLinkCompleted(nID))
        {
            Debug.LogWarning(new object[]
            {
                "Mission link " + nID / 1000 + " has completed!"
            });
            return false;
        }
        if (this.IsInAccLinkList(nID))
        {
            Debug.LogWarning(new object[]
            {
                string.Concat(new object[]
                {
                    "Mission link ",
                    nID % 1000,
                    ", step ",
                    nID % 1000,
                    " has accept!"
                })
            });
            return false;
        }
        return true;
    }

    //public void CheckSkipMission(int nID)
    //{
    //	if (!this.IsLinkCompleted(nID))
    //	{
    //		return;
    //	}
    //	MissionInfo missionInfo = GameData.Instance.RoleData.GetMissionInfo(nID);
    //	if (missionInfo == null)
    //	{
    //		return;
    //	}
    //	if (missionInfo.MissType == 1)
    //	{
    //		if (missionInfo.MissVal.Count == 0)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < missionInfo.MissVal.Count; i++)
    //		{
    //			Logger.Log(new object[]
    //			{
    //				"acc = " + missionInfo.MissVal[i].ToString()
    //			});
    //			this.AcceptMission(missionInfo.MissVal[i]);
    //		}
    //	}
    //}

    [Serializable]
    public class MisLinkInfo
    {
        public int linkId;

        public int curStep;

        public ModMission.MisLinkInfo Clone()
        {
            return new ModMission.MisLinkInfo
            {
                linkId = this.linkId,
                curStep = this.curStep
            };
        }
    }

    //[Serializable]
    //public class AccMisInfo_SD
    //{
    //    public int ID;

    //    public bool Complete;

    //    public List<MissionInfo.MissionAimInfo> AimList = new List<MissionInfo.MissionAimInfo>();

    //    public int LinkId
    //    {
    //        get
    //        {
    //            return this.ID / 1000;
    //        }
    //        set
    //        {
    //        }
    //    }

    //    public int Step
    //    {
    //        get
    //        {
    //            return this.ID % 1000;
    //        }
    //        set
    //        {
    //        }
    //    }

    //    public ModMission.AccMisInfo Clone2Nor()
    //    {
    //        ModMission.AccMisInfo accMisInfo = new ModMission.AccMisInfo();
    //        accMisInfo.ID = this.ID;
    //        accMisInfo.Complete = this.Complete;
    //        accMisInfo.MisInfo = null;
    //        for (int i = 0; i < this.AimList.Count; i++)
    //        {
    //            accMisInfo.AimList.Add(this.AimList[i].Clone());
    //        }
    //        return accMisInfo;
    //    }
    //}

    public class AccMisInfo
    {
        public int ID;

        public bool Complete;

        public List<MissionInfo.MissionAimInfo> AimList = new List<MissionInfo.MissionAimInfo>();

        public MissionInfo MisInfo;

        public int LinkId
        {
            get
            {
                return this.ID / 1000;
            }
            set
            {
            }
        }

        public int Step
        {
            get
            {
                return this.MisInfo.step;
            }
            set
            {
            }
        }

        //public ModMission.AccMisInfo_SD Clone2SD()
        //{
        //    ModMission.AccMisInfo_SD accMisInfo_SD = new ModMission.AccMisInfo_SD();
        //    accMisInfo_SD.ID = this.ID;
        //    accMisInfo_SD.Complete = this.Complete;
        //    for (int i = 0; i < this.AimList.Count; i++)
        //    {
        //        accMisInfo_SD.AimList.Add(this.AimList[i].Clone());
        //    }
        //    return accMisInfo_SD;
        //}

        public string[] GetCompleteStateStr()
        {
            string[] array = new string[this.AimList.Count];
            for (int i = 0; i < this.AimList.Count; i++)
            {
                MissionInfo.MissionAimInfo missionAimInfo = this.AimList[i];
                if (string.Compare(missionAimInfo.AimDis, "null", true) != 0)
                {
                    array[i] = missionAimInfo.AimDis;
                }
                else if (missionAimInfo.AimType != 7)
                {
                    if (missionAimInfo.AimType == 6)
                    {
                        array[i] = GameData.Instance.RoleData.GetMonsterNameById(missionAimInfo.AimData);
                    }
                }
            }
            return array;
        }
    }

    public class MisEndInfoData
    {
        public ModMission.AccMisInfo amDesc;

        public Color tColor;

        public MisEndInfoData(ModMission.AccMisInfo amDestInfo, Color tDestColor)
        {
            this.amDesc = amDestInfo;
            this.tColor = tDestColor;
        }
    }

    //public class MisEndInfo
    //{
    //    // Token: 0x060021B6 RID: 8630 RVA: 0x000E75C0 File Offset: 0x000E57C0
    //    public MisEndInfo()
    //    {
    //        this.m_tTypeColor.Clear();
    //        this.Clear();
    //    }

    //    // Token: 0x060021B7 RID: 8631 RVA: 0x000E75F0 File Offset: 0x000E57F0
    //    public bool AddInfo(ModMission.MisEndInfoData meDesc)
    //    {
    //        if (this.m_lstMisEndInfo.ContainsKey(meDesc.amDesc.ID.ToString()))
    //        {
    //            Logger.LogWarning(new object[]
    //            {
    //                    "====add info failed! id=" + meDesc.amDesc.ID.ToString()
    //            });
    //            return false;
    //        }
    //        this.m_lstMisEndInfo.Add(meDesc.amDesc.ID.ToString(), meDesc);
    //        Logger.Log(new object[]
    //        {
    //                "add mis endinfo id: " + meDesc.amDesc.ID.ToString()
    //        });
    //        return true;
    //    }

    //    // Token: 0x060021B8 RID: 8632 RVA: 0x000E768C File Offset: 0x000E588C
    //    public bool SetMisEndTypeColor(int nIndex, Color tColor)
    //    {
    //        if (nIndex != 0)
    //        {
    //            return false;
    //        }
    //        this.m_tTypeColor[0] = tColor;
    //        return true;
    //    }

    //    // Token: 0x060021B9 RID: 8633 RVA: 0x000E76A4 File Offset: 0x000E58A4
    //    public void Clear()
    //    {
    //        this.m_lstMisEndInfo.Clear();
    //        for (int i = 0; i < 3; i++)
    //        {
    //            this.SetMisEndTypeColor(i, new Color(1f, 1f, 1f, 1f));
    //        }
    //    }

    //    // Token: 0x060021BA RID: 8634 RVA: 0x000E76F0 File Offset: 0x000E58F0
    //    public ModMission.MisEndInfoData GetMisEndData(string szIDKey)
    //    {
    //        if (!this.m_lstMisEndInfo.ContainsKey(szIDKey))
    //        {
    //            Logger.LogWarning(new object[]
    //            {
    //                    "GetMisEndData at failed id!"
    //            });
    //            return null;
    //        }
    //        return this.m_lstMisEndInfo[szIDKey];
    //    }

    //    // Token: 0x060021BB RID: 8635 RVA: 0x000E7730 File Offset: 0x000E5930
    //    public int GetMisEndInfoCount()
    //    {
    //        return this.m_lstMisEndInfo.Count;
    //    }
    //}
}
