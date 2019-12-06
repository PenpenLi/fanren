using System;
using System.Collections.Generic;
using UnityEngine;


public class SkillPlayer : CSkillBase
{
	public SkillPlayer()
	{
	}

	public SkillPlayer(SkillPlayer clone) : base(clone)
	{
		this.baTiMin = clone.baTiMin;
		this.baTiMax = clone.baTiMax;
		this.backTime = clone.backTime;
		this.distance = clone.distance;
		this.materialEffect = clone.materialEffect;
	}

	// Token: 0x06002739 RID: 10041 RVA: 0x00110990 File Offset: 0x0010EB90
	public override void TextRead(List<string> infoList, ref int index)
	{
		base.TextRead(infoList, ref index);
		this.baTiMin = float.Parse(infoList[index++]);
		this.baTiMax = float.Parse(infoList[index++]);
		this.backTime = float.Parse(infoList[index++]);
		this.distance = float.Parse(infoList[index++]);
		this.materialEffect = int.Parse(infoList[index++]);
	}

	// Token: 0x0600273A RID: 10042 RVA: 0x00110A28 File Offset: 0x0010EC28
	public override CSkillBase Clone()
	{
		return new SkillPlayer(this);
	}

	// Token: 0x0600273B RID: 10043 RVA: 0x00110A30 File Offset: 0x0010EC30
	public float GetDistance()
	{
		return this.distance;
	}

	// Token: 0x0600273C RID: 10044 RVA: 0x00110A38 File Offset: 0x0010EC38
	public bool IsBack()
	{
		return this.IsOutControl;
	}

	// Token: 0x0600273D RID: 10045 RVA: 0x00110A40 File Offset: 0x0010EC40
	protected FightInfo CreatFightInfo()
	{
		return new FightInfo
		{
			materialID = this.materialEffect
		};
	}

	// Token: 0x0600273E RID: 10046 RVA: 0x00110A60 File Offset: 0x0010EC60
	public Vector3 GetTargetPos()
	{
		if (this.m_cTargetRole != null)
		{
			Vector3 a = this.m_cTargetRole.GetPos() - this.m_cSourceRole.GetPos();
			a.y = 0f;
			return a + this.m_cSourceRole.GetPos();
		}
		if (this.m_vecTargetPos != Vector3.zero)
		{
			Vector3 a2 = this.m_vecTargetPos - this.m_cSourceRole.GetPos();
			a2.y = 0f;
			return a2 + this.m_cSourceRole.GetPos();
		}
		return Vector3.zero;
	}

	// Token: 0x040024DB RID: 9435
	protected float baTiMin;

	// Token: 0x040024DC RID: 9436
	protected float baTiMax;

	// Token: 0x040024DD RID: 9437
	protected float backTime;

	// Token: 0x040024DE RID: 9438
	protected float distance;

	// Token: 0x040024DF RID: 9439
	protected int materialEffect;

	// Token: 0x040024E0 RID: 9440
	protected bool IsOutControl;
}
