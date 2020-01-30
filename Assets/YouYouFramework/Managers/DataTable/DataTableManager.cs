using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace YouYou
{
    public class DataTableManager : ManagerBase
    {
        public DataTableManager()
        {
            InitDBModel();
        }

        /// <summary>
        /// 总共需要加载的表格数量
        /// </summary>
        public int TotalTableCount = 0;

        /// <summary>
        /// 当前加载的表格数量
        /// </summary>
        public int CurrLoadTableCount = 0;

        public RoleDBModel RoleDBModel { get; private set; }
        public LocalizationDBModel LocalizationDBModel { get; private set; }
        public NPCDBModel NPCDBModel { get; private set; }
        public MissionDBModel MissionDBModel { get; private set; }
        public Sys_EffectDBModel Sys_EffectDBModel { get; private set; }
        public Sys_SoundDBModel Sys_SoundDBModel { get; private set; }
        public Sys_StorySoundDBModel Sys_StorySoundDBModel { get; private set; }
        public Sys_UIFormDBModel Sys_UIFormDBModel { get; private set; }
        public Sys_SceneDBModel Sys_SceneDBModel { get; private set; }
        public Sys_SceneDetailDBModel Sys_SceneDetailDBModel { get; private set; }
        public ScriptMoudleDBModel ScriptMoudleDBModel { get; private set; }
        public ScriptTriggerDBModel ScriptTriggerDBModel { get; private set; }
        public BattleDBModel BattleDBModel { get; private set; }
        /// <summary>
        /// 初始化DBModel
        /// </summary>
        private void InitDBModel()
        {
            //每个表都new
            NPCDBModel = new NPCDBModel();
            MissionDBModel = new MissionDBModel();
            RoleDBModel = new RoleDBModel();
            Sys_UIFormDBModel = new Sys_UIFormDBModel();
            Sys_SceneDBModel = new Sys_SceneDBModel();
            Sys_SceneDetailDBModel = new Sys_SceneDetailDBModel();
            ScriptMoudleDBModel = new ScriptMoudleDBModel();
            ScriptTriggerDBModel = new ScriptTriggerDBModel();
            BattleDBModel = new BattleDBModel();
        }

        /// <summary>
        /// 加载表格
        /// </summary>
        public void LoadDataTable()
        {
            //每个表都 LoadData
            RoleDBModel.LoadData();
            NPCDBModel.LoadData();
            MissionDBModel.LoadData();
            Sys_UIFormDBModel.LoadData();
            Sys_SceneDBModel.LoadData();
            Sys_SceneDetailDBModel.LoadData();
            ScriptMoudleDBModel.LoadData();
            ScriptTriggerDBModel.LoadData();
            BattleDBModel.LoadData();

            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadDataTableComplete);
        }

        /// <summary>
        /// 表格资源包
        /// </summary>
        public AssetBundle m_DataTableBundle;

        /// <summary>
        /// 异步加载表格
        /// </summary>
        public void LoadDataTableAsync()
        {
#if DISABLE_ASSETBUNDLE
            LoadDataTable();
#else
            GameEntry.Resource.ResourceLoaderManager.LoadAssetBundle(ConstDefine.DataTableAssetBundlePath, onComplete: (AssetBundle bundle) =>
            {
                m_DataTableBundle = bundle;
                LoadDataTable();
            });
#endif
        }

        /// <summary>
        /// 获取表格的字节数组
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public void GetDataTableBuffer(string tableName, Action<byte[]> onComplete)
        {
#if DISABLE_ASSETBUNDLE
            byte[] buffer = IOUtil.GetFileBuffer(string.Format("{0}/download/DataTable/{1}.bytes", GameEntry.Resource.LocalFilePath, tableName));
            if (onComplete != null)
            {
                onComplete(buffer);
            }
#else
            GameEntry.Resource.ResourceLoaderManager.LoadAsset(GameEntry.Resource.GetLastPathName(tableName), m_DataTableBundle, onComplete: (UnityEngine.Object obj) =>
            {
                TextAsset asset = obj as TextAsset;
                if (onComplete != null)
                {
                    onComplete(asset.bytes);
                }
            });
#endif
        }

        public void Clear()
        {
            //每个表都Clear
            RoleDBModel.Clear();
            NPCDBModel.Clear();
            MissionDBModel.Clear();
            Sys_UIFormDBModel.Clear();
            Sys_SceneDBModel.Clear();
            Sys_SceneDetailDBModel.Clear();
            ScriptMoudleDBModel.Clear();
            ScriptTriggerDBModel.Clear();
            BattleDBModel.Clear();
        }
    }
}