using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YouYou;

[RequireComponent(typeof(Toggle))]
public class UICharacterAction : UIFormBase
{
    public UIRoleActionForm ActionManager;

    public Toggle TempToggle;

   // public UISkill uiSkill;
    public Text textRemainsTurns;
    public Image imageRemainsTurnsGage;
    public int skillIndex;
   // public CharacterSkill skill;

    public bool IsOn
    {
        get { return TempToggle.isOn; }
        set { TempToggle.isOn = value; }
    }

    public void OnSelected()
    {
       // ActionManager.ActiveCharacter.SetAction(skillIndex);
    }
}
