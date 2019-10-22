using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 按键管理
/// </summary>
public class KeyManager : MonoBehaviour
{
    public const float AttackEffectiveTime = 0.3f;

    public string ClassName = "KeyManager";

    private static bool _hotKeyEnabled = true;

    private Event currentEvent;

    public static bool _bScript = false;

    private static bool numeric;

    private static bool capsLock;

    private static bool control;

    private static bool shift;

    private static bool alt;

    private static Callback callBack;

    private static KeyManager.eKeyGroupMask m_KeyGroupMask = KeyManager.eKeyGroupMask.All;

    public static Role controlRole = null;

    public static float startTime = 0f;

    public static float pressedTime = 0f;

    private static Dictionary<KeyCode, Callback> NormalHotKeys = new Dictionary<KeyCode, Callback>();

    private static Dictionary<KeyCode, Callback> NormalUIKeys = new Dictionary<KeyCode, Callback>();

    private static Dictionary<KeyCode, Callback> CtrlHotKeys = new Dictionary<KeyCode, Callback>();

    private static Dictionary<KeyCode, Callback> ShiftHotKeys = new Dictionary<KeyCode, Callback>();

    private static Dictionary<KeyCode, Callback> AltHotKeys = new Dictionary<KeyCode, Callback>();

    public enum eKeyGroupMask
    {      
        None,
        UIKey,
        NormalHotKey,
        MouseClick = 4,
        MouseScroll = 8,
        All = 65535
    }

    public static bool hotKeyEnabled
	{
		get
		{
			return KeyManager._hotKeyEnabled;
		}
		set
		{
			KeyManager._hotKeyEnabled = value;
		}
	}

	public static KeyManager.eKeyGroupMask KeyGroupMask
	{
		get
		{
			return KeyManager.m_KeyGroupMask;
		}
		set
		{
			KeyManager.m_KeyGroupMask = value;
		}
	}

	public static bool Numeric
	{
		get
		{
			return KeyManager.numeric;
		}
		set
		{
			KeyManager.numeric = value;
		}
	}

	public static bool CapsLock
	{
		get
		{
			return KeyManager.capsLock;
		}
		set
		{
			KeyManager.capsLock = value;
		}
	}

	public static bool Control
	{
		get
		{
			return KeyManager.control;
		}
		set
		{
			KeyManager.control = value;
		}
	}

	public static bool Shift
	{
		get
		{
			return KeyManager.shift;
		}
		set
		{
			KeyManager.shift = value;
		}
	}

	public static bool Alt
	{
		get
		{
			return KeyManager.alt;
		}
		set
		{
			KeyManager.alt = value;
		}
	}

	private void Update()
	{
        //按下Shift键退出训练模式
        //if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && Singleton<DrillSystem>.GetInstance().IsDrillState)
        //{
        //    Singleton<DrillSystem>.GetInstance().ExitDrill();
        //}
        if (!KeyManager.hotKeyEnabled)
        {
            return;
        }
        if (SceneManager.GetActiveScene().name == "Landing")
        {
            return;
        }

        if (Player.Instance != null)
        {
            //if (!this.KeyForHelp(3, 0, KeyCode.None, "Vertical"))
            //{
            //    return;
            //}
           
            float axisRaw = Input.GetAxisRaw("Vertical");
            float axisRaw2 = Input.GetAxisRaw("Horizontal");
            bool buttonDown = Input.GetButtonDown("Jump");
            if (KeyManager.controlRole != null)
            {
                KeyManager.controlRole.Input(axisRaw, axisRaw2);
            }

            if (KeyManager.Shift)
            {
                Debug.Log("KeyManager.Shift");
                //if (Config.DEBUG)
                //{
                //    Player.Instance.RunSpeed = 8f;
                //}
            }
            else
            {
                //ModBuffProperty modBuffProperty = (ModBuffProperty)Player.Instance.GetModule(MODULE_TYPE.MT_BUFF);
                //if (modBuffProperty.GetValue(BUFF_VALUE_TYPE.DEL_WALK_SPEED) != 0)
                //{
                //    return;
                //}
                //Player.Instance.RunSpeed = 5f;
            }
        }
        if (KeyManager.pressedTime > 0.3f && Player.Instance != null)
        {
            //Player.Instance.m_cModFight.StartGatherStrength();//积聚力量
        }
        KeyManager.calculationTime();
    }

