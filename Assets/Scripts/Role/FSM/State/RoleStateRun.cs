//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-12-12 08:54:29
//备    注：
//===================================================
using UnityEngine;
using System.Collections;

/// <summary>
/// 跑状态
/// </summary>
public class RoleStateRun : RoleStateBase
{
    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("进入Run状态");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }

    public override void OnLeave()
    {
        base.OnLeave();

    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}