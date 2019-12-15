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

        //public Sys_CodeDBModel Sys_CodeDBModel { get; private set; }
        //public Sys_EffectDBModel Sys_EffectDBModel { get; private set; }
        //public Sys_PrefabDBModel Sys_PrefabDBModel { get; private set; }
        //public Sys_SoundDBModel Sys_SoundDBModel { get; private set; }
        //public Sys_StorySoundDBModel Sys_StorySoundDBModel { get; private set; }
        //public Sys_UIFormDBModel Sys_UIFormDBModel { get; private set; }
        //public Sys_SceneDBModel Sys_SceneDBModel { get; private set; }
        //public Sys_SceneDetailDBModel Sys_SceneDetailDBModel { get; private set; }
        public LocalizationBModel LocalizationBModel { get; private set; }

        /// <summary>
        /// �±�
        /// </summary>
        //public ChapterDBModel ChapterDBModel { get; private set; }

        ///// <summary>
        ///// �ؿ���
        ///// </summary>
        //public GameLevelDBModel GameLevelDBModel { get; private set; }

        ///// <summary>
        ///// �����
        ///// </summary>
        //public TaskDBModel TaskDBModel { get; private set; }

        /// <summary>
        /// ��ʼ��DBModel
        /// </summary>
        private void InitDBModel()
        {
            //ÿ����new
            //Sys_CodeDBModel = new Sys_CodeDBModel();
            //Sys_EffectDBModel = new Sys_EffectDBModel();
            //Sys_PrefabDBModel = new Sys_PrefabDBModel();
            //Sys_SoundDBModel = new Sys_SoundDBModel();
            //Sys_StorySoundDBModel = new Sys_StorySoundDBModel();
            //Sys_UIFormDBModel = new Sys_UIFormDBModel();
            //Sys_SceneDBModel = new Sys_SceneDBModel();
            //Sys_SceneDetailDBModel = new Sys_SceneDetailDBModel();
            LocalizationBModel = new LocalizationBModel();

            //ChapterDBModel = new ChapterDBModel();
            //GameLevelDBModel = new GameLevelDBModel();
            //TaskDBModel = new TaskDBModel();
        }

        public void LoadDataTable()
        {
            ////ÿ����LoadData
            //Sys_UIFormDBModel.LoadData();
            //Sys_EffectDBModel.LoadData();
            //Sys_PrefabDBModel.LoadData();
            //Sys_SoundDBModel.LoadData();
            //Sys_StorySoundDBModel.LoadData();
            //Sys_UIFormDBModel.LoadData();
            //Sys_SceneDBModel.LoadData();
            //Sys_SceneDetailDBModel.LoadData();
            LocalizationBModel.LoadData();

            //ChapterDBModel.LoadData();
            //GameLevelDBModel.LoadData();
            //TaskDBModel.LoadData();

            //���б�Load���
            GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadDataTableComplete);
        }

        /// <summary>
        /// �첽���ر��
        /// </summary>
        public void LoadDataTableAsync()
        {
            Task.Factory.StartNew(LoadDataTable);
        }

        public void Clear()
        {
            //ÿ����Clear
            //Sys_UIFormDBModel.Clear();
            //Sys_EffectDBModel.Clear();
            //Sys_PrefabDBModel.Clear();
            //Sys_SoundDBModel.Clear();
            //Sys_StorySoundDBModel.Clear();
            //Sys_UIFormDBModel.Clear();
            //Sys_SceneDBModel.Clear();
            //Sys_SceneDetailDBModel.Clear();
            LocalizationBModel.Clear();

            //ChapterDBModel.Clear();
            //GameLevelDBModel.Clear();
            //TaskDBModel.Clear();
        }
    }
}
