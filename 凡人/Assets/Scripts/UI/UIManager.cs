using System;
using System.Text;
using UnityEngine;

[AddComponentMenu("EZ GUI/Management/UI Manager")]
public class UIManager : MonoBehaviour
{
    private static UIManager s_Instance;

    public UIManager.POINTER_TYPE pointerType = UIManager.POINTER_TYPE.AUTO_TOUCHPAD;

    //public float dragThreshold = 8f;

    //public float rayDragThreshold = 2f;

    public float rayDepth = float.PositiveInfinity;

    public LayerMask rayMask = -1;

    //public bool focusWithRay;

    //public string actionAxis = "Fire1";

    //public UIManager.OUTSIDE_VIEWPORT inputOutsideViewport = UIManager.OUTSIDE_VIEWPORT.Move_Off;

    //public bool warnOnNonUiHits = true;

    //protected Transform raycastingTransform;

    public EZCameraSettings[] uiCameras = new EZCameraSettings[1];

    public Camera rayCamera;

    //public bool blockInput;

    //public float defaultDragOffset = 1f;

    //public EZAnimation.EASING_TYPE cancelDragEasing = EZAnimation.EASING_TYPE.ExponentialOut;

    //public float cancelDragDuration = 1f;

    //public TextAsset defaultFont;

    //public Material defaultFontMaterial;

    //protected bool rayActive;

    //protected UIManager.RAY_ACTIVE_STATE rayState;

    //protected POINTER_INFO[,] pointers;

    //protected UIManager.NonUIHitInfo[] nonUIHits;

    protected bool[] usedPointers;

    //// Token: 0x040001A4 RID: 420
    //protected bool[] usedNonUIHits;

    //// Token: 0x040001A5 RID: 421
    //protected bool rayIsNonUIHit;

    protected int numPointers;

    protected int numTouchPointers;

    protected int[] activePointers;

    protected int numActivePointers;

    protected int numNonUIHits;

    //// Token: 0x040001AB RID: 427
    //protected POINTER_INFO rayPtr;

    //// Token: 0x040001AC RID: 428
    //protected UIManager.PointerPollerDelegate pointerPoller;

    //// Token: 0x040001AD RID: 429
    //protected UIManager.PointerInfoDelegate informNonUIHit;

    //// Token: 0x040001AE RID: 430
    //protected UIManager.PointerInfoDelegate mouseTouchListeners;

    //// Token: 0x040001AF RID: 431
    //protected UIManager.PointerInfoDelegate rayListeners;

    //// Token: 0x040001B0 RID: 432
    //protected IUIObject focusObj;

    //// Token: 0x040001B1 RID: 433
    //protected string controlText;

    //// Token: 0x040001B2 RID: 434
    //protected int insert;

    //// Token: 0x040001B3 RID: 435
    //private KEYBOARD_INFO kbInfo = default(KEYBOARD_INFO);

    protected int inputLockCount;

    protected bool m_started;

    private int lastUpdateFrame;

    private int curActionID;

    private int numTouches;

    //protected RaycastHit hit;

    //protected Vector3 tempVec;

    //private bool down;

    //private bool rightDown;

    //private bool lastUpIsRightMouse;

    //private IUIObject tempObj;

    //private POINTER_INFO tempPtr;

    //private StringBuilder sb = new StringBuilder();

    public enum POINTER_TYPE
    {
        MOUSE,//鼠标
        TOUCHPAD,
        AUTO_TOUCHPAD,
        RAY,
        MOUSE_AND_RAY,
        TOUCHPAD_AND_RAY
    }

    //// Token: 0x02000036 RID: 54
    //public enum RAY_ACTIVE_STATE
    //{
    //	// Token: 0x040001C9 RID: 457
    //	Inactive,
    //	// Token: 0x040001CA RID: 458
    //	Momentary,
    //	// Token: 0x040001CB RID: 459
    //	Constant
    //}

    //// Token: 0x02000037 RID: 55
    //public enum OUTSIDE_VIEWPORT
    //{
    //	// Token: 0x040001CD RID: 461
    //	Process_All,
    //	// Token: 0x040001CE RID: 462
    //	Ignore,
    //	// Token: 0x040001CF RID: 463
    //	Move_Off
    //}

    //// Token: 0x02000038 RID: 56
    //public struct NonUIHitInfo
    //{
    //	// Token: 0x060002DE RID: 734 RVA: 0x000154D0 File Offset: 0x000136D0
    //	public NonUIHitInfo(int pIndex, int cIndex)
    //	{
    //		this.ptrIndex = pIndex;
    //		this.camIndex = cIndex;
    //	}

    //	// Token: 0x040001D0 RID: 464
    //	public int ptrIndex;

    //	// Token: 0x040001D1 RID: 465
    //	public int camIndex;
    //}

    //public delegate void PointerPollerDelegate();

    //public delegate void PointerInfoDelegate(POINTER_INFO ptr);

    public static UIManager instance
    {
        get
        {
            if (UIManager.s_Instance == null)
            {
                UIManager.s_Instance = (UnityEngine.Object.FindObjectOfType(typeof(UIManager)) as UIManager);
                if (UIManager.s_Instance == null && Application.isEditor)
                {
                    Debug.LogError("Could not locate a UIManager object. You have to have exactly one UIManager in the scene.");
                }
            }
            return UIManager.s_Instance;
        }
    }

    //public static bool Exists()
    //{
    //	if (UIManager.s_Instance == null)
    //	{
    //		UIManager.s_Instance = (UnityEngine.Object.FindObjectOfType(typeof(UIManager)) as UIManager);
    //	}
    //	return UIManager.s_Instance != null;
    //}

    //public void OnDestroy()
    //{
    //	UIManager.s_Instance = null;
    //}

    //private void Start()
    //{
    //	if (Application.loadedLevel == 0)
    //	{
    //		this.Init();
    //	}
    //}

    public void Init()
    {
        if (!(UIManager.s_Instance != null))
        {
            UIManager.s_Instance = this;
        }

        if (this.pointerType == UIManager.POINTER_TYPE.TOUCHPAD || this.pointerType == UIManager.POINTER_TYPE.TOUCHPAD_AND_RAY)
        {
            this.numTouches = 11;
        }
        else if (this.pointerType == UIManager.POINTER_TYPE.AUTO_TOUCHPAD)
        {
            this.numTouches = 12;
        }
        else if (this.pointerType == UIManager.POINTER_TYPE.MOUSE_AND_RAY)
        {
            this.numTouches = 1;
        }
        else
        {
            this.numTouches = 1;
        }

        if (this.pointerType == UIManager.POINTER_TYPE.AUTO_TOUCHPAD || this.pointerType == UIManager.POINTER_TYPE.MOUSE || this.pointerType == UIManager.POINTER_TYPE.MOUSE_AND_RAY)
        {
            this.numTouchPointers = this.numTouches - 1;
        }
        else
        {
            this.numTouchPointers = this.numTouches;
        }

        if (this.uiCameras.Length < 1)
        {
            this.uiCameras = new EZCameraSettings[1];
            this.uiCameras[0].camera = Camera.main;
        }
        else
        {
            for (int i = 0; i < this.uiCameras.Length; i++)
            {
                if (this.uiCameras[i].camera == null)
                {
                    this.uiCameras[i].camera = Camera.main;
                }
            }
        }

        if (this.rayCamera == null)
        {
            this.rayCamera = this.uiCameras[0].camera;
        }
        this.StartSetting();
    }

