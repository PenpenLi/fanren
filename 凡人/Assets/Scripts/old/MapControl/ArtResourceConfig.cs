using System;
using System.Collections.Generic;
using System.IO;
using NS_RoleBaseFun;
using UnityEngine;


public class ArtResourceConfig
{
    public const int BASE_ART_RES_FIRST_ID = 1000000;

    public const int MATREIAL_INFO_FIRST_ID = 2000000;

    public const int PREFAB_INFO_FIRST_ID = 3000000;

    public List<BaseArtResInfo> ArtResInfoList = new List<BaseArtResInfo>();

    public void LoadConf()
	{
		this.ArtResInfoList.Clear();
		this.LoadBaseArtResInfo();
		this.LoadMaterialInfo();
		this.LoadPrefabInfo();
	}

	public void SaveConf()
	{
		//this.SaveBaseArtResInfo();
		//this.SaveMaterialInfo();
		//this.SavePrefabInfo();
	}

	public int RemoveInfoByPath(string Path)
	{
		for (int i = this.ArtResInfoList.Count - 1; i >= 0; i--)
		{
			if (this.ArtResInfoList[i].Path == Path)
			{
				int id = this.ArtResInfoList[i].ID;
				this.ArtResInfoList.Remove(this.ArtResInfoList[i]);
				return id;
			}
		}
		return 0;
	}

	public void AddInfoToList(BaseArtResInfo newBARI)
	{
		int num = 0;
		foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
		{
			if (newBARI.ID >= baseArtResInfo.ID)
			{
				break;
			}
			num++;
		}
		this.ArtResInfoList.Insert(num, newBARI);
		Debug.Log(
			"ID:"+
			newBARI.ID+
			" Path:"+
			newBARI.Path
		);
	}

	public BaseArtResInfo GetBaseArtResInfoById(int id)
	{
		foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
		{
			if (baseArtResInfo.ID == id)
			{
				return baseArtResInfo;
			}
		}
		return null;
	}

	public BaseArtResInfo GetBaseArtResInfoByPath(string path)
	{
		foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
		{
			if (baseArtResInfo.Path.ToLower() == path.ToLower())
			{
				return baseArtResInfo;
			}
		}
		return null;
	}

	public BaseArtResInfo GetBaseArtResInfoByPathDim(string path)
	{
		BaseArtResInfo baseArtResInfoByPath = this.GetBaseArtResInfoByPath(path);
		if (baseArtResInfoByPath != null)
		{
			return baseArtResInfoByPath;
		}
		foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
		{
			if (baseArtResInfo.Path.ToLower().Contains(path.ToLower()))
			{
				return baseArtResInfo;
			}
		}
		return null;
	}

	public void GetBARIListByPathDim(string path, ref List<BaseArtResInfo> bariList)
	{
		bariList.Clear();
		foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
		{
			if (baseArtResInfo.Path.ToLower().Contains(path.ToLower()))
			{
				bariList.Add(baseArtResInfo);
			}
		}
	}

	public BaseArtResInfo GetBaseArtResInfoByName(string name)
	{
		foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
		{
			if (baseArtResInfo.Name.ToLower() == name.ToLower())
			{
				return baseArtResInfo;
			}
		}
		return null;
	}

    private void LoadBaseArtResInfo()
    {
        List<string> list = RoleBaseFun.LoadConfInAssets("res/normalInfo");
        if (list == null)
        {
            return;
        }
        foreach (string text in list)
        {
            string[] array = text.Split(CacheData.separator);
            if (array.Length == 4)
            {
                BaseArtResInfo baseArtResInfo = new BaseArtResInfo();
                int num = 0;
                baseArtResInfo.ID = Convert.ToInt32(array[num++]);
                baseArtResInfo.ResType = (RES_TYPE)Convert.ToInt32(array[num++]);
                baseArtResInfo.Name = array[num++];
                baseArtResInfo.Path = array[num++];
                this.ArtResInfoList.Add(baseArtResInfo);
            }
        }
    }

    //// Token: 0x06000595 RID: 1429 RVA: 0x00019678 File Offset: 0x00017878
    //private void SaveBaseArtResInfo()
    //{
    //	if (this.ArtResInfoList.Count <= 0)
    //	{
    //		return;
    //	}
    //	string path = Application.dataPath + "/Resources/conf/res/normalInfo.txt";
    //	FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
    //	StreamWriter streamWriter = new StreamWriter(fileStream);
    //	foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
    //	{
    //		if (baseArtResInfo != null)
    //		{
    //			if (baseArtResInfo.ID >= 1000000 && baseArtResInfo.ID < 2000000)
    //			{
    //				string value = string.Concat(new string[]
    //				{
    //					baseArtResInfo.ID.ToString(),
    //					"\t",
    //					((int)baseArtResInfo.ResType).ToString(),
    //					"\t",
    //					baseArtResInfo.Name,
    //					"\t",
    //					baseArtResInfo.Path
    //				});
    //				streamWriter.WriteLine(value);
    //			}
    //		}
    //	}
    //	streamWriter.Close();
    //	fileStream.Close();
    //}

