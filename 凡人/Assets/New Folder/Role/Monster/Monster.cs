using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;


public class Monster : Role
{
    private const float _DisapperTime = 5f;

    public bool bProcess;

    private static float CHECK_PRC_TIME = 0.3f;

    private float lastCheckProcTime = Monster.CHECK_PRC_TIME;

    public bool FindPlayer;

    public MonsterInfo _monsterInfo;

    private bool _bNeedResetCamera;

    private static int nNextEnemyID = 30000;

    private ModAttribute modAttr;

    private ModAnimation modAni;

   //private ModBuffProperty m_cModBuff;

    private Transform mobMeshTrans;

    private float _dieTime = float.MaxValue;

    public bool _bDie;

    private bool _bDieCount = true;

    private SphereCollider raderCollider;

    public Monster()
	{
		this._roleType = ROLE_TYPE.RT_MONSTER;
	}

	public MonsterInfo MonInfo
	{
		get
		{
			return this._monsterInfo;
		}
		set
		{
			this._monsterInfo = value;
		}
	}

	public bool BNeedResetCamera
	{
		get
		{
			return this._bNeedResetCamera;
		}
		set
		{
			this._bNeedResetCamera = value;
		}
	}

	public bool MonsterHp
	{
		get
		{
			return this._bDie;
		}
		set
		{
			this._bDie = value;
		}
	}

	//public void ProcessRandomSkill()
	//{
	//	if (this._monsterInfo._randerSkillsID == 0 || this._monsterInfo._randerSkillCount == 0)
	//	{
	//		return;
	//	}
	//	RandomSkillsInfo randomSkillInfoByID = GameData.Instance.RoleData.GetRandomSkillInfoByID(this._monsterInfo._randerSkillsID);
	//	if (randomSkillInfoByID == null)
	//	{
	//		return;
	//	}
	//	List<MonsterSkill> list = new List<MonsterSkill>();
	//	foreach (MonsterSkill monsterSkill in randomSkillInfoByID.RanderSkillList)
	//	{
	//		list.Add(new MonsterSkill(monsterSkill.SkillID, monsterSkill.UseRule));
	//	}
	//	for (int i = 0; i < this._monsterInfo._randerSkillCount; i++)
	//	{
	//		int num = -1;
	//		for (int j = 0; j < this._monsterInfo._attackSkill.Count; j++)
	//		{
	//			if (this._monsterInfo._attackSkill[j].SkillID == 0)
	//			{
	//				num = j;
	//				break;
	//			}
	//		}
	//		if (num == -1)
	//		{
	//			break;
	//		}
	//		int index = UnityEngine.Random.Range(0, list.Count - 1);
	//		this._monsterInfo._attackSkill[num] = list[index];
	//		list.RemoveAt(index);
	//	}
	//}

