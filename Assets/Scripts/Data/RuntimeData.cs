using System;
using System.Collections.Generic;
using System.Globalization;
using YouYou;

/// <summary>
/// 运行数据
/// </summary>
public class RuntimeData
{
    public const string TIMEKEY_PREF = "TIMEKEY_";

    public const string FLAG_PREF = "FLAG_";

    public bool IsInited;

    private static RuntimeData _instance;

    //public GameEngine gameEngine;

    //public MapUI mapUI;

    //public TouchUI touchUI;

    //public RoleSelectUI roleSelectUI;

    //public BattleField battleFieldUI;

    ///// <summary>
    ///// 队伍
    ///// </summary>
    //public List<Role> Team = new List<Role>();

    ///// <summary>
    ///// 跟随
    ///// </summary>
    //public List<Role> Follow = new List<Role>();

    public string NewbieTask = string.Empty;

    //public Dictionary<ItemInstance, int> Xiangzi = new Dictionary<ItemInstance, int>();

    //public Dictionary<ItemInstance, int> Items = new Dictionary<ItemInstance, int>();

    public Dictionary<string, string> KeyValues = new Dictionary<string, string>();

    private RuntimeData()
    {
    }

    public static RuntimeData Instance
    {
        get
        {
            if (RuntimeData._instance == null)
            {
                RuntimeData._instance = new RuntimeData();
            }
            return RuntimeData._instance;
        }
    }

    /// <summary>
    /// 初始化运行数据
    /// </summary>
    public void Init()
    {
        //this.gameEngine = new GameEngine();
        this.Clear();
        //this.UUID = Guid.NewGuid().ToString();
        this.IsInited = true;
    }

    public bool IsCheat
    {
        get
        {
            //if (CommonSettings.MOD_EDITOR_MODE)
            //{
            //    return false;
            //}
            //foreach (Role role in this.Team)
            //{
            //    if (role.maxhp > CommonSettings.MAX_HPMP + 2000 || role.maxmp > CommonSettings.MAX_HPMP + 2000)
            //    {
            //        return true;
            //    }
            //    if (role.quanzhang > 300)
            //    {
            //        return true;
            //    }
            //    if (role.jianfa > 300)
            //    {
            //        return true;
            //    }
            //    if (role.daofa > 300)
            //    {
            //        return true;
            //    }
            //    if (role.qimen > 300)
            //    {
            //        return true;
            //    }
            //    if (role.bili > 300)
            //    {
            //        return true;
            //    }
            //    if (role.shenfa > 300)
            //    {
            //        return true;
            //    }
            //    if (role.dingli > 300)
            //    {
            //        return true;
            //    }
            //    if (role.fuyuan > 300)
            //    {
            //        return true;
            //    }
            //    if (role.wuxing > 300)
            //    {
            //        return true;
            //    }
            //    if (role.gengu > 300)
            //    {
            //        return true;
            //    }
            //    foreach (SkillInstance skillInstance in role.Skills)
            //    {
            //        if (skillInstance.Level > 23)
            //        {
            //            return true;
            //        }
            //    }
            //    foreach (InternalSkillInstance internalSkillInstance in role.InternalSkills)
            //    {
            //        if (internalSkillInstance.Level > 23)
            //        {
            //            return true;
            //        }
            //    }
            //}
            return false;
        }
    }

    public void Clear()
    {
        //this.Team.Clear();
        //this.Follow.Clear();
        //this.Items.Clear();
        //this.Xiangzi.Clear();
        this.KeyValues.Clear();
        this.TrialRoles = string.Empty;
        this.NewbieTask = string.Empty;
        this.Rank = -1;
        this.IsInited = false;
    }

    //public bool InTeam(string roleKey)
    //{
    //    foreach (Role role in this.Team)
    //    {
    //        if (role.Key.Equals(roleKey))
    //        {
    //            return true;
    //        }
    //    }
    //    foreach (Role role2 in this.Follow)
    //    {
    //        if (role2.Key.Equals(roleKey))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    /// <summary>
    /// 重置队伍
    /// </summary>
    public void ResetTeam()
    {
        //foreach (Role role in this.Team)
        //{
        //    role.Reset(true);
        //}
    }

