using System;
using System.Collections.Generic;

/// <summary>
/// 玩家属性信息
/// </summary>
public class PlayerPropertyInfo
{
    public string strName = "韩立";

    public int nID = 1;

    public Dictionary<ATTRIBUTE_TYPE, float> dyPropertyKey = new Dictionary<ATTRIBUTE_TYPE, float>();

    public PlayerPropertyInfo()
	{
		this.InitPropertyKey();
	}

	public void InitPropertyKey()
	{
		if (this.dyPropertyKey == null)
		{
			this.dyPropertyKey = new Dictionary<ATTRIBUTE_TYPE, float>();
		}
		for (int i = 0; i < 1000; i++)
		{
			if (i == 1 || i == 3)
			{
				this.dyPropertyKey.Add((ATTRIBUTE_TYPE)i, 1000f);
			}
			else
			{
				this.dyPropertyKey.Add((ATTRIBUTE_TYPE)i, 0f);
			}
		}
	}

	public bool IsHaveKey(ATTRIBUTE_TYPE key)
	{
		return this.dyPropertyKey.ContainsKey(key);
	}

	public float GetProperty(ATTRIBUTE_TYPE key)
	{
		if (this.IsHaveKey(key))
		{
			return this.dyPropertyKey[key];
		}
		return 0f;
	}
}
