using System;
using UnityEngine;


[AddComponentMenu("碰撞检测/角色控制器")]
public class ColliderCheckCharacterController : ColliderCheckRay
{
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
