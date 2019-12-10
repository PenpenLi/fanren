using System;


public class ControlEventRestoreAttackIdle : ControlEventBase
{
	public ControlEventRestoreAttackIdle(bool Forced) : base(Forced)
	{
		this.m_iInputId = CONTROL_INPUT.RESTORE_ATTACK_IDLE;
		this.m_bForced = Forced;
	}
}