    private void OnGUI()
	{
		if (SceneManager.GetActiveScene().name == "Landing")
		{
			return;
		}
        //绘制按钮
		//this.currentEvent = Event.current;
		//this.LockMouse(this.currentEvent);
		//KeyManager.Numeric = this.currentEvent.numeric;
		//KeyManager.CapsLock = this.currentEvent.capsLock;
		//KeyManager.Control = this.currentEvent.control;
		//KeyManager.Shift = this.currentEvent.shift;
		//KeyManager.Alt = this.currentEvent.alt;
		//if ((KeyManager.m_KeyGroupMask & KeyManager.eKeyGroupMask.UIKey) != KeyManager.eKeyGroupMask.None && (this.currentEvent.functionKey || this.currentEvent.isKey))
		//{
		//	//this.onUIKeyFunction(this.currentEvent);
		//}
		//if (!KeyManager.hotKeyEnabled)
		//{
		//	return;
		//}
		//if ((KeyManager.m_KeyGroupMask & KeyManager.eKeyGroupMask.MouseClick) != KeyManager.eKeyGroupMask.None && this.currentEvent.isMouse)
		//{
		//	//this.onMouseClickEvent(this.currentEvent);
		//}
		//if ((KeyManager.m_KeyGroupMask & KeyManager.eKeyGroupMask.MouseScroll) != KeyManager.eKeyGroupMask.None && this.currentEvent.type == EventType.ScrollWheel)
		//{
		//	//this.onMouseScrollWheel(this.currentEvent);
		//}
		//if (((KeyManager.m_KeyGroupMask & KeyManager.eKeyGroupMask.NormalHotKey) != KeyManager.eKeyGroupMask.None && this.currentEvent.functionKey) || this.currentEvent.isKey)
		//{
		//	//this.onKeyFunction(this.currentEvent);
		//}
	}

	private void LockMouse(Event e)
	{
		if (!Cursor.visible)
		{
			MouseManager.LockCursor();
		}
	}

    //private void onMouseScrollWheel(Event e)
    //{
    //	if (this.KeyForHelp(2, 2, KeyCode.None, "null") && Player.Instance != null)
    //	{
    //		Player.Instance.m_cModCamera.ScaleCamera(e.delta.y);
    //	}
    //}

    //private void onMouseClickEvent(Event e)
    //{
    //	if (e.type == EventType.MouseDown)
    //	{
    //		switch (e.button)
    //		{
    //		case 0:
    //			if (this.KeyForHelp(2, 0, KeyCode.None, "null"))
    //			{
    //				KeyManager.initTime();
    //			}
    //			break;
    //		case 1:
    //			if (this.KeyForHelp(2, 1, KeyCode.None, "null"))
    //			{
    //				if (Player.Instance != null && Application.isEditor)
    //				{
    //					Player.Instance.m_cModCamera.isMouseOrbit = true;
    //				}
    //				if (Player.Instance != null)
    //				{
    //					Player.Instance.SystemFigure.UseSkill();
    //				}
    //			}
    //			break;
    //		case 2:
    //			if (this.KeyForHelp(2, 2, KeyCode.None, "null") && Player.Instance != null)
    //			{
    //				Player.Instance.m_cModCamera.ReSetCamera(true);
    //			}
    //			break;
    //		}
    //	}
    //	if (e.type == EventType.MouseUp)
    //	{
    //		switch (e.button)
    //		{
    //		case 0:
    //			if (Player.Instance != null)
    //			{
    //				if (KeyManager.pressedTime <= 0.3f)
    //				{
    //					Player.Instance.Fight();
    //				}
    //				else if (Player.Instance.modMFS.GetCurrentStateId() == CONTROL_STATE.GATHER_STRENGTH)
    //				{
    //					if (Player.Instance.m_cModFight.IsStrengthFull)
    //					{
    //						Player.Instance.m_cModFight.UseGatherSkill();
    //					}
    //					else
    //					{
    //						Player.Instance.modMFS.ChangeStateToIdle();
    //					}
    //				}
    //				KeyManager.clearTime();
    //			}
    //			break;
    //		case 1:
    //			if (Player.Instance != null && Application.isEditor)
    //			{
    //				Player.Instance.m_cModCamera.isMouseOrbit = false;
    //			}
    //			if (Player.Instance != null)
    //			{
    //				Player.Instance.SystemFigure.StopSkill();
    //			}
    //			break;
    //		}
    //	}
    //}

