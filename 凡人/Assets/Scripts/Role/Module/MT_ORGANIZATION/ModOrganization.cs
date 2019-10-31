using System;

/// <summary>
/// 社交模块
/// </summary>
public class ModOrganization : Module
{
    private OrganizationInfo _orgInfo = new OrganizationInfo();

    public ModOrganization()
	{
	}

	public ModOrganization(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_ORGANIZATION;
	}

    public OrganizationInfo OrgInfo
    {
        get
        {
            return this._orgInfo;
        }
        set
        {
            this._orgInfo = value;
        }
    }

    public ORG_TYPE OrgType
    {
        get
        {
            return this._orgInfo.OrgType;
        }
        set
        {
            this._orgInfo.OrgType = value;
        }
    }

    public override bool Init()
    {
        this._orgInfo.OrgType = this._role.SpawnInfo.orgType;
        OrganizationInfo orgInfoByType = GameData.Instance.RoleData.GetOrgInfoByType(this._orgInfo.OrgType);
        if (orgInfoByType != null)
        {
            this._orgInfo.RepList.Clear();
            foreach (OrganizationInfo.Reputation reputation in orgInfoByType.RepList)
            {
                OrganizationInfo.Reputation reputation2 = new OrganizationInfo.Reputation();
                reputation2.orgType = reputation.orgType;
                reputation2.value = reputation.value;
                this._orgInfo.RepList.Add(reputation2);
            }
            return base.Init();
        }
        return false;
    }

    public int GetReputation(ORG_TYPE orgType)
    {
        foreach (OrganizationInfo.Reputation reputation in this._orgInfo.RepList)
        {
            if (reputation.orgType == orgType)
            {
                return reputation.value;
            }
        }
        return -1;
    }

    public bool IsEnmity(ORG_TYPE orgType)
    {
        return orgType != this.OrgType && this.GetReputation(orgType) < 3000;
    }

    public bool IsEnmity(ModOrganization modOrgan)
    {
        return this.IsEnmity(modOrgan.OrgType);
    }

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
}