    /// <summary>
    /// 开始设置
    /// </summary>
    protected void StartSetting()
    {
        if (this.m_started)
        {
            return;
        }
        this.m_started = true;
        this.numPointers = this.numTouches;
        this.activePointers = new int[this.numTouches];
        this.usedPointers = new bool[this.numPointers];
        //this.nonUIHits = new UIManager.NonUIHitInfo[this.numTouches];
        //this.usedNonUIHits = new bool[this.numPointers];
        this.numNonUIHits = 0;
        this.SetupPointers();
    }

    protected void SetupPointers()
    {
        this.StartSetting();
        //this.pointers = new POINTER_INFO[this.uiCameras.Length, this.numTouches];
        //if (this.raycastingTransform == null)
        //{
        //    this.raycastingTransform = Camera.main.transform;
        //}
        //this.raycastingTransform = this.rayCamera.gameObject.transform;
        //switch (this.pointerType)
        //{
        //    case UIManager.POINTER_TYPE.MOUSE:
        //        this.pointerPoller = new UIManager.PointerPollerDelegate(this.PollMouse);
        //        this.activePointers[0] = 0;
        //        this.numActivePointers = 1;
        //        for (int i = 0; i < this.uiCameras.Length; i++)
        //        {
        //            this.pointers[i, 0].id = 0;
        //            this.pointers[i, 0].rayDepth = this.uiCameras[i].rayDepth;
        //            this.pointers[i, 0].layerMask = this.uiCameras[i].mask;
        //            this.pointers[i, 0].camera = this.uiCameras[i].camera;
        //            this.pointers[i, 0].type = POINTER_INFO.POINTER_TYPE.MOUSE;
        //        }
        //        break;
        //    case UIManager.POINTER_TYPE.TOUCHPAD:
        //        this.pointerPoller = new UIManager.PointerPollerDelegate(this.PollTouchpad);
        //        for (int j = 0; j < this.uiCameras.Length; j++)
        //        {
        //            for (int k = 0; k < this.numPointers; k++)
        //            {
        //                this.pointers[j, k].id = k;
        //                this.pointers[j, k].rayDepth = this.uiCameras[j].rayDepth;
        //                this.pointers[j, k].layerMask = this.uiCameras[j].mask;
        //                this.pointers[j, k].camera = this.uiCameras[j].camera;
        //                this.pointers[j, k].type = POINTER_INFO.POINTER_TYPE.TOUCHPAD;
        //            }
        //        }
        //        break;
        //    case UIManager.POINTER_TYPE.AUTO_TOUCHPAD:
        //        this.pointerPoller = new UIManager.PointerPollerDelegate(this.PollMouseAndTouchpad);
        //        for (int l = 0; l < this.uiCameras.Length; l++)
        //        {
        //            for (int m = 0; m < this.numPointers; m++)
        //            {
        //                this.pointers[l, m].id = m;
        //                this.pointers[l, m].rayDepth = this.uiCameras[l].rayDepth;
        //                this.pointers[l, m].layerMask = this.uiCameras[l].mask;
        //                this.pointers[l, m].camera = this.uiCameras[l].camera;
        //                this.pointers[l, m].type = POINTER_INFO.POINTER_TYPE.TOUCHPAD;
        //            }
        //            this.pointers[l, this.numPointers - 1].type = POINTER_INFO.POINTER_TYPE.MOUSE;
        //        }
        //        break;
        //    case UIManager.POINTER_TYPE.RAY:
        //        this.pointerPoller = new UIManager.PointerPollerDelegate(this.PollRay);
        //        this.numActivePointers = 0;
        //        this.rayPtr.type = POINTER_INFO.POINTER_TYPE.RAY;
        //        this.rayPtr.id = -1;
        //        this.rayPtr.rayDepth = this.rayDepth;
        //        this.rayPtr.layerMask = this.rayMask;
        //        this.rayPtr.camera = this.rayCamera;
        //        break;
        //    case UIManager.POINTER_TYPE.MOUSE_AND_RAY:
        //        this.pointerPoller = new UIManager.PointerPollerDelegate(this.PollMouseRay);
        //        this.activePointers[0] = 0;
        //        this.numActivePointers = 1;
        //        for (int n = 0; n < this.uiCameras.Length; n++)
        //        {
        //            this.pointers[n, 0].id = 0;
        //            this.pointers[n, 0].rayDepth = this.uiCameras[n].rayDepth;
        //            this.pointers[n, 0].layerMask = this.uiCameras[n].mask;
        //            this.pointers[n, 0].camera = this.uiCameras[n].camera;
        //            this.pointers[n, 0].type = POINTER_INFO.POINTER_TYPE.MOUSE;
        //        }
        //        this.rayPtr.id = -1;
        //        this.rayPtr.type = POINTER_INFO.POINTER_TYPE.RAY;
        //        this.rayPtr.rayDepth = this.rayDepth;
        //        this.rayPtr.layerMask = this.rayMask;
        //        this.rayPtr.camera = this.rayCamera;
        //        break;
        //    case UIManager.POINTER_TYPE.TOUCHPAD_AND_RAY:
        //        this.pointerPoller = new UIManager.PointerPollerDelegate(this.PollTouchpadRay);
        //        for (int num = 0; num < this.uiCameras.Length; num++)
        //        {
        //            for (int num2 = 0; num2 < this.numPointers; num2++)
        //            {
        //                this.pointers[num, num2].id = num2;
        //                this.pointers[num, num2].rayDepth = this.uiCameras[num].rayDepth;
        //                this.pointers[num, num2].layerMask = this.uiCameras[num].mask;
        //                this.pointers[num, num2].camera = this.uiCameras[num].camera;
        //                this.pointers[num, num2].type = POINTER_INFO.POINTER_TYPE.TOUCHPAD;
        //            }
        //        }
        //        this.rayPtr.id = -1;
        //        this.rayPtr.type = POINTER_INFO.POINTER_TYPE.RAY;
        //        this.rayPtr.rayDepth = this.rayDepth;
        //        this.rayPtr.layerMask = this.rayMask;
        //        this.rayPtr.camera = this.rayCamera;
        //        break;
        //    default:
        //        Debug.LogError("ERROR: Invalid pointer type selected!");
        //        break;
        //}
    }

    //public void SetNonUIHitDelegate(UIManager.PointerInfoDelegate del)
    //{
    //	this.informNonUIHit = del;
    //}

    //public void AddNonUIHitDelegate(UIManager.PointerInfoDelegate del)
    //{
    //	this.informNonUIHit = (UIManager.PointerInfoDelegate)Delegate.Combine(this.informNonUIHit, del);
    //}

