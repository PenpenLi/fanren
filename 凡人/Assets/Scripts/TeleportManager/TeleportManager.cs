using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 传送管理
/// </summary>
public class TeleportManager : MonoBehaviour
{
    private TeleportInfo teleportInfo;

    public static void InitTeleport(int sceneId)
	{
		List<TeleportInfo> teleports = GameData.Instance.cacheData.getTeleports(sceneId);
		foreach (TeleportInfo teleportInfo in teleports)
		{
			GameObject gameObject = ResourceLoader.Load(teleportInfo.path, typeof(GameObject)) as GameObject;
			//gameObject = (GameObject)LoadMachine.InstantiateObject(gameObject, new Vector3(teleportInfo.posX, teleportInfo.posY, teleportInfo.posZ), Quaternion.Euler(new Vector3(0f, teleportInfo.telRotY, 0f)));
			TeleportManager teleportManager = gameObject.AddComponent<TeleportManager>();
			teleportManager.teleportInfo = teleportInfo;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (this.teleportInfo == null)
			{
				return;
			}
            FanrenSceneManager.currentTeleport = this.teleportInfo;
			SceneInfo sceneInfo = GameData.Instance.cacheData.getSceneInfo(this.teleportInfo.targetSceneId);
			if (FanrenSceneManager.currScenenInfo != null && FanrenSceneManager.currScenenInfo.id == sceneInfo.id)
			{
                FanrenSceneManager.LoadLevel(sceneInfo.name, false, true, false);
			}
			else
			{
                FanrenSceneManager.LoadLevel(sceneInfo.name, true, true, false);
			}
		}
	}
}
