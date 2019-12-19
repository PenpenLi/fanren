using System;

namespace ActionScript
{
	// Token: 0x0200003D RID: 61
	public class ConditionNot : ScriptNode
	{
		// Token: 0x06000146 RID: 326 RVA: 0x00006B30 File Offset: 0x00004D30
		public ConditionNot()
		{
			base.Type = 8;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00006B40 File Offset: 0x00004D40
		public override bool Evaluate()
		{
			if (base.Child.Count == 0)
			{
				return true;
			}
			bool result = false;
			foreach (ScriptNode scriptNode in base.Child)
			{
				if (!scriptNode.Evaluate())
				{
					result = true;
				}
			}
			return result;
		}
	}
}
