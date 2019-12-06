using System;
using FantasyTools;
using UnityEngine;


public class FantasyAssist
{
    public static FantasyAssist Instance;

    public bool IsCreated;

    public FantasyTimer TimerMan = new FantasyTimer();

    private ExecuteInfosCenter _executeInfos = new ExecuteInfosCenter();

    public ExecuteInfosCenter ExecuteInfos
    {
        get
        {
            if (this._executeInfos == null)
            {
                this._executeInfos = new ExecuteInfosCenter();
                if (!this.ExecuteInfos.LoadExecuteInfos())
                {
                    Debug.LogWarning("ExecuteInfosCenter error !");
                }
            }
            return this._executeInfos;
        }
    }

    public bool Create()
	{
		FantasyAssist.Instance = this;
        if (!this.ExecuteInfos.LoadExecuteInfos())
        {
            return false;
        }
        this.IsCreated = true;
		return true;
	}

	public void FixUpdate()
	{
	}

	public void Update()
	{
		//this.TimerMan.Update();
	}
}
