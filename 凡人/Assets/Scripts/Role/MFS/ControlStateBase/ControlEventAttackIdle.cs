using System;
using UnityEngine;

// Token: 0x02000499 RID: 1177
public class ControlEventAttackIdle : ControlEventBase
{
	// Token: 0x06001EBD RID: 7869 RVA: 0x000D55BC File Offset: 0x000D37BC
	public ControlEventAttackIdle(bool Forced) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK_IDLE;
		this.m_bForced = Forced;
	}

	// Token: 0x06001EBE RID: 7870 RVA: 0x000D55D4 File Offset: 0x000D37D4
	public ControlEventAttackIdle(bool Forced, Transform target, int aniIndex) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK_IDLE;
		this.m_bForced = Forced;
		this.Target = target;
		this.AniIndex = aniIndex;
	}

	// Token: 0x06001EBF RID: 7871 RVA: 0x000D55FC File Offset: 0x000D37FC
	public ControlEventAttackIdle(bool Forced, Transform target, int aniIndex, float lastTime) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK_IDLE;
		this.m_bForced = Forced;
		this.Target = target;
		this.AniIndex = aniIndex;
		this.LastTime = lastTime;
	}

	// Token: 0x1700037D RID: 893
	// (get) Token: 0x06001EC0 RID: 7872 RVA: 0x000D5634 File Offset: 0x000D3834
	// (set) Token: 0x06001EC1 RID: 7873 RVA: 0x000D563C File Offset: 0x000D383C
	public Transform Target { get; private set; }

	// Token: 0x1700037E RID: 894
	// (get) Token: 0x06001EC2 RID: 7874 RVA: 0x000D5648 File Offset: 0x000D3848
	// (set) Token: 0x06001EC3 RID: 7875 RVA: 0x000D5650 File Offset: 0x000D3850
	public int AniIndex { get; private set; }

	// Token: 0x1700037F RID: 895
	// (get) Token: 0x06001EC4 RID: 7876 RVA: 0x000D565C File Offset: 0x000D385C
	// (set) Token: 0x06001EC5 RID: 7877 RVA: 0x000D5664 File Offset: 0x000D3864
	public float LastTime { get; private set; }
}
