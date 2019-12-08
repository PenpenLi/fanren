using System;
using System.IO;
using UnityEngine;

namespace ActionScript
{
	/// <summary>
    /// 条件容器
    /// </summary>
	public class ConditionContainer : ScriptNode
	{

		public ConditionContainer()
		{
			base.Type = 6;
		}


		public override bool Evaluate()
		{
			foreach (ScriptNode scriptNode in this.child)
			{
                Debug.Log(scriptNode);
                if (!scriptNode.Evaluate())
				{
					return false;
				}
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
