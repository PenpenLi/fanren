using System;
using System.Collections.Generic;
using FantasyTools;
using UnityEngine;

// Token: 0x0200025B RID: 603
public class WidgetConfig
{
	// Token: 0x06001005 RID: 4101 RVA: 0x0008A344 File Offset: 0x00088544
	public bool Add(string linedata)
	{
		if (string.IsNullOrEmpty(linedata))
		{
			return false;
		}
		string[] array = linedata.Split(CacheData.separator);

		if (array == null || array.Length < 13)
		{
			return false;
		}
		this._Parameters.Clear();
		this._ObjParameters.Clear();
        Debug.Log(array[0]);
		this.SceneName = array[0];
		this.ID = Toolset.Get<int>(array[1]);
		this.StartDelayTime = Toolset.Get<float>(array[2]);
		this.LastTime = Toolset.Get<float>(array[3]);
		this.WidgetName = array[4];
		this.ResPath = array[5];
		this.Position.x = Toolset.Get<float>(array[6]);
		this.Position.y = Toolset.Get<float>(array[7]);
		this.Position.z = Toolset.Get<float>(array[8]);
		this.LocalRotation.x = Toolset.Get<float>(array[9]);
		this.LocalRotation.y = Toolset.Get<float>(array[10]);
		this.LocalRotation.z = Toolset.Get<float>(array[11]);
		this.LocalScale.x = Toolset.Get<float>(array[12]);
		this.LocalScale.y = Toolset.Get<float>(array[13]);
		this.LocalScale.z = Toolset.Get<float>(array[14]);
		int i;
		for (i = 15; i < array.Length; i++)
		{
			if (array[i] == "RESPAR")
			{
				break;
			}
			string a = array[i];
			i++;
			if (i + 1 < array.Length)
			{
				string text = array[i];
				if (a == FAN_PAR_TYPE.FPT_BOOL.ToString())
				{
					bool flag = Toolset.Get<bool>(text);
					i++;
					this._Parameters.Add(new KeyValuePair<object, string>(flag, array[i]));
				}
				else if (a == FAN_PAR_TYPE.FPT_INT.ToString())
				{
					int num = Toolset.Get<int>(text);
					i++;
					this._Parameters.Add(new KeyValuePair<object, string>(num, array[i]));
				}
				else if (a == FAN_PAR_TYPE.FPT_FLOAT.ToString())
				{
					float num2 = Toolset.Get<float>(text);
					i++;
					this._Parameters.Add(new KeyValuePair<object, string>(num2, array[i]));
				}
				else if (a == FAN_PAR_TYPE.FPT_STRING.ToString())
				{
					i++;
					this._Parameters.Add(new KeyValuePair<object, string>(text, array[i]));
				}
				else if (a == FAN_PAR_TYPE.FPT_VECTOR2.ToString())
				{
					Vector2 vector = Toolset.GetVector2(text);
					i++;
					this._Parameters.Add(new KeyValuePair<object, string>(vector, array[i]));
				}
				else if (a == FAN_PAR_TYPE.FPT_VECTOR3.ToString())
				{
					Vector3 vector2 = Toolset.GetVector3(text);
					i++;
					this._Parameters.Add(new KeyValuePair<object, string>(vector2, array[i]));
				}
				else if (a == FAN_PAR_TYPE.FPT_VECTOR4.ToString())
				{
					Vector4 vector3 = Toolset.GetVector4(text);
					i++;
					this._Parameters.Add(new KeyValuePair<object, string>(vector3, array[i]));
				}
				else if (a == FAN_PAR_TYPE.FPT_COLOR.ToString())
				{
					Color color = Toolset.GetColor(text);
					i++;
					this._Parameters.Add(new KeyValuePair<object, string>(color, array[i]));
				}
			}
		}
		for (i++; i < array.Length; i++)
		{
			string key = array[i];
			string value = (i < array.Length) ? array[i] : "null";
			this._ObjParameters.Add(new KeyValuePair<string, string>(key, value));
		}
		return true;
	}

	// Token: 0x06001006 RID: 4102 RVA: 0x0008A710 File Offset: 0x00088910
	public override string ToString()
	{
		string text = string.Empty;
		text += this.SceneName;
		text += this._spe;
		text += this.ID;
		text += this._spe;
		text += this.StartDelayTime;
		text += this._spe;
		text += this.LastTime;
		text += this._spe;
		text += this.WidgetName;
		text += this._spe;
		text += this.ResPath;
		text += this._spe;
		text += this.Position.x;
		text += this._spe;
		text += this.Position.y;
		text += this._spe;
		text += this.Position.z;
		text += this._spe;
		text += this.LocalRotation.x;
		text += this._spe;
		text += this.LocalRotation.y;
		text += this._spe;
		text += this.LocalRotation.z;
		text += this._spe;
		text += this.LocalScale.x;
		text += this._spe;
		text += this.LocalScale.y;
		text += this._spe;
		text += this.LocalScale.z;
		foreach (KeyValuePair<object, string> keyValuePair in this._Parameters)
		{
			//FAN_PAR_TYPE objectType = Toolset.GetObjectType(keyValuePair.Key);
			//if (objectType == FAN_PAR_TYPE.FPT_NULL)
			//{
			//	Debug.LogError("unknow type : " + keyValuePair.Key);
			//}
			//else
			//{
			//	text += this._spe;
			//	text += objectType.ToString();
			//	text += this._spe;
			//	text += keyValuePair.Key;
			//	text += this._spe;
			//	if (string.IsNullOrEmpty(keyValuePair.Value))
			//	{
			//		text = "null";
			//	}
			//	else
			//	{
			//		text += keyValuePair.Value;
			//	}
			//}
		}
		if (this._ObjParameters != null && this._ObjParameters.Count > 0)
		{
			text += this._spe;
			text += "RESPAR";
		}
		foreach (KeyValuePair<string, string> keyValuePair2 in this._ObjParameters)
		{
			//FAN_PAR_TYPE objectType2 = Toolset.GetObjectType(keyValuePair2.Key);
			//text += this._spe;
			//text += objectType2.ToString();
			//text += this._spe;
			//if (string.IsNullOrEmpty(keyValuePair2.Key))
			//{
			//	text += "null";
			//}
			//else
			//{
			//	text += keyValuePair2.Key;
			//}
			//text += this._spe;
			//if (string.IsNullOrEmpty(keyValuePair2.Value))
			//{
			//	text += "null";
			//}
			//else
			//{
			//	text += keyValuePair2.Value;
			//}
		}
		return text;
	}

	// Token: 0x04001129 RID: 4393
	public string SceneName;

	// Token: 0x0400112A RID: 4394
	public int ID;

	// Token: 0x0400112B RID: 4395
	public string WidgetName;

	// Token: 0x0400112C RID: 4396
	public string ResPath;

	// Token: 0x0400112D RID: 4397
	public Vector3 Position = Vector3.zero;

	// Token: 0x0400112E RID: 4398
	public Quaternion LocalRotation = Quaternion.identity;

	// Token: 0x0400112F RID: 4399
	public Vector3 LocalScale = Vector3.zero;

	// Token: 0x04001130 RID: 4400
	public List<KeyValuePair<object, string>> _Parameters = new List<KeyValuePair<object, string>>();

	// Token: 0x04001131 RID: 4401
	public List<KeyValuePair<string, string>> _ObjParameters = new List<KeyValuePair<string, string>>();

	// Token: 0x04001132 RID: 4402
	public float StartDelayTime;

	// Token: 0x04001133 RID: 4403
	public float LastTime;

	// Token: 0x04001134 RID: 4404
	private string _spe = "\t";
}
