using System;
using System.Collections.Generic;
using System.IO;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using UnityEngine;

public class PlayersManager
{

    //	// Token: 0x040031D8 RID: 12760
    //	public static GameObject curCtrlModel = null;

    //	// Token: 0x040031D9 RID: 12761
    //	public static List<GameObject> ActivePlayers = new List<GameObject>();

    public static List<GameObject> AllPlayers = new List<GameObject>();

    //	// Token: 0x040031DB RID: 12763
    //	private static List<PerceptionRange> AllPlayersPerceptionRange = new List<PerceptionRange>();

    //	// Token: 0x040031DC RID: 12764
    //	private static int PlayerIndex = 0;

    //	// Token: 0x040031DD RID: 12765
    //	private static string PlayerTemplatePath = "Template/Character/";

    //	// Token: 0x040031DE RID: 12766
    //	public static Action<int> OnAddPlayer = null;

    //	// Token: 0x040031DF RID: 12767
    //	private static Transform tempDestTF = null;

    //	// Token: 0x040031E0 RID: 12768
    //	private static int TempPlayersCount = 0;

    //	// Token: 0x040031E1 RID: 12769
    //	private static int TempPlayerIndex = 0;

    static PlayersManager()
    {
        //PlayersManager.OnTabPlayer = null;
        //PlayersManager.OnRemovePlayer = null;
    }

    //	// Token: 0x14000028 RID: 40
    //	// (add) Token: 0x0600375E RID: 14174 RVA: 0x0019170C File Offset: 0x0018F90C
    //	// (remove) Token: 0x0600375F RID: 14175 RVA: 0x00191724 File Offset: 0x0018F924
    //	public static event Action<int> OnTabPlayer;

    //	// Token: 0x14000029 RID: 41
    //	// (add) Token: 0x06003760 RID: 14176 RVA: 0x0019173C File Offset: 0x0018F93C
    //	// (remove) Token: 0x06003761 RID: 14177 RVA: 0x00191754 File Offset: 0x0018F954
    //	public static event Action<PalNPC> OnAfterSetPlayer;

    //	// Token: 0x1400002A RID: 42
    //	// (add) Token: 0x06003762 RID: 14178 RVA: 0x0019176C File Offset: 0x0018F96C
    //	// (remove) Token: 0x06003763 RID: 14179 RVA: 0x00191784 File Offset: 0x0018F984
    //	public static event Action<int> OnRemovePlayer;

    //	// Token: 0x1700043B RID: 1083
    //	// (get) Token: 0x06003764 RID: 14180 RVA: 0x0019179C File Offset: 0x0018F99C
    //	public static GameObject Player
    //	{
    //		get
    //		{
    //			if (PlayersManager.curCtrlModel != null)
    //			{
    //				return PlayersManager.curCtrlModel;
    //			}
    //			if (PlayersManager.ActivePlayers.Count < 1)
    //			{
    //				GameObject gameObject = GameObject.FindWithTag("Player");
    //				if (gameObject != null)
    //				{
    //					PlayersManager.ActivePlayers.Add(gameObject);
    //				}
    //			}
    //			if (PlayersManager.PlayerIndex < 0 || PlayersManager.PlayerIndex >= PlayersManager.ActivePlayers.Count)
    //			{
    //				return null;
    //			}
    //			return PlayersManager.ActivePlayers[PlayersManager.PlayerIndex];
    //		}
    //	}

    //	// Token: 0x06003765 RID: 14181 RVA: 0x00191824 File Offset: 0x0018FA24
    //	public static void Initialize()
    //	{
    //		PlayersManager.AllPlayers.Clear();
    //		PlayersManager.AllPlayersPerceptionRange.Clear();
    //		for (int i = 0; i < 8; i++)
    //		{
    //			if (i != 6)
    //			{
    //				GameObject gameObject = PlayersManager.FindMainChar(i, true);
    //				if (!(gameObject == null))
    //				{
    //					PalNPC component = gameObject.GetComponent<PalNPC>();
    //					if (!(component == null))
    //					{
    //						PalNPC palNPC = component;
    //						palNPC.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC.OnLoadModelEnd, new PalNPC.void_fun_TF(PlayersManager.SetClothFar));
    //					}
    //				}
    //			}
    //		}
    //		GameObject gameObject2 = PlayersManager.FindMainChar(0, true);
    //		if (gameObject2 != null)
    //		{
    //			PalNPC component2 = gameObject2.GetComponent<PalNPC>();
    //			if (component2 == null)
    //			{
    //				Debug.Log("PlayersManager.Initialize: NPC 0 is null");
    //			}
    //			else
    //			{
    //				PalNPC palNPC2 = component2;
    //				palNPC2.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC2.OnLoadModelEnd, new PalNPC.void_fun_TF(PlayersManager.OnLoadModelEnd));
    //			}
    //		}
    //		GameObject gameObject3 = PlayersManager.FindMainChar(5, true);
    //		if (gameObject3 != null)
    //		{
    //			PalNPC component3 = gameObject3.GetComponent<PalNPC>();
    //			if (component3 == null)
    //			{
    //				Debug.Log("PlayersManager.Initialize: NPC 5 is null");
    //			}
    //			else
    //			{
    //				PalNPC palNPC3 = component3;
    //				palNPC3.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC3.OnLoadModelEnd, new PalNPC.void_fun_TF(PlayersManager.OnLoadModelEnd));
    //			}
    //		}
    //		GameObject gameObject4 = PlayersManager.FindMainChar(3, true);
    //		if (gameObject4 != null)
    //		{
    //			ModelChangeScript component4 = gameObject4.GetComponent<ModelChangeScript>();
    //			if (component4 != null)
    //			{
    //				ModelChangeScript modelChangeScript = component4;
    //				modelChangeScript.OnSetModeEnd = (Action<PalNPC>)Delegate.Combine(modelChangeScript.OnSetModeEnd, new Action<PalNPC>(PlayersManager.OnSetModeEnd));
    //			}
    //		}
    //		GameObject gameObject5 = PlayersManager.FindMainChar(4, true);
    //		if (gameObject5 != null)
    //		{
    //			PalNPC component5 = gameObject5.GetComponent<PalNPC>();
    //			if (component5 == null)
    //			{
    //				Debug.Log("PlayersManager.Initialize: NPC 4 is null");
    //			}
    //			else if (component5.model != null)
    //			{
    //				Agent component6 = component5.model.GetComponent<Agent>();
    //				component6.CrossZhuoDiTime = 0.12f;
    //			}
    //			else
    //			{
    //				PalNPC palNPC4 = component5;
    //				palNPC4.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC4.OnLoadModelEnd, new PalNPC.void_fun_TF(PlayersManager.OnLoadModelEnd));
    //			}
    //		}
    //		GameObject gameObject6 = PlayersManager.FindMainChar(7, true);
    //		if (gameObject6 != null)
    //		{
    //			PlayersManager.PlayerInitSneakScript(gameObject6, null);
    //		}
    //		ScenesManager.Instance.OnChangeMap -= PlayersManager.OnChangeMap;
    //		ScenesManager.Instance.OnChangeMap += PlayersManager.OnChangeMap;
    //		FlagManager.OnSetFlag = (Action<int, int>)Delegate.Remove(FlagManager.OnSetFlag, new Action<int, int>(PlayersManager.OnSetFlag));
    //		FlagManager.OnSetFlag = (Action<int, int>)Delegate.Combine(FlagManager.OnSetFlag, new Action<int, int>(PlayersManager.OnSetFlag));
    //	}