    //public void RemoveNonUIHitDelegate(UIManager.PointerInfoDelegate del)
    //{
    //	this.informNonUIHit = (UIManager.PointerInfoDelegate)Delegate.Remove(this.informNonUIHit, del);
    //}

    //public void AddMouseTouchPtrListener(UIManager.PointerInfoDelegate del)
    //{
    //	this.mouseTouchListeners = (UIManager.PointerInfoDelegate)Delegate.Combine(this.mouseTouchListeners, del);
    //}

    //public void AddRayPtrListener(UIManager.PointerInfoDelegate del)
    //{
    //	this.rayListeners = (UIManager.PointerInfoDelegate)Delegate.Combine(this.rayListeners, del);
    //}

    //public void RemoveMouseTouchPtrListener(UIManager.PointerInfoDelegate del)
    //{
    //	this.mouseTouchListeners = (UIManager.PointerInfoDelegate)Delegate.Remove(this.mouseTouchListeners, del);
    //}

    //public void RemoveRayPtrListener(UIManager.PointerInfoDelegate del)
    //{
    //	this.rayListeners = (UIManager.PointerInfoDelegate)Delegate.Remove(this.rayListeners, del);
    //}

    //protected void AddNonUIHit(int ptrIndex, int camIndex)
    //{
    //	if (this.informNonUIHit == null)
    //	{
    //		return;
    //	}
    //	if (camIndex == -1)
    //	{
    //		this.rayIsNonUIHit = true;
    //		return;
    //	}
    //	if (this.usedPointers[ptrIndex])
    //	{
    //		return;
    //	}
    //	if (this.usedNonUIHits[ptrIndex])
    //	{
    //		return;
    //	}
    //	this.usedNonUIHits[ptrIndex] = true;
    //	this.nonUIHits[this.numNonUIHits] = new UIManager.NonUIHitInfo(ptrIndex, camIndex);
    //	this.numNonUIHits++;
    //}

    //// Token: 0x060002BC RID: 700 RVA: 0x000134F0 File Offset: 0x000116F0
    //protected void CallNonUIHitDelegate()
    //{
    //	if (this.informNonUIHit == null)
    //	{
    //		return;
    //	}
    //	for (int i = 0; i < this.numNonUIHits; i++)
    //	{
    //		UIManager.NonUIHitInfo nonUIHitInfo = this.nonUIHits[i];
    //		this.usedNonUIHits[nonUIHitInfo.ptrIndex] = false;
    //		if (!this.usedPointers[nonUIHitInfo.ptrIndex])
    //		{
    //			this.informNonUIHit(this.pointers[nonUIHitInfo.camIndex, nonUIHitInfo.ptrIndex]);
    //		}
    //	}
    //	if (this.rayIsNonUIHit)
    //	{
    //		this.informNonUIHit(this.rayPtr);
    //	}
    //}

    //// Token: 0x060002BD RID: 701 RVA: 0x0001359C File Offset: 0x0001179C
    //public bool DidPointerHitUI(int id)
    //{
    //	if (this.lastUpdateFrame != Time.frameCount)
    //	{
    //		this.Update();
    //	}
    //	if (id == -1)
    //	{
    //		return this.rayPtr.targetObj != null;
    //	}
    //	Mathf.Clamp(id, 0, this.usedPointers.Length - 1);
    //	return this.usedPointers[id];
    //}

    //// Token: 0x060002BE RID: 702 RVA: 0x000135F4 File Offset: 0x000117F4
    //public bool DidAnyPointerHitUI()
    //{
    //	if (this.lastUpdateFrame != Time.frameCount)
    //	{
    //		this.Update();
    //	}
    //	if (this.rayPtr.targetObj != null)
    //	{
    //		return true;
    //	}
    //	for (int i = 0; i < this.usedPointers.Length; i++)
    //	{
    //		if (this.usedPointers[i])
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x060002BF RID: 703 RVA: 0x00013654 File Offset: 0x00011854
    //public void AddCamera(Camera cam, LayerMask mask, float depth, int index)
    //{
    //	EZCameraSettings[] array = new EZCameraSettings[this.uiCameras.Length + 1];
    //	index = Mathf.Clamp(index, 0, this.uiCameras.Length + 1);
    //	int i = 0;
    //	int num = 0;
    //	while (i < array.Length)
    //	{
    //		if (i == index)
    //		{
    //			array[i] = new EZCameraSettings();
    //			array[i].camera = cam;
    //			array[i].mask = mask;
    //			array[i].rayDepth = depth;
    //			num++;
    //		}
    //		else
    //		{
    //			array[i] = this.uiCameras[num];
    //		}
    //		i++;
    //		num++;
    //	}
    //	this.uiCameras = array;
    //	this.SetupPointers();
    //}

    //// Token: 0x060002C0 RID: 704 RVA: 0x000136EC File Offset: 0x000118EC
    //public void RemoveCamera(int index)
    //{
    //	EZCameraSettings[] array = new EZCameraSettings[this.uiCameras.Length - 1];
    //	index = Mathf.Clamp(index, 0, this.uiCameras.Length);
    //	int num = 0;
    //	for (int i = 0; i < this.uiCameras.Length; i++)
    //	{
    //		if (i != index)
    //		{
    //			array[num] = this.uiCameras[i];
    //			num++;
    //		}
    //	}
    //	this.uiCameras = array;
    //	this.SetupPointers();
    //}

    //// Token: 0x060002C1 RID: 705 RVA: 0x00013758 File Offset: 0x00011958
    //public void ReplaceCamera(int index, Camera cam)
    //{
    //	index = Mathf.Clamp(index, 0, this.uiCameras.Length);
    //	this.uiCameras[index].camera = cam;
    //	this.SetupPointers();
    //}

    //// Token: 0x060002C2 RID: 706 RVA: 0x00013780 File Offset: 0x00011980
    //public void OnLevelWasLoaded(int level)
    //{
    //	for (int i = 0; i < this.uiCameras.Length; i++)
    //	{
    //		if (this.uiCameras[i].camera == null)
    //		{
    //			this.uiCameras[i].camera = Camera.main;
    //		}
    //	}
    //	if (this.rayCamera == null)
    //	{
    //		this.rayCamera = Camera.main;
    //	}
    //	if (this.focusObj == null)
    //	{
    //		this.FocusObject = null;
    //	}
    //	this.blockInput = false;
    //	this.inputLockCount = 0;
    //}

    //protected void BeginDrag(ref POINTER_INFO curPtr)
    //{
    //	curPtr.targetObj.OnEZDragDrop_Internal(new EZDragDropParams(EZDragDropEvent.Begin, curPtr.targetObj, curPtr));
    //	curPtr.targetObj.DragUpdatePosition(curPtr);
    //}

