using System;
using System.Collections.Generic;
using UnityEngine;


public class RoleGameObject
{
    private Role m_cRole;

    //   // Token: 0x04002040 RID: 8256
    //   private int m_iModelId;

    //   // Token: 0x04002041 RID: 8257
    //   private float m_fModelScale;

    //   // Token: 0x04002042 RID: 8258
    //   private GameObject m_cGO;

    //   // Token: 0x04002043 RID: 8259
    //   private RoleModelInfo m_cModelInfo;

       private Transform m_cTrans;

    //   // Token: 0x04002045 RID: 8261
    //   private Animation m_cRoleAnimation;

    //   // Token: 0x04002046 RID: 8262
    //   private CharacterController m_cRoleController;

    //   // Token: 0x04002047 RID: 8263
    //   private BindRole m_cRoleBind;

    //   // Token: 0x04002048 RID: 8264
    //   private Renderer[] renderers;

    //   // Token: 0x04002049 RID: 8265
    //   private ColliderCheckCharacterController m_cColliderCheck;

    //   // Token: 0x0400204A RID: 8266
    //   private List<RoleGameObject.BindEffectInfo> m_cEffectList = new List<RoleGameObject.BindEffectInfo>();

    //   // Token: 0x0400204B RID: 8267
    //   private Dictionary<CHILD_EFFECT_POINT, Transform> m_mapEffectTrans = new Dictionary<CHILD_EFFECT_POINT, Transform>();

    //   // Token: 0x0400204C RID: 8268
    //   private Dictionary<CHILD_MESH_POINT, Renderer> m_mapMeshTrans = new Dictionary<CHILD_MESH_POINT, Renderer>();

    //   // Token: 0x0400204D RID: 8269
    //   private Dictionary<CHILD_RAGDOLL_POINT, Rigidbody> m_mapRagDollTrans = new Dictionary<CHILD_RAGDOLL_POINT, Rigidbody>();

    //   // Token: 0x0400204E RID: 8270
    //   private Dictionary<ATTACHMENT, GameObject> m_mapAttachmentGo = new Dictionary<ATTACHMENT, GameObject>();

    //   // Token: 0x0400204F RID: 8271
    //   private Dictionary<CHILD_ARM_POINT, Transform> m_mapArmTrans = new Dictionary<CHILD_ARM_POINT, Transform>();

    //   // Token: 0x04002050 RID: 8272
    //   private Dictionary<HARM_PART, ColliderCheckObject> m_mapHarm = new Dictionary<HARM_PART, ColliderCheckObject>();

    //   // Token: 0x04002051 RID: 8273
    //   private Dictionary<HURT_PART, HurtRoleGameObject> m_mapHurt = new Dictionary<HURT_PART, HurtRoleGameObject>();

    //   // Token: 0x04002052 RID: 8274
    //   private Rigidbody[] rigidbodys;

    //   // Token: 0x04002053 RID: 8275
    //   private SkinnedMeshRenderer[] skinMeshs;

    //   // Token: 0x02000546 RID: 1350
    //   public struct BindEffectInfo
    //   {
    //       // Token: 0x0600242E RID: 9262 RVA: 0x000F4898 File Offset: 0x000F2A98
    //       public BindEffectInfo(GameObject effect, CHILD_EFFECT_POINT type, Vector3 pos, Vector3 euler)
    //       {
    //           this.effectObj = effect;
    //           this.pointType = type;
    //           this.posOffest = pos;
    //           this.eulerOffest = euler;
    //       }

    //       // Token: 0x04002055 RID: 8277
    //       public GameObject effectObj;

    //       // Token: 0x04002056 RID: 8278
    //       public CHILD_EFFECT_POINT pointType;

    //       // Token: 0x04002057 RID: 8279
    //       public Vector3 posOffest;

    //       // Token: 0x04002058 RID: 8280
    //       public Vector3 eulerOffest;
    //   }

    //   public Renderer[] Renderers
    //{
    //	get
    //	{
    //		if (this.renderers == null)
    //		{
    //			this.renderers = this.RoleBody.GetComponentsInChildren<Renderer>(true);
    //		}
    //		return this.renderers;
    //	}
    //}

    //public bool IsHiding { get; private set; }

