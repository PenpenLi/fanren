using System;
using UnityEngine;

// Token: 0x020004AA RID: 1194
public class BindRoleInfo
{
	// Token: 0x04001BC7 RID: 7111
	public Role role;

	// Token: 0x04001BC8 RID: 7112
	public Role beBindedRole;

	// Token: 0x04001BC9 RID: 7113
	public Transform bindTrans;

	// Token: 0x04001BCA RID: 7114
	public BindRoleInfo.BRIType type;

	// Token: 0x020004AB RID: 1195
	public enum BRIType
	{
		// Token: 0x04001BCC RID: 7116
		Horse,
		// Token: 0x04001BCD RID: 7117
		Grasp
	}
}
