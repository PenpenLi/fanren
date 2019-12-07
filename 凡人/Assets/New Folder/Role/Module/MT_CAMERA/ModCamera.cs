using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// 摄像机模块
/// </summary>
public class ModCamera : Module
{
    public string ClassName = "ModCamera";

    private GameObject cameraControlGO;

    public GameObject cameraFather;

    private Transform cameraTrans;

    private Transform _target;

    public float minDistance = 4f;

    public float currentDistance = 8f;

    public float nomalDistance = 8f;

    public float maxDistance = 12f;

    private float checkDistance = 4f;

    public float height = 2f;

    public float centerHeight = 3f;

    private float targetDistance;

    private float near = 0.5f;

    public float far = 80f;

    public float fieldOfView = 60f;

    public float moveTime = 0.5f;

    private Vector3 velocity = Vector3.zero;

    public float smoothTime = 0.06f;

    public Vector3 cameraLockPosition = Vector3.zero;

    public Vector3 vLockAxis = Vector3.zero;

    public Vector2 vXLockFollowLimit = Vector2.zero;

    public Vector2 vYLockFollowLimit = Vector2.zero;

    public Vector2 vZLockFollowLimit = Vector2.zero;

    public Vector3 FollowPositionLockAxisOffset = Vector3.zero;

    public Vector3 FollowPositionLockAxisRotation = Vector3.zero;

    private float xSpeed = 80f;

    private float ySpeed = 40f;

    private float offsetY;

    private float offsetStep;

    private float offsetSpeed = 0.02f;

    private float yMinLimit = -8f;

    private float yMaxLimit = 60f;

    public float x;

    public float y;

    public float deltaTime = 6f;

    public bool isMouseOrbit = true;

    public bool isSmooth;

    private float curDist;

    private Vector3 moveDist = new Vector3(0f, 1f, 0f);

    public LayerMask layerMask = 8194;

    private RaycastHit rayHit;

    public bool isLockCamera;

    public bool isScaleCamera = true;

    private Transform cacheTransform;

    public Camera mainCamera = Camera.main;

    public ModCamera.CameraState cameraState;

    public GameObject CameraGo;

    public Transform transform;

    public enum CameraState
    {
        Null,
        Shake,
        LockCamera,
        FollowPositionAutoRotation,
        LockPositionAutoLook,
        MouseOrbit,
        LookTarget,
        Stop,
        FollowPositionLockAxis
    }

    public GameObject cameraControl
	{
		get
		{
			return this.cameraControlGO;
		}
		set
		{
			this.cameraControlGO = value;
		}
	}

	public Transform cameraTransform
	{
		get
		{
			return this.cameraTrans;
		}
		set
		{
			this.cameraTrans = value;
		}
	}

	public static Module Create(GameObject go, Role role)
	{
		return new ModCamera
		{
			_role = role,
			CameraGo = go,
			ModType = MODULE_TYPE.MT_CAMERA,
			transform = go.transform
		};
	}

	public override bool Init()
	{
		this.Start();
		return base.Init();
	}

	private void Start()
	{
        if (this._role == null)
		{
            return;
		}
		if (this._role._roleType != ROLE_TYPE.RT_PLAYER)//如果角色不是玩家 锁定摄像机
		{
			this.isLockCamera = true;
		}
        if (!this.cameraTransform && Camera.main)
		{
            this.cameraTransform = Camera.main.transform;
        }
		if (!this.cameraTransform)
		{
            this.cameraTransform = Singleton<ActorManager>.GetInstance().MainCamera.transform;
			Debug.Log("Please assign a camera to the modCamera script.");
			this.m_bEnabled = false;
		}
		this.cameraTransform.name = "Main Camera";
		SceneInfo scenenInfo = FanrenSceneManager.curScenenInfo;
		if (scenenInfo != null)
		{
			string name = "CameraRenderBox_" + scenenInfo.name;
			GameObject gameObject = GameObject.Find(name);
			if (gameObject != null)
			{
				gameObject.name = "CameraRenderBox";
			}
		}
		GameObject obj = GameObject.Find("CameFather2");
		this.cameraFather = new GameObject("CameFather2");
		this.cameraTransform.parent = this.cameraFather.transform;
		this.cameraTransform = this.cameraFather.transform;
		if (obj != null)
		{
			UnityEngine.Object.Destroy(obj);
		}
		GameObject obj2 = GameObject.Find("CameraControl");
		this.cameraControl = new GameObject("CameraControl");
		if (obj2 != null)
		{
			UnityEngine.Object.Destroy(obj2);
		}
		this.cameraTransform.parent = this.cameraControl.transform;
		this._target = this.transform;
		this.InitCamera();
		this.StartMouseOrbit();
	}

