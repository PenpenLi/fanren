using System;
using System.Collections.Generic;
using System.IO;

namespace ActionScript
{
	public class ConditionOne : ScriptNode
	{
		public ConditionOne()
		{
			base.Type = 3;
		}

		public override bool Evaluate()
		{
			if (false || this.param.Length == 0)
			{
				return false;
			}
			object[] array = new object[this.param.Length];
			for (int i = 0; i < this.param.Length; i++)
			{
				//array[i] = Function.ConvertParam((VALUE_TYPE)this.param[i].Key, this.param[i].Value);
			}
			//return ConditionFunction.ConditionAnalyse(this.conditionID, array);
            return false;
        }

		// Token: 0x06000142 RID: 322 RVA: 0x00006998 File Offset: 0x00004B98
		public override void WritData(TextWriter writer)
		{
			List<string> list = new List<string>();
			list.Add(base.Type.ToString());
			list.Add(this.conditionID.ToString());
			list.Add(this.param.Length.ToString());
			for (int i = 0; i < this.param.Length; i++)
			{
				list.Add(this.param[i].Key.ToString());
				list.Add(this.param[i].Value);
			}
			writer.WriteLine(Function.CombineString(list));
		}

		// Token: 0x040000AC RID: 172
		public int conditionID;

		// Token: 0x040000AD RID: 173
		public KeyValuePair<int, string>[] param = new KeyValuePair<int, string>[0];
	}
}
