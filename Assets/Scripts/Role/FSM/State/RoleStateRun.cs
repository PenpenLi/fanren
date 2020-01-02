//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-12-12 08:54:29
//备    注：
//===================================================
using UnityEngine;
using System.Collections;

/// <summary>
/// 跑状态
/// </summary>
public class RoleStateRun : RoleStateBase
{
    private MoveTarget m_cMove;

    /// <summary>
    /// 转身速度
    /// </summary>
    private float m_RotationSpeed = 0.2f;

    /// <summary>
    /// 转身的目标方向
    /// </summary>
    private Quaternion m_TargetQuaternion;

    /// <summary>
    /// 移动速度
    /// </summary>
    private float m_MoveSpeed = 0f;

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("进入Run状态");
        CurrFsm.GetOwner().roleGameObject.RoleAnimator.SetBool(ToAnimatorCondition.ToRun.ToString(), true);

       
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        CurrRoleAnimatorStateInfo = CurrFsm.GetOwner().roleGameObject.RoleAnimator.GetCurrentAnimatorStateInfo(0);

        if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorState.Run.ToString()))
        {
            CurrFsm.GetOwner().roleGameObject.RoleAnimator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleAnimatorState.Run);
        }
        else
        {
            CurrFsm.GetOwner().roleGameObject.RoleAnimator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
        }

        CurrFsm.GetOwner().GetTrans().LookAt(CurrFsm.GetOwner().TargetPos);

    }

    public override void OnLeave()
    {
        base.OnLeave();
        CurrFsm.GetOwner().roleGameObject.RoleAnimator.SetBool(ToAnimatorCondition.ToRun.ToString(), false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}