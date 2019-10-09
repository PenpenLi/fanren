using System;
using System.Collections;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

/// <summary>
/// 用户数据
/// </summary>
public class UserData
{
    private ArrayList playerList = new ArrayList();

    public void initialize()
	{
		this.readPlayerList();
	}

	private void readPlayerList()
	{
		this.playerList.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets("PlayerInfo");
		foreach (string text in list)
		{
			if (text.Length != 0)
			{
				string[] array = text.Split(CacheData.separator);
				if (array.Length < 5)
				{
                    Debug.Log(
					
						"This line: \"" + text + "\" has some error format!"
					);
				}
				else
				{
					int num = 0;
					PlayerInfo playerInfo = new PlayerInfo();
					playerInfo.id = Convert.ToInt32(array[num]);
					num++;
					playerInfo.name = Convert.ToString(array[num]);
					num++;
					playerInfo.headPath = Convert.ToString(array[num]);
					num++;
					playerInfo.resourcePath = Convert.ToString(array[num]);
					num++;
					playerInfo.runSpeed = Convert.ToSingle(array[num]);
					num++;
					playerInfo.weaponId = Convert.ToInt32(array[num]);
					num++;
					if (!this.playerList.Contains(playerInfo))
					{
						this.playerList.Add(playerInfo);
					}
				}
			}
		}
	}

	public PlayerInfo getPlayerInfo(int playerId)
	{
		foreach (object obj in this.playerList)
		{
			PlayerInfo playerInfo = (PlayerInfo)obj;
			if (playerInfo.id == playerId)
			{
				return playerInfo;
			}
		}
		return null;
	}
}
