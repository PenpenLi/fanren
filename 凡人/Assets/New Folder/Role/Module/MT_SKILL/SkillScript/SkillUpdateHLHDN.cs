using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;
using UnityUtility;


public class SkillUpdateHLHDN : SkillPlayer
{

	public SkillUpdateHLHDN()
	{
		this.m_sTargetType = 0;
		this.m_sRangeType = 3;
		this.m_sStopAnimateState = 4;
	}

	public SkillUpdateHLHDN(SkillUpdateHLHDN sujzb) : base(sujzb)
	{
		this.m_iAnimation = sujzb.m_iAnimation;
		this.m_fRadius = sujzb.m_fRadius;
		this.m_fHitValue = sujzb.m_fHitValue;
		this.m_iHitId = sujzb.m_iHitId;
		this.m_iShockId = sujzb.m_iShockId;
		this.m_iBuffId = sujzb.m_iBuffId;
	}

	// Token: 0x060028E9 RID: 10473 RVA: 0x001272A0 File Offset: 0x001254A0
	public override KeyValuePair<string, Type>[] GetRes()
	{
		List<KeyValuePair<string, Type>> list = new List<KeyValuePair<string, Type>>();
		if (base.GetRes() != null)
		{
			list.AddRange(base.GetRes());
		}
		//KeyValuePair<string, Type>[] effectResPath = UtilityRoleResource.GetEffectResPath(742);
		//if (effectResPath != null)
		//{
		//	list.AddRange(effectResPath);
		//}
		//KeyValuePair<string, Type>[] effectResPath2 = UtilityRoleResource.GetEffectResPath(740);
		//if (effectResPath2 != null)
		//{
		//	list.AddRange(effectResPath2);
		//}
		return list.ToArray();
	}

	// Token: 0x060028EA RID: 10474 RVA: 0x00127300 File Offset: 0x00125500
	public override CSkillBase Clone()
	{
		return new SkillUpdateHLHDN(this);
	}

	// Token: 0x060028EB RID: 10475 RVA: 0x00127318 File Offset: 0x00125518
	public override void Init(Role sourceRole, Role targetRole, Vector3 targetPos)
	{
		base.Init(sourceRole, targetRole, targetPos);
		this.m_lstPos.Clear();
		this.count = 0;
		this.m_lstEffId.Clear();
		this.ShockCount = 0;
		this.IsShock = false;
		//this.play = new PlayRoleAnimationOnce();
		//this.play.SetActor(this.m_cSourceRole);
		//this.play.AniINdex = this.m_iAnimation;
	}

	// Token: 0x060028EC RID: 10476 RVA: 0x00127388 File Offset: 0x00125588
	public override void Write(CSerializer cs)
	{
		base.Write(cs);
		cs.Write(this.m_iAnimation);
		cs.Write(this.m_fRadius);
		cs.Write(this.m_fHitValue);
		cs.Write(this.m_iHitId);
		cs.Write(this.m_iShockId);
		cs.Write(this.m_iBuffId);
	}

	// Token: 0x060028ED RID: 10477 RVA: 0x001273E4 File Offset: 0x001255E4
	public override void Read(CSerializer cs)
	{
		base.Read(cs);
		this.m_iAnimation = cs.ReadInt32();
		this.m_fRadius = cs.ReadFloat();
		this.m_fHitValue = cs.ReadFloat();
		this.m_iHitId = cs.ReadInt32();
		this.m_iShockId = cs.ReadInt32();
		this.m_iBuffId = cs.ReadInt32();
	}

	public override void TextRead(List<string> infoList, ref int index)
	{
		base.TextRead(infoList, ref index);
		this.m_iAnimation = Convert.ToInt32(infoList[index++]);
		this.m_fRadius = Convert.ToSingle(infoList[index++]);
		this.m_fHitValue = Convert.ToSingle(infoList[index++]);
		this.m_iHitId = Convert.ToInt32(infoList[index++]);
		this.m_iShockId = Convert.ToInt32(infoList[index++]);
		this.m_iBuffId = Convert.ToInt32(infoList[index++]);
	}

	// Token: 0x060028EF RID: 10479 RVA: 0x001274F4 File Offset: 0x001256F4
	public override void Destory()
	{
		ModColliderProperty modColliderProperty = this.m_cSourceRole.GetModule(MODULE_TYPE.MT_COLLIDER) as ModColliderProperty;
		if (modColliderProperty != null)
		{
			modColliderProperty.Stop();
		}
		base.Destory();
	}

