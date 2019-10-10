using System;
using UnityEngine;


public class ModCamera : Module
{

    // Token: 0x04001EDE RID: 7902
    public string ClassName = "ModCamera";

    // Token: 0x04001EDF RID: 7903
    private GameObject cameraControlGO;

    // Token: 0x04001EE0 RID: 7904
    public GameObject cameraFather;

    // Token: 0x04001EE1 RID: 7905
    private Transform cameraTrans;

    // Token: 0x04001EE2 RID: 7906
    private Transform _target;

    // Token: 0x04001EE3 RID: 7907
    public float minDistance = 4f;

    // Token: 0x04001EE4 RID: 7908
    public float currentDistance = 8f;

    // Token: 0x04001EE5 RID: 7909
    public float nomalDistance = 8f;

    // Token: 0x04001EE6 RID: 7910
    public float maxDistance = 12f;

    // Token: 0x04001EE7 RID: 7911
    private float checkDistance = 4f;

    // Token: 0x04001EE8 RID: 7912
    public float height = 2f;

    // Token: 0x04001EE9 RID: 7913
    public float centerHeight = 3f;

    // Token: 0x04001EEA RID: 7914
    private float targetDistance;

    // Token: 0x04001EEB RID: 7915
    private float near = 0.5f;

    // Token: 0x04001EEC RID: 7916
    public float far = 80f;

    // Token: 0x04001EED RID: 7917
    public float fieldOfView = 60f;

    // Token: 0x04001EEE RID: 7918
    public float moveTime = 0.5f;

    // Token: 0x04001EEF RID: 7919
    private Vector3 velocity = Vector3.zero;

    // Token: 0x04001EF0 RID: 7920
    public float smoothTime = 0.06f;

    // Token: 0x04001EF1 RID: 7921
    public Vector3 cameraLockPosition = Vector3.zero;

    // Token: 0x04001EF2 RID: 7922
    public Vector3 vLockAxis = Vector3.zero;

    // Token: 0x04001EF3 RID: 7923
    public Vector2 vXLockFollowLimit = Vector2.zero;

    // Token: 0x04001EF4 RID: 7924
    public Vector2 vYLockFollowLimit = Vector2.zero;

    // Token: 0x04001EF5 RID: 7925
    public Vector2 vZLockFollowLimit = Vector2.zero;

    // Token: 0x04001EF6 RID: 7926
    public Vector3 FollowPositionLockAxisOffset = Vector3.zero;

    // Token: 0x04001EF7 RID: 7927
    public Vector3 FollowPositionLockAxisRotation = Vector3.zero;

    // Token: 0x04001EF8 RID: 7928
    private float xSpeed = 80f;

    // Token: 0x04001EF9 RID: 7929
    private float ySpeed = 40f;

    // Token: 0x04001EFA RID: 7930
    private float offsetY;

    // Token: 0x04001EFB RID: 7931
    private float offsetStep;

    // Token: 0x04001EFC RID: 7932
    private float offsetSpeed = 0.02f;

    // Token: 0x04001EFD RID: 7933
    private float yMinLimit = -8f;

    // Token: 0x04001EFE RID: 7934
    private float yMaxLimit = 60f;

    // Token: 0x04001EFF RID: 7935
    public float x;

    // Token: 0x04001F00 RID: 7936
    public float y;

    // Token: 0x04001F01 RID: 7937
    public float deltaTime = 6f;

    // Token: 0x04001F02 RID: 7938
    public bool isMouseOrbit = true;

    // Token: 0x04001F03 RID: 7939
    public bool isSmooth;

    // Token: 0x04001F04 RID: 7940
    private float curDist;

    // Token: 0x04001F05 RID: 7941
    private Vector3 moveDist = new Vector3(0f, 1f, 0f);

    // Token: 0x04001F06 RID: 7942
    public LayerMask layerMask = 8194;

    // Token: 0x04001F07 RID: 7943
    private RaycastHit rayHit;

    // Token: 0x04001F08 RID: 7944
    public bool isLockCamera;

    // Token: 0x04001F09 RID: 7945
    public bool isScaleCamera = true;

    // Token: 0x04001F0A RID: 7946
    private Transform cacheTransform;

    // Token: 0x04001F0B RID: 7947
    public Camera mainCamera = Camera.main;

    // Token: 0x04001F0C RID: 7948
    public ModCamera.CameraState cameraState;

    // Token: 0x04001F0D RID: 7949
    public GameObject CameraGo;

    // Token: 0x04001F0E RID: 7950
    public Transform transform;

    // Token: 0x0200051F RID: 1311
    public enum CameraState
    {
        // Token: 0x04001F10 RID: 7952
        Null,
        // Token: 0x04001F11 RID: 7953
        Shake,
        // Token: 0x04001F12 RID: 7954
        LockCamera,
        // Token: 0x04001F13 RID: 7955
        FollowPositionAutoRotation,
        // Token: 0x04001F14 RID: 7956
        LockPositionAutoLook,
        // Token: 0x04001F15 RID: 7957
        MouseOrbit,
        // Token: 0x04001F16 RID: 7958
        LookTarget,
        // Token: 0x04001F17 RID: 7959
        Stop,
        // Token: 0x04001F18 RID: 7960
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
		if (Application.isEditor)
		{
			this.isMouseOrbit = false;
		}
		if (this._role == null)
		{
			return;
		}
		if (this._role._roleType != ROLE_TYPE.RT_PLAYER)
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
		SceneInfo scenenInfo = FanrenSceneManager.currScenenInfo;
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

