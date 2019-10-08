﻿using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;


public class Role
{
    //    //public const int nMaxID = 100000;

    //    //public ROLE_TYPE _roleType;

    //    //public RoleHatred hatred = new RoleHatred();

    //    //// Token: 0x04001FCF RID: 8143
    //    //protected List<Module> _modList = new List<Module>();

    //    //// Token: 0x04001FD0 RID: 8144
    //    //public List<Role> rolePartsList = new List<Role>();

    //    //// Token: 0x04001FD1 RID: 8145
    //    //public List<BindRoleInfo> BindRoleList = new List<BindRoleInfo>();


     private int _roleId;

    //    //// Token: 0x04001FD3 RID: 8147
    //    //private string _roleName;

    //    //// Token: 0x04001FD4 RID: 8148
    //    //private GameObjSpawn.SpawnInfo _spawnInfo;

    //    //// Token: 0x04001FD5 RID: 8149
    //    //private bool _bRagdoll;

    //    //// Token: 0x04001FD6 RID: 8150
    //    //private RoleChildren _roleChildren = new RoleChildren();

    //    //// Token: 0x04001FD7 RID: 8151
    //    //public ModControlMFS modMFS;

    //    //// Token: 0x04001FD8 RID: 8152
    //    //public ModBehaviorAI modAi;

    //    //// Token: 0x04001FD9 RID: 8153
    //    //private bool _bAniMove;

    //    //// Token: 0x04001FDA RID: 8154
    //    //private int bevTreeID;

    //    //// Token: 0x04001FDB RID: 8155
    //    //private MFS_TALBE_TYPE m_eMFSType;

    //    //// Token: 0x04001FDC RID: 8156
    //    //private MonsterHp _monsterHp;

    //    //// Token: 0x04001FDD RID: 8157
    //    //private MonsterHp _monsterHpBottom;

    //    //// Token: 0x04001FDE RID: 8158
    //    //private bool invincible;

    //    //// Token: 0x04001FDF RID: 8159
    //    //private bool isDestroyed;

    //    //// Token: 0x04001FE0 RID: 8160
    //    //private static Transform zeroTrans;

 
    protected RoleGameObject _roleGameObj = new RoleGameObject();

    //    //// Token: 0x04001FE2 RID: 8162
    //    //private float runSpeed = 7f;

    //    //// Token: 0x04001FE3 RID: 8163
    //    //public List<Role> RetinueList = new List<Role>();

    //    //// Token: 0x04001FE4 RID: 8164
    //    //public Role ParentRole;

    //    //public event RoleDeadEventHandler beforeDead;

    //	public static Transform ZeroTrans
    //	{
    //		get
    //		{
    //			if (Role.zeroTrans == null)
    //			{
    //				Role.zeroTrans = new GameObject("ZeroTrans").transform;
    //			}
    //			return Role.zeroTrans;
    //		}
    //	}

    //	// Token: 0x17000420 RID: 1056
    //	// (get) Token: 0x0600233A RID: 9018 RVA: 0x000EFCC8 File Offset: 0x000EDEC8
    //	// (set) Token: 0x0600233B RID: 9019 RVA: 0x000EFCD0 File Offset: 0x000EDED0
    //	public RoleEventHandler EventHandlerManager { get; private set; }

    //	// Token: 0x0600233C RID: 9020 RVA: 0x000EFCDC File Offset: 0x000EDEDC
    //	public virtual void BeforeDead(object sender, RoleDeadArgs e)
    //	{
    //		if (this.beforeDead != null)
    //		{
    //			this.beforeDead(sender, e);
    //		}
    //	}

    //	// Token: 0x17000421 RID: 1057
    //	// (get) Token: 0x0600233D RID: 9021 RVA: 0x000EFCF8 File Offset: 0x000EDEF8
    //	// (set) Token: 0x0600233E RID: 9022 RVA: 0x000EFD00 File Offset: 0x000EDF00
    //	public bool Invincible
    //	{
    //		get
    //		{
    //			return this.invincible;
    //		}
    //		set
    //		{
    //			this.invincible = value;
    //		}
    //	}

    //	// Token: 0x17000422 RID: 1058
    //	// (get) Token: 0x0600233F RID: 9023 RVA: 0x000EFD0C File Offset: 0x000EDF0C
    //	// (set) Token: 0x06002340 RID: 9024 RVA: 0x000EFD14 File Offset: 0x000EDF14
    //	public MFS_TALBE_TYPE MFSType
    //	{
    //		get
    //		{
    //			return this.m_eMFSType;
    //		}
    //		set
    //		{
    //			this.m_eMFSType = value;
    //		}
    //	}

