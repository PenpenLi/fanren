
//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-01-30 15:55:06
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Battle数据管理
/// </summary>
public partial class BattleDBModel : DataTableDBModelBase<BattleDBModel, BattleEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "Battle"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            BattleEntity entity = new BattleEntity();
            entity.Id = ms.ReadInt();
            entity.Name = ms.ReadUTF8String();
            entity.Desc = ms.ReadUTF8String();
            entity.Pic = ms.ReadUTF8String();
            entity.Music = ms.ReadUTF8String();
            entity.Role = ms.ReadUTF8String();
            entity.MapLocation = ms.ReadUTF8String();
            entity.MapUnits = ms.ReadUTF8String();

            m_List.Add(entity);
            m_Dic[entity.Id] = entity;
        }
    }
}