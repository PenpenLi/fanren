using System;
using System.Collections.Generic;
using System.IO;
using NS_RoleBaseFun;
using UnityEngine;

/// <summary>
/// 资源加载
/// </summary>
public class ResourceLoader
{
    public const char SEPERATOR = '\t';

    public enum CacheType
    {
        CaGameObject,
        CaAudioClip,
        CaMaterial,
        CaAnimClip
    }

    public static UnityEngine.Object Load(string path, Type type)
    {
        UnityEngine.Object @object;

        @object = Resources.Load(path, type);     

        if (@object == null)
        {
            Debug.LogWarning("not find resource: " + path);
        }
        return @object;
    }

    //public static string GetResPath(string path, Type type)
    //{
    //	if (path.Contains("_frres"))
    //	{
    //		return EngineFun.RemoveExtensionName(path);
    //	}
    //	if (!path.Contains("Assets/") && !path.Contains("Assets/Resources/"))
    //	{
    //		path = "Assets/Resources/" + path;
    //	}
    //	if (type == typeof(GameObject))
    //	{
    //		string text = path;
    //		if (!text.Contains("_frres"))
    //		{
    //			text += ".prefab_frres";
    //		}
    //		return text;
    //	}
    //	if (type == typeof(MovieTexture))
    //	{
    //		string text2 = path;
    //		if (!text2.Contains("_frres"))
    //		{
    //			text2 += ".mp4_frres";
    //		}
    //		return text2;
    //	}
    //	if (type == typeof(Shader))
    //	{
    //		string text3 = path;
    //		if (!text3.Contains("_frres"))
    //		{
    //			text3 += ".shader_frres";
    //		}
    //		return text3;
    //	}
    //	if (type == typeof(Material))
    //	{
    //		string text4 = path;
    //		if (!text4.Contains("_frres"))
    //		{
    //			text4 += ".mat_frres";
    //		}
    //		return text4;
    //	}
    //	if (type == typeof(AudioClip))
    //	{
    //		int num = 0;
    //		if (num < ResourcePath.DOT_AUDIOCIP.Length)
    //		{
    //			string text5 = path;
    //			if (!text5.Contains("_frres"))
    //			{
    //				text5 = text5 + ResourcePath.DOT_AUDIOCIP[num] + "_frres";
    //			}
    //			return text5;
    //		}
    //	}
    //	if (type == typeof(Texture2D) || type == typeof(Texture))
    //	{
    //		int num2 = 0;
    //		if (num2 < ResourcePath.DOT_TEXTURE.Length)
    //		{
    //			string text6 = path;
    //			if (!text6.Contains("_frres"))
    //			{
    //				text6 = text6 + ResourcePath.DOT_TEXTURE[num2] + "_frres";
    //			}
    //			return text6;
    //		}
    //	}
    //	if (type == typeof(TextAsset))
    //	{
    //		string text7 = path;
    //		if (!text7.Contains("_frres"))
    //		{
    //			text7 += ".txt_frres";
    //		}
    //		return text7;
    //	}
    //	if (type == typeof(Font))
    //	{
    //		string text8 = path;
    //		if (!text8.Contains("_frres"))
    //		{
    //			text8 += ".ttf_frres";
    //		}
    //		return text8;
    //	}
    //	if (type == typeof(AnimationClip))
    //	{
    //		string text9 = path;
    //		if (!text9.Contains("_frres"))
    //		{
    //			text9 += ".anim_frres";
    //		}
    //		return text9;
    //	}
    //	return null;
    //}

    //// Token: 0x06001D79 RID: 7545 RVA: 0x000CDFFC File Offset: 0x000CC1FC
    //public static UnityEngine.Object[] LoadAll(string path)
    //{
    //	return Resources.LoadAll(path);
    //}

    //// Token: 0x06001D7A RID: 7546 RVA: 0x000CE004 File Offset: 0x000CC204
    //public static UnityEngine.Object LoadAssetAtPath(string assetPath, Type type)
    //{
    //	return Resources.LoadAssetAtPath(assetPath, type);
    //}

    //// Token: 0x06001D7B RID: 7547 RVA: 0x000CE010 File Offset: 0x000CC210
    //public static UnityEngine.Object[] FindObjectsOfTypeAll(Type type)
    //{
    //	return Resources.FindObjectsOfTypeAll(type);
    //}

    //// Token: 0x06001D7C RID: 7548 RVA: 0x000CE018 File Offset: 0x000CC218
    //public static void Destroy(UnityEngine.Object obj)
    //{
    //	UnityEngine.Object.Destroy(obj);
    //}

    //// Token: 0x06001D7D RID: 7549 RVA: 0x000CE020 File Offset: 0x000CC220
    //public static void DestroyObject(UnityEngine.Object obj)
    //{
    //	UnityEngine.Object.DestroyObject(obj);
    //}