    /// <summary>
    /// 初始化摄像机
    /// </summary>
	private void InitCamera()
	{
		LayerMask mask = 33643520;
		this.isLockCamera = true;
		this.cameraState = ModCamera.CameraState.MouseOrbit;
		this.mainCamera = Camera.main;
		Camera.main.cullingMask = ~mask;
		Camera.main.backgroundColor = RenderSettings.fogColor;
		this.isLockCamera = false;
		this.InitPosition();
	}

    /// <summary>
    /// 初始化位置
    /// </summary>
	public void InitPosition()
	{
		this.isLockCamera = true;
		this.x = this._role.GetTrans().rotation.eulerAngles.y + 90f;
		this.y = 30f;
		this.cameraControl.transform.rotation = Quaternion.Euler(0f, this.x, this.y);
		this.cameraControl.transform.position = Player.Instance.GetTrans().position;
		this.cameraTransform.transform.localPosition = Vector3.right * this.nomalDistance + this.moveDist;
		this.cameraTransform.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
		Camera.main.transform.localPosition = Vector3.zero;
		Camera.main.transform.localRotation = Quaternion.identity;
		this.isLockCamera = false;
	}

	public override void Process()
	{
        if (!this.m_bEnabled)
		{
            return;
		}
		if (this.isLockCamera)
		{
            return;
		}
		if (!this.cameraTransform)
		{
            return;
		}
        switch (this.cameraState)
        {
            case ModCamera.CameraState.LockCamera:
                this.LockCamera();
                break;
            case ModCamera.CameraState.FollowPositionAutoRotation:
                this.CameraFollowPositionAutoRotation();
                break;
            case ModCamera.CameraState.LockPositionAutoLook:
                this.CameraLockPositionAutoLook();
                break;
            case ModCamera.CameraState.MouseOrbit:
                this.UpdateMouseOrbit();
                break;
            case ModCamera.CameraState.LookTarget:
                this.LookTarget();
                break;
            case ModCamera.CameraState.Stop:
                this.StopCamera();
                break;
            case ModCamera.CameraState.FollowPositionLockAxis:
                this.UpdateFollowPositionLockAxis();
                break;
        }
        this.CheckCameraHit();
	}

	public void SetCameraState(ModCamera.CameraState state)
	{
		if (this.cameraState == ModCamera.CameraState.LookTarget && (state == ModCamera.CameraState.FollowPositionAutoRotation || state == ModCamera.CameraState.LockPositionAutoLook || state == ModCamera.CameraState.LockCamera))
		{
			return;
		}
		this.cameraState = state;
		switch (this.cameraState)
		{
		case ModCamera.CameraState.MouseOrbit:
			this.StartMouseOrbit();
			break;
		}
	}

	private void StopCamera()
	{
		this.cameraControl.transform.rotation = this.cameraControl.transform.rotation;
		this.cameraControl.transform.position = this.cameraControl.transform.position;
	}

