using UnityEngine;
using System.Collections;
using YouYou;

/// <summary>
/// 待机状态
/// </summary>
public class RoleStateIdle : RoleStateBase
{
    /// <summary>
    /// 此状态的运行时间
    /// </summary>
    private float m_RuningTime = 0;

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("进入Idle状态");

        CurrFsm.GetOwner().roleGameObject.RoleAnimator.SetBool(ToAnimatorCondition.ToIdleNormal.ToString(), true);

        m_RuningTime = 0;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        CurrRoleAnimatorStateInfo = CurrFsm.GetOwner().roleGameObject.RoleAnimator.GetCurrentAnimatorStateInfo(0);

        if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorState.Idle_Normal.ToString()))
        {
            //设置当前动画状态条件的目的是 防止频繁的进入相同 动画状态
            CurrFsm.GetOwner().roleGameObject.RoleAnimator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleAnimatorState.Idle_Normal);
        }
        else
        {
            //防止怪原地跑
            CurrFsm.GetOwner().roleGameObject.RoleAnimator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
        }
    }

    public override void OnLeave()
    {
        base.OnLeave();
        CurrFsm.GetOwner().roleGameObject.RoleAnimator.SetBool(ToAnimatorCondition.ToIdleNormal.ToString(), false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}