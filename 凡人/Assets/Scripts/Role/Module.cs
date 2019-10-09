using System;
using UnityEngine;

// Token: 0x0200051C RID: 1308
public class Module
{
	// Token: 0x060021FD RID: 8701 RVA: 0x000E8CC8 File Offset: 0x000E6EC8
	public Module()
	{
	}

	// Token: 0x060021FE RID: 8702 RVA: 0x000E8CD8 File Offset: 0x000E6ED8
	public Module(Role role)
	{
		this._role = role;
	}

	// Token: 0x17000409 RID: 1033
	// (get) Token: 0x060021FF RID: 8703 RVA: 0x000E8CF0 File Offset: 0x000E6EF0
	// (set) Token: 0x06002200 RID: 8704 RVA: 0x000E8CF8 File Offset: 0x000E6EF8
	public bool Enable
	{
		get
		{
			return this.m_bEnabled;
		}
		set
		{
			this.m_bEnabled = true;
		}
	}

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x06002202 RID: 8706 RVA: 0x000E8D10 File Offset: 0x000E6F10
	// (set) Token: 0x06002201 RID: 8705 RVA: 0x000E8D04 File Offset: 0x000E6F04
	public MODULE_TYPE ModType
	{
		get
		{
			return this._modType;
		}
		set
		{
			this._modType = value;
		}
	}

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x06002203 RID: 8707 RVA: 0x000E8D18 File Offset: 0x000E6F18
	public Role Role
	{
		get
		{
			return this._role;
		}
	}

	// Token: 0x06002204 RID: 8708 RVA: 0x000E8D20 File Offset: 0x000E6F20
	public virtual bool Remove()
	{
		return true;
	}

	// Token: 0x06002205 RID: 8709 RVA: 0x000E8D24 File Offset: 0x000E6F24
	public virtual bool Check(GameObject go)
	{
		return true;
	}

	// Token: 0x06002206 RID: 8710 RVA: 0x000E8D28 File Offset: 0x000E6F28
	public virtual bool Init()
	{
		return true;
	}

	// Token: 0x06002207 RID: 8711 RVA: 0x000E8D2C File Offset: 0x000E6F2C
	public virtual void Process()
	{
	}

	// Token: 0x06002208 RID: 8712 RVA: 0x000E8D30 File Offset: 0x000E6F30
	public virtual void Render()
	{
	}

	// Token: 0x06002209 RID: 8713 RVA: 0x000E8D34 File Offset: 0x000E6F34
	public virtual void Reset()
	{
	}

	// Token: 0x04001F13 RID: 7955
	private MODULE_TYPE _modType;

	// Token: 0x04001F14 RID: 7956
	protected Role _role;

	// Token: 0x04001F15 RID: 7957
	protected bool m_bEnabled = true;
}
