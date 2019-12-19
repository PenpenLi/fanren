using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 碰撞模块
/// </summary>
public class ModColliderProperty : Module
{
    private List<int> hurtedID = new List<int>();

    private FightInfo m_cHurtInfo;

    private int[] openingParts;

    public ModColliderProperty(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_COLLIDER;
	}

	public override bool Init()
	{
		base.Init();
		return true;
	}

	private void GetCollider()
	{
	}

	public override void Render()
	{
		base.Render();
	}

	public override void Process()
	{
		base.Process();
	}

	public bool Start(FightInfo hurtInfo, int[] openParts)
	{
		this.m_cHurtInfo = hurtInfo;
		this.hurtedID.Clear();
		this.OpenColliderCheck(openParts, true);
		this.openingParts = openParts;
		return true;
	}

	// Token: 0x06002156 RID: 8534 RVA: 0x000E52B4 File Offset: 0x000E34B4
	public bool Start(FightInfo hurtInfo)
	{
		this.m_cHurtInfo = hurtInfo;
		this.hurtedID.Clear();
		//foreach (ColliderCheckObject colliderCheckObject in this._role.roleGameObject.HarmPart.Values)
		//{
		//	if (colliderCheckObject != null)
		//	{
		//		colliderCheckObject.OnHitEnter = new ColliderCheckHandle(this.OnHit);
		//		colliderCheckObject.OpenCheck();
		//	}
		//}
		return true;
	}

	// Token: 0x06002157 RID: 8535 RVA: 0x000E535C File Offset: 0x000E355C
	private void OpenColliderCheck(int[] openParts, bool open)
	{
		if (openParts == null || openParts.Length == 0)
		{
			return;
		}
		for (int i = 0; i < openParts.Length; i++)
		{
			if (openParts[i] > 0)
			{
				//if (this._role.roleGameObject.HarmPart.ContainsKey((HARM_PART)openParts[i]))
				//{
				//	ColliderCheckObject colliderCheckObject = this._role.roleGameObject.HarmPart[(HARM_PART)openParts[i]];
				//	if (!(colliderCheckObject == null))
				//	{
				//		if (open)
				//		{
				//			colliderCheckObject.OnHitEnter = new ColliderCheckHandle(this.OnHit);
				//			colliderCheckObject.OpenCheck();
				//		}
				//		else
				//		{
				//			colliderCheckObject.CloseCheck();
				//		}
				//	}
				//}
			}
		}
	}

	// Token: 0x06002158 RID: 8536 RVA: 0x000E540C File Offset: 0x000E360C
	public bool Stop()
	{
		this.OpenColliderCheck(this.openingParts, false);
		return true;
	}

	// Token: 0x06002159 RID: 8537 RVA: 0x000E541C File Offset: 0x000E361C
	public bool StopAll()
	{
		//foreach (ColliderCheckObject colliderCheckObject in this._role.roleGameObject.HarmPart.Values)
		//{
		//	if (colliderCheckObject != null)
		//	{
		//		colliderCheckObject.CloseCheck();
		//	}
		//}
		return true;
	}

	// Token: 0x0600215A RID: 8538 RVA: 0x000E54A0 File Offset: 0x000E36A0
	private void OnHit(object sender, HitEventArgs e)
	{
		if (this.m_cHurtInfo == null)
		{
			return;
		}
		HurtGameObject component = e.collider.GetComponent<HurtGameObject>();
		if (component == null)
		{
			return;
		}
		if (this.AlreadyHurt(component))
		{
			return;
		}
		this.hurtedID.Add(component.GetOwnerID());
		this.m_cHurtInfo.hurtPoint = e.hitPoint;
		//component.Hurt(this.m_cHurtInfo);
	}

	// Token: 0x0600215B RID: 8539 RVA: 0x000E5510 File Offset: 0x000E3710
	private void SetFightInfo(Vector3 hitPoint, Vector3 orignPoint)
	{
		this.m_cHurtInfo.attackPoint = orignPoint;
		this.m_cHurtInfo.hurtPoint = hitPoint;
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x000E552C File Offset: 0x000E372C
	private bool AlreadyHurt(HurtGameObject hurtGO)
	{
		return !(hurtGO == null) && this.hurtedID.Contains(hurtGO.GetOwnerID());
	}

	// Token: 0x0600215D RID: 8541 RVA: 0x000E5558 File Offset: 0x000E3758
	private void CreatHitEffect(FightInfo info, HurtGameObject hurt, Vector3 hurtPoint)
	{
		int id = -1;
		if (info.hurtEffectInfo != null)
		{
			id = info.hurtEffectInfo.effectID;
		}
		else
		{
			int materialType = this._role.roleGameObject.ModelInfo.MaterialType;
			//HurtEffect data = Singleton<HurtEffectData>.GetInstance().GetData(info.weaponMateriaType, hurt.GetBodyMaterialType());
			//if (data != null)
			//{
			//	id = data.EffectID;
			//}
		}
		//SingletonMono<EffectManager>.GetInstance().AddEffect(id, Vector3.zero, Vector3.zero, hurtPoint, Quaternion.identity, null, false);
	}
}
