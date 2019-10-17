using System;
using System.Collections;
using System.Collections.Generic;
//using FantasyTools;
using NS_RoleBaseFun;
using UnityEngine;


public class RoleAnimationManager : Singleton<RoleAnimationManager>
{
    private const string CFG_PATH = "Anim/RoleAniTypeDefine";

    public bool IsSwitch = true;

    private Dictionary<RoleAnimationType, ArrayList> _aniTypeTable = new Dictionary<RoleAnimationType, ArrayList>();

    //private List<RoleAniCollect> _table = new List<RoleAniCollect>();

    private Hashtable _nowRunAnimation = new Hashtable();

    private Dictionary<string, AnimationClip> _tempRes = new Dictionary<string, AnimationClip>();

    public RoleAnimationManager()
	{
        this.InitData();
        this.Collect();
    }

	//public int Count
	//{
	//	get
	//	{
	//		return (this._table != null) ? this._table.Count : 0;
	//	}
	//}

	//public void Clear()
	//{
	//	this._table.Clear();
	//	this._nowRunAnimation.Clear();
	//}

    /// <summary>
    /// 初始化数据
    /// </summary>
	private void InitData()
	{
		//this._aniTypeTable.Clear();
		//List<string> list = RoleBaseFun.LoadConfInAssets("Anim/RoleAniTypeDefine");
		//if (list != null)
		//{
		//	string[] separator = new string[]
		//	{
		//		"\t"
		//	};
		//	foreach (string text in list)
		//	{
		//		string[] array = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		//		if (array != null && array.Length >= 2)
		//		{
		//			//int num = Toolset.Get<int>(array[0]);
		//			//if (Toolset.IsEnumDefined(typeof(RoleAnimationType), num))
		//			//{
		//			//	ArrayList arrayList = new ArrayList();
		//			//	RoleAnimationType key = (RoleAnimationType)num;
		//			//	for (int i = 1; i < array.Length; i++)
		//			//	{
		//			//		arrayList.Clear();
		//			//		if (array[i].Contains("-"))
		//			//		{
		//			//			int num2 = array[i].IndexOf("-");
		//			//			string obj = array[i].Substring(0, num2);
		//			//			string obj2 = array[i].Substring(num2 + 1, array[i].Length - num2 - 1);
		//			//			int num3 = Toolset.Get<int>(obj);
		//			//			int num4 = Toolset.Get<int>(obj2);
		//			//			for (int j = num3; j <= num4; j++)
		//			//			{
		//			//				arrayList.Add(j);
		//			//			}
		//			//		}
		//			//		else
		//			//		{
		//			//			arrayList.Add(Toolset.Get<int>(array[i]));
		//			//		}
		//			//		foreach (object obj3 in arrayList)
		//			//		{
		//			//			int num5 = (int)obj3;
		//			//			if (this._aniTypeTable.ContainsKey(key))
		//			//			{
		//			//				this._aniTypeTable[key].Add(num5);
		//			//			}
		//			//			else
		//			//			{
		//			//				ArrayList arrayList2 = new ArrayList();
		//			//				arrayList2.Add(num5);
		//			//				this._aniTypeTable.Add(key, arrayList2);
		//			//			}
		//			//		}
		//			//	}
		//			//}
		//		}
		//	}
		//}
	}

