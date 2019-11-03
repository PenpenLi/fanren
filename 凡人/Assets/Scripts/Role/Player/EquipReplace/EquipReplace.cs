using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

/// <summary>
/// 装备替换
/// </summary>
public class EquipReplace
{
    private Dictionary<ulong, List<GameObject>> wearEffectInstance = new Dictionary<ulong, List<GameObject>>();

    private GameObject roleBody;

    private Role _Player;

    //public List<EquipElement> elementList = new List<EquipElement>();

    private Dictionary<RoleWearEquipPos, string> equipPosDict = new Dictionary<RoleWearEquipPos, string>();

    public EquipReplace(Player player)
	{
		this._Player = player;
		this.Init();
	}

    //public GameObject RoleBody
    //{
    //	get
    //	{
    //		if (this.roleBody == null)
    //		{
    //			if (this._Player._roleType == ROLE_TYPE.RT_PUPPET)
    //			{
    //				this.roleBody = PuppetRole.Instance.roleGameObject.RoleBody;
    //			}
    //			else
    //			{
    //				this.roleBody = Player.Instance.roleGameObject.RoleBody;
    //			}
    //			if (this.roleBody == null)
    //			{
    //				Debug.Log("roleBody is not Instance");
    //			}
    //		}
    //		return this.roleBody;
    //	}
    //	set
    //	{
    //		this.roleBody = value;
    //	}
    //}

    private void Init()
    {
        this.equipPosDict.Add(RoleWearEquipPos.WEAR_SHOULDER, "top");
        this.equipPosDict.Add(RoleWearEquipPos.WEAR_CLOTHES, "body");
        this.equipPosDict.Add(RoleWearEquipPos.WEAR_CUFF, "hand");
        this.equipPosDict.Add(RoleWearEquipPos.WEAR_FOOT, "foot");
    }

    //// Token: 0x06000FDC RID: 4060 RVA: 0x00088E34 File Offset: 0x00087034
    //public void TakeOn(RoleWearEquipPos pos, CItemBase item)
    //{
    //	if (this.RoleBody == null)
    //	{
    //		return;
    //	}
    //	if (this.equipPosDict.ContainsKey(pos))
    //	{
    //		this.Generate(item, pos);
    //		this.CreatWearEffect(item.ITEM_STATIC_ID);
    //	}
    //	if (pos == RoleWearEquipPos.WEAR_WEAPON)
    //	{
    //		EquipCfgType item_CHILDTYPE_ID = (EquipCfgType)item.DynamicData.ITEM_CHILDTYPE_ID;
    //		if (this._Player._roleType == ROLE_TYPE.RT_PUPPET)
    //		{
    //			PuppetRole.Instance.weaponManager.changeWeapon(item_CHILDTYPE_ID, item);
    //		}
    //		else
    //		{
    //			Player.Instance.weaponManager.changeWeapon(item_CHILDTYPE_ID, item);
    //		}
    //	}
    //	this._Player.roleGameObject.ResetRender();
    //}

    //// Token: 0x06000FDD RID: 4061 RVA: 0x00088ED4 File Offset: 0x000870D4
    //public void TakeOff(RoleWearEquipPos pos)
    //{
    //	if (this.RoleBody == null)
    //	{
    //		return;
    //	}
    //	if (this.equipPosDict.ContainsKey(pos))
    //	{
    //		EquipElement equipElement = null;
    //		foreach (EquipElement equipElement2 in this.elementList)
    //		{
    //			if (pos == equipElement2.pos)
    //			{
    //				equipElement = equipElement2;
    //				break;
    //			}
    //		}
    //		if (equipElement != null)
    //		{
    //			this.DestroyWearEffect(equipElement.item.ITEM_STATIC_ID);
    //			this.elementList.Remove(equipElement);
    //			this.UnloadRes(equipElement.item.ITEM_STATIC_ID);
    //		}
    //		this.BuildSkinnedMeshRenderer(false);
    //	}
    //	if (pos == RoleWearEquipPos.WEAR_WEAPON)
    //	{
    //		if (this._Player._roleType == ROLE_TYPE.RT_PUPPET)
    //		{
    //			PuppetRole.Instance.weaponManager.changeWeapon(EquipCfgType.EQCHILD_CT_UNKNOWN);
    //		}
    //		else
    //		{
    //			Player.Instance.weaponManager.changeWeapon(EquipCfgType.EQCHILD_CT_UNKNOWN);
    //		}
    //	}
    //	this._Player.roleGameObject.ResetRender();
    //}

