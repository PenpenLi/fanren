using System;
using UnityEngine;


public class GUIBind : MonoBehaviour
{

	private void Awake()
	{
		this.Init();
	}


	public void Init()
	{
		GUIBind.instance = this;
		this._cGUI = GameObject.FindWithTag("UICam");
		GUIBind._camera = this._cGUI.GetComponent<Camera>();
		this._cGUI.AddComponent<LoadingMain>();
		GUIBind.binded = true;
	}

	public void AddLandUI()
	{
		//if (this._cGUI == null)
		//{
		//	return;
		//}
		//if (this._cGUI.GetComponent<LandPlane>() == null)
		//{
		//	this._cGUI.AddComponent<LandPlane>();
		//}
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x0003F9A8 File Offset: 0x0003DBA8
	public void RemoveLandUI()
	{
		if (this._cGUI == null)
		{
			return;
		}
		//LandPlane component = this._cGUI.GetComponent<LandPlane>();
		//if (component == null)
		//{
		//	return;
		//}
		//Singleton<EZGUIManager>.GetInstance().UnRegister("LandPlane");
		//if (component._landPlane != null)
		//{
		//	LoadMachine.DeleteAsset(component.KEY_LAND_PLANE, typeof(GameObject), true);
		//	UnityEngine.Object.DestroyImmediate(component._landPlane, false);
		//}
		//UnityEngine.Object.Destroy(component);
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x0003FA2C File Offset: 0x0003DC2C
	public void AddRunGUIEx()
	{
		if (GUIBind._bind)
		{
			return;
		}
		if (this._cGUI == null)
		{
			this._cGUI = GameObject.FindWithTag("UICam");
			GUIBind.instance = this;
		}
		//this._cGUI.AddComponent<HelpPlane>();
		//this._cGUI.AddComponent<PickPlane>();
		//this._cGUI.AddComponent<UpgradePlane>();
		//this._cGUI.AddComponent<AdeptTalentPlane>();
		//this._cGUI.AddComponent<PropsPlane>();
		//this._cGUI.AddComponent<EquipPlane>();
		//this._cGUI.AddComponent<GUIPlayerSkill>();
		//this._cGUI.AddComponent<MixtureSmeltPlane>();
		//this._cGUI.AddComponent<AttachMagicPlane>();
		//this._cGUI.AddComponent<ShopPlane>();
		//this._cGUI.AddComponent<ShopBuyPlane>();
		//this._cGUI.AddComponent<ShopSellPlane>();
		//this._cGUI.AddComponent<SystemPlane>();
		//this._cGUI.AddComponent<SynopsisPlane>();
		//this._cGUI.AddComponent<PlayerUIManager>();
		//this._cGUI.AddComponent<SkillUIManager>();
		//this._cGUI.AddComponent<PlayerGUI>();
		//this._cGUI.AddComponent<MonsterGUI>();
		//this._cGUI.AddComponent<BuffGUI>();
		//this._cGUI.AddComponent<PanelManager>();
		//this._cGUI.AddComponent<AchTipPlane>();
		//this._cGUI.AddComponent<QuickEventButton>();
		//this._cGUI.AddComponent<UITips>();
		//this._cGUI.AddComponent<BigMap>();
		//this._cGUI.AddComponent<MapName>();
		//this._cGUI.AddComponent<MessageBox>();
		//this._cGUI.AddComponent<StageUI>();
		//this._cGUI.AddComponent<TaskTrackPlane>();
		//this._cGUI.AddComponent<DieGUI>();
		//this._cGUI.AddComponent<GreenBottle>();
		//this._cGUI.AddComponent<Cultureplane>();
		//this._cGUI.AddComponent<Tipplane>();
		//this._cGUI.AddComponent<TextDialogPlane>();
		//this._cGUI.AddComponent<TeachPlane>();
		GUIBind._bind = true;
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x0003FC0C File Offset: 0x0003DE0C
	public void BindComponent(string strClassName)
	{
		if (this._cGUI == null)
		{
			return;
		}
		if (this._cGUI.GetComponent(strClassName))
		{
			return;
		}
		//this._cGUI.AddComponent(strClassName);
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x0003FC50 File Offset: 0x0003DE50
	public static T BindComponent<T>() where T : Component
	{
		if (GUIBind.instance == null)
		{
			return (T)((object)null);
		}
		return GUIBind.instance._cGUI.AddComponent<T>();
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x0003FC84 File Offset: 0x0003DE84
	private void Update()
	{
		if (GUIBind._camera == null)
		{
			return;
		}
		Ray ray = GUIBind._camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit, float.PositiveInfinity, 1 << LayerMask.NameToLayer("EZGUI")))
		{
			GUIBind.pointIsUI = true;
		}
		else
		{
			GUIBind.pointIsUI = false;
		}
	}

	// Token: 0x04000957 RID: 2391
	public GameObject _cGUI;

	// Token: 0x04000958 RID: 2392
	public static GUIBind instance;

	// Token: 0x04000959 RID: 2393
	private static Camera _camera;

	// Token: 0x0400095A RID: 2394
	public static bool pointIsUI;

	// Token: 0x0400095B RID: 2395
	public static bool binded;

	// Token: 0x0400095C RID: 2396
	public static bool _bind;
}
