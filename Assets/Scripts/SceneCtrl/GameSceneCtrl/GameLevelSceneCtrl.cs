//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2016-08-09 21:42:22
//备    注：
//===================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PathologicalGames;
using System;
using YouYou;

public class GameLevelSceneCtrl : GameSceneCtrlBase
{

    [SerializeField]
    private GameLevelRegionCtrl[] AllRegion;

    /// <summary>
    /// 表格中的区域列表
    /// </summary>
    private List<GameLevelRegionEntity> m_RegionList;

    /// <summary>
    /// 当前进入的区域索引号
    /// </summary>
    private int m_CurrRegionIndex;

    /// <summary>
    /// 当前关卡Id
    /// </summary>
    private int m_CurrGameLevelId;

    /// <summary>
    /// 当前关卡的难度等级
    /// </summary>
    //private GameLevelGrade m_CurrGrade;

    /// <summary>
    /// 当前的区域编号
    /// </summary>
    private int m_CurrRegionId;

    /// <summary>
    /// 本关卡怪的总数
    /// </summary>
    private int m_AllMonsterCount;

    /// <summary>
    /// 怪的种类
    /// </summary>
    private int[] m_MonsterId;

    /// <summary>
    /// 怪物池
    /// </summary>
    private SpawnPool m_MonsterPool;

    /// <summary>
    /// 当前区域怪的总数量
    /// </summary>
    private int m_CurrRegionMonsterCount;

    /// <summary>
    /// 当前区域创建的怪的数量
    /// </summary>
    private int m_CurrRegionCreateMonsterCount;

    /// <summary>
    /// 当前区域杀死的怪的数量
    /// </summary>
    private int m_CurrRegionKillMonsterCount;

    /// <summary>
    /// 当前区域怪的详情（每种怪 有多少）
    /// </summary>
    private Dictionary<int, int> m_RegionMonsterDic;

    /// <summary>
    /// 当前的区域控制器
    /// </summary>
    private GameLevelRegionCtrl m_CurrRegionCtrl;

    /// <summary>
    /// 战斗的时间
    /// </summary>
    private float m_FightTime = 0;

    /// <summary>
    /// 是否在战斗中
    /// </summary>
    private bool m_IsFighting;

    public static GameLevelSceneCtrl Instance;

    protected override void OnAwake()
    {
        base.OnAwake();
        Instance = this;
    }

    protected override void OnStart()
    {
        base.OnStart();
        //m_CurrGameLevelId = SceneMgr.Instance.CurrGameLevelId;
        //GameLevelEntity entity = GameLevelDBModel.Instance.Get(m_CurrGameLevelId);
        //if (entity != null)
        //{
        //    AudioBackGroundMgr.Instance.Play(entity.Audio_BG);
        //}

        //m_CurrGrade = SceneMgr.Instance.CurrGameLevelGrade;

        //GameLevelCtrl.Instance.CurrGameLevelId = m_CurrGameLevelId;
        //GameLevelCtrl.Instance.CurrGameLevelGrade = m_CurrGrade;

        //m_IsFighting = true;

        //m_RegionMonsterDic = new Dictionary<int, int>();
        //m_SpriteList = new List<int>();

        //GameLevelCtrl.Instance.CurrGameLevelTotalExp = 0;
        //GameLevelCtrl.Instance.CurrGameLevelTotalGold = 0;
        //GameLevelCtrl.Instance.CurrGameLevelKillMonsterDic.Clear();
        //GameLevelCtrl.Instance.CurrGameLevelGetGoodsList.Clear();
    }

    protected override void OnLoadUIMainCityViewComplete(UIFormBase t1)
    {
        base.OnLoadUIMainCityViewComplete(t1);

        //设置左上角 基本信息
        //PlayerCtrl.Instance.SetMainCityRoleData();

        ////根据游戏关卡编号 返回所有区域
        //m_RegionList = GameLevelRegionDBModel.Instance.GetListByGameLevelId(m_CurrGameLevelId);


        //m_AllMonsterCount = GameLevelMonsterDBModel.Instance.GetGameLevelMonsterCount(m_CurrGameLevelId, m_CurrGrade);
        //m_MonsterId = GameLevelMonsterDBModel.Instance.GetGameLevelMonsterId(m_CurrGameLevelId, m_CurrGrade);

        //创建怪物池
        //m_MonsterPool = PoolManager.Pools.Create("Monster");
        //m_MonsterPool.group.parent = null;
        //m_MonsterPool.group.localPosition = Vector3.zero;

        //LoadMonster(0, OnLoadMonsterCallBack);
    }

