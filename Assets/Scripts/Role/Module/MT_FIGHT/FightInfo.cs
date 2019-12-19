using System;
using UnityEngine;

public class FightInfo
{
	public void setFightInfo()
	{
	}

	public Role _role;

	public float _damage;

	public float _calculatedDamage = -1f;

	public float _figureEnergy;

	public float _percentDamage;

	public float _dist;

	public int _attackCount;

	public int _weaponType;

	public int materialID;

	public int hurtBev;

	public int figureID;

	public FightInfo.HURT_LEVEL hurtLevel;

	public ACTION_INDEX aniIndex;

	public Vector3 hurtPoint;

	public Vector3 hurtDirection;

	public Vector3 attackPoint;

	public FightInfo.HurtEffectInfo hurtEffectInfo;

	public int timeScaleID;

	public int screenShakeID;

	public Vector3 attackForce;

	//public HurtedHandle hurtedHandle;

	public int skillID;

	public float harmScale = 1f;

	public int weaponMateriaType;

	public FightInfo.FightType _fightType = FightInfo.FightType.FT_PHY;

	public enum FightType
	{
		FT_NONE,
		FT_PHY,
		FT_MAG
	}

	public class HurtEffectInfo
	{
        public int effectID;

        public FightInfo.HURT_EFFECT_TYPE type;

        public HurtEffectInfo(FightInfo.HURT_EFFECT_TYPE Type, int Id)
		{
			this.effectID = Id;
			this.type = Type;
		}
	}

	public enum HURT_EFFECT_TYPE
	{
		POSITION = 1,
		ONE_POS_BIND,
		BODY_BIND
	}

	public enum HURT_LEVEL
	{
		NORMAL,
		BREAK_WUDI,
		BREAK_BATI,
		BREAK_ALL
	}
}
