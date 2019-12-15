using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    public class RoleManager : ManagerBase
    {
        #region InitMainPlayer 初始化主角
        /// <summary>
        /// 主角是否已经初始化
        /// </summary>
        private bool m_IsMainPlayerInit = false;

        /// <summary>
        /// 初始化主角
        /// </summary>
        public void InitMainPlayer()
        {
            if (m_IsMainPlayerInit) return;

            GameObject mainPlayerObj = Object.Instantiate(Resources.Load("Prefab/RolePrefab/Player/Role_MainPlayer_Cike", typeof(GameObject)) as GameObject);
            Object.DontDestroyOnLoad(mainPlayerObj);

           // RoleCtrl m_RoleCtrl = mainPlayerObj.GetComponent<RoleCtrl>();
            //m_RoleCtrl.Init(ROLE_TYPE.RT_PLAYER);
            mainPlayerObj.transform.position = new Vector3(58f,0f,14f);

            m_IsMainPlayerInit = true;
        }
        #endregion

    }
}
