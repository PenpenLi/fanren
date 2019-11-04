using System;
using System.Collections.Generic;
using System.IO;
using NS_RoleBaseFun;
using UnityEngine;

// Token: 0x020001D6 RID: 470
public class ImageGroupManager
{
	// Token: 0x06000ACB RID: 2763 RVA: 0x000491DC File Offset: 0x000473DC
	public bool SetImgInAtlas(ulong id, ref Material mat)
	{
		if (ImageGroupManager._buildAtlas == null || ImageGroupManager._buildAtlas.ImgTable == null || !ImageGroupManager._buildAtlas.ImgTable.ContainsKey(id))
		{
			return false;
		}
		Texture2D textureByID = this.GetTextureByID(id);
		if (textureByID == null)
		{
			return false;
		}
		mat = new Material(this.GetSharder());
		mat.name = "IMG_" + id + "_MAT";
		mat.mainTexture = textureByID;
		mat.SetTextureOffset("_MainTex", ImageGroupManager._buildAtlas.ImgTable[id].offset);
		mat.SetTextureScale("_MainTex", ImageGroupManager._buildAtlas.ImgTable[id].uv);
		mat.shader = this.GetSharder();
		mat.color = this.SetBrightness(mat.color, this._defultBrightness);
		return true;
	}

	// Token: 0x06000ACC RID: 2764 RVA: 0x000492CC File Offset: 0x000474CC
	public bool SetImgInAtlasByEZGUI(ulong id, ref Material mat)
	{
		if (ImageGroupManager._buildAtlas == null || ImageGroupManager._buildAtlas.ImgTable == null || !ImageGroupManager._buildAtlas.ImgTable.ContainsKey(id))
		{
			return false;
		}
		Texture2D textureByID = this.GetTextureByID(id);
		if (textureByID == null)
		{
			return false;
		}
		mat = new Material(this.GetEZSharder());
		mat.name = "IMG_" + id + "_MAT";
		mat.mainTexture = textureByID;
		mat.SetTextureOffset("_MainTex", ImageGroupManager._buildAtlas.ImgTable[id].offset);
		mat.SetTextureScale("_MainTex", ImageGroupManager._buildAtlas.ImgTable[id].uv);
		mat.shader = this.GetEZSharder();
		return true;
	}

	// Token: 0x06000ACD RID: 2765 RVA: 0x000493A0 File Offset: 0x000475A0
	public GameObject GetImgByAtlas(ulong id)
	{
		if (ImageGroupManager._buildAtlas == null || ImageGroupManager._buildAtlas.ImgTable == null || !ImageGroupManager._buildAtlas.ImgTable.ContainsKey(id))
		{
			return null;
		}
		Texture2D textureByID = this.GetTextureByID(id);
		if (textureByID == null)
		{
			return null;
		}
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
		gameObject.name = id.ToString();
		gameObject.tag = "EZGUI";
		gameObject.layer = 10;
		gameObject.transform.position = new Vector3(0f, 122f, 0.5f);
		//gameObject.renderer.material.mainTexture = textureByID;
		//gameObject.renderer.material.SetTextureOffset("_MainTex", ImageGroupManager._buildAtlas.ImgTable[id].offset);
		//gameObject.renderer.material.SetTextureScale("_MainTex", ImageGroupManager._buildAtlas.ImgTable[id].uv);
		//gameObject.transform.localRotation = this.GetRotation();
		//gameObject.transform.localScale = this.GetScale(ImageGroupManager._buildAtlas.ImgTable[id].size);
		//gameObject.renderer.material.shader = this.GetSharder();
		//gameObject.renderer.material.color = this.SetBrightness(gameObject.renderer.material.color, this._defultBrightness);
		return gameObject;
	}