    public bool NameInTeam(string roleName)
    {
        //foreach (Role role in this.Team)
        //{
        //    //if (role.Name.Equals(roleName))
        //    //{
        //    //    return true;
        //    //}
        //}
        //foreach (Role role2 in this.Follow)
        //{
        //    //if (role2.Name.Equals(roleName))
        //    //{
        //    //    return true;
        //    //}
        //}
        return false;
    }

    //public Role GetTeamRole(string roleKey)
    //{
    //    foreach (Role role in this.Team)
    //    {
    //        if (role.Key.Equals(roleKey))
    //        {
    //            return role;
    //        }
    //    }
    //    return null;
    //}

    //// Token: 0x060000B1 RID: 177 RVA: 0x00006BB0 File Offset: 0x00004DB0
    //public Role GetFollowRole(string roleKey)
    //{
    //    foreach (Role role in this.Follow)
    //    {
    //        if (role.Key.Equals(roleKey))
    //        {
    //            return role;
    //        }
    //    }
    //    return null;
    //}

    /// <summary>
    /// 添加队伍成员
    /// </summary>
    /// <param name="roleID">角色ID</param>
    public void addTeamMember(int roleID)
    {
        //this.Team.Add(GameEntry.DataTable.GetRole(roleID));
    }

    //public void addFollowMember(string roleKey)
    //{
    //    this.Follow.Add(ResourceManager.Get<Role>(roleKey).Clone());
    //}

    //// Token: 0x060000B5 RID: 181 RVA: 0x00006C88 File Offset: 0x00004E88
    //public void addFollowMember(string roleKey, string changeName)
    //{
    //    Role role = ResourceManager.Get<Role>(roleKey).Clone();
    //    role.Name = changeName;
    //    this.Follow.Add(role);
    //}

    //// Token: 0x060000B6 RID: 182 RVA: 0x00006CB4 File Offset: 0x00004EB4
    //public void removeTeamMember(string roleKey)
    //{
    //    Role role = null;
    //    foreach (Role role2 in this.Team)
    //    {
    //        if (role2.Key.Equals(roleKey))
    //        {
    //            role = role2;
    //            break;
    //        }
    //    }
    //    if (role != null)
    //    {
    //        foreach (ItemInstance item in role.Equipment)
    //        {
    //            this.addItem(item, 1);
    //        }
    //        this.Team.Remove(role);
    //    }
    //}

    //// Token: 0x060000B7 RID: 183 RVA: 0x00006D98 File Offset: 0x00004F98
    //public void removeAllTeamMember()
    //{
    //    Role item = null;
    //    foreach (Role role in this.Team)
    //    {
    //        if (role.Key.Equals("主角"))
    //        {
    //            item = role;
    //        }
    //        else
    //        {
    //            foreach (ItemInstance item2 in role.Equipment)
    //            {
    //                this.addItem(item2, 1);
    //            }
    //        }
    //    }
    //    this.Team.Clear();
    //    this.Team.Add(item);
    //}

    //// Token: 0x060000B8 RID: 184 RVA: 0x00006E84 File Offset: 0x00005084
    //public void removeFollowMember(string roleKey)
    //{
    //    Role role = null;
    //    foreach (Role role2 in this.Follow)
    //    {
    //        if (role2.Key.Equals(roleKey))
    //        {
    //            role = role2;
    //            break;
    //        }
    //    }
    //    if (role != null)
    //    {
    //        this.Follow.Remove(role);
    //    }
    //}

    //// Token: 0x060000B9 RID: 185 RVA: 0x00006F10 File Offset: 0x00005110
    //public bool isLocationInTask(string location)
    //{
    //    Task task = ResourceManager.Get<Task>(this.NewbieTask);
    //    if (task == null)
    //    {
    //        return false;
    //    }
    //    foreach (TaskLocation taskLocation in task.Locations)
    //    {
    //        if (taskLocation.name.Equals(location))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //// Token: 0x060000BA RID: 186 RVA: 0x00006FA0 File Offset: 0x000051A0
    //public void setTask(string task)
    //{
    //    this.NewbieTask = task;
    //}

