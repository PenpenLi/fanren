using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using YouYou;

/// <summary>
/// 按键管理
/// </summary>
public class KeyManager : YouYouBaseComponent, IUpdateComponent
{
    private static bool _hotKeyEnabled = true;

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

    protected override void OnAwake()
    {
        base.OnAwake();
        GameEntry.RegisterUpdateComponent(this);
    }

    public override void Shutdown()
    {
        
    }

    public void OnUpdate()
    {
        //防止UI穿透
        if (IsPointerOverGameObject(Input.mousePosition))
        {
            return;
        }

        if (GameEntry.Role.Player != null)
        {          
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                //判断是否击中了NPC
                if (Physics.Raycast(ray, out hit))
                {
                    //如果击中了NPC
                    if (hit.collider.gameObject.tag == "npc")
                    {
                        hit.collider.gameObject.GetComponent<NPCClick>().Call();
                    }
                    else if (hit.collider.gameObject.tag == "Road")
                    {
                        GameEntry.Role.Player.MoveTo(hit.point);
                    }
                }
            }          

            if (Input.GetKeyDown(KeyCode.C))
            {
                Transform trans = GameEntry.Role.Player.gameObject.transform;
                string pos = string.Format("{0}_{1}_{2}_{3}", trans.position.x, trans.position.y, trans.position.z, trans.rotation.eulerAngles.y);
                Debug.Log("位置信息=" + pos);
            }

            //    //if (!this.KeyForHelp(3, 0, KeyCode.None, "Vertical"))
            //    //{
            //    //    return;
            //    //}
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    GameEntry.Event.CommonEvent.Dispatch(KeyCodeEventId.F);
            //}

            if (Input.GetButton("Vertical")|| Input.GetButton("Horizontal"))
            {
                float VerInput = Input.GetAxisRaw("Vertical");
                float HorInput = Input.GetAxisRaw("Horizontal");
                Vector3 a = GameEntry.Camera.MainCamera.transform.forward;//摄像机前方
                Vector3 vector = VerInput * a + HorInput * GameEntry.Camera.MainCamera.transform.right;
                Vector3 vector2 = GameEntry.Role.Player.gameObject.transform.position + vector;//移动目标点    
                GameEntry.Role.Player.MoveTo(vector2);
            }
            //else
            //{
            //    GameEntry.Role.Player.CurrRoleFSMMgr.ChangeState(RoleState.Idle);
            //}

            bool buttonDown = Input.GetButtonDown("Jump");
            //    //if (KeyManager.Shift)
            //    //{

            //    //    Player.Instance.RunSpeed = 8f;
            //    //}
            //    //else
            //    //{
            //    //    ModBuffProperty modBuffProperty = (ModBuffProperty)Player.Instance.GetModule(MODULE_TYPE.MT_BUFF);
            //    //    //if (modBuffProperty.GetValue(BUFF_VALUE_TYPE.DEL_WALK_SPEED) != 0)
            //    //    //{
            //    //    //    return;
            //    //    //}
            //    //    Player.Instance.RunSpeed = 5f;
            //    //}
        }
    }

    List<RaycastResult> raycastResults = new List<RaycastResult>();
    public bool IsPointerOverGameObject(Vector2 screenPosition)
    {
        //实例化点击事件  
        PointerEventData eventDataCurrentPosition = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
        //将点击位置的屏幕坐标赋值给点击事件  
        eventDataCurrentPosition.position = new Vector2(screenPosition.x, screenPosition.y);

        raycastResults.Clear();
        //向点击处发射射线  
        EventSystem.current.RaycastAll(eventDataCurrentPosition, raycastResults);

        return raycastResults.Count > 0;
    }
}
