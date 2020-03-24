using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using YouYou;

/// <summary>
/// 存档读档管理
/// </summary>
public class SaveLoadManager : YouYouBaseComponent
{
    //	public const string EncryptKey = "";

    private static DES desObj = new DES();

    public static string DIR_PATH ;

    private static bool m_bKey = false;

    [Serializable]
    public enum tagSL
    {
        Save_Auto,
        Save_One,
        Save_Two,
        Save_Three,
        Save_Four,
        Save_Five,
        Load_Auto = 10,
        Load_One,
        Load_Two,
        Load_Three,
        Load_Four,
        Load_Five,
        Del_Auto = 20,
        Del_One,
        Del_Two,
        Del_Three,
        Del_Four,
        Del_Five,
        NONE = -1
    }

    protected override void OnAwake()
    {
        base.OnAwake();
        DIR_PATH = Application.dataPath + "/Save/";
    }

    //	public static bool IsCanMudalSave()
    //	{
    //		return SaveLoadManager.m_bKey || GameData.Instance.cacheData.getSceneInfo(Application.loadedLevelName).isCanMudalSave;
    //	}

    //	public static void SetKey(bool bo)
    //	{
    //		SaveLoadManager.m_bKey = bo;
    //	}

    //	// Token: 0x060007F0 RID: 2032 RVA: 0x00024568 File Offset: 0x00022768
    //	public static bool IsHaveSavedata()
    //	{
    //		return SDManager.m_saveInfoList.Count > 0;
    //	}

    private static void CreateSaveFold()
    {
        if (!Directory.Exists(SaveLoadManager.DIR_PATH))
        {
            Directory.CreateDirectory(SaveLoadManager.DIR_PATH);
        }
    }

    //	// Token: 0x060007F2 RID: 2034 RVA: 0x00024594 File Offset: 0x00022794
    //	public static SaveLoadManager.tagSL SystemtagToSL(SystemTag st)
    //	{
    //		if (st == SystemTag.SAVE_CHILD_AUTO)
    //		{
    //			return SaveLoadManager.tagSL.Save_Auto;
    //		}
    //		if (st == SystemTag.SAVE_CHILD_ONE)
    //		{
    //			return SaveLoadManager.tagSL.Save_One;
    //		}
    //		if (st == SystemTag.SAVE_CHILD_TWO)
    //		{
    //			return SaveLoadManager.tagSL.Save_Two;
    //		}
    //		if (st == SystemTag.SAVE_CHILD_THREE)
    //		{
    //			return SaveLoadManager.tagSL.Save_Three;
    //		}
    //		if (st == SystemTag.SAVE_CHILD_FOUR)
    //		{
    //			return SaveLoadManager.tagSL.Save_Four;
    //		}
    //		if (st == SystemTag.LOAD_CHILD_AUTO)
    //		{
    //			return SaveLoadManager.tagSL.Load_Auto;
    //		}
    //		if (st == SystemTag.LOAD_CHILD_ONE)
    //		{
    //			return SaveLoadManager.tagSL.Load_One;
    //		}
    //		if (st == SystemTag.LOAD_CHILD_TWO)
    //		{
    //			return SaveLoadManager.tagSL.Load_Two;
    //		}
    //		if (st == SystemTag.LOAD_CHILD_THREE)
    //		{
    //			return SaveLoadManager.tagSL.Load_Three;
    //		}
    //		if (st == SystemTag.LOAD_CHILD_FOUR)
    //		{
    //			return SaveLoadManager.tagSL.Load_Four;
    //		}
    //		return SaveLoadManager.tagSL.NONE;
    //	}

    public static string GetFileName(SaveLoadManager.tagSL st)
    {
        return "Data" + (int)st + ".sav";
    }

    /// <summary>
    /// 存档
    /// </summary>
    /// <param name="st"></param>
    /// <returns></returns>
    public static SaveInfo Save(SaveLoadManager.tagSL st)
    {
        int num = (int)st;
        if (num >= 10 && num < 20)
        {
            num -= 10;
            st = (SaveLoadManager.tagSL)num;
        }
        //ModBuffProperty modBuffProperty = Player.Instance.GetModule(MODULE_TYPE.MT_BUFF) as ModBuffProperty;
        //modBuffProperty.DelAllBuff();//去除BUff

        string fileName = SaveLoadManager.GetFileName(st);//文件名  
        SaveData saveDate = SaveData.GetSaveDate(st);
        SaveInfo saveInfo = null;
        //if (SaveLoadManager.WriteSaveFile(fileName, saveDate))
        //{
        //    SDManager.m_saveInfoList.Remove(SDManager.GetSaveInfo(st));
        //    saveInfo = new SaveInfo(saveDate.SaveDateInfo, saveDate.SaveDateBitmap);
        //    SDManager.m_saveInfoList.Add(saveInfo);
        //}
        //FantasyWorld.Instance.Assist.TimerMan.TimePause(false);
        //TimeOutManager.SetTimeOut(Main.Instance.transform, 1f, delegate ()
        //{
        //    Main.Instance.GC();
        //});
        //SingletonMono<TestSaveLoad>.GetInstance().ResetData(st, saveDate);
        return saveInfo;
    }

    //	public static bool Delete(SaveLoadManager.tagSL st)
    //	{
    //		return false;
    //	}

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

    //	// Token: 0x060007F7 RID: 2039 RVA: 0x000247D4 File Offset: 0x000229D4
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

    /// <summary>
    /// 读存档文件
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static object ReadSaveFile(string fileName)
    {
        string text = SaveLoadManager.DIR_PATH + "tempLoad.save";//临时读取的文件
        fileName = SaveLoadManager.DIR_PATH + fileName;
        object result = null;

        object saveLoadLock = new object();
        lock (saveLoadLock)
        {
            Stream stream = null;
            try
            {
                SaveLoadManager.desObj.DecryptFile(fileName, text);
                stream = File.Open(text, FileMode.Open, FileAccess.Read);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Deserialize(stream);//反序列化
                //object obj = binaryFormatter.Deserialize(stream);//反序列化
                //stream.Close();
                //stream = null;
                //result = obj;
            }
            catch (Exception ex)
            {
                Debug.LogWarning("ReadSaveFile Fail:" + fileName);
                result = null;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (File.Exists(text))
                {
                    File.Delete(text);
                }
            }
        }
        return result;
    }

    public override void Shutdown()
    {
        
    }
}