    //// Token: 0x06000FDE RID: 4062 RVA: 0x00088FF4 File Offset: 0x000871F4
    //public void Generate(CItemBase item, RoleWearEquipPos pos)
    //{
    //	string item_RES_PREB = item.DynamicData.ITEM_RES_PREB;
    //	GameObject gameObject = ResourceLoader.Load(item_RES_PREB, typeof(GameObject)) as GameObject;
    //	if (gameObject == null)
    //	{
    //		return;
    //	}
    //	GameObject gameObject2 = (GameObject)LoadMachine.InstantiateObject(gameObject);
    //	foreach (Animation animation in gameObject2.GetComponentsInChildren<Animation>())
    //	{
    //		animation.cullingType = AnimationCullingType.AlwaysAnimate;
    //	}
    //	Transform[] componentsInChildren2 = this.RoleBody.GetComponentsInChildren<Transform>();
    //	SkinnedMeshRenderer[] componentsInChildren3 = gameObject2.GetComponentsInChildren<SkinnedMeshRenderer>(true);
    //	foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren3)
    //	{
    //		EquipElement equipElement = new EquipElement();
    //		equipElement.item = item;
    //		equipElement.pos = pos;
    //		equipElement.skinName = skinnedMeshRenderer.name;
    //		equipElement.materials.AddRange(skinnedMeshRenderer.materials);
    //		CombineInstance item2 = default(CombineInstance);
    //		item2.mesh = skinnedMeshRenderer.sharedMesh;
    //		item2.subMeshIndex = 0;
    //		equipElement.combineInstances.Add(item2);
    //		foreach (Transform transform in skinnedMeshRenderer.bones)
    //		{
    //			foreach (Transform transform2 in componentsInChildren2)
    //			{
    //				if (!(transform2.name != transform.name))
    //				{
    //					equipElement.bones.Add(transform2);
    //					break;
    //				}
    //			}
    //		}
    //		this.elementList.Add(equipElement);
    //	}
    //	UnityEngine.Object.Destroy(gameObject2);
    //	this.BuildSkinnedMeshRenderer(false);
    //}

    //// Token: 0x06000FDF RID: 4063 RVA: 0x000891A0 File Offset: 0x000873A0
    //public void ReGenerate()
    //{
    //	List<EquipElement> list = new List<EquipElement>();
    //	foreach (EquipElement equipElement in this.elementList)
    //	{
    //		list.Add(equipElement);
    //		Debug.LogWarning("ReGenerate:" + equipElement.item.Name);
    //	}
    //	this.elementList.Clear();
    //	foreach (EquipElement equipElement2 in list)
    //	{
    //		this.Generate(equipElement2.item, equipElement2.pos);
    //	}
    //}

    //// Token: 0x06000FE0 RID: 4064 RVA: 0x00089290 File Offset: 0x00087490
    //public void ReGenerateWeapon()
    //{
    //	CItemBase citemBase = Player.Instance.ItemFolder.WearOperate[RoleWearEquipPos.WEAR_WEAPON];
    //	if (citemBase != null)
    //	{
    //		EquipCfgType item_CHILDTYPE_ID = (EquipCfgType)citemBase.DynamicData.ITEM_CHILDTYPE_ID;
    //		if (this._Player._roleType == ROLE_TYPE.RT_PUPPET)
    //		{
    //			PuppetRole.Instance.weaponManager.changeWeapon(item_CHILDTYPE_ID, citemBase);
    //		}
    //		else
    //		{
    //			Player.Instance.weaponManager.changeWeapon(item_CHILDTYPE_ID, citemBase);
    //		}
    //	}
    //}

    //// Token: 0x06000FE1 RID: 4065 RVA: 0x00089300 File Offset: 0x00087500
    //public void ReGenerateAll()
    //{
    //	this.ReGenerate();
    //	this.ReGenerateWeapon();
    //}

    //// Token: 0x06000FE2 RID: 4066 RVA: 0x00089310 File Offset: 0x00087510
    //private static void GetAllElement(EquipElement allElement, EquipElement equipElement)
    //{
    //	foreach (Material item in equipElement.materials)
    //	{
    //		allElement.materials.Add(item);
    //	}
    //	foreach (CombineInstance item2 in equipElement.combineInstances)
    //	{
    //		allElement.combineInstances.Add(item2);
    //	}
    //	foreach (Transform item3 in equipElement.bones)
    //	{
    //		allElement.bones.Add(item3);
    //	}
    //}