    /// <summary>
    /// 加载怪
    /// </summary>
    /// <param name="index"></param>
    /// <param name="onComplete"></param>
    private void LoadMonster(int index, Action onComplete)
    {
        int monsterId = m_MonsterId[index];
        //RoleMgr.Instance.LoadSprite(monsterId,
        //    (GameObject obj) =>
        //    {
        //        PrefabPool prefabPool = new PrefabPool(obj.transform);
        //        prefabPool.preloadAmount = 5; //预加载数量
        //        m_MonsterPool.CreatePrefabPool(prefabPool);

        //        index++;

        //        if (index == m_MonsterId.Length)
        //        {
        //            //加载完毕
        //            if (onComplete != null)
        //            {
        //                onComplete();
        //            }
        //        }
        //        else
        //        {
        //            //进行递归
        //            LoadMonster(index, onComplete);
        //        }
        //    });

    }

    /// <summary>
    /// 怪加载完毕
    /// </summary>
    private void OnLoadMonsterCallBack()
    {
        //怪加载完毕后 进入第一个区域
        m_CurrRegionIndex = 0;
        EnterRegion(m_CurrRegionIndex);
    }

    //==============================

    /// <summary>
    /// 当前区域是否有怪
    /// </summary>
    /// <returns></returns>
    public bool CurrRegionHasMonster
    {
        get
        {
            return m_CurrRegionKillMonsterCount < m_CurrRegionMonsterCount;
        }
    }

    /// <summary>
    /// 当前区域是否是最后一个区域
    /// </summary>
    public bool CurrRegionIsLast
    {
        get
        {
            return m_CurrRegionIndex > m_RegionList.Count - 1;
        }
    }

    /// <summary>
    /// 下一个区域的主角出生点
    /// </summary>
    public Vector3 NextRegionPlayerBornPos
    {
        get
        {
            //根据区域索引号 得到进入了哪个区域
            GameLevelRegionEntity entity = GetRegionEntityByIndex(m_CurrRegionIndex);

            if (entity == null) return Vector3.zero;

            //得到了区域Id
            int regionId = entity.RegionId;
            return GetRegionCtrlByRegionId(regionId).RoleBornPos.position;
        }
    }

    /// <summary>
    /// 根据索引号查询区域实体
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private GameLevelRegionEntity GetRegionEntityByIndex(int index)
    {
        for (int i = 0; i < m_RegionList.Count; i++)
        {
            if (i == index)
            {
                return m_RegionList[i];
            }
        }
        return null;
    }

    /// <summary>
    /// 根据区域编号获取区域控制器
    /// </summary>
    /// <param name="regionId"></param>
    /// <returns></returns>
    private GameLevelRegionCtrl GetRegionCtrlByRegionId(int regionId)
    {
        for (int i = 0; i < AllRegion.Length; i++)
        {
            if (AllRegion[i].RegionId == regionId)
            {
                return AllRegion[i];
            }
        }
        return null;
    }

