using UnityEngine;
using System.Collections;
using Pathfinding;
using System;
using System.Collections.Generic;
using YouYou;

/// <summary>
/// 角色控制器
/// </summary>
[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(FunnelModifier))]
public class RoleCtrl : MonoBehaviour
{
    #region 成员变量或属性
    /// <summary>
    /// 昵称挂点
    /// </summary>
    [SerializeField]
    private Transform m_HeadBarPos;

    /// <summary>
    /// 头顶UI条
    /// </summary>
    private GameObject m_HeadBar;

    /// <summary>
    /// 动画
    /// </summary>
    [SerializeField]
    public Animator Animator;

    /// <summary>
    /// 移动的目标点
    /// </summary>
    [HideInInspector]
    public Vector3 TargetPos = Vector3.zero;

    /// <summary>
    /// 控制器
    /// </summary>
    [HideInInspector]
    public CharacterController CharacterController;

    /// <summary>
    /// 移动速度
    /// </summary>
    [SerializeField]
    public float Speed = 10f;

    /// <summary>
    /// 出生点
    /// </summary>
    [HideInInspector]
    public Vector3 BornPoint;

    /// <summary>
    /// 视野范围
    /// </summary>
    public float ViewRange;

    /// <summary>
    /// 巡逻范围
    /// </summary>
    public float PatrolRange;

    /// <summary>
    /// 当前角色类型
    /// </summary>
    public RoleType CurrRoleType = RoleType.None;

    /// <summary>
    /// 死亡声音名称
    /// </summary>
    [SerializeField]
    private string DieAudioName;

    /// <summary>
    /// 当前角色信息
    /// </summary>
    public RoleInfoBase CurrRoleInfo = null;

    /// <summary>
    /// 当前角色AI
    /// </summary>
    public IRoleAI CurrRoleAI = null;

    /// <summary>
    /// 锁定敌人
    /// </summary>
    [HideInInspector]
    public RoleCtrl LockEnemy;

    /// <summary>
    /// 角色受伤委托
    /// </summary>
    public System.Action OnRoleHurt;

    /// <summary>
    /// 角色死亡
    /// </summary>
    public System.Action<RoleCtrl> OnRoleDie;

    /// <summary>
    /// 角色是否已经死亡
    /// </summary>
    [HideInInspector]
    public bool IsDied;

    ///// <summary>
    ///// 数值变化委托
    ///// </summary>
    ///// <param name="type"></param>
    //public delegate void OnValueChangeHandler(ValueChangeType type);

    ///// <summary>
    ///// HP变化
    ///// </summary>
    //public OnValueChangeHandler OnHPChange;

    ///// <summary>
    ///// MP变化
    ///// </summary>
    //public OnValueChangeHandler OnMPChange;

    public Dictionary<int, OperableItemBase> EnableOperableList = new Dictionary<int, OperableItemBase>();

    /// <summary>
    /// 当前角色有限状态机管理器
    /// </summary>
    public RoleFSMMgr CurrRoleFSMMgr = null;

    private RoleHeadBarView roleHeadBarView = null;

    //======================寻路相关============================
    [HideInInspector]
    private Seeker m_Seeker;

    public Seeker Seeker
    {
        get { return m_Seeker; }
    }

    /// <summary>
    /// 路径
    /// </summary>
    [HideInInspector]
    public ABPath AStartPath;

    /// <summary>
    /// 当前要去的路径点索引
    /// </summary>
    [HideInInspector]
    public int AStartCurrWayPointIndex = 1;

    //=========================战斗相关=================

    /// <summary>
    /// 角色销毁委托
    /// </summary>
    public Action<Transform> OnRoleDestroy;

    /// <summary>
    /// 上次战斗的时间
    /// </summary>
    [HideInInspector]
    public float PrevFightTime = 0f;

    /// <summary>
    /// 是否初始化
    /// </summary>
    private bool m_IsInit = false;

