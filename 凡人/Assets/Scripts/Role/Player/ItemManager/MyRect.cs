using System;

// Token: 0x020001B6 RID: 438
public class MyRect
{
	// Token: 0x06000906 RID: 2310 RVA: 0x0002BE38 File Offset: 0x0002A038
	public MyRect(float fx, float fy, float fw, float fh, float tw, float th)
	{
		this.x = fx;
		this.y = fy;
		this.width = fw;
		this.height = fh;
		this.texw = tw;
		this.texh = th;
	}

	// Token: 0x040007F0 RID: 2032
	public float x;

	// Token: 0x040007F1 RID: 2033
	public float y;

	// Token: 0x040007F2 RID: 2034
	public float width;

	// Token: 0x040007F3 RID: 2035
	public float height;

	// Token: 0x040007F4 RID: 2036
	public float texw;

	// Token: 0x040007F5 RID: 2037
	public float texh;
}
