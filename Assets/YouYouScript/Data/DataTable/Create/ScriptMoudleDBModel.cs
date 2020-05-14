
//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-01-21 16:20:05
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// ScriptMoudle数据管理
/// </summary>
public partial class ScriptMoudleDBModel : DataTableDBModelBase<ScriptMoudleDBModel, ScriptMoudleEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "ScriptMoudle"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            ScriptMoudleEntity entity = new ScriptMoudleEntity();
            entity.Id = ms.ReadInt();
            entity.ModName = ms.ReadUTF8String();
            entity.Dec = ms.ReadUTF8String();

            m_List.Add(entity);
            m_Dic[entity.Id] = entity;
        }
    }
}