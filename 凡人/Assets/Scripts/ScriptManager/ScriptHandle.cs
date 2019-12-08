using System;
using System.Collections.Generic;
using System.IO;

namespace ActionScript
{
	// Token: 0x02000036 RID: 54
	public class ScriptHandle : ScriptNode
	{
		// Token: 0x0600011A RID: 282 RVA: 0x00002D22 File Offset: 0x00000F22
		public ScriptHandle()
		{
			this.Name = "事件处理";
			base.Type = 1;
			//base.AddChild(new ConditionContainer());
			//base.AddChild(new ActionContainer());
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00002D52 File Offset: 0x00000F52
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00002D5A File Offset: 0x00000F5A
		public string Name { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00002D63 File Offset: 0x00000F63
		//public ConditionContainer ConditionContainer
		//{
		//	get
		//	{
		//		return (ConditionContainer)this.child[0];
		//	}
		//}

		//// Token: 0x17000018 RID: 24
		//// (get) Token: 0x0600011E RID: 286 RVA: 0x00002D76 File Offset: 0x00000F76
		//public ActionContainer ActionContainer
		//{
		//	get
		//	{
		//		return (ActionContainer)this.child[1];
		//	}
		//}

		// Token: 0x0600011F RID: 287 RVA: 0x00002D89 File Offset: 0x00000F89
		public override bool Evaluate()
		{
			if (base.Child.Count < 2)
			{
				return false;
			}
			if (!base.Child[0].Evaluate())
			{
				return false;
			}
			base.Child[1].Evaluate();
			return true;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00002DC9 File Offset: 0x00000FC9
		public override void WritData(TextWriter writer)
		{
			writer.WriteLine(this.Name);
			base.WritData(writer);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00023D18 File Offset: 0x00021F18
		public override void ReadData(TextReader reader)
		{
			string text = reader.ReadLine();
			this.Name = text;
			text = reader.ReadLine();
			int num = int.Parse(text);
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					//ScriptNode scriptNode = this.ReadConditionNode(reader, null);
					//if (scriptNode != null)
					//{
					//	base.Child[0].AddChild(scriptNode);
					//}
				}
			}
			text = reader.ReadLine();
			num = int.Parse(text);
			if (num > 0)
			{
				for (int j = 0; j < num; j++)
				{
					ScriptAction scriptAction = new ScriptAction();
					text = reader.ReadLine();
					string[] array = Function.SplitString(text);
					int num2 = 0;
					scriptAction.scriptId = int.Parse(array[num2++]);
					int num3 = int.Parse(array[num2++]);
					scriptAction.param = new KeyValuePair<int, string>[num3];
					for (int k = 0; k < num3; k++)
					{
						int key = int.Parse(array[num2++]);
						string value = array[num2++];
						scriptAction.param[k] = new KeyValuePair<int, string>(key, value);
					}
					base.Child[1].AddChild(scriptAction);
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00023E58 File Offset: 0x00022058
		//private ScriptNode ReadConditionNode(TextReader reader, ScriptNode top)
		//{
		//	string str = reader.ReadLine();
		//	string[] array = Function.SplitString(str);
		//	int num = 0;
		//	if (array.Length == 0)
		//	{
		//		return null;
		//	}
		//	int num2 = int.Parse(array[num++]);
		//	//if (num2 == 3)
		//	//{
		//	//	if (array.Length < 2)
		//	//	{
		//	//		return null;
		//	//	}
		//	//	//ConditionOne conditionOne = new ConditionOne();
		//	//	if (top != null)
		//	//	{
		//	//		top.AddChild(conditionOne);
		//	//	}
		//	//	conditionOne.conditionID = int.Parse(array[num++]);
		//	//	int num3 = int.Parse(array[num++]);
		//	//	conditionOne.param = new KeyValuePair<int, string>[num3];
		//	//	for (int i = 0; i < num3; i++)
		//	//	{
		//	//		int key = int.Parse(array[num++]);
		//	//		string value = array[num++];
		//	//		conditionOne.param[i] = new KeyValuePair<int, string>(key, value);
		//	//	}
		//	//	return conditionOne;
		//	//}
		//	//else if (num2 == 4)
		//	//{
		//	//	if (array.Length < 2)
		//	//	{
		//	//		return null;
		//	//	}
		//	//	int num4 = int.Parse(array[num++]);
		//	//	//ConditionAnd conditionAnd = new ConditionAnd();
		//	//	if (top != null)
		//	//	{
		//	//		top.AddChild(conditionAnd);
		//	//	}
		//	//	if (num4 > 0)
		//	//	{
		//	//		for (int j = 0; j < num4; j++)
		//	//		{
		//	//			this.ReadConditionNode(reader, conditionAnd);
		//	//		}
		//	//	}
		//	//	return conditionAnd;
		//	//}
		//	//else if (num2 == 8)
		//	//{
		//	//	if (array.Length < 2)
		//	//	{
		//	//		return null;
		//	//	}
		//	//	int num5 = int.Parse(array[num++]);
		//	//	ConditionNot conditionNot = new ConditionNot();
		//	//	if (top != null)
		//	//	{
		//	//		top.AddChild(conditionNot);
		//	//	}
		//	//	if (num5 > 0)
		//	//	{
		//	//		for (int k = 0; k < num5; k++)
		//	//		{
		//	//			this.ReadConditionNode(reader, conditionNot);
		//	//		}
		//	//	}
		//	//	return conditionNot;
		//	//}
		//	//else
		//	//{
		//	//	if (array.Length < 2)
		//	//	{
		//	//		return null;
		//	//	}
		//	//	int num6 = int.Parse(array[num++]);
		//	//	ConditionOr conditionOr = new ConditionOr();
		//	//	if (top != null)
		//	//	{
		//	//		top.AddChild(conditionOr);
		//	//	}
		//	//	if (num6 > 0)
		//	//	{
		//	//		for (int l = 0; l < num6; l++)
		//	//		{
		//	//			this.ReadConditionNode(reader, conditionOr);
		//	//		}
		//	//	}
		//	//	return conditionOr;
		//	//}
		//}

		// Token: 0x06000123 RID: 291 RVA: 0x0002404C File Offset: 0x0002224C
		private void WritConditionNode(TextWriter writer, ScriptNode top)
		{
			List<string> list = new List<string>();
			list.Add(top.Type.ToString());
			if (top.Type == 3)
			{
				//ConditionOne conditionOne = (ConditionOne)top;
				//list.Add(conditionOne.conditionID.ToString());
				//list.Add(conditionOne.param.Length.ToString());
				//for (int i = 0; i < conditionOne.param.Length; i++)
				//{
				//	list.Add(conditionOne.param[i].Key.ToString());
				//	list.Add(conditionOne.param[i].Value);
				//}
			}
			else
			{
				list.Add(top.Child.Count.ToString());
			}
			writer.WriteLine(Function.CombineString(list));
		}
	}
}
