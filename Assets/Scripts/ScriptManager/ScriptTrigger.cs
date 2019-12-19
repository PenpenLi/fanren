using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ActionScript
{
	public class ScriptTrigger : ScriptNode
	{
		public ScriptTrigger()
		{
            base.AddChild(new ScriptHandle());
            base.Type = 0;
        }

		public int ID { get; set; }

		public string Name { get; set; }

		public override bool Evaluate()
		{
			foreach (ScriptNode scriptNode in this.child)
			{
				scriptNode.Evaluate();
			}
			return true;
		}

		public override void ReadData(TextReader reader)
		{
			base.Child.Clear();//子脚本清空
            string str = reader.ReadLine();
            string[] array = Function.SplitString(str);
            int num = 0;
            this.ID = int.Parse(array[num++]);//触发ID
            this.Name = array[num++];//名称
            int num2 = int.Parse(array[num++]);//事件数量
            if (num2 > 0)
            {
                for (int i = 0; i < num2; i++)
                {
                    ScriptHandle scriptHandle = new ScriptHandle();
                    scriptHandle.ReadData(reader);
                    base.AddChild(scriptHandle);
                }
            }
        }

		public override void WritData(TextWriter writer)
		{
			writer.WriteLine(Function.CombineString(new List<string>
			{
				this.ID.ToString(),
				this.Name,
				this.child.Count.ToString()
			}));
			for (int i = 0; i < this.child.Count; i++)
			{
				this.child[i].WritData(writer);
			}
		}
	}
}
