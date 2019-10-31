using System;
using System.Collections.Generic;


public class ModMutualPlayer : Module
{
    //private List<PlayerMutualObject> m_lstMutualObjects = new List<PlayerMutualObject>();

    public ModMutualPlayer(Role role) : base(role)
	{
		base.ModType = MODULE_TYPE.MT_PLAYERMUTUAL;
	}

	public new bool Enable
	{
		get
		{
			return this.m_bEnabled;
		}
		set
		{
			this.m_bEnabled = value;
		}
	}

	//public void AddMutualObject(PlayerMutualObject mutualObject)
	//{
	//	this.m_lstMutualObjects.Add(mutualObject);
	//}

	//public void RemoveMutualObject(PlayerMutualObject mutualObject)
	//{
	//	this.m_lstMutualObjects.Remove(mutualObject);
	//}

	//public void ClearMutualObject()
	//{
	//	this.m_lstMutualObjects.Clear();
	//}

	//// Token: 0x060021E5 RID: 8677 RVA: 0x000E8608 File Offset: 0x000E6808
	//public override void Process()
	//{
	//	base.Process();
	//	if (!this.m_bEnabled)
	//	{
	//		return;
	//	}
	//	if (SingletonMono<ButtonEventManager>.GetInstance().IsChecking())
	//	{
	//		return;
	//	}
	//	if (this.m_lstMutualObjects.Count == 0)
	//	{
	//		return;
	//	}
	//	PlayerMutualObject playerMutualObject = this.m_lstMutualObjects[0];
	//	float num = (this._role.GetTrans().position - playerMutualObject.transform.position).sqrMagnitude;
	//	for (int i = 1; i < this.m_lstMutualObjects.Count; i++)
	//	{
	//		float sqrMagnitude = (this._role.GetTrans().position - this.m_lstMutualObjects[i].transform.position).sqrMagnitude;
	//		if (sqrMagnitude < num)
	//		{
	//			playerMutualObject = this.m_lstMutualObjects[i];
	//			num = sqrMagnitude;
	//		}
	//	}
	//	playerMutualObject.StartChecking();
	//}
}
