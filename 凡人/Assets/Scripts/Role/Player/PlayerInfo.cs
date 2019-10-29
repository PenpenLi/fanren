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
    /// 
    /// </summary>
	public static Vector3 PLAYER_POSITION = Vector3.zero;

    /// <summary>
    /// 
    /// </summary>
	public static Vector3 PLAYER_REVIVE_POSITION = Vector3.zero;

    /// <summary>
    /// 
    /// </summary>
	public static Vector3 PLAYER_ROTATION = Vector3.zero;

    /// <summary>
    /// 
    /// </summary>
	public static Vector3 PLAYER_REVIVE_ROTATION = Vector3.zero;

    /// <summary>
    /// 
    /// </summary>
	public static string RIGHT_HAND = "Bip01 R Hand";
}
