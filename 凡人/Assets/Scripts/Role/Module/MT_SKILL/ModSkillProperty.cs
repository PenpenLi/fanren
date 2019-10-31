using System;
using UnityEngine;


public class ModSkillProperty : Module
{
    private SSkillCoolTime[] m_cSkills = new SSkillCoolTime[11];

    public string str = string.Empty;

    public ModSkillProperty(Role role)
	{
		this._role = role;
		base.ModType = MODULE_TYPE.MT_SKILL;
		this.ClearSkill();
	}

    //public SSkillCoolTime[] M_cSkills
    //{
    //	get
    //	{
    //		return this.m_cSkills;
    //	}
    //}

    //// Token: 0x0600256B RID: 9579 RVA: 0x000FFD7C File Offset: 0x000FDF7C
    //public void SetSkillList(SSkillCoolTime[] skillList)
    //{
    //	this.ClearSkill();
    //	for (int i = 0; i < skillList.Length; i++)
    //	{
    //		if (skillList[i] != null)
    //		{
    //			this.AddSkill(skillList[i].ID);
    //		}
    //	}
    //}

    /// <summary>
    /// 清除技能
    /// </summary>
    public void ClearSkill()
    {
        for (int i = 0; i < this.m_cSkills.Length; i++)
        {
            this.m_cSkills[i] = null;
        }
    }

    //// Token: 0x0600256D RID: 9581 RVA: 0x000FFDEC File Offset: 0x000FDFEC
    //public void DelSkill(int index)
    //{
    //	if (this.m_cSkills[index] != null)
    //	{
    //		this.m_cSkills[index] = null;
    //	}
    //}

    //// Token: 0x0600256E RID: 9582 RVA: 0x000FFE04 File Offset: 0x000FE004
    //public override bool Init()
    //{
    //	return base.Init();
    //}

    //// Token: 0x0600256F RID: 9583 RVA: 0x000FFE0C File Offset: 0x000FE00C
    //public bool IsReady(SKILL_ID id)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && this.m_cSkills[i].ID == (int)id)
    //		{
    //			return this.m_cSkills[i].IsReady();
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06002570 RID: 9584 RVA: 0x000FFE64 File Offset: 0x000FE064
    //public bool SkillIsReady(int id)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && this.m_cSkills[i].ID == id)
    //		{
    //			return this.m_cSkills[i].IsReady();
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06002571 RID: 9585 RVA: 0x000FFEBC File Offset: 0x000FE0BC
    //public int GetSkillID(int index)
    //{
    //	if (index >= this.m_cSkills.Length)
    //	{
    //		return 0;
    //	}
    //	if (index < 0 || this.m_cSkills[index] == null)
    //	{
    //		return 0;
    //	}
    //	return this.m_cSkills[index].ID;
    //}

    //// Token: 0x06002572 RID: 9586 RVA: 0x000FFEF4 File Offset: 0x000FE0F4
    //public int SkillCount()
    //{
    //	return this.m_cSkills.Length;
    //}

    //// Token: 0x06002573 RID: 9587 RVA: 0x000FFF00 File Offset: 0x000FE100
    //public void ResetCoolDownTime(SKILL_ID id)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && this.m_cSkills[i].ID == (int)id)
    //		{
    //			this.m_cSkills[i].ResetCoolDownTime();
    //		}
    //	}
    //}

    //// Token: 0x06002574 RID: 9588 RVA: 0x000FFF54 File Offset: 0x000FE154
    //public void ResetCoolDownTime(int id)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && this.m_cSkills[i].ID == id)
    //		{
    //			this.m_cSkills[i].ResetCoolDownTime();
    //		}
    //	}
    //}

    //// Token: 0x06002575 RID: 9589 RVA: 0x000FFFA8 File Offset: 0x000FE1A8
    //public bool IsReady(int index)
    //{
    //	return this.m_cSkills[index] != null && this.m_cSkills[index].IsReady();
    //}

    //// Token: 0x06002576 RID: 9590 RVA: 0x000FFFDC File Offset: 0x000FE1DC
    //public bool UseSkillById(SKILL_ID id, Role targetRole, Vector3 targetPos)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && id == (SKILL_ID)this.m_cSkills[i].ID)
    //		{
    //			return this.UseSkill(i, targetRole, targetPos);
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06002577 RID: 9591 RVA: 0x00100030 File Offset: 0x000FE230
    //public bool UseSkillById(int id, Role targetRole, Vector3 targetPos)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && id == this.m_cSkills[i].ID)
    //		{
    //			return this.UseSkill(i, targetRole, targetPos);
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06002578 RID: 9592 RVA: 0x00100084 File Offset: 0x000FE284
    //public int GetSkillIndex(int id)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && this.m_cSkills[i].ID == id)
    //		{
    //			return i;
    //		}
    //	}
    //	return -1;
    //}

