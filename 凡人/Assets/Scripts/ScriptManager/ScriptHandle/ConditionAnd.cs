using System;
using System.Collections.Generic;
using System.IO;

namespace ActionScript
{
	// Token: 0x0200003E RID: 62
	public class ConditionAnd : ScriptNode
	{
		// Token: 0x06000148 RID: 328 RVA: 0x00006BC4 File Offset: 0x00004DC4
		public ConditionAnd()
		{
			base.Type = 4;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00006BD4 File Offset: 0x00004DD4
		public override bool Evaluate()
		{
			if (base.Child.Count == 0)
			{
				return true;
			}
			foreach (ScriptNode scriptNode in base.Child)
			{
				if (!scriptNode.Evaluate())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00006C5C File Offset: 0x00004E5C
		public override void ReadData(TextReader reader)
		{
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00006C60 File Offset: 0x00004E60
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
