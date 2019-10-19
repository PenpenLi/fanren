using System;
using UnityEngine;


[Serializable]
public class OperableSaveDataBase
{
    public int id;

    public OperableItemBase.OperableItemType type;

    public bool bState;

    public int index;

    public bool useAble;

    public virtual void PrintData()
	{
        Debug.Log(
			string.Concat(new object[]
			{
				"Operable    id:",
				this.id,
				",type:",
				this.type,
				",bState:",
				this.bState,
				",index:",
				this.index,
				",useAble:",
				this.useAble,
				"."
			}));
	}
}
