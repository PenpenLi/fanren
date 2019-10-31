using System;
using System.Collections.Generic;

// Token: 0x0200023C RID: 572
public class EffectSoundData
{
	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x06000F07 RID: 3847 RVA: 0x0000B267 File Offset: 0x00009467
	// (set) Token: 0x06000F08 RID: 3848 RVA: 0x0000B26F File Offset: 0x0000946F
	public int[] SoundID { get; private set; }

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x06000F09 RID: 3849 RVA: 0x0000B278 File Offset: 0x00009478
	// (set) Token: 0x06000F0A RID: 3850 RVA: 0x0000B280 File Offset: 0x00009480
	public float[] SoundTime { get; private set; }

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x06000F0B RID: 3851 RVA: 0x0000B289 File Offset: 0x00009489
	// (set) Token: 0x06000F0C RID: 3852 RVA: 0x0000B291 File Offset: 0x00009491
	public bool[] IsSoundLoop { get; private set; }

	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x06000F0D RID: 3853 RVA: 0x0000B29A File Offset: 0x0000949A
	// (set) Token: 0x06000F0E RID: 3854 RVA: 0x0000B2A2 File Offset: 0x000094A2
	public bool[] IsFollow { get; private set; }

	// Token: 0x06000F0F RID: 3855 RVA: 0x00096414 File Offset: 0x00094614
	public void ReadData(List<string> infoList, ref int index)
	{
		//this.SoundID = UtilityStringData.GetIntFromCombineStr(infoList[index++]);
		//this.SoundTime = UtilityStringData.GetFloatFromCombineStr(infoList[index++]);
		//this.IsSoundLoop = UtilityStringData.GetBooltFromCombineStr(infoList[index++]);
		//this.IsFollow = UtilityStringData.GetBooltFromCombineStr(infoList[index++]);
	}

	// Token: 0x06000F10 RID: 3856 RVA: 0x0009648C File Offset: 0x0009468C
	public void ReadData(string[] infoList, ref int index)
	{
		//this.SoundID = UtilityStringData.GetIntFromCombineStr(infoList[index++]);
		//this.SoundTime = UtilityStringData.GetFloatFromCombineStr(infoList[index++]);
		//this.IsSoundLoop = UtilityStringData.GetBooltFromCombineStr(infoList[index++]);
		//this.IsFollow = UtilityStringData.GetBooltFromCombineStr(infoList[index++]);
	}

	// Token: 0x06000F11 RID: 3857 RVA: 0x0000B2AB File Offset: 0x000094AB
	public bool IsHasSound()
	{
		return this.SoundID != null && this.SoundID.Length != 0 && this.SoundID[0] > 0;
	}
}
