using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneCtrlMgr : MonoBehaviour
{
    /// <summary>
    /// ��Ϸ�ؿ�����������
    /// </summary>
    [SerializeField]
    private GameLevelSceneCtrl GameLevelSceneCtrl;

    /// <summary>
    /// �����ͼ������������
    /// </summary>
    [SerializeField]
    private WorldMapSceneCtrl WorldMapSceneCtrl;
    // Use this for initialization

    //private Dictionary<SceneType, GameObject> m_Dic = new Dictionary<SceneType, GameObject>();

    [SerializeField]
    private Transform Ground;

    private void Awake()
    {
        if (GameLevelSceneCtrl != null)
        {
           // m_Dic[SceneType.GameLevel] = GameLevelSceneCtrl.gameObject;
        }

        if (WorldMapSceneCtrl != null)
        {
           // m_Dic[SceneType.WorldMap] = WorldMapSceneCtrl.gameObject;
        }

       // GameObject obj = m_Dic[SceneMgr.Instance.CurrSceneType];
        //if (obj != null)
        //{
        //    obj.SetActive(true);
        //}

        //foreach(var item in m_Dic)
        //{
        //    if (item.Key != SceneMgr.Instance.CurrSceneType)
        //    {
        //        Destroy(item.Value);
        //    }
        //}

        //���õ���Render����
        Renderer[] groundRenders = Ground.GetComponentsInChildren<Renderer>();
        if (groundRenders != null && groundRenders.Length > 0)
        {
            for (int i = 0; i < groundRenders.Length; i++)
            {
                groundRenders[i].enabled = false;
            }
        }
    }
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
