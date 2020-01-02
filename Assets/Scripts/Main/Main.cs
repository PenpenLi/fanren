using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using UnityEngine;

/// <summary>
/// 主要
/// </summary>
public class Main : MonoBehaviour
{
    [DllImport("kernel32")]
    public static extern void GlobalMemoryStatus(ref Main.MEMORY_INFO meminfo);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetCurrentProcess();

    [DllImport("psapi.dll", SetLastError = true)]
    private static extern bool GetProcessMemoryInfo(IntPtr hProcess, out Main.PROCESS_MEMORY_COUNTERS counters, uint size);

    public static string ClassName = "Main";

    private static GameObject MainGo;

    private static Main instance;

    private static string strText = "确定要退出游戏吗?未保存的进度将丢失.";

    private static int nMsgBoxID = -10;

    private bool bIsShowInfo;

    private Rect rc = new Rect(50f, 5f, 100f, 30f);

    public struct MEMORY_INFO
    {
        public uint dwLength;

        public uint dwMemoryLoad;

        public uint dwTotalPhys;

        public uint dwAvailPhys;

        public uint dwTotalPageFile;

        public uint dwAvailPageFile;

        public uint dwTotalVirtual;

        public uint dwAvailVirtual;
    }

    [StructLayout(LayoutKind.Sequential, Size = 40)]
    private struct PROCESS_MEMORY_COUNTERS
    {
        public uint cb;

        public uint PageFaultCount;

        public uint PeakWorkingSetSize;

        public uint WorkingSetSize;

        public uint QuotaPeakPagedPoolUsage;

        public uint QuotaPagedPoolUsage;

        public uint QuotaPeakNonPagedPoolUsage;

        public uint QuotaNonPagedPoolUsage;

        public uint PagefileUsage;

        public uint PeakPagefileUsage;
    }

	public static Main Instance
	{
		get
		{
			Main.InitMain();
			return Main.instance;
		}
	}

	public static void InitMain()
	{
		if (Main.instance != null)
		{
			return;
		}
		Main.MainGo = new GameObject(Main.ClassName);
		Main.instance = Main.MainGo.AddComponent<Main>();
		UnityEngine.Object.DontDestroyOnLoad(Main.MainGo);
		Main.AddComponents();
	}

    //public void GC()
    //{
    //	try
    //	{
    //		ResourceLoader.UnloadUnusedAssets();
    //		System.GC.Collect();
    //		UnityEngine.Debug.Log("System.GC.Collect!");
    //	}
    //	catch (Exception exception)
    //	{
    //		UnityEngine.Debug.LogException(exception);
    //	}
    //}

    public void DelayGC(float delayTime)
    {
        //this.CancelGC();
        //base.Invoke("GC", delayTime);
    }

    //public void CancelGC()
    //{
    //	base.CancelInvoke("GC");
    //}

    /// <summary>
    /// 添加组件
    /// </summary>
    private static void AddComponents()
    {
        Main.MainGo.AddComponent<KeyManager>();
        Main.MainGo.AddComponent<MouseManager>();
        Main.MainGo.AddComponent<BroadcastManager>();             
    }

    //截图
    //public void CaptureScreenshot()
    //{
    //	string text = Config.APPLICATION_NAME;
    //	string text2 = Application.dataPath;
    //	if (Application.isEditor)
    //	{
    //		text2 = text2.Substring(0, text2.Length - 6);
    //	}
    //	else
    //	{
    //		text2 = text2.Substring(0, text2.Length - 13);
    //	}
    //	text2 += "Screenshots/";
    //	if (!Directory.Exists(text2))
    //	{
    //		Directory.CreateDirectory(text2);
    //	}
    //	text += DateTime.Now.Year.ToString();
    //	text += DateTime.Now.Month.ToString();
    //	text = text + DateTime.Now.Day.ToString() + "_";
    //	text += DateTime.Now.Hour.ToString();
    //	text += DateTime.Now.Minute.ToString();
    //	text += DateTime.Now.Second.ToString();
    //	Application.CaptureScreenshot(text2 + text + ".png");
    //}

    //private static void LoadConfig()
    //{
    //	XmlDocument xmlDocument = new XmlDocument();
    //	xmlDocument.Load("Config.xml");
    //	XmlNode xmlNode = xmlDocument.SelectSingleNode("configuration");
    //	XmlNodeList childNodes = xmlNode.ChildNodes;
    //	foreach (object obj in childNodes)
    //	{
    //		XmlNode xmlNode2 = (XmlNode)obj;
    //		XmlNodeList childNodes2 = xmlNode2.ChildNodes;
    //		foreach (object obj2 in childNodes2)
    //		{
    //			XmlNode xmlNode3 = (XmlNode)obj2;
    //			XmlElement xmlElement = (XmlElement)xmlNode3;
    //			string attribute = xmlElement.GetAttribute("key");
    //			string attribute2 = xmlElement.GetAttribute("value");
    //			string text = attribute;
    //			switch (text)
    //			{
    //			case "version":
    //				Config.VERSION = attribute2;
    //				break;
    //			case "debug":
    //				Config.DEBUG = (attribute2 == "true");
    //				break;
    //			case "language":
    //				Config.LANGUAGE = attribute2;
    //				break;
    //			case "configPath":
    //				Config.CONFIG_PATH = attribute2;
    //				break;
    //			case "resourcePath":
    //				Config.RESOURCES_PATH = attribute2;
    //				break;
    //			}
    //		}
    //	}
    //}

