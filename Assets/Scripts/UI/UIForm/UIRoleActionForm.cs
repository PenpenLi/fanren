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
    public UICharacterAction[] uiActions;

    public ToggleGroup TempToggleGroup;

    public RoleCtrl ActiveCharacter;

    private readonly List<UICharacterAction> UICharacterSkills = new List<UICharacterAction>();

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        ActiveCharacter = (RoleCtrl)userData;
        TempToggleGroup.allowSwitchOff = false;
        var skillIndex = 0;
        foreach (var uiAction in uiActions)
        {
            uiAction.ActionManager = this;
            uiAction.IsOn = false;
            var uiSkill = uiAction;
            if (uiSkill != null)
            {
                uiSkill.skillIndex = skillIndex;
                UICharacterSkills.Add(uiSkill);
                ++skillIndex;
            }
        }
    }

    protected override void OnOpen(object userData)
    {
        base.OnOpen(userData);
        var i = 0;
        for (i = 0; i < uiActions.Length; ++i)
        {
            uiActions[i].IsOn = false;
            if (i == 0)
            {
                uiActions[i].IsOn = true;
            }
        }
        i = 0;
        for (; i < UICharacterSkills.Count; ++i)
        {
            var ui = UICharacterSkills[i];
            ui.Close();
        }
    }

    protected override void OnClose()
    {
        base.OnClose();
    }

    protected override void OnBeforDestroy()
    {
        base.OnBeforDestroy();
    }

    private void Update()
    {
        //if (!IsPlayerCharacterActive || ActiveCharacter.IsDoingAction)//这里位置最好换个
        //{
        //    Hide();
        //    return;
        //}

        //var i = 0;
        //foreach (var skill in Manager.ActiveCharacter.Skills)
        //{
        //    if (i >= UICharacterSkills.Count)
        //        break;
        //    var ui = UICharacterSkills[i];
        //    ui.skill = skill as CharacterSkill;
        //    ui.Show();
        //    ++i;
        //}
        //for (; i < UICharacterSkills.Count; ++i)
        //{
        //    var ui = UICharacterSkills[i];
        //    ui.Hide();
        //}
    }
}
