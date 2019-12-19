﻿using System;

/// <summary>
/// 属性类型
/// </summary>
public enum ATTRIBUTE_TYPE
{
	ATT_NONE = -1,
    /// <summary>
    /// 等级
    /// </summary>
	ATT_LEVEL,
    /// <summary>
    /// 当前HP
    /// </summary>
	ATT_HP,
    /// <summary>
    /// 最大HP
    /// </summary>
	ATT_MAXHP,
	ATT_MP,
	ATT_MAXMP,
	ATT_CRITICAL,
	ATT_CRITCHANCE,
	ATT_PHY_HURTLESS,
	ATT_MAG_HURTLESS,
	ATT_PHY_ATK,
	ATT_PHY_DEF,
	ATT_MAG_ATK,
	ATT_MAG_DEF,
	ATT_BGILITY,
	ATT_BLOODREGAIN,
	ATT_MAGICREGAIN,
	ATT_SUPERARMOR,
	ATT_HITRECOVER,
	ATT_METAL_ELEMENT,
	ATT_WOOD_ELEMENT,
	ATT_WATER_ELEMENT,
	ATT_FIRE_ELEMENT,
	ATT_EARTH_ELEMENT,
	ATT_FIVE_ELEMENT_ATK,
	ATT_HunVal,
	ATT_MONEY,
    /// <summary>
    /// 出生
    /// </summary>
	ATT_BORN,
	ATT_FP,
	ATT_MAXFP,
	ATT_EXP,
	ATT_VIEW_RANGE,
	ATT_ATTACK_RANGE,
	ATT_ATTACK_INTERVAL,
    /// <summary>
    /// 移动速度
    /// </summary>
	ATT_MOVESPEED,
	ATT_TRUNSPEED,
	ATT_HMOVESPEED,
	ATT_BMOVESPEED,
	ATT_WALKSPEED,
	ATT_MOVESPEED_ORIGN,
	ATT_HMOVESPEED_ORIGN,
	ATT_BMOVESPEED_ORIGN,
	ATT_RUNSPEED,
	ATT_STRONG,
	ATT_STRONG_AWAYS,
	ATT_ATTACK_FLEE,
	ATT_PREPARE_TIME,
	ATT_ATTACK_TIMES,
	ATT_CUR_ATK_TIMES,
	ATT_CHAPTER,
	ATT_GROUND_TOUCH_TYPE,
	ATT_FEEBLE,
	ATT_WALKPATH,
	ATT_GROW,
	ATT_LIANTI,
	ATT_LIANSHEN,
	ATT_NUMERICAL_END = 1000
}