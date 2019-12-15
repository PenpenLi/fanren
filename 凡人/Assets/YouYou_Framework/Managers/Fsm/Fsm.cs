using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ״̬��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Fsm<T>: FsmBase where T:class
    {
        /// <summary>
        /// ��ǰ״̬
        /// </summary>
        private FsmState<T> m_CurrState;

        /// <summary>
        /// ״̬�ֵ�
        /// </summary>
        private Dictionary<byte, FsmState<T>> m_StateDic;

        /// <summary>
        /// �����ֵ�
        /// </summary>
        private Dictionary<string, VariableBase> m_ParamDic;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="fsmId">״̬�����</param>
        /// <param name="owner">ӵ����</param>
        /// <param name="status">״̬����</param>
        public Fsm(int fsmId, T owner, FsmState<T>[] states):base(fsmId)
        {
            m_StateDic = new Dictionary<byte, FsmState<T>>();
            m_ParamDic = new Dictionary<string, VariableBase>();

            int len = states.Length;
            for(int i = 0; i < len; i++)
            {
                FsmState<T> state = states[i];
                state.CurrFsm = this;
                m_StateDic[(byte)i] = state;
            }

            CurrStateType = 0;
            m_CurrState = m_StateDic[CurrStateType];
            m_CurrState.OnEnter();
        }

        /// <summary>
        /// ��ȡ״̬
        /// </summary>
        /// <param name="stateType"></param>
        /// <returns></returns>
        public FsmState<T> GetState(byte stateType)
        {
            FsmState<T> state = null;
            m_StateDic.TryGetValue(stateType, out state);
            return state;
        }

        public void OnUpdate()
        {
            if (m_CurrState!=null)
            {
                m_CurrState.OnUpdate();
            }
        }

        /// <summary>
        /// �л�״̬
        /// </summary>
        /// <param name="newState"></param>
        public void ChangeState(byte newState)
        {
            //����״̬һ�����ظ�����
            if (CurrStateType == newState)
            {
                return;
            }

            if (m_CurrState != null)
            {
                m_CurrState.OnLeave();
            }

            CurrStateType = newState;
            m_CurrState = m_StateDic[CurrStateType];

            m_CurrState.OnEnter();
        }

        /// <summary>
        /// ���ò���ֵ
        /// </summary>
        /// <typeparam name="TData">��������</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData<TData>(string key,TData value)
        {
            VariableBase itemBase = null;
            if(m_ParamDic.TryGetValue(key,out itemBase))
            {
                Variable<TData> item = itemBase as Variable<TData>;
                item.Value = value;
                m_ParamDic[key] = item;
            }
            else
            {
                Variable<TData> item = new Variable<TData>();
                item.Value = value;
                m_ParamDic[key] = item;
            }
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TData GetData<TData>(string key)
        {
            VariableBase itemBase = null;
            if (m_ParamDic.TryGetValue(key, out itemBase))
            {
                Variable<TData> item = itemBase as Variable<TData>;
                return item.Value;
            }
            return default(TData);
        }

        /// <summary>
        /// �ر�״̬��
        /// </summary>
        public override void ShutDown()
        {
            if (m_CurrState != null)
            {
                m_CurrState.OnLeave();
            }

            foreach (KeyValuePair<byte,FsmState<T>> state in m_StateDic)
            {
                state.Value.OnDestroy();
            }
            m_StateDic.Clear();
            m_ParamDic.Clear();
        }

    }
}