    //// Token: 0x060000BB RID: 187 RVA: 0x00006FAC File Offset: 0x000051AC
    //public void removeTask(string task)
    //{
    //    this.NewbieTask = string.Empty;
    //}

    //// Token: 0x060000BC RID: 188 RVA: 0x00006FBC File Offset: 0x000051BC
    //public bool hasTask()
    //{
    //    return this.NewbieTask != null && !this.NewbieTask.Equals(string.Empty);
    //}

    //// Token: 0x060000BD RID: 189 RVA: 0x00006FE4 File Offset: 0x000051E4
    //public bool judgeFinishTask()
    //{
    //    Task task = ResourceManager.Get<Task>(this.NewbieTask);
    //    if (task == null)
    //    {
    //        return false;
    //    }
    //    foreach (TaskFinish taskFinish in task.Finishes)
    //    {
    //        bool flag = true;
    //        foreach (Condition condition in taskFinish.Conditions)
    //        {
    //            if (!TriggerLogic.judge(condition))
    //            {
    //                flag = false;
    //                break;
    //            }
    //        }
    //        if (flag)
    //        {
    //            this.NewbieTask = string.Empty;
    //            if (task.Result != null)
    //            {
    //                this.gameEngine.SwitchGameScene(task.Result.type, task.Result.value);
    //            }
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //// Token: 0x17000019 RID: 25
    //// (get) Token: 0x060000BE RID: 190 RVA: 0x00007108 File Offset: 0x00005308
    //public int XiangziCount
    //{
    //    get
    //    {
    //        int num = 0;
    //        foreach (KeyValuePair<ItemInstance, int> keyValuePair in this.Xiangzi)
    //        {
    //            num += keyValuePair.Value;
    //        }
    //        return num;
    //    }
    //}

    //// Token: 0x1700001A RID: 26
    //// (get) Token: 0x060000BF RID: 191 RVA: 0x00007174 File Offset: 0x00005374
    //public int MaxXiangziItemCount
    //{
    //    get
    //    {
    //        return 8 + RuntimeData.Instance.Round * 6;
    //    }
    //}

    //// Token: 0x060000C0 RID: 192 RVA: 0x00007184 File Offset: 0x00005384
    //public Dictionary<ItemInstance, int> GetItems(ItemType type)
    //{
    //    Dictionary<ItemInstance, int> dictionary = new Dictionary<ItemInstance, int>();
    //    foreach (ItemInstance itemInstance in this.Items.Keys)
    //    {
    //        if (itemInstance.Type == type)
    //        {
    //            dictionary.Add(itemInstance, this.Items[itemInstance]);
    //        }
    //    }
    //    return dictionary;
    //}

    //// Token: 0x060000C1 RID: 193 RVA: 0x00007210 File Offset: 0x00005410
    //public ItemInstance GetItem(string pk)
    //{
    //    foreach (KeyValuePair<ItemInstance, int> keyValuePair in this.Items)
    //    {
    //        if (keyValuePair.Key.PK == pk)
    //        {
    //            return keyValuePair.Key;
    //        }
    //    }
    //    return null;
    //}

    //// Token: 0x060000C2 RID: 194 RVA: 0x00007298 File Offset: 0x00005498
    //public Dictionary<ItemInstance, int> GetItems(ItemType[] types)
    //{
    //    Dictionary<ItemInstance, int> dictionary = new Dictionary<ItemInstance, int>();
    //    foreach (ItemInstance itemInstance in this.Items.Keys)
    //    {
    //        for (int i = 0; i < types.Length; i++)
    //        {
    //            if (types[i] == itemInstance.Type)
    //            {
    //                dictionary.Add(itemInstance, this.Items[itemInstance]);
    //            }
    //        }
    //    }
    //    return dictionary;
    //}

    //public void addItem(Item item, int number = 1)
    //{
    //    this.addItem(ItemInstance.Generate(item.Name, false), number);
    //}

