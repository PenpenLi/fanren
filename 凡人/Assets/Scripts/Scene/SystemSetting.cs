using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class SystemSetting : MonoBehaviour
{
    public const string SOUND_MUTE = "sound mute";

    public const string GAME_SOUND_MUTE = "GameSoundMute";

    public const string BG_SOUND_MUTE = "BgSoundMute";

    public const string DUB_SOUND_MUTE = "VoiceMute";

    public const string GAME_SOUND_VALUE = "GameSoundValue";

    public const string BG_SOUND_VALUE = "BgSoundValue";

    public const string DUB_SOUND_VALUE = "VoiceValue";

    public const string QUALITY = "Quality";

    public const string RESOLUTION_INDEX = "ResolutionIndex";

    public const string FULL_SCREEN = "FullScreen";

    public const string SUN_SHAFTS = "sunShafts";

    public const string TILT_SHIFT = "tilt shift";

    public const string VIGNETTING = "vignetting";

    public const string SSAO_EFFECT = "SSAOEffect";

    public const string BLOOM_AND_LENS_FLARES = "bloom and lens flares";

    public const string COLOR_CORRECTION_CURVES = "color correction curves";

    public const string ANTIALIASING_AS_POST_EFFECT = "antialiasing as post effect";

    public const string REFRESH_RATE = "preferredRefreshRate";

    public const string ANTI_ALIASING = "AntiAliasing";

    public const string V_SYNC_COUNT = "VSyncCount";

    public const string TEXTURE_LIMIT = "MasterTextureLimit";

    public const string ANISOTROPIC_FILTERING = "anisotropicFiltering";

    public const string SHADOW_PROJECTION = "shadowProjection";

    public const string SHADOW_CASCADES = "ShadowCascades";

    public const string WATER_LEVEL = "WaterLevel";

    public const string LIGHT_LEVEL = "lightLevel";

    public const string PARTICLE_RAYCAST_BUDGET = "particleRaycastBudget";

    public const string VIEW_DISTANCE = "SightRange";

    public const string TERRAIN_LEVEL = "TerrainLevel";

    public const string CONFIG_FOLDER = "/Config/";

    public const string FILE_NAME = "SystemSetting.data";

    public static bool soundMute = false;

    public static bool bgSoundMute = false;

    public static bool gameSoundMute = false;

    public static bool dubSoundMute = false;

    public static float gameSoundValue = 1f;

    public static float bgSoundValue = 0.5f;

    public static float dubSoundValue = 1f;

    public static int quality = 3;

    public static string resolutionIndex = Screen.currentResolution.width + "x" + Screen.currentResolution.height;

    public static int fullScreen = 1;

    public static int view = 2;

    public static int terrainLevel = 0;

    public static int liquid = 0;

    public static int particle = 0;

    public static int shadowCascade = 0;

    public static int masterTexture = 0;

    public static int VSyncCount = 0;

    public static int antiAliasing = 0;

    public static int sunShafts = 0;

    public static int tiltShift = 0;

    public static int vignetting = 0;

    public static int ssaoEffect = 0;

    public static int bloomAndLensFlares = 0;

    public static int colorCorrectionCurves = 0;

    public static int antialiasingAsPostEffect = 0;

    private static Dictionary<string, object> settingDic = new Dictionary<string, object>();

    private static Dictionary<string, object> SystemSettingDic = new Dictionary<string, object>();

    private static int[] TextureQuality = new int[5];

    public static int[] ViewDistance = new int[]
    {
        50,
        100,
        150,
        250,
        500
    };

    private static float[] DetailObjectDensity = new float[]
    {
        0.6f,
        0.8f,
        1f,
        1f,
        1f
    };

    private static int[] DetailObjectDistance = new int[]
    {
        170,
        140,
        110,
        80,
        50
    };

    public static void initialize()
	{
		if (SystemSetting.SystemSettingDic.Count != 0)
		{
			return;
		}
		SystemSetting.CheckSystemSupports();
		SystemSetting.CacheOriginData();
		SystemSetting.ReadSystemSetting();
		SystemSetting.GetAllSetting();
	}

	private static void ReadSystemSetting()
	{
		string[] separator = new string[]
		{
			"="
		};
		string text = "/Config/";
		string text2 = text + "SystemSetting.data";
		if (Application.isEditor)
		{
			text = Application.dataPath + text;
			text2 = Application.dataPath + text2;
		}
		else
		{
			text = ResourcePath.GetPublishPath() + text;
			text2 = ResourcePath.GetPublishPath() + text2;
		}
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		if (!File.Exists(text2))
		{
            UnityEngine.Debug.Log(
				"not find file:" + text2
			);
			SystemSetting.CreateConfigData();
			return;
		}
		FileStream fileStream = new FileStream(text2, FileMode.Open, FileAccess.Read);
		StreamReader streamReader = new StreamReader(fileStream);
		SystemSetting.SystemSettingDic.Clear();
		for (;;)
		{
			string text3 = streamReader.ReadLine();
			if (text3 == null || text3.Length == 0)
			{
				break;
			}
			string[] array = text3.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length >= 2 && !text3.Contains("#"))
			{
				if (!SystemSetting.SystemSettingDic.ContainsKey(array[0]))
				{
					SystemSetting.SystemSettingDic.Add(array[0], array[1]);
				}
			}
		}
		streamReader.Close();
		fileStream.Close();
	}

	public static void CreateConfigData()
	{
		SystemSetting.SystemSettingDic.Clear();
		SystemSetting.SystemSettingDic.Add("Quality", SystemSetting.quality);
		SystemSetting.SystemSettingDic.Add("FullScreen", SystemSetting.fullScreen);
		SystemSetting.SystemSettingDic.Add("ResolutionIndex", SystemSetting.resolutionIndex);
		SystemSetting.SystemSettingDic.Add("SSAOEffect", SystemSetting.ssaoEffect);
		SystemSetting.SystemSettingDic.Add("AntiAliasing", SystemSetting.antiAliasing);
		SystemSetting.SystemSettingDic.Add("VSyncCount", SystemSetting.VSyncCount);
		SystemSetting.SystemSettingDic.Add("MasterTextureLimit", SystemSetting.masterTexture);
		SystemSetting.SystemSettingDic.Add("ShadowCascades", SystemSetting.shadowCascade);
		SystemSetting.SystemSettingDic.Add("WaterLevel", SystemSetting.liquid);
		SystemSetting.SystemSettingDic.Add("SightRange", SystemSetting.view);
		SystemSetting.SystemSettingDic.Add("TerrainLevel", SystemSetting.terrainLevel);
		SystemSetting.SystemSettingDic.Add("BgSoundMute", (!SystemSetting.bgSoundMute) ? 0 : 1);
		SystemSetting.SystemSettingDic.Add("GameSoundMute", (!SystemSetting.gameSoundMute) ? 0 : 1);
		SystemSetting.SystemSettingDic.Add("VoiceMute", (!SystemSetting.dubSoundMute) ? 0 : 1);
		SystemSetting.SystemSettingDic.Add("GameSoundValue", SystemSetting.gameSoundValue);
		SystemSetting.SystemSettingDic.Add("BgSoundValue", SystemSetting.bgSoundValue);
		SystemSetting.SystemSettingDic.Add("VoiceValue", SystemSetting.dubSoundValue);
	}

	public static void SaveSystemSetting()
	{
		try
		{
			if (SystemSetting.SystemSettingDic.Count != 0)
			{
				string text = "/Config/SystemSetting.data";
				if (Application.isEditor)
				{
					text = Application.dataPath + text;
				}
				else
				{
					text = ResourcePath.GetPublishPath() + text;
				}
				FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.ReadWrite);
				StreamWriter streamWriter = new StreamWriter(fileStream);
				foreach (KeyValuePair<string, object> keyValuePair in SystemSetting.SystemSettingDic)
				{
					string value = keyValuePair.Key + "=" + keyValuePair.Value;
					streamWriter.WriteLine(value);
				}
				streamWriter.Close();
				fileStream.Close();
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
			UnityEngine.Debug.LogError("save setting error!");
		}
	}

	private static void CacheOriginData()
	{
		if (SystemSetting.settingDic.Count != 0)
		{
			return;
		}
		SystemSetting.settingDic.Add("sound mute", SystemSetting.soundMute);
		SystemSetting.settingDic.Add("BgSoundMute", SystemSetting.bgSoundMute);
		SystemSetting.settingDic.Add("GameSoundMute", SystemSetting.gameSoundMute);
		SystemSetting.settingDic.Add("VoiceMute", SystemSetting.dubSoundMute);
		SystemSetting.settingDic.Add("GameSoundValue", SystemSetting.gameSoundValue);
		SystemSetting.settingDic.Add("BgSoundValue", SystemSetting.bgSoundValue);
		SystemSetting.settingDic.Add("VoiceValue", SystemSetting.dubSoundValue);
		SystemSetting.settingDic.Add("Quality", SystemSetting.quality);
		SystemSetting.settingDic.Add("FullScreen", SystemSetting.fullScreen);
		SystemSetting.settingDic.Add("ResolutionIndex", SystemSetting.resolutionIndex);
		SystemSetting.settingDic.Add("SSAOEffect", SystemSetting.ssaoEffect);
		SystemSetting.settingDic.Add("AntiAliasing", SystemSetting.antiAliasing);
		SystemSetting.settingDic.Add("VSyncCount", SystemSetting.VSyncCount);
		SystemSetting.settingDic.Add("MasterTextureLimit", SystemSetting.masterTexture);
		SystemSetting.settingDic.Add("ShadowCascades", SystemSetting.shadowCascade);
		SystemSetting.settingDic.Add("WaterLevel", SystemSetting.liquid);
		SystemSetting.settingDic.Add("particleRaycastBudget", SystemSetting.particle);
		SystemSetting.settingDic.Add("SightRange", SystemSetting.view);
		SystemSetting.settingDic.Add("TerrainLevel", SystemSetting.terrainLevel);
	}

	private static void GetAllSetting()
	{
		foreach (KeyValuePair<string, object> keyValuePair in SystemSetting.SystemSettingDic)
		{
			SystemSetting.GetSetting(keyValuePair.Key);
		}
	}

	private static void GetSetting(string key)
	{
		switch (key)
		{
		case "sound mute":
			if (SystemSetting.SystemSettingDic.ContainsKey("sound mute"))
			{
				SystemSetting.soundMute = (Convert.ToInt32(SystemSetting.SystemSettingDic["sound mute"]) == 1);
			}
			break;
		case "BgSoundMute":
			if (SystemSetting.SystemSettingDic.ContainsKey("BgSoundMute"))
			{
				SystemSetting.bgSoundMute = (Convert.ToInt32(SystemSetting.SystemSettingDic["BgSoundMute"]) == 1);
			}
			if (SystemSetting.bgSoundMute)
			{
				//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.bgSound, 0f);
			}
			else
			{
				//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.bgSound, SystemSetting.bgSoundValue);
			}
			break;
		case "GameSoundMute":
			if (SystemSetting.SystemSettingDic.ContainsKey("GameSoundMute"))
			{
				SystemSetting.gameSoundMute = (Convert.ToInt32(SystemSetting.SystemSettingDic["GameSoundMute"]) == 1);
			}
			if (SystemSetting.gameSoundMute)
			{
				//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.gameSound, 0f);
			}
			else
			{
				//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.gameSound, SystemSetting.gameSoundValue);
			}
			break;
		case "VoiceMute":
			if (SystemSetting.SystemSettingDic.ContainsKey("VoiceMute"))
			{
				SystemSetting.dubSoundMute = (Convert.ToInt32(SystemSetting.SystemSettingDic["VoiceMute"]) == 1);
			}
			if (SystemSetting.dubSoundMute)
			{
				//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.dubSound, 0f);
			}
			else
			{
				//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.dubSound, SystemSetting.dubSoundValue);
			}
			break;
		case "GameSoundValue":
			if (SystemSetting.SystemSettingDic.ContainsKey("GameSoundValue"))
			{
				SystemSetting.gameSoundValue = Convert.ToSingle(SystemSetting.SystemSettingDic["GameSoundValue"]);
			}
			//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.gameSound, SystemSetting.gameSoundValue);
			break;
		case "BgSoundValue":
			if (SystemSetting.SystemSettingDic.ContainsKey("BgSoundValue"))
			{
				SystemSetting.bgSoundValue = Convert.ToSingle(SystemSetting.SystemSettingDic["BgSoundValue"]);
			}
			//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.bgSound, SystemSetting.bgSoundValue);
			break;
		case "VoiceValue":
			if (SystemSetting.SystemSettingDic.ContainsKey("VoiceValue"))
			{
				SystemSetting.dubSoundValue = Convert.ToSingle(SystemSetting.SystemSettingDic["VoiceValue"]);
			}
			//SingletonMono<AudioManager>.GetInstance().SetAudioVolume(SoundType.dubSound, SystemSetting.dubSoundValue);
			break;
		case "Quality":
			if (SystemSetting.SystemSettingDic.ContainsKey("Quality"))
			{
				SystemSetting.quality = Convert.ToInt32(SystemSetting.SystemSettingDic["Quality"]);
			}
			SystemSetting.QualitySetting();
			break;
		case "FullScreen":
			if (SystemSetting.SystemSettingDic.ContainsKey("FullScreen"))
			{
				SystemSetting.fullScreen = Convert.ToInt32(SystemSetting.SystemSettingDic["FullScreen"]);
			}
			Screen.fullScreen = (SystemSetting.fullScreen == 1);
			break;
		case "ResolutionIndex":
		{
			if (Application.isEditor)
			{
				return;
			}
			bool flag = SystemSetting.fullScreen == 1;
			if (SystemSetting.SystemSettingDic.ContainsKey("ResolutionIndex"))
			{
				string text = Convert.ToString(SystemSetting.SystemSettingDic["ResolutionIndex"]);
				if (!text.Contains("x"))
				{
					text = SystemSetting.resolutionIndex;
				}
				SystemSetting.resolutionIndex = text;
				Resolution[] resolutions = Screen.resolutions;
				foreach (Resolution resolution in resolutions)
				{
					if (SystemSetting.resolutionIndex == resolution.width + "x" + resolution.height)
					{
						SystemSetting.SetResolution(resolution.width, resolution.height, flag);
					}
				}
			}
			break;
		}
		case "AntiAliasing":
			if (SystemSetting.SystemSettingDic.ContainsKey("AntiAliasing"))
			{
				SystemSetting.antiAliasing = Convert.ToInt32(SystemSetting.SystemSettingDic["AntiAliasing"]);
			}
			SystemSetting.SetAntiAliasing();
			break;
		case "VSyncCount":
			if (SystemSetting.SystemSettingDic.ContainsKey("VSyncCount"))
			{
				SystemSetting.VSyncCount = Convert.ToInt32(SystemSetting.SystemSettingDic["VSyncCount"]);
			}
			QualitySettings.vSyncCount = SystemSetting.VSyncCount;
			break;
		case "MasterTextureLimit":
			if (SystemSetting.SystemSettingDic.ContainsKey("MasterTextureLimit"))
			{
				SystemSetting.masterTexture = Convert.ToInt32(SystemSetting.SystemSettingDic["MasterTextureLimit"]);
			}
			SystemSetting.SetTextureQuality();
			break;
		case "ShadowCascades":
			if (SystemSetting.SystemSettingDic.ContainsKey("ShadowCascades"))
			{
				SystemSetting.shadowCascade = Convert.ToInt32(SystemSetting.SystemSettingDic["ShadowCascades"]);
			}
			QualitySettings.shadowCascades = SystemSetting.shadowCascade;
			break;
		case "SightRange":
			if (SystemSetting.SystemSettingDic.ContainsKey("SightRange"))
			{
				SystemSetting.view = Convert.ToInt32(SystemSetting.SystemSettingDic["SightRange"]);
			}
			SystemSetting.SetViewDistance();
			break;
		case "particleRaycastBudget":
			if (SystemSetting.SystemSettingDic.ContainsKey("particleRaycastBudget"))
			{
				SystemSetting.particle = Convert.ToInt32(SystemSetting.SystemSettingDic["particleRaycastBudget"]);
			}
			QualitySettings.particleRaycastBudget = SystemSetting.particle;
			break;
		case "TerrainLevel":
			if (SystemSetting.SystemSettingDic.ContainsKey("TerrainLevel"))
			{
				SystemSetting.terrainLevel = Convert.ToInt32(SystemSetting.SystemSettingDic["TerrainLevel"]);
			}
			SystemSetting.SetTerrainLevel();
			break;
		case "WaterLevel":
			if (SystemSetting.SystemSettingDic.ContainsKey("WaterLevel"))
			{
				SystemSetting.liquid = Convert.ToInt32(SystemSetting.SystemSettingDic["WaterLevel"]);
			}
			SystemSetting.SetWaterLevel();
			break;
		case "SSAOEffect":
			if (SystemSetting.SystemSettingDic.ContainsKey("SSAOEffect"))
			{
				SystemSetting.ssaoEffect = Convert.ToInt32(SystemSetting.SystemSettingDic["SSAOEffect"]);
			}
			SystemSetting.SetSSAO();
			break;
		}
	}


	public static void SceneSetting()
	{
		SystemSetting.SetViewDistance();
		SystemSetting.SetTerrainLevel();
		SystemSetting.SetWaterLevel();
		SystemSetting.SetSSAO();
	}

	public static void SetCameraEffect(string key, int value)
	{
	}

	private static int GetIndexByResolution(Resolution currentResolution)
	{
		Resolution[] resolutions = Screen.resolutions;
		int num = resolutions.Length;
		for (int i = 0; i < num; i++)
		{
			Resolution resolution = resolutions[i];
			if (resolution.width == currentResolution.width && resolution.height == currentResolution.height)
			{
				return i;
			}
		}
		return 0;
	}

	private static Resolution GetResolutionByIndex(int index)
	{
		Resolution[] resolutions = Screen.resolutions;
		if (resolutions.Length < index)
		{
            UnityEngine.Debug.Log(
				"没有对应的分辨率！索引：" + index
			);
			return resolutions[0];
		}
		return resolutions[index];
	}

	private static bool Setting(string key, object value)
	{
		if (!SystemSetting.SystemSettingDic.ContainsKey(key))
		{
			return false;
		}
		if (key == "ResolutionIndex" && Application.isEditor)
		{
			return false;
		}
		SystemSetting.SystemSettingDic[key] = value;
		SystemSetting.GetSetting(key);
		return true;
	}

	public static void ReSetAll()
	{
		SystemSetting.ReSetAll(0);
		SystemSetting.ReSetAll(1);
	}

	public static void ReSetAll(int index)
	{
		if (index == 1)
		{
			SystemSetting.Setting("sound mute", (!(bool)SystemSetting.settingDic["sound mute"]) ? 0 : 1);
			SystemSetting.Setting("BgSoundMute", (!(bool)SystemSetting.settingDic["BgSoundMute"]) ? 0 : 1);
			SystemSetting.Setting("GameSoundMute", (!(bool)SystemSetting.settingDic["GameSoundMute"]) ? 0 : 1);
			SystemSetting.Setting("VoiceMute", (!(bool)SystemSetting.settingDic["VoiceMute"]) ? 0 : 1);
			SystemSetting.Setting("GameSoundValue", (float)SystemSetting.settingDic["GameSoundValue"]);
			SystemSetting.Setting("BgSoundValue", (float)SystemSetting.settingDic["BgSoundValue"]);
			SystemSetting.Setting("VoiceValue", (float)SystemSetting.settingDic["VoiceValue"]);
		}
		else if (index == 0)
		{
			SystemSetting.Setting("Quality", (int)SystemSetting.settingDic["Quality"]);
			SystemSetting.Setting("FullScreen", (int)SystemSetting.settingDic["FullScreen"]);
			SystemSetting.Setting("ResolutionIndex", SystemSetting.settingDic["ResolutionIndex"]);
			SystemSetting.Setting("SSAOEffect", (int)SystemSetting.settingDic["SSAOEffect"]);
			SystemSetting.Setting("AntiAliasing", (int)SystemSetting.settingDic["AntiAliasing"]);
			SystemSetting.Setting("VSyncCount", (int)SystemSetting.settingDic["VSyncCount"]);
			SystemSetting.Setting("MasterTextureLimit", (int)SystemSetting.settingDic["MasterTextureLimit"]);
			SystemSetting.Setting("ShadowCascades", (int)SystemSetting.settingDic["ShadowCascades"]);
			SystemSetting.Setting("WaterLevel", (int)SystemSetting.settingDic["WaterLevel"]);
			SystemSetting.Setting("particleRaycastBudget", (int)SystemSetting.settingDic["particleRaycastBudget"]);
			SystemSetting.Setting("SightRange", (int)SystemSetting.settingDic["SightRange"]);
			SystemSetting.Setting("TerrainLevel", (int)SystemSetting.settingDic["TerrainLevel"]);
		}
	}

	public static void SetSoundMute(bool mute)
	{
		SystemSetting.Setting("sound mute", (!mute) ? 0 : 1);
	}

	public static void SetGameSoundMute(bool mute)
	{
		SystemSetting.Setting("GameSoundMute", (!mute) ? 0 : 1);
	}

	public static void SetBgSoundMute(bool mute)
	{
		SystemSetting.Setting("BgSoundMute", (!mute) ? 0 : 1);
	}

	public static void SetDubSoundMute(bool mute)
	{
		SystemSetting.Setting("VoiceMute", (!mute) ? 0 : 1);
	}

	public static void SetGameSoundValue(float value)
	{
		SystemSetting.Setting("GameSoundValue", value);
	}

	public static void SetBgSoundValue(float value)
	{
		SystemSetting.Setting("BgSoundValue", value);
	}

	public static void SetDubSoundValue(float value)
	{
		SystemSetting.Setting("VoiceValue", value);
	}

	public static void SetFullScreen(int isFullScreen)
	{
		SystemSetting.Setting("FullScreen", isFullScreen);
	}

	public static void QualitySetting(int index)
	{
		SystemSetting.Setting("Quality", index);
	}

	private static void QualitySetting()
	{
		string[] names = QualitySettings.names;
		int num = 0;
		if (names != null)
		{
			num = names.Length - 1;
		}
		if (SystemSetting.quality < 0)
		{
			SystemSetting.quality = 0;
		}
		if (SystemSetting.quality > num)
		{
			SystemSetting.quality = num;
		}
		try
		{
			QualitySettings.SetQualityLevel(SystemSetting.quality);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
		SystemSetting.SetLevelByQuality(SystemSetting.quality);
	}

	public static void SetResolution(string index)
	{
		SystemSetting.Setting("ResolutionIndex", index);
	}

	public static void SetResolution(int width, int height, bool fullScreen)
	{
		Screen.SetResolution(width, height, fullScreen);
		//Singleton<HpCautionEffect>.GetInstance().AdjustSize();
	}

	public static void SetResolution(int width, int height, bool fullScreen, int preferredRefreshRate)
	{
	}

	public static int GetFrameRate()
	{
		return Screen.currentResolution.refreshRate;
	}

	public static void SetAntiAliasing(int level)
	{
		SystemSetting.Setting("AntiAliasing", level);
	}

	public static void SetVSyncCount(int count)
	{
		SystemSetting.Setting("VSyncCount", count);
	}

	public static void SetAntiAliasing()
	{
		QualitySettings.antiAliasing = SystemSetting.antiAliasing;
		bool flag = QualitySettings.antiAliasing != 0;
		//CameraEffectManager.SetAntialiasingAsPostEffect(flag);
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x000266D8 File Offset: 0x000248D8
	public static void SetTextureQuality(int level)
	{
		SystemSetting.Setting("MasterTextureLimit", level);
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x000266EC File Offset: 0x000248EC
	private static void SetTextureQuality()
	{
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x000266F0 File Offset: 0x000248F0
	public static void SetAnisotropicTextures(int level)
	{
		SystemSetting.Setting("anisotropicFiltering", level);
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x00026704 File Offset: 0x00024904
	public static void SetShadowProjection(int level)
	{
		SystemSetting.Setting("shadowProjection", level);
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x00026718 File Offset: 0x00024918
	public static void SetShadowResolution(int level)
	{
		SystemSetting.Setting("ShadowCascades", level);
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x0002672C File Offset: 0x0002492C
	public static void SetWaterLevel(int level)
	{
		SystemSetting.Setting("WaterLevel", level);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x00026740 File Offset: 0x00024940
	private static void SetWaterLevel()
	{
		if (SystemSetting.liquid == SystemSetting.quality)
		{
			return;
		}
		float num = 0.1f;
		if (SystemSetting.liquid > SystemSetting.quality)
		{
			num = 0.1f;
		}
		else if (SystemSetting.liquid < SystemSetting.quality)
		{
			num = -0.1f;
		}
		//UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(Water));
		//foreach (Water water in array)
		//{
		//	water.m_ClipPlaneOffset += num;
		//}
		//UnityEngine.Object[] array3 = UnityEngine.Object.FindObjectsOfType(typeof(WaterBase));
		//foreach (WaterBase waterBase in array3)
		//{
		//	if (SystemSetting.liquid > 4)
		//	{
		//		waterBase.waterQuality = WaterQuality.High;
		//	}
		//	else if (SystemSetting.liquid > 2 && SystemSetting.liquid < 5)
		//	{
		//		waterBase.waterQuality = WaterQuality.Medium;
		//	}
		//	else if (SystemSetting.liquid < 3)
		//	{
		//		waterBase.waterQuality = WaterQuality.Medium;
		//	}
		//}
	}

	public static void SetParticles(int level)
	{
		SystemSetting.Setting("particleRaycastBudget", level);
	}

	public static void SetSSAO(int level)
	{
		SystemSetting.Setting("SSAOEffect", level);
	}

	private static void SetSSAO()
	{
		//if (CameraEffectManager.ssaoEffect == null)
		//{
		//	return;
		//}
		//if (SystemSetting.ssaoEffect == 0)
		//{
		//	CameraEffectManager.ssaoEffect.enabled = false;
		//}
		//else if (SystemSetting.ssaoEffect == 1 || SystemSetting.ssaoEffect == 2)
		//{
		//	CameraEffectManager.ssaoEffect.enabled = true;
		//	CameraEffectManager.ssaoEffect.m_SampleCount = (SSAOEffect.SSAOSamples)SystemSetting.ssaoEffect;
		//}
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000268EC File Offset: 0x00024AEC
	public static void SetViewDistance(int level)
	{
		SystemSetting.Setting("SightRange", level);
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x00026900 File Offset: 0x00024B00
	private static void SetViewDistance()
	{
		if (Camera.main)
		{
			Camera.main.far = (float)SystemSetting.ViewDistance[SystemSetting.view];
		}
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x00026928 File Offset: 0x00024B28
	public static void SetTerrainLevel(int level)
	{
		SystemSetting.Setting("TerrainLevel", level);
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x0002693C File Offset: 0x00024B3C
	private static void SetTerrainLevel()
	{
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(Terrain));
		foreach (Terrain terrain in array)
		{
			terrain.detailObjectDensity = SystemSetting.DetailObjectDensity[SystemSetting.terrainLevel];
			terrain.detailObjectDistance = (float)SystemSetting.DetailObjectDistance[SystemSetting.terrainLevel];
		}
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x0002699C File Offset: 0x00024B9C
	private static int GetMemoryUsed()
	{
		int result = 0;
		Process currentProcess = Process.GetCurrentProcess();
		if (currentProcess.ProcessName.Contains("Unity") || currentProcess.ProcessName.Contains("Immortal"))
		{
			result = currentProcess.MaxWorkingSet.ToInt32() / 1024;
		}
		return result;
	}

	public static string ShowMemoryUsed()
	{
		return string.Empty;
	}

	public static void CheckSystemSupports()
	{
		int systemLevel = SystemSetting.GetSystemLevel();
		SystemSetting.quality = systemLevel;
		SystemSetting.SetLevelByQuality(systemLevel);
	}

	private static void SetLevelByQuality(int level)
	{
		if (level < 2)
		{
			SystemSetting.ssaoEffect = 0;
		}
		if (level > 1 && level < 4)
		{
			SystemSetting.ssaoEffect = 1;
		}
		if (level == 4)
		{
			SystemSetting.ssaoEffect = 2;
		}
		//CameraEffectManager.SetCameraEffect(level);
	}

	private static int GetSystemLevel()
	{
		int result = 0;
		int num = 1;
		int num2 = 1;
		int num3 = 1;
		if (SystemInfo.graphicsMemorySize < 512)
		{
			num = 1;
		}
		else if (SystemInfo.graphicsMemorySize >= 512 && SystemInfo.graphicsMemorySize < 2048)
		{
			num = 2;
		}
		else if (SystemInfo.graphicsMemorySize >= 2048 && SystemInfo.graphicsMemorySize < 4096)
		{
			num = 3;
		}
		else if (SystemInfo.graphicsMemorySize >= 4096 && SystemInfo.graphicsMemorySize < 8192)
		{
			num = 4;
		}
		else if (SystemInfo.graphicsMemorySize >= 8192)
		{
			num = 5;
		}
		if (SystemInfo.systemMemorySize < 512)
		{
			num2 = 1;
		}
		else if (SystemInfo.systemMemorySize >= 512 && SystemInfo.systemMemorySize < 2048)
		{
			num2 = 2;
		}
		else if (SystemInfo.systemMemorySize >= 2048 && SystemInfo.systemMemorySize < 4096)
		{
			num2 = 3;
		}
		else if (SystemInfo.systemMemorySize >= 4096 && SystemInfo.systemMemorySize < 8192)
		{
			num2 = 4;
		}
		else if (SystemInfo.systemMemorySize >= 8192)
		{
			num2 = 5;
		}
		if (SystemInfo.supportsImageEffects)
		{
			num3++;
		}
		if (SystemInfo.supportsRenderTextures)
		{
			num3++;
		}
		if (SystemInfo.supportsShadows)
		{
			num3++;
		}
		if (SystemInfo.supportsVertexPrograms)
		{
			num3++;
		}
		if (num == 1 || num2 == 1 || SystemInfo.processorCount < 2 || SystemInfo.graphicsShaderLevel < 10)
		{
			result = 0;
		}
		else if (num == 2 && num2 >= 2 && SystemInfo.processorCount >= 2 && SystemInfo.graphicsShaderLevel > 20)
		{
			result = 1;
		}
		else if (num == 3 && num2 >= 3 && SystemInfo.processorCount >= 3 && SystemInfo.graphicsShaderLevel > 30)
		{
			result = 2;
		}
		else if (num == 4 && num2 >= 3 && SystemInfo.processorCount >= 3 && SystemInfo.graphicsShaderLevel > 30)
		{
			result = 3;
		}
		else if (num == 5 && num2 >= 3 && SystemInfo.processorCount >= 3 && SystemInfo.graphicsShaderLevel > 30)
		{
			result = 4;
		}
		return result;
	}
}
