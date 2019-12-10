using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

// Token: 0x02000236 RID: 566
public class EffectColliderProperty
{
	// Token: 0x06000EE1 RID: 3809 RVA: 0x0000B11D File Offset: 0x0000931D
	public EffectColliderProperty(EffectBase effect)
	{
		this.m_cEffect = effect;
		this.Init();
	}

	// Token: 0x06000EE2 RID: 3810 RVA: 0x00095D0C File Offset: 0x00093F0C
	private bool Init()
	{
		this.m_bEnable = false;
		Collider[] componentsInChildren = this.m_cEffect.gameObject.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			//if (collider.name == "ColliderBehaviour" && collider.gameObject.GetComponent<ColliderBehaviour>() == null)
			//{
			//	//collider.gameObject.AddComponent<ColliderBehaviour>();
			//}
		}
		return true;
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x0000B13E File Offset: 0x0000933E
	public void SetCallBack(EffectColliderProperty.ColliderCallBack func)
	{
		this.m_delCallBack = func;
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x00095D84 File Offset: 0x00093F84
	public bool Start(FightInfo hurtInfo, int hurtAni)
	{
		if (this.m_bEnable)
		{
			return false;
		}
		this.m_bEnable = true;
		this.m_lstHitRoles.Clear();
		this.m_cHurtInfo = hurtInfo;
		this.m_iHurtAni = hurtAni;
		//ColliderBehaviour[] componentsInChildren = this.m_cEffect.gameObject.GetComponentsInChildren<ColliderBehaviour>();
		//foreach (ColliderBehaviour colliderBehaviour in componentsInChildren)
		//{
		//	colliderBehaviour.enabled = true;
		//	colliderBehaviour.Init(new Callback<RaycastHit>(this.OnHit));
		//}
		return true;
	}

	// Token: 0x06000EE5 RID: 3813 RVA: 0x00095E04 File Offset: 0x00094004
	public bool Stop()
	{
		if (!this.m_bEnable)
		{
			return false;
		}
		this.m_bEnable = false;
		this.m_lstHitRoles.Clear();
		//ColliderBehaviour[] componentsInChildren = this.m_cEffect.gameObject.GetComponentsInChildren<ColliderBehaviour>();
		//foreach (ColliderBehaviour colliderBehaviour in componentsInChildren)
		//{
		//	colliderBehaviour.enabled = false;
		//	colliderBehaviour.Destory();
		//}
		return true;
	}

	// Token: 0x06000EE6 RID: 3814 RVA: 0x00095E6C File Offset: 0x0009406C
	public void DependOn()
	{
		if (this.m_bEnable)
		{
			Vector3 position = this.m_cEffect.gameObject.transform.position;
			foreach (Role role in this.m_lstHitRoles)
			{
				if (role._roleType != ROLE_TYPE.RT_MONSTER)
				{
					role.GetTrans().position = new Vector3(position.x, position.y + 1f, position.z);
				}
			}
		}
	}

	// Token: 0x06000EE7 RID: 3815 RVA: 0x00095F18 File Offset: 0x00094118
	private void OnHit(RaycastHit hit)
	{
		Collider collider = hit.collider;
		//Role roleScriptFromGo = RoleBaseFun.GetRoleScriptFromGo(collider.gameObject);
		//if (roleScriptFromGo == null)
		//{
		//	return;
		//}
		//if (this.AlreadyHit(roleScriptFromGo))
		//{
		//	return;
		//}
		//this.m_lstHitRoles.Add(roleScriptFromGo);
		//if (this.m_delCallBack != null)
		//{
		//	this.m_delCallBack(this.m_cEffect.Id, collider);
		//	return;
		//}
		//ModFight modFight = (ModFight)roleScriptFromGo.GetModule(MODULE_TYPE.MT_FIGHT);
		//if (this.m_cHurtInfo != null && modFight != null)
		//{
		//	modFight.Hurt(this.m_cHurtInfo, (ACTION_INDEX)this.m_iHurtAni);
		//}
	}

	// Token: 0x06000EE8 RID: 3816 RVA: 0x00095FB8 File Offset: 0x000941B8
	private bool AlreadyHit(Role role)
	{
		foreach (Role role2 in this.m_lstHitRoles)
		{
			if (role2.ID == role.ID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04001007 RID: 4103
	private List<Role> m_lstHitRoles = new List<Role>();

	// Token: 0x04001008 RID: 4104
	private FightInfo m_cHurtInfo;

	// Token: 0x04001009 RID: 4105
	private int m_iHurtAni;

	// Token: 0x0400100A RID: 4106
	private bool m_bEnable;

	// Token: 0x0400100B RID: 4107
	private EffectBase m_cEffect;

	// Token: 0x0400100C RID: 4108
	private EffectColliderProperty.ColliderCallBack m_delCallBack;

	// Token: 0x02000237 RID: 567
	// (Invoke) Token: 0x06000EEA RID: 3818
	public delegate void ColliderCallBack(object arg, object arg1);
}
