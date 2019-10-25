using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 组件状态管理
/// </summary>
public class ComponentStateControl
{
    private static ArrayList _StateTables = new ArrayList();

    private static ArrayList _Operates = new ArrayList();

    private static ArrayList _temp = new ArrayList();

    public static void AddStateControl(object compoent)
	{
		if (compoent == null || ComponentStateControl._StateTables.Contains(compoent))
		{
			return;
		}
		ComponentStateControl._StateTables.Add(compoent);
	}

	public static void RemoveStateControl(object compoent)
	{
		if (compoent == null || !ComponentStateControl._StateTables.Contains(compoent))
		{
			return;
		}
		ComponentStateControl._StateTables.Remove(compoent);
	}

	public static void PlayState()
	{
		if (GameTime.IsPause || ComponentStateControl._StateTables == null)
		{
			return;
		}
		ComponentStateControl._temp.Clear();
		foreach (object obj in ComponentStateControl._Operates)
		{
			if (obj == null)
			{
				ComponentStateControl._temp.Add(obj);
			}
			else if (obj.GetType() == typeof(AnimationState))
			{
				AnimationState animationState = obj as AnimationState;
				if (animationState == null)
				{
					ComponentStateControl._temp.Add(obj);
				}
				else if (animationState.enabled)
				{
					animationState.speed = 1f;
				}
			}
			else if (obj.GetType() == typeof(ParticleSystem))
			{
				ParticleSystem particleSystem = obj as ParticleSystem;
				if (particleSystem == null || particleSystem.gameObject == null)
				{
					ComponentStateControl._temp.Add(obj);
				}
				else
				{
					particleSystem.Play();
				}
			}
			//else if (obj.GetType() == typeof(ParticleEmitter))
			//{
			//	ParticleEmitter particleEmitter = obj as ParticleEmitter;
			//	if (particleEmitter == null || particleEmitter.gameObject == null)
			//	{
			//		ComponentStateControl._temp.Add(obj);
			//	}
			//	else if (particleEmitter.enabled)
			//	{
			//		particleEmitter.emit = true;
			//	}
			//}
			//else if (obj.GetType() == typeof(ParticleAnimator))
			//{
			//	ParticleAnimator particleAnimator = obj as ParticleAnimator;
			//	if (particleAnimator == null || particleAnimator.gameObject == null)
			//	{
			//		ComponentStateControl._temp.Add(obj);
			//	}
			//}
		}
		for (int i = 0; i < ComponentStateControl._temp.Count; i++)
		{
			ComponentStateControl._StateTables.Remove(ComponentStateControl._temp[i]);
		}
		ComponentStateControl._temp.Clear();
		ComponentStateControl._Operates.Clear();
	}

	public static void StopState()
	{
		if (!GameTime.IsPause)
		{
			return;
		}
		ComponentStateControl._temp.Clear();
		ComponentStateControl._Operates.Clear();
		foreach (object obj in ComponentStateControl._StateTables)
		{
			if (obj == null)
			{
				ComponentStateControl._temp.Add(obj);
			}
			else if (obj.GetType() == typeof(Animation))
			{
				Animation animation = obj as Animation;
				if (animation == null || animation.gameObject == null)
				{
					ComponentStateControl._temp.Add(obj);
				}
				else if (animation.enabled)
				{
					foreach (object obj2 in animation)
					{
						AnimationState animationState = (AnimationState)obj2;
						if (animation.IsPlaying(animationState.name))
						{
							ComponentStateControl._Operates.Add(animationState);
							animationState.speed = 0f;
						}
					}
				}
			}
			else if (obj.GetType() == typeof(ParticleSystem))
			{
				ParticleSystem particleSystem = obj as ParticleSystem;
				if (particleSystem == null || particleSystem.gameObject == null)
				{
					ComponentStateControl._temp.Add(obj);
				}
				else if (particleSystem.isPlaying)
				{
					ComponentStateControl._Operates.Add(obj);
					particleSystem.Pause();
				}
			}
			//else if (obj.GetType() == typeof(ParticleEmitter))
			//{
			//	ParticleEmitter particleEmitter = obj as ParticleEmitter;
			//	if (particleEmitter == null || particleEmitter.gameObject == null)
			//	{
			//		ComponentStateControl._temp.Add(obj);
			//	}
			//	else if (particleEmitter.enabled && particleEmitter.emit)
			//	{
			//		particleEmitter.emit = false;
			//	}
			//}
			//else if (obj.GetType() == typeof(ParticleAnimator))
			//{
			//	ParticleAnimator particleAnimator = obj as ParticleAnimator;
			//	if (particleAnimator == null || particleAnimator.gameObject == null)
			//	{
			//		ComponentStateControl._temp.Add(obj);
			//	}
			//}
		}
		for (int i = 0; i < ComponentStateControl._temp.Count; i++)
		{
			ComponentStateControl._StateTables.Remove(ComponentStateControl._temp[i]);
		}
		ComponentStateControl._temp.Clear();
	}

	//public static void CheckStateControl(GameObject go)
	//{
	//	if (go == null)
	//	{
	//		return;
	//	}
	//	if ((go.particleSystem != null || go.animation != null || go.particleEmitter != null || go.GetComponent<ParticleAnimator>() != null) && go.GetComponent<ComponentStateRegister>() == null)
	//	{
	//		go.AddComponent<ComponentStateRegister>();
	//	}
	//	if (go.transform.GetChildCount() > 0)
	//	{
	//		for (int i = 0; i < go.transform.GetChildCount(); i++)
	//		{
	//			GameObject gameObject = go.transform.GetChild(i).gameObject;
	//			ComponentStateControl.CheckStateControl(gameObject);
	//		}
	//	}
	//}
}