    //public Dictionary<CHILD_EFFECT_POINT, Transform> EffectTrans
    //{
    //	get
    //	{
    //		return this.m_mapEffectTrans;
    //	}
    //}


    //public Dictionary<CHILD_MESH_POINT, Renderer> MeshTrans
    //{
    //	get
    //	{
    //		return this.m_mapMeshTrans;
    //	}
    //}

    //public Dictionary<CHILD_RAGDOLL_POINT, Rigidbody> RagdollTrans
    //{
    //	get
    //	{
    //		return this.m_mapRagDollTrans;
    //	}
    //}

    //public Dictionary<CHILD_ARM_POINT, Transform> ArmTrans
    //{
    //	get
    //	{
    //		return this.m_mapArmTrans;
    //	}
    //}

    //public Dictionary<ATTACHMENT, GameObject> Attachment
    //{
    //	get
    //	{
    //		return this.m_mapAttachmentGo;
    //	}
    //}

    //public Dictionary<HARM_PART, ColliderCheckObject> HarmPart
    //{
    //	get
    //	{
    //		return this.m_mapHarm;
    //	}
    //}

    //public Dictionary<HURT_PART, HurtRoleGameObject> HurtPart
    //{
    //	get
    //	{
    //		return this.m_mapHurt;
    //	}
    //}

    //public RoleModelInfo ModelInfo
    //{
    //	get
    //	{
    //		return this.m_cModelInfo;
    //	}
    //}

    //public string Name
    //{
    //	get
    //	{
    //		if (this.m_cGO == null)
    //		{
    //			return string.Empty;
    //		}
    //		return this.m_cGO.name;
    //	}
    //}

    //// Token: 0x1700043E RID: 1086
    //// (get) Token: 0x0600240A RID: 9226 RVA: 0x000F3734 File Offset: 0x000F1934
    //public GameObject RoleBody
    //{
    //	get
    //	{
    //		return this.m_cGO;
    //	}
    //}

    //// Token: 0x1700043F RID: 1087
    //// (get) Token: 0x0600240B RID: 9227 RVA: 0x000F373C File Offset: 0x000F193C
    //public BindRole RoleBind
    //{
    //	get
    //	{
    //		if (this.m_cGO == null)
    //		{
    //			return null;
    //		}
    //		if (this.m_cRoleBind == null)
    //		{
    //			this.m_cRoleBind = this.m_cGO.GetComponent<BindRole>();
    //		}
    //		return this.m_cRoleBind;
    //	}
    //}

    public Transform RoleTransform
    {
        get
        {
            return this.m_cTrans;
        }
    }

    //// Token: 0x17000441 RID: 1089
    //// (get) Token: 0x0600240D RID: 9229 RVA: 0x000F3784 File Offset: 0x000F1984
    //public CharacterController RoleController
    //{
    //	get
    //	{
    //		if (this.m_cGO == null)
    //		{
    //			return null;
    //		}
    //		if (this.m_cRoleController == null)
    //		{
    //			this.m_cRoleController = this.m_cGO.GetComponent<CharacterController>();
    //		}
    //		return this.m_cRoleController;
    //	}
    //}

    //// Token: 0x17000442 RID: 1090
    //// (get) Token: 0x0600240E RID: 9230 RVA: 0x000F37C4 File Offset: 0x000F19C4
    //public Animation RoleAnimation
    //{
    //	get
    //	{
    //		if (this.m_cGO == null)
    //		{
    //			return null;
    //		}
    //		if (this.m_cRoleAnimation == null)
    //		{
    //			this.m_cRoleAnimation = this.m_cGO.GetComponent<Animation>();
    //			if (this.m_cRoleAnimation == null)
    //			{
    //				foreach (object obj in this.m_cGO.transform)
    //				{
    //					Transform transform = (Transform)obj;
    //					this.m_cRoleAnimation = transform.GetComponent<Animation>();
    //					if (this.m_cRoleAnimation != null)
    //					{
    //						break;
    //					}
    //				}
    //			}
    //		}
    //		return this.m_cRoleAnimation;
    //	}
    //}

