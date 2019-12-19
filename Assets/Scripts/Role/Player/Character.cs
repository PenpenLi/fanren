using System;

/// <summary>
/// 角色
/// </summary>
public class Character
{
    private int _id;

    private string _name;

    private int _level;

    private int _HP;

    private int _MAXHP;

    private int _MP;

    private int _MAXMP;

    private int _FP;

    private int _MAXFP;

    private int _Exp;

    public int Id
	{
		get
		{
			return this._id;
		}
		set
		{
			this._id = value;
		}
	}

	public string Name
	{
		get
		{
			return this._name;
		}
		set
		{
			this._name = value;
		}
	}

	public int Level
	{
		get
		{
			return this._level;
		}
		set
		{
			this._level = value;
		}
	}

	public int HP
	{
		get
		{
			return this._HP;
		}
		set
		{
			this._HP = value;
		}
	}

	public int MAXHP
	{
		get
		{
			return this._MAXHP;
		}
		set
		{
			this._MAXHP = value;
		}
	}

	public int MP
	{
		get
		{
			return this._MP;
		}
		set
		{
			this._MP = value;
		}
	}

	public int MAXMP
	{
		get
		{
			return this._MAXMP;
		}
		set
		{
			this._MAXMP = value;
		}
	}

	public int FP
	{
		get
		{
			return this._FP;
		}
		set
		{
			this._FP = value;
		}
	}

	public int MAXFP
	{
		get
		{
			return this._MAXFP;
		}
		set
		{
			this._MAXFP = value;
		}
	}

	public int Exp
	{
		get
		{
			return this._Exp;
		}
		set
		{
			this._Exp = value;
		}
	}
}
