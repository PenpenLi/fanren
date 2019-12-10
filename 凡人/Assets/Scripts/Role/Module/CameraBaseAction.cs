using System;

// Token: 0x02000071 RID: 113
public class CameraBaseAction
{
	// Token: 0x0600023D RID: 573 RVA: 0x00003888 File Offset: 0x00001A88
	public CameraBaseAction()
	{
		this.ExcuteCount = 0;
		this.ExcuteLimitCount = -1;
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x0600023E RID: 574 RVA: 0x0000389E File Offset: 0x00001A9E
	// (set) Token: 0x0600023F RID: 575 RVA: 0x000038A6 File Offset: 0x00001AA6
	public bool IsStart { get; set; }

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x06000240 RID: 576 RVA: 0x000038AF File Offset: 0x00001AAF
	// (set) Token: 0x06000241 RID: 577 RVA: 0x000038B7 File Offset: 0x00001AB7
	public bool IsPause { get; set; }

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x06000242 RID: 578 RVA: 0x000038C0 File Offset: 0x00001AC0
	// (set) Token: 0x06000243 RID: 579 RVA: 0x000038C8 File Offset: 0x00001AC8
	public bool IsEnd { get; private set; }

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x06000244 RID: 580 RVA: 0x000038D1 File Offset: 0x00001AD1
	// (set) Token: 0x06000245 RID: 581 RVA: 0x000038D9 File Offset: 0x00001AD9
	public int ExcuteLimitCount { get; set; }

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x06000246 RID: 582 RVA: 0x000038E2 File Offset: 0x00001AE2
	// (set) Token: 0x06000247 RID: 583 RVA: 0x000038EA File Offset: 0x00001AEA
	public int ExcuteCount { get; private set; }

	// Token: 0x06000248 RID: 584 RVA: 0x00002AD8 File Offset: 0x00000CD8
	public virtual bool Create()
	{
		return true;
	}

	// Token: 0x06000249 RID: 585 RVA: 0x0000221B File Offset: 0x0000041B
	public void SetParameter()
	{
	}

	// Token: 0x0600024A RID: 586 RVA: 0x000038F3 File Offset: 0x00001AF3
	public virtual bool Play()
	{
		this.IsStart = true;
		this.IsPause = false;
		this.IsEnd = false;
		this.ExcuteCount++;
		return true;
	}

	// Token: 0x0600024B RID: 587 RVA: 0x00003919 File Offset: 0x00001B19
	public virtual bool Stop()
	{
		this.IsStart = false;
		this.IsPause = false;
		this.IsEnd = true;
		return true;
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00003931 File Offset: 0x00001B31
	public virtual void Reset()
	{
		this.Stop();
	}

	// Token: 0x0600024D RID: 589 RVA: 0x00003931 File Offset: 0x00001B31
	public virtual void Release()
	{
		this.Stop();
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00002AD8 File Offset: 0x00000CD8
	public virtual bool Update()
	{
		return true;
	}
}
