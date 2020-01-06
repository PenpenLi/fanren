//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-12-12 08:57:48
//备    注：
//===================================================
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// 主角主城AI
/// </summary>
public class RoleMainPlayerCityAI : IRoleAI
{
    public RoleCtrl CurrRole
    {
        get;
        set;
    }

    public RoleMainPlayerCityAI(RoleCtrl roleCtrl)
    {
        CurrRole = roleCtrl;
        m_SearchList = new List<Collider>();
    }

    /// <summary>
    /// 物理攻击技能Id 索引
    /// </summary>
    private int m_PhyIndex = 0;

    public void DoAI()
    {
        //执行AI
        //if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Die) return;

        //if (CurrRole.Attack.IsAutoFight)
        //{
        //    AutoFightState();
        //}
        //else
        //{
        //    NormalState();
        //}
    }

    /// <summary>
    /// 搜索到的敌人列表
    /// </summary>
    private List<Collider> m_SearchList = null;

    private Vector3 m_MoveToPoint;

    private RaycastHit hitInfo;

    private Vector3 m_RayPoint;

    //#region AutoFightState 自动战斗状态
    ///// <summary>
    ///// 自动战斗状态
    ///// </summary>
    //private void AutoFightState()
    //{
    //    if (CurrRole.IsRigidity) return;

    //    if (!GameLevelSceneCtrl.Instance.CurrRegionHasMonster) //如果当前区域已经没有怪了
    //    {
    //        if (GameLevelSceneCtrl.Instance.CurrRegionIsLast)
    //        {
    //            //如果 当前是最后一个区域了 直接返回
    //            return;
    //        }
    //        else
    //        {
    //            //否则进入下一个区域
    //            CurrRole.MoveTo(GameLevelSceneCtrl.Instance.NextRegionPlayerBornPos);
    //        }
    //    }
    //    else
    //    {
    //        //找怪 打怪

    //        if (CurrRole.LockEnemy == null) //如果当前没有锁定敌人
    //        {
    //            //如果没有锁定敌人
    //            //发射射线去找 找离当前攻击者 最近的 就是锁定敌人
    //            Collider[] searchList = Physics.OverlapSphere(CurrRole.gameObject.transform.position, 1000f, 1 << LayerMask.NameToLayer("Role"));

    //            m_SearchList.Clear();
    //            if (searchList != null && searchList.Length > 0)
    //            {
    //                for (int i = 0; i < searchList.Length; i++)
    //                {
    //                    RoleCtrl ctrl = searchList[i].GetComponent<RoleCtrl>();
    //                    if (ctrl != null)
    //                    {
    //                        if (ctrl.CurrRoleInfo.RoleId != CurrRole.CurrRoleInfo.RoleId)
    //                        {
    //                            m_SearchList.Add(searchList[i]);
    //                        }
    //                    }
    //                }
    //            }

    //            //对敌人进行排序 找到最近的
    //            m_SearchList.Sort((Collider c1, Collider c2) =>
    //            {
    //                int ret = 0;

    //                if (Vector3.Distance(c1.gameObject.transform.position, CurrRole.gameObject.transform.position) <
    //                    Vector3.Distance(c2.gameObject.transform.position, CurrRole.gameObject.transform.position))
    //                {
    //                    ret = -1;
    //                }
    //                else
    //                {
    //                    ret = 1;
    //                }

    //                return ret;
    //            });

    //            //当作锁定敌人
    //            if (m_SearchList.Count > 0)
    //            {
    //                CurrRole.LockEnemy = m_SearchList[0].GetComponent<RoleCtrl>();
    //            }
    //        }
    //        else
    //        {
    //            //当前有锁定敌人

    //            //锁定敌人已经死亡 设置为Null 然后返回
    //            if (CurrRole.LockEnemy.CurrRoleInfo.CurrHP <= 0)
    //            {
    //                CurrRole.LockEnemy = null;
    //                return;
    //            }

