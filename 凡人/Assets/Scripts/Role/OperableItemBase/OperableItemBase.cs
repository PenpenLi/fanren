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

    //Token: 0x0600186B RID: 6251 RVA: 0x000BCC34 File Offset: 0x000BAE34

    //public virtual bool CreateBySaveData(OperableSaveDataBase ocsd)
    //{
    //    return true;
    //}

    // Token: 0x0600186C RID: 6252 RVA: 0x000BCC38 File Offset: 0x000BAE38
    public virtual bool ActiveItem()
	{
		return true;
	}

	// Token: 0x0600186D RID: 6253 RVA: 0x000BCC3C File Offset: 0x000BAE3C
	public virtual void CloseCallBack(List<int> idList)
	{
	}

	//public virtual OperableSaveDataBase GetSaveData()
	//{
	//	return null;
	//}

	// Token: 0x0600186F RID: 6255 RVA: 0x000BCC44 File Offset: 0x000BAE44
	public virtual void Call()
	{
	}

	// Token: 0x06001870 RID: 6256 RVA: 0x000BCC48 File Offset: 0x000BAE48
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