    //// Token: 0x17000443 RID: 1091
    //// (get) Token: 0x0600240F RID: 9231 RVA: 0x000F38A0 File Offset: 0x000F1AA0
    //public BodyColliderBehaviour[] RoleBodyCollider
    //{
    //	get
    //	{
    //		if (this.m_cGO == null)
    //		{
    //			return null;
    //		}
    //		return this.m_cGO.GetComponentsInChildren<BodyColliderBehaviour>();
    //	}
    //}

    //// Token: 0x17000444 RID: 1092
    //// (get) Token: 0x06002410 RID: 9232 RVA: 0x000F38C0 File Offset: 0x000F1AC0
    //public ColliderCheckCharacterController RoleColliderCheck
    //{
    //	get
    //	{
    //		if (this.m_cGO == null)
    //		{
    //			return null;
    //		}
    //		if (this.m_cColliderCheck == null)
    //		{
    //			this.m_cColliderCheck = this.m_cGO.GetComponent<ColliderCheckCharacterController>();
    //		}
    //		return this.m_cColliderCheck;
    //	}
    //}

    //// Token: 0x17000445 RID: 1093
    //// (get) Token: 0x06002411 RID: 9233 RVA: 0x000F3900 File Offset: 0x000F1B00
    //public int ModelID
    //{
    //	get
    //	{
    //		return this.m_iModelId;
    //	}
    //}

    public void Init(Role role)
    {
        this.m_cRole = role;
    }

    //public Rigidbody[] Rigidbodys
    //{
    //	get
    //	{
    //		if (this.m_cGO == null)
    //		{
    //			return null;
    //		}
    //		if (this.rigidbodys == null)
    //		{
    //			this.rigidbodys = this.m_cGO.GetComponentsInChildren<Rigidbody>(true);
    //		}
    //		return this.rigidbodys;
    //	}
    //}

    //// Token: 0x17000447 RID: 1095
    //// (get) Token: 0x06002414 RID: 9236 RVA: 0x000F3958 File Offset: 0x000F1B58
    //public SkinnedMeshRenderer[] SkinMeshRensers
    //{
    //	get
    //	{
    //		if (this.m_cGO == null)
    //		{
    //			return null;
    //		}
    //		if (this.skinMeshs == null)
    //		{
    //			this.skinMeshs = this.m_cGO.GetComponentsInChildren<SkinnedMeshRenderer>(true);
    //		}
    //		return this.skinMeshs;
    //	}
    //}

    //// Token: 0x06002415 RID: 9237 RVA: 0x000F399C File Offset: 0x000F1B9C
    //public void AddMeshMeterial(int meterialId)
    //{
    //	Material material = null;
    //	if (meterialId != 0)
    //	{
    //		material = (Singleton<CResourcesStaticManager>.GetInstance().GetRes(meterialId, typeof(Material)) as Material);
    //	}
    //	if (material == null)
    //	{
    //		return;
    //	}
    //	SkinnedMeshRenderer[] skinMeshRensers = this.SkinMeshRensers;
    //	foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinMeshRensers)
    //	{
    //		if (material != null)
    //		{
    //			skinnedMeshRenderer.materials = new List<Material>
    //			{
    //				skinnedMeshRenderer.renderer.material,
    //				material
    //			}.ToArray();
    //		}
    //	}
    //}

    //// Token: 0x06002416 RID: 9238 RVA: 0x000F3A3C File Offset: 0x000F1C3C
    //public void AddMaterialeffect(int meterialId, float time)
    //{
    //	if (this.RoleBody == null)
    //	{
    //		return;
    //	}
    //	MaterialAdder materialAdder = this.RoleBody.GetComponent<MaterialAdder>();
    //	if (materialAdder == null)
    //	{
    //		materialAdder = this.RoleBody.AddComponent<MaterialAdder>();
    //	}
    //	materialAdder.AddMaterial(meterialId, this, time);
    //}

    //// Token: 0x06002417 RID: 9239 RVA: 0x000F3A88 File Offset: 0x000F1C88
    //public void AddMaterialeffect(int meterialId, float time, float fadeInSpeed, float fadeOutSpeed)
    //{
    //	if (this.RoleBody == null)
    //	{
    //		return;
    //	}
    //	MaterialAdder materialAdder = this.RoleBody.GetComponent<MaterialAdder>();
    //	if (materialAdder == null)
    //	{
    //		materialAdder = this.RoleBody.AddComponent<MaterialAdder>();
    //	}
    //	materialAdder.AddMaterial(meterialId, this, time, fadeInSpeed, fadeOutSpeed);
    //}

