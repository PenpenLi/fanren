using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using YouYou;

public class BattleManager : YouYouBaseComponent
{
    public GameFormation PlayerFormation;
    public GameFormation FoeFormation;

    public int CurrentWave { get; private set; }

    public BattleEntity m_BattleEntity { get; private set; }

    public RoleCtrl ActiveRole { get; private set; }

    public RoleCtrl ActiveTarget { get; private set; }

    public float doActionMoveSpeed = 8f;

    public bool isUnitRunningToTarget = false;            //玩家是否为移动至目标状态
    public bool isUnitRunningBack = false;   //玩家是否为返回
    public bool isWaitForPlayerToChooseSkill = false;            //玩家选择技能UI的开关
    private float distanceToTarget;         //当前行动单位到攻击目标的距离
    private float distanceToInitial;

    public bool IsAutoPlay; 

    public void StartGame()
    {
        // 设置玩家阵型
        PlayerFormation.ClearCharacters();
        PlayerFormation.isPlayerFormation = true;
        PlayerFormation.foeFormation = GameEntry.Battle.FoeFormation;
        //设置敌人阵型
        FoeFormation.ClearCharacters();
        FoeFormation.isPlayerFormation = false;
        FoeFormation.foeFormation = GameEntry.Battle.PlayerFormation;


        CurrentWave = 0;
        m_BattleEntity = GameEntry.DataTable.DataTableManager.BattleDBModel.Get(GameEntry.Data.RuntimeDataManager.CurrBattleID);

        PlayerFormation.SetCharacters(GameEntry.Data.RuntimeDataManager.Team);//加载玩家 王家只加载一次，敌人每一波都需要加载

        NextWave();
        NewTurn();
    }

    public void NextWave()
    {
        if (m_BattleEntity != null)
        {
            string[] foes;
            List<RoleInfo> items = new List<RoleInfo>();
            string[] arr1 = m_BattleEntity.Role.Split('|');
            string[] arr2 = arr1[CurrentWave].Split(',');
            if (arr2.Length > 1)//是否是随机敌人
            {
                foes = arr2[Random.Range(0, arr2.Length)].Split('_');
            }
            else
            {
                foes = arr2[0].Split('_');
            }

            for (int i = 0; i < foes.Length; i++)//创建敌人角色
            {
                string[] arr3 = foes[i].Split('@');
                RoleEntity roleEntity = GameEntry.DataTable.DataTableManager.RoleDBModel.Get(arr3[0].ToInt());
                RoleInfo roleInfo = new RoleInfo();
                roleInfo.RoleId = roleEntity.Id;
                roleInfo.Level = arr3[1].ToInt();
                roleInfo.MaxHP = roleEntity.MaxHp;
                roleInfo.CurrHP = roleEntity.MaxHp;
                roleInfo.ShenFa = roleEntity.ShenFa;
                items.Add(roleInfo);
            }
            FoeFormation.SetCharacters(items);
            ++CurrentWave;
        }
    }

    public void NewTurn()
    {
        if (ActiveRole != null)
        {
            ActiveRole.currentTimeCount = 0;
        }

        RoleCtrl activatingCharacter = null;
        var maxTime = int.MinValue;
        List<RoleCtrl> characters = new List<RoleCtrl>();
        characters.AddRange(PlayerFormation.Characters.Values);//把玩家角色加入列表
        characters.AddRange(FoeFormation.Characters.Values);//把敌人角色加入列表
        for (int i = 0; i < characters.Count; ++i)//进行排序
        {
            RoleCtrl character = characters[i] as RoleCtrl;
            if (character != null)
            {
                if (!character.IsDied)//如果角色没有死亡 
                {
                    int spd = character.CurrRoleInfo.ShenFa;
                    character.currentTimeCount += spd;
                    if (character.currentTimeCount > maxTime)//速度快的先出手
                    {
                        maxTime = character.currentTimeCount;
                        activatingCharacter = character;
                    }
                }
                else
                {
                    character.currentTimeCount = 0;
                }
            }
        }
        ActiveRole = activatingCharacter;

        //ActiveCharacter.DecreaseBuffsTurn();//减少Buff
        //ActiveCharacter.DecreaseSkillsTurn();//减少技能CD
        ActiveRole.ResetStates();//重置状态
        if (!ActiveRole.IsDied)//如果角色没死
        {
            //在该单位脚底下显示特效
            //thisPartical = Instantiate(partical_show) as GameObject;

            //thisPartical.SetParent(ActiveCharacter.bodyEffectContainer);

            if (ActiveRole.IsPlayerCharacter)//行动角色如果是玩家
            {
                if (IsAutoPlay)//是否自动模式
                {
                    //ActiveCharacter.RandomAction();//如果是自动模式随机行动
                }
                else
                {
                    GameEntry.UI.OpenUIForm(UIFormId.Battle);//窗口名字要改
                }
            }
            else
            {
                //ActiveCharacter.RandomAction();//如果是敌人随机行动
            }
        }
        else
        {
            NotifyEndAction(ActiveRole);//通知结束行动
        }
    }

