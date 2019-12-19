using System;
using System.Collections.Generic;
using System.IO;

namespace ActionScript
{
	public class ConditionOne : ScriptNode
	{
        public int conditionID;

        public KeyValuePair<int, string>[] param = new KeyValuePair<int, string>[0];

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
                array[i] = Function.ConvertParam((VALUE_TYPE)this.param[i].Key, this.param[i].Value);
            }
            return ConditionFunction.ConditionAnalyse(this.conditionID, array);
        }

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
	}
}
