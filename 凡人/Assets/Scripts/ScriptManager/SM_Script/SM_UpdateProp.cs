using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 添加道具
/// </summary>
public class SM_UpdateProp
{
    public static ulong m_keyA;

    public static ulong m_keyB;

    private string m_keyAPath;

    private string m_keyBPath;

    private bool m_bCount;

    public static bool m_bColorForA;

    public static bool m_bColorForB;

    public void Exec(int type, ulong itemstaticid)
	{
        Debug.Log(type);
		//if (type == 2 && !Singleton<EZGUIManager>.GetInstance().GetGUI<MixtureSmeltPlane>()._pObject.active)
		//{
		//	//ulong e = Player.Instance.m_RoleGrowDatas.E;
		//	//ulong r = Player.Instance.m_RoleGrowDatas.R;
		//	//if (e == itemstaticid || r == itemstaticid)
		//	//{
		//	//	List<CItemBase> list = new List<CItemBase>();
		//	//	Dictionary<ulong, CItemBase> dictionary = new Dictionary<ulong, CItemBase>();
		//	//	if (GameData.Instance.ItemMan.TryGetItemsByID(itemstaticid, out dictionary))
		//	//	{
		//	//		if (dictionary == null || dictionary.Count <= 0)
		//	//		{
		//	//			return;
		//	//		}
		//	//		foreach (CItemBase item in dictionary.Values)
		//	//		{
		//	//			list.Add(item);
		//	//		}
		//	//		CItemBase citemBase = list[0];
		//	//		ItemCfgType itemCfgTpyeByID = GameData.Instance.ItemStaticMan.GetItemCfgTpyeByID(type);
		//	//		List<ATTRIBUTE_TYPE> list2 = new List<ATTRIBUTE_TYPE>(citemBase.DynamicData.ITEM_ATTRIBUTES_MAP.Keys);
		//	//		List<ITEM_ADD_ATTRIBUTE> list3 = new List<ITEM_ADD_ATTRIBUTE>(citemBase.DynamicData.ITEM_ADDATTRIBUTES_MAP.Keys);
		//	//		Player player = (Player)SceneManager.RoleMan.GetRole(Player.currentPlayerId);
		//	//		if (player == null)
		//	//		{
		//	//			return;
		//	//		}
		//	//		if (player.m_cModAttribute == null)
		//	//		{
		//	//			return;
		//	//		}
		//	//		float attributeValue = player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MAXMP);
		//	//		float attributeValue2 = player.m_cModAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MP);
		//	//		float num = (float)player.GetMaxHp();
		//	//		float num2 = (float)player.GetCurHp();
		//	//		this.m_bCount = false;
		//	//		if (list2 != null && PropsPlane.m_bType)
		//	//		{
		//	//			for (int i = 0; i < list2.Count; i++)
		//	//			{
		//	//				ATTRIBUTE_TYPE attribute_TYPE = list2[i];
		//	//				ATTRIBUTE_TYPE attribute_TYPE2 = ATTRIBUTE_TYPE.ATT_MP;
		//	//				ATTRIBUTE_TYPE attribute_TYPE3 = ATTRIBUTE_TYPE.ATT_HP;
		//	//				if (attribute_TYPE != attribute_TYPE2 && attribute_TYPE != attribute_TYPE3)
		//	//				{
		//	//					player.m_cModAttribute.UpdateAttributeNum(attribute_TYPE, citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE], false);
		//	//					string text = (citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE] <= 0f) ? " 减少" : " 增加";
		//	//					string strText = string.Concat(new object[]
		//	//					{
		//	//						"属性更新 : ",
		//	//						ModAttribute.GetAttributeName(attribute_TYPE),
		//	//						text,
		//	//						" : ",
		//	//						citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE]
		//	//					});
		//	//					GameData.Instance.RadioCenter.PushRadioQueue(strText, Color.green);
		//	//					GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
		//	//					if (!this.m_bCount)
		//	//					{
		//	//						list.RemoveAt(0);
		//	//						this.m_bCount = true;
		//	//					}
		//	//				}
		//	//				else if (attributeValue2 < attributeValue || num2 < num)
		//	//				{
		//	//					player.m_cModAttribute.UpdateAttributeNum(attribute_TYPE, citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE], false);
		//	//					string text2 = (citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE] <= 0f) ? " 减少" : " 增加";
		//	//					string strText2 = string.Concat(new object[]
		//	//					{
		//	//						"属性更新 : ",
		//	//						ModAttribute.GetAttributeName(attribute_TYPE),
		//	//						text2,
		//	//						" : ",
		//	//						citemBase.DynamicData.ITEM_ATTRIBUTES_MAP[attribute_TYPE]
		//	//					});
		//	//					GameData.Instance.RadioCenter.PushRadioQueue(strText2, Color.green);
		//	//					GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
		//	//					if (!this.m_bCount)
		//	//					{
		//	//						list.RemoveAt(0);
		//	//						this.m_bCount = true;
		//	//					}
		//	//				}
		//	//			}
		//	//		}
		//	//		if (list3 != null)
		//	//		{
		//	//			for (int j = 0; j < list3.Count; j++)
		//	//			{
		//	//				ITEM_ADD_ATTRIBUTE item_ADD_ATTRIBUTE = list3[j];
		//	//				player.m_cModAttribute.UpdateItemAddAttribute(item_ADD_ATTRIBUTE, citemBase.DynamicData.ITEM_ADDATTRIBUTES_MAP[item_ADD_ATTRIBUTE]);
		//	//				GameData.Instance.ItemMan.RemoveItemByID(citemBase.ID);
		//	//				if (!this.m_bCount)
		//	//				{
		//	//					list.RemoveAt(0);
		//	//					this.m_bCount = true;
		//	//				}
		//	//			}
		//	//		}
		//	//		if (e == itemstaticid)
		//	//		{
		//	//			this.m_keyAPath = citemBase.SmallIco;
		//	//			SkillUIManager.m_AValue.Text = list.Count.ToString();
		//	//			if (SM_UpdateProp.m_bColorForA)
		//	//			{
		//	//				SkillUIManager.instance.SetOneItemTexture(0, this.m_keyAPath, false, TYPE.ITEM_TYPE);
		//	//				SM_UpdateProp.m_bColorForA = false;
		//	//			}
		//	//		}
		//	//		else if (r == itemstaticid)
		//	//		{
		//	//			this.m_keyBPath = citemBase.SmallIco;
		//	//			SkillUIManager.m_BValue.Text = list.Count.ToString();
		//	//			if (SM_UpdateProp.m_bColorForB)
		//	//			{
		//	//				SkillUIManager.instance.SetOneItemTexture(1, this.m_keyBPath, false, TYPE.ITEM_TYPE);
		//	//				SM_UpdateProp.m_bColorForB = false;
		//	//			}
		//	//		}
		//	//		if (list.Count <= 0)
		//	//		{
		//	//			if (itemstaticid == e && SkillUIManager.instance != null)
		//	//			{
		//	//				PropsPlane.m_AValue.Text = "0";
		//	//				SkillUIManager.m_AValue.Text = "0";
		//	//				SkillUIManager.instance.SetOneItemTexture(0, this.m_keyAPath, true, TYPE.ITEM_TYPE);
		//	//				SM_UpdateProp.m_bColorForA = true;
		//	//				Color color = SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/item1").GetComponent<MeshRenderer>().material.color;
		//	//				PropsPlane.m_proA = color;
		//	//			}
		//	//			if (itemstaticid == r && SkillUIManager.instance != null)
		//	//			{
		//	//				PropsPlane.m_BValue.Text = "0";
		//	//				SkillUIManager.m_BValue.Text = "0";
		//	//				SkillUIManager.instance.SetOneItemTexture(1, this.m_keyBPath, true, TYPE.ITEM_TYPE);
		//	//				SM_UpdateProp.m_bColorForB = true;
		//	//				Color color2 = SkillUIManager.uiObject.transform.FindChild("Top/Skill&Item/Skill&ItemImage/item2").GetComponent<MeshRenderer>().material.color;
		//	//				PropsPlane.m_proB = color2;
		//	//			}
		//	//		}
		//	//	}
		//	//	SkillUIManager.m_AValue.Text = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.E);
		//	//	SkillUIManager.m_BValue.Text = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.R);
		//	//	PropsPlane.m_AValue.Text = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.E);
		//	//	PropsPlane.m_BValue.Text = GameData.Instance.ItemMan.GetItemCount(Player.Instance.m_RoleGrowDatas.R);
		//	//}
		//}
	}
}
