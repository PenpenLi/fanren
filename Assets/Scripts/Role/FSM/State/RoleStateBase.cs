using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

/// <summary>
/// ��ɫ״̬������
/// </summary>
public class RoleStateBase : FsmState<RoleFSMMgr>
{
    /// <summary>
    /// ��ǰ����״̬��Ϣ
    /// </summary>
    public AnimatorStateInfo CurrRoleAnimatorStateInfo { get; set; }

    /// <summary>
    /// �Ƿ��л�����״̬���
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
