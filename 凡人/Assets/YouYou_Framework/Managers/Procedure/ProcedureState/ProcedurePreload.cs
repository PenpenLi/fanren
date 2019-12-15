using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// Ԥ��������
    /// </summary>
    public class ProcedurePreload : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Event.CommonEvent.AddEventListener(SysEventId.LoadDataTableComplete, OnLoadDataTableComplete);
            GameEntry.DataTable.LoadDataTableAsync();
        }
    
        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Event.CommonEvent.RemoveEventListener(SysEventId.LoadDataTableComplete, OnLoadDataTableComplete);
        }

        /// <summary>
        /// �������б����
        /// </summary>
        /// <param name="userData"></param>
        private void OnLoadDataTableComplete(object userData)
        {
            GameEntry.Procedure.ChangeState(ProcedureState.LogOn);        
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
