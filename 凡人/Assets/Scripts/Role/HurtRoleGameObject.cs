using System;


public class HurtRoleGameObject : HurtGameObject
{
    protected Role role;

    protected int modelID;

    //protected ModFight modFight;

    public Role TheRole
	{
		get
		{
			return this.role;
		}
	}


	public int ModelID
	{
		get
		{
			return this.modelID;
		}
	}

	public virtual void SetRole(Role theRole)
	{
		if (theRole == null)
		{
			return;
		}
		this.role = theRole;
	}

	public void SetModelID(int id)
	{
		this.modelID = id;
	}

	public void Remove()
	{
		//this.role = null;
		//this.modFight = null;
	}

	//public override void Hurt(FightInfo info)
	//{
	//	if (this.role == null)
	//	{
	//		return;
	//	}
	//	if (this.modFight == null)
	//	{
	//		this.modFight = (this.role.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight);
	//	}
	//	if (this.modFight != null)
	//	{
	//		this.modFight.Hurt(info, ACTION_INDEX.AN_NONE);
	//	}
	//}

	public override int GetOwnerID()
	{
		if (this.role == null)
		{
			return 0;
		}
		return this.role.ID;
	}

	//public override int GetBodyMaterialType()
	//{
	//	if (this.role == null)
	//	{
	//		return 0;
	//	}
	//	return this.role.roleGameObject.ModelInfo.MaterialType;
	//}
}
