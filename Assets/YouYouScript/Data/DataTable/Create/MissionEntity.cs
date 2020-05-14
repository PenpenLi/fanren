
//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-01-24 23:40:33
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using YouYou;

/// <summary>
/// Mission实体
/// </summary>
public partial class MissionEntity : DataTableEntityBase
{
    /// <summary>
    /// 步骤
    /// </summary>
    public int step;

    /// <summary>
    /// 总步骤
    /// </summary>
    public int StepAmount;

    /// <summary>
    /// 掩码
    /// </summary>
    public int Mask;

    /// <summary>
    /// 任务名
    /// </summary>
    public string Name;

    /// <summary>
    /// 任务剧情文字
    /// </summary>
    public string AimDescribe;

    /// <summary>
    /// 任务要求
    /// </summary>
    public string AimRequire;

    /// <summary>
    /// 完成NPC
    /// </summary>
    public int CompleteNpc;

    /// <summary>
    /// 触发类型-1:不做任何操作;0:自动触发某任务,比如主线任务;1:完成后跳转到指定任务;
    /// </summary>
    public int MissType;

    /// <summary>
    /// 触发内容
    /// </summary>
    public string MissVal;

    /// <summary>
    /// 脚本ID
    /// </summary>
    public int ComSMT;

    /// <summary>
    /// 数据ID
    /// </summary>
    public int ComSMTDate;

    /// <summary>
    /// 任务目标个数
    /// </summary>
    public string AimInfo;

}
