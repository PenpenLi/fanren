using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 存档数据管理
/// </summary>
public class SDManager
{
    private static string SAVEINFO_FILE_NAME = "SaveInfo.ini";

    public static List<SaveInfo> m_saveInfoList = new List<SaveInfo>();

    public static SaveData m_SDSave = new SaveData();

    public static List<string> SaveFileList = new List<string>();

    static SDManager()
	{
		SDManager.SDSave.Reset();
		SDManager.LoadSaveInfo();
	}

    /// <summary>
    /// 存档数据
    /// </summary>
	public static SaveData SDSave
	{
		get
		{
			return SDManager.m_SDSave;
		}
		set
		{
			SDManager.m_SDSave = value;
		}
	}

	public static string GetSaveDir()
	{
		return SaveLoadManager.DIR_PATH;
	}

	public static SaveInfo GetAutoSaveInfo()
	{
		foreach (SaveInfo saveInfo in SDManager.m_saveInfoList)
		{
			if (saveInfo.ShowIndex == SaveLoadManager.tagSL.Save_Auto)
			{
				return saveInfo;
			}
		}
		return null;
	}

	public static SaveInfo GetSaveInfo(SaveLoadManager.tagSL st)
	{
		int num = (int)st;
		if (num >= 10 && num < 20)
		{
			num -= 10;
			st = (SaveLoadManager.tagSL)num;
		}
		else if (num >= 20)
		{
			num -= 20;
			st = (SaveLoadManager.tagSL)num;
		}
		foreach (SaveInfo saveInfo in SDManager.m_saveInfoList)
		{
			if (saveInfo.ShowIndex == st)
			{
				return saveInfo;
			}
		}
		return null;
	}

    /// <summary>
    /// 设置角色数据
    /// </summary>
	public static void SetRoleDate()
	{
        if (FanrenSceneManager.RoleMan == null)
        {
            return;
        }
        //SDManager.SDSave.SaveDateGame.PlayerList.Clear();
        //bool flag = false;
        //for (int i = 0; i < SceneManager.RoleMan.RoleObjList.Count; i++)
        //{
        //	Role role = SceneManager.RoleMan.RoleObjList[i];
        //	if (role == null && role._roleType == ROLE_TYPE.RT_PLAYER)
        //	{
        //		Debug.LogWarning(DU.Warning(new object[]
        //		{
        //			"role is null"
        //		}));
        //	}
        //	if (role != null && role._roleType == ROLE_TYPE.RT_PLAYER)
        //	{
        //		Player player = role as Player;
        //		if (player == null)
        //		{
        //			Logger.Log(new object[]
        //			{
        //				"role is not player"
        //			});
        //		}
        //		SaveData.SDPlayerDate playerDate = SaveData.SDPlayerDate.GetPlayerDate(player);
        //		if (playerDate == null)
        //		{
        //			Debug.LogWarning(DU.Warning(new object[]
        //			{
        //				"SetRoleDate"
        //			}));
        //		}
        //		SDManager.SDSave.SaveDateGame.PlayerList.Add(playerDate);
        //		flag = true;
        //	}
        //}
        //if (!flag)
        //{
        //	Debug.LogWarning(DU.Warning(new object[]
        //	{
        //		"Not find ",
        //		Application.loadedLevelName
        //	}));
        //}
    }

    /// <summary>
    /// 添加当前场景数据
    /// </summary>
	public static void AddCurSceneDate()
	{
		SaveData.SDSceneDate curSceneDate = SaveData.SDSceneDate.GetCurSceneDate();
        if (curSceneDate == null)
        {
            Debug.LogWarning("SDManager.AddCurSceneDate");
            return;
        }
        SaveData.SDSceneDate sdsceneDate = null;
        if (curSceneDate.SceneName.Length != 0)
        {
            sdsceneDate = SDManager.GetSceneDate(curSceneDate.SceneName);
        }
        if (sdsceneDate != null)
        {
            SDManager.SDSave.SaveDateGame.SceneList.Remove(sdsceneDate);
        }
        SDManager.SDSave.SaveDateGame.SceneList.Add(curSceneDate);
    }

	public static void Clear()
	{
		SDManager.SDSave.SaveDateGame.SceneList.Clear();
	}

    /// <summary>
    /// 获得当前场景数据
    /// </summary>
    /// <returns></returns>
	public static SaveData.SDSceneDate GetCurSceneDate()
	{
		return SDManager.GetSceneDate(SceneManager.GetActiveScene().name);
	}

	public static SaveData.SDSceneDate GetSceneDate(string sceneName)
	{
		foreach (SaveData.SDSceneDate sdsceneDate in SDManager.SDSave.SaveDateGame.SceneList)
		{
			if (sdsceneDate != null)
			{
				if (sdsceneDate.SceneName == sceneName)
				{
					return sdsceneDate;
				}
			}
		}
		return null;
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x0003A358 File Offset: 0x00038558
	public static void GetAllSaveFileName()
	{
		SDManager.SaveFileList.Clear();
		DirectoryInfo directoryInfo = new DirectoryInfo(SDManager.GetSaveDir());
		FileInfo[] files = directoryInfo.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			SDManager.SaveFileList.Add(SDManager.GetSaveDir() + "/" + fileInfo.Name);
		}
	}

    /// <summary>
    /// 读取存档信息
    /// </summary>
	public static void LoadSaveInfo()
	{
		SDManager.m_saveInfoList.Clear();
		if (!Directory.Exists(SDManager.GetSaveDir()))
		{
			Directory.CreateDirectory(SDManager.GetSaveDir());
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(SDManager.GetSaveDir());
        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            string text = fileInfo.Name.Trim();          
            for (SaveLoadManager.tagSL tagSL = SaveLoadManager.tagSL.Save_Auto; tagSL < SaveLoadManager.tagSL.Save_Five; tagSL++)
            {
                if (text == SaveLoadManager.GetFileName(tagSL))
                {
                    SaveData saveData = SaveLoadManager.ReadSaveFile(fileInfo.Name) as SaveData;
                    if (saveData == null)
                    {
                        Debug.LogWarning("Load Err:" + text);
                    }
                    else
                    {
                        SaveInfo item = new SaveInfo(saveData.SaveDateInfo, saveData.SaveDateBitmap);
                        SDManager.m_saveInfoList.Add(item);
                    }
                }
            }
        }
    }
}
