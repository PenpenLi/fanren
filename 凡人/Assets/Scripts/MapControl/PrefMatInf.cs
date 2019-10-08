using System;


public class PrefMatInf
{
    private int _id;

    private string _renderGoPath;

    private string _renderIdx;

    private int _matIdx;

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

	public string RenderGoPath
	{
		get
		{
			return this._renderGoPath;
		}
		set
		{
			this._renderGoPath = value;
		}
	}

	public string RenderIdx
	{
		get
		{
			return this._renderIdx;
		}
		set
		{
			this._renderIdx = value;
		}
	}

	public int MatIdx
	{
		get
		{
			return this._matIdx;
		}
		set
		{
			this._matIdx = value;
		}
	}
}
