using System;
using System.Collections.Generic;

// Token: 0x0200048A RID: 1162
public class AmbitData
{
	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001E2F RID: 7727 RVA: 0x000D1E80 File Offset: 0x000D0080
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06001E30 RID: 7728 RVA: 0x000D1E88 File Offset: 0x000D0088
	public string Description
	{
		get
		{
			return this.description;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06001E31 RID: 7729 RVA: 0x000D1E90 File Offset: 0x000D0090
	public float BaseHP
	{
		get
		{
			return this.baseHP;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06001E32 RID: 7730 RVA: 0x000D1E98 File Offset: 0x000D0098
	public float BaseMP
	{
		get
		{
			return this.baseMP;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06001E33 RID: 7731 RVA: 0x000D1EA0 File Offset: 0x000D00A0
	public float BaseDefense
	{
		get
		{
			return this.baseDefense;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x06001E34 RID: 7732 RVA: 0x000D1EA8 File Offset: 0x000D00A8
	public float BaseMagicDefense
	{
		get
		{
			return this.baseMagicDefence;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x06001E35 RID: 7733 RVA: 0x000D1EB0 File Offset: 0x000D00B0
	public float BaseAttack
	{
		get
		{
			return this.baseAttack;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x06001E36 RID: 7734 RVA: 0x000D1EB8 File Offset: 0x000D00B8
	public float BaseMagicAttack
	{
		get
		{
			return this.baseMagicAttack;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06001E37 RID: 7735 RVA: 0x000D1EC0 File Offset: 0x000D00C0
	public float ElementMetal
	{
		get
		{
			return this.elementMetal;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x06001E38 RID: 7736 RVA: 0x000D1EC8 File Offset: 0x000D00C8
	public float ElementWood
	{
		get
		{
			return this.elementWood;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x06001E39 RID: 7737 RVA: 0x000D1ED0 File Offset: 0x000D00D0
	public float ElementWater
	{
		get
		{
			return this.elementWater;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x06001E3A RID: 7738 RVA: 0x000D1ED8 File Offset: 0x000D00D8
	public float ElementFire
	{
		get
		{
			return this.elementFire;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06001E3B RID: 7739 RVA: 0x000D1EE0 File Offset: 0x000D00E0
	public float ElementEarth
	{
		get
		{
			return this.elementEarth;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06001E3C RID: 7740 RVA: 0x000D1EE8 File Offset: 0x000D00E8
	public float MaxRage
	{
		get
		{
			return this.maxRage;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001E3D RID: 7741 RVA: 0x000D1EF0 File Offset: 0x000D00F0
	public float MaxEnergy
	{
		get
		{
			return this.maxEnergy;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001E3E RID: 7742 RVA: 0x000D1EF8 File Offset: 0x000D00F8
	public float RageTime
	{
		get
		{
			return this.rageTime;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001E3F RID: 7743 RVA: 0x000D1F00 File Offset: 0x000D0100
	public float AddAttackPer
	{
		get
		{
			return this.addAttackPer;
		}
	}

	// Token: 0x17000362 RID: 866
	// (get) Token: 0x06001E40 RID: 7744 RVA: 0x000D1F08 File Offset: 0x000D0108
	public float AddMagicAttackPer
	{
		get
		{
			return this.addMagicAttackPer;
		}
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x06001E41 RID: 7745 RVA: 0x000D1F10 File Offset: 0x000D0110
	public float AddDefensePer
	{
		get
		{
			return this.addDefensePer;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x06001E42 RID: 7746 RVA: 0x000D1F18 File Offset: 0x000D0118
	public float AddMagicDefensePer
	{
		get
		{
			return this.addMagicDefensePer;
		}
	}

	// Token: 0x17000365 RID: 869
	// (get) Token: 0x06001E43 RID: 7747 RVA: 0x000D1F20 File Offset: 0x000D0120
	public int EffectId
	{
		get
		{
			return this.effectId;
		}
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x06001E44 RID: 7748 RVA: 0x000D1F28 File Offset: 0x000D0128
	public string EffectBoneName
	{
		get
		{
			return this.bindBone;
		}
	}

	// Token: 0x17000367 RID: 871
	// (get) Token: 0x06001E45 RID: 7749 RVA: 0x000D1F30 File Offset: 0x000D0130
	public int BodyId
	{
		get
		{
			return this.bodyId;
		}
	}

	// Token: 0x06001E46 RID: 7750 RVA: 0x000D1F38 File Offset: 0x000D0138
	public void ReadConfig(List<string> infoList, ref int index)
	{
		this.name = infoList[index++];
		this.description = infoList[index++];
		this.baseHP = float.Parse(infoList[index++]);
		this.baseMP = float.Parse(infoList[index++]);
		this.baseDefense = float.Parse(infoList[index++]);
		this.baseMagicDefence = float.Parse(infoList[index++]);
		this.baseAttack = float.Parse(infoList[index++]);
		this.baseMagicAttack = float.Parse(infoList[index++]);
		this.elementMetal = float.Parse(infoList[index++]);
		this.elementWood = float.Parse(infoList[index++]);
		this.elementWater = float.Parse(infoList[index++]);
		this.elementFire = float.Parse(infoList[index++]);
		this.elementEarth = float.Parse(infoList[index++]);
		this.maxRage = float.Parse(infoList[index++]);
		this.rageTime = float.Parse(infoList[index++]);
		this.maxEnergy = float.Parse(infoList[index++]);
		this.addAttackPer = float.Parse(infoList[index++]);
		this.addDefensePer = float.Parse(infoList[index++]);
		this.addMagicAttackPer = float.Parse(infoList[index++]);
		this.addMagicDefensePer = float.Parse(infoList[index++]);
		this.effectId = int.Parse(infoList[index++]);
		this.bindBone = infoList[index++];
		this.bodyId = int.Parse(infoList[index++]);
	}

	// Token: 0x04001B33 RID: 6963
	private string name;

	// Token: 0x04001B34 RID: 6964
	private string description;

	// Token: 0x04001B35 RID: 6965
	private float baseHP;

	// Token: 0x04001B36 RID: 6966
	private float baseMP;

	// Token: 0x04001B37 RID: 6967
	private float baseDefense;

	// Token: 0x04001B38 RID: 6968
	private float baseMagicDefence;

	// Token: 0x04001B39 RID: 6969
	private float baseAttack;

	// Token: 0x04001B3A RID: 6970
	private float baseMagicAttack;

	// Token: 0x04001B3B RID: 6971
	private float elementMetal;

	// Token: 0x04001B3C RID: 6972
	private float elementWood;

	// Token: 0x04001B3D RID: 6973
	private float elementWater;

	// Token: 0x04001B3E RID: 6974
	private float elementFire;

	// Token: 0x04001B3F RID: 6975
	private float elementEarth;

	// Token: 0x04001B40 RID: 6976
	private float maxRage;

	// Token: 0x04001B41 RID: 6977
	private float maxEnergy;

	// Token: 0x04001B42 RID: 6978
	private float rageTime;

	// Token: 0x04001B43 RID: 6979
	private float addAttackPer;

	// Token: 0x04001B44 RID: 6980
	private float addDefensePer;

	// Token: 0x04001B45 RID: 6981
	private float addMagicAttackPer;

	// Token: 0x04001B46 RID: 6982
	private float addMagicDefensePer;

	// Token: 0x04001B47 RID: 6983
	private int effectId;

	// Token: 0x04001B48 RID: 6984
	private string bindBone;

	// Token: 0x04001B49 RID: 6985
	private int bodyId;
}
