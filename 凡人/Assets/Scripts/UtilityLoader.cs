using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityUtility
{
	public class UtilityLoader
	{
        public delegate void CallBack(UnityEngine.Object obj);

        public static IEnumerator Load(string path, UtilityLoader.CallBack cb)
		{
			WWW _www = new WWW(path);
			yield return _www;
			if (_www.error != null)
			{
				Debug.Break();
				Debug.LogError("There is something wrong in the WWW.");
			}
			else
			{
				cb(_www.assetBundle.mainAsset);
			}
			yield break;
		}

		public static UnityEngine.Object Load(string path)
		{
			return Resources.Load(path);
		}

		public static List<string> LoadConfText(string filename)
		{
			TextAsset textAsset = (TextAsset)ResourceLoader.Load(filename, typeof(TextAsset));
			if (textAsset == null)
			{
				Debug.Log("(UL)Can't find file:" + filename);
				return null;
			}
			string[] separator = new string[]
			{
				"\t"
			};
			string[] array = textAsset.text.Split(separator, StringSplitOptions.None);
			List<string> list = new List<string>();
			foreach (string text in array)
			{
				string[] array3 = text.Split("\r\n".ToCharArray(), StringSplitOptions.None);
				foreach (string text2 in array3)
				{
					if (text2.Length != 0 && text2[0] != '\r' && !text2.StartsWith("#"))
					{
						list.Add(text2);
					}
				}
			}
			Resources.UnloadAsset(textAsset);
			return list;
		}
	}
}
