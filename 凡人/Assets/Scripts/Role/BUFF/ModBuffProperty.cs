using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

public class ModBuffProperty : Module
{
    private Dictionary<int, Buff> m_mapBuffs = new Dictionary<int, Buff>();

    private float m_fAbsorbDamage;

    private int m_fAbsorbCount;

    private float m_fAbsorbHp;

    private float m_fAbsorLongHP;

    private int m_iNowEffectId;

    public ModBuffProperty(Role role)
	{
		this._role = role;
		base.ModType = MODULE_TYPE.MT_BUFF;
	}

	public float GetLongHP
	{
		get
		{
			return this.m_fAbsorLongHP;
		}
	}

	public void AddAbsorbDamage(float damage, FightInfo AttObj, Role srole)
	{
		if (AttObj == null || srole == null)
		{
			return;
		}
		this.m_fAbsorbDamage += damage;
		if (this.ContainBuff(110))
		{
			SingletonMono<EffectManager>.GetInstance().AddEffectBind(127, this._role.GetTrans().gameObject);
		}
		if (this.ContainBuff(112))
		{
			ModBuffProperty modBuffProperty = (ModBuffProperty)AttObj._role.GetModule(MODULE_TYPE.MT_BUFF);
			modBuffProperty.AddBuff(273);
		}
		if (this.ContainBuff(113))
		{
			float num = damage * 0.1f;
			ModFight modFight = (ModFight)AttObj._role.GetModule(MODULE_TYPE.MT_FIGHT);
			FightInfo fightInfo = new FightInfo();
			fightInfo._role = srole;
			fightInfo._damage = -1f * num;
			fightInfo._fightType = FightInfo.FightType.FT_MAG;
			fightInfo.hurtBev = 3;
			//modFight.Hurt(fightInfo, ACTION_INDEX.AN_NONE);
			fightInfo.hurtPoint = srole.GetPos();
			Transform transform = AttObj._role.GetTrans().FindChild("MobMesh/Bip001");
			if (transform != null)
			{
				SingletonMono<EffectManager>.GetInstance().AddEffectBind(155, transform.gameObject);
			}
		}
		if (this.ContainBuff(241))
		{
			//SingletonMono<BulletTimeController>.GetInstance().ChangeTimeScale(6);
			SingletonMono<EffectManager>.GetInstance().AddEffectBind(512, this._role.GetTrans().gameObject);
			SingletonMono<EffectManager>.GetInstance().AddEffectBind(313, AttObj._role.GetTrans().FindChild("MobMesh/Bip001").gameObject);
		}
		float num2;
		if ((float)this.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE) < 100f)
		{
			ModAttribute modAttribute = srole.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
			float attributeValue = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP);
			num2 = attributeValue * ((float)this.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE) / 100f);
		}
		else
		{
			num2 = (float)this.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE);
		}
		if (this.m_fAbsorbDamage >= num2)
		{
			int disEffect = this.GetDisEffect(BUFF_VALUE_TYPE.ABSORB_DAMAGE);
			if (disEffect != 0)
			{
				CEffectData effectInfo = Singleton<EffectTableManager>.GetInstance().GetEffectInfo(disEffect);
				if (effectInfo.Type == 2)
				{
					this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectBind(disEffect, this._role.GetTrans().gameObject);
				}
				else
				{
					this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectFixure(disEffect, this._role.GetPos(), this._role.GetTrans().rotation);
				}
			}
			if (this.ContainBuff(112))
			{
				//List<Role> nearestEnmitys = SceneManager.RoleMan.GetNearestEnmitys(this._role, this._role.GetPos(), 3f);
				//foreach (Role role in nearestEnmitys)
				//{
				//	ModBuffProperty modBuffProperty2 = (ModBuffProperty)role.GetModule(MODULE_TYPE.MT_BUFF);
				//	modBuffProperty2.AddBuff(281);
				//}
			}
			if (this.ContainBuff(113))
			{
				//List<Role> nearestEnmitys2 = SceneManager.RoleMan.GetNearestEnmitys(this._role, this._role.GetPos(), 10f);
				//foreach (Role role2 in nearestEnmitys2)
				//{
				//	ModBuffProperty modBuffProperty3 = (ModBuffProperty)role2.GetModule(MODULE_TYPE.MT_BUFF);
				//	modBuffProperty3.AddBuff(120);
				//}
			}
			this.CleaAbsorbDamage();
			foreach (Buff buff in this.m_mapBuffs.Values)
			{
				if (buff.GetValue(BUFF_VALUE_TYPE.ABSORB_DAMAGE) != 0)
				{
					buff.Stop();
				}
			}
		}
	}

	public void AddAbsorbCount(float damage, FightInfo AttObj, Role srole)
	{
		if (AttObj == null || srole == null)
		{
			return;
		}
		this.m_fAbsorbCount++;
		int value = this.GetValue(BUFF_VALUE_TYPE.COUNT);
		if (this.m_fAbsorbCount >= value)
		{
			this.m_fAbsorbCount = 0;
			foreach (Buff buff in this.m_mapBuffs.Values)
			{
				if (buff.GetValue(BUFF_VALUE_TYPE.COUNT) != 0)
				{
					buff.Stop();
				}
			}
		}
		if (this.ContainBuff(251))
		{
			//SingletonMono<BulletTimeController>.GetInstance().ChangeTimeScale(6);
			SingletonMono<EffectManager>.GetInstance().AddEffectBind(512, this._role.GetTrans().gameObject);
			SingletonMono<EffectManager>.GetInstance().AddEffectBind(313, AttObj._role.GetTrans().FindChild("MobMesh/Bip001").gameObject);
			ModFight modFight = (ModFight)AttObj._role.GetModule(MODULE_TYPE.MT_FIGHT);
			//modFight.Hurt(new FightInfo
			//{
			//	_role = srole,
			//	_damage = damage * -0.5f,
			//	_fightType = FightInfo.FightType.FT_MAG,
			//	hurtBev = 3
			//}, ACTION_INDEX.AN_NONE);
		}
	}

	public void addAttackHp(float damage)
	{
		float f = damage * ((float)this.GetValue(BUFF_VALUE_TYPE.ATTACK_HP) / 100f);
		ModAttribute modAttribute = this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
		modAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, Mathf.Abs(f), true);
	}

	public void addAttackBing(FightInfo AttObj)
	{
		if (AttObj == null)
		{
			return;
		}
		//List<Role> nearestEnmitys = SceneManager.RoleMan.GetNearestEnmitys(AttObj._role, AttObj._role.GetPos(), 2f);
		//foreach (Role role in nearestEnmitys)
		//{
		//	ModBuffProperty modBuffProperty = (ModBuffProperty)role.GetModule(MODULE_TYPE.MT_BUFF);
		//	if (modBuffProperty != null)
		//	{
		//		modBuffProperty.AddBuff(209);
		//	}
		//}
		ModBuffProperty modBuffProperty2 = (ModBuffProperty)AttObj._role.GetModule(MODULE_TYPE.MT_BUFF);
		if (modBuffProperty2.ContainBuff(210))
		{
			modBuffProperty2.DelBuff(210);
		}
	}

	public void addBloodBladeAttackHp(float damage)
	{
		ModAttribute modAttribute = this._role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
		float num = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP) * ((float)this.GetValue(BUFF_VALUE_TYPE.BLOOD_BLADE) / 100f);
		float num2 = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXHP) * ((float)this.GetValue(BUFF_VALUE_TYPE.BLOOD_BLADE) / 500f);
		this.m_fAbsorbHp += num2;
		if (this.m_fAbsorbHp >= num)
		{
			this.m_fAbsorbHp = 0f;
			foreach (Buff buff in this.m_mapBuffs.Values)
			{
				if (buff.GetValue(BUFF_VALUE_TYPE.BLOOD_BLADE) != 0)
				{
					buff.Stop();
				}
			}
		}
		else
		{
			modAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, Mathf.Abs(num2), true);
		}
	}

	public void addBlood(float damage)
	{
		this.m_fAbsorLongHP += damage;
	}

	public void RestLongHP()
	{
		this.m_fAbsorLongHP = 0f;
	}

	public void addDamageBack(float damage, FightInfo AttObj)
	{
		float num = damage * ((float)this.GetValue(BUFF_VALUE_TYPE.DAMAGE_BACK) / 100f);
		ModFight modFight = (ModFight)AttObj._role.GetModule(MODULE_TYPE.MT_FIGHT);
		//modFight.Hurt(new FightInfo
		//{
		//	_role = this._role,
		//	_damage = -1f * num,
		//	_fightType = FightInfo.FightType.FT_MAG,
		//	hurtBev = 3
		//}, ACTION_INDEX.AN_NONE);
	}

	public void addChainHurt(float damge, Role role, FightInfo AttObj)
	{
		//List<Role> nearestParty = SceneManager.RoleMan.GetNearestParty(role, role.GetPos(), 20f);
		//foreach (Role role2 in nearestParty)
		//{
		//	ModBuffProperty modBuffProperty = (ModBuffProperty)role2.GetModule(MODULE_TYPE.MT_BUFF);
		//	if (modBuffProperty.ContainBuff(227))
		//	{
		//		ModAttribute modAttribute = role2.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
		//		modAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_HP, -1f * damge, true);
		//	}
		//}
	}

	public void addFireBlade(FightInfo AttObj)
	{
		//List<Role> nearestEnmitys = SceneManager.RoleMan.GetNearestEnmitys(AttObj._role);
		//foreach (Role role in nearestEnmitys)
		//{
		//	ModBuffProperty modBuffProperty = (ModBuffProperty)role.GetModule(MODULE_TYPE.MT_BUFF);
		//	if (modBuffProperty != null)
		//	{
		//		modBuffProperty.AddBuff(128);
		//	}
		//}
	}

	public void addCrazyBladeOne()
	{
		Transform transform = this._role.GetTrans().FindChild("Bip01");
		Vector3 position = transform.position;
		this.m_iNowEffectId = SingletonMono<EffectManager>.GetInstance().AddEffectRay(241, position, Quaternion.identity, this._role.GetTrans().forward * 3f);
		EffectBase effectById = SingletonMono<EffectManager>.GetInstance().GetEffectById(this.m_iNowEffectId);
		effectById.ColliderProperty.SetCallBack(new EffectColliderProperty.ColliderCallBack(this.EffectCallBack));
		effectById.ColliderProperty.Start(null, 0);
	}

	private void EffectCallBack(object arg, object arg1)
	{
		Collider collider = arg1 as Collider;
		//Role roleScriptFromGo = RoleBaseFun.GetRoleScriptFromGo(collider.gameObject);
		//if (roleScriptFromGo != null)
		//{
		//	//ModOrganization modOrganization = roleScriptFromGo.GetModule(MODULE_TYPE.MT_ORGANIZATION) as ModOrganization;
		//	if (modOrganization.OrgType == ORG_TYPE.OT_MONSTER)
		//	{
		//		SingletonMono<EffectManager>.GetInstance().AddEffectFixure(242, roleScriptFromGo.GetPos(), Quaternion.identity);
		//		ModFight modFight = (ModFight)roleScriptFromGo.GetModule(MODULE_TYPE.MT_FIGHT);
		//		modFight.Hurt(new FightInfo
		//		{
		//			_role = this._role,
		//			_damage = -50f,
		//			_fightType = FightInfo.FightType.FT_PHY
		//		}, (ACTION_INDEX)385);
		//	}
		//}
	}

	public void addHitSlow(FightInfo AttObj)
	{
		ModBuffProperty modBuffProperty = (ModBuffProperty)AttObj._role.GetModule(MODULE_TYPE.MT_BUFF);
		modBuffProperty.AddBuff(160);
	}

	public void addHitDelAttack(FightInfo AttObj)
	{
		ModBuffProperty modBuffProperty = (ModBuffProperty)AttObj._role.GetModule(MODULE_TYPE.MT_BUFF);
		modBuffProperty.AddBuff(162);
	}

	public void addThunderZone(FightInfo AttObj, Role role)
	{
		for (int i = 0; i < 4; i++)
		{
			int id = SingletonMono<EffectManager>.GetInstance().AddEffectFixure(452, role.GetPos(), Quaternion.Euler(0f, (float)(90 * i), 0f));
			FightInfo fightInfo = new FightInfo();
			fightInfo._role = role;
			fightInfo._damage = -50f;
			fightInfo._fightType = FightInfo.FightType.FT_MAG;
			fightInfo.hurtBev = 1001;
			fightInfo.attackPoint = role.GetPos();
			EffectBase effectById = SingletonMono<EffectManager>.GetInstance().GetEffectById(id);
			effectById.ColliderProperty.Start(fightInfo, 0);
		}
	}

	public void addYRYYZR()
	{
		//List<Role> nearestEnmitys = SceneManager.RoleMan.GetNearestEnmitys(this._role, this._role.GetPos(), 8f);
		//foreach (Role role in nearestEnmitys)
		//{
		//	ModBuffProperty modBuffProperty = (ModBuffProperty)role.GetModule(MODULE_TYPE.MT_BUFF);
		//	if (modBuffProperty != null)
		//	{
		//		modBuffProperty.AddBuff(166);
		//	}
		//}
	}

	public void CleaAbsorbDamage()
	{
		this.m_fAbsorbDamage = 0f;
	}

	public override void Process()
	{
		base.Process();
		List<Buff> list = new List<Buff>();
		List<int> list2 = new List<int>();
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (!buff.Update())
			{
				list.Add(buff);
				if (this.m_mapBuffs[buff.Id].DoubleNum >= this.m_mapBuffs[buff.Id].GetMaxOverlyingNum() && this.m_mapBuffs[buff.Id].ReachNum() != 0)
				{
					list2.Add(this.m_mapBuffs[buff.Id].ReachNum());
				}
				ModControlMFS modControlMFS = (ModControlMFS)this._role.GetModule(MODULE_TYPE.MT_CONTROL_MFS);
				if (modControlMFS != null && modControlMFS.GetCurrentStateId() == CONTROL_STATE.BUFF && this.GetValue(BUFF_VALUE_TYPE.SLEEP) == 0 && this.GetValue(BUFF_VALUE_TYPE.NONO) == 0 && this.GetValue(BUFF_VALUE_TYPE.DIZZY) == 0 && this.GetValue(BUFF_VALUE_TYPE.CHANGE_ROLE) == 0 && this.GetValue(BUFF_VALUE_TYPE.BIND) == 0 && this.GetValue(BUFF_VALUE_TYPE.FALL_DOWN) == 0)
				{
					modControlMFS.ChangeStateToIdle();
				}
			}
			if (this.ContainBuff(163))
			{
				//List<Role> nearestEnmitys = SceneManager.RoleMan.GetNearestEnmitys(this._role);
				//if (nearestEnmitys.Count == 0)
				//{
				//	this.DelBuff(163);
				//}
			}
		}
		foreach (Buff buff2 in list)
		{
			buff2.Destory();
			this.m_mapBuffs.Remove(buff2.Id);
		}
		foreach (int id in list2)
		{
			this.AddBuff(id);
		}
	}

	public void AddBuff(int id)
	{
		if (this.m_mapBuffs.ContainsKey(id))
		{
			if (this.m_mapBuffs[id].IsOverlying())
			{
				this.m_mapBuffs[id].ReDouble();
			}
			else
			{
				this.m_mapBuffs[id].Reset();
			}
			return;
		}
		BuffData buffData = Singleton<BuffTableManager>.GetInstance().GetBuffData(id);
		if (buffData != null)
		{
			Buff value = new Buff(id, this._role);
			this.m_mapBuffs.Add(id, value);
			//if (Singleton<EZGUIManager>.GetInstance().GetGUI("BuffGUI") != null)
			//{
			//	Singleton<EZGUIManager>.GetInstance().GetGUI<BuffGUI>().SetIcons();
			//}
		}
		else
		{
			Debug.LogWarning("No BuffID :" + id);
		}
	}

	// Token: 0x060025F1 RID: 9713 RVA: 0x00019A4D File Offset: 0x00017C4D
	public void DelBuff(int id)
	{
		if (!this.m_mapBuffs.ContainsKey(id))
		{
			return;
		}
		this.m_mapBuffs[id].Stop();
		this.m_mapBuffs[id].Destory();
	}

	// Token: 0x060025F2 RID: 9714 RVA: 0x000FECA0 File Offset: 0x000FCEA0
	public void DelAllBuff()
	{
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			this.DelBuff(buff.Id);
		}
		this.m_mapBuffs.Clear();
	}

	public int GetValue(BUFF_VALUE_TYPE bvy)
	{
		int num = 0;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			num += buff.GetValue(bvy);
		}
		return num;
	}

	// Token: 0x060025F4 RID: 9716 RVA: 0x000FED78 File Offset: 0x000FCF78
	public int GetDisEffect(BUFF_VALUE_TYPE bvy)
	{
		int num = 0;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			num += buff.GetDisEffect(bvy);
		}
		return num;
	}

	// Token: 0x060025F5 RID: 9717 RVA: 0x000FEDE0 File Offset: 0x000FCFE0
	public List<Buff> GetBuffs()
	{
		List<Buff> list = new List<Buff>();
		foreach (Buff item in this.m_mapBuffs.Values)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x060025F6 RID: 9718 RVA: 0x000FEE48 File Offset: 0x000FD048
	public int GetAttackValues()
	{
		int num = 0;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.ADD_ATTACK) != 0)
			{
				num += buff.GetValue(BUFF_VALUE_TYPE.ADD_ATTACK);
			}
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_ATTACK) != 0)
			{
				num -= buff.GetValue(BUFF_VALUE_TYPE.ADD_ATTACK);
			}
		}
		return num;
	}

	// Token: 0x060025F7 RID: 9719 RVA: 0x000FEED4 File Offset: 0x000FD0D4
	public float GetAttackPercent()
	{
		float num = 0f;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.ADD_ATTACK_PER) != 0)
			{
				num += (float)buff.GetValue(BUFF_VALUE_TYPE.ADD_ATTACK_PER);
			}
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_ATTACK_PER) != 0)
			{
				num -= (float)buff.GetValue(BUFF_VALUE_TYPE.DEL_ATTACK_PER);
			}
		}
		return num / 100f;
	}

	// Token: 0x060025F8 RID: 9720 RVA: 0x000FEF6C File Offset: 0x000FD16C
	public float GetDefPercent()
	{
		float num = 0f;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.PHY_DEF) != 0)
			{
				num += (float)buff.GetValue(BUFF_VALUE_TYPE.PHY_DEF);
			}
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_DEF) != 0)
			{
				num -= (float)buff.GetValue(BUFF_VALUE_TYPE.DEL_DEF);
			}
		}
		return num / 100f;
	}

	// Token: 0x060025F9 RID: 9721 RVA: 0x000FF004 File Offset: 0x000FD204
	public int GetMAttackValues()
	{
		int num = 0;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.ADD_MATTACK) != 0)
			{
				num += buff.GetValue(BUFF_VALUE_TYPE.ADD_MATTACK);
			}
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_MATTACK) != 0)
			{
				num -= buff.GetValue(BUFF_VALUE_TYPE.DEL_MATTACK);
			}
		}
		return num;
	}

	// Token: 0x060025FA RID: 9722 RVA: 0x000FF090 File Offset: 0x000FD290
	public float GetMAttackPercent()
	{
		float num = 0f;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.ADD_MATTACK_PER) != 0)
			{
				num += (float)buff.GetValue(BUFF_VALUE_TYPE.ADD_MATTACK_PER);
			}
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_MATTACK_PER) != 0)
			{
				num -= (float)buff.GetValue(BUFF_VALUE_TYPE.DEL_MATTACK_PER);
			}
		}
		return num / 100f;
	}

	// Token: 0x060025FB RID: 9723 RVA: 0x000FF128 File Offset: 0x000FD328
	public int GetDelDamageValues()
	{
		int num = 0;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_DAMAGE) != 0)
			{
				num += buff.GetValue(BUFF_VALUE_TYPE.DEL_DAMAGE);
			}
		}
		return num;
	}

	// Token: 0x060025FC RID: 9724 RVA: 0x000FF19C File Offset: 0x000FD39C
	public float GetDelDamagePercent()
	{
		float num = 0f;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_DAMAGE_PER) != 0)
			{
				num += (float)buff.GetValue(BUFF_VALUE_TYPE.DEL_DAMAGE_PER);
			}
		}
		return num / 100f;
	}

	// Token: 0x060025FD RID: 9725 RVA: 0x000FF21C File Offset: 0x000FD41C
	public int GetDelMDamageValues()
	{
		int num = 0;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_MDAMAGE) != 0)
			{
				num += buff.GetValue(BUFF_VALUE_TYPE.DEL_MDAMAGE);
			}
		}
		return num;
	}

	// Token: 0x060025FE RID: 9726 RVA: 0x000FF290 File Offset: 0x000FD490
	public float GetDelMDamagePercent()
	{
		float num = 0f;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.DEL_MDAMAGE_PER) != 0)
			{
				num += (float)buff.GetValue(BUFF_VALUE_TYPE.DEL_MDAMAGE_PER);
			}
		}
		return num / 100f;
	}

	// Token: 0x060025FF RID: 9727 RVA: 0x000FF310 File Offset: 0x000FD510
	public float GetCriticalHitPercent()
	{
		float num = 0f;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(BUFF_VALUE_TYPE.CRITICAL_HIT) != 0)
			{
				num += (float)buff.GetValue(BUFF_VALUE_TYPE.CRITICAL_HIT);
			}
		}
		return num / 100f;
	}

	// Token: 0x06002600 RID: 9728 RVA: 0x000FF390 File Offset: 0x000FD590
	public string GetToolTip()
	{
		string result = string.Empty;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			result = buff.GetToolTip();
		}
		return result;
	}

	// Token: 0x06002601 RID: 9729 RVA: 0x000FF3F8 File Offset: 0x000FD5F8
	public string GetIconPath()
	{
		string result = string.Empty;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			result = buff.GetIconPath();
		}
		return result;
	}

	// Token: 0x06002602 RID: 9730 RVA: 0x000FF460 File Offset: 0x000FD660
	public bool GetIsBuff()
	{
		bool result = false;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			result = buff.IsBuff();
		}
		return result;
	}

	// Token: 0x06002603 RID: 9731 RVA: 0x000FF4C4 File Offset: 0x000FD6C4
	public bool GetIsMedicine()
	{
		bool result = false;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			result = buff.IsMedicine();
		}
		return result;
	}

	// Token: 0x06002604 RID: 9732 RVA: 0x000FF528 File Offset: 0x000FD728
	public int GetMaxValue(BUFF_VALUE_TYPE bvy)
	{
		int num = 0;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (num < buff.GetMaxValue(bvy))
			{
				num = buff.GetMaxValue(bvy);
			}
		}
		return num;
	}

	// Token: 0x06002605 RID: 9733 RVA: 0x000FF598 File Offset: 0x000FD798
	public int GetMinValue(BUFF_VALUE_TYPE bvy)
	{
		int num = 268435455;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (num > buff.GetMinValue(bvy))
			{
				num = buff.GetMinValue(bvy);
			}
		}
		return num;
	}

	// Token: 0x06002606 RID: 9734 RVA: 0x00019A83 File Offset: 0x00017C83
	public bool ContainBuff(int id)
	{
		return this.m_mapBuffs.ContainsKey(id);
	}

	public int GetBuffByValueType(BUFF_VALUE_TYPE valueType)
	{
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			if (buff.GetValue(valueType) > 0)
			{
				return buff.Id;
			}
		}
		return 0;
	}

	public float GetBuffTime()
	{
		float result = 0f;
		foreach (Buff buff in this.m_mapBuffs.Values)
		{
			result = buff.GetBuffTime();
		}
		return result;
	}
}
