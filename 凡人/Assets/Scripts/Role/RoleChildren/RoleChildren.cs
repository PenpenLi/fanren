using System;
using System.Collections;
using UnityEngine;


public class RoleChildren
{
    private Hashtable _typeGoTable = new Hashtable();

    private Hashtable stringGoTable = new Hashtable();

    public void ClearTable()
	{
		this._typeGoTable.Clear();
		this.stringGoTable.Clear();
	}

	public void SetRoleChild(RoleChildType rct, GameObject go)
	{
		this._typeGoTable[rct] = go;
	}

	public void SetRolcChild(string rctName, GameObject go)
	{
		this.stringGoTable[rctName] = go;
	}

	public void RemoveRoleChild(RoleChildType rct)
	{
		if (this._typeGoTable.Contains(rct))
		{
			this._typeGoTable.Remove(rct);
		}
	}

	public void RemoveRoleChild(string rctName)
	{
		if (this.stringGoTable.Contains(rctName))
		{
			this.stringGoTable.Remove(rctName);
		}
	}

	public GameObject GetGoByType(RoleChildType rct)
	{
		if (!this._typeGoTable.Contains(rct))
		{
			if (rct != RoleChildType.RCT_NONE)
			{
				Debug.Log(rct.ToString() + " is missing!");
			}
			return null;
		}
		return (GameObject)this._typeGoTable[rct];
	}

	public GameObject GetGoByName(string rctName)
	{
		if (this.stringGoTable.Contains(rctName))
		{
			return (GameObject)this.stringGoTable[rctName];
		}
		return null;
	}

	public Transform GetTransByName(string rctName)
	{
		GameObject goByName = this.GetGoByName(rctName);
		if (goByName != null)
		{
			return goByName.transform;
		}
		return null;
	}

	public GameObject GetGoByType(short index)
	{
		switch (index)
		{
		case 0:
			return null;
		case 1:
			return (GameObject)this._typeGoTable[RoleChildType.RCT_BONE_CHEST];
		case 2:
			return (GameObject)this._typeGoTable[RoleChildType.RCT_BONE_LEFT_HAND];
		case 3:
			return (GameObject)this._typeGoTable[RoleChildType.RCT_BONE_RIGHT_HAND];
		case 4:
			return (GameObject)this._typeGoTable[RoleChildType.RCT_BONE_HEAD];
		case 5:
			return (GameObject)this._typeGoTable[RoleChildType.RCT_BONE_TONGUE];
		case 6:
			return (GameObject)this._typeGoTable[RoleChildType.RCT_BONE_FOOT];
		default:
			return null;
		}
	}

	public Transform GetTransformByType(RoleChildType rct)
	{
		if (!this._typeGoTable.Contains(rct))
		{
			if (rct != RoleChildType.RCT_NONE)
			{
                Debug.Log(rct.ToString() + " is missing!");
			}
			return null;
		}
		GameObject gameObject = (GameObject)this._typeGoTable[rct];
		if (gameObject != null)
		{
			return gameObject.transform;
		}
        Debug.Log(rct.ToString() + "'s GameObject is null!");
		return null;
	}

	public void PrintTable()
	{
		foreach (object obj in this._typeGoTable)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
            Debug.Log("RoleChildren:" + dictionaryEntry.Key.ToString() + "," + ((GameObject)dictionaryEntry.Value).name);
		}
		foreach (object obj2 in this.stringGoTable)
		{
			DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
            Debug.Log("RoleChildren:" + dictionaryEntry2.Key.ToString() + "," + ((GameObject)dictionaryEntry2.Value).name);
		}
	}
}
