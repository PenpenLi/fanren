using System;
using System.Collections.Generic;
using UnityEngine;


[AddComponentMenu("相机状态切换控制/CameraBoxsSelect")]
public class CameraBoxsSelect : MonoBehaviour
{
    public static CameraBoxsSelect Instance;

    public bool IsCheckStop;

    public List<CameraBoxsSelect.ChangeEvents> _Events;

    [HideInInspector]
    public CameraBoxsSelect.ChangeState _NowState = CameraBoxsSelect.ChangeState.CS_NORMAL;

    private CameraBoxsSelect.ChangeState _LastState;

    private List<GameObject> _TempBoxs;

    [Serializable]
    public enum ChangeState
    {
        CS_NONE,
        CS_NORMAL,
        CS_FIGHT
    }

    [Serializable]
    public class ChangeEvents
    {
        public CameraBoxsSelect.ChangeState _State;

        public List<GameObject> _Boxs;
    }

    private void Awake()
	{
		CameraBoxsSelect.Instance = this;
	}

	private void Update()
	{
		if (this._Events == null)
		{
			return;
		}
		if (this.IsCheckStop)
		{
			return;
		}
		if (this._NowState == this._LastState)
		{
			return;
		}
		foreach (CameraBoxsSelect.ChangeEvents changeEvents in this._Events)
		{
			if (changeEvents._Boxs != null && changeEvents._Boxs.Count >= 1)
			{
				this._TempBoxs = changeEvents._Boxs;
				bool activeRecursively = this._NowState == changeEvents._State;
				foreach (GameObject gameObject in this._TempBoxs)
				{
					if (!(gameObject == null))
					{
						gameObject.SetActiveRecursively(activeRecursively);
					}
				}
			}
		}
		this._LastState = this._NowState;
	}
}
