using System;
using UnityEngine;

/// <summary>
/// 摄像机特效
/// </summary>
public class CameraEffectManager : MonoBehaviour
{
 //   public static SunShafts sunShafts;

 //   public static TiltShift tiltShift;

 //   public static Vignetting vignetting;

 //   // Token: 0x040015AC RID: 5548
 //   public static SSAOEffect ssaoEffect;

 //   // Token: 0x040015AD RID: 5549
 //   public static BloomAndLensFlares bloomAndLensFlares;

 //   // Token: 0x040015AE RID: 5550
 //   public static ColorCorrectionCurves colorCorrectionCurves;

 //   // Token: 0x040015AF RID: 5551
 //   public static AntialiasingAsPostEffect antialiasingAsPostEffect;

 //   // Token: 0x040015B0 RID: 5552
 //   public static DepthOfFieldScatter depthOfFieldScatter;

 //   // Token: 0x040015B1 RID: 5553
 //   private static GrayscaleEffect mainGrayscaleEffect;

 //   // Token: 0x040015B2 RID: 5554
 //   public static MotionBlur motionBlur;

 //   // Token: 0x040015B3 RID: 5555
 //   public static GrayscaleEffect grayscaleEffect;

 //   public static GrayscaleEffect MainGrayscaleEffect
	//{
	//	get
	//	{
	//		if (CameraEffectManager.mainGrayscaleEffect == null)
	//		{
	//			CameraEffectManager.mainGrayscaleEffect = SceneManager.Instance.gameObject.GetComponent<GrayscaleEffect>();
	//			if (CameraEffectManager.mainGrayscaleEffect == null)
	//			{
	//				CameraEffectManager.mainGrayscaleEffect = SceneManager.Instance.gameObject.AddComponent<GrayscaleEffect>();
	//				CameraEffectManager.mainGrayscaleEffect.shader = (Shader)Resources.Load("Shaders/GrayscaleEffect", typeof(Shader));
	//			}
	//			CameraEffectManager.mainGrayscaleEffect.enabled = false;
	//		}
	//		return CameraEffectManager.mainGrayscaleEffect;
	//	}
	//}

    /// <summary>
    /// 获取所有摄像特效组件机组件
    /// </summary>
	public static void GetAllCameraEffectComponent()
	{
		GameObject gameObject = FanrenSceneManager.Instance.gameObject;
		//CameraEffectManager.sunShafts = gameObject.GetComponent<SunShafts>();
		//CameraEffectManager.tiltShift = gameObject.GetComponent<TiltShift>();
		//CameraEffectManager.vignetting = gameObject.GetComponent<Vignetting>();
		//CameraEffectManager.ssaoEffect = gameObject.GetComponent<SSAOEffect>();
		//CameraEffectManager.bloomAndLensFlares = gameObject.GetComponent<BloomAndLensFlares>();
		//CameraEffectManager.colorCorrectionCurves = gameObject.GetComponent<ColorCorrectionCurves>();
		//CameraEffectManager.antialiasingAsPostEffect = gameObject.GetComponent<AntialiasingAsPostEffect>();
		//CameraEffectManager.depthOfFieldScatter = gameObject.GetComponent<DepthOfFieldScatter>();
		//CameraEffectManager.motionBlur = gameObject.GetComponent<MotionBlur>();
		//if (CameraEffectManager.motionBlur == null)
		//{
		//	CameraEffectManager.motionBlur = gameObject.AddComponent<MotionBlur>();
		//}
		//CameraEffectManager.motionBlur.shader = (Shader)Resources.Load("Shaders/MotionBlur", typeof(Shader));
		//CameraEffectManager.motionBlur.blurAmount = 0.5f;
		//CameraEffectManager.motionBlur.enabled = false;
		//if (CameraEffectManager.depthOfFieldScatter != null)
		//{
		//	CameraEffectManager.depthOfFieldScatter.focalTransform = Player.Instance.GetTrans();
		//}
		//if (CameraEffectManager.sunShafts != null)
		//{
		//	GameObject gameObject2 = GameObject.Find("sun shafts");
		//	if (gameObject2)
		//	{
		//		CameraEffectManager.sunShafts.sunTransform = gameObject2.transform;
		//	}
		//}
		//CameraEffectManager.SetCameraEffect(SystemSetting.quality);
	}

	//public static void AddCameraEffect()
	//{
	//	CameraEffectManager.grayscaleEffect = Camera.main.GetComponent<GrayscaleEffect>();
	//	if (CameraEffectManager.grayscaleEffect == null)
	//	{
	//		CameraEffectManager.grayscaleEffect = Camera.main.gameObject.AddComponent<GrayscaleEffect>();
	//		CameraEffectManager.grayscaleEffect.shader = (Shader)Resources.Load("Shaders/GrayscaleEffect", typeof(Shader));
	//	}
	//	CameraEffectManager.grayscaleEffect.enabled = false;
	//}

	//public static void SetAntialiasingAsPostEffect(bool enabled)
	//{
	//	if (CameraEffectManager.antialiasingAsPostEffect != null)
	//	{
	//		CameraEffectManager.antialiasingAsPostEffect.enabled = enabled;
	//	}
	//}