    //	// Token: 0x17000423 RID: 1059
    //	// (get) Token: 0x06002342 RID: 9026 RVA: 0x000EFD2C File Offset: 0x000EDF2C
    //	// (set) Token: 0x06002341 RID: 9025 RVA: 0x000EFD20 File Offset: 0x000EDF20
    //	public int BevTreeID
    //	{
    //		get
    //		{
    //			return this.bevTreeID;
    //		}
    //		set
    //		{
    //			this.bevTreeID = value;
    //		}
    //	}

    //	// Token: 0x17000424 RID: 1060
    //	// (get) Token: 0x06002344 RID: 9028 RVA: 0x000EFD40 File Offset: 0x000EDF40
    //	// (set) Token: 0x06002343 RID: 9027 RVA: 0x000EFD34 File Offset: 0x000EDF34
    //	public bool BRagdoll
    //	{
    //		get
    //		{
    //			return this._bRagdoll;
    //		}
    //		set
    //		{
    //			this._bRagdoll = value;
    //		}
    //	}

    public int ID
    {
        get
        {
            return this._roleId;
        }
        set
        {
            this._roleId = value;
        }
    }

    //	// Token: 0x17000426 RID: 1062
    //	// (get) Token: 0x06002348 RID: 9032 RVA: 0x000EFD68 File Offset: 0x000EDF68
    //	// (set) Token: 0x06002347 RID: 9031 RVA: 0x000EFD5C File Offset: 0x000EDF5C
    //	public GameObjSpawn.SpawnInfo SpawnInfo
    //	{
    //		get
    //		{
    //			return this._spawnInfo;
    //		}
    //		set
    //		{
    //			this._spawnInfo = value;
    //		}
    //	}

    //	// Token: 0x17000427 RID: 1063
    //	// (get) Token: 0x0600234A RID: 9034 RVA: 0x000EFD7C File Offset: 0x000EDF7C
    //	// (set) Token: 0x06002349 RID: 9033 RVA: 0x000EFD70 File Offset: 0x000EDF70
    //	public string RoleName
    //	{
    //		get
    //		{
    //			return this._roleName;
    //		}
    //		set
    //		{
    //			this._roleName = value;
    //		}
    //	}

    //	// Token: 0x17000428 RID: 1064
    //	// (get) Token: 0x0600234C RID: 9036 RVA: 0x000EFD90 File Offset: 0x000EDF90
    //	// (set) Token: 0x0600234B RID: 9035 RVA: 0x000EFD84 File Offset: 0x000EDF84
    //	public RoleChildren RoleChildObj
    //	{
    //		get
    //		{
    //			return this._roleChildren;
    //		}
    //		set
    //		{
    //			this._roleChildren = value;
    //		}
    //	}

    //	// Token: 0x17000429 RID: 1065
    //	// (get) Token: 0x0600234E RID: 9038 RVA: 0x000EFDA4 File Offset: 0x000EDFA4
    //	// (set) Token: 0x0600234D RID: 9037 RVA: 0x000EFD98 File Offset: 0x000EDF98
    //	public bool BAniMove
    //	{
    //		get
    //		{
    //			return this._bAniMove;
    //		}
    //		set
    //		{
    //			this._bAniMove = value;
    //		}
    //	}

    //	// Token: 0x1700042A RID: 1066
    //	// (get) Token: 0x06002350 RID: 9040 RVA: 0x000EFDB8 File Offset: 0x000EDFB8
    //	// (set) Token: 0x0600234F RID: 9039 RVA: 0x000EFDAC File Offset: 0x000EDFAC
    //	public MonsterHp MonsterHP
    //	{
    //		get
    //		{
    //			return this._monsterHp;
    //		}
    //		set
    //		{
    //			this._monsterHp = value;
    //		}
    //	}

    //	// Token: 0x1700042B RID: 1067
    //	// (get) Token: 0x06002352 RID: 9042 RVA: 0x000EFDCC File Offset: 0x000EDFCC
    //	// (set) Token: 0x06002351 RID: 9041 RVA: 0x000EFDC0 File Offset: 0x000EDFC0
    //	public MonsterHp MonsterHpBottom
    //	{
    //		get
    //		{
    //			return this._monsterHpBottom;
    //		}
    //		set
    //		{
    //			this._monsterHpBottom = value;
    //		}
    //	}

    public virtual void Create()
    {
    }

    //	// Token: 0x06002354 RID: 9044 RVA: 0x000EFDD8 File Offset: 0x000EDFD8
    //	public virtual void SetChildrenGameObj(GameObject go)
    //	{
    //	}

    //	// Token: 0x06002355 RID: 9045 RVA: 0x000EFDDC File Offset: 0x000EDFDC
    //	public virtual void CreateModule()
    //	{
    //	}