	public static Monster Create(GameObject parentObj, GameObjSpawn.SpawnInfo spawnInfo, MonsterInfo mi)
	{
		if (mi.SpawnEffect != -1)
		{
		}
		Monster monster = new Monster();
		monster.MFSType = MFS_TALBE_TYPE.MONSTER;
		monster._roleType = ROLE_TYPE.RT_MONSTER;
		monster.roleGameObject.Init(monster);
		monster.roleGameObject.CreatGO(mi.ModelID, spawnInfo.position, spawnInfo.rotation);
		if (monster.roleGameObject.RoleBind == null)
		{
			return null;
		}
		monster.roleGameObject.RoleBind.SetRole(monster);
		GameObject roleBody = monster.roleGameObject.RoleBody;
		monster.roleGameObject.RoleTransform.parent = parentObj.transform;
		//monster.BAniMove = mi.AniMove;
		//monster.SpawnInfo = spawnInfo;
		//monster._monsterInfo = new MonsterInfo(mi);
		//monster.ProcessRandomSkill();
		//monster.RoleName = mi.Name;
		//monster._bDieCount = true;
		//monster.BevTreeID = mi.bevTreeID;
		roleBody.tag = "Monster";
		monster.ID = Monster.nNextEnemyID;
		roleBody.name = mi.Name + monster.ID.ToString();
		Monster.nNextEnemyID++;
		monster.roleGameObject.EnableRagdoll(false);
		monster.CreateModule();
		monster.lastCheckProcTime = UnityEngine.Random.Range(0f, Monster.CHECK_PRC_TIME);
		if (spawnInfo.parentRole != null)
		{
			//spawnInfo.parentRole.AddRetinue(monster);
		}
		if (monster.roleGameObject.RoleController != null && !monster.roleGameObject.RoleController.isGrounded)
		{
			monster.roleGameObject.RoleController.Move(new Vector3(0f, -20f, 0f));
		}
		if (monster.modMFS != null)
		{
			int bornBev = (spawnInfo.BornBev <= 0) ? mi.BornBev : spawnInfo.BornBev;
			//monster.modMFS.ChangeState(new ControlEventSpawn(false, bornBev));
		}
		if (mi.BloodType == 0)
		{
			GameObject original = (GameObject)ResourceLoader.Load("Prefabs/Mob/HPGUI", typeof(GameObject));
			GameObject gameObject = LoadMachine.InstantiateObject(original, Vector3.zero, Quaternion.identity) as GameObject;
			//gameObject.transform.parent = SceneManager.RoleMan.MonsterHpRoot.transform;
			//monster.MonsterHP = gameObject.transform.GetComponent<MonsterHp>();
			//if (monster.MonsterHP != null)
			//{
			//	monster.MonsterHP.HpTarget = roleBody.transform;
			//	monster.MonsterHP.monster = monster;
			//	monster.MonsterHP.bBack = false;
			//	monster.MonsterHP.gameObject.active = false;
			//}
			//GameObject original2 = (GameObject)ResourceLoader.Load("Prefabs/Mob/HpBottom", typeof(GameObject));
			//GameObject gameObject2 = LoadMachine.InstantiateObject(original2, Vector3.zero, Quaternion.identity) as GameObject;
			//monster.MonsterHpBottom = gameObject2.transform.GetComponent<MonsterHp>();
			//gameObject2.transform.parent = SceneManager.RoleMan.MonsterHpRoot.transform;
			//if (monster.MonsterHpBottom != null)
			//{
			//	monster.MonsterHpBottom.HpTarget = roleBody.transform;
			//	monster.MonsterHpBottom.monster = monster;
			//	monster.MonsterHpBottom.gameObject.active = false;
			//}
			monster.hatred.selfRole = monster;
		}
		if (mi.BloodType == 2)
		{
			GameObject original3 = (GameObject)ResourceLoader.Load("Prefabs/Mob/Refine_HPGUI", typeof(GameObject));
			GameObject gameObject3 = LoadMachine.InstantiateObject(original3, Vector3.zero, Quaternion.identity) as GameObject;
			//gameObject3.transform.parent = SceneManager.RoleMan.MonsterHpRoot.transform;
			//monster.MonsterHP = gameObject3.transform.GetComponent<MonsterHp>();
			//if (monster.MonsterHP != null)
			//{
			//	monster.MonsterHP.HpTarget = roleBody.transform;
			//	monster.MonsterHP.monster = monster;
			//	monster.MonsterHP.bBack = false;
			//	monster.MonsterHP.gameObject.active = false;
			//}
			GameObject original4 = (GameObject)ResourceLoader.Load("Prefabs/Mob/Refine_HpBottom", typeof(GameObject));
			GameObject gameObject4 = LoadMachine.InstantiateObject(original4, Vector3.zero, Quaternion.identity) as GameObject;
			//monster.MonsterHpBottom = gameObject4.transform.GetComponent<MonsterHp>();
			//gameObject4.transform.parent = SceneManager.RoleMan.MonsterHpRoot.transform;
			//if (monster.MonsterHpBottom != null)
			//{
			//	monster.MonsterHpBottom.HpTarget = roleBody.transform;
			//	monster.MonsterHpBottom.monster = monster;
			//	monster.MonsterHpBottom.gameObject.active = false;
			//}
			monster.hatred.selfRole = monster;
		}
		return monster;
	}

