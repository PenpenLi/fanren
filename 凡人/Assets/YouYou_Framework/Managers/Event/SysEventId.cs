using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    /// <summary>
    /// ϵͳ�¼���ţ�ϵͳ�¼� ��� ����4λ 1001��10��ʾģ�� 01��ʾ��ţ���
    /// </summary>
    public class SysEventId 
    {
        /// <summary>
        /// ���ر�����
        /// </summary>
        public const ushort LoadDataTableComplete = 1001;

        /// <summary>
        /// ���ص�һ������
        /// </summary>
        public const ushort LoadOneDataTableComplete = 1002;

        /// <summary>
        /// ����Lua������
        /// </summary>
        public const ushort LoadLuaDataTableComplete = 1003;

        /// <summary>
        /// ���س���
        /// </summary>
        public const ushort LoadingProgressChange = 1104;
    }
}
