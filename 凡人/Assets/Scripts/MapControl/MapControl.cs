using System;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    public MapManagerEx MapManEx = new MapManagerEx();

    public int MapID = 1007;

    public static bool LoadAsync;

    public static LoadMachine loadMachine;

    private void Awake()
	{
		if (MapControl.LoadAsync && ResourcePath.IS_PUBLISH)
		{
			LoadMachine.isLoadCompleted = false;
			MapControl.loadMachine = base.gameObject.AddComponent<LoadMachine>();
		}
		this.MapManEx.LoadMapInfo(false);
	}

	private void Start()
	{
		this.MapManEx.CreateMap(this.MapID);
	}
}
