using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 角色组件
    /// </summary>
    public class RoleComponent : YouYouBaseComponent
    {
        /// <summary>
        /// 角色管理器
        /// </summary>
        private RoleManager m_RoleManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            m_RoleManager = new RoleManager();
        }

        public void InitMainPlayer()
        {
            m_RoleManager.InitMainPlayer();
        }

        public override void Shutdown()
        {
           
        }
    }
}
