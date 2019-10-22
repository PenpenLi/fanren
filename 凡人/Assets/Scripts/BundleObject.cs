using System;
using UnityEngine;

public class BundleObject : ScriptableObject
{
    public UnityEngine.Object content;

    public UnityEngine.Object GetContent()
	{
		return this.content;
	}
}