	private void Collect()
	{
		//if (Singleton<RoleModelData>.GetInstance().MapRoleModelInfos != null)
		//{
		//	//this.Clear();
		//	Dictionary<int, int> dictionary = new Dictionary<int, int>();
		//	foreach (RoleModelInfo roleModelInfo in Singleton<RoleModelData>.GetInstance().MapRoleModelInfos.Values)
		//	{
		//		if (roleModelInfo.ID == 1)
		//		{
		//			if (!dictionary.ContainsKey(roleModelInfo.ID))
		//			{
		//				dictionary.Add(roleModelInfo.ID, roleModelInfo.AnimationIndex);
		//			}
		//			else
		//			{
		//				Debug.LogError(string.Concat(new object[]
		//				{
		//					"RoleModelInfo ",
		//					roleModelInfo.Name,
		//					" id already exists ! Info : ",
		//					roleModelInfo.ID
		//				}));
		//			}
		//		}
		//	}
		//	ArrayList arrayList = new ArrayList();
		//	ArrayList arrayList2 = new ArrayList();
		//	foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		//	{
		//		//foreach (AniInfo aniInfo in Singleton<AniInfoStaticManager>.GetInstance().AniInfoData.Values)
		//		//{
		//		//	foreach (AniInfo.AniInfoNode aniInfoNode in aniInfo.AniNameList)
		//		//	{
		//		//		if (aniInfoNode.meshIndex == keyValuePair.Value || aniInfoNode.meshIndex == 9999)
		//		//		{
		//		//			RoleAniCollect roleAniCollect = new RoleAniCollect();
		//		//			roleAniCollect.meshID = aniInfoNode.meshIndex;
		//		//			roleAniCollect.aniName = aniInfoNode.Name;
		//		//			if (!arrayList2.Contains(aniInfoNode.Name))
		//		//			{
		//		//				arrayList2.Add(aniInfoNode.Name);
		//		//			}
		//		//			if (!arrayList.Contains(roleAniCollect))
		//		//			{
		//		//				arrayList.Add(roleAniCollect);
		//		//				roleAniCollect.modelID = keyValuePair.Key;
		//		//				roleAniCollect.aniIndex = aniInfoNode.animatioIndex;
		//		//				roleAniCollect.weaponIndex = aniInfoNode.weapoIndex;
		//		//				roleAniCollect.ContainsType = this.FindRoleAniTypeAll(roleAniCollect.aniIndex);
		//		//				if (!this._table.Contains(roleAniCollect))
		//		//				{
		//		//					this._table.Add(roleAniCollect);
		//		//				}
		//		//				else
		//		//				{
		//		//					Debug.LogError(string.Concat(new object[]
		//		//					{
		//		//						"modelID = ",
		//		//						roleAniCollect.modelID,
		//		//						" meshID= ",
		//		//						roleAniCollect.meshID,
		//		//						" aniIndex = ",
		//		//						roleAniCollect.aniIndex,
		//		//						" aniName= ",
		//		//						roleAniCollect.aniName
		//		//					}));
		//		//				}
		//		//			}
		//		//		}
		//		//	}
		//		//}
		//	}
		//	arrayList.Clear();
		//	dictionary.Clear();
		//}
	}

    //public bool IsExistsRoleAniType(RoleAnimationType tp, int aniIdx)
    //{
    //	if (!this._aniTypeTable.ContainsKey(tp))
    //	{
    //		return false;
    //	}
    //	foreach (object obj in this._aniTypeTable[tp])
    //	{
    //		ArrayList arrayList = (ArrayList)obj;
    //		if (arrayList.Contains(aniIdx))
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06002443 RID: 9283 RVA: 0x000F2040 File Offset: 0x000F0240
    //public bool IsExistsRoleAniTypeAtAll(int aniIdx)
    //{
    //	foreach (KeyValuePair<RoleAnimationType, ArrayList> keyValuePair in this._aniTypeTable)
    //	{
    //		if (keyValuePair.Value.Contains(aniIdx))
    //		{
    //			return true;
    //		}
    //	}
    //	return false;
    //}

    //// Token: 0x06002444 RID: 9284 RVA: 0x000F20B4 File Offset: 0x000F02B4
    //public bool IsExistsByModelID(int modID)
    //{
    //	return this._table.Exists((RoleAniCollect rac) => rac.modelID == modID);
    //}

    //// Token: 0x06002445 RID: 9285 RVA: 0x000F20E8 File Offset: 0x000F02E8
    //public bool IsExistsByModelIDAndAniIndex(int modID, int aniIdx)
    //{
    //	return this._table.Exists((RoleAniCollect rac) => rac.modelID == modID && rac.aniIndex == aniIdx);
    //}

