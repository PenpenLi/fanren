using System;
using UnityEngine;

public class BindRole : HurtRoleGameObject
{
	private new void Start()
	{
	}

    /// <summary>
    /// 设置角色标签和层
    /// </summary>
    /// <param name="theRole"></param>
	public override void SetRole(Role theRole)
	{
		base.SetRole(theRole);
		if (this.role == null)
		{
			return;
		}
		switch (this.role._roleType)
		{
		case ROLE_TYPE.RT_PLAYER:
			base.gameObject.tag = "Player";
			base.gameObject.layer = LayerMask.NameToLayer("zhujue");
			return;
		case ROLE_TYPE.RT_MONSTER:
			base.gameObject.layer = LayerMask.NameToLayer("Monster");
			this.SetLayer(LayerMask.NameToLayer("Monster"));
			return;
		}
		base.gameObject.layer = LayerMask.NameToLayer("Monster");
		this.SetLayer(LayerMask.NameToLayer("Monster"));
	}

    /// <summary>
    /// 设置层
    /// </summary>
    /// <param name="layer"></param>
	private void SetLayer(int layer)
	{
		//SkinnedMeshRenderer[] skinMeshRensers = this.role.roleGameObject.SkinMeshRensers;
		//if (skinMeshRensers != null && skinMeshRensers.Length > 0)
		//{
		//	foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinMeshRensers)
		//	{
		//		if (skinnedMeshRenderer != null && skinnedMeshRenderer.gameObject != null)
		//		{
		//			skinnedMeshRenderer.gameObject.layer = layer;
		//		}
		//	}
		//}
	}
}
