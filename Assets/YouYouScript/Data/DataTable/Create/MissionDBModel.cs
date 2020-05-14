
//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-01-24 23:40:33
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// Mission数据管理
/// </summary>
public partial class MissionDBModel : DataTableDBModelBase<MissionDBModel, MissionEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "Mission"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            MissionEntity entity = new MissionEntity();
            entity.Id = ms.ReadInt();
            entity.step = ms.ReadInt();
            entity.StepAmount = ms.ReadInt();
            entity.Mask = ms.ReadInt();
            entity.Name = ms.ReadUTF8String();
            entity.AimDescribe = ms.ReadUTF8String();
            entity.AimRequire = ms.ReadUTF8String();
            entity.CompleteNpc = ms.ReadInt();
            entity.MissType = ms.ReadInt();
            entity.MissVal = ms.ReadUTF8String();
            entity.ComSMT = ms.ReadInt();
            entity.ComSMTDate = ms.ReadInt();
            entity.AimInfo = ms.ReadUTF8String();

            m_List.Add(entity);
            m_Dic[entity.Id] = entity;
        }
    }
}