using System;
using UnityEngine;

// Token: 0x02000498 RID: 1176
public class ControlEventAttack : ControlEventBase
{
	// Token: 0x06001EB8 RID: 7864 RVA: 0x000D54EC File Offset: 0x000D36EC
	public ControlEventAttack(bool Forced, Vector3 targetDir, Role target) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK;
		this.m_bForced = Forced;
		this.m_cTarget = target;
		this.m_vecTargetDir = targetDir;
	}

	// Token: 0x06001EB9 RID: 7865 RVA: 0x000D5524 File Offset: 0x000D3724
	public ControlEventAttack(bool Forced, Vector3 targetDir, Role target, int combo) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK;
		this.m_bForced = Forced;
		this.m_cTarget = target;
		this.m_vecTargetDir = targetDir;
		this.comboNum = combo;
	}

	// Token: 0x06001EBA RID: 7866 RVA: 0x000D5564 File Offset: 0x000D3764
	public ControlEventAttack(bool Forced, Vector3 targetDir, Role target, int combo, int comboId) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.ATTACK;
		this.m_bForced = Forced;
		this.m_cTarget = target;
		this.m_vecTargetDir = targetDir;
		this.comboNum = combo;
		this.m_comboID = comboId;
	}

	// Token: 0x1700037B RID: 891
	// (get) Token: 0x06001EBB RID: 7867 RVA: 0x000D55AC File Offset: 0x000D37AC
	public Role Target
	{
		get
		{
			return this.m_cTarget;
		}
	}

	// Token: 0x1700037C RID: 892
	// (get) Token: 0x06001EBC RID: 7868 RVA: 0x000D55B4 File Offset: 0x000D37B4
	public Vector3 TargetDir
	{
		get
		{
			return this.m_vecTargetDir;
		}
	}

	// Token: 0x04001B82 RID: 7042
	private Role m_cTarget;

	// Token: 0x04001B83 RID: 7043
	private Vector3 m_vecTargetDir;

	// Token: 0x04001B84 RID: 7044
	public int m_imouseFlag;

	// Token: 0x04001B85 RID: 7045
	public int m_comboID;

	// Token: 0x04001B86 RID: 7046
	public int comboNum = -1;
}
