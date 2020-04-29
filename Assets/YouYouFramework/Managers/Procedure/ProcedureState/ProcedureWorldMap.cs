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
        /// <summary>
        /// 传送点字典
        /// </summary>
        private Dictionary<int, MapTransCtrl> m_TransPosDic;

        public override void OnEnter()
        {
            base.OnEnter();
            m_TransPosDic = new Dictionary<int, MapTransCtrl>();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureWorldMap");            

           

      
            //DoScriptMoudle();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
          
            m_TransPosDic = null;
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

        #region InitTransPos 初始化传送点

        string[] posInfoArr;

        /// <summary>
        /// 初始化传送点
        /// </summary>
        /// <returns></returns>
        private void InitTransPos()
        {
            Sys_SceneEntity m_Sys_SceneEntity = GameEntry.Scene.GetSceneEntity();
            posInfoArr = m_Sys_SceneEntity.TransPos.Split('|');

            Debug.Log("特效池加载对象");
            string path = "Assets/Download/Effect/Common/Efflect_Trans.prefab";
            //加载镜像
            GameObject obj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);

            for (int i = 0; i < posInfoArr.Length; i++)
            {
                string[] posInfo = posInfoArr[i].Split('_');

                if (posInfo.Length == 7)
                {
                    //坐标点
                    Vector3 pos = new Vector3();

                    float f = 0;

                    float.TryParse(posInfo[0], out f);
                    pos.x = f;

                    float.TryParse(posInfo[1], out f);
                    pos.y = f;

                    float.TryParse(posInfo[2], out f);
                    pos.z = f;

                    //y轴旋转
                    float y = 0;
                    float.TryParse(posInfo[3], out y);

                    //当前编号
                    int currTransPosId = 0;
                    int.TryParse(posInfo[4], out currTransPosId);

                    int targetTransSceneId = 0;
                    int targetSceneTransId = 0;
                    int.TryParse(posInfo[5], out targetTransSceneId);
                    int.TryParse(posInfo[6], out targetSceneTransId);

                    GameObject objTrans = UnityEngine.Object.Instantiate(obj);
                    objTrans.transform.position = pos;
                    objTrans.transform.eulerAngles = new Vector3(0, y, 0);
                    MapTransCtrl ctrl = objTrans.GetComponent<MapTransCtrl>();
                    if (ctrl != null)
                    {
                        ctrl.SetParam(currTransPosId, targetTransSceneId, targetSceneTransId);
                    }

                    m_TransPosDic[currTransPosId] = ctrl;
                }
            }
        }
        #endregion
    }
}