using System;
using System.Collections.Generic;

/// <summary>
/// 团队信息
/// </summary>
public class OrganizationInfo
{
	public const int ORG_Worship = 21000;

	public const int ORG_Respect = 12000;

	public const int ORG_Friendly = 9000;

	public const int ORG_Inhospitality = 3000;

	public const int ORG_Enmity = 0;

	public ORG_TYPE OrgType;

	public List<OrganizationInfo.Reputation> RepList = new List<OrganizationInfo.Reputation>();

	public class Reputation
	{
		public ORG_TYPE orgType;

		public int value;
	}
}
