using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 数据组件
    /// </summary>
    public class DataComponent : YouYouBaseComponent
    {
        /// <summary>
        /// 系统相关数据
        /// </summary>
        public SysDataManager SysDataManager
        {
            get;
            private set;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            SysDataManager = new SysDataManager();
        }

        public override void Shutdown()
        {
            SysDataManager.Dispose();
        }
    }
}