    //	// Token: 0x06003766 RID: 14182 RVA: 0x00191AD8 File Offset: 0x0018FCD8
    //	public static void BeforeLoadData()
    //	{
    //		for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.AllPlayers[i];
    //			if (!(gameObject == null))
    //			{
    //				PalGameObjectBase component = gameObject.GetComponent<PalGameObjectBase>();
    //				if (!(component == null))
    //				{
    //					component.CurObjType = ObjType.none;
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003767 RID: 14183 RVA: 0x00191B40 File Offset: 0x0018FD40
    //	private static void OnChangeMap(int mapIndex)
    //	{
    //		for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.AllPlayers[i];
    //			if (!(gameObject == null))
    //			{
    //				PalNPC component = gameObject.GetComponent<PalNPC>();
    //				if (!(component == null))
    //				{
    //					if (component.perception == null)
    //					{
    //						Debug.LogError("Error : PlayersManager.OnChangeMap " + component.name + " perception == null");
    //					}
    //					else
    //					{
    //						component.perception.Clear();
    //					}
    //				}
    //			}
    //		}
    //	}

    /// <summary>
    /// 改变头发Shader
    /// </summary>
    /// <param name="bUseAlpha"></param>
    public static void ChangeHairShader(bool bUseAlpha)
    {
        //UtilFun.ChangeHairShader(bUseAlpha, PlayersManager.AllPlayers.ToArray());
    }

    //	// Token: 0x06003769 RID: 14185 RVA: 0x00191BEC File Offset: 0x0018FDEC
    //	private static void OnSetModeEnd(PalNPC npc)
    //	{
    //		PlayersManager.AddNeedComponent(npc);
    //	}

    //	// Token: 0x0600376A RID: 14186 RVA: 0x00191BF4 File Offset: 0x0018FDF4
    //	private static void OnLoadModelEnd(PalNPC npc)
    //	{
    //		switch (npc.Data.CharacterID)
    //		{
    //		case 0:
    //			FlagManager.SetFlag(6, 1, true);
    //			SetActiveChildByFlag.Init(npc.gameObject, 6, "yanzhao");
    //			break;
    //		case 4:
    //		{
    //			Agent component = npc.model.GetComponent<Agent>();
    //			component.CrossZhuoDiTime = 0.12f;
    //			break;
    //		}
    //		case 5:
    //			FlagManager.SetFlag(7, 0, true);
    //			SetActiveChildByFlag.Init(npc.gameObject, 7, "YanZhao");
    //			break;
    //		}
    //	}

    //	// Token: 0x0600376B RID: 14187 RVA: 0x00191C88 File Offset: 0x0018FE88
    //	private static void SetClothFar(PalNPC npc)
    //	{
    //		ShroudInstance[] components = npc.model.GetComponents<ShroudInstance>();
    //		foreach (ShroudInstance shroudInstance in components)
    //		{
    //			shroudInstance.m_blendStartDistance = 300f;
    //			shroudInstance.m_blendEndDistance = 400f;
    //		}
    //	}

    //	// Token: 0x0600376C RID: 14188 RVA: 0x00191CD4 File Offset: 0x0018FED4
    //	public static void Restart()
    //	{
    //		for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //		{
    //			if (PlayersManager.AllPlayers[i] != null && PlayersManager.AllPlayers[i].GetModelObj(false) != PlayersManager.AllPlayers[i])
    //			{
    //				AnimCtrlScript component = PlayersManager.AllPlayers[i].GetModelObj(false).GetComponent<AnimCtrlScript>();
    //				component.ActiveAnimCrossFade("ZhanLi", false, 0f, true);
    //				LateSetActive.Init(PlayersManager.AllPlayers[i].GetModelObj(false), false, 0.01f);
    //			}
    //			try
    //			{
    //				if (i < PlayersManager.AllPlayers.Count)
    //				{
    //					PalNPC component2 = PlayersManager.AllPlayers[i].GetComponent<PalNPC>();
    //					if (component2 != null && component2.Data != null)
    //					{
    //						PlayersManager.AllPlayers[i].GetComponent<PalNPC>().Data.Reset();
    //					}
    //				}
    //			}
    //			catch
    //			{
    //			}
    //		}
    //		PlayersManager.ActivePlayers.Clear();
    //		GameObject gameObject = PlayersManager.FindMainChar(3, true);
    //		if (gameObject != null)
    //		{
    //			ModelChangeScript component3 = gameObject.GetComponent<ModelChangeScript>();
    //			if (component3 != null)
    //			{
    //				component3.Reset();
    //			}
    //		}
    //	}

    public static void RestoreLayer(bool NeedRestorePos)
    {
        for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
        {
            GameObject gameObject = PlayersManager.AllPlayers[i];
            if (!(gameObject == null))
            {
                if (!gameObject.activeSelf)
                {
                    gameObject.SetActive(true);
                }

                //PalNPC component = gameObject.GetComponent<PalNPC>();
                //if (component == null)
                //{
                //    Debug.LogError("Error : " + gameObject.name + " 没有PalNPC");
                //}
                //else
                //{
                //    Transform transform = component.transform;
                //    if (component.model == null)
                //    {
                //        Debug.LogError("Error : " + component.name + " 没有model");
                //    }
                //    else
                //    {
                //        Transform transform2 = component.model.transform;
                //        if (transform2.parent != transform)
                //        {
                //            transform2.parent = transform;
                //        }
                //        Footmark component2 = component.model.GetComponent<Footmark>();
                //        if (component2 != null)
                //        {
                //            component2.CurMode = Footmark.Mode.Ground;
                //        }
                //        if (NeedRestorePos)
                //        {
                //            transform2.localPosition = Vector3.zero;
                //            component.model.SetVisible(true);
                //            if (component.gameObject != PlayersManager.Player && component.model.activeSelf)
                //            {
                //                AnimCtrlScript component3 = component.model.GetComponent<AnimCtrlScript>();
                //                component3.ActiveAnimCrossFade("ZhanLi", false, 0f, true);
                //                LateSetActive.Init(component.model, false, 0.01f);
                //            }
                //        }
                //    }
                //}
            }
        }
    }

