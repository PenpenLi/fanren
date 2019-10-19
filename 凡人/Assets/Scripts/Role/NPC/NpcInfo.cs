using System;

/// <summary>
/// NPC信息
/// </summary>
public class NpcInfo : RoleStaticInfo
{
    public int ID;

    public int ModelID;

    public string HeadPicPath;

    public string Name;

    public ORG_TYPE OrgType;

    public int scriptModID;

    public int scriptDataID;

    public int bevNodeType;

    public float ViewRange;

    public int prepareDis;

    public float walkSpeed;

    public NpcInfo(NpcInfo res)
	{
		this.ID = res.ID;
		this.ModelID = res.ModelID;
		this.HeadPicPath = res.HeadPicPath;
		this.Name = res.Name;
		this.OrgType = res.OrgType;
		this.scriptModID = res.scriptModID;
		this.scriptDataID = res.scriptDataID;
		this.bevNodeType = res.bevNodeType;
		this.ViewRange = res.ViewRange;
		this.walkSpeed = res.walkSpeed;
	}

	public NpcInfo()
	{
	}

	public override int GetBevTreeID()
	{
		return this.bevNodeType;
	}
}
