using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;


public class Role
{
    public const int nMaxID = 100000;

    public ROLE_TYPE _roleType;

    /// <summary>
    /// 角色仇恨
    /// </summary>
    public RoleHatred hatred = new RoleHatred();

    protected List<Module> _modList = new List<Module>();

    public List<Role> rolePartsList = new List<Role>();

    public List<BindRoleInfo> BindRoleList = new List<BindRoleInfo>();

    private int _roleId;

    private string _roleName;

    //private GameObjSpawn.SpawnInfo _spawnInfo;

    private bool _bRagdoll;

    //private RoleChildren _roleChildren = new RoleChildren();

    public ModControlMFS modMFS;

    //public ModBehaviorAI modAi;

    private bool _bAniMove;

    private int bevTreeID;

    //private MFS_TALBE_TYPE m_eMFSType;

    //private MonsterHp _monsterHp;

    //private MonsterHp _monsterHpBottom;

    //private bool invincible;

    //private bool isDestroyed;


    private static Transform zeroTrans;

 
    protected RoleGameObject _roleGameObj = new RoleGameObject();


    private float runSpeed = 7f;

    public List<Role> RetinueList = new List<Role>();

    public Role ParentRole;

    //public event RoleDeadEventHandler beforeDead;

    public static Transform ZeroTrans
    {
        get
        {
            if (Role.zeroTrans == null)
            {
                Role.zeroTrans = new GameObject("ZeroTrans").transform;
            }
            return Role.zeroTrans;
        }
    }

    public RoleEventHandler EventHandlerManager { get; private set; }

    //	public virtual void BeforeDead(object sender, RoleDeadArgs e)
    //	{
    //		if (this.beforeDead != null)
    //		{
    //			this.beforeDead(sender, e);
    //		}
    //	}

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

    public string RoleName
    {
        get
        {
            return this._roleName;
        }
        set
        {
            this._roleName = value;
        }
    }

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


    public virtual void SetChildrenGameObj(GameObject go)
    {
    }

    public virtual void CreateModule()
    {
    }

    //	public virtual string GetHeadPath()
    //	{
    //		return null;
    //	}

    //	public virtual string GetShoutTalk()
    //	{
    //		return null;
    //	}

    //	public virtual string GetFleeWord()
    //	{
    //		return null;
    //	}

    //	public virtual bool GetCanFlee()
    //	{
    //		return false;
    //	}

    //	public virtual RoleStaticInfo GetStaticRoleInfo()
    //	{
    //		return null;
    //	}

    //	public virtual string GetName()
    //	{
    //		return null;
    //	}

    //	public virtual float GetPrepareDis()
    //	{
    //		return 0f;
    //	}

    //	public virtual float FleeHpPercent()
    //	{
    //		return 0f;
    //	}

    //	public virtual float BegProbability()
    //	{
    //		return 0f;
    //	}

    //	public virtual int SkillAttact()
    //	{
    //		return 0;
    //	}

    //	public virtual int SkillAssault()
    //	{
    //		return 0;
    //	}

    //	public virtual int SkillAggress()
    //	{
    //		return 0;
    //	}

    //	public virtual int SkillBuff()
    //	{
    //		return 0;
    //	}

    //	public virtual int SkillBlood()
    //	{
    //		return 0;
    //	}

    //	public virtual IdentityType Identity()
    //	{
    //		return (IdentityType)0;
    //	}

    //	public virtual float NextAtkTime()
    //	{
    //		return 0f;
    //	}

    //	public virtual float Height()
    //	{
    //		return 0f;
    //	}

    //	public virtual int GetHurtID()
    //	{
    //		return 0;
    //	}

    //	public virtual float Distance()
    //	{
    //		return 0f;
    //	}

    //	public virtual int GetBloodType()
    //	{
    //		return 0;
    //	}

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

    //	public bool IsDieing()
    //	{
    //		return this.modMFS.GetCurrentStateId() == CONTROL_STATE.DIE;
    //	}

    public string name
    {
        get
        {
            return this._roleGameObj.Name;
        }
    }

    //	public bool IsEnemy(Role role)
    //	{
    //		ModOrganization modOrganization = role.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //		ModOrganization modOrganization2 = this.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //		return modOrganization != null && modOrganization2 != null && modOrganization2.IsEnmity(modOrganization);
    //	}

    public GameObject gameObject
    {
        get
        {
            return this._roleGameObj.RoleBody;
        }
    }

    //	public virtual List<MonsterSkill> GetUseableSkill(int skillType)
    //	{
    //		return null;
    //	}

    //	public virtual List<MonsterSkill> GetUseableSkill()
    //	{
    //		return null;
    //	}

    public void InitRole()
    {
        this.EventHandlerManager = new RoleEventHandler(this);
        for (int i = 0; i < this._modList.Count; i++)
        {
            this._modList[i].Init();
        }
    }

    /// <summary>
    /// 添加模块
    /// </summary>
    /// <param name="md"></param>
    /// <returns></returns>
    public bool AddModule(Module md)
    {
        if (md == null)
        {
            return false;
        }
        this.RmvModule(md.ModType);
        this._modList.Add(md);
        return true;
    }

    /// <summary>
    /// 移除模块
    /// </summary>
    /// <param name="mt"></param>
    /// <returns></returns>
    public bool RmvModule(MODULE_TYPE mt)
    {
        for (int i = 0; i < this._modList.Count; i++)
        {
            if (this._modList[i].ModType == mt)
            {
                this._modList[i].Remove();
                this._modList.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public Module GetModule(MODULE_TYPE mt)
    {
        for (int i = 0; i < this._modList.Count; i++)
        {
            if (this._modList[i].ModType == mt)
            {
                return this._modList[i];
            }
        }
        return null;
    }

    //	public bool GetBuff(int id)
    //	{
    //		ModBuffProperty modBuffProperty = (ModBuffProperty)this.GetModule(MODULE_TYPE.MT_BUFF);
    //		return false;
    //	}

    public Vector3 GetPos()
    {
        if (this.GetTrans() == null)
        {
            return Vector3.zero;
        }
        return this.GetTrans().position;
    }

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

    public void SetRat(Vector3 rat)
    {
        this.roleGameObject.RoleTransform.rotation = Quaternion.Euler(rat);
    }

    public void SetRat(Quaternion rat)
    {
        this.roleGameObject.RoleTransform.rotation = rat;
    }

    public Transform GetTrans()
    {
        if (this.roleGameObject.RoleTransform == null)
        {
            return Role.ZeroTrans;
        }
        Role.ZeroTrans.position = this.roleGameObject.RoleTransform.position;
        return this.roleGameObject.RoleTransform;
    }

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

    public float RunSpeed
    {
        get
        {
            return 7;
            //ModAttribute modAttribute = this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
            //return modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MOVESPEED);
        }
        set
        {
            //ModAttribute modAttribute = this.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
            //modAttribute.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED, value, true);
        }
    }

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

    public virtual void RoleProcess()
    {
        if (this.roleGameObject.RoleBody == null)
        {
            return;
        }
        for (int i = 0; i < this._modList.Count; i++)
        {
            this._modList[i].Process();
        }
    }

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

    //	public void RemoveBindRole(BindRoleInfo bri)
    //	{
    //		this.BindRoleList.Remove(bri);
    //	}

    public virtual void Input(float VerInput, float HorInput)
    {
    }

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
