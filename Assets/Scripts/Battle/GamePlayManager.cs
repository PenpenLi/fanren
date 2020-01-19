//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.Events;
//using YouYou;

//public class GamePlayManager : BaseGamePlayManager
//{
//    public static string BattleSession { get; private set; }
//    public static int PlayingBattle { get; protected set; }//战斗编号
//    public static GamePlayManager Singleton { get; private set; }
//    public Camera inputCamera;
//    [Header("Formation/Spawning")]
//    public GamePlayFormation playerFormation;
//    public GamePlayFormation foeFormation;
//    public Transform mapCenter;
//    [Header("Speed/Delay")]
//    public float formationMoveSpeed = 5f;
//    public float doActionMoveSpeed = 8f;
//    public float actionDoneMoveSpeed = 10f;
//    public float beforeMoveToNextWaveDelay = 2f;
//    public float moveToNextWaveDelay = 1f;
//    [Header("UI")]
//    public Transform uiCharacterStatsContainer;
//    public UICharacterStats uiCharacterStatsPrefab;
//    public UICharacterActionManager uiCharacterActionManager;
//    public CharacterEntity ActiveCharacter { get; private set; }

//    public GameObject partical_show;            //展示当前行动单位的特效
//    private GameObject thisPartical;            //存储生成的特效

//    /// <summary>
//    /// 地图中心位置
//    /// </summary>
//    public Vector3 MapCenterPosition
//    {
//        get
//        {
//            if (mapCenter == null)
//                return Vector3.zero;
//            return mapCenter.position;
//        }
//    }

//    private void Awake()
//    {
//        Singleton = this;
//        if (inputCamera == null)
//            inputCamera = Camera.main;
//        // 设置UI
//        uiCharacterActionManager.Hide();
//        // 设置玩家阵型
//        playerFormation.isPlayerFormation = true;
//        playerFormation.foeFormation = foeFormation;
//        //设置敌人阵型
//        foeFormation.ClearCharacters();
//        foeFormation.isPlayerFormation = false;
//        foeFormation.foeFormation = playerFormation;

//        BattleEntity battleEntity = GameEntry.DataTable.DataTableManager.BattleDBModel.Get(PlayingBattle);
//        string[] array=battleEntity.Role.Split(',');
//        if (array.Length > 1)
//        {
//            //随机敌人 
//        }
//        else
//        {
//            string[] array2=array[0].Split('_');
//            foeFormation.SetCharacters(array2);//设置敌人
//        }
//        foeFormation.Revive();
//    }

//    private void Start()
//    {
//        NewTurn();
//    }

//    private void Update()
//    {
//        //if (uiPauseGame.IsVisible())
//        //{
//        //    Time.timeScale = 0;
//        //    return;
//        //}

//        //if (IsAutoPlay != isAutoPlayDirty)
//        //{
//        //    if (IsAutoPlay)
//        //    {
//        //        uiCharacterActionManager.Hide();
//        //        if (ActiveCharacter != null)
//        //            ActiveCharacter.RandomAction();
//        //    }
//        //    isAutoPlayDirty = IsAutoPlay;
//        //}

//        //Time.timeScale = !isEnding && IsSpeedMultiply ? 2 : 1;

//        if (Input.GetMouseButtonDown(0) && ActiveCharacter != null && ActiveCharacter.IsPlayerCharacter)
//        {
//            Ray ray = inputCamera.ScreenPointToRay(InputManager.MousePosition());
//            RaycastHit hitInfo;
//            if (!Physics.Raycast(ray, out hitInfo))
//                return;

//            var targetCharacter = hitInfo.collider.GetComponent<CharacterEntity>();
//            if (targetCharacter != null)
//            {
//                if (ActiveCharacter.DoAction(targetCharacter))
//                {
//                    Destroy(thisPartical);          //选择完目标后删除标识当前行动单位的特效
//                    playerFormation.SetCharactersSelectable(false);
//                    foeFormation.SetCharactersSelectable(false);
//                }
//            }
//        }
//    }

//    public void NewTurn()
//    {
//        if (ActiveCharacter != null)
//        {
//            ActiveCharacter.currentTimeCount = 0;
//        }

