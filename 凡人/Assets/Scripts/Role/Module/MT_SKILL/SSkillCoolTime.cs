using System;
using UnityUtility;


[Serializable]
public class SSkillCoolTime
{
    private int m_iSkillId;

    private int m_iIndex;

    private float m_fLastTime = -1048575f;

    private float m_fSkillCoolTime;

    public SSkillCoolTime(int index, int id, float cooltime)
	{
		this.m_iIndex = index;
		this.m_iSkillId = id;
		this.m_fSkillCoolTime = cooltime;
	}

	public int ID
	{
		get
		{
			return this.m_iSkillId;
		}
	}

	public void Write(CSerializer cs)
	{
		cs.Write(this.m_iSkillId);
		cs.Write(this.m_fLastTime);
		cs.Write(this.m_fSkillCoolTime);
	}

	public void Read(CSerializer cs)
	{
		this.m_iSkillId = cs.ReadInt32();
		this.m_fLastTime = cs.ReadFloat();
		this.m_fSkillCoolTime = cs.ReadFloat();
	}

	public void CopyTo(SSkillCoolTime ssct)
	{
		ssct.m_iSkillId = this.m_iSkillId;
		ssct.m_iIndex = this.m_iIndex;
		ssct.m_fLastTime = this.m_fLastTime;
		ssct.m_fSkillCoolTime = this.m_fSkillCoolTime;
	}

	public bool IsReady()
	{
		return GameTime.time - this.m_fLastTime > this.m_fSkillCoolTime;
	}

	public float GetCoolTimePer()
	{
		float num = GameTime.time - this.m_fLastTime / this.m_fSkillCoolTime;
		if (num > 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float GetCoolTime()
	{
		return this.m_fSkillCoolTime;
	}

	public void ResetCoolDownTime()
	{
		this.m_fLastTime = 0f;
	}

	public bool Used()
	{
		if (this.IsReady())
		{
			this.m_fLastTime = GameTime.time;
			return true;
		}
		return false;
	}
}
