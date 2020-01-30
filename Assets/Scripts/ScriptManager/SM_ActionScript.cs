using System;
using UnityEngine;
using YouYou;

public class SM_ActionScript
{
	public void Exec(int par)
	{
        GameEntry.ScriptData.RunScript(par);
    }
}
