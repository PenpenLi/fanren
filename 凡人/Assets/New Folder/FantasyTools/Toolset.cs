using System;
using UnityEngine;

namespace FantasyTools
{
	// Token: 0x02000269 RID: 617
	public class Toolset
	{
		// Token: 0x06001067 RID: 4199 RVA: 0x0008CF64 File Offset: 0x0008B164
		public static string GetFileExt(string strFile, bool ContainsPoint)
		{
			if (string.IsNullOrEmpty(strFile))
			{
				return strFile;
			}
			int num = strFile.LastIndexOf(".") + ((!ContainsPoint) ? 1 : 0);
			if (num == -1)
			{
				return string.Empty;
			}
			return strFile.Substring(num, strFile.Length - num);
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x0008CFB4 File Offset: 0x0008B1B4
		public static bool IsEnumDefined(Type etype, object index)
		{
			return Enum.IsDefined(etype, index);
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x0008CFC0 File Offset: 0x0008B1C0
		public static bool TryGetIndexByEnum(Type etype, string name, out int ret)
		{
			ret = -1;
			if (!Toolset.IsEnumDefined(etype, name))
			{
				return false;
			}
			ret = (int)Enum.Parse(etype, name);
			return true;
		}

		public static bool TryGetEnumByIndex(Type etype, int index, out string ret)
		{
			ret = string.Empty;
			if (!Toolset.IsEnumDefined(etype, index))
			{
				return false;
			}
			ret = Enum.GetName(etype, index);
			return true;
		}

		//public static FAN_PAR_TYPE GetObjectType(object obj)
		//{
		//	if (Convert.IsDBNull(obj))
		//	{
		//		return FAN_PAR_TYPE.FPT_NULL;
		//	}
		//	TypeCode typeCode = Convert.GetTypeCode(obj);
		//	if (typeCode == TypeCode.Empty)
		//	{
		//		return FAN_PAR_TYPE.FPT_NULL;
		//	}
		//	if (typeCode == TypeCode.Boolean)
		//	{
		//		return FAN_PAR_TYPE.FPT_BOOL;
		//	}
		//	if (typeCode == TypeCode.Int32)
		//	{
		//		return FAN_PAR_TYPE.FPT_INT;
		//	}
		//	if (typeCode == TypeCode.Single)
		//	{
		//		return FAN_PAR_TYPE.FPT_FLOAT;
		//	}
		//	if (typeCode == TypeCode.String)
		//	{
		//		return FAN_PAR_TYPE.FPT_STRING;
		//	}
		//	if (typeCode == TypeCode.Object)
		//	{
		//		string name = obj.GetType().Name;
		//		if (name == typeof(Vector2).Name)
		//		{
		//			return FAN_PAR_TYPE.FPT_VECTOR2;
		//		}
		//		if (name == typeof(Vector3).Name)
		//		{
		//			return FAN_PAR_TYPE.FPT_VECTOR3;
		//		}
		//		if (name == typeof(Vector4).Name)
		//		{
		//			return FAN_PAR_TYPE.FPT_VECTOR4;
		//		}
		//		if (name == typeof(Color).Name)
		//		{
		//			return FAN_PAR_TYPE.FPT_COLOR;
		//		}
		//		if (obj.GetType().IsSubclassOf(typeof(GameObject)))
		//		{
		//			return FAN_PAR_TYPE.FPT_GAMEOBJECT;
		//		}
		//		if (obj.GetType().IsSubclassOf(typeof(UnityEngine.Object)))
		//		{
		//			return FAN_PAR_TYPE.FPT_OBJECT;
		//		}
		//	}
		//	return FAN_PAR_TYPE.FPT_NULL;
		//}

		public static T Get<T>(object obj)
		{
			if (Convert.IsDBNull(obj))
			{
				return default(T);
			}
			TypeCode typeCode = Type.GetTypeCode(typeof(T));
			TypeCode typeCode2 = Convert.GetTypeCode(obj);
			if (typeCode == TypeCode.Empty || typeCode2 == TypeCode.Empty)
			{
				Debug.LogError(string.Concat(new object[]
				{
					"Try convert unknow type ! ",
					typeCode2,
					" => ",
					typeCode
				}));
				return default(T);
			}
			return (T)((object)Convert.ChangeType(obj, typeof(T)));
		}

		public static Color GetColor(object obj)
		{
			if (!Convert.IsDBNull(obj))
			{
				string text = obj.ToString();
				text = text.Replace("RGBA(", string.Empty);
				text = text.Replace(")", string.Empty);
				string[] array = text.Split(new char[]
				{
					','
				});
				if (array != null || array.Length != 4)
				{
					Color result = new Color(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]), Convert.ToSingle(array[2]), Convert.ToSingle(array[3]));
					return result;
				}
			}
			return Color.white;
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x0008D254 File Offset: 0x0008B454
		public static Vector2 GetVector2(object obj)
		{
			if (!Convert.IsDBNull(obj))
			{
				string text = obj.ToString();
				text = text.Replace("(", string.Empty);
				text = text.Replace(")", string.Empty);
				string[] array = text.Split(new char[]
				{
					','
				});
				if (array != null || array.Length != 2)
				{
					Vector2 result = new Vector2(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]));
					return result;
				}
			}
			return Vector2.zero;
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x0008D2D4 File Offset: 0x0008B4D4
		public static Vector3 GetVector3(object obj)
		{
			if (!Convert.IsDBNull(obj))
			{
				string text = obj.ToString();
				text = text.Replace("(", string.Empty);
				text = text.Replace(")", string.Empty);
				string[] array = text.Split(new char[]
				{
					','
				});
				if (array != null || array.Length != 3)
				{
					Vector3 result = new Vector3(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]), Convert.ToSingle(array[2]));
					return result;
				}
			}
			return Vector3.zero;
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x0008D35C File Offset: 0x0008B55C
		public static Vector4 GetVector4(object obj)
		{
			if (!Convert.IsDBNull(obj))
			{
				string text = obj.ToString();
				text = text.Replace("(", string.Empty);
				text = text.Replace(")", string.Empty);
				string[] array = text.Split(new char[]
				{
					','
				});
				if (array != null || array.Length != 4)
				{
					Vector4 result = new Vector4(Convert.ToSingle(array[0]), Convert.ToSingle(array[1]), Convert.ToSingle(array[2]), Convert.ToSingle(array[3]));
					return result;
				}
			}
			return Vector2.zero;
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x0008D3F4 File Offset: 0x0008B5F4
		public static string GetHierarchyPath(GameObject obj)
		{
			if (obj == null)
			{
				return "null";
			}
			string text = obj.name;
			while (obj.transform.parent != null)
			{
				obj = obj.transform.parent.gameObject;
				text = obj.name + "/" + text;
			}
			return "\"" + text + "\"";
		}
	}
}
