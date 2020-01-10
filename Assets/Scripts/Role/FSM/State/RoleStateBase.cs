using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

/// <summary>
/// 角色状态机基类
/// </summary>
public class RoleStateBase : FsmState<RoleFSMMgr>
{
    /// <summary>
    /// 当前动画状态信息
    /// </summary>
    public AnimatorStateInfo CurrRoleAnimatorStateInfo { get; set; }

    /// <summary>
    /// 是否切换动画状态完毕
    /// </summary>
    protected bool IsChangeOver { get; set; }

    public override void OnEnter()
    {

    }

    public override void OnUpdate()
    {

    }

    public override void OnLeave()
    {

    }

    public override void OnDestroy()
    {

    }

}
