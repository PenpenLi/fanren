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
[RequireComponent(typeof(CharacterController))]
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
    /// 死亡声音名称
    /// </summary>
    [SerializeField]
    private string DieAudioName;

    /// <summary>
    /// 当前角色类型
    /// </summary>
    public RoleType CurrRoleType = RoleType.None;

    /// <summary>
    /// 当前角色信息
    /// </summary>
    public RoleInfo CurrRoleInfo = null;

    /// <summary>
    /// 当前角色AI
    /// </summary>
    public IRoleAI CurrRoleAI = null;

    /// <summary>
    /// 移动目标
    /// </summary>
    [HideInInspector]
    public RoleCtrl targetCharacter;

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

    /// <summary>
    /// 当前时间计数
    /// </summary>
    [HideInInspector]
    public int currentTimeCount;

    public Dictionary<int, OperableItemBase> EnableOperableList = new Dictionary<int, OperableItemBase>();

    /// <summary>
    /// 当前角色有限状态机管理器
    /// </summary>
    public RoleFSMMgr CurrRoleFSMMgr = null;

    //private RoleHeadBarView roleHeadBarView = null;

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
    public string ANIM_KEY_IS_DEAD = "IsDead";
    public string ANIM_KEY_SPEED = "Speed";
    public string ANIM_KEY_ACTION_STATE = "ActionState";
    public string ANIM_KEY_DO_ACTION = "DoAction";
    public string ANIM_KEY_HURT = "Hurt";

    [HideInInspector]
    public bool selectable;

    public bool IsPlayerCharacter { get { return Formation != null && Formation.isPlayerFormation; } }

    public int SkillId { get; private set; }
    public bool IsDoingAction { get; private set; }
    /// <summary>
    /// 行动目标
    /// </summary>
    public RoleCtrl ActionTarget { get; private set; }

    public bool IsMovingToTarget { get; private set; }
    private Coroutine movingCoroutine;

    public GameFormation Formation { get; protected set; }
    public int Position { get; protected set; }
    private bool isReachedTargetCharacter;
    private Vector3 targetPosition;

    public Transform InitialTransform;

    private Transform tempTransform;
    public Transform TempTransform
    {
        get
        {
            if (tempTransform == null)
                tempTransform = GetComponent<Transform>();
            return tempTransform;
        }
    }

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
    public void Init(RoleType roleType, RoleInfo roleInfo, IRoleAI ai)
    {
        CurrRoleType = roleType;
        CurrRoleInfo = roleInfo;
        CurrRoleAI = ai;

        if (CharacterController != null)
        {
            CharacterController.enabled = true;
        }

        IsDied = false;
        m_IsInit = true;
    }

    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

        //寻路 计算路径的类
        m_Seeker = GetComponent<Seeker>();

        CurrRoleFSMMgr = new RoleFSMMgr(this, OnDieCallBack, OnDestroyCallBack);
    }

    public void ResetStates()
    {
        ActionTarget = null;
        IsDoingAction = false;
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

    /// <summary>
    /// 角色出生
    /// </summary>
    /// <param name="pos"></param>
    public void Born(Vector3 pos)
    {
        //PrevFightTime = 0f;
        //if (CurrRoleFSMMgr != null)
        //{
        //    ToIdle();
        //}
        //BornPoint = pos;
        //transform.position = pos;
        //InitHeadBar();
    }

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
            CharacterController.Move((transform.position + new Vector3(0, -100, 0)) - transform.position);
        }
    }

    public void SetFormation(GameFormation formation, int position, Transform container)
    {
        if (container == null)
            return;

        Formation = formation;
        Position = position;
        InitialTransform = container;

        //Quaternion headingRotation;
        //if (CastedFormation.TryGetHeadingToFoeRotation(out headingRotation))
        //{
        //    TempTransform.rotation = headingRotation;
        //    if (Manager != null)
        //        TempTransform.position -= Manager.spawnOffset * TempTransform.forward;
        //}
    }

    public void SetAction(int skillId)
    {
        SkillId = skillId;
        GameEntry.Battle.ShowTargetScopesOrDoAction();
    }

    public bool DoAction(RoleCtrl target)
    {
        if (target == null || target.CurrRoleInfo.CurrHP <= 0)
        {
            return false;
        }

        //不能攻击自己或相同的团队角色
        

        ActionTarget = target;
        DoAction();
        return true;
    }

    private void DoAction()
    {
        //if (IsDoingAction)
        //{
        //    return;
        //}

        //判断是技能攻击还是普通攻击
        //if (Action == ACTION_ATTACK)
        //{
        DoAttackActionRoutine();
        //}           
        //else
        //{
        //    //SelectedSkill.OnUseSkill();
        //    //StartCoroutine(DoSkillActionRoutine());
        //}
    }

    public void DoAttackActionRoutine()
    {

        ////判断是不是范围攻击
        //IsDoingAction = true;
        ////var manager = Manager;
        //AttackAnimationData attackAnimation = null;
        //if (AttackAnimations.Count > 0)
        //    attackAnimation = AttackAnimations[Random.Range(0, AttackAnimations.Count - 1)] as AttackAnimationData;
        //if (!attackAnimation.GetIsRangeAttack())//如果不是范围攻击
        //{
        // 移动到目标角色
        //yield return MoveTo(ActionTarget, GameEntry.Battle.doActionMoveSpeed);
        RunToTarget();
        //}
        // 播放攻击动画
        //if (attackAnimation != null)
        //{
        //    switch (attackAnimation.type)
        //    {
        //        case AnimationDataType.ChangeAnimationByState:
        //            CacheAnimator.SetInteger(ANIM_KEY_ACTION_STATE, attackAnimation.GetAnimationActionState());
        //            break;
        //        case AnimationDataType.ChangeAnimationByClip:
        //            ChangeActionClip(attackAnimation.GetAnimationClip());
        //            CacheAnimator.SetBool(ANIM_KEY_DO_ACTION, true);
        //            break;
        //    }
        //}
        //yield return new WaitForSeconds(attackAnimation.GetHitDuration());
        // 申请伤害
        //Attack(ActionTarget, attackAnimation.GetDamage() as Damage);
        //// 等待赔偿做了
        //while (Damages.Count > 0)
        //{
        //    yield return 0;
        //}
        // End attack
        //var endAttackDuration = attackAnimation.GetAnimationDuration() - attackAnimation.GetHitDuration();
        //if (endAttackDuration < 0)
        //    endAttackDuration = 0;
        //yield return new WaitForSeconds(endAttackDuration);
        //ClearActionState();
        //yield return MoveTo(Container.position, GameEntry.Battle.doActionMoveSpeed);
        //NotifyEndAction();
        //IsDoingAction = false;
    }

    /// <summary>
    /// 攻击者移动到攻击目标前
    /// </summary>
    void RunToTarget()
    {
        //保存移动前的位置和朝向，因为跑回来还要用
        //目标的位置
        //开启移动状态
        MoveTo(ActionTarget.InitialTransform.position);
        GameEntry.Battle.isUnitRunningToTarget = true;
        //移动的控制放到Update里，因为要每一帧判断离目标的距离
    }

    //IEnumerator DoSkillActionRoutine()
    //{
    //    //IsDoingAction = true;
    //    //var skill = SelectedSkill.CastedSkill;
    //    //var skillCastAnimation = skill.castAnimation as SkillCastAnimationData;
    //    //var manager = Manager;
    //    //// Cast
    //    //if (skillCastAnimation.GetCastAtMapCenter())
    //    //    yield return MoveTo(Manager.MapCenterPosition, Manager.doActionMoveSpeed);
    //    //var castEffects = skillCastAnimation.GetCastEffects();
    //    //var effects = new List<GameEffect>();
    //    //if (castEffects != null)
    //    //    effects.AddRange(castEffects.InstantiatesTo(this));
    //    //// Play cast animation
    //    //if (skillCastAnimation != null)
    //    //{
    //    //    switch (skillCastAnimation.type)
    //    //    {
    //    //        case AnimationDataType.ChangeAnimationByState:
    //    //            CacheAnimator.SetInteger(ANIM_KEY_ACTION_STATE, skillCastAnimation.GetAnimationActionState());
    //    //            break;
    //    //        case AnimationDataType.ChangeAnimationByClip:
    //    //            ChangeActionClip(skillCastAnimation.GetAnimationClip());
    //    //            CacheAnimator.SetBool(ANIM_KEY_DO_ACTION, true);
    //    //            break;
    //    //    }
    //    //}
    //    //yield return new WaitForSeconds(skillCastAnimation.GetAnimationDuration());
    //    //ClearActionState();
    //    //foreach (var effect in effects)
    //    //{
    //    //    effect.DestroyEffect();
    //    //}
    //    //effects.Clear();
    //    //// Buffs
    //    //yield return StartCoroutine(ApplyBuffsRoutine());
    //    //// Attacks
    //    //yield return StartCoroutine(SkillAttackRoutine());
    //    //// Move back to formation
    //    //yield return MoveTo(Container.position, Manager.actionDoneMoveSpeed);
    //    //NotifyEndAction();
    //    //IsDoingAction = false;
    //}

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

    /// <summary>
    /// 角色移动
    /// </summary>
    /// <param name="targetPos"></param>
    public void MoveTo(Vector3 targetPos)
    {
        if (CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Die) return;

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

    public void ToIdle()
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Idle);
    }

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

    #region OnDestroy 销毁
    /// <summary>
    /// 销毁
    /// </summary>
    void OnDestroy()
    {
        CurrRoleFSMMgr = null;
        //if (m_HeadBar != null)
        //{
        //    Destroy(m_HeadBar);
        //}
    }
    #endregion
}