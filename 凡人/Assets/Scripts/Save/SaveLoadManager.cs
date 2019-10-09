using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class SaveLoadManager
{

    //	// Token: 0x040006C8 RID: 1736
    //	public const string EncryptKey = "";

    	public static string DIR_PATH = Application.dataPath + "/Save/";

    //	// Token: 0x040006CA RID: 1738
    //	private static object SaveLoadLock = new object();

    //	// Token: 0x040006CB RID: 1739
    //	//private static DES desObj = new DES();

    //	// Token: 0x040006CC RID: 1740
    //	private static bool m_bKey = false;

    [Serializable]
    public enum tagSL
    {
        // Token: 0x040006CF RID: 1743
        Save_Auto,
        // Token: 0x040006D0 RID: 1744
        Save_One,
        // Token: 0x040006D1 RID: 1745
        Save_Two,
        // Token: 0x040006D2 RID: 1746
        Save_Three,
        // Token: 0x040006D3 RID: 1747
        Save_Four,
        // Token: 0x040006D4 RID: 1748
        Save_Five,
        // Token: 0x040006D5 RID: 1749
        Load_Auto = 10,
        // Token: 0x040006D6 RID: 1750
        Load_One,
        // Token: 0x040006D7 RID: 1751
        Load_Two,
        // Token: 0x040006D8 RID: 1752
        Load_Three,
        // Token: 0x040006D9 RID: 1753
        Load_Four,
        // Token: 0x040006DA RID: 1754
        Load_Five,
        // Token: 0x040006DB RID: 1755
        Del_Auto = 20,
        // Token: 0x040006DC RID: 1756
        Del_One,
        // Token: 0x040006DD RID: 1757
        Del_Two,
        // Token: 0x040006DE RID: 1758
        Del_Three,
        // Token: 0x040006DF RID: 1759
        Del_Four,
        // Token: 0x040006E0 RID: 1760
        Del_Five,
        // Token: 0x040006E1 RID: 1761
        NONE = -1
    }

    //	// Token: 0x060007EE RID: 2030 RVA: 0x00007632 File Offset: 0x00005832
    //	public static bool IsCanMudalSave()
    //	{
    //		return SaveLoadManager.m_bKey || GameData.Instance.cacheData.getSceneInfo(Application.loadedLevelName).isCanMudalSave;
    //	}

    //	// Token: 0x060007EF RID: 2031 RVA: 0x00007659 File Offset: 0x00005859
    //	public static void SetKey(bool bo)
    //	{
    //		SaveLoadManager.m_bKey = bo;
    //	}

    //	// Token: 0x060007F0 RID: 2032 RVA: 0x00007661 File Offset: 0x00005861
    //	public static bool IsHaveSavedata()
    //	{
    //		return SDManager.m_saveInfoList.Count > 0;
    //	}

    //	private static void CreateSaveFold()
    //	{
    //		if (!Directory.Exists(SaveLoadManager.DIR_PATH))
    //		{
    //			Directory.CreateDirectory(SaveLoadManager.DIR_PATH);
    //		}
    //	}

    public static SaveLoadManager.tagSL SystemtagToSL(SystemTag st)
    {
        if (st == SystemTag.SAVE_CHILD_AUTO)
        {
            return SaveLoadManager.tagSL.Save_Auto;
        }
        if (st == SystemTag.SAVE_CHILD_ONE)
        {
            return SaveLoadManager.tagSL.Save_One;
        }
        if (st == SystemTag.SAVE_CHILD_TWO)
        {
            return SaveLoadManager.tagSL.Save_Two;
        }
        if (st == SystemTag.SAVE_CHILD_THREE)
        {
            return SaveLoadManager.tagSL.Save_Three;
        }
        if (st == SystemTag.SAVE_CHILD_FOUR)
        {
            return SaveLoadManager.tagSL.Save_Four;
        }
        if (st == SystemTag.LOAD_CHILD_AUTO)
        {
            return SaveLoadManager.tagSL.Load_Auto;
        }
        if (st == SystemTag.LOAD_CHILD_ONE)
        {
            return SaveLoadManager.tagSL.Load_One;
        }
        if (st == SystemTag.LOAD_CHILD_TWO)
        {
            return SaveLoadManager.tagSL.Load_Two;
        }
        if (st == SystemTag.LOAD_CHILD_THREE)
        {
            return SaveLoadManager.tagSL.Load_Three;
        }
        if (st == SystemTag.LOAD_CHILD_FOUR)
        {
            return SaveLoadManager.tagSL.Load_Four;
        }
        return SaveLoadManager.tagSL.NONE;
    }

    //	// Token: 0x060007F3 RID: 2035 RVA: 0x0000768C File Offset: 0x0000588C
    //	public static string GetFileName(SaveLoadManager.tagSL st)
    //	{
    //		return "Data" + (int)st + ".sav";
    //	}

    //	// Token: 0x060007F4 RID: 2036 RVA: 0x0003C318 File Offset: 0x0003A518
    //	public static SaveInfo Save(SaveLoadManager.tagSL st)
    //	{
    //		int num = (int)st;
    //		if (num >= 10 && num < 20)
    //		{
    //			num -= 10;
    //			st = (SaveLoadManager.tagSL)num;
    //		}
    //		if (st == SaveLoadManager.tagSL.Save_Auto)
    //		{
    //			Singleton<EZGUIManager>.GetInstance().GetGUI<Tipplane>().SaveTip();
    //		}
    //		ModBuffProperty modBuffProperty = Player.Instance.GetModule(MODULE_TYPE.MT_BUFF) as ModBuffProperty;
    //		modBuffProperty.DelAllBuff();
    //		string fileName = SaveLoadManager.GetFileName(st);
    //		SaveData saveDate = SaveData.GetSaveDate(st);
    //		SaveInfo saveInfo = null;
    //		if (SaveLoadManager.WriteSaveFile(fileName, saveDate))
    //		{
    //			SDManager.m_saveInfoList.Remove(SDManager.GetSaveInfo(st));
    //			saveInfo = new SaveInfo(saveDate.SaveDateInfo, saveDate.SaveDateBitmap);
    //			SDManager.m_saveInfoList.Add(saveInfo);
    //		}
    //		FantasyWorld.Instance.Assist.TimerMan.TimePause(false);
    //		TimeOutManager.SetTimeOut(Main.Instance.transform, 1f, delegate()
    //		{
    //			Main.Instance.GC();
    //		});
    //		SingletonMono<TestSaveLoad>.GetInstance().ResetData(st, saveDate);
    //		return saveInfo;
    //	}

    //	// Token: 0x060007F5 RID: 2037 RVA: 0x0003C410 File Offset: 0x0003A610
    //	public static bool Delete(SaveLoadManager.tagSL st)
    //	{
    //		return false;
    //	}

    //	// Token: 0x060007F6 RID: 2038 RVA: 0x0003C420 File Offset: 0x0003A620
    //	public static bool Load(SaveLoadManager.tagSL st)
    //	{
    //		int num = (int)st;
    //		if (num >= 0 && num < 10)
    //		{
    //			num += 10;
    //			st = (SaveLoadManager.tagSL)num;
    //		}
    //		SaveInfo saveInfo = SDManager.GetSaveInfo(st);
    //		if (saveInfo == null)
    //		{
    //			Debug.LogWarning(DU.Warning(new object[]
    //			{
    //				saveInfo
    //			}));
    //			return false;
    //		}
    //		SaveData saveData = SaveLoadManager.ReadSaveFile(SaveLoadManager.GetFileName(saveInfo.ShowIndex)) as SaveData;
    //		if (saveData == null)
    //		{
    //			return false;
    //		}
    //		SDManager.SDSave.Reset();
    //		SDManager.SDSave = saveData;
    //		SDManager.SDSave.BeLoaded = false;
    //		DynamicData.SetDate(SDManager.SDSave.SaveDateGame.MoiveInfoList);
    //		SceneManager.LoadLevel(saveData.SaveDateGame.CurSceneName, true, false, true);
    //		return true;
    //	}

    //	// Token: 0x060007F7 RID: 2039 RVA: 0x0003C4CC File Offset: 0x0003A6CC
    //	private static bool WriteSaveFile(string fileName, object obj)
    //	{
    //		SaveLoadManager.CreateSaveFold();
    //		string text = SaveLoadManager.DIR_PATH + "tempSave.save";
    //		fileName = SaveLoadManager.DIR_PATH + fileName;
    //		bool result = false;
    //		object saveLoadLock = SaveLoadManager.SaveLoadLock;
    //		lock (saveLoadLock)
    //		{
    //			Stream stream = null;
    //			try
    //			{
    //				stream = File.Open(text, FileMode.Create);
    //				BinaryFormatter binaryFormatter = new BinaryFormatter();
    //				binaryFormatter.Serialize(stream, obj);
    //				stream.Close();
    //				stream = null;
    //				result = true;
    //			}
    //			catch (Exception ex)
    //			{
    //				Debug.LogWarning(DU.Warning(new object[]
    //				{
    //					ex.Message
    //				}));
    //				Logger.LogError(new object[]
    //				{
    //					string.Concat(new string[]
    //					{
    //						"SaveLoadManager.WriteSaveFile():Faile to serialize object to file ",
    //						fileName,
    //						" (Reason: ",
    //						ex.ToString(),
    //						")"
    //					})
    //				});
    //				result = false;
    //			}
    //			finally
    //			{
    //				if (stream != null)
    //				{
    //					stream.Close();
    //				}
    //			}
    //			SaveLoadManager.desObj.EncryptFile(text, fileName);
    //			File.Delete(text);
    //		}
    //		return result;
    //	}

    //	// Token: 0x060007F8 RID: 2040 RVA: 0x0003C5E8 File Offset: 0x0003A7E8
    //	public static object ReadSaveFile(string fileName)
    //	{
    //		//string text = SaveLoadManager.DIR_PATH + "tempLoad.save";
    //		//fileName = SaveLoadManager.DIR_PATH + fileName;
    //		//object result = null;
    //		//object saveLoadLock = SaveLoadManager.SaveLoadLock;
    //		//lock (saveLoadLock)
    //		//{
    //		//	Stream stream = null;
    //		//	try
    //		//	{
    //		//		SaveLoadManager.desObj.DecryptFile(fileName, text);
    //		//		stream = File.Open(text, FileMode.Open, FileAccess.Read);
    //		//		BinaryFormatter binaryFormatter = new BinaryFormatter();
    //		//		object obj = binaryFormatter.Deserialize(stream);
    //		//		stream.Close();
    //		//		stream = null;
    //		//		result = obj;
    //		//	}
    //		//	catch (Exception ex)
    //		//	{
    //		//		Debug.LogWarning(DU.Warning(new object[]
    //		//		{
    //		//			"ReadSaveFile Fail:",
    //		//			fileName
    //		//		}));
    //		//		result = null;
    //		//	}
    //		//	finally
    //		//	{
    //		//		if (stream != null)
    //		//		{
    //		//			stream.Close();
    //		//		}
    //		//		if (File.Exists(text))
    //		//		{
    //		//			File.Delete(text);
    //		//		}
    //		//	}
    //		//}
    //		return result;
    //	}
}
