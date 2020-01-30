
//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-01-28 19:27:51
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// ScriptTrigger数据管理
/// </summary>
public partial class ScriptTriggerDBModel : DataTableDBModelBase<ScriptTriggerDBModel, ScriptTriggerEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "ScriptTrigger"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            ScriptTriggerEntity entity = new ScriptTriggerEntity();
            entity.Id = ms.ReadInt();
            entity.Name = ms.ReadUTF8String();
            entity.ScriptHandle = ms.ReadUTF8String();

            m_List.Add(entity);
            m_Dic[entity.Id] = entity;
        }
    }
}