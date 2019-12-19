using System;
using System.Collections.Generic;

/// <summary>
/// 角色基础信息
/// </summary>
public class RoleBaseInfo
{
    /// <summary>
    /// ID
    /// </summary>
	public int ID;

    /// <summary>
    /// 名字
    /// </summary>
	public string Name;

    /// <summary>
    /// 角色模型路径
    /// </summary>
	public string PrefabName;

    /// <summary>
    /// 默认装备ID		
    /// </summary>
	public Dictionary<RoleWearEquipPos, ulong> DefultEquip = new Dictionary<RoleWearEquipPos, ulong>();
}
