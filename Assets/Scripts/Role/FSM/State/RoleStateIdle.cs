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
        CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToIdleNormal.ToString(), true);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
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

    public override void OnLeave()
    {
        base.OnLeave();
        CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToIdleNormal.ToString(), false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}