    //	// Token: 0x0600376E RID: 14190 RVA: 0x00191FB0 File Offset: 0x001901B0
    //	public static bool ShouldLoad(GameObject go)
    //	{
    //		if (go == null)
    //		{
    //			return false;
    //		}
    //		if (!PlayersManager.ActivePlayers.Contains(go))
    //		{
    //			PalNPC component = go.GetComponent<PalNPC>();
    //			return component != null && !PlayersManager.ExsitsInPlayers(component.Data.CharacterID);
    //		}
    //		return true;
    //	}

    //	// Token: 0x0600376F RID: 14191 RVA: 0x00192008 File Offset: 0x00190208
    //	public static int GetAverageLevel()
    //	{
    //		int num = 0;
    //		int count = PlayersManager.ActivePlayers.Count;
    //		for (int i = 0; i < count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.ActivePlayers[i];
    //			PalNPC component = gameObject.GetComponent<PalNPC>();
    //			num += component.Data.Level;
    //		}
    //		return num / count;
    //	}

    //	// Token: 0x06003770 RID: 14192 RVA: 0x0019205C File Offset: 0x0019025C
    //	public static int GetMaxLevel()
    //	{
    //		int num = 0;
    //		int count = PlayersManager.ActivePlayers.Count;
    //		for (int i = 0; i < count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.ActivePlayers[i];
    //			PalNPC component = gameObject.GetComponent<PalNPC>();
    //			int level = component.Data.Level;
    //			if (num < level)
    //			{
    //				num = level;
    //			}
    //		}
    //		return num;
    //	}

    //	// Token: 0x06003771 RID: 14193 RVA: 0x001920B8 File Offset: 0x001902B8
    //	public static bool IsMainChar(GameObject go)
    //	{
    //		return PlayersManager.AllPlayers.Contains(go);
    //	}

    //	// Token: 0x06003772 RID: 14194 RVA: 0x001920C8 File Offset: 0x001902C8
    //	public static List<AnimatorOverrideController> GetMainOverrideCtrlList()
    //	{
    //		List<AnimatorOverrideController> list = new List<AnimatorOverrideController>();
    //		for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.AllPlayers[i];
    //			PalNPC component = gameObject.GetComponent<PalNPC>();
    //			Animator component2 = component.model.GetComponent<Animator>();
    //			AnimatorOverrideController item = component2.runtimeAnimatorController as AnimatorOverrideController;
    //			list.Add(item);
    //		}
    //		return list;
    //	}

    //	// Token: 0x06003773 RID: 14195 RVA: 0x00192130 File Offset: 0x00190330
    //	public static bool ExsitsInPlayers(int ID)
    //	{
    //		for (int i = 0; i < PlayersManager.ActivePlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.ActivePlayers[i];
    //			if (!(gameObject == null))
    //			{
    //				PalNPC component = gameObject.GetComponent<PalNPC>();
    //				if (!(component == null))
    //				{
    //					if (component.Data.CharacterID == ID)
    //					{
    //						return true;
    //					}
    //				}
    //			}
    //		}
    //		return false;
    //	}

    //	// Token: 0x06003774 RID: 14196 RVA: 0x001921A4 File Offset: 0x001903A4
    //	private static int ExcludeJiGuanXiong(int newPlayerIndex)
    //	{
    //		GameObject gameObject = PlayersManager.ActivePlayers[newPlayerIndex];
    //		if (gameObject != null)
    //		{
    //			PalNPC component = gameObject.GetComponent<PalNPC>();
    //			if (component.Data.CharacterID == 6)
    //			{
    //				newPlayerIndex++;
    //				if (newPlayerIndex >= PlayersManager.ActivePlayers.Count)
    //				{
    //					newPlayerIndex = 0;
    //				}
    //			}
    //		}
    //		return newPlayerIndex;
    //	}

    //	// Token: 0x06003775 RID: 14197 RVA: 0x001921FC File Offset: 0x001903FC
    //	public static void TabPlayer()
    //	{
    //		int count = PlayersManager.ActivePlayers.Count;
    //		int num = PlayersManager.PlayerIndex + 1;
    //		if (num >= count)
    //		{
    //			num = 0;
    //		}
    //		num = PlayersManager.ExcludeJiGuanXiong(num);
    //		PlayersManager.SetPlayer(num, true);
    //		MiniMap.Instance.MapSkillTime_Cur.fillAmount = 1f;
    //		if (PlayersManager.OnTabPlayer != null)
    //		{
    //			PlayersManager.OnTabPlayer(num);
    //		}
    //	}

    //	// Token: 0x06003776 RID: 14198 RVA: 0x0019225C File Offset: 0x0019045C
    //	private static void AddNeedComponent(PalNPC npc)
    //	{
    //		if (npc == null)
    //		{
    //			Debug.LogError("Error : AddNeedComponent npc==null");
    //			return;
    //		}
    //		if (npc.model == null)
    //		{
    //			return;
    //		}
    //		GameObject model = npc.model;
    //		if (model.GetComponent<BattleTrigger>() == null)
    //		{
    //			model.AddComponent<BattleTrigger>();
    //		}
    //		if (model.GetComponent<TakePlace>() == null)
    //		{
    //			model.AddComponent<TakePlace>();
    //		}
    //		model.SetHeadLight(true);
    //	}

