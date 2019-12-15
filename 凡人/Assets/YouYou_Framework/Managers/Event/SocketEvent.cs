using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace YouYou
{
    /// <summary>
    /// Socket�¼�
    /// </summary>
    public class SocketEvent: IDisposable
    {
        public delegate void OnActionHandler(byte[] buffer);
        public Dictionary<ushort, List<OnActionHandler>> dic = new Dictionary<ushort, List<OnActionHandler>>();

        #region AddEventListener ��Ӽ���
        /// <summary>
        /// ��Ӽ���
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void AddEventListener(ushort key, OnActionHandler handler)
        {
            List<OnActionHandler> lstHandler = null;
            dic.TryGetValue(key, out lstHandler);
            if (lstHandler == null)
            {
                lstHandler = new List<OnActionHandler>();
                dic[key] = lstHandler;
            }

            lstHandler.Add(handler);
        }
        #endregion

        #region RemoveEventListener �Ƴ�����
        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void RemoveEventListener(ushort key, OnActionHandler handler)
        {
            List<OnActionHandler> lstHandler = null;
            dic.TryGetValue(key, out lstHandler);

            if (lstHandler != null)
            {
                lstHandler.Remove(handler);
                if (lstHandler.Count == 0)
                {
                    dic.Remove(key);
                }
            }
        }
        #endregion

        #region Dispatch �ɷ�
        /// <summary>
        /// �ɷ�
        /// </summary>
        /// <param name="key"></param>
        /// <param name="p"></param>
        public void Dispatch(ushort key, byte[] buffer)
        {
            List<OnActionHandler> lstHandler = null;
            dic.TryGetValue(key, out lstHandler);

            if (lstHandler != null)
            {
                int lstCount = lstHandler.Count;

                for (int i = 0; i < lstCount; i++)
                {
                    OnActionHandler handler = lstHandler[i];
                    if (handler != null)
                    {
                        handler(buffer);
                    }
                }
            }
        }

        public void Dispatch(ushort key)
        {
            Dispatch(key, null);
        }
        #endregion

        public void Dispose()
        {
            dic.Clear();
        }
    }
}
