using System;
using UnityEngine;

public class PlayerInfo
{

	public int id;


	public string name;


	public string headPath;


	public string resourcePath;

	// Token: 0x04000609 RID: 1545
	public float runSpeed;

	// Token: 0x0400060A RID: 1546
	public int weaponId;

	// Token: 0x0400060B RID: 1547
	public static Vector3 PLAYER_POSITION = Vector3.zero;

	// Token: 0x0400060C RID: 1548
	public static Vector3 PLAYER_REVIVE_POSITION = Vector3.zero;

	// Token: 0x0400060D RID: 1549
	public static Vector3 PLAYER_ROTATION = Vector3.zero;

	// Token: 0x0400060E RID: 1550
	public static Vector3 PLAYER_REVIVE_ROTATION = Vector3.zero;

	// Token: 0x0400060F RID: 1551
	public static string RIGHT_HAND = "Bip01 R Hand";
}
