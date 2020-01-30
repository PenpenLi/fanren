using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYou
{   
    /// <summary>
    /// 游戏关卡流程
    /// </summary>
    public class ProcedureGameLevel : ProcedureBase
    {
        public int CurrentWave { get; private set; }

        public BattleEntity m_BattleEntity { get; private set; }

        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureGameLevel");
            GameEntry.Camera.cameraState=CameraState.Battle;
            GameEntry.Camera.InitBattle();

            // 设置UI
            //uiCharacterActionManager.Hide();
            // 设置玩家阵型
            GameEntry.Role.foeFormation.ClearCharacters();
            GameEntry.Role.playerFormation.isPlayerFormation = true;
            GameEntry.Role.playerFormation.foeFormation = GameEntry.Role.foeFormation;
            //设置敌人阵型
            GameEntry.Role.foeFormation.ClearCharacters();
            GameEntry.Role.foeFormation.isPlayerFormation = false;
            GameEntry.Role.foeFormation.foeFormation = GameEntry.Role.playerFormation;

            m_BattleEntity = GameEntry.DataTable.DataTableManager.BattleDBModel.Get(GameEntry.RuntimeData.CurrBattleID);          

            CurrentWave = 0;
            NextWave();
            NewTurn();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();

            GameEntry.Log(LogCategory.Procedure, "OnLeave ProcedureGameLevel");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void NextWave()
        {
            //PlayerItem[] characters;
            //StageFoe[] foes;
            //var wave = CastedStage.waves[CurrentWave];
            //if (!wave.useRandomFoes && wave.foes.Length > 0)
            //    foes = wave.foes;
            //else
            //    foes = CastedStage.RandomFoes().foes;
            string[] foes;
            if (m_BattleEntity != null)
            {
                string[] arr1 = m_BattleEntity.Role.Split('|');
                for (int i = 0; i < arr1.Length; i++)
                {
                    string[] arr2 = arr1[i].Split(',');
                    Debug.Log(arr2.Length);
                    if (arr2.Length > 1)
                    {
                        //随机敌人
                        Debug.Log("随机敌人");
                    }
                    else
                    {
                        foes = arr2;
                    }
                }
            }

            //characters = new PlayerItem[foes.Length];
            //for (var i = 0; i < characters.Length; ++i)
            //{
            //    var foe = foes[i];
            //    if (foe != null && foe.character != null)
            //    {
            //        var character = PlayerItem.CreateActorItemWithLevel(foe.character, foe.level);
            //        characters[i] = character;
            //    }
            //}

            //if (characters.Length == 0)
            //    Debug.LogError("Missing Foes Data");

            //foeFormation.SetCharacters(characters);
            //foeFormation.Revive();
            //++CurrentWave;
        }

        public void NewTurn()
        {
            //if (ActiveCharacter != null)
            //    ActiveCharacter.currentTimeCount = 0;

            //CharacterEntity activatingCharacter = null;
            //var maxTime = int.MinValue;
            //List<BaseCharacterEntity> characters = new List<BaseCharacterEntity>();
            //characters.AddRange(playerFormation.Characters.Values);
            //characters.AddRange(foeFormation.Characters.Values);
            //for (int i = 0; i < characters.Count; ++i)
            //{
            //    CharacterEntity character = characters[i] as CharacterEntity;
            //    if (character != null)
            //    {
            //        if (character.Hp > 0)
            //        {
            //            int spd = (int)character.GetTotalAttributes().spd;
            //            if (spd <= 0)
            //                spd = 1;
            //            character.currentTimeCount += spd;
            //            if (character.currentTimeCount > maxTime)
            //            {
            //                maxTime = character.currentTimeCount;
            //                activatingCharacter = character;
            //            }
            //        }
            //        else
            //            character.currentTimeCount = 0;
            //    }
            //}
            //ActiveCharacter = activatingCharacter;
            //ActiveCharacter.DecreaseBuffsTurn();
            //ActiveCharacter.DecreaseSkillsTurn();
            //ActiveCharacter.ResetStates();
            //if (ActiveCharacter.Hp > 0)
            //{
            //    if (ActiveCharacter.IsPlayerCharacter)
            //    {
            //        if (IsAutoPlay)
            //            ActiveCharacter.RandomAction();
            //        else
            //            uiCharacterActionManager.Show();
            //    }
            //    else
            //        ActiveCharacter.RandomAction();
            //}
            //else
            //    ActiveCharacter.NotifyEndAction();
        }
    }
}