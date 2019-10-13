using System;
using System.Collections.Generic;

public class RoleHatred
{
    public static float INIT_HATRED = 1000f;

    public Role selfRole;

    public List<RoleHatred.HatredInfo> HatredList = new List<RoleHatred.HatredInfo>();

    public class HatredInfo
    {
        public Role RoleObj;

        public float HatredValue;

        //public HatredType hatredType;
    }

 //   public void RemoveDieRole()
	//{
	//	for (int i = this.HatredList.Count - 1; i >= 0; i--)
	//	{
	//		if (!this.HatredList[i].RoleObj.isAlive())
	//		{
	//			this.HatredList.RemoveAt(i);
	//		}
	//	}
	//}

	//public List<Role> GetMaxHatredRole(Role role)
	//{
	//	this.RemoveDieRole();
	//	float num = 0f;
	//	foreach (RoleHatred.HatredInfo hatredInfo in this.HatredList)
	//	{
	//		if (hatredInfo.HatredValue > num)
	//		{
	//			num = hatredInfo.HatredValue;
	//		}
	//	}
	//	List<Role> list = new List<Role>();
	//	foreach (RoleHatred.HatredInfo hatredInfo2 in this.HatredList)
	//	{
	//		if (hatredInfo2.HatredValue == num && hatredInfo2.HatredValue > 0f)
	//		{
	//			list.Add(hatredInfo2.RoleObj);
	//		}
	//	}
	//	return list;
	//}

	//// Token: 0x0600243C RID: 9276 RVA: 0x000F5D40 File Offset: 0x000F3F40
	//public bool IsHadredListEmpty()
	//{
	//	return this.HatredList.Count == 0;
	//}

	//// Token: 0x0600243D RID: 9277 RVA: 0x000F5D58 File Offset: 0x000F3F58
	//public void RemoveRoleFromHatred(Role role)
	//{
	//	int id = role.ID;
	//	for (int i = 0; i < this.HatredList.Count; i++)
	//	{
	//		if (this.selfRole != null && this.HatredList[i].RoleObj != null && this.HatredList[i].RoleObj.MonsterHP != null && this.HatredList[i].RoleObj.MonsterHpBottom != null && this.HatredList[i].RoleObj.ID == id && this.selfRole != null && this.HatredList[i].RoleObj.MonsterHP.gameObject.active && this.HatredList[i].RoleObj.MonsterHpBottom.gameObject.active && this.selfRole._roleType == ROLE_TYPE.RT_PLAYER)
	//		{
	//			this.HatredList[i].RoleObj.MonsterHP.gameObject.active = false;
	//			this.HatredList[i].RoleObj.MonsterHpBottom.gameObject.active = false;
	//		}
	//		if (this.HatredList[i] == null || this.HatredList[i].RoleObj == null || this.HatredList[i].RoleObj.ID == id)
	//		{
	//			if (this.HatredList[i].hatredType != HatredType.ToDead || !this.HatredList[i].RoleObj.isAlive())
	//			{
	//				this.HatredList.RemoveAt(i);
	//			}
	//			return;
	//		}
	//	}
	//}

	//// Token: 0x0600243E RID: 9278 RVA: 0x000F5F38 File Offset: 0x000F4138
	//public float GetHatred(int roleId)
	//{
	//	foreach (RoleHatred.HatredInfo hatredInfo in this.HatredList)
	//	{
	//		if (hatredInfo.RoleObj.ID == roleId)
	//		{
	//			return hatredInfo.HatredValue;
	//		}
	//	}
	//	return 0f;
	//}

	//// Token: 0x0600243F RID: 9279 RVA: 0x000F5FBC File Offset: 0x000F41BC
	//public void UpdateHatred(Role role, float value)
	//{
	//	float hatred = this.GetHatred(role.ID);
	//	this.SetHatred(role, hatred + value);
	//}

	//// Token: 0x06002440 RID: 9280 RVA: 0x000F5FE0 File Offset: 0x000F41E0
	//public void SetHatred(Role role, float value)
	//{
	//	this.SetHatred(role, value, HatredType.Normal);
	//}

