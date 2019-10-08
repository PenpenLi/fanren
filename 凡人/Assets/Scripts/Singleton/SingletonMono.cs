using System;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : Component
{
    protected static T instance;

    public static T GetInstance()
	{
		if (SingletonMono<T>.instance == null)
		{
			GameObject gameObject = new GameObject("Manager");
			SingletonMono<T>.instance = gameObject.AddComponent<T>();
			gameObject.name = SingletonMono<T>.instance.ToString();
		}
		return SingletonMono<T>.instance;
	}
}
