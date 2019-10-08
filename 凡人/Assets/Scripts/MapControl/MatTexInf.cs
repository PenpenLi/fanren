using System;

public class MatTexInf
{
    private int _id;

    private string _nameInShader;

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

	public string NameInShader
	{
		get
		{
			return this._nameInShader;
		}
		set
		{
			this._nameInShader = value;
		}
	}
}