    //protected void DoDragUpdate(POINTER_INFO curPtr)
    //{
    //	IUIObject targetObj = curPtr.targetObj;
    //	targetObj.DragUpdatePosition(curPtr);
    //	RaycastHit[] array = Physics.RaycastAll(curPtr.ray, curPtr.rayDepth, curPtr.layerMask);
    //	bool flag = false;
    //	float num = float.PositiveInfinity;
    //	for (int i = 0; i < array.Length; i++)
    //	{
    //		if (array[i].transform != targetObj.transform && array[i].distance < num)
    //		{
    //			num = array[i].distance;
    //			targetObj.DropTarget = array[i].transform.gameObject;
    //			flag = true;
    //		}
    //	}
    //	if (!flag)
    //	{
    //		targetObj.DropTarget = null;
    //	}
    //	POINTER_INFO.INPUT_EVENT evt = curPtr.evt;
    //	switch (evt)
    //	{
    //	case POINTER_INFO.INPUT_EVENT.NO_CHANGE:
    //		break;
    //	default:
    //		if (evt != POINTER_INFO.INPUT_EVENT.DRAG)
    //		{
    //			return;
    //		}
    //		break;
    //	case POINTER_INFO.INPUT_EVENT.RELEASE:
    //		curPtr.targetObj.OnEZDragDrop_Internal(new EZDragDropParams(EZDragDropEvent.Dropped, targetObj, curPtr));
    //		return;
    //	}
    //	curPtr.targetObj.OnEZDragDrop_Internal(new EZDragDropParams(EZDragDropEvent.Update, targetObj, curPtr));
    //}

    //// Token: 0x060002C5 RID: 709 RVA: 0x00013960 File Offset: 0x00011B60
    //public virtual void Update()
    //{
    //	if (!this.m_started)
    //	{
    //		return;
    //	}
    //	if (this.lastUpdateFrame != Time.frameCount)
    //	{
    //		this.lastUpdateFrame = Time.frameCount;
    //		this.pointerPoller();
    //		if (this.focusObj != null)
    //		{
    //			this.PollKeyboard();
    //		}
    //		this.DispatchInput();
    //		return;
    //	}
    //}

    //// Token: 0x060002C6 RID: 710 RVA: 0x000139BC File Offset: 0x00011BBC
    //protected void DispatchInput()
    //{
    //	this.numNonUIHits = 0;
    //	this.rayIsNonUIHit = false;
    //	for (int i = 0; i < this.usedPointers.Length; i++)
    //	{
    //		this.usedPointers[i] = false;
    //	}
    //	if (this.mouseTouchListeners != null)
    //	{
    //		for (int j = 0; j < this.numActivePointers; j++)
    //		{
    //			for (int k = 0; k < this.uiCameras.Length; k++)
    //			{
    //				if (this.uiCameras[k].camera.gameObject.active)
    //				{
    //					this.DispatchHelper(ref this.pointers[k, this.activePointers[j]], k);
    //					if (this.mouseTouchListeners != null)
    //					{
    //						this.mouseTouchListeners(this.pointers[k, this.activePointers[j]]);
    //					}
    //					if (this.usedPointers[this.activePointers[j]])
    //					{
    //						break;
    //					}
    //				}
    //			}
    //		}
    //	}
    //	else
    //	{
    //		for (int l = 0; l < this.numActivePointers; l++)
    //		{
    //			for (int m = 0; m < this.uiCameras.Length; m++)
    //			{
    //				if (this.uiCameras[m].camera.gameObject.active)
    //				{
    //					this.DispatchHelper(ref this.pointers[m, this.activePointers[l]], m);
    //					if (this.usedPointers[this.activePointers[l]])
    //					{
    //						break;
    //					}
    //				}
    //			}
    //		}
    //	}
    //	if (this.pointerType == UIManager.POINTER_TYPE.RAY || this.pointerType == UIManager.POINTER_TYPE.MOUSE_AND_RAY || this.pointerType == UIManager.POINTER_TYPE.TOUCHPAD_AND_RAY)
    //	{
    //		this.DispatchHelper(ref this.rayPtr, -1);
    //		if (this.rayListeners != null)
    //		{
    //			this.rayListeners(this.rayPtr);
    //		}
    //	}
    //	this.CallNonUIHitDelegate();
    //}

