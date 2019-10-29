using System;
using UnityEngine;

/// <summary>
/// 玩家信息
/// </summary>
public class PlayerInfo
{
    /// <summary>
    /// ID
    /// </summary>
	public int id;

    /// <summary>
    /// 名称
    /// </summary>
	public string name;

    /// <summary>
    /// 头像路径
    /// </summary>
	public string headPath;

    /// <summary>
    /// 资源路径
    /// </summary>
	public string resourcePath;

    /// <summary>
    /// 默认移动速度
    /// </summary>
	public float runSpeed;

    /// <summary>
    /// 默认武器id
    /// </summary>
	public int weaponId;

    /// <summary>
    /// 玩家位置
    /// </summary>
	public static Vector3 PLAYER_POSITION = Vector3.zero;

    /// <summary>
    /// 玩家复活位置
    /// </summary>
	public static Vector3 PLAYER_REVIVE_POSITION = Vector3.zero;

    /// <summary>
    /// 玩家旋转角度 朝向
    /// </summary>
	public static Vector3 PLAYER_ROTATION = Vector3.zero;

    /// <summary>
    /// 玩家复活朝向
    /// </summary>
	public static Vector3 PLAYER_REVIVE_ROTATION = Vector3.zero;

    /// <summary>
    /// 右手
    /// </summary>
	public static string RIGHT_HAND = "Bip01 R Hand";
}
