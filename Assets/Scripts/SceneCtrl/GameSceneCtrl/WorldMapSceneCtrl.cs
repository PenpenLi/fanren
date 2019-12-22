//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2015-12-06 07:43:41
//备    注：
//===================================================
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using YouYou;

/// <summary>
/// 世界地图场景的主控制器
/// </summary>
public class WorldMapSceneCtrl : GameSceneCtrlBase
{
    #region 属性
    /// <summary>
    /// 主角出生点
    /// </summary>
    [SerializeField]
    private Transform m_PlayerBornPos;

    private WorldMapEntity CurrWorldMapEntity;

    /// <summary>
    /// 传送点字典
    /// </summary>
    private Dictionary<int, WorldMapTransCtrl> m_TransPosDic;

    private float m_NextSendTime = 0;
    //private WorldMap_PosProto m_WorldMapPosProto = new WorldMap_PosProto();

    public static WorldMapSceneCtrl Instance;

    /// <summary>
    /// 所有角色字典
    /// </summary>
    //private Dictionary<int, RoleCtrl> m_AllRoleDic;
    #endregion

    #region OnAwake
    protected override void OnAwake()
    {
        base.OnAwake();
        Instance = this;
    }
    #endregion

    #region OnStart
    protected override void OnStart()
    {
        base.OnStart();
        m_TransPosDic = new Dictionary<int, WorldMapTransCtrl>();

       // m_AllRoleDic = new Dictionary<int, RoleCtrl>();
    }
    #endregion

    #region OnLoadUIMainCityViewComplete 加载主UI完毕
    /// <summary>
    /// 加载主UI完毕
    /// </summary>
    protected override void OnLoadUIMainCityViewComplete(UIFormBase t1)
    {
        base.OnLoadUIMainCityViewComplete(t1);

        //RoleMgr.Instance.InitMainPlayer();
        //if (GlobalInit.Instance.CurrPlayer != null)
        //{
        //    CurrWorldMapEntity = WorldMapDBModel.Instance.Get(SceneMgr.Instance.CurrWorldMapId);

        //    AudioBackGroundMgr.Instance.Play(CurrWorldMapEntity.Audio_BG);

        //    InitTransPos();

        //    //如果未设置玩家目标场景传送点 id 则使用表上配置的出生点
        //    if (SceneMgr.Instance.TargertWorldMapTransPosId == 0)
        //    {
        //        //如果服务器告诉了客户端 主角最后进入世界地图场景坐标信息
        //        if (!string.IsNullOrEmpty(PlayerCtrl.Instance.LastInWorldMapPos))
        //        {
        //            string[] arr = PlayerCtrl.Instance.LastInWorldMapPos.Split('_');
        //            Vector3 pos = new Vector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));

        //            GlobalInit.Instance.CurrPlayer.Born(pos);
        //            GlobalInit.Instance.CurrPlayer.gameObject.transform.eulerAngles = new Vector3(0, float.Parse(arr[3]), 0);
        //        }
        //        else
        //        {
        //            if (CurrWorldMapEntity.RoleBirthPostion != Vector3.zero)
        //            {
        //                GlobalInit.Instance.CurrPlayer.Born(CurrWorldMapEntity.RoleBirthPostion);
        //                GlobalInit.Instance.CurrPlayer.gameObject.transform.eulerAngles = new Vector3(0, CurrWorldMapEntity.RoleBirthEulerAnglesY, 0);
        //            }
        //            else
        //            {
        //                GlobalInit.Instance.CurrPlayer.Born(m_PlayerBornPos.position);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //找传送点
        //        if (m_TransPosDic.ContainsKey(SceneMgr.Instance.TargertWorldMapTransPosId))
        //        {
        //            Vector3 newBornPos = m_TransPosDic[SceneMgr.Instance.TargertWorldMapTransPosId].transform.forward.normalized * 3 + m_TransPosDic[SceneMgr.Instance.TargertWorldMapTransPosId].transform.position;
        //            Vector3 lookAtPos = m_TransPosDic[SceneMgr.Instance.TargertWorldMapTransPosId].transform.forward.normalized * 3.5f + m_TransPosDic[SceneMgr.Instance.TargertWorldMapTransPosId].transform.position;

        //            GlobalInit.Instance.CurrPlayer.Born(newBornPos);
        //            GlobalInit.Instance.CurrPlayer.transform.LookAt(lookAtPos);

        //            SceneMgr.Instance.TargertWorldMapTransPosId = 0;
        //        }
        //    }

        //    //客户端发送角色已经进入场景
        //    this.SendRoleAlreadyEnter(SceneMgr.Instance.CurrWorldMapId, GlobalInit.Instance.CurrPlayer.transform.position, GlobalInit.Instance.CurrPlayer.transform.eulerAngles.y);

        //    //当前玩家也添加
        //    m_AllRoleDic[GlobalInit.Instance.CurrPlayer.CurrRoleInfo.RoleId] = GlobalInit.Instance.CurrPlayer;

        //    PlayerCtrl.Instance.SetMainCityRoleData();

        //    //我加载完毕
        //    if (DelegateDefine.Instance.OnSceneLoadOk != null)
        //    {
        //        DelegateDefine.Instance.OnSceneLoadOk();
        //    }
        //}
        //StartCoroutine(InitNPC());
    }
    #endregion

