
//===================================================
//作    者：边涯  http://www.u3dol.com
//创建时间：2020-01-12 23:17:57
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using YouYou;

/// <summary>
/// Sys_Scene实体
/// </summary>
public partial class Sys_SceneEntity : DataTableEntityBase
{
    /// <summary>
    /// 名称
    /// </summary>
    public string SceneName;

    /// <summary>
    /// 背景音乐
    /// </summary>
    public int BGMId;

    /// <summary>
    /// 场景类型(0=登陆1=地图2=战斗)
    /// </summary>
    public int SceneType;

    /// <summary>
    /// 传送点（坐标_y轴旋转_传送点编号_要传送的场景Id_目标场景出生传送点id）
    /// </summary>
    public string TransPos;

    /// <summary>
    /// 主角出生点坐标
    /// </summary>
    public string RoleBirthPos;

    /// <summary>
    /// NPC列表
    /// </summary>
    public string NPCList;

}
