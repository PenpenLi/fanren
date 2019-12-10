using System;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : SingletonMono<StageManager>
{
	//// Token: 0x1700048F RID: 1167
	//// (get) Token: 0x0600313E RID: 12606 RVA: 0x0017DF84 File Offset: 0x0017C184
	//// (set) Token: 0x0600313F RID: 12607 RVA: 0x0017DF8C File Offset: 0x0017C18C
	//public List<StageState> StageStatic
	//{
	//	get
	//	{
	//		return this.m_StageStatic;
	//	}
	//	set
	//	{
	//		this.m_StageStatic = value;
	//	}
	//}

	//// Token: 0x17000490 RID: 1168
	//// (get) Token: 0x06003140 RID: 12608 RVA: 0x0017DF98 File Offset: 0x0017C198
	//// (set) Token: 0x06003141 RID: 12609 RVA: 0x0017DFA0 File Offset: 0x0017C1A0
	//public List<StageState> StageDynamic
	//{
	//	get
	//	{
	//		return this.m_StageDynamic;
	//	}
	//	set
	//	{
	//		this.m_StageDynamic = value;
	//	}
	//}

	//// Token: 0x06003142 RID: 12610 RVA: 0x0017DFAC File Offset: 0x0017C1AC
	//public bool IsLoading()
	//{
	//	return this.m_LoadingStage;
	//}

	//// Token: 0x06003143 RID: 12611 RVA: 0x0017DFB4 File Offset: 0x0017C1B4
	//public void Read()
	//{
	//	this.m_LoadingStage = true;
	//	List<StageState> list = new List<StageState>(this.m_StageStatic);
	//	foreach (StageState stageState in list)
	//	{
	//		stageState.Read();
	//	}
	//	this.m_LoadingStage = false;
	//}

	//// Token: 0x06003144 RID: 12612 RVA: 0x0017E030 File Offset: 0x0017C230
	//public bool RegistStage(StageState stage)
	//{
	//	if (stage.m_IsDynamic)
	//	{
	//		return this.RegistStageDynamic(stage);
	//	}
	//	return this.RegistStageStatic(stage);
	//}

	//// Token: 0x06003145 RID: 12613 RVA: 0x0017E04C File Offset: 0x0017C24C
	//public bool RegistStageStatic(StageState stage)
	//{
	//	if (stage == null)
	//	{
	//		Debug.LogWarning(DU.Warning(new object[]
	//		{
	//			stage
	//		}));
	//		return false;
	//	}
	//	StageState stageState = null;
	//	if (StageState.FindStage(this.m_StageStatic, stage.id, out stageState))
	//	{
	//		Debug.LogWarning(DU.Warning(new object[]
	//		{
	//			"Already have stage id",
	//			stage.gameObject,
	//			stage.id
	//		}));
	//		this.m_StageStaticConflict.Add(stage);
	//		return false;
	//	}
	//	this.m_StageStatic.Add(stage);
	//	return true;
	//}

	//// Token: 0x06003146 RID: 12614 RVA: 0x0017E0E0 File Offset: 0x0017C2E0
	//public bool RegistStageDynamic(StageState stage)
	//{
	//	if (stage == null)
	//	{
	//		Debug.LogWarning(DU.Warning(new object[]
	//		{
	//			stage
	//		}));
	//		return false;
	//	}
	//	if (this.m_StageDynamic.Contains(stage))
	//	{
	//		Debug.LogWarning(DU.Warning(new object[]
	//		{
	//			stage.gameObject.name,
	//			stage.id
	//		}));
	//		return false;
	//	}
	//	this.m_StageDynamic.Add(stage);
	//	return true;
	//}

	//// Token: 0x06003147 RID: 12615 RVA: 0x0017E15C File Offset: 0x0017C35C
	//public void ExStageStaticGate(int id, int state)
	//{
	//	StageState stageState = null;
	//	if (StageState.FindStage(this.m_StageStatic, id, out stageState))
	//	{
	//		stageState.Excute(new StageGateTriggerArgs(null, state));
	//	}
	//}

	//// Token: 0x040037C3 RID: 14275
	//private List<StageState> m_StageStatic = new List<StageState>();

	//// Token: 0x040037C4 RID: 14276
	//private List<StageState> m_StageStaticConflict = new List<StageState>();

	//// Token: 0x040037C5 RID: 14277
	//private List<StageState> m_StageDynamic = new List<StageState>();

	//// Token: 0x040037C6 RID: 14278
	//private bool m_LoadingStage;
}