    //// Token: 0x060002C7 RID: 711 RVA: 0x00013B90 File Offset: 0x00011D90
    //protected void DispatchHelper(ref POINTER_INFO curPtr, int camIndex)
    //{
    //	if (this.inputOutsideViewport == UIManager.OUTSIDE_VIEWPORT.Process_All || curPtr.type == POINTER_INFO.POINTER_TYPE.RAY || curPtr.camera.pixelRect.Contains(curPtr.devicePos))
    //	{
    //		if (curPtr.targetObj != null && curPtr.targetObj.IsDragging)
    //		{
    //			this.DoDragUpdate(curPtr);
    //		}
    //		else
    //		{
    //			switch (curPtr.evt)
    //			{
    //			case POINTER_INFO.INPUT_EVENT.NO_CHANGE:
    //			case POINTER_INFO.INPUT_EVENT.MOVE:
    //				this.tempObj = null;
    //				if (Physics.Raycast(curPtr.ray, out this.hit, curPtr.rayDepth, curPtr.layerMask))
    //				{
    //					this.tempObj = (IUIObject)this.hit.collider.gameObject.GetComponent("IUIObject");
    //					curPtr.hitInfo = this.hit;
    //					if (this.tempObj != null)
    //					{
    //						this.tempObj = this.tempObj.GetControl(ref curPtr);
    //					}
    //					if (this.tempObj == null)
    //					{
    //						this.AddNonUIHit(curPtr.id, camIndex);
    //						if (this.warnOnNonUiHits)
    //						{
    //							this.LogNonUIObjErr(this.hit.collider.gameObject);
    //						}
    //					}
    //					if (!curPtr.active)
    //					{
    //						if (curPtr.targetObj != this.tempObj && curPtr.targetObj != null)
    //						{
    //							this.tempPtr.Copy(curPtr);
    //							this.tempPtr.evt = POINTER_INFO.INPUT_EVENT.MOVE_OFF;
    //							if (!this.blockInput)
    //							{
    //								curPtr.targetObj.OnInput(this.tempPtr);
    //							}
    //						}
    //						if (!this.blockInput)
    //						{
    //							curPtr.targetObj = this.tempObj;
    //							if (this.tempObj != null)
    //							{
    //								curPtr.targetObj.OnInput(curPtr);
    //							}
    //						}
    //					}
    //					else if (curPtr.targetObj != null && !this.blockInput)
    //					{
    //						curPtr.targetObj.OnInput(curPtr);
    //					}
    //				}
    //				else
    //				{
    //					curPtr.hitInfo = default(RaycastHit);
    //					if (curPtr.targetObj != null && !curPtr.active)
    //					{
    //						curPtr.evt = POINTER_INFO.INPUT_EVENT.MOVE_OFF;
    //						curPtr.targetObj.OnInput(curPtr);
    //					}
    //					if (!curPtr.active)
    //					{
    //						curPtr.targetObj = null;
    //					}
    //				}
    //				break;
    //			case POINTER_INFO.INPUT_EVENT.PRESS:
    //				if (Physics.Raycast(curPtr.ray, out this.hit, curPtr.rayDepth, curPtr.layerMask))
    //				{
    //					this.tempObj = (IUIObject)this.hit.collider.gameObject.GetComponent("IUIObject");
    //					curPtr.hitInfo = this.hit;
    //					if (this.tempObj != null)
    //					{
    //						this.tempObj = this.tempObj.GetControl(ref curPtr);
    //					}
    //					if (this.tempObj == null)
    //					{
    //						this.AddNonUIHit(curPtr.id, camIndex);
    //						if (this.warnOnNonUiHits)
    //						{
    //							this.LogNonUIObjErr(this.hit.collider.gameObject);
    //						}
    //					}
    //					if (this.tempObj != curPtr.targetObj && curPtr.targetObj != null)
    //					{
    //						this.tempPtr.Copy(curPtr);
    //						this.tempPtr.evt = POINTER_INFO.INPUT_EVENT.MOVE_OFF;
    //						if (!this.blockInput)
    //						{
    //							curPtr.targetObj.OnInput(this.tempPtr);
    //						}
    //					}
    //					if (!this.blockInput)
    //					{
    //						curPtr.targetObj = this.tempObj;
    //					}
    //					else
    //					{
    //						if (curPtr.targetObj != null)
    //						{
    //							this.tempPtr.Copy(curPtr);
    //							this.tempPtr.evt = POINTER_INFO.INPUT_EVENT.RELEASE_OFF;
    //							curPtr.targetObj.OnInput(this.tempPtr);
    //						}
    //						curPtr.targetObj = null;
    //					}
    //					if (curPtr.targetObj != null)
    //					{
    //						if (!this.blockInput)
    //						{
    //							curPtr.targetObj.OnInput(curPtr);
    //						}
    //						if (curPtr.targetObj != this.focusObj && curPtr.type == POINTER_INFO.POINTER_TYPE.RAY == this.focusWithRay)
    //						{
    //							if (curPtr.targetObj.GotFocus())
    //							{
    //								this.FocusObject = curPtr.targetObj;
    //							}
    //							else
    //							{
    //								this.FocusObject = null;
    //							}
    //						}
    //					}
    //					else if (curPtr.type == POINTER_INFO.POINTER_TYPE.RAY == this.focusWithRay)
    //					{
    //						this.FocusObject = null;
    //					}
    //				}
    //				else
    //				{
    //					curPtr.hitInfo = default(RaycastHit);
    //					if (this.blockInput && curPtr.targetObj != null)
    //					{
    //						this.tempPtr.Copy(curPtr);
    //						this.tempPtr.evt = POINTER_INFO.INPUT_EVENT.RELEASE_OFF;
    //						curPtr.targetObj.OnInput(this.tempPtr);
    //					}
    //					curPtr.targetObj = null;
    //					if (curPtr.type == POINTER_INFO.POINTER_TYPE.RAY == this.focusWithRay)
    //					{
    //						this.FocusObject = null;
    //					}
    //				}
    //				break;
    //			case POINTER_INFO.INPUT_EVENT.RELEASE:
    //			case POINTER_INFO.INPUT_EVENT.TAP:
    //			case POINTER_INFO.INPUT_EVENT.DRAG:
    //			case POINTER_INFO.INPUT_EVENT.MOUSE_RIGHT_TAP:
    //				if (curPtr.evt == POINTER_INFO.INPUT_EVENT.RELEASE || curPtr.evt == POINTER_INFO.INPUT_EVENT.TAP)
    //				{
    //					this.tempObj = null;
    //					if (Physics.Raycast(curPtr.ray, out this.hit, curPtr.rayDepth, curPtr.layerMask))
    //					{
    //						this.tempObj = (IUIObject)this.hit.collider.gameObject.GetComponent("IUIObject");
    //						curPtr.hitInfo = this.hit;
    //						if (this.tempObj != null)
    //						{
    //							this.tempObj = this.tempObj.GetControl(ref curPtr);
    //						}
    //						if (this.tempObj == null)
    //						{
    //							this.AddNonUIHit(curPtr.id, camIndex);
    //						}
    //					}
    //					else
    //					{
    //						curPtr.hitInfo = default(RaycastHit);
    //					}
    //					if (this.tempObj != curPtr.targetObj)
    //					{
    //						if (curPtr.targetObj != null)
    //						{
    //							this.tempPtr.Copy(curPtr);
    //							if (curPtr.evt == POINTER_INFO.INPUT_EVENT.RELEASE)
    //							{
    //								this.tempPtr.evt = POINTER_INFO.INPUT_EVENT.RELEASE_OFF;
    //							}
    //							else
    //							{
    //								this.tempPtr.evt = POINTER_INFO.INPUT_EVENT.TAP;
    //							}
    //							curPtr.targetObj.OnInput(this.tempPtr);
    //						}
    //						if (curPtr.id >= 0)
    //						{
    //							this.usedPointers[curPtr.id] = true;
    //						}
    //						if (!this.blockInput)
    //						{
    //							curPtr.targetObj = this.tempObj;
    //						}
    //						if (this.tempObj != null && curPtr.evt != POINTER_INFO.INPUT_EVENT.TAP && !this.blockInput)
    //						{
    //							this.tempObj.OnInput(curPtr);
    //						}
    //					}
    //					else if (curPtr.targetObj != null)
    //					{
    //						curPtr.targetObj.OnInput(curPtr);
    //						if (curPtr.id >= 0)
    //						{
    //							this.usedPointers[curPtr.id] = true;
    //						}
    //					}
    //					if (curPtr.type == POINTER_INFO.POINTER_TYPE.TOUCHPAD)
    //					{
    //						curPtr.targetObj = null;
    //					}
    //				}
    //				else
    //				{
    //					if (Physics.Raycast(curPtr.ray, out this.hit, curPtr.rayDepth, curPtr.layerMask))
    //					{
    //						curPtr.hitInfo = this.hit;
    //						if (curPtr.targetObj == null)
    //						{
    //							this.AddNonUIHit(curPtr.id, camIndex);
    //						}
    //					}
    //					else
    //					{
    //						curPtr.hitInfo = default(RaycastHit);
    //					}
    //					if (curPtr.targetObj != null && !this.blockInput)
    //					{
    //						curPtr.targetObj.OnInput(curPtr);
    //						if (curPtr.targetObj.IsDraggable && !curPtr.isTap)
    //						{
    //							this.BeginDrag(ref curPtr);
    //						}
    //					}
    //				}
    //				break;
    //			}
    //		}
    //		if (curPtr.targetObj != null && curPtr.id >= 0)
    //		{
    //			this.usedPointers[curPtr.id] = true;
    //		}
    //		return;
    //	}
    //	if (this.inputOutsideViewport == UIManager.OUTSIDE_VIEWPORT.Ignore)
    //	{
    //		return;
    //	}
    //	if (curPtr.targetObj == null)
    //	{
    //		return;
    //	}
    //	this.tempPtr.Copy(curPtr);
    //	if (curPtr.active)
    //	{
    //		this.tempPtr.evt = POINTER_INFO.INPUT_EVENT.RELEASE_OFF;
    //		curPtr.targetObj.OnInput(this.tempPtr);
    //	}
    //	else
    //	{
    //		this.tempPtr.evt = POINTER_INFO.INPUT_EVENT.MOVE_OFF;
    //		this.tempPtr.targetObj.OnInput(this.tempPtr);
    //	}
    //	if (curPtr.targetObj.IsDragging)
    //	{
    //		curPtr.targetObj.OnEZDragDrop_Internal(new EZDragDropParams(EZDragDropEvent.Dropped, curPtr.targetObj, curPtr));
    //	}
    //	curPtr.targetObj = null;
    //}