	//// Token: 0x06002441 RID: 9281 RVA: 0x000F5FEC File Offset: 0x000F41EC
	//public static float GetInitialHatredValue(Role self, Role other)
	//{
	//	HatredRuleInfo initHatredInfo = GameData.Instance.RoleData.GetInitHatredInfo(self.SpawnInfo.hatredRuleID);
	//	float num = 0f;
	//	bool flag = false;
	//	if (initHatredInfo != null)
	//	{
	//		foreach (HatredRuleInfo.singleInfo singleInfo in initHatredInfo.infoList)
	//		{
	//			if (singleInfo.HatRlType == HatredRuleInfo.HatredRuleType.OTHER_IN_MYLIST && singleInfo.roleType == other.SpawnInfo.ObjectType)
	//			{
	//				num = singleInfo.initValue;
	//				flag = true;
	//				break;
	//			}
	//		}
	//	}
	//	HatredRuleInfo initHatredInfo2 = GameData.Instance.RoleData.GetInitHatredInfo(other.SpawnInfo.hatredRuleID);
	//	if (initHatredInfo2 != null)
	//	{
	//		foreach (HatredRuleInfo.singleInfo singleInfo2 in initHatredInfo2.infoList)
	//		{
	//			if (singleInfo2.HatRlType == HatredRuleInfo.HatredRuleType.IN_OTHER_LIST && singleInfo2.roleType == self.SpawnInfo.ObjectType)
	//			{
	//				num += singleInfo2.initValue;
	//				flag = true;
	//				break;
	//			}
	//		}
	//	}
	//	if (flag)
	//	{
	//		return num;
	//	}
	//	ModOrganization modOrganization = other.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
	//	if (modOrganization != null)
	//	{
	//		float roleOrgHateValue = Singleton<HatedOrgInfo>.GetInstance().GetRoleOrgHateValue(self.GetDetailType(), modOrganization.OrgType);
	//		if (roleOrgHateValue >= 0f)
	//		{
	//			return roleOrgHateValue;
	//		}
	//	}
	//	modOrganization = (self.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization);
	//	if (modOrganization != null)
	//	{
	//		float roleOrgBeHatedValue = Singleton<HatedOrgInfo>.GetInstance().GetRoleOrgBeHatedValue(other.GetDetailType(), modOrganization.OrgType);
	//		if (roleOrgBeHatedValue >= 0f)
	//		{
	//			return roleOrgBeHatedValue;
	//		}
	//	}
	//	return RoleHatred.INIT_HATRED;
	//}

	//public void SetHatred(Role role, float value, HatredType ht)
	//{
	//	RoleHatred.HatredInfo hatredInfo = this.GetHatredInfo(role);
	//	if (hatredInfo == null)
	//	{
	//		RoleHatred.HatredInfo hatredInfo2 = new RoleHatred.HatredInfo();
	//		hatredInfo2.RoleObj = role;
	//		hatredInfo2.HatredValue = value;
	//		hatredInfo2.hatredType = ht;
	//		if (role.MonsterHP != null && role.MonsterHpBottom != null && role != null && this.selfRole != null && !role.MonsterHP.gameObject.active && !role.MonsterHpBottom.gameObject.active && this.selfRole._roleType == ROLE_TYPE.RT_PLAYER)
	//		{
	//			role.MonsterHP.gameObject.active = true;
	//			role.MonsterHpBottom.gameObject.active = true;
	//		}
	//		this.HatredList.Add(hatredInfo2);
	//	}
	//	else
	//	{
	//		hatredInfo.RoleObj = role;
	//		hatredInfo.HatredValue = value;
	//		hatredInfo.hatredType = ht;
	//	}
	//}

	//// Token: 0x06002443 RID: 9283 RVA: 0x000F62D4 File Offset: 0x000F44D4
	//public RoleHatred.HatredInfo GetHatredInfo(Role role)
	//{
	//	for (int i = 0; i < this.HatredList.Count; i++)
	//	{
	//		RoleHatred.HatredInfo hatredInfo = this.HatredList[i];
	//		if (hatredInfo.RoleObj == null || hatredInfo.RoleObj.IsDead())
	//		{
	//			this.HatredList.Remove(hatredInfo);
	//		}
	//		else if (hatredInfo.RoleObj.ID == role.ID)
	//		{
	//			return hatredInfo;
	//		}
	//	}
	//	return null;
	//}
}