    //// Token: 0x06002418 RID: 9240 RVA: 0x000F3AD8 File Offset: 0x000F1CD8
    //public void RemoveMaterialeffect(int meterialId)
    //{
    //	if (this.RoleBody == null)
    //	{
    //		return;
    //	}
    //	MaterialAdder component = this.RoleBody.GetComponent<MaterialAdder>();
    //	if (component == null)
    //	{
    //		return;
    //	}
    //	component.RemoveMaterial(meterialId);
    //}

    //// Token: 0x06002419 RID: 9241 RVA: 0x000F3B18 File Offset: 0x000F1D18
    //public int BindEffect(CHILD_EFFECT_POINT point, int id, Vector3 posOffest, Vector3 eulerOffest)
    //{
    //	if (id <= 0)
    //	{
    //		return -1;
    //	}
    //	if (!this.EffectTrans.ContainsKey(point))
    //	{
    //		return -1;
    //	}
    //	Transform transform = this.EffectTrans[point];
    //	if (transform == null)
    //	{
    //		return -1;
    //	}
    //	int num = SingletonMono<EffectManager>.GetInstance().AddEffectBind(id, transform.gameObject);
    //	if (num < 0)
    //	{
    //		return -1;
    //	}
    //	GameObject @object = Singleton<ActorManager>.GetInstance().GetObject(num);
    //	if (@object == null)
    //	{
    //		return -1;
    //	}
    //	@object.transform.localPosition = posOffest / this.m_fModelScale;
    //	@object.transform.localEulerAngles = eulerOffest;
    //	RoleGameObject.BindEffectInfo item = new RoleGameObject.BindEffectInfo(@object, point, posOffest, eulerOffest);
    //	this.m_cEffectList.Add(item);
    //	this.RemoveEmptyEffect();
    //	return num;
    //}

    //// Token: 0x0600241A RID: 9242 RVA: 0x000F3BD4 File Offset: 0x000F1DD4
    //private void RemoveEmptyEffect()
    //{
    //	for (int i = this.m_cEffectList.Count - 1; i >= 0; i--)
    //	{
    //		if (this.m_cEffectList[i].effectObj == null)
    //		{
    //			this.m_cEffectList.RemoveAt(i);
    //		}
    //	}
    //}

    //// Token: 0x0600241B RID: 9243 RVA: 0x000F3C2C File Offset: 0x000F1E2C
    //public void DetachEffect()
    //{
    //	for (int i = this.m_cEffectList.Count - 1; i >= 0; i--)
    //	{
    //		if (!(this.m_cEffectList[i].effectObj == null))
    //		{
    //			this.m_cEffectList[i].effectObj.transform.parent = null;
    //		}
    //	}
    //}

    //// Token: 0x0600241C RID: 9244 RVA: 0x000F3C9C File Offset: 0x000F1E9C
    //private void CorrectEffect()
    //{
    //	if (this.m_cEffectList.Count <= 0)
    //	{
    //		return;
    //	}
    //	for (int i = this.m_cEffectList.Count - 1; i >= 0; i--)
    //	{
    //		if (!(this.m_cEffectList[i].effectObj == null))
    //		{
    //			Transform transform = this.EffectTrans[this.m_cEffectList[i].pointType];
    //			if (transform == null)
    //			{
    //				transform = this.m_cTrans;
    //			}
    //			this.m_cEffectList[i].effectObj.transform.parent = transform;
    //			this.m_cEffectList[i].effectObj.transform.localPosition = this.m_cEffectList[i].posOffest / this.m_fModelScale;
    //			this.m_cEffectList[i].effectObj.transform.localEulerAngles = this.m_cEffectList[i].eulerOffest;
    //		}
    //	}
    //}

    public void CreatGO(int modelId, Vector3 position, Quaternion rotation)
    {
        this.SetGO(RoleGameObject.CreatRoleGameObject(modelId, position, rotation));
    }