    //// Token: 0x06000FE3 RID: 4067 RVA: 0x00089434 File Offset: 0x00087634
    //public void BuildSkinnedMeshRenderer(bool isDress = false)
    //{
    //	EquipElement equipElement = new EquipElement();
    //	foreach (EquipElement equipElement2 in this.elementList)
    //	{
    //		EquipReplace.GetAllElement(equipElement, equipElement2);
    //	}
    //	if (this._Player.roleGameObject.ModelID != 1)
    //	{
    //		return;
    //	}
    //	SkinnedMeshRenderer skinnedMeshRenderer = this.RoleBody.GetComponent<SkinnedMeshRenderer>();
    //	if (skinnedMeshRenderer == null)
    //	{
    //		skinnedMeshRenderer = this.RoleBody.AddComponent<SkinnedMeshRenderer>();
    //	}
    //	skinnedMeshRenderer.sharedMesh = new Mesh();
    //	skinnedMeshRenderer.sharedMesh.CombineMeshes(equipElement.combineInstances.ToArray(), false, false);
    //	skinnedMeshRenderer.bones = equipElement.bones.ToArray();
    //	skinnedMeshRenderer.materials = equipElement.materials.ToArray();
    //	skinnedMeshRenderer.updateWhenOffscreen = true;
    //	this.HideModel(this.RoleBody.transform, isDress);
    //}

    //// Token: 0x06000FE4 RID: 4068 RVA: 0x0008953C File Offset: 0x0008773C
    //public void HideModel(Transform tf, bool isDress = false)
    //{
    //	SkinnedMeshRenderer component = tf.GetComponent<SkinnedMeshRenderer>();
    //	if (component == null)
    //	{
    //		return;
    //	}
    //	if (this._Player.roleGameObject.ModelID != 1)
    //	{
    //		return;
    //	}
    //	foreach (KeyValuePair<RoleWearEquipPos, string> keyValuePair in this.equipPosDict)
    //	{
    //		Transform transform = RoleBaseFun.FindDescendants(tf, keyValuePair.Value);
    //		if (transform)
    //		{
    //			transform.gameObject.SetActive(true);
    //		}
    //	}
    //	foreach (EquipElement equipElement in this.elementList)
    //	{
    //		Transform transform2 = RoleBaseFun.FindDescendants(tf, equipElement.skinName);
    //		if (transform2)
    //		{
    //			transform2.gameObject.SetActive(false);
    //		}
    //	}
    //}

    //// Token: 0x06000FE5 RID: 4069 RVA: 0x00089664 File Offset: 0x00087864
    //public static void CombineMesh(Role role)
    //{
    //	List<EquipElement> list = new List<EquipElement>();
    //	Transform[] componentsInChildren = role.roleGameObject.RoleBody.GetComponentsInChildren<Transform>();
    //	SkinnedMeshRenderer[] componentsInChildren2 = role.roleGameObject.RoleBody.GetComponentsInChildren<SkinnedMeshRenderer>(true);
    //	foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
    //	{
    //		EquipElement equipElement = new EquipElement();
    //		equipElement.skinName = skinnedMeshRenderer.name;
    //		equipElement.materials.AddRange(skinnedMeshRenderer.materials);
    //		CombineInstance item = default(CombineInstance);
    //		item.mesh = skinnedMeshRenderer.sharedMesh;
    //		item.subMeshIndex = 0;
    //		equipElement.combineInstances.Add(item);
    //		foreach (Transform transform in skinnedMeshRenderer.bones)
    //		{
    //			foreach (Transform transform2 in componentsInChildren)
    //			{
    //				if (!(transform2.name != transform.name))
    //				{
    //					equipElement.bones.Add(transform2);
    //					break;
    //				}
    //			}
    //		}
    //		list.Add(equipElement);
    //		UnityEngine.Object.Destroy(skinnedMeshRenderer.gameObject);
    //	}
    //	EquipElement equipElement2 = new EquipElement();
    //	foreach (EquipElement equipElement3 in list)
    //	{
    //		EquipReplace.GetAllElement(equipElement2, equipElement3);
    //	}
    //	SkinnedMeshRenderer skinnedMeshRenderer2 = role.roleGameObject.RoleBody.GetComponent<SkinnedMeshRenderer>();
    //	if (skinnedMeshRenderer2 == null)
    //	{
    //		skinnedMeshRenderer2 = role.roleGameObject.RoleBody.AddComponent<SkinnedMeshRenderer>();
    //	}
    //	skinnedMeshRenderer2.sharedMesh = new Mesh();
    //	skinnedMeshRenderer2.sharedMesh.CombineMeshes(equipElement2.combineInstances.ToArray(), false, false);
    //	skinnedMeshRenderer2.bones = equipElement2.bones.ToArray();
    //	skinnedMeshRenderer2.materials = equipElement2.materials.ToArray();
    //	skinnedMeshRenderer2.updateWhenOffscreen = true;
    //}