    //public void addItem(ItemInstance item, int number = 1)
    //{
    //    if (number > 0)
    //    {
    //        for (int i = 0; i < number; i++)
    //        {
    //            if (this.Items.ContainsKey(item))
    //            {
    //                Dictionary<ItemInstance, int> items;
    //                Dictionary<ItemInstance, int> dictionary = items = this.Items;
    //                int num = items[item];
    //                dictionary[item] = num + 1;
    //            }
    //            else
    //            {
    //                this.Items.Add(item, 1);
    //            }
    //        }
    //    }
    //    else if (this.Items.ContainsKey(item))
    //    {
    //        Dictionary<ItemInstance, int> items2;
    //        Dictionary<ItemInstance, int> dictionary2 = items2 = this.Items;
    //        int num = items2[item];
    //        dictionary2[item] = num + number;
    //        if (this.Items[item] <= 0)
    //        {
    //            this.Items.Remove(item);
    //        }
    //    }
    //}

    //public void xiangziAddItem(ItemInstance item, int number = 1)
    //{
    //    if (number > 0)
    //    {
    //        for (int i = 0; i < number; i++)
    //        {
    //            if (this.Xiangzi.ContainsKey(item))
    //            {
    //                Dictionary<ItemInstance, int> xiangzi;
    //                Dictionary<ItemInstance, int> dictionary = xiangzi = this.Xiangzi;
    //                int num = xiangzi[item];
    //                dictionary[item] = num + 1;
    //            }
    //            else
    //            {
    //                this.Xiangzi.Add(item, 1);
    //            }
    //        }
    //    }
    //    else if (this.Xiangzi.ContainsKey(item))
    //    {
    //        Dictionary<ItemInstance, int> xiangzi2;
    //        Dictionary<ItemInstance, int> dictionary2 = xiangzi2 = this.Xiangzi;
    //        int num = xiangzi2[item];
    //        dictionary2[item] = num + number;
    //        if (this.Xiangzi[item] <= 0)
    //        {
    //            this.Xiangzi.Remove(item);
    //        }
    //    }
    //}

    //// Token: 0x1700001B RID: 27
    //// (get) Token: 0x060000C6 RID: 198 RVA: 0x000074C0 File Offset: 0x000056C0
    //// (set) Token: 0x060000C7 RID: 199 RVA: 0x000074D4 File Offset: 0x000056D4
    //public string CurrentNick
    //{
    //    get
    //    {
    //        return this.getDataOrInit("currentNick", "初出茅庐");
    //    }
    //    set
    //    {
    //        this.KeyValues["currentNick"] = value.ToString();
    //    }
    //}

    /// <summary>
    /// 前一个故事
    /// </summary>  
    public string PrevStory
    {
        get
        {
            return this.getDataOrInit("prevStory", string.Empty);
        }
        set
        {
            this.KeyValues["prevStory"] = value.ToString();
        }
    }

    /// <summary>
    /// 周目
    /// </summary>
    public int Round
    {
        get
        {
            return int.Parse(this.getDataOrInit("round", "1"));
        }
        set
        {
            this.KeyValues["round"] = value.ToString();
        }
    }

    //public void NextZhoumuClear()
    //{
    //    int round = this.Round;
    //    Dictionary<ItemInstance, int> dictionary = new Dictionary<ItemInstance, int>();
    //    foreach (KeyValuePair<ItemInstance, int> keyValuePair in this.Xiangzi)
    //    {
    //        dictionary.Add(keyValuePair.Key, keyValuePair.Value);
    //    }
    //    string trialRoles = this.TrialRoles;
    //    this.Clear();
    //    this.IsInited = true;
    //    this.Round = round;
    //    this.Xiangzi = dictionary;
    //    this.addTeamMember("主角", "小虾米");
    //    this.Money = 100;
    //}

    //// Token: 0x060000CD RID: 205 RVA: 0x00007608 File Offset: 0x00005808
    //public int getHaogan(string roleKey = "女主")
    //{
    //    string key = "HAOGAN" + roleKey;
    //    return int.Parse(this.getDataOrInit(key, "50"));
    //}