	// Token: 0x060028F0 RID: 10480 RVA: 0x00127528 File Offset: 0x00125728
	public override bool Update()
	{
		if (!base.Update())
		{
			return false;
		}
		//if (!this.play.Update())
		//{
		//	this.m_bCanChangeState = true;
		//}
		//if (this.play.GetLength() - this.play.GetCurrentTime() <= this.backTime)
		//{
		//	this.IsOutControl = true;
		//}
		switch (this.m_sUpdateStatus)
		{
		case 1:
			this.m_sUpdateStatus += 1;
			break;
		case 2:
			if (this.m_cTargetRole != null)
			{
				this.m_cSourceRole.GetTrans().LookAt(new Vector3(this.m_cTargetRole.GetPos().x, this.m_cSourceRole.GetPos().y, this.m_cTargetRole.GetPos().z));
				this.TagPos = this.m_cTargetRole.GetPos();
				//this.m_lstPos.Add(RoleBaseFun.GetRandomPosOnAngleRadius(this.m_cTargetRole.GetPos(), this.m_fRadius, this.m_cTargetRole, -90f, -90f));
				//this.m_lstPos.Add(RoleBaseFun.GetRandomPosOnAngleRadius(this.m_cTargetRole.GetPos(), this.m_fRadius, this.m_cTargetRole, 90f, 90f));
				//this.m_lstPos.Add(RoleBaseFun.GetRandomPosOnAngleRadius(this.m_cTargetRole.GetPos(), this.m_fRadius, this.m_cTargetRole, 0f, 0f));
				//this.m_lstPos.Add(RoleBaseFun.GetRandomPosOnAngleRadius(this.m_cTargetRole.GetPos(), this.m_fRadius, this.m_cTargetRole, 180f, 180f));
			}
			else
			{
				//Vector3 randomPosOnAngleRadius = RoleBaseFun.GetRandomPosOnAngleRadius(this.m_cSourceRole.GetPos(), 8f, this.m_cSourceRole, 0f, 0f);
				//this.TagPos = randomPosOnAngleRadius;
				//this.m_lstPos.Add(RoleBaseFun.GetRandomPosOnAngleRadius(randomPosOnAngleRadius, this.m_fRadius, this.m_cSourceRole, -90f, -90f));
				//this.m_lstPos.Add(RoleBaseFun.GetRandomPosOnAngleRadius(randomPosOnAngleRadius, this.m_fRadius, this.m_cSourceRole, 90f, 90f));
				//this.m_lstPos.Add(RoleBaseFun.GetRandomPosOnAngleRadius(randomPosOnAngleRadius, this.m_fRadius, this.m_cSourceRole, 0f, 0f));
				//this.m_lstPos.Add(RoleBaseFun.GetRandomPosOnAngleRadius(randomPosOnAngleRadius, this.m_fRadius, this.m_cSourceRole, 180f, 180f));
			}
			this.m_sUpdateStatus += 1;
			break;
		case 3:
		{
			for (int i = 0; i < 4; i++)
			{
				SingletonMono<EffectManager>.GetInstance().AddEffectFixure(742, this.m_lstPos[i], Quaternion.identity);
				SingletonMono<EffectManager>.GetInstance().AddEffectFixure(740, this.m_lstPos[i], Quaternion.identity);
			}
			int key = SingletonMono<EffectManager>.GetInstance().AddEffectFixure(817, this.TagPos, Quaternion.identity);
			//SkillAutoOpenCheck skillAutoOpenCheck = Singleton<ActorManager>.GetInstance().GetObject(key).AddComponent<SkillAutoOpenCheck>();
			//skillAutoOpenCheck.Init(GameTime.time, 0.45f, this.m_cSourceRole, this.m_fHitValue, this.m_iHitId, this.m_iBuffId, this.m_fVForce, this.m_fHForce);
			this.ShockTime = GameTime.time;
			this.m_sUpdateStatus += 1;
			break;
		}
		case 4:
			if (GameTime.time - this.ShockTime > 0.4f && !this.IsShock)
			{
				this.IsShock = true;
				//SingletonMono<ScreenShockController>.GetInstance().Shock(this.m_iShockId);
			}
			//if (!this.play.Update())
			//{
			//	this.m_sUpdateStatus += 1;
			//}
			break;
		case 5:
			this.m_sUpdateStatus += 1;
			break;
		case 6:
			return false;
		}
		return true;
	}

	// Token: 0x04002865 RID: 10341
	private const short SKILL_STATUS_NONE = 0;

	// Token: 0x04002866 RID: 10342
	private const short SKILL_STATUS_BEGIN = 1;

	// Token: 0x04002867 RID: 10343
	private const short SKILL_STATUS_SHOOT_BEGIN = 2;

	// Token: 0x04002868 RID: 10344
	private const short SKILL_STATUS_SHOOT_BEGIN_END = 3;

	// Token: 0x04002869 RID: 10345
	private const short SKILL_STATUS_SHOOT_MIDDLE = 4;

	// Token: 0x0400286A RID: 10346
	private const short SKILL_STATUS_SHOOT_END = 5;

	// Token: 0x0400286B RID: 10347
	private const short SKILL_STATUS_END = 6;

	// Token: 0x0400286C RID: 10348
	private int m_iAnimation;

	// Token: 0x0400286D RID: 10349
	private float m_fRadius;

	// Token: 0x0400286E RID: 10350
	private float m_fHitValue;

	// Token: 0x0400286F RID: 10351
	private int m_iHitId;

	// Token: 0x04002870 RID: 10352
	private int m_iShockId;

	// Token: 0x04002871 RID: 10353
	private int m_iBuffId;

	// Token: 0x04002872 RID: 10354
	private int m_iNowEffectId;

	// Token: 0x04002873 RID: 10355
	private List<Vector3> m_lstPos = new List<Vector3>();

	// Token: 0x04002874 RID: 10356
	private int count;

	// Token: 0x04002875 RID: 10357
	private List<int> m_lstEffId = new List<int>();

	//private PlayRoleAnimationOnce play;

	// Token: 0x04002877 RID: 10359
	private float ShockTime;

	// Token: 0x04002878 RID: 10360
	private int ShockCount;

	// Token: 0x04002879 RID: 10361
	private bool IsShock;

	// Token: 0x0400287A RID: 10362
	private Vector3 TagPos;
}
