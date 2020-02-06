using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using YouYou;

public class BattleManager : YouYouBaseComponent
{
    public int CurrentWave { get; private set; }

    public BattleEntity m_BattleEntity { get; private set; }

    public RoleCtrl ActiveCharacter { get; private set; }

    public void StartGame()
    {
        CurrentWave = 0;
        m_BattleEntity = GameEntry.DataTable.DataTableManager.BattleDBModel.Get(GameEntry.RuntimeData.CurrBattleID);
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
            if (arr2.Length > 1)
            {
                foes = arr2[Random.Range(0, arr2.Length)].Split('_');
            }
            else
            {
                foes = arr2[0].Split('_');
            }

            for (int i = 0; i < foes.Length; i++)
            {
                string[] arr3 = foes[i].Split('@');
                RoleEntity roleEntity = GameEntry.DataTable.DataTableManager.RoleDBModel.Get(arr3[0].ToInt());
                RoleInfo roleInfo = new RoleInfo();
                roleInfo.RoleId = roleEntity.Id;
                roleInfo.Level = arr3[1].ToInt();
                roleInfo.MaxHP = roleEntity.maxhp;
                roleInfo.CurrHP = roleEntity.maxhp;
                roleInfo.ShenFa = roleEntity.shenfa;
                items.Add(roleInfo);
            }
            GameEntry.Role.foeFormation.SetCharacters(items);
            ++CurrentWave;
        }
    }

    public void NewTurn()
    {
        if (ActiveCharacter != null)
        {
            ActiveCharacter.currentTimeCount = 0;
        }

        RoleCtrl activatingCharacter = null;
        var maxTime = int.MinValue;
        List<RoleCtrl> characters = new List<RoleCtrl>();
        characters.AddRange(GameEntry.Role.playerFormation.Characters.Values);//把玩家角色加入列表
        characters.AddRange(GameEntry.Role.foeFormation.Characters.Values);//把敌人角色加入列表
        for (int i = 0; i < characters.Count; ++i)//进行排序
        {
            RoleCtrl character = characters[i] as RoleCtrl;
            if (character != null)
            {
                if (character.CurrRoleInfo.CurrHP > 0)//如果角色血量大于零 
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
        ActiveCharacter = activatingCharacter;
        //ActiveCharacter.DecreaseBuffsTurn();//减少Buff
        //ActiveCharacter.DecreaseSkillsTurn();//减少技能CD
        ActiveCharacter.ResetStates();//重置状态
        if (ActiveCharacter.CurrRoleInfo.CurrHP > 0)//如果角色没死
        {
            //在该单位脚底下显示特效
            //thisPartical = Instantiate(partical_show) as GameObject;

            //thisPartical.SetParent(ActiveCharacter.bodyEffectContainer);

            if (ActiveCharacter.IsPlayerCharacter)//行动角色如果是玩家
            {
                //if (IsAutoPlay)//是否自动模式
                //{
                //    //ActiveCharacter.RandomAction();
                //}
                //else
                //{
                GameEntry.UI.OpenUIForm(UIFormId.Battle, ActiveCharacter);
                //}
            }
            else
            {
                //ActiveCharacter.RandomAction();//如果是敌人随机行动
            }
        }
        else
        {
            NotifyEndAction(ActiveCharacter);//通知结束行动
        }
    }

    public void NotifyEndAction(RoleCtrl character)
    {
        if (character != ActiveCharacter)
        {
            return;
        }

        if (!GameEntry.Role.playerFormation.IsAnyCharacterAlive())
        {
            ActiveCharacter = null;
            //加载游戏失败
            //StartCoroutine(LoseGameRoutine());
        }
        else if (!GameEntry.Role.foeFormation.IsAnyCharacterAlive())
        {
            //进入下一波战斗
            ActiveCharacter = null;
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

        if (Input.GetMouseButtonDown(0) && ActiveCharacter != null && ActiveCharacter.IsPlayerCharacter)
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
                if (ActiveCharacter.DoAction(targetCharacter))
                {
                    //GameEntry.Role.playerFormation.SetCharactersSelectable(false);
                    //GameEntry.Role.foeFormation.SetCharactersSelectable(false);
                }
            }
        }
    }

    public override void Shutdown()
    {
       
    }
}
