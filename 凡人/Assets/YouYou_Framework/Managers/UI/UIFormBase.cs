using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace YouYou
{
    public class UIFormBase : MonoBehaviour
    {
        /// <summary>
        /// UI������
        /// </summary>
        public int UIFormId
        {
            get;
            private set;
        }

        /// <summary>
        /// ������
        /// </summary>
        public byte GroupId
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ǰ����
        /// </summary>
        public Canvas CurrCanvas
        {
            get;
            private set;
        }

        /// <summary>
        /// �ر�ʱ��
        /// </summary>
        public float CloseTime
        {
            get;
            private set;
        }

        /// <summary>
        /// ���ò㼶����
        /// </summary>
        public bool DisableUILayer
        {
            get;
            private set;
        }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsLock
        {
            get;
            private set;
        }

        /// <summary>
        /// �û�����
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }

        private void Awake()
        {
            CurrCanvas = GetComponent<Canvas>();
        }

        internal void Init(int uiFormId,byte groupId,bool disableUILayer,bool isLock,object userData)
        {
            UIFormId = uiFormId;
            GroupId = groupId;
            DisableUILayer = disableUILayer;
            IsLock = isLock;
            UserData = userData;           
        }

        private void Start()
        {
            OnInit(UserData);
            Open(UserData,true);
        }

        internal void Open(object userData,bool isFromInit=false)
        {
            if (!isFromInit)
            {
                UserData = userData;
            }         

            if (!DisableUILayer)
            {
                //���в㼶���� ���Ӳ㼶
                GameEntry.UI.SetSortingOrder(this, true);
            }

            OnOpen(UserData);
        }

        public void Close()
        {
            GameEntry.UI.CloseUIForm(this);
        }

        public void ToClose()
        {
            if (!DisableUILayer)
            {
                //���в㼶���� ���ٲ㼶
                GameEntry.UI.SetSortingOrder(this, false);
            }

            OnClose();

            CloseTime = Time.time;
            GameEntry.UI.Enqueue(this);
        }

        private void OnDestroy()
        {
            OnBeforDestroy(); 
        }

        protected virtual void OnInit(object userData) { }
        protected virtual void OnOpen(object userData) { }
        protected virtual void OnClose() { }
        protected virtual void OnBeforDestroy() { }
    }
}
