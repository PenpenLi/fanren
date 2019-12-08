using System;
using System.Collections.Generic;
using System.IO;
using ActionScript;
using UnityEngine;

/// <summary>
/// 脚本数据管理
/// </summary>
public class ScriptDataManager : Singleton<ScriptDataManager>
{
    private const string CONFIG_PATH = "conf/ScriptData/ActionScript";

    private string ConfigPath = Application.dataPath + "\\Resources\\conf\\ScriptData\\ActionScript.txt";

    /// <summary>
    /// 脚本触发数据
    /// </summary>
    private Dictionary<int, ScriptTrigger> ScriptTriggerData = new Dictionary<int, ScriptTrigger>();

    public ScriptDataManager()
	{
		this.ReadData();
	}

	public bool RunScript(int id)
	{
        Debug.Log(id);
        return this.ScriptTriggerData.ContainsKey(id)&& this.ScriptTriggerData[id].Evaluate();
    }

	private void ReadData()
	{
		this.ScriptTriggerData.Clear();
		TextAsset textAsset = (TextAsset)ResourceLoader.Load("conf/ScriptData/ActionScript", typeof(TextAsset));
		if (textAsset == null)
		{
			return;
		}
        using (StringReader stringReader = new StringReader(textAsset.text))
        {
            while (stringReader.Peek() >= 0)
            {
                string str = stringReader.ReadLine();
                string[] array = Function.SplitString(str);
                if (array.Length == 0)
                {
                    break;
                }          
                int num = int.Parse(array[0]);
                for (int i = 0; i < num; i++)
                {
                    ScriptTrigger scriptTrigger = new ScriptTrigger();
                    scriptTrigger.ReadData(stringReader);
                    this.ScriptTriggerData.Add(scriptTrigger.ID, scriptTrigger);
                }
            }
        }
    }
}
