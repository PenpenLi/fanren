using System;
using System.Collections.Generic;
using UnityEngine;


public class ControlStateWalkForward : ControlStateBase
{
    private MoveTarget m_cMove;

    private List<Vector3> m_lstPathPoints = new List<Vector3>();

    private int m_iPointIndex;

    private int m_iPointNum;

    public ControlStateWalkForward(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.WALK_FORWARD)
	{
		this.m_cMove = new MoveTarget(role, control);
		this.m_cMove.SetTurnSpeed(800f);
	}

	public override bool Update()
	{
        //if (this.m_cRole.IsDead())
        //{
        //	return false;
        //}
        //if (!base.Update())
        //{
        //    return false;
        //}
        this.SetSpeed();
        if (!this.m_cMove.Update())
		{
			if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
			{
				return false;
			}
			if (this.m_iPointIndex >= this.m_iPointNum - 1)
			{
				return false;
			}
			this.m_cMove.Enable = true;
			this.m_cMove.SetTargetPos(this.m_lstPathPoints[++this.m_iPointIndex]);
		}
		base.CheckToFallingState();
		return true;
	}

    public override bool OnEnter(ControlEventBase ceb)
    {
        //ModBuffProperty modBuffProperty = (ModBuffProperty)this.m_cRole.GetModule(MODULE_TYPE.MT_BUFF);
        //if (this.m_cRole._roleType != ROLE_TYPE.RT_NPC && modBuffProperty.GetValue(BUFF_VALUE_TYPE.BIND) != 0)
        //{
        //    return false;
        //}
        base.OnEnter(ceb);
        Vector3 vector = Vector3.zero;
        ACTION_INDEX ai = ACTION_INDEX.AN_IDLE;
        bool b = true;
        float num = 7f;//this.modAtt.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MOVESPEED);
        Vector3[] array = null;
        CONTROL_INPUT inputId = ceb.InputId;
        if (inputId == CONTROL_INPUT.WALK_FORWARD)
        {
            vector = ((ControlEventMoveForward)ceb).TargetPos;
            ai = ((ControlEventMoveForward)ceb).ActIdx;
            num = ((ControlEventMoveForward)ceb).Speed;
            b = ((ControlEventMoveForward)ceb).Rotate;
            array = ((ControlEventMoveForward)ceb).Path;
        }
        this.m_cMove.Reset(ai, num);
        //this.modAtt.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED, num, true);
        //if (this.m_cRole._roleType != ROLE_TYPE.RT_PLAYER)
        //{
        //    if (array != null)
        //    {
        //        if (this.m_lstPathPoints == null)
        //        {
        //            this.m_lstPathPoints = new List<Vector3>();
        //        }
        //        this.m_lstPathPoints.Clear();
        //        foreach (Vector3 item in array)
        //        {
        //            this.m_lstPathPoints.Add(item);
        //        }
        //        this.m_iPointIndex = 0;
        //        this.m_iPointNum = this.m_lstPathPoints.Count;
        //        if (this.m_iPointNum > 0)
        //        {
        //            this.m_cMove.SetTargetPos(this.m_lstPathPoints[0]);
        //        }
        //        else
        //        {
        //            this.m_cMove.Stop();
        //        }
        //    }
        //    else if (!Singleton<DrillSystem>.GetInstance().IsDrillState)
        //    {
        //        this.Setm_lstPathPoints(vector);
        //    }
        //    else
        //    {
                this.m_cMove.SetTargetPos(vector);
        //    }
        //    this.m_cMove.RotateWhenMove = true;
        //}
        //else
        //{
        this.m_cMove.SetTargetPos(vector);
        this.m_cMove.RotateWhenMove = false;
        this.m_cMove.EnableSoundEffect = true;
        this.m_cMove.EnableDirtEffect = true;
        //this.m_cMove.SetTurnSpeed(1300f);
        //}
        //this.m_cMove.SwitchRotate(b);
        this.m_cMove.SwitchGravity(true);
        return true;
    }

    private void SetSpeed()
    {
        //float attributeValue = this.modAtt.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MOVESPEED);
        //this.m_cMove.Speed = attributeValue;
        //float attributeValue2 = this.modAtt.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MOVESPEED_ORIGN);
        //if (attributeValue2 == 0f)
        //{
        //    this.m_cAnimation.AniSpeed = 1f;
        //    return;
        //}
        //float aniSpeed = attributeValue / attributeValue2;
        //this.m_cAnimation.AniSpeed = aniSpeed;
    }

    public override void OnExit()
    {
        base.OnExit();
        this.m_cControlMfs.ChangeStateToIdle();
    }

    //private void Setm_lstPathPoints(Vector3 targetPoint)
    //{
    //	this.m_lstPathPoints = Pathfinding.GetPath(this.m_cRole.GetTrans().position, targetPoint, 1.5f);
    //	this.m_iPointIndex = 0;
    //	this.m_iPointNum = this.m_lstPathPoints.Count;
    //	if (this.m_iPointNum > 0)
    //	{
    //		this.m_cMove.SetTargetPos(this.m_lstPathPoints[0]);
    //	}
    //	else
    //	{
    //		this.m_cMove.Stop();
    //	}
    //}

    public override bool Destory()
	{
		base.Destory();
		this.m_cAnimation.AniSpeed = 1f;
		return true;
	}
}
