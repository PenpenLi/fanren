using System;
using UnityEngine;

/// <summary>
/// 切换场景
/// </summary>
public class SM_SwitchScene
{
	public void Exec(int par)
	{
		//if (GUIControl.OpeText != null && GUIControl.OpeText.activeSelf)//关闭文字
		//{
		//	GUIControl.OpeText.SetActive(false);
		//}
		TeleportInfo teleportInfo = GameData.Instance.cacheData.getTeleportInfo(par);//获得传送信息
		FanrenSceneManager.currentTeleport = teleportInfo;
		SceneInfo sceneInfo = GameData.Instance.cacheData.getSceneInfo(teleportInfo.targetSceneId);
		KeyManager.hotKeyEnabled = true;
        if (FanrenSceneManager.currScenenInfo != null && FanrenSceneManager.currScenenInfo.id == sceneInfo.id)
		{
            Debug.Log("传送场景等于当前场景");
            FanrenSceneManager.LoadLevel(sceneInfo.name, false, true, false);
		}
		else
		{
            FanrenSceneManager.LoadLevel(sceneInfo.name, true, true, false);
		}
	}
}
