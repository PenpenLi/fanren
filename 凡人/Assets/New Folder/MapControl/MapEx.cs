using System;
using System.Collections.Generic;
using System.IO;
using NS_RoleBaseFun;
using UnityEngine;

public class MapEx
{
    private const string MAP_OBJ_NAME = "Map";

    public int ID;

    public string Name;

    public string ScenePath;

    public string MapFilePath;

    public string ShadowBackFilePath;

    public RenderSettingInfo RndSetInfo;

    public List<MapObjectInfo> mapObjInfoList = new List<MapObjectInfo>();

    private static List<GameObject> activeGoList = new List<GameObject>();

    public Dictionary<string, Type> cacheDir = new Dictionary<string, Type>();

    public static Dictionary<string, Type> uiCacheDir = new Dictionary<string, Type>();
    
    public static Dictionary<string, Type> playerCacheDir = new Dictionary<string, Type>();

    public List<MapEx.GOInfo> mapGoList = new List<MapEx.GOInfo>();

    private GameObject m_cMapObj;

    public class GOInfo
    {
        public GOInfo(int pId, GameObject pGo)
        {
            this.id = pId;
            this.go = pGo;
        }

        public int id;

        public GameObject go;
    }

    public void LoadObj()
    {
        this.mapObjInfoList.Clear();
        List<string> list = RoleBaseFun.LoadConfInAssets(this.MapFilePath);
        foreach (string text in list)
        {
            string[] array = text.Split(CacheData.separator);
            if (array.Length != 16)
            {
                Debug.LogError(
                    this.MapFilePath + " 格式错误");
                break;
            }
            MapObjectInfo mapObjectInfo = new MapObjectInfo();
            int num = 0;
            mapObjectInfo.ID = Convert.ToInt32(array[num]);
            num++;
            mapObjectInfo.Name = array[num];
            num++;
            mapObjectInfo.ResID = Convert.ToInt32(array[num]);
            num++;
            mapObjectInfo.moiType = (MOI_Type)Convert.ToInt32(array[num]);
            num++;
            mapObjectInfo.Tag = array[num];
            num++;
            mapObjectInfo.Layer = Convert.ToInt32(array[num]);
            num++;
            mapObjectInfo.ParentID = Convert.ToInt32(array[num]);
            num++;
            float[] array2 = new float[9];
            for (int i = 0; i < 9; i++)
            {
                array2[i] = Convert.ToSingle(array[num]);
                num++;
            }
            mapObjectInfo.Pos = new Vector3(array2[0], array2[1], array2[2]);
            mapObjectInfo.Qua = new Vector3(array2[3], array2[4], array2[5]);
            mapObjectInfo.Scale = new Vector3(array2[6], array2[7], array2[8]);
            this.mapObjInfoList.Add(mapObjectInfo);
        }
    }

    //public void ClearMapGoList()
    //{
    //	foreach (MapEx.GOInfo goinfo in this.mapGoList)
    //	{
    //		goinfo.go = null;
    //	}
    //	this.mapGoList.Clear();
    //}

    //public GameObject GetMapGoById(int id)
    //{
    //	foreach (MapEx.GOInfo goinfo in this.mapGoList)
    //	{
    //		if (goinfo.id == id)
    //		{
    //			return goinfo.go;
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x060016C5 RID: 5829 RVA: 0x000B1924 File Offset: 0x000AFB24
    //public static void ActiveMap()
    //{
    //	foreach (GameObject gameObject in MapEx.activeGoList)
    //	{
    //		gameObject.active = true;
    //	}
    //	MapEx.activeGoList.Clear();
    //       FanrenSceneManager.Instance.GameStart();
    //       //FanrenSceneManager.Instance.DoScriptMoudle();
    //}

    public GameObject InitGameObject(GameObject prefabGo, MapObjectInfo moi)
    {
        if (moi == null)
        {
            return null;
        }
        GameObject gameObject;
        if (prefabGo == null)
        {
            gameObject = new GameObject();
            gameObject.transform.position = moi.Pos;
            gameObject.transform.rotation = Quaternion.Euler(moi.Qua);
        }
        else
        {
            gameObject = EngineFun.InstantiateGameObject(prefabGo, moi.Pos, Quaternion.Euler(moi.Qua));
        }
        //gameObject.name = moi.Name;
        if (moi.ParentID != 0)
        {
            //GameObject mapGoById = this.GetMapGoById(moi.ParentID);
            //if (mapGoById != null)
            //{
            //    gameObject.transform.parent = mapGoById.transform;
            //}
            //else
            //{
            //    MapObjectInfo mapObjInfoById = this.GetMapObjInfoById(moi.ParentID);
            //    this.InitGameObject(mapObjInfoById.ResID, mapObjInfoById.ID, mapObjInfoById.Name);
            //    mapGoById = this.GetMapGoById(mapObjInfoById.ID);
            //    gameObject.transform.parent = mapGoById.transform;
            //}
        }
        else if (moi.moiType == MOI_Type.Scene)
        {
            //gameObject.transform.parent = this.m_cMapObj.transform;
        }
        //gameObject.transform.localScale = moi.Scale;
        //gameObject.tag = moi.Tag;
        //gameObject.layer = moi.Layer;
        //return gameObject;
        return null;
    }

