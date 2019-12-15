using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ʱ�����
    /// </summary>
    public class TimeComponent : YouYouBaseComponent, IUpdateComponent
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);

            m_TimeManager = new TimeManager();
        }

        #region ��ʱ��
        /// <summary>
        /// ��ʱ��������
        /// </summary>
        private TimeManager m_TimeManager;

        /// <summary>
        /// ע�ᶨʱ��
        /// </summary>
        /// <param name="action"></param>
        internal void RegisterTimeAction(TimeAction action)
        {
            m_TimeManager.RegisterTimeAction(action);
        }

        /// <summary>
        /// �Ƴ���ʱ��
        /// </summary>
        /// <param name="action"></param>
        internal void RemoveTimeAction(TimeAction action)
        {
            m_TimeManager.RemoveTimeAction(action);
            GameEntry.Pool.EnqueueClassObject(action);
        }

        /// <summary>
        /// ������ʱ��
        /// </summary>
        /// <returns></returns>
        public TimeAction CreateTimeAction()
        {
            return GameEntry.Pool.DequeueClassObject<TimeAction>();
        }
        #endregion

        public void OnUpdate()
        {
            m_TimeManager.OnUpdate();
        }

        public override void Shutdown()
        {
            m_TimeManager.Dispose();
        }
    }
}
