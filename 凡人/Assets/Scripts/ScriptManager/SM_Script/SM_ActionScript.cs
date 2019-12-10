using System;
using UnityEngine;

public class SM_ActionScript
{
	public void Exec(int par)
	{
        Singleton<ScriptDataManager>.GetInstance().RunScript(3107001);
        //Singleton<ScriptDataManager>.GetInstance().RunScript(par);
    }
}
