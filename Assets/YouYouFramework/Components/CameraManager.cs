using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YouYou;

public enum CameraState
{
    Null,
    Shake,
    LockCamera,
    FollowPositionAutoRotation,
    LockPositionAutoLook,
    /// <summary>
    /// 鼠标操作
    /// </summary>
    MouseOrbit,
    /// <summary>
    /// 战斗
    /// </summary>
    Battle,
    LookTarget,
    Stop,
    FollowPositionLockAxis
}

public class CameraManager : YouYouBaseComponent, IUpdateComponent
{
    /// <summary>
    /// 主摄像机
    /// </summary>
    public Camera MainCamera;

    /// <summary>
    /// 控制摄像机上下 X控制远近
    /// </summary>
    [SerializeField]
    private Transform m_CameraUpAndDown; 

    /// <summary>
    /// 摄像机缩放父物体 Z
    /// </summary>
    [SerializeField]
    private Transform m_CameraZoomContainer;

    /// <summary>
    /// 摄像机容器 Z缩放
    /// </summary>
    [SerializeField]
    private Transform m_CameraContainer;

    private Transform m_target;

    private GameObject Player;

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

    private float offsetSpeed = 0.05f;

    private float yMinLimit = 10f;

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

    public CameraState cameraState;

    protected override void OnAwake()
    {
        base.OnAwake();
        GameEntry.RegisterUpdateComponent(this);
        InitCamera();
    }

    /// <summary>
    /// 初始化摄像机
    /// </summary>
	private void InitCamera()
    {    
        this.isLockCamera = true;
        this.cameraState = CameraState.MouseOrbit;
        Camera.main.backgroundColor = RenderSettings.fogColor;
        this.isLockCamera = false;
    }

    /// <summary>
    /// 初始化位置
    /// </summary>
	public void InitPosition(GameObject gameObject)
    {
        this.isLockCamera = true;
        m_target= gameObject.transform;
        transform.position = m_target.position;
        AutoLookAt(m_target.position);
        this.x = gameObject.transform.rotation.eulerAngles.y + 90f;
        this.y = 30f;
        this.transform.rotation = Quaternion.Euler(0f, this.x, 0f);
        this.m_CameraUpAndDown.transform.localRotation = Quaternion.Euler(0f, 0f, this.y);
        this.m_CameraZoomContainer.transform.localPosition = Vector3.right * this.nomalDistance + this.moveDist;
        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localRotation = Quaternion.identity;
        this.isLockCamera = false;
    }

