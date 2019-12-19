using System;
using System.Collections.Generic;
using UnityEngine;

public class CSkillManager : MonoBehaviour
{
	//// Token: 0x06002599 RID: 9625 RVA: 0x00101138 File Offset: 0x000FF338
	//private void Awake()
	//{
	//	this.m_lstSkill.Clear();
	//}

	//// Token: 0x0600259A RID: 9626 RVA: 0x00101148 File Offset: 0x000FF348
	//private void OnGUI()
	//{
	//}

	//// Token: 0x0600259B RID: 9627 RVA: 0x0010114C File Offset: 0x000FF34C
	//private void Update()
	//{
	//	if (GameTime.IsPause)
	//	{
	//		return;
	//	}
	//	int i = 0;
	//	while (i < this.m_lstSkill.Count)
	//	{
	//		CSkillBase cskillBase = this.m_lstSkill[i];
	//		if (!cskillBase.Update())
	//		{
	//			cskillBase.Destory();
	//			this.m_lstSkill.RemoveAt(i);
	//		}
	//		else
	//		{
	//			i++;
	//		}
	//	}
	//}

	//// Token: 0x0600259C RID: 9628 RVA: 0x001011B0 File Offset: 0x000FF3B0
	//public CSkillBase CreateSkill(int skillId, Role sourceRole)
	//{
	//	return this.CreateSkill(skillId, sourceRole, null, Vector3.zero);
	//}

	//// Token: 0x0600259D RID: 9629 RVA: 0x001011C0 File Offset: 0x000FF3C0
	//public CSkillBase CreateSkill(int skillId, Role sourceRole, Role targetRole)
	//{
	//	return this.CreateSkill(skillId, sourceRole, targetRole, Vector3.zero);
	//}

	//// Token: 0x0600259E RID: 9630 RVA: 0x001011D0 File Offset: 0x000FF3D0
	//public CSkillBase CreateSkill(int skillId, Role sourceRole, Vector3 pos)
	//{
	//	return this.CreateSkill(skillId, sourceRole, null, pos);
	//}

	//// Token: 0x0600259F RID: 9631 RVA: 0x001011DC File Offset: 0x000FF3DC
	//public CSkillBase CreateSkill(int skillId, Role sourceRole, Role targetRole, Vector3 TargetPos)
	//{
	//	CSkillBase skill = Singleton<CSkillStaticManager>.GetInstance().GetSkill(skillId);
	//	ModOrganization modOrganization = null;
	//	ModOrganization modOrganization2 = null;
	//	if (sourceRole != null)
	//	{
	//		modOrganization = (ModOrganization)sourceRole.GetModule(MODULE_TYPE.MT_ORGANIZATION);
	//	}
	//	if (targetRole != null)
	//	{
	//		modOrganization2 = (ModOrganization)targetRole.GetModule(MODULE_TYPE.MT_ORGANIZATION);
	//	}
	//	switch (skill.TargetType)
	//	{
	//	case 1:
	//		if (sourceRole == null)
	//		{
	//			Debug.LogWarning("The Skill Target Type is Wrong.");
	//			return null;
	//		}
	//		break;
	//	case 2:
	//		if (modOrganization == null || modOrganization2 == null || !modOrganization.IsEnmity(modOrganization2))
	//		{
	//			Debug.LogWarning("The Skill Target Type is Wrong.");
	//		}
	//		break;
	//	case 3:
	//		if (TargetPos == Vector3.zero)
	//		{
	//			Debug.LogWarning("The Skill Target Type is Wrong.");
	//			return null;
	//		}
	//		break;
	//	case 4:
	//		if (modOrganization == null || modOrganization2 == null || modOrganization.IsEnmity(modOrganization2))
	//		{
	//			Debug.LogWarning("The Skill Target Type is Wrong.");
	//			return null;
	//		}
	//		break;
	//	}
	//	ModBuffProperty modBuffProperty = (ModBuffProperty)sourceRole.GetModule(MODULE_TYPE.MT_BUFF);
	//	ModAttribute modAttribute = (ModAttribute)sourceRole.GetModule(MODULE_TYPE.MT_ATTRIBUTE);
	//	if (modBuffProperty != null && modBuffProperty.GetValue(BUFF_VALUE_TYPE.NOT_MP) != 0)
	//	{
	//		if (modAttribute != null)
	//		{
	//			modAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_MP, 0f, false);
	//		}
	//	}
	//	else
	//	{
	//		float attributeValue = modAttribute.GetAttributeValue(ATTRIBUTE_TYPE.ATT_MP);
	//		if (attributeValue < skill.MpValue)
	//		{
	//			SM_HelpEnable.ExecHelp(1000827);
	//			return null;
	//		}
	//		modAttribute.UpdateAttributeNum(ATTRIBUTE_TYPE.ATT_MP, skill.MpValue * -1f, false);
	//	}
	//	skill.Init(sourceRole, targetRole, TargetPos);
	//	this.m_lstSkill.Add(skill);
	//	return skill;
	//}

	//// Token: 0x060025A0 RID: 9632 RVA: 0x00101374 File Offset: 0x000FF574
	//public bool DestorySkill(CSkillBase csb)
	//{
	//	if (csb == null)
	//	{
	//		return false;
	//	}
	//	if (csb.ID == 1000 || csb.ID == 1001)
	//	{
	//		return false;
	//	}
	//	foreach (CSkillBase cskillBase in this.m_lstSkill)
	//	{
	//		if (cskillBase == csb)
	//		{
	//			this.m_lstSkill.Remove(csb);
	//			csb.Destory();
	//			return true;
	//		}
	//	}
	//	return false;
	//}

	//// Token: 0x060025A1 RID: 9633 RVA: 0x00101424 File Offset: 0x000FF624
	//public void Clear()
	//{
	//	foreach (CSkillBase cskillBase in this.m_lstSkill)
	//	{
	//		cskillBase.Destory();
	//	}
	//	this.m_lstSkill.Clear();
	//}

	//// Token: 0x060025A2 RID: 9634 RVA: 0x00101494 File Offset: 0x000FF694
	//public bool IsOver(CSkillBase csb)
	//{
	//	foreach (CSkillBase cskillBase in this.m_lstSkill)
	//	{
	//		if (csb == cskillBase)
	//		{
	//			return false;
	//		}
	//	}
	//	return true;
	//}

	//// Token: 0x04002285 RID: 8837
	//public static CSkillManager Instance;

	//// Token: 0x04002286 RID: 8838
	//public List<CSkillBase> m_lstSkill = new List<CSkillBase>();
}