    //// Token: 0x060002C8 RID: 712 RVA: 0x000143C0 File Offset: 0x000125C0
    //protected void PollMouse()
    //{
    //	this.PollMouse(ref this.pointers[0, 0]);
    //	for (int i = 1; i < this.uiCameras.Length; i++)
    //	{
    //		if (this.uiCameras[i].camera.gameObject.active)
    //		{
    //			this.pointers[i, 0].Reuse(this.pointers[0, 0]);
    //			this.pointers[i, 0].prevRay = this.pointers[i, 0].ray;
    //			this.pointers[i, 0].ray = this.uiCameras[i].camera.ScreenPointToRay(this.pointers[i, 0].devicePos);
    //		}
    //	}
    //}

    //// Token: 0x060002C9 RID: 713 RVA: 0x00014494 File Offset: 0x00012694
    //protected void PollMouseAndTouchpad()
    //{
    //	this.numActivePointers = 1;
    //	int num = this.numTouches - 1;
    //	this.activePointers[this.numActivePointers - 1] = num;
    //	this.PollMouse(ref this.pointers[0, num]);
    //	for (int i = 1; i < this.uiCameras.Length; i++)
    //	{
    //		if (this.uiCameras[i].camera.gameObject.active)
    //		{
    //			this.pointers[i, num].Reuse(this.pointers[0, num]);
    //			this.pointers[i, num].prevRay = this.pointers[i, num].ray;
    //			this.pointers[i, num].ray = this.uiCameras[i].camera.ScreenPointToRay(this.pointers[i, num].devicePos);
    //		}
    //	}
    //}

    //// Token: 0x060002CA RID: 714 RVA: 0x00014588 File Offset: 0x00012788
    //protected void PollMouse(ref POINTER_INFO curPtr)
    //{
    //	this.down = Input.GetMouseButton(0);
    //	this.rightDown = Input.GetMouseButton(1);
    //	float num = Input.GetAxis("Mouse ScrollWheel");
    //	num *= Time.deltaTime;
    //	bool flag = num != 0f;
    //	if (!this.lastUpIsRightMouse)
    //	{
    //		if (this.down && curPtr.active)
    //		{
    //			if (Input.mousePosition != curPtr.devicePos)
    //			{
    //				curPtr.evt = POINTER_INFO.INPUT_EVENT.DRAG;
    //				curPtr.inputDelta = Input.mousePosition - curPtr.devicePos;
    //				curPtr.devicePos = Input.mousePosition;
    //				if (curPtr.isTap)
    //				{
    //					this.tempVec = curPtr.origPos - curPtr.devicePos;
    //					if (Mathf.Abs(this.tempVec.x) > this.dragThreshold || Mathf.Abs(this.tempVec.y) > this.dragThreshold)
    //					{
    //						curPtr.isTap = false;
    //					}
    //				}
    //			}
    //			else
    //			{
    //				curPtr.evt = POINTER_INFO.INPUT_EVENT.NO_CHANGE;
    //				curPtr.inputDelta = Vector3.zero;
    //			}
    //		}
    //		else if (this.down && !curPtr.active)
    //		{
    //			curPtr.Reset(this.curActionID++);
    //			curPtr.evt = POINTER_INFO.INPUT_EVENT.PRESS;
    //			curPtr.active = true;
    //			curPtr.inputDelta = Input.mousePosition - curPtr.devicePos;
    //			curPtr.origPos = Input.mousePosition;
    //			curPtr.isTap = true;
    //			curPtr.activeTime = Time.time;
    //		}
    //		else if (!this.down && curPtr.active)
    //		{
    //			curPtr.inputDelta = Input.mousePosition - curPtr.devicePos;
    //			curPtr.devicePos = Input.mousePosition;
    //			if (curPtr.isTap)
    //			{
    //				this.tempVec = curPtr.origPos - curPtr.devicePos;
    //				if (Mathf.Abs(this.tempVec.x) > this.dragThreshold || Mathf.Abs(this.tempVec.y) > this.dragThreshold)
    //				{
    //					curPtr.isTap = false;
    //				}
    //			}
    //			if (curPtr.isTap)
    //			{
    //				curPtr.evt = POINTER_INFO.INPUT_EVENT.TAP;
    //			}
    //			else
    //			{
    //				curPtr.evt = POINTER_INFO.INPUT_EVENT.RELEASE;
    //			}
    //			curPtr.active = false;
    //			curPtr.activeTime = 0f;
    //		}
    //		else if (!this.down && Input.mousePosition != curPtr.devicePos)
    //		{
    //			curPtr.evt = POINTER_INFO.INPUT_EVENT.MOVE;
    //			curPtr.inputDelta = Input.mousePosition - curPtr.devicePos;
    //			curPtr.devicePos = Input.mousePosition;
    //		}
    //		else
    //		{
    //			curPtr.evt = POINTER_INFO.INPUT_EVENT.NO_CHANGE;
    //			curPtr.inputDelta = Vector3.zero;
    //		}
    //	}
    //	if (this.rightDown && !this.lastUpIsRightMouse)
    //	{
    //		this.lastUpIsRightMouse = true;
    //		curPtr.Reset(this.curActionID++);
    //		curPtr.evt = POINTER_INFO.INPUT_EVENT.NO_CHANGE;
    //		curPtr.inputDelta = Input.mousePosition - curPtr.devicePos;
    //		curPtr.origPos = Input.mousePosition;
    //		curPtr.isTap = true;
    //		curPtr.activeTime = Time.time;
    //	}
    //	else if (!this.rightDown && this.lastUpIsRightMouse)
    //	{
    //		curPtr.inputDelta = Input.mousePosition - curPtr.devicePos;
    //		curPtr.devicePos = Input.mousePosition;
    //		if (curPtr.isTap)
    //		{
    //			this.tempVec = curPtr.origPos - curPtr.devicePos;
    //			if (Mathf.Abs(this.tempVec.x) > this.dragThreshold || Mathf.Abs(this.tempVec.y) > this.dragThreshold)
    //			{
    //				curPtr.isTap = false;
    //			}
    //		}
    //		if (curPtr.isTap)
    //		{
    //			curPtr.evt = POINTER_INFO.INPUT_EVENT.MOUSE_RIGHT_TAP;
    //		}
    //		curPtr.activeTime = 0f;
    //		this.lastUpIsRightMouse = false;
    //	}
    //	if (flag)
    //	{
    //		curPtr.inputDelta.z = num;
    //	}
    //	curPtr.devicePos = Input.mousePosition;
    //	curPtr.prevRay = curPtr.ray;
    //	curPtr.ray = this.uiCameras[0].camera.ScreenPointToRay(curPtr.devicePos);
    //}