	//public override void CreateModule()
	//{
	//	if (this.MonInfo.identity == IdentityType.Bar)
	//	{
	//		this.AddModule(MODULE_TYPE.MT_ATTRIBUTE);
	//		this.AddModule(MODULE_TYPE.MT_FIGHT);
	//		this.AddModule(MODULE_TYPE.MT_MOTION);
	//		this.AddModule(MODULE_TYPE.MT_MOVE);
	//		this.AddModule(MODULE_TYPE.MT_AI_BEHAVIOR);
	//		this.AddModule(MODULE_TYPE.MT_ORGANIZATION);
	//	}
	//	else
	//	{
	//		this.AddModule(MODULE_TYPE.MT_MOVE);
	//		this.AddModule(MODULE_TYPE.MT_ATTRIBUTE);
	//		this.AddModule(MODULE_TYPE.MT_MOTION);
	//		this.AddModule(MODULE_TYPE.MT_ORGANIZATION);
	//		this.AddModule(MODULE_TYPE.MT_FIGHT);
	//		this.AddModule(MODULE_TYPE.MT_BUFF);
	//		this.AddModule(MODULE_TYPE.MT_COLLIDER);
	//		this.AddModule(MODULE_TYPE.MT_SKILL);
	//		this.AddModule(MODULE_TYPE.MT_CONTROL_MFS);
	//		this.AddModule(MODULE_TYPE.MT_AI_BEHAVIOR);
	//	}
	//	this.AddModule(MODULE_TYPE.MT_VOICE);
	//	BodyColliderBehaviour[] roleBodyCollider = base.roleGameObject.RoleBodyCollider;
	//	CharacterController component = base.GetTrans().GetComponent<CharacterController>();
	//	foreach (BodyColliderBehaviour bodyColliderBehaviour in roleBodyCollider)
	//	{
	//		Collider[] components = bodyColliderBehaviour.GetComponents<Collider>();
	//		foreach (Collider collider in components)
	//		{
	//			collider.enabled = true;
	//			Physics.IgnoreCollision(component, collider);
	//		}
	//	}
	//	RolePop.Create(this);
	//	base.InitRole();
	//}

	//public void AddModule(MODULE_TYPE mt)
	//{
	//	Module module = null;
	//	switch (mt)
	//	{
	//	case MODULE_TYPE.MT_MOTION:
	//		if (base.roleGameObject.RoleAnimation == null)
	//		{
	//			base.roleGameObject.RoleBody.AddComponent<Animation>();
	//		}
	//		module = new ModAnimation(this, base.roleGameObject.RoleAnimation, base.roleGameObject.RoleController);
	//		this.modAni = (module as ModAnimation);
	//		break;
	//	case MODULE_TYPE.MT_ORGANIZATION:
	//		module = new ModOrganization(this);
	//		break;
	//	case MODULE_TYPE.MT_ATTRIBUTE:
	//		module = new ModAttribute(this);
	//		this.modAttr = (module as ModAttribute);
	//		this.SetMonsterAttribute();
	//		break;
	//	case MODULE_TYPE.MT_FIGHT:
	//		module = new ModFight(this);
	//		break;
	//	case MODULE_TYPE.MT_SKILL:
	//	{
	//		module = new ModSkillProperty(this);
	//		ModSkillProperty modSkillProperty = module as ModSkillProperty;
	//		if (modSkillProperty != null)
	//		{
	//			for (int i = 0; i < this._monsterInfo._attackSkill.Count; i++)
	//			{
	//				if (this._monsterInfo._attackSkill[i].SkillID != 0)
	//				{
	//					modSkillProperty.AddSkill(this._monsterInfo._attackSkill[i].SkillID);
	//				}
	//			}
	//			if (this._monsterInfo._skillBuff != 0)
	//			{
	//				modSkillProperty.AddSkill(this._monsterInfo._skillBuff);
	//			}
	//			if (this._monsterInfo._skillBlood != 0)
	//			{
	//				modSkillProperty.AddSkill(this._monsterInfo._skillBlood);
	//			}
	//		}
	//		break;
	//	}
	//	case MODULE_TYPE.MT_BUFF:
	//		module = new ModBuffProperty(this);
	//		this.m_cModBuff = (module as ModBuffProperty);
	//		break;
	//	case MODULE_TYPE.MT_COLLIDER:
	//		module = new ModColliderProperty(this);
	//		break;
	//	case MODULE_TYPE.MT_CONTROL_MFS:
	//		module = new ModControlMFS(base.gameObject, this);
	//		this.modMFS = (module as ModControlMFS);
	//		break;
	//	case MODULE_TYPE.MT_QTE:
	//	{
	//		module = new ModQTEProperty(this);
	//		ModQTEProperty modQTEProperty = (ModQTEProperty)module;
	//		if (this.MonInfo.QTEId != 0)
	//		{
	//			modQTEProperty.AddQTECondition(this.MonInfo.QTEId);
	//		}
	//		break;
	//	}
	//	case MODULE_TYPE.MT_AI_BEHAVIOR:
	//		module = new ModBehaviorAI(this);
	//		this.modAi = (ModBehaviorAI)module;
	//		break;
	//	case MODULE_TYPE.MT_VOICE:
	//		module = new ModVoice(this);
	//		break;
	//	}
	//	if (module != null)
	//	{
	//		this._modList.Add(module);
	//	}
	//}

