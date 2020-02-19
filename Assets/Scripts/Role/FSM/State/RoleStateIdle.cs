using UnityEngine;
using System.Collections;
using YouYou;

/// <summary>
/// 待机状态
/// </summary>
public class RoleStateIdle : RoleStateBase
{
    public override void OnEnter()
    {
        base.OnEnter();
        if (GameEntry.Procedure.CurrProcedureState==ProcedureState.WorldMap)
        {
            CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToIdleNormal.ToString(), true);
        }
        else if(GameEntry.Procedure.CurrProcedureState == ProcedureState.GameLevel)
        {
            CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToIdleFight.ToString(), true);
        }     
    }

    public override void OnUpdate()
    {
        base.OnUpdate();      

        if (GameEntry.Procedure.CurrProcedureState == ProcedureState.WorldMap)
        {
            CurrRoleAnimatorStateInfo = CurrFsm.m_Owner.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);

            if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorState.Idle_Normal.ToString()))
            {
                //设置当前动画状态条件的目的是 防止频繁的进入相同 动画状态
                CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleAnimatorState.Idle_Normal);
            }
            else 
            {
                //防止怪原地跑
                CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
            }
        }
        else if (GameEntry.Procedure.CurrProcedureState == ProcedureState.GameLevel)
        {
            CurrRoleAnimatorStateInfo = CurrFsm.m_Owner.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
            if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorState.Idle_Fight.ToString()))
            {
                //设置当前动画状态条件的目的是 防止频繁的进入相同 动画状态
                CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleAnimatorState.Idle_Fight);
            }
            else
            {
                //防止怪原地跑
                CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
            }
        }
  
    }

    public override void OnLeave()
    {
        base.OnLeave();

        if (GameEntry.Procedure.CurrProcedureState == ProcedureState.WorldMap)
        {
            CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToIdleNormal.ToString(), false);
            CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToXiuXian.ToString(), false);
        }
        else if (GameEntry.Procedure.CurrProcedureState == ProcedureState.GameLevel)
        {
            CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToIdleFight.ToString(), false);
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}