using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ActionScript
{
	// Token: 0x02000039 RID: 57
	public class ScriptAction : ScriptNode
	{
		// Token: 0x0600013A RID: 314 RVA: 0x00002E99 File Offset: 0x00001099
		public ScriptAction()
		{
			base.Type = 2;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000242F4 File Offset: 0x000224F4
		public override bool Evaluate()
		{
			if (GameData.Instance == null)
			{
				return false;
			}
			if (this.param == null || this.param.Length == 0)
			{
				GameData.Instance.ScrMan.Exec(this.scriptId);
			}
			object[] array = new object[this.param.Length];
			for (int i = 0; i < this.param.Length; i++)
			{
				//array[i] = Function.ConvertParam((VALUE_TYPE)this.param[i].Key, this.param[i].Value);
				//if (array[i] == null)
				//{
				//	Debug.Log("5..................................");
				//	return false;
				//}
			}
			GameData.Instance.ScrMan.Exec(this.scriptId, array);
			return true;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x000243B8 File Offset: 0x000225B8
		public override void WritData(TextWriter writer)
		{
			List<string> list = new List<string>();
			list.Add(this.scriptId.ToString());
			list.Add(this.param.Length.ToString());
			for (int i = 0; i < this.param.Length; i++)
			{
				list.Add(this.param[i].Key.ToString());
				list.Add(this.param[i].Value);
			}
			writer.WriteLine(Function.CombineString(list));
		}

		// Token: 0x040000AA RID: 170
		public int scriptId;

		// Token: 0x040000AB RID: 171
		public KeyValuePair<int, string>[] param = new KeyValuePair<int, string>[0];
	}
}
