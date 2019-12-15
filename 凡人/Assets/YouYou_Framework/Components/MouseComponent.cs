using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 鼠标组件
    /// </summary>
    public class MouseComponent : YouYouBaseComponent
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
            this._mouseNor = (Texture2D)Resources.Load(this.MouseA, typeof(Texture2D));
            this._mouseDown = (Texture2D)Resources.Load(this.MouseB, typeof(Texture2D));
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
        /// 显示鼠标
        /// </summary>
        /// <param name="isLock"></param>
        public static void ShowCursor()
        {
            if (!Application.isEditor)
            {
                //Cursor.visible = isShow;
                MouseComponent.LockCursor();
            }
        }

        /// <summary>
        /// 锁定鼠标
        /// </summary>
        /// <param name="isLock"></param>
        public static void LockCursor()
        {
            if (!Application.isEditor)
            {
                Cursor.lockState = CursorLockMode.Locked;
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
            this._mouseNor =null;
            this._mouseDown = null;
        }
    }
}
