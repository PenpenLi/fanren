using System;
using UnityEngine;

// Token: 0x020004A9 RID: 1193
public class BindRole : HurtRoleGameObject
{
	// Token: 0x06001F11 RID: 7953 RVA: 0x0000221B File Offset: 0x0000041B
	private new void Start()
	{
	}

	// Token: 0x06001F12 RID: 7954 RVA: 0x000D8D0C File Offset: 0x000D6F0C
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

	// Token: 0x06001F13 RID: 7955 RVA: 0x000D8DD4 File Offset: 0x000D6FD4
	private void SetLayer(int layer)
	{
		SkinnedMeshRenderer[] skinMeshRensers = this.role.roleGameObject.SkinMeshRensers;
		if (skinMeshRensers != null && skinMeshRensers.Length > 0)
		{
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinMeshRensers)
			{
				if (skinnedMeshRenderer != null && skinnedMeshRenderer.gameObject != null)
				{
					skinnedMeshRenderer.gameObject.layer = layer;
				}
			}
		}
	}
}
