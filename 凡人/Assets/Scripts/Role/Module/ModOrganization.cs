using System;

/// <summary>
/// 团体
/// </summary>
public class ModOrganization : Module
{
	
	public ModOrganization()
	{
	}

	public ModOrganization(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_ORGANIZATION;
	}

	//// Token: 0x17000404 RID: 1028
	//// (get) Token: 0x060021E9 RID: 8681 RVA: 0x000E8728 File Offset: 0x000E6928
	//// (set) Token: 0x060021E8 RID: 8680 RVA: 0x000E871C File Offset: 0x000E691C
	//public OrganizationInfo OrgInfo
	//{
	//	get
	//	{
	//		return this._orgInfo;
	//	}
	//	set
	//	{
	//		this._orgInfo = value;
	//	}
	//}

	//// Token: 0x17000405 RID: 1029
	//// (get) Token: 0x060021EB RID: 8683 RVA: 0x000E8740 File Offset: 0x000E6940
	//// (set) Token: 0x060021EA RID: 8682 RVA: 0x000E8730 File Offset: 0x000E6930
	//public ORG_TYPE OrgType
	//{
	//	get
	//	{
	//		return this._orgInfo.OrgType;
	//	}
	//	set
	//	{
	//		this._orgInfo.OrgType = value;
	//	}
	//}

	//// Token: 0x060021EC RID: 8684 RVA: 0x000E8750 File Offset: 0x000E6950
	//public override bool Init()
	//{
	//	this._orgInfo.OrgType = this._role.SpawnInfo.orgType;
	//	OrganizationInfo orgInfoByType = GameData.Instance.RoleData.GetOrgInfoByType(this._orgInfo.OrgType);
	//	if (orgInfoByType != null)
	//	{
	//		this._orgInfo.RepList.Clear();
	//		foreach (OrganizationInfo.Reputation reputation in orgInfoByType.RepList)
	//		{
	//			OrganizationInfo.Reputation reputation2 = new OrganizationInfo.Reputation();
	//			reputation2.orgType = reputation.orgType;
	//			reputation2.value = reputation.value;
	//			this._orgInfo.RepList.Add(reputation2);
	//		}
	//		return base.Init();
	//	}
	//	return false;
	//}

	//// Token: 0x060021ED RID: 8685 RVA: 0x000E883C File Offset: 0x000E6A3C
	//public int GetReputation(ORG_TYPE orgType)
	//{
	//	foreach (OrganizationInfo.Reputation reputation in this._orgInfo.RepList)
	//	{
	//		if (reputation.orgType == orgType)
	//		{
	//			return reputation.value;
	//		}
	//	}
	//	return -1;
	//}

	//// Token: 0x060021EE RID: 8686 RVA: 0x000E88BC File Offset: 0x000E6ABC
	//public bool IsEnmity(ORG_TYPE orgType)
	//{
	//	return orgType != this.OrgType && this.GetReputation(orgType) < 3000;
	//}

	//// Token: 0x060021EF RID: 8687 RVA: 0x000E88EC File Offset: 0x000E6AEC
	//public bool IsEnmity(ModOrganization modOrgan)
	//{
	//	return this.IsEnmity(modOrgan.OrgType);
	//}

	//// Token: 0x060021F0 RID: 8688 RVA: 0x000E88FC File Offset: 0x000E6AFC
	//public void UpdateReputation(ORG_TYPE orgType, int updateValue)
	//{
	//	bool flag = false;
	//	for (int i = 0; i < this._orgInfo.RepList.Count; i++)
	//	{
	//		OrganizationInfo.Reputation reputation = this._orgInfo.RepList[i];
	//		if (reputation.orgType == orgType)
	//		{
	//			reputation.value += updateValue;
	//			flag = true;
	//			break;
	//		}
	//	}
	//	if (!flag)
	//	{
	//		OrganizationInfo.Reputation reputation2 = new OrganizationInfo.Reputation();
	//		reputation2.orgType = orgType;
	//		reputation2.value = Math.Max(0, updateValue);
	//		this._orgInfo.RepList.Add(reputation2);
	//	}
	//}

	//// Token: 0x04001F09 RID: 7945
	//private OrganizationInfo _orgInfo = new OrganizationInfo();
}
