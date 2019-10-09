using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NS_RoleBaseFun
{
	public class RoleBaseFun
	{
		public static Transform FindDescendants(Transform root, string aimName)
		{
			if (root == null)
			{
				return null;
			}
			foreach (object obj in root)
			{
				Transform transform = (Transform)obj;
				if (transform.name == aimName)
				{
					return transform;
				}
				Transform transform2 = RoleBaseFun.FindDescendants(transform, aimName);
				if (transform2 != null)
				{
					return transform2;
				}
			}
			return null;
		}

        //	public static void SetGravityToRigid(Transform root, bool gravity)
        //	{
        //		if (root.rigidbody != null)
        //		{
        //			root.rigidbody.useGravity = gravity;
        //		}
        //		foreach (object obj in root)
        //		{
        //			Transform transform = (Transform)obj;
        //			Transform transform2 = root.FindChild(transform.name);
        //			if (transform2 != null)
        //			{
        //				RoleBaseFun.SetGravityToRigid(transform2, gravity);
        //			}
        //		}
        //	}

        //	// Token: 0x060023CC RID: 9164 RVA: 0x000F20D8 File Offset: 0x000F02D8
        //	public static void SetRigidSleep(Transform root)
        //	{
        //		if (root.rigidbody != null)
        //		{
        //			root.rigidbody.Sleep();
        //		}
        //		foreach (object obj in root)
        //		{
        //			Transform transform = (Transform)obj;
        //			Transform transform2 = root.FindChild(transform.name);
        //			if (transform2 != null)
        //			{
        //				RoleBaseFun.SetRigidSleep(transform2);
        //			}
        //		}
        //	}

        //	// Token: 0x060023CD RID: 9165 RVA: 0x000F2178 File Offset: 0x000F0378
        //	public static void SetColiiderTriggle(Transform root, bool bEnable)
        //	{
        //		BoxCollider component = root.GetComponent<BoxCollider>();
        //		if (component != null)
        //		{
        //			component.isTrigger = !bEnable;
        //		}
        //		SphereCollider component2 = root.GetComponent<SphereCollider>();
        //		if (component2 != null)
        //		{
        //			component2.isTrigger = !bEnable;
        //		}
        //		CapsuleCollider component3 = root.GetComponent<CapsuleCollider>();
        //		if (component3 != null)
        //		{
        //			component3.isTrigger = !bEnable;
        //		}
        //		foreach (object obj in root)
        //		{
        //			Transform transform = (Transform)obj;
        //			Transform transform2 = root.FindChild(transform.name);
        //			if (transform2 != null)
        //			{
        //				RoleBaseFun.SetColiiderTriggle(transform2, bEnable);
        //			}
        //		}
        //	}

        //	// Token: 0x060023CE RID: 9166 RVA: 0x000F225C File Offset: 0x000F045C
        //	public static void SetColiiderEnable(Transform root, bool bEnable)
        //	{
        //		BoxCollider[] componentsInChildren = root.GetComponentsInChildren<BoxCollider>(true);
        //		foreach (BoxCollider boxCollider in componentsInChildren)
        //		{
        //			if (boxCollider.rigidbody != null)
        //			{
        //				boxCollider.enabled = bEnable;
        //			}
        //		}
        //		SphereCollider[] componentsInChildren2 = root.GetComponentsInChildren<SphereCollider>(true);
        //		foreach (SphereCollider sphereCollider in componentsInChildren2)
        //		{
        //			if (sphereCollider.rigidbody != null)
        //			{
        //				sphereCollider.enabled = bEnable;
        //			}
        //		}
        //		CapsuleCollider[] componentsInChildren3 = root.GetComponentsInChildren<CapsuleCollider>(true);
        //		foreach (CapsuleCollider capsuleCollider in componentsInChildren3)
        //		{
        //			if (capsuleCollider.rigidbody != null)
        //			{
        //				capsuleCollider.enabled = bEnable;
        //			}
        //		}
        //	}

        //	// Token: 0x060023CF RID: 9167 RVA: 0x000F2334 File Offset: 0x000F0534
        //	public static void SetRigidbodyMass(Transform root, float percent)
        //	{
        //		if (root.rigidbody != null)
        //		{
        //			root.rigidbody.mass = root.rigidbody.mass * percent;
        //		}
        //		foreach (object obj in root)
        //		{
        //			Transform transform = (Transform)obj;
        //			Transform transform2 = root.FindChild(transform.name);
        //			if (transform2 != null)
        //			{
        //				RoleBaseFun.SetRigidbodyMass(transform2, percent);
        //			}
        //		}
        //	}

        //	// Token: 0x060023D0 RID: 9168 RVA: 0x000F23E0 File Offset: 0x000F05E0
        //	public static void SetRigidbodyEnable(Transform root, bool bEnable)
        //	{
        //		Rigidbody[] componentsInChildren = root.GetComponentsInChildren<Rigidbody>(true);
        //		foreach (Rigidbody rigidbody in componentsInChildren)
        //		{
        //			if (bEnable)
        //			{
        //				rigidbody.useGravity = true;
        //				rigidbody.isKinematic = false;
        //			}
        //			else
        //			{
        //				rigidbody.useGravity = false;
        //				rigidbody.isKinematic = true;
        //			}
        //		}
        //	}

        //	// Token: 0x060023D1 RID: 9169 RVA: 0x000F2438 File Offset: 0x000F0638
        //	public static void CopyTransformsRecurse(Transform src, Transform dst, bool bCopySelf)
        //	{
        //		if (bCopySelf)
        //		{
        //			dst.position = src.position;
        //			dst.rotation = src.rotation;
        //		}
        //		foreach (object obj in dst)
        //		{
        //			Transform transform = (Transform)obj;
        //			Transform transform2 = src.Find(transform.name);
        //			if (transform2 != null)
        //			{
        //				RoleBaseFun.CopyTransformsRecurse(transform2, transform, true);
        //			}
        //		}
        //	}

        public static List<string> LoadConfInAssets(string filename)
        {
            if (!File.Exists(Application.dataPath + "/Resources/conf/" + filename) && !File.Exists(Application.dataPath + "/Resources/conf/" + filename + ".txt"))
            {
                Debug.LogError( "(RF)Can't find file:" + Application.dataPath + "/Resources/conf/" + filename);
            }
            TextAsset textAsset = (TextAsset)ResourceLoader.Load("conf/" + filename, typeof(TextAsset));
            if (textAsset == null)
            {
                return null;
            }
            string[] separator = new string[]
            {
                "\n"
            };
            string[] array = textAsset.text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new List<string>();
            foreach (string text in array)
            {
                string text2 = text.Trim();
                if (!string.IsNullOrEmpty(text2))
                {
                    if (text2.Length != 0)
                    {
                        if (text2.IndexOf('#') != 0)
                        {
                            list.Add(text2);
                        }
                    }
                }
            }
            Resources.UnloadAsset(textAsset);
            return list;
        }

        //	public static Role GetRoleScriptFromGo(GameObject go)
        //	{
        //		return RoleBaseFun.GetRoleScriptFromGo(go, false);
        //	}

        //	public static Role GetRoleScriptFromGo(GameObject go, bool bFindParent)
        //	{
        //		if (go == null)
        //		{
        //			return null;
        //		}
        //		BindRole component = go.transform.GetComponent<BindRole>();
        //		if (component == null)
        //		{
        //			return null;
        //		}
        //		Role theRole = component.TheRole;
        //		if (theRole != null)
        //		{
        //			return theRole;
        //		}
        //		if (!bFindParent)
        //		{
        //			return null;
        //		}
        //		if (go.transform.parent == null)
        //		{
        //			return null;
        //		}
        //		if (go.transform.parent.name == "Role")
        //		{
        //			return null;
        //		}
        //		return RoleBaseFun.GetRoleScriptFromGo(go.transform.parent.gameObject);
        //	}

        //	public static bool IsFriendForward(Role role, Role targetRole)
        //	{
        //		Vector3 direction = targetRole.GetPos() - role.GetPos();
        //		float magnitude = direction.magnitude;
        //		float radius = role.roleGameObject.RoleController.radius;
        //		float d = role.roleGameObject.RoleController.height * 0.5f;
        //		Vector3 point = role.GetPos() - Vector3.up * d + role.roleGameObject.RoleController.center;
        //		Vector3 point2 = role.GetPos() + Vector3.up * d + role.roleGameObject.RoleController.center;
        //		RaycastHit[] array = Physics.CapsuleCastAll(point2, point, radius * 0.6f, direction, magnitude);
        //		if (array != null)
        //		{
        //			foreach (RaycastHit raycastHit in array)
        //			{
        //				Role roleScriptFromGo = RoleBaseFun.GetRoleScriptFromGo(raycastHit.collider.gameObject);
        //				if (roleScriptFromGo != null && roleScriptFromGo._roleType == role._roleType && roleScriptFromGo != role && roleScriptFromGo != targetRole)
        //				{
        //					return true;
        //				}
        //			}
        //		}
        //		return false;
        //	}

        //	// Token: 0x060023D6 RID: 9174 RVA: 0x000F27E0 File Offset: 0x000F09E0
        //	public static bool IsDrectionHaveRole(Role role, Vector3 dir, float dis)
        //	{
        //		float radius = role.roleGameObject.RoleController.radius;
        //		float d = role.roleGameObject.RoleController.height * 0.5f;
        //		Vector3 point = role.GetPos() - Vector3.up * d + role.roleGameObject.RoleController.center;
        //		Vector3 point2 = role.GetPos() + Vector3.up * d + role.roleGameObject.RoleController.center;
        //		RaycastHit[] array = Physics.CapsuleCastAll(point2, point, radius * 0.5f, dir, dis + radius);
        //		if (array != null)
        //		{
        //			foreach (RaycastHit raycastHit in array)
        //			{
        //				Role roleScriptFromGo = RoleBaseFun.GetRoleScriptFromGo(raycastHit.collider.gameObject);
        //				if (roleScriptFromGo != null && roleScriptFromGo != role)
        //				{
        //					return true;
        //				}
        //			}
        //		}
        //		return false;
        //	}

        //	// Token: 0x060023D7 RID: 9175 RVA: 0x000F28DC File Offset: 0x000F0ADC
        //	public static void CheckComponent(Transform root)
        //	{
        //		GameObject gameObject = root.gameObject;
        //		Component[] components = gameObject.GetComponents<Component>();
        //		int num = 0;
        //		int num2 = 0;
        //		for (int i = 0; i < components.Length; i++)
        //		{
        //			num++;
        //			if (components[i] == null)
        //			{
        //				num2++;
        //				Debug.Log(gameObject.name + " has an empty script attaced in position:" + i);
        //			}
        //		}
        //		foreach (object obj in root)
        //		{
        //			Transform transform = (Transform)obj;
        //			Transform transform2 = root.FindChild(transform.name);
        //			if (transform2 != null)
        //			{
        //				RoleBaseFun.CheckComponent(transform2);
        //			}
        //		}
        //	}

        //	// Token: 0x060023D8 RID: 9176 RVA: 0x000F29C8 File Offset: 0x000F0BC8
        //	public static bool IsBInForwardOfA(Transform a, Transform b)
        //	{
        //		Vector3 vector = b.position - a.position;
        //		float num = Vector3.Dot(vector.normalized, a.right);
        //		if (num < 0.3f && num >= -0.3f)
        //		{
        //			float num2 = Vector3.Dot(vector.normalized, a.forward);
        //			return num2 > 0f;
        //		}
        //		return false;
        //	}

        //	// Token: 0x060023D9 RID: 9177 RVA: 0x000F2A34 File Offset: 0x000F0C34
        //	public static Vector3 GetRandomPosOnRadius(Vector3 pos, float radius)
        //	{
        //		if (radius <= 1f)
        //		{
        //			Logger.LogWarning(new object[]
        //			{
        //				"radius must max than 1"
        //			});
        //			return Vector3.zero;
        //		}
        //		float angle = UnityEngine.Random.Range(0f, 360f);
        //		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        //		Vector3 direction = rotation * Vector3.forward;
        //		Ray ray = new Ray(pos, direction);
        //		return ray.GetPoint(radius);
        //	}

        //	// Token: 0x060023DA RID: 9178 RVA: 0x000F2AA4 File Offset: 0x000F0CA4
        //	public static Vector3 GetRandomPosOnAngleRadius(Vector3 pos, float radius, Role role, float min, float max)
        //	{
        //		if (radius <= 1f)
        //		{
        //			Logger.LogWarning(new object[]
        //			{
        //				"radius must max than 1"
        //			});
        //			return Vector3.zero;
        //		}
        //		float angle = UnityEngine.Random.Range(min, max);
        //		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        //		Vector3 direction = rotation * role.GetTrans().forward;
        //		Ray ray = new Ray(pos, direction);
        //		return ray.GetPoint(radius);
        //	}

        //	// Token: 0x060023DB RID: 9179 RVA: 0x000F2B14 File Offset: 0x000F0D14
        //	public static Vector3 GetPosOnAngleRadius(Vector3 pos, float radius, float angle)
        //	{
        //		if (radius <= 1f)
        //		{
        //			Logger.LogWarning(new object[]
        //			{
        //				"radius must max than 1"
        //			});
        //			return Vector3.zero;
        //		}
        //		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        //		Vector3 direction = rotation * Vector3.forward;
        //		Ray ray = new Ray(pos, direction);
        //		return ray.GetPoint(radius);
        //	}

        //	// Token: 0x060023DC RID: 9180 RVA: 0x000F2B78 File Offset: 0x000F0D78
        //	public static Vector3 GetPosOnSameAngleInRadius(Vector3 pos, float radius, float angle)
        //	{
        //		int num = 1;
        //		if (radius <= 1f)
        //		{
        //			Logger.LogWarning(new object[]
        //			{
        //				"radius must max than 1"
        //			});
        //			return Vector3.zero;
        //		}
        //		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        //		Vector3 direction = rotation * Vector3.forward;
        //		Ray ray = new Ray(pos, direction);
        //		return ray.GetPoint(UnityEngine.Random.Range((float)num, radius));
        //	}

        //	// Token: 0x060023DD RID: 9181 RVA: 0x000F2BE4 File Offset: 0x000F0DE4
        //	public static Vector3 GetRandomPosInRadius(Vector3 pos, float radius)
        //	{
        //		int num = 1;
        //		if (radius <= 1f)
        //		{
        //			Logger.LogWarning(new object[]
        //			{
        //				"radius must max than 1"
        //			});
        //			return Vector3.zero;
        //		}
        //		float angle = UnityEngine.Random.Range(0f, 360f);
        //		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        //		Vector3 direction = rotation * Vector3.forward;
        //		Ray ray = new Ray(pos, direction);
        //		return ray.GetPoint(UnityEngine.Random.Range((float)num, radius));
        //	}

        //	// Token: 0x060023DE RID: 9182 RVA: 0x000F2C5C File Offset: 0x000F0E5C
        //	public static bool PointOutBox(Vector3 position, Vector3 pointPosition, string boxName)
        //	{
        //		Vector3 direction = position - pointPosition;
        //		RaycastHit[] array = Physics.RaycastAll(pointPosition, direction, direction.magnitude);
        //		for (int i = 0; i < array.Length; i++)
        //		{
        //			if (string.Compare(array[i].transform.transform.name, boxName) == 0)
        //			{
        //				return true;
        //			}
        //		}
        //		return false;
        //	}

        //	// Token: 0x060023DF RID: 9183 RVA: 0x000F2CB8 File Offset: 0x000F0EB8
        //	public static bool IsRayCastBox(Vector3 position, Vector3 posintPosition, string boxName)
        //	{
        //		return RoleBaseFun.PointOutBox(position, posintPosition, boxName) || RoleBaseFun.PointOutBox(posintPosition, position, boxName);
        //	}

        //	// Token: 0x060023E0 RID: 9184 RVA: 0x000F2CD8 File Offset: 0x000F0ED8
        //	public static Vector3 GetGroundPoint(Vector3 castPos, float distance)
        //	{
        //		RaycastHit[] array = Physics.RaycastAll(castPos, -Vector3.up, distance);
        //		if (array != null)
        //		{
        //			foreach (RaycastHit raycastHit in array)
        //			{
        //				if (raycastHit.collider.GetComponent<TerrainCollider>() != null)
        //				{
        //					return raycastHit.point;
        //				}
        //				if (!raycastHit.collider.isTrigger)
        //				{
        //					if (!(raycastHit.collider is CharacterController))
        //					{
        //						if (!(raycastHit.collider.GetComponent<HurtGameObject>() != null))
        //						{
        //							if (!(raycastHit.collider.renderer == null))
        //							{
        //								if (raycastHit.collider.renderer.enabled)
        //								{
        //									return raycastHit.point;
        //								}
        //							}
        //						}
        //					}
        //				}
        //			}
        //		}
        //		return Vector3.zero;
        //	}

        //	// Token: 0x060023E1 RID: 9185 RVA: 0x000F2DCC File Offset: 0x000F0FCC
        //	public static int[] GetRoleControllerLayer()
        //	{
        //		return new int[]
        //		{
        //			9,
        //			15
        //		};
        //	}

        //	// Token: 0x060023E2 RID: 9186 RVA: 0x000F2DE0 File Offset: 0x000F0FE0
        //	public static void CopyAnimation(Animation source, Animation target)
        //	{
        //		List<AnimationClip> list = new List<AnimationClip>();
        //		foreach (object obj in target)
        //		{
        //			AnimationState animationState = (AnimationState)obj;
        //			if (animationState.clip != null)
        //			{
        //				list.Add(animationState.clip);
        //			}
        //		}
        //		foreach (AnimationClip animationClip in list)
        //		{
        //			if (target[animationClip.name] != null)
        //			{
        //				target.RemoveClip(animationClip);
        //			}
        //		}
        //		foreach (object obj2 in source)
        //		{
        //			AnimationState animationState2 = (AnimationState)obj2;
        //			if (animationState2.clip != null)
        //			{
        //				target.animation.AddClip(animationState2.clip, animationState2.name);
        //			}
        //		}
        //	}

        //	// Token: 0x060023E3 RID: 9187 RVA: 0x000F2F58 File Offset: 0x000F1158
        //	public static bool IsPlayerInFight()
        //	{
        //		foreach (Role role in SceneManager.RoleMan.RoleObjList)
        //		{
        //			if (role is Monster)
        //			{
        //				Monster monster = (Monster)role;
        //				if (monster.isAlive())
        //				{
        //					if (monster.FindPlayer)
        //					{
        //						return true;
        //					}
        //				}
        //			}
        //		}
        //		return false;
        //	}

        //	// Token: 0x060023E4 RID: 9188 RVA: 0x000F2FF4 File Offset: 0x000F11F4
        //	public static Monster CreatMonster(int monsterID, ORG_TYPE orgType, Vector3 position, Quaternion rotation, Role owner)
        //	{
        //		GameObjSpawn.SpawnInfo spawnInfo = default(GameObjSpawn.SpawnInfo);
        //		spawnInfo.orgType = orgType;
        //		spawnInfo.parentRole = owner;
        //		spawnInfo.position = position;
        //		spawnInfo.rotation = rotation;
        //		spawnInfo.ObjectType = monsterID;
        //		return SceneManager.RoleMan.CreateMonsterGO(spawnInfo) as Monster;
        //	}
    }
}
