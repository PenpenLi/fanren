using System;
using System.Collections.Generic;
using System.IO;

namespace ActionScript
{   
    public class ScriptNode
	{
        protected List<ScriptNode> child = new List<ScriptNode>();

        protected ScriptNode father;

        public int Type { get; set; }

		public List<ScriptNode> Child
		{
			get
			{
				return this.child;
			}
			set
			{
				this.child = value;
			}
		}

		public ScriptNode Father
		{
			get
			{
				return this.father;
			}
			set
			{
				this.father = value;
			}
		}

		public virtual bool Evaluate()
		{
			return false;
		}

		public void AddChild(ScriptNode node)
		{
			if (node == null)
			{
				return;
			}
			this.child.Add(node);
			node.Father = this;//父物体
		}

		public void ClearChild()
		{
			this.child.Clear();
		}

		public virtual void ReadData(TextReader reader)
		{
		}

		public virtual void WritData(TextWriter writer)
		{
			foreach (ScriptNode scriptNode in this.child)
			{
				scriptNode.WritData(writer);
			}
		}

		public virtual ScriptNode Clone()
		{
			return null;
		}

		public void SetFather(ScriptNode theFather)
		{
			if (theFather == null)
			{
				return;
			}
			theFather.AddChild(this);
		}
	}
}
