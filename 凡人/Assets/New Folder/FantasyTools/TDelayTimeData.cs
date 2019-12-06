using System;
using System.Collections.Generic;

namespace FantasyTools
{
	// Token: 0x02000266 RID: 614
	public class TDelayTimeData : IComparable
	{
		// Token: 0x06001046 RID: 4166 RVA: 0x0008C740 File Offset: 0x0008A940
		public TDelayTimeData(float start, float delay, object classna, string metname)
		{
			this._fStartTime = start;
			this._fDelayTime = delay;
			this._CallClass = classna;
			this._strCallMethodName = metname;
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06001047 RID: 4167 RVA: 0x0008C77C File Offset: 0x0008A97C
		// (set) Token: 0x06001048 RID: 4168 RVA: 0x0008C79C File Offset: 0x0008A99C
		public List<object> ParamList
		{
			get
			{
				if (this._paramList == null)
				{
					this._paramList = new List<object>();
				}
				return this._paramList;
			}
			set
			{
				this._paramList = value;
			}
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x0008C7A8 File Offset: 0x0008A9A8
		public bool IsInvalid()
		{
			return this._CallClass == null || string.IsNullOrEmpty(this._strCallMethodName);
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x0008C7C4 File Offset: 0x0008A9C4
		public int CompareTo(object obj)
		{
			int result;
			try
			{
				if (obj == null)
				{
					result = -1;
				}
				else
				{
					TDelayTimeData tdelayTimeData = (TDelayTimeData)obj;
					result = this._priorityLevel.CompareTo(tdelayTimeData._priorityLevel);
				}
			}
			catch
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0400116C RID: 4460
		public int _priorityLevel;

		// Token: 0x0400116D RID: 4461
		public string _keyMark = string.Empty;

		// Token: 0x0400116E RID: 4462
		public float _fStartTime;

		// Token: 0x0400116F RID: 4463
		public float _fDelayTime;

		// Token: 0x04001170 RID: 4464
		public bool _bUseRealTime;

		// Token: 0x04001171 RID: 4465
		public object _CallClass;

		// Token: 0x04001172 RID: 4466
		public string _strCallMethodName = string.Empty;

		// Token: 0x04001173 RID: 4467
		public List<object> _paramList;
	}
}
