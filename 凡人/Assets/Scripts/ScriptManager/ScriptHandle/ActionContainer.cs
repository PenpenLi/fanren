using System;
using System.IO;

namespace ActionScript
{

    /// <summary>
    /// 行动容器
    /// </summary>
	public class ActionContainer : ScriptNode
	{
		
		public ActionContainer()
		{
			base.Type = 7;
		}

		public override bool Evaluate()
		{
			foreach (ScriptNode scriptNode in this.child)
			{
				scriptNode.Evaluate();
			}
			return true;
		}

		public override void WritData(TextWriter writer)
		{
			writer.WriteLine(base.Child.Count.ToString());
			foreach (ScriptNode scriptNode in this.child)
			{
				scriptNode.WritData(writer);
			}
		}
	}
}