    private bool KeyForHelp(int type, int mouseIndex, KeyCode keyCode, string axis)
    {
        //if (!HelpManager.m_isHelp || (HelpManager.m_Keycode == 0 && HelpManager.m_Mouse == -1 && HelpManager._instance.m_Move == "null"))
        //{
        //    return true;
        //}
        //if (type == 1)
        //{
        //    if (!HelpManager.m_IsKey || (keyCode != (KeyCode)HelpManager.m_Keycode && HelpManager.m_Keycode != 0) || HelpManager.m_Mouse != -1 || HelpManager._instance.m_Move != "null")
        //    {
        //        return false;
        //    }
        //    if (Singleton<EZGUIManager>.GetInstance().GetGUI("PlayerUIManager") != null && !Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>().pausePanelInstant.active)
        //    {
        //        GameTime.Start();
        //    }
        //    HelpManager.m_Keycode = 0;
        //}
        //if (type == 2)
        //{
        //    if (!HelpManager.m_IsKey || (HelpManager.m_Mouse != mouseIndex && HelpManager.m_Mouse != -1) || HelpManager.m_Keycode != 0 || HelpManager._instance.m_Move != "null")
        //    {
        //        return false;
        //    }
        //    if (HelpManager._instance.m_Info._zOffset > 10f && Singleton<EZGUIManager>.GetInstance().GetGUI("PlayerUIManager") != null && !Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>().pausePanelInstant.active)
        //    {
        //        GameTime.Start();
        //    }
        //    HelpManager.m_Mouse = -1;
        //}
        //if (type == 3)
        //{
        //    if (!HelpManager.m_IsKey || (HelpManager._instance.m_Move != axis && HelpManager._instance.m_Move != "null") || HelpManager.m_Keycode != 0 || HelpManager.m_Mouse != -1)
        //    {
        //        return false;
        //    }
        //    if (Singleton<EZGUIManager>.GetInstance().GetGUI("PlayerUIManager") != null && !Singleton<EZGUIManager>.GetInstance().GetGUI<PlayerUIManager>().pausePanelInstant.active)
        //    {
        //        GameTime.Start();
        //    }
        //    HelpManager._instance.m_Move = "null";
        //}
        //KeyManager._bScript = true;
        //HelpManager.m_IsKey = true;
        //if (HelpManager._instance.m_Info._zOffset < 10f)
        //{
        //    GameTime.Stop();
        //}
        //Singleton<EZGUIManager>.GetInstance().GetGUI("HelpPlane").Hide();
        //HelpManager.m_isHelp = false;
        return true;
    }

    //// Token: 0x060015EA RID: 5610 RVA: 0x000AD97C File Offset: 0x000ABB7C
    //private static void initTime()
    //{
    //	if (KeyManager.pressedTime == 0f)
    //	{
    //		KeyManager.startTime = GameTime.time;
    //	}
    //}

    /// <summary>
    /// 计算时间
    /// </summary>
    private static void calculationTime()
    {
        if (KeyManager.startTime != 0f)
        {
            KeyManager.pressedTime = GameTime.time - KeyManager.startTime;
        }
    }

    //private static void clearTime()
    //{
    //	KeyManager.pressedTime = 0f;
    //	KeyManager.startTime = 0f;
    //}

    //// Token: 0x060015ED RID: 5613 RVA: 0x000AD9D4 File Offset: 0x000ABBD4
    //public static void addNormalKey(KeyCode keyCode, Callback callback)
    //{
    //	KeyManager.removeNormalKey(keyCode);
    //	KeyManager.NormalHotKeys.Add(keyCode, callback);
    //}

    //// Token: 0x060015EE RID: 5614 RVA: 0x000AD9E8 File Offset: 0x000ABBE8
    //public static void removeNormalKey(KeyCode keyCode)
    //{
    //	if (KeyManager.NormalHotKeys.ContainsKey(keyCode))
    //	{
    //		KeyManager.NormalHotKeys.Remove(keyCode);
    //	}
    //}

    //// Token: 0x060015EF RID: 5615 RVA: 0x000ADA08 File Offset: 0x000ABC08
    //public static void addUIKey(KeyCode keyCode, Callback callback)
    //{
    //	KeyManager.removeUIKey(keyCode);
    //	KeyManager.NormalUIKeys.Add(keyCode, callback);
    //}

    //// Token: 0x060015F0 RID: 5616 RVA: 0x000ADA1C File Offset: 0x000ABC1C
    //public static void removeUIKey(KeyCode keyCode)
    //{
    //	if (KeyManager.NormalUIKeys.ContainsKey(keyCode))
    //	{
    //		KeyManager.NormalUIKeys.Remove(keyCode);
    //	}
    //}

    //// Token: 0x060015F1 RID: 5617 RVA: 0x000ADA3C File Offset: 0x000ABC3C
    //public static void addCtrlKey(KeyCode keyCode, Callback callback)
    //{
    //	KeyManager.removeCtrlKey(keyCode);
    //	KeyManager.CtrlHotKeys.Add(keyCode, callback);
    //}

