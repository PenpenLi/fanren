using System;

namespace FantasyTools
{
	// Token: 0x02000267 RID: 615
	public class THeartbeatPacket
	{
		// Token: 0x0600104C RID: 4172 RVA: 0x0008C84C File Offset: 0x0008AA4C
		public bool IsInvalid()
		{
			return this._CallClass == null || string.IsNullOrEmpty(this._strCallMethodName);
		}

		// Token: 0x04001174 RID: 4468
		public int _PacketID = -1000;

		// Token: 0x04001175 RID: 4469
		public float _fPartTime;

		// Token: 0x04001176 RID: 4470
		public float _frequency;

		// Token: 0x04001177 RID: 4471
		public object _CallClass;

		// Token: 0x04001178 RID: 4472
		public string _strCallMethodName = string.Empty;
	}
}
