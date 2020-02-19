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
        NewGame();   
        GameEntry.Scene.LoadScene(SceneId.DaLi,true, onComplete: () =>
        {
            GameEntry.Procedure.ChangeState(ProcedureState.WorldMap);
        });
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

    /// <summary>
    /// 新游戏
    /// </summary>
    public void NewGame()
    {
        Debug.Log("开始新游戏 添加初始数据");
        GameEntry.Data.RuntimeDataManager.Money = 0; ;
        GameEntry.Data.RuntimeDataManager.addTeamMember(1);
        //RuntimeData.Instance.addItem(ItemInstance.Generate("大还丹", false), 10);
        GameEntry.Data.RuntimeDataManager.AutoAcceptMisson();
    }
}