    //            //定义要使用的技能id和技能类型(物理/技能)
    //            //首先检测有没有可使用的技能
    //            int skillId = CurrRole.CurrRoleInfo.GetCanUsedSkillId();
    //            RoleAttackType type;

    //            if (skillId > 0)//如果有可使用的技能
    //            {
    //                //使用技能攻击
    //                //设置技能id
    //                type = RoleAttackType.SkillAttack;
    //            }
    //            else
    //            {
    //                //使用物理攻击
    //                //设置物理攻击技能id
    //                skillId = CurrRole.CurrRoleInfo.PhySkillIds[m_PhyIndex];
    //                type = RoleAttackType.PhyAttack;

    //                m_PhyIndex++;

    //                if (m_PhyIndex >= CurrRole.CurrRoleInfo.PhySkillIds.Length)
    //                {
    //                    m_PhyIndex = 0;
    //                }
    //            }


    //            SkillEntity entity = SkillDBModel.Instance.Get(skillId);
    //            if (entity == null) return;

    //            //判断敌人 是否在此技能的攻击范围内
    //            if (Vector3.Distance(CurrRole.transform.position, CurrRole.LockEnemy.transform.position) <= entity.AttackRange)
    //            {
    //                if (type == RoleAttackType.SkillAttack)
    //                {
    //                    PlayerCtrl.Instance.OnSkillClick(skillId);
    //                }
    //                else
    //                {
    //                    //对敌人发起攻击
    //                    CurrRole.ToAttack(type, skillId);
    //                }
    //            }
    //            else
    //            {
    //                //在我的技能攻击范围外
    //                //进行追击

    //                //如果在我的视野范围之内 攻击范围之外 进行追击
    //                if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Idle)
    //                {
    //                    //半圆内找
    //                    m_MoveToPoint = GameUtil.GetRandomPos(CurrRole.transform.position, CurrRole.LockEnemy.transform.position, entity.AttackRange);

    //                    m_RayPoint = new Vector3(m_MoveToPoint.x, m_MoveToPoint.y + 50, m_MoveToPoint.z);
    //                    if (Physics.Raycast(m_RayPoint, new Vector3(0, -100, 0), out hitInfo, 1000f, 1 << LayerMask.NameToLayer("RegionMask")))
    //                    {
    //                        return;
    //                    }
    //                    //移动到敌人周围 攻击半径内的随机点
    //                    CurrRole.MoveTo(m_MoveToPoint);
    //                }
    //            }
    //        }
    //    }
    //}
    //#endregion

    //#region NormalState 普通状态
    ///// <summary>
    ///// 普通状态
    ///// </summary>
    //private void NormalState()
    //{
    //    //如果离上次战斗时间超过 30秒 切换普通待机
    //    if (CurrRole.PrevFightTime != 0)
    //    {
    //        if (Time.time > CurrRole.PrevFightTime + 30f)
    //        {
    //            CurrRole.ToIdle();
    //            CurrRole.PrevFightTime = 0;
    //        }
    //    }

    //    //1.如果我有锁定敌人 就行攻击
    //    if (CurrRole.LockEnemy != null)
    //    {
    //        if (CurrRole.LockEnemy.CurrRoleInfo.CurrHP <= 0)
    //        {
    //            CurrRole.LockEnemy = null;
    //            return;
    //        }

    //        if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Idle)
    //        {
    //            if (CurrRole.Attack.FollowSkillId > 0)
    //            {
    //                //如果有后续技能 使用后续技能
    //                PlayerCtrl.Instance.OnSkillClick(CurrRole.Attack.FollowSkillId);
    //            }
    //            else
    //            {
    //                //否则 使用物理攻击
    //                int skillId = CurrRole.CurrRoleInfo.PhySkillIds[m_PhyIndex];
    //                CurrRole.ToAttack(RoleAttackType.PhyAttack, skillId);

    //                m_PhyIndex++;

    //                if (m_PhyIndex >= CurrRole.CurrRoleInfo.PhySkillIds.Length)
    //                {
    //                    m_PhyIndex = 0;
    //                }
    //            }
    //        }
    //    }
    //}
    //#endregion
}