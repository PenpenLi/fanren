//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-12-12 08:58:43
//备    注：
//===================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 主角信息
/// </summary>
public class RoleInfoMainPlayer : RoleInfoBase
{
    public byte JobId; //职业编号
    public int TotalRechargeMoney; //累计充值
    public int Money; //元宝
    public int Gold; //金币

    public int Equip_Weapon; //穿戴武器
    public int Equip_Pants; //穿戴护腿
    public int Equip_Clothes; //穿戴衣服
    public int Equip_Belt; //穿戴腰带
    public int Equip_Cuff; //穿戴护腕
    public int Equip_Necklace; //穿戴项链
    public int Equip_Shoe; //穿戴鞋
    public int Equip_Ring; //穿戴戒指

    public int Equip_WeaponTableId; //穿戴武器
    public int Equip_PantsTableId; //穿戴护腿
    public int Equip_ClothesTableId; //穿戴衣服
    public int Equip_BeltTableId; //穿戴腰带
    public int Equip_CuffTableId; //穿戴护腕
    public int Equip_NecklaceTableId; //穿戴项链
    public int Equip_ShoeTableId; //穿戴鞋
    public int Equip_RingTableId; //穿戴戒指

    public RoleInfoMainPlayer() : base()
    {

    }

    //public RoleInfoMainPlayer(RoleOperation_SelectRoleInfoReturnProto roleInfoProto)
    //{
    //    RoleId = roleInfoProto.RoldId;
    //    RoleNickName = roleInfoProto.RoleNickName;
    //    JobId = roleInfoProto.JobId;
    //    Level = roleInfoProto.Level;
    //    TotalRechargeMoney = roleInfoProto.TotalRechargeMoney;
    //    Money = roleInfoProto.Money;
    //    Gold = roleInfoProto.Gold;
    //    Exp = roleInfoProto.Exp;
    //    MaxHP = roleInfoProto.MaxHP;
    //    MaxMP = roleInfoProto.MaxMP;
    //    CurrHP = roleInfoProto.CurrHP;
    //    CurrMP = roleInfoProto.CurrMP;
    //    Attack = roleInfoProto.Attack;
    //    Defense = roleInfoProto.Defense;
    //    Hit = roleInfoProto.Hit;
    //    Dodge = roleInfoProto.Dodge;
    //    Cri = roleInfoProto.Cri;
    //    Res = roleInfoProto.Res;
    //    Fighting = roleInfoProto.Fighting;

    //    Equip_Weapon = roleInfoProto.Equip_Weapon;
    //    Equip_Pants = roleInfoProto.Equip_Pants;
    //    Equip_Clothes = roleInfoProto.Equip_Clothes;
    //    Equip_Belt = roleInfoProto.Equip_Belt;
    //    Equip_Cuff = roleInfoProto.Equip_Cuff;
    //    Equip_Necklace = roleInfoProto.Equip_Necklace;
    //    Equip_Shoe = roleInfoProto.Equip_Shoe;
    //    Equip_Ring = roleInfoProto.Equip_Ring;

    //    Equip_WeaponTableId = roleInfoProto.Equip_WeaponTableId;
    //    Equip_PantsTableId = roleInfoProto.Equip_PantsTableId;
    //    Equip_ClothesTableId = roleInfoProto.Equip_ClothesTableId;
    //    Equip_BeltTableId = roleInfoProto.Equip_BeltTableId;
    //    Equip_CuffTableId = roleInfoProto.Equip_CuffTableId;
    //    Equip_NecklaceTableId = roleInfoProto.Equip_NecklaceTableId;
    //    Equip_ShoeTableId = roleInfoProto.Equip_ShoeTableId;
    //    Equip_RingTableId = roleInfoProto.Equip_RingTableId;

    //    SkillList = new List<RoleInfoSkill>();
    //}

    ///// <summary>
    ///// 加载主角学会的技能
    ///// </summary>
    ///// <param name="proto"></param>
    //public void LoadSkill(RoleData_SkillReturnProto proto)
    //{
    //    SkillList.Clear();

    //    for (int i = 0; i < proto.CurrSkillDataList.Count; i++)
    //    {
    //        SkillList.Add(new RoleInfoSkill()
    //        {
    //            SkillId = proto.CurrSkillDataList[i].SkillId,
    //            SkillLevel = proto.CurrSkillDataList[i].SkillLevel,
    //            SlotsNo = proto.CurrSkillDataList[i].SlotsNo

    //        });
    //    }
    //}
}