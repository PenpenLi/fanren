using System;

public class Singleton<T>
{
    protected static T m_cInstance;

    public static T GetInstance()
	{
		if (Singleton<T>.m_cInstance == null)
		{
			Singleton<T>.m_cInstance = Activator.CreateInstance<T>();
		}
		return Singleton<T>.m_cInstance;
	}

	public static void RemoveInstance()
	{
		Singleton<T>.m_cInstance = default(T);
	}
}
