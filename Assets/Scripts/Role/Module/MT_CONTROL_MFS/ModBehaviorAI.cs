using System;
using System.Collections.Generic;
//using BevAI;
using UnityEngine;


public class ModBehaviorAI : Module
{
    private float lastTargetTime;

    private ModControlMFS mfs;

    //private BevNodeInputParam inputParam = new BevNodeInputParam();

    //public BevNodeType type;

    public bool _bAttact;

    public bool bPause;

    //public RoleStatusFlag rlSttsFlg = new RoleStatusFlag();

    //public List<BevNodeType> typeList = new List<BevNodeType>();

    public Role _enmityTarget;

    public Role _allyTarget;

   // public BevNode rootSel;


    public ModBehaviorAI(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_AI_BEHAVIOR;
	}

	public float Dis
	{
		get
		{
			if (this._role._roleType == ROLE_TYPE.RT_MONSTER)
			{
				//if (this._enmityTarget != null && this._enmityTarget.isAlive())
				//{
				//	return Vector3.Distance(this._enmityTarget.GetPos(), this._role.GetPos());
				//}
				return 0f;
			}
			else
			{
				//Player player = (Player)FanrenSceneManager.RoleMan.GetRole(Player.currentPlayerId);
				//if (player != null)
				//{
				//	return Vector3.Distance(player.GetPos(), this._role.GetPos());
				//}
				return 0f;
			}
		}
		set
		{
		}
	}

	public override bool Init()
	{
		if (this._role != null)
		{
			//if (this._role._roleType == ROLE_TYPE.RT_MONSTER && this._role.Identity() != IdentityType.Bar)
			//{
			//	this.mfs = (this._role.GetModule(MODULE_TYPE.MT_CONTROL_MFS) as ModControlMFS);
			//}
			//if (this._role._roleType == ROLE_TYPE.RT_NPC)
			//{
			//	this.mfs = (this._role.GetModule(MODULE_TYPE.MT_CONTROL_MFS) as ModControlMFS);
			//}
			//this.inputParam.role = this._role;
			//this.rlSttsFlg.SetFlag(RoleStatusFlag.Status.Stay);
			//this.inputParam.rlSttsFlg = this.rlSttsFlg;
			this.CreateTree();
		}
		return base.Init();
	}

	// Token: 0x0600212E RID: 8494 RVA: 0x000E3B54 File Offset: 0x000E1D54
	public void CreateTree()
	{
		//BevTreeInfo bevTreeInfo = BevTreeInfo.Copy(BevTreeData.GetBevTree(this._role.GetStaticRoleInfo().GetBevTreeID()));
		//for (int i = 0; i < bevTreeInfo.nodeList.Count; i++)
		//{
		//	BevTreeData.FindParent(bevTreeInfo.nodeList[i], bevTreeInfo);
		//	if (i == 0)
		//	{
		//		this.rootSel = bevTreeInfo.nodeList[i].Node;
		//		this.type = bevTreeInfo.nodeList[i].NodeType;
		//	}
		//}
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x000E3BE0 File Offset: 0x000E1DE0
	public override void Process()
	{
		if (!base.Enable)
		{
			return;
		}
		//if (MovieManager.MovieMag.IsPlaying() && this._role._roleType == ROLE_TYPE.RT_MONSTER && this._role.isAlive())
		//{
		//	return;
		//}
		if (GameTime.time == 0f)
		{
			return;
		}
		if (this.lastTargetTime > 0f)
		{
			this.lastTargetTime -= GameTime.deltaTime;
		}
		if (this._role._roleType == ROLE_TYPE.RT_MONSTER)
		{
			//if (this.bPause && this._role.isAlive())
			//{
			//	return;
			//}
			//if (this._role.Identity() != IdentityType.Bar && this.mfs.GetCurrentStateId() == CONTROL_STATE.QTE)
			//{
			//	return;
			//}
			//SceneManager.RoleMan.CheckRoleInView(this._role);
		}
		if (this.lastTargetTime <= 0f)
		{
			Role role;
			//if (!this._role.HaveBuff(163))
			//{
			//	role = SceneManager.RoleMan.GetPriorAttackRole(this._role);
			//}
			//else
			//{
			//	role = SceneManager.RoleMan.GetNearestEnmity(this._role);
			//}
			//if (role == null)
			//{
			//	role = SceneManager.RoleMan.GetAllyInViewTarget(this._role);
			//}
			//if (role == null || !role.isAlive())
			//{
			//	this._enmityTarget = null;
			//}
			//else if (this.Dis < this._role.GetViewRange())
			//{
			//	this._enmityTarget = role;
			//}
			//else
			//{
			//	this._enmityTarget = null;
			//}
			this.lastTargetTime = 1f;
		}
		if (this._role._roleType == ROLE_TYPE.RT_NPC)
		{
			//if (this.Dis < this._role.GetPrepareDis())
			//{
			//	if (this.mfs == null)
			//	{
			//		return;
			//	}
			//	if (this._enmityTarget != null)
			//	{
			//		this.inputParam.targetRole = this._enmityTarget;
			//	}
			//	this.inputParam.dis = this.Dis;
			//	this.rootSel.Evaluate(this.inputParam);
			//}
			//else
			//{
			//	this.rootSel.Evaluate(this.inputParam);
			//}
		}
		if (this._role._roleType != ROLE_TYPE.RT_MONSTER)
		{
			return;
		}
		//this.inputParam.targetRole = this._enmityTarget;
		//this.inputParam.dis = this.Dis;
		//this.rootSel.Evaluate(this.inputParam);
		//if (this.inputParam.type == BevNodeType.Attact || this.inputParam.type == BevNodeType.AttactSkill || this.inputParam.type == BevNodeType.MoveForward)
		//{
		//	this._bAttact = true;
		//	return;
		//}
		this._bAttact = false;
	}
}
