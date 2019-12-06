using System;
using UnityEngine;

public class ResourcePath
{
    public const string MAP_ROOT_NAME = "Map";

    public const string ASSETS_FOLDER_NAME = "Assets";

    public const string BIND_EXPORT_FOLDER = "Bund_Assets";

    public const string ASSETS_RESOURCES = "Assets/Resources/";

    public const string ASSETS_MEISHU_ASSETS = "Assets/Meishu Assets/";

    public const string PREFAB = "prefab";

    public const string MATERIAL = "mat";

    public const string FRRES = "_frres";

    public const string NULL_STR = "NULL";

    public const string MAP_PREFAB = "MapPrefab";

    public const string TEMP_BUILD_STR = "-buildBndTmp.";

    public const string TEMP_OBJ_FOLDER = "BndTmpFolder/";

    public const string RES_INI_PATH = "Assets/Resources/conf/";

    public const string MAP_INI_PATH = "Assets/Resources/conf/map/";

    public const string MAP_SKY_BOX_MATERIAL_PAHT = "/Resources/SkyBox/";

    public const string DOT_ANIM = ".anim";

    public const string DOT_TEXT = ".txt";

    public const string DOT_FONT = ".ttf";

    public const string DOT_MATERIAL = ".mat";

    public const string DOT_PREFAB = ".prefab";

    public const string DOT_SHADER = ".shader";
    
    public const string DOT_MOVIETEXTURE = ".mp4";

    public const string MAP_RENDERSETTINGS_INI = "res/RenderSettings";

    public const string BASE_ART_RES_INFO_FILENAME = "res/normalInfo";

    public const string MATERIAL_INFO_FILENAME = "res/materialInfo";

    public const string PREFAB_IFNO_FILENAME = "res/prefabInfo";

    public static string[] FOLDER_FILTER = new string[]
    {
        "Shaders",
        "Plugins",
        "EZGUI",
        "GameLegend",
        "ItemAtlas",
        "Sprite Atlases",
        "HanLi.prefab"
    };

    public static string[] SUFFIX_ARRAY = new string[]
    {
        "mp3",
        "wav",
        "ogg",
        "prefab",
        "png",
        "shader",
        "mp4",
        "exr",
        "mat",
        "PNG",
        "tga",
        "TGA",
        "dds",
        "DDS",
        "tif",
        "psd",
        "bmp",
        "jpg",
        "txt",
        "anim"
    };

    public static string[] DOT_AUDIOCIP = new string[]
    {
        ".ogg",
        ".mp3",
        ".wav"
    };

    public static string[] DOT_TEXTURE = new string[]
    {
        ".exr",
        ".PNG",
        ".tga",
        ".TGA",
        ".dds",
        ".DDS",
        ".tif",
        ".psd",
        ".png",
        ".bmp",
        ".jpg"
    };

    public static string GUI_SKIN = "Skin/All";

    public static string BOTTOM_TEXTURE = "GUI/bottom";

    public static string SKILL_ONE = "GUI/skill2  normal";

    public static string SKILL_TWO = "GUI/skill4  normal";

    public static string SKILL_THREE = "GUI/skill7  normal";

    public static string TRAIL1 = "Materials/Trail/Trail1";

    public static string TRAIL2 = "Materials/Trail/Trail2";

    public static string TRAIL3 = "Materials/Trail/Trail3";

    public static string PLAYER_PREFABS = "Prefabs/Player/HanLi";

    public static string PLAYER_WEAPON1 = "Prefabs/Player/Weapon1";

    public static string PLAYER_WEAPON2 = "Prefabs/Player/Weapon2";

    public static string TELEPORT = "Prefabs/Effect/chuansong";

    public static string WATER_STAND = "Prefabs/particles/water_soldier_standing";

    public static string SHADOW_PROJECTOR = "Prefabs/particles/RoleShadowProjector";

    public static string STAGE_PREFABS = "Prefabs/Mob/Spawn/";

    public static string ASSETS_BUNDLE_PATH = "/Bund_Assets";

    public static bool IS_PUBLISH = true;

    public static string GetApplicationPath()
	{
		return Application.dataPath;
	}

	public static string GetEditorPath()
	{
		return Application.dataPath.Substring(0, Application.dataPath.Length - 6);
	}

	public static string GetPublishPath()
	{
		return Application.dataPath.Substring(0, Application.dataPath.Length - 13);
	}

	public static string GetEditorAssetsBundlePath()
	{
		return "E:\\Projects\\ExportClient\\Bund_Assets";
	}

	public static string GetPublishAssetsBundlePath()
	{
		return ResourcePath.GetApplicationPath() + ResourcePath.ASSETS_BUNDLE_PATH;
	}
}
