using System;
using System.Collections.Generic;
using System.IO;

namespace ActionScript
{
	// Token: 0x0200003C RID: 60
	public class ConditionOr : ScriptNode
	{
		// Token: 0x06000143 RID: 323 RVA: 0x00002EDE File Offset: 0x000010DE
		public ConditionOr()
		{
			base.Type = 5;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000245F8 File Offset: 0x000227F8
		public override bool Evaluate()
		{
			if (base.Child.Count == 0)
			{
				return true;
			}
			foreach (ScriptNode scriptNode in base.Child)
			{
				if (scriptNode.Evaluate())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00024674 File Offset: 0x00022874
		public override void WritData(TextWriter writer)
		{
			writer.WriteLine(Function.CombineString(new List<string>
			{
				base.Type.ToString(),
				base.Child.Count.ToString()
			}));
			base.WritData(writer);
		}
	}
}
