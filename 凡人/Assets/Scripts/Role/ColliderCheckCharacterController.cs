using System;
using UnityEngine;


[AddComponentMenu("碰撞检测/角色控制器")]
public class ColliderCheckCharacterController : ColliderCheckRay
{
	// Token: 0x0600129D RID: 4765 RVA: 0x0009CB88 File Offset: 0x0009AD88
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (!base.enabled)
		{
			return;
		}
		base.StartHandle();
		base.TouchAGameObject(hit.collider, hit.point, hit.normal);
		base.LastHandle();
	}
}
