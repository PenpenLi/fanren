using System;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public class MissionManager
{
    //	private int _id;

    private long misMask;

    /// <summary>
    /// 任务关联信息
    /// </summary>
    public List<MisLinkInfo> misLinkList = new List<MisLinkInfo>();

    /// <summary>
    /// 已经接受的任务
    /// </summary>
    public List<AccMisInfo> accMisList = new List<AccMisInfo>();

    //	public ModMission.MisEndInfo m_MisEndInfo = new ModMission.MisEndInfo();


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

    public void Init()
    {
        this.misLinkList.Clear();
        this.accMisList.Clear();
    }

    public MisLinkInfo GetInMisLinkList(int linkId)
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

    //	// Token: 0x06002197 RID: 8599 RVA: 0x000E69DC File Offset: 0x000E4BDC
    //	public void DelMisLink(int linkId)
    //	{
    //		for (int i = 0; i < this.misLinkList.Count; i++)
    //		{
    //			if (this.misLinkList[i].linkId == linkId)
    //			{
    //				this.misLinkList.RemoveAt(i);
    //				return;
    //			}
    //		}
    //	}

    public bool IsInAccLinkList(int ID)
    {
        //foreach (ModMission.AccMisInfo accMisInfo in this.accMisList)
        //{
        //    if (accMisInfo.ID == ID)
        //    {
        //        return true;
        //    }
        //}
        return false;
    }

    //	// Token: 0x06002199 RID: 8601 RVA: 0x000E6AA4 File Offset: 0x000E4CA4
    //	public void CompleteMission(int ID)
    //	{
    //		ModMission.AccMisInfo accMisInfo = this.GetAccMisInfo(ID);
    //		if (accMisInfo == null)
    //		{
    //			return;
    //		}
    //		MissionInfo misInfo = accMisInfo.MisInfo;
    //		this.accMisList.Remove(accMisInfo);
    //		this.m_MisEndInfo.AddInfo(new ModMission.MisEndInfoData(accMisInfo, new Color(1f, 1f, 1f)));
    //		if (accMisInfo.Step >= misInfo.StepAmount)
    //		{
    //			this.DelMisLink(accMisInfo.LinkId);
    //			this.SetMisMask(misInfo.Mask);
    //			if (accMisInfo.MisInfo.Type == MissionType.Main)
    //			{
    //				GameData.Instance.ScrMan.Exec(33, 1);
    //			}
    //		}
    //		else
    //		{
    //			ModMission.MisLinkInfo inMisLinkList = this.GetInMisLinkList(accMisInfo.LinkId);
    //			inMisLinkList.curStep = accMisInfo.Step + 1;
    //		}
    //		GameData.Instance.ScrMan.Exec((int)misInfo.ComSMT, misInfo.ComSMTDate);
    //		this.CheckSkipMission(ID);
    //	}

    /// <summary>
    /// 接受任务
    /// </summary>
    /// <param name="ID"></param>
    public void AcceptMission(int ID)
    {
        Debug.Log("接受任务 ! ID:" + ID.ToString());
        //if (!this.CheckMissionCondition(ID))//已经完成任务返回
        //{
        //    return;
        //}

        AccMisInfo accMisInfo = new AccMisInfo();
        accMisInfo.ID = ID;
        accMisInfo.MissionAimList.Clear();
        MissionEntity missionEntity = GameEntry.DataTable.DataTableManager.MissionDBModel.Get(ID);
        if (missionEntity != null)
        {
            string[] arr1 = missionEntity.AimInfo.Split('|');
            for (int i = 0; i < arr1.Length; i++)
            {
                string[] arr2 = arr1[i].Split('_');
                int AimType = 0;
                int.TryParse(arr2[0], out AimType);
                int AimData = 0;
                int.TryParse(arr2[2], out AimData);

                MissionInfo.MissionAimInfo missionAimInfo = new MissionInfo.MissionAimInfo();
                missionAimInfo.AimType = AimType;
                missionAimInfo.AimDis = arr2[1];
                missionAimInfo.AimData = AimData;
                missionAimInfo.Count = arr2[3].ToInt();
                missionAimInfo.CurCount = 0;
                accMisInfo.MissionAimList.Add(missionAimInfo);
            }
        }

        accMisInfo.MisInfo = missionEntity;
        this.accMisList.Add(accMisInfo);
        //if (this.GetInMisLinkList(accMisInfo.LinkId) == null)//关联任务
        //{
        //    MisLinkInfo misLinkInfo = new MisLinkInfo();
        //    misLinkInfo.linkId = accMisInfo.LinkId;
        //    misLinkInfo.curStep = accMisInfo.Step;
        //    this.misLinkList.Add(misLinkInfo);
        //}
        ShowTask();
    }

    public void ShowTask()
    {
        Debug.Log("显示任务追踪");
        //if (Singleton<EZGUIManager>.GetInstance().GetGUI<TaskTrackPlane>() != null)
        //{
        //    Singleton<EZGUIManager>.GetInstance().GetGUI<TaskTrackPlane>().Show();
        //}
    }

    /// <summary>
    /// 是否已经连环完成
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool IsLinkCompleted(int ID)
    {
        MissionEntity missionEntity = GameEntry.DataTable.DataTableManager.MissionDBModel.Get(ID);
        return this.IsMisMask(missionEntity.Mask);
    }

    public bool IsMisMask(int bityIdx)
    {
        return bityIdx >= 0 && bityIdx < 64 && (1L << bityIdx & this.misMask) != 0L;
    }

    //	// Token: 0x0600219E RID: 8606 RVA: 0x000E6DA0 File Offset: 0x000E4FA0
    //	public void SetMisMask(int bityIdx)
    //	{
    //		if (bityIdx < 0 || bityIdx >= 64)
    //		{
    //			return;
    //		}
    //		this.misMask |= 1L << bityIdx;
    //	}

    public MissionState GetMissionState(int ID)
    {
        //if (this.IsLinkCompleted(ID))
        //{
        //    return MissionState.MS_Completed;
        //}
        //AccMisInfo accMisInfo = this.GetAccMisInfo(ID);
        //if (accMisInfo != null)
        //{
        //    if (this.IsAccMisInfoComplete(accMisInfo))
        //    {
        //        return MissionState.MS_Doing_Cmp;
        //    }
        //    return MissionState.MS_Doing;
        //}
        return MissionState.MS_Doing;
        //else
        //{
        //    int linkId = ID / 1000;
        //    //MissionInfo missionInfo = GameData.Instance.RoleData.GetMissionInfo(ID);
        //    //if (missionInfo == null)
        //    //{
        //    //    Logger.LogWarning(new object[]
        //    //    {
        //    //            "Can't find mission config:" + ID
        //    //    });
        //    //    return MissionState.MS_UnAccept;
        //    //}
        //    //int step = missionInfo.step;
        //    //ModMission.MisLinkInfo inMisLinkList = this.GetInMisLinkList(linkId);
        //    //if (inMisLinkList == null)
        //    //{
        //    //    if (step == 1)
        //    //    {
        //    //        return MissionState.MS_UnAccept;
        //    //    }
        //    //    return MissionState.MS_UnAccept_Canot;
        //    //}
        //    //else
        //    //{
        //    //    if (inMisLinkList.curStep > step)
        //    //    {
        //    //        return MissionState.MS_Completed;
        //    //    }
        //    //    if (inMisLinkList.curStep < step)
        //    //    {
        //    //        return MissionState.MS_UnAccept_Canot;
        //    //    }
        //       return MissionState.MS_UnAccept;
        //    //}
        //}
    }

    public AccMisInfo GetAccMisInfo(int ID)
    {
        for (int i = 0; i < this.accMisList.Count; i++)
        {
            if (this.accMisList[i].ID == ID)
            {
                return this.accMisList[i];
            }
        }
        return null;
    }

    //	public ModMission.MisEndInfo GetAccMisEndInfo()
    //	{
    //		return this.m_MisEndInfo;
    //	}

    /// <summary>
    /// 更新任务进展
    /// </summary>
    /// <param name="aimType"></param>
    /// <param name="aimData"></param>
    public void UpdateMissionProgress(int aimType, int aimData)
    {
        for (int i = 0; i < this.accMisList.Count; i++)
        {
            AccMisInfo accMisInfo = this.accMisList[i];
            if (accMisInfo == null)
            {
                return;
            }

            if (this.IsAccMisInfoComplete(accMisInfo))
            {
                return;
            }

            int num = 0;
            for (int j = 0; j < accMisInfo.MissionAimList.Count; j++)
            {
                if (aimData == accMisInfo.MissionAimList[j].AimData && aimType == accMisInfo.MissionAimList[j].AimType)
                {
                    num = accMisInfo.MissionAimList[j].Count;
                    break;
                }
            }
            if (num == 0)
            {
                return;
            }

            string[] completeStateStr = accMisInfo.GetCompleteStateStr();
            if (completeStateStr.Length != accMisInfo.MissionAimList.Count)
            {
                Debug.LogWarning("AimStr's Length is not match the ami.AimList.Count.");
            }

            for (int k = 0; k < accMisInfo.MissionAimList.Count; k++)
            {
                if (aimType == accMisInfo.MissionAimList[k].AimType && accMisInfo.MissionAimList[k].Count < num)
                {
                    accMisInfo.MissionAimList[k].Count++;
                    string text = string.Concat(new object[]
                    {
                            completeStateStr[k],
                            " ",
                            accMisInfo.MissionAimList[k].Count,
                            "/",
                            num
                    });
                    if (accMisInfo.MissionAimList[k].Count >= num)
                    {
                        accMisInfo.Complete = true;
                    }
                    else
                    {
                        accMisInfo.Complete = false;
                    }
                    break;
                }
            }

            if (accMisInfo.MisInfo.CompleteNpc == -1)
            {
                Debug.Log("完成任务 : " + accMisInfo.ID.ToString() + "名称 : " + accMisInfo.MisInfo.Name);
                //GameData.Instance.ScrMan.Exec(5, accMisInfo.ID);
            }
        }
    }

    /// <summary>
    /// 是否已经完成任务
    /// </summary>
    /// <param name="ami"></param>
    /// <returns></returns>
    public bool IsAccMisInfoComplete(AccMisInfo ami)
    {
        if (ami.Complete)
        {
            return true;
        }
        for (int i = 0; i < ami.MissionAimList.Count; i++)
        {
            MissionInfo.MissionAimInfo missionAimInfo = ami.MissionAimList[i];
            if (missionAimInfo.Count > 0)
            {
                if (missionAimInfo.AimType == 7)
                {
                    int num = 10000;
                    if (num < missionAimInfo.Count)
                    {
                        return false;
                    }
                }
                else
                {
                    bool flag = false;
                    int j = 0;
                    while (j < ami.MissionAimList.Count)
                    {
                        if (missionAimInfo.AimType == ami.MissionAimList[j].AimType)
                        {
                            flag = true;
                            if (ami.MissionAimList[j].CurCount < missionAimInfo.Count)
                            {
                                return false;
                            }
                            break;
                        }
                        else
                        {
                            j++;
                        }
                    }
                    if (!flag)
                    {
                        Debug.LogWarning("错误：接受的任务数据和静态任务数据不匹配。");
                        return false;
                    }
                }
            }
        }
        return true;
    }

    /// <summary>
    /// 检查任务状况
    /// </summary>
    /// <param name="nID"></param>
    /// <returns></returns>
    public bool CheckMissionCondition(int nID)
    {
        if (this.IsLinkCompleted(nID))//检查任务是否完成
        {
            Debug.Log("Mission link " + nID / 1000 + " has completed!");
            return false;
        }

        if (this.IsInAccLinkList(nID))//检查链接任务是否完成 前置任务
        {
            Debug.Log("Mission link "+nID % 1000+", step "+nID % 1000+" has accept!");
            return false;
        }
        return true;
    }

    //	// Token: 0x060021A5 RID: 8613 RVA: 0x000E72DC File Offset: 0x000E54DC
    //	public void CheckSkipMission(int nID)
    //	{
    //		if (!this.IsLinkCompleted(nID))
    //		{
    //			return;
    //		}
    //		MissionInfo missionInfo = GameData.Instance.RoleData.GetMissionInfo(nID);
    //		if (missionInfo == null)
    //		{
    //			return;
    //		}
    //		if (missionInfo.MissType == 1)
    //		{
    //			if (missionInfo.MissVal.Count == 0)
    //			{
    //				return;
    //			}
    //			for (int i = 0; i < missionInfo.MissVal.Count; i++)
    //			{
    //				Logger.Log(new object[]
    //				{
    //					"acc = " + missionInfo.MissVal[i].ToString()
    //				});
    //				this.AcceptMission(missionInfo.MissVal[i]);
    //			}
    //		}
    //	}

    /// <summary>
    /// 任务关联信息
    /// </summary>
    [Serializable]
    public class MisLinkInfo
    {
        public int linkId;

        public int curStep;

        public List<MissionInfo.MissionAimInfo> AimList = new List<MissionInfo.MissionAimInfo>();

        public MisLinkInfo Clone()
        {
            return new MisLinkInfo
            {
                linkId = this.linkId,
                curStep = this.curStep
            };
        }
    }

    [Serializable]
    public class AccMisInfo_SD
    {
        public int ID;

        public bool Complete;

        //		public int LinkId
        //		{
        //			get
        //			{
        //				return this.ID / 1000;
        //			}
        //			set
        //			{
        //			}
        //		}

        //		// Token: 0x170003FE RID: 1022
        //		// (get) Token: 0x060021AC RID: 8620 RVA: 0x000E73E8 File Offset: 0x000E55E8
        //		// (set) Token: 0x060021AB RID: 8619 RVA: 0x000E73E4 File Offset: 0x000E55E4
        //		public int Step
        //		{
        //			get
        //			{
        //				return this.ID % 1000;
        //			}
        //			set
        //			{
        //			}
        //		}

        //		// Token: 0x060021AD RID: 8621 RVA: 0x000E73F8 File Offset: 0x000E55F8
        //		public ModMission.AccMisInfo Clone2Nor()
        //		{
        //			ModMission.AccMisInfo accMisInfo = new ModMission.AccMisInfo();
        //			accMisInfo.ID = this.ID;
        //			accMisInfo.Complete = this.Complete;
        //			accMisInfo.MisInfo = null;
        //			for (int i = 0; i < this.AimList.Count; i++)
        //			{
        //				accMisInfo.AimList.Add(this.AimList[i].Clone());
        //			}
        //			return accMisInfo;
        //		}
    }

    /// <summary>
    /// 接受任务信息
    /// </summary>
    public class AccMisInfo
    {
        public int ID;

        public bool Complete;

        /// <summary>
        /// 任务目标列表
        /// </summary>
        public List<MissionInfo.MissionAimInfo> MissionAimList = new List<MissionInfo.MissionAimInfo>();

        public MissionEntity MisInfo;

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

        //		public ModMission.AccMisInfo_SD Clone2SD()
        //		{
        //			ModMission.AccMisInfo_SD accMisInfo_SD = new ModMission.AccMisInfo_SD();
        //			accMisInfo_SD.ID = this.ID;
        //			accMisInfo_SD.Complete = this.Complete;
        //			for (int i = 0; i < this.AimList.Count; i++)
        //			{
        //				accMisInfo_SD.AimList.Add(this.AimList[i].Clone());
        //			}
        //			return accMisInfo_SD;
        //		}

        public string[] GetCompleteStateStr()
        {
            string[] array = new string[this.MissionAimList.Count];
            for (int i = 0; i < this.MissionAimList.Count; i++)
            {
                MissionInfo.MissionAimInfo missionAimInfo = this.MissionAimList[i];
                if (string.Compare(missionAimInfo.AimDis, "null", true) != 0)
                {
                    array[i] = missionAimInfo.AimDis;
                }
                else if (missionAimInfo.AimType != 7)
                {
                    if (missionAimInfo.AimType == 6)
                    {
                        array[i] = "怪物名称";
                        //array[i] = GameData.Instance.RoleData.GetMonsterNameById(missionAimInfo.AimData);
                    }
                }
            }
            return array;
        }
    }

    public class MisEndInfoData
        {
            //public ModMission.AccMisInfo amDesc;

            //public Color tColor;

            //		// Token: 0x060021B5 RID: 8629 RVA: 0x000E75A8 File Offset: 0x000E57A8
            //		public MisEndInfoData(ModMission.AccMisInfo amDestInfo, Color tDestColor)
            //		{
            //			this.amDesc = amDestInfo;
            //			this.tColor = tDestColor;
            //		}

        }

        public class MisEndInfo
    {

        //		// Token: 0x060021BB RID: 8635 RVA: 0x000E7730 File Offset: 0x000E5930
        //		public int GetMisEndInfoCount()
        //		{
        //			return this.m_lstMisEndInfo.Count;
        //		}

        //		// Token: 0x04001EE1 RID: 7905
        //		public Dictionary<int, Color> m_tTypeColor = new Dictionary<int, Color>();

        //		// Token: 0x04001EE2 RID: 7906
        //		public Dictionary<string, ModMission.MisEndInfoData> m_lstMisEndInfo = new Dictionary<string, ModMission.MisEndInfoData>();

        //		// Token: 0x060021B6 RID: 8630 RVA: 0x000E75C0 File Offset: 0x000E57C0
        //		public MisEndInfo()
        //		{
        //			this.m_tTypeColor.Clear();
        //			this.Clear();
        //		}

        //		// Token: 0x060021B7 RID: 8631 RVA: 0x000E75F0 File Offset: 0x000E57F0
        //		public bool AddInfo(ModMission.MisEndInfoData meDesc)
        //		{
        //			if (this.m_lstMisEndInfo.ContainsKey(meDesc.amDesc.ID.ToString()))
        //			{
        //				Logger.LogWarning(new object[]
        //				{
        //					"====add info failed! id=" + meDesc.amDesc.ID.ToString()
        //				});
        //				return false;
        //			}
        //			this.m_lstMisEndInfo.Add(meDesc.amDesc.ID.ToString(), meDesc);
        //			Logger.Log(new object[]
        //			{
        //				"add mis endinfo id: " + meDesc.amDesc.ID.ToString()
        //			});
        //			return true;
        //		}

        //		// Token: 0x060021B8 RID: 8632 RVA: 0x000E768C File Offset: 0x000E588C
        //		public bool SetMisEndTypeColor(int nIndex, Color tColor)
        //		{
        //			if (nIndex != 0)
        //			{
        //				return false;
        //			}
        //			this.m_tTypeColor[0] = tColor;
        //			return true;
        //		}

        //		// Token: 0x060021B9 RID: 8633 RVA: 0x000E76A4 File Offset: 0x000E58A4
        //		public void Clear()
        //		{
        //			this.m_lstMisEndInfo.Clear();
        //			for (int i = 0; i < 3; i++)
        //			{
        //				this.SetMisEndTypeColor(i, new Color(1f, 1f, 1f, 1f));
        //			}
        //		}

        //		// Token: 0x060021BA RID: 8634 RVA: 0x000E76F0 File Offset: 0x000E58F0
        //		public ModMission.MisEndInfoData GetMisEndData(string szIDKey)
        //		{
        //			if (!this.m_lstMisEndInfo.ContainsKey(szIDKey))
        //			{
        //				Logger.LogWarning(new object[]
        //				{
        //					"GetMisEndData at failed id!"
        //				});
        //				return null;
        //			}
        //			return this.m_lstMisEndInfo[szIDKey];
        //		}
    }
}
