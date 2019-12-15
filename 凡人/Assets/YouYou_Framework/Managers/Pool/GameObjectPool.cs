using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ��Ϸ��������
    /// </summary>
    public class GameObjectPool : IDisposable
    {
        /// <summary>
        /// ��Ϸ���������ֵ�
        /// </summary>
        public Dictionary<byte, GameObjectPoolEntity> m_SpawnPoolDic;


        public GameObjectPool()
        {
            m_SpawnPoolDic = new Dictionary<byte, GameObjectPoolEntity>();
        }

        public void Dispose()
        {
            m_SpawnPoolDic.Clear();
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public IEnumerator Init(GameObjectPoolEntity[] arr, Transform parent)
        {
            int len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                GameObjectPoolEntity entity = arr[i];

                if (entity.Pool != null)
                {
                    UnityEngine.Object.Destroy(entity.Pool.gameObject);
                    yield return null;
                    entity.Pool = null;
                }

                PathologicalGames.SpawnPool pool = PathologicalGames.PoolManager.Pools.Create(entity.PoolName);
                pool.group.parent = parent;
                pool.group.localPosition = Vector3.zero;
                entity.Pool = pool;

                m_SpawnPoolDic[entity.PoolId] = entity;
            }
        }

        /// <summary>
        /// �Ӷ�����л�ȡ����
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="prefab"></param>
        /// <param name="onComplete"></param>
        public void Spawn(byte poolId, Transform prefab, System.Action<Transform> onComplete)
        {
            GameObjectPoolEntity entity = m_SpawnPoolDic[poolId];

            PathologicalGames.PrefabPool prefabPool = entity.Pool.GetPrefabPool(prefab);

            if (prefabPool == null)
            {
                prefabPool = new PathologicalGames.PrefabPool(prefab);
                prefabPool.cullDespawned = entity.CullDespawned;
                prefabPool.cullAbove = entity.CullAbove;
                prefabPool.cullDelay = entity.CullDelay;
                prefabPool.cullMaxPerPass = entity.CullMaxPerPass;

                entity.Pool.CreatePrefabPool(prefabPool);
            }

            if (onComplete != null)
            {
                onComplete(entity.Pool.Spawn(prefab));
            }
        }

        /// <summary>
        /// ����س�
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="instance"></param>
        public void Despawn(byte poolId, Transform instance)
        {
            GameObjectPoolEntity entity = m_SpawnPoolDic[poolId];
            entity.Pool.Despawn(instance);
        }
    }
}
