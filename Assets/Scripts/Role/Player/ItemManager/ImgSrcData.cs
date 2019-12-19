using System;
using UnityEngine;

// Token: 0x020001B7 RID: 439
public class ImgSrcData : IComparable
{
	// Token: 0x06000907 RID: 2311 RVA: 0x0002BE70 File Offset: 0x0002A070
	public ImgSrcData(ulong idx, string na, string ph)
	{
		this.id = idx;
		this.name = na;
		this.path = ph;
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x0002BE90 File Offset: 0x0002A090
	public int CompareTo(object obj)
	{
		int result;
		try
		{
			ImgSrcData imgSrcData = (ImgSrcData)obj;
			if (this.tex == null || imgSrcData.tex == null)
			{
				result = -1;
			}
			else
			{
				result = this.tex.height.CompareTo(imgSrcData.tex.height);
			}
		}
		catch (Exception ex)
		{
			result = -1;
		}
		return result;
	}

	// Token: 0x040007F6 RID: 2038
	public ulong id;

	// Token: 0x040007F7 RID: 2039
	public string name;

	// Token: 0x040007F8 RID: 2040
	public string path;

	// Token: 0x040007F9 RID: 2041
	public Texture2D tex;
}