    //	// Token: 0x06003777 RID: 14199 RVA: 0x001922D0 File Offset: 0x001904D0
    //	public static void SetPlayer(int newPlayerIndex, bool SetPos = true)
    //	{
    //		using (new PlayersManager.AfterSetPlayer())
    //		{
    //			if (newPlayerIndex == PlayersManager.PlayerIndex)
    //			{
    //				if (PlayersManager.Player == null)
    //				{
    //					Debug.LogError("Error : PlayerIndex==" + PlayersManager.PlayerIndex.ToString() + " Player == null 596行");
    //				}
    //				else
    //				{
    //					PalNPC component = PlayersManager.Player.GetComponent<PalNPC>();
    //					if (component == null)
    //					{
    //						Debug.LogError("Error : " + PlayersManager.Player.name + " npc == null 604行");
    //					}
    //					else
    //					{
    //						SneakAttack[] componentsInChildren = component.GetComponentsInChildren<SneakAttack>(true);
    //						if (componentsInChildren != null && componentsInChildren.Length > 0 && componentsInChildren[0] != null)
    //						{
    //							componentsInChildren[0].enabled = true;
    //						}
    //						GameObject model = component.model;
    //						if (model != null)
    //						{
    //							model.layer = 8;
    //						}
    //						PlayersManager.Player.tag = "Player";
    //						PlayersManager.Player.layer = SmoothFollow2.IgnoreLayer;
    //						UtilFun.SetActive(PlayersManager.Player, true);
    //						if (model != null)
    //						{
    //							PalNPC palNPC = component;
    //							palNPC.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Remove(palNPC.OnLoadModelEnd, new PalNPC.void_fun_TF(PlayersManager.AddNeedComponent));
    //							LateSetActive.DeleteKey(model.name);
    //							if (!model.activeSelf)
    //							{
    //								UtilFun.SetActive(model, true);
    //							}
    //							PlayersManager.AddNeedComponent(component);
    //							model.SetHeadLight(true);
    //							SkillSEPreviewAnimMove component2 = model.GetComponent<SkillSEPreviewAnimMove>();
    //							if (component2 != null)
    //							{
    //								UnityEngine.Object.Destroy(component2);
    //							}
    //						}
    //						else
    //						{
    //							PalNPC palNPC2 = component;
    //							palNPC2.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC2.OnLoadModelEnd, new PalNPC.void_fun_TF(PlayersManager.AddNeedComponent));
    //						}
    //						Agent component3 = model.GetComponent<Agent>();
    //						if (component3 != null && component3.charCtrller != null && !component3.charCtrller.enabled)
    //						{
    //							component3.charCtrller.enabled = true;
    //						}
    //						PlayerCtrlManager.Reset();
    //					}
    //				}
    //			}
    //			else if (newPlayerIndex < 0 || newPlayerIndex >= PlayersManager.ActivePlayers.Count)
    //			{
    //				Debug.LogError("PlayersManager.SetPlayer: out of bound, newPlayerIndex = " + newPlayerIndex);
    //			}
    //			else
    //			{
    //				GameObject gameObject = null;
    //				Transform transform = null;
    //				GameObject player = PlayersManager.Player;
    //				SlideDown slideDown = null;
    //				if (PlayersManager.Player != null)
    //				{
    //					PalNPC component4 = PlayersManager.Player.GetComponent<PalNPC>();
    //					if (component4 == null)
    //					{
    //						Debug.LogError("Error : " + PlayersManager.Player.name + " npc == null 690行");
    //					}
    //					SneakAttack component5 = component4.GetComponent<SneakAttack>();
    //					if (component5 != null)
    //					{
    //						component5.enabled = false;
    //					}
    //					if (component4 != null && component4.Data != null && component4.Data.CharacterID == 0)
    //					{
    //						if (component4.model == null)
    //						{
    //							Debug.LogError("Error : " + component4.name + " npc.model == null 707行");
    //						}
    //						AnimCtrlScript component6 = component4.model.GetComponent<AnimCtrlScript>();
    //						if (component6 != null)
    //						{
    //							component6.ActiveZhanDou(false, 1, true, true, true);
    //						}
    //						if (component4.Weapons == null)
    //						{
    //							Debug.LogError("Error : " + component4.name + " npc.Weapons == null 718行");
    //						}
    //						for (int i = 0; i < component4.Weapons.Count; i++)
    //						{
    //							GameObject gameObject2 = component4.Weapons[i];
    //							if (gameObject2 != null)
    //							{
    //								Animator componentInChildren = gameObject2.GetComponentInChildren<Animator>();
    //								if (componentInChildren != null)
    //								{
    //									componentInChildren.enabled = false;
    //									AnimatorListen componentInChildren2 = gameObject2.GetComponentInChildren<AnimatorListen>();
    //									if (componentInChildren2 != null)
    //									{
    //										UnityEngine.Object.Destroy(componentInChildren2);
    //									}
    //								}
    //								UtilFun.YueJinChaoShenSuo(gameObject2.transform, Vector3.zero);
    //							}
    //						}
    //					}
    //					gameObject = component4.model;
    //					if (gameObject != null)
    //					{
    //						if (gameObject.transform.parent != PlayersManager.Player.transform)
    //						{
    //							transform = gameObject.transform.parent;
    //							gameObject.transform.parent = PlayersManager.Player.transform;
    //						}
    //						PlayersManager.Player.tag = "Untagged";
    //						PlayersManager.Player.layer = 0;
    //						UtilFun.SetActive(gameObject, false);
    //						Agent component7 = gameObject.GetComponent<Agent>();
    //						if (component7 != null)
    //						{
    //							component7.curCtrlMode = ControlMode.ControlByAgent;
    //						}
    //						gameObject.SetHeadLight(false);
    //					}
    //					slideDown = gameObject.GetComponent<SlideDown>();
    //				}
    //				PlayersManager.PlayerIndex = newPlayerIndex;
    //				if (PlayersManager.Player != null)
    //				{
    //					PalNPC component8 = PlayersManager.Player.GetComponent<PalNPC>();
    //					if (component8 == null)
    //					{
    //						Debug.LogError("Error : " + PlayersManager.Player.name + "  npc==null  784行");
    //					}
    //					SneakAttack[] componentsInChildren2 = component8.GetComponentsInChildren<SneakAttack>(true);
    //					if (componentsInChildren2 != null && componentsInChildren2.Length > 0 && componentsInChildren2[0] != null)
    //					{
    //						componentsInChildren2[0].enabled = true;
    //					}
    //					GameObject model2 = component8.model;
    //					if (model2 == null)
    //					{
    //						Debug.LogError("Error : " + PlayersManager.Player.name + "  npc.model==null  799行");
    //					}
    //					model2.layer = 8;
    //					Agent component9 = model2.GetComponent<Agent>();
    //					if (component9 != null && component9.charCtrller != null && !component9.charCtrller.enabled)
    //					{
    //						component9.charCtrller.enabled = true;
    //					}
    //					PlayersManager.Player.tag = "Player";
    //					PlayersManager.Player.layer = SmoothFollow2.IgnoreLayer;
    //					if (gameObject != null && SetPos)
    //					{
    //						if (transform != null && transform.name != "7")
    //						{
    //							model2.transform.parent = transform;
    //						}
    //						UtilFun.SetPosition(model2.transform, gameObject.transform.position);
    //						model2.transform.rotation = gameObject.transform.rotation;
    //					}
    //					UtilFun.SetActive(PlayersManager.Player, true);
    //					LateSetActive.DeleteKey(model2.name);
    //					if (!model2.activeSelf)
    //					{
    //						UtilFun.SetActive(model2, true);
    //					}
    //					if (gameObject != null && SetPos)
    //					{
    //						UtilFun.SetPosition(model2.transform, gameObject.transform.position);
    //					}
    //					Agent component10 = model2.GetComponent<Agent>();
    //					if (component10 != null)
    //					{
    //						component10.curCtrlMode = ControlMode.None;
    //					}
    //					if (model2 != null)
    //					{
    //						if (model2.GetComponent<BattleTrigger>() == null)
    //						{
    //							model2.AddComponent<BattleTrigger>();
    //						}
    //						model2.SetHeadLight(true);
    //						TurnHead component11 = model2.GetComponent<TurnHead>();
    //						if (component11 != null)
    //						{
    //							component11.enabled = false;
    //						}
    //						SkillSEPreviewAnimMove component12 = model2.GetComponent<SkillSEPreviewAnimMove>();
    //						if (component12 != null)
    //						{
    //							UnityEngine.Object.Destroy(component12);
    //						}
    //					}
    //					PlayerCtrlManager.Reset();
    //					if (player != null)
    //					{
    //						PalNPC component13 = PlayersManager.Player.GetComponent<PalNPC>();
    //						PalNPC component14 = player.GetComponent<PalNPC>();
    //						if (component13 != null && component13.perception != null && component14 != null && component14.perception != null)
    //						{
    //							component13.perception.CopyData(component14.perception);
    //						}
    //					}
    //					if (model2 != null && slideDown != null)
    //					{
    //						SlideDown component15 = model2.GetComponent<SlideDown>();
    //						if (component15 != null)
    //						{
    //							component15.enabled = slideDown.enabled;
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x06003778 RID: 14200 RVA: 0x00192A90 File Offset: 0x00190C90
    //	public static GameObject GetPlayer(int ID)
    //	{
    //		GameObject result = null;
    //		foreach (GameObject gameObject in PlayersManager.ActivePlayers)
    //		{
    //			if (gameObject != null && gameObject.name == ID.ToString())
    //			{
    //				result = gameObject;
    //				break;
    //			}
    //		}
    //		return result;
    //	}

