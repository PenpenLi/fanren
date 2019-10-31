using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

public class Buff
{
    private int m_iTypeId;

    private float m_fStartTime;

    private float m_fLastHitTime;

    private bool m_bHit;

    private BuffData m_cBuffData;

    private Role m_cRole;

    private int m_iDoubleNum;

    private List<int> m_lstEffectNow = new List<int>();

    private bool m_bEnable;

    private int m_iNowEffectId;

    public Buff(int id, Role role)
	{
		this.m_cRole = role;
		this.m_iTypeId = id;
		this.m_fStartTime = GameTime.time;
		this.m_fLastHitTime = GameTime.time;
		this.m_bHit = false;
		this.m_cBuffData = Singleton<BuffTableManager>.GetInstance().GetBuffData(this.m_iTypeId);
		this.m_bEnable = true;
		this.m_iDoubleNum = 1;
		this.Init();
	}

	public int Id
	{
		get
		{
			return this.m_iTypeId;
		}
	}

	public int DoubleNum
	{
		get
		{
			return this.m_iDoubleNum;
		}
	}

	public string ToolTip
	{
		get
		{
			return this.m_cBuffData.ToolTip;
		}
	}

	private void Init()
	{
		this.m_lstEffectNow.Clear();
		for (int i = 0; i < 3; i++)
		{
			string bone = this.m_cBuffData.GetBone(i);
			int effect = this.m_cBuffData.GetEffect(i);
			Transform transform;
			if (bone == " ")
			{
				transform = this.m_cRole.GetTrans();
			}
			else
			{
				transform = this.m_cRole.GetTrans().FindChild(bone);
			}
			if (!(transform == null))
			{
				if (effect != 0)
				{
					CEffectData effectInfo = Singleton<EffectTableManager>.GetInstance().GetEffectInfo(effect);
					if (effectInfo.Type == 2)
					{
						if (transform == this.m_cRole.GetTrans())
						{
							this.m_iNowEffectId = this.m_cRole.roleGameObject.BindEffect(CHILD_EFFECT_POINT.TOP, effect, this.m_cBuffData.GetOffsetPos(i), this.m_cBuffData.GetOffsetRotate(i));
							GameObject @object = Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId);
							if (@object != null && this.m_cRole.GetTrans().localScale.x != 1f && effect == 258)
							{
								float num = this.m_cRole.GetTrans().localScale.x / 1f;
								@object.transform.localScale = new Vector3(@object.transform.localScale.x * num, @object.transform.localScale.y * num, @object.transform.localScale.z * num);
							}
						}
						else
						{
							this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectBind(effect, transform.gameObject);
							GameObject object2 = Singleton<ActorManager>.GetInstance().GetObject(this.m_iNowEffectId);
							if (object2 != null)
							{
								object2.transform.Rotate(this.m_cBuffData.GetOffsetRotate(i));
								object2.transform.Translate(this.m_cBuffData.GetOffsetPos(i));
								if (this.m_cRole.GetTrans().localScale.x != 1f && effect == 258)
								{
									float num2 = this.m_cRole.GetTrans().localScale.x / 1f;
									object2.transform.localScale = new Vector3(object2.transform.localScale.x * num2, object2.transform.localScale.y * num2, object2.transform.localScale.z * num2);
								}
							}
						}
					}
					if (effectInfo.Type == 1)
					{
						this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectFixure(effect, this.m_cRole.GetPos(), this.m_cRole.GetTrans().rotation);
					}
					this.m_lstEffectNow.Add(this.m_iNowEffectId);
				}
			}
		}
		int value = this.GetValue(BUFF_VALUE_TYPE.BIND);
		if (value != 0)
		{
		}
		value = this.GetValue(BUFF_VALUE_TYPE.NO_BREAK);
		if (value != 0)
		{
			ModFight modFight = this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
			modFight.StrongBuff(true);
		}
		value = this.GetValue(BUFF_VALUE_TYPE.INVINCIBLE);
		if (value != 0)
		{
			ModFight modFight2 = this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
			modFight2.Invincible(true);
		}
		value = this.GetValue(BUFF_VALUE_TYPE.NONO);
		if (value != 0)
		{
			ModControlMFS modControlMFS = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			modControlMFS.ChangeState(new ControlEventBuff(false, 100));
		}
		value = this.GetValue(BUFF_VALUE_TYPE.SLEEP);
		if (value != 0)
		{
			ModControlMFS modControlMFS2 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			modControlMFS2.ChangeState(new ControlEventBuff(false, 100));
		}
		value = this.GetValue(BUFF_VALUE_TYPE.DIZZY);
		if (value != 0)
		{
			ModControlMFS modControlMFS3 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			modControlMFS3.ChangeState(new ControlEventBuff(false, 100));
		}
		value = this.GetValue(BUFF_VALUE_TYPE.FALL_DOWN);
		if (value != 0)
		{
			ModControlMFS modControlMFS4 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			modControlMFS4.ChangeState(new ControlEventBuff(false, 380));
		}
		value = this.GetValue(BUFF_VALUE_TYPE.FROZEN);
		if (value != 0)
		{
			ModControlMFS modControlMFS5 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			modControlMFS5.ChangeState(new ControlEventBuff(false, 0));
			ModAnimation modAnimation = (ModAnimation)this.m_cRole.GetModule(MODULE_TYPE.MT_MOTION);
			if (modAnimation != null)
			{
				//modAnimation.StopAnimation();
			}
		}
		value = this.GetValue(BUFF_VALUE_TYPE.DEL_WALK_SPEED);
		if (value != 0)
		{
			if (this.m_cRole._roleType != ROLE_TYPE.RT_PLAYER)
			{
				ModAttribute modAttribute = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
				//modAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MOVESPEED, -((float)value / 100f));
				//modAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_HMOVESPEED, -((float)value / 100f));
				//modAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_BMOVESPEED, -((float)value / 100f));
			}
			else
			{
				ModAttribute modAttribute2 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
				//modAttribute2.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MOVESPEED, -((float)value / 100f));
			}
		}
		value = this.GetValue(BUFF_VALUE_TYPE.CONTROL_MONSTER);
		if (value != 0)
		{
			Transform trans = this.m_cRole.GetTrans();
			this.m_iNowEffectId = this.m_cRole.roleGameObject.BindEffect(CHILD_EFFECT_POINT.TOP, 653, Vector3.zero, Vector3.zero);
			//ModOrganization modOrganization = this.m_cRole.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
			//modOrganization.OrgType = ORG_TYPE.OT_PLAYER;
		}
		value = this.GetValue(BUFF_VALUE_TYPE.CRITICAL_HIT);
		if (value != 0)
		{
			ModAttribute modAttribute3 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			//modAttribute3.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_CRITCHANCE, 8f);
		}
		value = this.GetValue(BUFF_VALUE_TYPE.ADD_ATTACK_PER);
		if (value != 0)
		{
		}
		value = this.GetValue(BUFF_VALUE_TYPE.PHY_DEF);
		if (value != 0)
		{
		}
		value = this.GetValue(BUFF_VALUE_TYPE.MAG_DEF);
		if (value != 0)
		{
			ModAttribute modAttribute4 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			//modAttribute4.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAG_DEF, (float)(value / 100));
		}
		value = this.GetValue(BUFF_VALUE_TYPE.TRANSPARENT);
		if (value != 0)
		{
			SkinnedMeshRenderer[] componentsInChildren = this.m_cRole.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
			{
				skinnedMeshRenderer.material.shader = Shader.Find("BY-FR/ShaderfoTransAndGloss");
				Color color = default(Color);
				color.a = 0.5f;
				skinnedMeshRenderer.material.color = color;
			}
		}
		value = this.GetValue(BUFF_VALUE_TYPE.ATT_FEEBLE);
		if (value != 0)
		{
			float num3 = (float)value;
			ModAttribute modAttribute5 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			//modAttribute5.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_FEEBLE, num3 / 100f);
		}
		value = this.GetValue(BUFF_VALUE_TYPE.MATERIAL_BING);
		if (value != 0)
		{
			ModFight modFight3 = this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
			modFight3.StrongBuff(true);
			ModControlMFS modControlMFS6 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			modControlMFS6.ChangeState(new ControlEventBuff(false, 0));
			ModAnimation modAnimation2 = (ModAnimation)this.m_cRole.GetModule(MODULE_TYPE.MT_MOTION);
			if (modAnimation2 != null)
			{
				//modAnimation2.StopAnimation();
			}
			//Material item = Singleton<CResourcesStaticManager>.GetInstance().GetRes(value, typeof(Material)) as Material;
			SkinnedMeshRenderer[] componentsInChildren2 = this.m_cRole.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in componentsInChildren2)
			{
				skinnedMeshRenderer2.materials = new List<Material>
				{
					//skinnedMeshRenderer2.renderer.material,
					//item
				}.ToArray();
			}
			MeshRenderer[] componentsInChildren3 = this.m_cRole.gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren3)
			{
				meshRenderer.materials = new List<Material>
				{
					//meshRenderer.renderer.material,
					//item
				}.ToArray();
			}
		}
	}

	// Token: 0x060025A6 RID: 9638 RVA: 0x000FC748 File Offset: 0x000FA948
	public void Destory()
	{
		if (this.m_iTypeId == 242)
		{
			SingletonMono<EffectManager>.GetInstance().AddEffectFixure(520, this.m_cRole.GetPos(), this.m_cRole.GetTrans().rotation);
		}
		if (this.m_iTypeId == 266)
		{
			SingletonMono<EffectManager>.GetInstance().AddEffectFixure(610, this.m_cRole.GetPos(), this.m_cRole.GetTrans().rotation);
		}
		float num = (float)this.GetValue(BUFF_VALUE_TYPE.DEL_WALK_SPEED);
		if (num != 0f)
		{
			if (this.m_cRole._roleType != ROLE_TYPE.RT_PLAYER)
			{
				ModAttribute modAttribute = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
				//modAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MOVESPEED, num / 100f);
				//modAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_HMOVESPEED, num / 100f);
				//modAttribute.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_BMOVESPEED, num / 100f);
			}
			else
			{
				ModAttribute modAttribute2 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
				//modAttribute2.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MOVESPEED, num / 100f);
			}
		}
		float num2 = (float)this.GetValue(BUFF_VALUE_TYPE.FROZEN);
		if (num2 != 0f)
		{
			int disEffect = this.GetDisEffect(BUFF_VALUE_TYPE.FROZEN);
			SingletonMono<EffectManager>.GetInstance().AddEffectFixure(disEffect, this.m_cRole.GetPos(), this.m_cRole.GetTrans().rotation);
			ModControlMFS modControlMFS = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			if (modControlMFS != null)
			{
				modControlMFS.ChangeState(new ControlEventIdle(true));
			}
		}
		float num3 = (float)this.GetValue(BUFF_VALUE_TYPE.DIZZY);
		if (num3 != 0f)
		{
			ModControlMFS modControlMFS2 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			if (modControlMFS2 != null)
			{
				modControlMFS2.ChangeState(new ControlEventIdle(true));
			}
		}
		float num4 = (float)this.GetValue(BUFF_VALUE_TYPE.SLEEP);
		if (num4 != 0f)
		{
			ModControlMFS modControlMFS3 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			if (modControlMFS3 != null)
			{
				modControlMFS3.ChangeState(new ControlEventIdle(true));
			}
		}
		float num5 = (float)this.GetValue(BUFF_VALUE_TYPE.BIND);
		if (num5 != 0f)
		{
			ModControlMFS modControlMFS4 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			if (modControlMFS4 != null)
			{
				modControlMFS4.ChangeState(new ControlEventIdle(true));
			}
		}
		float num6 = (float)this.GetValue(BUFF_VALUE_TYPE.NO_BREAK);
		if (num6 != 0f)
		{
			ModFight modFight = this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
			modFight.StrongBuff(false);
		}
		float num7 = (float)this.GetValue(BUFF_VALUE_TYPE.INVINCIBLE);
		if (num7 != 0f)
		{
			ModFight modFight2 = this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
			modFight2.Invincible(false);
		}
		float num8 = (float)this.GetValue(BUFF_VALUE_TYPE.CONTROL_MONSTER);
		if (num8 != 0f)
		{
			SingletonMono<EffectManager>.GetInstance().Delete(this.m_iNowEffectId);
			//ModOrganization modOrganization = this.m_cRole.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
			//modOrganization.OrgType = ORG_TYPE.OT_MONSTER;
		}
		float num9 = (float)this.GetValue(BUFF_VALUE_TYPE.CRITICAL_HIT);
		if (num9 != 0f)
		{
			ModAttribute modAttribute3 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			//modAttribute3.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_CRITCHANCE, -8f);
		}
		float num10 = (float)this.GetValue(BUFF_VALUE_TYPE.ADD_ATTACK_PER);
		if (num10 != 0f)
		{
		}
		float num11 = (float)this.GetValue(BUFF_VALUE_TYPE.PHY_DEF);
		if (num11 != 0f)
		{
		}
		float num12 = (float)this.GetValue(BUFF_VALUE_TYPE.MAG_DEF);
		if (num12 != 0f)
		{
			ModAttribute modAttribute4 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			//modAttribute4.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_MAG_ATK, -num12 / 100f);
		}
		float num13 = (float)this.GetValue(BUFF_VALUE_TYPE.XUE_LONG);
		if (num13 != 0f)
		{
			ModAttribute modAttribute5 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			ModBuffProperty modBuffProperty = (ModBuffProperty)this.m_cRole.GetModule(MODULE_TYPE.MT_BUFF);
			modAttribute5.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, modBuffProperty.GetLongHP * (num13 / 100f), true);
			Transform trans = this.m_cRole.GetTrans();
			this.m_cRole.roleGameObject.BindEffect(CHILD_EFFECT_POINT.TOP, 239, Vector3.zero, Vector3.zero);
			modBuffProperty.RestLongHP();
		}
		float num14 = (float)this.GetValue(BUFF_VALUE_TYPE.TRANSPARENT);
		if (num14 != 0f)
		{
			SkinnedMeshRenderer[] componentsInChildren = this.m_cRole.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
			{
				skinnedMeshRenderer.material.shader = Shader.Find("BY-FR/ShaderforNewGloss");
				Color color = new Color(1f, 1f, 1f, 1f);
				skinnedMeshRenderer.material.color = color;
			}
			GameData.Instance.ScrMan.Exec(this.m_cBuffData.ScriptModID, this.m_cBuffData.ScriptDataID);
			GameData.Instance.ScrMan.Exec(this.m_cBuffData.ScriptModID, this.m_cBuffData.ScriptDataIDi);
		}
		float num15 = (float)this.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE);
		if (num15 != 0f)
		{
			int disEffect2 = this.GetDisEffect(BUFF_VALUE_TYPE.ABSORB_DAMAGE);
			int num16;
			if (disEffect2 == 472 || disEffect2 == 156)
			{
				num16 = SingletonMono<EffectManager>.GetInstance().AddEffectFixure(disEffect2, this.m_cRole.GetPos(), Quaternion.identity);
				EffectBase effectById = SingletonMono<EffectManager>.GetInstance().GetEffectById(num16);
				if (effectById != null)
				{
					effectById.ColliderProperty.SetCallBack(new EffectColliderProperty.ColliderCallBack(this.EffectCallBack));
					effectById.ColliderProperty.Start(null, 0);
				}
			}
			else
			{
				num16 = this.m_cRole.roleGameObject.BindEffect(CHILD_EFFECT_POINT.TOP, disEffect2, Vector3.zero, Vector3.zero);
			}
			GameObject @object = Singleton<ActorManager>.GetInstance().GetObject(num16);
			if (this.m_cRole.GetTrans().localScale.x != 1f && disEffect2 == 259)
			{
				float num17 = this.m_cRole.GetTrans().localScale.x / 1f;
				@object.transform.localScale = new Vector3(@object.transform.localScale.x * num17, @object.transform.localScale.y * num17, @object.transform.localScale.z * num17);
			}
		}
		float num18 = (float)this.GetValue(BUFF_VALUE_TYPE.ATT_FEEBLE);
		if (num18 != 0f)
		{
			ModAttribute modAttribute6 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			//modAttribute6.UpdateAttributePercentByBase(ATTRIBUTE_TYPE.ATT_FEEBLE, -num18 / 100f);
		}
		float num19 = (float)this.GetValue(BUFF_VALUE_TYPE.MATERIAL_BING);
		if (num19 != 0f)
		{
			ModFight modFight3 = this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
			modFight3.StrongBuff(false);
			int disEffect3 = this.GetDisEffect(BUFF_VALUE_TYPE.MATERIAL_BING);
			Transform transform = this.m_cRole.GetTrans().FindChild("MobMesh/Bip001");
			if (transform != null)
			{
				SingletonMono<EffectManager>.GetInstance().AddEffectFixure(disEffect3, transform.position, Quaternion.identity);
			}
			ModControlMFS modControlMFS5 = (ModControlMFS)this.m_cRole.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
			if (modControlMFS5 != null)
			{
				modControlMFS5.ChangeState(new ControlEventIdle(true));
			}
			ModFight modFight4 = this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight;
			//modFight4.ChangeToHurtState(new FightInfo
			//{
			//	hurtBev = 1
			//});
			SkinnedMeshRenderer[] componentsInChildren2 = this.m_cRole.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in componentsInChildren2)
			{
				skinnedMeshRenderer2.materials = new List<Material>
				{
					//skinnedMeshRenderer2.renderer.material
				}.ToArray();
			}
			MeshRenderer[] componentsInChildren3 = this.m_cRole.gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer meshRenderer in componentsInChildren3)
			{
				meshRenderer.materials = new List<Material>
				{
					//meshRenderer.renderer.material
				}.ToArray();
			}
		}
		foreach (int curEffectID in this.m_lstEffectNow)
		{
			SingletonMono<EffectManager>.GetInstance().Delete(curEffectID);
		}
	}

	// Token: 0x060025A7 RID: 9639 RVA: 0x000FCFC0 File Offset: 0x000FB1C0
	private void EffectCallBack(object arg, object arg1)
	{
		Collider collider = arg1 as Collider;
		//Role roleScriptFromGo = RoleBaseFun.GetRoleScriptFromGo(collider.gameObject);
		//if (roleScriptFromGo != null && roleScriptFromGo._roleType != this.m_cRole._roleType && roleScriptFromGo._roleType != ROLE_TYPE.RT_NPC)
		//{
		//	ModAttribute modAttribute = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
		//	float num = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP) * 0.3f;
		//	ModFight modFight = (ModFight)roleScriptFromGo.GetModule(MODULE_TYPE.MT_FIGHT);
		//	FightInfo fightInfo = new FightInfo();
		//	if (this.m_cRole != null)
		//	{
		//		fightInfo._role = this.m_cRole;
		//		if (this.m_cRole._roleType == ROLE_TYPE.RT_PLAYER)
		//		{
		//			fightInfo._damage = num * -1f;
		//		}
		//		if (this.m_cRole._roleType == ROLE_TYPE.RT_MONSTER)
		//		{
		//			fightInfo._damage = -1f;
		//		}
		//	}
		//	fightInfo._fightType = FightInfo.FightType.FT_MAG;
		//	fightInfo.hurtBev = 2;
		//	fightInfo.attackPoint = this.m_cRole.GetPos();
		//	fightInfo.screenShakeID = 1;
		//	fightInfo.timeScaleID = 1;
		//	modFight.Hurt(fightInfo, (ACTION_INDEX)385);
		//	Transform transform = roleScriptFromGo.GetTrans().FindChild("MobMesh/Bip001");
		//	if (transform == null)
		//	{
		//		SingletonMono<EffectManager>.GetInstance().AddEffectBind(313, transform.gameObject);
		//	}
		//}
	}

	public void Stop()
	{
		this.m_bEnable = false;
	}

	public bool Update()
	{
		if (this.IsOver())
		{
			//if (Singleton<EZGUIManager>.GetInstance().GetGUI("BuffGUI") != null)
			//{
			//	Singleton<EZGUIManager>.GetInstance().GetGUI<BuffGUI>().RemoveBuff(this);
			//}
			return false;
		}
		if (this.m_cBuffData.IntervalHitTime != 0f && this.IsHit())
		{
			for (int i = 0; i < 4; i++)
			{
				int valueType = this.m_cBuffData.GetValueType(i);
				if (valueType == 1)
				{
				}
				if (valueType == 5)
				{
					ModAttribute modAttribute = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
					float attributeValue = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP);
					float value = attributeValue * (float)this.m_cBuffData.GetValue(0) / 100f;
					modAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, value, true);
				}
				if (valueType == 2)
				{
					int disEffect = this.GetDisEffect(BUFF_VALUE_TYPE.DEL_HP);
					if (disEffect != 0)
					{
						//this.m_cRole.roleGameObject.AddMaterialeffect(disEffect, 0.1f);
					}
					ModAttribute modAttribute2 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
					ModBuffProperty modBuffProperty = (ModBuffProperty)this.m_cRole.GetModule(MODULE_TYPE.MT_BUFF);
					if (this.m_cBuffData.Overlying)
					{
						if (this.m_iDoubleNum < this.m_cBuffData.MaxOverlyingNum)
						{
							float num = (float)(this.m_cBuffData.GetValue(0) * this.m_iDoubleNum);
							if (modBuffProperty.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE) != 0)
							{
								modBuffProperty.AddAbsorbDamage(Mathf.Abs(num), null, null);
							}
							else if (num < 0f)
							{
								ModFight modFight = (ModFight)this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT);
								if (!modFight.IsInvincible)
								{
									//modFight.Hurt(new FightInfo
									//{
									//	_damage = num * -1f
									//});
								}
							}
							else
							{
								modAttribute2.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, num, true);
							}
						}
						if (this.m_iDoubleNum >= this.m_cBuffData.MaxOverlyingNum && this.m_cBuffData.ReachNum == 0)
						{
							float num2 = (float)(this.m_cBuffData.GetValue(0) * this.m_iDoubleNum);
							if (modBuffProperty.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE) != 0)
							{
								modBuffProperty.AddAbsorbDamage(Mathf.Abs(num2), null, null);
							}
							else if (num2 < 0f)
							{
								ModFight modFight2 = (ModFight)this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT);
								//modFight2.Hurt(new FightInfo
								//{
								//	_damage = num2 * -1f
								//});
								Debug.Log("hit1111111111");
							}
							else
							{
								modAttribute2.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, (float)(this.m_cBuffData.GetValue(0) * this.m_iDoubleNum), true);
							}
						}
						if (this.m_iDoubleNum >= this.m_cBuffData.MaxOverlyingNum && this.m_cBuffData.ReachNum != 0)
						{
							this.Stop();
						}
					}
					else
					{
						float num3 = (float)this.m_cBuffData.GetValue(0);
						if (modBuffProperty.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE) != 0)
						{
							modBuffProperty.AddAbsorbDamage(Mathf.Abs(num3), null, null);
						}
						else if (num3 < 0f)
						{
							ModFight modFight3 = (ModFight)this.m_cRole.GetModule(MODULE_TYPE.MT_FIGHT);
							//modFight3.Hurt(new FightInfo
							//{
							//	_damage = num3 * -1f
							//});
						}
						else
						{
							modAttribute2.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, (float)this.m_cBuffData.GetValue(0), true);
						}
					}
				}
				if (valueType == 6)
				{
					ModAttribute modAttribute3 = this.m_cRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
					float attributeValue2 = modAttribute3.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP);
					float value2 = -1f * attributeValue2 * (float)this.m_cBuffData.GetValue(0) / 100f;
					modAttribute3.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, value2, true);
				}
				if (valueType == 9)
				{
				}
				if (valueType == 10)
				{
				}
				if (valueType == 14)
				{
				}
				if (valueType == 11)
				{
				}
				if (valueType == 15)
				{
				}
				if (valueType == 18)
				{
				}
			}
		}
		return true;
	}

	// Token: 0x060025AA RID: 9642 RVA: 0x00019709 File Offset: 0x00017909
	public bool IsOver()
	{
		return !this.m_bEnable || this.m_cBuffData == null || GameTime.time - this.m_fStartTime > this.m_cBuffData.TotalHitTime;
	}

	// Token: 0x060025AB RID: 9643 RVA: 0x00019740 File Offset: 0x00017940
	public bool IsBuff()
	{
		return this.m_cBuffData.IsBuff;
	}

	// Token: 0x060025AC RID: 9644 RVA: 0x00019755 File Offset: 0x00017955
	public bool IsMedicine()
	{
		return this.m_cBuffData.IsMedicine;
	}

	// Token: 0x060025AD RID: 9645 RVA: 0x0001976A File Offset: 0x0001796A
	public bool IsOverlying()
	{
		return this.m_cBuffData.Overlying;
	}

	// Token: 0x060025AE RID: 9646 RVA: 0x0001977F File Offset: 0x0001797F
	public int ReachNum()
	{
		if (this.m_cBuffData.ReachNum != 0)
		{
			return this.m_cBuffData.ReachNum;
		}
		return 0;
	}

	// Token: 0x060025AF RID: 9647 RVA: 0x0001979E File Offset: 0x0001799E
	public int GetMaxOverlyingNum()
	{
		if (this.m_cBuffData.MaxOverlyingNum != 0)
		{
			return this.m_cBuffData.MaxOverlyingNum;
		}
		return 0;
	}

	// Token: 0x060025B0 RID: 9648 RVA: 0x000197BD File Offset: 0x000179BD
	public float GetBuffTime()
	{
		if (this.m_cBuffData.TotalHitTime != 0f)
		{
			return this.m_cBuffData.TotalHitTime;
		}
		return 0f;
	}

	// Token: 0x060025B1 RID: 9649 RVA: 0x000FD4E8 File Offset: 0x000FB6E8
	public int GetEffect(BUFF_VALUE_TYPE bvy)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (this.m_cBuffData.GetValueType(i) == (int)bvy)
			{
				num += this.m_cBuffData.GetEffect(i);
			}
		}
		return num;
	}

	// Token: 0x060025B2 RID: 9650 RVA: 0x000FD52C File Offset: 0x000FB72C
	public int GetDisEffect(BUFF_VALUE_TYPE bvy)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (this.m_cBuffData.GetValueType(i) == (int)bvy)
			{
				num += this.m_cBuffData.GetDisEffect(i);
			}
		}
		return num;
	}

	// Token: 0x060025B3 RID: 9651 RVA: 0x000197E5 File Offset: 0x000179E5
	public void Reset()
	{
		this.m_fStartTime = GameTime.time;
		this.m_fLastHitTime = GameTime.time;
	}

	// Token: 0x060025B4 RID: 9652 RVA: 0x000197FD File Offset: 0x000179FD
	public void ReDouble()
	{
		this.m_iDoubleNum++;
		this.Reset();
	}

	private bool IsHit()
	{
		float num = GameTime.time - this.m_fLastHitTime;
		if (num >= this.m_cBuffData.IntervalHitTime)
		{
			this.m_bHit = false;
			this.m_fLastHitTime = GameTime.time;
		}
		if (!this.m_bHit)
		{
			this.m_bHit = true;
			return true;
		}
		return false;
	}

	public bool IsShowIcon()
	{
		return this.m_cBuffData.Show;
	}

	public string GetToolTip()
	{
		return this.m_cBuffData.ToolTip;
	}

	public string GetIconPath()
	{
		return this.m_cBuffData.IconPath;
	}

	public int GetValue(BUFF_VALUE_TYPE bvy)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (this.m_cBuffData.GetValueType(i) == (int)bvy)
			{
				num += this.m_cBuffData.GetValue(i);
			}
		}
		return num;
	}

	public int GetMinValue(BUFF_VALUE_TYPE bvy)
	{
		int num = 268435455;
		for (int i = 0; i < 4; i++)
		{
			if (this.m_cBuffData.GetValueType(i) == (int)bvy && num > this.m_cBuffData.GetValue(i))
			{
				num = this.m_cBuffData.GetValue(i);
			}
		}
		return num;
	}

	public int GetMaxValue(BUFF_VALUE_TYPE bvy)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (this.m_cBuffData.GetValueType(i) == (int)bvy && num < this.m_cBuffData.GetValue(i))
			{
				num = this.m_cBuffData.GetValue(i);
			}
		}
		return num;
	}
}
