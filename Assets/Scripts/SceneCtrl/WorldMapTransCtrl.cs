using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapTransCtrl : MonoBehaviour
{
    /// <summary>
    /// 传送点编号
    /// </summary>
    private int m_TransPosId;

    /// <summary>
    /// 要传送点目标场景Id
    /// </summary>
    private int m_TargetTransSceneId;

    /// <summary>
    /// 目标场景传送点Id
    /// </summary>
    private int m_TargetSceneTransId;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetParam(int transPosId, int targetTransSceneId, int targetSceneTransId)
    {
        m_TransPosId = transPosId;
        m_TargetTransSceneId = targetTransSceneId;
        m_TargetSceneTransId = targetSceneTransId;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            //SceneMgr.Instance.TargertWorldMapTransPosId = m_TargetSceneTransId;
            //SceneMgr.Instance.LoadToWorldMap(m_TargetTransSceneId);
        }
    }
}