	// Token: 0x06000ACE RID: 2766 RVA: 0x00049518 File Offset: 0x00047718
	public Texture2D GetTextureByID(ulong id)
	{
		if (!ImageGroupManager._buildAtlas.ImgTable.ContainsKey(id))
		{
			return null;
		}
		string texpath = ImageGroupManager._buildAtlas.ImgTable[id].texpath;
		return this.GetTextureByPath(texpath);
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x0004955C File Offset: 0x0004775C
	public Color SetBrightness(Color col, float value)
	{
		return new Color(col.r * value, col.g * value, col.b * value, 255f);
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x00049584 File Offset: 0x00047784
	public ImgData GetImgDataByID(ulong id)
	{
		if (!ImageGroupManager._buildAtlas.ImgTable.ContainsKey(id))
		{
			return null;
		}
		return ImageGroupManager._buildAtlas.ImgTable[id];
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x000495B8 File Offset: 0x000477B8
	private Texture2D GetTextureByPath(string path)
	{
		if (ImageGroupManager._texList.ContainsKey(path))
		{
			return ImageGroupManager._texList[path];
		}
		return null;
	}

	// Token: 0x06000AD2 RID: 2770 RVA: 0x000495D8 File Offset: 0x000477D8
	public Quaternion GetRotation()
	{
		return ImageGroupManager._defultRotation;
	}

	// Token: 0x06000AD3 RID: 2771 RVA: 0x000495E0 File Offset: 0x000477E0
	private Vector3 GetScale(Vector3 size)
	{
		Vector3 result = default(Vector3);
		float num = size.y / size.x;
		if (size.x > size.y)
		{
			result.x = this._defultScaleRatio;
			result.z = this._defultScaleRatio * num;
		}
		else
		{
			result.z = this._defultScaleRatio;
			result.x = this._defultScaleRatio * num;
		}
		result.y = size.z;
		return result;
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x00049664 File Offset: 0x00047864
	private Shader GetSharder()
	{
		return Shader.Find("Sprite/Vertex Colored");
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x00049670 File Offset: 0x00047870
	private Shader GetEZSharder()
	{
		return Shader.Find("Sprite/Vertex Colored");
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x0004967C File Offset: 0x0004787C
	public bool Init()
	{
		if (!this.ReadyConfig())
		{
			//Logger.LogWarning(new object[]
			//{
			//	"ImageGroupManager Config error! Will Used defult data!"
			//});
		}
		ImageGroupManager._buildAtlas = new BuildImageAtlas(this._outPath, this._outName);
		return true;
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x000496B4 File Offset: 0x000478B4
	private bool ReadyConfig()
	{
		List<string> list = RoleBaseFun.LoadConfInAssets("DataFile/ItemData/ItemAtlasConfig");
		if (list.Count <= 0)
		{
			Debug.LogWarning("ImageGroupManager Config no found!");
			return false;
		}
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			if (array.Length < 1)
			{
				Debug.LogWarning("ImageGroupManager Config line data is error!");
			}
			else
			{
				string text2 = array[0];
				if (text2.Contains("[Build]") || text2.Contains("[OutAtlasPath]") || text2.Contains("[OutAtlasName]"))
				{
					string[] array2 = text2.Split(ImageGroupManager.cfgsep);
					if (array2.Length < 2 || string.IsNullOrEmpty(array2[1]))
					{
						Debug.LogWarning("ImageGroupManager Config line data is error! At :" + text2);
					}
					else
					{
						if (text2.Contains("[Build]"))
						{
							this._isNeedBuild = (array2[1] == "true");
						}
						if (text2.Contains("[OutAtlasPath]"))
						{
							this._outPath = array2[1];
						}
						if (text2.Contains("[OutAtlasName]"))
						{
							this._outName = array2[1];
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x00049838 File Offset: 0x00047A38
	public bool ReadyData(Dictionary<ulong, ImgSrcData> pDatas)
	{
		if (pDatas == null || pDatas.Count <= 0)
		{
			return false;
		}
		if (ImageGroupManager._pReadyDatas == null)
		{
			ImageGroupManager._pReadyDatas = new Dictionary<ulong, ImgSrcData>();
		}
		ImageGroupManager._pReadyDatas.Clear();
		ImageGroupManager._pReadyDatas = pDatas;
		return true;
	}

	// Token: 0x06000AD9 RID: 2777 RVA: 0x00049874 File Offset: 0x00047A74
	public bool ExecuteBuild()
	{
		if (this._isNeedBuild)
		{
			if (ImageGroupManager._pReadyDatas == null || ImageGroupManager._pReadyDatas.Count <= 0)
			{
				//Logger.LogError(new object[]
				//{
				//	"ImageGroupManager  error! Try build atlas ,but no datas!"
				//});
				return false;
			}
			foreach (ImgSrcData imgSrcData in ImageGroupManager._pReadyDatas.Values)
			{
				ImageGroupManager._buildAtlas.AddImgSrcData(imgSrcData.id, imgSrcData.name, imgSrcData.path);
			}
			if (ImageGroupManager._buildAtlas.ExecuteBuild())
			{
				this.SaveAtlasFile(this._outPath + this._outName + ".txt");
			}
		}
		return true;
	}

	public bool ExecuteLoad()
	{
		string filename = this._outPath + this._outName;
		List<string> list = ImageGroupManager.LoadConfInAssetsEx(filename);
		if (list == null || list.Count <= 0)
		{
			Debug.LogWarning("ExecuteLoad no found!");
			return false;
		}
		List<string> list2 = new List<string>();
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			if (array.Length < 7)
			{
				Debug.LogWarning("ExecuteLoad line data is error! cnt =" + array.Length);
			}
			else
			{
				ulong num = Convert.ToUInt64(array[0]);
				int imgcnt = Convert.ToInt32(array[5]);
				ImgData imgData = new ImgData(num, array[1], imgcnt);
				imgData.texpath = array[6];
				string[] array2 = array[2].Split(new char[]
				{
					','
				});
				string[] array3 = array2[0].Split(new char[]
				{
					'('
				});
				string[] array4 = array2[1].Split(new char[]
				{
					')'
				});
				float x = Convert.ToSingle(array3[1]);
				float y = Convert.ToSingle(array4[0]);
				imgData.offset = new Vector2(x, y);
				string[] array5 = array[3].Split(new char[]
				{
					','
				});
				string[] array6 = array5[0].Split(new char[]
				{
					'('
				});
				string[] array7 = array5[1].Split(new char[]
				{
					')'
				});
				float x2 = Convert.ToSingle(array6[1]);
				float y2 = Convert.ToSingle(array7[0]);
				imgData.uv = new Vector2(x2, y2);
				string[] array8 = array[4].Split(new char[]
				{
					','
				});
				string[] array9 = array8[0].Split(new char[]
				{
					'('
				});
				string[] array10 = array8[2].Split(new char[]
				{
					')'
				});
				float x3 = Convert.ToSingle(array9[1]);
				float y3 = Convert.ToSingle(array8[1]);
				float z = Convert.ToSingle(array10[0]);
				imgData.size = new Vector3(x3, y3, z);
				if (!list2.Contains(imgData.texpath))
				{
					list2.Add(imgData.texpath);
				}
				ImageGroupManager._buildAtlas.ImgTable.Add(num, imgData);
			}
		}
		return this.BuildInstanse(list2);
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x00049BE0 File Offset: 0x00047DE0
	private bool BuildInstanse(List<string> texpath)
	{
		if (texpath.Count <= 0)
		{
			return false;
		}
		ImageGroupManager._texList.Clear();
		for (int i = 0; i < texpath.Count; i++)
		{
			Texture2D texture2D = ResourceLoader.Load(texpath[i], typeof(Texture2D)) as Texture2D;
			if (texture2D == null)
			{
				Debug.LogError("BuildInstanse failed ! img : " + texpath[i]);
			}
			else
			{
				UnityEngine.Object.DontDestroyOnLoad(texture2D);
				ImageGroupManager._texList.Add(texpath[i], texture2D);
			}
		}
		return ImageGroupManager._texList.Count > 0;
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x00049C84 File Offset: 0x00047E84
	private void SaveAtlasFile(string path)
	{
		if (ImageGroupManager._buildAtlas == null || ImageGroupManager._buildAtlas.ImgTable.Count <= 0)
		{
			//Logger.LogWarning(new object[]
			//{
			//	"ImageGroupManager Save Atlas File failed!"
			//});
			return;
		}
		if (string.IsNullOrEmpty(path))
		{
			path = "ItemAtlas/icon/Item_icon";
		}
		string path2 = Application.dataPath + "/Resources/" + path;
		FileStream fileStream = new FileStream(path2, FileMode.Create, FileAccess.ReadWrite);
		StreamWriter streamWriter = new StreamWriter(fileStream);
		bool flag = true;
		string str = CacheData.separator[0].ToString();
		string text = string.Empty;
		foreach (ImgData imgData in ImageGroupManager._buildAtlas.ImgTable.Values)
		{
			if (flag)
			{
				text += "#本信息由ImageAtlas自动生成\n";
				text += "#纹理ID";
				text += str;
				text += "#纹理名称";
				text += str;
				text += "#纹理偏移";
				text += str;
				text += "#纹理uv";
				text += str;
				text += "#纹理大小";
				text += str;
				text += "#Atlas序列";
				text += str;
				text += "#纹理路径";
				text += str;
				flag = false;
			}
			text += "\n";
			text += imgData.id;
			text += str;
			text += imgData.name;
			text += str;
			text += "(";
			text += imgData.offset.x;
			text += ",";
			text += imgData.offset.y;
			text += ")";
			text += str;
			text += "(";
			text += imgData.uv.x;
			text += ",";
			text += imgData.uv.y;
			text += ")";
			text += str;
			text += "(";
			text += imgData.size.x;
			text += ",";
			text += imgData.size.y;
			text += ",";
			text += imgData.size.z;
			text += ")";
			text += str;
			text += imgData.imgorder;
			text += str;
			text += imgData.texpath;
			text += str;
		}
		streamWriter.Write(text);
		streamWriter.Close();
		fileStream.Close();
	}

	public static List<string> LoadConfInAssetsEx(string filename)
	{
		TextAsset textAsset = (TextAsset)ResourceLoader.Load(filename, typeof(TextAsset));
		if (textAsset == null)
		{
			return null;
		}
		string[] separator = new string[]
		{
			"\n"
		};
		string[] array = textAsset.text.Split(separator, StringSplitOptions.None);
		List<string> list = new List<string>();
		foreach (string text in array)
		{
			if (text.Length != 0)
			{
				string text2 = text.Trim();
				if (text2.IndexOf('#') != 0)
				{
					list.Add(text2);
				}
			}
		}
		Resources.UnloadAsset(textAsset);
		return list;
	}

	// Token: 0x04000A46 RID: 2630
	private const string CONFIG_PATH = "DataFile/ItemData/ItemAtlasConfig";

	// Token: 0x04000A47 RID: 2631
	private const string CFG_KEY_BUILD = "[Build]";

	// Token: 0x04000A48 RID: 2632
	private const string CFG_KEY_PATH = "[OutAtlasPath]";

	// Token: 0x04000A49 RID: 2633
	private const string CFG_KEY_NAME = "[OutAtlasName]";

	// Token: 0x04000A4A RID: 2634
	public static char[] cfgsep = new char[]
	{
		'='
	};

	// Token: 0x04000A4B RID: 2635
	public bool _isNeedBuild = true;

	// Token: 0x04000A4C RID: 2636
	public string _outPath = "ItemAtlas/icon";

	// Token: 0x04000A4D RID: 2637
	public string _outName = "Item_icon";

	// Token: 0x04000A4E RID: 2638
	public float _defultScaleRatio = 0.1f;

	// Token: 0x04000A4F RID: 2639
	public float _defultBrightness = 0.54901f;

	// Token: 0x04000A50 RID: 2640
	public static Quaternion _defultRotation = Quaternion.Euler(new Vector3(0f, 0f, 180f));

	// Token: 0x04000A51 RID: 2641
	private static BuildImageAtlas _buildAtlas = null;

	// Token: 0x04000A52 RID: 2642
	private static Dictionary<ulong, ImgSrcData> _pReadyDatas = null;

	// Token: 0x04000A53 RID: 2643
	private static Dictionary<string, Texture2D> _texList = new Dictionary<string, Texture2D>();
}
