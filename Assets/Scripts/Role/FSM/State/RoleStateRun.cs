using UnityEngine;
using System.Collections;

/// <summary>
/// 跑状态
/// </summary>
public class RoleStateRun : RoleStateBase
{
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
        m_RotationSpeed = 0;

        CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToRun.ToString(), true);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        CurrRoleAnimatorStateInfo = CurrFsm.m_Owner.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
        if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorState.Run.ToString()))
        {
            CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleAnimatorState.Run);
        }
        else
        {
            CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
        }

        //如果没有路 切换待机
        if (CurrFsm.m_Owner.CurrRoleCtrl.AStartPath == null)
        {
            CurrFsm.m_Owner.ChangeState(RoleState.Idle);
            return;
        }

        //如果整个路径走完了 切换待机
        if (CurrFsm.m_Owner.CurrRoleCtrl.AStartCurrWayPointIndex >= CurrFsm.m_Owner.CurrRoleCtrl.AStartPath.vectorPath.Count)
        {
            CurrFsm.m_Owner.ChangeState(RoleState.Idle);
            return;
        }

        //方向
        Vector3 direction = Vector3.zero;

        //临时目标路径点
        Vector3 temp = new Vector3(CurrFsm.m_Owner.CurrRoleCtrl.AStartPath.vectorPath[CurrFsm.m_Owner.CurrRoleCtrl.AStartCurrWayPointIndex].x,
            CurrFsm.m_Owner.CurrRoleCtrl.gameObject.transform.position.y,
            CurrFsm.m_Owner.CurrRoleCtrl.AStartPath.vectorPath[CurrFsm.m_Owner.CurrRoleCtrl.AStartCurrWayPointIndex].z
            );

        //计算方向
        direction = temp - CurrFsm.m_Owner.CurrRoleCtrl.gameObject.transform.position;

        direction = direction.normalized; //归一化

        m_MoveSpeed = CurrFsm.m_Owner.CurrRoleCtrl.Speed > 0 ? CurrFsm.m_Owner.CurrRoleCtrl.Speed : CurrFsm.m_Owner.CurrRoleCtrl.Speed;

        direction = direction * Time.deltaTime * m_MoveSpeed;
        direction.y = 0;

        //让角色缓慢转身
        if (m_RotationSpeed <= 1)
        {
            m_RotationSpeed += 10f * Time.deltaTime;
            m_TargetQuaternion = Quaternion.LookRotation(direction);
            CurrFsm.m_Owner.CurrRoleCtrl.transform.rotation = Quaternion.Lerp(CurrFsm.m_Owner.CurrRoleCtrl.transform.rotation, m_TargetQuaternion, m_RotationSpeed);

            if (Quaternion.Angle(CurrFsm.m_Owner.CurrRoleCtrl.transform.rotation, m_TargetQuaternion) < 1)
            {
                m_RotationSpeed = 0;
            }
        }

        //判断是否应该向下一个点移动
        float dis = Vector3.Distance(CurrFsm.m_Owner.CurrRoleCtrl.transform.position, temp);

        //当到达临时目标点了
        if (dis <= direction.magnitude + 0.1f)
        {
            CurrFsm.m_Owner.CurrRoleCtrl.AStartCurrWayPointIndex++;
        }

        CurrFsm.m_Owner.CurrRoleCtrl.CharacterController.Move(direction);
    }

    public override void OnLeave()
    {
        base.OnLeave();
        CurrFsm.m_Owner.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToRun.ToString(), false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}