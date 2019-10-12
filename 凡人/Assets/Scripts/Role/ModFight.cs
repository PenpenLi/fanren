using System;
using System.Collections.Generic;
using UnityEngine;

public class ModFight : Module
{
    private ModCamera m_cModCamera;

    //private ModAttribute m_cModAttr;

    public Vector3 HitPoint;

    private Vector3 m_vecAttackDir;

    private int strongValue;

    private int awaysStrongValue;

    private int m_bIsInvincible;

    //   private int m_bBaseInvincible;

    //   private FightInfo m_cLastHurtInfo;

    //   private TargetQuadrant m_eTargetQuadrant = TargetQuadrant.NONE;

    //   private Role m_cTargetRole;

    //   private bool m_bIsFighting;

    //   private float m_fFightingStartTime;

    //   public FightInfo m_cCurrentFightInfo;

    public float VerInput;

    public float HorInput;

    //   public ModFight(Role role) : base(role)
    //{
    //	base.ModType = MODULE_TYPE.MT_FIGHT;
    //}

    //public event RoleHurtEventHandler beforeHurt;

    //public bool IsStrengthFull { get; set; }

    //public int GatherSkillID { get; set; }

    //public bool IsAttacking { get; set; }

    //public bool IsUsingWeapon { get; set; }

    //public bool IsStrong
    //{
    //	get
    //	{
    //		return (float)this.strongValue > 0f || (float)this.awaysStrongValue > 0f;
    //	}
    //}

    //public void SetStrong(bool b)
    //{
    //	this.awaysStrongValue = ((!b) ? 0 : 1);
    //}

    //public void StrongBuff(bool b)
    //{
    //	int num = (!b) ? -1 : 1;
    //	this.strongValue += num;
    //	if (this.strongValue <= 0)
    //	{
    //		this.strongValue = 0;
    //	}
    //}

    //public bool IsInvincible
    //{
    //	get
    //	{
    //		return this.m_bIsInvincible > 0 || this.m_bBaseInvincible > 0;
    //	}
    //}

    //public void BaseInvincible(bool b)
    //{
    //	this.m_bBaseInvincible = ((!b) ? 0 : 1);
    //}

    //public void Invincible(bool b)
    //{
    //	int num = (!b) ? -1 : 1;
    //	this.m_bIsInvincible += num;
    //	if (this.m_bIsInvincible <= 0)
    //	{
    //		this.m_bIsInvincible = 0;
    //	}
    //}

    //public FightInfo LastHurtInfo
    //{
    //	get
    //	{
    //		return this.m_cLastHurtInfo;
    //	}
    //}

    public Vector3 AttackDir
    {
        get
        {
            return this.m_vecAttackDir;
        }
        set
        {
            this.m_vecAttackDir = value;
        }
    }

    //public TargetQuadrant TargetQuadrant
    //{
    //	get
    //	{
    //		return this.m_eTargetQuadrant;
    //	}
    //	set
    //	{
    //		this.m_eTargetQuadrant = value;
    //	}
    //}

    //public Role TargetRole
    //{
    //	get
    //	{
    //		return this.m_cTargetRole;
    //	}
    //	set
    //	{
    //		this.m_cTargetRole = value;
    //	}
    //}

    //public bool IsFighting
    //{
    //	get
    //	{
    //		return this.m_bIsFighting;
    //	}
    //}

    //public override bool Init()
    //{
    //	if (this._role._roleType == ROLE_TYPE.RT_PLAYER)
    //	{
    //		this.m_cModCamera = (ModCamera)this._role.GetModule(MODULE_TYPE.MT_CAMERA);
    //		if (this.m_cModCamera == null)
    //		{
    //			Logger.Log(new object[]
    //			{
    //				"ModCamera is missing!"
    //			});
    //		}
    //	}
    //	this.m_cModAttr = (ModAttribute)this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE);
    //	return base.Init();
    //}

    //public bool CanBeFight(Role role)
    //{
    //	if (this._role.GetCurHp() <= 0)
    //	{
    //		return false;
    //	}
    //	Logger.Log(new object[]
    //	{
    //		role.Invincible + "____222222_______" + role.name
    //	});
    //	if (this._role.Invincible)
    //	{
    //		return false;
    //	}
    //	ModOrganization modOrganization = this._role.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //	ModOrganization modOrganization2 = role.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //	return modOrganization != null && modOrganization2 != null && modOrganization.IsEnmity(modOrganization2);
    //}

    //public bool Attack(int mouseFlag, int comboId)
    //{
    //	ModControlMFS modControlMFS = (ModControlMFS)this._role.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
    //	modControlMFS.ChangeState(new ControlEventAttack(false, this.m_vecAttackDir, this.m_cTargetRole)
    //	{
    //		m_imouseFlag = mouseFlag,
    //		m_comboID = comboId
    //	});
    //	return true;
    //}

