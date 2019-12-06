using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200023E RID: 574
public class EffectManager : SingletonMono<EffectManager>
{
	// Token: 0x06000F16 RID: 3862 RVA: 0x0000B30C File Offset: 0x0000950C
	public void ClearObject()
	{
		this.m_lstEfflist.Clear();
		this.effectPrefabs.Clear();
		this.movieEffectPrefabs.Clear();
	}

	// Token: 0x06000F17 RID: 3863 RVA: 0x0000B32F File Offset: 0x0000952F
	private void OnDestroy()
	{
		this.ClearObject();
	}

	// Token: 0x06000F18 RID: 3864 RVA: 0x0009664C File Offset: 0x0009484C
	public EffectBase[] GetEffectbyType(int typeID)
	{
		List<EffectBase> list = new List<EffectBase>();
		foreach (EffectBase effectBase in this.m_lstEfflist)
		{
			if (effectBase != null && effectBase.effectID == typeID)
			{
				list.Add(effectBase);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x000966CC File Offset: 0x000948CC
	public GameObject InitEffect(int id, bool is_movie)
	{
		GameObject gameObject = null;
		if (is_movie)
		{
			if (this.movieEffectPrefabs.ContainsKey(id) && this.movieEffectPrefabs[id] != null)
			{
				gameObject = this.movieEffectPrefabs[id];
			}
			if (gameObject == null)
			{
				//gameObject = (GameObject)Singleton<CResourcesStaticManager>.GetInstance().GetMovieRes(id);
				if (this.movieEffectPrefabs.ContainsKey(id))
				{
					this.movieEffectPrefabs[id] = gameObject;
				}
				else
				{
					this.movieEffectPrefabs.Add(id, gameObject);
				}
			}
		}
		else
		{
			if (this.effectPrefabs.ContainsKey(id) && this.effectPrefabs[id] != null)
			{
				gameObject = this.effectPrefabs[id];
			}
			if (gameObject == null)
			{
				//gameObject = (GameObject)Singleton<CResourcesStaticManager>.GetInstance().GetRes(id, typeof(GameObject));
				if (this.effectPrefabs.ContainsKey(id))
				{
					this.effectPrefabs[id] = gameObject;
				}
				else
				{
					this.effectPrefabs.Add(id, gameObject);
				}
			}
		}
		if (gameObject == null)
		{
			gameObject = new GameObject("Effect");
			//Logger.LogWarning(new object[]
			//{
			//	"Effect " + id + " can't be found!"
			//});
			return gameObject;
		}
        //GameObject gameObject2 = LoadMachine.InstantiateObject(gameObject, Vector3.zero, Quaternion.identity) as GameObject;
        //ComponentStateControl.CheckStateControl(gameObject2);
        //return gameObject2;
        return null;

    }

	// Token: 0x06000F1A RID: 3866 RVA: 0x00096850 File Offset: 0x00094A50
	public EffectBase GetEffectById(int id)
	{
		for (int i = 0; i < this.m_lstEfflist.Count; i++)
		{
			if (this.m_lstEfflist[i].Id == id)
			{
				return this.m_lstEfflist[i];
			}
		}
		return null;
	}

	// Token: 0x06000F1B RID: 3867 RVA: 0x0000B337 File Offset: 0x00009537
	public int AddEffectFixure(int id, Vector3 pos, Quaternion rotate)
	{
		return this.AddEffect(id, pos, Vector3.zero, pos, rotate, null, false);
	}

	// Token: 0x06000F1C RID: 3868 RVA: 0x0000B34A File Offset: 0x0000954A
	public int AddEffectFixure(int id, Vector3 pos, Quaternion rotate, bool isMovie)
	{
		return this.AddEffect(id, pos, Vector3.zero, pos, rotate, null, isMovie);
	}

	// Token: 0x06000F1D RID: 3869 RVA: 0x0000B35E File Offset: 0x0000955E
	public int AddEffectBind(int id, GameObject target)
	{
		return this.AddEffect(id, Vector3.zero, Vector3.zero, Vector3.zero, Quaternion.identity, target, false);
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x0000B37D File Offset: 0x0000957D
	public int AddEffectBind(int id, GameObject target, bool isMovie)
	{
		return this.AddEffect(id, Vector3.zero, Vector3.zero, Vector3.zero, Quaternion.identity, target, isMovie);
	}

	// Token: 0x06000F1F RID: 3871 RVA: 0x000968A0 File Offset: 0x00094AA0
	public int AddEffectFllow(int id, Vector3 pos, Quaternion rotate, GameObject target, float initSpeed)
	{
		return this.AddEffect(id, pos, Vector3.zero, Vector3.zero, rotate, target, false, initSpeed);
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x0000B39C File Offset: 0x0000959C
	public int AddEffectFllow(int id, Vector3 pos, Quaternion rotate, GameObject target, bool isMovie)
	{
		return this.AddEffect(id, pos, Vector3.zero, Vector3.zero, rotate, target, isMovie);
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x0000B3B5 File Offset: 0x000095B5
	public int AddEffectLink(int id, Vector3 pos, Quaternion rotate, GameObject target)
	{
		return this.AddEffect(id, pos, Vector3.zero, target.transform.position, rotate, target, false);
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x0000B3D4 File Offset: 0x000095D4
	public int AddEffectLink(int id, Vector3 pos, Quaternion rotate, GameObject target, bool isMovie)
	{
		return this.AddEffect(id, pos, Vector3.zero, target.transform.position, rotate, target, isMovie);
	}

	// Token: 0x06000F23 RID: 3875 RVA: 0x0000B3F4 File Offset: 0x000095F4
	public int AddEffectLinkEx(int id, Vector3 pos, Quaternion rotate, Vector3 targetPos, bool isPositive)
	{
		return this.AddEffect(id, pos, Vector3.zero, targetPos, rotate, null, false);
	}

	// Token: 0x06000F24 RID: 3876 RVA: 0x0000B408 File Offset: 0x00009608
	public int AddEffectLinkEx(int id, Vector3 pos, Quaternion rotate, Vector3 targetPos, bool isPositive, bool isMovie)
	{
		return this.AddEffect(id, pos, Vector3.zero, targetPos, rotate, null, isMovie);
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x0000B41D File Offset: 0x0000961D
	public int AddEffectRay(int id, Vector3 pos, Quaternion rotate, Vector3 dir)
	{
		return this.AddEffect(id, pos, dir, Vector3.zero, rotate, null, false);
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x0000B431 File Offset: 0x00009631
	public int AddEffectRadial(int id, Vector3 pos, Quaternion rotate, Vector3 dir, bool isMovie)
	{
		return this.AddEffect(id, pos, dir, Vector3.zero, rotate, null, isMovie);
	}

	// Token: 0x06000F27 RID: 3879 RVA: 0x00002C8D File Offset: 0x00000E8D
	public int AddEffectParabola(int id)
	{
		return 0;
	}

	// Token: 0x06000F28 RID: 3880 RVA: 0x00002C8D File Offset: 0x00000E8D
	public int AddEffectRoleBodyCover(int id, Role role)
	{
		return 0;
	}

	// Token: 0x06000F29 RID: 3881 RVA: 0x000968C8 File Offset: 0x00094AC8
	public KeyValuePair<string, Type> GetEffetResPath(int effectID)
	{
		CEffectData effectInfo = Singleton<EffectTableManager>.GetInstance().GetEffectInfo(effectID);
		//if (effectInfo != null)
		//{
		//	return UtilityRoleResource.GetResPath(effectInfo.ResId);
		//}
		return default(KeyValuePair<string, Type>);
	}

	// Token: 0x06000F2A RID: 3882 RVA: 0x00096900 File Offset: 0x00094B00
	public int AddEffect(int id, Vector3 Pos, Vector3 Dir, Vector3 targetPos, Quaternion Rot, GameObject Target, bool is_movie, float value1)
	{
		CEffectData ceffectData;
		if (is_movie)
		{
			ceffectData = Singleton<EffectTableManager>.GetInstance().GetMovieEffectInfo(id);
		}
		else
		{
			ceffectData = Singleton<EffectTableManager>.GetInstance().GetEffectInfo(id);
		}
		if (ceffectData == null)
		{
			Debug.Log(id + " Effect Info is None.");
			return 0;
		}
		return this.AddEffect(ceffectData, Pos, Dir, Rot, ceffectData.Type, Target, targetPos, is_movie, value1);
	}

	// Token: 0x06000F2B RID: 3883 RVA: 0x0009696C File Offset: 0x00094B6C
	public int AddEffect(int id, Vector3 Pos, Vector3 Dir, Vector3 targetPos, Quaternion Rot, GameObject Target, bool is_movie)
	{
		return this.AddEffect(id, Pos, Dir, targetPos, Rot, Target, is_movie, 0f);
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x00096990 File Offset: 0x00094B90
	private int AddEffect(CEffectData info, Vector3 Pos, Vector3 Velocity, Quaternion Rot, short EffType, GameObject Target, Vector3 TargetPos, bool is_movie, float value1)
	{
		float lastTime = info.LastTime;
		int resId = info.ResId;
		GameObject gameObject = this.InitEffect(resId, is_movie);
		if (gameObject == null)
		{
			return 0;
		}
		if (info.effectSoundData.IsHasSound())
		{
			//EffectSoundMono.AddSound(info.effectSoundData, gameObject);
		}
		int num = 0;
		switch (EffType)
		{
		case 1:
		{
			//EffectFixure effectFixure = gameObject.AddComponent<EffectFixure>();
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//effectFixure.SetParam(num, TargetPos, Rot, lastTime);
			//this.m_lstEfflist.Add(effectFixure);
			break;
		}
		case 2:
		{
			//EffectBind effectBind = gameObject.AddComponent<EffectBind>();
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//effectBind.SetParam(num, Target, lastTime);
			//this.m_lstEfflist.Add(effectBind);
			break;
		}
		case 3:
		{
			//EffectFllow effectFllow = gameObject.AddComponent<EffectFllow>();
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//effectFllow.SetParam(num, Pos, Rot, Target, value1);
			//this.m_lstEfflist.Add(effectFllow);
			break;
		}
		case 4:
		{
			//EffectRadial effectRadial = gameObject.AddComponent<EffectRadial>();
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//effectRadial.SetParam(resId, num, Pos, Velocity, Rot, lastTime);
			//this.m_lstEfflist.Add(effectRadial);
			break;
		}
		case 5:
		{
			//EffectParabola effectParabola = gameObject.AddComponent<EffectParabola>();
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//effectParabola.SetParam(num, Pos, Velocity, Rot);
			//this.m_lstEfflist.Add(effectParabola);
			break;
		}
		case 6:
		{
			//EffectLink effectLink = gameObject.AddComponent<EffectLink>();
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//effectLink.SetParam(num, Pos, Rot, Target, lastTime);
			//this.m_lstEfflist.Add(effectLink);
			break;
		}
		case 7:
		{
			//EffectScale effectScale = gameObject.AddComponent<EffectScale>();
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//effectScale.SetParam(num, Pos, Rot, TargetPos, lastTime);
			//this.m_lstEfflist.Add(effectScale);
			break;
		}
		case 8:
			//SingletonMono<ScreenShockController>.GetInstance().Shock(new Vector3(1.5f, 2f, 0f), lastTime);
			break;
		case 9:
		{
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//EffectCameraFadeOut effectCameraFadeOut = gameObject.AddComponent<EffectCameraFadeOut>();
			//effectCameraFadeOut.SetParam(num, null, lastTime);
			//this.m_lstEfflist.Add(effectCameraFadeOut);
			break;
		}
		case 10:
		{
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//EffectCameraFadeIn effectCameraFadeIn = gameObject.AddComponent<EffectCameraFadeIn>();
			//effectCameraFadeIn.SetParam(num, null, lastTime);
			//this.m_lstEfflist.Add(effectCameraFadeIn);
			break;
		}
		case 11:
		{
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//EffectCameraFillColor effectCameraFillColor = gameObject.AddComponent<EffectCameraFillColor>();
			//effectCameraFillColor.SetParam(num, null, lastTime);
			//this.m_lstEfflist.Add(effectCameraFillColor);
			break;
		}
		case 12:
		{
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//EffectCameraFadeOutEx effectCameraFadeOutEx = gameObject.AddComponent<EffectCameraFadeOutEx>();
			//effectCameraFadeOutEx.SetParam(num, null, lastTime);
			//this.m_lstEfflist.Add(effectCameraFadeOutEx);
			break;
		}
		case 13:
		{
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//EffectCameraFadeInEx effectCameraFadeInEx = gameObject.AddComponent<EffectCameraFadeInEx>();
			//effectCameraFadeInEx.SetParam(num, null, lastTime);
			//this.m_lstEfflist.Add(effectCameraFadeInEx);
			break;
		}
		case 14:
		{
			num = Singleton<ActorManager>.GetInstance().Add(gameObject);
			//EffectCameraFillColorEx effectCameraFillColorEx = gameObject.AddComponent<EffectCameraFillColorEx>();
			//effectCameraFillColorEx.SetParam(num, null, lastTime);
			//this.m_lstEfflist.Add(effectCameraFillColorEx);
			break;
		}
		}
		EffectBase component = gameObject.GetComponent<EffectBase>();
		if (component != null)
		{
			component.effectID = info.TypeId;
		}
		return num;
	}

	// Token: 0x06000F2D RID: 3885 RVA: 0x00096CFC File Offset: 0x00094EFC
	public void Delete(int CurEffectID)
	{
		if (CurEffectID <= 0)
		{
			return;
		}
		foreach (EffectBase effectBase in this.m_lstEfflist)
		{
			if (effectBase.Id == CurEffectID)
			{
				effectBase.Over();
				this.m_lstEfflist.Remove(effectBase);
				Singleton<ActorManager>.GetInstance().Del(effectBase.Id);
				break;
			}
		}
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x00096D94 File Offset: 0x00094F94
	public bool IsExist(int id)
	{
		for (int i = 0; i < this.m_lstEfflist.Count; i++)
		{
			if (this.m_lstEfflist[i].Id == id)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400102F RID: 4143
	private int m_iCurEffectID = 50000;

	// Token: 0x04001030 RID: 4144
	private List<EffectBase> m_lstEfflist = new List<EffectBase>();

	// Token: 0x04001031 RID: 4145
	private Dictionary<int, GameObject> effectPrefabs = new Dictionary<int, GameObject>();

	// Token: 0x04001032 RID: 4146
	private Dictionary<int, GameObject> movieEffectPrefabs = new Dictionary<int, GameObject>();
}