    /// <summary>
    /// 进去区域
    /// </summary>
    /// <param name="regionIndex">区域索引号</param>
    private void EnterRegion(int regionIndex)
    {
        //根据区域索引号 得到进入了哪个区域
        GameLevelRegionEntity entity = GetRegionEntityByIndex(regionIndex);

        if (entity == null) return;

        //得到了区域Id
        int regionId = entity.RegionId;

        m_CurrRegionCtrl = GetRegionCtrlByRegionId(regionId);
        if (m_CurrRegionCtrl == null) return;

        m_CurrRegionCreateMonsterCount = 0;
        m_CurrRegionKillMonsterCount = 0;

        //销毁本区域的遮挡物体
        if (m_CurrRegionCtrl.RegionMask != null)
        {
            Destroy(m_CurrRegionCtrl.RegionMask);
        }


        //打开通往下个区域的门
        if (regionIndex != 0)
        {
            //使用上次的区域编号
            GameLevelDoorCtrl toNextRegionDoor = m_CurrRegionCtrl.GetToNextRegionDoor(m_CurrRegionId);
            if (toNextRegionDoor != null)
            {
                toNextRegionDoor.gameObject.SetActive(false);
                if (toNextRegionDoor.ConnectToDoor != null)
                {
                    toNextRegionDoor.ConnectToDoor.gameObject.SetActive(false);
                }
            }
        }

        m_CurrRegionId = regionId;

        if (regionIndex == 0)
        {
            //if (GlobalInit.Instance.CurrPlayer != null)
            //{
            //    GlobalInit.Instance.CurrPlayer.Born(m_CurrRegionCtrl.RoleBornPos.position);
            //    GlobalInit.Instance.CurrPlayer.ToIdle(RoleIdleState.IdleFight);

            //    //主角死亡回调
            //    GlobalInit.Instance.CurrPlayer.OnRoleDie = (RoleCtrl ctrl) =>
            //    {
            //        StartCoroutine(ShowFailView());
            //    };
            //}

            //我加载完毕
            //if (DelegateDefine.Instance.OnSceneLoadOk != null)
            //{
            //    DelegateDefine.Instance.OnSceneLoadOk();
            //}
        }

        //刷怪
       // m_CurrRegionMonsterCount = GameLevelMonsterDBModel.Instance.GetGameLevelMonsterCount(m_CurrGameLevelId, m_CurrGrade, regionId);

        //AppDebug.Log("m_CurrRegionMonsterCount=" + m_CurrRegionMonsterCount);

        //List<GameLevelMonsterEntity> lst = GameLevelMonsterDBModel.Instance.GetGameLevelMonster(m_CurrGameLevelId, m_CurrGrade, regionId);
        //for (int i = 0; i < lst.Count; i++)
        //{
        //    if (m_RegionMonsterDic.ContainsKey(lst[i].SpriteId))
        //    {
        //        m_RegionMonsterDic[lst[i].SpriteId] += lst[i].SpriteCount;
        //    }
        //    else
        //    {
        //        m_RegionMonsterDic[lst[i].SpriteId] = lst[i].SpriteCount;
        //    }
        //}
    }


    private IEnumerator ShowFailView()
    {
        yield return new WaitForSeconds(3f);
        //GameLevelCtrl.Instance.OpenView(WindowUIType.GameLevelFail);
    }

