using System;
using System.Collections.Generic;
using NS_RoleBaseFun;

public class RndSetMan
{
    public List<RenderSettingInfo> RndSetInfoList = new List<RenderSettingInfo>();

    public RenderSettingInfo GetRndSetInfo(int id)
    {
        foreach (RenderSettingInfo renderSettingInfo in this.RndSetInfoList)
        {
            if (renderSettingInfo.mapID == id)
            {
                return renderSettingInfo;
            }
        }
        return null;
    }

    public void LoadRndSetInfo()
    {
        string[] separator = new string[]
        {
            "\t"
        };
        this.RndSetInfoList.Clear();
        string filename = "res/RenderSettings";
        List<string> list = RoleBaseFun.LoadConfInAssets(filename);
        if (list.Count < 0)
        {
            return;
        }
        foreach (string text in list)
        {
            if (text == null || text.Length == 0)
            {
                break;
            }
            string[] array = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (array.Length > 0 && array.Length <= 17)
            {
                RenderSettingInfo renderSettingInfo = new RenderSettingInfo();
                int num = 0;
                renderSettingInfo.TextLoad(array, ref num);
                this.RndSetInfoList.Add(renderSettingInfo);
            }
        }
    }
}
