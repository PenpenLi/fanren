using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// �������
    /// </summary>
    public class DataComponent : YouYouBaseComponent
    {
        /// <summary>
        /// ϵͳ�������
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