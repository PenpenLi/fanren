using System;
using UnityEngine;

//NPC点击
public class NPCClick : OperableItemBase
{
    //	// Token: 0x1700028C RID: 652
    //	// (get) Token: 0x06001821 RID: 6177 RVA: 0x000B9F68 File Offset: 0x000B8168
    //	// (set) Token: 0x06001820 RID: 6176 RVA: 0x000B9F5C File Offset: 0x000B815C
    //	public NpcInfo NI
    //	{
    //		get
    //		{
    //			return this.ni;
    //		}
    //		set
    //		{
    //			this.ni = value;
    //		}
    //	}

    //	// Token: 0x06001822 RID: 6178 RVA: 0x000B9F70 File Offset: 0x000B8170
    //	public new void Start()
    //	{
    //		this.type = OperableItemBase.OperableItemType.Op_Npc;
    //		this.useAble = true;
    //		this.index = OperableItemBase.OPERABLE_INDEX;
    //		OperableItemBase.OPERABLE_INDEX++;
    //		this.myTransform = base.transform;
    //	}

    //	// Token: 0x06001823 RID: 6179 RVA: 0x000B9FA4 File Offset: 0x000B81A4
    //	public void OnTriggerStay(Collider Collision)
    //	{
    //		if (Collision.gameObject.tag == "Player")
    //		{
    //			Npc npc = RoleBaseFun.GetRoleScriptFromGo(base.transform.gameObject) as Npc;
    //			if (npc.info.scriptModID != -1 && !OperableItemBase._bFCall && !MovieManager.MovieMag.IsPlaying())
    //			{
    //				GUIControl.OpeText.active = true;
    //			}
    //			Player player = SceneManager.RoleMan.GetPlayer();
    //			if (player != null)
    //			{
    //				player.AddEnableOperable(this);
    //			}
    //			NPCClick._bCall = true;
    //			ModControlMFS modControlMFS = npc.GetModule(MODULE_TYPE.MT_CONTROL_MFS) as ModControlMFS;
    //			modControlMFS.ChangeState(new ControlEventIdle(false));
    //		}
    //	}

    //	// Token: 0x06001824 RID: 6180 RVA: 0x000BA050 File Offset: 0x000B8250
    //	public override void Call()
    //	{
    //		Npc npc = RoleBaseFun.GetRoleScriptFromGo(base.transform.gameObject) as Npc;
    //		if (npc != null && npc.info.scriptModID == 57 && RoleBaseFun.IsPlayerInFight())
    //		{
    //			SM_HelpEnable.ExecHelp(1000829);
    //			return;
    //		}
    //		OperableItemBase._bFCall = true;
    //		GUIControl.OpeText.active = false;
    //		Npc npc2 = RoleBaseFun.GetRoleScriptFromGo(base.transform.gameObject) as Npc;
    //		if (npc2 != null)
    //		{
    //			if (npc2.info.scriptModID == 57)
    //			{
    //				Player player = (Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId);
    //				if (player != null)
    //				{
    //					if (!player.m_RoleGrowDatas._dicNPC.ContainsKey(npc2.ID))
    //					{
    //						player.m_RoleGrowDatas._dicNPC.Add(npc2.ID, false);
    //					}
    //					PlayerUIManager._iNPC = npc2.ID;
    //				}
    //			}
    //			if (npc2.info.scriptModID == 35 || npc2.info.scriptModID == 59)
    //			{
    //				GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID);
    //				ModControlMFS modControlMFS = npc2.GetModule(MODULE_TYPE.MT_CONTROL_MFS) as ModControlMFS;
    //				modControlMFS.ChangeStateToIdle();
    //				return;
    //			}
    //			if (npc2.info.scriptModID == 37)
    //			{
    //				Player role = (Player)SceneManager.RoleMan.GetRole(1);
    //				GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID, role);
    //			}
    //			else if (npc2.info.scriptModID == 46)
    //			{
    //				GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID);
    //			}
    //			else
    //			{
    //				if (MovieManager.MovieMag.IsPlaying())
    //				{
    //					GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID, 0);
    //				}
    //				else
    //				{
    //					GameData.Instance.ScrMan.Exec(npc2.info.scriptModID, npc2.info.scriptDataID, 1);
    //				}
    //				ModControlMFS modControlMFS2 = npc2.GetModule(MODULE_TYPE.MT_CONTROL_MFS) as ModControlMFS;
    //				modControlMFS2.ChangeStateToIdle();
    //			}
    //		}
    //	}

    //	// Token: 0x06001825 RID: 6181 RVA: 0x000BA298 File Offset: 0x000B8498
    //	public void OnTriggerExit(Collider Collision)
    //	{
    //		if (Collision.gameObject.tag == "Player")
    //		{
    //			Npc npc = RoleBaseFun.GetRoleScriptFromGo(base.transform.gameObject) as Npc;
    //			if (npc.info.scriptModID != -1)
    //			{
    //				OperableItemBase._bFCall = false;
    //				GUIControl.OpeText.active = false;
    //			}
    //			Player player = SceneManager.RoleMan.GetPlayer();
    //			if (player != null)
    //			{
    //				player.RemoveEnableOperable(this);
    //			}
    //			NPCClick._bCall = false;
    //		}
    //	}

    //	// Token: 0x06001826 RID: 6182 RVA: 0x000BA318 File Offset: 0x000B8518
    //	public void OnDestroy()
    //	{
    //		if (base.transform != null && GUIControl.OpeText != null)
    //		{
    //			GUIControl.OpeText.active = false;
    //		}
    //	}

    // Token: 0x040017C4 RID: 6084
   // private NpcInfo ni;

// Token: 0x040017C5 RID: 6085
public static bool _bCall;
}
