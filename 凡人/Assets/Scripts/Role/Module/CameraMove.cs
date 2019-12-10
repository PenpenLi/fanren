using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000075 RID: 117
public class CameraMove : CameraBaseAction
{
	// Token: 0x06000270 RID: 624 RVA: 0x000267FC File Offset: 0x000249FC
	public void AddPos(Vector3 to, float movetime, float speedRate, bool imme)
	{
		if (base.IsPause)
		{
			return;
		}
		if (imme)
		{
			this.Reset();
		}
		if (this._Moves.Count > 0 && this._Moves[this._Moves.Count - 1].Pos == to)
		{
			return;
		}
		this._Moves.Add(new CameraMove.MoveInfo(to, movetime, speedRate, imme));
	}

	// Token: 0x06000271 RID: 625 RVA: 0x00003B84 File Offset: 0x00001D84
	public override void Reset()
	{
		this._Moves.Clear();
		this.offset = 0;
		this.fJoinTime = 0f;
		this.fJoinValue = 0f;
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00003BAE File Offset: 0x00001DAE
	public override bool Play()
	{
		this.offset = 0;
		this.fJoinTime = 0f;
		this.fJoinValue = 0f;
		return base.Play();
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00003B21 File Offset: 0x00001D21
	public override bool Stop()
	{
		base.Stop();
		return true;
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00003BD3 File Offset: 0x00001DD3
	public override void Release()
	{
		this.offset = 0;
		this.fJoinTime = 0f;
		this.fJoinValue = 0f;
		this._Moves.Clear();
		base.Release();
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00026874 File Offset: 0x00024A74
	public override bool Update()
	{
		base.Update();
		if (this._Moves.Count < 1)
		{
			return true;
		}
		CameraMove.MoveInfo moveInfo = this._Moves[this.offset];
		bool flag;
		if (moveInfo.IsImmed)
		{
			if (moveInfo.StartTime == 0f)
			{
				moveInfo.Run();
			}
			Vector3 vector = Vector3.zero;
			//if (BroadcastManager.Instance == null || BroadcastManager.Instance.GetPlayerCamera() == null || BroadcastManager.Instance.GetPlayerCamera().transform == null)
			//{
			//	return false;
			//}
			//vector = BroadcastManager.Instance.GetPlayerCamera().transform.position;
			//if (vector == moveInfo.Pos)
			//{
			//	flag = true;
			//}
			//else
			//{
			//	vector = Vector3.SmoothDamp(vector, moveInfo.Pos, ref this.currentVelocity1, moveInfo.MoveTime * GameTime.deltaTime);
			//	flag = true;
			//}
			//BroadcastManager.Instance.GetPlayerCamera().transform.position = vector;
		}
		else
		{
			flag = true;
		}
		//if (flag)
		//{
		//	this.offset++;
		//	if (this.offset >= this._Moves.Count)
		//	{
		//		this.Reset();
		//	}
		//}
		return true;
	}

	// Token: 0x040001A7 RID: 423
	private int offset;

	// Token: 0x040001A8 RID: 424
	private float fJoinTime;

	// Token: 0x040001A9 RID: 425
	private float fJoinValue;

	// Token: 0x040001AA RID: 426
	private Vector3 currentVelocity;

	// Token: 0x040001AB RID: 427
	private List<CameraMove.MoveInfo> _Moves = new List<CameraMove.MoveInfo>();

	// Token: 0x040001AC RID: 428
	private Vector3 currentVelocity1 = Vector3.zero;

	// Token: 0x02000076 RID: 118
	public class MoveInfo
	{
		// Token: 0x06000276 RID: 630 RVA: 0x000269B4 File Offset: 0x00024BB4
		public MoveInfo(Vector3 to, float time, float speedRate, bool imme)
		{
			this.Normalize();
			this.Pos = to;
			this.MoveTime = time;
			this.ElapseTime = this.MoveTime;
			this.SpeedRate = speedRate;
			this.IsImmed = imme;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00003C03 File Offset: 0x00001E03
		public void Run()
		{
			this.StartTime = GameTime.time;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00026A08 File Offset: 0x00024C08
		public void Normalize()
		{
			this.Pos = Vector3.zero;
			this.MoveTime = 0f;
			this.SpeedRate = 0f;
			this.StartTime = 0f;
			this.ElapseTime = this.MoveTime;
			this.IsImmed = true;
		}

		// Token: 0x040001AD RID: 429
		public Vector3 Pos = Vector3.zero;

		// Token: 0x040001AE RID: 430
		public float MoveTime;

		// Token: 0x040001AF RID: 431
		public float SpeedRate;

		// Token: 0x040001B0 RID: 432
		public bool IsImmed = true;

		// Token: 0x040001B1 RID: 433
		public float StartTime;

		// Token: 0x040001B2 RID: 434
		public float ElapseTime;
	}
}