    //// Token: 0x0600241E RID: 9246 RVA: 0x000F3DD4 File Offset: 0x000F1FD4
    //public void DisableBody(bool hide)
    //{
    //	this.RoleBody.SetActive(!hide);
    //	foreach (GameObject gameObject in this.m_mapAttachmentGo.Values)
    //	{
    //		if (gameObject != null)
    //		{
    //			gameObject.SetActive(!hide);
    //		}
    //	}
    //}

    public void SetGO(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        this.SetGO(gameObject);
        if (this.m_cTrans != null)
        {
            this.m_cTrans.position = position;
            this.m_cTrans.rotation = rotation;
        }
    }

    public void SetGO(GameObject gameObject)
    {
        if (gameObject == null)
        {
            return;
        }
        //BindRole component = gameObject.GetComponent<BindRole>();
        //if (component == null)
        //{
        //    return;
        //}
        //ColliderCheckCharacterController colliderCheckCharacterController = gameObject.GetComponent<ColliderCheckCharacterController>();
        //if (colliderCheckCharacterController == null)
        //{
        //    colliderCheckCharacterController = gameObject.AddComponent<ColliderCheckCharacterController>();
        //}
        //colliderCheckCharacterController.ClearHandle();
        //colliderCheckCharacterController.CloseCheck();
        //this.m_cGO = gameObject;
        //this.m_cRoleAnimation = null;
        //this.m_cRoleController = null;
        //this.renderers = null;
        //this.rigidbodys = null;
        //this.m_cRoleBind = component;
        //this.m_iModelId = component.ModelID;
        //this.m_cTrans = this.m_cGO.transform;
        //this.m_fModelScale = this.m_cTrans.localScale.x;
        //this.m_cModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(this.m_iModelId);
        //this.SetBodyInfo(this.m_cTrans);
        //this.CorrectEffect();
    }

    //// Token: 0x06002421 RID: 9249 RVA: 0x000F3F7C File Offset: 0x000F217C
    //public void CloneGO(GameObject clone)
    //{
    //	if (clone == null)
    //	{
    //		return;
    //	}
    //	BindRole component = clone.GetComponent<BindRole>();
    //	if (component == null)
    //	{
    //		return;
    //	}
    //	GameObject go = LoadMachine.InstantiateObject(clone) as GameObject;
    //	this.SetGO(go);
    //}

    //// Token: 0x06002422 RID: 9250 RVA: 0x000F3FC0 File Offset: 0x000F21C0
    //public void DestroyGO()
    //{
    //	UnityEngine.Object.Destroy(this.m_cGO);
    //	foreach (GameObject gameObject in this.m_mapAttachmentGo.Values)
    //	{
    //		if (gameObject != null)
    //		{
    //			UnityEngine.Object.Destroy(gameObject);
    //		}
    //	}
    //	this.m_mapAttachmentGo.Clear();
    //}

