using System;
using System.Collections.Generic;
using UnityUtility;

/// <summary>
/// 玩家战斗数据
/// </summary>
public class PlayerFightData : Singleton<PlayerFightData>
{
    private const string CONFIG_PATH = "conf/PlayerFightConfig";

    private Dictionary<EquipCfgType, float> closeWeaponTime;

    public PlayerFightData()
	{
		this.ReadData();
	}

	public float SwordSelectDistance { get; private set; }

	public float DaggerSelectDistance { get; private set; }

	public float MagicSelectDistance { get; private set; }

	public float MoveSelectAngle { get; private set; }

	public float StaySelectAngle_1 { get; private set; }

	public float StaySelectAngle_2 { get; private set; }

	public float RollBackTime { get; private set; }

	public float RollCheckInputTime { get; private set; }

	public float WeaponStayTime { get; private set; }

	public float GetCloseWeaponTime(EquipCfgType type)
	{
		if (this.closeWeaponTime.ContainsKey(type))
		{
			return this.closeWeaponTime[type];
		}
		return 0f;
	}

	private void ReadData()
	{
		List<string> list = UtilityLoader.LoadConfText("conf/PlayerFightConfig");
		if (list.Count <= 0)
		{
			return;
		}
		this.closeWeaponTime = new Dictionary<EquipCfgType, float>();
		int i = 0;
		while (i < list.Count)
		{
			this.SwordSelectDistance = float.Parse(list[i++]);
			this.DaggerSelectDistance = float.Parse(list[i++]);
			this.MagicSelectDistance = float.Parse(list[i++]);
			this.MoveSelectAngle = float.Parse(list[i++]);
			this.StaySelectAngle_1 = float.Parse(list[i++]);
			this.StaySelectAngle_2 = float.Parse(list[i++]);
			this.RollBackTime = float.Parse(list[i++]);
			this.RollCheckInputTime = float.Parse(list[i++]);
			this.WeaponStayTime = float.Parse(list[i++]);
			this.closeWeaponTime.Add(EquipCfgType.EQCHILD_CT_WEAPON, float.Parse(list[i++]));
			this.closeWeaponTime.Add(EquipCfgType.EQCHILD_CT_DWEAPON, float.Parse(list[i++]));
			this.closeWeaponTime.Add(EquipCfgType.EQCHILD_CT_MAGICWEAPON, float.Parse(list[i++]));
		}
	}
}
