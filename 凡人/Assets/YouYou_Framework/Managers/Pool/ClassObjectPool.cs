using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace YouYou
{
    /// <summary>
    /// ������
    /// </summary>
    public class ClassObjectPool:IDisposable
    {
        /// <summary>
        /// ������ڳ��еĳ�פ����
        /// </summary>
        public Dictionary<int, byte> ClassObjectCount
        {
            get;
            private set;
        }

        /// <summary>
        /// �������ֵ�
        /// </summary>
        private Dictionary<int, Queue<object>> m_ClassObjectPoolDic;

#if UNITY_EDITOR
        /// <summary>
        /// �ڼ��������ʾ����Ϣ
        /// </summary>
        public Dictionary<Type,int> InspectorDic=new Dictionary<Type, int>();
#endif

        public ClassObjectPool()
        {
            m_ClassObjectPoolDic = new Dictionary<int, Queue<object>>();
            ClassObjectCount = new Dictionary<int, byte>();
        }

        #region SetResideCount �����ೣפ����
        /// <summary>
        /// �����ೣפ����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        public void SetResideCount<T>(byte count) where T : class
        {
            //���ҵ������Ĺ�ϣ��
            int key = typeof(T).GetHashCode();
            ClassObjectCount[key] = count;
        }
        #endregion

        #region Dequeue ȡ��һ������
        /// <summary>
        /// ȡ��һ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Dequeue<T>() where T : class, new()
        {
            lock (m_ClassObjectPoolDic)
            {
                //���ҵ������Ĺ�ϣ��
                int key = typeof(T).GetHashCode();

                Queue<object> queue = null;
                m_ClassObjectPoolDic.TryGetValue(key, out queue);

                if (queue == null)
                {
                    queue = new Queue<object>();
                    m_ClassObjectPoolDic[key] = queue;
                }

                //��ʼ��ȡ����
                if (queue.Count > 0)
                {
                    //˵�������� �����õ�
                    object obj = queue.Dequeue();
#if UNITY_EDITOR
                    Type t = obj.GetType();
                    if (InspectorDic.ContainsKey(t))
                    {
                        InspectorDic[t]--;
                    }
                    else
                    {
                        InspectorDic[t] = 0;
                    }
#endif
                    return (T)obj;
                }
                else
                {
                    //���������û�� ��ʵ����һ��
                    return new T();
                }
            }
        }     
        #endregion

        #region Enqueue ����س�
        /// <summary>
        /// ����س�
        /// </summary>
        /// <param name="obj"></param>
        public void Enqueue(object obj)
        {
            lock (m_ClassObjectPoolDic)
            {
                int key = obj.GetType().GetHashCode();

                Queue<object> queue = null;
                m_ClassObjectPoolDic.TryGetValue(key, out queue);

#if UNITY_EDITOR
                Type t = obj.GetType();
                if (InspectorDic.ContainsKey(t))
                {
                    InspectorDic[t]++;
                }
                else
                {
                    InspectorDic[t] = 1;
                }
#endif


                if (queue != null)
                {
                    queue.Enqueue(obj);
                }
            }
        }
        #endregion

        /// <summary>
        /// �ͷ�������
        /// </summary>
        public void Clear()
        {
            lock (m_ClassObjectPoolDic)
            {
                int queueCount = 0;

                //1.���������
                var enumerator = m_ClassObjectPoolDic.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    int key = enumerator.Current.Key;

                    Queue<object> queue = m_ClassObjectPoolDic[key];
#if UNITY_EDITOR
                    Type t = null;
#endif
                    queueCount = queue.Count;

                    byte resideCount = 0;
                    ClassObjectCount.TryGetValue(key, out resideCount);
                    while (queueCount > resideCount)
                    {
                        queueCount--;
                        object obj = queue.Dequeue();
#if UNITY_EDITOR
                        t = obj.GetType();
                        InspectorDic[t]--;
#endif
                    }

                    if (queueCount == 0)
                    {
#if UNITY_EDITOR
                        if (t != null)
                        {
                            InspectorDic.Remove(t);
                        }
#endif
                    }
                }
                GC.Collect();
            }           
        }

        public void Dispose()
        {
            m_ClassObjectPoolDic.Clear();
        }
    }
}
