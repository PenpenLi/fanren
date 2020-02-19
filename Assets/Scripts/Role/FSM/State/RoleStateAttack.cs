using UnityEngine;
using System.Collections;

/// <summary>
/// 攻击状态
/// </summary>
public class RoleStateAttack : RoleStateBase
{
    /// <summary>
    /// 动画控制器执行条件
    /// </summary>
    public string AnimatorCondition;

    /// <summary>
    /// （旧）动画控制器执行条件 目的：因为是先调用上一个状态的离开
    /// </summary>
    private string m_OldAnimatorCondition;

    /// <summary>
    /// 条件值
    /// </summary>
    public int AnimatorConditionValue;

    /// <summary>
    /// 当前角色动画状态
    /// </summary>
    public RoleAnimatorState AnimatorCurrState;

    /// <summary>
    /// 实现基类 进入状态
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        //CurrFsm.m_Owner.CurrRoleCtrl.PrevFightTime = Time.time;

        //m_OldAnimatorCondition = AnimatorCondition;
        //CurrFsm.m_Owner.CurrRoleCtrl.IsRigidity = true;

        //CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(AnimatorCondition, AnimatorConditionValue);

        //if (CurrFsm.m_Owner.CurrRoleCtrl.LockEnemy != null)
        //{
        //    CurrFsm.m_Owner.CurrRoleCtrl.transform.LookAt(new Vector3(CurrFsm.m_Owner.CurrRoleCtrl.LockEnemy.transform.position.x, CurrFsm.m_Owner.CurrRoleCtrl.transform.position.y, CurrFsm.m_Owner.CurrRoleCtrl.LockEnemy.transform.position.z));
        //}
    }

    /// <summary>
    /// 实现基类 执行状态
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();

        //CurrRoleAnimatorStateInfo = CurrFsm.m_Owner.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
        //if (CurrRoleAnimatorStateInfo.IsName(AnimatorCurrState.ToString()))
        //{
        //    CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)AnimatorCurrState);

        //    //如果动画执行了一遍 就切换待机
        //    if (CurrRoleAnimatorStateInfo.normalizedTime > 1)
        //    {
        //        CurrFsm.m_Owner.CurrRoleCtrl.IsRigidity = false;
        //        CurrFsm.m_Owner.CurrRoleCtrl.ToIdle(RoleIdleState.IdleFight);
        //    }
        //}
        //else
        //{
        //    CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
        //}
    }

    /// <summary>
    /// 实现基类 离开状态
    /// </summary>
    public override void OnLeave()
    {
        base.OnLeave();
        //CurrFsm.m_Owner.CurrRoleCtrl.IsRigidity = false;
        //CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(m_OldAnimatorCondition, 0);
        //CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}