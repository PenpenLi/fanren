using System;
using UnityEngine;

/// <summary>
/// 模块基类
/// </summary>
public class Module
{
    private MODULE_TYPE _modType;

    protected Role _role;

    protected bool m_bEnabled = true;

    public Module()
	{
	}

	public Module(Role role)
	{
		this._role = role;
	}

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

	public Role Role
	{
		get
		{
			return this._role;
		}
	}

	public virtual bool Remove()
	{
		return true;
	}

	public virtual bool Check(GameObject go)
	{
		return true;
	}

	public virtual bool Init()
	{
		return true;
	}

	public virtual void Process()
	{
	}

	public virtual void Render()
	{
	}

	public virtual void Reset()
	{
	}
}
