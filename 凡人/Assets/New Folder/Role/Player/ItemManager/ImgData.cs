using System;
using UnityEngine;

// Token: 0x020001B8 RID: 440
public class ImgData
{
	// Token: 0x06000909 RID: 2313 RVA: 0x0002BF20 File Offset: 0x0002A120
	public ImgData(ulong idx, string na, int imgcnt)
	{
		this.id = idx;
		this.name = na;
		this.imgorder = imgcnt;
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x0002BF40 File Offset: 0x0002A140
	public override string ToString()
	{
		return string.Concat(new object[]
		{
			"( id=",
			this.id,
			"; name=",
			this.name,
			"; offset=",
			this.offset,
			"; uv=",
			this.uv,
			"; size=",
			this.size,
			"; imgorder=",
			this.imgorder,
			"; texpath=",
			this.texpath,
			" )"
		});
	}

	// Token: 0x040007FA RID: 2042
	public ulong id;

	// Token: 0x040007FB RID: 2043
	public string name;

	// Token: 0x040007FC RID: 2044
	public Vector2 offset;

	// Token: 0x040007FD RID: 2045
	public Vector2 uv;

	// Token: 0x040007FE RID: 2046
	public Vector3 size;

	// Token: 0x040007FF RID: 2047
	public int imgorder;

	// Token: 0x04000800 RID: 2048
	public string texpath;
}
