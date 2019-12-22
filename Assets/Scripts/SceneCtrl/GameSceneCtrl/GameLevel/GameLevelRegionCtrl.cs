using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelRegionCtrl : MonoBehaviour
{
    /// <summary>
    /// 区域编号
    /// </summary>
    public int RegionId;

    /// <summary>
    /// 角色出生点
    /// </summary>
    public Transform RoleBornPos;

    /// <summary>
    /// 怪的出生点
    /// </summary>
    public Transform[] MonsterBornPos;

    /// <summary>
    /// 所有的门
    /// </summary>
    [SerializeField]
    private GameLevelDoorCtrl[] AllDoor;

    /// <summary>
    /// 区域遮挡物体
    /// </summary>
    [SerializeField]
    public GameObject RegionMask;
    // Use this for initialization
    private void Awake()
    {
        if (MonsterBornPos != null && MonsterBornPos.Length > 0)
        {
            for (int i = 0; i < MonsterBornPos.Length; i++)
            {
                Renderer render = MonsterBornPos[i].GetComponent<Renderer>();
                if (render != null) render.enabled = false;
            }
        }

        if (AllDoor != null && AllDoor.Length > 0)
        {
            for (int i = 0; i < AllDoor.Length; i++)
            {
                Renderer render = AllDoor[i].GetComponent<Renderer>();
                if (render != null) render.enabled = false;

                AllDoor[i].OwnerRegionId = RegionId;
            }
        }
    }

    public GameLevelDoorCtrl GetToNextRegionDoor(int nextRegionId)
    {
        if (AllDoor != null && AllDoor.Length > 0)
        {
            for(int i = 0; i < AllDoor.Length;i++)
            {
                if(AllDoor[i].ConnectToDoor.OwnerRegionId== nextRegionId)
                {
                    return AllDoor[i];
                }
            }
        }
        return null;
    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(this.transform.position, 0.6f);

        if (RoleBornPos != null)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(RoleBornPos.position, 0.6f);

            Gizmos.DrawLine(transform.position, RoleBornPos.position);
        }

        if(MonsterBornPos!=null&& MonsterBornPos.Length > 0)
        {
            Gizmos.color = Color.red;
            for(int i = 0; i < MonsterBornPos.Length; i++)
            {
                Gizmos.DrawSphere(MonsterBornPos[i].position, 0.6f);
                Gizmos.DrawLine(transform.position, MonsterBornPos[i].position);
            }
        }

        if (AllDoor != null && AllDoor.Length > 0)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < AllDoor.Length; i++)
            {
                Gizmos.DrawSphere(AllDoor[i].transform.position, 0.6f);
                Gizmos.DrawLine(transform.position, AllDoor[i].transform.position);
            }
        }
    }
#endif
}
