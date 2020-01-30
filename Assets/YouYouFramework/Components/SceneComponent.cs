using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// 场景组件
    /// </summary>
    public class SceneComponent : YouYouBaseComponent, IUpdateComponent
    {
        /// <summary>
        /// 场景管理器
        /// </summary>
        private YouYouSceneManager m_YouYouSceneManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            m_YouYouSceneManager = new YouYouSceneManager();
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="sceneId">场景编号</param>
        /// <param name="showLoadingForm">是否显示Loading</param>
        /// <param name="onComplete">加载完毕</param>
        public void LoadScene(int sceneId, bool showLoadingForm = true, BaseAction onComplete = null)
        {
            m_YouYouSceneManager.LoadScene(sceneId, showLoadingForm, onComplete);
        }

        /// <summary>
        /// 获得场景名称
        /// </summary>
        /// <returns></returns>
        public string GetSceneName()
        {         
            return m_YouYouSceneManager.m_CurrSceneEntity.SceneName;
        }

        /// <summary>
        /// 获得场景名称
        /// </summary>
        /// <returns></returns>
        public Sys_SceneEntity GetSceneEntity()
        {
            return m_YouYouSceneManager.m_CurrSceneEntity;
        }

        public override void Shutdown()
        {
            GameEntry.RemoveUpdateComponent(this);
        }

        public void OnUpdate()
        {
            m_YouYouSceneManager.OnUpdate();
        }
    }
}