﻿using System;
using NS_RoleBaseFun;
using UnityEngine;

public class WeaponManager
{
    private Transform leftHand;

    private Transform rightHand;

    private Transform leftBackPack;

    private Transform rightBackPack;

    public EquipCfgType currentWeaponType;

    private GameObject currentRightWeapon;

    private GameObject currentLeftWeapon;

    private ulong weaponID;

    private bool isWeaponActive;

    private Transform roleTransform;

    public bool weaponClosing;

    public string currentWeaponPath;

    public WeaponInfoData weaponInfoData;

    private string currentName;

    private Player player;

    public bool weaponeActive
	{
		get
		{
			return this.isWeaponActive;
		}
		set
		{
			this.isWeaponActive = value;
		}
	}

	public ulong WeaponID
	{
		get
		{
			return this.weaponID;
		}
	}

	public void initialize(Role role)
	{
		this.weaponClosing = false;
		this.player = (Player)role;
		this.roleTransform = this.player.GetTrans();
		this.SetWeaponTransform();
	}

	private void SetWeaponTransform()
	{
		if (this.weaponInfoData == null)
		{
			return;
		}
		this.leftHand = RoleBaseFun.FindDescendants(this.roleTransform, this.weaponInfoData.LHand);
		this.rightHand = RoleBaseFun.FindDescendants(this.roleTransform, this.weaponInfoData.RHand);
		this.leftBackPack = RoleBaseFun.FindDescendants(this.roleTransform, this.weaponInfoData.LBack);
		this.rightBackPack = RoleBaseFun.FindDescendants(this.roleTransform, this.weaponInfoData.RBack);
	}

	public void SetWeaponEmit(bool emit)
	{
	}

	public void autoChangeWeapon()
	{
		//if (this.player.ItemFolder.WearOperate.SwitchWeapon() && SkillUIManager.instance != null)
		//{
		//	CItemBase citemBase = this.player.ItemFolder.WearOperate[RoleWearEquipPos.WEAR_WEAPON];
		//	if (EZGUIManager._aWeapon != null)
		//	{
		//		EZGUIManager._aWeapon.PlayOneShot(EZGUIManager._aWeapon.clip);
		//	}
		//	else
		//	{
		//		GameData.Instance.soundTable.initialize();
		//		SingletonMono<AudioManager>.GetInstance().PlaySound(SoundType.gameSound, SceneManager.Instance.transform, 5003, false);
		//	}
		//}
	}

	public void HideWeapon(bool hide)
	{
		if (this.currentLeftWeapon != null)
		{
			this.currentLeftWeapon.SetActive(!hide);
		}
		if (this.currentRightWeapon != null)
		{
			this.currentRightWeapon.SetActive(!hide);
		}
	}

	public void DrawLine()
	{
	}

	public void changeWeapon(EquipCfgType weaponType, CItemBase weaponItem)
	{
		this.delCurrentWeapon();
		if (weaponItem == null)
		{
			return;
		}
		//this.weaponInfoData = GameData.Instance.weaponInfo.GetWeaponInfoById(weaponItem.ITEM_STATIC_ID);
		//if (this.weaponInfoData == null)
		//{
		//	return;
		//}
		//this.weaponID = weaponItem.ID;
		//this.currentWeaponPath = weaponItem.DynamicData.ITEM_RES_PREB;
		//this.currentName = this.currentWeaponPath.Substring(this.currentWeaponPath.LastIndexOf("/") + 1) + "(Clone)";
		//this.changeWeapon(weaponType);
		//Player.Instance.SystemFigure.BindWeaponEffect();
		//PuppetRole.Instance.BindWeaponEffect();
	}

	public void changeWeapon(EquipCfgType weaponType)
	{
		this.addNewWeapon(weaponType);
	}

	public void delCurrentWeapon()
	{
		UnityEngine.Object.Destroy(this.currentLeftWeapon);
		UnityEngine.Object.Destroy(this.currentRightWeapon);
		this.currentLeftWeapon = null;
		this.currentRightWeapon = null;
		this.weaponInfoData = null;
	}

