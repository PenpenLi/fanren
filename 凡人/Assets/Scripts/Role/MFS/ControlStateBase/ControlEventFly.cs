using System;
using UnityEngine;

// Token: 0x020004A4 RID: 1188
public class ControlEventFly : ControlEventBase
{
	// Token: 0x06001EDF RID: 7903 RVA: 0x000D5868 File Offset: 0x000D3A68
	public ControlEventFly(bool Forced, bool isRise, Vector3 target, ACTION_INDEX act, float speed, bool rot) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.FLY;
		this.m_bForced = Forced;
		this.m_vecTarget = target;
		this.m_actIdx = act;
		this.m_rotate = rot;
		this.m_speed = speed;
		this.m_bRise = isRise;
	}

	// Token: 0x1700038E RID: 910
	// (get) Token: 0x06001EE0 RID: 7904 RVA: 0x000D58B4 File Offset: 0x000D3AB4
	public Vector3 TargetPos
	{
		get
		{
			return this.m_vecTarget;
		}
	}

	// Token: 0x1700038F RID: 911
	// (get) Token: 0x06001EE1 RID: 7905 RVA: 0x000D58BC File Offset: 0x000D3ABC
	public ACTION_INDEX ActIdx
	{
		get
		{
			return this.m_actIdx;
		}
	}

	// Token: 0x17000390 RID: 912
	// (get) Token: 0x06001EE2 RID: 7906 RVA: 0x000D58C4 File Offset: 0x000D3AC4
	public float Speed
	{
		get
		{
			return this.m_speed;
		}
	}

	// Token: 0x17000391 RID: 913
	// (get) Token: 0x06001EE3 RID: 7907 RVA: 0x000D58CC File Offset: 0x000D3ACC
	public bool Rotate
	{
		get
		{
			return this.m_rotate;
		}
	}

	// Token: 0x17000392 RID: 914
	// (get) Token: 0x06001EE4 RID: 7908 RVA: 0x000D58D4 File Offset: 0x000D3AD4
	public bool Rise
	{
		get
		{
			return this.m_bRise;
		}
	}

	// Token: 0x04001B9A RID: 7066
	private Vector3 m_vecTarget;

	// Token: 0x04001B9B RID: 7067
	private ACTION_INDEX m_actIdx;

	// Token: 0x04001B9C RID: 7068
	private float m_speed;

	// Token: 0x04001B9D RID: 7069
	private bool m_rotate;

	// Token: 0x04001B9E RID: 7070
	private bool m_bRise;
}
