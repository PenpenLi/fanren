using System;
using System.Collections.Generic;
using UnityUtility;

// Token: 0x0200002F RID: 47
public class ScriptConditionData : Singleton<ScriptConditionData>
{
	// Token: 0x06000114 RID: 276 RVA: 0x00005CC8 File Offset: 0x00003EC8
	public ScriptConditionData()
	{
		this.ReadConfig();
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00005CE4 File Offset: 0x00003EE4
	public string GetConditionName(int id)
	{
		if (this.conditionName.ContainsKey(id))
		{
			return this.conditionName[id];
		}
		return string.Empty;
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00005D0C File Offset: 0x00003F0C
	private void ReadConfig()
	{
		List<string> list = new List<string>();
		list = UtilityLoader.LoadConfText("conf/ScriptCondition");
		if (list.Count == 0)
		{
			return;
		}
		int i = 0;
		while (i < list.Count)
		{
			string text = list[i++];
			int key = int.Parse(text.ToString());
			string value = list[i++];
			this.conditionName.Add(key, value);
		}
	}

	// Token: 0x0400007A RID: 122
	private const string CONFIG_PATH = "conf/ScriptCondition";

	// Token: 0x0400007B RID: 123
	private Dictionary<int, string> conditionName = new Dictionary<int, string>();
}
