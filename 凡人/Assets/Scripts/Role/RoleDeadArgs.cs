using System;

// Token: 0x02000051 RID: 81
public class RoleDeadArgs : EventArgs
{
	// Token: 0x0600019A RID: 410 RVA: 0x000077C4 File Offset: 0x000059C4
	public RoleDeadArgs(Role role)
	{
		this.DeadRole = role;
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x0600019B RID: 411 RVA: 0x000077D4 File Offset: 0x000059D4
	// (set) Token: 0x0600019C RID: 412 RVA: 0x000077DC File Offset: 0x000059DC
	public Role DeadRole { get; private set; }
}
