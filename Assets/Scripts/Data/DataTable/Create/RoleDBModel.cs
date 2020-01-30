using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// Role数据管理
/// </summary>
public partial class RoleDBModel : DataTableDBModelBase<RoleDBModel, RoleEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "Role"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            RoleEntity entity = new RoleEntity();
            entity.Id = ms.ReadInt();
            entity.Name = ms.ReadUTF8String();
            entity.maxhp = ms.ReadInt();
            entity.maxmp = ms.ReadInt();
            entity.bili = ms.ReadInt();
            entity.shenfa = ms.ReadInt();
            entity.wuxing = ms.ReadInt();
            entity.quanzhang = ms.ReadInt();
            entity.jianfa = ms.ReadInt();
            entity.daofa = ms.ReadInt();
            entity.qimen = ms.ReadInt();
            entity.gengu = ms.ReadInt();
            entity.wuxue = ms.ReadInt();
            entity.fuyuan = ms.ReadInt();
            entity.talent = ms.ReadUTF8String();
            entity.grow_template = ms.ReadUTF8String();
            entity.model = ms.ReadUTF8String();
            entity.female = ms.ReadInt();
            entity.level = ms.ReadInt();
            entity.special_skills = ms.ReadUTF8String();
            entity.internal_skills = ms.ReadUTF8String();
            entity.skill = ms.ReadUTF8String();
            entity.items = ms.ReadUTF8String();

            m_List.Add(entity);
            m_Dic[entity.Id] = entity;
        }
    }
}