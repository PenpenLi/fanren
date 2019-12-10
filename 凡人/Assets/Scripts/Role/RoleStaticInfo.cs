using System;

/// <summary>
/// 角色静态信息
/// </summary>
public class RoleStaticInfo
{
	public virtual bool GetBackMove()
	{
		return false;
	}

	public virtual bool GetLateralMove()
	{
		return false;
	}

	public virtual int GetQTEID()
	{
		return 0;
	}

	public virtual int GetBevTreeID()
	{
		return 0;
	}
}
