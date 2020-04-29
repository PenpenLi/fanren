using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{   
    /// <summary>
    /// 游戏关卡流程
    /// </summary>
    public class ProcedureGameLevel : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureGameLevel");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();          
        }

        public override void OnLeave()
        {
            base.OnLeave();

            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureGameLevel");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}