    //// Token: 0x060000CE RID: 206 RVA: 0x00007634 File Offset: 0x00005834
    //public void addHaogan(int value, string roleKey = "女主")
    //{
    //    string key = "HAOGAN" + roleKey;
    //    int num = int.Parse(this.getDataOrInit(key, "50"));
    //    this.KeyValues[key] = (num + value).ToString();
    //}

    //public string UUID
    //{
    //    get
    //    {
    //        return this.getDataOrInit("UUID", Guid.NewGuid().ToString());
    //    }
    //    set
    //    {
    //        this.KeyValues["UUID"] = value.ToString();
    //    }
    //}

    //// Token: 0x1700001F RID: 31
    //// (get) Token: 0x060000D1 RID: 209 RVA: 0x000076B8 File Offset: 0x000058B8
    //// (set) Token: 0x060000D2 RID: 210 RVA: 0x000076D0 File Offset: 0x000058D0
    //public int Daode
    //{
    //    get
    //    {
    //        return int.Parse(this.getDataOrInit("daode", "50"));
    //    }
    //    set
    //    {
    //        this.KeyValues["daode"] = value.ToString();
    //    }
    //}

    //// Token: 0x17000020 RID: 32
    //// (get) Token: 0x060000D3 RID: 211 RVA: 0x000076EC File Offset: 0x000058EC
    //// (set) Token: 0x060000D4 RID: 212 RVA: 0x00007700 File Offset: 0x00005900
    //public string femaleName
    //{
    //    get
    //    {
    //        return this.getDataOrInit("femaleName", "铃兰");
    //    }
    //    set
    //    {
    //        this.KeyValues["femaleName"] = value.ToString();
    //    }
    //}

    //// Token: 0x17000021 RID: 33
    //// (get) Token: 0x060000D5 RID: 213 RVA: 0x00007718 File Offset: 0x00005918
    //// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000772C File Offset: 0x0000592C
    //public string maleName
    //{
    //    get
    //    {
    //        return this.getDataOrInit("maleName", "小虾米");
    //    }
    //    set
    //    {
    //        this.KeyValues["maleName"] = value.ToString();
    //    }
    //}

    public int Money
    {
        get
        {
            return int.Parse(this.getDataOrInit("money", "0"));
        }
        set
        {
            this.KeyValues["money"] = value.ToString();
        }
    }

    //// Token: 0x17000023 RID: 35
    //// (get) Token: 0x060000D9 RID: 217 RVA: 0x00007778 File Offset: 0x00005978
    //// (set) Token: 0x060000DA RID: 218 RVA: 0x00007780 File Offset: 0x00005980
    //public int Yuanbao
    //{
    //    get
    //    {
    //        return GlobalData.Yuanbao;
    //    }
    //    set
    //    {
    //        GlobalData.Yuanbao = value;
    //    }
    //}

    //// Token: 0x17000024 RID: 36
    //// (get) Token: 0x060000DB RID: 219 RVA: 0x00007788 File Offset: 0x00005988
    //// (set) Token: 0x060000DC RID: 220 RVA: 0x00007844 File Offset: 0x00005A44
    //public DateTime Date
    //{
    //    get
    //    {
    //        if (!this.KeyValues.ContainsKey("date"))
    //        {
    //            this.KeyValues.Add("date", DateTime.ParseExact("0001-01-01 14:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss"));
    //        }
    //        DateTime result;
    //        try
    //        {
    //            result = DateTime.Parse(this.KeyValues["date"]);
    //        }
    //        catch
    //        {
    //            result = DateTime.ParseExact(this.KeyValues["date"], "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
    //        }
    //        return result;
    //    }
    //    set
    //    {
    //        if (!this.KeyValues.ContainsKey("date"))
    //        {
    //            this.KeyValues.Add("date", DateTime.ParseExact("0001-01-01 14:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture).ToString("yyyy-MM-dd HH:mm:ss"));
    //        }
    //        this.KeyValues["date"] = value.ToString("yyyy-MM-dd HH:mm:ss");
    //    }
    //}

    /// <summary>
    /// 游戏难度
    /// </summary>
    public string GameMode
    {
        get
        {
            return this.getDataOrInit("mode", "normal");
        }
        set
        {
            this.KeyValues["mode"] = value.ToString();
        }
    }

