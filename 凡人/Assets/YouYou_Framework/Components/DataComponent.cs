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
        /// ��ʱ��������
        /// </summary>
        public CacheData CacheData
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ʱ��������
        /// </summary>
        public ScriptManager ScriptManager
        {
            get;
            private set;
        }

        /// <summary>
        /// ϵͳ�������
        /// </summary>
        //public SysDataManager SysData
        //{
        //    get;
        //    private set;
        //}

        /// <summary>
        /// �û��������
        /// </summary>
        //public UserDataManager UserDataManager
        //{
        //    get;
        //    private set;
        //}

        ///// <summary>
        ///// �ؿ���ͼ����
        ///// </summary>
        //public PVEMapData PVEMapData
        //{
        //    get;
        //    private set;
        //}

        protected override void OnAwake()
        {
            base.OnAwake();
            CacheData = new CacheData();
            ScriptManager = new ScriptManager();
            //SysData = new SysData();
            //UserData = new UserData();
            //PVEMapData = new PVEMapData();
        }

        public override void Shutdown()
        {
            //CacheData.Dispose();
            //SysData.Dispose();
            //UserData.Dispose();
            //PVEMapData.Dispose();
        }
    }
}
