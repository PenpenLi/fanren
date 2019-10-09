using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadMachine : MonoBehaviour
{
    public static List<LoadedResourceInfo> ResList = new List<LoadedResourceInfo>();

    public static List<LoadingRes> LoadingList = new List<LoadingRes>();

    public static List<UnityEngine.Object> ObjectList = new List<UnityEngine.Object>();

    //public static Dictionary<string, AssetBundle> AssetBundleList = new Dictionary<string, AssetBundle>();

    //public static Dictionary<string, AssetBundle> UIAssetBundleList = new Dictionary<string, AssetBundle>();

    //public static List<LoadingRes> RemoveList = new List<LoadingRes>();

    public static bool bLoading = false;

    public static bool isLoadCompleted = false;

    private void Update()
	{
        if (!LoadMachine.bLoading)
        {
            bool flag = false;
            foreach (LoadingRes loadingRes in LoadMachine.LoadingList)
            {
                if (!(LoadMachine.GetLoadedObj(loadingRes.resID) != null))
                {
                    base.StartCoroutine(this.Load(loadingRes));
                    break;
                }
                flag = true;
            }
            if (flag)
            {
                LoadMachine.ProcessCallBack();
            }
        }
    }

    //public static void RemoveObj(RES_TYPE rt)
    //{
    //	for (int i = LoadMachine.ResList.Count - 1; i >= 0; i--)
    //	{
    //		LoadedResourceInfo loadedResourceInfo = LoadMachine.ResList[i];
    //		if (loadedResourceInfo == null)
    //		{
    //			LoadMachine.ResList.RemoveAt(i);
    //		}
    //		else if (!LoadMachine.IsFilterFolder(loadedResourceInfo))
    //		{
    //			if (!LoadMachine.IsFilterAnim(loadedResourceInfo))
    //			{
    //				if (loadedResourceInfo.rt == rt && loadedResourceInfo.Obj != null)
    //				{
    //					loadedResourceInfo.Clear();
    //					LoadMachine.ResList.Remove(loadedResourceInfo);
    //				}
    //			}
    //		}
    //	}
    //}

    //public static void ClearLoadedObj()
    //{
    //	TimeOutManager.ClearAllTiemOut();
    //	Time.timeScale = 0f;
    //	for (int i = 0; i < LoadMachine.LoadingList.Count; i++)
    //	{
    //		LoadMachine.LoadingList[i] = null;
    //	}
    //	LoadMachine.LoadingList.Clear();
    //	if (MovieManager.MovieMag != null)
    //	{
    //		MovieManager.MovieMag.StopAllMovie();
    //	}
    //	SingletonMono<EffectManager>.GetInstance().ClearObject();
    //	SingletonMono<AudioManager>.GetInstance().ClearObject();
    //	LoadMachine.ClearInstantiateObject();
    //	if (SceneManager.RoleMan != null)
    //	{
    //		SceneManager.RoleMan.DestroyAllRole();
    //	}
    //	LoadMachine.RemoveObj(RES_TYPE.AUDIO);
    //	LoadMachine.RemoveObj(RES_TYPE.VIDEO);
    //	LoadMachine.RemoveObj(RES_TYPE.TEXTURE);
    //	LoadMachine.RemoveObj(RES_TYPE.FONT);
    //	LoadMachine.RemoveObj(RES_TYPE.TEXT);
    //	LoadMachine.RemoveObj(RES_TYPE.ANIM);
    //	LoadMachine.RemoveObj(RES_TYPE.SHADER);
    //	LoadMachine.RemoveObj(RES_TYPE.MATERIAL);
    //	LoadMachine.RemoveObj(RES_TYPE.OBJECT);
    //	LoadMachine.RemoveObj(RES_TYPE.GAMEOBJECT);
    //	LoadMachine.ClearAssetsBundle();
    //	Main.Instance.CancelGC();
    //	Main.Instance.GC();
    //	Time.timeScale = 1f;
    //}

    //public static bool IsFilterFolder(LoadedResourceInfo lri)
    //{
    //	bool result = false;
    //	BaseArtResInfo baseArtResInfoById = GameData.Instance.ArtResConf.GetBaseArtResInfoById(lri.ResId);
    //	string path = baseArtResInfoById.Path;
    //	foreach (string value in ResourcePath.FOLDER_FILTER)
    //	{
    //		if (path.Contains(value))
    //		{
    //			result = true;
    //			break;
    //		}
    //	}
    //	return result;
    //}

    //public static bool IsFilterAnim(LoadedResourceInfo lri)
    //{
    //	bool result = false;
    //	BaseArtResInfo baseArtResInfoById = GameData.Instance.ArtResConf.GetBaseArtResInfoById(lri.ResId);
    //	string path = baseArtResInfoById.Path;
    //	foreach (KeyValuePair<string, Type> keyValuePair in MapEx.playerCacheDir)
    //	{
    //		if (path.Contains(keyValuePair.Key))
    //		{
    //			result = true;
    //			Debug.Log("IsFilterAnim path:" + path);
    //			break;
    //		}
    //	}
    //	return result;
    //}

    //public static void ClearInstantiateObject()
    //{
    //	foreach (UnityEngine.Object @object in LoadMachine.ObjectList)
    //	{
    //		if (@object != null)
    //		{
    //			GameObject gameObject = (GameObject)@object;
    //			Collider[] componentsInChildren = gameObject.GetComponentsInChildren<Collider>();
    //			if (componentsInChildren.Length == 0)
    //			{
    //				gameObject.active = false;
    //			}
    //		}
    //	}
    //	LoadMachine.ObjectList.Clear();
    //}

    //public static void ClearAssetsBundle()
    //{
    //	foreach (KeyValuePair<string, AssetBundle> keyValuePair in LoadMachine.AssetBundleList)
    //	{
    //		if (keyValuePair.Value != null)
    //		{
    //			AssetBundle value = keyValuePair.Value;
    //			try
    //			{
    //				Debug.Log("AssetsBundleUnload:" + keyValuePair.Key);
    //				value.Unload(true);
    //			}
    //			catch (Exception exception)
    //			{
    //				Debug.LogException(exception);
    //			}
    //		}
    //	}
    //	LoadMachine.AssetBundleList.Clear();
    //}

    //public static bool DeleteAsset(UnityEngine.Object obj, bool bIsDeep)
    //{
    //	if (!ResourcePath.IS_PUBLISH)
    //	{
    //		return false;
    //	}
    //	int num = LoadMachine.ResList.FindIndex((LoadedResourceInfo lr) => lr.Obj == obj);
    //	return num >= 0 && num < LoadMachine.ResList.Count && LoadMachine.DeleteAsset(LoadMachine.ResList[num].ResId, bIsDeep);
    //}

    //// Token: 0x06001DA7 RID: 7591 RVA: 0x000CED98 File Offset: 0x000CCF98
    //public static bool DeleteAsset(string path, Type type, bool bIsDeep)
    //{
    //	if (!ResourcePath.IS_PUBLISH)
    //	{
    //		return false;
    //	}
    //	string resPath = ResourceLoader.GetResPath(path, type);
    //	BaseArtResInfo baseArtResInfoByPath = GameData.Instance.ArtResConf.GetBaseArtResInfoByPath(resPath);
    //	return baseArtResInfoByPath != null && LoadMachine.DeleteAsset(baseArtResInfoByPath.ID, bIsDeep);
    //}

    //// Token: 0x06001DA8 RID: 7592 RVA: 0x000CEDE0 File Offset: 0x000CCFE0
    //public static bool DeleteAsset(int nResID, bool bIsDeep)
    //{
    //	if (!ResourcePath.IS_PUBLISH)
    //	{
    //		return false;
    //	}
    //	int num = LoadMachine.ResList.FindIndex((LoadedResourceInfo lr) => lr.ResId == nResID);
    //	if (num < 0 || num >= LoadMachine.ResList.Count)
    //	{
    //		return false;
    //	}
    //	LoadedResourceInfo loadedResourceInfo = LoadMachine.ResList[num];
    //	BaseArtResInfo baseArtResInfoById = GameData.Instance.ArtResConf.GetBaseArtResInfoById(loadedResourceInfo.ResId);
    //	if (baseArtResInfoById.Path.Contains("Font_weibei") || baseArtResInfoById.Path.Contains("Shaders/Dissolve"))
    //	{
    //		return false;
    //	}
    //	if (bIsDeep && baseArtResInfoById != null)
    //	{
    //		if (loadedResourceInfo.rt == RES_TYPE.GAMEOBJECT)
    //		{
    //			PrefabInfo prefabInfo = baseArtResInfoById as PrefabInfo;
    //			if (prefabInfo != null)
    //			{
    //				foreach (PrefMatInf prefMatInf in prefabInfo.MatList)
    //				{
    //					LoadMachine.DeleteAsset(prefMatInf.ID, true);
    //				}
    //			}
    //		}
    //		else if (loadedResourceInfo.rt == RES_TYPE.MATERIAL)
    //		{
    //			MaterialInfo materialInfo = baseArtResInfoById as MaterialInfo;
    //			if (materialInfo != null)
    //			{
    //				foreach (MatTexInf matTexInf in materialInfo.TexList)
    //				{
    //					LoadMachine.DeleteAsset(matTexInf.ID, true);
    //				}
    //			}
    //		}
    //	}
    //	ResourceLoader.UnloadAssets(loadedResourceInfo.Obj);
    //	loadedResourceInfo.Clear();
    //	if (num >= 0 && num < LoadMachine.ResList.Count)
    //	{
    //		LoadMachine.ResList.RemoveAt(num);
    //	}
    //	return true;
    //}

    public static UnityEngine.Object GetLoadedObj(int idx)
    {
        int num = LoadMachine.ResList.FindIndex((LoadedResourceInfo lr) => lr.ResId == idx);
        if (num < 0 || num >= LoadMachine.ResList.Count)
        {
            return null;
        }
        return LoadMachine.ResList[num].Obj;
    }

    //// Token: 0x06001DAA RID: 7594 RVA: 0x000CF020 File Offset: 0x000CD220
    //private static bool Find(int idx)
    //{
    //	return true;
    //}

    //// Token: 0x06001DAB RID: 7595 RVA: 0x000CF024 File Offset: 0x000CD224
    //public static void ReplaceLoadObj(int idx, UnityEngine.Object obj)
    //{
    //	LoadedResourceInfo loadedResourceInfo = LoadMachine.GetLoadResInfo(idx);
    //	if (loadedResourceInfo != null)
    //	{
    //		loadedResourceInfo.Obj = obj;
    //	}
    //	else
    //	{
    //		loadedResourceInfo = new LoadedResourceInfo();
    //		loadedResourceInfo.Obj = obj;
    //		loadedResourceInfo.ResId = idx;
    //		LoadMachine.ResList.Add(loadedResourceInfo);
    //	}
    //}

    //// Token: 0x06001DAC RID: 7596 RVA: 0x000CF06C File Offset: 0x000CD26C
    //public static LoadedResourceInfo GetLoadResInfo(int idx)
    //{
    //	foreach (LoadedResourceInfo loadedResourceInfo in LoadMachine.ResList)
    //	{
    //		if (loadedResourceInfo.ResId == idx)
    //		{
    //			return loadedResourceInfo;
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x06001DAD RID: 7597 RVA: 0x000CF0E0 File Offset: 0x000CD2E0
    //public bool IsExistInLoadingQueue(int idx)
    //{
    //	foreach (LoadingRes loadingRes in LoadMachine.LoadingList)
    //	{
    //		if (loadingRes.resID == idx)
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    public static void ProcessCallBack(int idx)
    {
        //if (!LoadMachine.IsLoadCompleted(idx))
        //{
        //    return;
        //}
        //for (int i = LoadMachine.LoadingList.Count - 1; i >= 0; i--)
        //{
        //    LoadingRes loadingRes = LoadMachine.LoadingList[i];
        //    if (loadingRes != null)
        //    {
        //        if (loadingRes.resID == idx)
        //        {
        //            loadingRes.callback(loadingRes.resID, loadingRes.value, loadingRes.strValue);
        //            LoadMachine.LoadingList.Remove(loadingRes);
        //        }
        //    }
        //}
    }

    //// Token: 0x06001DAF RID: 7599 RVA: 0x000CF1D8 File Offset: 0x000CD3D8
    //private static bool CheckLoadingComplete()
    //{
    //	if (LoadMachine.LoadingList.Count == 0 && !LoadMachine.isLoadCompleted)
    //	{
    //		LoadMachine.isLoadCompleted = true;
    //		LoadMachine.RemoveList.Clear();
    //		MapEx.ActiveMap();
    //		Debug.Log("CheckLoadingComplete!");
    //	}
    //	return LoadMachine.isLoadCompleted;
    //}

    public static void ProcessCallBack()
    {
        //for (int i = LoadMachine.LoadingList.Count - 1; i >= 0; i--)
        //{
        //    LoadingRes loadingRes = LoadMachine.LoadingList[i];
        //    if (loadingRes != null)
        //    {
        //        if (LoadMachine.IsLoadCompleted(loadingRes.resID))
        //        {
        //            loadingRes.callback(loadingRes.resID, loadingRes.value, loadingRes.strValue);
        //            LoadMachine.LoadingList.Remove(loadingRes);
        //        }
        //    }
        //}
    }

    public static UnityEngine.Object LoadNormalResImmediately(int idx, RES_TYPE rt)
    {
        UnityEngine.Object @object = LoadMachine.GetLoadedObj(idx);
        if (@object != null)
        {
            return @object;
        }
        BaseArtResInfo baseArtResInfoById = GameData.Instance.ArtResConf.GetBaseArtResInfoById(idx);
        if (baseArtResInfoById == null)
        {
            Debug.LogWarning("Can't find BaseArtResInfo whose id is " + idx);
            return null;
        }
        @object = LoadMachine.LoadObj(baseArtResInfoById.Path, baseArtResInfoById.Name, baseArtResInfoById.ResType);
        if (@object != null && idx != -1)
        {
            LoadedResourceInfo loadedResourceInfo = new LoadedResourceInfo();
            loadedResourceInfo.Obj = @object;
            loadedResourceInfo.ResId = idx;
            loadedResourceInfo.rt = rt;
            LoadMachine.ResList.Add(loadedResourceInfo);
            LoadMachine.ProcessCallBack(idx);
        }
        else
        {
            Debug.LogWarning("Can't find Resources from path: " + baseArtResInfoById.Path);
        }
        return @object;
    }

    //// Token: 0x06001DB2 RID: 7602 RVA: 0x000CF35C File Offset: 0x000CD55C
    //public static UnityEngine.Object LoadObjImmediately(string path, RES_TYPE rt)
    //{
    //	BaseArtResInfo baseArtResInfoByPathDim = GameData.Instance.ArtResConf.GetBaseArtResInfoByPathDim(path);
    //	if (baseArtResInfoByPathDim == null)
    //	{
    //		return null;
    //	}
    //	return LoadMachine.LoadObjImmediately(baseArtResInfoByPathDim.ID, rt);
    //}

    public static UnityEngine.Object LoadObjImmediately(int idx, RES_TYPE rt)
    {
        if (idx < 1000000)
        {
            Debug.Log("Id is error!" + idx);
            return null;
        }
        if (idx >= 1000000 && idx < 2000000)
        {
            //return LoadMachine.LoadNormalResImmediately(idx, rt);
        }
        if (idx >= 2000000 && idx < 3000000)
        {
            //return LoadMachine.LoadMaterialResImmediately(idx, rt);
        }
        if (idx >= 3000000)
        {
            return LoadMachine.LoadPrefabResImmediately(idx, rt);
        }
        return null;
    }

    //// Token: 0x06001DB4 RID: 7604 RVA: 0x000CF410 File Offset: 0x000CD610
    //public static UnityEngine.Object LoadMaterialResImmediately(int idx, RES_TYPE rt)
    //{
    //	UnityEngine.Object loadedObj = LoadMachine.GetLoadedObj(idx);
    //	if (loadedObj != null)
    //	{
    //		return loadedObj;
    //	}
    //	MaterialInfo materialInfo = GameData.Instance.ArtResConf.GetBaseArtResInfoById(idx) as MaterialInfo;
    //	if (materialInfo == null)
    //	{
    //		Debug.Log("Can't find materialinfo whose id is " + idx);
    //	}
    //	Material material = LoadMachine.LoadNormalResImmediately(idx, rt) as Material;
    //	if (material == null)
    //	{
    //		Debug.Log("Material " + idx + " is null!");
    //		return null;
    //	}
    //	Material material2 = new Material(material);
    //	foreach (MatTexInf matTexInf in materialInfo.TexList)
    //	{
    //		Texture texture = LoadMachine.LoadNormalResImmediately(matTexInf.ID, RES_TYPE.TEXTURE) as Texture;
    //		if (texture == null)
    //		{
    //			Debug.Log("Can't load texture.id:" + matTexInf.ID);
    //		}
    //		else
    //		{
    //			material2.SetTexture(matTexInf.NameInShader, texture);
    //		}
    //	}
    //	LoadMachine.ReplaceLoadObj(idx, material2);
    //	return material2;
    //}

    public static void SetMatOnObject(int idx, ref GameObject go)
    {
        PrefabInfo prefabInfo = GameData.Instance.ArtResConf.GetBaseArtResInfoById(idx) as PrefabInfo;
        if (prefabInfo == null)
        {
            return;
        }
        go.name = prefabInfo.Name;
        foreach (PrefMatInf prefMatInf in prefabInfo.MatList)
        {
            //Material material = LoadMachine.LoadMaterialResImmediately(prefMatInf.ID, RES_TYPE.MATERIAL) as Material;
            //if (material == null)
            //{
            //    Debug.Log("Can't load material id:" + prefMatInf.ID);
            //}
            //else if (prefMatInf.RenderGoPath.Length == 0)
            //{
            //    go.renderer.sharedMaterials[prefMatInf.MatIdx] = material;
            //    if (prefMatInf.MatIdx == 0)
            //    {
            //        go.renderer.sharedMaterial = material;
            //    }
            //}
            //else
            //{
            //    string empty = string.Empty;
            //    Transform transByIndexPath = LoadMachine.GetTransByIndexPath(go.transform, prefMatInf.RenderIdx, ref empty);
            //    if (empty != prefMatInf.RenderGoPath)
            //    {
            //        Debug.Log("Render index path is not match RenderGoPath! " + prefMatInf.RenderIdx + "," + prefMatInf.RenderGoPath);
            //    }
            //    else if (transByIndexPath == null)
            //    {
            //        Debug.Log(
            //            "rendGo is null,path is "+
            //            prefMatInf.RenderGoPath+
            //            ",index:"+
            //            idx+
            //            ",go's name is "+
            //            go.name);
            //    }
            //    else
            //    {
            //        transByIndexPath.gameObject.renderer.sharedMaterials[prefMatInf.MatIdx] = material;
            //        if (prefMatInf.MatIdx == 0)
            //        {
            //            transByIndexPath.gameObject.renderer.sharedMaterial = material;
            //        }
            //    }
            //}
        }
        //LoadMachine.ReplaceLoadObj(idx, go);
    }

    public static UnityEngine.Object LoadPrefabResImmediately(int idx, RES_TYPE rt)
    {
        UnityEngine.Object loadedObj = LoadMachine.GetLoadedObj(idx);
        if (loadedObj != null)
        {          
            return loadedObj;
        }
        GameObject gameObject = LoadMachine.LoadNormalResImmediately(idx, rt) as GameObject;
        if (gameObject == null)
        {
            Debug.LogWarning("Can't find BaseArtResInfo whose id is " + idx);
            return null;
        }
        LoadMachine.SetMatOnObject(idx, ref gameObject);
        return gameObject;
    }

    //// Token: 0x06001DB7 RID: 7607 RVA: 0x000CF798 File Offset: 0x000CD998
    //public static Transform GetTransByIndexPath(Transform rootTrans, string indexPath, ref string strPath)
    //{
    //	string[] array = indexPath.Split(new string[]
    //	{
    //		"-"
    //	}, StringSplitOptions.None);
    //	Transform transform = rootTrans;
    //	strPath = string.Empty;
    //	for (int i = 1; i < array.Length; i++)
    //	{
    //		int num = Convert.ToInt32(array[i]);
    //		int num2 = 0;
    //		foreach (object obj in transform)
    //		{
    //			Transform transform2 = (Transform)obj;
    //			if (num2 == num)
    //			{
    //				transform = transform2;
    //				if (strPath.Length == 0)
    //				{
    //					strPath = transform2.name;
    //				}
    //				else
    //				{
    //					strPath = strPath + "/" + transform2.name;
    //				}
    //				break;
    //			}
    //			num2++;
    //		}
    //	}
    //	return transform;
    //}

    //// Token: 0x06001DB8 RID: 7608 RVA: 0x000CF88C File Offset: 0x000CDA8C
    //public static bool IsLoadCompleted(int id)
    //{
    //	if (id < 1000000)
    //	{
    //		Debug.Log("Id is error!");
    //		return false;
    //	}
    //	if (id >= 1000000 && id < 2000000)
    //	{
    //		return LoadMachine.IsNormalLoadComplete(id);
    //	}
    //	if (id >= 2000000 && id < 3000000)
    //	{
    //		return LoadMachine.IsMaterialLoadComplete(id);
    //	}
    //	return id >= 3000000 && LoadMachine.IsPrefabLoadComplete(id);
    //}

    //// Token: 0x06001DB9 RID: 7609 RVA: 0x000CF900 File Offset: 0x000CDB00
    //public static bool IsMaterialLoadComplete(int id)
    //{
    //	MaterialInfo materialInfo = GameData.Instance.ArtResConf.GetBaseArtResInfoById(id) as MaterialInfo;
    //	if (materialInfo == null)
    //	{
    //		Debug.Log("Can't find PrefabInfo whose id is " + id);
    //		return true;
    //	}
    //	if (LoadMachine.IsRemovedObj(id))
    //	{
    //		return true;
    //	}
    //	if (LoadMachine.GetLoadedObj(id) == null)
    //	{
    //		return false;
    //	}
    //	foreach (MatTexInf matTexInf in materialInfo.TexList)
    //	{
    //		if (!LoadMachine.IsNormalLoadComplete(matTexInf.ID))
    //		{
    //			return false;
    //		}
    //	}
    //	return true;
    //}

    //// Token: 0x06001DBA RID: 7610 RVA: 0x000CF9CC File Offset: 0x000CDBCC
    //public static bool IsPrefabLoadComplete(int id)
    //{
    //	PrefabInfo prefabInfo = GameData.Instance.ArtResConf.GetBaseArtResInfoById(id) as PrefabInfo;
    //	if (prefabInfo == null)
    //	{
    //		Debug.Log("Can't find PrefabInfo whose id is " + id);
    //		return true;
    //	}
    //	if (LoadMachine.IsRemovedObj(id))
    //	{
    //		return true;
    //	}
    //	if (LoadMachine.GetLoadedObj(id) == null)
    //	{
    //		return false;
    //	}
    //	foreach (PrefMatInf prefMatInf in prefabInfo.MatList)
    //	{
    //		if (!LoadMachine.IsMaterialLoadComplete(prefMatInf.ID))
    //		{
    //			return false;
    //		}
    //	}
    //	return true;
    //}

    //// Token: 0x06001DBB RID: 7611 RVA: 0x000CFA98 File Offset: 0x000CDC98
    //public static bool IsNormalLoadComplete(int id)
    //{
    //	if (GameData.Instance.ArtResConf.GetBaseArtResInfoById(id) == null)
    //	{
    //		Debug.Log("Can't find bari whose id is " + id);
    //		return true;
    //	}
    //	return LoadMachine.IsRemovedObj(id) || !(LoadMachine.GetLoadedObj(id) == null);
    //}

    //// Token: 0x06001DBC RID: 7612 RVA: 0x000CFAF4 File Offset: 0x000CDCF4
    //public static bool IsRemovedObj(int id)
    //{
    //	foreach (LoadingRes loadingRes in LoadMachine.RemoveList)
    //	{
    //		if (loadingRes.resID == id)
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06001DBD RID: 7613 RVA: 0x000CFB68 File Offset: 0x000CDD68
    //public static void SetMaterialOnGameObject(int matId, int goId, string renderPath)
    //{
    //	Material material = LoadMachine.GetLoadedObj(matId) as Material;
    //	if (material == null)
    //	{
    //		return;
    //	}
    //	MaterialInfo materialInfo = GameData.Instance.ArtResConf.GetBaseArtResInfoById(matId) as MaterialInfo;
    //	if (materialInfo != null)
    //	{
    //		foreach (MatTexInf matTexInf in materialInfo.TexList)
    //		{
    //			LoadMachine.LoadNormalResAsynchronism(matTexInf.ID, RES_TYPE.TEXTURE, new Callback<int, int, string>(LoadMachine.SetTextureOnMaterial), matId, matTexInf.NameInShader);
    //		}
    //	}
    //	GameObject gameObject = LoadMachine.GetLoadedObj(goId) as GameObject;
    //	if (gameObject == null)
    //	{
    //		return;
    //	}
    //	Transform transform;
    //	if (renderPath.Length == 0)
    //	{
    //		transform = gameObject.transform;
    //	}
    //	else
    //	{
    //		transform = gameObject.transform.FindChild(renderPath);
    //	}
    //	if (transform == null)
    //	{
    //		Debug.Log("rendGo is null,path is " + renderPath);
    //		return;
    //	}
    //	transform.renderer.sharedMaterial = material;
    //}

    //// Token: 0x06001DBE RID: 7614 RVA: 0x000CFC8C File Offset: 0x000CDE8C
    //public static void SetTextureOnMaterial(int texId, int MatId, string shaderTexName)
    //{
    //	Texture texture = LoadMachine.GetLoadedObj(texId) as Texture;
    //	if (texture == null)
    //	{
    //		return;
    //	}
    //	Material material = LoadMachine.GetLoadedObj(MatId) as Material;
    //	if (material == null)
    //	{
    //		return;
    //	}
    //	Material material2 = new Material(material);
    //	LoadedResourceInfo loadResInfo = LoadMachine.GetLoadResInfo(MatId);
    //	loadResInfo.Obj = material2;
    //	material2.SetTexture(shaderTexName, texture);
    //}

    //// Token: 0x06001DBF RID: 7615 RVA: 0x000CFCE8 File Offset: 0x000CDEE8
    //public static void LoadNormalResAsynchronism(int idx, RES_TYPE rt, Callback<int, int, string> cb, int value, string strValue)
    //{
    //	if (LoadMachine.GetLoadedObj(idx) != null)
    //	{
    //		cb(idx, value, strValue);
    //		return;
    //	}
    //	BaseArtResInfo baseArtResInfoById = GameData.Instance.ArtResConf.GetBaseArtResInfoById(idx);
    //	if (baseArtResInfoById == null)
    //	{
    //		Debug.Log("Can't find BaseArtResInfo whose id is " + idx);
    //	}
    //	LoadingRes loadingRes = new LoadingRes();
    //	loadingRes.path = baseArtResInfoById.Path;
    //	loadingRes.resID = idx;
    //	loadingRes.rt = rt;
    //	loadingRes.callback = cb;
    //	loadingRes.value = value;
    //	loadingRes.strValue = strValue;
    //	LoadMachine.LoadingList.Add(loadingRes);
    //}

    //// Token: 0x06001DC0 RID: 7616 RVA: 0x000CFD80 File Offset: 0x000CDF80
    //public static void LoadMaterialResAsynchronism(int idx, RES_TYPE rt, Callback<int, int, string> cb, int value, string strValue)
    //{
    //	if (LoadMachine.GetLoadedObj(idx) != null)
    //	{
    //		cb(idx, value, strValue);
    //		return;
    //	}
    //	MaterialInfo materialInfo = GameData.Instance.ArtResConf.GetBaseArtResInfoById(idx) as MaterialInfo;
    //	if (materialInfo == null)
    //	{
    //		Debug.Log("Can't find materialinfo whose id is " + idx);
    //		return;
    //	}
    //	LoadingRes loadingRes = new LoadingRes();
    //	loadingRes.path = materialInfo.Path;
    //	loadingRes.resID = idx;
    //	loadingRes.rt = rt;
    //	loadingRes.callback = cb;
    //	loadingRes.value = value;
    //	loadingRes.strValue = strValue;
    //	LoadMachine.LoadingList.Add(loadingRes);
    //	foreach (MatTexInf matTexInf in materialInfo.TexList)
    //	{
    //		LoadMachine.LoadNormalResAsynchronism(matTexInf.ID, RES_TYPE.TEXTURE, new Callback<int, int, string>(LoadMachine.SetTextureOnMaterial), idx, matTexInf.NameInShader);
    //	}
    //}

    //// Token: 0x06001DC1 RID: 7617 RVA: 0x000CFE90 File Offset: 0x000CE090
    //public static void LoadPrefabResAsynchronism(int idx, RES_TYPE rt, Callback<int, int, string> cb, int value, string strValue)
    //{
    //	if (LoadMachine.GetLoadedObj(idx) != null)
    //	{
    //		cb(idx, value, strValue);
    //		return;
    //	}
    //	PrefabInfo prefabInfo = GameData.Instance.ArtResConf.GetBaseArtResInfoById(idx) as PrefabInfo;
    //	if (prefabInfo == null)
    //	{
    //		Debug.Log("Can't find PrefabInfo whose id is " + idx);
    //		return;
    //	}
    //	LoadingRes loadingRes = new LoadingRes();
    //	loadingRes.path = prefabInfo.Path;
    //	loadingRes.resID = idx;
    //	loadingRes.rt = rt;
    //	loadingRes.callback = cb;
    //	loadingRes.value = value;
    //	loadingRes.strValue = strValue;
    //	LoadMachine.LoadingList.Add(loadingRes);
    //	foreach (PrefMatInf prefMatInf in prefabInfo.MatList)
    //	{
    //		LoadMachine.LoadMaterialResAsynchronism(prefMatInf.ID, RES_TYPE.MATERIAL, new Callback<int, int, string>(LoadMachine.SetMaterialOnGameObject), idx, prefMatInf.RenderGoPath);
    //	}
    //}

    //// Token: 0x06001DC2 RID: 7618 RVA: 0x000CFFA0 File Offset: 0x000CE1A0
    //public static void LoadResAsynchronism(int idx, string path, RES_TYPE rt, Callback<int, int, string> cb, int value, string strValue)
    //{
    //	if (idx < 1000000)
    //	{
    //		Debug.Log("Id is error!");
    //	}
    //	if (idx >= 1000000 && idx < 2000000)
    //	{
    //		LoadMachine.LoadNormalResAsynchronism(idx, rt, cb, value, strValue);
    //	}
    //	if (idx >= 2000000 && idx < 3000000)
    //	{
    //		LoadMachine.LoadMaterialResAsynchronism(idx, rt, cb, value, strValue);
    //	}
    //	if (idx >= 3000000)
    //	{
    //		LoadMachine.LoadPrefabResAsynchronism(idx, rt, cb, value, strValue);
    //	}
    //}

    public IEnumerator Load(LoadingRes lr)
    {
        LoadMachine.bLoading = true;
        yield return new LoadResource(lr);
        LoadMachine.bLoading = false;
        yield break;
    }

    //// Token: 0x06001DC4 RID: 7620 RVA: 0x000D0044 File Offset: 0x000CE244
    //public static Type GetResType(RES_TYPE rt)
    //{
    //	switch (rt)
    //	{
    //	case RES_TYPE.GAMEOBJECT:
    //		return typeof(GameObject);
    //	case RES_TYPE.TEXTURE:
    //		return typeof(Texture2D);
    //	case RES_TYPE.AUDIO:
    //		return typeof(AudioClip);
    //	case RES_TYPE.VIDEO:
    //		return typeof(MovieTexture);
    //	case RES_TYPE.SHADER:
    //		return typeof(Shader);
    //	case RES_TYPE.MATERIAL:
    //		return typeof(Material);
    //	case RES_TYPE.TEXT:
    //		return typeof(TextAsset);
    //	case RES_TYPE.OBJECT:
    //		return typeof(UnityEngine.Object);
    //	}
    //	return typeof(UnityEngine.Object);
    //}

    public static UnityEngine.Object LoadObj(string path, string name, RES_TYPE rt)
    {
        string text = "Assets/";
        path = path.Substring(text.Length);
        GameObject obj =Resources.Load(path)as GameObject;
        return obj;
    }

    public static UnityEngine.Object InstantiateObject(UnityEngine.Object original)
    {
        UnityEngine.Object @object = UnityEngine.Object.Instantiate(original);
        LoadMachine.ObjectList.Add(@object);
        return @object;
    }

    public static UnityEngine.Object InstantiateObject(UnityEngine.Object original, Vector3 position, Quaternion rotation)
    {
        UnityEngine.Object @object = UnityEngine.Object.Instantiate(original, position, rotation);
        LoadMachine.ObjectList.Add(@object);
        return @object;
    }

    //// Token: 0x06001DC8 RID: 7624 RVA: 0x000D01C0 File Offset: 0x000CE3C0
    //private static AssetBundle GetAssetBundle(string path)
    //{
    //	foreach (KeyValuePair<string, AssetBundle> keyValuePair in LoadMachine.AssetBundleList)
    //	{
    //		if (keyValuePair.Key == path)
    //		{
    //			return keyValuePair.Value;
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x06001DC9 RID: 7625 RVA: 0x000D0244 File Offset: 0x000CE444
    //private static AssetBundle GetUIAssetBundle(string path)
    //{
    //	foreach (KeyValuePair<string, AssetBundle> keyValuePair in LoadMachine.UIAssetBundleList)
    //	{
    //		if (keyValuePair.Key == path)
    //		{
    //			return keyValuePair.Value;
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x06001DCA RID: 7626 RVA: 0x000D02C8 File Offset: 0x000CE4C8
    //private static void AddAssetBundle(string path, AssetBundle item)
    //{
    //	if (path.Contains("Shaders") || path.Contains("Plugins") || path.Contains("EZGUI") || path.Contains("GameLegend") || path.Contains("ItemAtlas") || path.Contains("Sprite Atlases"))
    //	{
    //		if (!LoadMachine.UIAssetBundleList.ContainsKey(path))
    //		{
    //			LoadMachine.UIAssetBundleList.Add(path, item);
    //		}
    //	}
    //	else if (!LoadMachine.AssetBundleList.ContainsKey(path))
    //	{
    //		LoadMachine.AssetBundleList.Add(path, item);
    //	}
    //}
}
