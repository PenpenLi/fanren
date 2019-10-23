using System;


public class ControlEventFalling : ControlEventBase
{
	public ControlEventFalling(bool Forced) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.FALLING;
		this.m_bForced = Forced;
	}
}
