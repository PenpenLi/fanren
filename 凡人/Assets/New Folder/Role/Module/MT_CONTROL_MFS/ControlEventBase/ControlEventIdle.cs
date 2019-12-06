using System;

/// <summary>
/// Idle事件
/// </summary>
public class ControlEventIdle : ControlEventBase
{
	public ControlEventIdle(bool Forced) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.IDLE;
		this.m_bForced = Forced;
	}
}
