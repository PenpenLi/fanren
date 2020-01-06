//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-12-12 08:58:19
//备    注：
//===================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 角色信息基类
/// </summary>
public class RoleInfoBase 
{
    public int RoleId; //角色编号
    public string RoleNickName; //角色昵称
    public int Level; //等级
    public int Exp; //经验
    public int MaxHP; //最大HP
    public int MaxMP; //最大MP
    public int CurrHP; //当前HP
    public int CurrMP; //当前MP
    public int Attack; //攻击力
    public int Defense; //防御
    public int Hit; //命中
    public int Dodge; //闪避
    public int Cri; //暴击
    public int Res; //抗性
    public int Fighting; //综合战斗力

    /// <summary>
    /// 角色的技能列表
    /// </summary>
    public List<RoleInfoSkill> SkillList;

    /// <summary>
    /// 角色的物理攻击Id数组
    /// </summary>
    public int[] PhySkillIds;

    public RoleInfoBase()
    {
        SkillList = new List<RoleInfoSkill>();
    }

    /// <summary>
    /// 根据技能Id获取技能等级
    /// </summary>
    /// <param name="skillId"></param>
    /// <returns></returns>
    public int GetSkillLevel(int skillId)
    {
        if (SkillList == null) return 1;
        for (int i = 0; i < SkillList.Count; i++)
        {
            if (SkillList[i].SkillId == skillId)
            {
                return SkillList[i].SkillLevel;
            }
        }
        return 1;
    }

    /// <summary>
    /// 设置角色的物理攻击
    /// </summary>
    /// <param name="phySkillIds"></param>
    public void SetPhySkillId(string phySkillIds)
    {
        string[] ids = phySkillIds.Split(';');

        PhySkillIds = new int[ids.Length];

        for (int i = 0; i < ids.Length; i++)
        {
            PhySkillIds[i] = ids[i].ToInt();
        }
    }

    /// <summary>
    /// 设置技能的冷却结束时间
    /// </summary>
    /// <param name="skillId"></param>
    public void SetSkillCDEndTime(int skillId)
    {
        if (SkillList.Count > 0)
        {
            for (int i = 0; i < SkillList.Count; i++)
            {
                if (SkillList[i].SkillId == skillId)
                {
                    SkillList[i].SkillCDEndTime = SkillList[i].SkillCDTime + Time.time;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 获取可使用的技能Id
    /// </summary>
    /// <returns></returns>
    public int GetCanUsedSkillId()
    {
        if (SkillList.Count > 0)
        {
            for (int i = 0; i < SkillList.Count; i++)
            {
                if (Time.time > SkillList[i].SkillCDEndTime && CurrMP >= SkillList[i].SpendMP)
                {
                    return SkillList[i].SkillId;
                }
            }
        }
        return 0;
    }
}