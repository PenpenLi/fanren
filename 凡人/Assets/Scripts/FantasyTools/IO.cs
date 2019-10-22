using System;
using System.Collections.Generic;
using UnityEngine;

namespace FantasyTools
{
	// Token: 0x0200026A RID: 618
	public class IO
	{
		// Token: 0x06001074 RID: 4212 RVA: 0x0008D4DC File Offset: 0x0008B6DC
		public static List<string> LoadConfInAssets(string filename)
		{
			TextAsset textAsset = (TextAsset)ResourceLoader.Load(filename, typeof(TextAsset));
			if (textAsset == null)
			{
				return null;
			}
			string[] array = textAsset.text.Split(IO.sep_newline, StringSplitOptions.None);
			List<string> list = new List<string>();
			foreach (string text in array)
			{
				if (text.Length != 0)
				{
					string text2 = text.Trim();
					if (text2.IndexOf(IO.sep_note) != 0)
					{
						list.Add(text2);
					}
				}
			}
			return list;
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0008D580 File Offset: 0x0008B780
		public static Dictionary<string, List<string>> LoadConfig(string filename)
		{
			TextAsset textAsset = (TextAsset)ResourceLoader.Load(filename, typeof(TextAsset));
			if (textAsset == null)
			{
				return null;
			}
			string[] array = textAsset.text.Split(IO.sep_newline, StringSplitOptions.None);
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			foreach (string text in array)
			{
				if (text.Length != 0)
				{
					string text2 = text.Trim();
					if (text2.IndexOf(IO.sep_note) != 0)
					{
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array3 = text2.Split(IO.sep_signeC);
							if (array3 != null && array3.Length >= 1)
							{
								string key = array3[0];
								List<string> list = (!dictionary.ContainsKey(key)) ? new List<string>() : dictionary[key];
								if (array3.Length > 1)
								{
									string[] array4 = array3[1].Split(IO.sep_signeA);
									foreach (string item in array4)
									{
										list.Add(item);
									}
								}
								else
								{
									list.Add("null");
								}
								if (!dictionary.ContainsKey(key))
								{
									dictionary.Add(key, list);
								}
							}
						}
					}
				}
			}
			return dictionary;
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x0008D6E8 File Offset: 0x0008B8E8
		public static Dictionary<int, List<string>> LoadSkinAndStyleFile(string filename)
		{
			TextAsset textAsset = (TextAsset)ResourceLoader.Load(filename, typeof(TextAsset));
			if (textAsset == null)
			{
				return null;
			}
			string[] array = textAsset.text.Split(IO.sep_newline, StringSplitOptions.None);
			Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
			foreach (string text in array)
			{
				if (text.Length != 0)
				{
					string text2 = text.Trim();
					if (text2.IndexOf(IO.sep_note) != 0)
					{
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array3 = text2.Split(IO.sep_signeB);
							if (array3 != null && array3.Length >= 2)
							{
								int key = Convert.ToInt32(array3[0]);
								for (int j = 1; j < array3.Length; j++)
								{
									if (dictionary.ContainsKey(key))
									{
										dictionary[key].Add(array3[j]);
									}
									else
									{
										dictionary.Add(key, new List<string>
										{
											array3[j]
										});
									}
								}
							}
						}
					}
				}
			}
			if (Application.isEditor)
			{
				Debug.Log(string.Concat(new object[]
				{
					" LoadSkinAndStyleFile ",
					filename,
					" End. Total count = ",
					dictionary.Count
				}));
			}
			return dictionary;
		}

		// Token: 0x04001183 RID: 4483
		public static string[] sep_newline = new string[]
		{
			"\n"
		};

		// Token: 0x04001184 RID: 4484
		public static char sep_note = '#';

		// Token: 0x04001185 RID: 4485
		public static char[] sep_signeA = new char[]
		{
			';'
		};

		// Token: 0x04001186 RID: 4486
		public static char[] sep_signeB = new char[]
		{
			'\t'
		};

		// Token: 0x04001187 RID: 4487
		public static char[] sep_signeC = new char[]
		{
			'='
		};

		// Token: 0x04001188 RID: 4488
		public static char[] sep_signeD = new char[]
		{
			'/'
		};
	}
}
