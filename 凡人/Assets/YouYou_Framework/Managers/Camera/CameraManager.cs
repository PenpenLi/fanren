using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{
    public class CameraManager : ManagerBase
    {
        /// <summary>
        /// 控制摄像机上下
        /// </summary>
        [SerializeField]
        private Transform m_CameraUpAndDown;

        /// <summary>
        /// 摄像机缩放父物体
        /// </summary>
        [SerializeField]
        private Transform m_CameraZoomContainer;

        /// <summary>
        /// 摄像机容器
        /// </summary>
        [SerializeField]
        private Transform m_CameraContainer;
    }
}
