using System;
using UnityEngine;

/// <summary>
/// 游戏时间
/// </summary>
public class GameTime
{
    private static float m_fStartTime;

    private static float m_fDeltaTime;

    private static float m_fScale;

    private static float m_fSaveTime;

    private static float m_fStartScaleTime;

    private static float m_fLastTimeScale = 1f;

    public static int frameCount = 1;

    public static void Init()
	{
		GameTime.m_fSaveTime = 0f;
		GameTime.m_fStartTime = Time.time;
		GameTime.m_fScale = 1f;
		GameTime.m_fStartScaleTime = Time.time;
	}

	public static float time
	{
		get
		{
			GameTime.m_fSaveTime += (Time.time - GameTime.m_fStartScaleTime) * (1f - GameTime.m_fScale);
			GameTime.m_fStartScaleTime = Time.time;
			return Time.time - GameTime.m_fStartTime - GameTime.m_fSaveTime;
		}
	}

	public static float deltaTime
	{
		get
		{
			return Time.deltaTime * GameTime.m_fScale;
		}
	}

	public static float timeScale
	{
		get
		{
			return GameTime.m_fScale;
		}
	}

	public static void PauseGame()
	{
		if (GameTime.m_fScale == 0f)
		{
			return;
		}
		GameTime.m_fSaveTime += (Time.time - GameTime.m_fStartScaleTime) * (1f - GameTime.m_fScale);
		GameTime.m_fStartScaleTime = Time.time;
		GameTime.m_fScale = 0f;
		GameTime.m_fLastTimeScale = Time.timeScale;
		Time.timeScale = 1f;
		ComponentStateControl.StopState();
	}

	public static void ReturnGame()
	{
		if (GameTime.m_fScale == 1f)
		{
			return;
		}
		GameTime.m_fSaveTime += (Time.time - GameTime.m_fStartScaleTime) * (1f - GameTime.m_fScale);
		GameTime.m_fStartScaleTime = Time.time;
		Time.timeScale = GameTime.m_fLastTimeScale;
		GameTime.m_fScale = 1f;
		ComponentStateControl.PlayState();
	}

	public static bool IsPause
	{
		get
		{
			return GameTime.m_fScale == 0f;
		}
	}

	public static void Stop()
	{
		GameTime.PauseGame();
	}

	public static void Start()
	{
		GameTime.ReturnGame();
	}
}