    //	// Token: 0x06003779 RID: 14201 RVA: 0x00192B1C File Offset: 0x00190D1C
    //	public static GameObject FindMainChar(int ID, bool NeedAddToAllPlayers = true)
    //	{
    //		for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.AllPlayers[i];
    //			if (!(gameObject == null))
    //			{
    //				if (gameObject.name == ID.ToString())
    //				{
    //					return gameObject;
    //				}
    //			}
    //		}
    //		GameObject gameObject2 = GameObject.Find("/" + ID.ToString());
    //		if (gameObject2 == null)
    //		{
    //			gameObject2 = GameObject.Find(ID.ToString());
    //		}
    //		if (NeedAddToAllPlayers && gameObject2 != null && ID != 6)
    //		{
    //			PlayersManager.AllPlayers.Add(gameObject2);
    //		}
    //		return gameObject2;
    //	}

    //	// Token: 0x0600377A RID: 14202 RVA: 0x00192BD0 File Offset: 0x00190DD0
    //	public static GameObject AddPlayer(int ID, bool bSetLevel = true)
    //	{
    //		GameObject player = PlayersManager.GetPlayer(ID);
    //		if (player != null)
    //		{
    //			Debug.Log("PlayersManager.AddPlayer 已经存在" + ID.ToString());
    //			return player;
    //		}
    //		GameObject gameObject = PlayersManager.FindMainChar(ID, true);
    //		if (gameObject != null && gameObject.GetComponent<PalNPC>() != null)
    //		{
    //			PlayersManager.AddPlayer(gameObject, bSetLevel);
    //			if (PlayersManager.ActivePlayers.Count == 1)
    //			{
    //				PlayersManager.SetPlayer(ID, false);
    //			}
    //			if (ID != 6 && PlayersManager.OnAddPlayer != null)
    //			{
    //				PlayersManager.OnAddPlayer(ID);
    //			}
    //			return gameObject;
    //		}
    //		GameObject gameObject2 = PlayersManager.LoadPlayer(ID);
    //		if (gameObject2 != null)
    //		{
    //			if (PlayersManager.AllPlayers.Count > ID + 1 && PlayersManager.AllPlayers[ID] == null)
    //			{
    //				PlayersManager.AllPlayers[ID] = gameObject2;
    //			}
    //			PlayersManager.AddPlayer(gameObject2, bSetLevel);
    //			if (ID == 4)
    //			{
    //				PlayersManager.AddPlayer(6, true);
    //			}
    //		}
    //		if (ID != 6 && PlayersManager.OnAddPlayer != null)
    //		{
    //			PlayersManager.OnAddPlayer(ID);
    //		}
    //		return gameObject2;
    //	}

    //	// Token: 0x0600377B RID: 14203 RVA: 0x00192CE4 File Offset: 0x00190EE4
    //	private static void SetLevel(GameObject go)
    //	{
    //		PalNPC component = go.GetComponent<PalNPC>();
    //		int level = component.Data.Level;
    //		GameObject gameObject = go;
    //		for (int i = 0; i < PlayersManager.ActivePlayers.Count; i++)
    //		{
    //			GameObject gameObject2 = PlayersManager.ActivePlayers[i];
    //			PalNPC component2 = gameObject2.GetComponent<PalNPC>();
    //			if (level < component2.Data.Level)
    //			{
    //				level = component2.Data.Level;
    //				gameObject = gameObject2;
    //			}
    //		}
    //		if (gameObject != go)
    //		{
    //			PalNPC component3 = go.GetComponent<PalNPC>();
    //			component3.Data.Exp = PlayerBaseProperty.LevelData.GetLevelExp(level - 1);
    //			Debug.Log(string.Concat(new string[]
    //			{
    //				"Log : 对角色",
    //				go.name,
    //				"进行等级设置，参照了",
    //				gameObject.name,
    //				"的等级(",
    //				level.ToString(),
    //				"级)  其经验为:",
    //				component3.Data.Exp.ToString()
    //			}));
    //		}
    //	}

    //	// Token: 0x0600377C RID: 14204 RVA: 0x00192DE8 File Offset: 0x00190FE8
    //	public static GameObject LoadPlayer(int ID)
    //	{
    //		string path = PlayersManager.PlayerTemplatePath + ID.ToString();
    //		UnityEngine.Object @object = Resources.Load(path);
    //		GameObject gameObject = null;
    //		if (@object != null)
    //		{
    //			gameObject = (UnityEngine.Object.Instantiate(@object) as GameObject);
    //			gameObject.ExcludeCloneName();
    //			PlayersManager.PlayerInitSneakScript(gameObject, null);
    //		}
    //		else
    //		{
    //			Debug.Log("PlayersManager.LoadPlayer: playerObj == null");
    //		}
    //		return gameObject;
    //	}

