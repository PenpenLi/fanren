using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

/// <summary>
/// 战斗面板
/// </summary>
public class UIRoleActionForm : UIFormBase
{
    public UIRoleAction uiActions;

    public ToggleGroup TempToggleGroup;

    private List<UIRoleAction> UIRoleSkills = new List<UIRoleAction>();

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        TempToggleGroup.allowSwitchOff = false;
        for (int i = 0; i < GameEntry.Battle.ActiveRole.CurrRoleInfo.SkillList.Count; ++i)
        {
            GameObject go=Instantiate(uiActions.gameObject);
            go.transform.SetParent(transform);
            go.GetComponent<Toggle>().group = TempToggleGroup;
            UIRoleAction uIRoleAction = go.GetComponent<UIRoleAction>();
            uIRoleAction.SkillId = GameEntry.Battle.ActiveRole.CurrRoleInfo.SkillList[i].SkillId;
            UIRoleSkills.Add(uIRoleAction);
        }     
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        UIRoleSkills[0].IsOn = true;
    }

    protected override void OnClose()
    {
        base.OnClose();
    }

    protected override void OnBeforDestroy()
    {
        base.OnBeforDestroy();
    }
}
