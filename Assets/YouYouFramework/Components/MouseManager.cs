using System;
using UnityEngine;
using YouYou;

/// <summary>
/// 鼠标管理器
/// </summary>
public class MouseManager : YouYouBaseComponent
{
    public const int LEFT_MOUSE = 0;

    public const int RIGHT_MOUSE = 1;

    public const int MIDDLE_MOUSE = 2;

    public const int CURSOR_A = 1;

    public const int CURSOR_B = 2;

    public Texture2D _mouseNor;

    public Texture2D _mouseDown;

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
    public static void LockCursor(bool isLock)
	{
        if (isLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }       
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

    public override void Shutdown()
    {
        _mouseNor = null;
        _mouseDown = null;
    }
}
