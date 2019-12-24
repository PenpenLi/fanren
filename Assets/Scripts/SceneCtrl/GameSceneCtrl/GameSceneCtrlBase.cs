//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2016-08-11 21:37:47
//备    注：所有场景控制器的基类
//===================================================
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using YouYou;

/// <summary>
/// 所有场景控制器的基类
/// </summary>
public class GameSceneCtrlBase : MonoBehaviour
{
    void Awake()
    {      
        OnAwake();
    }

    List<RaycastResult> raycastResults = new List<RaycastResult>();

    void Start()
    {     
        Debug.Log("加载主UI");
        //GameEntry.UI.OpenUIForm(UIFormId.LogOn,null, OnLoadUIMainCityViewComplete);
        OnStart();
    }

    protected virtual void OnLoadUIMainCityViewComplete(UIFormBase t1)
    {
       
        //EffectMgr.Instance.Init(this);
    }

    void Update()
    {
        OnUpdate();
    }

    void OnDestroy()
    {      
        //EffectMgr.Instance.Clear();
        BeforeOnDestroy();
    }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    protected virtual void BeforeOnDestroy() { }
}