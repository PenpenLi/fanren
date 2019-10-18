using System;
using UnityEngine;

/// <summary>
/// 鼠标管理器
/// </summary>
public class MouseManager : MonoBehaviour
{
    public const int LEFT_MOUSE = 0;

    public const int RIGHT_MOUSE = 1;

    public const int MIDDLE_MOUSE = 2;

    public const int CURSOR_A = 1;

    public const int CURSOR_B = 2;

    public string ClassName = "MouseManager";

    private Texture2D _mouseNor;

    private Texture2D _mouseDown;

    private string MouseA = "EZGUI/Main/Mouse1";

    private string MouseB = "EZGUI/Main/Mouse2";

    private void Start()
	{
		this._mouseNor = (Texture2D)ResourceLoader.Load(this.MouseA, typeof(Texture2D));
		this._mouseDown = (Texture2D)ResourceLoader.Load(this.MouseB, typeof(Texture2D));
	}

    /// <summary>
    /// 显示鼠标
    /// </summary>
    /// <param name="isShow"></param>
	public static void ShowCursor(bool isShow)
	{
        Cursor.visible = isShow;
    }

    /// <summary>
    /// 锁定鼠标
    /// </summary>
    /// <param name="isLock"></param>
    public static void LockCursor()
	{
        Cursor.lockState = CursorLockMode.Locked;
    }

	private void OnGUI()
	{
		if (Event.current.type == EventType.MouseDown)
		{
			this.SetMouseState(1);
		}
		if (Event.current.type == EventType.MouseUp)
		{
			this.SetMouseState(2);
		}
	}

    /// <summary>
    /// 设置鼠标状态
    /// </summary>
    /// <param name="mouseType"></param>
	public void SetMouseState(int mouseType)
	{
		if (mouseType != 1)
		{
			if (mouseType != 2)
			{
				Cursor.SetCursor(null, Vector3.zero, CursorMode.Auto);
			}
			else
			{
				Cursor.SetCursor(this._mouseNor, Vector3.zero, CursorMode.Auto);
			}
		}
		else
		{
			Cursor.SetCursor(this._mouseDown, Vector3.zero, CursorMode.Auto);
		}
	}
}