    //// Token: 0x06002446 RID: 9286 RVA: 0x00018BDE File Offset: 0x00016DDE
    //public bool IsExistsPlayerAnimation(int aniIdx, int weaponIndex)
    //{
    //	return this.IsExistsAnimation(1, aniIdx, weaponIndex);
    //}

    //// Token: 0x06002447 RID: 9287 RVA: 0x000F2120 File Offset: 0x000F0320
    //public bool IsExistsAnimation(int modID, int aniIdx, int weaponIndex)
    //{
    //	return this._table.Exists((RoleAniCollect rac) => rac.modelID == modID && rac.aniIndex == aniIdx && rac.weaponIndex == weaponIndex);
    //}

    //// Token: 0x06002448 RID: 9288 RVA: 0x000F2160 File Offset: 0x000F0360
    //public ArrayList FindRoleAniTypeAll(int aniIdx)
    //{
    //	ArrayList arrayList = null;
    //	foreach (KeyValuePair<RoleAnimationType, ArrayList> keyValuePair in this._aniTypeTable)
    //	{
    //		if (keyValuePair.Value.Contains(aniIdx))
    //		{
    //			if (arrayList == null)
    //			{
    //				arrayList = new ArrayList();
    //			}
    //			arrayList.Add(keyValuePair.Key);
    //		}
    //	}
    //	return arrayList;
    //}

    //// Token: 0x06002449 RID: 9289 RVA: 0x00018BE9 File Offset: 0x00016DE9
    //public ArrayList FindAniIndexByRoleAniType(RoleAnimationType type)
    //{
    //	return (!this._aniTypeTable.ContainsKey(type)) ? null : this._aniTypeTable[type];
    //}

    //// Token: 0x0600244A RID: 9290 RVA: 0x000F21EC File Offset: 0x000F03EC
    //public List<RoleAniCollect> FindByModelID(int modID)
    //{
    //	return this._table.FindAll((RoleAniCollect rac) => rac.modelID == modID);
    //}

    //// Token: 0x0600244B RID: 9291 RVA: 0x000F2220 File Offset: 0x000F0420
    //public List<RoleAniCollect> FindByModelIDAndAniIndex(int modID, int aniIdx)
    //{
    //	return this._table.FindAll((RoleAniCollect rac) => rac.modelID == modID && rac.aniIndex == aniIdx);
    //}

    //// Token: 0x0600244C RID: 9292 RVA: 0x00018C0E File Offset: 0x00016E0E
    //public RoleAniCollect FindPlayerAnimation(int aniIdx, int weaponIndex)
    //{
    //	return this.FindAnimation(1, aniIdx, weaponIndex);
    //}

    //// Token: 0x0600244D RID: 9293 RVA: 0x000F2258 File Offset: 0x000F0458
    //public RoleAniCollect FindAnimation(int modID, int aniIdx, int weaponIndex)
    //{
    //	return this._table.Find((RoleAniCollect rac) => rac.modelID == modID && rac.aniIndex == aniIdx && rac.weaponIndex == weaponIndex);
    //}

    //// Token: 0x0600244E RID: 9294 RVA: 0x000F2298 File Offset: 0x000F0498
    //public void DetachAllAnimation(Role role)
    //{
    //	if (!this.IsSwitch)
    //	{
    //		return;
    //	}
    //	if (Application.isEditor && !ResourcePath.IS_PUBLISH)
    //	{
    //		return;
    //	}
    //	if (role == null)
    //	{
    //		return;
    //	}
    //	for (RoleAnimationType roleAnimationType = RoleAnimationType.Normal; roleAnimationType < RoleAnimationType.Max; roleAnimationType++)
    //	{
    //		this.DetachAnimation(roleAnimationType, role);
    //	}
    //}