    //public void CreatHurtEffect(FightInfo info)
    //{
    //	int id = -1;
    //	int num = -1;
    //	if (info.hurtEffectInfo != null && info.hurtEffectInfo.effectID > 0)
    //	{
    //		id = info.hurtEffectInfo.effectID;
    //	}
    //	else if (info.figureID != 0)
    //	{
    //		id = Singleton<FigureEffectData>.GetInstance().GetAttackedEffectId(info.figureID);
    //		int materialType = this._role.roleGameObject.ModelInfo.MaterialType;
    //		HurtEffect data = Singleton<HurtEffectData>.GetInstance().GetData(info.weaponMateriaType, materialType);
    //		if (data != null)
    //		{
    //			num = data.SoundID;
    //		}
    //	}
    //	else
    //	{
    //		int materialType2 = this._role.roleGameObject.ModelInfo.MaterialType;
    //		HurtEffect data2 = Singleton<HurtEffectData>.GetInstance().GetData(info.weaponMateriaType, materialType2);
    //		if (data2 != null)
    //		{
    //			id = data2.EffectID;
    //			num = data2.SoundID;
    //		}
    //	}
    //	Vector3 vector = info.hurtPoint;
    //	if (vector == Vector3.zero)
    //	{
    //		vector = base.Role.GetPos() + new Vector3(0f, 1f, 0f);
    //	}
    //	SingletonMono<EffectManager>.GetInstance().AddEffect(id, vector, vector, vector, Quaternion.identity, null, false);
    //	if (num > 0)
    //	{
    //		SingletonMono<AudioManager>.GetInstance().PlaySound(SoundType.gameSound, vector, num, false);
    //	}
    //	if (info.materialID > 0)
    //	{
    //		this._role.roleGameObject.AddMaterialeffect(info.materialID, 1f);
    //	}
    //}

    //public void Hurt(FightInfo info, ACTION_INDEX ani)
    //{
    //	if (info == null)
    //	{
    //		return;
    //	}
    //	if (this.beforeHurt != null)
    //	{
    //		this.beforeHurt(this, new RoleHurtArgs(info));
    //	}
    //	bool flag = true;
    //	if (this.IsInvincible)
    //	{
    //		flag = false;
    //	}
    //	if (info.hurtLevel == FightInfo.HURT_LEVEL.BREAK_ALL || info.hurtLevel == FightInfo.HURT_LEVEL.BREAK_WUDI)
    //	{
    //		flag = true;
    //	}
    //	if (flag)
    //	{
    //		if (info._role != null)
    //		{
    //			ModOrganization modOrganization = this._role.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //			ModOrganization modOrganization2 = info._role.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
    //			if (modOrganization != null && modOrganization2 != null && !modOrganization.IsEnmity(modOrganization2))
    //			{
    //				return;
    //			}
    //		}
    //		this.Hurt(info);
    //		if (info.screenShakeID > 0)
    //		{
    //			SingletonMono<ScreenShockController>.GetInstance().Shock(info.screenShakeID);
    //		}
    //		if (info.timeScaleID > 0 && !SingletonMono<BulletTimeController>.GetInstance().IsSlow())
    //		{
    //			SingletonMono<BulletTimeController>.GetInstance().ChangeTimeScale(info.timeScaleID);
    //		}
    //		this.ChangeToHurtState(info);
    //	}
    //}

    //public bool ChangeToHurtState(FightInfo info)
    //{
    //	if (info == null)
    //	{
    //		return false;
    //	}
    //	bool flag = true;
    //	if (this.IsStrong)
    //	{
    //		flag = false;
    //	}
    //	if (info.hurtLevel == FightInfo.HURT_LEVEL.BREAK_ALL || info.hurtLevel == FightInfo.HURT_LEVEL.BREAK_BATI)
    //	{
    //		flag = true;
    //	}
    //	if (!flag)
    //	{
    //		return false;
    //	}
    //	if (!this._role.isAlive())
    //	{
    //		return false;
    //	}
    //	ModControlMFS modControlMFS = (ModControlMFS)this._role.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
    //	return modControlMFS != null && modControlMFS.ChangeState(new ControlEventHurt(false, info));
    //}

    //public void Hurt(FightInfo info)
    //{
    //	if (info == null)
    //	{
    //		return;
    //	}
    //	if (info._role != null && info._role._roleType == ROLE_TYPE.RT_PLAYER && info._figureEnergy > 0f)
    //	{
    //		((Player)info._role).SystemFigure.AddFigureEnergy(info._figureEnergy);
    //		info._figureEnergy = 0f;
    //	}
    //	if (this._role._roleType == ROLE_TYPE.RT_MONSTER)
    //	{
    //		this._role.roleGameObject.AddMaterialeffect(809, 0.03f, 100f, 50f);
    //	}
    //	this.m_cLastHurtInfo = info;
    //	this.UpdateAttribute(this._role, info);
    //	this.CreatHurtEffect(info);
    //	if (info.hurtedHandle != null)
    //	{
    //		HurtedArgs hurtedArgs = new HurtedArgs(info);
    //		hurtedArgs.isWuDi = this.IsInvincible;
    //		hurtedArgs.isBaTi = this.IsStrong;
    //		hurtedArgs.hurtedObject = base.Role;
    //		info.hurtedHandle(base.Role, hurtedArgs);
    //	}
    //}

