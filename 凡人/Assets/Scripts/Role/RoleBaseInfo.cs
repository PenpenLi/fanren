using System;
using System.Collections.Generic;

public class RoleBaseInfo
{
	public int ID;

	public string Name;

	public string PrefabName;

	public Dictionary<RoleWearEquipPos, ulong> DefultEquip = new Dictionary<RoleWearEquipPos, ulong>();
}
