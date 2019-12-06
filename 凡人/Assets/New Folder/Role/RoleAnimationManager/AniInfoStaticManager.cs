using System;
using System.Collections.Generic;
using UnityUtility;

public class AniInfoStaticManager : Singleton<AniInfoStaticManager>
{
    private Dictionary<long, AniInfo> aniInfoData = new Dictionary<long, AniInfo>();

    public AniInfoStaticManager()
	{
		this.TextLoad();
	}

	public Dictionary<long, AniInfo> AniInfoData
	{
		get
		{
			return this.aniInfoData;
		}
	}

	public AniInfo GetAniInfoById(long id)
	{
		if (this.aniInfoData.ContainsKey(id))
		{
			return this.aniInfoData[id];
		}
		return null;
	}

	public void TextLoad()
	{
		List<string> list = UtilityLoader.LoadConfText("conf/Anim/Animation");
		int i = 0;
		while (i < list.Count)
		{
			long num = (long)Convert.ToInt32(list[i]);
			i++;
			long num2 = (long)Convert.ToInt32(list[i]);
			i++;
			long num3 = (long)Convert.ToInt32(list[i]);
			i++;
			long nHorse = (long)Convert.ToInt32(list[i]);
			i++;
			AniInfo.AniInfoNode aniInfoNode = new AniInfo.AniInfoNode();
			aniInfoNode.animatioIndex = (int)num;
			aniInfoNode.meshIndex = (int)num2;
			aniInfoNode.weapoIndex = (int)num3;
			aniInfoNode.TextLoad(list, ref i);
			long aniId = this.GetAniId(nHorse, num3, num2, num);
			if (this.aniInfoData.ContainsKey(aniId))
			{
				this.aniInfoData[aniId].AniNameList.Add(aniInfoNode);
			}
			else
			{
				AniInfo aniInfo = new AniInfo();
				aniInfo.AniNameList.Add(aniInfoNode);
				this.aniInfoData.Add(aniId, aniInfo);
			}
		}
	}

	public long GetAniId(long nHorse, long nWeaponIndex, long nMeshIndex, long nAniIndex)
	{
		return nHorse * 100000000000L + nWeaponIndex * 100000000L + nMeshIndex * 10000L + nAniIndex;
	}
}
