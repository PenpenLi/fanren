using System;
using System.Collections.Generic;
using UnityEngine;


public class ControlStateFly : ControlStateBase
{
    //private MoveFree m_cMove;

    //private MoveUpDown m_cMoveUp;

    private MoveBase m_cCurrentMove;

    private List<Vector3> m_lstPathPoints;

    private int m_iPointIndex;

    private int m_iPointNum;

    public ControlStateFly(Role role, CharacterController control, ModControlMFS mcm) : base(role, control, mcm, CONTROL_STATE.FLY)
    {
        //this.m_cMove = new MoveFree(role, control);
        //this.m_cMoveUp = new MoveUpDown(role, control);
        //this.m_cCurrentMove = this.m_cMove;
    }

    //// Token: 0x06001F9F RID: 8095 RVA: 0x000D7C0C File Offset: 0x000D5E0C
    //public override bool Update()
    //{
    //	if (!base.Update())
    //	{
    //		return false;
    //	}
    //	if (!this.m_cCurrentMove.Update())
    //	{
    //		if (this.m_cRole._roleType != ROLE_TYPE.RT_PLAYER)
    //		{
    //			if (this.m_iPointIndex < this.m_iPointNum - 1)
    //			{
    //				this.m_cMove.SetTargetPos(this.m_lstPathPoints[++this.m_iPointIndex]);
    //			}
    //			else
    //			{
    //				this.Stay();
    //			}
    //		}
    //		else
    //		{
    //			this.Stay();
    //		}
    //	}
    //	else if (this.m_cControl.isGrounded)
    //	{
    //		return false;
    //	}
    //	return true;
    //}

    //// Token: 0x06001FA0 RID: 8096 RVA: 0x000D7CB0 File Offset: 0x000D5EB0
    //public override bool OnEnter(ControlEventBase ceb)
    //{
    //	base.OnEnter(ceb);
    //	Vector3 vector = Vector3.zero;
    //	ACTION_INDEX ai = ACTION_INDEX.AN_IDLE;
    //	bool b = true;
    //	float speed = 3f;
    //	bool flag = false;
    //	CONTROL_INPUT inputId = ceb.InputId;
    //	if (inputId == CONTROL_INPUT.FLY)
    //	{
    //		vector = ((ControlEventFly)ceb).TargetPos;
    //		ai = ((ControlEventFly)ceb).ActIdx;
    //		speed = ((ControlEventFly)ceb).Speed;
    //		b = ((ControlEventFly)ceb).Rotate;
    //		flag = ((ControlEventFly)ceb).Rise;
    //	}
    //	if (flag)
    //	{
    //		this.m_cCurrentMove = this.m_cMoveUp;
    //	}
    //	else
    //	{
    //		this.m_cCurrentMove = this.m_cMove;
    //	}
    //	this.m_cCurrentMove.Reset(ai, speed);
    //	if (this.m_cRole._roleType != ROLE_TYPE.RT_PLAYER)
    //	{
    //		this.Setm_lstPathPoints(vector);
    //	}
    //	else
    //	{
    //		this.m_cCurrentMove.SetTargetPos(vector);
    //	}
    //	this.m_cCurrentMove.SwitchRotate(b);
    //	this.m_cCurrentMove.SwitchGravity(false);
    //	return true;
    //}

    //// Token: 0x06001FA1 RID: 8097 RVA: 0x000D7DAC File Offset: 0x000D5FAC
    //public override void OnExit()
    //{
    //	base.OnExit();
    //	this.m_cControlMfs.ChangeStateToIdle();
    //}

    //// Token: 0x06001FA2 RID: 8098 RVA: 0x000D7DC0 File Offset: 0x000D5FC0
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

    //// Token: 0x06001FA3 RID: 8099 RVA: 0x000D7E3C File Offset: 0x000D603C
    //private void Stay()
    //{
    //	if (!this.m_cAnimation.IsPlaying(ACTION_INDEX.AN_WALK))
    //	{
    //		this.m_cAnimation.PlayAnimation(ACTION_INDEX.AN_WALK, WrapMode.Loop);
    //	}
    //	Transform trans = this.m_cRole.GetTrans();
    //	Quaternion to = Quaternion.Euler(new Vector3(0f, trans.eulerAngles.y, 0f));
    //	if (GameTime.deltaTime == 0f)
    //	{
    //		return;
    //	}
    //	trans.rotation = Quaternion.RotateTowards(trans.rotation, to, GameTime.deltaTime * this.m_cRole.GetTurnSpeed());
    //}

    private void ChangeCameraArange(float top, float blow)
	{
		ModCamera modCamera = this.m_cRole.GetModule(MODULE_TYPE.MT_CAMERA) as ModCamera;
	}
}
