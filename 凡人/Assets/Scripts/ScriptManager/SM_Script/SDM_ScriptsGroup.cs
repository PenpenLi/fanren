using System;
using System.Collections.Generic;
using UnityUtility;

// Token: 0x0200028E RID: 654
public class SDM_ScriptsGroup
{
	// Token: 0x0600114B RID: 4427 RVA: 0x000925BC File Offset: 0x000907BC
	public SDM_ScriptsGroup.ScriptsGroupDate GetScriptsGroupById(int id)
	{
		for (int i = 0; i < this.ScriptsGroupList.Count; i++)
		{
			if (id == this.ScriptsGroupList[i].ID)
			{
				return this.ScriptsGroupList[i];
			}
		}
		return null;
	}

	public void ReadData()
	{
		this.ScriptsGroupList.Clear();
		List<string> list = UtilityLoader.LoadConfText("conf/ScriptData/ScriptsGroup");
		int i = 0;
		while (i < list.Count)
		{
			SDM_ScriptsGroup.ScriptsGroupDate scriptsGroupDate = new SDM_ScriptsGroup.ScriptsGroupDate();
			scriptsGroupDate.ID = Convert.ToInt32(list[i]);
			i++;
			for (int j = 0; j < SDM_ScriptsGroup.MAX_SCRIPT_AMOUNT; j++)
			{
				int num = Convert.ToInt32(list[i]);
				i++;
				int sd = Convert.ToInt32(list[i]);
				i++;
				if (num >= 0)
				{
					SDM_ScriptsGroup.ScriptDate scriptDate = new SDM_ScriptsGroup.ScriptDate();
					scriptDate.smt = (ScrModType)num;
					scriptDate.sd = sd;
					scriptsGroupDate.ScriptsList.Add(scriptDate);
				}
			}
			this.ScriptsGroupList.Add(scriptsGroupDate);
		}
	}

	// Token: 0x04001261 RID: 4705
	public static int MAX_SCRIPT_AMOUNT = 5;

	// Token: 0x04001262 RID: 4706
	public List<SDM_ScriptsGroup.ScriptsGroupDate> ScriptsGroupList = new List<SDM_ScriptsGroup.ScriptsGroupDate>();

	// Token: 0x0200028F RID: 655
	public class ScriptDate
	{
		// Token: 0x04001263 RID: 4707
		public ScrModType smt;

		// Token: 0x04001264 RID: 4708
		public int sd;
	}

	// Token: 0x02000290 RID: 656
	public class ScriptsGroupDate
	{
		// Token: 0x04001265 RID: 4709
		public int ID;

		// Token: 0x04001266 RID: 4710
		public List<SDM_ScriptsGroup.ScriptDate> ScriptsList = new List<SDM_ScriptsGroup.ScriptDate>();
	}
}