    //	// Token: 0x06002356 RID: 9046 RVA: 0x000EFDE0 File Offset: 0x000EDFE0
    //	public virtual string GetHeadPath()
    //	{
    //		return null;
    //	}

    //	// Token: 0x06002357 RID: 9047 RVA: 0x000EFDE4 File Offset: 0x000EDFE4
    //	public virtual string GetShoutTalk()
    //	{
    //		return null;
    //	}

    //	// Token: 0x06002358 RID: 9048 RVA: 0x000EFDE8 File Offset: 0x000EDFE8
    //	public virtual string GetFleeWord()
    //	{
    //		return null;
    //	}

    //	// Token: 0x06002359 RID: 9049 RVA: 0x000EFDEC File Offset: 0x000EDFEC
    //	public virtual bool GetCanFlee()
    //	{
    //		return false;
    //	}

    //	// Token: 0x0600235A RID: 9050 RVA: 0x000EFDF0 File Offset: 0x000EDFF0
    //	public virtual RoleStaticInfo GetStaticRoleInfo()
    //	{
    //		return null;
    //	}

    //	// Token: 0x0600235B RID: 9051 RVA: 0x000EFDF4 File Offset: 0x000EDFF4
    //	public virtual string GetName()
    //	{
    //		return null;
    //	}

    //	// Token: 0x0600235C RID: 9052 RVA: 0x000EFDF8 File Offset: 0x000EDFF8
    //	public virtual float GetPrepareDis()
    //	{
    //		return 0f;
    //	}

    //	// Token: 0x0600235D RID: 9053 RVA: 0x000EFE00 File Offset: 0x000EE000
    //	public virtual float FleeHpPercent()
    //	{
    //		return 0f;
    //	}

    //	// Token: 0x0600235E RID: 9054 RVA: 0x000EFE08 File Offset: 0x000EE008
    //	public virtual float BegProbability()
    //	{
    //		return 0f;
    //	}

    //	// Token: 0x0600235F RID: 9055 RVA: 0x000EFE10 File Offset: 0x000EE010
    //	public virtual int SkillAttact()
    //	{
    //		return 0;
    //	}

    //	// Token: 0x06002360 RID: 9056 RVA: 0x000EFE14 File Offset: 0x000EE014
    //	public virtual int SkillAssault()
    //	{
    //		return 0;
    //	}

    //	// Token: 0x06002361 RID: 9057 RVA: 0x000EFE18 File Offset: 0x000EE018
    //	public virtual int SkillAggress()
    //	{
    //		return 0;
    //	}

    //	// Token: 0x06002362 RID: 9058 RVA: 0x000EFE1C File Offset: 0x000EE01C
    //	public virtual int SkillBuff()
    //	{
    //		return 0;
    //	}

    //	// Token: 0x06002363 RID: 9059 RVA: 0x000EFE20 File Offset: 0x000EE020
    //	public virtual int SkillBlood()
    //	{
    //		return 0;
    //	}

    //	// Token: 0x06002364 RID: 9060 RVA: 0x000EFE24 File Offset: 0x000EE024
    //	public virtual IdentityType Identity()
    //	{
    //		return (IdentityType)0;
    //	}

    //	// Token: 0x06002365 RID: 9061 RVA: 0x000EFE28 File Offset: 0x000EE028
    //	public virtual float NextAtkTime()
    //	{
    //		return 0f;
    //	}

    //	// Token: 0x06002366 RID: 9062 RVA: 0x000EFE30 File Offset: 0x000EE030
    //	public virtual float Height()
    //	{
    //		return 0f;
    //	}

    //	// Token: 0x06002367 RID: 9063 RVA: 0x000EFE38 File Offset: 0x000EE038
    //	public virtual int GetHurtID()
    //	{
    //		return 0;
    //	}

    //	// Token: 0x06002368 RID: 9064 RVA: 0x000EFE3C File Offset: 0x000EE03C
    //	public virtual float Distance()
    //	{
    //		return 0f;
    //	}

    //	// Token: 0x06002369 RID: 9065 RVA: 0x000EFE44 File Offset: 0x000EE044
    //	public virtual int GetBloodType()
    //	{
    //		return 0;
    //	}

    //	// Token: 0x0600236A RID: 9066 RVA: 0x000EFE48 File Offset: 0x000EE048
    //	public virtual float HpHigh()
    //	{
    //		return 0f;
    //	}

    public RoleGameObject roleGameObject
    {
        get
        {
            return this._roleGameObj;
        }
    }

    //	// Token: 0x0600236C RID: 9068 RVA: 0x000EFE58 File Offset: 0x000EE058
    //	public bool IsDieing()
    //	{
    //		return this.modMFS.GetCurrentStateId() == CONTROL_STATE.DIE;
    //	}

