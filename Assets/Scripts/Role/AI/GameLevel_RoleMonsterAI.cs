//using UnityEngine;
//using System.Collections;
//using System;

///// <summary>
///// 怪AI
///// </summary>
//public class GameLevel_RoleMonsterAI : IRoleAI
//{
//    /// <summary>
//    /// 当前角色控制器
//    /// </summary>
//    public RoleCtrl CurrRole
//    {
//        get;
//        set;
//    }

//    /// <summary>
//    /// 下次巡逻时间
//    /// </summary>
//    private float m_NextPatrolTime = 0f;

//    /// <summary>
//    /// 下次攻击时间
//    /// </summary>
//    private float m_NextAttackTime = 0f;

//    /// <summary>
//    /// 怪的信息
//    /// </summary>
//    private RoleInfoMonster m_Info;

//    /// <summary>
//    /// 要使用的技能Id
//    /// </summary>
//    private int m_UsedSkillId = 0;

//    ///// <summary>
//    ///// 攻击类型
//    ///// </summary>
//    //private RoleAttackType m_RoleAttackType;

//    /// <summary>
//    /// 要移动要的目标点
//    /// </summary>
//    private Vector3 m_MoveToPoint;

//    private RaycastHit hitInfo;

//    private Vector3 m_RayPoint;

//    /// <summary>
//    /// 下次思考时间
//    /// </summary>
//    private float m_NextThinkTime = 0f;

//    /// <summary>
//    /// 是否发呆中
//    /// </summary>
//    private bool m_IsDaze;

//    public GameLevel_RoleMonsterAI(RoleCtrl roleCtrl, RoleInfoMonster info)
//    {
//        CurrRole = roleCtrl;
//        m_Info = info;
//    }

//    public void DoAI()
//    {
//        //如果当前玩家 不存在 直接返回
//        //if (GlobalInit.Instance == null || GlobalInit.Instance.CurrPlayer == null) return;

//        //如果怪已经死亡 直接返回
//        if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Die || CurrRole.IsRigidity) return;

//        if (CurrRole.LockEnemy == null)
//        {
//            //如果怪没有锁定敌人

//            //如果是待机状态
//            if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Idle)
//            {
//                if (Time.time > m_NextPatrolTime)
//                {
//                    m_NextPatrolTime = Time.time + UnityEngine.Random.Range(5f, 10f);


//                    m_MoveToPoint = new Vector3(CurrRole.BornPoint.x + UnityEngine.Random.Range(CurrRole.PatrolRange * -1, CurrRole.PatrolRange), CurrRole.BornPoint.y, CurrRole.BornPoint.z + UnityEngine.Random.Range(CurrRole.PatrolRange * -1, CurrRole.PatrolRange));

//                    m_RayPoint = new Vector3(m_MoveToPoint.x, m_MoveToPoint.y + 50, m_MoveToPoint.z);
//                    if (Physics.Raycast(m_RayPoint, new Vector3(0, -100, 0), out hitInfo, 1000f, 1 << LayerMask.NameToLayer("RegionMask")))
//                    {
//                        return;
//                    }

//                    //进行巡逻
//                    CurrRole.MoveTo(m_MoveToPoint);
//                }
//            }

//            //如果主角在怪的视野范围内
//            //if (Vector3.Distance(CurrRole.transform.position, GlobalInit.Instance.CurrPlayer.transform.position) <= CurrRole.ViewRange)
//            //{
//            //    CurrRole.LockEnemy = GlobalInit.Instance.CurrPlayer;

//            //    //下次攻击时刻 = 当前时刻 + 延迟攻击时间
//            //    m_NextAttackTime = Time.time + m_Info.SpriteEntity.DelaySec_Attack;
//            //}
//        }
//        else
//        {
//            //锁定敌人已经死亡 设置为Null 然后返回
//            if (CurrRole.LockEnemy.CurrRoleInfo.CurrHP <= 0)
//            {
//                CurrRole.LockEnemy = null;
//                return;
//            }

