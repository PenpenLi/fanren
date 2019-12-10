using System;
using System.Collections;
using System.Collections.Generic;
//using BevAI;
using NS_RoleBaseFun;
using UnityEngine;
using UnityUtility;

/// <summary>
/// 角色数据信息
/// </summary>
public class RoleDateInfo
{
    public static string BPN_HEAD = "Bip01 Head";

    public static string BPN_LHAND = "Bip01 L Hand";

    public static string BPN_RHAND = "Bip01 R Hand";

    //private List<EnemySkill> _enemySkill = new List<EnemySkill>();

    private List<MonsterInfo> _monsterInfo = new List<MonsterInfo>();

    //private List<RolePartInfo> rolePartInfoList = new List<RolePartInfo>();

    private List<string> _PatrolInfo = new List<string>();

    private List<OrganizationInfo> _orgList = new List<OrganizationInfo>();

    //private List<ScriptNodeBase> _scriptList = new List<ScriptNodeBase>();

    public List<NpcInfo> NpcInfoList = new List<NpcInfo>();

    public List<MissionInfo> MissionInfoList = new List<MissionInfo>();

    public List<MissionContent> MissionContentList = new List<MissionContent>();

    //public List<ChapterInfo> ChapterInfoList = new List<ChapterInfo>();

    //public List<SoulBallInfo> SoulBallInfoList = new List<SoulBallInfo>();

    public Hashtable StringResTable = new Hashtable();

    public Hashtable monsterTable = new Hashtable();

    //public List<DropItemRuleInfo> DropItemRuleInfoList = new List<DropItemRuleInfo>();

    //public List<HatredRuleInfo> HatRleInfList = new List<HatredRuleInfo>();

    //public List<RandomSkillsInfo> RandserSkillsInfList = new List<RandomSkillsInfo>();

    private bool _bLoaded;

    public class AtkExAniIni
    {
        public int ID;

        public List<AniInfo.AtkExAniInfo> atkExAniInfoList = new List<AniInfo.AtkExAniInfo>();
    }

    public void LoadConf()
	{
		if (this._bLoaded)
		{
			return;
		}
		this.ReadMonsterInfo();
		//this.ReadRolePartInfo();
		//this.ReadEnemySkill();
		//this.ReadHatredRuleInfo();
		//this.ReadPatrolInfo();
		//this.ReadScriptNodeInfo();
		//this.ReadStringRes();
		this.ReadNpcInfo();
		this.ReadMissionInfo();
		//this.ReadChapterInfo();
		//this.ReadSoulBallInfo();
		//this.ReadRandomSkillInfo();
		this.ReadOrganizationInfo();
		//BevTreeData.LoadFromTxt();
		//this.ReadDropItemRule();
		//this.ReadOrganizationInfo();
		this._bLoaded = true;
	}

	public string GetStr(int id)
	{
		if (this.StringResTable.Contains(id))
		{
			return (string)this.StringResTable[id];
		}
		return null;
	}

