using System;
using UnityEngine;

public class GUIBase : MonoBehaviour
{
    private bool _bIsInited;

    private bool _bIsShow;

    public string GUIKey
	{
		get
		{
			return base.GetType().Name;
		}
	}

	public bool IsInited
	{
		get
		{
			return this._bIsInited;
		}
		set
		{
			this._bIsInited = value;
		}
	}

	public bool IsShow
	{
		get
		{
			return this._bIsShow;
		}
	}

	public virtual bool Init()
	{
		return true;
	}

	public virtual void Show()
	{
		this._bIsShow = true;
	}

	public virtual void Hide()
	{
		this._bIsShow = false;
	}

	//public virtual int OnEZMessage(GUI_TYPE type, POINTER_INFO pt)
	//{
	//	return 0;
	//}

	//public virtual int OnChildEZMessage(GUI_TYPE type, string strChildKey, POINTER_INFO pt)
	//{
	//	return 0;
	//}

	// Token: 0x06000A07 RID: 2567 RVA: 0x0003F66C File Offset: 0x0003D86C
	public virtual int OnHandMessage(GUI_TYPE type, UnityEngine.Object pData)
	{
		return 0;
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x0003F670 File Offset: 0x0003D870
	public virtual int OnChildHandMessage(GUI_TYPE type, string strChildKey, UnityEngine.Object pData)
	{
		return 0;
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x0003F674 File Offset: 0x0003D874
	public void SetParent(GameObject pData)
	{
		if (pData != null && Singleton<EZGUIManager>.GetInstance().ParentTrans != null)
		{
			pData.transform.parent = Singleton<EZGUIManager>.GetInstance().ParentTrans;
		}
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x0003F6B8 File Offset: 0x0003D8B8
	public void SetParentEx(GameObject pData)
	{
		if (pData != null && Singleton<EZGUIManager>.GetInstance().ParentTrans != null)
		{
			pData.transform.parent = Singleton<EZGUIManager>.GetInstance().ParentTrans;
			pData.name = this.GUIKey;
		}
	}

    //// Token: 0x06000A0C RID: 2572 RVA: 0x0003F720 File Offset: 0x0003D920
    //public bool MenuGUI(string name, GameObject go)
    //{
    //	return Singleton<EZGUIManager>.GetInstance().MenuGUI(name, go);
    //}

    //// Token: 0x06000A0D RID: 2573 RVA: 0x0003F738 File Offset: 0x0003D938
    //public bool RemoveGUI(string key)
    //{
    //	return Singleton<EZGUIManager>.GetInstance().UnRegister(key);
    //}

    //// Token: 0x06000A0E RID: 2574 RVA: 0x0003F748 File Offset: 0x0003D948
    //public Vector3 Position(GUI_LAYER layer, GUI_POS pos, float pictureX, float pictureY)
    //{
    //	Vector3 zero = Vector3.zero;
    //	float num = (!(UICamera.Instance != null) || !(UICamera.Instance.uiCamera != null)) ? ((float)Screen.width) : UICamera.Instance.uiCamera.pixelWidth;
    //	float num2 = (!(UICamera.Instance != null) || !(UICamera.Instance.uiCamera != null)) ? ((float)Screen.height) : UICamera.Instance.uiCamera.pixelHeight;
    //	switch (pos)
    //	{
    //	case GUI_POS.UIPOS_LEFT:
    //	{
    //		float num3 = num / num2 * ((10f - pictureY / 2f + pictureY / 2f) * 2f) / 2f - pictureX / 2f;
    //		zero = new Vector3(-num3, 122.8469f, (float)layer);
    //		return zero;
    //	}
    //	case GUI_POS.UIPOS_RIGHT:
    //	{
    //		float x = num / num2 * ((10f - pictureY / 2f + pictureY / 2f) * 2f) / 2f - pictureX / 2f;
    //		zero = new Vector3(x, 122.8469f, (float)layer);
    //		return zero;
    //	}
    //	case GUI_POS.UIPOS_MIDDLE:
    //		zero = new Vector3(0f, 122.8469f, (float)layer);
    //		return zero;
    //	default:
    //		return zero;
    //	}
    //}

    //// Token: 0x06000A0F RID: 2575 RVA: 0x0003F89C File Offset: 0x0003DA9C
    //public EventEZMsg RegisterEZMsg(GUI_TYPE cmd)
    //{
    //	return Singleton<EZGUIManager>.GetInstance().RegisterEZMsg(cmd, this.GUIKey);
    //}

    //// Token: 0x06000A10 RID: 2576 RVA: 0x0003F8B0 File Offset: 0x0003DAB0
    //public EventEZMsg RegisterChildEZMsg(GUI_TYPE cmd, string childkey)
    //{
    //	return Singleton<EZGUIManager>.GetInstance().RegisterChildEZMsg(cmd, base.GetType().Name, childkey);
    //}

    //// Token: 0x06000A11 RID: 2577 RVA: 0x0003F8D4 File Offset: 0x0003DAD4
    //public bool PostUIMessage(GUI_TYPE type, UnityEngine.Object pData)
    //{
    //	return Singleton<EZGUIManager>.GetInstance().PostGUIMessage(type, this.GUIKey, pData);
    //}

    //// Token: 0x06000A12 RID: 2578 RVA: 0x0003F8E8 File Offset: 0x0003DAE8
    //public bool PostUIChildMessage(GUI_TYPE type, string childkey, UnityEngine.Object pData)
    //{
    //	return Singleton<EZGUIManager>.GetInstance().PostGUIChildMessage(type, this.GUIKey, childkey, pData);
    //}
}
