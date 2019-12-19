using System;
using UnityEngine;

// Token: 0x020004B6 RID: 1206
public class ControlEventSwim : ControlEventBase
{
	// Token: 0x06001F33 RID: 7987 RVA: 0x000D6040 File Offset: 0x000D4240
	public ControlEventSwim(bool Forced, float SwimHeight, Vector3 target, ACTION_INDEX act, float speed, bool rot) : base(Forced)
	{
		this.m_fSwimHeight = SwimHeight;
		this.m_iInputId = CONTROL_INPUT.SWIM;
		this.m_bForced = Forced;
		this.m_vecTarget = target;
		this.m_actIdx = act;
		this.m_rotate = rot;
		this.m_speed = speed;
	}

	// Token: 0x170003BF RID: 959
	// (get) Token: 0x06001F34 RID: 7988 RVA: 0x000D608C File Offset: 0x000D428C
	public Vector3 TargetPos
	{
		get
		{
			return this.m_vecTarget;
		}
	}

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x06001F35 RID: 7989 RVA: 0x000D6094 File Offset: 0x000D4294
	public ACTION_INDEX ActIdx
	{
		get
		{
			return this.m_actIdx;
		}
	}

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x06001F36 RID: 7990 RVA: 0x000D609C File Offset: 0x000D429C
	public float Speed
	{
		get
		{
			return this.m_speed;
		}
	}

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001F37 RID: 7991 RVA: 0x000D60A4 File Offset: 0x000D42A4
	public bool Rotate
	{
		get
		{
			return this.m_rotate;
		}
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001F38 RID: 7992 RVA: 0x000D60AC File Offset: 0x000D42AC
	public float SwimHeight
	{
		get
		{
			return this.m_fSwimHeight;
		}
	}

	// Token: 0x04001BCD RID: 7117
	private Vector3 m_vecTarget;

	// Token: 0x04001BCE RID: 7118
	private ACTION_INDEX m_actIdx;

	// Token: 0x04001BCF RID: 7119
	private float m_speed;

	// Token: 0x04001BD0 RID: 7120
	private bool m_rotate;

	// Token: 0x04001BD1 RID: 7121
	private float m_fSwimHeight;
}
