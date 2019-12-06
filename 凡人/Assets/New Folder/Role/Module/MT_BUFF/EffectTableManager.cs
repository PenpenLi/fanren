using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

// Token: 0x02000242 RID: 578
public class EffectTableManager : Singleton<EffectTableManager>
{
	// Token: 0x06000F3A RID: 3898 RVA: 0x0000B483 File Offset: 0x00009683
	public EffectTableManager()
	{
		this.TextLoad();
	}

	// Token: 0x06000F3B RID: 3899 RVA: 0x00097088 File Offset: 0x00095288
	private void InfoLoad()
	{
		this.m_mapEffectInfo.Clear();
		CSerializer cserializer = new CSerializer();
		//CFile cfile = new CFile(Application.dataPath + "/Data/EffectInfoScript.dt");
		//cserializer.BeginRead(cfile.ReadBytesAll());
		int num = cserializer.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			CEffectData ceffectData = new CEffectData();
			ceffectData.Read(cserializer);
			this.m_mapEffectInfo.Add(ceffectData.TypeId, ceffectData);
		}
		cserializer.EndRead();
	}

	// Token: 0x06000F3C RID: 3900 RVA: 0x0000B4A7 File Offset: 0x000096A7
	public void Load()
	{
		this.InfoLoad();
	}

	// Token: 0x06000F3D RID: 3901 RVA: 0x0009710C File Offset: 0x0009530C
	private void InfoSave()
	{
		CSerializer cserializer = new CSerializer();
		cserializer.BeginWrite();
		cserializer.Write(this.m_mapEffectInfo.Count);
		foreach (KeyValuePair<int, CEffectData> keyValuePair in this.m_mapEffectInfo)
		{
			keyValuePair.Value.Write(cserializer);
		}
		//CFile cfile = new CFile(Application.dataPath + "/Data/EffectInfoScript.dt");
		//cfile.WriteBytesAll(cserializer.GetWriteBytes());
		cserializer.EndWrite();
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x0000B4AF File Offset: 0x000096AF
	public void Save()
	{
		this.InfoSave();
	}

	// Token: 0x06000F3F RID: 3903 RVA: 0x000971B4 File Offset: 0x000953B4
	private void InfoTextLoad()
	{
		List<string> list = new List<string>();
		list = UtilityLoader.LoadConfText("conf/DataFile/EffectTable");
		this.m_mapEffectInfo.Clear();
		int i = 0;
		while (i < list.Count)
		{
			CEffectData ceffectData = new CEffectData();
			ceffectData.TextRead(list, ref i);
			this.m_mapEffectInfo.Add(ceffectData.TypeId, ceffectData);
		}
		this.m_mapMovieEffectInfo.Clear();
		List<string> list2 = new List<string>();
		list2 = UtilityLoader.LoadConfText("conf/DataFile/MovieEffectTable");
		int j = 0;
		while (j < list2.Count)
		{
			CEffectData ceffectData2 = new CEffectData();
			ceffectData2.TextRead(list2, ref j);
			this.m_mapMovieEffectInfo.Add(ceffectData2.TypeId, ceffectData2);
		}
	}

	// Token: 0x06000F40 RID: 3904 RVA: 0x0000B4B7 File Offset: 0x000096B7
	public void TextLoad()
	{
		this.InfoTextLoad();
	}

	// Token: 0x06000F41 RID: 3905 RVA: 0x0000B4BF File Offset: 0x000096BF
	public CEffectData GetEffectInfo(int id)
	{
		if (this.m_mapEffectInfo.ContainsKey(id))
		{
			return this.m_mapEffectInfo[id];
		}
		return null;
	}

	// Token: 0x06000F42 RID: 3906 RVA: 0x0000B4E0 File Offset: 0x000096E0
	public CEffectData GetMovieEffectInfo(int id)
	{
		if (this.m_mapMovieEffectInfo.ContainsKey(id))
		{
			return this.m_mapMovieEffectInfo[id];
		}
		return null;
	}

	// Token: 0x04001039 RID: 4153
	private Dictionary<int, CEffectData> m_mapEffectInfo = new Dictionary<int, CEffectData>();

	// Token: 0x0400103A RID: 4154
	private Dictionary<int, CEffectData> m_mapMovieEffectInfo = new Dictionary<int, CEffectData>();
}