    //// Token: 0x06002579 RID: 9593 RVA: 0x001000D0 File Offset: 0x000FE2D0
    //public bool UseSkill(int index, Role targetRole, Vector3 targetPos)
    //{
    //	if (index < 0 || index >= this.m_cSkills.Length || this.m_cSkills[index] == null)
    //	{
    //		Debug.Log("Index error");
    //		return false;
    //	}
    //	if (this.m_cSkills[index] == null || !this.m_cSkills[index].IsReady())
    //	{
    //		if (targetRole != null && targetRole._roleType != ROLE_TYPE.RT_PLAYER)
    //		{
    //			string par = Singleton<CSkillStaticManager>.GetInstance().GetSkill(this.m_cSkills[index].ID).Name + GameData.Instance.GetStr(20);
    //			GameData.Instance.ScrMan.Exec(10, par, 1);
    //		}
    //		return false;
    //	}
    //	PanelManager.TextControl();
    //	ModControlMFS modControlMFS = (ModControlMFS)this._role.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
    //	return modControlMFS.ChangeState(new ControlEventSkill(false, this.m_cSkills[index].ID, targetRole, targetPos));
    //}

    //// Token: 0x0600257A RID: 9594 RVA: 0x001001BC File Offset: 0x000FE3BC
    //public bool AddSkill(int id, int index)
    //{
    //	this.str = id.ToString();
    //	CSkillBase skill = Singleton<CSkillStaticManager>.GetInstance().GetSkill(id);
    //	if (skill == null)
    //	{
    //		return false;
    //	}
    //	if (index < 0 || index >= this.m_cSkills.Length || this.m_cSkills[index] != null)
    //	{
    //		return false;
    //	}
    //	SSkillCoolTime sskillCoolTime = new SSkillCoolTime(index, skill.ID, skill.CoolTime);
    //	if (this.m_cSkills[index] != null)
    //	{
    //		return false;
    //	}
    //	if (this._role is Player)
    //	{
    //	}
    //	this.m_cSkills[index] = sskillCoolTime;
    //	return true;
    //}

    //// Token: 0x0600257B RID: 9595 RVA: 0x0010024C File Offset: 0x000FE44C
    //public bool IsSkillExist(int id)
    //{
    //	foreach (SSkillCoolTime sskillCoolTime in this.m_cSkills)
    //	{
    //		if (sskillCoolTime.ID == id)
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x0600257C RID: 9596 RVA: 0x00100288 File Offset: 0x000FE488
    //public bool IsSkillFull()
    //{
    //	int num = 0;
    //	foreach (SSkillCoolTime sskillCoolTime in this.m_cSkills)
    //	{
    //		if (sskillCoolTime.ID != 0)
    //		{
    //			num++;
    //		}
    //	}
    //	return num >= 8;
    //}

    //// Token: 0x0600257D RID: 9597 RVA: 0x001002D0 File Offset: 0x000FE4D0
    //public bool AddSkill(int id)
    //{
    //	int i;
    //	for (i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] == null)
    //		{
    //			break;
    //		}
    //	}
    //	if (i >= this.m_cSkills.Length)
    //	{
    //		Debug.LogError("The Skill is Full");
    //		return false;
    //	}
    //	if (this._role._roleType == ROLE_TYPE.RT_PLAYER && this.ChangeSkill(id) != -1)
    //	{
    //		i = this.ChangeSkill(id);
    //	}
    //	return this.AddSkill(id, i);
    //}

    //// Token: 0x0600257E RID: 9598 RVA: 0x00100350 File Offset: 0x000FE550
    //public int ChangeSkill(int id)
    //{
    //	int[] sortedSkillID = Singleton<PlayerSkillData>.GetInstance().GetSortedSkillID(PLAYER_SKILL_TYPE.FIRE);
    //	int[] sortedSkillID2 = Singleton<PlayerSkillData>.GetInstance().GetSortedSkillID(PLAYER_SKILL_TYPE.SHIELD);
    //	int[] sortedSkillID3 = Singleton<PlayerSkillData>.GetInstance().GetSortedSkillID(PLAYER_SKILL_TYPE.PUPPET);
    //	int[] sortedSkillID4 = Singleton<PlayerSkillData>.GetInstance().GetSortedSkillID(PLAYER_SKILL_TYPE.SWORD);
    //	int[][] array = new int[][]
    //	{
    //		sortedSkillID,
    //		sortedSkillID2,
    //		sortedSkillID3,
    //		sortedSkillID4
    //	};
    //	for (int i = 0; i < 4; i++)
    //	{
    //		for (int j = 0; j < array[i].Length; j++)
    //		{
    //			if (array[i][j] == id)
    //			{
    //				this.DelSkill(i);
    //				return i;
    //			}
    //		}
    //	}
    //	return -1;
    //}

    //// Token: 0x0600257F RID: 9599 RVA: 0x001003F8 File Offset: 0x000FE5F8
    //public SSkillCoolTime GetSkillCoolTimeByIndex(int index)
    //{
    //	if (index >= this.m_cSkills.Length)
    //	{
    //		return null;
    //	}
    //	return this.m_cSkills[index];
    //}

    //// Token: 0x06002580 RID: 9600 RVA: 0x00100414 File Offset: 0x000FE614
    //public SSkillCoolTime GetSkillCooTimeById(int id)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && this.m_cSkills[i].ID == id)
    //		{
    //			return this.m_cSkills[i];
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x06002581 RID: 9601 RVA: 0x00100464 File Offset: 0x000FE664
    //public bool HasSkill(int id)
    //{
    //	for (int i = 0; i < this.m_cSkills.Length; i++)
    //	{
    //		if (this.m_cSkills[i] != null && this.m_cSkills[i].ID == id)
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}
}
