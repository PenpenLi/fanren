using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YouYou;

public class ScriptDataManager 
{
    private string m_ScriptAction;

    public void RunScript(int id)
    {
        m_ScriptAction = "";
        ScriptTriggerEntity scriptTriggerEntity = GameEntry.DataTable.DataTableManager.ScriptTriggerDBModel.Get(id);
        if (scriptTriggerEntity != null)
        {
            string[] arr1 = scriptTriggerEntity.ScriptHandle.Split('|');
            for (int i = 0; i < arr1.Length; i++)
            {
                string[] arr2 = arr1[i].Split(',');
                string[] arr3 = arr2[0].Split('@');
                m_ScriptAction = arr2[1];
                for (int j = 0; j < arr3.Length; j++)
                {
                    string[] arr4 = arr3[j].Split('_');
                    if (arr4[0].ToInt() == 0)
                    {
                        ScriptAction();
                    }
                    else if (arr4[0].ToInt() == 3)
                    {
                        string[] arr5 = arr4[2].Split('$');
                        ConditionAnalyse(arr4[1], arr5);
                    }
                    else if (arr4[0].ToInt() == 4)
                    {
                        Debug.Log("类型4");
                    }
                    else if (arr4[0].ToInt() == 8)
                    {

                        Debug.Log("类型8");
                    }
                    else
                    {
                        Debug.Log("类型其它");
                    }
                }
            }
        }
    }

    public void ConditionAnalyse(string id, string[] param)
    {
        if (id.ToInt()==1)
        {

        }
        else if (id.ToInt() == 2)
        {
            //判断任务状态
            MissionManager modMission = GameEntry.Data.RuntimeDataManager.modMission;
            MissionState missionState2 = modMission.GetMissionState(param[0].ToInt());
            if (param[1].ToInt() == (int)missionState2)
            {
                ScriptAction();
            }
        }
        else if (id.ToInt() == 3)
        {

        }
    }

    private void ScriptAction()
    {
        //string[] arr1 =m_ScriptAction.Split('@');
        //for (int i = 0; i < arr1.Length; i++)
        //{
        //    string[] arr2 = arr1[i].Split('_');
        //    for (int j = 0; j < arr2.Length; j++)
        //    {
        //        string[] arr3 = arr1[j].Split('$');
               
        //    }
        //}
    }
}