    //	// Token: 0x1700042D RID: 1069
    //	// (get) Token: 0x0600236D RID: 9069 RVA: 0x000EFE74 File Offset: 0x000EE074
    //	public string name
    //	{
    //		get
    //		{
    //			return this._roleGameObj.Name;
    //		}
    //	}

    //	// Token: 0x0600236E RID: 9070 RVA: 0x000EFE84 File Offset: 0x000EE084
    //	public bool IsEnemy(Role role)
    //	{
    //		ModOrganization modOrganization = role.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //		ModOrganization modOrganization2 = this.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //		return modOrganization != null && modOrganization2 != null && modOrganization2.IsEnmity(modOrganization);
    //	}

    //	// Token: 0x1700042E RID: 1070
    //	// (get) Token: 0x0600236F RID: 9071 RVA: 0x000EFEC0 File Offset: 0x000EE0C0
    //	public GameObject gameObject
    //	{
    //		get
    //		{
    //			return this._roleGameObj.RoleBody;
    //		}
    //	}

    //	// Token: 0x06002370 RID: 9072 RVA: 0x000EFED0 File Offset: 0x000EE0D0
    //	public virtual List<MonsterSkill> GetUseableSkill(int skillType)
    //	{
    //		return null;
    //	}

    //	// Token: 0x06002371 RID: 9073 RVA: 0x000EFED4 File Offset: 0x000EE0D4
    //	public virtual List<MonsterSkill> GetUseableSkill()
    //	{
    //		return null;
    //	}

    //	// Token: 0x06002372 RID: 9074 RVA: 0x000EFED8 File Offset: 0x000EE0D8
    //	public void InitRole()
    //	{
    //		this.EventHandlerManager = new RoleEventHandler(this);
    //		for (int i = 0; i < this._modList.Count; i++)
    //		{
    //			this._modList[i].Init();
    //		}
    //	}

    //	// Token: 0x06002373 RID: 9075 RVA: 0x000EFF20 File Offset: 0x000EE120
    //	public bool AddModule(Module md)
    //	{
    //		if (md == null)
    //		{
    //			return false;
    //		}
    //		this.RmvModule(md.ModType);
    //		this._modList.Add(md);
    //		return true;
    //	}

    //	// Token: 0x06002374 RID: 9076 RVA: 0x000EFF50 File Offset: 0x000EE150
    //	public bool RmvModule(MODULE_TYPE mt)
    //	{
    //		for (int i = 0; i < this._modList.Count; i++)
    //		{
    //			if (this._modList[i].ModType == mt)
    //			{
    //				this._modList[i].Remove();
    //				this._modList.RemoveAt(i);
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	// Token: 0x06002375 RID: 9077 RVA: 0x000EFFB4 File Offset: 0x000EE1B4
    //	public Module GetModule(MODULE_TYPE mt)
    //	{
    //		for (int i = 0; i < this._modList.Count; i++)
    //		{
    //			if (this._modList[i].ModType == mt)
    //			{
    //				return this._modList[i];
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x06002376 RID: 9078 RVA: 0x000F0004 File Offset: 0x000EE204
    //	public bool GetBuff(int id)
    //	{
    //		ModBuffProperty modBuffProperty = (ModBuffProperty)this.GetModule(MODULE_TYPE.MT_BUFF);
    //		return false;
    //	}

    //	// Token: 0x06002377 RID: 9079 RVA: 0x000F0020 File Offset: 0x000EE220
    //	public Vector3 GetPos()
    //	{
    //		if (this.GetTrans() == null)
    //		{
    //			return Vector3.zero;
    //		}
    //		return this.GetTrans().position;
    //	}

    //	// Token: 0x06002378 RID: 9080 RVA: 0x000F0050 File Offset: 0x000EE250
    //	public void SetPos(Vector3 pos)
    //	{
    //		this.roleGameObject.RoleTransform.position = pos;
    //	}

    //	// Token: 0x06002379 RID: 9081 RVA: 0x000F0064 File Offset: 0x000EE264
    //	public virtual int GetDetailType()
    //	{
    //		return 0;
    //	}

    //	// Token: 0x0600237A RID: 9082 RVA: 0x000F0068 File Offset: 0x000EE268
    //	public Quaternion GetRat()
    //	{
    //		return this.roleGameObject.RoleTransform.rotation;
    //	}

    //	// Token: 0x0600237B RID: 9083 RVA: 0x000F007C File Offset: 0x000EE27C
    //	public void SetRat(Vector3 rat)
    //	{
    //		this.roleGameObject.RoleTransform.rotation = Quaternion.Euler(rat);
    //	}

