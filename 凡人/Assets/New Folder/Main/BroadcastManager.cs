using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 播放
/// </summary>
public class BroadcastManager : MonoBehaviour
{
    public static BroadcastManager Instance;

 //   public CameraFrame MainFrame;

 //   public CameraFrame MainFeature;

 //   public CameraMove MainMove;

 //   public CameraLook MainLook;

 //   private Dictionary<int, CameraFrame> _Frames = new Dictionary<int, CameraFrame>();

 //   private Dictionary<int, FightCameraArea> _Areas = new Dictionary<int, FightCameraArea>();

 //   private BroadcastManager.FeatureData feature = new BroadcastManager.FeatureData();

 //   private List<int> Playings = new List<int>();

 //   private int offset;

 //   public class FeatureData
 //   {
 //       public int ID;

 //       public bool bIsFeature;

 //       public float MoveTime;

 //       public float StartTime;

 //       public Vector3 to;

 //       public float Rate;

 //       public Vector3 srcDirection = Vector3.zero;

 //       public int areaID;

 //       public OnFeatureEnd callBack;

 //       public Vector3 currentVelocity;
 //   }


 //   public bool IsPause { get; set; }

	//public CameraFrame CurrentFrame { get; private set; }

	//public GameObject GetPlayerCamera()
	//{
	//	if (Player.Instance == null)
	//	{
	//		return null;
	//	}
	//	if (Player.Instance.m_cModCamera == null)
	//	{
	//		return null;
	//	}
	//	return Player.Instance.m_cModCamera.cameraControl;
	//}

	//public void AddArea(int id, FightCameraArea obj)
	//{
	//	if (this._Areas.ContainsKey(id))
	//	{
	//		Debug.Log("fight area is contains!");
	//		return;
	//	}
	//	this._Areas.Add(id, obj);
	//}

	//public void RemoveArea(int id)
	//{
	//	if (this._Areas.ContainsKey(id))
	//	{
	//		this._Areas.Remove(id);
	//	}
	//}

	//public FightCameraArea GetArea(int id)
	//{
	//	if (this._Areas.ContainsKey(id))
	//	{
	//		return this._Areas[id];
	//	}
	//	return null;
	//}

	//public bool AddFrame(CameraFrame frame)
	//{
	//	if (frame == null || this._Frames.ContainsKey(frame.ID))
	//	{
	//		return false;
	//	}
	//	this._Frames.Add(frame.ID, frame);
	//	return true;
	//}

	//public void RemoveFrame(int id)
	//{
	//	if (!this._Frames.ContainsKey(id))
	//	{
	//		return;
	//	}
	//	this._Frames[id].Stop();
	//	this._Frames.Remove(id);
	//}

	//public bool PlayFrame(params int[] frames)
	//{
	//	if (frames == null || frames.Length < 1)
	//	{
	//		return false;
	//	}
	//	foreach (int key in frames)
	//	{
	//		if (!this._Frames.ContainsKey(key))
	//		{
	//			return false;
	//		}
	//	}
	//	this.Playings.Clear();
	//	this.offset = 0;
	//	this.Playings.AddRange(frames);
	//	return true;
	//}

	//public void ApplyFeatureLens(int areaID, int ID, Vector3 to, float rate, float time, OnFeatureEnd callBack)
	//{
	//	if (!this._Areas.ContainsKey(areaID))
	//	{
	//		return;
	//	}
	//	this.feature.srcDirection = this._Areas[areaID].Direction;
	//	this.feature.to = to;
	//	this.feature.ID = ID;
	//	this.feature.Rate = rate;
	//	this.feature.MoveTime = time;
	//	this.feature.StartTime = GameTime.time;
	//	this.feature.areaID = areaID;
	//	this.feature.bIsFeature = true;
	//	this.feature.callBack = callBack;
	//}

	//private void Init()
	//{
	//	this.MainFrame = new CameraFrame();
	//	if (this.MainFrame.Create(0) && this.AddFrame(this.MainFrame))
	//	{
	//		this.MainMove = this.MainFrame.AddAction<CameraMove>(null);
	//		this.MainLook = this.MainFrame.AddAction<CameraLook>(null);
	//	}
	//	this.MainFrame.Play();
	//	this.PlayFrame(new int[1]);
	//}

	//private void OnEnd(int id)
	//{
	//}

	//private void Awake()
	//{
	//	BroadcastManager.Instance = this;
	//	this.Init();
	//}
	//public void Clear()
	//{
	//	foreach (CameraFrame cameraFrame in this._Frames.Values)
	//	{
	//		cameraFrame.Release();
	//	}
	//	this._Frames.Clear();
	//}

	//private void Update()
	//{
	//	if (GameTime.IsPause || this.IsPause)
	//	{
	//		return;
	//	}
	//	if (this._Frames.Count < 1 || this.Playings.Count < 1)
	//	{
	//		return;
	//	}
	//	CameraFrame cameraFrame = this._Frames[this.Playings[this.offset]];
	//	if (cameraFrame.IsStart && !cameraFrame.IsPause && !cameraFrame.IsEnd)
	//	{
	//		cameraFrame.Update();
	//	}
	//	if (cameraFrame.IsEnd)
	//	{
	//		this.OnEnd(cameraFrame.ID);
	//		this.offset++;
	//	}
	//	if (this.offset >= this.Playings.Count)
	//	{
	//		this.Playings.Clear();
	//	}
	//	if (this.feature != null && this.feature.bIsFeature && this._Areas.ContainsKey(this.feature.areaID))
	//	{
	//		float num;
	//		if (this.feature.MoveTime <= 0f)
	//		{
	//			num = 1f;
	//		}
	//		else
	//		{
	//			num = (GameTime.time - this.feature.StartTime) / this.feature.MoveTime;
	//			this.feature.MoveTime -= this.feature.Rate;
	//		}
	//		if (num >= 1f)
	//		{
	//			this.feature.bIsFeature = false;
	//			this._Areas[this.feature.areaID].Direction = this.feature.to;
	//		}
	//		else
	//		{
	//			Vector3 direction = Vector3.Lerp(this._Areas[this.feature.areaID].Direction, this.feature.to, num);
	//			if (direction.y < 0f)
	//			{
	//				direction[1] = 0f;
	//			}
	//			this._Areas[this.feature.areaID].Direction = direction;
	//		}
	//		if (!this.feature.bIsFeature || this._Areas[this.feature.areaID].Direction == this.feature.to)
	//		{
	//			if (this.feature.callBack != null)
	//			{
	//				this.feature.callBack(this.feature.areaID, this.feature.ID);
	//			}
	//			this.feature.bIsFeature = false;
	//		}
	//	}
	//}
}