    private void LoadPrefabInfo()
    {
        List<string> list = RoleBaseFun.LoadConfInAssets("res/prefabInfo");
        if (list == null)
        {
            return;
        }
        foreach (string text in list)
        {
            string[] array = text.Split(CacheData.separator);
            if (array.Length >= 4)
            {
                int num = 0;
                PrefabInfo prefabInfo = new PrefabInfo();
                prefabInfo.ID = Convert.ToInt32(array[num++]);
                prefabInfo.ResType = (RES_TYPE)Convert.ToInt32(array[num++]);
                prefabInfo.Name = array[num++];
                prefabInfo.Path = array[num++];
                int num2 = Convert.ToInt32(array[num++]);
                for (int i = 0; i < num2; i++)
                {
                    PrefMatInf prefMatInf = new PrefMatInf();
                    prefMatInf.ID = Convert.ToInt32(array[num++]);
                    prefMatInf.RenderGoPath = array[num++];
                    if (prefMatInf.RenderGoPath == "NULL")
                    {
                        prefMatInf.RenderGoPath = string.Empty;
                    }
                    prefMatInf.RenderIdx = array[num++];
                    prefMatInf.MatIdx = Convert.ToInt32(array[num++]);
                    prefabInfo.MatList.Add(prefMatInf);
                }
                this.ArtResInfoList.Add(prefabInfo);
            }
        }
    }

    //// Token: 0x06000597 RID: 1431 RVA: 0x0001993C File Offset: 0x00017B3C
    //private void SavePrefabInfo()
    //{
    //	if (this.ArtResInfoList.Count <= 0)
    //	{
    //		return;
    //	}
    //	string path = Application.dataPath + "/Resources/conf/res/prefabInfo.txt";
    //	FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
    //	StreamWriter streamWriter = new StreamWriter(fileStream);
    //	foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
    //	{
    //		if (baseArtResInfo != null)
    //		{
    //			if (baseArtResInfo.ID >= 3000000)
    //			{
    //				PrefabInfo prefabInfo = baseArtResInfo as PrefabInfo;
    //				string text = string.Concat(new string[]
    //				{
    //					prefabInfo.ID.ToString(),
    //					"\t",
    //					((int)prefabInfo.ResType).ToString(),
    //					"\t",
    //					prefabInfo.Name,
    //					"\t",
    //					prefabInfo.Path,
    //					"\t",
    //					prefabInfo.MatList.Count.ToString()
    //				});
    //				for (int i = 0; i < prefabInfo.MatList.Count; i++)
    //				{
    //					string text2 = "NULL";
    //					if (prefabInfo.MatList[i].RenderGoPath.Length != 0)
    //					{
    //						text2 = prefabInfo.MatList[i].RenderGoPath;
    //					}
    //					string text3 = text;
    //					text = string.Concat(new object[]
    //					{
    //						text3,
    //						"\t",
    //						prefabInfo.MatList[i].ID,
    //						"\t",
    //						text2,
    //						"\t",
    //						prefabInfo.MatList[i].RenderIdx,
    //						"\t",
    //						prefabInfo.MatList[i].MatIdx
    //					});
    //				}
    //				streamWriter.WriteLine(text);
    //			}
    //		}
    //	}
    //	streamWriter.Close();
    //	fileStream.Close();
    //}

    private void LoadMaterialInfo()
    {
        List<string> list = RoleBaseFun.LoadConfInAssets("res/materialInfo");
        if (list == null)
        {
            return;
        }
        foreach (string text in list)
        {
            string[] array = text.Split(CacheData.separator);
            if (array.Length >= 4)
            {
                int num = 0;
                MaterialInfo materialInfo = new MaterialInfo();
                materialInfo.ID = Convert.ToInt32(array[num++]);
                materialInfo.ResType = (RES_TYPE)Convert.ToInt32(array[num++]);
                materialInfo.Name = array[num++];
                materialInfo.Path = array[num++];
                int num2 = Convert.ToInt32(array[num++]);
                for (int i = 0; i < num2; i++)
                {
                    MatTexInf matTexInf = new MatTexInf();
                    matTexInf.ID = Convert.ToInt32(array[num++]);
                    matTexInf.NameInShader = array[num++];
                    materialInfo.TexList.Add(matTexInf);
                }
                this.ArtResInfoList.Add(materialInfo);
            }
        }
    }

    //// Token: 0x06000599 RID: 1433 RVA: 0x00019CB8 File Offset: 0x00017EB8
    //private void SaveMaterialInfo()
    //{
    //	if (this.ArtResInfoList.Count <= 0)
    //	{
    //		return;
    //	}
    //	string path = Application.dataPath + "/Resources/conf/res/materialInfo.txt";
    //	FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
    //	StreamWriter streamWriter = new StreamWriter(fileStream);
    //	foreach (BaseArtResInfo baseArtResInfo in this.ArtResInfoList)
    //	{
    //		if (baseArtResInfo != null)
    //		{
    //			if (baseArtResInfo.ID >= 2000000 && baseArtResInfo.ID < 3000000)
    //			{
    //				MaterialInfo materialInfo = baseArtResInfo as MaterialInfo;
    //				string text = string.Concat(new string[]
    //				{
    //					baseArtResInfo.ID.ToString(),
    //					"\t",
    //					((int)baseArtResInfo.ResType).ToString(),
    //					"\t",
    //					baseArtResInfo.Name,
    //					"\t",
    //					baseArtResInfo.Path,
    //					"\t",
    //					materialInfo.TexList.Count.ToString()
    //				});
    //				for (int i = 0; i < materialInfo.TexList.Count; i++)
    //				{
    //					string text2 = text;
    //					text = string.Concat(new object[]
    //					{
    //						text2,
    //						"\t",
    //						materialInfo.TexList[i].ID,
    //						"\t",
    //						materialInfo.TexList[i].NameInShader
    //					});
    //				}
    //				streamWriter.WriteLine(text);
    //			}
    //		}
    //	}
    //	streamWriter.Close();
    //	fileStream.Close();
    //}
}
