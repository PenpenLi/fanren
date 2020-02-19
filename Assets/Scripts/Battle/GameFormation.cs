using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YouYou;

public class GameFormation : MonoBehaviour
{
    /// <summary>
    /// 敌人阵型
    /// </summary>
    public GameFormation foeFormation;
    /// <summary>
    /// 是否玩家阵型
    /// </summary>
    public bool isPlayerFormation;

    //    /// <summary>
    //    /// 角色状态UI字典
    //    /// </summary>
    //    public readonly Dictionary<int, UICharacterStats> UIStats = new Dictionary<int, UICharacterStats>();

    public Transform[] containers;

    /// <summary>
    /// 角色字典
    /// </summary>
    public readonly Dictionary<int, RoleCtrl> Characters = new Dictionary<int, RoleCtrl>();

    public void SetCharacters(List<RoleInfo> items)
    {
        ClearCharacters();
        for (var i = 0; i < items.Count; ++i)
        {
            GameObject gameObject = null;
            GameEntry.Role.CreateRole("zhujiao_cike_animation", (ResourceEntity resourceEntity) =>
            {
                gameObject = UnityEngine.Object.Instantiate(resourceEntity.Target as GameObject);
            });
            RoleCtrl ctrl = gameObject.GetComponent<RoleCtrl>();
            //gameObject.layer = LayerMask.NameToLayer("zhujue");//设置层 
            ctrl.Init(RoleType.MainPlayer, items[i], new RoleMainPlayerCityAI(ctrl));
            Characters[i] = ctrl;//添加到角色列表
            GameEntry.Role.AddRole(ctrl);//添加到角色列表

            gameObject.SetParent(transform);
            gameObject.transform.localPosition = containers[i].position;//设置根节点 
            gameObject.transform.localRotation = containers[i].rotation;

            ctrl.SetFormation(this, i, containers[i]);
        }
    }

    /// <summary>
    /// 清除角色
    /// </summary>
    public virtual void ClearCharacters()
    {
        foreach (var container in containers)
        {
            int childCount = container.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Destroy(container.GetChild(0).gameObject);
            }
        }
        Characters.Clear();
    }

    public bool IsAnyCharacterAlive()
    {
        var characters = Characters.Values;
        foreach (var character in characters)
        {
            if (character.CurrRoleInfo.CurrHP > 0)
                return true;
        }
        return false;
    }

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

    /// <summary>
    /// 设置角色选择标记
    /// </summary>
    /// <param name="selectable"></param>
    public void SetCharactersSelectable(bool selectable)
    {
        var characters = Characters.Values;
        foreach (var character in characters)
        {
            var castedCharacter = character as RoleCtrl;
            castedCharacter.selectable = selectable;
        }
    }

    //    public int CountDeadCharacters()
    //    {
    //        return Characters.Values.Where(a => a.Hp <= 0).ToList().Count;
    //    }
}
