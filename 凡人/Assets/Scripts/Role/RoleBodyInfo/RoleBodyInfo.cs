using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("角色模型信息")]
public class RoleBodyInfo : MonoBehaviour
{
	public CharacterController Controller;

	public Animation Animation;

	//public List<HARM_PART> HarmPartType = new List<HARM_PART>();

	public List<ColliderCheckObject> HarmCheckPart = new List<ColliderCheckObject>();

	//public List<HURT_PART> HurtPartType = new List<HURT_PART>();

	public List<HurtRoleGameObject> HurtPart = new List<HurtRoleGameObject>();

	//public List<CHILD_EFFECT_POINT> EffectType = new List<CHILD_EFFECT_POINT>();

	public List<Transform> EffectTrans = new List<Transform>();

	//public List<CHILD_MESH_POINT> MeshType = new List<CHILD_MESH_POINT>();

	public List<Renderer> Mesh = new List<Renderer>();

	//public List<CHILD_RAGDOLL_POINT> RagDollType = new List<CHILD_RAGDOLL_POINT>();

	public List<Rigidbody> RagDollRigidbody = new List<Rigidbody>();

	//public List<CHILD_ARM_POINT> ArmType = new List<CHILD_ARM_POINT>();

	public List<Transform> ArmTrans = new List<Transform>();
}
