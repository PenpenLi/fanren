using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    internal class UIManager : ManagerBase
    {
        /// <summary>
        /// �Ѿ��򿪵�UI����
        /// </summary>
        private LinkedList<UIFormBase> m_OpenUIFormList;

        public UIManager()
        {
            m_OpenUIFormList = new LinkedList<UIFormBase>();
        }

        /// <summary>
        /// ��UI����
        /// </summary>
        /// <param name="uiFormId"></param>
        /// <param name="userData"></param>
        internal void OpenUIForm(int uiFormId,object userData=null, Action<UIFormBase> onOpen = null)
        {
            if (IsExists(uiFormId))
            {
                return;
            }
            //1.����

            //Sys_UIFormEntity entity = GameEntry.DataTable.DataTableManager.Sys_UIFormDBModel.Get(uiFormId);

            //if (entity == null)
            //{
            //    return;
            //}

            UIFormBase formBase = GameEntry.UI.Dequeue(uiFormId);

            if (formBase == null)
            {
                string assetPath = string.Empty;
                switch (GameEntry.Localization.CurrLanguage)
                {
                    case YouYouLanguage.Chinese:
                        //assetPath = entity.AssetPath_Chinese;
                        break;
                    case YouYouLanguage.English:
                        //assetPath = entity.AssetPath_English;
                        break;
                }
#if UNITY_EDITOR
                string path = string.Format("Assets/Resources/UI/UIPrefab/{0}.prefab", assetPath);
                //���ؾ���
                UnityEngine.Object obj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);
                GameObject uiObj = UnityEngine.Object.Instantiate(obj) as GameObject;
#else
                string path = string.Format("UI/UIPrefab/{0}", assetPath);
                GameObject obj = Resources.Load<GameObject>(path);
                GameObject uiObj = UnityEngine.Object.Instantiate(obj) as GameObject;
#endif
                //uiObj.transform.SetParent(GameEntry.UI.GetUIGroup(entity.UIGroupId).Group);
                uiObj.transform.localPosition = Vector3.zero;
                uiObj.transform.localScale = Vector3.one;

                formBase = uiObj.GetComponent<UIFormBase>();
                //formBase.Init(uiFormId, entity.UIGroupId, entity.DisableUILayer == 1, entity.IsLock == 1, userData);

                m_OpenUIFormList.AddLast(formBase);

                if (onOpen != null)
                {
                    onOpen(formBase);
                }
            }
            else
            {
                formBase.gameObject.SetActive(true);
                formBase.Open(userData);
                m_OpenUIFormList.AddLast(formBase);

                if (onOpen != null)
                {
                    onOpen(formBase);
                }
            }         
        }

        /// <summary>
        /// ���UI�Ƿ��Ѿ���
        /// </summary>
        /// <param name="uiformId"></param>
        /// <returns></returns>
        public bool IsExists(int uiformId)
        {
            for (LinkedListNode<UIFormBase> curr = m_OpenUIFormList.First; curr != null; curr = curr.Next)
            {
                if(curr.Value.UIFormId== uiformId)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ����UIFormId�ر�UI
        /// </summary>
        /// <param name="uiformId"></param>
        internal void CloseUIForm(int uiformId)
        {
            for (LinkedListNode<UIFormBase> curr = m_OpenUIFormList.First; curr != null; curr = curr.Next)
            {
                if (curr.Value.UIFormId == uiformId)
                {
                    CloseUIForm(curr.Value);
                    break;
                }
            }
        }

        internal void CloseUIForm(UIFormBase formBase)
        {
            m_OpenUIFormList.Remove(formBase);
            formBase.ToClose();
        }
    }
}
