using System;
using UnityEngine;

/// <summary>
/// 切换场景
/// </summary>
public class SM_SwitchScene
{

	public void Exec(int par)
	{
		//if (GUIControl.OpeText != null && GUIControl.OpeText.activeSelf)
		//{
		//	GUIControl.OpeText.SetActive(false);
		//}
		TeleportInfo teleportInfo = GameData.Instance.cacheData.getTeleportInfo(par);
		FanrenSceneManager.currentTeleport = teleportInfo;
		SceneInfo sceneInfo = GameData.Instance.cacheData.getSceneInfo(teleportInfo.targetSceneId);
		KeyManager.hotKeyEnabled = true;
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
