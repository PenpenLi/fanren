using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 世界地图流程
    /// </summary>
    public class ProcedureWorldMap : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureWorldMap");
            Debug.Log("加载主UI");
            if (GameEntry.Role.Player == null)
            {
                GameEntry.Role.CreatePlayer();
            }
            else
            {
                GameEntry.Role.Player.gameObject.SetActive(true);
            }
           
            GameEntry.Role.CreateAllNPC();

            //DoScriptMoudle();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Role.Player.gameObject.SetActive(false);
            GameEntry.Role.ClearRole();
            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureWorldMap");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void DoScriptMoudle()
        {
            //string[] arr1 = m_CurrSceneEntity.ScriptModId.Split('|');
            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    string[] arr2 = arr1[i].Split('_');

            //    int moduleID = 0;
            //    int.TryParse(arr2[0], out moduleID);

            //    int parID = 0;
            //    int.TryParse(arr2[1], out parID);

            //    if (moduleID != -1)
            //    {
            //        GameEntry.Script.Exec(moduleID, parID);
            //    }              
            //}
        }
    }
}