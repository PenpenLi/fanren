using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

/// <summary>
/// ��ɫ����״̬
/// </summary>
public enum RoleAnimatorState
{
    Idle_Normal = 1,
    Idle_Fight = 2,
    Run = 3,
    Hurt = 4,
    Die = 5,
    Select = 6,
    XiuXian = 7,
    Died = 8,
    PhyAttack1 = 11,
    PhyAttack2 = 12,
    PhyAttack3 = 13,
    Skill1 = 14,
    Skill2 = 15,
    Skill3 = 16,
    Skill4 = 17,
    Skill5 = 18,
    Skill6 = 19,
}

public enum ToAnimatorCondition
{
    ToIdleNormal,
    ToIdleFight,
    ToRun,
    ToHurt,
    ToDie,
    ToDied,
    ToPhyAttack,
    ToSkill,
    ToSelect,
    ToXiuXian,
    CurrState
}

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
