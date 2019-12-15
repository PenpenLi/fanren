using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// �����
    /// </summary>
    public class PoolComponent : YouYouBaseComponent,IUpdateComponent
    {
        public PoolManager PoolManager
        {
            get;
            private set;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            PoolManager = new PoolManager();
            GameEntry.RegisterUpdateComponent(this);

            m_NextRunTime = Time.time;
            InitGameObjectPool();
        }

        protected override void OnStart()
        {
            base.OnStart();
            InitClassReside();
        }

        /// <summary>
        /// ��ʼ�������ೣפ����
        /// </summary>
        private void InitClassReside()
        {
            GameEntry.Pool.SetClassObjectResideCount<Dictionary<string,object>>(3);
        }

        #region ������

        #region SetResideCount �����ೣפ����
        /// <summary>
        /// �����ೣפ����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        public void SetClassObjectResideCount<T>(byte count) where T : class
        {
            PoolManager.ClassObjectPool.SetResideCount<T>(count);
        }
        #endregion

        #region DequeueClassObject ȡ��һ������
        /// <summary>
        /// ȡ��һ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DequeueClassObject<T>() where T : class, new()
        {
           return  PoolManager.ClassObjectPool.Dequeue<T>();
        }
        #endregion

        #region EnqueueClassObject ����س�
        /// <summary>
        /// ����س�
        /// </summary>
        /// <param name="obj"></param>
        public void EnqueueClassObject(object obj)
        {
            PoolManager.ClassObjectPool.Enqueue(obj);
        }
        #endregion

        #endregion

        #region ���������

        /// <summary>
        /// �����������
        /// </summary>
        private object m_VarObjectLock=new object();

#if UNITY_EDITOR
        /// <summary>
        /// �ڼ��������ʾ����Ϣ
        /// </summary>
        public Dictionary<Type, int> VarObjectInspectorDic = new Dictionary<Type, int>();
#endif

        /// <summary>
        /// ȡ��һ����������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DequeueVarObject<T>() where T :VariableBase,new ()
        {
            lock (m_VarObjectLock)
            {
                T item= DequeueClassObject<T>();
#if UNITY_EDITOR
                Type t = item.GetType();
                if (VarObjectInspectorDic.ContainsKey(t))
                {
                    VarObjectInspectorDic[t]++;
                }
                else
                {
                    VarObjectInspectorDic[t]=1;
                }
#endif
                return item;
            }         
        }

        /// <summary>
        /// ��������س�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void EnqueueVarObject<T>(T item)where T : VariableBase
        {
            lock (m_VarObjectLock)
            {
                EnqueueClassObject(item);
#if UNITY_EDITOR
                Type t = item.GetType();
                if (VarObjectInspectorDic.ContainsKey(t))
                {
                    VarObjectInspectorDic[t]--;
                    if (VarObjectInspectorDic[t]==0)
                    {
                        VarObjectInspectorDic.Remove(t);
                    }
                }
#endif
            }
        }

        #endregion

        public override void Shutdown()
        {
            PoolManager.Dispose();
        }


        /// <summary>
        /// �ͷż��
        /// </summary>
        [SerializeField]
        public int m_ClearInterval = 30;

        private float m_NextRunTime = 0f;

        public void OnUpdate()
        {
            if (Time.time > m_NextRunTime + m_ClearInterval)
            {
                m_NextRunTime = Time.time;
                PoolManager.ClearClassObjectPool();
            }
        }

        #region ��Ϸ��������
        /// <summary>
        /// ����ط���
        /// </summary>
        [SerializeField]
        private GameObjectPoolEntity[] m_GameObjectPoolGroups;

        /// <summary>
        /// ��ʼ����Ϸ��������
        /// </summary>
        public void InitGameObjectPool()
        {
            StartCoroutine(PoolManager.GameObjectPool.Init(m_GameObjectPoolGroups,transform));
        }

        /// <summary>
        /// �Ӷ�����л�ȡ����
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="prefab"></param>
        /// <param name="onComplete"></param>
        public void GameObjectSpawn(byte poolId, Transform prefab, System.Action<Transform> onComplete)
        {
            PoolManager.GameObjectPool.Spawn(poolId, prefab, onComplete);
        }

        /// <summary>
        /// ����س�
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="instance"></param>
        public void GameObjectDespawn(byte poolId, Transform instance)
        {
            PoolManager.GameObjectPool.Despawn(poolId, instance);
        }
        #endregion
    }
}
