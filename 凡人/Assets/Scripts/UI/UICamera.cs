using System;
using UnityEngine;

/// <summary>
/// UI摄像机
/// </summary>
public class UICamera : MonoBehaviour
{
    public static string ClassName = "UICamera";

    private static UICamera instance;

    public Camera uiCamera;

    public GUIControl guiControl;

    public UIManager uiManager;

    private int mask = 17408;

    private EZCameraSettings uiCameraSetting = new EZCameraSettings();

    public static UICamera Instance
	{
		get
		{
			UICamera.InitUICamera();
			return UICamera.instance;
		}
	}

	public static void InitUICamera()
	{
		if (UICamera.instance != null)
		{
			return;
		}
		GameObject gameObject = new GameObject(UICamera.ClassName);
		UICamera.instance = gameObject.gameObject.AddComponent<UICamera>();
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		UICamera.CreateUICamera();//创建UI摄像机
        UICamera.CreateUIManager();//创建UIManager
		//CameraEffectManager.AddCameraEffect();
	}

	private static void CreateUICamera()
	{
		GameObject gameObject = new GameObject("UICam");
		gameObject.transform.parent = UICamera.instance.transform;
		gameObject.transform.position = new Vector3(0f, 122.8469f, 0f);
		UICamera.instance.uiCamera = gameObject.AddComponent<Camera>();
		UICamera.instance.uiCamera.tag = "UICam";
		UICamera.instance.uiCamera.clearFlags = CameraClearFlags.Depth;
		UICamera.instance.uiCamera.cullingMask = UICamera.instance.mask;
		UICamera.instance.uiCamera.orthographic = true;
		UICamera.instance.uiCamera.orthographicSize = 10f;
		UICamera.instance.uiCamera.nearClipPlane = 0.3f;
		UICamera.instance.uiCamera.farClipPlane = 50f;
		UICamera.instance.uiCamera.depth = 2f;
	}

	private static void CreateUIManager()
	{
		UICamera.instance.uiManager = UICamera.instance.uiCamera.gameObject.AddComponent<UIManager>();
		UICamera.instance.uiManager.pointerType = UIManager.POINTER_TYPE.MOUSE;
		UICamera.instance.uiManager.rayDepth = 50f;
		UICamera.instance.uiManager.rayMask = UICamera.instance.mask;
		UICamera.instance.uiCameraSetting.camera = UICamera.instance.uiCamera;
		UICamera.instance.uiCameraSetting.mask = UICamera.instance.mask;
		UICamera.instance.uiCameraSetting.rayDepth = 50f;
		UICamera.instance.uiManager.uiCameras[0] = UICamera.instance.uiCameraSetting;
		UICamera.instance.uiManager.rayCamera = UICamera.instance.uiCamera;
		UICamera.instance.uiManager.Init();
		UICamera.instance.guiControl = UICamera.instance.uiCamera.gameObject.AddComponent<GUIControl>();
	}
}