    #endregion

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="roleType">角色类型</param>
    /// <param name="roleInfo">角色信息</param>
    /// <param name="ai">AI</param>
    public void Init(RoleType roleType, RoleInfoBase roleInfo, IRoleAI ai)
    {
        CurrRoleType = roleType;
        //CurrRoleInfo = roleInfo;
        //CurrRoleAI = ai;

        if (CharacterController != null)
        {
            CharacterController.enabled = true;
        }

        //PrevFightTime = 0;
        IsDied = false;
        m_IsInit = true;
    }

    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

        //寻路 计算路径的类
        m_Seeker = GetComponent<Seeker>();

        CurrRoleFSMMgr = new RoleFSMMgr(this, OnDieCallBack, OnDestroyCallBack);
        //m_Hurt = new RoleHurt(CurrRoleFSMMgr);
        //m_Hurt.OnRoleHurt = OnRoleHurtCallBack;
        //Attack.SetFSM(CurrRoleFSMMgr);

        if(CurrRoleType== RoleType.MainPlayer)
        {
            AddPlayerHotKey();
        }
    }

    private void AddPlayerHotKey()
    {
        GameEntry.Event.CommonEvent.AddEventListener(KeyCodeEventId.F, Operable);
    }

    private void Operable(object userData)
    {
        Debug.Log("按下F键");
        float num = float.MaxValue;
        List<OperableItemBase> list = new List<OperableItemBase>();
        List<OperableItemBase> list2 = new List<OperableItemBase>();
        foreach (KeyValuePair<int, OperableItemBase> keyValuePair in this.EnableOperableList)
        {
            //if (!keyValuePair.Value.useAble)
            //{
            //    list.Add(keyValuePair.Value);
            //}
            //else
            //{
            //    float num2 = Vector3.Distance(base.GetPos(), keyValuePair.Value.GetPos());
            //    if (num2 <= num && num2 < 2f)
            //    {
            //        num = num2;
            //        OperableItemBase value = keyValuePair.Value;
            //        list2.Add(value);
            //    }
            //}
        }
        foreach (OperableItemBase item in list)
        {
            //this.RemoveEnableOperable(item);
        }
        foreach (OperableItemBase operableItemBase in list2)
        {
            operableItemBase.Call();
        }
    }

    private void OnDestroyCallBack()
    {
        //if (OnRoleDestroy != null) OnRoleDestroy(transform);

        //if (SceneMgr.Instance.CurrPlayType == PlayType.PVE && CurrRoleType != RoleType.MainPlayer)
        //{
        //    if (roleHeadBarView != null)
        //    {
        //        Destroy(roleHeadBarView.gameObject);
        //    }
        //}
    }

    /// <summary>
    /// 角色死亡回调
    /// </summary>
    private void OnDieCallBack()
    {
        ////角色死亡时候 禁用了CharacterController
        ////角色复活的时候，要重新启用
        //if (CharacterController != null)
        //{
        //    CharacterController.enabled = false;
        //}

        //if (OnRoleDie != null && CurrRoleInfo != null)
        //{
        //    OnRoleDie(this);
        //}
    }

    //    /// <summary>
    //    /// 角色复活
    //    /// </summary>
    //    /// <param name="state"></param>
    //    public void ToResurgence(RoleIdleState state = RoleIdleState.IdleFight)
    //    {
    //        if (CharacterController != null)
    //        {
    //            CharacterController.enabled = true;
    //        }

    //        PrevFightTime = 0;
    //        CurrRoleInfo.CurrHP = CurrRoleInfo.MaxHP; //满血
    //        CurrRoleInfo.CurrMP = CurrRoleInfo.MaxMP; //满蓝
    //        LockEnemy = null;

    //        if (OnHPChange != null)
    //        {
    //            OnHPChange(ValueChangeType.Add);
    //        }

    //        if (OnMPChange != null)
    //        {
    //            OnMPChange(ValueChangeType.Add);
    //        }

    //        ToIdle(state);
    //    }

    //    /// <summary>
    //    /// 角色受伤的回调
    //    /// </summary>
    //    private void OnRoleHurtCallBack()
    //    {
    //        if (roleHeadBarView != null)
    //        {
    //            roleHeadBarView.SetSliderHP((float)CurrRoleInfo.CurrHP / CurrRoleInfo.MaxHP);
    //        }

    //        if (OnHPChange != null)
    //        {
    //            OnHPChange(ValueChangeType.Subtrack);
    //        }
    //    }

    //    /// <summary>
    //    /// 角色出生
    //    /// </summary>
    //    /// <param name="pos"></param>
    //    public void Born(Vector3 pos)
    //    {
    //        PrevFightTime = 0f;
    //        if (CurrRoleFSMMgr != null)
    //        {
    //            ToIdle();
    //        }
    //        BornPoint = pos;
    //        transform.position = pos;
    //        InitHeadBar();
    //    }

    public void OnUpdate()
    {
        if (CurrRoleFSMMgr != null)
        {
            CurrRoleFSMMgr.OnUpdate();
        }

        ////如果角色没有AI 直接返回
        //if (CurrRoleAI == null) return;
        //CurrRoleAI.DoAI();

        //if (m_IsInit)
        //{
        //    m_IsInit = false;
        //    //角色每次出生 初始化一次状态
        //    if (CurrRoleInfo.CurrHP <= 0)
        //    {
        //        ToDie(isDied: true);
        //    }
        //    else
        //    {
        //        if (this.CurrRoleType == RoleType.Monster)
        //        {
        //            ToIdle(RoleIdleState.IdleFight);
        //        }
        //        else
        //        {
        //            ToIdle();
        //        }
        //    }
        //}

        //if (CharacterController == null) return;

        //让角色贴着地面
        if (!CharacterController.isGrounded)
        {
            CharacterController.Move((transform.position + new Vector3(0, -1000, 0)) - transform.position);
        }

        if (CurrRoleType == RoleType.MainPlayer)
        {
            //AutoSmallMap();
        }
    }

    //    private void AutoSmallMap()
    //    {
    //        if (SmallMapHelper.Instance == null || UIMainCitySmallMapView.Instance == null) return;

    //        SmallMapHelper.Instance.transform.position = transform.position;

    //        UIMainCitySmallMapView.Instance.SmallMap.transform.localPosition = new Vector3(SmallMapHelper.Instance.transform.localPosition.x * -512, SmallMapHelper.Instance.transform.localPosition.z * -512, 1);

    //        UIMainCitySmallMapView.Instance.SmallMapArr.transform.localEulerAngles = new Vector3(0, 0, 360 - transform.eulerAngles.y);
    //    }

    //    /// <summary>
    //    /// 初始化头顶UI条
    //    /// </summary>
    //    private void InitHeadBar()
    //    {
    //        if (RoleHeadBarRoot.Instance == null) return;
    //        if (CurrRoleInfo == null) return;
    //        if (m_HeadBarPos == null) return;

    //        AssetBundleMgr.Instance.LoadOrDownload("Download/Prefab/UIPrefab/UIOther/RoleHeadBar.assetbundle", "RoleHeadBar", (GameObject asset) =>
    //        {
    //            m_HeadBar = Instantiate(asset as GameObject);
    //            m_HeadBar.transform.SetParent(RoleHeadBarRoot.Instance.gameObject.transform);
    //            m_HeadBar.transform.localScale = Vector3.one;


    //            roleHeadBarView = m_HeadBar.GetComponent<RoleHeadBarView>();

    //            //给预设赋值
    //            roleHeadBarView.Init(m_HeadBarPos, CurrRoleInfo.RoleNickName, isShowHPBar: (CurrRoleType == RoleType.MainPlayer || CurrRoleType == RoleType.OTherRole ? false : true), sliderValue: (float)CurrRoleInfo.CurrHP / CurrRoleInfo.MaxHP);

    //        });
    //    }


    //    #region 控制角色方法

    //    public void ToIdle(RoleIdleState state = RoleIdleState.IdleNormal)
    //    {
    //        CurrRoleFSMMgr.ToIdleState = state;
    //        CurrRoleFSMMgr.ChangeState(RoleState.Idle);
    //    }

    /// <summary>
    /// 角色移动
    /// </summary>
    /// <param name="targetPos"></param>
    public void MoveTo(Vector3 targetPos)
    {
        //if (CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Die) return;

        ////如果角色处于僵直状态 则不能移动
        //if (IsRigidity) return;

        //如果目标点不是原点 进行移动
        if (targetPos == Vector3.zero) return;

        TargetPos = targetPos;

        //计算路径
        m_Seeker.StartPath(transform.position, targetPos, (Path p) =>
        {
            if (!p.error)
            {
                AStartPath = (ABPath)p;
                if (Vector3.Distance(AStartPath.endPoint, new Vector3(AStartPath.originalEndPoint.x, AStartPath.endPoint.y, AStartPath.originalEndPoint.z)) > 0.5f)
                {
                    AStartPath = null;
                    return;
                }

                AStartCurrWayPointIndex = 1;
                CurrRoleFSMMgr.ChangeState(RoleState.Run);
            }
            else
            {
                Debug.Log("寻路出错");
                AStartPath = null;
            }
        });
    } 

    //    /// <summary>
    //    /// 发起攻击
    //    /// </summary>
    //    /// <param name="type"></param>
    //    /// <param name="index"></param>
    //    public void ToAttackByIndex(RoleAttackType type, int index)
    //    {
    //        Attack.ToAttackByIndex(type, index);
    //    }

    //    /// <summary>
    //    /// 根据技能编号发起攻击
    //    /// </summary>
    //    /// <param name="type"></param>
    //    /// <param name="skillId"></param>
    //    public bool ToAttack(RoleAttackType type, int skillId)
    //    {
    //        return Attack.ToAttack(type, skillId);
    //    }

    //    /// <summary>
    //    /// 播放攻击动画
    //    /// </summary>
    //    /// <param name="skillId"></param>
    //    public void PlayAttack(int skillId)
    //    {
    //        Attack.PlayAttack(skillId);
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="roleTransferAttackInfo"></param>
    //    public void ToHurt(RoleTransferAttackInfo roleTransferAttackInfo)
    //    {
    //        StartCoroutine(m_Hurt.ToHurt(roleTransferAttackInfo));
    //    }

    //    public void ToDie(bool isDied = false)
    //    {
    //#if !DEBUG_ROLESTATE
    //        IsDied = isDied;
    //        CurrRoleInfo.CurrHP = 0;
    //#endif

    //        PlayAudio(DieAudioName, 0);
    //        CurrRoleFSMMgr.ChangeState(RoleState.Die);

    //        if (SceneMgr.Instance.CurrSceneType == SceneType.GameLevel)
    //        {
    //            //如果是关卡中的怪 则怪死亡就把名字销毁
    //            if (CurrRoleType == RoleType.Monster)
    //            {
    //                if (m_HeadBar != null)
    //                {
    //                    Destroy(m_HeadBar);
    //                }
    //            }
    //        }
    //    }

    //    public void ToSelect()
    //    {
    //        CurrRoleFSMMgr.ChangeState(RoleState.Select);
    //    }

    //    /// <summary>
    //    /// 播放音效
    //    /// </summary>
    //    /// <param name="audioName">音效名称</param>
    //    /// <param name="delayTime">延迟时间</param>
    //    public void PlayAudio(string audioName, float delayTime)
    //    {
    //        StartCoroutine(PlayAudioCoroutine(audioName, delayTime));
    //    }

    //    private IEnumerator PlayAudioCoroutine(string audioName, float delayTime)
    //    {
    //        yield return new WaitForSeconds(delayTime);

    //        AudioEffectMgr.Instance.Play(string.Format("Download/Audio/Fight/{0}.assetbundle", audioName), transform.position, is3D: true);

    //    }

    //    #endregion

    //    #region OnDestroy 销毁
    //    /// <summary>
    //    /// 销毁
    //    /// </summary>
    //    void OnDestroy()
    //    {
    //        if (m_HeadBar != null)
    //        {
    //            Destroy(m_HeadBar);
    //        }
    //    }
    //    #endregion
}