    //#region InitNPC 初始化NPC
    ///// <summary>
    ///// 初始化NPC
    ///// </summary>
    ///// <returns></returns>
    //private IEnumerator InitNPC()
    //{
    //    yield return null;

    //    if (CurrWorldMapEntity == null) yield break;

    //    LoadNPC(0);
    //}

    //private void LoadNPC(int index)
    //{
    //    if (CurrWorldMapEntity.NPCWorldMapList.Count == 0) return;

    //    NPCWorldMapData data = CurrWorldMapEntity.NPCWorldMapList[index];
    //    NPCEntity entity = NPCDBModel.Instance.Get(data.NPCId);
    //    RoleMgr.Instance.LoadNPC(entity.PrefabName,
    //        (GameObject obj) =>
    //        {
    //            obj.transform.position = data.NPCPostion;
    //            obj.transform.eulerAngles = new Vector3(0, data.EulerAnglesY, 0);
    //            NPCCtrl ctrl = obj.GetComponent<NPCCtrl>();
    //            ctrl.Init(data);

    //            index++;
    //            if (index == CurrWorldMapEntity.NPCWorldMapList.Count)
    //            {
    //                AppDebug.Log("NPC加载完毕");
    //            }
    //            else
    //            {
    //                LoadNPC(index);
    //            }
    //        });

    //}

    //#endregion

    //#region InitTransPos 初始化传送点

    //string[] posInfoArr;

    ///// <summary>
    ///// 初始化传送点
    ///// </summary>
    ///// <returns></returns>
    //private void InitTransPos()
    //{
    //    posInfoArr = CurrWorldMapEntity.TransPos.Split('|');

    //    AssetBundleMgr.Instance.LoadOrDownload("Download/Prefab/Effect/Common/Efflect_Trans.assetbundle", "Efflect_Trans",
    //    (GameObject obj) =>
    //    {

    //        for (int i = 0; i < posInfoArr.Length; i++)
    //        {
    //            string[] posInfo = posInfoArr[i].Split('_');

    //            if (posInfo.Length == 7)
    //            {
    //                //坐标点
    //                Vector3 pos = new Vector3();

    //                float f = 0;

    //                float.TryParse(posInfo[0], out f);
    //                pos.x = f;

    //                float.TryParse(posInfo[1], out f);
    //                pos.y = f;

    //                float.TryParse(posInfo[2], out f);
    //                pos.z = f;

    //                //y轴旋转
    //                float y = 0;
    //                float.TryParse(posInfo[3], out y);


    //                //当前编号
    //                int currTransPosId = 0;
    //                int.TryParse(posInfo[4], out currTransPosId);

    //                int targetTransSceneId = 0;
    //                int targetSceneTransId = 0;
    //                int.TryParse(posInfo[5], out targetTransSceneId);
    //                int.TryParse(posInfo[6], out targetSceneTransId);

    //                GameObject objTrans = Instantiate(obj);
    //                objTrans.transform.position = pos;
    //                objTrans.transform.eulerAngles = new Vector3(0, y, 0);
    //                WorldMapTransCtrl ctrl = objTrans.GetComponent<WorldMapTransCtrl>();
    //                if (ctrl != null)
    //                {
    //                    ctrl.SetParam(currTransPosId, targetTransSceneId, targetSceneTransId);
    //                }

    //                m_TransPosDic[currTransPosId] = ctrl;
    //            }
    //        }
    //    });
    //}
    //#endregion

    //#region OnUpdate
    //protected override void OnUpdate()
    //{
    //    base.OnUpdate();

    //    if (Time.time > m_NextSendTime)
    //    {
    //        m_NextSendTime += 1f;
    //        SendPlayerPos();
    //    }
    //}
    //#endregion

    //#region BeforeOnDestroy
    //protected override void BeforeOnDestroy()
    //{
    //    base.BeforeOnDestroy();

    //    RemoveEventListener();
    //}
    //#endregion
}