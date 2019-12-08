using System;
using UnityEngine;

public class SM_ActionScript
{
	public void Exec(int par)
	{
        Debug.Log(par);
        //Singleton<ScriptDataManager>.GetInstance().RunScript(par);
    }
}
