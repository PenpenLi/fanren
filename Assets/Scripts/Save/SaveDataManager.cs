using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using YouYou;

/// <summary>
/// 存档数据管理
/// </summary>
public class SaveDataManager 
{
    //	private static string SAVEINFO_FILE_NAME = "SaveInfo.ini";

    public List<SaveInfo> m_saveInfoList = new List<SaveInfo>();

    public SaveData m_SDSave = new SaveData();

    //	public static List<string> SaveFileList = new List<string>();

    /// <summary>
    /// 存档路径
    /// </summary>
    public string DIR_PATH ;

    public SaveData SDSave
    {
        get
        {
            return m_SDSave;
        }
        set
        {
            m_SDSave = value;
        }
    }

    //	public static SaveInfo GetAutoSaveInfo()
    //	{
    //		foreach (SaveInfo saveInfo in SDManager.m_saveInfoList)
    //		{
    //			if (saveInfo.ShowIndex == SaveLoadManager.tagSL.Save_Auto)
    //			{
    //				return saveInfo;
    //			}
    //		}
    //		return null;
    //	}

    //	public static SaveInfo GetSaveInfo(SaveLoadManager.tagSL st)
    //	{
    //		int num = (int)st;
    //		if (num >= 10 && num < 20)
    //		{
    //			num -= 10;
    //			st = (SaveLoadManager.tagSL)num;
    //		}
    //		else if (num >= 20)
    //		{
    //			num -= 20;
    //			st = (SaveLoadManager.tagSL)num;
    //		}
    //		foreach (SaveInfo saveInfo in SDManager.m_saveInfoList)
    //		{
    //			if (saveInfo.ShowIndex == st)
    //			{
    //				return saveInfo;
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x060007A7 RID: 1959 RVA: 0x00021F3C File Offset: 0x0002013C
    //	public static void SetRoleDate()
    //	{
    //		if (SceneManager.RoleMan == null)
    //		{
    //			return;
    //		}
    //		SDManager.SDSave.SaveDateGame.PlayerList.Clear();
    //		bool flag = false;
    //		for (int i = 0; i < SceneManager.RoleMan.RoleObjList.Count; i++)
    //		{
    //			Role role = SceneManager.RoleMan.RoleObjList[i];
    //			if (role == null && role._roleType == ROLE_TYPE.RT_PLAYER)
    //			{
    //				Debug.LogWarning(DU.Warning(new object[]
    //				{
    //					"role is null"
    //				}));
    //			}
    //			if (role != null && role._roleType == ROLE_TYPE.RT_PLAYER)
    //			{
    //				Player player = role as Player;
    //				if (player == null)
    //				{
    //					Logger.Log(new object[]
    //					{
    //						"role is not player"
    //					});
    //				}
    //				SaveData.SDPlayerDate playerDate = SaveData.SDPlayerDate.GetPlayerDate(player);
    //				if (playerDate == null)
    //				{
    //					Debug.LogWarning(DU.Warning(new object[]
    //					{
    //						"SetRoleDate"
    //					}));
    //				}
    //				SDManager.SDSave.SaveDateGame.PlayerList.Add(playerDate);
    //				flag = true;
    //			}
    //		}
    //		if (!flag)
    //		{
    //			Debug.LogWarning(DU.Warning(new object[]
    //			{
    //				"Not find ",
    //				Application.loadedLevelName
    //			}));
    //		}
    //	}

    //	// Token: 0x060007A8 RID: 1960 RVA: 0x00022068 File Offset: 0x00020268
    //	public static void AddCurSceneDate()
    //	{
    //		SaveData.SDSceneDate curSceneDate = SaveData.SDSceneDate.GetCurSceneDate();
    //		if (curSceneDate == null)
    //		{
    //			Debug.LogWarning(DU.Warning(new object[]
    //			{
    //				"SDManager.AddCurSceneDate "
    //			}));
    //			return;
    //		}
    //		SaveData.SDSceneDate sdsceneDate = null;
    //		if (curSceneDate.SceneName.Length != 0)
    //		{
    //			sdsceneDate = SDManager.GetSceneDate(curSceneDate.SceneName);
    //		}
    //		if (sdsceneDate != null)
    //		{
    //			SDManager.SDSave.SaveDateGame.SceneList.Remove(sdsceneDate);
    //		}
    //		SDManager.SDSave.SaveDateGame.SceneList.Add(curSceneDate);
    //	}

    //	// Token: 0x060007A9 RID: 1961 RVA: 0x000220EC File Offset: 0x000202EC
    //	public static void Clear()
    //	{
    //		SDManager.SDSave.SaveDateGame.SceneList.Clear();
    //	}

    //	// Token: 0x060007AA RID: 1962 RVA: 0x00022104 File Offset: 0x00020304
    //	public static SaveData.SDSceneDate GetCurSceneDate()
    //	{
    //		return SDManager.GetSceneDate(Application.loadedLevelName);
    //	}

    //	// Token: 0x060007AB RID: 1963 RVA: 0x00022110 File Offset: 0x00020310
    //	public static SaveData.SDSceneDate GetSceneDate(string sceneName)
    //	{
    //		foreach (SaveData.SDSceneDate sdsceneDate in SDManager.SDSave.SaveDateGame.SceneList)
    //		{
    //			if (sdsceneDate != null)
    //			{
    //				if (sdsceneDate.SceneName == sceneName)
    //				{
    //					return sdsceneDate;
    //				}
    //			}
    //		}
    //		return null;
    //	}

    //	// Token: 0x060007AC RID: 1964 RVA: 0x000221A0 File Offset: 0x000203A0
    //	public static void GetAllSaveFileName()
    //	{
    //		SDManager.SaveFileList.Clear();
    //		DirectoryInfo directoryInfo = new DirectoryInfo(SDManager.GetSaveDir());
    //		FileInfo[] files = directoryInfo.GetFiles();
    //		foreach (FileInfo fileInfo in files)
    //		{
    //			SDManager.SaveFileList.Add(SDManager.GetSaveDir() + "/" + fileInfo.Name);
    //		}
    //	}

    /// <summary>
    /// 加载存档信息
    /// </summary>
    public void LoadSaveInfo()
    {
        DIR_PATH = Application.dataPath + "/Save/";
        m_saveInfoList.Clear();
        if (!Directory.Exists(DIR_PATH))
        {
            Directory.CreateDirectory(DIR_PATH);
        }
        DirectoryInfo directoryInfo = new DirectoryInfo(DIR_PATH);
        foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        {
            string text = fileInfo.Name.Trim();
            for (SaveLoadManager.tagSL tagSL = SaveLoadManager.tagSL.Save_Auto; tagSL < SaveLoadManager.tagSL.Save_Five; tagSL++)
            {
                if (text == GameEntry.SaveLoad.GetFileName(tagSL))
                {
                    SaveData saveData = GameEntry.SaveLoad.ReadSaveFile(fileInfo.Name) as SaveData;
                    if (saveData == null)
                    {
                        Debug.LogWarning("Load Err:"+text);
                    }
                    else
                    {
                        SaveInfo item = new SaveInfo(saveData.SaveDateInfo, saveData.SaveDateBitmap);
                        m_saveInfoList.Add(item);
                    }
                }
            }
        }
    }
}
