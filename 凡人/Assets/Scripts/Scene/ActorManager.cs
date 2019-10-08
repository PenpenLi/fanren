using System;
using System.Collections.Generic;
using UnityEngine;


public class ActorManager : Singleton<ActorManager>
{

	public GameObject MainCamera
	{
		get
		{
			if (this.m_cMainCamera != null)
			{
				Transform parent = this.m_cMainCamera.transform.parent;
				if (parent != null)
				{
					return parent.gameObject;
				}
			}
			return null;
		}
		set
		{
			this.m_cMainCamera = value;
		}
	}

	// Token: 0x06001572 RID: 5490 RVA: 0x000AAB64 File Offset: 0x000A8D64
	public void Clear()
	{
		this.MapActorsClear();
		this.HidenClear();
		this.m_mapActors.Clear();
		this.m_lstHiden.Clear();
		this.m_iObjectIndex = 1;
	}

	// Token: 0x06001573 RID: 5491 RVA: 0x000AAB9C File Offset: 0x000A8D9C
	public void MapActorsClear()
	{
		foreach (KeyValuePair<int, GameObject> keyValuePair in this.m_mapActors)
		{
			if (keyValuePair.Value != null)
			{
				UnityEngine.Object.Destroy(keyValuePair.Value);
			}
		}
	}

	// Token: 0x06001574 RID: 5492 RVA: 0x000AAC1C File Offset: 0x000A8E1C
	public void HidenClear()
	{
		foreach (ActorManager.MovieMemoryInfo movieMemoryInfo in this.m_lstHiden)
		{
			if (movieMemoryInfo.m_cGo != null)
			{
				UnityEngine.Object.Destroy(movieMemoryInfo.m_cGo);
			}
		}
	}

	// Token: 0x06001575 RID: 5493 RVA: 0x000AAC98 File Offset: 0x000A8E98
	public int Add(GameObject go)
	{
		if (this.m_mapActors.ContainsKey(this.m_iObjectIndex))
		{
			Debug.LogError("Error: The ID is Exit!");
			return 0;
		}
		this.m_mapActors.Add(this.m_iObjectIndex, go);
		return this.m_iObjectIndex++;
	}

	// Token: 0x06001576 RID: 5494 RVA: 0x000AACEC File Offset: 0x000A8EEC
	public bool Del(int key)
	{
		if (!this.m_mapActors.ContainsKey(key))
		{
			return false;
		}
		UnityEngine.Object.Destroy(this.m_mapActors[key]);
		this.m_mapActors.Remove(key);
		return true;
	}

	// Token: 0x06001577 RID: 5495 RVA: 0x000AAD2C File Offset: 0x000A8F2C
	public bool Del(GameObject obj)
	{
		using (Dictionary<int, GameObject>.Enumerator enumerator = this.m_mapActors.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, GameObject> keyValuePair = enumerator.Current;
				UnityEngine.Object.Destroy(keyValuePair.Value);
				this.m_mapActors.Remove(keyValuePair.Key);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001578 RID: 5496 RVA: 0x000AADB4 File Offset: 0x000A8FB4
	public Dictionary<int, GameObject> GetAllObjects()
	{
		return this.m_mapActors;
	}

	// Token: 0x06001579 RID: 5497 RVA: 0x000AADBC File Offset: 0x000A8FBC
	public GameObject GetObject(int key)
	{
		if (this.m_mapActors.ContainsKey(key) && this.m_mapActors[key].active)
		{
			return this.m_mapActors[key];
		}
		Debug.Log("The key " + key.ToString() + " has no gameobjct.Or the gameobject is not active.");
		return null;
	}

	// Token: 0x0600157A RID: 5498 RVA: 0x000AAE1C File Offset: 0x000A901C
	public void HideAllActiveGO()
	{
		foreach (KeyValuePair<int, GameObject> keyValuePair in this.m_mapActors)
		{
			if (!(keyValuePair.Value == null))
			{
				if (keyValuePair.Value.active)
				{
					Debug.Log(keyValuePair.Key.ToString() + "key hide already");
					this.HideGO(keyValuePair.Key);
				}
			}
		}
		if (this.MainCamera != null)
		{
			Camera component = this.MainCamera.GetComponent<Camera>();
			if (component)
			{
				component.depth = -10f;
			}
			AudioListener component2 = this.MainCamera.GetComponent<AudioListener>();
			if (component2)
			{
				component2.enabled = false;
			}
		}
	}

	// Token: 0x0600157B RID: 5499 RVA: 0x000AAF20 File Offset: 0x000A9120
	public void ShowBack()
	{
		foreach (ActorManager.MovieMemoryInfo movieMemoryInfo in this.m_lstHiden)
		{
			if (movieMemoryInfo.m_cGo != null)
			{
				movieMemoryInfo.m_cGo.SetActive(true);
			}
		}
		if (this.MainCamera != null)
		{
			Camera component = this.MainCamera.GetComponent<Camera>();
			if (component)
			{
				component.depth = 0f;
			}
			AudioListener component2 = this.MainCamera.GetComponent<AudioListener>();
			if (component2)
			{
				component2.enabled = true;
			}
		}
		this.m_lstHiden.Clear();
	}

	// Token: 0x0600157C RID: 5500 RVA: 0x000AAFF8 File Offset: 0x000A91F8
	public void HideGO(int key)
	{
		if (!this.m_mapActors.ContainsKey(key))
		{
			Debug.LogError("Error:No GameObject for the ID " + key.ToString());
			return;
		}
		this.m_mapActors[key].SetActive(false);
		this.m_lstHiden.Add(new ActorManager.MovieMemoryInfo(key, this.m_mapActors[key]));
	}

	// Token: 0x0600157D RID: 5501 RVA: 0x000AB05C File Offset: 0x000A925C
	public bool IsKeyExist(int key)
	{
		return this.m_mapActors.ContainsKey(key);
	}

	// Token: 0x0400159D RID: 5533
	private Dictionary<int, GameObject> m_mapActors = new Dictionary<int, GameObject>();

	// Token: 0x0400159E RID: 5534
	private List<ActorManager.MovieMemoryInfo> m_lstHiden = new List<ActorManager.MovieMemoryInfo>();

	// Token: 0x0400159F RID: 5535
	private int m_iObjectIndex = 1;

	// Token: 0x040015A0 RID: 5536
	private GameObject m_cMainCamera;

	// Token: 0x02000364 RID: 868
	private class MovieMemoryInfo
	{
		// Token: 0x0600157E RID: 5502 RVA: 0x000AB06C File Offset: 0x000A926C
		public MovieMemoryInfo(int id, GameObject go)
		{
			this.m_iId = id;
			this.m_cGo = go;
		}

		// Token: 0x040015A1 RID: 5537
		public int m_iId;

		// Token: 0x040015A2 RID: 5538
		public GameObject m_cGo;
	}
}
