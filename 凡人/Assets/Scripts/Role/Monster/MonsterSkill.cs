using System;


/// <summary>
/// 怪物技能
/// </summary>
public class MonsterSkill
{
    /// <summary>
    /// 技能编号
    /// </summary>
    public int SkillID;

    public SkillUselRule UseRule;

    public MonsterSkill(int id, SkillUselRule uss)
	{
		this.SkillID = id;
		this.UseRule = uss;
	}


	public MonsterSkill()
	{
		this.SkillID = 0;
		this.UseRule = SkillUselRule.Init;
	}
}
