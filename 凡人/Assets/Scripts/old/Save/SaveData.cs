using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000185 RID: 389
[Serializable]
public class SaveData
{
	// Token: 0x060007AF RID: 1967 RVA: 0x0000744A File Offset: 0x0000564A
	public void PrintDate()
	{
		this.SaveDateBase.PrintDate();
		this.SaveDateGame.PrintDate();
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x00007462 File Offset: 0x00005662
	public void Reset()
	{
		this.SaveDateGame.Reset();
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x0003A4C8 File Offset: 0x000386C8
	public static SaveData GetSaveDate(SaveLoadManager.tagSL st)
	{
		return new SaveData
		{
			SaveDateBase = SaveData.SDBase.GetBaseDate(),
			SaveDateGame = SaveData.SDGame.GetGameDate(),
			SaveDateBitmap = SaveInfo.SaveScreen(),
			SaveDateInfo = SaveInfo.GetInfoDate(st)
		};
	}

	//public static void GetAttributeDate(List<ModAttribute.Attribute> attrList, Role role)
	//{
	//	ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
	//	if (modAttribute != null)
	//	{
	//		for (int i = 0; i < modAttribute.AttList.Count; i++)
	//		{
	//			ModAttribute.Attribute attribute = modAttribute.AttList[i];
	//			if (attribute == null)
	//			{
	//				Debug.LogWarning(DU.Warning(new object[]
	//				{
	//					"SaveData",
	//					"GetAttributeDate",
	//					"attr ==null"
	//				}));
	//			}
	//			else if (attribute.attType < ATTRIBUTE_TYPE.ATT_NUMERICAL_END)
	//			{
	//				ModAttribute.Att_Numerical item = new ModAttribute.Att_Numerical();
	//				item = (attribute as ModAttribute.Att_Numerical);
	//				attrList.Add(item);
	//			}
	//			else
	//			{
	//				ModAttribute.Att_StringIndex item2 = new ModAttribute.Att_StringIndex();
	//				item2 = (attribute as ModAttribute.Att_StringIndex);
	//				attrList.Add(item2);
	//			}
	//		}
	//	}
	//	else
	//	{
	//		Debug.LogWarning(DU.Warning(new object[]
	//		{
	//			"SaveData",
	//			"GetAttributeDate",
	//			"modAttr ==null"
	//		}));
	//	}
	//}

	// Token: 0x04000679 RID: 1657
	public SaveData.SDBase SaveDateBase = new SaveData.SDBase();

	// Token: 0x0400067A RID: 1658
	public SaveData.SDGame SaveDateGame = new SaveData.SDGame();

	// Token: 0x0400067B RID: 1659
	public List<byte> SaveDateBitmap = new List<byte>();

	// Token: 0x0400067C RID: 1660
	public SaveInfo SaveDateInfo = new SaveInfo();

	// Token: 0x0400067D RID: 1661
	public bool BeLoaded = true;

	// Token: 0x02000186 RID: 390
	[Serializable]
	public class SDSkill
	{
		//public static SaveData.SDSkill GetSkill(Player player)
		//{
		//	ModSkillProperty modSkillProperty = player.GetModule(MODULE_TYPE.MT_SKILL) as ModSkillProperty;
		//	if (modSkillProperty != null)
		//	{
		//		SaveData.SDSkill sdskill = new SaveData.SDSkill();
		//		for (int i = 0; i < modSkillProperty.M_cSkills.Length; i++)
		//		{
		//			if (modSkillProperty.M_cSkills[i] != null)
		//			{
		//				sdskill.m_cSkills[i] = new SSkillCoolTime(0, 0, 0f);
		//				modSkillProperty.M_cSkills[i].CopyTo(sdskill.m_cSkills[i]);
		//			}
		//			else
		//			{
		//				sdskill.m_cSkills[i] = null;
		//			}
		//		}
		//		return sdskill;
		//	}
		//	return null;
		//}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0000221B File Offset: 0x0000041B
		public void PrintDate()
		{
		}

		// Token: 0x0400067E RID: 1662
		//public SSkillCoolTime[] m_cSkills = new SSkillCoolTime[11];
	}

	// Token: 0x02000187 RID: 391
	[Serializable]
	public class SDMission
	{
		// Token: 0x060007B7 RID: 1975 RVA: 0x0003A680 File Offset: 0x00038880
		public static SaveData.SDMission GetMission(Player player)
		{
			//ModMission modMission = player.GetModule(MODULE_TYPE.MT_MISSION) as ModMission;
			//if (modMission == null)
			//{
			//	return null;
			//}
			SaveData.SDMission sdmission = new SaveData.SDMission();
			sdmission.Reset();
			//sdmission.misMask = modMission.MisMask;
			//for (int i = 0; i < modMission.misLinkList.Count; i++)
			//{
			//	sdmission.misLinkList.Add(modMission.misLinkList[i].Clone());
			//}
			//for (int j = 0; j < modMission.accMisList.Count; j++)
			//{
			//	sdmission.accMisList.Add(modMission.accMisList[j].Clone2SD());
			//}
			return sdmission;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x000074A2 File Offset: 0x000056A2
		public void Reset()
		{
			this.misMask = 0L;
			//this.misLinkList.Clear();
			//this.accMisList.Clear();
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0003A72C File Offset: 0x0003892C
		public void PrintDate()
		{
			//Logger.Log(new object[]
			//{
			//	"------------ Mission Data Start ---------------"
			//});
			//Logger.Log(new object[]
			//{
			//	"MisMask:" + this.misMask
			//});
			//for (int i = 0; i < this.misLinkList.Count; i++)
			//{
			//	//ModMission.MisLinkInfo misLinkInfo = this.misLinkList[i];
			//	//Logger.Log(new object[]
			//	//{
			//	//	string.Concat(new object[]
			//	//	{
			//	//		"LinkInfo  linkId:",
			//	//		misLinkInfo.linkId,
			//	//		",setp:",
			//	//		misLinkInfo.curStep
			//	//	})
			//	//});
			//}
			//for (int j = 0; j < this.accMisList.Count; j++)
			//{
			//	//ModMission.AccMisInfo_SD accMisInfo_SD = this.accMisList[j];
			//	Logger.Log(new object[]
			//	{
			//		string.Concat(new object[]
			//		{
			//			"AccInfo  linkId:",
			//			accMisInfo_SD.LinkId,
			//			",setp:",
			//			accMisInfo_SD.Step,
			//			",bComplete:",
			//			accMisInfo_SD.Complete
			//		})
			//	});
			//	for (int k = 0; k < accMisInfo_SD.AimList.Count; k++)
			//	{
			//		MissionInfo.MissionAimInfo missionAimInfo = accMisInfo_SD.AimList[k];
			//		Logger.Log(new object[]
			//		{
			//			string.Concat(new object[]
			//			{
			//				"AimInfo  AimType:",
			//				missionAimInfo.AimType,
			//				",AimDis:",
			//				missionAimInfo.AimDis,
			//				",AimData:",
			//				missionAimInfo.AimData,
			//				",Count:",
			//				missionAimInfo.Count
			//			})
			//		});
			//	}
			//}
			//Logger.Log(new object[]
			//{
			//	"------------ Mission Data End ----------------"
			//});
		}

		// Token: 0x0400067F RID: 1663
		public long misMask;

		// Token: 0x04000680 RID: 1664
		//public List<ModMission.MisLinkInfo> misLinkList = new List<ModMission.MisLinkInfo>();

		// Token: 0x04000681 RID: 1665
		//public List<ModMission.AccMisInfo_SD> accMisList = new List<ModMission.AccMisInfo_SD>();
	}

	// Token: 0x02000188 RID: 392
	[Serializable]
	public class SDFigure
	{
		// Token: 0x060007BB RID: 1979 RVA: 0x0003A914 File Offset: 0x00038B14
		public static SaveData.SDFigure GetFigure(Player role)
		{
			return new SaveData.SDFigure
			{
				//currentID = role.SystemFigure.SkillID,
				//currentEnergy = role.SystemFigure.Energy,
				//learnedID = role.SystemFigure.LearnedSkillID
			};
		}

		// Token: 0x04000682 RID: 1666
		public int currentID;

		// Token: 0x04000683 RID: 1667
		public List<int> learnedID = new List<int>();

		// Token: 0x04000684 RID: 1668
		public float currentEnergy;
	}

	// Token: 0x02000189 RID: 393
	[Serializable]
	public class SDNote
	{
		// Token: 0x060007BD RID: 1981 RVA: 0x0003A95C File Offset: 0x00038B5C
		//public static SaveData.SDNote GetNote(Player role)
		//{
		//	SaveData.SDNote sdnote = new SaveData.SDNote();
		//	//foreach (int id in role.SystemHandbook.RoleKnown)
		//	//{
		//	//	RoleDisplayData.Data roleDisplayData = Singleton<RoleDisplayData>.GetInstance().GetRoleDisplayData(id);
		//	//	if (roleDisplayData != null)
		//	//	{
		//	//		sdnote.roleKonwn.Add(new SaveData.NoteInfo(roleDisplayData.ID, roleDisplayData.Active, roleDisplayData.Index));
		//	//	}
		//	//}
		//	//foreach (int id2 in role.SystemHandbook.CultureKnown)
		//	//{
		//	//	CultureData.Data data = Singleton<CultureData>.GetInstance().GetData(id2);
		//	//	if (data != null)
		//	//	{
		//	//		sdnote.cultureKnown.Add(new SaveData.NoteInfo(data.ID, data.Active, -1));
		//	//	}
		//	//}
		//	//foreach (AchievementData.AchData achData in Singleton<AchievementData>.GetInstance().Achievement.Values)
		//	//{
		//	//	sdnote.achievement.Add(new SaveData.NoteInfo(achData.ID, achData.Active, achData.Progress));
		//	//}
		//	//return sdnote;
		//}

		// Token: 0x04000685 RID: 1669
		public List<SaveData.NoteInfo> roleKonwn = new List<SaveData.NoteInfo>();

		// Token: 0x04000686 RID: 1670
		public List<SaveData.NoteInfo> cultureKnown = new List<SaveData.NoteInfo>();

		// Token: 0x04000687 RID: 1671
		public List<SaveData.NoteInfo> achievement = new List<SaveData.NoteInfo>();
	}

	// Token: 0x0200018A RID: 394
	[Serializable]
	public class NoteInfo
	{
		// Token: 0x060007BE RID: 1982 RVA: 0x000074FE File Offset: 0x000056FE
		public NoteInfo(int id, bool active, int index)
		{
			this.ID = id;
			this.Active = active;
			this.Index = index;
		}

		// Token: 0x04000688 RID: 1672
		public int ID;

		// Token: 0x04000689 RID: 1673
		public bool Active;

		// Token: 0x0400068A RID: 1674
		public int Index;
	}

	// Token: 0x0200018B RID: 395
	[Serializable]
	public class SDAmbit
	{
		// Token: 0x060007C0 RID: 1984 RVA: 0x0003AAE0 File Offset: 0x00038CE0
		public static SaveData.SDAmbit GetData(Player role)
		{
			return new SaveData.SDAmbit
			{
				//Energy = role.SystemAmbit.RageNum,
				//Level = (int)role.SystemAmbit.GetAmbitLevel()
			};
		}

		// Token: 0x0400068B RID: 1675
		public float Energy;

		// Token: 0x0400068C RID: 1676
		public int Level;
	}

	// Token: 0x0200018C RID: 396
	[Serializable]
	public class PosAndRat
	{
		// Token: 0x0400068D RID: 1677
		public float PosX;

		// Token: 0x0400068E RID: 1678
		public float PosY;

		// Token: 0x0400068F RID: 1679
		public float PosZ;

		// Token: 0x04000690 RID: 1680
		public float RatX;

		// Token: 0x04000691 RID: 1681
		public float RatY;

		// Token: 0x04000692 RID: 1682
		public float RatZ;
	}

	// Token: 0x0200018D RID: 397
	[Serializable]
	public class SDMonsterDate
	{
		// Token: 0x060007C3 RID: 1987 RVA: 0x0003AB18 File Offset: 0x00038D18
		//public static SaveData.SDMonsterDate GetMonsterDate(Monster role)
		//{
		//	SaveData.SDMonsterDate sdmonsterDate = new SaveData.SDMonsterDate();
		//	sdmonsterDate.Type = (int)role._roleType;
		//	sdmonsterDate.PosRat.PosX = role.GetPos().x;
		//	sdmonsterDate.PosRat.PosY = role.GetPos().y;
		//	sdmonsterDate.PosRat.PosZ = role.GetPos().z;
		//	sdmonsterDate.PosRat.RatX = role.GetRat().eulerAngles.x;
		//	sdmonsterDate.PosRat.RatY = role.GetRat().eulerAngles.y;
		//	sdmonsterDate.PosRat.RatZ = role.GetRat().eulerAngles.z;
		//	sdmonsterDate.SpawnID = role.SpawnInfo.ID;
		//	SaveData.GetAttributeDate(sdmonsterDate.AttrList, role);
		//	return sdmonsterDate;
		//}

		// Token: 0x060007C4 RID: 1988 RVA: 0x0003AB18 File Offset: 0x00038D18
		//public static SaveData.SDMonsterDate GetNPCDate(Npc role)
		//{
		//	SaveData.SDMonsterDate sdmonsterDate = new SaveData.SDMonsterDate();
		//	sdmonsterDate.Type = (int)role._roleType;
		//	sdmonsterDate.PosRat.PosX = role.GetPos().x;
		//	sdmonsterDate.PosRat.PosY = role.GetPos().y;
		//	sdmonsterDate.PosRat.PosZ = role.GetPos().z;
		//	sdmonsterDate.PosRat.RatX = role.GetRat().eulerAngles.x;
		//	sdmonsterDate.PosRat.RatY = role.GetRat().eulerAngles.y;
		//	sdmonsterDate.PosRat.RatZ = role.GetRat().eulerAngles.z;
		//	sdmonsterDate.SpawnID = role.SpawnInfo.ID;
		//	SaveData.GetAttributeDate(sdmonsterDate.AttrList, role);
		//	return sdmonsterDate;
		//}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0003AC10 File Offset: 0x00038E10
		public void PrintDate()
		{
			//Logger.Log(new object[]
			//{
			//	string.Concat(new object[]
			//	{
			//		"MonsterInfo-Type:",
			//		this.Type,
			//		",PosX:",
			//		this.PosRat.PosX,
			//		",PosY:",
			//		this.PosRat.PosY,
			//		",PosZ:",
			//		this.PosRat.PosZ,
			//		",RatX:",
			//		this.PosRat.RatX,
			//		",RatY:",
			//		this.PosRat.RatY,
			//		",RatZ:",
			//		this.PosRat.RatZ,
			//		",SpawnID:",
			//		this.SpawnID
			//	})
			//});
			//foreach (ModAttribute.Attribute attribute in this.AttrList)
			//{
			//	if (attribute.attType < ATTRIBUTE_TYPE.ATT_NUMERICAL_END)
			//	{
			//		ModAttribute.Att_Numerical att_Numerical = attribute as ModAttribute.Att_Numerical;
			//		Logger.Log(new object[]
			//		{
			//			string.Concat(new object[]
			//			{
			//				attribute.attType.ToString(),
			//				"-value:",
			//				att_Numerical.Value,
			//				",base:",
			//				att_Numerical.BaseValue,
			//				",add:",
			//				att_Numerical.AddValue
			//			})
			//		});
			//	}
			//	else
			//	{
			//		ModAttribute.Att_StringIndex att_StringIndex = attribute as ModAttribute.Att_StringIndex;
			//		string str = att_StringIndex.attType.ToString() + "-";
			//		for (int i = 0; i < att_StringIndex.GetStrListCount(); i++)
			//		{
			//			str = str + att_StringIndex.GetStrByIndex(i).ToString() + ",";
			//		}
			//	}
			//}
		}

		// Token: 0x04000693 RID: 1683
		public int Type;

		// Token: 0x04000694 RID: 1684
		public SaveData.PosAndRat PosRat = new SaveData.PosAndRat();

		// Token: 0x04000695 RID: 1685
		public int SpawnID;

		// Token: 0x04000696 RID: 1686
		//public List<ModAttribute.Attribute> AttrList = new List<ModAttribute.Attribute>();
	}

	// Token: 0x0200018E RID: 398
	[Serializable]
	public class MoivePlayDate
	{
		// Token: 0x04000697 RID: 1687
		public int Id;

		// Token: 0x04000698 RID: 1688
		public int playCount;
	}

	// Token: 0x0200018F RID: 399
	[Serializable]
	public class SDPlayerDate
	{
		// Token: 0x060007C8 RID: 1992 RVA: 0x0003AEF8 File Offset: 0x000390F8
		public void Reset()
		{
			this.PosRat.PosX = 0f;
			this.PosRat.PosY = 0f;
			this.PosRat.PosZ = 0f;
			this.PosRat.RatX = 0f;
			this.PosRat.RatY = 0f;
			this.PosRat.RatZ = 0f;
			//this.AttrList.Clear();
			//this.itemList.Clear();
			//this.Mission.Reset();
			//this.AdpTlnt.Clear();
			//this.MxtSmlt.Clear();
			//this.HelpSave.Clear();
			//this.RoleGrowDatas.Clear();
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x0003AFB4 File Offset: 0x000391B4
		public static SaveData.SDPlayerDate GetPlayerDate(Player role)
		{
			SaveData.SDPlayerDate sdplayerDate = new SaveData.SDPlayerDate();
			sdplayerDate.Reset();
			sdplayerDate.ID = role.ID;
			//sdplayerDate.PosRat.PosX = role.GetPos().x;
			//sdplayerDate.PosRat.PosY = role.GetPos().y;
			//sdplayerDate.PosRat.PosZ = role.GetPos().z;
			//sdplayerDate.PosRat.RatX = role.GetTrans().rotation.eulerAngles.x;
			//sdplayerDate.PosRat.RatY = role.GetTrans().rotation.eulerAngles.y;
			//sdplayerDate.PosRat.RatZ = role.GetTrans().rotation.eulerAngles.z;
			//SaveData.GetAttributeDate(sdplayerDate.AttrList, role);
			//Dictionary<ulong, CItemBase> dictionary = new Dictionary<ulong, CItemBase>();
			//GameData.Instance.ItemMan.TryGetAllItem(out dictionary);
			//foreach (KeyValuePair<ulong, CItemBase> keyValuePair in dictionary)
			//{
			//	ItemSaveData itemSaveData = keyValuePair.Value.GetItemSaveData();
			//	sdplayerDate.itemList.Add(itemSaveData);
			//}
			//sdplayerDate.Mission = SaveData.SDMission.GetMission(role);
			//sdplayerDate.Skill = SaveData.SDSkill.GetSkill(role);
			//sdplayerDate.Note = SaveData.SDNote.GetNote(role);
			//sdplayerDate.Figure = SaveData.SDFigure.GetFigure(role);
			//sdplayerDate.Ambit = SaveData.SDAmbit.GetData(role);
			//sdplayerDate.AdpTlnt = AdeptTalentSaveData.GetAdeptTalentSD(role);
			//sdplayerDate.MxtSmlt = MixtureSmeltSaveData.GetMxtrSmltSD(role);
			//sdplayerDate.BottleData = BottleSystem.BottleSaveData.GetData(role);
			//sdplayerDate.HelpSave = HelpSaveData.GetHelpSD(role);
			//sdplayerDate.RoleGrowDatas = RoleGrowDataSaveData.GetRoleGrowDataSaveSD(role);
			//sdplayerDate.ShopData = SDShopData.GetData();
			return sdplayerDate;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x0003B1A4 File Offset: 0x000393A4
		public void PrintDate()
		{
			//Logger.Log(new object[]
			//{
			//	string.Concat(new object[]
			//	{
			//		"ID:",
			//		this.ID,
			//		",PosX:",
			//		this.PosRat.PosX,
			//		",PosY:",
			//		this.PosRat.PosY,
			//		",PosZ:",
			//		this.PosRat.PosZ,
			//		",RatX:",
			//		this.PosRat.RatX,
			//		",RatY:",
			//		this.PosRat.RatY,
			//		",RatZ:",
			//		this.PosRat.RatZ
			//	})
			//});
			//foreach (ItemSaveData itemSaveData in this.itemList)
			//{
			//	itemSaveData.PrintDate();
			//}
			//foreach (ModAttribute.Attribute attribute in this.AttrList)
			//{
			//	if (attribute.attType < ATTRIBUTE_TYPE.ATT_NUMERICAL_END)
			//	{
			//		ModAttribute.Att_Numerical att_Numerical = attribute as ModAttribute.Att_Numerical;
			//		Logger.Log(new object[]
			//		{
			//			string.Concat(new object[]
			//			{
			//				attribute.attType.ToString(),
			//				"-value:",
			//				att_Numerical.Value,
			//				",base:",
			//				att_Numerical.BaseValue,
			//				",add:",
			//				att_Numerical.AddValue
			//			})
			//		});
			//	}
			//	else
			//	{
			//		ModAttribute.Att_StringIndex att_StringIndex = attribute as ModAttribute.Att_StringIndex;
			//		string str = att_StringIndex.attType.ToString() + "-";
			//		for (int i = 0; i < att_StringIndex.GetStrListCount(); i++)
			//		{
			//			str = str + att_StringIndex.GetStrByIndex(i).ToString() + ",";
			//		}
			//	}
			//}
			this.Skill.PrintDate();
			this.Mission.PrintDate();
		}

		// Token: 0x04000699 RID: 1689
		public int ID;

		// Token: 0x0400069A RID: 1690
		public SaveData.PosAndRat PosRat = new SaveData.PosAndRat();

		// Token: 0x0400069B RID: 1691
		//public List<ModAttribute.Attribute> AttrList = new List<ModAttribute.Attribute>();

		// Token: 0x0400069C RID: 1692
		//public List<ItemSaveData> itemList = new List<ItemSaveData>();

		// Token: 0x0400069D RID: 1693
		public SaveData.SDSkill Skill = new SaveData.SDSkill();

		// Token: 0x0400069E RID: 1694
		public SaveData.SDMission Mission = new SaveData.SDMission();

		// Token: 0x0400069F RID: 1695
		public SaveData.SDNote Note = new SaveData.SDNote();

		// Token: 0x040006A0 RID: 1696
		public SaveData.SDFigure Figure = new SaveData.SDFigure();

		// Token: 0x040006A1 RID: 1697
		public SaveData.SDAmbit Ambit = new SaveData.SDAmbit();

		// Token: 0x040006A2 RID: 1698
		//public AdeptTalentSaveData AdpTlnt = new AdeptTalentSaveData();

		// Token: 0x040006A3 RID: 1699
		//public MixtureSmeltSaveData MxtSmlt = new MixtureSmeltSaveData();

		// Token: 0x040006A4 RID: 1700
		//public BottleSystem.BottleSaveData BottleData = new BottleSystem.BottleSaveData();

		// Token: 0x040006A5 RID: 1701
		//public RoleGrowDataSaveData RoleGrowDatas = new RoleGrowDataSaveData();

		// Token: 0x040006A6 RID: 1702
		//public HelpSaveData HelpSave = new HelpSaveData();

		// Token: 0x040006A7 RID: 1703
		//public SDShopData ShopData = new SDShopData();
	}

	// Token: 0x02000190 RID: 400
	[Serializable]
	public class SDSpawn
	{
		// Token: 0x060007CC RID: 1996 RVA: 0x0003B434 File Offset: 0x00039634
		public static SaveData.SDSpawn GetSpawn(GameObjSpawn mobSpawn)
		{
			return new SaveData.SDSpawn
			{
				ID = mobSpawn.ID,
				Active = mobSpawn.transform.gameObject.active
			};
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x0003B46C File Offset: 0x0003966C
		public void PrintDate()
		{
			//Logger.Log(new object[]
			//{
			//	string.Concat(new object[]
			//	{
			//		"SDSpawn-id:",
			//		this.ID,
			//		",Active:",
			//		this.Active
			//	})
			//});
		}

		// Token: 0x040006A8 RID: 1704
		public int ID;

		// Token: 0x040006A9 RID: 1705
		public bool Active;
	}

	// Token: 0x02000191 RID: 401
	[Serializable]
	public class SDSpawnMan
	{
		// Token: 0x060007CF RID: 1999 RVA: 0x0003B4C0 File Offset: 0x000396C0
		//public static SaveData.SDSpawnMan GetSpawnMan(SpawnManager spawnMan)
		//{
		//	return new SaveData.SDSpawnMan
		//	{
		//		ID = spawnMan.ID,
		//		Active = spawnMan.bPlayedMovieid
		//	};
		//}

		// Token: 0x060007D0 RID: 2000 RVA: 0x00007539 File Offset: 0x00005739
		public void PrintDate()
		{
			//Logger.Log(new object[]
			//{
			//	"SDSpawnMan-active:" + this.Active
			//});
		}

		// Token: 0x040006AA RID: 1706
		public int ID;

		// Token: 0x040006AB RID: 1707
		public bool Active;
	}

	// Token: 0x02000192 RID: 402
	[Serializable]
	public class SDStageState
	{
		// Token: 0x060007D2 RID: 2002 RVA: 0x0003B4EC File Offset: 0x000396EC
		//public static SaveData.SDStageState GetStageData(StageState state)
		//{
		//	return state.SaveData();
		//}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0003B504 File Offset: 0x00039704
		public static bool FindStage(List<SaveData.SDStageState> list, int id, out SaveData.SDStageState sdstage)
		{
			foreach (SaveData.SDStageState sdstageState in list)
			{
				if (sdstageState != null && sdstageState.ID == id)
				{
					sdstage = sdstageState;
					return true;
				}
			}
			sdstage = null;
			return false;
		}

		// Token: 0x040006AC RID: 1708
		public int ID;

		// Token: 0x040006AD RID: 1709
		public int State;
	}

	// Token: 0x02000193 RID: 403
	[Serializable]
	public class SDMoiveDate
	{
		// Token: 0x060007D5 RID: 2005 RVA: 0x0000755E File Offset: 0x0000575E
		public void Reset()
		{
			this.ID = 0;
			this.PlayCount = 0;
		}

		// Token: 0x040006AE RID: 1710
		public int ID;

		// Token: 0x040006AF RID: 1711
		public int PlayCount;
	}

	// Token: 0x02000194 RID: 404
	[Serializable]
	public class SDSceneDate
	{
		// Token: 0x060007D7 RID: 2007 RVA: 0x0003B5D4 File Offset: 0x000397D4
		public void Reset()
		{
			this.SceneName = string.Empty;
			this.StageStateList.Clear();
			this.MonsterList.Clear();
			//this.OperableList.Clear();
			this.SpawnList.Clear();
			this.SpawnManList.Clear();
			//this.FantasyData.Clear();
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x0003B630 File Offset: 0x00039830
		//public static SaveData.SDSceneDate GetCurSceneDate()
		//{
		//	//if (GUIControl.OpeText != null && GUIControl.OpeText.active)
		//	//{
		//	//	GUIControl.OpeText.active = false;
		//	//}
		//	//SaveData.SDSceneDate sdsceneDate = new SaveData.SDSceneDate();
		//	//sdsceneDate.Reset();
		//	//sdsceneDate.SceneName = Application.loadedLevelName;
		//	//if (SceneManager.RoleMan != null)
		//	//{
		//	//	if (SceneManager.RoleMan.RoleObjList.Count == 0)
		//	//	{
		//	//		Debug.LogWarning(DU.Warning(new object[]
		//	//		{
		//	//			Application.loadedLevelName,
		//	//			"roleobjlist count = 0"
		//	//		}));
		//	//	}
		//	//	for (int i = 0; i < SceneManager.RoleMan.RoleObjList.Count; i++)
		//	//	{
		//	//		Role role = SceneManager.RoleMan.RoleObjList[i];
		//	//		if (!SceneManager.RoleMan.StageRoleList.Contains(role))
		//	//		{
		//	//			if (role == null)
		//	//			{
		//	//				Debug.LogWarning(DU.Warning(new object[]
		//	//				{
		//	//					Application.loadedLevelName,
		//	//					"null"
		//	//				}));
		//	//			}
		//	//			else if (!role.IsDead() || role._roleType == ROLE_TYPE.RT_NPC)
		//	//			{
		//	//				ROLE_TYPE roleType = role._roleType;
		//	//				if (roleType != ROLE_TYPE.RT_MONSTER)
		//	//				{
		//	//					if (roleType == ROLE_TYPE.RT_NPC)
		//	//					{
		//	//						Npc npc = role as Npc;
		//	//						if (npc == null)
		//	//						{
		//	//							Debug.LogWarning(DU.Warning(new object[]
		//	//							{
		//	//								"role is not npc"
		//	//							}));
		//	//						}
		//	//						SaveData.SDMonsterDate npcdate = SaveData.SDMonsterDate.GetNPCDate(npc);
		//	//						sdsceneDate.MonsterList.Add(npcdate);
		//	//					}
		//	//				}
		//	//				else
		//	//				{
		//	//					Monster monster = role as Monster;
		//	//					if (monster == null)
		//	//					{
		//	//						Debug.LogWarning(DU.Warning(new object[]
		//	//						{
		//	//							"role is not monster"
		//	//						}));
		//	//					}
		//	//					SaveData.SDMonsterDate monsterDate = SaveData.SDMonsterDate.GetMonsterDate(monster);
		//	//					sdsceneDate.MonsterList.Add(monsterDate);
		//	//				}
		//	//			}
		//	//		}
		//	//	}
		//	//	foreach (OperableItemBase operableItemBase in SceneManager.RoleMan.OperableItemList)
		//	//	{
		//	//		OperableSaveDataBase saveData = operableItemBase.GetSaveData();
		//	//		if (saveData != null)
		//	//		{
		//	//			sdsceneDate.OperableList.Add(saveData);
		//	//		}
		//	//	}
		//	//	for (int j = 0; j < SceneManager.RoleMan.MobSpawnList.Count; j++)
		//	//	{
		//	//		GameObjSpawn gameObjSpawn = SceneManager.RoleMan.MobSpawnList[j];
		//	//		if (!(gameObjSpawn == null))
		//	//		{
		//	//			SaveData.SDSpawn spawn = SaveData.SDSpawn.GetSpawn(gameObjSpawn);
		//	//			sdsceneDate.SpawnList.Add(spawn);
		//	//		}
		//	//	}
		//	//	for (int k = 0; k < SceneManager.RoleMan.SpawnManList.Count; k++)
		//	//	{
		//	//		SpawnManager spawnManager = SceneManager.RoleMan.SpawnManList[k];
		//	//		if (!(spawnManager == null))
		//	//		{
		//	//			SaveData.SDSpawnMan spawnMan = SaveData.SDSpawnMan.GetSpawnMan(spawnManager);
		//	//			sdsceneDate.SpawnManList.Add(spawnMan);
		//	//		}
		//	//	}
		//	//	foreach (StageState stageState in SingletonMono<StageManager>.GetInstance().StageStatic)
		//	//	{
		//	//		if (stageState == null)
		//	//		{
		//	//			Debug.LogWarning(DU.Warning(new object[]
		//	//			{
		//	//				"Has destroy stage",
		//	//				stageState
		//	//			}));
		//	//		}
		//	//		else
		//	//		{
		//	//			SaveData.SDStageState stageData = SaveData.SDStageState.GetStageData(stageState);
		//	//			if (stageData != null)
		//	//			{
		//	//				SaveData.SDStageState sdstageState = null;
		//	//				if (SaveData.SDStageState.FindStage(sdsceneDate.StageStateList, stageData.ID, out sdstageState))
		//	//				{
		//	//					Debug.LogWarning(DU.Warning(new object[]
		//	//					{
		//	//						"Read Stage Wrong!",
		//	//						"Have same id in scene",
		//	//						stageState.gameObject,
		//	//						stageState.id
		//	//					}));
		//	//				}
		//	//				else
		//	//				{
		//	//					sdsceneDate.StageStateList.Add(stageData);
		//	//				}
		//	//			}
		//	//		}
		//	//	}
		//	//	sdsceneDate.StageStateList.Sort((SaveData.SDStageState left, SaveData.SDStageState right) => left.ID.CompareTo(right.ID));
		//	//}
		//	//sdsceneDate.musicData = SingletonMono<MusicManager>.GetInstance().GetCurrentMusicData();
		//	//if (FantasyGod.Instance != null)
		//	//{
		//	//	sdsceneDate.FantasyData = SDFantasyExecuteData.GetFantasyExecuteDataSD();
		//	//}
		//	//return sdsceneDate;
		//}

		// Token: 0x060007D9 RID: 2009 RVA: 0x0003BA64 File Offset: 0x00039C64
		public void PrintDate()
		{
			//Logger.Log(new object[]
			//{
			//	"SceneName:" + this.SceneName
			//});
			//Logger.Log(new object[]
			//{
			//	"MonsterCount:" + this.MonsterList.Count
			//});
			foreach (SaveData.SDMonsterDate sdmonsterDate in this.MonsterList)
			{
				sdmonsterDate.PrintDate();
			}
			foreach (SaveData.SDSpawn sdspawn in this.SpawnList)
			{
				sdspawn.PrintDate();
			}
			foreach (SaveData.SDSpawnMan sdspawnMan in this.SpawnManList)
			{
				sdspawnMan.PrintDate();
			}
			//foreach (OperableSaveDataBase operableSaveDataBase in this.OperableList)
			//{
			//	operableSaveDataBase.PrintData();
			//}
		}

		// Token: 0x040006B0 RID: 1712
		public string SceneName;

		// Token: 0x040006B1 RID: 1713
		public List<SaveData.SDMonsterDate> MonsterList = new List<SaveData.SDMonsterDate>();

		// Token: 0x040006B2 RID: 1714
		//public List<OperableSaveDataBase> OperableList = new List<OperableSaveDataBase>();

		// Token: 0x040006B3 RID: 1715
		public List<SaveData.SDSpawn> SpawnList = new List<SaveData.SDSpawn>();

		// Token: 0x040006B4 RID: 1716
		public List<SaveData.SDSpawnMan> SpawnManList = new List<SaveData.SDSpawnMan>();

		// Token: 0x040006B5 RID: 1717
		public List<SaveData.SDStageState> StageStateList = new List<SaveData.SDStageState>();

		// Token: 0x040006B6 RID: 1718
		//public SDFantasyExecuteData FantasyData = new SDFantasyExecuteData();

		// Token: 0x040006B7 RID: 1719
		//public MusicData musicData = new MusicData();
	}

	// Token: 0x02000195 RID: 405
	[Serializable]
	public class SDBase
	{
		// Token: 0x060007DC RID: 2012 RVA: 0x0003BBE4 File Offset: 0x00039DE4
		public static SaveData.SDBase GetBaseDate()
		{
			return new SaveData.SDBase
			{
				Version = 10000,
				ViewPos = 1,
				SaveTime = DateTime.Now.ToString()
			};
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x00007581 File Offset: 0x00005781
		public void Reset()
		{
			this.Version = 10000;
			this.ViewPos = 1;
			this.SaveTime = string.Empty;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0003BC20 File Offset: 0x00039E20
		public void PrintDate()
		{
			//Logger.Log(new object[]
			//{
			//	string.Concat(new object[]
			//	{
			//		"version:",
			//		this.Version,
			//		",viewPos:",
			//		this.ViewPos,
			//		",saveTime:",
			//		this.SaveTime
			//	})
			//});
		}

		// Token: 0x040006B9 RID: 1721
		public int Version;

		// Token: 0x040006BA RID: 1722
		public int ViewPos;

		// Token: 0x040006BB RID: 1723
		public string SaveTime;
	}

	// Token: 0x02000196 RID: 406
	[Serializable]
	public class SDGame
	{
		// Token: 0x060007E0 RID: 2016 RVA: 0x000075C9 File Offset: 0x000057C9
		public void Reset()
		{
			this.CurSceneName = string.Empty;
			this.PlayerList.Clear();
			this.SceneList.Clear();
			this.MoiveInfoList.Clear();
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0003BC84 File Offset: 0x00039E84
		public static SaveData.SDGame GetGameDate()
		{
			SaveData.SDGame sdgame = new SaveData.SDGame();
			sdgame.Reset();
			sdgame.CurSceneName = Application.loadedLevelName;
			bool flag = false;
			//for (int i = 0; i < SceneManager.RoleMan.RoleObjList.Count; i++)
			//{
			//	Role role = SceneManager.RoleMan.RoleObjList[i];
			//	if (role != null && role._roleType == ROLE_TYPE.RT_PLAYER)
			//	{
			//		Player player = role as Player;
			//		if (player == null)
			//		{
			//			Debug.LogWarning(DU.Warning(new object[]
			//			{
			//				"Player null"
			//			}));
			//		}
			//		flag = true;
			//		SaveData.SDPlayerDate playerDate = SaveData.SDPlayerDate.GetPlayerDate(player);
			//		sdgame.PlayerList.Add(playerDate);
			//	}
			//}
			//if (!flag)
			//{
			//	Debug.LogWarning(DU.Warning(new object[]
			//	{
			//		"noll player"
			//	}));
			//}
			//SaveData.SDSceneDate curSceneDate = SaveData.SDSceneDate.GetCurSceneDate();
			//for (int j = 0; j < SDManager.SDSave.SaveDateGame.SceneList.Count; j++)
			//{
			//	SaveData.SDSceneDate sdsceneDate = SDManager.SDSave.SaveDateGame.SceneList[j];
			//	if (sdsceneDate != null)
			//	{
			//		if (sdsceneDate.SceneName == curSceneDate.SceneName)
			//		{
			//			sdgame.SceneList.Remove(sdsceneDate);
			//		}
			//		else
			//		{
			//			sdgame.SceneList.Add(sdsceneDate);
			//		}
			//	}
			//}
			//for (int k = 0; k < DynamicData.MoiveInfoList.Count; k++)
			//{
			//	sdgame.MoiveInfoList.Add(DynamicData.MoiveInfoList[k]);
			//}
			//sdgame.SceneList.Add(curSceneDate);
			return sdgame;
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0003BE1C File Offset: 0x0003A01C
		public void PrintDate()
		{
			//Logger.Log(new object[]
			//{
			//	"curSceneName:" + this.CurSceneName
			//});
			//foreach (SaveData.SDMoiveDate sdmoiveDate in this.MoiveInfoList)
			//{
			//	Logger.Log(new object[]
			//	{
			//		string.Concat(new object[]
			//		{
			//			"moiveDate:",
			//			sdmoiveDate.ID,
			//			",",
			//			sdmoiveDate.PlayCount
			//		})
			//	});
			//}
			//foreach (SaveData.SDPlayerDate sdplayerDate in this.PlayerList)
			//{
			//	sdplayerDate.PrintDate();
			//}
			//foreach (SaveData.SDSceneDate sdsceneDate in this.SceneList)
			//{
			//	sdsceneDate.PrintDate();
			//}
		}

		// Token: 0x040006BC RID: 1724
		public string CurSceneName;

		// Token: 0x040006BD RID: 1725
		public List<SaveData.SDPlayerDate> PlayerList = new List<SaveData.SDPlayerDate>();

		// Token: 0x040006BE RID: 1726
		public List<SaveData.SDSceneDate> SceneList = new List<SaveData.SDSceneDate>();

		// Token: 0x040006BF RID: 1727
		public List<SaveData.SDMoiveDate> MoiveInfoList = new List<SaveData.SDMoiveDate>();
	}
}