    //	// Token: 0x0600377D RID: 14205 RVA: 0x00192E48 File Offset: 0x00191048
    //	public static void PlayerInitSneakScript(GameObject newPlayer, PalNPC npc = null)
    //	{
    //		if (npc == null)
    //		{
    //			npc = newPlayer.GetComponent<PalNPC>();
    //		}
    //		if (!newPlayer.name.ToLower().Contains("jiguanxiong"))
    //		{
    //			newPlayer.AddComponent<InitSneakScript>();
    //			SneakAttack[] componentsInChildren = newPlayer.GetComponentsInChildren<SneakAttack>();
    //			if (componentsInChildren == null || componentsInChildren.Length < 1)
    //			{
    //				int characterID = npc.Data.CharacterID;
    //				if (characterID != 6 && characterID != 7)
    //				{
    //					if (characterID == 0 || characterID == 2 || characterID == 3)
    //					{
    //						newPlayer.AddComponent<JinQiXi>();
    //					}
    //					else
    //					{
    //						newPlayer.AddComponent<YuanQiXi>();
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x0600377E RID: 14206 RVA: 0x00192EE4 File Offset: 0x001910E4
    //	public static void AddPlayer(GameObject newPlayer, bool bSetLevel = true)
    //	{
    //		if (newPlayer == null)
    //		{
    //			return;
    //		}
    //		newPlayer.ExcludeCloneName();
    //		PalNPC component = newPlayer.GetComponent<PalNPC>();
    //		if (component == null)
    //		{
    //			return;
    //		}
    //		PlayersManager.PlayerInitSneakScript(newPlayer, component);
    //		if (!PlayersManager.ActivePlayers.Contains(newPlayer))
    //		{
    //			newPlayer.transform.parent = null;
    //			if (newPlayer.GetComponent<DontDestroyOnLevelChange>() == null)
    //			{
    //				newPlayer.AddComponent<DontDestroyOnLevelChange>();
    //			}
    //			if (newPlayer.GetComponent<SavePrefabTarget>() == null)
    //			{
    //				SavePrefabTarget savePrefabTarget = newPlayer.AddComponent<SavePrefabTarget>();
    //			}
    //			if (component.model == null)
    //			{
    //				PalNPC palNPC = component;
    //				palNPC.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC.OnLoadModelEnd, new PalNPC.void_fun_TF(PlayersManager.WaitLoadOverThanSetActiveFalse));
    //			}
    //			else
    //			{
    //				ShroudInstance component2 = component.model.GetComponent<ShroudInstance>();
    //				if (component2 != null)
    //				{
    //					component2.blendWeightK = 100f;
    //				}
    //				AnimCtrlScript component3 = component.model.GetComponent<AnimCtrlScript>();
    //				component3.ActiveAnimCrossFade("ZhanLi", false, 0f, true);
    //				if (component.Data.CharacterID == 2)
    //				{
    //					if (!component.animator.GetCurrentAnimatorStateInfo(0).IsName("yidongState.ZhanLi"))
    //					{
    //						LateSetActive.Init(component.model, false, 0.01f);
    //					}
    //					else
    //					{
    //						UtilFun.SetActive(component.model, false);
    //					}
    //				}
    //				else
    //				{
    //					UtilFun.SetActive(component.model, false);
    //				}
    //			}
    //			if (bSetLevel)
    //			{
    //				PlayersManager.SetLevel(newPlayer);
    //			}
    //			PlayersManager.ActivePlayers.Add(newPlayer);
    //			if (component.Data != null)
    //			{
    //				FlagManager.SetBoolFlag((ulong)(34048L + (long)component.Data.CharacterID), true);
    //			}
    //		}
    //		else
    //		{
    //			Debug.Log("Log : PlayersManager.AddPlayer 已经存在 " + newPlayer.name);
    //		}
    //	}

    //	// Token: 0x0600377F RID: 14207 RVA: 0x001930A4 File Offset: 0x001912A4
    //	private static void WaitLoadOverThanSetActiveFalse(PalNPC npc)
    //	{
    //		if (PlayersManager.Player != null && npc != null && PlayersManager.Player != npc.gameObject)
    //		{
    //			UtilFun.SetActive(npc.model, false);
    //		}
    //	}

    //	// Token: 0x06003780 RID: 14208 RVA: 0x001930F0 File Offset: 0x001912F0
    //	public static void RemovePlayer(int ID, bool bActive = false)
    //	{
    //		if (ID == 4)
    //		{
    //			PlayersManager.RemovePlayer(6, bActive);
    //		}
    //		GameObject player = PlayersManager.GetPlayer(ID);
    //		if (!player)
    //		{
    //			Debug.Log("ActivePlayers不存在此ID");
    //			return;
    //		}
    //		PlayersManager.RemovePlayer(player, bActive);
    //		if (ID != 6 && PlayersManager.OnRemovePlayer != null)
    //		{
    //			PlayersManager.OnRemovePlayer(ID);
    //		}
    //	}

    //	// Token: 0x06003781 RID: 14209 RVA: 0x0019314C File Offset: 0x0019134C
    //	public static void RemovePlayer(GameObject go, bool bActive = false)
    //	{
    //		if (PlayersManager.ActivePlayers.Count < 2)
    //		{
    //			Debug.LogError(go.name + "打算离队  只有一个人就别离队了");
    //			return;
    //		}
    //		int newPlayerIndex = 0;
    //		GameObject gameObject = null;
    //		if (PlayersManager.Player == go)
    //		{
    //			newPlayerIndex = PlayersManager.PlayerIndex % (PlayersManager.ActivePlayers.Count - 1);
    //		}
    //		else
    //		{
    //			gameObject = PlayersManager.Player;
    //		}
    //		PlayersManager.ActivePlayers.Remove(go);
    //		GameObject modelObj = go.GetModelObj(false);
    //		LateSetActive.Init(modelObj, bActive, 0.01f);
    //		if (gameObject == null)
    //		{
    //			PlayersManager.SetPlayer(newPlayerIndex, false);
    //		}
    //		else
    //		{
    //			newPlayerIndex = PlayersManager.ActivePlayers.IndexOf(gameObject);
    //			PlayersManager.SetPlayer(newPlayerIndex, false);
    //		}
    //	}

    //	// Token: 0x06003782 RID: 14210 RVA: 0x001931FC File Offset: 0x001913FC
    //	public static GameObject SpawnPlayer(string path = null, string DestPosName = null, bool NeedSetCamera = false)
    //	{
    //		if (Application.loadedLevelName != "Start")
    //		{
    //			GameObject gameObject = PlayersManager.AddPlayer(0, true);
    //			PlayersManager.SetPlayer(0, true);
    //		}
    //		if (!string.IsNullOrEmpty(DestPosName))
    //		{
    //			PlayersManager.SetPlayerPosByDestObj(DestPosName);
    //		}
    //		return PlayersManager.Player;
    //	}

