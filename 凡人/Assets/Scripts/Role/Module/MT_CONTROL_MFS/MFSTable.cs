using System;
using System.Collections.Generic;
using UnityEngine;


public class MFSTable
{
    private bool[,] m_mapEventTable = new bool[33, 31];

    public void TextRead(List<string> infoList, ref int index)
	{
		for (int i = 0; i < 33; i++)
		{
			for (int j = 0; j < 31; j++)
			{
				this.m_mapEventTable[i, j] = Convert.ToBoolean(infoList[index++]);
			}
		}
	}

	public void PrintData()
	{
		for (int i = 0; i < 33; i++)
		{
			for (int j = 0; j < 31; j++)
			{
				Debug.Log(string.Concat(new object[]
				{
					((CONTROL_INPUT)i).ToString(),
					"-",
					((CONTROL_STATE)j).ToString(),
					":",
					this.m_mapEventTable[i, j]
				}));
			}
		}
	}

	public bool GetTableData(CONTROL_INPUT ci, CONTROL_STATE cs)
	{
		return this.m_mapEventTable[(int)ci, (int)cs];
	}
}