	//public static void SetCameraEffect(int level)
	//{
	//	switch (level)
	//	{
	//	case 1:
	//		if (CameraEffectManager.sunShafts != null)
	//		{
	//			CameraEffectManager.sunShafts.enabled = false;
	//		}
	//		if (CameraEffectManager.tiltShift != null)
	//		{
	//			CameraEffectManager.tiltShift.enabled = false;
	//		}
	//		if (CameraEffectManager.vignetting != null)
	//		{
	//			CameraEffectManager.vignetting.enabled = true;
	//		}
	//		if (CameraEffectManager.bloomAndLensFlares != null)
	//		{
	//			CameraEffectManager.bloomAndLensFlares.enabled = false;
	//		}
	//		if (CameraEffectManager.colorCorrectionCurves != null)
	//		{
	//			CameraEffectManager.colorCorrectionCurves.enabled = true;
	//		}
	//		if (CameraEffectManager.depthOfFieldScatter != null)
	//		{
	//			CameraEffectManager.depthOfFieldScatter.enabled = false;
	//		}
	//		if (CameraEffectManager.ssaoEffect != null)
	//		{
	//			CameraEffectManager.ssaoEffect.enabled = false;
	//		}
	//		break;
	//	case 2:
	//		if (CameraEffectManager.sunShafts != null)
	//		{
	//			CameraEffectManager.sunShafts.enabled = true;
	//		}
	//		if (CameraEffectManager.tiltShift != null)
	//		{
	//			CameraEffectManager.tiltShift.enabled = false;
	//		}
	//		if (CameraEffectManager.vignetting != null)
	//		{
	//			CameraEffectManager.vignetting.enabled = true;
	//		}
	//		if (CameraEffectManager.bloomAndLensFlares != null)
	//		{
	//			CameraEffectManager.bloomAndLensFlares.enabled = false;
	//		}
	//		if (CameraEffectManager.colorCorrectionCurves != null)
	//		{
	//			CameraEffectManager.colorCorrectionCurves.enabled = true;
	//		}
	//		if (CameraEffectManager.depthOfFieldScatter != null)
	//		{
	//			CameraEffectManager.depthOfFieldScatter.enabled = false;
	//		}
	//		if (CameraEffectManager.ssaoEffect != null)
	//		{
	//			CameraEffectManager.ssaoEffect.enabled = false;
	//		}
	//		break;
	//	case 3:
	//		if (CameraEffectManager.sunShafts != null)
	//		{
	//			CameraEffectManager.sunShafts.enabled = true;
	//		}
	//		if (CameraEffectManager.tiltShift != null)
	//		{
	//			CameraEffectManager.tiltShift.enabled = true;
	//		}
	//		if (CameraEffectManager.vignetting != null)
	//		{
	//			CameraEffectManager.vignetting.enabled = true;
	//		}
	//		if (CameraEffectManager.bloomAndLensFlares != null)
	//		{
	//			CameraEffectManager.bloomAndLensFlares.enabled = true;
	//		}
	//		if (CameraEffectManager.colorCorrectionCurves != null)
	//		{
	//			CameraEffectManager.colorCorrectionCurves.enabled = true;
	//		}
	//		if (CameraEffectManager.depthOfFieldScatter != null)
	//		{
	//			CameraEffectManager.depthOfFieldScatter.enabled = false;
	//		}
	//		if (CameraEffectManager.ssaoEffect != null)
	//		{
	//			CameraEffectManager.ssaoEffect.enabled = false;
	//		}
	//		break;
	//	case 4:
	//		if (CameraEffectManager.sunShafts != null)
	//		{
	//			CameraEffectManager.sunShafts.enabled = true;
	//		}
	//		if (CameraEffectManager.tiltShift != null)
	//		{
	//			CameraEffectManager.tiltShift.enabled = true;
	//		}
	//		if (CameraEffectManager.vignetting != null)
	//		{
	//			CameraEffectManager.vignetting.enabled = true;
	//		}
	//		if (CameraEffectManager.bloomAndLensFlares != null)
	//		{
	//			CameraEffectManager.bloomAndLensFlares.enabled = true;
	//		}
	//		if (CameraEffectManager.colorCorrectionCurves != null)
	//		{
	//			CameraEffectManager.colorCorrectionCurves.enabled = true;
	//		}
	//		if (CameraEffectManager.depthOfFieldScatter != null)
	//		{
	//			CameraEffectManager.depthOfFieldScatter.enabled = true;
	//		}
	//		if (CameraEffectManager.ssaoEffect != null)
	//		{
	//			CameraEffectManager.ssaoEffect.enabled = false;
	//		}
	//		break;
	//	case 5:
	//		if (CameraEffectManager.sunShafts != null)
	//		{
	//			CameraEffectManager.sunShafts.enabled = true;
	//		}
	//		if (CameraEffectManager.tiltShift != null)
	//		{
	//			CameraEffectManager.tiltShift.enabled = true;
	//		}
	//		if (CameraEffectManager.vignetting != null)
	//		{
	//			CameraEffectManager.vignetting.enabled = true;
	//		}
	//		if (CameraEffectManager.bloomAndLensFlares != null)
	//		{
	//			CameraEffectManager.bloomAndLensFlares.enabled = true;
	//		}
	//		if (CameraEffectManager.colorCorrectionCurves != null)
	//		{
	//			CameraEffectManager.colorCorrectionCurves.enabled = true;
	//		}
	//		if (CameraEffectManager.depthOfFieldScatter != null)
	//		{
	//			CameraEffectManager.depthOfFieldScatter.enabled = true;
	//		}
	//		if (CameraEffectManager.ssaoEffect != null)
	//		{
	//			CameraEffectManager.ssaoEffect.enabled = true;
	//		}
	//		break;
	//	}
	//}
}