    public void NotifyEndAction(RoleCtrl character)
    {
        if (character != ActiveRole)
        {
            return;
        }

        if (!PlayerFormation.IsAnyCharacterAlive())
        {
            ActiveRole = null;
            //加载游戏失败
            //StartCoroutine(LoseGameRoutine());
        }
        else if (!FoeFormation.IsAnyCharacterAlive())
        {
            //进入下一波战斗
            ActiveRole = null;
            //if (CurrentWave >= CastedStage.waves.Length)
            //{
            //    StartCoroutine(WinGameRoutine());
            //    return;
            //}
            //StartCoroutine(MoveToNextWave());
        }
        else
        {
            NewTurn();
        }       
    }

    /// <summary>
    /// 显示攻击范围
    /// </summary>
    /// <param name="character"></param>
    public void ShowTargetScopesOrDoAction()
    {
        isWaitForPlayerToChooseSkill = true;

        var allyTeamFormation = ActiveRole.IsPlayerCharacter ? PlayerFormation : FoeFormation;//自己阵营
        var foeTeamFormation = !ActiveRole.IsPlayerCharacter ? PlayerFormation : FoeFormation;//敌对阵营
        allyTeamFormation.SetCharactersSelectable(false);
        foeTeamFormation.SetCharactersSelectable(false);
        //if (ActiveCharacter.Action == RoleCtrl.ACTION_ATTACK)
        //{
        foeTeamFormation.SetCharactersSelectable(true);
        //}           
        //else
        //{
        //    //switch (ActiveCharacter.SelectedSkill.CastedSkill.usageScope)
        //    //{
        //    //    case SkillUsageScope.Self:
        //    //        character.selectable = true;
        //    //        break;
        //    //    case SkillUsageScope.Ally:
        //    //        allyTeamFormation.SetCharactersSelectable(true);
        //    //        break;
        //    //    case SkillUsageScope.Enemy:
        //    //        foeTeamFormation.SetCharactersSelectable(true);
        //    //        break;
        //    //    case SkillUsageScope.All:
        //    //        allyTeamFormation.SetCharactersSelectable(true);
        //    //        foeTeamFormation.SetCharactersSelectable(true);
        //    //        break;
        //    //}
        //}
    }

