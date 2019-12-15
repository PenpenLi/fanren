using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ���ݱ�������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="P"></typeparam>
    public abstract class DataTableDBModelBase<T, P>
    where T : class, new()
    where P : DataTableEntityBase
    {
        protected List<P> m_List;
        protected Dictionary<int, P> m_Dic;

        public DataTableDBModelBase()
        {
            m_List = new List<P>();
            m_Dic = new Dictionary<int, P>();

        }

        #region ��Ҫ����ʵ�ֵ����Ի򷽷�
        /// <summary>
        /// ���ݱ���
        /// </summary>
        public abstract string DataTableName { get; }

        /// <summary>
        /// ���������б�
        /// </summary>
        protected abstract void LoadList(MMO_MemoryStream ms);
        #endregion

        #region �������ݱ����� LoadData
        /// <summary>
        /// �������ݱ�����
        /// </summary>
        public void LoadData()
        {
            byte[] buffer = GameEntry.Resource.GetFileBuffer(string.Format("{0}/DataTable/{1}.bytes",GameEntry.Resource.LocalFilePath,DataTableName));

            using (MMO_MemoryStream ms =new MMO_MemoryStream(buffer))
            {
                LoadList(ms);
            }

            //GameEntry.Event.CommonEvent.Dispatch(SysEventId.LoadOneDataTableComplete,DataTableName);
        }
        #endregion

        #region GetList ��ȡ����
        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <returns></returns>
        public List<P> GetList()
        {
            return m_List;
        }
        #endregion

        #region Get ���ݱ�Ż�ȡʵ��
        /// <summary>
        /// ���ݱ�Ż�ȡʵ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public P Get(int id)
        {
            if (m_Dic.ContainsKey(id))
            {
                return m_Dic[id];
            }
            return null;
        }
        #endregion

        public void Clear()
        {
            m_Dic.Clear();
            m_List.Clear();
        }
    }
}
