using System;

public class BaseArtResInfo
{
    private int _id;

    private string _name;

    private string _path;

    private RES_TYPE _resType;

    public int ID
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

	public string Path
	{
		get
		{
			return this._path;
		}
		set
		{
			this._path = value;
		}
	}

	public RES_TYPE ResType
	{
		get
		{
			return this._resType;
		}
		set
		{
			this._resType = value;
		}
	}
}
