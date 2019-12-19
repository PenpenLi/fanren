using System;
using System.Collections.Generic;


/// <summary>
/// 怪物信息
/// </summary>
public class MonsterInfo : RoleStaticInfo
{
    public int MonsterID;

    public int ModelID;

    public string RealMeshName;

    public string HeadPicPath;

    public string Name;

    public int HurtID;

    public float MassNumber;

    public float MoveSpeed;

    public float HMoveSpeed;

    public float BMoveSpeed;

    public float TurnSpeed;

    public int Mp;

    public int Hp;

    public float AtkRange;

    public float PhyDamage;

    public float MagicDamage;

    public float PhyDefense;

    public float MagicDefense;

    public float metal;

    public float wood;

    public float water;

    public float fire;

    public float earth;

    public bool AniMove;

    public float ViewRange;

    public float _attackInterval;

    public int BloodType;

    public float HpHigh;

    public int dropSoulballRuleID;

    public int _randerSkillsID;

    public int _randerSkillCount;

    public List<MonsterSkill> _attackSkill;

    public int _skillBuff;

    public int _skillBlood;

    public int bevTreeID;

    public int SoulAmount;

    public float RageAmount;

    public int QTEId;

    public IdentityType identity;

    public float PrepareTime;

    public float PrepareDis;

    public int AttackTimes;

    public bool CallPartner;

    public bool MoveBack;
    
    public bool LateralMove;

    public bool Flee;

    public float FleeHpPercent;

    public float BegProbability;

    public int DieScriptMod;

    public int DieScriptData;

    public string InBattleWord;

    public string ProvokeWord;

    public string FleeWord;

    public float Height;

    public float Distance;

    public int SpawnEffect;

    public int DieEffect;

    public int DieSound;

    public int DieRule;

    public int BornBev;

    public List<int> DropRuleList = new List<int>();

    public MonsterInfo(MonsterInfo res)
	{
		this.MonsterID = res.MonsterID;
		this.ModelID = res.ModelID;
		this.RealMeshName = res.RealMeshName;
		this.HeadPicPath = res.HeadPicPath;
		this.Name = res.Name;
		this.HurtID = res.HurtID;
		this.MassNumber = res.MassNumber;
		this.MoveSpeed = res.MoveSpeed;
		this.HMoveSpeed = res.HMoveSpeed;
		this.BMoveSpeed = res.BMoveSpeed;
		this.TurnSpeed = res.TurnSpeed;
		this.Mp = res.Mp;
		this.Hp = res.Hp;
		this.AtkRange = res.AtkRange;
		this.PhyDamage = res.PhyDamage;
		this.MagicDamage = res.MagicDamage;
		this.PhyDefense = res.PhyDefense;
		this.MagicDefense = res.MagicDefense;
		this.metal = res.metal;
		this.wood = res.wood;
		this.water = res.water;
		this.fire = res.fire;
		this.earth = res.earth;
		this.AniMove = res.AniMove;
		this.ViewRange = res.ViewRange;
		this._attackInterval = res._attackInterval;
		this.BloodType = res.BloodType;
		this.HpHigh = res.HpHigh;
		this.dropSoulballRuleID = res.dropSoulballRuleID;
		this._randerSkillsID = res._randerSkillsID;
		this._randerSkillCount = res._randerSkillCount;
		this._attackSkill = new List<MonsterSkill>();
		this._attackSkill.Clear();
		foreach (MonsterSkill monsterSkill in res._attackSkill)
		{
			this._attackSkill.Add(new MonsterSkill(monsterSkill.SkillID, monsterSkill.UseRule));
		}
		this._skillBuff = res._skillBuff;
		this._skillBlood = res._skillBlood;
		this.bevTreeID = res.bevTreeID;
		this.SoulAmount = res.SoulAmount;
		this.RageAmount = res.RageAmount;
		this.QTEId = res.QTEId;
		this.identity = res.identity;
		this.PrepareTime = res.PrepareTime;
		this.PrepareDis = res.PrepareDis;
		this.AttackTimes = res.AttackTimes;
		this.CallPartner = res.CallPartner;
		this.MoveBack = res.MoveBack;
		this.LateralMove = res.LateralMove;
		this.Flee = res.Flee;
		this.FleeHpPercent = res.FleeHpPercent;
		this.BegProbability = res.BegProbability;
		this.DieScriptMod = res.DieScriptMod;
		this.DieScriptData = res.DieScriptData;
		this.InBattleWord = res.InBattleWord;
		this.ProvokeWord = res.ProvokeWord;
		this.FleeWord = res.FleeWord;
		this.Height = res.Height;
		this.Distance = res.Distance;
		this.SpawnEffect = res.SpawnEffect;
		this.DieEffect = res.DieEffect;
		this.DieSound = res.DieSound;
		this.DieRule = res.DieRule;
		this.BornBev = res.BornBev;
		this.DropRuleList.Clear();
		foreach (int item in res.DropRuleList)
		{
			this.DropRuleList.Add(item);
		}
	}

	public MonsterInfo()
	{
	}

	public override bool GetBackMove()
	{
		return this.MoveBack;
	}

	public override bool GetLateralMove()
	{
		return this.LateralMove;
	}

	public override int GetQTEID()
	{
		return this.QTEId;
	}

	public override int GetBevTreeID()
	{
		return this.bevTreeID;
	}
}