    public void OnUpdate()
    {
        //if (uiPauseGame.IsVisible())
        //{
        //    Time.timeScale = 0;
        //    return;
        //}

        //if (IsAutoPlay != isAutoPlayDirty)
        //{
        //    if (IsAutoPlay)
        //    {
        //        uiCharacterActionManager.Hide();
        //        if (ActiveCharacter != null)
        //            ActiveCharacter.RandomAction();
        //    }
        //    isAutoPlayDirty = IsAutoPlay;
        //}

        //Time.timeScale = !isEnding && IsSpeedMultiply ? 2 : 1;
        if (isWaitForPlayerToChooseSkill)
        {
            if (Input.GetMouseButtonDown(0) && ActiveRole != null && ActiveRole.IsPlayerCharacter)
            {
                Ray ray = GameEntry.Camera.MainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (!Physics.Raycast(ray, out hitInfo))
                {
                    return;
                }

                var targetCharacter = hitInfo.collider.GetComponent<RoleCtrl>();
                if (targetCharacter != null)
                {
                    if (ActiveRole.DoAction(targetCharacter))
                    {                        
                        ActiveTarget = targetCharacter;
                        PlayerFormation.SetCharactersSelectable(false);
                        FoeFormation.SetCharactersSelectable(false);
                        isWaitForPlayerToChooseSkill = false;
                    }
                }
            }
        }
        
        if (isUnitRunningToTarget)
        {
            distanceToTarget = Vector3.Distance(ActiveRole.transform.position, ActiveTarget.InitialTransform.position);           //到目标的距离，需要实时计算
            //避免靠近目标时抖动
            if (distanceToTarget < 1.6f)            
            {
                ActiveRole.ToIdle();
                //停止移动
                //关闭移动状态
                isUnitRunningToTarget = false;
                //开始攻击
                LaunchAttack();
            }
        }

        if (isUnitRunningBack)
        {
            distanceToInitial = Vector3.Distance(ActiveRole.transform.position, ActiveRole.InitialTransform.position);           //离初始位置的距离
            if (distanceToInitial <1.1f)      
            {
                ActiveRole.ToIdle();
                //停止移动
                ////关闭移动状态
                isUnitRunningBack = false;
                ////修正到初始位置和朝向
                ActiveRole.transform.rotation = ActiveRole.InitialTransform.rotation;

                ////攻击单位回原位后行动结束，到下一个单位
                //ToBattle();
            }
        }   
    }

    /// <summary>
    /// 当前行动单位执行攻击动作
    /// </summary>
    public void LaunchAttack()
    {
        ////存储攻击者和攻击目标的属性脚本
        //UnitStats attackOwner = currentActUnit.GetComponent<UnitStats>();
        //UnitStats attackReceiver = currentActUnitTarget.GetComponent<UnitStats>();
        ////根据攻防计算伤害
        //attackData = (attackOwner.attack - attackReceiver.defense + Random.Range(-2, 2)) * attackDamageMultiplier;
        ////播放攻击动画
        //ActiveCharacter.CurrRoleFSMMgr.ChangeState(RoleState.Attack);
        ////获取攻击动画长度
        //float attackAnimationTime = currentActUnit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        //float damageAnimationTime = attackAnimationTime * 0.4f;
        float attackAnimationTime = 2;
        float damageAnimationTime = 2;
        //Debug.Log(currentActUnit.name + "使用技能（" + attackTypeName + "）对" + currentActUnitTarget.name + "造成了" + attackData + "点伤害");

        //在对象承受伤害前添加延迟（伤害在动作砍下去就得出现）
        //StartCoroutine(WaitForTakeDamage(damageAnimationTime));

        //下一个单位行动前延时
        StartCoroutine(WaitForRunBack(attackAnimationTime));
    }

    /// <summary>
    /// 延时操作函数，避免在怪物回合操作过快
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForTakeDamage(float time)
    {
        yield return new WaitForSeconds(time);

        //被攻击者承受伤害
        //currentActUnitTarget.GetComponent<UnitStats>().ReceiveDamage(attackData);

        ////实例化伤害字体并设置到画布上（字体位置和内容的控制放在它自身的脚本中）
        //GameObject thisText = Instantiate(bloodText) as GameObject;
        //thisText.transform.SetParent(GameObject.Find("BloodTextGroup").transform, false);

        //if (!currentActUnitTarget.GetComponent<UnitStats>().IsDead())
        //{
        //    currentActUnitTarget.GetComponent<Animator>().SetTrigger("TakeDamage");
        //}
        //else
        //{
        //    currentActUnitTarget.GetComponent<Animator>().SetTrigger("Dead");
        //}

    }

    IEnumerator WaitForRunBack(float time)
    {
        yield return new WaitForSeconds(time);
        //远程单位不需要跑回来，延迟后直接下个单位行动
        //if (currentActUnit.GetComponent<UnitStats>().attackType == 1)
        //{
        //    ToBattle();
        //}
        //else
        //{
        //    //此时开启跑回状态
        ActiveRole.MoveTo(ActiveRole.InitialTransform.position);
        isUnitRunningBack = true;
        //}
    }

    public override void Shutdown()
    {
       
    }
}