    //// Token: 0x060016C7 RID: 5831 RVA: 0x000B1AF0 File Offset: 0x000AFCF0
    //public void InitGameObject(int id, int value, string strValue)
    //{
    //	MapObjectInfo mapObjInfoById = this.GetMapObjInfoById(value);
    //	if (mapObjInfoById == null)
    //	{
    //		return;
    //	}
    //	GameObject prefabGo = null;
    //	if (id != 0)
    //	{
    //		prefabGo = (LoadMachine.GetLoadedObj(id) as GameObject);
    //	}
    //	LoadMachine.SetMatOnObject(mapObjInfoById.ResID, ref prefabGo);
    //	GameObject gameObject = this.InitGameObject(prefabGo, mapObjInfoById);
    //	if (gameObject != null)
    //	{
    //		this.mapGoList.Add(new MapEx.GOInfo(value, gameObject));
    //	}
    //}

    //// Token: 0x060016C8 RID: 5832 RVA: 0x000B1B54 File Offset: 0x000AFD54
    //public void InitGameObjectUnActive(int id, int value, string strValue)
    //{
    //	MapObjectInfo mapObjInfoById = this.GetMapObjInfoById(value);
    //	if (mapObjInfoById == null)
    //	{
    //		return;
    //	}
    //	GameObject prefabGo = null;
    //	if (id != 0)
    //	{
    //		prefabGo = (LoadMachine.GetLoadedObj(id) as GameObject);
    //	}
    //	LoadMachine.SetMatOnObject(mapObjInfoById.ResID, ref prefabGo);
    //	GameObject gameObject = this.InitGameObject(prefabGo, mapObjInfoById);
    //	if (gameObject != null)
    //	{
    //		this.mapGoList.Add(new MapEx.GOInfo(value, gameObject));
    //		gameObject.active = false;
    //		MapEx.activeGoList.Add(gameObject);
    //	}
    //}

    //// Token: 0x060016C9 RID: 5833 RVA: 0x000B1BCC File Offset: 0x000AFDCC
    //private static void InitCacheGameObject(int id, int value, string strValue)
    //{
    //	GameObject x = null;
    //	if (id != 0)
    //	{
    //		x = (LoadMachine.GetLoadedObj(id) as GameObject);
    //	}
    //	if (id < 1000000)
    //	{
    //		Debug.Log("Id is error!" + id);
    //		return;
    //	}
    //	if (id < 1000000 || id < 2000000)
    //	{
    //	}
    //	if (id < 2000000 || id < 3000000)
    //	{
    //	}
    //	if (id >= 3000000 && x != null)
    //	{
    //		LoadMachine.SetMatOnObject(id, ref x);
    //	}
    //	x = null;
    //}

    //// Token: 0x060016CA RID: 5834 RVA: 0x000B1C5C File Offset: 0x000AFE5C
    //public MapObjectInfo GetMapObjInfoById(int id)
    //{
    //	foreach (MapObjectInfo mapObjectInfo in this.mapObjInfoList)
    //	{
    //		if (mapObjectInfo.ID == id)
    //		{
    //			return mapObjectInfo;
    //		}
    //	}
    //	return null;
    //}

    public void LoadCache()
    {
        this.cacheDir.Clear();
        string text = this.MapFilePath.Replace("map/", string.Empty);
        text = text.Replace("m", "M");
        this.cacheDir = ResourceLoader.ReadCacheConfig(text);
        foreach (KeyValuePair<string, Type> item in this.cacheDir)
        {
            string cachePath = MapEx.GetCachePath(item);
            BaseArtResInfo baseArtResInfoByPath = GameData.Instance.ArtResConf.GetBaseArtResInfoByPath(cachePath);
            if (baseArtResInfoByPath != null)
            {
                //LoadMachine.LoadObjImmediately(new MapObjectInfo
                //{
                //    ID = baseArtResInfoByPath.ID,
                //    Name = baseArtResInfoByPath.Name,
                //    ResID = baseArtResInfoByPath.ID,
                //    moiType = MOI_Type.Normal,
                //    ParentID = 0
                //}.ResID, RES_TYPE.GAMEOBJECT);
            }
        }
        this.cacheDir.Clear();
    }

