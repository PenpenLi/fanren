using System;
using System.Collections.Generic;
using System.Reflection;

namespace ActionScript
{
	public static class ConditionFunction
	{
		public static bool ConditionAnalyse(int id, object[] param)
		{
			string conditionName = Singleton<ScriptConditionData>.GetInstance().GetConditionName(id);
			if (string.IsNullOrEmpty(conditionName))
			{
				return false;
			}
			MethodInfo method = typeof(ConditionFunction).GetMethod(conditionName);
			return method != null && (bool)method.Invoke(null, param);
		}

		public static bool MissionState(int missionID, int missionState)
		{
			Player instance = Player.Instance;
			if (instance == null)
			{
				return false;
			}
			ModMission modMission = instance.GetModule(MODULE_TYPE.MT_MISSION) as ModMission;
			MissionState missionState2 = modMission.GetMissionState(missionID);
			return missionState == (int)missionState2;
		}

		//public static bool RoleAtt(Role role, int attType, int compareType, float attValue)
		//{
		//	if (role == null)
		//	{
		//		return false;
		//	}
		//	//ModAttribute modAttribute = role.GetModule(MODULE_TYPE.MT_ATTRIBUTE) as ModAttribute;
		//	//if (modAttribute == null)
		//	//{
		//	//	return false;
		//	//}
		//	//float attributeValue = modAttribute.GetAttributeValue((ATTRIBUTE_TYPE)attType);
		//	//return ConditionFunction.CompareValue(attributeValue, attValue, compareType);
		//}

		public static bool PlayerItemNum(int itemType, int compareType, int num)
		{
			if (Player.Instance == null)
			{
				return false;
			}
			//Dictionary<ulong, CItemBase> dictionary = Player.Instance.ItemFolder.FolderData();
			int num2 = 0;
			ulong num3 = (ulong)((long)itemType);
			//foreach (CItemBase citemBase in dictionary.Values)
			//{
			//	if (num3 == citemBase.ITEM_STATIC_ID)
			//	{
			//		num2++;
			//	}
			//}
			return ConditionFunction.CompareValue((float)num2, (float)num, compareType);
		}

		private static bool CompareValue(float a, float b, int compareType)
		{
			if (compareType == 0)
			{
				if (a == b)
				{
					return true;
				}
			}
			else if (compareType == 1)
			{
				if (a > b)
				{
					return true;
				}
			}
			else if (compareType == 2)
			{
				if (a >= b)
				{
					return true;
				}
			}
			else if (compareType == 3)
			{
				if (a <= b)
				{
					return true;
				}
			}
			else if (compareType == 4)
			{
				if (a < b)
				{
					return true;
				}
			}
			else if (compareType == 4 && a != b)
			{
				return true;
			}
			return false;
		}
	}
}
