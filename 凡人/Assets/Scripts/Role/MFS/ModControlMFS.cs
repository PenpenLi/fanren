using System;
using System.Collections.Generic;
using UnityEngine;

public class ModControlMFS : Module
{
    private ModControlMFS.WrapState m_cWrapState;

    private ControlStateBase m_cCurrentState;

    public ModControlMFS(GameObject go, Role role)
	{
		this._role = role;
		base.ModType = MODULE_TYPE.MT_CONTROL_MFS;
	}

    public ControlStateBase CurrentState
    {
        get
        {
            return this.m_cCurrentState;
        }
    }

    public override bool Init()
    {
        base.Init();
        CharacterController roleController = this._role.roleGameObject.RoleController;
        this.m_cWrapState = new ModControlMFS.WrapState(this._role, roleController, this);
        return true;
    }

    public override void Process()
    {
        if (this.m_cCurrentState != null && !this.m_cCurrentState.Update())
        {
            this.m_cCurrentState.OnExit();
        }
    }

    public void ChangeStateToIdle()
    {
        if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
        {
            //if (((Player)this._role).weaponManager.weaponeActive)
            //{
            //    ControlEventRestoreAttackIdle tmpEvent = new ControlEventRestoreAttackIdle(false);
            //    this.ChangeState(tmpEvent);
            //}
            //else
            //{
                ControlEventRestoreIdle tmpEvent2 = new ControlEventRestoreIdle(false);
                this.ChangeState(tmpEvent2);
           // }
        }
        else
        {
            //ControlEventRestoreIdle tmpEvent3 = new ControlEventRestoreIdle(false);
            //this.ChangeState(tmpEvent3);
        }
    }

    //public void ChangeStateToAttackIdle()
    //{
    //	ControlEventAttackIdle tmpEvent = new ControlEventAttackIdle(false);
    //	this.ChangeState(tmpEvent);
    //}

    public CONTROL_STATE GetCurrentStateId()
    {
        if (this.m_cCurrentState == null)
        {
            return CONTROL_STATE.NONE;
        }
        return this.m_cCurrentState.GetState();
    }

    public bool ChangeState(ControlEventBase tmpEvent)
    {
        if (tmpEvent.Forced)//强制的
        {
            ControlStateBase stateByInput = this.m_cWrapState.GetStateByInput(tmpEvent.InputId);
            if (this.m_cCurrentState != null)
            {
                this.m_cCurrentState.Destory();
                this.m_cCurrentState.ExitProcess();
            }
            this.m_cCurrentState = stateByInput;
            this.m_cCurrentState.OnEnter(tmpEvent);
            return true;
        }

        if (this.m_cCurrentState != null)
        {
            if (this.m_cCurrentState.IsLocked)
            {
                Debug.Log("m_cCurrentState.IsLocked");
                return false;
            }
            if (!this.m_cCurrentState.IsFree && !this.m_cCurrentState.BreakEvent.Contains(tmpEvent.InputId) && !this.m_cWrapState.IsEventForbid(tmpEvent.InputId, this.m_cCurrentState.GetState()))
            {
                return false;
            }
        }

        ControlStateBase stateByInput2 = this.m_cWrapState.GetStateByInput(tmpEvent.InputId);
        if (!stateByInput2.IsEffectTive(tmpEvent))
        {
            return false;
        }
        ControlStateBase cCurrentState = this.m_cCurrentState;
        if (cCurrentState != null)
        {
            if (!cCurrentState.Destory())
            {
                this.m_cCurrentState = cCurrentState;
                return false;
            }
            cCurrentState.ExitProcess();
        }

        if (!stateByInput2.OnEnter(tmpEvent))
        {
            return false;
        }
        stateByInput2.EnterProcess();
        this.m_cCurrentState = stateByInput2;
        //if (this.m_cCurrentState != null && this._role._roleType == ROLE_TYPE.RT_PLAYER)//&& CameraBoxsSelect.Instance != null
        //{
        //    if (this.m_cCurrentState.GetState() == CONTROL_STATE.ATTACK)
        //    {
        //        //CameraBoxsSelect.Instance._NowState = CameraBoxsSelect.ChangeState.CS_FIGHT;
        //    }
        //    else
        //    {
        //        //CameraBoxsSelect.Instance._NowState = CameraBoxsSelect.ChangeState.CS_NORMAL;
        //    }
        //}
        return true;
    }

    private class WrapState
    {
        private Dictionary<CONTROL_STATE, ControlStateBase> m_mapOutputStates = new Dictionary<CONTROL_STATE, ControlStateBase>();

        private Dictionary<CONTROL_INPUT, ControlStateBase> m_mapInpuStates = new Dictionary<CONTROL_INPUT, ControlStateBase>();

        private MFSTable m_mapEventTable;

