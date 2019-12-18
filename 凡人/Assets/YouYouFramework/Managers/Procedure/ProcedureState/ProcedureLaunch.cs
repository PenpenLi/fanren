//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：
//备    注：
//===================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 启动流程
    /// </summary>
    public class ProcedureLaunch : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureLaunch");          
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            //GameEntry.Procedure.ChangeState(ProcedureState.CheckVersion);
            GameEntry.Procedure.ChangeState(ProcedureState.Preload);
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureLaunch");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}