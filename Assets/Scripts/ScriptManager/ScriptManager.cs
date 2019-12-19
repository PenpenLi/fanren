using System;
using System.Collections.Generic;
using System.Reflection;
using NS_RoleBaseFun;
using UnityEngine;

/// <summary>
/// 脚本管理器
/// </summary>
public class ScriptManager
{
    public List<ScriptManager.ScrMod> ScrModList = new List<ScriptManager.ScrMod>();

    public class ScrMod
    {
        public int modId;
        public string modName;
    }

    private void Start()
	{
		this.ReadScrModInfo();
	}

	public void ReadScrModInfo()
	{
		this.ScrModList.Clear();
		List<string> list = RoleBaseFun.LoadConfInAssets("ScriptMoudle");
		foreach (string text in list)
		{
			string[] array = text.Split(CacheData.separator);
			ScriptManager.ScrMod scrMod = new ScriptManager.ScrMod();
			if (array.Length >= 2)
			{
				int num = 0;
				scrMod.modId = Convert.ToInt32(array[num]);
				num++;
				scrMod.modName = array[num];
				this.ScrModList.Add(scrMod);
			}
		}
	}

	public string GetScrModNameByID(int modID)
	{
		for (int i = 0; i < this.ScrModList.Count; i++)
		{
			if (this.ScrModList[i].modId == modID)
			{
				return this.ScrModList[i].modName;
			}
		}
		return null;
	}

    private void CallFunByCNameAndMName(string className, string methodName, int param, Role role)
    {
        try
        {
            Type type = Type.GetType(className);
            MethodInfo method = type.GetMethod(methodName);
            object obj = Activator.CreateInstance(type);
            object[] parameters = new object[]
            {
                param,
                role
            };
            method.Invoke(obj, parameters);
        }
        catch (Exception ex)
        {
            Debug.LogError((new object[]
            {
                className,
                methodName,
                param,
                role,
                ex.Message
            }));
        }
    }

    private void CallFunByCNameAndMName(string className, string methodName, object[] param)
    {
        try
        {
            Type type = Type.GetType(className);
            MethodInfo method = type.GetMethod(methodName);
            object obj = Activator.CreateInstance(type);
            method.Invoke(obj, param);
        }
        catch (Exception ex)
        {
            string text = string.Empty;
            foreach (object obj2 in param)
            {
                if (obj2 != null)
                {
                    text += obj2.ToString();
                }
            }
            Debug.LogError((new object[]
            {
                className,
                methodName,
                text,
                ex.Message
            }));
        }
    }

    private void CallFunByCNameAndMName(string className, string methodName, int param1, ulong param2, float param3, Role role)
    {
        try
        {
            Type type = Type.GetType(className);
            MethodInfo method = type.GetMethod(methodName);
            object obj = Activator.CreateInstance(type);
            object[] parameters = new object[]
            {
                param1,
                param2,
                param3,
                role
            };
            method.Invoke(obj, parameters);
        }
        catch (Exception ex)
        {
            Debug.LogError((new object[]
            {
                className,
                methodName,
                param1,
                param2,
                param3,
                role,
                ex.Message
            }));
        }
    }

    private void CallFunByCNameAndMName(string className, string methodName, float param, Role role)
    {
        try
        {
            Type type = Type.GetType(className);
            MethodInfo method = type.GetMethod(methodName);
            object obj = Activator.CreateInstance(type);
            object[] parameters = new object[]
            {
                param,
                role
            };
            method.Invoke(obj, parameters);
        }
        catch (Exception ex)
        {
            Debug.LogError((new object[]
            {
                className,
                methodName,
                param,
                role,
                ex.Message
            }));
        }
    }

    private void CallFunByCNameAndMName(string className, string methodName, int param)
    {
        try
        {
            Type type = Type.GetType(className);
            MethodInfo method = type.GetMethod(methodName);
            object obj = Activator.CreateInstance(type);
            object[] parameters = new object[]
            {
                param
            };
            method.Invoke(obj, parameters);
        }
        catch (Exception ex)
        {
            Debug.LogError(className+""+methodName+""+param+""+ex.Message);
        }
    }

    private void CallFunByCNameAndMName(string className, string methodName, string param1, int param2)
    {
        try
        {
            Type type = Type.GetType(className);
            MethodInfo method = type.GetMethod(methodName);
            object obj = Activator.CreateInstance(type);
            object[] parameters = new object[]
            {
                param1,
                param2
            };
            method.Invoke(obj, parameters);
        }
        catch (Exception ex)
        {
            Debug.LogError((new object[]
            {
                className,
                methodName,
                param1,
                param2,
                ex.Message
            }));
        }
    }

    //// Token: 0x06001276 RID: 4726 RVA: 0x0009BA30 File Offset: 0x00099C30
    //private void CallFunByCNameAndMName(string className, string methodName, SD_Base param)
    //{
    //	try
    //	{
    //		Type type = Type.GetType(className);
    //		MethodInfo method = type.GetMethod(methodName);
    //		object obj = Activator.CreateInstance(type);
    //		object[] parameters = new object[]
    //		{
    //			param
    //		};
    //		method.Invoke(obj, parameters);
    //	}
    //	catch (Exception ex)
    //	{
    //		Debug.LogError(DU.Err(new object[]
    //		{
    //			className,
    //			methodName,
    //			param,
    //			ex.Message
    //		}));
    //	}
    //}

    private void CallFunByCNameAndMName(string className, string methodName, int param1, object param2)
    {
        try
        {
            Type type = Type.GetType(className);
            MethodInfo method = type.GetMethod(methodName);
            object obj = Activator.CreateInstance(type);
            object[] parameters = new object[]
            {
                param1,
                param2
            };
            method.Invoke(obj, parameters);
        }
        catch (Exception ex)
        {
            Debug.LogError(
                className+""+
                methodName +
                param1+
                param2 +
                ex.Message);
        }
    }