    //	// Token: 0x06003783 RID: 14211 RVA: 0x00193244 File Offset: 0x00191444
    //	public static void SetPlayerPosByDestObj(string DestName)
    //	{
    //		GameObject gameObject = GameObject.Find(DestName);
    //		if (gameObject == null)
    //		{
    //			Debug.LogError("没有找到 " + DestName);
    //			return;
    //		}
    //		if (PlayersManager.Player == null)
    //		{
    //			Debug.LogError("没有主控角色");
    //			return;
    //		}
    //		Transform transform;
    //		if (PlayerCtrlManager.agentObj != null)
    //		{
    //			transform = PlayerCtrlManager.agentObj.transform;
    //		}
    //		else
    //		{
    //			PalNPC component = PlayersManager.Player.GetComponent<PalNPC>();
    //			if (!(component.model != null))
    //			{
    //				PlayersManager.tempDestTF = gameObject.transform;
    //				PalNPC palNPC = component;
    //				palNPC.OnLoadModelEnd = (PalNPC.void_fun_TF)Delegate.Combine(palNPC.OnLoadModelEnd, new PalNPC.void_fun_TF(PlayersManager.WaitForSpawn));
    //				return;
    //			}
    //			transform = component.model.transform;
    //		}
    //		if (transform != null)
    //		{
    //			Agent component2 = transform.GetComponent<Agent>();
    //			if (component2 != null && component2.charCtrller != null && !component2.charCtrller.enabled)
    //			{
    //				component2.charCtrller.enabled = true;
    //			}
    //		}
    //		Transform transform2 = gameObject.transform;
    //		Vector3 vector = transform2.position;
    //		vector.y += 1f;
    //		RaycastHit raycastHit;
    //		if (Physics.Raycast(vector, Vector3.down, out raycastHit))
    //		{
    //			vector = raycastHit.point;
    //		}
    //		UtilFun.SetPosition(transform, vector);
    //		transform.eulerAngles = new Vector3(0f, transform2.eulerAngles.y, 0f);
    //		SceneFall2.SetLastPointOnLoadOver();
    //	}

    //	// Token: 0x06003784 RID: 14212 RVA: 0x001933CC File Offset: 0x001915CC
    //	private static void WaitForSpawn(PalNPC npc)
    //	{
    //		Vector3 vector = PlayersManager.tempDestTF.position;
    //		RaycastHit raycastHit;
    //		if (Physics.Raycast(vector, Vector3.down, out raycastHit))
    //		{
    //			vector = raycastHit.point;
    //		}
    //		Transform transform = npc.model.transform;
    //		UtilFun.SetPosition(transform, vector);
    //		transform.eulerAngles = new Vector3(0f, PlayersManager.tempDestTF.eulerAngles.y, 0f);
    //		SceneFall2.SetLastPointOnLoadOver();
    //	}

    //	// Token: 0x06003785 RID: 14213 RVA: 0x00193440 File Offset: 0x00191640
    //	public static string Save(string SaveName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(SaveName);
    //		text += "/Player";
    //		List<SavePrefabTarget> players = PlayersManager.GetPlayers();
    //		using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(text, FileMode.Create)))
    //		{
    //			PlayersManager.Save_FileStream(binaryWriter);
    //		}
    //		return string.Empty;
    //	}

    //	// Token: 0x06003786 RID: 14214 RVA: 0x001934B0 File Offset: 0x001916B0
    //	public static string Save_FileStream(BinaryWriter _writer)
    //	{
    //		List<SavePrefabTarget> players = PlayersManager.GetPlayers();
    //		_writer.Write(PlayersManager.PlayerIndex);
    //		_writer.Write(players.Count);
    //		foreach (SavePrefabTarget savePrefabTarget in players)
    //		{
    //			if (!savePrefabTarget.Save(_writer))
    //			{
    //				return savePrefabTarget.name + "保存出错";
    //			}
    //		}
    //		int count = PlayersManager.ActivePlayers.Count;
    //		_writer.Write(count);
    //		for (int i = 0; i < count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.ActivePlayers[i];
    //			PalNPC component = gameObject.GetComponent<PalNPC>();
    //			int characterID = component.Data.CharacterID;
    //			_writer.Write(characterID);
    //		}
    //		SmoothFollow2 component2 = Camera.main.GetComponent<SmoothFollow2>();
    //		if (component2 != null)
    //		{
    //			component2.Save(_writer);
    //		}
    //		WeatherManage.Save(_writer);
    //		TimeManager.Instance.SaveWeatherTime(_writer);
    //		return string.Empty;
    //	}

    //	// Token: 0x06003787 RID: 14215 RVA: 0x001935DC File Offset: 0x001917DC
    //	public static string Load_FileStream(BinaryReader _reader)
    //	{
    //		for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.AllPlayers[i];
    //			if (!(gameObject == null))
    //			{
    //				GameObject modelObj = gameObject.GetModelObj(false);
    //				ShroudInstance component = modelObj.GetComponent<ShroudInstance>();
    //				if (component != null)
    //				{
    //					ShroudWeight component2 = modelObj.GetComponent<ShroudWeight>();
    //					if (component2 != null)
    //					{
    //						UnityEngine.Object.Destroy(component2);
    //					}
    //					component.HairWeightK = 100f;
    //					component.blendWeightK = 100f;
    //				}
    //			}
    //		}
    //		PlayersManager.ActivePlayers.Clear();
    //		PlayersManager.TempPlayerIndex = _reader.ReadInt32();
    //		int num = _reader.ReadInt32();
    //		if (num > 0)
    //		{
    //			PlayersManager.TempPlayersCount = 0;
    //			for (int j = 0; j < num; j++)
    //			{
    //				GameObject gameObject2 = SavePrefabTarget.Load(_reader, null);
    //				if (!gameObject2)
    //				{
    //					return "读取人物 " + j.ToString() + " 时报错";
    //				}
    //				PalNPC component3 = gameObject2.GetComponent<PalNPC>();
    //				if (component3.model == null && !component3.gameObject.activeSelf)
    //				{
    //					Debug.LogError("palNpc " + component3.name + " 这个东西没莫名的disable了，需查明愿意");
    //				}
    //			}
    //			if (PlayersManager.TempPlayersCount <= 0)
    //			{
    //				PlayersManager.ActivePlayers.Clear();
    //				int num2 = _reader.ReadInt32();
    //				for (int k = 0; k < num2; k++)
    //				{
    //					int id = _reader.ReadInt32();
    //					GameObject newPlayer = PlayersManager.FindMainChar(id, true);
    //					PlayersManager.AddPlayer(newPlayer, false);
    //				}
    //				PlayersManager.SetPlayer(PlayersManager.TempPlayerIndex, false);
    //			}
    //		}
    //		if (!SaveManager.IsErZhouMu)
    //		{
    //			SmoothFollow2 component4 = Camera.main.GetComponent<SmoothFollow2>();
    //			if (component4 != null)
    //			{
    //				component4.Load(_reader);
    //			}
    //			WeatherManage.Load(_reader);
    //			TimeManager.Instance.LoadWeatherTime(_reader);
    //		}
    //		return string.Empty;
    //	}

