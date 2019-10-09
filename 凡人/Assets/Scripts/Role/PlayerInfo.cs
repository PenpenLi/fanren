using System;
using UnityEngine;

/// <summary>
/// 玩家信息
/// </summary>
public class PlayerInfo
{
	public int id;

	public string name;

	public string headPath;

	public string resourcePath;

	public float runSpeed;

	public int weaponId;

	public static Vector3 PLAYER_POSITION = Vector3.zero;

	public static Vector3 PLAYER_REVIVE_POSITION = Vector3.zero;

	public static Vector3 PLAYER_ROTATION = Vector3.zero;

	public static Vector3 PLAYER_REVIVE_ROTATION = Vector3.zero;

	public static string RIGHT_HAND = "Bip01 R Hand";
}
