using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020001B9 RID: 441
public class BuildImageAtlas
{
	// Token: 0x0600090B RID: 2315 RVA: 0x0002BFFC File Offset: 0x0002A1FC
	public BuildImageAtlas(string outpath, string atlasname)
	{
		this.Init(outpath, atlasname, this._bIsScaleAdjust, this._SizeLimit);
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x0002C070 File Offset: 0x0002A270
	public BuildImageAtlas(string outpath, string atlasname, bool bIsScaleAdjust, int sizelimit)
	{
		this.Init(outpath, atlasname, bIsScaleAdjust, sizelimit);
	}

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x0600090D RID: 2317 RVA: 0x0002C0DC File Offset: 0x0002A2DC
	// (set) Token: 0x0600090E RID: 2318 RVA: 0x0002C0E4 File Offset: 0x0002A2E4
	public Dictionary<ulong, ImgData> ImgTable
	{
		get
		{
			return this._imgTable;
		}
		set
		{
			this._imgTable = value;
		}
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x0002C0F0 File Offset: 0x0002A2F0
	private void Init(string outpath, string atlasname, bool bIsScaleAdjust, int sizelimit)
	{
		this._outAtlaspath = Application.dataPath + "/Resources/" + outpath;
		this._outAtlasname = atlasname;
		this._outRespath = outpath;
		this._bIsScaleAdjust = bIsScaleAdjust;
		this._SizeLimit = sizelimit;
		if (this._bIsOutInfo)
		{
			Debug.Log("BuildImageAtlas : outAtlaspath=" + this._outAtlaspath + "  _outAtlasname=" + this._outAtlasname);
		}
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x0002C15C File Offset: 0x0002A35C
	private void ReleaseRuntime()
	{
		this._imgCnt = 0;
		this._SizeLimit = 2048;
		this._MeshZ = 0.01f;
		this._bIsAppSystemMode = false;
		this._Padding = 0;
		this._bIsScaleAdjust = false;
		this._tempAtiasSize.Clear();
		this._tempAtiasPos.Clear();
		foreach (List<ImgSrcData> list in this._tempImgList.Values)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].tex != null)
				{
					UnityEngine.Object.DestroyImmediate(list[i].tex);
					list[i].tex = null;
				}
			}
		}
		this._tempImgList.Clear();
		foreach (ImgSrcData imgSrcData in this._imgsrcTable.Values)
		{
			if (imgSrcData.tex != null)
			{
				UnityEngine.Object.DestroyImmediate(imgSrcData.tex);
				imgSrcData.tex = null;
			}
		}
		this._imgsrcTable.Clear();
		GC.Collect();
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x0002C2E8 File Offset: 0x0002A4E8
	public bool AddImgSrcData(ulong id, string name, string path)
	{
		if (this._imgsrcTable.ContainsKey(id) || string.IsNullOrEmpty(path))
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"BuildImageAtlas:AddImgSrcData Error! Info=> id=",
				id,
				" name=",
				name,
				" path=",
				path
			}));
			return false;
		}
		this._imgsrcTable.Add(id, new ImgSrcData(id, name, path));
		if (this._bIsOutInfo)
		{
			Debug.Log(string.Concat(new object[]
			{
				"BuildImageAtlas:AddImgSrcData : id=",
				id,
				" name=",
				name,
				" path=",
				path
			}));
		}
		return true;
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x0002C3A8 File Offset: 0x0002A5A8
	public bool ExecuteBuild()
	{
		GC.Collect();
		try
		{
			if (!this.ExecuteLoadData())
			{
				Debug.LogError("ExecuteLoadData failed!");
				return false;
			}
			if (!this.ExecuteBuildAtlas())
			{
				Debug.LogError("ExecuteBuildAtlas failed!");
				return false;
			}
			this.ReleaseRuntime();
		}
		catch
		{
			string text = "BuildImageAtlas unknow error memory overflow!";
			if (!Application.isEditor)
			{
				//Logger.LogToFile(text);
			}
			else
			{
				//Logger.Log(new object[]
				//{
				//	text
				//});
			}
		}
		GC.Collect();
		return true;
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x0002C454 File Offset: 0x0002A654
	private bool ExecuteLoadData()
	{
		if (this._imgsrcTable.Count <= 0)
		{
			Debug.LogWarning("ExecuteLoadData failed , no data!");
			return false;
		}
		this._tempImgList.Clear();
		this._imgTable.Clear();
		this._tempAtiasSize.Clear();
		this._tempAtiasPos.Clear();
		this._imgCnt = 0;
		Dictionary<Vector2, List<ImgSrcData>> dictionary = new Dictionary<Vector2, List<ImgSrcData>>();
		List<ImgSrcData> list = new List<ImgSrcData>();
		foreach (ImgSrcData imgSrcData in this._imgsrcTable.Values)
		{
			if (this._imgTable.ContainsKey(imgSrcData.id))
			{
				Debug.LogWarning("ExecuteLoadData Resources.Load ContainsKey res , continue!");
			}
			else
			{
				Texture2D texture2D = Resources.Load(imgSrcData.path, typeof(Texture)) as Texture2D;
				if (texture2D == null)
				{
					Debug.LogError("ExecuteLoadData Resources.Load failed , continue!");
				}
				else
				{
					texture2D = (Texture2D)UnityEngine.Object.Instantiate(texture2D);
					imgSrcData.tex = texture2D;
					Vector2 key = new Vector2((float)texture2D.width, (float)texture2D.height);
					if (!dictionary.ContainsKey(key))
					{
						List<ImgSrcData> list2 = new List<ImgSrcData>();
						list2.Add(imgSrcData);
						dictionary.Add(key, list2);
					}
					else
					{
						dictionary[key].Add(imgSrcData);
					}
					list.Add(imgSrcData);
				}
			}
		}
		if (dictionary.Count <= 0)
		{
			if (this._bIsOutInfo)
			{
				Debug.LogWarning("ExecuteLoadData pStandard.Count =0 , return!");
			}
			return false;
		}
		if (list != null)
		{
			list.Sort();
			this._imgCnt = 0;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				ImgSrcData imgSrcData2 = list[i];
				if (num3 < imgSrcData2.tex.height)
				{
					num3 = imgSrcData2.tex.height;
				}
				num6++;
				this._imgTable.Add(imgSrcData2.id, new ImgData(imgSrcData2.id, imgSrcData2.name, this._imgCnt));
				if (this._tempAtiasPos.ContainsKey(this._imgCnt))
				{
					this._tempAtiasPos[this._imgCnt].Add(new Vector2((float)num, (float)num2));
				}
				else
				{
					List<Vector2> list3 = new List<Vector2>();
					list3.Add(new Vector2((float)num, (float)num2));
					this._tempAtiasPos.Add(this._imgCnt, list3);
				}
				if (this._tempImgList.ContainsKey(this._imgCnt))
				{
					this._tempImgList[this._imgCnt].Add(imgSrcData2);
				}
				else
				{
					if (num5 <= 0)
					{
						num5 = num3;
					}
					List<ImgSrcData> list4 = new List<ImgSrcData>();
					list4.Add(imgSrcData2);
					this._tempImgList.Add(this._imgCnt, list4);
				}
				num += imgSrcData2.tex.width + this._Padding;
				if (num4 < num)
				{
					num4 = num;
				}
				int num8 = (i - 1 < 0) ? 0 : list[i - 1].tex.width;
				if (num + num8 > this._SizeLimit)
				{
					num2 += num3 + this._Padding;
					num6--;
					num5 = num2 + num3;
					int num9 = (i - 1 < 0) ? 0 : list[i - 1].tex.height;
					if (num2 + num9 > this._SizeLimit)
					{
						if (this._bIsOutInfo)
						{
							Debug.Log(string.Concat(new object[]
							{
								"图=",
								this._imgCnt,
								" 最终高度=",
								num5,
								" 最终宽度=",
								num4
							}));
						}
						this._tempAtiasSize.Add(this._imgCnt, new Vector2((float)num4, (float)num5));
						this._imgCnt++;
						num2 = 0;
						num7 = 0;
						num4 = 0;
						num5 = 0;
						if (this._bIsOutInfo)
						{
							Debug.Log("新的一张");
						}
					}
					num = 0;
					num3 = 0;
					num6 = 0;
					num7++;
				}
			}
			this._tempAtiasSize.Add(this._imgCnt, new Vector2((float)num4, (float)num5));
			if (this._bIsOutInfo)
			{
				Debug.Log(string.Concat(new object[]
				{
					"图=",
					this._imgCnt,
					" 最终高度=",
					num5,
					" 最终宽度=",
					num4
				}));
			}
		}
		if (this._bIsOutInfo)
		{
			Debug.Log("smal img cnt = " + this._imgsrcTable.Count);
			foreach (KeyValuePair<int, List<ImgSrcData>> keyValuePair in this._tempImgList)
			{
				Debug.Log(string.Concat(new object[]
				{
					"big img cnt = ",
					keyValuePair.Key,
					" have img =",
					keyValuePair.Value.Count
				}));
			}
		}
		return true;
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x0002C9FC File Offset: 0x0002ABFC
	private bool ExecuteBuildAtlas()
	{
		if (this._imgTable.Count <= 0)
		{
			Debug.LogWarning("ExecuteBuildAtlas failed , no texturedata!");
			return false;
		}
		Directory.CreateDirectory(this._outAtlaspath);
		foreach (KeyValuePair<int, List<ImgSrcData>> keyValuePair in this._tempImgList)
		{
			Texture2D texture2D = new Texture2D(4, 4, TextureFormat.ARGB32, false);
			byte[] array = texture2D.EncodeToPNG();
			List<Texture2D> list = new List<Texture2D>();
			for (int i = 0; i < keyValuePair.Value.Count; i++)
			{
				if (keyValuePair.Value[i].tex == null)
				{
					Debug.LogWarning("ExecuteBuildAtlas img is null." + keyValuePair.Value[i].path + ":" + keyValuePair.Value[i].name);
				}
				else
				{
					list.Add(keyValuePair.Value[i].tex);
				}
			}
			if (list.Count <= 0)
			{
				Debug.LogWarning("ExecuteBuildAtlas img is null.");
			}
			else
			{
				texture2D.name = this._outAtlasname + "_" + keyValuePair.Key;
				string text = this._outAtlaspath + "/" + texture2D.name + ".png";
				Rect[] array2 = null;
				MyRect[] array3 = null;
				if (this._bIsAppSystemMode)
				{
					array2 = texture2D.PackTextures(list.ToArray(), this._Padding, this._SizeLimit);
				}
				else
				{
					array3 = this.PackTextures(texture2D, keyValuePair.Key, list.ToArray(), this._Padding, this._SizeLimit);
				}
				if (this._bIsScaleAdjust && array2 != null && (array2[0].width * (float)texture2D.width != (float)list[0].width || array2[0].height * (float)texture2D.height != (float)list[0].height))
				{
					float num = array2[0].width * (float)texture2D.width / (float)list[0].width;
					float num2 = array2[0].height * (float)texture2D.height / (float)list[0].height;
					float num3 = (num > num2) ? num2 : num;
					for (;;)
					{
						Texture2D[] array4 = list.ToArray();
						Texture2D[] array5 = new Texture2D[array4.Length];
						for (int j = 0; j < array5.Length; j++)
						{
							array5[j] = this.BilinearScaleTexture(array4[j], num3);
						}
						array2 = texture2D.PackTextures(array5, this._Padding, this._SizeLimit);
						if (array2[0].width * (float)texture2D.width == (float)array5[0].width && array2[0].height * (float)texture2D.height == (float)array5[0].height)
						{
							break;
						}
						num3 *= 0.9f;
					}
					Debug.LogWarning("ExecuteBuildAtlas resize BilinearScaleTexture! ");
				}
				if (this._bIsAppSystemMode)
				{
					for (int k = 0; k < array2.Length; k++)
					{
						ulong id = keyValuePair.Value[k].id;
						if (!this._imgTable.ContainsKey(id))
						{
							Debug.LogWarning("ExecuteBuildAtlas is no find  idx at uvs, continue! ");
						}
						else
						{
							this._imgTable[id].offset = new Vector2(array2[k].x, array2[k].y);
							this._imgTable[id].uv = new Vector2(array2[k].width, array2[k].height);
							bool flag = array2[k].width > array2[k].height;
							float num4 = array2[k].height / array2[k].width;
							this._imgTable[id].size = new Vector3((!flag) ? num4 : 1f, (!flag) ? 1f : num4, this._MeshZ);
							this._imgTable[id].texpath = this._outRespath + "/" + texture2D.name;
						}
					}
				}
				else
				{
					for (int l = 0; l < array3.Length; l++)
					{
						ulong id2 = keyValuePair.Value[l].id;
						if (!this._imgTable.ContainsKey(id2))
						{
							Debug.LogWarning("ExecuteBuildAtlas is no find  idx at uvs, continue! ");
						}
						else
						{
							this._imgTable[id2].offset = new Vector2(array3[l].x, array3[l].y);
							this._imgTable[id2].uv = new Vector2(array3[l].width, array3[l].height);
							this._imgTable[id2].size = new Vector3(array3[l].texw, array3[l].texh, this._MeshZ);
							this._imgTable[id2].texpath = this._outRespath + "/" + texture2D.name;
						}
					}
				}
				array = texture2D.EncodeToPNG();
				using (FileStream fileStream = File.Create(text))
				{
					fileStream.Write(array, 0, array.Length);
					fileStream.Close();
					GC.Collect();
				}
				if (this._bIsOutInfo)
				{
					Debug.Log("ExecuteBuildAtlas sucessed out img :" + text);
				}
			}
		}
		Debug.Log("ExecuteBuildAtlas sucessed ! total img :" + this._tempImgList.Count);
		return true;
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x0002D060 File Offset: 0x0002B260
	private Texture2D BilinearScaleTexture(Texture2D originalTexture, float scaleFactor)
	{
		Texture2D texture2D = new Texture2D(Mathf.CeilToInt((float)originalTexture.width * scaleFactor), Mathf.CeilToInt((float)originalTexture.height * scaleFactor));
		float num = 1f / scaleFactor;
		int a = originalTexture.width - 1;
		int a2 = originalTexture.height - 1;
		for (int i = 0; i < texture2D.height; i++)
		{
			for (int j = 0; j < texture2D.width; j++)
			{
				float num2 = (float)j * num;
				float num3 = (float)i * num;
				int num4 = Mathf.Min(a, Mathf.FloorToInt(num2));
				int num5 = Mathf.Min(a2, Mathf.FloorToInt(num3));
				int x = Mathf.Min(a, num4 + 1);
				int y = Mathf.Min(a2, num5 + 1);
				float num6 = num2 - (float)num4;
				float num7 = num3 - (float)num5;
				float num8 = (1f - num6) * (1f - num7);
				float num9 = num6 * (1f - num7);
				float num10 = (1f - num6) * num7;
				float num11 = num6 * num7;
				Color pixel = originalTexture.GetPixel(num4, num5);
				Color pixel2 = originalTexture.GetPixel(x, num5);
				Color pixel3 = originalTexture.GetPixel(num4, y);
				Color pixel4 = originalTexture.GetPixel(x, y);
				Color color = new Color(Mathf.Clamp01(pixel.r * num8 + pixel2.r * num9 + pixel3.r * num10 + pixel4.r * num11), Mathf.Clamp01(pixel.g * num8 + pixel2.g * num9 + pixel3.g * num10 + pixel4.g * num11), Mathf.Clamp01(pixel.b * num8 + pixel2.b * num9 + pixel3.b * num10 + pixel4.b * num11), Mathf.Clamp01(pixel.a * num8 + pixel2.a * num9 + pixel3.a * num10 + pixel4.a * num11));
				texture2D.SetPixel(j, i, color);
			}
		}
		return texture2D;
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x0002D26C File Offset: 0x0002B46C
	public MyRect[] PackTextures(Texture2D tex, int atlas, Texture2D[] textures, int padding, int maximumAtlasSize)
	{
		MyRect[] array = new MyRect[textures.Length];
		if (this._bIsOutInfo)
		{
			Debug.Log("PackTextures cnt =" + textures.Length);
		}
		int num = maximumAtlasSize;
		int num2 = maximumAtlasSize;
		if (this._tempAtiasSize.ContainsKey(atlas))
		{
			num = (int)this._tempAtiasSize[atlas].x;
			num2 = (int)this._tempAtiasSize[atlas].y;
		}
		num = this.GetLimitSize(num);
		num2 = this.GetLimitSize(num2);
		tex.Resize(num, num2);
		for (int i = 0; i < maximumAtlasSize; i++)
		{
			for (int j = 0; j < maximumAtlasSize; j++)
			{
				tex.SetPixel(i, j, Color.clear);
			}
		}
		tex.Apply();
		if (this._bIsOutInfo)
		{
			Debug.Log(string.Concat(new object[]
			{
				" refw:",
				num,
				" refh:",
				num2,
				" tex.width:",
				tex.width,
				" tex.height:",
				tex.height
			}));
		}
		int num3 = 0;
		for (int k = 0; k < textures.Length; k++)
		{
			float fw = (float)(textures[k].width / num);
			float fh = (float)(textures[k].height / num2);
			float fy = this._tempAtiasPos[atlas][k].y / (float)num2;
			float fx = this._tempAtiasPos[atlas][k].x / (float)num;
			array[k] = new MyRect(fx, fy, fw, fh, (float)textures[k].width, (float)textures[k].height);
			num3++;
			int num4 = (int)this._tempAtiasPos[atlas][k].x;
			int num5 = (int)this._tempAtiasPos[atlas][k].y;
			Debug.Log(string.Concat(new object[]
			{
				num3,
				"  psx = ",
				num4,
				"  psy = ",
				num5,
				" width=",
				textures[k].width,
				" height=",
				textures[k].height
			}));
			tex.SetPixels(num4, num5, textures[k].width, textures[k].height, textures[k].GetPixels());
		}
		tex.Apply();
		if (this._bIsOutInfo)
		{
			Debug.Log("PackTextures result cnt =" + num3);
		}
		return array;
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x0002D584 File Offset: 0x0002B784
	private int GetLimitSize(int num)
	{
		if (num % 2 != 0)
		{
			num++;
		}
		if (num > this._SizeLimit)
		{
			return this._SizeLimit;
		}
		return num;
	}

	// Token: 0x04000801 RID: 2049
	private Dictionary<ulong, ImgSrcData> _imgsrcTable = new Dictionary<ulong, ImgSrcData>();

	// Token: 0x04000802 RID: 2050
	private Dictionary<ulong, ImgData> _imgTable = new Dictionary<ulong, ImgData>();

	// Token: 0x04000803 RID: 2051
	private Dictionary<int, List<ImgSrcData>> _tempImgList = new Dictionary<int, List<ImgSrcData>>();

	// Token: 0x04000804 RID: 2052
	private Dictionary<int, Vector2> _tempAtiasSize = new Dictionary<int, Vector2>();

	// Token: 0x04000805 RID: 2053
	private Dictionary<int, List<Vector2>> _tempAtiasPos = new Dictionary<int, List<Vector2>>();

	// Token: 0x04000806 RID: 2054
	private string _outAtlaspath;

	// Token: 0x04000807 RID: 2055
	private string _outRespath;

	// Token: 0x04000808 RID: 2056
	private string _outAtlasname;

	// Token: 0x04000809 RID: 2057
	private int _imgCnt;

	// Token: 0x0400080A RID: 2058
	private int _SizeLimit = 2048;

	// Token: 0x0400080B RID: 2059
	private bool _bIsAppSystemMode;

	// Token: 0x0400080C RID: 2060
	private int _Padding;

	// Token: 0x0400080D RID: 2061
	private float _MeshZ = 0.01f;

	// Token: 0x0400080E RID: 2062
	private bool _bIsScaleAdjust;

	// Token: 0x0400080F RID: 2063
	private bool _bIsOutInfo;
}