    //// Token: 0x0600221E RID: 8734 RVA: 0x000E8E2C File Offset: 0x000E702C
    //private void UpdateAttribute(Role role, FightInfo fightInfo)
    //{
    //	if (role._roleType == ROLE_TYPE.RT_MONSTER)
    //	{
    //		if (role.MonsterHP != null)
    //		{
    //			role.MonsterHP.ShowHP();
    //		}
    //		if (role.MonsterHpBottom != null)
    //		{
    //			role.MonsterHpBottom.ShowHP();
    //		}
    //	}
    //	fightInfo._percentDamage = Mathf.Abs(fightInfo._percentDamage);
    //	fightInfo._damage = Mathf.Abs(fightInfo._damage);
    //	if (fightInfo._role == null)
    //	{
    //		ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (fightInfo._percentDamage > 0f)
    //		{
    //			modAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, -fightInfo._percentDamage * modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP), false);
    //		}
    //		else
    //		{
    //			modAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, -fightInfo._damage, false);
    //		}
    //	}
    //	else
    //	{
    //		ModAttribute modAttribute2 = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //		if (modAttribute2 != null)
    //		{
    //			KeyValuePair<float, bool> keyValuePair = modAttribute2.AttackCalculate(role, fightInfo);
    //			if (keyValuePair.Key != 0f && keyValuePair.Key < 0f && fightInfo._role._roleType == ROLE_TYPE.RT_PLAYER && fightInfo._fightType == FightInfo.FightType.FT_PHY)
    //			{
    //				Player player = (Player)fightInfo._role;
    //				player.m_cAdeptSystem.CheckAdeptSkill();
    //			}
    //		}
    //	}
    //}

    //// Token: 0x0600221F RID: 8735 RVA: 0x000E8F6C File Offset: 0x000E716C
    //public float CalculateAtk()
    //{
    //	float num = this.m_cModAttr.GetAttributeValue(ATTRIBUTE_TYPE.ATT_PHY_ATK);
    //	float num2 = 1f;
    //	num *= num2;
    //	return -num;
    //}

    //// Token: 0x06002220 RID: 8736 RVA: 0x000E8F94 File Offset: 0x000E7194
    //private float CalculateDamage(FightInfo fightInfo)
    //{
    //	ModAttribute modAttribute = this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
    //	float result = 0f;
    //	if (fightInfo._damage != 0f)
    //	{
    //		result = fightInfo._damage;
    //	}
    //	else if (fightInfo._percentDamage != 0f)
    //	{
    //		float f = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP) * Mathf.Abs(fightInfo._percentDamage) / 100f;
    //		if (fightInfo._percentDamage < 0f)
    //		{
    //			f = -Mathf.Abs(f);
    //		}
    //	}
    //	return result;
    //}

    //// Token: 0x06002221 RID: 8737 RVA: 0x00017988 File Offset: 0x00015B88
    //public void SetFighting()
    //{
    //	this.m_bIsFighting = true;
    //	this.m_fFightingStartTime = GameTime.time;
    //}

    //// Token: 0x06002222 RID: 8738 RVA: 0x000E9018 File Offset: 0x000E7218
    //private void CheckFighting()
    //{
    //	if (this._role._roleType != ROLE_TYPE.RT_PLAYER)
    //	{
    //		return;
    //	}
    //	if (Player.Instance == null)
    //	{
    //		return;
    //	}
    //	if (Player.Instance.weaponManager.weaponeActive && this.m_bIsFighting && GameTime.time - this.m_fFightingStartTime > 2.5f)
    //	{
    //		this.m_bIsFighting = false;
    //		ModControlMFS modControlMFS = (ModControlMFS)this._role.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
    //		modControlMFS.ChangeState(new ControlEventBackWeapon(false));
    //	}
    //}

    //// Token: 0x06002223 RID: 8739 RVA: 0x0000221B File Offset: 0x0000041B
    //public void StartGatherStrength()
    //{
    //}

    //// Token: 0x06002224 RID: 8740 RVA: 0x000E90A0 File Offset: 0x000E72A0
    //public void UseGatherSkill()
    //{
    //	this.TargetRole = null;
    //	if (Player.Instance != null)
    //	{
    //		Player.Instance.SetTargetRoleByInput();
    //	}
    //	this._role.modMFS.ChangeState(new ControlEventSkill(true, this.GatherSkillID, this.TargetRole, this.AttackDir + base.Role.GetPos()));
    //}

    public override void Process()
	{
		base.Process();
	}
}
