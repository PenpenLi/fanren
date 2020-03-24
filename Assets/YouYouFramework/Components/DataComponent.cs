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
        /// ��������
        /// </summary>
        public RuntimeDataManager RuntimeDataManager
        {
            get;
            private set;
        }

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
            RuntimeDataManager = new RuntimeDataManager();
            SysDataManager = new SysDataManager();
        }

        public override void Shutdown()
        {
            RuntimeDataManager.Dispose();
            SysDataManager.Dispose();
        }
    }
}