    //// Token: 0x060016CC RID: 5836 RVA: 0x000B1DF0 File Offset: 0x000AFFF0
    //public static void LoadUICache()
    //{
    //	if (MapEx.uiCacheDir.Count > 0)
    //	{
    //		return;
    //	}
    //	string filepath = "CacheConfig/Gui_Mono.txt";
    //	MapEx.uiCacheDir = ResourceLoader.ReadCacheConfigFile(filepath);
    //	foreach (KeyValuePair<string, Type> item in MapEx.uiCacheDir)
    //	{
    //		string cachePath = MapEx.GetCachePath(item);
    //		BaseArtResInfo baseArtResInfoByPath = GameData.Instance.ArtResConf.GetBaseArtResInfoByPath(cachePath);
    //		if (baseArtResInfoByPath != null)
    //		{
    //			MapObjectInfo mapObjectInfo = new MapObjectInfo();
    //			mapObjectInfo.ID = baseArtResInfoByPath.ID;
    //			mapObjectInfo.Name = baseArtResInfoByPath.Name;
    //			mapObjectInfo.ResID = baseArtResInfoByPath.ID;
    //			mapObjectInfo.moiType = MOI_Type.Normal;
    //			mapObjectInfo.ParentID = 0;
    //			LoadMachine.LoadResAsynchronism(mapObjectInfo.ResID, string.Empty, RES_TYPE.OBJECT, new Callback<int, int, string>(MapEx.InitCacheGameObject), mapObjectInfo.ID, mapObjectInfo.Name);
    //		}
    //	}
    //}

    //// Token: 0x060016CD RID: 5837 RVA: 0x000B1F04 File Offset: 0x000B0104
    //public void LoadAnimationCache()
    //{
    //	if (MapEx.playerCacheDir.Count > 0)
    //	{
    //		return;
    //	}
    //	string filepath = "CacheConfig/HanLi.txt";
    //	MapEx.playerCacheDir = ResourceLoader.ReadCacheConfigFile(filepath);
    //	foreach (KeyValuePair<string, Type> item in MapEx.playerCacheDir)
    //	{
    //		string cachePath = MapEx.GetCachePath(item);
    //		BaseArtResInfo baseArtResInfoByPath = GameData.Instance.ArtResConf.GetBaseArtResInfoByPath(cachePath);
    //		if (baseArtResInfoByPath != null)
    //		{
    //			MapObjectInfo mapObjectInfo = new MapObjectInfo();
    //			mapObjectInfo.ID = baseArtResInfoByPath.ID;
    //			mapObjectInfo.Name = baseArtResInfoByPath.Name;
    //			mapObjectInfo.ResID = baseArtResInfoByPath.ID;
    //			mapObjectInfo.moiType = MOI_Type.Normal;
    //			mapObjectInfo.ParentID = 0;
    //			LoadMachine.LoadResAsynchronism(mapObjectInfo.ResID, string.Empty, RES_TYPE.OBJECT, new Callback<int, int, string>(MapEx.InitCacheGameObject), mapObjectInfo.ID, mapObjectInfo.Name);
    //		}
    //	}
    //}

    private static string GetCachePath(KeyValuePair<string, Type> item)
    {
        string text = item.Key;
        if (!text.Contains("Assets/") && !text.Contains("Assets/Resources/"))
        {
            text = "Assets/Resources/" + text;
        }
        if (item.Value == typeof(AnimationClip))
        {
            text += ".anim_frres";
        }
        if (item.Value == typeof(Material))
        {
            text += ".mat_frres";
        }
        if (item.Value == typeof(GameObject))
        {
            text += ".prefab_frres";
        }
        if (item.Value == typeof(AudioClip))
        {
            foreach (string str in ResourcePath.DOT_AUDIOCIP)
            {
                string text2 = text + str + "_frres";
                text2 = ResourcePath.GetPublishAssetsBundlePath() + text2;
                text2 = text2.Replace("_Assets", "_");
                if (File.Exists(text2))
                {
                    text = text + str + "_frres";
                    break;
                }
            }
        }
        return text;
    }

    public void InitMap()
    {
        this.m_cMapObj = new GameObject("Map");
        for (int i = 0; i < this.mapObjInfoList.Count; i++)
        {
            MapObjectInfo mapObjectInfo = this.mapObjInfoList[i];
            if (mapObjectInfo != null)
            {
                if (mapObjectInfo.moiType == MOI_Type.Scene)
                {
                }
                Debug.Log(mapObjectInfo.ResID);
                if (mapObjectInfo.ResID != 0)
                {
                    if (MapControl.LoadAsync)
                    {                       
                        if (mapObjectInfo.moiType == MOI_Type.Scene)
                        {
                            //LoadMachine.LoadResAsynchronism(mapObjectInfo.ResID, string.Empty, RES_TYPE.OBJECT, new Callback<int, int, string>(this.InitGameObject), mapObjectInfo.ID, mapObjectInfo.Name);
                        }
                        else
                        {
                            //LoadMachine.LoadResAsynchronism(mapObjectInfo.ResID, string.Empty, RES_TYPE.OBJECT, new Callback<int, int, string>(this.InitGameObjectUnActive), mapObjectInfo.ID, mapObjectInfo.Name);
                        }
                    }
                    else
                    {
                        GameObject prefabGo = LoadMachine.LoadObjImmediately(mapObjectInfo.ResID, RES_TYPE.GAMEOBJECT) as GameObject;
                        GameObject gameObject = this.InitGameObject(prefabGo, mapObjectInfo);
                      
                    }
                }
                else
                {
                    //GameObject gameObject = this.InitGameObject(null, mapObjectInfo);
                }
            }
        }
        //this.ClearMapGoList();
        if (this.RndSetInfo != null)
        {
            this.RndSetInfo.SetRenderSettings();
        }
    }
}
