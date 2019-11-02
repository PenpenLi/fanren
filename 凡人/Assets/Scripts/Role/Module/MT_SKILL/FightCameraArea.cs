using System;
using System.Collections.Generic;
using UnityEngine;


public class FightCameraArea : MonoBehaviour
{
    public int AreaID;

    public bool PlayOnAwake = true;

    private bool bRun;

    public float AddDisance = 1f;

    public float AddHeight = 1f;

    // Token: 0x040001B8 RID: 440
    public int MonsterID;

    // Token: 0x040001B9 RID: 441
    public bool LookNoTrail;

    // Token: 0x040001BA RID: 442
    public float MoveTrailTime = 0.05f;

    // Token: 0x040001BB RID: 443
    public float MoveTrailTimeRate = 100f;

    // Token: 0x040001BC RID: 444
    public float EnterMoveTrailTime = 0.05f;

    // Token: 0x040001BD RID: 445
    public float EnterMoveTrailTimeRate = 100f;

    // Token: 0x040001BE RID: 446
    public float LookTrailRatio = 0.001f;

    // Token: 0x040001BF RID: 447
    public float LookMoveTrailRatio = 1E-07f;

    // Token: 0x040001C0 RID: 448
    public Vector3 Direction = Vector3.right;

    // Token: 0x040001C1 RID: 449
    public Vector3 ControlDirection = Vector3.zero;

    // Token: 0x040001C2 RID: 450
    public List<FightCameraArea.FeatureLensData> faetures = new List<FightCameraArea.FeatureLensData>();

    private CameraMove _CameraMove;

    private CameraLook _CameraLook;

    // Token: 0x040001C5 RID: 453
    private Transform cHero;

    // Token: 0x040001C6 RID: 454
    private Transform cMonster;

    // Token: 0x040001C7 RID: 455
    private FightCameraArea.EnterData data = new FightCameraArea.EnterData();

    // Token: 0x040001C8 RID: 456
    private Vector3 currentVelocity1;

    // Token: 0x040001C9 RID: 457
    private Vector3 currentVelocity2;

    // Token: 0x040001CA RID: 458
    private Vector3 lastLookPos;

    // Token: 0x040001CB RID: 459
    private Vector3 lastMovePos;

    [Serializable]
    public class FeatureLensData
    {
        // Token: 0x040001CC RID: 460
        public int ID;

        // Token: 0x040001CD RID: 461
        public Vector3 targetPos = Vector3.zero;

        // Token: 0x040001CE RID: 462
        public float Rate = 0.0005f;

        // Token: 0x040001CF RID: 463
        public float Time = 2f;
    }