    //	// Token: 0x0600237C RID: 9084 RVA: 0x000F0094 File Offset: 0x000EE294
    //	public void SetRat(Quaternion rat)
    //	{
    //		this.roleGameObject.RoleTransform.rotation = rat;
    //	}

    //	// Token: 0x0600237D RID: 9085 RVA: 0x000F00A8 File Offset: 0x000EE2A8
    //	public Transform GetTrans()
    //	{
    //		if (this.roleGameObject.RoleTransform == null)
    //		{
    //			return Role.ZeroTrans;
    //		}
    //		Role.ZeroTrans.position = this.roleGameObject.RoleTransform.position;
    //		return this.roleGameObject.RoleTransform;
    //	}

    //	// Token: 0x0600237E RID: 9086 RVA: 0x000F00F8 File Offset: 0x000EE2F8
    //	public virtual bool IsOutOfSpawnBox()
    //	{
    //		return false;
    //	}

    //	// Token: 0x0600237F RID: 9087 RVA: 0x000F00FC File Offset: 0x000EE2FC
    //	public virtual bool IsOutOfSpawnBox(Vector3 pos)
    //	{
    //		return false;
    //	}

    //	// Token: 0x06002380 RID: 9088 RVA: 0x000F0100 File Offset: 0x000EE300
    //	public virtual long GetMeshIdx()
    //	{
    //		if (this.roleGameObject.ModelInfo != null)
    //		{
    //			return (long)this.roleGameObject.ModelInfo.AnimationIndex;
    //		}
    //		return -1L;
    //	}

    //	// Token: 0x06002381 RID: 9089 RVA: 0x000F0134 File Offset: 0x000EE334
    //	public virtual long GetWeaponIdx()
    //	{
    //		return 0L;
    //	}

    //	// Token: 0x06002382 RID: 9090 RVA: 0x000F0138 File Offset: 0x000EE338
    //	public virtual long GetHorseIdx()
    //	{
    //		return 0L;
    //	}

    //	// Token: 0x06002383 RID: 9091 RVA: 0x000F013C File Offset: 0x000EE33C
    //	public virtual float GetTurnSpeed()
    //	{
    //		return 0f;
    //	}

    //	// Token: 0x06002384 RID: 9092 RVA: 0x000F0144 File Offset: 0x000EE344
    //	public virtual float GetMassNumber()
    //	{
    //		return 1f;
    //	}

    //	// Token: 0x06002385 RID: 9093 RVA: 0x000F014C File Offset: 0x000EE34C
    //	public virtual bool ChangeModel(int modelID, bool destroyOld)
    //	{
    //		Vector3 position = this.GetTrans().position;
    //		Quaternion rotation = this.GetTrans().rotation;
    //		GameObject gameObject = RoleGameObject.CreatRoleGameObject(modelID, position, rotation);
    //		if (gameObject == null)
    //		{
    //			return false;
    //		}
    //		Transform parent = this.GetTrans().parent;
    //		if (destroyOld)
    //		{
    //			this.roleGameObject.RoleBody.active = false;
    //			this.roleGameObject.DetachEffect();
    //			this.roleGameObject.DestroyGO();
    //		}
    //		else
    //		{
    //			this.roleGameObject.RoleBind.Remove();
    //		}
    //		this.roleGameObject.SetGO(gameObject);
    //		if (parent != null)
    //		{
    //			this.GetTrans().parent = parent;
    //		}
    //		return true;
    //	}

    //	// Token: 0x06002386 RID: 9094 RVA: 0x000F01FC File Offset: 0x000EE3FC
    //	public virtual bool ChangeModel(GameObject gameObject, bool destroyOld)
    //	{
    //		if (gameObject == null)
    //		{
    //			return false;
    //		}
    //		Transform parent = this.GetTrans().parent;
    //		Vector3 position = this.GetTrans().position;
    //		Quaternion rotation = this.GetTrans().rotation;
    //		if (destroyOld)
    //		{
    //			this.roleGameObject.DetachEffect();
    //			this.roleGameObject.DestroyGO();
    //		}
    //		else
    //		{
    //			this.roleGameObject.RoleBind.Remove();
    //		}
    //		this.roleGameObject.SetGO(gameObject, position, rotation);
    //		if (parent != null)
    //		{
    //			this.GetTrans().parent = parent;
    //		}
    //		return true;
    //	}

    //	// Token: 0x1700042F RID: 1071
    //	// (get) Token: 0x06002387 RID: 9095 RVA: 0x000F0294 File Offset: 0x000EE494
    //	// (set) Token: 0x06002388 RID: 9096 RVA: 0x000F02B8 File Offset: 0x000EE4B8
    //	public float RunSpeed
    //	{
    //		get
    //		{
    //			ModAttribute modAttribute = this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //			return modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MOVESPEED);
    //		}
    //		set
    //		{
    //			ModAttribute modAttribute = this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //			modAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED, value, true);
    //		}
    //	}

