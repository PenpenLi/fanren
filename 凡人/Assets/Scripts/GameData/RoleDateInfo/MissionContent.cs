using System;
using UnityEngine;

public class MissionContent
{
    public const int DETAIL_STR = 97;

    public const int COMPLETE_STR = 98;

    public const int UNCOMPLETE_STR = 99;

    public int ID;

    public int StrStep;

    public string Str;

    public bool bIsSucceed;

    public bool SetMissionID(int nID)
	{
		if (nID <= -2147483648 || nID >= 2147483647)
		{
            Debug.Log(new object[]
            {
                "Mission file Val Range Error!"
            });
            return false;
		}
		this.ID = nID;
		return true;
	}

	public bool SetStepID(int nStep)
	{
		if (nStep <= -2147483648 || nStep >= 2147483647)
		{
            Debug.Log(new object[]
            {
                "Mission file Val Range Error!"
            });
            return false;
		}
		this.StrStep = nStep;
		return true;
	}
}