    [HideInInspector]
	public bool IsRun
	{
		get
		{
			return this.bRun;
		}
		set
		{
			this.bRun = value;
			if (this.bRun)
			{
				this.OnEnter();
			}
		}
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00003C32 File Offset: 0x00001E32
	private Transform GetHero()
	{
		if (null == this.cHero && Player.Instance != null)
		{
			this.cHero = Player.Instance.GetTrans();
		}
		return this.cHero;
	}

	private Transform GetMonster()
	{
		if (this.cMonster == null)
		{
			//List<Role> allMonsters = FanrenSceneManager.RoleMan.GetAllMonsters(ROLE_TYPE.RT_MONSTER);
			//if (allMonsters != null && allMonsters.Count > 0)
			//{
			//	foreach (Role role in allMonsters)
			//	{
			//		if (role.GetDetailType() == this.MonsterID)
			//		{
			//			this.cMonster = role.GetTrans();
			//			break;
			//		}
			//	}
			//}
		}
		return this.cMonster;
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00026B9C File Offset: 0x00024D9C
	private void DataSet(bool bEnter)
	{
		if (bEnter)
		{
			this.data.ControlPos = Player.Instance.m_cModCamera.cameraControl.transform.position;
			this.data.ControlRotation = Player.Instance.m_cModCamera.cameraControl.transform.rotation;
			this.data.FatherlocalPos = Player.Instance.m_cModCamera.cameraFather.transform.localPosition;
			this.data.FatherlocalRotation = Player.Instance.m_cModCamera.cameraFather.transform.localRotation;
			this.data.CameralocalPos = Player.Instance.m_cModCamera.mainCamera.transform.localPosition;
			this.data.CameralocalRotation = Player.Instance.m_cModCamera.mainCamera.transform.localRotation;
		}
		else
		{
			if (Player.Instance != null && Player.Instance.m_cModCamera != null && Player.Instance.m_cModCamera.cameraControl != null && Player.Instance.m_cModCamera.cameraFather != null && Player.Instance.m_cModCamera.mainCamera != null)
			{
				Player.Instance.m_cModCamera.cameraControl.transform.rotation = this.data.ControlRotation;
				Player.Instance.m_cModCamera.cameraFather.transform.localPosition = this.data.FatherlocalPos;
				Player.Instance.m_cModCamera.cameraFather.transform.localRotation = this.data.FatherlocalRotation;
				Player.Instance.m_cModCamera.mainCamera.transform.localPosition = this.data.CameralocalPos;
				Player.Instance.m_cModCamera.mainCamera.transform.localRotation = Quaternion.identity;
			}
			this.data.Reset();
		}
	}

	private void OnTriggerEnter(Collider obj)
	{
		if (!this.IsPlaying())
		{
			return;
		}
		//if (!this.IsCheck(obj.gameObject))
		//{
		//	return;
		//}
		if (obj.tag != "Player")
		{
			return;
		}
		this.OnEnter();
	}

	// Token: 0x06000280 RID: 640 RVA: 0x00026DAC File Offset: 0x00024FAC
	private void OnEnter()
	{
		this.bRun = true;
		this.DataSet(true);
		Player.Instance.m_cModCamera.isLockCamera = true;
		this.EnterReady();
		this._CameraMove.Play();
		this._CameraLook.Play();
		this.OnAction(this.EnterMoveTrailTime, this.EnterMoveTrailTimeRate, false);
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00026E08 File Offset: 0x00025008
	private void EnterReady()
	{
		if (Player.Instance == null)
		{
			return;
		}
		if (Player.Instance.m_cModCamera.cameraFather == null)
		{
			return;
		}
		Player.Instance.m_cModCamera.cameraFather.transform.localPosition = Vector3.zero;
		Player.Instance.m_cModCamera.cameraFather.transform.localEulerAngles = this.ControlDirection;
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00026E78 File Offset: 0x00025078
	private void OnDisable()
	{
		if (this.IsRun && Player.Instance != null && Player.Instance.m_cModCamera != null)
		{
			this.bRun = false;
			this._CameraMove.Stop();
			this._CameraLook.Stop();
			this._CameraMove.Release();
			this._CameraLook.Release();
			this.DataSet(false);
			Player.Instance.m_cModCamera.isLockCamera = false;
		}
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00026EF8 File Offset: 0x000250F8
	private void OnTriggerExit(Collider obj)
	{
		if (!this.IsPlaying())
		{
			return;
		}
		if (obj.tag == "Player")
		{
			this.bRun = false;
			this._CameraMove.Stop();
			this._CameraLook.Stop();
			this._CameraMove.Release();
			this._CameraLook.Release();
			this.DataSet(false);
			Player.Instance.m_cModCamera.isLockCamera = false;
		}
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00026F74 File Offset: 0x00025174
	private void OnTriggerStay(Collider obj)
	{
		if (!this.IsPlaying())
		{
			return;
		}
		//if (!this.IsCheck(obj.gameObject))
		//{
		//	return;
		//}
		if (obj.tag != "Player")
		{
			return;
		}
		if (Player.Instance.m_cModCamera != null)
		{
			Player.Instance.m_cModCamera.cameraControl.transform.rotation = Quaternion.identity;
		}
		//if (!MovieManager.MovieMag.IsPlaying())
		//{
		//	Player.Instance.m_cModCamera.isLockCamera = true;
		//}
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00027004 File Offset: 0x00025204
	private void OnAction(float time, float rate, bool imme)
	{
		if (this.GetHero() == null)
		{
			return;
		}
		this.EnterReady();
		this.TempFun();
		float num = this.AddDisance + 0.65f;
		float num2 = this.AddHeight - 0.39f;
		Vector3 vector = Vector3.zero;
		vector = this.GetHero().position;
		Vector3 vector2 = (!(this.GetMonster() == null)) ? this.GetMonster().position : (this.GetHero().position + this.GetHero().forward * ((num + num2) / 2f));
		float num3 = vector.x + vector2.x;
		float x = num3 / 2f;
		float num4 = vector.y + vector2.y;
		float y = num4 / 2f + num2;
		float num5 = vector.z + vector2.z;
		float z = num5 / 2f;
		float num6 = Vector3.Distance(vector, vector2) + num + num2;
		Vector3 vector3 = new Vector3(x, y, z);
		Vector3 vector4 = vector3 + this.Direction * num6;
		if (this.GetMonster() != null)
		{
			this._CameraMove.AddPos(vector4, num6 * time, rate, imme);
			this._CameraLook.AddPos(vector3, (!this.LookNoTrail) ? this.LookTrailRatio : 0f, (!this.LookNoTrail) ? this.LookMoveTrailRatio : 0f, this.LookNoTrail);
		}
		else
		{
			//GameObject playerCamera = BroadcastManager.Instance.GetPlayerCamera();
			//if (playerCamera != null)
			//{
			//	Vector3 position = playerCamera.transform.position;
			//	playerCamera.transform.position = Vector3.SmoothDamp(position, vector4, ref this.currentVelocity1, time * GameTime.deltaTime);
			//	this._CameraLook.AddPos(vector, (!this.LookNoTrail) ? this.LookTrailRatio : 0f, (!this.LookNoTrail) ? this.LookMoveTrailRatio : 0f, true);
			//}
		}
	
			Debug.DrawLine(vector, vector2, Color.red);
			Debug.DrawLine(vector4, vector3, Color.yellow);
		
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00003CA1 File Offset: 0x00001EA1
	public bool IsPlaying()
	{
		return this.PlayOnAwake || this.IsRun;
	}

	// Token: 0x06000287 RID: 647 RVA: 0x0002724C File Offset: 0x0002544C
	//private bool IsCheck(GameObject obj)
	//{
	//	return !MovieManager.MovieMag.IsPlaying() && !Singleton<DrillSystem>.GetInstance().IsDrillState && !(this.GetHero() == null) && (obj.tag == "Player" || obj.tag == "Monster");
	//}

	// Token: 0x06000288 RID: 648 RVA: 0x000272BC File Offset: 0x000254BC
	//public void ApplyFeature(int featureID, OnFeatureEnd callBack)
	//{
	//	FightCameraArea.FeatureLensData featureLensData = null;
	//	foreach (FightCameraArea.FeatureLensData featureLensData2 in this.faetures)
	//	{
	//		if (featureLensData2.ID == featureID)
	//		{
	//			featureLensData = featureLensData2;
	//		}
	//	}
	//	if (featureLensData == null)
	//	{
	//		return;
	//	}
	//	BroadcastManager.Instance.ApplyFeatureLens(this.AreaID, featureLensData.ID, featureLensData.targetPos, featureLensData.Rate, featureLensData.Time, callBack);
	//}

	private void Awake()
	{
	}

	private void Start()
	{
		//BroadcastManager.Instance.AddArea(this.AreaID, this);
		//this._CameraMove = BroadcastManager.Instance.MainMove;
		//this._CameraLook = BroadcastManager.Instance.MainLook;
	}

	private void Update()
	{
		if (!this.bRun)
		{
			return;
		}
		if (!this.IsPlaying())
		{
			return;
		}
		//if (MovieManager.MovieMag.IsPlaying() || Singleton<DrillSystem>.GetInstance().IsDrillState)
		//{
		//	return;
		//}
		this.OnAction(this.MoveTrailTime, this.MoveTrailTimeRate, true);
	}

	private void TempFun()
	{
		//if (BroadcastManager.Instance.MainFrame != null)
		//{
		//	BroadcastManager.Instance.MainFrame.IsStart = true;
		//	BroadcastManager.Instance.MainFrame.IsPause = false;
		//	BroadcastManager.Instance.MainFrame.IsEnd = false;
		//}
		//if (this._CameraMove != null)
		//{
		//	this._CameraMove.IsStart = true;
		//	this._CameraMove.IsPause = false;
		//}
		//if (this._CameraLook != null)
		//{
		//	this._CameraLook.IsStart = true;
		//	this._CameraLook.IsPause = false;
		//}
	}

	private Vector3 CheckCameraHit(Vector3 position)
	{
		Ray ray = new Ray(position, Vector3.back);
		RaycastHit raycastHit;
		if (Physics.SphereCast(ray, 2f, out raycastHit))
		{
			//Logger.DrawLine(position, raycastHit.point, Color.yellow);
			return raycastHit.point;
		}
		return position;
	}

	public class EnterData
	{
        public Vector3 ControlPos = Vector3.zero;

        // Token: 0x040001D1 RID: 465
        public Quaternion ControlRotation = Quaternion.identity;

        // Token: 0x040001D2 RID: 466
        public Vector3 FatherlocalPos = Vector3.zero;

        // Token: 0x040001D3 RID: 467
        public Quaternion FatherlocalRotation = Quaternion.identity;

        // Token: 0x040001D4 RID: 468
        public Vector3 CameralocalPos = Vector3.zero;

        // Token: 0x040001D5 RID: 469
        public Quaternion CameralocalRotation = Quaternion.identity;

        public void Reset()
		{
			this.ControlPos = Vector3.zero;
			this.ControlRotation = Quaternion.identity;
			this.FatherlocalPos = Vector3.zero;
			this.FatherlocalRotation = Quaternion.identity;
			this.CameralocalPos = Vector3.zero;
			this.CameralocalRotation = Quaternion.identity;
		}
	}
}