    //	// Token: 0x06002389 RID: 9097 RVA: 0x000F02DC File Offset: 0x000EE4DC
    //	public int GetCurHp()
    //	{
    //		ModAttribute modAttribute = this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (modAttribute == null)
    //		{
    //			return 0;
    //		}
    //		return (int)modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_HP);
    //	}

    //	// Token: 0x0600238A RID: 9098 RVA: 0x000F0308 File Offset: 0x000EE508
    //	public float GetCurHpPercent()
    //	{
    //		if (this.GetMaxHp() == 0)
    //		{
    //			return 0f;
    //		}
    //		return (float)this.GetCurHp() / (float)this.GetMaxHp();
    //	}

    //	// Token: 0x0600238B RID: 9099 RVA: 0x000F0338 File Offset: 0x000EE538
    //	public bool isAlive()
    //	{
    //		return !this.isDestroyed && (!(this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) is ModAttribute) || this.GetCurHp() > 0);
    //	}

    //	// Token: 0x0600238C RID: 9100 RVA: 0x000F0378 File Offset: 0x000EE578
    //	public int GetMaxHp()
    //	{
    //		ModAttribute modAttribute = this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (modAttribute == null)
    //		{
    //			return 0;
    //		}
    //		return (int)modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP);
    //	}

    //	// Token: 0x0600238D RID: 9101 RVA: 0x000F03A4 File Offset: 0x000EE5A4
    //	public bool IsDead()
    //	{
    //		return this.isDestroyed || (this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) is ModAttribute && this.GetCurHp() <= 0);
    //	}

    //	// Token: 0x0600238E RID: 9102 RVA: 0x000F03E4 File Offset: 0x000EE5E4
    //	public bool AddRolePart(int id)
    //	{
    //		return true;
    //	}

    //	// Token: 0x0600238F RID: 9103 RVA: 0x000F03E8 File Offset: 0x000EE5E8
    //	public Role GetRolePart(int id)
    //	{
    //		RolePart rolePart = null;
    //		foreach (Role role in this.rolePartsList)
    //		{
    //			rolePart = (role as RolePart);
    //			if (rolePart.ID == id)
    //			{
    //				return rolePart;
    //			}
    //		}
    //		return rolePart;
    //	}

    //	// Token: 0x06002390 RID: 9104 RVA: 0x000F0468 File Offset: 0x000EE668
    //	public bool RolePartContains(int id)
    //	{
    //		RolePartInfo rolePart = GameData.Instance.RoleData.GetRolePart(id);
    //		if (rolePart == null)
    //		{
    //			return false;
    //		}
    //		foreach (Role role in this.rolePartsList)
    //		{
    //			RolePart rolePart2 = role as RolePart;
    //			if (rolePart2.rolePartInfo.BindPos == rolePart.BindPos && rolePart2.rolePartInfo.rolePartType == rolePart.rolePartType)
    //			{
    //				return true;
    //			}
    //		}
    //		return false;
    //	}

    //	// Token: 0x06002391 RID: 9105 RVA: 0x000F0520 File Offset: 0x000EE720
    //	public bool RemoveRolePart(int id)
    //	{
    //		for (int i = this.rolePartsList.Count - 1; i >= 0; i--)
    //		{
    //			RolePart rolePart = this.rolePartsList[i] as RolePart;
    //			if (rolePart != null)
    //			{
    //				if (rolePart.rolePartInfo.ID == id)
    //				{
    //					rolePart.DestroyRole();
    //					this.rolePartsList.Remove(rolePart);
    //				}
    //			}
    //		}
    //		return true;
    //	}

    //	// Token: 0x06002392 RID: 9106 RVA: 0x000F0590 File Offset: 0x000EE790
    //	public float GetMoveSpeed()
    //	{
    //		ModAttribute modAttribute = this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (modAttribute != null)
    //		{
    //			return modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MOVESPEED);
    //		}
    //		return -1f;
    //	}

    //	// Token: 0x06002393 RID: 9107 RVA: 0x000F05C0 File Offset: 0x000EE7C0
    //	public virtual void Die(bool qte)
    //	{
    //	}

    //	// Token: 0x06002394 RID: 9108 RVA: 0x000F05C4 File Offset: 0x000EE7C4
    //	public virtual void Die(bool qte, float corpseTime)
    //	{
    //	}

    //	// Token: 0x06002395 RID: 9109 RVA: 0x000F05C8 File Offset: 0x000EE7C8
    //	public virtual void Render()
    //	{
    //		for (int i = 0; i < this._modList.Count; i++)
    //		{
    //			this._modList[i].Render();
    //		}
    //	}

