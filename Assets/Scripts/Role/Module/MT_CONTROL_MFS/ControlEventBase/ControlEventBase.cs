using System;

/// <summary>
/// 控制事件基类
/// </summary>
public class ControlEventBase
{
    protected bool m_bForced;

    protected CONTROL_INPUT m_iInputId;

    public ControlEventBase(bool Forced)
	{
		this.m_bForced = Forced;
	}

	public bool Forced
	{
		get
		{
			return this.m_bForced;
		}
	}

    public CONTROL_INPUT InputId
    {
        get
        {
            return this.m_iInputId;
        }
    }
}