    //// Token: 0x17000026 RID: 38
    //// (get) Token: 0x060000DF RID: 223 RVA: 0x000078E0 File Offset: 0x00005AE0
    //public string GameModeChinese
    //{
    //    get
    //    {
    //        string gameMode = this.GameMode;
    //        switch (gameMode)
    //        {
    //            case "normal":
    //                return "简单";
    //            case "hard":
    //                return "进阶";
    //            case "crazy":
    //                return "炼狱";
    //        }
    //        return "未定义";
    //    }
    //}

    /// <summary>
    /// 同队伍是否能互相伤害
    /// </summary>
    public bool FriendlyFire
    {
        get
        {
            return bool.Parse(this.getDataOrInit("friendlyfire", "false"));
        }
        set
        {
            this.KeyValues["friendlyfire"] = value.ToString();
        }
    }

    //// Token: 0x17000028 RID: 40
    //// (get) Token: 0x060000E2 RID: 226 RVA: 0x000079AC File Offset: 0x00005BAC
    //// (set) Token: 0x060000E3 RID: 227 RVA: 0x000079C0 File Offset: 0x00005BC0
    //public string Menpai
    //{
    //    get
    //    {
    //        return this.getDataOrInit("menpai", string.Empty);
    //    }
    //    set
    //    {
    //        this.KeyValues["menpai"] = value.ToString();
    //    }
    //}

    //// Token: 0x17000029 RID: 41
    //// (get) Token: 0x060000E4 RID: 228 RVA: 0x000079D8 File Offset: 0x00005BD8
    //// (set) Token: 0x060000E5 RID: 229 RVA: 0x000079EC File Offset: 0x00005BEC
    //public string Log
    //{
    //    get
    //    {
    //        return this.getDataOrInit("log", string.Empty);
    //    }
    //    set
    //    {
    //        this.KeyValues["log"] = value.ToString();
    //    }
    //}

    //// Token: 0x1700002A RID: 42
    //// (get) Token: 0x060000E6 RID: 230 RVA: 0x00007A04 File Offset: 0x00005C04
    //// (set) Token: 0x060000E7 RID: 231 RVA: 0x00007A1C File Offset: 0x00005C1C
    //public int DodgePoint
    //{
    //    get
    //    {
    //        return int.Parse(this.getDataOrInit("dodgePoint", "0"));
    //    }
    //    set
    //    {
    //        this.KeyValues["dodgePoint"] = value.ToString();
    //    }
    //}

    //// Token: 0x1700002B RID: 43
    //// (get) Token: 0x060000E8 RID: 232 RVA: 0x00007A38 File Offset: 0x00005C38
    //// (set) Token: 0x060000E9 RID: 233 RVA: 0x00007A50 File Offset: 0x00005C50
    //public int biliPoint
    //{
    //    get
    //    {
    //        return int.Parse(this.getDataOrInit("biliPoint", "0"));
    //    }
    //    set
    //    {
    //        this.KeyValues["biliPoint"] = value.ToString();
    //    }
    //}

    public int Rank
    {
        get
        {
            return int.Parse(this.getDataOrInit("rank", "0"));
        }
        set
        {
            this.KeyValues["rank"] = value.ToString();
        }
    }

    public void SetLocation(string mapKey, string location)
    {
        string key = "location." + mapKey;
        if (!this.KeyValues.ContainsKey(key))
        {
            this.KeyValues.Add(key, string.Empty);
        }
        this.KeyValues[key] = location;
    }

    //// Token: 0x060000ED RID: 237 RVA: 0x00007AE8 File Offset: 0x00005CE8
    //public string GetLocation(string mapKey)
    //{
    //    string key = "location." + mapKey;
    //    if (!this.KeyValues.ContainsKey(key))
    //    {
    //        this.KeyValues.Add(key, string.Empty);
    //    }
    //    return this.KeyValues[key];
    //}

    public string CurrentBigMap
    {
        get
        {
            return this.getDataOrInit("currentBigMap", "大地图");
        }
        set
        {
            this.KeyValues["currentBigMap"] = value.ToString();
        }
    }