    /// <summary>
    /// 初始化位置
    /// </summary>
	public void InitBattle()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        m_CameraUpAndDown.localPosition = Vector3.zero;
        m_CameraUpAndDown.localRotation = Quaternion.identity;
        m_CameraZoomContainer.localPosition = Vector3.zero;
        m_CameraZoomContainer.localRotation = Quaternion.identity;
        m_CameraContainer.localPosition = Vector3.zero;
        m_CameraContainer.localRotation = Quaternion.identity;
        Camera.main.transform.localPosition = new Vector3(0f, 4f, -5f);
        Camera.main.transform.localRotation = Quaternion.Euler(30f, 0f, 0f);
    }

    /// <summary>
    /// 实时看着主角
    /// </summary>
    /// <param name="pos"></param>
    public void AutoLookAt(Vector3 pos)
    {
        m_CameraZoomContainer.LookAt(pos);
    }

    //public void SetCameraState(ModCamera.CameraState state)
    //{
    //    if (this.cameraState == ModCamera.CameraState.LookTarget && (state == ModCamera.CameraState.FollowPositionAutoRotation || state == ModCamera.CameraState.LockPositionAutoLook || state == ModCamera.CameraState.LockCamera))
    //    {
    //        return;
    //        return;
    //    }
    //    this.cameraState = state;
    //    switch (this.cameraState)
    //    {
    //        case ModCamera.CameraState.MouseOrbit:
    //            this.StartMouseOrbit();
    //            break;
    //    }
    //}

    //private void StopCamera()
    //{
    //    this.cameraControl.transform.rotation = this.cameraControl.transform.rotation;
    //    this.cameraControl.transform.position = this.cameraControl.transform.position;
    //}

    //private void LockCamera()
    //{
    //    Quaternion rotation = Quaternion.Euler(0f, this.x, this.y);
    //    this.cameraControl.transform.rotation = rotation;
    //    this.cameraControl.transform.position = this.cameraLockPosition;
    //    //this.cameraTransform.parent = this.cameraControl.transform;
    //    //this.cameraTransform.transform.localPosition = Vector3.right * this.curDist + this.moveDist;
    //    //this.cameraTransform.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
    //    //this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
    //}

    public void CameraFollowPositionAutoRotation()
    {
        if (this.m_target == null)
        {
            return;
        }
        //this.cameraTransform.parent = this.cameraControl.transform;
        //this.cameraTransform.transform.localPosition = Vector3.right * this.curDist + this.moveDist;
        //this.cameraTransform.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
        //this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
        this.AutoRotationLook();
        //Vector3 position = this._role.GetTrans().position;
        //this.cameraControl.transform.position = Vector3.SmoothDamp(this.cameraControl.transform.position, position, ref this.velocity, this.smoothTime);
    }

    public void UpdateFollowPositionLockAxis()
    {
        //this.cameraTransform.parent = this.cameraControl.transform;
        //this.cameraTransform.transform.localPosition = Vector3.right * this.curDist + this.moveDist;
        //this.cameraTransform.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));
        //this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
        //Quaternion to = Quaternion.Euler(0f, this.x + this.FollowPositionLockAxisRotation.y, this.y + this.FollowPositionLockAxisRotation.z);
        //if (Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.y) != Mathf.Round(to.eulerAngles.y) || Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.z) != Mathf.Round(to.eulerAngles.z))
        //{
        //    this.cameraControl.transform.rotation = Quaternion.Lerp(this.cameraControl.transform.rotation, to, Time.deltaTime * this.moveTime);
        //}
        //float num = (this.vLockAxis.x != 0f) ? this.cameraControl.transform.position.x : this._role.GetTrans().position.x;
        //float num2 = (this.vLockAxis.y != 0f) ? this.cameraControl.transform.position.y : this._role.GetTrans().position.y;
        //float num3 = (this.vLockAxis.z != 0f) ? this.cameraControl.transform.position.z : this._role.GetTrans().position.z;
        //Vector3 target = new Vector3(num + this.FollowPositionLockAxisOffset.x, num2 + this.FollowPositionLockAxisOffset.y, num3 + this.FollowPositionLockAxisOffset.z);
        //this.cameraControl.transform.position = Vector3.SmoothDamp(this.cameraControl.transform.position, target, ref this.velocity, this.smoothTime);
    }

    public void AutoRotationLook()
    {
        Quaternion to = Quaternion.Euler(0f, this.x, this.y);
        //if (Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.y) != Mathf.Round(to.eulerAngles.y) || Mathf.Round(this.cameraControl.transform.rotation.eulerAngles.z) != Mathf.Round(to.eulerAngles.z))
        //{
        //    this.cameraControl.transform.rotation = Quaternion.Lerp(this.cameraControl.transform.rotation, to, Time.deltaTime * this.moveTime);
        //}
    }

    public void CameraLookTarget(Transform targetTransform, float targetHeight, float targetDist)
    {
        if (targetTransform == null)
        {
            return;
        }
        this.m_target = targetTransform;
        this.isScaleCamera = false;
        this.height = targetHeight;
        this.targetDistance = targetDist;
        //this.SetCameraState(ModCamera.CameraState.LookTarget);
    }

    private void LookTarget()
    {
        if (this.m_target == null)
        {
            return;
        }
        Vector3 vector = this.m_target.transform.position + new Vector3(0f, this.height, 0f);
        //this.cameraTransform.parent = this.cameraControl.transform;
        //this.cameraTransform.transform.localPosition = Vector3.right * this.targetDistance;
        //this.cameraTransform.transform.LookAt(vector);
        //this.cameraTransform.transform.localScale = new Vector3(1f, 1f, 1f);
        //this.cameraControl.transform.position = Vector3.SmoothDamp(this.cameraControl.transform.position, vector, ref this.velocity, this.smoothTime);
    }

    private void CameraLockPositionAutoLook()
    {
        if (this.m_target == null)
        {
            return;
        }
        Quaternion quaternion = Quaternion.Euler(0f, this.x, this.y);
        //this.cameraControl.transform.position = this.cameraLockPosition;
        ////Vector3 position = this._role.GetTrans().position;
        ////this.cameraTransform.transform.LookAt(position);
        //this.cameraFather.transform.localPosition = Vector3.zero;
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
        this.SetCamearTarget(Player.transform);
        this.isScaleCamera = true;
        this.isLockCamera = false;
        if (resetDist)
        {
            this.currentDistance = this.nomalDistance;
        }
        this.height = 2f;
        this.centerHeight = 3f;
    }

    public void SetCamearTarget(Transform transform)
    {
        this.m_target = transform;
    }

    public void SetOrignTarget(Transform trans)
    {
        this.m_target = trans;
        //this.transform = trans;
        //this.CameraGo = trans.gameObject;
    }

    public void UpdateMouseOrbit()
    {

        //if (KeyManager.hotKeyEnabled && this._target && Time.timeScale != 0f)
        //{
        transform.position = m_target.position;
        AutoLookAt(m_target.position);

        if (this.isMouseOrbit && Input.GetMouseButton(1))
        {
            this.x += Input.GetAxis("Mouse X") * this.xSpeed * this.offsetSpeed;
            this.y -= Input.GetAxis("Mouse Y") * this.ySpeed * this.offsetSpeed;
           
            this.y = ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
        }
        this.transform.rotation = Quaternion.Euler(0f, this.x, 0f);
        this.m_CameraUpAndDown.transform.localRotation = Quaternion.Euler(0f, 0f, this.y);
        //Vector3 position = Vector3.SmoothDamp(this.cameraControl.transform.position, this._target.position, ref this.velocity, this.smoothTime);
        //this.cameraControl.transform.position = position;
        //if (this.y < 0f)
        //{
        //    this.curDist = Mathf.Lerp(m_MainCamera.transform.localPosition.x, this.minDistance + this.y, Time.deltaTime * this.deltaTime);
        //    this.checkDistance = 2f;
        //}
        this.currentDistance -= Input.GetAxis("Mouse ScrollWheel");
        this.CheckDistance();
        this.m_CameraZoomContainer.transform.localPosition = Vector3.right * this.currentDistance + this.moveDist;
        //}
    }

    public void UpdateBattle()
    {

       
    }

    /// <summary>
    /// 检查距离
    /// </summary>
    private void CheckDistance()
    {
        if (this.currentDistance < this.checkDistance)
        {
            this.currentDistance = this.checkDistance;
        }
        if (this.currentDistance > this.maxDistance)
        {
            this.currentDistance = this.maxDistance;
        }
    }

    ///// <summary>
    ///// 检查距离
    ///// </summary>
    //private void CheckDistance()
    //{
    //    if (this.curDist < this.checkDistance)
    //    {
    //        this.curDist = this.checkDistance;
    //    }
    //    if (this.curDist > this.maxDistance)
    //    {
    //        this.curDist = this.maxDistance;
    //    }
    //}

 //   /// <summary>
 //   /// 检查摄像机碰撞
 //   /// </summary>
 //   /// <returns></returns>
	//private float CheckCameraHit()
 //   {
 //       Vector3 vector = this.cameraControl.transform.position + new Vector3(0f, 1f, 0f);
 //       Vector3 vector2 = vector - this.cameraTransform.forward * this.currentDistance;
 //       Debug.DrawLine(vector, vector2, Color.green);
 //       int num = 8194;
 //       float num2 = 0f;
 //       RaycastHit raycastHit;
 //       if (Physics.SphereCast(vector, 0.2f, vector2 - vector, out raycastHit, this.currentDistance, num))
 //       {
 //           num2 = raycastHit.distance;
 //       }
 //       if (num2 != 0f)
 //       {
 //           this.curDist = Mathf.Lerp(this.cameraTransform.transform.localPosition.x, num2 - 0.1f, Time.deltaTime * 10f);
 //           this.checkDistance = 0.6f;
 //       }
 //       else
 //       {
 //           this.curDist = Mathf.Lerp(this.cameraTransform.transform.localPosition.x, this.currentDistance, Time.deltaTime);
 //       }
 //       return num2;
 //   }

    public void CatchMainCamera()
    {
        //this.cameraTransform.parent = this.cameraControl.transform;
        //this.isLockCamera = false;
        //switch (this.cameraState)
        //{
        //    case ModCamera.CameraState.LockCamera:
        //        this.LockCamera();
        //        break;
        //    case ModCamera.CameraState.FollowPositionAutoRotation:
        //        this.CameraFollowPositionAutoRotation();
        //        break;
        //    case ModCamera.CameraState.LockPositionAutoLook:
        //        this.CameraLockPositionAutoLook();
        //        break;
        //    case ModCamera.CameraState.MouseOrbit:
        //        this.UpdateMouseOrbit();
        //        break;
        //    case ModCamera.CameraState.LookTarget:
        //        this.LookTarget();
        //        break;
        //    case ModCamera.CameraState.Stop:
        //        this.StopCamera();
        //        break;
        //    case ModCamera.CameraState.FollowPositionLockAxis:
        //        this.UpdateFollowPositionLockAxis();
        //        break;
        //}
    }

    /// <summary>
    /// 限制夹角
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
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

    public override void Shutdown()
    {
       
    }

    public void OnUpdate()
    {
        if (m_target == null)
        {
            return;
        }

        if (this.isLockCamera)
        {
            return;
        }

        switch (this.cameraState)
        {
            case CameraState.MouseOrbit:
                this.UpdateMouseOrbit();
                break;
            case CameraState.Battle:
                this.UpdateBattle();
                break;
        }
        //this.CheckCameraHit();
    }

    

    /// <summary>
    /// 设置摄像机 缩放
    /// </summary>
    /// <param name="type">0=拉近 1=拉远</param>
    public void SetCameraZoom(int type)
    {      
        m_CameraContainer.Translate(Vector3.forward * 10 * Time.deltaTime * ((type == 1 ? -1 : 1)));
        m_CameraContainer.localPosition = new Vector3(0, 0, Mathf.Clamp(m_CameraContainer.localPosition.z, -5f, 5f));
    }
}
