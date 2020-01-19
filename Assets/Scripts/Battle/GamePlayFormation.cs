using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YouYou;

public class GamePlayFormation : MonoBehaviour
{
    //    /// <summary>
    //    /// 敌人阵型
    //    /// </summary>
    //    public GamePlayFormation foeFormation;
    //    /// <summary>
    //    /// 是否玩家阵型
    //    /// </summary>
    //    public bool isPlayerFormation;
    //    public GamePlayManager Manager { get { return GamePlayManager.Singleton; } }
    //    /// <summary>
    //    /// 角色状态UI字典
    //    /// </summary>
    //    public readonly Dictionary<int, UICharacterStats> UIStats = new Dictionary<int, UICharacterStats>();
    //    public Transform[] containers;
    //    /// <summary>
    //    /// 角色字典
    //    /// </summary>
    //    public readonly Dictionary<int, CharacterEntity> Characters = new Dictionary<int, CharacterEntity>();

    //    private void Start()
    //    {
    //        if (isPlayerFormation)
    //        {
    //            SetFormationCharacters();
    //        }                  
    //    }

    //    /// <summary>
    //    /// 设置阵型角色
    //    /// </summary>
    //    public virtual void SetFormationCharacters()
    //    {
    //        List<Role> Teamlist = RuntimeData.Instance.Team;
    //        ClearCharacters();
    //        for (var i = 0; i < Teamlist.Count; ++i)
    //        {
    //            SetCharacter(i, Teamlist[i]);
    //        }
    //    }

    //    public virtual void SetCharacters(string[] items)
    //    {
    //        ClearCharacters();
    //        for (var i = 0; i < items.Length; ++i)
    //        {
    //            SetCharacter(i, GameEntry.DataTable.GetRole(items[i].ToInt()));
    //        }
    //    }

    //    public void SetCharacter(int position, Role role)
    //    {
    //        var container = containers[position];
    //        container.RemoveAllChildren();
    //        string path = "Characters/" + role.model;
    //        GameObject go = Resources.Load(path) as GameObject;
    //        var character = Instantiate(go).GetComponent<CharacterEntity>();
    //        character.SetFormation(this, position, container);
    //        character.Role = role;
    //        Characters[position] = character;

    //        if (character == null)
    //            return;

    //        UICharacterStats uiStats;
    //        if (UIStats.TryGetValue(position, out uiStats))
    //        {
    //            Destroy(uiStats.gameObject);
    //            UIStats.Remove(position);
    //        }

    //        if (Manager != null)
    //        {
    //            uiStats = Instantiate(Manager.uiCharacterStatsPrefab, Manager.uiCharacterStatsContainer);
    //            uiStats.transform.localScale = Vector3.one;
    //            uiStats.character = character;
    //            character.uiCharacterStats = uiStats;
    //        }
    //    }

    //    /// <summary>
    //    /// 清除角色
    //    /// </summary>
    //    public virtual void ClearCharacters()
    //    {
    //        foreach (var container in containers)
    //        {
    //            container.RemoveAllChildren();
    //        }
    //        Characters.Clear();
    //    }

    //    public void Revive()
    //    {
    //        var characters = Characters.Values;
    //        foreach (var character in characters)
    //        {
    //            character.Revive();
    //        }
    //    }

    //    public bool IsAnyCharacterAlive()
    //    {
    //        var characters = Characters.Values;
    //        foreach (var character in characters)
    //        {
    //            if (character.Hp > 0)
    //                return true;
    //        }
    //        return false;
    //    }

    //    public bool TryGetHeadingToFoeRotation(out Quaternion rotation)
    //    {
    //        if (foeFormation != null)
    //        {
    //            var rotateHeading = foeFormation.transform.position - transform.position;
    //            rotation = Quaternion.LookRotation(rotateHeading);
    //            return true;
    //        }
    //        rotation = Quaternion.identity;
    //        return false;
    //    }

    //    public void SetActiveDeadCharacters(bool isActive)
    //    {
    //        var characters = Characters.Values;
    //        foreach (var character in characters)
    //        {
    //            if (character.Hp <= 0)
    //                character.gameObject.SetActive(isActive);
    //        }
    //    }

    //    public UnityEngine.Coroutine ForceCharactersPlayMoving(float duration)
    //    {
    //        return StartCoroutine(ForceCharactersPlayMovingRoutine(duration));
    //    }

    //    private IEnumerator ForceCharactersPlayMovingRoutine(float duration)
    //    {
    //        var characters = Characters.Values;
    //        foreach (var character in characters)
    //        {
    //            var castedCharacter = character as CharacterEntity;
    //            castedCharacter.forcePlayMoving = true;
    //        }
    //        yield return new WaitForSeconds(duration);
    //        foreach (var character in characters)
    //        {
    //            var castedCharacter = character as CharacterEntity;
    //            castedCharacter.forcePlayMoving = false;
    //        }
    //    }

    //    public void SetCharactersSelectable(bool selectable)
    //    {
    //        var characters = Characters.Values;
    //        foreach (var character in characters)
    //        {
    //            var castedCharacter = character as CharacterEntity;
    //            castedCharacter.selectable = selectable;
    //        }
    //    }

    //    public int CountDeadCharacters()
    //    {
    //        return Characters.Values.Where(a => a.Hp <= 0).ToList().Count;
    //    }
}