    /// <summary>
    /// 试炼角色
    /// </summary>
    public string TrialRoles
    {
        get
        {
            return this.getDataOrInit("trailRoles", string.Empty);
        }
        set
        {
            this.KeyValues["trailRoles"] = value.ToString();
        }
    }

    //// Token: 0x060000F2 RID: 242 RVA: 0x00007B88 File Offset: 0x00005D88
    //public void AddLog(string info)
    //{
    //    string text = "江湖" + Tools.DateToString(this.Date);
    //    RuntimeData instance = RuntimeData.Instance;
    //    string log = instance.Log;
    //    instance.Log = string.Concat(new string[]
    //    {
    //            log,
    //            text,
    //            "，",
    //            info,
    //            "\r\n"
    //    });
    //}

    //// Token: 0x060000F3 RID: 243 RVA: 0x00007BE4 File Offset: 0x00005DE4
    //public void AddTimeKeyStory(string key, int days, string story)
    //{
    //    string key2 = "TIMEKEY_" + key;
    //    RuntimeData.Instance.KeyValues[key2] = string.Format("{0}#{1}#{2}", RuntimeData.Instance.Date, days, story);
    //}

    //// Token: 0x060000F4 RID: 244 RVA: 0x00007C30 File Offset: 0x00005E30
    //public void RemoveTimeKey(string key)
    //{
    //    string key2 = "TIMEKEY_" + key;
    //    if (RuntimeData.Instance.KeyValues.ContainsKey(key2))
    //    {
    //        RuntimeData.Instance.KeyValues.Remove(key2);
    //    }
    //}

