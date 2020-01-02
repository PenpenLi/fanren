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
    /// 流程状态机
    /// </summary>
    private Fsm<RoleFSMMgr> m_CurrFsm;

    /// <summary>
    /// 当前流程状态机
    /// </summary>
    public Fsm<RoleFSMMgr> CurrFsm
    {
        get
        {
            return m_CurrFsm;
        }
    }

    /// <summary>
    /// 当前的流程状态
    /// </summary>
    public RoleState CurrRoleState
    {
        get
        {
            return (RoleState)m_CurrFsm.CurrStateType;
        }
    }

    /// <summary>
    /// 当前的流程
    /// </summary>
    public FsmState<RoleFSMMgr> CurrProcedure
    {
        get
        {
            return m_CurrFsm.GetState(m_CurrFsm.CurrStateType);
        }
    }

    public RoleFSMMgr()
    {
        FsmState<RoleFSMMgr>[] states = new FsmState<RoleFSMMgr>[5];
        states[0] = new RoleStateIdle();
        states[1] = new RoleStateRun();
        states[2] = new RoleStateHurt();
        states[3] = new RoleStateDie();
        states[4] = new RoleStateAttack();

        m_CurrFsm = GameEntry.Fsm.Create(this, states);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
      
    }

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(RoleState state)
    {
        m_CurrFsm.ChangeState((byte)state);
    }

    public void OnUpdate()
    {
        m_CurrFsm.OnUpate();
    }
}