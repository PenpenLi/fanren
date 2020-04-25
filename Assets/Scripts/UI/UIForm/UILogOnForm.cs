using SoftStar.Pal6;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

/// <summary>
/// 登陆面板
/// </summary>
public class UILogOnForm : UIFormBase
{
    private void Start()
    {

    }

    public void OnNewGameBtn()
    {
        Debug.Log("开始新游戏 添加初始数据");
        //GameEntry.Data.RuntimeDataManager.Money = 0; ;
        //GameEntry.Data.RuntimeDataManager.addTeamMember(1);
        ////RuntimeData.Instance.addItem(ItemInstance.Generate("大还丹", false), 10);
        //GameEntry.Data.RuntimeDataManager.AutoAcceptMisson();

        PalMain.GameDifficulty = 0;
        //SaveManager.GameDifficulty = v;
        HPMPDPProperty.StaticData.Reset();
        FightProperty.StaticData.Reset();
        //PalMain.backgroundAudio.ChangeBackMusicImmediate(null);
        this.AfterSetGameDifficulty_NewStart();
    }

    public void OnLoadBtn()
    {
        //LoadPlane.SetActive(true);
    }

    public void OnSystemBtn()
    {
        //SystemPlane.SetActive(true);
    }

    public void OnLoadbackBtn()
    {
        //LoadPlane.SetActive(false);
    }

    public void OnSystembackBtn()
    {
        //SystemPlane.SetActive(false);
    }

    public void AfterSetGameDifficulty_NewStart()
    {
        if (PlayerTeam.Instance != null)
        {
            PlayerTeam.Instance.LoadTeam();
        }
        PalMain.GameBeginTime = Time.fixedTime;
        PalMain.GameTotleTime = 0f;
        PalMain.ChangeMap("SceneEnter", 1, true, true);
    }
}