	public void addNewWeapon(EquipCfgType weaponType)
	{
		EquipCfgType equipCfgType = this.currentWeaponType;
		this.currentWeaponType = weaponType;
		switch (this.currentWeaponType)
		{
		case EquipCfgType.EQCHILD_CT_UNKNOWN:
			this.weaponeActive = false;
			UnityEngine.Object.Destroy(this.currentRightWeapon);
			UnityEngine.Object.Destroy(this.currentLeftWeapon);
			this.currentRightWeapon = null;
			this.currentLeftWeapon = null;
			break;
		case EquipCfgType.EQCHILD_CT_WEAPON:
			if (this.currentRightWeapon == null)
			{
				this.currentRightWeapon = this.loadWeapon(this.currentWeaponPath);
				//PlayerWeaponSword playerWeaponSword = this.currentRightWeapon.AddComponent<PlayerWeaponSword>();
				//playerWeaponSword.Init(this.player.roleGameObject.ArmTrans[CHILD_ARM_POINT.BACK], this.player.roleGameObject.ArmTrans[CHILD_ARM_POINT.RIGHT_HAND], this.weaponInfoData.RightClosePos, this.weaponInfoData.RightCloseAngle, this.weaponInfoData.RightOpenPos, this.weaponInfoData.RightOpenAngle);
			}
			break;
		case EquipCfgType.EQCHILD_CT_MAGICWEAPON:
			if (this.currentLeftWeapon == null)
			{
				this.currentLeftWeapon = this.loadWeapon(this.currentWeaponPath);
				//PlayerWeaponMagic playerWeaponMagic = this.currentLeftWeapon.AddComponent<PlayerWeaponMagic>();
				//playerWeaponMagic.Init(this.player.GetTrans(), this.player.roleGameObject.ArmTrans[CHILD_ARM_POINT.LEFT_HAND], this.weaponInfoData.LeftClosePos, this.weaponInfoData.LeftCloseAngle, this.weaponInfoData.LeftOpenPos, this.weaponInfoData.LeftOpenAngle);
			}
			break;
		case EquipCfgType.EQCHILD_CT_DWEAPON:
			if (this.currentLeftWeapon == null || this.currentRightWeapon == null)
			{
				this.currentLeftWeapon = this.loadWeapon(this.currentWeaponPath);
				this.currentRightWeapon = this.loadWeapon(this.currentWeaponPath);
				//PlayerWeaponSword playerWeaponSword2 = this.currentLeftWeapon.AddComponent<PlayerWeaponSword>();
				//playerWeaponSword2.Init(this.player.roleGameObject.ArmTrans[CHILD_ARM_POINT.LEFT_WAIST], this.player.roleGameObject.ArmTrans[CHILD_ARM_POINT.LEFT_HAND], this.weaponInfoData.LeftClosePos, this.weaponInfoData.LeftCloseAngle, this.weaponInfoData.LeftOpenPos, this.weaponInfoData.LeftOpenAngle);
				//PlayerWeaponSword playerWeaponSword3 = this.currentRightWeapon.AddComponent<PlayerWeaponSword>();
				//playerWeaponSword3.Init(this.player.roleGameObject.ArmTrans[CHILD_ARM_POINT.RIGHT_WAIST], this.player.roleGameObject.ArmTrans[CHILD_ARM_POINT.RIGHT_HAND], this.weaponInfoData.RightClosePos, this.weaponInfoData.RightCloseAngle, this.weaponInfoData.RightOpenPos, this.weaponInfoData.RightOpenAngle);
			}
			break;
		}
		if (this.weaponeActive)
		{
			this.OpenWeapon();
		}
		else
		{
			this.CloseWeapon();
		}
		//this.player.roleGameObject.AttachWeapon(ATTACHMENT.LEFT_WEAPON, HARM_PART.LEFT_HAND, this.currentLeftWeapon);
		//this.player.roleGameObject.AttachWeapon(ATTACHMENT.RIGHT_WEAPON, HARM_PART.RIGHT_HAND, this.currentRightWeapon);
		if (this.currentLeftWeapon && this.player._roleType == ROLE_TYPE.RT_PUPPET)
		{
			this.currentLeftWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
			//PuppetRole.ModifyTagAndLayer(this.currentLeftWeapon.transform, PuppetRole.Instance.defultflag, PuppetRole.Instance.defultflag);
		}
		if (this.currentRightWeapon && this.player._roleType == ROLE_TYPE.RT_PUPPET)
		{
			this.currentRightWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
			//PuppetRole.ModifyTagAndLayer(this.currentRightWeapon.transform, PuppetRole.Instance.defultflag, PuppetRole.Instance.defultflag);
		}
		if (equipCfgType != this.currentWeaponType && this.player.modMFS != null)
		{
			CONTROL_STATE currentStateId = this.player.modMFS.GetCurrentStateId();
			if (currentStateId == CONTROL_STATE.ATTACK_IDLE)
			{
				//this.player.modMFS.ChangeState(new ControlEventAttackIdle(false));
			}
		}
	}

	public GameObject loadWeapon(string weaponPath)
	{
		GameObject gameObject = (GameObject)ResourceLoader.Load(weaponPath, typeof(GameObject));
		if (gameObject == null)
		{
			Debug.Log("not find weapon resources:" + weaponPath);
			return null;
		}
		//return (GameObject)LoadMachine.InstantiateObject(gameObject);
        return null;
    }

	public void SetWeaponClosing(bool closing)
	{
		this.weaponClosing = closing;
	}

	public void OpenWeapon()
	{
		this.weaponeActive = true;
		this.CloseWeapon(this.currentLeftWeapon, false, false);
		this.CloseWeapon(this.currentRightWeapon, false, false);
	}

	public void SmoothClose()
	{
		this.weaponeActive = false;
		this.CloseWeapon(this.currentLeftWeapon, true, true);
		this.CloseWeapon(this.currentRightWeapon, true, true);
	}

	private void CloseWeapon(GameObject weaponGO, bool close, bool smooth)
	{
		if (weaponGO)
		{
			//PlayerWeaponMonoBase component = weaponGO.GetComponent<PlayerWeaponMonoBase>();
			//if (component != null)
			//{
			//	if (smooth)
			//	{
			//		if (close)
			//		{
			//			component.SmoothClose();
			//		}
			//		else
			//		{
			//			component.Open();
			//		}
			//	}
			//	else if (close)
			//	{
			//		component.Close();
			//	}
			//	else
			//	{
			//		component.Open();
			//	}
			//}
		}
	}

	public void CloseWeapon()
	{
		this.weaponeActive = false;
		this.CloseWeapon(this.currentLeftWeapon, true, false);
		this.CloseWeapon(this.currentRightWeapon, true, false);
	}
}
