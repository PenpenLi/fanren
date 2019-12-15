using PathologicalGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    [System.Serializable]
    public class GameObjectPoolEntity
    {
        /// <summary>
        /// ����ر��
        /// </summary>
        public byte PoolId;

        /// <summary>
        /// ���������
        /// </summary>
        public string PoolName;

        /// <summary>
        /// �Ƿ���������Զ�����ģʽ
        /// </summary>
        public bool CullDespawned = true;

        /// <summary>
        /// ������Զ����� ����ʼ�ձ���������������
        /// </summary>
        public int CullAbove = 5;

        /// <summary>
        /// �೤ʱ������һ�� ��λ����
        /// </summary>
        public int CullDelay = 2;

        /// <summary>
        /// ÿ��������
        /// </summary>
        public int CullMaxPerPass = 2;

        /// <summary>
        /// ��Ӧ����Ϸ��������
        /// </summary>
        public SpawnPool Pool;
    }
}