	//// Token: 0x06002216 RID: 8726 RVA: 0x000E9760 File Offset: 0x000E7960
	//public void SetMonsterAttribute()
	//{
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_VIEW_RANGE, this._monsterInfo.ViewRange, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_ATTACK_RANGE, this._monsterInfo.AtkRange, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED, this._monsterInfo.MoveSpeed, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_TRUNSPEED, this._monsterInfo.TurnSpeed, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_ATTACK_INTERVAL, this._monsterInfo._attackInterval, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MAXHP, (float)this._monsterInfo.Hp, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_HP, (float)this._monsterInfo.Hp, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MAXMP, (float)this._monsterInfo.Mp, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MP, (float)this._monsterInfo.Mp, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_PHY_ATK, this._monsterInfo.PhyDamage, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MAG_ATK, this._monsterInfo.MagicDamage, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_PHY_DEF, this._monsterInfo.PhyDefense, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MAG_DEF, this._monsterInfo.MagicDefense, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_METAL_ELEMENT, this._monsterInfo.metal, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_WOOD_ELEMENT, this._monsterInfo.wood, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_WATER_ELEMENT, this._monsterInfo.water, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_FIRE_ELEMENT, this._monsterInfo.fire, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_EARTH_ELEMENT, this._monsterInfo.earth, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_PREPARE_TIME, this._monsterInfo.PrepareTime, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_ATTACK_TIMES, (float)this._monsterInfo.AttackTimes, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_CUR_ATK_TIMES, 0f, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_HMOVESPEED, this._monsterInfo.HMoveSpeed, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_BMOVESPEED, this._monsterInfo.BMoveSpeed, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_MOVESPEED_ORIGN, this._monsterInfo.MoveSpeed, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_HMOVESPEED_ORIGN, this._monsterInfo.HMoveSpeed, true);
	//	this.modAttr.SetAttributeNum(ATTRIBUTE_TYPE.ATT_BMOVESPEED_ORIGN, this._monsterInfo.BMoveSpeed, true);
	//}

	//// Token: 0x06002217 RID: 8727 RVA: 0x000E99F4 File Offset: 0x000E7BF4
	//public override string GetName()
	//{
	//	return this.MonInfo.Name;
	//}

	//// Token: 0x06002218 RID: 8728 RVA: 0x000E9A04 File Offset: 0x000E7C04
	//public override float GetTurnSpeed()
	//{
	//	ModAttribute modAttribute = base.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
	//	float num = 600f;
	//	if (modAttribute != null)
	//	{
	//		num = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_TRUNSPEED);
	//		if (num == -1f)
	//		{
	//			num = 600f;
	//		}
	//	}
	//	return num;
	//}

	//// Token: 0x06002219 RID: 8729 RVA: 0x000E9A48 File Offset: 0x000E7C48
	//public override void SetChildrenGameObj(GameObject go)
	//{
	//	base.RoleChildObj.SetRoleChild(RoleChildType.RCT_MONSTER_PHY, go);
	//	Transform transform = go.transform.FindChild("MobMesh");
	//	if (transform != null)
	//	{
	//		base.RoleChildObj.SetRoleChild(RoleChildType.RCT_MOB_MESH, transform.gameObject);
	//	}
	//	Transform transform2 = transform.transform.FindChild(this.MonInfo.RealMeshName);
	//	if (transform2 != null)
	//	{
	//		base.RoleChildObj.SetRoleChild(RoleChildType.RCT_REALY_MESH, transform2.gameObject);
	//	}
	//	Transform transform3 = transform.transform.FindChild("Bip01");
	//	if (transform3 != null)
	//	{
	//		base.RoleChildObj.SetRoleChild(RoleChildType.RCT_BONE_CHEST, transform3.gameObject);
	//		base.RoleChildObj.SetRolcChild("Bip01", transform3.gameObject);
	//	}
	//	else
	//	{
	//		transform3 = transform.transform.FindChild("Bip001");
	//		if (transform3 != null)
	//		{
	//			base.RoleChildObj.SetRoleChild(RoleChildType.RCT_BONE_CHEST, transform3.gameObject);
	//			base.RoleChildObj.SetRolcChild("Bip001", transform3.gameObject);
	//		}
	//		else if (transform2 != null)
	//		{
	//			transform3 = transform2.transform.FindChild("Bone001");
	//			if (transform3 != null)
	//			{
	//				base.RoleChildObj.SetRoleChild(RoleChildType.RCT_BONE_CHEST, transform3.gameObject);
	//			}
	//		}
	//	}
	//	Transform transform4 = RoleBaseFun.FindDescendants(base.GetTrans(), "Bip01 Head");
	//	if (transform4)
	//	{
	//		base.RoleChildObj.SetRoleChild(RoleChildType.RCT_BONE_HEAD, transform4.gameObject);
	//	}
	//	if (transform4)
	//	{
	//		base.RoleChildObj.SetRoleChild(RoleChildType.RCT_BONE_TONGUE, transform4.gameObject);
	//	}
	//	Transform transform5 = RoleBaseFun.FindDescendants(base.GetTrans(), "Bip01 Footsteps");
	//	if (transform5)
	//	{
	//		base.RoleChildObj.SetRoleChild(RoleChildType.RCT_BONE_FOOT, transform5.gameObject);
	//	}
	//}

	//// Token: 0x0600221A RID: 8730 RVA: 0x000E9C14 File Offset: 0x000E7E14
	//public override string GetHeadPath()
	//{
	//	return this.MonInfo.HeadPicPath;
	//}

	//// Token: 0x0600221B RID: 8731 RVA: 0x000E9C24 File Offset: 0x000E7E24
	//public override string GetShoutTalk()
	//{
	//	return this.MonInfo.InBattleWord;
	//}

	//// Token: 0x0600221C RID: 8732 RVA: 0x000E9C34 File Offset: 0x000E7E34
	//public override string GetFleeWord()
	//{
	//	return this.MonInfo.FleeWord;
	//}

	//// Token: 0x0600221D RID: 8733 RVA: 0x000E9C44 File Offset: 0x000E7E44
	//public override bool GetCanFlee()
	//{
	//	return this.MonInfo.Flee;
	//}

	//// Token: 0x0600221E RID: 8734 RVA: 0x000E9C54 File Offset: 0x000E7E54
	//public override RoleStaticInfo GetStaticRoleInfo()
	//{
	//	return this.MonInfo;
	//}

	//// Token: 0x0600221F RID: 8735 RVA: 0x000E9C5C File Offset: 0x000E7E5C
	//public override float GetPrepareDis()
	//{
	//	return this.MonInfo.PrepareDis;
	//}

	//// Token: 0x06002220 RID: 8736 RVA: 0x000E9C6C File Offset: 0x000E7E6C
	//public override float GetMassNumber()
	//{
	//	return this.MonInfo.MassNumber;
	//}

	//// Token: 0x06002221 RID: 8737 RVA: 0x000E9C7C File Offset: 0x000E7E7C
	//public override float FleeHpPercent()
	//{
	//	return this.MonInfo.FleeHpPercent;
	//}

	//// Token: 0x06002222 RID: 8738 RVA: 0x000E9C8C File Offset: 0x000E7E8C
	//public override float BegProbability()
	//{
	//	return this.MonInfo.BegProbability;
	//}

	//// Token: 0x06002223 RID: 8739 RVA: 0x000E9C9C File Offset: 0x000E7E9C
	//public override float HpHigh()
	//{
	//	return this.MonInfo.HpHigh;
	//}

	//// Token: 0x06002224 RID: 8740 RVA: 0x000E9CAC File Offset: 0x000E7EAC
	//public override int SkillBuff()
	//{
	//	return this.MonInfo._skillBuff;
	//}

	//// Token: 0x06002225 RID: 8741 RVA: 0x000E9CBC File Offset: 0x000E7EBC
	//public MonsterSkill GetAttackSkillByIdx(int idx)
	//{
	//	if (idx < 0 || idx >= this.MonInfo._attackSkill.Count)
	//	{
	//		return null;
	//	}
	//	return this.MonInfo._attackSkill[idx];
	//}

	//// Token: 0x06002226 RID: 8742 RVA: 0x000E9CFC File Offset: 0x000E7EFC
	//public override int SkillBlood()
	//{
	//	return this.MonInfo._skillBlood;
	//}

	//// Token: 0x06002227 RID: 8743 RVA: 0x000E9D0C File Offset: 0x000E7F0C
	//public override IdentityType Identity()
	//{
	//	return this.MonInfo.identity;
	//}

	//// Token: 0x06002228 RID: 8744 RVA: 0x000E9D1C File Offset: 0x000E7F1C
	//public override float Height()
	//{
	//	return this.MonInfo.Height;
	//}

	//// Token: 0x06002229 RID: 8745 RVA: 0x000E9D2C File Offset: 0x000E7F2C
	//public override float Distance()
	//{
	//	return this.MonInfo.Distance;
	//}

	//// Token: 0x0600222A RID: 8746 RVA: 0x000E9D3C File Offset: 0x000E7F3C
	//public override int GetBloodType()
	//{
	//	return this.MonInfo.BloodType;
	//}

	//// Token: 0x0600222B RID: 8747 RVA: 0x000E9D4C File Offset: 0x000E7F4C
	//public override void RoleProcess()
	//{
	//	base.RoleProcess();
	//}

	//// Token: 0x0600222C RID: 8748 RVA: 0x000E9D54 File Offset: 0x000E7F54
	//private void CreateSoulBall()
	//{
	//	if (this.MonInfo.identity == IdentityType.Bar)
	//	{
	//		return;
	//	}
	//	List<int> list = new List<int>();
	//	List<int> list2 = new List<int>();
	//	list.Clear();
	//	list2.Clear();
	//	list.Add(this.MonInfo.dropSoulballRuleID);
	//	list2 = DropItemManager.GetItemIdList(list);
	//	if (list2.Count == 0)
	//	{
	//		return;
	//	}
	//	int nType = list2[0];
	//	int num = list2[1];
	//	for (int i = 0; i < num; i++)
	//	{
	//		SceneManager.RoleMan.CreateSoulBall(nType, base.GetPos() + new Vector3(UnityEngine.Random.Range(0.2f, 1.5f), 0f, UnityEngine.Random.Range(0.2f, 1.5f)));
	//	}
	//}

	//// Token: 0x0600222D RID: 8749 RVA: 0x000E9E14 File Offset: 0x000E8014
	//private void CreateCorpse()
	//{
	//	List<int> itemIdList = DropItemManager.GetItemIdList(this.MonInfo.DropRuleList);
	//	if (itemIdList != null && itemIdList.Count > 0)
	//	{
	//		SceneManager.RoleMan.CreateCorpse(base.GetPos(), itemIdList);
	//	}
	//}

	//// Token: 0x0600222E RID: 8750 RVA: 0x000E9E58 File Offset: 0x000E8058
	//public override void Die(bool qte)
	//{
	//	this.Die(qte, 5f);
	//}

	//// Token: 0x0600222F RID: 8751 RVA: 0x000E9E68 File Offset: 0x000E8068
	//public override void Die(bool qte, float corpseTime)
	//{
	//	if (this._bDieCount)
	//	{
	//		base.Die(qte);
	//		if (this.MonInfo.DieScriptMod > 0)
	//		{
	//			GameData.Instance.ScrMan.Exec(this.MonInfo.DieScriptMod, this.MonInfo.DieScriptData);
	//		}
	//		SoulEffect.CreatByMonster(this);
	//		this.CreateSoulBall();
	//		if (Player.Instance != null)
	//		{
	//			Player.Instance.SystemAmbit.AddRageSoule(this.MonInfo.RageAmount);
	//			if (Player.Instance.m_cModFight.TargetRole == this)
	//			{
	//				Player.Instance.m_cModFight.TargetRole = null;
	//			}
	//		}
	//		this.CreateCorpse();
	//		this._dieTime = 10f;
	//		if (this._bNeedResetCamera)
	//		{
	//			ModCamera curPlayerCamera = SceneManager.RoleMan.GetCurPlayerCamera();
	//			if (curPlayerCamera != null)
	//			{
	//				curPlayerCamera.ReSetCamera(false);
	//			}
	//		}
	//		if (this.m_cModBuff != null)
	//		{
	//			this.m_cModBuff.DelAllBuff();
	//		}
	//		if (this.ParentRole != null)
	//		{
	//			this.ParentRole.DelRetinue(this);
	//		}
	//		this._bDie = true;
	//		this._bDieCount = false;
	//		if (this.modMFS != null && this.modMFS.ChangeState(new ControlEventDie(true, this.MonInfo.DieRule)))
	//		{
	//			Debug.Log("enter die state.......................................");
	//			this.modAi.Enable = false;
	//		}
	//	}
	//}

	//// Token: 0x06002230 RID: 8752 RVA: 0x000E9FC4 File Offset: 0x000E81C4
	//private void DestroyRoleBody(Role role)
	//{
	//	CharacterController component = base.GetTrans().GetComponent<CharacterController>();
	//	if (component != null)
	//	{
	//		component.enabled = false;
	//	}
	//	RoleBaseFun.SetColiiderEnable(role.GetTrans(), true);
	//	RoleBaseFun.SetRigidbodyEnable(role.GetTrans(), true);
	//	Rigidbody[] componentsInChildren = role.roleGameObject.RoleBody.GetComponentsInChildren<Rigidbody>(true);
	//	foreach (Rigidbody rigidbody in componentsInChildren)
	//	{
	//		rigidbody.mass = 0.1f;
	//		rigidbody.AddForce(Player.Instance.GetTrans().forward * (float)UnityEngine.Random.Range(-10, 200));
	//	}
	//}

	//// Token: 0x06002231 RID: 8753 RVA: 0x000EA06C File Offset: 0x000E826C
	//public void ChangeMeshMeterial(int meterialId)
	//{
	//	Material material = null;
	//	if (meterialId != 0)
	//	{
	//		material = (Singleton<CResourcesStaticManager>.GetInstance().GetRes(meterialId, typeof(Material)) as Material);
	//	}
	//	SkinnedMeshRenderer[] componentsInChildren = base.roleGameObject.RoleBody.GetComponentsInChildren<SkinnedMeshRenderer>(true);
	//	foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
	//	{
	//		if (material != null)
	//		{
	//			skinnedMeshRenderer.materials = new List<Material>
	//			{
	//				skinnedMeshRenderer.renderer.material,
	//				material
	//			}.ToArray();
	//		}
	//	}
	//}

	//// Token: 0x06002232 RID: 8754 RVA: 0x000EA108 File Offset: 0x000E8308
	//public void DestroyHP()
	//{
	//	if (base.MonsterHP != null)
	//	{
	//		UnityEngine.Object.Destroy(base.MonsterHP.gameObject);
	//	}
	//	if (base.MonsterHpBottom != null)
	//	{
	//		UnityEngine.Object.Destroy(base.MonsterHpBottom.gameObject);
	//	}
	//}

	//// Token: 0x06002233 RID: 8755 RVA: 0x000EA158 File Offset: 0x000E8358
	//public override void DestroyRole()
	//{
	//	base.DestroyRole();
	//	this.DestroyHP();
	//}

	//// Token: 0x06002234 RID: 8756 RVA: 0x000EA168 File Offset: 0x000E8368
	//public override bool ChangeMeshColor(Color col)
	//{
	//	GameObject goByType;
	//	if (!base.BRagdoll)
	//	{
	//		goByType = base.RoleChildObj.GetGoByType(RoleChildType.RCT_REALY_MESH);
	//	}
	//	else
	//	{
	//		goByType = base.RoleChildObj.GetGoByType(RoleChildType.RCT_REALY_MESH_R);
	//	}
	//	if (goByType != null)
	//	{
	//		goByType.renderer.material.SetColor("_Color", col);
	//		return true;
	//	}
	//	return false;
	//}

	//// Token: 0x06002235 RID: 8757 RVA: 0x000EA1C8 File Offset: 0x000E83C8
	//public override int GetDetailType()
	//{
	//	return this.MonInfo.MonsterID;
	//}

	//// Token: 0x06002236 RID: 8758 RVA: 0x000EA1D8 File Offset: 0x000E83D8
	//public override long GetWeaponIdx()
	//{
	//	if (base.roleGameObject.ModelInfo == null)
	//	{
	//		return -1L;
	//	}
	//	List<int> attackTable = base.roleGameObject.ModelInfo.AttackTable;
	//	if (attackTable.Count > 0)
	//	{
	//		return (long)attackTable[0];
	//	}
	//	return -1L;
	//}

	//// Token: 0x06002237 RID: 8759 RVA: 0x000EA220 File Offset: 0x000E8420
	//public override int GetHurtID()
	//{
	//	return this.MonInfo.HurtID;
	//}

	//// Token: 0x06002238 RID: 8760 RVA: 0x000EA230 File Offset: 0x000E8430
	//public override bool IsOutOfSpawnBox()
	//{
	//	return this.IsOutOfSpawnBox(base.GetPos());
	//}

	//// Token: 0x06002239 RID: 8761 RVA: 0x000EA240 File Offset: 0x000E8440
	//public override float GetViewRange()
	//{
	//	return this.MonInfo.ViewRange;
	//}

	//// Token: 0x0600223A RID: 8762 RVA: 0x000EA250 File Offset: 0x000E8450
	//public override bool IsOutOfSpawnBox(Vector3 pos)
	//{
	//	Ray ray = default(Ray);
	//	ray.origin = pos;
	//	ray.direction = base.SpawnInfo.position - pos;
	//	RaycastHit[] array = Physics.RaycastAll(ray.origin, ray.direction, Vector3.Distance(base.SpawnInfo.position, pos));
	//	for (int i = 0; i < array.Length; i++)
	//	{
	//		if (string.Compare(array[i].transform.transform.name, base.SpawnInfo.areaName) == 0)
	//		{
	//			return true;
	//		}
	//	}
	//	return false;
	//}

	//// Token: 0x0600223B RID: 8763 RVA: 0x000EA2F8 File Offset: 0x000E84F8
	//public override List<MonsterSkill> GetUseableSkill(int skillType)
	//{
	//	ModSkillProperty modSkillProperty = base.GetModule(MODULE_TYPE.MT_SKILL) as ModSkillProperty;
	//	if (modSkillProperty == null)
	//	{
	//		return null;
	//	}
	//	List<MonsterSkill> list = new List<MonsterSkill>();
	//	list.Clear();
	//	switch (skillType)
	//	{
	//	case 0:
	//		for (int i = 0; i < this._monsterInfo._attackSkill.Count; i++)
	//		{
	//			if (this._monsterInfo._attackSkill[i].SkillID != 0 && modSkillProperty.SkillIsReady(this._monsterInfo._attackSkill[i].SkillID))
	//			{
	//				list.Add(this._monsterInfo._attackSkill[i]);
	//			}
	//		}
	//		break;
	//	case 1:
	//		if (this._monsterInfo._skillBlood != 0 && modSkillProperty.SkillIsReady(this._monsterInfo._skillBlood))
	//		{
	//			list.Add(new MonsterSkill(this._monsterInfo._skillBlood, SkillUselRule.Init));
	//		}
	//		break;
	//	case 2:
	//		if (this._monsterInfo._skillBuff != 0 && modSkillProperty.SkillIsReady(this._monsterInfo._skillBuff))
	//		{
	//			list.Add(new MonsterSkill(this._monsterInfo._skillBuff, SkillUselRule.Init));
	//		}
	//		break;
	//	}
	//	return list;
	//}

	//// Token: 0x0600223C RID: 8764 RVA: 0x000EA444 File Offset: 0x000E8644
	//public override List<MonsterSkill> GetUseableSkill()
	//{
	//	return this.GetUseableSkill(0);
	//}

	//// Token: 0x0600223D RID: 8765 RVA: 0x000EA450 File Offset: 0x000E8650
	//public override void Input(float VerInput, float HorInput)
	//{
	//	Vector3 vector = VerInput * Singleton<ActorManager>.GetInstance().MainCamera.transform.forward + HorInput * Singleton<ActorManager>.GetInstance().MainCamera.transform.right;
	//	Vector3 vector2 = base.GetPos() + vector;
	//	Debug.DrawLine(base.GetPos() + Vector3.up, vector2, Color.white);
	//	if (vector == Vector3.zero)
	//	{
	//		this.modMFS.ChangeState(new ControlEventIdle(false));
	//	}
	//	else
	//	{
	//		this.modMFS.ChangeState(new ControlEventMoveForward(false, vector2, ACTION_INDEX.AN_RUN, 6f, true));
	//	}
	//}
}
