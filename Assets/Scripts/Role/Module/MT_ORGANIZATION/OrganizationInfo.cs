using System;
using System.Collections.Generic;

/// <summary>
/// 社交信息
/// </summary>
public class OrganizationInfo
{
    /// <summary>
    /// 崇拜
    /// </summary>
	public const int ORG_Worship = 21000;

    /// <summary>
    /// 尊敬
    /// </summary>
	public const int ORG_Respect = 12000;

    /// <summary>
    /// 友好
    /// </summary>
	public const int ORG_Friendly = 9000;

    /// <summary>
    /// 冷淡
    /// </summary>
	public const int ORG_Inhospitality = 3000;

    /// <summary>
    /// 敌意
    /// </summary>
	public const int ORG_Enmity = 0;

	public ORG_TYPE OrgType;

	public List<OrganizationInfo.Reputation> RepList = new List<OrganizationInfo.Reputation>();

	public class Reputation
	{
		public ORG_TYPE orgType;

		public int value;
	}
}
