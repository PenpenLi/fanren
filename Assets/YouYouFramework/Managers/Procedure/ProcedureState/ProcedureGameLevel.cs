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
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Log(LogCategory.Procedure, "OnEnter ProcedureGameLevel");

            GameEntry.Camera.cameraState=CameraState.Battle;
            GameEntry.Camera.InitBattle();

            // 设置玩家阵型
            GameEntry.Role.foeFormation.ClearCharacters();
            GameEntry.Role.playerFormation.isPlayerFormation = true;
            GameEntry.Role.playerFormation.foeFormation = GameEntry.Role.foeFormation;
            //设置敌人阵型
            GameEntry.Role.foeFormation.ClearCharacters();
            GameEntry.Role.foeFormation.isPlayerFormation = false;
            GameEntry.Role.foeFormation.foeFormation = GameEntry.Role.playerFormation;

            GameEntry.Role.playerFormation.SetCharacters(GameEntry.RuntimeData.Team);

            GameEntry.Battle.StartGame();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            GameEntry.Battle.OnUpdate();
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
    }
}