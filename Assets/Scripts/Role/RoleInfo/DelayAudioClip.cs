//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2017-05-14 17:49:16
//备    注：
//===================================================
using UnityEngine;
using System.Collections;

[System.Serializable]
public class DelayAudioClip
{
    /// <summary>
    /// 要播放的声音片段
    /// </summary>
    public string AudioClipName;

    /// <summary>
    /// 延迟多少秒后才开始播放
    /// </summary>
    public float DelayTime;
}