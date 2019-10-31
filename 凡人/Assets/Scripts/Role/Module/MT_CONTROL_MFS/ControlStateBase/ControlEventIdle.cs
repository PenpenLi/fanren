using System;

// Token: 0x020004A7 RID: 1191
public class ControlEventIdle : ControlEventBase
{
	// Token: 0x06001EE8 RID: 7912 RVA: 0x000D5918 File Offset: 0x000D3B18
	public ControlEventIdle(bool Forced) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.IDLE;
		this.m_bForced = Forced;
	}
}