	private void LockCamera()
	{
		Quaternion rotation = Quaternion.Euler(0f, this.x, this.y);
		this.cameraControl.transform.rotation = rotation;
		this.cameraControl.transform.position = this.cameraLockPosition;
		this.cameraTransform.parent = this.cameraControl.transform;
		this.cameraTransform.transform.localPosition = Vector3.right * this.curDist + this.moveDist;
		this.cameraTransform.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
		this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	public void CameraFollowPositionAutoRotation()
	{
		if (this._target == null)
		{
			return;
		}
		this.cameraTransform.parent = this.cameraControl.transform;
		this.cameraTransform.transform.localPosition = Vector3.right * this.curDist + this.moveDist;
		this.cameraTransform.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
		this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
		this.AutoRotationLook();
		Vector3 position = this._role.GetTrans().position;
		this.cameraControl.transform.position = Vector3.SmoothDamp(this.cameraControl.transform.position, position, ref this.velocity, this.smoothTime);
	}

	public void UpdateFollowPositionLockAxis()
	{
		this.cameraTransform.parent = this.cameraControl.transform;
		this.cameraTransform.transform.localPosition = Vector3.right * this.curDist + this.moveDist;
		this.cameraTransform.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
		this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
		Quaternion to = Quaternion.Euler(0f, this.x + this.FollowPositionLockAxisRotation.y, this.y + this.FollowPositionLockAxisRotation.z);
		if (Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.y) != Mathf.Round(to.eulerAngles.y) || Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.z) != Mathf.Round(to.eulerAngles.z))
		{
			this.cameraControl.transform.rotation = Quaternion.Lerp(this.cameraControl.transform.rotation, to, Time.deltaTime * this.moveTime);
		}
		float num = (this.vLockAxis.x != 0f) ? this.cameraControl.transform.position.x : this._role.GetTrans().position.x;
		float num2 = (this.vLockAxis.y != 0f) ? this.cameraControl.transform.position.y : this._role.GetTrans().position.y;
		float num3 = (this.vLockAxis.z != 0f) ? this.cameraControl.transform.position.z : this._role.GetTrans().position.z;
		Vector3 target = new Vector3(num + this.FollowPositionLockAxisOffset.x, num2 + this.FollowPositionLockAxisOffset.y, num3 + this.FollowPositionLockAxisOffset.z);
		this.cameraControl.transform.position = Vector3.SmoothDamp(this.cameraControl.transform.position, target, ref this.velocity, this.smoothTime);
	}

	public void AutoRotationLook()
	{
		Quaternion to = Quaternion.Euler(0f, this.x, this.y);
		if (Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.y) != Mathf.Round(to.eulerAngles.y) || Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.z) != Mathf.Round(to.eulerAngles.z))
		{
			this.cameraControl.transform.rotation = Quaternion.Lerp(this.cameraControl.transform.rotation, to, Time.deltaTime * this.moveTime);
		}
	}

	public void CameraLookTarget(Transform targetTransform, float targetHeight, float targetDist)
	{
		if (targetTransform == null)
		{
			return;
		}
		this._target = targetTransform;
		this.isScaleCamera = false;
		this.height = targetHeight;
		this.targetDistance = targetDist;
		this.SetCameraState(ModCamera.CameraState.LookTarget);
	}

	private void LookTarget()
	{
		if (this._target == null)
		{
			return;
		}
		Vector3 vector = this._target.transform.position + new Vector3(0f, this.height, 0f);
		this.cameraTransform.parent = this.cameraControl.transform;
		this.cameraTransform.transform.localPosition = Vector3.right * this.targetDistance;
		this.cameraTransform.transform.LookAt(vector);
		this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
		this.cameraControl.transform.position = Vector3.SmoothDamp(this.cameraControl.transform.position, vector, ref this.velocity, this.smoothTime);
	}

	private void CameraLockPositionAutoLook()
	{
		if (this._target == null)
		{
			return;
		}
		Quaternion quaternion = Quaternion.Euler(0f, this.x, this.y);
		this.cameraControl.transform.position = this.cameraLockPosition;
		Vector3 position = this._role.GetTrans().position;
		this.cameraTransform.transform.LookAt(position);
		this.cameraFather.transform.localPosition = Vector3.zero;
	}

	public void ShakeCameraRotation(Vector3 amount, float time)
	{
		//iTween.ShakeRotation(this.cameraTransform.gameObject, amount, time);
	}

	public void ShakeCameraPosition(Vector3 amount, float time)
	{
		//SingletonMono<ScreenShockController>.GetInstance().Shock(amount, time);
	}

	public void ReSetCamera(bool resetDist = false)
	{
		this.SetCamearTarget(this.transform);
		this.isScaleCamera = true;
		this.isLockCamera = false;
		if (resetDist)
		{
			this.currentDistance = this.nomalDistance;
		}
		this.height = 2f;
		this.centerHeight = 3f;
	}

	public void ScaleCamera(float delta)
	{
		if (this.isScaleCamera)
		{
			this.currentDistance += Event.current.delta.y / 6f;
			if (this.currentDistance < this.minDistance)
			{
				this.currentDistance = this.minDistance;
			}
			if (this.currentDistance > this.maxDistance)
			{
				this.currentDistance = this.maxDistance;
			}
		}
	}

	public void SetCamearTarget(Transform transform)
	{
		this._target = transform;
	}

	public void SetOrignTarget(Transform trans)
	{
		this._target = trans;
		this.transform = trans;
		this.CameraGo = trans.gameObject;
	}

	public void StartMouseOrbit()
	{
		this.cameraState = ModCamera.CameraState.MouseOrbit;
		this.ReSetCamera(false);
		this.x = this.cameraControl.transform.eulerAngles.y;
		this.y = this.cameraControl.transform.eulerAngles.z;
        
        if (transform.GetComponent<Rigidbody>())
        {
            this.transform.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

	public void UpdateMouseOrbit()
	{
		if (KeyManager.hotKeyEnabled && this._target && this.cameraTransform && Time.timeScale != 0f)
		{
            if (this.isMouseOrbit)
			{
                this.x += Input.GetAxis("Mouse X") * this.xSpeed * this.offsetSpeed;
				this.y -= Input.GetAxis("Mouse Y") * this.ySpeed * this.offsetSpeed;
				this.y = ModCamera.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
			}
			this.cameraTransform.parent = this.cameraControl.transform;
			this.cameraControl.transform.rotation = Quaternion.Euler(0f, this.x, this.y);
			Vector3 position = Vector3.SmoothDamp(this.cameraControl.transform.position, this._target.position, ref this.velocity, this.smoothTime);
			this.cameraControl.transform.position = position;
			if (this.y < 0f)
			{
				this.curDist = Mathf.Lerp(this.cameraTransform.transform.localPosition.x, this.minDistance + this.y, Time.deltaTime * this.deltaTime);
				this.checkDistance = 2f;
			}
			this.CheckDistance();
			this.cameraTransform.transform.localPosition = Vector3.right * this.curDist + this.moveDist;
			this.cameraTransform.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
			this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}

	private void CheckDistance()
	{
		if (this.curDist < this.checkDistance)
		{
			this.curDist = this.checkDistance;
		}
		if (this.curDist > this.maxDistance)
		{
			this.curDist = this.maxDistance;
		}
	}

    /// <summary>
    /// 检查摄像机碰撞
    /// </summary>
    /// <returns></returns>
	private float CheckCameraHit()
	{
		Vector3 vector = this.cameraControl.transform.position + new Vector3(0f, 1f, 0f);
		Vector3 vector2 = vector - this.cameraTransform.forward * this.currentDistance;
		Debug.DrawLine(vector, vector2, Color.green);
		int num = 8194;
		float num2 = 0f;
		RaycastHit raycastHit;
		if (Physics.SphereCast(vector, 0.2f, vector2 - vector, out raycastHit, this.currentDistance, num))
		{
			num2 = raycastHit.distance;
		}
		if (num2 != 0f)
		{
			this.curDist = Mathf.Lerp(this.cameraTransform.transform.localPosition.x, num2 - 0.1f, Time.deltaTime * 10f);
			this.checkDistance = 0.6f;
		}
		else
		{
			this.curDist = Mathf.Lerp(this.cameraTransform.transform.localPosition.x, this.currentDistance, Time.deltaTime);
		}
		return num2;
	}

	public void CatchMainCamera()
	{
		this.cameraTransform.parent = this.cameraControl.transform;
		this.isLockCamera = false;
		switch (this.cameraState)
		{
		case ModCamera.CameraState.LockCamera:
			this.LockCamera();
			break;
		case ModCamera.CameraState.FollowPositionAutoRotation:
			this.CameraFollowPositionAutoRotation();
			break;
		case ModCamera.CameraState.LockPositionAutoLook:
			this.CameraLockPositionAutoLook();
			break;
		case ModCamera.CameraState.MouseOrbit:
			this.UpdateMouseOrbit();
			break;
		case ModCamera.CameraState.LookTarget:
			this.LookTarget();
			break;
		case ModCamera.CameraState.Stop:
			this.StopCamera();
			break;
		case ModCamera.CameraState.FollowPositionLockAxis:
			this.UpdateFollowPositionLockAxis();
			break;
		}
	}

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