    public string CheckTimeFlags()
    {
        List<string> list = new List<string>();
        foreach (string text in this.KeyValues.Keys)
        {
            if (text.StartsWith("TIMEKEY_"))
            {
                string text2 = this.KeyValues[text];
                DateTime d = DateTime.MinValue;
                try
                {
                    d = DateTime.Parse(text2.Split(new char[]
                    {
                                '#'
                    })[0]);
                }
                catch
                {
                    d = DateTime.ParseExact(text2.Split(new char[]
                    {
                                '#'
                    })[0], "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
                }
                int num = int.Parse(text2.Split(new char[]
                {
                            '#'
                })[1]);
                //if ((this.Date - d).TotalDays > (double)num)
                //{
                //    list.Add(text);
                //}
            }
        }
        string result = string.Empty;
        string text3 = string.Empty;
        foreach (string text4 in list)
        {
            string text5 = this.KeyValues[text4];
            if (text5.Split(new char[]
            {
                        '#'
            }).Length > 2)
            {
                result = text5.Split(new char[]
                {
                            '#'
                })[2];
                text3 = text4;
            }
            else
            {
                this.KeyValues.Remove(text4);
            }
        }
        if (text3 != null && !text3.Equals(string.Empty))
        {
            this.KeyValues.Remove(text3);
        }
        return result;
    }

    //public void AddFlag(string key)
    //{
    //    string key2 = "FLAG_" + key;
    //    RuntimeData.Instance.KeyValues[key2] = string.Format("{0}", RuntimeData.Instance.Date);
    //}

    //// Token: 0x060000F7 RID: 247 RVA: 0x00007EBC File Offset: 0x000060BC
    //public void RemoveFlag(string key)
    //{
    //    string key2 = "FLAG_" + key;
    //    if (RuntimeData.Instance.KeyValues.ContainsKey(key2))
    //    {
    //        RuntimeData.Instance.KeyValues.Remove(key2);
    //    }
    //}

    public bool HasFlag(string key)
    {
        string key2 = "FLAG_" + key;
        return RuntimeData.Instance.KeyValues.ContainsKey(key2);
    }

    public bool IsStoryFinished(string storyName)
    {
        return this.KeyValues.ContainsKey(storyName);
    }

    public void StoryFinish(string storyName, string storyResult)
    {
        if (!string.IsNullOrEmpty(storyName))
        {
            this.KeyValues[storyName] = storyResult;
        }
    }

    private string getDataOrInit(string key, string initValue = "")
    {
        if (!this.KeyValues.ContainsKey(key))
        {
            this.KeyValues[key] = initValue;
        }
        return this.KeyValues[key];
    }

    //// Token: 0x060000FC RID: 252 RVA: 0x00007F94 File Offset: 0x00006194
    //public string Save()
    //{
    //    GameSave gameSave = new GameSave();
    //    gameSave.Roles = GameSaveRole.Create(this.Team);
    //    gameSave.Follows = GameSaveRole.Create(this.Follow);
    //    gameSave.NewbieTask = this.NewbieTask;
    //    gameSave.GameItems = new GameSaveItem[this.Items.Count];
    //    int num = 0;
    //    foreach (KeyValuePair<ItemInstance, int> keyValuePair in this.Items)
    //    {
    //        if (keyValuePair.Value > 0)
    //        {
    //            gameSave.GameItems[num] = new GameSaveItem
    //            {
    //                name = keyValuePair.Key.Name,
    //                triggers = keyValuePair.Key.AdditionTriggers.ToArray(),
    //                count = keyValuePair.Value
    //            };
    //        }
    //        num++;
    //    }
    //    gameSave.XiangziItems = new GameSaveItem[this.Xiangzi.Count];
    //    num = 0;
    //    foreach (KeyValuePair<ItemInstance, int> keyValuePair2 in this.Xiangzi)
    //    {
    //        if (keyValuePair2.Value > 0)
    //        {
    //            gameSave.XiangziItems[num] = new GameSaveItem
    //            {
    //                name = keyValuePair2.Key.Name,
    //                triggers = keyValuePair2.Key.AdditionTriggers.ToArray(),
    //                count = keyValuePair2.Value
    //            };
    //        }
    //        num++;
    //    }
    //    gameSave.KeyValues = new GameSaveKeyValues[this.KeyValues.Count];
    //    num = 0;
    //    foreach (KeyValuePair<string, string> keyValuePair3 in this.KeyValues)
    //    {
    //        gameSave.KeyValues[num] = new GameSaveKeyValues
    //        {
    //            key = keyValuePair3.Key,
    //            value = keyValuePair3.Value
    //        };
    //        num++;
    //    }
    //    return Tools.SerializeXML<GameSave>(gameSave);
    //}

    //// Token: 0x060000FD RID: 253 RVA: 0x00008200 File Offset: 0x00006400
    //public bool Load(string str)
    //{
    //    GameSave gameSave = BasePojo.Create<GameSave>(str);
    //    this.Clear();
    //    if (gameSave.Roles != null)
    //    {
    //        foreach (GameSaveRole gameSaveRole in gameSave.Roles)
    //        {
    //            this.Team.Add(gameSaveRole.GenerateRole());
    //        }
    //    }
    //    if (gameSave.Follows != null)
    //    {
    //        foreach (GameSaveRole gameSaveRole2 in gameSave.Follows)
    //        {
    //            this.Follow.Add(gameSaveRole2.GenerateRole());
    //        }
    //    }
    //    this.NewbieTask = gameSave.NewbieTask;
    //    this.Items.Clear();
    //    if (gameSave.GameItems != null)
    //    {
    //        foreach (GameSaveItem gameSaveItem in gameSave.GameItems)
    //        {
    //            this.Items.Add(gameSaveItem.Generate(), gameSaveItem.count);
    //        }
    //    }
    //    this.Xiangzi.Clear();
    //    if (gameSave.XiangziItems != null)
    //    {
    //        foreach (GameSaveItem gameSaveItem2 in gameSave.XiangziItems)
    //        {
    //            this.Xiangzi.Add(gameSaveItem2.Generate(), gameSaveItem2.count);
    //        }
    //    }
    //    this.KeyValues.Clear();
    //    foreach (GameSaveKeyValues gameSaveKeyValues in gameSave.KeyValues)
    //    {
    //        this.KeyValues.Add(gameSaveKeyValues.key, gameSaveKeyValues.value);
    //    }
    //    this.IsInited = true;
    //    return true;
    //}
}


