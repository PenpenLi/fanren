using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EngineFun : MonoBehaviour
{
	public static void ChangeLayerRecursively(Transform trans, string name)
	{
		foreach (object obj in trans)
		{
			Transform transform = (Transform)obj;
			transform.gameObject.layer = LayerMask.NameToLayer(name);
			EngineFun.ChangeLayerRecursively(transform, name);
		}
	}

	public static GameObject InstantiateGameObject(GameObject prefab)
	{
		return EngineFun.InstantiateGameObject(prefab, Vector3.zero, Quaternion.identity);
	}

	public static GameObject InstantiateGameObject(GameObject prefab, Vector3 pos, Quaternion qua)
	{
		return LoadMachine.InstantiateObject(prefab, pos, qua) as GameObject;
	}

	public static GameObject CopyToMemory(GameObject resGo, string name)
	{
		GameObject gameObject = GameObject.Find("MapRes");
		if (gameObject == null)
		{
			gameObject = new GameObject();
			gameObject.name = "MapRes";
		}
		GameObject gameObject2 = LoadMachine.InstantiateObject(resGo, new Vector3(0f, 0f, -10000f), Quaternion.identity) as GameObject;
		gameObject2.name = name;
		gameObject2.transform.parent = gameObject.transform;
		return gameObject2;
	}

	public static bool ReadFile(string fileName, ref List<string> strList)
	{
		if (!File.Exists(fileName))
		{
			Debug.Log(
				fileName + " can't be found!"
			);
			return false;
		}
		FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
		StreamReader streamReader = new StreamReader(fileStream);
		while (streamReader.Peek() >= 0)
		{
			string item = streamReader.ReadLine();
			strList.Add(item);
		}
		streamReader.Close();
		fileStream.Close();
		return true;
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x0001758C File Offset: 0x0001578C
	public static void WriteFile(string filename, List<string> strList)
	{
		FileStream fileStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
		StreamWriter streamWriter = new StreamWriter(fileStream);
		for (int i = 0; i < strList.Count; i++)
		{
			streamWriter.Write(strList[i]);
		}
		streamWriter.Close();
		fileStream.Close();
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x000175DC File Offset: 0x000157DC
	public static void DelFile(string filename)
	{
		if (File.Exists(filename))
		{
			File.Delete(filename);
		}
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x000175F0 File Offset: 0x000157F0
	public static string RemoveExtensionName(string str)
	{
		int num = str.LastIndexOf('.');
		if (num == -1)
		{
			return str;
		}
		return str.Substring(0, num);
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x0001761C File Offset: 0x0001581C
	public static string RemovePath(string str)
	{
		int num = str.LastIndexOf('/');
		return str.Substring(num + 1, str.Length - num - 1);
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x00017648 File Offset: 0x00015848
	public static string GetPath(string str)
	{
		int num = str.LastIndexOf('/');
		return str.Substring(0, num + 1);
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x0001766C File Offset: 0x0001586C
	public static string GetFileNameFromPath(string path)
	{
		int num = path.LastIndexOf('/');
		int num2 = path.LastIndexOf('.');
		return path.Substring(num + 1, num2 - (num + 1));
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x0001769C File Offset: 0x0001589C
	public static string GetSuffix(string fileName)
	{
		int num = fileName.LastIndexOf('.');
		if (num < 0 || num > fileName.Length)
		{
			return null;
		}
		return fileName.Substring(num + 1);
	}
}
