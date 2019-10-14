using System;

public class LoadingRes
{
	public int resID;

	public string path;

	public RES_TYPE rt;

	public Callback<int, int, string> callback;

	public int value;

	public string strValue;
}
