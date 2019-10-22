using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace FantasyTools
{
	// Token: 0x02000268 RID: 616
	public class FantasyTimer
	{
		// Token: 0x0600104D RID: 4173 RVA: 0x0008C868 File Offset: 0x0008AA68
		public FantasyTimer()
		{
			FantasyTimer.Instance = this;
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600104E RID: 4174 RVA: 0x0008C8B0 File Offset: 0x0008AAB0
		// (set) Token: 0x0600104F RID: 4175 RVA: 0x0008C8B8 File Offset: 0x0008AAB8
		public float FantasyDeltaTime
		{
			get
			{
				return this._fantasyDeltaTime;
			}
			private set
			{
				this._fantasyDeltaTime = value;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06001050 RID: 4176 RVA: 0x0008C8C4 File Offset: 0x0008AAC4
		// (set) Token: 0x06001051 RID: 4177 RVA: 0x0008C8CC File Offset: 0x0008AACC
		public float FantasyDeltaRealTime
		{
			get
			{
				return this._fantasyRealDeltaTime;
			}
			private set
			{
				this._fantasyRealDeltaTime = value;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06001052 RID: 4178 RVA: 0x0008C8D8 File Offset: 0x0008AAD8
		// (set) Token: 0x06001053 RID: 4179 RVA: 0x0008C8E0 File Offset: 0x0008AAE0
		public float FantasyTime
		{
			get
			{
				return this._fantasyTime;
			}
			private set
			{
				this._fantasyTime = value;
			}
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x0008C8EC File Offset: 0x0008AAEC
		public void TimeReset()
		{
			this._fantasyDeltaTime = 0f;
			this._fantasyRealDeltaTime = 0f;
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x0008C904 File Offset: 0x0008AB04
		public void TimePause(bool bIsPause)
		{
			this._IsPause = bIsPause;
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x0008C910 File Offset: 0x0008AB10
		public int AddDelayFantasyTimeEvent(float fTime, object callclass, string callmethod)
		{
			return this.AddDelayTimeEvent(0, string.Empty, fTime, true, callclass, callmethod, null);
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x0008C930 File Offset: 0x0008AB30
		public int AddDelayFantasyTimeEventEx(float fTime, string key, object callclass, string callmethod)
		{
			return this.AddDelayTimeEvent(0, key, fTime, true, callclass, callmethod, null);
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x0008C94C File Offset: 0x0008AB4C
		public int AddDelayFantasyTimeEvent(float fTime, object callclass, string callmethod, params object[] paramList)
		{
			return this.AddDelayTimeEvent(0, string.Empty, fTime, true, callclass, callmethod, paramList);
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x0008C96C File Offset: 0x0008AB6C
		public int AddDelayFantasyTimeEventEx(float fTime, string key, object callclass, string callmethod, params object[] paramList)
		{
			return this.AddDelayTimeEvent(0, key, fTime, true, callclass, callmethod, paramList);
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x0008C988 File Offset: 0x0008AB88
		public int AddDelayTimeEvent(float fTime, object callclass, string callmethod)
		{
			return this.AddDelayTimeEvent(0, string.Empty, fTime, false, callclass, callmethod, null);
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x0008C9A8 File Offset: 0x0008ABA8
		public int AddDelayTimeEventEx(float fTime, string key, object callclass, string callmethod)
		{
			return this.AddDelayTimeEvent(0, key, fTime, false, callclass, callmethod, null);
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x0008C9C4 File Offset: 0x0008ABC4
		public int AddDelayTimeEvent(float fTime, object callclass, string callmethod, params object[] paramList)
		{
			return this.AddDelayTimeEvent(0, string.Empty, fTime, false, callclass, callmethod, paramList);
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x0008C9E4 File Offset: 0x0008ABE4
		public int AddDelayTimeEventEx(float fTime, string key, object callclass, string callmethod, params object[] paramList)
		{
			return this.AddDelayTimeEvent(0, key, fTime, false, callclass, callmethod, paramList);
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x0008CA00 File Offset: 0x0008AC00
		public int AddDelayTimeEvent(int priorityLevel, string key, float fTime, bool userealtime, object callclass, string callmethod, params object[] paramList)
		{
			TDelayTimeData tdelayTimeData = new TDelayTimeData(this._fantasyDeltaTime, fTime, callclass, callmethod);
			if (!string.IsNullOrEmpty(key))
			{
				tdelayTimeData._keyMark = key;
			}
			tdelayTimeData._priorityLevel = priorityLevel;
			tdelayTimeData._bUseRealTime = userealtime;
			if (paramList != null && paramList.Length > 0)
			{
				tdelayTimeData.ParamList.AddRange(paramList);
			}
			int count = this._delayQueue.Count;
			this._delayQueue.Add(tdelayTimeData);
			this._delayQueue.Sort();
			return count;
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x0008CA84 File Offset: 0x0008AC84
		public bool RemoveEvent(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return false;
			}
			this._IsLockProcess = true;
			this._runtimeRmv.Clear();
			for (int i = 0; i < this._delayQueue.Count; i++)
			{
				if (!string.IsNullOrEmpty(this._delayQueue[i]._keyMark) && this._delayQueue[i]._keyMark == key)
				{
					this._runtimeRmv.Add(i);
					this._delayQueue.RemoveAt(i);
				}
			}
			if (this._runtimeRmv.Count <= 0)
			{
				return false;
			}
			this._IsLockProcess = false;
			return true;
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0008CB38 File Offset: 0x0008AD38
		public bool IsEvent(string key)
		{
			for (int i = 0; i < this._delayQueue.Count; i++)
			{
				if (!string.IsNullOrEmpty(this._delayQueue[i]._keyMark) && this._delayQueue[i]._keyMark == key)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x0008CB9C File Offset: 0x0008AD9C
		public bool AddHeartbeatPacket(int id, float frequency, object callclass, string callmethod)
		{
			if (this._heartbeatPackets.ContainsKey(id))
			{
				return false;
			}
			THeartbeatPacket theartbeatPacket = new THeartbeatPacket();
			theartbeatPacket._PacketID = id;
			theartbeatPacket._frequency = frequency;
			theartbeatPacket._CallClass = callclass;
			theartbeatPacket._strCallMethodName = callmethod;
			theartbeatPacket._fPartTime = Time.realtimeSinceStartup;
			this._heartbeatPackets.Add(id, theartbeatPacket);
			return true;
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x0008CBF8 File Offset: 0x0008ADF8
		public void RemoveHeartbeatPacket(int id)
		{
			if (this._heartbeatPackets.ContainsKey(id))
			{
				this._IsLockProcess = true;
				this._heartbeatPackets.Remove(id);
				this._IsLockProcess = false;
			}
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0008CC34 File Offset: 0x0008AE34
		public void Update()
		{
			if (this._IsPause)
			{
				return;
			}
			if (this._IsLockProcess)
			{
				return;
			}
			this._fantasyDeltaTime += Time.deltaTime;
			this._fantasyTime = Time.time;
			if (GameTime.timeScale == 1f)
			{
				this._fantasyRealDeltaTime += Time.deltaTime;
			}
			if (this._delayTemp != null && this._delayTemp.Count > 0)
			{
				this._delayTemp.Clear();
			}
			for (int i = 0; i < this._delayQueue.Count; i++)
			{
				TDelayTimeData tdelayTimeData = this._delayQueue[i];
				float num = (!tdelayTimeData._bUseRealTime) ? this._fantasyDeltaTime : this._fantasyRealDeltaTime;
				if (num - tdelayTimeData._fStartTime >= tdelayTimeData._fDelayTime)
				{
					this.CallBackDelayTime(tdelayTimeData);
					if (this._delayTemp != null)
					{
						this._delayTemp.Add(i);
					}
				}
			}
			if (this._delayTemp != null && this._delayTemp.Count > 0)
			{
				for (int j = this._delayTemp.Count - 1; j >= 0; j--)
				{
					this._delayQueue.RemoveAt(this._delayTemp[j]);
				}
			}
			foreach (THeartbeatPacket theartbeatPacket in this._heartbeatPackets.Values)
			{
				float num2 = Time.realtimeSinceStartup - theartbeatPacket._fPartTime;
				if (num2 >= theartbeatPacket._frequency)
				{
					this.CallBackHeartbeatPacket(theartbeatPacket);
					theartbeatPacket._fPartTime = Time.realtimeSinceStartup;
				}
			}
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x0008CE14 File Offset: 0x0008B014
		private void CallBackDelayTime(TDelayTimeData data)
		{
			if (data == null || data.IsInvalid() || data._CallClass == null)
			{
				return;
			}
			try
			{
				MethodInfo method = data._CallClass.GetType().GetMethod(data._strCallMethodName);
				if (method != null)
				{
					if (data._paramList == null || data._paramList.Count <= 0)
					{
						method.Invoke(data._CallClass, null);
					}
					else
					{
						method.Invoke(data._CallClass, data._paramList.ToArray());
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.Break();
			}
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x0008CED4 File Offset: 0x0008B0D4
		private void CallBackHeartbeatPacket(THeartbeatPacket data)
		{
			if (data == null || data.IsInvalid() || data._CallClass == null)
			{
				return;
			}
			try
			{
				MethodInfo method = data._CallClass.GetType().GetMethod(data._strCallMethodName);
				if (method != null)
				{
					method.Invoke(data._CallClass, null);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.Break();
			}
		}

		// Token: 0x04001179 RID: 4473
		public static FantasyTimer Instance;

		// Token: 0x0400117A RID: 4474
		private float _fantasyDeltaTime;

		// Token: 0x0400117B RID: 4475
		private float _fantasyRealDeltaTime;

		// Token: 0x0400117C RID: 4476
		private float _fantasyTime;

		// Token: 0x0400117D RID: 4477
		private bool _IsPause;

		// Token: 0x0400117E RID: 4478
		private bool _IsLockProcess;

		// Token: 0x0400117F RID: 4479
		private List<TDelayTimeData> _delayQueue = new List<TDelayTimeData>();

		// Token: 0x04001180 RID: 4480
		private List<int> _delayTemp = new List<int>();

		// Token: 0x04001181 RID: 4481
		private List<int> _runtimeRmv = new List<int>();

		// Token: 0x04001182 RID: 4482
		private Dictionary<int, THeartbeatPacket> _heartbeatPackets = new Dictionary<int, THeartbeatPacket>();
	}
}