	// Token: 0x060021CC RID: 8652 RVA: 0x000E6E60 File Offset: 0x000E5060
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

	// Token: 0x060021CE RID: 8654 RVA: 0x000E6FD4 File Offset: 0x000E51D4
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

	// Token: 0x060021CF RID: 8655 RVA: 0x000E7094 File Offset: 0x000E5294
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

	// Token: 0x060021D0 RID: 8656 RVA: 0x000E7120 File Offset: 0x000E5320
	private void StopCamera()
	{
		this.cameraControl.transform.rotation = this.cameraControl.transform.rotation;
		this.cameraControl.transform.position = this.cameraControl.transform.position;
	}

	// Token: 0x060021D1 RID: 8657 RVA: 0x000E7170 File Offset: 0x000E5370
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

	// Token: 0x060021D2 RID: 8658 RVA: 0x000E724C File Offset: 0x000E544C
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

	// Token: 0x060021D3 RID: 8659 RVA: 0x000E7344 File Offset: 0x000E5544
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

	// Token: 0x060021D4 RID: 8660 RVA: 0x000E760C File Offset: 0x000E580C
	public void AutoRotationLook()
	{
		Quaternion to = Quaternion.Euler(0f, this.x, this.y);
		if (Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.y) != Mathf.Round(to.eulerAngles.y) || Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.z) != Mathf.Round(to.eulerAngles.z))
		{
			this.cameraControl.transform.rotation = Quaternion.Lerp(this.cameraControl.transform.rotation, to, Time.deltaTime * this.moveTime);
		}
	}

	// Token: 0x060021D5 RID: 8661 RVA: 0x00017607 File Offset: 0x00015807
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

	// Token: 0x060021D6 RID: 8662 RVA: 0x000E76E4 File Offset: 0x000E58E4
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

	// Token: 0x060021D7 RID: 8663 RVA: 0x000E77CC File Offset: 0x000E59CC
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

	// Token: 0x060021D8 RID: 8664 RVA: 0x00017639 File Offset: 0x00015839
	public void ShakeCameraRotation(Vector3 amount, float time)
	{
		//iTween.ShakeRotation(this.cameraTransform.gameObject, amount, time);
	}

	// Token: 0x060021D9 RID: 8665 RVA: 0x0001764D File Offset: 0x0001584D
	public void ShakeCameraPosition(Vector3 amount, float time)
	{
		//SingletonMono<ScreenShockController>.GetInstance().Shock(amount, time);
	}

	// Token: 0x060021DA RID: 8666 RVA: 0x000E7850 File Offset: 0x000E5A50
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

	// Token: 0x060021DB RID: 8667 RVA: 0x000E78A0 File Offset: 0x000E5AA0
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

	// Token: 0x060021DC RID: 8668 RVA: 0x0001765B File Offset: 0x0001585B
	public void SetCamearTarget(Transform transform)
	{
		this._target = transform;
	}

	// Token: 0x060021DD RID: 8669 RVA: 0x00017664 File Offset: 0x00015864
	public void SetOrignTarget(Transform trans)
	{
		this._target = trans;
		this.transform = trans;
		this.CameraGo = trans.gameObject;
	}

	// Token: 0x060021DE RID: 8670 RVA: 0x000E7918 File Offset: 0x000E5B18
	public void StartMouseOrbit()
	{
		this.cameraState = ModCamera.CameraState.MouseOrbit;
		this.ReSetCamera(false);
		this.x = this.cameraControl.transform.eulerAngles.y;
		this.y = this.cameraControl.transform.eulerAngles.z;
		//if (this.transform.rigidbody)
		//{
		//	this.transform.rigidbody.freezeRotation = true;
		//}
	}

	// Token: 0x060021DF RID: 8671 RVA: 0x000E7998 File Offset: 0x000E5B98
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

	// Token: 0x060021E0 RID: 8672 RVA: 0x00017680 File Offset: 0x00015880
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

	// Token: 0x060021E1 RID: 8673 RVA: 0x000E7BA0 File Offset: 0x000E5DA0
	private float CheckCameraHit()
	{
		Vector3 vector = this.cameraControl.transform.position + new Vector3(0f, 1f, 0f);
		Vector3 vector2 = vector - this.cameraTransform.forward * this.currentDistance;
		//Logger.DrawLine(vector, vector2, Color.green);
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

	// Token: 0x060021E2 RID: 8674 RVA: 0x000E7CB8 File Offset: 0x000E5EB8
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

	// Token: 0x060021E3 RID: 8675 RVA: 0x000176BC File Offset: 0x000158BC
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