    //private void CallFunByCNameAndMName(string className, string methodName, int param1, int param2)
    //{
    //	try
    //	{
    //		Type type = Type.GetType(className);
    //		MethodInfo method = type.GetMethod(methodName);
    //		object obj = Activator.CreateInstance(type);
    //		object[] parameters = new object[]
    //		{
    //			param1,
    //			param2
    //		};
    //		method.Invoke(obj, parameters);
    //	}
    //	catch (Exception ex)
    //	{
    //		Debug.LogError(DU.Err(new object[]
    //		{
    //			className,
    //			methodName,
    //			param1,
    //			param2,
    //			ex.Message
    //		}));
    //	}
    //}

    public void Exec(int moduleID, int parID)
    {
        if (moduleID < 0 || parID < 0)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleID);
        if (scrModNameByID != null)
        {
            this.UpdateMission(moduleID, parID);
            this.CallFunByCNameAndMName(scrModNameByID, "Exec", parID);
        }
        else
        {
            Debug.Log("Can't Find ScriptMode " + moduleID);
        }
    }

    public void Exec(int moduleID, int parID, Role role)
    {
        Debug.Log(new object[]
        {
            "Exec " + moduleID
        });
        if (moduleID < 0 || parID < 0)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleID);
        if (scrModNameByID != null)
        {
            this.UpdateMission(moduleID, parID);
            //this.CallFunByCNameAndMName(scrModNameByID, "Exec", parID, role);
        }
    }

    public void Exec(int moduleID, object[] param)
    {
        Debug.Log("Exec " + moduleID);
        if (moduleID < 0)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleID);
        if (scrModNameByID != null)
        {
            //this.CallFunByCNameAndMName(scrModNameByID, "Exec", param);
        }
    }

    public void Exec(int moduleID)
    {
        Debug.Log(new object[]
        {
            "Exec " + moduleID
        });
        if (moduleID < 0)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleID);
        if (scrModNameByID != null)
        {
            Type type = Type.GetType(scrModNameByID);
            MethodInfo method = type.GetMethod("Exec");
            object obj = Activator.CreateInstance(type);
            method.Invoke(obj, null);
        }
    }

    public void Exec(int moduleID, ATTRIBUTE_TYPE type, ulong itemid, float val, Role role)
    {
        if (moduleID < 0 || itemid < 0UL)
        {
            return;
        }
        if (moduleID != 26)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleID);
        if (scrModNameByID != null)
        {
            //this.CallFunByCNameAndMName(scrModNameByID, "Exec", (int)type, itemid, val, role);
        }
    }

    public void Exec(int moduleID, ItemCfgType type, ulong itemid)
    {
        if (moduleID < 0 || itemid < 0UL)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleID);
        if (scrModNameByID != null)
        {
            this.CallFunByCNameAndMName(scrModNameByID, "Exec", (int)type, itemid);
        }
    }

    // Token: 0x0600127F RID: 4735 RVA: 0x0009BDF8 File Offset: 0x00099FF8
    public void Exec(int moduleID, float parID, Role role)
    {
        if (moduleID < 0 || parID < 0f)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleID);
        if (scrModNameByID != null)
        {
            this.UpdateMission(moduleID, (int)parID);
            //this.CallFunByCNameAndMName(scrModNameByID, "Exec", parID, role);
        }
    }

    // Token: 0x06001280 RID: 4736 RVA: 0x0009BE40 File Offset: 0x0009A040
    public void Exec(int moduleId, string par1, int par2)
    {
        if (moduleId < 0)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleId);
        if (scrModNameByID != null)
        {
            //this.CallFunByCNameAndMName(scrModNameByID, "Exec", par1, par2);
        }
    }

    // Token: 0x06001281 RID: 4737 RVA: 0x0009BE74 File Offset: 0x0009A074
    public void Exec(int moduleId, int par, object agrs)
    {
        if (moduleId < 0 || par < 0)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleId);
        if (scrModNameByID != null)
        {
            //this.CallFunByCNameAndMName(scrModNameByID, "Exec", par, agrs);
        }
    }

    // Token: 0x06001282 RID: 4738 RVA: 0x0009BEAC File Offset: 0x0009A0AC
    public void Exec(int moduleId, int par1, int par2)
    {
        if (moduleId < 0 || par1 < 0)
        {
            return;
        }
        string scrModNameByID = this.GetScrModNameByID(moduleId);
        if (scrModNameByID != null)
        {
            this.UpdateMission(moduleId, par1);
            //this.CallFunByCNameAndMName(scrModNameByID, "Exec", par1, par2);
        }
    }

    // Token: 0x06001283 RID: 4739 RVA: 0x0009BEEC File Offset: 0x0009A0EC
    //public void Exec(int moduleId, SD_Base agrs)
    //{
    //    if (moduleId < 0)
    //    {
    //        return;
    //    }
    //    string scrModNameByID = this.GetScrModNameByID(moduleId);
    //    if (scrModNameByID != null)
    //    {
    //        this.CallFunByCNameAndMName(scrModNameByID, "Exec", agrs);
    //    }
    //}

    public void UpdateMission(int moduleID, int parID)
    {
        //if (FanrenSceneManager.RoleMan == null)
        //{
        //    return;
        //}
        //Role role = SceneManager.RoleMan.GetRole(1);
        //if (role != null)
        //{
        //    ModMission modMission = role.GetModule(MODULE_TYPE.MT_MISSION) as ModMission;
        //    if (modMission != null)
        //    {
        //        modMission.UpdateMissionProgress(moduleID, parID);
        //    }
        //}
    }
}
