using System;
using UnityEngine;


public sealed class LoadResource : YieldInstruction
{
	public LoadResource(LoadingRes lr)
	{
        Debug.Log("执行");
		BaseArtResInfo baseArtResInfoById = GameData.Instance.ArtResConf.GetBaseArtResInfoById(lr.resID);
		if (baseArtResInfoById == null)
		{
			return;
		}
		//UnityEngine.Object @object = LoadMachine.LoadObj(lr.path, baseArtResInfoById.Name, baseArtResInfoById.ResType);
		//if (@object != null)
		//{
		//	LoadedResourceInfo loadedResourceInfo = new LoadedResourceInfo();
		//	loadedResourceInfo.Obj = @object;
		//	loadedResourceInfo.ResId = lr.resID;
		//	loadedResourceInfo.rt = lr.rt;
		//	LoadMachine.ResList.Add(loadedResourceInfo);
		//}
		//else
		//{
		//	LoadMachine.RemoveList.Add(lr);
		//	LoadMachine.LoadingList.Remove(lr);
		//}
		LoadMachine.ProcessCallBack(lr.resID);
	}
}
