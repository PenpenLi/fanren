using System;
using System.Collections.Generic;
using System.IO;

namespace ActionScript
{
	// Token: 0x02000038 RID: 56
	public class ScriptNode
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00002E2D File Offset: 0x0000102D
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00002E35 File Offset: 0x00001035
		public int Type { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00002E3E File Offset: 0x0000103E
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00002E46 File Offset: 0x00001046
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

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00002E4F File Offset: 0x0000104F
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00002E57 File Offset: 0x00001057
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

		// Token: 0x06000133 RID: 307 RVA: 0x00002C8D File Offset: 0x00000E8D
		public virtual bool Evaluate()
		{
			return false;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00002E60 File Offset: 0x00001060
		public void AddChild(ScriptNode node)
		{
			if (node == null)
			{
				return;
			}
			this.child.Add(node);
			node.Father = this;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00002E7C File Offset: 0x0000107C
		public void ClearChild()
		{
			this.child.Clear();
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000221B File Offset: 0x0000041B
		public virtual void ReadData(TextReader reader)
		{
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00024298 File Offset: 0x00022498
		public virtual void WritData(TextWriter writer)
		{
			foreach (ScriptNode scriptNode in this.child)
			{
				scriptNode.WritData(writer);
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000029BC File Offset: 0x00000BBC
		public virtual ScriptNode Clone()
		{
			return null;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00002E89 File Offset: 0x00001089
		public void SetFather(ScriptNode theFather)
		{
			if (theFather == null)
			{
				return;
			}
			theFather.AddChild(this);
		}

		// Token: 0x040000A7 RID: 167
		protected List<ScriptNode> child = new List<ScriptNode>();

		// Token: 0x040000A8 RID: 168
		protected ScriptNode father;
	}
}