    //	// Token: 0x06003788 RID: 14216 RVA: 0x001937C0 File Offset: 0x001919C0
    //	private static List<SavePrefabTarget> GetPlayers()
    //	{
    //		List<SavePrefabTarget> list = new List<SavePrefabTarget>();
    //		for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.AllPlayers[i];
    //			if (!(gameObject == null))
    //			{
    //				SavePrefabTarget savePrefabTarget = gameObject.GetComponent<SavePrefabTarget>();
    //				if (savePrefabTarget == null)
    //				{
    //					savePrefabTarget = gameObject.AddComponent<SavePrefabTarget>();
    //				}
    //				list.Add(savePrefabTarget);
    //			}
    //		}
    //		if (list.Count < 1)
    //		{
    //			for (int j = 0; j < PlayersManager.ActivePlayers.Count; j++)
    //			{
    //				GameObject gameObject2 = PlayersManager.ActivePlayers[j];
    //				if (!(gameObject2 == null))
    //				{
    //					SavePrefabTarget savePrefabTarget2 = gameObject2.GetComponent<SavePrefabTarget>();
    //					if (savePrefabTarget2 == null)
    //					{
    //						savePrefabTarget2 = gameObject2.AddComponent<SavePrefabTarget>();
    //					}
    //					list.Add(savePrefabTarget2);
    //				}
    //			}
    //		}
    //		return list;
    //	}

    //	// Token: 0x06003789 RID: 14217 RVA: 0x001938A0 File Offset: 0x00191AA0
    //	public static string Load(string LoadName)
    //	{
    //		string text = SaveManager.GetStoreDirePath(LoadName);
    //		text += "/Player";
    //		if (!File.Exists(text))
    //		{
    //			return "没找到 " + text;
    //		}
    //		string result = string.Empty;
    //		using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(text)))
    //		{
    //			result = PlayersManager.Load_FileStream(binaryReader);
    //		}
    //		return result;
    //	}

    //	// Token: 0x0600378A RID: 14218 RVA: 0x00193920 File Offset: 0x00191B20
    //	private static void WaitForSetPlayer(PalNPC npc)
    //	{
    //		UtilFun.SetActive(npc.model, false);
    //		PlayersManager.TempPlayersCount--;
    //		if (PlayersManager.TempPlayersCount <= 0)
    //		{
    //			PlayersManager.SetPlayer(PlayersManager.TempPlayerIndex, false);
    //		}
    //	}

    //	// Token: 0x0600378B RID: 14219 RVA: 0x0019395C File Offset: 0x00191B5C
    //	public static void AddExp(int exp)
    //	{
    //		for (int i = 0; i < PlayersManager.ActivePlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.ActivePlayers[i];
    //			if (gameObject == null)
    //			{
    //				Debug.LogError("ActivePlayers 有null 元素");
    //			}
    //			else
    //			{
    //				PalNPC component = gameObject.GetComponent<PalNPC>();
    //				if (component == null)
    //				{
    //					Debug.LogError(gameObject.name + "没找到PalNPC");
    //				}
    //				else if (component.Data == null)
    //				{
    //					Debug.LogError(gameObject.name + " npc.Data ==null");
    //				}
    //				else
    //				{
    //					component.Data.Exp += exp;
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x0600378C RID: 14220 RVA: 0x00193A10 File Offset: 0x00191C10
    //	public static void ResetPlayersInteract(bool bDLC = false)
    //	{
    //		for (int i = 0; i < PlayersManager.AllPlayers.Count; i++)
    //		{
    //			GameObject gameObject = PlayersManager.AllPlayers[i];
    //			if (!(gameObject == null))
    //			{
    //				Interact component = gameObject.GetComponent<Interact>();
    //				if (!(component == null))
    //				{
    //					string actionClassName = component.ActionClassName;
    //					if (!bDLC)
    //					{
    //						int num = actionClassName.IndexOf("_DLC");
    //						if (num > -1)
    //						{
    //							string str = actionClassName.Substring(0, num);
    //							component.ActionClassName = str + "_touch";
    //						}
    //					}
    //					else
    //					{
    //						int num2 = actionClassName.IndexOf("_DLC");
    //						if (num2 < 0)
    //						{
    //							int length = actionClassName.IndexOf("_touch");
    //							string str2 = actionClassName.Substring(0, length);
    //							component.ActionClassName = str2 + "_DLC_touch";
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}

    //	// Token: 0x0600378D RID: 14221 RVA: 0x00193AF0 File Offset: 0x00191CF0
    //	private static void OnSetFlag(int idx, int flagValue)
    //	{
    //		if (idx == MissionManager.BranchLineToggleFlag)
    //		{
    //			PlayersManager.ResetPlayersInteract(flagValue > 0);
    //		}
    //	}

    //	// Token: 0x0600378E RID: 14222 RVA: 0x00193B08 File Offset: 0x00191D08
    //	public static void AddPlayerPerceptionRange(PalNPC npc)
    //	{
    //		PerceptionRange[] componentsInChildren = npc.model.GetComponentsInChildren<PerceptionRange>();
    //		for (int i = 0; i < componentsInChildren.Length; i++)
    //		{
    //			PlayersManager.AllPlayersPerceptionRange.Add(componentsInChildren[i]);
    //		}
    //	}

    //	// Token: 0x0600378F RID: 14223 RVA: 0x00193B44 File Offset: 0x00191D44
    //	public static void SetAllPlayersPerceptionRange(bool enable)
    //	{
    //		for (int i = 0; i < PlayersManager.AllPlayersPerceptionRange.Count; i++)
    //		{
    //			Collider component = PlayersManager.AllPlayersPerceptionRange[i].GetComponent<Collider>();
    //			component.enabled = enable;
    //		}
    //	}


    //	// Token: 0x020007B2 RID: 1970
    //	private class AfterSetPlayer : IDisposable
    //	{
    //		// Token: 0x06003791 RID: 14225 RVA: 0x00193B8C File Offset: 0x00191D8C
    //		public void Dispose()
    //		{
    //			if (PlayersManager.PlayerIndex < 0 || PlayersManager.PlayerIndex >= PlayersManager.ActivePlayers.Count)
    //			{
    //				return;
    //			}
    //			GameObject gameObject = PlayersManager.ActivePlayers[PlayersManager.PlayerIndex];
    //			PalNPC obj = null;
    //			if (gameObject != null)
    //			{
    //				obj = gameObject.GetComponent<PalNPC>();
    //			}
    //			if (PlayersManager.OnAfterSetPlayer != null)
    //			{
    //				PlayersManager.OnAfterSetPlayer(obj);
    //			}
    //		}
    //	}
}
