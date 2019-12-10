using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class RoleGameObject
{
    private Role m_cRole;

    /// <summary>
    /// 模型ID
    /// </summary>
    private int m_iModelId;

    private float m_fModelScale;

    /// <summary>
    /// 游戏物体
    /// </summary>
    private GameObject m_cGO;

    /// <summary>
    /// 角色模型信息
    /// </summary>
    private RoleModelInfo m_cModelInfo;

    private Transform m_cTrans;

    private Animator m_cRoleAnimator;

    /// <summary>
    /// 角色控制器
    /// </summary>
    private CharacterController m_cRoleController;

    private BindRole m_cRoleBind;

    private Renderer[] renderers;

    private ColliderCheckCharacterController m_cColliderCheck;

    private List<RoleGameObject.BindEffectInfo> m_cEffectList = new List<RoleGameObject.BindEffectInfo>();

    /// <summary>
    /// 特效
    /// </summary>
    private Dictionary<CHILD_EFFECT_POINT, Transform> m_mapEffectTrans = new Dictionary<CHILD_EFFECT_POINT, Transform>();

    private Dictionary<CHILD_MESH_POINT, Renderer> m_mapMeshTrans = new Dictionary<CHILD_MESH_POINT, Renderer>();

    private Dictionary<CHILD_RAGDOLL_POINT, Rigidbody> m_mapRagDollTrans = new Dictionary<CHILD_RAGDOLL_POINT, Rigidbody>();

    //private Dictionary<ATTACHMENT, GameObject> m_mapAttachmentGo = new Dictionary<ATTACHMENT, GameObject>();

    /// <summary>
    /// 手臂位置
    /// </summary>
    private Dictionary<CHILD_ARM_POINT, Transform> m_mapArmTrans = new Dictionary<CHILD_ARM_POINT, Transform>();

    private Dictionary<HARM_PART, ColliderCheckObject> m_mapHarm = new Dictionary<HARM_PART, ColliderCheckObject>();

    private Dictionary<HURT_PART, HurtRoleGameObject> m_mapHurt = new Dictionary<HURT_PART, HurtRoleGameObject>();

    private Rigidbody[] rigidbodys;

    //   private SkinnedMeshRenderer[] skinMeshs;

    public struct BindEffectInfo
    {
        public GameObject effectObj;

        public CHILD_EFFECT_POINT pointType;

        public Vector3 posOffest;

        public Vector3 eulerOffest;

        public BindEffectInfo(GameObject effect, CHILD_EFFECT_POINT type, Vector3 pos, Vector3 euler)
        {
            this.effectObj = effect;
            this.pointType = type;
            this.posOffest = pos;
            this.eulerOffest = euler;
        }
    }

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

    public Dictionary<CHILD_EFFECT_POINT, Transform> EffectTrans
    {
        get
        {
            return this.m_mapEffectTrans;
        }
    }


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

    public RoleModelInfo ModelInfo
    {
        get
        {
            return this.m_cModelInfo;
        }
    }

    public string Name
    {
        get
        {
            if (this.m_cGO == null)
            {
                return string.Empty;
            }
            return this.m_cGO.name;
        }
    }

    /// <summary>
    /// 角色物体
    /// </summary>
    public GameObject RoleBody
    {
        get
        {
            return this.m_cGO;
        }
    }

    public BindRole RoleBind
    {
        get
        {
            if (this.m_cGO == null)
            {
                return null;
            }
            if (this.m_cRoleBind == null)
            {
                this.m_cRoleBind = this.m_cGO.GetComponent<BindRole>();
            }
            return this.m_cRoleBind;
        }
    }

    public Transform RoleTransform
    {
        get
        {
            return this.m_cTrans;
        }
    }

    public CharacterController RoleController
    {
        get
        {
            if (this.m_cGO == null)
            {
                return null;
            }
            if (this.m_cRoleController == null)
            {
                this.m_cRoleController = this.m_cGO.GetComponent<CharacterController>();
            }
            return this.m_cRoleController;
        }
    }

    public Animator RoleAnimator
    {
        get
        {
            if (this.m_cGO == null)
            {
                return null;
            }
            if (this.m_cRoleAnimator == null)
            {
                this.m_cRoleAnimator = this.m_cGO.GetComponent<Animator>();
                if (this.m_cRoleAnimator == null)
                {
                    foreach (object obj in this.m_cGO.transform)
                    {
                        Transform transform = (Transform)obj;
                        this.m_cRoleAnimator = transform.GetComponent<Animator>();
                        if (this.m_cRoleAnimator != null)
                        {
                            break;
                        }
                    }
                }
            }
            return this.m_cRoleAnimator;
        }
    }

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

    public int ModelID
    {
        get
        {
            return this.m_iModelId;
        }
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="role"></param>
    public void Init(Role role)
    {
        this.m_cRole = role;
    }

    public Rigidbody[] Rigidbodys
    {
        get
        {
            if (this.m_cGO == null)
            {
                return null;
            }
            if (this.rigidbodys == null)
            {
                this.rigidbodys = this.m_cGO.GetComponentsInChildren<Rigidbody>(true);
            }
            return this.rigidbodys;
        }
    }

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

    public int BindEffect(CHILD_EFFECT_POINT point, int id, Vector3 posOffest, Vector3 eulerOffest)
    {
        if (id <= 0)
        {
            return -1;
        }
        if (!this.EffectTrans.ContainsKey(point))
        {
            return -1;
        }
        Transform transform = this.EffectTrans[point];
        if (transform == null)
        {
            return -1;
        }
        // int num = SingletonMono<EffectManager>.GetInstance().AddEffectBind(id, transform.gameObject);
        //if (num < 0)
        //{
        //    return -1;
        //}
        //GameObject @object = Singleton<ActorManager>.GetInstance().GetObject(num);
        //if (@object == null)
        //{
        //    return -1;
        //}
        //@object.transform.localPosition = posOffest / this.m_fModelScale;
        //@object.transform.localEulerAngles = eulerOffest;
        //RoleGameObject.BindEffectInfo item = new RoleGameObject.BindEffectInfo(@object, point, posOffest, eulerOffest);
        //this.m_cEffectList.Add(item);
        //this.RemoveEmptyEffect();
        //return num;
        return 0;
    }

    private void RemoveEmptyEffect()
    {
        for (int i = this.m_cEffectList.Count - 1; i >= 0; i--)
        {
            if (this.m_cEffectList[i].effectObj == null)
            {
                this.m_cEffectList.RemoveAt(i);
            }
        }
    }

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

    /// <summary>
    /// 更正特效
    /// </summary>
    private void CorrectEffect()
    {
        if (this.m_cEffectList.Count <= 0)
        {
            return;
        }
        for (int i = this.m_cEffectList.Count - 1; i >= 0; i--)
        {
            if (!(this.m_cEffectList[i].effectObj == null))
            {
                Transform transform = this.EffectTrans[this.m_cEffectList[i].pointType];
                if (transform == null)
                {
                    transform = this.m_cTrans;
                }
                this.m_cEffectList[i].effectObj.transform.parent = transform;
                this.m_cEffectList[i].effectObj.transform.localPosition = this.m_cEffectList[i].posOffest / this.m_fModelScale;
                this.m_cEffectList[i].effectObj.transform.localEulerAngles = this.m_cEffectList[i].eulerOffest;
            }
        }
    }

    /// <summary>
    /// 创建对象并设置
    /// </summary>
    /// <param name="modelId">模型ID</param>
    /// <param name="position">位置</param>
    /// <param name="rotation">旋转</param>
    public void CreatGO(int modelId, Vector3 position, Quaternion rotation)
    {
        this.SetGO(RoleGameObject.CreatRoleGameObject(modelId, position, rotation));
    }

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

    /// <summary>
    /// 设置物体
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    public void SetGO(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        this.SetGO(gameObject);
        if (this.m_cTrans != null)
        {
            this.m_cTrans.position = position;
            this.m_cTrans.rotation = rotation;
        }
    }

    /// <summary>
    /// 设置物体
    /// </summary>
    /// <param name="gameObject"></param>
    public void SetGO(GameObject gameObject)
    {
        if (gameObject == null)
        {
            return;
        }

        BindRole component = gameObject.GetComponent<BindRole>();
        if (component == null)
        {
            return;
        }

        ColliderCheckCharacterController colliderCheckCharacterController = gameObject.GetComponent<ColliderCheckCharacterController>();
        if (colliderCheckCharacterController == null)
        {
            colliderCheckCharacterController = gameObject.AddComponent<ColliderCheckCharacterController>();
        }
        colliderCheckCharacterController.ClearHandle();
        colliderCheckCharacterController.CloseCheck();
        this.m_cGO = gameObject;
        this.m_cRoleAnimator = null;
        this.m_cRoleController = null;
        this.renderers = null;
        this.rigidbodys = null;
        this.m_cRoleBind = component;
        this.m_iModelId = component.ModelID;
        this.m_cTrans = this.m_cGO.transform;
        this.m_fModelScale = this.m_cTrans.localScale.x;
        this.m_cModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(this.m_iModelId);
        this.SetBodyInfo(this.m_cTrans);//应该是骨骼信息
        this.CorrectEffect();//特效挂点
    }

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

    /// <summary>
    /// 设置身体信息
    /// </summary>
    /// <param name="root"></param>
    private void SetBodyInfo(Transform root)
    {
        RoleBodyInfo component = root.GetComponent<RoleBodyInfo>();
        if (component == null)
        {
            return;
        }
        this.m_cRoleController = component.Controller;
        this.m_cRoleAnimator = component.Animator;
        this.m_mapEffectTrans.Clear();
        this.m_mapEffectTrans.Add(CHILD_EFFECT_POINT.TOP, root);
        for (int i = 0; i < component.EffectType.Count; i++)
        {
            if (!this.m_mapEffectTrans.ContainsKey(component.EffectType[i]))
            {
                this.m_mapEffectTrans.Add(component.EffectType[i], component.EffectTrans[i]);
            }
        }
        this.m_mapArmTrans.Clear();
        for (int j = 0; j < component.ArmType.Count; j++)
        {
            this.m_mapArmTrans.Add(component.ArmType[j], component.ArmTrans[j]);
        }
        this.m_mapMeshTrans.Clear();
        for (int k = 0; k < component.MeshType.Count; k++)
        {
            this.m_mapMeshTrans.Add(component.MeshType[k], component.Mesh[k]);
        }
        this.m_mapRagDollTrans.Clear();
        for (int l = 0; l < component.RagDollType.Count; l++)
        {
            this.m_mapRagDollTrans.Add(component.RagDollType[l], component.RagDollRigidbody[l]);
        }
        this.m_mapHarm.Clear();
        for (int m = 0; m < component.HarmPartType.Count; m++)
        {
            this.m_mapHarm.Add(component.HarmPartType[m], component.HarmCheckPart[m]);
            if (component.HarmCheckPart[m] != null)
            {
                component.HarmCheckPart[m].CloseCheck();
                if (this.RoleController != null)
                {
                    Collider[] allCollider = component.HarmCheckPart[m].GetAllCollider();
                    if (allCollider != null && allCollider.Length > 0)
                    {
                        foreach (Collider collider in allCollider)
                        {
                            if (collider != null)
                            {
                                Physics.IgnoreCollision(collider, this.RoleController);
                            }
                        }
                    }
                }
            }
        }
        this.m_mapHurt.Clear();
        for (int num = 0; num < component.HurtPartType.Count; num++)
        {
            this.m_mapHurt.Add(component.HurtPartType[num], component.HurtPart[num]);
            if (component.HurtPart[num] != null)
            {
                component.HurtPart[num].SetRole(this.m_cRole);
                if (this.RoleController != null)
                {
                    Collider[] collider2 = component.HurtPart[num].GetCollider();
                    if (collider2 != null)
                    {
                        foreach (Collider collider3 in collider2)
                        {
                            if (collider3 != null)
                            {
                                Physics.IgnoreCollision(collider3, this.RoleController);
                            }
                        }
                    }
                }
            }
        }
    }

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

    /// <summary>
    /// 激活布娃娃系统
    /// </summary>
    /// <param name="enable"></param>
    public void EnableRagdoll(bool enable)
    {
        if (this.Rigidbodys == null)
        {
            return;
        }
        foreach (Rigidbody rigidbody in this.Rigidbodys)
        {
            rigidbody.gameObject.layer = 24;
            //if (rigidbody.GetComponent<Joint>() != null)
            //{
            //    rigidbody.isKinematic = !enable;
            //    rigidbody.useGravity = enable;
            //    if (rigidbody.collider != null)
            //    {
            //        rigidbody.collider.enabled = enable;
            //    }
            //}
            //else if (rigidbody.GetComponent<HurtGameObject>() == null)
            //{
            //    rigidbody.isKinematic = !enable;
            //    rigidbody.useGravity = enable;
            //    if (rigidbody.collider != null)
            //    {
            //        rigidbody.collider.enabled = enable;
            //    }
            //}
        }
    }

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

    /// <summary>
    /// 创建角色物体
    /// </summary>
    /// <param name="modelID">模型ID</param>
    /// <returns></returns>
    public static GameObject CreatRoleGameObject(int modelID)
    {
        RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(modelID);//角色模型信息
        if (roleModelInfo == null)
        {
            return null;
        }
        GameObject gameObject = ResourceLoader.Load(roleModelInfo.Path, typeof(GameObject)) as GameObject;//加载模型到缓存
        if (gameObject == null)
        {
            return null;
        }
        //gameObject = (LoadMachine.InstantiateObject(gameObject) as GameObject);//实例化物体
        BindRole bindRole = gameObject.AddComponent<BindRole>();
        bindRole.SetModelID(modelID);//设置模型ID
        return gameObject;
    }

    /// <summary>
    /// 创建角色物体
    /// </summary>
    /// <param name="modelID">模型ID</param>
    /// <param name="position">位置</param>
    /// <param name="rotation">朝向</param>
    /// <returns></returns>
    public static GameObject CreatRoleGameObject(int modelID, Vector3 position, Quaternion rotation)
    {
        RoleModelInfo roleModelInfo = Singleton<RoleModelData>.GetInstance().GetRoleModelInfo(modelID);//角色模型信息
        if (roleModelInfo == null)
        {
            Debug.LogWarning("modelID:" + modelID);
            return null;
        }
        GameObject gameObject = Resources.Load(roleModelInfo.Path) as GameObject;
        if (gameObject == null)
        {
            Debug.LogWarning("modelID:" + roleModelInfo.Path);
            return null;
        }
        gameObject = UnityEngine.Object.Instantiate(gameObject,position,rotation);
        BindRole bindRole = gameObject.AddComponent<BindRole>();
        bindRole.SetModelID(modelID);//设置模型ID
        return gameObject;
    }
}