    //public static void Quit()
    //{
    //	if (LoadingMain.loadingIsShow)
    //	{
    //		return;
    //	}
    //	if (Main.nMsgBoxID < 0)
    //	{
    //		Main.nMsgBoxID = Singleton<MsgBoxs>.GetInstance().MessageBox(-1, Main.strText, new Vector3(0f, 0f, -5.65f), new MsgBoxs.MsgBoxCallFunction(Main.ExcuteQuit));
    //	}
    //}

    //public static void KillQuit()
    //{
    //	try
    //	{
    //		Main.Instance.StopAllCoroutines();
    //		GameTime.Stop();
    //		Time.timeScale = 0f;
    //		if (!Application.isEditor)
    //		{
    //			PublishLog.Close();
    //		}
    //		if (!Application.isEditor)
    //		{
    //			Process.GetCurrentProcess().Kill();
    //		}
    //	}
    //	catch (Exception exception)
    //	{
    //		UnityEngine.Debug.LogException(exception);
    //	}
    //}

    //private void OnApplicationQuit()
    //{
    //	Main.Instance.GC();
    //	PublishLog.Close();
    //	if (Application.isEditor || LoadingMain.loadingIsShow || Application.loadedLevelName == "Landing" || Application.loadedLevelName == "Credits" || Application.loadedLevelName == "End" || Application.loadedLevelName == "Start")
    //	{
    //		return;
    //	}
    //	Application.CancelQuit();
    //	Main.Quit();
    //}

    //private static int ExcuteQuit(int id, int reslut, GameObject taget)
    //{
    //	if (reslut == 1)
    //	{
    //		Main.KillQuit();
    //	}
    //	Main.nMsgBoxID = -10;
    //	return 1;
    //}

    //private void ShowMemory()
    //{
    //	this.bIsShowInfo = !this.bIsShowInfo;
    //}

    private void OnGUI()
    {     
        //if (this.bIsShowInfo && Player.Instance != null && Player.Instance.m_cModAttribute != null)
        //{
        //    GUI.color = Color.red;
        //    //string text = "HanLi HP base:" + Player.Instance.m_cModAttribute.GetAttributeBaseNum(ATTRIBUTE_TYPE.ATT_HP).ToString();
        //    //text = text + "__add :" + Player.Instance.m_cModAttribute.GetAttributeAddNum(ATTRIBUTE_TYPE.ATT_HP).ToString();
        //    //text = text + "\n MaxHp base :" + Player.Instance.m_cModAttribute.GetAttributeBaseNum(ATTRIBUTE_TYPE.ATT_MAXHP).ToString();
        //    //text = text + "__ add :" + Player.Instance.m_cModAttribute.GetAttributeAddNum(ATTRIBUTE_TYPE.ATT_MAXHP).ToString();
        //    //GUI.Label(new Rect(100f, 0f, 220f, 100f), text);
        //}
        if (this.bIsShowInfo)
        {
            string text2 = "\n";
            text2 += SystemInfo.deviceModel;
            text2 += "\n";
            text2 += SystemInfo.graphicsDeviceName;
            text2 += "\t(";
            text2 += SystemInfo.graphicsMemorySize;
            text2 += " MB)";
            text2 += SystemInfo.graphicsDeviceVersion;
            text2 += "\n";
            long num = 0L;
            long num2 = 0L;
            Main.MEMORY_INFO memory_INFO = default(Main.MEMORY_INFO);
            Main.GlobalMemoryStatus(ref memory_INFO);
            long num3 = Convert.ToInt64(memory_INFO.dwTotalPhys.ToString()) / 1024L / 1024L;
            long num4 = Convert.ToInt64(memory_INFO.dwAvailPhys.ToString()) / 1024L / 1024L;
            long num5 = num3 - num4;
            IntPtr currentProcess = Main.GetCurrentProcess();
            Main.PROCESS_MEMORY_COUNTERS process_MEMORY_COUNTERS = default(Main.PROCESS_MEMORY_COUNTERS);
            process_MEMORY_COUNTERS.cb = (uint)Marshal.SizeOf(process_MEMORY_COUNTERS);
            if (Main.GetProcessMemoryInfo(currentProcess, out process_MEMORY_COUNTERS, process_MEMORY_COUNTERS.cb))
            {
                num = Convert.ToInt64(process_MEMORY_COUNTERS.PagefileUsage.ToString()) / 1024L / 1024L;
                num2 = Convert.ToInt64(process_MEMORY_COUNTERS.WorkingSetSize.ToString()) / 1024L / 1024L;
            }
            string text3 = text2;
            text2 = string.Concat(new object[]
            {
                text3,
                "Memory : \nTotalUsed = ",
                num5,
                "MB\n"
            });
            text3 = text2;
            text2 = string.Concat(new object[]
            {
                text3,
                "HaveMemory = ",
                num4,
                " MB\n"
            });
            text3 = text2;
            text2 = string.Concat(new object[]
            {
                text3,
                "Application Working Used = ",
                num2,
                " MB\n"
            });
            text3 = text2;
            text2 = string.Concat(new object[]
            {
                text3,
                "Application Page Used = ",
                num,
                " MB\n"
            });
            GUI.color = ((num4 <= 256L) ? Color.red : Color.yellow);
            GUI.Label(new Rect(5f, 50f, (float)Screen.width - 20f, (float)Screen.height - 20f), text2);
            GUI.color = Color.black;
        }
    }
}
