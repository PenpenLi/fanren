using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

[RequireComponent(typeof(Toggle))]
public class UIRoleAction : UIFormBase
{
    public Toggle TempToggle;

   //public UISkill uiSkill;
    public Text textRemainsTurns;
    public Image imageRemainsTurnsGage;
    public int SkillId;

    public bool IsOn
    {
        get { return TempToggle.isOn; }
        set { TempToggle.isOn = value; }
    }

    public void OnSelected()
    {
        if (IsOn)
        {
            GameEntry.Battle.ActiveRole.SetAction(SkillId);
        }
    }
}