    //	// Token: 0x06002396 RID: 9110 RVA: 0x000F0604 File Offset: 0x000EE804
    //	public virtual void RoleProcess()
    //	{
    //		if (this.roleGameObject.RoleBody == null)
    //		{
    //			return;
    //		}
    //		for (int i = 0; i < this._modList.Count; i++)
    //		{
    //			this._modList[i].Process();
    //		}
    //	}

    //	// Token: 0x06002397 RID: 9111 RVA: 0x000F0658 File Offset: 0x000EE858
    //	public virtual bool ChangeMeshColor(Color col)
    //	{
    //		return true;
    //	}

    //	// Token: 0x06002398 RID: 9112 RVA: 0x000F065C File Offset: 0x000EE85C
    //	public virtual float GetViewRange()
    //	{
    //		return 40f;
    //	}

    //	// Token: 0x06002399 RID: 9113 RVA: 0x000F0664 File Offset: 0x000EE864
    //	public void StandUp()
    //	{
    //		ModAnimation modAnimation = this.GetModule(MODULE_TYPE.MT_MOTION) as ModAnimation;
    //		if (modAnimation == null)
    //		{
    //			return;
    //		}
    //		if (this.FaceDirInGround() == 0)
    //		{
    //			modAnimation.PlayAnimation(ACTION_INDEX.AN_FACEUP_STANDUP);
    //		}
    //		else
    //		{
    //			modAnimation.PlayAnimation(ACTION_INDEX.AN_FACEDOWN_STANDUP);
    //		}
    //	}

    //	// Token: 0x0600239A RID: 9114 RVA: 0x000F06AC File Offset: 0x000EE8AC
    //	public bool OnTheGroundInFace()
    //	{
    //		Transform transformByType;
    //		if (this._bRagdoll)
    //		{
    //			transformByType = this.RoleChildObj.GetTransformByType(RoleChildType.RCT_BONE_CHEST_R);
    //		}
    //		else
    //		{
    //			transformByType = this.RoleChildObj.GetTransformByType(RoleChildType.RCT_BONE_CHEST);
    //		}
    //		if (transformByType == null)
    //		{
    //			return false;
    //		}
    //		float num = Vector3.Dot(transformByType.right, Vector3.up);
    //		return (double)num > 0.4 || (double)num < -0.4;
    //	}

    //	// Token: 0x0600239B RID: 9115 RVA: 0x000F0728 File Offset: 0x000EE928
    //	public int FaceDirInGround()
    //	{
    //		Rigidbody rigidbody;
    //		if (this._bRagdoll)
    //		{
    //			rigidbody = this.roleGameObject.RagdollTrans[CHILD_RAGDOLL_POINT.ROOT];
    //		}
    //		else
    //		{
    //			rigidbody = this.roleGameObject.RagdollTrans[CHILD_RAGDOLL_POINT.ROOT];
    //		}
    //		float num = Vector3.Dot(rigidbody.transform.right, Vector3.up);
    //		if (num <= 0f)
    //		{
    //			return 0;
    //		}
    //		return 1;
    //	}

    //	// Token: 0x0600239C RID: 9116 RVA: 0x000F0790 File Offset: 0x000EE990
    //	public bool ChangeRagdoll(bool toRagdoll)
    //	{
    //		Animation roleAnimation = this.roleGameObject.RoleAnimation;
    //		ModAnimation modAnimation = this.GetModule(MODULE_TYPE.MT_MOTION) as ModAnimation;
    //		modAnimation.StopAnimation();
    //		if (roleAnimation == null)
    //		{
    //			return false;
    //		}
    //		CharacterController roleController = this.roleGameObject.RoleController;
    //		if (roleController == null)
    //		{
    //			return false;
    //		}
    //		roleAnimation.enabled = !toRagdoll;
    //		roleController.enabled = !toRagdoll;
    //		this.roleGameObject.EnableRagdoll(toRagdoll);
    //		this.BRagdoll = toRagdoll;
    //		return true;
    //	}

    //	// Token: 0x0600239D RID: 9117 RVA: 0x000F080C File Offset: 0x000EEA0C
    //	public void RemoveChildrenGameObj(bool bRagdoll)
    //	{
    //		if (bRagdoll)
    //		{
    //			this.RoleChildObj.RemoveRoleChild(RoleChildType.RCT_RAGDOLL);
    //			this.RoleChildObj.RemoveRoleChild(RoleChildType.RCT_REALY_MESH_R);
    //			this.RoleChildObj.RemoveRoleChild(RoleChildType.RCT_BONE_CHEST_R);
    //		}
    //		else
    //		{
    //			this.RoleChildObj.RemoveRoleChild(RoleChildType.RCT_MONSTER_PHY);
    //			this.RoleChildObj.RemoveRoleChild(RoleChildType.RCT_MOB_MESH);
    //			this.RoleChildObj.RemoveRoleChild(RoleChildType.RCT_REALY_MESH);
    //			this.RoleChildObj.RemoveRoleChild(RoleChildType.RCT_BONE_CHEST);
    //		}
    //	}

