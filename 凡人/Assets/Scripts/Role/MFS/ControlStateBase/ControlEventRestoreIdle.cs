using System;

public class ControlEventRestoreIdle : ControlEventBase
{
	public ControlEventRestoreIdle(bool Forced) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.RESTORE_IDLE;
		this.m_bForced = Forced;
	}
}
