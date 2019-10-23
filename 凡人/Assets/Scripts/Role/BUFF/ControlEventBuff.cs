using System;

// Token: 0x020004BA RID: 1210
public class ControlEventBuff : ControlEventBase
{
	// Token: 0x06001F61 RID: 8033 RVA: 0x00015820 File Offset: 0x00013A20
	public ControlEventBuff(bool Forced, int Ani) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.BUFF;
		this.m_bForced = Forced;
		this.m_iAnimation = Ani;
	}

	// Token: 0x170003AD RID: 941
	// (get) Token: 0x06001F62 RID: 8034 RVA: 0x0001583F File Offset: 0x00013A3F
	public int Ani
	{
		get
		{
			return this.m_iAnimation;
		}
	}

	// Token: 0x04001BFD RID: 7165
	private int m_iAnimation;
}