    //// Token: 0x0600244F RID: 9295 RVA: 0x000F22E8 File Offset: 0x000F04E8
    //public void DetachAnimation(RoleAnimationType detachType, Role role)
    //{
    //	if (!this.IsSwitch)
    //	{
    //		return;
    //	}
    //	if (Application.isEditor && !ResourcePath.IS_PUBLISH)
    //	{
    //		return;
    //	}
    //	if (role == null)
    //	{
    //		return;
    //	}
    //	if (!this._nowRunAnimation.ContainsKey(detachType))
    //	{
    //		return;
    //	}
    //	ArrayList arrayList = new ArrayList(this._nowRunAnimation[detachType] as ArrayList);
    //	this.print(LogType.Log, new object[]
    //	{
    //		"DetachAnimation",
    //		detachType.ToString(),
    //		role.roleGameObject.Name,
    //		arrayList.Count
    //	});
    //	(this._nowRunAnimation[detachType] as ArrayList).Clear();
    //	this._nowRunAnimation.Remove(detachType);
    //	foreach (object obj in arrayList)
    //	{
    //		string text = (string)obj;
    //		if (!this._nowRunAnimation.ContainsValue(text))
    //		{
    //			AnimationClip clip = role.roleGameObject.RoleAnimation.GetClip(text);
    //			if (clip == null)
    //			{
    //				this.print(LogType.Warning, new object[]
    //				{
    //					"DetachAnimation Continue :",
    //					detachType,
    //					" .No find AnimationClip ",
    //					text,
    //					" RoleModeID=",
    //					role.roleGameObject.ModelID
    //				});
    //			}
    //			else
    //			{
    //				role.roleGameObject.RoleAnimation.RemoveClip(clip);
    //				LoadMachine.DeleteAsset(clip, true);
    //				UnityEngine.Object.DestroyImmediate(clip, false);
    //			}
    //		}
    //	}
    //	this.CheckState(role);
    //	Main.Instance.DelayGC(10f);
    //}

    //// Token: 0x06002450 RID: 9296 RVA: 0x000F24C0 File Offset: 0x000F06C0
    //private void CheckState(Role role)
    //{
    //	if (this._nowRunAnimation.Count < 1)
    //	{
    //		return;
    //	}
    //	foreach (object obj in this._nowRunAnimation.Values)
    //	{
    //		ArrayList arrayList = (ArrayList)obj;
    //		foreach (object obj2 in arrayList)
    //		{
    //			string text = (string)obj2;
    //			AnimationClip animationClip = role.roleGameObject.RoleAnimation.GetClip(text);
    //			if (animationClip == null)
    //			{
    //				animationClip = this.LoadAnimation(role.roleGameObject.ModelInfo.Path + "/" + text);
    //				if (animationClip == null)
    //				{
    //					this.print(LogType.Warning, new object[]
    //					{
    //						"No find AnimationClip ",
    //						text,
    //						" RoleModeID=",
    //						role.roleGameObject.ModelID
    //					});
    //				}
    //				else
    //				{
    //					role.roleGameObject.RoleAnimation.AddClip(animationClip, text);
    //				}
    //			}
    //		}
    //	}
    //}

    //public bool AttachAnimationAdeptTalent(EquipCfgType weapontype, int AmbitID, Role role)
    //{
    //	if (!this.IsSwitch)
    //	{
    //		return false;
    //	}
    //	if (Application.isEditor && !ResourcePath.IS_PUBLISH)
    //	{
    //		return false;
    //	}
    //	int num = 0;
    //	int num2 = 0;
    //	if (weapontype == EquipCfgType.EQCHILD_CT_WEAPON)
    //	{
    //		num = 3;
    //		num2 = 6;
    //	}
    //	else if (weapontype == EquipCfgType.EQCHILD_CT_DWEAPON)
    //	{
    //		num = 11;
    //		num2 = 14;
    //	}
    //	else if (weapontype == EquipCfgType.EQCHILD_CT_MAGICWEAPON)
    //	{
    //		num = 7;
    //		num2 = 10;
    //	}
    //	int num3 = 0;
    //	int num4 = 0;
    //	for (int i = num; i <= num2; i++)
    //	{
    //		num3++;
    //		if (AmbitID != num3)
    //		{
    //			this.DetachAnimation((RoleAnimationType)i, role);
    //		}
    //		else
    //		{
    //			num4 = i;
    //		}
    //	}
    //	Debug.Log("attach = " + (RoleAnimationType)num4);
    //	return this.AttachAnimation((RoleAnimationType)num4, role);
    //}

