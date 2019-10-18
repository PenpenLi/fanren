using System;
using System.Collections.Generic;
using UnityUtility;

public class MFSTableManager : Singleton<MFSTableManager>
{
    private Dictionary<MFS_TALBE_TYPE, MFSTable> m_mapTables = new Dictionary<MFS_TALBE_TYPE, MFSTable>();

    public MFSTableManager()
	{
		this.TextLoad();
	}

	private void TextLoad()
	{
		this.m_mapTables.Clear();
		List<string> list = UtilityLoader.LoadConfText("conf/DataFile/MFSTable");
		int i = 0;
		while (i < list.Count)
		{
			int key = Convert.ToInt32(list[i++]);
			MFSTable mfstable = new MFSTable();
			mfstable.TextRead(list, ref i);
			this.m_mapTables.Add((MFS_TALBE_TYPE)key, mfstable);
		}
	}

	public MFSTable GetTableByType(MFS_TALBE_TYPE mty)
	{
		if (this.m_mapTables.ContainsKey(mty))
		{
			return this.m_mapTables[mty];
		}
		return null;
	}
}
