using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可操作物体基类
/// </summary>
public class OperableItemBase : CullableItem
{
    public int id;

    public OperableItemBase.OperableItemType type;

    public Role rTarget;

    public bool bState;

    public int index;

    public static int OPERABLE_INDEX;

    public bool useAble;

    protected GameObject effectGo;

    public static bool _bFCall;

    public enum OperableItemType
    {
        Op_NoneOp,
        Op_ChestOpe,
        Op_HerbalOpe,
        Op_MachineryOpe,
        Op_obstacleOpe,
        Op_OrganOpe,
        Op_SoulBall,
        Op_Corpse,
        Op_Npc
    }

    //public virtual bool Create(GameObjSpawn.SpawnInfo info, OperableItemInfoBase ni)
    //{
    //	return true;
    //}

    //public virtual bool CreateBySaveData(OperableSaveDataBase ocsd)
    //{
    //    return true;
    //}

    public virtual bool ActiveItem()
	{
		return true;
	}

	public virtual void CloseCallBack(List<int> idList)
	{
	}

	//public virtual OperableSaveDataBase GetSaveData()
	//{
	//	return null;
	//}

	public virtual void Call()
	{
	}

	public void EnableOperable(bool enable)
	{
		if (enable && !this.useAble)
		{
			if (this.effectGo != null)
			{
				this.effectGo.SetActiveRecursively(true);
			}
			this.useAble = true;
		}
		if (!enable && this.useAble)
		{
			if (this.effectGo != null)
			{
				this.effectGo.SetActiveRecursively(false);
			}
			this.useAble = false;
		}
	}
}
