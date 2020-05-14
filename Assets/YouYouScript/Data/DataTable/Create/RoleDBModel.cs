
//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-02-08 18:41:49
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

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
            entity.MaxHp = ms.ReadInt();
            entity.MaxMp = ms.ReadInt();
            entity.Attack = ms.ReadInt();
            entity.Defense = ms.ReadInt();
            entity.ShenFa = ms.ReadInt();
            entity.Job = ms.ReadInt();
            entity.Model = ms.ReadUTF8String();
            entity.Female = ms.ReadInt();
            entity.items = ms.ReadUTF8String();
            entity.SkillIds = ms.ReadUTF8String();

            m_List.Add(entity);
            m_Dic[entity.Id] = entity;
        }
    }
}