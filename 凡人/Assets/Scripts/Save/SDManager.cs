using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000184 RID: 388
public class SDManager
{
	// Token: 0x060007A1 RID: 1953 RVA: 0x0000739E File Offset: 0x0000559E
	static SDManager()
	{
		SDManager.SDSave.Reset();
		SDManager.LoadSaveInfo();
	}

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x060007A2 RID: 1954 RVA: 0x000073D7 File Offset: 0x000055D7
	// (set) Token: 0x060007A3 RID: 1955 RVA: 0x000073DE File Offset: 0x000055DE
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

	// Token: 0x060007A4 RID: 1956 RVA: 0x000073E6 File Offset: 0x000055E6
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

	// Token: 0x060007A6 RID: 1958 RVA: 0x0003A08C File Offset: 0x0003828C
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

	// Token: 0x060007A7 RID: 1959 RVA: 0x0003A124 File Offset: 0x00038324
	public static void SetRoleDate()
	{
		//if (SceneManager.RoleMan == null)
		//{
		//	return;
		//}
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

	// Token: 0x060007A8 RID: 1960 RVA: 0x0003A250 File Offset: 0x00038450
	public static void AddCurSceneDate()
	{
		//SaveData.SDSceneDate curSceneDate = SaveData.SDSceneDate.GetCurSceneDate();
		//if (curSceneDate == null)
		//{
		//	Debug.LogWarning(DU.Warning(new object[]
		//	{
		//		"SDManager.AddCurSceneDate "
		//	}));
		//	return;
		//}
		SaveData.SDSceneDate sdsceneDate = null;
		//if (curSceneDate.SceneName.Length != 0)
		//{
		//	sdsceneDate = SDManager.GetSceneDate(curSceneDate.SceneName);
		//}
		//if (sdsceneDate != null)
		//{
		//	SDManager.SDSave.SaveDateGame.SceneList.Remove(sdsceneDate);
		//}
		//SDManager.SDSave.SaveDateGame.SceneList.Add(curSceneDate);
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x000073ED File Offset: 0x000055ED
	public static void Clear()
	{
		SDManager.SDSave.SaveDateGame.SceneList.Clear();
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x00007403 File Offset: 0x00005603
	public static SaveData.SDSceneDate GetCurSceneDate()
	{
		return SDManager.GetSceneDate(Application.loadedLevelName);
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x0003A2D4 File Offset: 0x000384D4
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

	// Token: 0x060007AD RID: 1965 RVA: 0x0003A3C0 File Offset: 0x000385C0
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
				//if (text == SaveLoadManager.GetFileName(tagSL))
				//{
				//	SaveData saveData = SaveLoadManager.ReadSaveFile(fileInfo.Name) as SaveData;
				//	if (saveData == null)
				//	{
				//		Debug.LogWarning(DU.Warning(new object[]
				//		{
				//			"Load Err:",
				//			text
				//		}));
				//	}
				//	else
				//	{
				//		if (Config.DEBUG)
				//		{
				//			SingletonMono<TestSaveLoad>.GetInstance().ResetData(tagSL, saveData);
				//		}
				//		SaveInfo item = new SaveInfo(saveData.SaveDateInfo, saveData.SaveDateBitmap);
				//		SDManager.m_saveInfoList.Add(item);
				//	}
				//}
			}
		}
	}

	// Token: 0x04000675 RID: 1653
	private static string SAVEINFO_FILE_NAME = "SaveInfo.ini";

	// Token: 0x04000676 RID: 1654
	public static List<SaveInfo> m_saveInfoList = new List<SaveInfo>();

	// Token: 0x04000677 RID: 1655
	public static SaveData m_SDSave = new SaveData();

	// Token: 0x04000678 RID: 1656
	public static List<string> SaveFileList = new List<string>();
}