//        CharacterEntity activatingCharacter = null;
//        var maxTime = int.MinValue;
//        List<CharacterEntity> characters = new List<CharacterEntity>();
//        characters.AddRange(playerFormation.Characters.Values);//把玩家角色加入列表
//        characters.AddRange(foeFormation.Characters.Values);//把敌人角色加入列表
//        for (int i = 0; i < characters.Count; ++i)//进行排序
//        {
//            CharacterEntity character = characters[i] as CharacterEntity;
//            if (character != null)
//            {
//                if (character.Hp > 0)//如果角色血量大于零 没死
//                {
//                    int spd = character.Role.shenfa;//获得角色速度
//                    if (spd <= 0)
//                        spd = 1;
//                    character.currentTimeCount += spd;
//                    if (character.currentTimeCount > maxTime)//速度快的先出手
//                    {
//                        maxTime = character.currentTimeCount;
//                        activatingCharacter = character;
//                    }
//                }
//                else
//                {
//                    character.currentTimeCount = 0;
//                }                 
//            }
//        }
//        ActiveCharacter = activatingCharacter;
//        ActiveCharacter.DecreaseBuffsTurn();//减少Buff
//        ActiveCharacter.DecreaseSkillsTurn();//减少技能CD
//        ActiveCharacter.ResetStates();//重置状态
//        if (ActiveCharacter.Hp > 0)//如果角色没死
//        {
//            //在该单位脚底下显示特效
//            thisPartical = Instantiate(partical_show) as GameObject;

//            thisPartical.SetParent(ActiveCharacter.bodyEffectContainer);

//            if (ActiveCharacter.IsPlayerCharacter)//行动角色如果是玩家
//            {
//                if (IsAutoPlay)//是否自动模式
//                {
//                    ActiveCharacter.RandomAction();
//                }
//                else
//                {
//                    uiCharacterActionManager.Show();
//                }                  
//            }
//            else
//            {
//                ActiveCharacter.RandomAction();//如果是敌人随机行动
//            }           
//        }
//        else
//        {
//            ActiveCharacter.NotifyEndAction();//通知结束行动
//        }
//    }

//    /// <summary>
//    /// This will be called by Character class to show target scopes or do action
//    /// 这将由角色类调用来显示目标范围或do操作
//    /// </summary>
//    /// <param name="character"></param>
//    public void ShowTargetScopesOrDoAction(CharacterEntity character)
//    {
//        var allyTeamFormation = character.IsPlayerCharacter ? playerFormation : foeFormation;
//        var foeTeamFormation = !character.IsPlayerCharacter ? playerFormation : foeFormation;
//        allyTeamFormation.SetCharactersSelectable(false);
//        foeTeamFormation.SetCharactersSelectable(false);
//        if (character.Action == CharacterEntity.ACTION_ATTACK)
//        {
//            foeTeamFormation.SetCharactersSelectable(true);
//        }           
//        else
//        {
//            //switch (character.SelectedSkill.CastedSkill.usageScope)
//            //{
//            //    case SkillUsageScope.Self:
//            //        character.selectable = true;
//            //        break;
//            //    case SkillUsageScope.Ally:
//            //        allyTeamFormation.SetCharactersSelectable(true);
//            //        break;
//            //    case SkillUsageScope.Enemy:
//            //        foeTeamFormation.SetCharactersSelectable(true);
//            //        break;
//            //    case SkillUsageScope.All:
//            //        allyTeamFormation.SetCharactersSelectable(true);
//            //        foeTeamFormation.SetCharactersSelectable(true);
//            //        break;
//            //}
//        }
//    }

//    public List<CharacterEntity> GetAllies(CharacterEntity character)
//    {
//        if (character.IsPlayerCharacter)
//            return playerFormation.Characters.Values.Where(a => a.Hp > 0).ToList();
//        else
//            return foeFormation.Characters.Values.Where(a => a.Hp > 0).ToList();
//    }

//    public List<CharacterEntity> GetFoes(CharacterEntity character)
//    {
//        if (character.IsPlayerCharacter)
//            return foeFormation.Characters.Values.Where(a => a.Hp > 0).ToList();
//        else
//            return playerFormation.Characters.Values.Where(a => a.Hp > 0).ToList();
//    }

//    public void NotifyEndAction(CharacterEntity character)
//    {
//        if (character != ActiveCharacter)
//            return;

//        if (!playerFormation.IsAnyCharacterAlive())
//        {
//            ActiveCharacter = null;
//            StartCoroutine(LoseGameRoutine());
//        }
//        else if (!foeFormation.IsAnyCharacterAlive())
//        {
//            ActiveCharacter = null;
//            //if (CurrentWave >= CastedStage.waves.Length)
//            //{
//            //    StartCoroutine(WinGameRoutine());
//            //    return;
//            //}
//            //StartCoroutine(MoveToNextWave());
//        }
//        else
//            NewTurn();
//    }

//    public override void OnRevive()
//    {
//        base.OnRevive();
//        playerFormation.Revive();
//        NewTurn();
//    }

//    public override int CountDeadCharacters()
//    {
//        return playerFormation.CountDeadCharacters();
//    }

//    /// <summary>
//    /// 设置关卡 设置战斗
//    /// </summary>
//    /// <param name="data"></param>
//    public static void StartBattle(int indx)
//    {
//        PlayingBattle = indx;
//    }
//}
