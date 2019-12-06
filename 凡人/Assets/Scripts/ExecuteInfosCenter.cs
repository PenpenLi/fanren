using System;
using System.Collections.Generic;
using System.IO;
using NS_RoleBaseFun;
using UnityEngine;

// Token: 0x0200025E RID: 606
public class ExecuteInfosCenter : Singleton<ExecuteInfosCenter>
{
	// Token: 0x170001CE RID: 462
	// (get) Token: 0x06001018 RID: 4120 RVA: 0x0008B42C File Offset: 0x0008962C
	public int Count
	{
		get
		{
			return this._WidgetsInfos.Count;
		}
	}

	public bool LoadExecuteInfos()
	{
		return this.LoadExecuteInfos(null);
	}

	public bool LoadExecuteInfos(string scenename)
	{
		List<string> list = new List<string>();
		if (Application.isEditor)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath + "/Resources/conf/FantasyWorld/ExecuteConfig/ExecuteInfo");
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				string a = fileInfo.Extension.ToLower();
				if (!(a != ".txt"))
				{
					string text = "FantasyWorld/ExecuteConfig/ExecuteInfo/" + fileInfo.Name;
					string[] array2 = text.Split(new char[]
					{
						'.'
					});
					if (string.IsNullOrEmpty(scenename))
					{
						list.Add(array2[0]);
					}
					else
					{
						string[] array3 = fileInfo.Name.Split(new char[]
						{
							'.'
						});
						if (scenename == array3[0])
						{
							list.Add(array2[0]);
						}
					}
				}
			}
		}
		else
		{
			foreach (object obj in GameData.Instance.cacheData.SceneList)
			{
				SceneInfo sceneInfo = (SceneInfo)obj;
				string item = "FantasyWorld/ExecuteConfig/ExecuteInfo/" + sceneInfo.name;
				list.Add(item);
			}
		}
		if (list.Count < 1)
		{
			return false;
		}
		foreach (string text2 in list)
		{ 
			List<string> list2 = RoleBaseFun.LoadConfInAssets(text2);    
            if (list2 != null && list2.Count >= 1)
			{
				foreach (string text3 in list2)
				{
                    if (string.IsNullOrEmpty(text3))
					{
						Debug.LogWarning(text2 + " line data is error !");
					}
					else
					{
						WidgetConfig widgetConfig = new WidgetConfig();
						widgetConfig.Add(text3);
						string sceneName = widgetConfig.SceneName;
                        if (this._WidgetsInfos.ContainsKey(sceneName))
						{
							this._WidgetsInfos[sceneName].Add(widgetConfig);
						}
						else
						{
							List<WidgetConfig> list3 = new List<WidgetConfig>();
							list3.Add(widgetConfig);
							this._WidgetsInfos.Add(sceneName, list3);
						}
						if (Application.isEditor)
						{
							int count = this._WidgetsInfos[sceneName].Count;
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0600101B RID: 4123 RVA: 0x0008B734 File Offset: 0x00089934
	public void LoadSceneObjectActionFile()
	{
	}

	// Token: 0x0600101C RID: 4124 RVA: 0x0008B738 File Offset: 0x00089938
	public WidgetConfig GetExecuteWidget(int id)
	{
		return this.GetExecuteWidget(Application.loadedLevelName, id);
	}

	// Token: 0x0600101D RID: 4125 RVA: 0x0008B748 File Offset: 0x00089948
	public WidgetConfig GetExecuteWidget(string scene, int id)
	{
		if (!this._WidgetsInfos.ContainsKey(scene))
		{
			return null;
		}
		foreach (WidgetConfig widgetConfig in this._WidgetsInfos[scene])
		{
			if (widgetConfig.ID == id)
			{
				return widgetConfig;
			}
		}
		return null;
	}

	// Token: 0x04001144 RID: 4420
	private const string WIDGETS_INFO_DIRPATH = "/Resources/conf/FantasyWorld/ExecuteConfig/ExecuteInfo";

	// Token: 0x04001145 RID: 4421
	private const string SCENEOBJECT_ACTIONS_PATH = "/Resources/conf/FantasyWorld/ExecuteConfig/SceneObjectAction";

	// Token: 0x04001146 RID: 4422
	public Dictionary<string, List<WidgetConfig>> _WidgetsInfos = new Dictionary<string, List<WidgetConfig>>();
}
