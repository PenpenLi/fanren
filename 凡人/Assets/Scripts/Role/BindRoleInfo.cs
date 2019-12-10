using System;
using UnityEngine;

/// <summary>
/// 绑定角色信息
/// </summary>
public class BindRoleInfo
{
	public Role role;

	public Role beBindedRole;

	public Transform bindTrans;

	public BindRoleInfo.BRIType type;

	public enum BRIType
	{
        /// <summary>
        /// 坐骑
        /// </summary>
		Horse,
        /// <summary>
        /// 武器
        /// </summary>
		Grasp
	}
}
