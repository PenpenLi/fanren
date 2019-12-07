using System;
using System.Collections;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

/// <summary>
/// 缓存数据
/// </summary>
public class CacheData
{
    public static char[] separator = new char[]
    {
        '\t'
    };

    private ArrayList sceneList = new ArrayList();

    private ArrayList teleportList = new ArrayList();

    private ArrayList bgSoundList = new ArrayList();

    public ArrayList SceneList
	{
		get
		{
			return this.sceneList;
		}
		set
		{
			this.sceneList = value;
		}
	}

	public void initialize()
	{
		this.readSceneList();
		this.readTeleportList();
		this.readBgSoundList();
	}

	private void readSceneList()
	{
		this.sceneList.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets("Scene");
		foreach (string text in list)
		{
			if (text.Length != 0)
			{
				string[] array = text.Split(CacheData.separator);
				if (array.Length < 12)
				{
                    Debug.LogError("This line: \"" + text + "\" has some error format!");
				}
				else
				{
					int num = 0;
					SceneInfo sceneInfo = new SceneInfo();
					sceneInfo.id = Convert.ToInt32(array[num]);
					num++;
					sceneInfo.name = Convert.ToString(array[num]);
					num++;
					sceneInfo.mapName = Convert.ToString(array[num]);
					num++;
					sceneInfo.mapPath = Convert.ToString(array[num]);
					num++;
					sceneInfo.mapBackPath = Convert.ToString(array[num]);
					num++;
					sceneInfo.bgSoundId = Convert.ToInt32(array[num]);
					num++;
					sceneInfo.posX = Convert.ToSingle(array[num]);
					num++;
					sceneInfo.posY = Convert.ToSingle(array[num]);
					num++;
					sceneInfo.posZ = Convert.ToSingle(array[num]);
					num++;
					sceneInfo.rotY = Convert.ToSingle(array[num]);
					num++;
					sceneInfo.revive_x = Convert.ToSingle(array[num]);
					num++;
					sceneInfo.revive_y = Convert.ToSingle(array[num]);
					num++;
					sceneInfo.revive_z = Convert.ToSingle(array[num]);
					num++;
					sceneInfo.revive_rot_y = Convert.ToSingle(array[num]);
					num++;
					sceneInfo.scriptModId = Convert.ToInt32(array[num]);
					num++;
					sceneInfo.isCanMudalSave = Convert.ToBoolean(Convert.ToInt32(array[num]));
					num++;
					if (!this.sceneList.Contains(sceneInfo))
					{
						this.sceneList.Add(sceneInfo);
					}
				}
			}
		}
	}

	public SceneInfo getSceneInfo(string sceneName)
	{
		foreach (object obj in this.sceneList)
		{
			SceneInfo sceneInfo = (SceneInfo)obj;
			if (sceneInfo.name == sceneName)
			{
				return sceneInfo;
			}
		}
		return null;
	}

	public SceneInfo getSceneInfo(int sceneId)
	{
		foreach (object obj in this.sceneList)
		{
			SceneInfo sceneInfo = (SceneInfo)obj;
			if (sceneInfo.id == sceneId)
			{
				return sceneInfo;
			}
		}
		return null;
	}

	private void readTeleportList()
	{
		this.teleportList.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets("Teleports");
		foreach (string text in list)
		{
			if (text.Length != 0)
			{
				string[] array = text.Split(CacheData.separator);
				if (array.Length < 11)
				{
                    Debug.LogError("This line: \"" + text + "\" has some error format!");
				}
				else
				{
					int num = 0;
					TeleportInfo teleportInfo = new TeleportInfo();
					teleportInfo.id = Convert.ToInt32(array[num]);
					num++;
					teleportInfo.name = Convert.ToString(array[num]);
					num++;
					teleportInfo.currentSceneId = Convert.ToInt32(array[num]);
					num++;
					teleportInfo.posX = Convert.ToSingle(array[num]);
					num++;
					teleportInfo.posY = Convert.ToSingle(array[num]);
					num++;
					teleportInfo.posZ = Convert.ToSingle(array[num]);
					num++;
					teleportInfo.telRotY = Convert.ToSingle(array[num]);
					num++;
					teleportInfo.path = Convert.ToString(array[num]);
					num++;
					teleportInfo.targetSceneId = Convert.ToInt32(array[num]);
					num++;
					teleportInfo.playerX = Convert.ToSingle(array[num]);
					num++;
					teleportInfo.playerY = Convert.ToSingle(array[num]);
					num++;
					teleportInfo.playerZ = Convert.ToSingle(array[num]);
					num++;
					teleportInfo.rotY = Convert.ToSingle(array[num]);
					num++;
					if (!this.teleportList.Contains(teleportInfo))
					{
						this.teleportList.Add(teleportInfo);
					}
				}
			}
		}
	}

	public List<TeleportInfo> getTeleports(int sceneId)
	{
		List<TeleportInfo> list = new List<TeleportInfo>();
		foreach (object obj in this.teleportList)
		{
			TeleportInfo teleportInfo = (TeleportInfo)obj;
			if (teleportInfo.currentSceneId == sceneId)
			{
				list.Add(teleportInfo);
			}
		}
		return list;
	}

	public TeleportInfo getTeleportInfo(int id)
	{
		foreach (object obj in this.teleportList)
		{
			TeleportInfo teleportInfo = (TeleportInfo)obj;
			if (teleportInfo.id == id)
			{
				return teleportInfo;
			}
		}
		return null;
	}

    private void readBgSoundList()
    {
        this.bgSoundList.Clear();
        List<string> list = RoleBaseFun.LoadConfInAssets("BgSound");
        foreach (string text in list)
        {
            if (text.Length != 0)
            {
                string[] array = text.Split(CacheData.separator);
                if (array.Length < 7)
                {
                    Debug.LogWarning( "This line: \"" + text + "\" has some error format!");
                }
                else
                {
                    int num = 0;
                    BgSoundInfo bgSoundInfo = new BgSoundInfo();
                    bgSoundInfo.sceneId = Convert.ToInt32(array[num]);
                    num++;
                    bgSoundInfo.soundId = Convert.ToInt32(array[num]);
                    num++;
                    bgSoundInfo.pointX = Convert.ToSingle(array[num]);
                    num++;
                    bgSoundInfo.pointY = Convert.ToSingle(array[num]);
                    num++;
                    bgSoundInfo.pointZ = Convert.ToSingle(array[num]);
                    num++;
                    bgSoundInfo.minDistance = Convert.ToSingle(array[num]);
                    num++;
                    bgSoundInfo.maxDistance = Convert.ToSingle(array[num]);
                    num++;
                    if (!this.bgSoundList.Contains(bgSoundInfo))
                    {
                        this.bgSoundList.Add(bgSoundInfo);
                    }
                }
            }
        }
    }

    public List<BgSoundInfo> GetBgSoundInfoBySceneId(int sceneId)
    {
        List<BgSoundInfo> list = new List<BgSoundInfo>();
        foreach (object obj in this.bgSoundList)
        {
            BgSoundInfo bgSoundInfo = (BgSoundInfo)obj;
            if (bgSoundInfo.sceneId == sceneId)
            {
                list.Add(bgSoundInfo);
            }
        }
        return list;
    }
}