    public bool AttachAnimation(RoleAnimationType attachType, Role role)
    {
        return this.AttachAnimation(attachType, role, false);
    }

    public bool AttachAnimation(RoleAnimationType attachType, Role role, bool detachOther)
    {      
        if (role == null)
        {
            return false;
        }

        if (this._nowRunAnimation.ContainsKey(attachType))
        {
            return false;
        }

        if (role.roleGameObject.RoleAnimation == null)
        {
            Animation animation = role.roleGameObject.RoleBody.AddComponent<Animation>();
            animation.playAutomatically = true;
            animation.animatePhysics = false;
            animation.cullingType = AnimationCullingType.BasedOnRenderers;
            animation.localBounds = new Bounds(Vector3.zero, new Vector3(500f, 500f, 500f));
        }

        //ArrayList arrayList = this.FindAniIndexByRoleAniType(attachType);
        //if (arrayList == null)
        //{
        //    this.print(LogType.Error, new object[]
        //    {
        //        "No define data ",
        //        attachType
        //    });
        //    return false;
        //}

        //foreach (object obj in arrayList)
        //{
        //    int aniIdx = (int)obj;
        //    List<RoleAniCollect> list = this.FindByModelIDAndAniIndex(role.roleGameObject.ModelID, aniIdx);
        //    foreach (RoleAniCollect roleAniCollect in list)
        //    {
        //        if (roleAniCollect.ContainsType != null && roleAniCollect.ContainsType.Contains(attachType))
        //        {
        //            AnimationClip animationClip = role.roleGameObject.RoleAnimation.GetClip(roleAniCollect.aniName);
        //            if (animationClip == null)
        //            {
        //                animationClip = this.LoadAnimation(role.roleGameObject.ModelInfo.Path + "/" + roleAniCollect.aniName);
        //                if (animationClip == null)
        //                {
        //                    this.print(LogType.Warning, new object[]
        //                    {
        //                        "AttachAnimation Continue :",
        //                        attachType,
        //                        " .No find AnimationClip ",
        //                        roleAniCollect.aniName,
        //                        " RoleModeID=",
        //                        role.roleGameObject.ModelID
        //                    });
        //                    continue;
        //                }
        //                role.roleGameObject.RoleAnimation.AddClip(animationClip, roleAniCollect.aniName);
        //            }
        //            if (!this._nowRunAnimation.ContainsKey(attachType))
        //            {
        //                ArrayList arrayList2 = new ArrayList();
        //                arrayList2.Add(roleAniCollect.aniName);
        //                this._nowRunAnimation.Add(attachType, arrayList2);
        //            }
        //            else
        //            {
        //                ArrayList arrayList3 = this._nowRunAnimation[attachType] as ArrayList;
        //                arrayList3.Add(roleAniCollect.aniName);
        //            }
        //        }
        //    }
        //}
        //AnimationClip clip = role.roleGameObject.RoleAnimation.GetClip("zhanli");
        //if (clip != null)
        //{
        //    role.roleGameObject.RoleAnimation.clip = clip;
        //    role.roleGameObject.RoleAnimation.Play("zhanli");
        //}
        return true;
    }

    //private AnimationClip LoadAnimation(string name)
    //{
    //	return ResourceLoader.Load(name, typeof(AnimationClip)) as AnimationClip;
    //}

    //public void AddRes(string name, AnimationClip ac)
    //{
    //	if (this._tempRes.ContainsKey(name))
    //	{
    //		return;
    //	}
    //	this._tempRes.Add(name, ac);
    //}

    //// Token: 0x06002457 RID: 9303 RVA: 0x00018C7F File Offset: 0x00016E7F
    //public void ClearRes()
    //{
    //	this._tempRes.Clear();
    //}
}
