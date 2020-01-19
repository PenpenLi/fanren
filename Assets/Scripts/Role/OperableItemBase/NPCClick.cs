using System;
using UnityEngine;
using YouYou;

/// <summary>
/// NPC点击
/// </summary>
public class NPCClick : OperableItemBase
{
    private NPCEntity ni;

    //public static bool _bCall;

    //public NPCEntity NI
    //{
    //    get
    //    {
    //        return this.ni;
    //    }
    //    set
    //    {
    //        this.ni = value;
    //    }
    //}

    //public new void Start()
    //{
    //    //this.type = OperableItemBase.OperableItemType.Op_Npc;
    //    //this.useAble = true;
    //    //this.index = OperableItemBase.OPERABLE_INDEX;
    //    //OperableItemBase.OPERABLE_INDEX++;
    //}

    public override void Call()
    {
        //GameEntry.UI.OpenUIForm(3);

        GameEntry.Scene.LoadScene(3, onComplete: () =>
        {
            GameEntry.Procedure.ChangeState(ProcedureState.GameLevel);
        });
        //if (npc2 != null)
        //{
        //  
        //    if (npc2.info.scriptModID == 35 || npc2.info.scriptModID == 59)
        //    {
        //        GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID);
        //        ModControlMFS modControlMFS = npc2.GetModule(MODULE_TYPE.MT_CONTROL_MFS) as ModControlMFS;
        //        modControlMFS.ChangeStateToIdle();
        //        return;
        //    }
        //    if (npc2.info.scriptModID == 37)
        //    {
        //        Player role = (Player)SceneManager.RoleMan.GetRole(1);
        //        GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID, role);
        //    }
        //    else if (npc2.info.scriptModID == 46)
        //    {
        //        GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID);
        //    }
        //    else
        //    {
        //        if (MovieManager.MovieMag.IsPlaying())
        //        {
        //            GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID, 0);
        //        }
        //        else
        //        {
        //            GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID, 1);
        //        }
        //        ModControlMFS modControlMFS2 = npc2.GetModule(MODULE_TYPE.MT_CONTROL_MFS) as ModControlMFS;
        //        modControlMFS2.ChangeStateToIdle();
        //    }
        //}
    }

    //	public void OnDestroy()
    //	{
    //		if (base.transform != null && GUIControl.OpeText != null)
    //		{
    //			GUIControl.OpeText.active = false;
    //		}
    //	}
}
