using System;

// Token: 0x020002F7 RID: 759
public enum ScrModType
{
	// Token: 0x0400131A RID: 4890
	SMT_NpcTalk_1,
	// Token: 0x0400131B RID: 4891
	SMT_NpcTalk_2,
	// Token: 0x0400131C RID: 4892
	SMT_Trigger,
	// Token: 0x0400131D RID: 4893
	SMT_AccMisDlg,
	// Token: 0x0400131E RID: 4894
	SMT_AcceptMission,
	// Token: 0x0400131F RID: 4895
	SMT_CompleteMission,
	// Token: 0x04001320 RID: 4896
	SMT_MonsterDie,
	// Token: 0x04001321 RID: 4897
	SMT_GetItem,
	// Token: 0x04001322 RID: 4898
	SMT_LoseItem,
	// Token: 0x04001323 RID: 4899
	SMT_ComMisDlg,
	// Token: 0x04001324 RID: 4900
	SMT_ShowString,
	// Token: 0x04001325 RID: 4901
	SMT_SpawnMonster,
	// Token: 0x04001326 RID: 4902
	SMT_SpawnMonster_ByInfo,
	// Token: 0x04001327 RID: 4903
	SMT_CompleteMission_Role,
	// Token: 0x04001328 RID: 4904
	SMT_AcceptMission_Role,
	// Token: 0x04001329 RID: 4905
	SMT_RestoredHealth,
	// Token: 0x0400132A RID: 4906
	SMT_AddBuff,
	// Token: 0x0400132B RID: 4907
	SMT_EnableOperable,
	// Token: 0x0400132C RID: 4908
	SMT_SetInvincible,
	// Token: 0x0400132D RID: 4909
	SMT_SetUnInvincible,
	// Token: 0x0400132E RID: 4910
	SMT_SpawByAdminId,
	// Token: 0x0400132F RID: 4911
	SMT_EnableSpawnAdmin,
	// Token: 0x04001330 RID: 4912
	SMT_ComForkMisDlg,
	// Token: 0x04001331 RID: 4913
	SMT_PlayMoive,
	// Token: 0x04001332 RID: 4914
	SMT_EnableGameObject,
	// Token: 0x04001333 RID: 4915
	SMT_LearningSkill,
	// Token: 0x04001334 RID: 4916
	SMT_UpDateAttribute,
	// Token: 0x04001335 RID: 4917
	SMT_ExecScripts,
	// Token: 0x04001336 RID: 4918
	SMT_OpenShopService,
	// Token: 0x04001337 RID: 4919
	SMT_NpcTalk_3,
	// Token: 0x04001338 RID: 4920
	SMT_SM_AddKnownRole,
	// Token: 0x04001339 RID: 4921
	SMT_SwitchScene,
	// Token: 0x0400133A RID: 4922
	SMT_SaveGame,
	// Token: 0x0400133B RID: 4923
	SMT_ChapterUpdate,
	// Token: 0x0400133C RID: 4924
	SMT_UpdateProp,
	// Token: 0x0400133D RID: 4925
	SMT_ActionScript,
	// Token: 0x0400133E RID: 4926
	SMT_AchievementProgress,
	// Token: 0x0400133F RID: 4927
	SMT_UseSkill,
	// Token: 0x04001340 RID: 4928
	SMT_FAN_EXCUTE,
	// Token: 0x04001341 RID: 4929
	SMT_FAN_EXCUTEATPOS,
	// Token: 0x04001342 RID: 4930
	SMT_MT_FAN_KILL_HANDLE,
	// Token: 0x04001343 RID: 4931
	SMT_EX_STAGE_GATE,
	// Token: 0x04001344 RID: 4932
	SMT_SM_OpenEquipShopService,
	// Token: 0x04001345 RID: 4933
	SMT_POP_SCRIPT,
	// Token: 0x04001346 RID: 4934
	SMT_HelpEnable,
	// Token: 0x04001347 RID: 4935
	SMT_UpdateMapName,
	// Token: 0x04001348 RID: 4936
	SMT_OpenMultiverseSpacePlane,
	// Token: 0x04001349 RID: 4937
	SMT_EnterDrillSystem,
	// Token: 0x0400134A RID: 4938
	SMT_ChangeMFS,
	// Token: 0x0400134B RID: 4939
	SMT_CameraSet,
	// Token: 0x0400134C RID: 4940
	SMT_PlayFightCamera,
	// Token: 0x0400134D RID: 4941
	SMT_ExStage,
	// Token: 0x0400134E RID: 4942
	SMT_LearnFigureSkill,
	// Token: 0x0400134F RID: 4943
	SMT_ExMixtureSmelt,
	// Token: 0x04001350 RID: 4944
	SM_LoadGame,
	// Token: 0x04001351 RID: 4945
	SM_SystemPlane,
	// Token: 0x04001352 RID: 4946
	SMT_ShowMsgBox,
	// Token: 0x04001353 RID: 4947
	SMT_ShowSaveMsgBox,
	// Token: 0x04001354 RID: 4948
	SMT_SM_Timer,
	// Token: 0x04001355 RID: 4949
	SMT_ExitNpcDlg = 10001,
	// Token: 0x04001356 RID: 4950
	SMT_Culture = 59,
	// Token: 0x04001357 RID: 4951
	SMT_UpdateHp,
	// Token: 0x04001358 RID: 4952
	SMT_PlayerFootPrint,
	// Token: 0x04001359 RID: 4953
	SMT_RotateNPC,
	// Token: 0x0400135A RID: 4954
	SMT_PlayBGMusic,
	// Token: 0x0400135B RID: 4955
	SMT_RecoverMusic,
	// Token: 0x0400135C RID: 4956
	SMT_PlayThemeMusic,
	// Token: 0x0400135D RID: 4957
	SMT_SetLevel = 67,
	// Token: 0x0400135E RID: 4958
	SMT_CreatEffect,
	// Token: 0x0400135F RID: 4959
	SMT_DeleteRole,
	// Token: 0x04001360 RID: 4960
	SMT_DeleteEffect,
	// Token: 0x04001361 RID: 4961
	SMT_StopFanHandle,
	// Token: 0x04001362 RID: 4962
	SMOpenDialogText,
	// Token: 0x04001363 RID: 4963
	SMT_SwitchMouse
}
