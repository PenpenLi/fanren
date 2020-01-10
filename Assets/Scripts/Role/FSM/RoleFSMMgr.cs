using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// 流程状态
/// </summary>
public enum RoleState
{
    Idle = 0,
    Run = 1,
    Hurt = 2,
    Die = 3,
    Attack = 4,
}

/// <summary>
/// 角色有限状态机管理器
/// </summary>
public class RoleFSMMgr
{
    /// <summary>
    /// 当前角色控制器
    /// </summary>
    public RoleCtrl CurrRoleCtrl { get; private set; }

    /// <summary>
    /// 当前角色状态机
    /// </summary>
    private Fsm<RoleFSMMgr> m_CurrFsm;

    /// <summary>
    /// 当前角色状态枚举
    /// </summary>
    public RoleState CurrRoleStateEnum { get; private set; }

    /// <summary>
    /// 当前的角色状态
    /// </summary>
    public RoleState CurrProcedureState
    {
        get
        {
            return (RoleState)m_CurrFsm.CurrStateType;
        }
    }

    /// <summary>
    /// 当前的角色状态机
    /// </summary>
    public FsmState<RoleFSMMgr> CurrRole
    {
        get
        {
            return m_CurrFsm.GetState(m_CurrFsm.CurrStateType);
        }
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="currRoleCtrl"></param>
    public RoleFSMMgr(RoleCtrl currRoleCtrl, Action onDie, Action onDestroy)
    {
        CurrRoleCtrl = currRoleCtrl;

        //RoleStateDie dieState = (RoleStateDie)m_RoleStateDic[RoleState.Die];
        //dieState.OnDie = onDie;
        //dieState.OnDestroy = onDestroy;

        FsmState<RoleFSMMgr>[] states = new FsmState<RoleFSMMgr>[5];
        states[0] = new RoleStateIdle();
        states[1] = new RoleStateRun();
        states[2] = new RoleStateHurt();
        states[3] = new RoleStateDie();
        states[4] = new RoleStateAttack();

        m_CurrFsm = GameEntry.Fsm.Create(this, states);    
    }

    #region OnUpdate 每帧执行
    /// <summary>
    /// 每帧执行
    /// </summary>
    public void OnUpdate()
    {
        m_CurrFsm.OnUpate();
    }
    #endregion

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(RoleState state)
    {
        m_CurrFsm.ChangeState((byte)state);
    }
}