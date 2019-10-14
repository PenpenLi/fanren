using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000197 RID: 407
[Serializable]
public class SaveInfo
{
	// Token: 0x060007E3 RID: 2019 RVA: 0x00002320 File Offset: 0x00000520
	public SaveInfo()
	{
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x0003BF68 File Offset: 0x0003A168
	public SaveInfo(SaveInfo info, List<byte> buffer)
	{
		this.Version = info.Version;
		this.ShowIndex = info.ShowIndex;
		this.SaveTime = info.SaveTime;
		this.MapName = info.MapName;
		this.DateFileName = info.DateFileName;
		this.Capture = SaveInfo.LoadScreen(buffer);
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x0003BFC4 File Offset: 0x0003A1C4
	public static SaveInfo GetInfoDate(SaveLoadManager.tagSL st)
	{
		return new SaveInfo
		{
			Version = GameData.GAME_VERSION,
			ShowIndex = st,
			//MapName = SceneManager.scenenInfo.mapName,
			SaveTime = DateTime.Now.ToString()
		};
	}

	public void TextLoad(string[] strArray, ref int idx)
	{
		this.Version = Convert.ToInt32(strArray[idx]);
		idx++;
		this.ShowIndex = (SaveLoadManager.tagSL)Convert.ToInt32(strArray[idx]);
		idx++;
		this.MapName = strArray[idx];
		idx++;
		this.SaveTime = strArray[idx];
		idx++;
		this.DateFileName = strArray[idx];
		idx++;
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x0003C078 File Offset: 0x0003A278
	public string TextSave()
	{
		string[] array = new string[10];
		array[0] = this.Version.ToString();
		array[1] = "\t";
		int num = 2;
		int showIndex = (int)this.ShowIndex;
		array[num] = showIndex.ToString();
		array[3] = "\t";
		array[4] = this.MapName;
		array[5] = "\t";
		array[6] = this.SaveTime;
		array[7] = "\t";
		array[8] = this.DateFileName;
		array[9] = "\n";
		return string.Concat(array);
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x0003C0F8 File Offset: 0x0003A2F8
	public void LogOut()
	{
		string[] array = new string[11];
		array[0] = "\t";
		array[1] = this.Version.ToString();
		array[2] = "\t";
		int num = 3;
		int showIndex = (int)this.ShowIndex;
		array[num] = showIndex.ToString();
		array[4] = "\t";
		array[5] = this.MapName;
		array[6] = "\t";
		array[7] = this.SaveTime;
		array[8] = "\t";
		array[9] = this.DateFileName;
		array[10] = "\n";
		string str = string.Concat(array);
		Debug.Log("SaveInfo:" + str);
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x000075F7 File Offset: 0x000057F7
	private static Texture2D CreateTex2d(int width, int height)
	{
		return new Texture2D(width, height, TextureFormat.RGB24, false);
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x0003C190 File Offset: 0x0003A390
	public static List<byte> SaveScreen()
	{
		RenderTexture renderTexture = new RenderTexture(166, 117, 16);
		Texture2D texture2D = SaveInfo.CreateTex2d(166, 117);
		GameObject gameObject = new GameObject("NeedDeleted:SaveLoad");
		Camera camera = gameObject.AddComponent<Camera>();
		camera.transform.position = Camera.main.transform.position;
		camera.transform.rotation = Camera.main.transform.rotation;
		camera.depth = -2f;
		camera.targetTexture = renderTexture;
		camera.RenderDontRestore();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), 0, 0);
		camera.targetTexture = null;
		RenderTexture.active = null;
		UnityEngine.Object.Destroy(renderTexture);
		List<byte> result = new List<byte>(texture2D.EncodeToPNG());
		UnityEngine.Object.Destroy(texture2D);
		UnityEngine.Object.Destroy(camera.gameObject);
		return result;
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x0003C27C File Offset: 0x0003A47C
	public static Texture2D LoadScreen(List<byte> buffer)
	{
		Texture2D texture2D = SaveInfo.CreateTex2d(166, 117);
		texture2D.LoadImage(buffer.ToArray());
		return texture2D;
	}

	// Token: 0x040006C0 RID: 1728
	private const int CaptureWidth = 166;

	// Token: 0x040006C1 RID: 1729
	private const int CaptureHeight = 117;

	// Token: 0x040006C2 RID: 1730
	public int Version;

	// Token: 0x040006C3 RID: 1731
	public SaveLoadManager.tagSL ShowIndex;

	// Token: 0x040006C4 RID: 1732
	public string SaveTime;

	// Token: 0x040006C5 RID: 1733
	public string MapName;

	// Token: 0x040006C6 RID: 1734
	public string DateFileName;

	// Token: 0x040006C7 RID: 1735
	[NonSerialized]
	public Texture2D Capture;
}