    //// Token: 0x060002CB RID: 715 RVA: 0x000149B8 File Offset: 0x00012BB8
    //protected void PollTouchpad()
    //{
    //}

    //// Token: 0x060002CC RID: 716 RVA: 0x000149BC File Offset: 0x00012BBC
    //protected void PollRay()
    //{
    //	if (this.actionAxis.Length != 0)
    //	{
    //		this.rayActive = Input.GetButton(this.actionAxis);
    //	}
    //	else
    //	{
    //		this.rayActive = (this.rayState != UIManager.RAY_ACTIVE_STATE.Inactive);
    //		if (this.rayState == UIManager.RAY_ACTIVE_STATE.Momentary)
    //		{
    //			this.rayState = UIManager.RAY_ACTIVE_STATE.Inactive;
    //		}
    //	}
    //	if (this.rayActive && this.rayPtr.active)
    //	{
    //		if (this.raycastingTransform.forward != this.rayPtr.ray.direction || this.raycastingTransform.position != this.rayPtr.ray.origin)
    //		{
    //			this.rayPtr.evt = POINTER_INFO.INPUT_EVENT.DRAG;
    //			this.tempVec = this.raycastingTransform.position + this.raycastingTransform.forward * this.rayDepth;
    //			this.rayPtr.inputDelta = this.tempVec - this.rayPtr.devicePos;
    //			this.rayPtr.devicePos = this.tempVec;
    //			if (this.rayPtr.isTap)
    //			{
    //				this.tempVec = this.rayPtr.origPos - this.rayPtr.devicePos;
    //				if (this.tempVec.sqrMagnitude > this.rayDragThreshold * this.rayDragThreshold)
    //				{
    //					this.rayPtr.isTap = false;
    //				}
    //			}
    //		}
    //		else
    //		{
    //			this.rayPtr.evt = POINTER_INFO.INPUT_EVENT.NO_CHANGE;
    //			this.rayPtr.inputDelta = Vector3.zero;
    //		}
    //	}
    //	else if (this.rayActive && !this.rayPtr.active)
    //	{
    //		this.rayPtr.Reset(this.curActionID++);
    //		this.rayPtr.evt = POINTER_INFO.INPUT_EVENT.PRESS;
    //		this.rayPtr.active = true;
    //		this.rayPtr.origPos = this.raycastingTransform.position + this.raycastingTransform.forward * this.rayDepth;
    //		this.rayPtr.inputDelta = this.rayPtr.origPos - this.rayPtr.devicePos;
    //		this.rayPtr.devicePos = this.rayPtr.origPos;
    //		this.rayPtr.isTap = true;
    //		this.rayPtr.activeTime = Time.time;
    //	}
    //	else if (!this.rayActive && this.rayPtr.active)
    //	{
    //		if (this.rayPtr.isTap)
    //		{
    //			this.rayPtr.evt = POINTER_INFO.INPUT_EVENT.TAP;
    //		}
    //		else
    //		{
    //			this.rayPtr.evt = POINTER_INFO.INPUT_EVENT.RELEASE;
    //		}
    //		this.tempVec = this.raycastingTransform.position + this.raycastingTransform.forward * this.rayDepth;
    //		this.rayPtr.inputDelta = this.tempVec - this.rayPtr.devicePos;
    //		this.rayPtr.devicePos = this.tempVec;
    //		this.rayPtr.active = false;
    //		this.rayPtr.activeTime = 0f;
    //	}
    //	else if (!this.rayActive && Input.mousePosition != this.rayPtr.devicePos)
    //	{
    //		this.rayPtr.evt = POINTER_INFO.INPUT_EVENT.MOVE;
    //		this.tempVec = this.raycastingTransform.position + this.raycastingTransform.forward * this.rayDepth;
    //		this.rayPtr.inputDelta = this.tempVec - this.rayPtr.devicePos;
    //		this.rayPtr.devicePos = this.tempVec;
    //	}
    //	else
    //	{
    //		this.rayPtr.evt = POINTER_INFO.INPUT_EVENT.NO_CHANGE;
    //		this.rayPtr.inputDelta = Vector3.zero;
    //	}
    //	this.rayPtr.prevRay = this.rayPtr.ray;
    //	this.rayPtr.ray = new Ray(this.raycastingTransform.position, this.raycastingTransform.forward);
    //}

    //// Token: 0x060002CD RID: 717 RVA: 0x00014DF4 File Offset: 0x00012FF4
    //protected void PollMouseRay()
    //{
    //	this.PollMouse();
    //	this.PollRay();
    //}

    //// Token: 0x060002CE RID: 718 RVA: 0x00014E04 File Offset: 0x00013004
    //protected void PollTouchpadRay()
    //{
    //	this.PollTouchpad();
    //	this.PollRay();
    //}

    //// Token: 0x060002CF RID: 719 RVA: 0x00014E14 File Offset: 0x00013014
    //protected void PollKeyboard()
    //{
    //	this.ProcessKeyboard();
    //	if (Input.GetKeyDown(KeyCode.RightArrow))
    //	{
    //		this.controlText = ((IKeyFocusable)this.focusObj).Content;
    //		this.insert = Mathf.Min(this.controlText.Length, this.insert + 1);
    //		((IKeyFocusable)this.focusObj).SetInputText(this.controlText, ref this.insert);
    //	}
    //	else if (Input.GetKeyDown(KeyCode.LeftArrow))
    //	{
    //		this.controlText = ((IKeyFocusable)this.focusObj).Content;
    //		this.insert = Mathf.Max(0, this.insert - 1);
    //		((IKeyFocusable)this.focusObj).SetInputText(this.controlText, ref this.insert);
    //	}
    //	else if (Input.GetKeyDown(KeyCode.Home))
    //	{
    //		this.controlText = ((IKeyFocusable)this.focusObj).Content;
    //		this.insert = 0;
    //		((IKeyFocusable)this.focusObj).SetInputText(this.controlText, ref this.insert);
    //	}
    //	else if (Input.GetKeyDown(KeyCode.End))
    //	{
    //		this.controlText = ((IKeyFocusable)this.focusObj).Content;
    //		this.insert = this.controlText.Length;
    //		((IKeyFocusable)this.focusObj).SetInputText(this.controlText, ref this.insert);
    //	}
    //}