        public WrapState(Role role, CharacterController control, ModControlMFS mcm)
        {
            this.m_mapOutputStates.Clear();
            this.m_mapOutputStates.Add(CONTROL_STATE.IDLE, new ControlStateIdle(role, control, mcm));
            this.m_mapOutputStates.Add(CONTROL_STATE.JUMP, new ControlStateJump(role, control, mcm));
            this.m_mapOutputStates.Add(CONTROL_STATE.BUFF, new ControlStateBuff(role, control, mcm));
            this.m_mapOutputStates.Add(CONTROL_STATE.HURT, new ControlStateHurt(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.FALLING, new ControlStateFalling(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.ATTACK, new ControlStateAttack(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.BACK_WEAPON, new ControlStateBackWeapon(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.DIE, new ControlStateDie(role, control, mcm));
            this.m_mapOutputStates.Add(CONTROL_STATE.WALK_FORWARD, new ControlStateWalkForward(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.SKILL, new ControlStateSkill(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.ATTACK_IDLE, new ControlStateAttackIdle(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.SHOWTIME, new ControlStateShowTime(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.HORIZONTAL, new ControlStateWalkHorizontal(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.FALL_BACK, new ControlStateWalkFallBack(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.FLEE, new ControlStateFlee(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.ROTATE, new ControlStateRotate(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.MOVIE, new ControlStateMovie(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.CASUAL, new ControlStateCasual(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.ROLL, new ControlStateRoll(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.SPAWN, new ControlStateSpawn(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.FEATURE, new ControlStateFeature(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.WEAKNESS, new ControlStateWeakness(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.QTE, new ControlStateQTE(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.BE_CONTROLL, new ControlStateBeControl(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.SWIM, new ControlStateSwim(role, control, mcm));
            this.m_mapOutputStates.Add(CONTROL_STATE.FLY, new ControlStateFly(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.PUSH, new ControlStatePush(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.WALK_SURROUND, new ControlStateWalkSurround(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.GATHER_STRENGTH, new ControlStateGatherStrength(role, control, mcm));
            //this.m_mapOutputStates.Add(CONTROL_STATE.BOSS_SHOW, new ControlStateBossShow(role, control, mcm));
            this.m_mapInpuStates.Clear();
            this.m_mapInpuStates.Add(CONTROL_INPUT.IDLE, this.m_mapOutputStates[CONTROL_STATE.IDLE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.RESTORE_IDLE, this.m_mapOutputStates[CONTROL_STATE.IDLE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.RESTORE_ATTACK_IDLE, this.m_mapOutputStates[CONTROL_STATE.ATTACK_IDLE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.JUMP, this.m_mapOutputStates[CONTROL_STATE.JUMP]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.BUFF, this.m_mapOutputStates[CONTROL_STATE.BUFF]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.HURT, this.m_mapOutputStates[CONTROL_STATE.HURT]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.FALLING, this.m_mapOutputStates[CONTROL_STATE.FALLING]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.ATTACK, this.m_mapOutputStates[CONTROL_STATE.ATTACK]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.BACK_WEAPON, this.m_mapOutputStates[CONTROL_STATE.BACK_WEAPON]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.DIE, this.m_mapOutputStates[CONTROL_STATE.DIE]);
            this.m_mapInpuStates.Add(CONTROL_INPUT.WALK_FORWARD, this.m_mapOutputStates[CONTROL_STATE.WALK_FORWARD]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.SKILL, this.m_mapOutputStates[CONTROL_STATE.SKILL]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.ATTACK_IDLE, this.m_mapOutputStates[CONTROL_STATE.ATTACK_IDLE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.SHOWTIME, this.m_mapOutputStates[CONTROL_STATE.SHOWTIME]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.HORIZONTAL, this.m_mapOutputStates[CONTROL_STATE.HORIZONTAL]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.FALL_BACK, this.m_mapOutputStates[CONTROL_STATE.FALL_BACK]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.FLEE, this.m_mapOutputStates[CONTROL_STATE.FLEE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.ROTATE, this.m_mapOutputStates[CONTROL_STATE.ROTATE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.MOVIE, this.m_mapOutputStates[CONTROL_STATE.MOVIE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.CASUAL, this.m_mapOutputStates[CONTROL_STATE.CASUAL]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.ROLL, this.m_mapOutputStates[CONTROL_STATE.ROLL]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.SPAWN, this.m_mapOutputStates[CONTROL_STATE.SPAWN]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.FEATURE, this.m_mapOutputStates[CONTROL_STATE.FEATURE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.WEAKNESS, this.m_mapOutputStates[CONTROL_STATE.WEAKNESS]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.QTE, this.m_mapOutputStates[CONTROL_STATE.QTE]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.BE_CONTROLL, this.m_mapOutputStates[CONTROL_STATE.BE_CONTROLL]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.SWIM, this.m_mapOutputStates[CONTROL_STATE.SWIM]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.FLY, this.m_mapOutputStates[CONTROL_STATE.FLY]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.PUSH, this.m_mapOutputStates[CONTROL_STATE.PUSH]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.WALK_SURROUND, this.m_mapOutputStates[CONTROL_STATE.WALK_SURROUND]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.GATHER_STRENGTH, this.m_mapOutputStates[CONTROL_STATE.GATHER_STRENGTH]);
            //this.m_mapInpuStates.Add(CONTROL_INPUT.BOSS_SHOW, this.m_mapOutputStates[CONTROL_STATE.BOSS_SHOW]);
            this.m_mapEventTable = Singleton<MFSTableManager>.GetInstance().GetTableByType(mcm._role.MFSType);
        }

        public ControlStateBase GetStateByInput(CONTROL_INPUT ci)
        {
            if (this.m_mapInpuStates.ContainsKey(ci))
            {
                return this.m_mapInpuStates[ci];
            }
            return null;
        }

        public ControlStateBase GetStateByOutput(CONTROL_STATE cs)
        {
            if (this.m_mapOutputStates.ContainsKey(cs))
            {
                return this.m_mapOutputStates[cs];
            }
            return null;
        }

        /// <summary>
        /// 事件禁止
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="cs"></param>
        /// <returns></returns>
        public bool IsEventForbid(CONTROL_INPUT ci, CONTROL_STATE cs)
        {
            return this.m_mapEventTable.GetTableData(ci, cs);
        }
    }
}