    //// Token: 0x06002423 RID: 9251 RVA: 0x000F404C File Offset: 0x000F224C
    //private void SetBodyInfo(Transform root)
    //{
    //	RoleBodyInfo component = root.GetComponent<RoleBodyInfo>();
    //	if (component == null)
    //	{
    //		return;
    //	}
    //	this.m_cRoleController = component.Controller;
    //	this.m_cRoleAnimation = component.Animation;
    //	this.m_mapEffectTrans.Clear();
    //	this.m_mapEffectTrans.Add(CHILD_EFFECT_POINT.TOP, root);
    //	for (int i = 0; i < component.EffectType.Count; i++)
    //	{
    //		if (!this.m_mapEffectTrans.ContainsKey(component.EffectType[i]))
    //		{
    //			this.m_mapEffectTrans.Add(component.EffectType[i], component.EffectTrans[i]);
    //		}
    //	}
    //	this.m_mapArmTrans.Clear();
    //	for (int j = 0; j < component.ArmType.Count; j++)
    //	{
    //		this.m_mapArmTrans.Add(component.ArmType[j], component.ArmTrans[j]);
    //	}
    //	this.m_mapMeshTrans.Clear();
    //	for (int k = 0; k < component.MeshType.Count; k++)
    //	{
    //		this.m_mapMeshTrans.Add(component.MeshType[k], component.Mesh[k]);
    //	}
    //	this.m_mapRagDollTrans.Clear();
    //	for (int l = 0; l < component.RagDollType.Count; l++)
    //	{
    //		this.m_mapRagDollTrans.Add(component.RagDollType[l], component.RagDollRigidbody[l]);
    //	}
    //	this.m_mapHarm.Clear();
    //	for (int m = 0; m < component.HarmPartType.Count; m++)
    //	{
    //		this.m_mapHarm.Add(component.HarmPartType[m], component.HarmCheckPart[m]);
    //		if (component.HarmCheckPart[m] != null)
    //		{
    //			component.HarmCheckPart[m].CloseCheck();
    //			if (this.RoleController != null)
    //			{
    //				Collider[] allCollider = component.HarmCheckPart[m].GetAllCollider();
    //				if (allCollider != null && allCollider.Length > 0)
    //				{
    //					foreach (Collider collider in allCollider)
    //					{
    //						if (collider != null)
    //						{
    //							Physics.IgnoreCollision(collider, this.RoleController);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}
    //	this.m_mapHurt.Clear();
    //	for (int num = 0; num < component.HurtPartType.Count; num++)
    //	{
    //		this.m_mapHurt.Add(component.HurtPartType[num], component.HurtPart[num]);
    //		if (component.HurtPart[num] != null)
    //		{
    //			component.HurtPart[num].SetRole(this.m_cRole);
    //			if (this.RoleController != null)
    //			{
    //				Collider[] collider2 = component.HurtPart[num].GetCollider();
    //				if (collider2 != null)
    //				{
    //					foreach (Collider collider3 in collider2)
    //					{
    //						if (collider3 != null)
    //						{
    //							Physics.IgnoreCollision(collider3, this.RoleController);
    //						}
    //					}
    //				}
    //			}
    //		}
    //	}
    //}

    //// Token: 0x06002424 RID: 9252 RVA: 0x000F43BC File Offset: 0x000F25BC
    //public void AttachWeapon(ATTACHMENT attchPart, HARM_PART harmPart, GameObject weapon)
    //{
    //	if (weapon == null)
    //	{
    //		return;
    //	}
    //	if (!this.m_mapAttachmentGo.ContainsKey(attchPart))
    //	{
    //		this.m_mapAttachmentGo.Add(attchPart, null);
    //	}
    //	this.m_mapAttachmentGo[attchPart] = weapon;
    //	ColliderCheckObject componentInChildren = weapon.GetComponentInChildren<ColliderCheckObject>();
    //	if (componentInChildren != null)
    //	{
    //		componentInChildren.CloseCheck();
    //	}
    //	this.m_mapHarm[harmPart] = componentInChildren;
    //	weapon.SetActive(this.RoleBody.active);
    //	if (this.IsHiding && weapon.transform.parent != null)
    //	{
    //		Renderer[] componentsInChildren = weapon.GetComponentsInChildren<Renderer>();
    //		if (componentsInChildren != null)
    //		{
    //			foreach (Renderer renderer in componentsInChildren)
    //			{
    //				renderer.enabled = false;
    //			}
    //		}
    //	}
    //	this.renderers = null;
    //}

    //// Token: 0x06002425 RID: 9253 RVA: 0x000F4494 File Offset: 0x000F2694
    //public GameObject GetAttachGO(ATTACHMENT attchPart)
    //{
    //	if (this.m_mapAttachmentGo.ContainsKey(attchPart))
    //	{
    //		return this.m_mapAttachmentGo[attchPart];
    //	}
    //	return null;
    //}

    //// Token: 0x06002426 RID: 9254 RVA: 0x000F44B8 File Offset: 0x000F26B8
    //public void EnableRagdoll(bool enable)
    //{
    //	if (this.Rigidbodys == null)
    //	{
    //		return;
    //	}
    //	foreach (Rigidbody rigidbody in this.Rigidbodys)
    //	{
    //		rigidbody.gameObject.layer = 24;
    //		if (rigidbody.GetComponent<Joint>() != null)
    //		{
    //			rigidbody.isKinematic = !enable;
    //			rigidbody.useGravity = enable;
    //			if (rigidbody.collider != null)
    //			{
    //				rigidbody.collider.enabled = enable;
    //			}
    //		}
    //		else if (rigidbody.GetComponent<HurtGameObject>() == null)
    //		{
    //			rigidbody.isKinematic = !enable;
    //			rigidbody.useGravity = enable;
    //			if (rigidbody.collider != null)
    //			{
    //				rigidbody.collider.enabled = enable;
    //			}
    //		}
    //	}
    //}

