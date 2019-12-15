using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YouYou
{
    /// <summary>
    /// �������غ�ж����
    /// </summary>
    public class SceneLoaderRoutine
    {
        private AsyncOperation m_CurrAsync = null;

        /// <summary>
        /// ���ȸ���
        /// </summary>
        private Action<int, float> OnProgressUpdate;

        /// <summary>
        /// ���س������
        /// </summary>
        private Action<SceneLoaderRoutine> OnLoadSceneComplete;

        /// <summary>
        /// ж�س������
        /// </summary>
        private Action<SceneLoaderRoutine> OnUnLoadSceneComplete;

        /// <summary>
        /// ������ϸ���
        /// </summary>
        private int m_SceneDetailId;

        public void LoadScene(int sceneDetailId,string sceneName,Action<int,float> onProgressUpdate,Action<SceneLoaderRoutine> onLoadSceneComplete)
        {
            Reset();

            m_SceneDetailId = sceneDetailId;
            OnProgressUpdate = onProgressUpdate;
            OnLoadSceneComplete = onLoadSceneComplete;

            m_CurrAsync = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
            if (m_CurrAsync == null)
            {
                if (OnLoadSceneComplete != null)
                {
                    OnLoadSceneComplete(this);
                }
            }
        }

        /// <summary>
        /// ж�س���
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="onUnLoadSceneComplete"></param>
        public void UnLoadScene(string sceneName,Action<SceneLoaderRoutine> onUnLoadSceneComplete)
        {
            Reset();

            OnUnLoadSceneComplete = onUnLoadSceneComplete;
            m_CurrAsync = SceneManager.UnloadSceneAsync(sceneName);
            if (m_CurrAsync == null)
            {
                if (OnUnLoadSceneComplete != null)
                {
                    OnUnLoadSceneComplete(this);
                }
            }
        }

        private void Reset()
        {
            m_CurrAsync = null;
            OnProgressUpdate = null;
            OnLoadSceneComplete = null;
            OnUnLoadSceneComplete = null;
        }

        /// <summary>
        /// ����
        /// </summary>
        public void OnUpdate()
        {
            if (m_CurrAsync==null)
            {
                return;
            }

            if (!m_CurrAsync.isDone)
            {
                if (m_CurrAsync.progress >= 0.9f)
                {
                    if (OnProgressUpdate != null)
                    {
                        OnProgressUpdate(m_SceneDetailId, m_CurrAsync.progress);
                    }

                    m_CurrAsync = null;

                    if (OnLoadSceneComplete != null)
                    {
                        OnLoadSceneComplete(this);
                    }
                }
                else
                {
                    if (OnProgressUpdate != null)
                    {
                        OnProgressUpdate(m_SceneDetailId, m_CurrAsync.progress);
                    }
                }
            }
            else
            {
                m_CurrAsync = null;
                if (OnUnLoadSceneComplete != null)
                {
                    OnUnLoadSceneComplete(this);
                }
            }
        }
    }
}
