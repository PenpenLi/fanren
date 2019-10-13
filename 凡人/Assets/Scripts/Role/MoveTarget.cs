using System;
using System.Collections.Generic;
using UnityEngine;


public class MoveTarget : MoveBase
{
    //private Rotate rotate;

    private bool rotateWhenMove;

    private bool enableSoundEffect;

    //private ModAttribute modAtt;

    //private ModVoice modVoice;

    private List<bool> isCreated = new List<bool>();

    private float[] walkSoundTime;

    public MoveTarget(Role role, CharacterController cc) : base(role, cc)
	{
		//this.rotate = new Rotate(role.GetTrans(), 800f, Vector3.zero);
		//this.modAtt = (ModAttribute)role.GetModule(MODULE_TYPE.MT_ATTRIBUTE);
		//this.modVoice = (ModVoice)role.GetModule(MODULE_TYPE.MT_VOICE);
	}

	public bool EnableDirtEffect { get; set; }

    public override bool Update()
    {
        //if (!base.Update())
        //{
        //    return false;
        //}
        //if (this.m_cTarget == null && this.m_vecTarget == Vector3.zero)
        //{
        //    return false;
        //}
        Vector3 a = Vector3.zero;
        if (this.m_vecTarget != Vector3.zero)
        {
            a = this.m_vecTarget;
        }
        if (this.m_cTarget != null)
        {
            a = this.m_cTarget.position;
        }
        Vector3 vector = a - this.m_cRole.GetTrans().position;
        vector.y = 0f;
        //if (vector.magnitude <= this.m_fSpeed * GameTime.deltaTime)
        //{
        Debug.Log(vector);
            this.m_cRole.roleGameObject.RoleController.Move(vector);
        //    this.Stop();
        //    return false;
        //}
        //vector = vector.normalized;
        //bool flag = this.rotateWhenMove;
        //if (this.m_bRotate)
        //{
        //    this.rotate.LookDirection = vector;
        //    if (!this.rotate.Update())
        //    {
        //        this.rotate.Reset();
        //        flag = true;
        //    }
        //}
        //else
        //{
        //    Vector3 worldPosition = new Vector3(a.x, this.m_cRole.GetPos().y, a.z);
        //    this.m_cRole.GetTrans().LookAt(worldPosition);
        //    flag = true;
        //}
        //if (flag)
        //{
        //    Vector3 motion = this.m_cRole.GetTrans().forward * this.m_fSpeed * GameTime.deltaTime;
        //    this.m_cController.Move(motion);
        //}
        //if ((this.enableSoundEffect || this.EnableDirtEffect) && this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER && this.walkSoundTime != null && this.walkSoundTime.Length > 0)
        //{
        //    if (this.isCreated.Count != this.walkSoundTime.Length || this.m_cAnimation.GetAniProgress() == 0f)
        //    {
        //        this.isCreated.Clear();
        //        for (int i = 0; i < this.walkSoundTime.Length; i++)
        //        {
        //            this.isCreated.Add(false);
        //        }
        //    }
        //    int num = 0;
        //    int num2 = 0;
        //    Vector3 vector2 = Vector3.zero;
        //    for (int j = 0; j < this.walkSoundTime.Length; j++)
        //    {
        //        if (this.m_cAnimation.GetAniProgress() >= this.walkSoundTime[j] && !this.isCreated[j])
        //        {
        //            RaycastHit raycastHit;
        //            if (Physics.Raycast(this.m_cRole.GetTrans().position + new Vector3(0f, this.m_cRole.roleGameObject.RoleController.height - 0.1f, 0f), -Vector3.up, out raycastHit, this.m_cRole.roleGameObject.RoleController.height, 8195))
        //            {
        //                num = Singleton<PlayerWalkSoundData>.GetInstance().GetSoundID(raycastHit.collider.gameObject.tag);
        //                num2 = Singleton<PlayerWalkSoundData>.GetInstance().GetEffectID(raycastHit.collider.gameObject.tag);
        //                vector2 = raycastHit.point + new Vector3(0f, 0.05f, 0f);
        //            }
        //            if (this.EnableDirtEffect && num2 > 0)
        //            {
        //                SingletonMono<EffectManager>.GetInstance().AddEffect(num2, vector2, vector2, vector2, this.m_cRole.GetTrans().rotation, null, false);
        //            }
        //            if (this.enableSoundEffect && num > 0)
        //            {
        //                this.modVoice.PlayOneShotSound(num);
        //            }
        //            this.isCreated[j] = true;
        //        }
        //    }
        //}
        return true;
    }

        //public override void Reset(ACTION_INDEX ai, float speed)
        //{
        //	base.Reset(ai, speed);
        //	this.rotate.Reset();
        //	if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
        //	{
        //		this.walkSoundTime = Singleton<PlayerWalkSoundData>.GetInstance().GetSoundtime((int)ai, (int)this.m_cRole.GetWeaponIdx());
        //		if (this.walkSoundTime != null)
        //		{
        //			if (this.m_cAnimation.GetAniProgress() == 0f)
        //			{
        //				this.isCreated.Clear();
        //				for (int i = 0; i < this.walkSoundTime.Length; i++)
        //				{
        //					this.isCreated.Add(false);
        //				}
        //			}
        //		}
        //		else
        //		{
        //			Debug.LogWarning(DU.Warning(new object[]
        //			{
        //				"NUll",
        //				this.walkSoundTime
        //			}));
        //		}
        //	}
        //}

    public override void Stop()
	{
		base.Stop();
	}

	public bool RotateWhenMove
	{
		get
		{
			return this.rotateWhenMove;
		}
		set
		{
			this.rotateWhenMove = value;
		}
	}

	public bool EnableSoundEffect
	{
		get
		{
			return this.enableSoundEffect;
		}
		set
		{
			this.enableSoundEffect = value;
		}
	}

	//public void SetTurnSpeed(float speed)
	//{
	//	if (this.rotate != null)
	//	{
	//		this.rotate.RotateSpeed = speed;
	//	}
	//}
}