    //// Token: 0x060002D0 RID: 720 RVA: 0x00014F88 File Offset: 0x00013188
    //protected void ProcessKeyboard()
    //{
    //	if (Input.inputString.Length == 0)
    //	{
    //		return;
    //	}
    //	this.controlText = ((IKeyFocusable)this.focusObj).Content;
    //	this.insert = Mathf.Clamp(this.insert, 0, this.controlText.Length);
    //	if (this.sb.Length > 0)
    //	{
    //		this.sb.Replace(this.sb.ToString(), this.controlText);
    //	}
    //	else
    //	{
    //		this.sb.Append(this.controlText);
    //	}
    //	foreach (char c in Input.inputString)
    //	{
    //		if (c == '\b')
    //		{
    //			this.insert = Mathf.Max(0, this.insert - 1);
    //			if (this.insert < this.sb.Length)
    //			{
    //				this.sb.Remove(this.insert, 1);
    //			}
    //		}
    //		else
    //		{
    //			this.sb.Insert(this.insert, c);
    //			this.insert++;
    //		}
    //	}
    //	this.controlText = this.sb.ToString();
    //	this.controlText = ((IKeyFocusable)this.focusObj).SetInputText(this.controlText, ref this.insert);
    //}

    //// Token: 0x17000081 RID: 129
    //// (get) Token: 0x060002D1 RID: 721 RVA: 0x000150E0 File Offset: 0x000132E0
    //// (set) Token: 0x060002D2 RID: 722 RVA: 0x000150E8 File Offset: 0x000132E8
    //public UIManager.RAY_ACTIVE_STATE RayActive
    //{
    //	get
    //	{
    //		return this.rayState;
    //	}
    //	set
    //	{
    //		this.rayState = value;
    //	}
    //}

    //// Token: 0x060002D3 RID: 723 RVA: 0x000150F4 File Offset: 0x000132F4
    //public void Detarget(IUIObject obj)
    //{
    //	this.Retarget(obj, null);
    //}

    //// Token: 0x060002D4 RID: 724 RVA: 0x00015100 File Offset: 0x00013300
    //public void Retarget(IUIObject oldObj, IUIObject newObj)
    //{
    //	if (this.uiCameras == null)
    //	{
    //		return;
    //	}
    //	for (int i = 0; i < this.numActivePointers; i++)
    //	{
    //		for (int j = 0; j < this.uiCameras.Length; j++)
    //		{
    //			if (this.uiCameras[j].camera != null && this.uiCameras[j].camera.gameObject.active && this.pointers[j, this.activePointers[i]].targetObj != null)
    //			{
    //				if (this.pointers[j, this.activePointers[i]].targetObj != oldObj)
    //				{
    //					break;
    //				}
    //				this.pointers[j, this.activePointers[i]].targetObj = newObj;
    //			}
    //		}
    //	}
    //	if (this.rayPtr.targetObj == oldObj)
    //	{
    //		this.rayPtr.targetObj = newObj;
    //	}
    //}

    //// Token: 0x060002D5 RID: 725 RVA: 0x000151FC File Offset: 0x000133FC
    //public bool GetPointer(IUIObject obj, out POINTER_INFO ptr)
    //{
    //	if (this.uiCameras == null)
    //	{
    //		ptr = default(POINTER_INFO);
    //		return false;
    //	}
    //	for (int i = 0; i < this.numActivePointers; i++)
    //	{
    //		int j = 0;
    //		while (j < this.uiCameras.Length)
    //		{
    //			if (this.uiCameras[j].camera != null && this.uiCameras[j].camera.gameObject.active && this.pointers[j, this.activePointers[i]].targetObj != null)
    //			{
    //				if (this.pointers[j, this.activePointers[i]].targetObj == obj)
    //				{
    //					ptr = this.pointers[j, this.activePointers[i]];
    //					return true;
    //				}
    //				break;
    //			}
    //			else
    //			{
    //				j++;
    //			}
    //		}
    //	}
    //	if (this.rayPtr.targetObj == obj)
    //	{
    //		ptr = this.rayPtr;
    //		return true;
    //	}
    //	ptr = default(POINTER_INFO);
    //	return false;
    //}

    //// Token: 0x060002D6 RID: 726 RVA: 0x00015318 File Offset: 0x00013518
    //public void LockInput()
    //{
    //	this.blockInput = true;
    //	this.inputLockCount++;
    //}

    //// Token: 0x060002D7 RID: 727 RVA: 0x00015330 File Offset: 0x00013530
    //public void UnlockInput()
    //{
    //	this.inputLockCount--;
    //	if (this.inputLockCount < 1)
    //	{
    //		this.inputLockCount = 0;
    //		this.blockInput = false;
    //	}
    //}

    //// Token: 0x17000082 RID: 130
    //// (get) Token: 0x060002D8 RID: 728 RVA: 0x00015368 File Offset: 0x00013568
    //// (set) Token: 0x060002D9 RID: 729 RVA: 0x00015370 File Offset: 0x00013570
    //public IUIObject FocusObject
    //{
    //	get
    //	{
    //		return this.focusObj;
    //	}
    //	set
    //	{
    //		if (this.focusObj != null && this.focusObj is IKeyFocusable)
    //		{
    //			((IKeyFocusable)this.focusObj).LostFocus();
    //		}
    //		this.focusObj = value;
    //		if (this.focusObj != null)
    //		{
    //			this.controlText = ((IKeyFocusable)this.focusObj).GetInputText(ref this.kbInfo);
    //			if (this.controlText == null)
    //			{
    //				this.controlText = string.Empty;
    //			}
    //			this.insert = this.kbInfo.insert;
    //			if (this.sb.Length > 0)
    //			{
    //				this.sb.Replace(this.sb.ToString(), this.controlText);
    //			}
    //			else
    //			{
    //				this.sb.Append(this.controlText);
    //			}
    //		}
    //	}
    //}

    //// Token: 0x17000083 RID: 131
    //// (get) Token: 0x060002DA RID: 730 RVA: 0x00015444 File Offset: 0x00013644
    //// (set) Token: 0x060002DB RID: 731 RVA: 0x0001544C File Offset: 0x0001364C
    //public int InsertionPoint
    //{
    //	get
    //	{
    //		return this.insert;
    //	}
    //	set
    //	{
    //		this.insert = value;
    //	}
    //}

    //// Token: 0x060002DC RID: 732 RVA: 0x00015458 File Offset: 0x00013658
    //protected static int FindInsertionPoint(string before, string after)
    //{
    //	if (before == null || after == null)
    //	{
    //		return 0;
    //	}
    //	int num = 0;
    //	while (num < before.Length && num < after.Length)
    //	{
    //		if (before[num] != after[num])
    //		{
    //			return num + 1;
    //		}
    //		num++;
    //	}
    //	return after.Length;
    //}

    //// Token: 0x060002DD RID: 733 RVA: 0x000154B4 File Offset: 0x000136B4
    //protected void LogNonUIObjErr(GameObject obj)
    //{
    //	Debug.LogWarning("The UIManager encountered a collider on object \"" + obj.name + "\" that does not not contain an IUIObject or derivative component.  Please double-check that this object has the correct layer and components assigned.");
    //}
}
