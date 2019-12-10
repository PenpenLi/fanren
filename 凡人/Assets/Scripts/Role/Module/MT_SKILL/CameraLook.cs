using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : CameraBaseAction
{
    private int offset;

    // Token: 0x0400019E RID: 414
    private float fElapseTime;

    // Token: 0x0400019F RID: 415
    private Vector3 currentVelocity = Vector3.zero;

    // Token: 0x040001A0 RID: 416
    private Vector3 lastPos = Vector3.zero;

    // Token: 0x040001A1 RID: 417
    private List<CameraLook.LookInfo> _Actions = new List<CameraLook.LookInfo>();

    // Token: 0x040001A2 RID: 418
    private Transform mc;

    public void AddPos(Vector3 to, float time, float mtime, bool IsImmediately)
	{
		if (base.IsPause)
		{
			return;
		}
		if (IsImmediately)
		{
			this.Reset();
		}
		this._Actions.Add(new CameraLook.LookInfo(to, time, mtime));
	}

	// Token: 0x06000269 RID: 617 RVA: 0x00003AF7 File Offset: 0x00001CF7
	public override void Reset()
	{
		this._Actions.Clear();
		this.offset = 0;
		this.fElapseTime = 0f;
		this.lastPos = Vector3.zero;
	}

	// Token: 0x0600026A RID: 618 RVA: 0x0002662C File Offset: 0x0002482C
	public override bool Play()
	{
		this.offset = 0;
		this.fElapseTime = 0f;
		this.lastPos = Vector3.zero;
		if (Player.Instance != null && Player.Instance.m_cModCamera != null)
		{
			this.mc = Player.Instance.m_cModCamera.mainCamera.transform;
		}
		return base.Play();
	}

	// Token: 0x0600026B RID: 619 RVA: 0x00003B21 File Offset: 0x00001D21
	public override bool Stop()
	{
		base.Stop();
		return true;
	}

	// Token: 0x0600026C RID: 620 RVA: 0x00003B2B File Offset: 0x00001D2B
	public override void Release()
	{
		this._Actions.Clear();
		base.Release();
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00026690 File Offset: 0x00024890
	public override bool Update()
	{
		base.Update();
		if (this._Actions.Count < 1)
		{
			return true;
		}
		CameraLook.LookInfo lookInfo = this._Actions[this.offset];
		bool flag = false;
		if (lookInfo.fMoveTime == 0f)
		{
			this.lastPos = lookInfo.Pos;
			flag = true;
		}
		else
		{
			this.lastPos = Vector3.SmoothDamp(this.lastPos, lookInfo.Pos, ref this.currentVelocity, lookInfo.fMoveTime * GameTime.deltaTime);
			if (this.currentVelocity.ToString() == Vector3.zero.ToString())
			{
				flag = true;
			}
		}
		if (this.mc != null)
		{
			this.mc.LookAt(this.lastPos);
		}
		if (flag)
		{
			this.fElapseTime += GameTime.deltaTime;
		}
		else if (this.lastPos == lookInfo.Pos)
		{
			this.fElapseTime += GameTime.deltaTime;
		}
		if (this.fElapseTime >= lookInfo.fTime || lookInfo.fTime == 0f)
		{
			this.offset++;
			this.fElapseTime = 0f;
			if (this.offset >= this._Actions.Count)
			{
				this.Reset();
			}
		}
		return true;
	}

	// Token: 0x02000074 RID: 116
	public class LookInfo
	{
		// Token: 0x0600026E RID: 622 RVA: 0x00003B3E File Offset: 0x00001D3E
		public LookInfo(Vector3 to, float time, float mtime)
		{
			this.Pos = to;
			this.fTime = time;
			this.fMoveTime = mtime;
			this.fStartTime = GameTime.time;
		}

		// Token: 0x040001A3 RID: 419
		public Vector3 Pos;

		// Token: 0x040001A4 RID: 420
		public float fTime;

		// Token: 0x040001A5 RID: 421
		public float fMoveTime;

		// Token: 0x040001A6 RID: 422
		public float fStartTime;
	}
}
