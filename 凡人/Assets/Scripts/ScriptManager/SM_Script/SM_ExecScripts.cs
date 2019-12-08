using System;
using UnityEngine;

internal class SM_ExecScripts
{
	public void Exec(int par)
	{
		SDM_ScriptsGroup.ScriptsGroupDate scriptsGroupById = GameData.Instance.SDM_ScrGro.GetScriptsGroupById(par);
      
        if (scriptsGroupById == null)
		{
			return;
		}
		foreach (SDM_ScriptsGroup.ScriptDate scriptDate in scriptsGroupById.ScriptsList)
		{
            Debug.Log(scriptDate.smt);
            Debug.Log(scriptDate.sd);
            if (scriptDate != null && scriptDate.smt >= ScrModType.SMT_NpcTalk_1)
			{
				GameData.Instance.ScrMan.Exec((int)scriptDate.smt, scriptDate.sd);
			}
		}
	}
}