    //// Token: 0x06001D7E RID: 7550 RVA: 0x000CE028 File Offset: 0x000CC228
    //public static void DestroyPrefab(GameObject go)
    //{
    //	if (go == null)
    //	{
    //		return;
    //	}
    //	MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>(true);
    //	foreach (MeshRenderer meshRenderer in componentsInChildren)
    //	{
    //		foreach (Material mat in meshRenderer.materials)
    //		{
    //			ResourceLoader.DestroyMaterial(mat);
    //		}
    //	}
    //	SkinnedMeshRenderer[] componentsInChildren2 = go.GetComponentsInChildren<SkinnedMeshRenderer>(true);
    //	foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
    //	{
    //		foreach (Material mat2 in skinnedMeshRenderer.materials)
    //		{
    //			ResourceLoader.DestroyMaterial(mat2);
    //		}
    //	}
    //}

    //// Token: 0x06001D7F RID: 7551 RVA: 0x000CE0F0 File Offset: 0x000CC2F0
    //public static void DestroyDeepPrefab(GameObject go)
    //{
    //	if (go == null)
    //	{
    //		return;
    //	}
    //	ResourceLoader.DestroyPrefab(go);
    //	for (int i = 0; i < go.transform.GetChildCount(); i++)
    //	{
    //		ResourceLoader.DestroyDeepPrefab(go);
    //	}
    //}

    //// Token: 0x06001D80 RID: 7552 RVA: 0x000CE134 File Offset: 0x000CC334
    //public static void DestroyMaterial(Material mat)
    //{
    //	ResourceLoader.DestroyObject(mat.mainTexture);
    //}

    //// Token: 0x06001D81 RID: 7553 RVA: 0x000CE144 File Offset: 0x000CC344
    //public static void UnloadAssets(UnityEngine.Object assetToUnload)
    //{
    //	if (assetToUnload == null)
    //	{
    //		return;
    //	}
    //	if (assetToUnload.GetType() == typeof(Material) || assetToUnload.GetType() == typeof(GameObject))
    //	{
    //		return;
    //	}
    //	Resources.UnloadAsset(assetToUnload);
    //}

    //// Token: 0x06001D82 RID: 7554 RVA: 0x000CE190 File Offset: 0x000CC390
    //public static void UnloadUnusedAssets()
    //{
    //	if (MovieManager.MovieMag != null)
    //	{
    //		if (!MovieManager.MovieMag.IsPlaying())
    //		{
    //			Debug.Log("UnloadUnusedAssets");
    //			Resources.UnloadUnusedAssets();
    //		}
    //		else
    //		{
    //			Main.Instance.DelayGC(10f);
    //		}
    //	}
    //}

    public static Dictionary<string, Type> ReadCacheConfig(string mapname)
    {
        return ResourceLoader.ReadCacheConfigFile(ResourceLoader.ConbineCacheConfig(mapname));
    }

    public static string ConbineCacheConfig(string map)
    {
        string path = "Assets/Resources/conf/CacheConfig";
        if (!Directory.Exists(path) && Application.isEditor)
        {
            Directory.CreateDirectory(path);
        }
        return "CacheConfig/" + map + "_Mono.txt";
    }

    public static Dictionary<string, Type> ReadCacheConfigFile(string filepath)
    {
        Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
        if (!filepath.Contains(".txt"))
        {
            return dictionary;
        }
        List<string> list = RoleBaseFun.LoadConfInAssets(filepath.Substring(0, filepath.Length - 4));
        if (list == null)
        {
            return dictionary;
        }
        if (list.Count == 0)
        {
            return dictionary;
        }
        foreach (string text in list)
        {
            string[] array = text.Split(new char[]
            {
                '\t'
            });
            if (array.Length >= 2)
            {
                if (!dictionary.ContainsKey(array[0]))
                {
                    Type type = ResourceLoader.StringToType(array[1]);
                    if (type != null)
                    {
                        dictionary.Add(array[0], type);
                    }
                }
            }
        }
        return dictionary;
    }

    //// Token: 0x06001D86 RID: 7558 RVA: 0x000CE328 File Offset: 0x000CC528
    //public static string TypeToString(Type type)
    //{
    //	if (type == typeof(GameObject))
    //	{
    //		return 0.ToString();
    //	}
    //	if (type == typeof(AudioClip))
    //	{
    //		return 1.ToString();
    //	}
    //	if (type == typeof(Material))
    //	{
    //		return 2.ToString();
    //	}
    //	if (type == typeof(AnimationClip))
    //	{
    //		return 3.ToString();
    //	}
    //	Debug.LogWarning(DU.Warning(new object[]
    //	{
    //		"未定义的缓存类型"
    //	}));
    //	return null;
    //}

    private static Type StringToType(string str)
    {
        if (string.Compare(str, 0.ToString(), true) == 0)
        {
            return typeof(GameObject);
        }
        if (string.Compare(str, 1.ToString(), true) == 0)
        {
            return typeof(AudioClip);
        }
        if (string.Compare(str, 2.ToString(), true) == 0)
        {
            return typeof(Material);
        }
        if (string.Compare(str, 3.ToString(), true) == 0)
        {
            return typeof(AnimationClip);
        }
        Debug.LogWarning(
            "未定义的缓存类型");
        return null;
    }
}