//            if (Time.time > m_NextThinkTime + UnityEngine.Random.Range(3, 3.5f))
//            {
//                //让角色休息
//                //CurrRole.ToIdle(RoleIdleState.IdleFight);
//                m_NextThinkTime = Time.time;
//                m_IsDaze = true;
//            }

//            if (m_IsDaze)
//            {
//                //如果角色休息中
//                if (Time.time > m_NextThinkTime + UnityEngine.Random.Range(1, 1.5f))
//                {
//                    m_IsDaze = false;
//                }
//                else
//                {
//                    //如果角色休息中 直接返回
//                    return;
//                }
//            }

//            if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum != RoleState.Idle) return;

//            //如果有锁定敌人
//            //如果我和锁定敌人的距离 超过了我的视野范围 则取消锁定
//            //主角跑得快 会脱离怪的视野范围 则怪取消追击
//            //if (Vector3.Distance(CurrRole.transform.position, GlobalInit.Instance.CurrPlayer.transform.position) > CurrRole.ViewRange)
//            //{
//            //    CurrRole.LockEnemy = null;
//            //    return;
//            //}

//            //如果有锁定敌人
//            //1.得到要使用的技能Id(包括物理攻击Id)
//            if (m_Info.SpriteEntity.PhysicalAttackRate >= UnityEngine.Random.Range(0, 100))
//            {
//                //说明要使用物理攻击
//                //m_UsedSkillId = m_Info.SpriteEntity.UsedPhyAttackArr[UnityEngine.Random.Range(0, m_Info.SpriteEntity.UsedPhyAttackArr.Length)];
//                //m_RoleAttackType = RoleAttackType.PhyAttack;
//            }
//            else
//            {
//                //使用技能攻击
//                //m_UsedSkillId = m_Info.SpriteEntity.UsedSkillListArr[UnityEngine.Random.Range(0, m_Info.SpriteEntity.UsedSkillListArr.Length)];
//                //m_RoleAttackType = RoleAttackType.SkillAttack;
//            }

//            //SkillEntity entity = SkillDBModel.Instance.Get(m_UsedSkillId);
//            //if (entity == null) return;


//            ////2.判断敌人 是否在此技能的攻击范围内
//            //if (Vector3.Distance(CurrRole.transform.position, GlobalInit.Instance.CurrPlayer.transform.position) <= entity.AttackRange)
//            //{
//            //    //让怪 朝向主角
//            //    CurrRole.transform.LookAt(new Vector3(CurrRole.LockEnemy.transform.position.x, CurrRole.transform.position.y, CurrRole.LockEnemy.transform.position.z));

//            //    //如果当前时刻大于下次攻击时刻 并且 当前角色 不处于攻击状态
//            //    if (Time.time > m_NextAttackTime && CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum != RoleState.Attack)
//            //    {
//            //        m_NextAttackTime = Time.time + UnityEngine.Random.Range(0f, 1f) + m_Info.SpriteEntity.Attack_Interval;

//            //        CurrRole.ToAttack(m_RoleAttackType, m_UsedSkillId);
//            //    }
//            //}
//            //else
//            //{
//            //    //如果在我的视野范围之内 攻击范围之外 进行追击
//            //    if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Idle)
//            //    {
//            //        //半圆内找
//            //        m_MoveToPoint = GameUtil.GetRandomPos(CurrRole.transform.position, CurrRole.LockEnemy.transform.position, entity.AttackRange);

//            //        m_RayPoint = new Vector3(m_MoveToPoint.x, m_MoveToPoint.y + 50, m_MoveToPoint.z);
//            //        if (Physics.Raycast(m_RayPoint, new Vector3(0, -100, 0), out hitInfo, 1000f, 1 << LayerMask.NameToLayer("RegionMask")))
//            //        {
//            //            return;
//            //        }
//            //        //移动到敌人周围 攻击半径内的随机点
//            //        CurrRole.MoveTo(m_MoveToPoint);
//            //    }
//            //}
//        }
//    }
//}