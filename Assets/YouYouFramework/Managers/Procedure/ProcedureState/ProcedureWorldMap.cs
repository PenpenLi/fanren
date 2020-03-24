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

            GameEntry.Role.InitMainPlayer();               
            if (GameEntry.Role.CurrPlayer != null)
            {
                Debug.Log("播放背景音乐");
                //AudioBackGroundMgr.Instance.Play(CurrWorldMapEntity.Audio_BG);

                InitTransPos();

                //如果未设置玩家目标场景传送点 id 则使用表上配置的出生点
                if (GameEntry.Scene.TargertWorldMapTransPosId == 0)
                {
                    //如果服务器告诉了客户端 主角最后进入世界地图场景坐标信息
                    if (!string.IsNullOrEmpty(GameEntry.Data.RuntimeDataManager.LastInWorldMapPos))
                    {
                        Debug.Log("主角信息为空");
                        //string[] arr = PlayerCtrl.Instance.LastInWorldMapPos.Split('_');
                        //Vector3 pos = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

                        //GlobalInit.Instance.CurrPlayer.Born(pos);
                        //GlobalInit.Instance.CurrPlayer.gameObject.transform.eulerAngles = new Vector3(0, float.Parse(arr[3]), 0);
                    }
                    else
                    {
                        //if (CurrWorldMapEntity.RoleBirthPostion != Vector3.zero)
                        //{
                        //    GlobalInit.Instance.CurrPlayer.Born(CurrWorldMapEntity.RoleBirthPostion);
                        //    GlobalInit.Instance.CurrPlayer.gameObject.transform.eulerAngles = new Vector3(0, CurrWorldMapEntity.RoleBirthEulerAnglesY, 0);
                        //}
                        //else
                        //{
                        //    GlobalInit.Instance.CurrPlayer.Born(m_PlayerBornPos.position);
                        //}
                    }
                }
                else
                {
                    //找传送点
                    if (m_TransPosDic.ContainsKey(GameEntry.Scene.TargertWorldMapTransPosId))
                    {
                        Vector3 newBornPos = m_TransPosDic[GameEntry.Scene.TargertWorldMapTransPosId].transform.forward.normalized * 3 + m_TransPosDic[GameEntry.Scene.TargertWorldMapTransPosId].transform.position;
                        Vector3 lookAtPos = m_TransPosDic[GameEntry.Scene.TargertWorldMapTransPosId].transform.forward.normalized * 3.5f + m_TransPosDic[GameEntry.Scene.TargertWorldMapTransPosId].transform.position;

                        GameEntry.Role.CurrPlayer.Born(newBornPos);
                        GameEntry.Role.CurrPlayer.transform.LookAt(lookAtPos);

                        GameEntry.Scene.TargertWorldMapTransPosId = 0;
                    }
                }
                ////当前玩家也添加
                //m_AllRoleDic[GlobalInit.Instance.CurrPlayer.CurrRoleInfo.RoleId] = GlobalInit.Instance.CurrPlayer;

                Debug.Log("加载主UI同时加载数据");
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
            GameEntry.Role.CurrPlayer.gameObject.SetActive(false);
            GameEntry.Role.ClearRole();
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