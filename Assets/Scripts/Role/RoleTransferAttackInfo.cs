using UnityEngine;
using System.Collections;

/// <summary>
/// ��ɫ���ݵĹ�����Ϣ
/// </summary>
public class RoleTransferAttackInfo
{
    /// <summary>
    /// �����߱��
    /// </summary>
    public int AttackRoleId;

    /// <summary>
    /// �����ߵ�λ��
    /// </summary>
    public Vector3 AttackRolePos;

    /// <summary>
    /// �������߱��
    /// </summary>
    public int BeAttackRoleId;

    /// <summary>
    /// �˺���ֵ
    /// </summary>
    public int HurtValue;

    /// <summary>
    /// ������ʹ�õļ���Id
    /// </summary>
    public int SkillId;

    /// <summary>
    /// ������ʹ�õļ��ܵȼ�
    /// </summary>
    public int SkillLevel;

    /// <summary>
    /// �Ƿ񸽼��쳣״̬
    /// </summary>
    public bool IsAbnormal;

    /// <summary>
    /// �Ƿ񱩻�
    /// </summary>
    public bool IsCri;

    /// <summary>
    /// �öԷ������ӳ�
    /// </summary>
    public float HurtDelayTime;
}
