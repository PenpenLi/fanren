using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// �������
    /// </summary>
    public class SceneComponent : YouYouBaseComponent,IUpdateComponent
    {
        /// <summary>
        /// ����������
        /// </summary>
        public YouYouSceneManager m_YouYouSceneManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            m_YouYouSceneManager = new YouYouSceneManager();
        }

        /// <summary>
        /// ���س���
        /// </summary>
        /// <param name="sceneId"></param>
        public void LoadScene(int sceneId, Action onComplete = null)
        {
            m_YouYouSceneManager.LoadScene(sceneId, onComplete);
        }

        public override void Shutdown()
        {
            
        }

        public void OnUpdate()
        {
            m_YouYouSceneManager.OnUpdate();
        }
    }
}
