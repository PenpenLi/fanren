using System;

public class RoleEventHandler
{
    private Role owner;

    public RoleEventHandler()
	{
	}

	public RoleEventHandler(Role role)
	{
		this.owner = role;
	}

	public void Init(Role role)
	{
		this.owner = role;
	}

	//public void AddBeforeHurtEvent(RoleHurtEventHandler handler)
	//{
	//	if (this.owner == null)
	//	{
	//		return;
	//	}
	//	ModFight modFight = this.owner.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
	//	if (modFight == null)
	//	{
	//		return;
	//	}
	//	modFight.beforeHurt += handler;
	//}

	//public void RemoveBeforeHurtEvent(RoleHurtEventHandler handler)
	//{
	//	if (this.owner == null)
	//	{
	//		return;
	//	}
	//	ModFight modFight = this.owner.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
	//	if (modFight == null)
	//	{
	//		return;
	//	}
	//	modFight.beforeHurt -= handler;
	//}

	//public void AddBeforeDeadEvent(RoleDeadEventHandler handler)
	//{
	//	if (this.owner == null)
	//	{
	//		return;
	//	}
	//	this.owner.beforeDead += handler;
	//}

	//public void RemoveBeforeDeadEvent(RoleDeadEventHandler handler)
	//{
	//	if (this.owner == null)
	//	{
	//		return;
	//	}
	//	this.owner.beforeDead -= handler;
	//}
}