    //// Token: 0x06000FE6 RID: 4070 RVA: 0x00089880 File Offset: 0x00087A80
    //private void CreatWearEffect(ulong itemID)
    //{
    //	WearEffectInfo.Data wearEffectData = Singleton<WearEffectInfo>.GetInstance().GetWearEffectData(itemID);
    //	if (wearEffectData == null)
    //	{
    //		return;
    //	}
    //	if (wearEffectData.EffectRssID == null)
    //	{
    //		return;
    //	}
    //	for (int i = 0; i < wearEffectData.EffectRssID.Length; i++)
    //	{
    //		if (wearEffectData.EffectRssID[i] > 0)
    //		{
    //			this.BoneGameObject(wearEffectData.BoneName[i], itemID, wearEffectData.EffectRssID[i], wearEffectData.PosOffset[i], wearEffectData.AngleOffset[i]);
    //		}
    //	}
    //}

    //// Token: 0x06000FE7 RID: 4071 RVA: 0x0008990C File Offset: 0x00087B0C
    //private void DestroyWearEffect(ulong itemID)
    //{
    //	if (!this.wearEffectInstance.ContainsKey(itemID))
    //	{
    //		return;
    //	}
    //	if (this.wearEffectInstance[itemID].Count == 0)
    //	{
    //		return;
    //	}
    //	foreach (GameObject obj in this.wearEffectInstance[itemID])
    //	{
    //		UnityEngine.Object.Destroy(obj);
    //	}
    //	this.wearEffectInstance.Remove(itemID);
    //}

    //// Token: 0x06000FE8 RID: 4072 RVA: 0x000899B0 File Offset: 0x00087BB0
    //private void BoneGameObject(string boneName, ulong wearID, int resID, Vector3 posOf, Vector3 angleOf)
    //{
    //	if (string.IsNullOrEmpty(boneName))
    //	{
    //		return;
    //	}
    //	GameObject gameObject = (GameObject)Singleton<CResourcesStaticManager>.GetInstance().GetRes(resID, typeof(GameObject));
    //	if (gameObject == null)
    //	{
    //		return;
    //	}
    //	Transform transform = RoleBaseFun.FindDescendants(this._Player.roleGameObject.RoleTransform, boneName);
    //	if (transform == null)
    //	{
    //		return;
    //	}
    //	GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject) as GameObject;
    //	gameObject2.transform.parent = transform;
    //	gameObject2.transform.localPosition = posOf;
    //	gameObject2.transform.localEulerAngles = angleOf;
    //	if (!this.wearEffectInstance.ContainsKey(wearID))
    //	{
    //		this.wearEffectInstance.Add(wearID, new List<GameObject>());
    //	}
    //	this.wearEffectInstance[wearID].Add(gameObject2);
    //}

    //// Token: 0x06000FE9 RID: 4073 RVA: 0x00089A7C File Offset: 0x00087C7C
    //private void UnloadRes(ulong itemID)
    //{
    //	KeyValuePair<string, Type>[] itemResource = UtilityRoleResource.GetItemResource((int)itemID);
    //	if (itemResource != null)
    //	{
    //		foreach (KeyValuePair<string, Type> keyValuePair in itemResource)
    //		{
    //			LoadMachine.DeleteAsset(keyValuePair.Key, keyValuePair.Value, true);
    //		}
    //	}
    //	WearEffectInfo.Data wearEffectData = Singleton<WearEffectInfo>.GetInstance().GetWearEffectData(itemID);
    //	if (wearEffectData != null && wearEffectData.EffectRssID != null)
    //	{
    //		for (int j = 0; j < wearEffectData.EffectRssID.Length; j++)
    //		{
    //			if (wearEffectData.EffectRssID[j] > 0)
    //			{
    //				KeyValuePair<string, Type> resPath = UtilityRoleResource.GetResPath(wearEffectData.EffectRssID[j]);
    //				LoadMachine.DeleteAsset(resPath.Key, resPath.Value, false);
    //			}
    //		}
    //	}
    //}
}
