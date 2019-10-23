using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtility;

// Token: 0x0200058A RID: 1418
public class BuffTableManager : Singleton<BuffTableManager>
{
	// Token: 0x060025D7 RID: 9687 RVA: 0x000199BF File Offset: 0x00017BBF
	public BuffTableManager()
	{
		this.TextLoad();
	}

	// Token: 0x060025D8 RID: 9688 RVA: 0x000FDC8C File Offset: 0x000FBE8C
	public void Load()
	{
		this.m_mapBuffData.Clear();
		CSerializer cserializer = new CSerializer();
		//CFile cfile = new CFile(Application.dataPath + string.Empty);
		//cserializer.BeginRead(cfile.ReadBytesAll());
		int num = cserializer.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			BuffData buffData = new BuffData();
			buffData.Read(cserializer);
			this.m_mapBuffData.Add(buffData.ID, buffData);
		}
		cserializer.EndRead();
	}

	// Token: 0x060025D9 RID: 9689 RVA: 0x000FDD10 File Offset: 0x000FBF10
	public void Save()
	{
		CSerializer cserializer = new CSerializer();
		cserializer.BeginWrite();
		cserializer.Write(this.m_mapBuffData.Count);
		foreach (KeyValuePair<int, BuffData> keyValuePair in this.m_mapBuffData)
		{
			keyValuePair.Value.Write(cserializer);
		}
		//CFile cfile = new CFile(Application.dataPath + string.Empty);
		//cfile.WriteBytesAll(cserializer.GetWriteBytes());
		cserializer.EndWrite();
	}

	// Token: 0x060025DA RID: 9690 RVA: 0x000FDDB8 File Offset: 0x000FBFB8
	public void TextLoad()
	{
		this.m_mapBuffData.Clear();
		List<string> list = UtilityLoader.LoadConfText("conf/DataFile/BuffTable");
		int i = 0;
		while (i < list.Count)
		{
			BuffData buffData = new BuffData();
			buffData.TextRead(list, ref i);
			this.m_mapBuffData.Add(buffData.ID, buffData);
		}
	}

	// Token: 0x060025DB RID: 9691 RVA: 0x000199D8 File Offset: 0x00017BD8
	public BuffData GetBuffData(int id)
	{
		if (this.m_mapBuffData.ContainsKey(id))
		{
			return this.m_mapBuffData[id];
		}
		return null;
	}

	// Token: 0x04002279 RID: 8825
	private Dictionary<int, BuffData> m_mapBuffData = new Dictionary<int, BuffData>();
}