    //	// Token: 0x0600239E RID: 9118 RVA: 0x000F0878 File Offset: 0x000EEA78
    //	public void UpdateRagdollPosition(GameObject ragdoll)
    //	{
    //		Transform transformByType = this.RoleChildObj.GetTransformByType(RoleChildType.RCT_BONE_CHEST_R);
    //		Transform transformByType2 = this.RoleChildObj.GetTransformByType(RoleChildType.RCT_BONE_CHEST);
    //		Vector3 localPosition = transformByType2.localPosition;
    //		if (transformByType2 == null)
    //		{
    //			return;
    //		}
    //		ragdoll.transform.position = transformByType.position - localPosition;
    //		transformByType.position = ragdoll.transform.position + localPosition;
    //	}

    //	// Token: 0x0600239F RID: 9119 RVA: 0x000F08E4 File Offset: 0x000EEAE4
    //	public void SetForceToRagdoll(Vector3 force, RoleChildType childType)
    //	{
    //		Transform transformByType = this.RoleChildObj.GetTransformByType(childType);
    //		if (transformByType)
    //		{
    //			Logger.Log(new object[]
    //			{
    //				"Add Force:" + force
    //			});
    //			transformByType.rigidbody.AddForce(force);
    //		}
    //	}

    //	// Token: 0x060023A0 RID: 9120 RVA: 0x000F0934 File Offset: 0x000EEB34
    //	public void SetRagdollSleep()
    //	{
    //		RoleBaseFun.SetRigidSleep(this.roleGameObject.RoleTransform);
    //	}

    //	// Token: 0x060023A1 RID: 9121 RVA: 0x000F0948 File Offset: 0x000EEB48
    //	public virtual void DestroyRole()
    //	{
    //		this.RoleChildObj.ClearTable();
    //		this.roleGameObject.DestroyGO();
    //		if (this._roleType != ROLE_TYPE.RT_PLAYER)
    //		{
    //			ModAttribute modAttribute = this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //			if (modAttribute != null)
    //			{
    //				modAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_HP, 0f, true);
    //			}
    //		}
    //		this.rolePartsList.Clear();
    //		this.isDestroyed = true;
    //	}

    //	// Token: 0x060023A2 RID: 9122 RVA: 0x000F09AC File Offset: 0x000EEBAC
    //	public void AddBindRole(BindRoleInfo bri)
    //	{
    //		bool flag = false;
    //		for (int i = 0; i < this.BindRoleList.Count; i++)
    //		{
    //			if (this.BindRoleList[i].beBindedRole.ID == bri.beBindedRole.ID)
    //			{
    //				flag = true;
    //				break;
    //			}
    //		}
    //		if (!flag)
    //		{
    //			this.BindRoleList.Add(bri);
    //		}
    //	}

    //	// Token: 0x060023A3 RID: 9123 RVA: 0x000F0A18 File Offset: 0x000EEC18
    //	public void RemoveBindRole(BindRoleInfo bri)
    //	{
    //		this.BindRoleList.Remove(bri);
    //	}

    //	// Token: 0x060023A4 RID: 9124 RVA: 0x000F0A28 File Offset: 0x000EEC28
    //	public virtual void Input(float VerInput, float HorInput)
    //	{
    //	}

    //	// Token: 0x060023A5 RID: 9125 RVA: 0x000F0A2C File Offset: 0x000EEC2C
    //	public bool HaveBuff(int buffId)
    //	{
    //		ModBuffProperty modBuffProperty = this.GetModule(MODULE_TYPE.MT_BUFF) as ModBuffProperty;
    //		return modBuffProperty != null && modBuffProperty.ContainBuff(buffId);
    //	}

    //	// Token: 0x060023A6 RID: 9126 RVA: 0x000F0A58 File Offset: 0x000EEC58
    //	public void AddRetinue(Role role)
    //	{
    //		if (role == null || this.RetinueList.Contains(role))
    //		{
    //			return;
    //		}
    //		this.RetinueList.Add(role);
    //		role.ParentRole = this;
    //	}

    //	// Token: 0x060023A7 RID: 9127 RVA: 0x000F0A88 File Offset: 0x000EEC88
    //	public void DelRetinue(Role role)
    //	{
    //		if (role == null || !this.RetinueList.Contains(role))
    //		{
    //			return;
    //		}
    //		this.RetinueList.Remove(role);
    //	}
}