    //// Token: 0x06002427 RID: 9255 RVA: 0x000F4580 File Offset: 0x000F2780
    //private void SetChild(int modelId)
    //{
    //}

    //// Token: 0x06002428 RID: 9256 RVA: 0x000F4584 File Offset: 0x000F2784
    //public Transform GetEffectTrans(CHILD_EFFECT_POINT key)
    //{
    //	foreach (KeyValuePair<CHILD_EFFECT_POINT, Transform> keyValuePair in this.m_mapEffectTrans)
    //	{
    //		if (keyValuePair.Key == key)
    //		{
    //			return keyValuePair.Value;
    //		}
    //	}
    //	return null;
    //}

    //// Token: 0x06002429 RID: 9257 RVA: 0x000F4600 File Offset: 0x000F2800
    //public void EnableBodyRender(bool enable)
    //{
    //	if (this.renderers == null)
    //	{
    //		this.renderers = this.RoleBody.GetComponentsInChildren<Renderer>(true);
    //	}
    //	if (this.renderers != null)
    //	{
    //		foreach (Renderer renderer in this.renderers)
    //		{
    //			if (!(renderer == null))
    //			{
    //				renderer.enabled = enable;
    //			}
    //		}
    //		this.IsHiding = !enable;
    //	}
    //}

    //// Token: 0x0600242A RID: 9258 RVA: 0x000F4678 File Offset: 0x000F2878
    //public void EnableHurtCollider(bool enable)
    //{
    //	this.RoleController.enabled = enable;
    //	foreach (HurtRoleGameObject hurtRoleGameObject in this.m_mapHurt.Values)
    //	{
    //		if (hurtRoleGameObject != null)
    //		{
    //			Collider[] collider = hurtRoleGameObject.GetCollider();
    //			if (collider != null)
    //			{
    //				foreach (Collider collider2 in collider)
    //				{
    //					if (collider2 != null)
    //					{
    //						collider2.enabled = enable;
    //					}
    //				}
    //			}
    //		}
    //	}
    //}

    //// Token: 0x0600242B RID: 9259 RVA: 0x000F4738 File Offset: 0x000F2938
    //public void ResetRender()
    //{
    //	this.renderers = this.RoleBody.GetComponentsInChildren<Renderer>(true);
    //	this.skinMeshs = null;
    //	if (this.renderers != null)
    //	{
    //		List<SkinnedMeshRenderer> list = new List<SkinnedMeshRenderer>();
    //		foreach (Renderer renderer in this.renderers)
    //		{
    //			if (renderer is SkinnedMeshRenderer)
    //			{
    //				list.Add((SkinnedMeshRenderer)renderer);
    //			}
    //		}
    //		this.skinMeshs = list.ToArray();
    //	}
    //}

    //public static GameObject CreatRoleGameObject(int modelID)
    //{
    //	RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(modelID);
    //	if (roleModelInfo == null)
    //	{
    //		return null;
    //	}
    //	GameObject gameObject = ResourceLoader.Load(roleModelInfo.Path, typeof(GameObject)) as GameObject;
    //	if (gameObject == null)
    //	{
    //		return null;
    //	}
    //	gameObject = (LoadMachine.InstantiateObject(gameObject) as GameObject);
    //	BindRole bindRole = gameObject.AddComponent<BindRole>();
    //	bindRole.SetModelID(modelID);
    //	return gameObject;
    //}

    public static GameObject CreatRoleGameObject(int modelID, Vector3 position, Quaternion rotation)
    {
        RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(modelID);
        if (roleModelInfo == null)
        {
            Debug.LogWarning("modelID:" + modelID);
            return null;
        }
        GameObject gameObject = ResourceLoader.Load(roleModelInfo.Path, typeof(GameObject)) as GameObject;
        if (gameObject == null)
        {
            Debug.LogWarning("modelID:" + roleModelInfo.Path);
            return null;
        }
        //BindRole bindRole = gameObject.AddComponent("BindRole");
        //bindRole.SetModelID(modelID);
        //return gameObject;
        return null;
    }
}
