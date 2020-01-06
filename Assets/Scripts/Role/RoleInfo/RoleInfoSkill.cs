using UnityEngine;
using System.Collections;

/// <summary>
/// ��ɫ������Ϣ
/// </summary>
public class RoleInfoSkill
{
    public int SkillId; //���ܱ��
    public int SkillLevel; //���ܵȼ�
    public byte SlotsNo; //���ܲ۱��

    private float m_SkillCDTime = 0f;
    public float SkillCDTime
    {
        get
        {
            if (m_SkillCDTime == 0)
            {
               // m_SkillCDTime = SkillLevelDBModel.Instance.GetEntityBySkillIdAndLevel(SkillId, SkillLevel).SkillCDTime;
            }
            return m_SkillCDTime;
        }
    }

    private int m_SpendMP;
    public int SpendMP
    {
        get
        {
            if (m_SpendMP == 0)
            {
                //m_SpendMP = SkillLevelDBModel.Instance.GetEntityBySkillIdAndLevel(SkillId, SkillLevel).SpendMP;
            }
            return m_SpendMP;
        }
    }
    public float SkillCDEndTime; //��ȴ����ʱ��
}
