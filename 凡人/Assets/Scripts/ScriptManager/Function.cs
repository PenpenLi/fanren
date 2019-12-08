using System;
using System.Collections.Generic;
using UnityEngine;

namespace ActionScript
{
	public static class Function
	{
		public static string[] SplitString(string str)
		{
			return str.Split(new char[]
			{
				'\n',
				'\t'
			}, StringSplitOptions.RemoveEmptyEntries);
		}

		public static string CombineString(List<string> str)
		{
			if (str == null)
			{
				return string.Empty;
			}
			string text = string.Empty;
			foreach (string str2 in str)
			{
				text = text + str2 + "\t";
			}
			return text;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000248BC File Offset: 0x00022ABC
		public static bool TryGetFloat(string str, out float num)
		{
			num = 0f;
			if (string.IsNullOrEmpty(str))
			{
				return false;
			}
			try
			{
				num = Convert.ToSingle(str);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				num = 0f;
				return false;
			}
			return true;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0002491C File Offset: 0x00022B1C
		//public static Role GetRoleById(int id)
		//{
		//	if (id == 0)
		//	{
		//		return Player.Instance;
		//	}
		//	return SceneManager.RoleMan.GetRoleByType(ROLE_TYPE.RT_MONSTER, id);
		//}

		// Token: 0x06000153 RID: 339 RVA: 0x00024944 File Offset: 0x00022B44
		public static bool TryGetVector3(string str, out Vector3 point)
		{
			point = Vector3.zero;
			if (string.IsNullOrEmpty(str))
			{
				return false;
			}
			string[] array = str.Split(new char[]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 3)
			{
				return false;
			}
			float[] array2 = new float[3];
			for (int i = 0; i < 3; i++)
			{
				if (!Function.TryGetFloat(array[i], out array2[i]))
				{
					return false;
				}
			}
			point = new Vector3(array2[0], array2[1], array2[2]);
			return true;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000249C8 File Offset: 0x00022BC8
		//public static object ConvertParam(VALUE_TYPE type, string s)
		//{
		//	object result = null;
		//	float num = 0f;
		//	int num2 = 0;
		//	switch (type)
		//	{
		//	case VALUE_TYPE.FLOAT:
		//		num = 0f;
		//		Function.TryGetFloat(s, out num);
		//		result = num;
		//		break;
		//	case VALUE_TYPE.STRING:
		//		result = s;
		//		break;
		//	case VALUE_TYPE.ROLE:
		//		num = 0f;
		//		if (Function.TryGetFloat(s, out num))
		//		{
		//			Role roleById = Function.GetRoleById((int)num);
		//			result = roleById;
		//		}
		//		break;
		//	default:
		//		if (type != VALUE_TYPE.BOOL)
		//		{
		//			int.TryParse(s, out num2);
		//			result = num2;
		//		}
		//		else
		//		{
		//			int.TryParse(s, out num2);
		//			if (num2 == 0)
		//			{
		//				result = false;
		//			}
		//			else
		//			{
		//				result = true;
		//			}
		//		}
		//		break;
		//	case VALUE_TYPE.POINT_3D:
		//	{
		//		Vector3 vector;
		//		if (Function.TryGetVector3(s, out vector))
		//		{
		//			result = vector;
		//		}
		//		break;
		//	}
		//	}
		//	return result;
		//}

		// Token: 0x040000AE RID: 174
		public const char CONNECT_WORD = ',';
	}
}