    /// <summary>
    /// 下次刷怪时间
    /// </summary>
    private float m_NextCreateMonsterTime = 0;

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (m_IsFighting)
        {
            m_FightTime += Time.deltaTime;

            //AppDebug.Log("m_CurrRegionCreateMonsterCount=" + m_CurrRegionCreateMonsterCount);
            //AppDebug.Log("m_CurrRegionMonsterCount=" + m_CurrRegionMonsterCount);

            if (m_CurrRegionCreateMonsterCount < m_CurrRegionMonsterCount)
            {
                if (Time.time > m_NextCreateMonsterTime)
                {
                    m_NextCreateMonsterTime = Time.time + 1f;

                    CreateMonster();
                }
            }
        }
    }

    private int m_Index = 0;
    /// <summary>
    /// 临时怪的Id
    /// </summary>
    private int m_MonsterTempId = 0;

    private List<int> m_SpriteList;

    /// <summary>
    /// 创建怪
    /// </summary>
    private void CreateMonster()
    {
        ////临时测试语句  就是只是刷一个怪
        //if (m_CurrRegionCreateMonsterCount >= 1) return;

        m_SpriteList.Clear();

        foreach (var item in m_RegionMonsterDic)
        {
            m_SpriteList.Add(item.Key);
        }

        m_Index = UnityEngine.Random.Range(0, m_RegionMonsterDic.Count);

        int monsterId = m_SpriteList[m_Index];

        //从缓存池中取怪
        //Transform transMonster = m_MonsterPool.Spawn(SpriteDBModel.Instance.Get(monsterId).PrefabName);

        //把怪放在怪的出生点

        Transform monsterBornPos = m_CurrRegionCtrl.MonsterBornPos[UnityEngine.Random.Range(0, m_CurrRegionCtrl.MonsterBornPos.Length)];

        //怪的控制器
        //RoleCtrl roleMonsterCtrl = transMonster.GetComponent<RoleCtrl>();
        //RoleInfoMonster monsterInfo = new RoleInfoMonster();

       // SpriteEntity entity = SpriteDBModel.Instance.Get(monsterId);
        //if (entity != null)
        //{
        //    monsterInfo.SpriteEntity = entity;

        //    monsterInfo.RoleId = ++m_MonsterTempId;
        //    monsterInfo.RoleNickName = entity.Name;
        //    monsterInfo.Level = entity.Level;
        //    monsterInfo.MaxHP = monsterInfo.CurrHP = entity.HP;
        //    monsterInfo.MaxMP = monsterInfo.CurrMP = entity.MP;
        //    monsterInfo.Attack = entity.Attack;
        //    monsterInfo.Defense = entity.Defense;
        //    monsterInfo.Hit = entity.Hit;
        //    monsterInfo.Dodge = entity.Dodge;
        //    monsterInfo.Cri = entity.Cri;
        //    monsterInfo.Res = entity.Res;
        //    monsterInfo.Fighting = entity.Fighting;

        //    roleMonsterCtrl.ViewRange = entity.Range_View + 30f; //怪的视野范围
        //    roleMonsterCtrl.Speed = entity.MoveSpeed; //怪的移动速度
        //}

        //roleMonsterCtrl.Init(RoleType.Monster, monsterInfo, new GameLevel_RoleMonsterAI(roleMonsterCtrl, monsterInfo));
        //roleMonsterCtrl.OnRoleDestroy = OnRoleDestroyCallBack;
        //roleMonsterCtrl.OnRoleDie = OnRoleDieCallBack;


        //怪出生
        //roleMonsterCtrl.Born(monsterBornPos.TransformPoint(UnityEngine.Random.Range(-0.5f, 0.5f), 0, UnityEngine.Random.Range(-0.5f, 0.5f)));

        m_RegionMonsterDic[monsterId]--;
        if (m_RegionMonsterDic[monsterId] <= 0)
        {
            m_RegionMonsterDic.Remove(monsterId);
        }

        m_CurrRegionCreateMonsterCount++;
    }

    private void OnRoleDestroyCallBack(Transform obj)
    {
        //角色销毁时候
        //回池
        m_MonsterPool.Despawn(obj);
    }

    /// <summary>
    /// 角色死亡的回调
    /// </summary>
    /// <param name="ctrl"></param>
    //private void OnRoleDieCallBack(RoleCtrl ctrl)
    //{
    //    m_CurrRegionKillMonsterCount++;
    //    //RoleInfoMonster monsterInfo = (RoleInfoMonster)ctrl.CurrRoleInfo;

    //    #region 处理掉落经验和金币
    //    //处理掉落经验和金币
    //    GameLevelMonsterEntity entity = GameLevelMonsterDBModel.Instance.GetGameLevelMonsterEntity(m_CurrGameLevelId, m_CurrGrade, m_CurrRegionId, monsterInfo.SpriteEntity.Id);
    //    if (entity != null)
    //    {
    //        if (entity.Exp > 0)
    //        {
    //            UITipView.Instance.ShowTip(0, string.Format("+{0}", entity.Exp));
    //            GameLevelCtrl.Instance.CurrGameLevelTotalExp += entity.Exp;
    //        }

    //        if (entity.Gold > 0)
    //        {
    //            UITipView.Instance.ShowTip(1, string.Format("+{0}", entity.Gold));
    //            GameLevelCtrl.Instance.CurrGameLevelTotalGold += entity.Gold;
    //        }
    //    }
    //    #endregion

    //    #region 怪物掉落

    //    //掉落的物品列表
    //    List<GoodsEntity> dropList = new List<GoodsEntity>();

    //    //处理怪物掉落装备
    //    //if (entity.DropEquipList != null && entity.DropEquipList.Count > 0)
    //    //{
    //    //    //先计算概率
    //    //    int probability = UnityEngine.Random.Range(1, 101);
    //    //    for (int i = 0; i < entity.DropEquipList.Count; i++)
    //    //    {
    //    //        if (entity.DropEquipList[i].Probability >= probability)
    //    //        {
    //    //            //把掉落的装备加入掉落物品列表
    //    //            dropList.Add(entity.DropEquipList[i]);
    //    //        }
    //    //    }
    //    //}

    //    //处理怪物掉落道具
    //    //if (entity.DropItemList != null && entity.DropItemList.Count > 0)
    //    //{
    //    //    //先计算概率
    //    //    int probability = UnityEngine.Random.Range(1, 101);
    //    //    for (int i = 0; i < entity.DropItemList.Count; i++)
    //    //    {
    //    //        if (entity.DropItemList[i].Probability >= probability)
    //    //        {
    //    //            //把掉落的道具加入掉落物品列表
    //    //            dropList.Add(entity.DropItemList[i]);
    //    //        }
    //    //    }
    //    //}

    //    //处理怪物掉落材料
    //    //if (entity.DropMaterialList != null && entity.DropMaterialList.Count > 0)
    //    //{
    //    //    //先计算概率
    //    //    int probability = UnityEngine.Random.Range(1, 101);
    //    //    for (int i = 0; i < entity.DropMaterialList.Count; i++)
    //    //    {
    //    //        if (entity.DropMaterialList[i].Probability >= probability)
    //    //        {
    //    //            //把掉落的材料加入掉落物品列表
    //    //            dropList.Add(entity.DropMaterialList[i]);
    //    //        }
    //    //    }
    //    //}

    //    //掉落的物品可能会很多 但是每次最多只能掉落两个 80%几率返回1个 20%的几率返回2个
    //    int dropCount = UnityEngine.Random.Range(1, 101) <= 20 ? 2 : 1;

    //    //在掉落列表中，随机找出掉落物品
    //    //for (int i = 0; i < dropCount; i++)
    //    //{
    //    //    if (dropList.Count > 0)
    //    //    {
    //    //        //获取一个随机的索引 （0 - 当前列表的长度）
    //    //        int index = UnityEngine.Random.Range(0, dropList.Count);

    //    //        //AppDebug.Log("怪物掉落了" + dropList[index].Type + " " + dropList[index].Id + "" + dropList[index].Name + " " + dropList[index].Count);

    //    //        //弹出提示
    //    //        UITipView.Instance.ShowTip(dropList[index].Type, dropList[index].Id, dropList[index].Name, dropList[index].Count);
                
                
    //    //        //获取这个索引的物品 加入游戏关卡的列表
    //    //        GameLevelCtrl.Instance.CurrGameLevelGetGoodsList.Add(new GetGoodsEntity() { GoodsType = (int)dropList[index].Type, GoodsId = dropList[index].Id, GoodsCount = dropList[index].Count });

    //    //        //从列表中移除这个索引数据
    //    //        dropList.RemoveAt(index);
    //    //    }
    //    //}

    //    dropList.Clear();
    //    dropList = null;
    //    #endregion

    //    //添加杀怪详情
    //    if (GameLevelCtrl.Instance.CurrGameLevelKillMonsterDic.ContainsKey(monsterInfo.SpriteEntity.Id))
    //    {
    //        GameLevelCtrl.Instance.CurrGameLevelKillMonsterDic[monsterInfo.SpriteEntity.Id] += 1;
    //    }
    //    else
    //    {
    //        GameLevelCtrl.Instance.CurrGameLevelKillMonsterDic[monsterInfo.SpriteEntity.Id] = 1;
    //    }


    //    //如果杀死的怪的数量 大于等于 当前区域的怪的总数
    //    //说明已经可以进入下一个区域
    //    if (m_CurrRegionKillMonsterCount >= m_CurrRegionMonsterCount)
    //    {
    //        m_CurrRegionIndex++;

    //        //判断是否是最后一个区域 0++=1 1>2-1
    //        if (CurrRegionIsLast)
    //        {
    //            m_IsFighting = false;
    //            GameLevelCtrl.Instance.CurrGameLevelPassTime = m_FightTime;
    //            TimeMgr.Instance.ChangeTimeScale(0.3f, 3f);

    //            //弹出胜利界面
    //            //AppDebug.Log("弹出胜利窗口");
    //            StartCoroutine(ShowVictory());
    //            return;
    //        }
    //        //进入下一个区域
    //        EnterRegion(m_CurrRegionIndex);
    //    }
    //}

    private IEnumerator ShowVictory()
    {
        yield return new WaitForSeconds(3f);
        //GameLevelCtrl.Instance.OpenView(WindowUIType.GameLevelVictory);
    }



#if UNITY_EDITOR

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, 0.8f);

        if (AllRegion != null && AllRegion.Length > 0)
        {
            Gizmos.color = Color.cyan;

            for (int i = 0; i < AllRegion.Length; i++)
            {
                Gizmos.DrawLine(this.transform.position, AllRegion[i].gameObject.transform.position);
            }
        }
    }

#endif
}