    //// Token: 0x060015F2 RID: 5618 RVA: 0x000ADA50 File Offset: 0x000ABC50
    //public static void removeCtrlKey(KeyCode keyCode)
    //{
    //	if (KeyManager.CtrlHotKeys.ContainsKey(keyCode))
    //	{
    //		KeyManager.CtrlHotKeys.Remove(keyCode);
    //	}
    //}

    //// Token: 0x060015F3 RID: 5619 RVA: 0x000ADA70 File Offset: 0x000ABC70
    //public static void addShiftKey(KeyCode keyCode, Callback callback)
    //{
    //	KeyManager.removeShiftKey(keyCode);
    //	KeyManager.ShiftHotKeys.Add(keyCode, callback);
    //}

    //// Token: 0x060015F4 RID: 5620 RVA: 0x000ADA84 File Offset: 0x000ABC84
    //public static void removeShiftKey(KeyCode keyCode)
    //{
    //	if (KeyManager.ShiftHotKeys.ContainsKey(keyCode))
    //	{
    //		KeyManager.ShiftHotKeys.Remove(keyCode);
    //	}
    //}

    //// Token: 0x060015F5 RID: 5621 RVA: 0x000ADAA4 File Offset: 0x000ABCA4
    //public static void addAltKey(KeyCode keyCode, Callback callback)
    //{
    //	KeyManager.removeAltKey(keyCode);
    //	KeyManager.AltHotKeys.Add(keyCode, callback);
    //}

    //// Token: 0x060015F6 RID: 5622 RVA: 0x000ADAB8 File Offset: 0x000ABCB8
    //public static void removeAltKey(KeyCode keyCode)
    //{
    //	if (KeyManager.AltHotKeys.ContainsKey(keyCode))
    //	{
    //		KeyManager.AltHotKeys.Remove(keyCode);
    //	}
    //}

    //// Token: 0x060015F7 RID: 5623 RVA: 0x000ADAD8 File Offset: 0x000ABCD8
    //private void onKeyFunction(Event e)
    //{
    //	if (e.type == EventType.KeyDown)
    //	{
    //		if (!KeyManager.Control && !KeyManager.Alt && !KeyManager.Shift)
    //		{
    //			foreach (KeyValuePair<KeyCode, Callback> keyValuePair in KeyManager.NormalHotKeys)
    //			{
    //				this.callBackFunction(keyValuePair, e.keyCode);
    //			}
    //		}
    //		else if (KeyManager.Control && !KeyManager.Alt && !KeyManager.Shift)
    //		{
    //			foreach (KeyValuePair<KeyCode, Callback> keyValuePair2 in KeyManager.CtrlHotKeys)
    //			{
    //				this.callBackFunction(keyValuePair2, e.keyCode);
    //			}
    //		}
    //		else if (!KeyManager.Control && KeyManager.Alt && !KeyManager.Shift)
    //		{
    //			foreach (KeyValuePair<KeyCode, Callback> keyValuePair3 in KeyManager.AltHotKeys)
    //			{
    //				this.callBackFunction(keyValuePair3, e.keyCode);
    //			}
    //		}
    //		else if (!KeyManager.Control && !KeyManager.Alt && KeyManager.Shift)
    //		{
    //			foreach (KeyValuePair<KeyCode, Callback> keyValuePair4 in KeyManager.ShiftHotKeys)
    //			{
    //				this.callBackFunction(keyValuePair4, e.keyCode);
    //			}
    //		}
    //		else if (!KeyManager.Control || !KeyManager.Alt || KeyManager.Shift)
    //		{
    //			if (!KeyManager.Control || KeyManager.Alt || !KeyManager.Shift)
    //			{
    //				if (!KeyManager.Control || !KeyManager.Alt || KeyManager.Shift)
    //				{
    //				}
    //			}
    //		}
    //	}
    //}

    //// Token: 0x060015F8 RID: 5624 RVA: 0x000ADD58 File Offset: 0x000ABF58
    //private void onUIKeyFunction(Event e)
    //{
    //	if (e.type == EventType.KeyUp)
    //	{
    //		foreach (KeyValuePair<KeyCode, Callback> keyValuePair in KeyManager.NormalUIKeys)
    //		{
    //			this.callBackFunction(keyValuePair, e.keyCode);
    //		}
    //	}
    //}

    //// Token: 0x060015F9 RID: 5625 RVA: 0x000ADDD0 File Offset: 0x000ABFD0
    //private void callBackFunction(KeyValuePair<KeyCode, Callback> keyValuePair, KeyCode keyCode)
    //{
    //	if (!this.KeyForHelp(1, -1, keyCode, "null"))
    //	{
    //		return;
    //	}
    //	if (keyValuePair.Key == keyCode)
    //	{
    //		KeyManager.callBack = keyValuePair.Value;
    //		KeyManager.callBack();
    //	}
    //}
}
