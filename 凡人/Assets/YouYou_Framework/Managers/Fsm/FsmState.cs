using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ״̬����״̬
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FsmState<T>  where T : class
    {
        /// <summary>
        /// ״̬��Ӧ��״̬��
        /// </summary>
        public Fsm<T> CurrFsm;

        /// <summary>
        /// ����״̬
        /// </summary>
        public virtual void OnEnter() { }

        /// <summary>
        /// ִ��״̬
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// �뿪״̬
        /// </summary>
        public virtual void OnLeave() { }

        /// <summary>
        /// ״̬������ʱ�����
        /// </summary>
        public virtual void OnDestroy() { }
    }
}