	private void ReadRandomSkillInfo()
	{
		//this.RandserSkillsInfList.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets("RandomSkill");
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			int num = 0;
			//RandomSkillsInfo randomSkillsInfo = new RandomSkillsInfo();
			//randomSkillsInfo.ID = Convert.ToInt32(array[num++]);
			int num2 = Convert.ToInt32(array[num++]);
			for (int i = 0; i < num2; i++)
			{
				MonsterSkill monsterSkill = new MonsterSkill();
				monsterSkill.SkillID = Convert.ToInt32(array[num++]);
				monsterSkill.UseRule = (SkillUselRule)Convert.ToInt32(array[num++]);
				//randomSkillsInfo.RanderSkillList.Add(monsterSkill);
			}
			//this.RandserSkillsInfList.Add(randomSkillsInfo);
		}
	}

	//public RandomSkillsInfo GetRandomSkillInfoByID(int id)
	//{
	//	foreach (RandomSkillsInfo randomSkillsInfo in this.RandserSkillsInfList)
	//	{
	//		if (randomSkillsInfo.ID == id)
	//		{
	//			return randomSkillsInfo;
	//		}
	//	}
	//	return null;
	//}

	//private void ReadHatredRuleInfo()
	//{
	//	this.HatRleInfList.Clear();
	//	List<string> list = RoleBaseFun.LoadConfInAssets("HatredRuleInfo");
	//	foreach (string text in list)
	//	{
	//		string[] array = text.Split(CacheData.separator);
	//		int num = 0;
	//		HatredRuleInfo hatredRuleInfo = new HatredRuleInfo();
	//		hatredRuleInfo.ID = Convert.ToInt32(array[num++]);
	//		int num2 = Convert.ToInt32(array[num++]);
	//		for (int i = 0; i < num2; i++)
	//		{
	//			HatredRuleInfo.singleInfo singleInfo = new HatredRuleInfo.singleInfo();
	//			singleInfo.HatRlType = (HatredRuleInfo.HatredRuleType)Convert.ToInt32(array[num++]);
	//			singleInfo.roleType = Convert.ToInt32(array[num++]);
	//			singleInfo.initValue = Convert.ToSingle(array[num++]);
	//			hatredRuleInfo.infoList.Add(singleInfo);
	//		}
	//		this.HatRleInfList.Add(hatredRuleInfo);
	//	}
	//}

	//public HatredRuleInfo GetInitHatredInfo(int id)
	//{
	//	foreach (HatredRuleInfo hatredRuleInfo in this.HatRleInfList)
	//	{
	//		if (hatredRuleInfo.ID == id)
	//		{
	//			return hatredRuleInfo;
	//		}
	//	}
	//	return null;
	//}

	private void ReadStringRes()
	{
		this.StringResTable.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets("StringRes");
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			int num = 0;
			int num2 = Convert.ToInt32(array[num]);
			num++;
			if (this.StringResTable.Contains(num2))
			{
                Debug.LogError("id 冲突:" + num2);
				break;
			}
			this.StringResTable[num2] = array[num];
		}
	}

    private void ReadMissionContent()
    {
        this.MissionContentList.Clear();
        List<string> list = RoleBaseFun.LoadConfInAssets("MissionContent");
        foreach (string text in list)
        {
            string[] array = text.Split(CacheData.separator);
            MissionContent missionContent = new MissionContent();
            missionContent.bIsSucceed = false;
            int num = 0;
            if (missionContent.SetMissionID(Convert.ToInt32(array[num])))
            {
                num++;
                if (missionContent.SetStepID(Convert.ToInt32(array[num])))
                {
                    num++;
                    missionContent.Str = array[num];
                    num++;
                    missionContent.bIsSucceed = true;
                    this.MissionContentList.Add(missionContent);
                }
            }
        }
    }

    //// Token: 0x06000763 RID: 1891 RVA: 0x0001F8C0 File Offset: 0x0001DAC0
    //public string GetMissionContentByID(int id)
    //{
    //	foreach (MissionContent missionContent in this.MissionContentList)
    //	{
    //		if (missionContent.ID == id)
    //		{
    //			return missionContent.Str;
    //		}
    //	}
    //	return null;
    //}

    private void ReadMissionInfo()
    {
        this.ReadMissionContent();
        //this.MissionInfoList.Clear();
        //List<string> list = RoleBaseFun.LoadConfInAssets("MissionInfo");
        //Hashtable hashtable = new Hashtable();
        //foreach (string text in list)
        //{
        //    string[] array = text.Split(CacheData.separator);
        //    MissionInfo missionInfo = new MissionInfo();
        //    int num = 0;
        //    missionInfo.ID = Convert.ToInt32(array[num++]);
        //    missionInfo.step = Convert.ToInt32(array[num++]);
        //    missionInfo.StepAmount = 0;
        //   // int num2 = (int)(missionInfo.Type * (MissionType)1000 + missionInfo.LinkID);
        //    //if (hashtable.Contains(num2))
        //    //{
        //    //    int num3 = (int)hashtable[num2];
        //    //    hashtable[num2] = num3 + 1;
        //    //}
        //    //else
        //    //{
        //    //    hashtable.Add(num2, 1);
        //    //}
        //    missionInfo.Mask = Convert.ToInt32(array[num]);
        //    num++;
        //    missionInfo.Name = array[num];
        //    num++;
        //    missionInfo.AimDescribe = array[num];
        //    num++;
        //    missionInfo.AimRequire = array[num];
        //    num++;
        //    missionInfo.PicPath = array[num];
        //    num++;
        //    missionInfo.PicBigPath = array[num];
        //    num++;
        //    missionInfo.CompleteNpc = Convert.ToInt32(array[num]);
        //    num++;
        //    missionInfo.MissType = Convert.ToInt32(array[num]);
        //    if (missionInfo.InvalidMissType(missionInfo.MissType))
        //    {
        //        Debug.Log(new object[]
        //        {
        //            "MissionInfo File Error !"
        //        });
        //    }
        //    num++;
        //    missionInfo.MissValCount = Convert.ToInt32(array[num]);
        //    num++;
        //    if (array.Length < missionInfo.MissValCount + num)
        //    {
        //        Debug.Log(new object[]
        //        {
        //            "MissionInfo File Length Error ! =",
        //            array.Length.ToString() + "/" + num.ToString()
        //        });
        //    }
        //    else
        //    {
        //        missionInfo.MissVal.Clear();
        //        for (int i = 0; i < missionInfo.MissValCount; i++)
        //        {
        //            missionInfo.MissVal.Add(Convert.ToInt32(array[num]));
        //            num++;
        //        }
        //       // missionInfo.ComSMT = (ScrModType)Convert.ToInt32(array[num]);
        //        num++;
        //        missionInfo.ComSMTDate = Convert.ToInt32(array[num]);
        //        num++;
        //        missionInfo.RewardItemList.Clear();
        //        int num4 = Convert.ToInt32(array[num]);
        //        num++;
        //        missionInfo.MissionAimList.Clear();
        //        for (int j = 0; j < num4; j++)
        //        {
        //            MissionInfo.MissionAimInfo missionAimInfo = new MissionInfo.MissionAimInfo();
        //            missionAimInfo.AimType = Convert.ToInt32(array[num]);
        //            num++;
        //            missionAimInfo.AimDis = array[num];
        //            num++;
        //            missionAimInfo.AimData = Convert.ToInt32(array[num]);
        //            num++;
        //            missionAimInfo.Count = Convert.ToInt32(array[num]);
        //            num++;
        //            missionInfo.MissionAimList.Add(missionAimInfo);
        //        }
        //       // missionInfo.MissionConList.Clear();
        //        for (int k = 0; k < this.MissionContentList.Count; k++)
        //        {
        //            if (this.MissionContentList[k].ID == missionInfo.ID)
        //            {
        //             //   missionInfo.MissionConList.Add(this.MissionContentList[k]);
        //            }
        //        }
        //        this.MissionInfoList.Add(missionInfo);
        //    }
        //}
        //for (int l = 0; l < this.MissionInfoList.Count; l++)
        //{
        //    //int num5 = (int)(this.MissionInfoList[l].Type * (MissionType)1000 + this.MissionInfoList[l].LinkID);
        //    //if (hashtable.Contains(num5))
        //    //{
        //    //    this.MissionInfoList[l].StepAmount = (int)hashtable[num5];
        //    //}
        //    //else
        //    //{
        //    //    Debug.Log(new object[]
        //    //    {
        //    //        "错误：无法正确设置任务步数。"
        //    //    });
        //    //}
        //}
    }

    //// Token: 0x06000765 RID: 1893 RVA: 0x0001FDC0 File Offset: 0x0001DFC0
    //public MissionInfo GetMissionInfo(int ID)
    //{
    //	for (int i = 0; i < this.MissionInfoList.Count; i++)
    //	{
    //		if (this.MissionInfoList[i].ID == ID)
    //		{
    //			return this.MissionInfoList[i];
    //		}
    //	}
    //	return null;
    //}

    private void ReadNpcInfo()
    {
        this.NpcInfoList.Clear();
        List<string> list = RoleBaseFun.LoadConfInAssets("npcInfo");
        foreach (string text in list)
        {
            string[] array = text.Split(CacheData.separator);
            if (array.Length != 11)
            {
                Debug.LogError("npcInfo.txt 格式错误");
                break;
            }
            NpcInfo npcInfo = new NpcInfo();
            int num = 0;
            npcInfo.ID = Convert.ToInt32(array[num]);
            num++;
            npcInfo.ModelID = Convert.ToInt32(array[num]);
            num++;
            npcInfo.HeadPicPath = array[num];
            num++;
            npcInfo.Name = array[num];
            num++;
            npcInfo.OrgType = (ORG_TYPE)Convert.ToInt32(array[num]);
            num++;
            npcInfo.scriptModID = Convert.ToInt32(array[num]);
            num++;
            npcInfo.scriptDataID = Convert.ToInt32(array[num]);
            num++;
            npcInfo.bevNodeType = Convert.ToInt32(array[num]);
            num++;
            npcInfo.ViewRange = Convert.ToSingle(array[num]);
            num++;
            npcInfo.prepareDis = Convert.ToInt32(array[num]);
            num++;
            npcInfo.walkSpeed = Convert.ToSingle(array[num]);
            this.NpcInfoList.Add(npcInfo);
        }
    }

    public NpcInfo GetNpcByType(int nType)
    {
        for (int i = 0; i < this.NpcInfoList.Count; i++)
        {
            if (this.NpcInfoList[i].ID == nType)
            {
                return this.NpcInfoList[i];
            }
        }
        return null;
    }

    //// Token: 0x06000768 RID: 1896 RVA: 0x0001FFF8 File Offset: 0x0001E1F8
    //private void ReadChapterInfo()
    //{
    //	this.ChapterInfoList.Clear();
    //	List<string> list = RoleBaseFun.LoadConfInAssets("ChapterInfo");
    //	foreach (string text in list)
    //	{
    //		string[] array = text.Split(CacheData.separator);
    //		ChapterInfo chapterInfo = new ChapterInfo();
    //		int num = 0;
    //		chapterInfo.chapterIndex = Convert.ToInt32(array[num]);
    //		num++;
    //		chapterInfo.missionDescribe = array[num];
    //		num++;
    //		chapterInfo.missionPicPath = array[num];
    //		this.ChapterInfoList.Add(chapterInfo);
    //	}
    //}

    //// Token: 0x06000769 RID: 1897 RVA: 0x000200C0 File Offset: 0x0001E2C0
    //public ChapterInfo GetChapterByType(int nType)
    //{
    //	for (int i = 0; i < this.ChapterInfoList.Count; i++)
    //	{
    //		if (this.ChapterInfoList[i].chapterIndex == nType)
    //		{
    //			return this.ChapterInfoList[i];
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x0600076A RID: 1898 RVA: 0x00020110 File Offset: 0x0001E310
    //private void ClearInfo()
    //{
    //	for (int i = 0; i < this._enemySkill.Count; i++)
    //	{
    //		this._enemySkill[i] = null;
    //	}
    //	this._enemySkill.Clear();
    //	for (int j = 0; j < this._monsterInfo.Count; j++)
    //	{
    //		this._monsterInfo[j] = null;
    //	}
    //	this._monsterInfo.Clear();
    //	for (int k = 0; k < this._PatrolInfo.Count; k++)
    //	{
    //		this._PatrolInfo[k] = null;
    //	}
    //	this._PatrolInfo.Clear();
    //}

    public void ReadPatrolInfo()
	{
		string item = "PatrolRoute1";
		this._PatrolInfo.Add(item);
	}

	//public void ReadEnemySkill()
	//{
	//	EnemySkill enemySkill = new EnemySkill();
	//	enemySkill.skillID = 0;
	//	enemySkill.skillName = "Fire Ball";
	//	enemySkill.EsType = EnemySkill.ES_Type.ES_Area;
	//	enemySkill.EsDamage = 10;
	//	enemySkill.MaxDistance = 10;
	//	enemySkill.MinDistance = 4;
	//	enemySkill.aniName = "g_1";
	//	enemySkill.MpNeed = 10;
	//	enemySkill.startEffect = "Chant";
	//	enemySkill.staEffBindPos = BIND_POS.BP_LHAND;
	//	this._enemySkill.Add(enemySkill);
	//}

	public long GetAniId(long nHorse, long nWeaponIndex, long nMeshIndex, long nAniIndex)
	{
		return nHorse * 100000000000L + nWeaponIndex * 100000000L + nMeshIndex * 10000L + nAniIndex;
	}

	private void AnalyticalAniId(long id, ref int nHorse, ref int nWeaponIndex, ref int nMeshIndex, ref int nAniIndex)
	{
		nAniIndex = (int)(id % 10000L);
		id /= 10000L;
		nMeshIndex = (int)(id % 1000L);
		id /= 1000L;
		nWeaponIndex = (int)(id % 1000L);
		id /= 1000L;
		nHorse = (int)id;
	}

    //public void ReadSoulBallInfo()
    //{
    //	this.SoulBallInfoList.Clear();
    //	List<string> list = UtilityLoader.LoadConfText("conf/SoulBallInfo");
    //	int i = 0;
    //	while (i < list.Count)
    //	{
    //		SoulBallInfo soulBallInfo = new SoulBallInfo();
    //		soulBallInfo.ID = Convert.ToInt32(list[i]);
    //		i++;
    //		soulBallInfo.PrefabPath = list[i];
    //		i++;
    //		int num = Convert.ToInt32(list[i]);
    //		soulBallInfo.AutoActive = (num == 1);
    //		i++;
    //		soulBallInfo.ModId = Convert.ToInt32(list[i]);
    //		i++;
    //		soulBallInfo.ModData = Convert.ToSingle(list[i]);
    //		i++;
    //		soulBallInfo.LastTime = Convert.ToSingle(list[i]);
    //		i++;
    //		soulBallInfo.roleEffectIdx = Convert.ToInt32(list[i]);
    //		i++;
    //		this.SoulBallInfoList.Add(soulBallInfo);
    //	}
    //}

    //// Token: 0x06000770 RID: 1904 RVA: 0x000203C0 File Offset: 0x0001E5C0
    //public SoulBallInfo GetSoulBallInfoById(int id)
    //{
    //	for (int i = 0; i < this.SoulBallInfoList.Count; i++)
    //	{
    //		if (id == this.SoulBallInfoList[i].ID)
    //		{
    //			return this.SoulBallInfoList[i];
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x06000771 RID: 1905 RVA: 0x00020410 File Offset: 0x0001E610
    //public void ReadScriptNodeInfo()
    //{
    //	this._scriptList.Clear();
    //	List<string> list = RoleBaseFun.LoadConfInAssets("ScriptInfo");
    //	foreach (string text in list)
    //	{
    //		string[] array = text.Split(CacheData.separator);
    //		int num = 0;
    //		uint id = (uint)Convert.ToInt32(array[num]);
    //		num++;
    //		SCRIPT_NODE_TYPE script_NODE_TYPE = (SCRIPT_NODE_TYPE)Convert.ToInt32(array[num]);
    //		SCRIPT_NODE_TYPE script_NODE_TYPE2 = script_NODE_TYPE;
    //		if (script_NODE_TYPE2 != SCRIPT_NODE_TYPE.SNT_SCRIPT)
    //		{
    //			if (script_NODE_TYPE2 == SCRIPT_NODE_TYPE.SNT_PLAYANIM)
    //			{
    //				num++;
    //				ACTION_INDEX actIdx = (ACTION_INDEX)Convert.ToInt32(array[num]);
    //				PlayAniScriptNode item = new PlayAniScriptNode(id, script_NODE_TYPE, actIdx);
    //				this._scriptList.Add(item);
    //			}
    //		}
    //	}
    //}

    public void ReadOrganizationInfo()
    {
        this._orgList.Clear();
        List<string> list = RoleBaseFun.LoadConfInAssets("OrganizationInfo");
        foreach (string text in list)
        {
            string[] array = text.Split(CacheData.separator);
            if (array.Length >= 3)
            {
                int num = 0;
                OrganizationInfo organizationInfo = new OrganizationInfo();
                organizationInfo.OrgType = (ORG_TYPE)Convert.ToInt32(array[num]);
                organizationInfo.RepList.Clear();
                num++;
                for (int i = 0; i < 3; i++)
                {
                    if (organizationInfo.OrgType == (ORG_TYPE)i)
                    {
                        num++;
                    }
                    else
                    {
                        OrganizationInfo.Reputation reputation = new OrganizationInfo.Reputation();
                        reputation.orgType = (ORG_TYPE)i;
                        reputation.value = Convert.ToInt32(array[num]);
                        num++;
                        organizationInfo.RepList.Add(reputation);
                    }
                }
                this._orgList.Add(organizationInfo);
            }
        }
    }

    public OrganizationInfo GetOrgInfoByType(ORG_TYPE orgType)
    {
        foreach (OrganizationInfo organizationInfo in this._orgList)
        {
            if (organizationInfo.OrgType == orgType)
            {
                return organizationInfo;
            }
        }
        return null;
    }

    //// Token: 0x06000774 RID: 1908 RVA: 0x000206A0 File Offset: 0x0001E8A0
    //public RolePartInfo GetRolePart(int id)
    //{
    //	for (int i = 0; i < this.rolePartInfoList.Count; i++)
    //	{
    //		if (id == this.rolePartInfoList[i].ID)
    //		{
    //			return this.rolePartInfoList[i];
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x06000775 RID: 1909 RVA: 0x000206F0 File Offset: 0x0001E8F0
    //public void ReadRolePartInfo()
    //{
    //	List<string> list = UtilityLoader.LoadConfText("conf/roleparts");
    //	this.rolePartInfoList.Clear();
    //	int i = 0;
    //	while (i < list.Count)
    //	{
    //		RolePartInfo rolePartInfo = new RolePartInfo();
    //		rolePartInfo.ID = Convert.ToInt32(list[i]);
    //		i++;
    //		rolePartInfo.rolePartType = (RolePartType)Convert.ToInt32(list[i]);
    //		i++;
    //		rolePartInfo.PrefabPath = list[i];
    //		i++;
    //		rolePartInfo.BindPos = (RoleChildType)Convert.ToInt32(list[i]);
    //		i++;
    //		this.rolePartInfoList.Add(rolePartInfo);
    //	}
    //}

    public void ReadMonsterInfo()
	{
		List<string> list = UtilityLoader.LoadConfText("conf/monster");
		this.monsterTable.Clear();
		int i = 0;
		while (i < list.Count)
		{
			MonsterInfo monsterInfo = new MonsterInfo();
			monsterInfo.MonsterID = Convert.ToInt32(list[i]);
			this.monsterTable.Add(monsterInfo.MonsterID, 0);
			i++;
			monsterInfo.RealMeshName = list[i];
			i++;
			monsterInfo.ModelID = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.HeadPicPath = list[i];
			i++;
			monsterInfo.Name = list[i];
			i++;
			monsterInfo.HurtID = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.MassNumber = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.bevTreeID = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.QTEId = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.AtkRange = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.PhyDamage = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.MagicDamage = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.PhyDefense = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.MagicDefense = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.metal = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.wood = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.water = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.fire = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.earth = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.ViewRange = Convert.ToSingle(list[i]);
			i++;
			int aniMove = Convert.ToInt32(list[i]);
			monsterInfo.AniMove = (aniMove != 0);
			i++;
			monsterInfo.MoveSpeed = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.HMoveSpeed = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.BMoveSpeed = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.TurnSpeed = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.Mp = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.Hp = Convert.ToInt32(list[i]);
			i++;
			monsterInfo._attackInterval = (float)Convert.ToInt32(list[i]) / 1000f;
			i++;
			monsterInfo.identity = (IdentityType)Convert.ToInt32(list[i]);
			i++;
			monsterInfo.PrepareTime = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.PrepareDis = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.AttackTimes = Convert.ToInt32(list[i]);
			i++;
			int num = Convert.ToInt32(list[i]);
			monsterInfo.CallPartner = (num >= 1);
			i++;
			int num2 = Convert.ToInt32(list[i]);
			monsterInfo.MoveBack = (num2 == 1);
			i++;
			int num3 = Convert.ToInt32(list[i]);
			monsterInfo.LateralMove = (num3 == 1);
			i++;
			int num4 = Convert.ToInt32(list[i]);
			monsterInfo.Flee = (num4 >= 1);
			i++;
			monsterInfo.FleeHpPercent = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.BegProbability = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.DieScriptMod = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.DieScriptData = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.InBattleWord = list[i];
			i++;
			monsterInfo.ProvokeWord = list[i];
			i++;
			monsterInfo.FleeWord = list[i];
			i++;
			monsterInfo._randerSkillsID = Convert.ToInt32(list[i++]);
			monsterInfo._randerSkillCount = Convert.ToInt32(list[i++]);
			monsterInfo._attackSkill = new List<MonsterSkill>();
			monsterInfo._attackSkill.Clear();
			for (int j = 0; j < 11; j++)
			{
				MonsterSkill monsterSkill = new MonsterSkill();
				monsterSkill.SkillID = Convert.ToInt32(list[i]);
				i++;
				monsterSkill.UseRule = (SkillUselRule)Convert.ToInt32(list[i]);
				i++;
				monsterInfo._attackSkill.Add(monsterSkill);
			}
			monsterInfo._skillBuff = Convert.ToInt32(list[i]);
			i++;
			monsterInfo._skillBlood = Convert.ToInt32(list[i]);
			i++;
			for (int k = 0; k < 5; k++)
			{
				monsterInfo.DropRuleList.Add(Convert.ToInt32(list[i]));
				i++;
			}
			monsterInfo.dropSoulballRuleID = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.SoulAmount = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.RageAmount = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.Height = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.Distance = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.BloodType = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.SpawnEffect = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.HpHigh = Convert.ToSingle(list[i]);
			i++;
			monsterInfo.DieEffect = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.DieSound = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.DieRule = Convert.ToInt32(list[i]);
			i++;
			monsterInfo.BornBev = Convert.ToInt32(list[i]);
			i++;
			this._monsterInfo.Add(monsterInfo);
		}
	}

	//// Token: 0x06000777 RID: 1911 RVA: 0x00020DE0 File Offset: 0x0001EFE0
	//public ScriptNodeBase GetScriptNodeByIndex(uint idx)
	//{
	//	for (int i = 0; i < this._scriptList.Count; i++)
	//	{
	//		if (this._scriptList[i].ID == idx)
	//		{
	//			return this._scriptList[i];
	//		}
	//	}
	//	return null;
	//}

	//// Token: 0x06000778 RID: 1912 RVA: 0x00020E30 File Offset: 0x0001F030
	//public EnemySkill GetEnemySkillByIndex(int skillID)
	//{
	//	for (int i = 0; i < this._enemySkill.Count; i++)
	//	{
	//		if (this._enemySkill[i].skillID == skillID)
	//		{
	//			return this._enemySkill[i];
	//		}
	//	}
	//	return null;
	//}

	public MonsterInfo GetMonsterInfoByID(int monsterID)
	{
		for (int i = 0; i < this._monsterInfo.Count; i++)
		{
			if (this._monsterInfo[i].MonsterID == monsterID)
			{
				return this._monsterInfo[i];
			}
		}
		return null;
	}

	public MonsterInfo GetMonsterInfoByIndex(int index)
	{
		if (index < 0 || index >= this._monsterInfo.Count)
		{
			return null;
		}
		return this._monsterInfo[index];
	}

	public string GetMonsterNameById(int id)
	{
		MonsterInfo monsterInfoByID = this.GetMonsterInfoByID(id);
		if (monsterInfoByID == null)
		{
			return null;
		}
		return monsterInfoByID.Name;
	}

	public int GetMonsterInfoCount()
	{
		return this._monsterInfo.Count;
	}

	public int GetMonsterHash(int vaule)
	{
		if (this.monsterTable.Contains(vaule))
		{
			return (int)this.monsterTable[vaule];
		}
		return -1;
	}

	public void ChangeHash(int vaule, int tag)
	{
		if (this.monsterTable.Contains(vaule) && (int)this.monsterTable[vaule] != tag)
		{
			this.monsterTable.Remove(vaule);
			this.monsterTable.Add(vaule, tag);
		}
	}

	//public string GetBindPosName(BIND_POS pos)
	//{
	//	switch (pos)
	//	{
	//	case BIND_POS.BP_HEAD:
	//		return RoleDateInfo.BPN_HEAD;
	//	case BIND_POS.BP_LHAND:
	//		return RoleDateInfo.BPN_LHAND;
	//	case BIND_POS.BP_RHAND:
	//		return RoleDateInfo.BPN_RHAND;
	//	default:
	//		return null;
	//	}
	//}

	public string GetPatrolNameByIndex(int idx)
	{
		if (idx < 0 || idx >= this._PatrolInfo.Count)
		{
			return null;
		}
		return this._PatrolInfo[idx];
	}

	public int GetPatrolNameCount()
	{
		return this._PatrolInfo.Count;
	}

	//public void ReadDropItemRule()
	//{
	//	List<string> list = UtilityLoader.LoadConfText("conf/DropItemRule");
	//	this.DropItemRuleInfoList.Clear();
	//	int i = 0;
	//	while (i < list.Count)
	//	{
	//		DropItemRuleInfo dropItemRuleInfo = new DropItemRuleInfo();
	//		dropItemRuleInfo.explain = list[i];
	//		i++;
	//		dropItemRuleInfo.ID = Convert.ToInt32(list[i]);
	//		i++;
	//		dropItemRuleInfo.type = (DropItemRuleInfo.RuleType)Convert.ToInt32(list[i]);
	//		i++;
	//		dropItemRuleInfo.ConType = (DropItemRuleInfo.ConditionType)Convert.ToInt32(list[i]);
	//		i++;
	//		dropItemRuleInfo.ConDate = Convert.ToInt32(list[i]);
	//		i++;
	//		dropItemRuleInfo.DropItemInfoList = new List<DropItemRuleInfo.DropItemInfo>();
	//		dropItemRuleInfo.DropItemInfoList.Clear();
	//		for (int j = 0; j < 10; j++)
	//		{
	//			DropItemRuleInfo.DropItemInfo dropItemInfo = new DropItemRuleInfo.DropItemInfo();
	//			dropItemInfo.Chance = Convert.ToInt32(list[i]);
	//			i++;
	//			dropItemInfo.ItemID = Convert.ToInt32(list[i]);
	//			i++;
	//			dropItemInfo.MinCount = Convert.ToInt32(list[i]);
	//			i++;
	//			dropItemInfo.MaxCount = Convert.ToInt32(list[i]);
	//			i++;
	//			dropItemRuleInfo.DropItemInfoList.Add(dropItemInfo);
	//		}
	//		this.DropItemRuleInfoList.Add(dropItemRuleInfo);
	//	}
	//}

	//// Token: 0x06000783 RID: 1923 RVA: 0x000211A8 File Offset: 0x0001F3A8
	//public DropItemRuleInfo GetDropItemRuleInfoById(int Id)
	//{
	//	for (int i = 0; i < this.DropItemRuleInfoList.Count; i++)
	//	{
	//		if (Id == this.DropItemRuleInfoList[i].ID)
	//		{
	//			return this.DropItemRuleInfoList[i];
	//		}
	//	}
	//	return null;
	//}
}
