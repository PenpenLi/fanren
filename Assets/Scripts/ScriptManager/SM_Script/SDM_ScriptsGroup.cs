using System;
using System.Collections.Generic;
using UnityUtility;


public class SDM_ScriptsGroup
{
    public static int MAX_SCRIPT_AMOUNT = 5;

    public List<SDM_ScriptsGroup.ScriptsGroupDate> ScriptsGroupList = new List<SDM_ScriptsGroup.ScriptsGroupDate>();

    public class ScriptDate
    {
        public ScrModType smt;

        public int sd;
    }

    public class ScriptsGroupDate
    {
        public int ID;

        public List<SDM_ScriptsGroup.ScriptDate> ScriptsList = new List<SDM_ScriptsGroup.ScriptDate>();
    }

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
}
