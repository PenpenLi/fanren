using System;
using UnityEngine;

public class EffectBase : MonoBehaviour
{
	public int Id
	{
		get
		{
			return this.m_iId;
		}
	}

	public float CostTime
	{
		get
		{
			return this.m_fLastTime;
		}
	}

	public Callback<int, GameObject, ContactPoint[]> CallBackFunction
	{
		get
		{
			return this.m_delCallBackFun;
		}
	}

	public EffectColliderProperty ColliderProperty
	{
		get
		{
			return this.m_cColliderProperty;
		}
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x0000AFE3 File Offset: 0x000091E3
	public virtual float GetLostTime()
	{
		return GameTime.time - this.m_fStartTime;
	}

	// Token: 0x06000EC1 RID: 3777 RVA: 0x0000AFF1 File Offset: 0x000091F1
	private void Awake()
	{
		this.m_cColliderProperty = new EffectColliderProperty(this);
	}

	// Token: 0x06000EC2 RID: 3778 RVA: 0x0000221B File Offset: 0x0000041B
	public virtual void Over()
	{
	}

	// Token: 0x06000EC3 RID: 3779 RVA: 0x0000AFFF File Offset: 0x000091FF
	public void SetCallBackFun(Callback<int, GameObject, ContactPoint[]> fun)
	{
		this.m_delCallBackFun = fun;
	}

	// Token: 0x04000FF4 RID: 4084
	protected int m_iId;

	// Token: 0x04000FF5 RID: 4085
	protected int m_iResId;

	// Token: 0x04000FF6 RID: 4086
	public int effectID;

	// Token: 0x04000FF7 RID: 4087
	protected short m_sEffectType;

	// Token: 0x04000FF8 RID: 4088
	protected float m_fLastTime;

	// Token: 0x04000FF9 RID: 4089
	protected Callback<int, GameObject, ContactPoint[]> m_delCallBackFun;

	// Token: 0x04000FFA RID: 4090
	protected Vector3 m_vecPos;

	// Token: 0x04000FFB RID: 4091
	protected Quaternion m_quaRot;

	// Token: 0x04000FFC RID: 4092
	protected GameObject m_goTarget;

	// Token: 0x04000FFD RID: 4093
	protected float m_fStartTime;

	// Token: 0x04000FFE RID: 4094
	protected EffectColliderProperty m_cColliderProperty;
}
