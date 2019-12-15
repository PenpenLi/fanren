using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 场景组件
    /// </summary>
    public class SceneComponent : YouYouBaseComponent,IUpdateComponent
    {
        /// <summary>
        /// 场景管理器
        /// </summary>
        public YouYouSceneManager m_YouYouSceneManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            m_YouYouSceneManager = new YouYouSceneManager();
        }

        /// <summary>
        /// 加载场景
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
