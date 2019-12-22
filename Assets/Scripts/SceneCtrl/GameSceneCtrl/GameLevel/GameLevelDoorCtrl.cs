using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelDoorCtrl : MonoBehaviour
{
    /// <summary>
    /// ��������
    /// </summary>
    [SerializeField]
    public GameLevelDoorCtrl ConnectToDoor;

    /// <summary>
    /// ���������Id
    /// </summary>
    [HideInInspector]
    public int OwnerRegionId;
    // Use this for initialization
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
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(this.transform.position, 0.5f);

        if (ConnectToDoor != null)
        {
            Gizmos.DrawLine(this.transform.position, ConnectToDoor.gameObject.transform.position);
        }
    }
#endif
}
