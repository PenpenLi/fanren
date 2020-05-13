using System;
using System.Collections;
using System.Collections.Generic;
using SoftStar.Pal6;
//using SoftStar.Pal6.UI;
using UnityEngine;

public class PlayerCtrlManager
{
    //    public static bool bControl
    //    {
    //        get
    //        {
    //            return PlayerCtrlManager.m_bControl;
    //        }
    //        set
    //        {
    //            if (PlayerCtrlManager.m_bControl != value)
    //            {
    //                PlayerCtrlManager.m_bControl = value;
    //                if (PlayerCtrlManager.m_bControl)
    //                {
    //                    if (PlayerCtrlManager.agentObj != null)
    //                    {
    //                        PlayerCtrlManager.agentObj.curCtrlMode = ControlMode.ControlByPlayer;
    //                        PlayerCtrlManager.agentObj.IsInSky = false;
    //                    }
    //                }
    //                else if (PlayerCtrlManager.agentObj != null && PlayerCtrlManager.agentObj.animator != null)
    //                {
    //                    PlayerCtrlManager.agentObj.animator.SetBool("YuanDiZou", false);
    //                }
    //            }
    //        }
    //    }

    //    Token: 0x17000437 RID: 1079
    //	 (get) Token: 0x06003746 RID: 14150 RVA: 0x0018FDDC File Offset: 0x0018DFDC

    //    protected static Transform MainCam
    //    {
    //        get
    //        {
    //            if (PlayerCtrlManager.m_MainCam == null)
    //            {
    //                PlayerCtrlManager.m_MainCam = Camera.main.transform;
    //            }
    //            return PlayerCtrlManager.m_MainCam;
    //        }
    //    }

    //    Token: 0x17000438 RID: 1080
    //	 (get) Token: 0x06003747 RID: 14151 RVA: 0x0018FE10 File Offset: 0x0018E010

    //    private static CharacterController charCtrler
    //    {
    //        get
    //        {
    //            return PlayerCtrlManager.agentObj.GetComponent<CharacterController>();
    //        }
    //    }

    //    Token: 0x17000439 RID: 1081
    //	 (get) Token: 0x06003748 RID: 14152 RVA: 0x0018FE1C File Offset: 0x0018E01C

    //    public static Agent agentObj
    //    {
    //        get
    //        {
    //            if (PlayerCtrlManager.m_agentObj == null && PlayersManager.Player != null)
    //            {
    //                GameObject modelObj = PlayersManager.Player.GetModelObj(false);
    //                PlayerCtrlManager.m_agentObj = modelObj.GetComponent<Agent>();
    //                PlayerCtrlManager.PlayerModelTF = PlayerCtrlManager.m_agentObj.transform;
    //                PlayerCtrlManager.sneakAttack = PlayersManager.Player.GetComponent<SneakAttack>();
    //                if (PlayerCtrlManager.m_agentObj)
    //                {
    //                    PlayerCtrlManager.SetAgentProperty(PlayerCtrlManager.m_agentObj);
    //                }
    //            }
    //            return PlayerCtrlManager.m_agentObj;
    //        }
    //    }

    //    Token: 0x06003749 RID: 14153 RVA: 0x0018FE9C File Offset: 0x0018E09C

    //    private static void SetAgentProperty(Agent agent)
    //    {
    //        agent.curCtrlMode = ControlMode.ControlByPlayer;
    //        if (agent.charCtrller == null)
    //        {
    //            agent.charCtrller = agent.GetComponent<CharacterController>();
    //        }
    //        if (agent.charCtrller != null && !agent.charCtrller.enabled)
    //        {
    //            agent.charCtrller.enabled = true;
    //            agent.charCtrller.detectCollisions = true;
    //        }
    //        agent.gameObject.layer = 8;
    //        Animator animator = agent.animator;
    //        if (animator != null)
    //        {
    //            animator.Play("ZhanLi");
    //            animator.SetFloat("Speed", 0f);
    //            animator.SetBool("Move", false);
    //            animator.speed = 1f;
    //        }
    //        agent.IsJump = false;
    //        SmoothFollow2 orAddComponent = PalMain.MainCamera.GetOrAddComponent<SmoothFollow2>();
    //        orAddComponent.Init(agent.gameObject);
    //        if (agent.name == "YueJinChao" && animator != null)
    //        {
    //            float layerWeight = animator.GetLayerWeight(1);
    //            if (layerWeight < 0.5f && agent.palNPC != null)
    //            {
    //                List<GameObject> weapons = agent.palNPC.Weapons;
    //                foreach (GameObject gameObject in weapons)
    //                {
    //                    if (!(gameObject == null))
    //                    {
    //                        UtilFun.YueJinChaoShenSuo(gameObject.transform, Vector3.zero);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    Token: 0x0600374A RID: 14154 RVA: 0x0019003C File Offset: 0x0018E23C

    //    public static void Reset()
    //    {
    //        PlayerCtrlManager.m_agentObj = null;
    //    }

    //    Token: 0x0600374B RID: 14155 RVA: 0x00190044 File Offset: 0x0018E244

    //    public static void SetCtrlModel(GameObject go)
    //    {
    //        if (go == null)
    //        {
    //            return;
    //        }
    //        go = go.GetModelObj(false);
    //        Agent component = go.GetComponent<Agent>();
    //        if (component == null)
    //        {
    //            return;
    //        }
    //        PlayerCtrlManager.lastAgentObj = PlayerCtrlManager.m_agentObj;
    //        PlayerCtrlManager.m_agentObj = component;
    //        PlayerCtrlManager.m_agentObj.curCtrlMode = ControlMode.ControlByPlayer;
    //        PlayerCtrlManager.m_agentObj.animator.SetApplyRootMotion(true);
    //        SmoothFollow2 smoothFollow = Camera.main.GetComponent<SmoothFollow2>();
    //        if (smoothFollow == null)
    //        {
    //            smoothFollow = Camera.main.gameObject.AddComponent<SmoothFollow2>();
    //        }
    //        smoothFollow.Init(component.gameObject);
    //        PlayersManager.curCtrlModel = go;
    //        UIManager.Instance.DoNotOpenMainMenu = true;
    //    }

    //    Token: 0x0600374C RID: 14156 RVA: 0x001900EC File Offset: 0x0018E2EC

    //    public static void RestoreModel()
    //    {
    //        if (PlayerCtrlManager.lastAgentObj == null)
    //        {
    //            Debug.LogError("lastAgentObj == null");
    //            return;
    //        }
    //        if (PlayerCtrlManager.m_agentObj != null)
    //        {
    //            PlayerCtrlManager.m_agentObj.curCtrlMode = ControlMode.ControlByAgent;
    //        }
    //        else
    //        {
    //            Debug.LogError("RestoreModel恢复主角控制时m_agentObj==null");
    //        }
    //        if (PlayerCtrlManager.lastAgentObj != null)
    //        {
    //            PlayerCtrlManager.Reset();
    //        }
    //        else
    //        {
    //            Debug.LogError("RestoreModel恢复主角控制时lastAgentObj==null");
    //        }
    //        UIManager.Instance.DoNotOpenMainMenu = false;
    //    }

    //    Token: 0x0600374D RID: 14157 RVA: 0x00190170 File Offset: 0x0018E370

    //    public static void Initialize()
    //    {
    //        GameStateManager.AddInitStateFun(GameState.Normal, new GameStateManager.void_fun(PlayerCtrlManager.OnInit));
    //        GameStateManager.AddEndStateFun(GameState.Normal, new GameStateManager.void_fun(PlayerCtrlManager.OnExit));
    //        PalMain.GameMain.updateHandles += PlayerCtrlManager.Update;
    //        PlayerCtrlManager.MoveID = Animator.StringToHash("Move");
    //        SaveManager.OnLoadOver -= PlayerCtrlManager.LoadOver;
    //        SaveManager.OnLoadOver += PlayerCtrlManager.LoadOver;
    //        PlayerCtrlManager.maskValue = 393220;
    //        PlayerCtrlManager.maskValue = ~PlayerCtrlManager.maskValue;
    //    }

    //    Token: 0x0600374E RID: 14158 RVA: 0x00190200 File Offset: 0x0018E400

    //    private static void OnInit()
    //    {
    //        PlayerCtrlManager.SetJumpEvent(true);
    //        PlayerCtrlManager.bControl = true;
    //        if (PlayerCtrlManager.agentObj != null)
    //        {
    //            PlayerCtrlManager.SetAgentProperty(PlayerCtrlManager.agentObj);
    //        }
    //        SmoothFollow2[] componentsInChildren = PalMain.MainCamera.GetComponentsInChildren<SmoothFollow2>(true);
    //        for (int i = 0; i < componentsInChildren.Length; i++)
    //        {
    //            componentsInChildren[i].enabled = true;
    //        }
    //        PlayerCtrlManager.bCanTab = true;
    //        PlayerCtrlManager.bCtrlOther = false;
    //    }

    //    Token: 0x0600374F RID: 14159 RVA: 0x00190268 File Offset: 0x0018E468

    //    public static void OnExit()
    //    {
    //        if (GameStateManager.NextGameState != GameState.SmallGame)
    //        {
    //            PlayerCtrlManager.bControl = false;
    //            if (PlayerCtrlManager.agentObj != null && PlayerCtrlManager.agentObj.animator != null)
    //            {
    //                PlayerCtrlManager.agentObj.animator.SetBool("Move", false);
    //                if (PlayerCtrlManager.agentObj.animCtrl == null)
    //                {
    //                    Debug.LogError("Error : " + PlayerCtrlManager.agentObj.name + " animCtrl==null 现在补上");
    //                    PlayerCtrlManager.agentObj.animCtrl = PlayerCtrlManager.agentObj.gameObject.GetOrAddComponent<AnimCtrlScript>();
    //                }
    //                PlayerCtrlManager.agentObj.animCtrl.ActiveAnim("ZhanLi", false, false, false);
    //                PlayerCtrlManager.agentObj.animCtrl.ActiveZhanDou(false, 1, true, true, false);
    //                AnimatorValueRestore.ActiveSet(PlayerCtrlManager.agentObj.animator, "Speed", 0f, 0.5f, false);
    //            }
    //        }
    //        if (GameStateManager.NextGameState == GameState.MainGUI && PlayerCtrlManager.agentObj != null && PlayerCtrlManager.agentObj.charCtrller != null)
    //        {
    //            PlayerCtrlManager.agentObj.charCtrller.enabled = false;
    //        }
    //        SmoothFollow2 component = Camera.main.GetComponent<SmoothFollow2>();
    //        if (component != null)
    //        {
    //            component.enabled = false;
    //        }
    //    }

    //    Token: 0x06003750 RID: 14160 RVA: 0x001903B4 File Offset: 0x0018E5B4

    //    public static void SetJumpEvent(bool bActive)
    //    {
    //        if (bActive)
    //        {
    //            PlayerCtrlManager.ProcessSpaceKey = (PlayerCtrlManager.void_fun_Agent)Delegate.Remove(PlayerCtrlManager.ProcessSpaceKey, new PlayerCtrlManager.void_fun_Agent(PlayerCtrlManager.JumpEvent));
    //            PlayerCtrlManager.ProcessSpaceKey = (PlayerCtrlManager.void_fun_Agent)Delegate.Combine(PlayerCtrlManager.ProcessSpaceKey, new PlayerCtrlManager.void_fun_Agent(PlayerCtrlManager.JumpEvent));
    //        }
    //        else
    //        {
    //            PlayerCtrlManager.ProcessSpaceKey = (PlayerCtrlManager.void_fun_Agent)Delegate.Remove(PlayerCtrlManager.ProcessSpaceKey, new PlayerCtrlManager.void_fun_Agent(PlayerCtrlManager.JumpEvent));
    //        }
    //    }

    //    Token: 0x06003751 RID: 14161 RVA: 0x0019042C File Offset: 0x0018E62C

    //    public static void JumpEvent(Agent agentObj)
    //    {
    //        if (PlayerCtrlManager.bCtrlOther)
    //        {
    //            return;
    //        }
    //        Animator animator = agentObj.animator;
    //        Locomotion locomotion = agentObj.locomotion;
    //        AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
    //        AnimatorStateInfo nextAnimatorStateInfo = animator.GetNextAnimatorStateInfo(0);
    //        if (currentAnimatorStateInfo.IsName("yidongState.ZhanLi") || currentAnimatorStateInfo.IsName("yidongState.YiDong") || currentAnimatorStateInfo.IsName("yidongState.ZhuoDi") || currentAnimatorStateInfo.IsName("yidongState.ZhuoDiPao") || currentAnimatorStateInfo.IsName("yidongState.XiuXian") || currentAnimatorStateInfo.IsName("yidongState.YuanDiZou"))
    //        {
    //            UIManager.Instance.DoNotOpenMainMenu = true;
    //            SneakAttack.canQiXi = false;
    //            agentObj.IsJump = true;
    //            agentObj.animCtrl.ActiveAnimCrossFade("TiaoQi", false, 0.03f, true);
    //            animator.SetFloat("VerticalSpeed", 10f);
    //            locomotion.firstShang = true;
    //            agentObj.CanSecondJump = true;
    //            bool flag = InputManager.GetDir() != Vector3.zero || PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Auto || PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Mouse1 || PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Mouse2;
    //            locomotion.ZhiKongMag = ((!flag) ? 0f : agentObj.AniRunSpeed);
    //            PlayerCtrlManager.JumpPosition = agentObj.transform.position;
    //        }
    //    }

    //    Token: 0x06003752 RID: 14162 RVA: 0x0019057C File Offset: 0x0018E77C

    //    private static void Update(float curTime, float deltaTime)
    //    {
    //        if (!PlayerCtrlManager.bControl || PlayerCtrlManager.agentObj == null || !PlayerCtrlManager.agentObj.animator)
    //        {
    //            return;
    //        }
    //        Animator animator = PlayerCtrlManager.agentObj.animator;
    //        Locomotion locomotion = PlayerCtrlManager.agentObj.locomotion;
    //        if (InputManager.GetKeyDown(KEY_ACTION.MOUSE_RIGHT, false) || InputManager.GetKeyUp(KEY_ACTION.MOUSE_RIGHT, false) || InputManager.GetKeyDown(KEY_ACTION.CAMERA_LEFT, false) || InputManager.GetKeyDown(KEY_ACTION.CAMERA_RIGHT, false) || InputManager.GetKeyUp(KEY_ACTION.CAMERA_LEFT, false) || InputManager.GetKeyUp(KEY_ACTION.CAMERA_RIGHT, false))
    //        {
    //            PlayerCtrlManager.LastForward = PlayerCtrlManager.MainCam.forward;
    //        }
    //        if (Input.anyKeyDown)
    //        {
    //            if (PlayerCtrlManager.CanChangeState && InputManager.GetKeyDown(KEY_ACTION.CHAGNESTATE, false))
    //            {
    //                AnimCtrlScript component = animator.GetComponent<AnimCtrlScript>();
    //                if (component != null)
    //                {
    //                    component.ActiveBattle(animator.GetLayerWeight(1) <= 0.5f);
    //                }
    //            }
    //            if (PlayerCtrlManager.bCanTab && InputManager.GetKeyDown(KEY_ACTION.TAB, false) && GameStateManager.CurGameState != GameState.Battle && (PlayerCtrlManager.charCtrler.isGrounded || Physics.Raycast(PlayerCtrlManager.agentObj.transform.position, Vector3.down, 0.07f)) && !PlayerCtrlManager.agentObj.IsJump)
    //            {
    //                PlayersManager.TabPlayer();
    //            }
    //            if (InputManager.GetKeyDown(KEY_ACTION.ACTION, false) && !PlayerCtrlManager.agentObj.IsJump)
    //            {
    //                PalNPC palNPC = PlayerCtrlManager.agentObj.palNPC;
    //                if (palNPC != null && palNPC.perception != null)
    //                {
    //                    if (palNPC.interActs.Count < 1)
    //                    {
    //                        Transform transform = null;
    //                        float num = 10000f;
    //                        foreach (Transform transform2 in palNPC.perception.hostsCanBeSeen)
    //                        {
    //                            Vector3 vector = transform2.gameObject.GetModelObj(false).transform.position - PlayerCtrlManager.agentObj.transform.position;
    //                            if (vector.magnitude < num)
    //                            {
    //                                num = vector.magnitude;
    //                                transform = transform2;
    //                            }
    //                        }
    //                        if (transform != null)
    //                        {
    //                            Interact component2 = transform.GetComponent<Interact>();
    //                            if (component2 != null)
    //                            {
    //                                float num2 = PlayerCtrlManager.agentObj.ActionRadius;
    //                                MouseEnterCursor componentInChildren = component2.GetComponentInChildren<MouseEnterCursor>();
    //                                if (componentInChildren != null && CursorScriptTemp.Instance.tempTypeDic.ContainsKey(componentInChildren.curState))
    //                                {
    //                                    num2 = CursorScriptTemp.Instance.tempTypeDic[componentInChildren.curState].dis;
    //                                }
    //                                if (num < num2)
    //                                {
    //                                    component2.InterAct();
    //                                }
    //                            }
    //                        }
    //                    }
    //                    else
    //                    {
    //                        Interact.LastInteractNPC = palNPC.gameObject;
    //                        palNPC.interActs[0].InterAct();
    //                    }
    //                }
    //            }
    //        }
    //        SneakAttack.SneakUpdate();
    //        if (InputManager.GetKeyDown(KEY_ACTION.JUMP, false) && PlayerCtrlManager.ProcessSpaceKey != null)
    //        {
    //            SlideDown instance = SlideDown.Instance;
    //            if (instance != null)
    //            {
    //                if (instance.CanJump())
    //                {
    //                    SlideDown.Instance.enabled = false;
    //                    PlayerCtrlManager.ProcessSpaceKey(PlayerCtrlManager.agentObj);
    //                }
    //            }
    //            else
    //            {
    //                PlayerCtrlManager.ProcessSpaceKey(PlayerCtrlManager.agentObj);
    //            }
    //        }
    //        if (PlayerCtrlManager.agentObj.IsInSky && PlayerCtrlManager.agentObj.CanSmallMove && InputManager.curKeyDir != KeyDirection.NONE)
    //        {
    //            PlayerCtrlManager.agentObj.CanSmallMove = false;
    //            Vector3 curMoveDir = PlayerCtrlManager.GetCurMoveDir();
    //            Transform transform3 = PlayerCtrlManager.agentObj.transform;
    //            locomotion.ZhiKongSpeedVec = curMoveDir.normalized;
    //            locomotion.ZhiKongSpeedVec.y = 0f;
    //            locomotion.ZhiKongSpeedVec *= PlayerCtrlManager.agentObj.SmallMoveSpeed;
    //            PlayerCtrlManager.agentObj.CanSlowByKeyUp = true;
    //        }
    //        if (PlayerCtrlManager.agentObj.IsInSky && PlayerCtrlManager.agentObj.CanSlowByKeyUp && InputManager.curKeyDir == KeyDirection.NONE)
    //        {
    //            PlayerCtrlManager.agentObj.SlowDownVel();
    //        }
    //        if (!InputManager.GetKey(KEY_ACTION.WALK, false))
    //        {
    //            if (PlayerCtrlManager.agentObj.CurSpeed < PlayerCtrlManager.agentObj.RunSpeed - 0.01f)
    //            {
    //                PlayerCtrlManager.agentObj.CurSpeed = Mathf.Lerp(PlayerCtrlManager.agentObj.CurSpeed, PlayerCtrlManager.agentObj.RunSpeed, PlayerCtrlManager.agentObj.dampSpeed * Time.deltaTime);
    //            }
    //            else if (PlayerCtrlManager.agentObj.CurSpeed > PlayerCtrlManager.agentObj.RunSpeed)
    //            {
    //                PlayerCtrlManager.agentObj.CurSpeed = PlayerCtrlManager.agentObj.RunSpeed;
    //            }
    //        }
    //        else if (PlayerCtrlManager.agentObj.CurSpeed > PlayerCtrlManager.agentObj.WalkSpeed + 0.01f)
    //        {
    //            PlayerCtrlManager.agentObj.CurSpeed = Mathf.Lerp(PlayerCtrlManager.agentObj.CurSpeed, PlayerCtrlManager.agentObj.WalkSpeed, PlayerCtrlManager.agentObj.dampSpeed * 0.7f * Time.deltaTime);
    //        }
    //        else if (PlayerCtrlManager.agentObj.CurSpeed < PlayerCtrlManager.agentObj.WalkSpeed)
    //        {
    //            PlayerCtrlManager.agentObj.CurSpeed = PlayerCtrlManager.agentObj.WalkSpeed;
    //        }
    //        if (InputManager.GetKeyDown(KEY_ACTION.MOUSE_LEFT, false))
    //        {
    //            if (PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Mouse1)
    //            {
    //                MessageProcess.Instance.AddMess(Message.Style.EndAction, new Action(PlayerCtrlManager.OnMouseMove));
    //            }
    //            else
    //            {
    //                MessageProcess.Instance.AddMess(Message.Style.Action, new Action(PlayerCtrlManager.OnMouseMove));
    //            }
    //        }
    //        if (PlayerCtrlManager.MouseLeftDown && InputManager.GetKey(KEY_ACTION.MOUSE_LEFT, false) && PlayerCtrlManager.CurControlModel != PlayerCtrlManager.PlayerControlModel.Mouse1 && PlayerCtrlManager.CurControlModel != PlayerCtrlManager.PlayerControlModel.Mouse2)
    //        {
    //            if (Vector3.SqrMagnitude(Input.mousePosition - PlayerCtrlManager.MouseLeftDownPos) > 4f)
    //            {
    //                PlayerCtrlManager.MouseLeftMove = true;
    //            }
    //            if (!PlayerCtrlManager.MouseLeftMove && Time.time - PlayerCtrlManager.MouseLeftDownTime > CursorScriptTemp.Instance.followCursorTime)
    //            {
    //                SmoothFollow2 component3 = Camera.main.GetComponent<SmoothFollow2>();
    //                if (component3 != null)
    //                {
    //                    component3.bControl = false;
    //                }
    //                PlayerCtrlManager.CurControlModel = PlayerCtrlManager.PlayerControlModel.Mouse1;
    //                CursorScriptTemp.CursorShow = null;
    //                CursorScriptTemp.Instance.CursorTexToState(CursorTextureState.FollowCursor, -1f);
    //                PalMain.Instance.StartCoroutine(PlayerCtrlManager.DelayShow());
    //            }
    //        }
    //        if (InputManager.GetKeyUp(KEY_ACTION.MOUSE_LEFT, false))
    //        {
    //            Debug.Log("MouseLeftDown = false");
    //            PlayerCtrlManager.MouseLeftDown = false;
    //            if (PlayerCtrlManager.curControlModel == PlayerCtrlManager.PlayerControlModel.Mouse1 || PlayerCtrlManager.curControlModel == PlayerCtrlManager.PlayerControlModel.Mouse2)
    //            {
    //                MessageProcess.Instance.AddMess(Message.Style.EndAction, new Action(PlayerCtrlManager.OnMouseUp));
    //            }
    //        }
    //        if (InputManager.GetKeyDown(KEY_ACTION.AUTO_WALK, false))
    //        {
    //            if (PlayerCtrlManager.CurControlModel != PlayerCtrlManager.PlayerControlModel.Auto)
    //            {
    //                PlayerCtrlManager.CurControlModel = PlayerCtrlManager.PlayerControlModel.Auto;
    //            }
    //            else
    //            {
    //                PlayerCtrlManager.CurControlModel = PlayerCtrlManager.PlayerControlModel.None;
    //            }
    //        }
    //        if (InputManager.GetKey(KEY_ACTION.UP, false) || InputManager.GetKey(KEY_ACTION.DOWN, false) || InputManager.GetKey(KEY_ACTION.LEFT, false) || InputManager.GetKey(KEY_ACTION.RIGHT, false) || InputManager.GetKey(KEY_ACTION.UPARROW, false) || InputManager.GetKey(KEY_ACTION.DOWNARROW, false) || InputManager.GetKey(KEY_ACTION.LEFTARROW, false) || InputManager.GetKey(KEY_ACTION.RIGHTARROW, false))
    //        {
    //            PlayerCtrlManager.CurControlModel = PlayerCtrlManager.PlayerControlModel.Keyboard;
    //        }
    //        else if (PlayerCtrlManager.MouseLeftDown && InputManager.GetKey(KEY_ACTION.MOUSE_LEFT, false) && InputManager.GetKey(KEY_ACTION.MOUSE_RIGHT, false))
    //        {
    //            PlayerCtrlManager.CurControlModel = PlayerCtrlManager.PlayerControlModel.Mouse2;
    //        }
    //        else if (PlayerCtrlManager.CurControlModel != PlayerCtrlManager.PlayerControlModel.Auto && PlayerCtrlManager.CurControlModel != PlayerCtrlManager.PlayerControlModel.Mouse1)
    //        {
    //            PlayerCtrlManager.CurControlModel = PlayerCtrlManager.PlayerControlModel.None;
    //        }
    //        TurnHead2 component4 = PlayersManager.Player.GetModelObj(false).GetComponent<TurnHead2>();
    //        if (PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Keyboard || PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Mouse2 || PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Mouse1 || PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Auto)
    //        {
    //            Vector3 forward = animator.transform.forward;
    //            forward.y = 0f;
    //            Vector3 dir = InputManager.GetDir();
    //            if (PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Auto)
    //            {
    //                dir.z = 1f;
    //            }
    //            else if (PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Mouse2)
    //            {
    //                dir.z = 1f;
    //            }
    //            else if (PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.Mouse1)
    //            {
    //                PlayerCtrlManager.PlayerScenePos = Camera.main.WorldToScreenPoint(PlayerCtrlManager.agentObj.transform.position);
    //                PlayerCtrlManager.PlayerScenePos.z = 0f;
    //                PlayerCtrlManager.tempDirection = Input.mousePosition - PlayerCtrlManager.PlayerScenePos;
    //                PlayerCtrlManager.tempDirection.Normalize();
    //                if (PlayerCtrlManager.PlayerScenePos.y < 0f && Input.mousePosition.y < 15f)
    //                {
    //                    PlayerCtrlManager.tempDirection.y = -1f;
    //                }
    //                dir.x = PlayerCtrlManager.tempDirection.x;
    //                dir.z = PlayerCtrlManager.tempDirection.y;
    //            }
    //            if (dir != Vector3.zero)
    //            {
    //                if (!animator.GetBool(PlayerCtrlManager.MoveID))
    //                {
    //                    animator.SetBool(PlayerCtrlManager.MoveID, true);
    //                }
    //                dir.Normalize();
    //                Vector3 vector2;
    //                if (InputManager.GetKey(KEY_ACTION.MOUSE_RIGHT, false) || InputManager.GetKey(KEY_ACTION.CAMERA_LEFT, false) || InputManager.GetKey(KEY_ACTION.CAMERA_RIGHT, false))
    //                {
    //                    vector2 = PlayerCtrlManager.MainCam.forward;
    //                    animator.SetBool("YuanDiZou", false);
    //                    PlayerCtrlManager.RRoundUp = true;
    //                }
    //                else
    //                {
    //                    vector2 = PlayerCtrlManager.LastForward;
    //                }
    //                vector2.y = 0f;
    //                PlayerCtrlManager.angle = Vector3.Angle(Vector3.forward, vector2);
    //                PlayerCtrlManager.cross = Vector3.Cross(Vector3.forward, vector2);
    //                if (PlayerCtrlManager.cross.y < -0.001f)
    //                {
    //                    PlayerCtrlManager.angle = 360f - PlayerCtrlManager.angle;
    //                }
    //                PlayerCtrlManager.referentialShift = Quaternion.AngleAxis(PlayerCtrlManager.angle, Vector3.up);
    //                PlayerCtrlManager.moveDirection = PlayerCtrlManager.referentialShift * dir;
    //                PlayerCtrlManager.moveDirection.y = 0f;
    //                if (!PlayerCtrlManager.agentObj.IsInSky)
    //                {
    //                    float num3 = Vector3.Angle(forward, PlayerCtrlManager.moveDirection);
    //                    PlayerCtrlManager.speed = Mathf.Lerp(PlayerCtrlManager.speed, PlayerCtrlManager.agentObj.CurSpeed, Time.deltaTime * PlayerCtrlManager.agentObj.dampSpeed);
    //                    float num4 = PlayerCtrlManager.speed;
    //                    if (PlayerCtrlManager.UseSunddenlyTurn && (!InputManager.GetKey(KEY_ACTION.MOUSE_RIGHT, false) || PlayerCtrlManager.agentObj.CurSpeed > PlayerCtrlManager.agentObj.WalkSpeed) && num3 > 135f && !PlayerCtrlManager.agentObj.IsInSky)
    //                    {
    //                        PlayerCtrlManager.agentObj.transform.forward = PlayerCtrlManager.moveDirection;
    //                        num3 = 0f;
    //                    }
    //                    if (PlayerCtrlManager.agentObj.CurSpeed <= PlayerCtrlManager.agentObj.WalkSpeed && InputManager.GetKey(KEY_ACTION.MOUSE_RIGHT, false) && num3 > 100f && num4 > 0f)
    //                    {
    //                        num4 *= -1f;
    //                    }
    //                    if (Vector3.Cross(forward, PlayerCtrlManager.moveDirection).y < 0f)
    //                    {
    //                        num3 *= -1f;
    //                    }
    //                    locomotion.Do(num4, num3, PlayerCtrlManager.agentObj.transform, PlayerCtrlManager.moveDirection);
    //                }
    //            }
    //            else
    //            {
    //                PlayerCtrlManager.CurControlModel = PlayerCtrlManager.PlayerControlModel.None;
    //            }
    //        }
    //        if (PlayerCtrlManager.CurControlModel == PlayerCtrlManager.PlayerControlModel.None)
    //        {
    //            float @float = animator.GetFloat("Speed");
    //            if (Mathf.Abs(@float) > 0.01f)
    //            {
    //                PlayerCtrlManager.speed = 0f;
    //                locomotion.Do(0f, 0f, PlayerCtrlManager.agentObj.transform, PlayerCtrlManager.moveDirection);
    //            }
    //            else
    //            {
    //                animator.SetFloat("Speed", 0f);
    //                bool @bool = animator.GetBool(PlayerCtrlManager.MoveID);
    //                if (@bool)
    //                {
    //                    animator.SetBool(PlayerCtrlManager.MoveID, false);
    //                }
    //            }
    //            if ((InputManager.GetKey(KEY_ACTION.MOUSE_RIGHT, false) || InputManager.GetKey(KEY_ACTION.CAMERA_LEFT, false) || InputManager.GetKey(KEY_ACTION.CAMERA_RIGHT, false)) && !PlayerCtrlManager.agentObj.IsJump)
    //            {
    //                if (PlayerCtrlManager.RRoundUp)
    //                {
    //                    PlayerCtrlManager.RRoundUp = false;
    //                }
    //                PlayerCtrlManager.TempForward = PlayerCtrlManager.MainCam.forward;
    //                PlayerCtrlManager.TempForward.y = 0f;
    //                Vector3 forward2 = PlayerCtrlManager.agentObj.transform.forward;
    //                forward2.y = 0f;
    //                float num5 = Vector3.Angle(PlayerCtrlManager.TempForward, forward2);
    //                if (num5 > 0.4f)
    //                {
    //                    animator.SetBool("YuanDiZou", true);
    //                    num5 = ((num5 <= 100f) ? num5 : 100f);
    //                    PlayerCtrlManager.lookAtWeight = num5 / 100f;
    //                    if (Vector3.Cross(forward2, PlayerCtrlManager.TempForward).y < 0f)
    //                    {
    //                        num5 = -num5;
    //                    }
    //                    Transform transform4 = PlayerCtrlManager.agentObj.transform;
    //                    Transform transform5 = GameObjectPath.GetEyeObjs(transform4)[0];
    //                    float num6 = transform5.position.y - transform4.position.y;
    //                    Quaternion rotation = Quaternion.AngleAxis(num5, transform4.up);
    //                    Vector3 target = rotation * transform4.forward * 10f + transform4.position;
    //                    target.y = transform4.position.y + num6;
    //                    component4.target = target;
    //                }
    //                else if (num5 < 0.01f)
    //                {
    //                    animator.SetBool("YuanDiZou", false);
    //                    PlayerCtrlManager.RRoundUp = true;
    //                }
    //                PlayerCtrlManager.agentObj.transform.forward = Vector3.RotateTowards(PlayerCtrlManager.agentObj.transform.forward, PlayerCtrlManager.TempForward, deltaTime * locomotion.ORotSpeed, deltaTime * locomotion.ORotSpeed);
    //            }
    //            else if (!PlayerCtrlManager.agentObj.IsInSky)
    //            {
    //                if (PlayerCtrlManager.XiuXianDelay <= 0f)
    //                {
    //                    float layerWeight = animator.GetLayerWeight(1);
    //                    if (layerWeight <= 0f)
    //                    {
    //                        animator.CrossFade("yidongState.XiuXian", 0.05f);
    //                    }
    //                    PlayerCtrlManager.XiuXianDelay = UnityEngine.Random.Range(10f, 25f);
    //                }
    //                else if (GameStateManager.CurGameState == GameState.Normal)
    //                {
    //                    PlayerCtrlManager.XiuXianDelay -= Time.deltaTime;
    //                }
    //            }
    //            if (InputManager.GetKeyUp(KEY_ACTION.MOUSE_RIGHT, false) || InputManager.GetKeyUp(KEY_ACTION.CAMERA_LEFT, false) || InputManager.GetKeyUp(KEY_ACTION.CAMERA_RIGHT, false))
    //            {
    //                animator.SetBool("YuanDiZou", false);
    //                PlayerCtrlManager.RRoundUp = true;
    //            }
    //            if (PlayerCtrlManager.RRoundUp)
    //            {
    //                PlayerCtrlManager.lookAtWeight -= deltaTime;
    //                if (PlayerCtrlManager.lookAtWeight <= 0f)
    //                {
    //                    PlayerCtrlManager.RRoundUp = false;
    //                    PlayerCtrlManager.lookAtWeight = 0f;
    //                    component4.lookAtWeight = 0f;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            PlayerCtrlManager.lookAtWeight = 0f;
    //            component4.lookAtWeight = 0f;
    //            if (PlayerCtrlManager.XiuXianDelay <= 0f)
    //            {
    //                PlayerCtrlManager.XiuXianDelay = UnityEngine.Random.Range(10f, 25f);
    //            }
    //        }
    //        if (PlayerCtrlManager.lookAtWeight > 0f)
    //        {
    //            component4.lookAtWeight = PlayerCtrlManager.lookAtWeight;
    //        }
    //        if (GameStateManager.CurGameState == GameState.Normal)
    //        {
    //            PlayerCtrlManager.agentObj.AgentUpdate();
    //            if (PlayerCtrlManager.agentObj.IsInSky)
    //            {
    //                PlayerCtrlManager.CheckReset();
    //            }
    //        }
    //    }

    public static void OnLevelLoaded(int level)
    {
        if (level != 11)
        {
            if (level != 19)
            {
                if (level != 27)
                {
                    //PlayerCtrlManager.ResetHeight = -10000f;
                    //PlayerCtrlManager.ResetSpecil = false;
                }
                else
                {
                    //PlayerCtrlManager.ResetHeight = 59f;
                    //PlayerCtrlManager.ResetSpecil = false;
                }
            }
            else
            {
                //PlayerCtrlManager.ResetHeight = 270f;
                //PlayerCtrlManager.ResetSpecil = false;
            }
        }
        else
        {
            //PlayerCtrlManager.ResetHeight = 90f;
            //PlayerCtrlManager.ResetSpecil = true;
            //PlayerCtrlManager.ResetSepcilPos = new Vector3(599.7473f, 104.578f, 198.2703f);
        }
    }

    //    private static void CheckReset()
    //    {
    //        if (PlayerCtrlManager.agentObj.transform.position.y < PlayerCtrlManager.ResetHeight)
    //        {
    //            if (!PlayerCtrlManager.ResetSpecil)
    //            {
    //                GameObject gameObject = GameObject.Find("SceneEnter");
    //                if (gameObject != null)
    //                {
    //                    SceneFall.Reset(gameObject.transform.position);
    //                }
    //            }
    //            else
    //            {
    //                SceneFall.Reset(PlayerCtrlManager.ResetSepcilPos);
    //            }
    //        }
    //    }

    //    Token: 0x06003755 RID: 14165 RVA: 0x001915A0 File Offset: 0x0018F7A0

    //    public static Vector3 GetCurMoveDir()
    //    {
    //        return PlayerCtrlManager.moveDirection;
    //    }

    //    Token: 0x1700043A RID: 1082
    //	 (get) Token: 0x06003756 RID: 14166 RVA: 0x001915A8 File Offset: 0x0018F7A8

    //     (set) Token: 0x06003757 RID: 14167 RVA: 0x001915B0 File Offset: 0x0018F7B0

    //    private static PlayerCtrlManager.PlayerControlModel CurControlModel
    //    {
    //        get
    //        {
    //            return PlayerCtrlManager.curControlModel;
    //        }
    //        set
    //        {
    //            if (PlayerCtrlManager.curControlModel == PlayerCtrlManager.PlayerControlModel.Mouse1 && value != PlayerCtrlManager.PlayerControlModel.Mouse1)
    //            {
    //                SmoothFollow2 component = Camera.main.GetComponent<SmoothFollow2>();
    //                if (component != null)
    //                {
    //                    component.bControl = true;
    //                }
    //                CursorScriptTemp.CursorShow = new CursorScriptTemp.FunHander(CursorScriptTemp.Instance.ProcessCursorShow);
    //                CursorScriptTemp.Instance.CursorTexToNormal();
    //            }
    //            PlayerCtrlManager.curControlModel = value;
    //        }
    //    }

    //    Token: 0x06003758 RID: 14168 RVA: 0x00191614 File Offset: 0x0018F814

    //    public static void LoadOver()
    //    {
    //        PlayerCtrlManager.LastForward = PlayerCtrlManager.MainCam.forward;
    //    }

    //    Token: 0x06003759 RID: 14169 RVA: 0x00191628 File Offset: 0x0018F828

    //    private static void OnMouseMove()
    //    {
    //        PlayerCtrlManager.MouseLeftDownTime = Time.time;
    //        PlayerCtrlManager.MouseLeftDown = true;
    //        PlayerCtrlManager.MouseLeftMove = false;
    //        PlayerCtrlManager.MouseLeftDownPos = Input.mousePosition;
    //    }

    //    Token: 0x0600375A RID: 14170 RVA: 0x00191658 File Offset: 0x0018F858

    //    private static void OnMouseUp()
    //    {
    //        if (Time.time - PlayerCtrlManager.MouseLeftDownTime < CursorScriptTemp.Instance.followCursorTime)
    //        {
    //            PlayerCtrlManager.CurControlModel = PlayerCtrlManager.PlayerControlModel.None;
    //        }
    //    }

    //    Token: 0x0600375B RID: 14171 RVA: 0x00191688 File Offset: 0x0018F888

    //    private static IEnumerator DelayShow()
    //    {
    //        yield return new WaitForEndOfFrame();
    //        CursorScriptTemp.Instance.ShowCursor();
    //        yield break;
    //    }

    //    Token: 0x040031A9 RID: 12713
    //	private static bool m_bControl = true;

    //    Token: 0x040031AA RID: 12714
    //	public static bool bCanTab = true;

    //    Token: 0x040031AB RID: 12715
    //	public static bool bCtrlOther = false;

    //    Token: 0x040031AC RID: 12716
    //	public static bool CanChangeState = false;

    //    Token: 0x040031AD RID: 12717
    //	protected static Transform m_MainCam;

    //    Token: 0x040031AE RID: 12718
    //	public static bool UseSunddenlyTurn = true;

    //    Token: 0x040031AF RID: 12719
    //	private static int MoveID = 0;

    //    Token: 0x040031B0 RID: 12720
    //	private static Quaternion LastRot;

    //    Token: 0x040031B1 RID: 12721
    //	public static Vector3 LastForward;

    //    Token: 0x040031B2 RID: 12722
    //	private static Vector3 LastStrickDirection;

    //    Token: 0x040031B3 RID: 12723
    //	private static Vector3 LastPosition;

    //    Token: 0x040031B4 RID: 12724
    //	private static Vector3 moveDirection;

    //    Token: 0x040031B5 RID: 12725
    //	private static float speed = 0f;

    //    Token: 0x040031B6 RID: 12726
    //	private static Vector3 TempForward;

    //    Token: 0x040031B7 RID: 12727
    //	private static KeyDirection JumpKeyDir = KeyDirection.NONE;

    //    Token: 0x040031B8 RID: 12728
    //	public static int maskValue = 0;

    //    Token: 0x040031B9 RID: 12729
    //	private static SneakAttack sneakAttack = null;

    //    Token: 0x040031BA RID: 12730
    //	public static bool CanJumpSecond = true;

    //    Token: 0x040031BB RID: 12731
    //	private static Agent m_agentObj;

    //    Token: 0x040031BC RID: 12732
    //	public static Transform PlayerModelTF = null;

    //    Token: 0x040031BD RID: 12733
    //	private static Agent lastAgentObj = null;

    //    Token: 0x040031BE RID: 12734
    //	public static PlayerCtrlManager.void_fun_Agent ProcessSpaceKey = null;

    //    Token: 0x040031BF RID: 12735
    //	public static Vector3 JumpPosition = Vector3.zero;

    //    Token: 0x040031C0 RID: 12736
    //	private static float lookAtWeight = 0f;

    //    Token: 0x040031C1 RID: 12737
    //	private static bool RRoundUp = false;

    //    Token: 0x040031C2 RID: 12738
    //	public static bool bAutoWalk = false;

    //    Token: 0x040031C3 RID: 12739
    //	private static float XiuXianDelay = 15f;

    //    Token: 0x040031C4 RID: 12740
    //	private static float MouseLeftDownTime = 0f;

    //    Token: 0x040031C5 RID: 12741
    //	private static float MouseRightDownTime = 0f;

    //    Token: 0x040031C6 RID: 12742
    //	private static bool MouseLeftDown = false;

    //    Token: 0x040031C7 RID: 12743
    //	private static bool MouseLeftMove = false;

    //    Token: 0x040031C8 RID: 12744
    //	private static Vector3 MouseLeftDownPos = Vector3.zero;

    //    Token: 0x040031C9 RID: 12745
    //	private static Vector3 PlayerScenePos = Vector3.zero;

    //    Token: 0x040031CA RID: 12746
    //	private static Vector3 tempDirection = Vector3.zero;

    //    Token: 0x040031CB RID: 12747
    //	private static float angle = 0f;

    //    Token: 0x040031CC RID: 12748
    //	private static Vector3 cross = Vector3.up;

    //    Token: 0x040031CD RID: 12749
    //	private static Quaternion referentialShift = Quaternion.identity;

    //    Token: 0x040031CE RID: 12750
    //	private static float ResetHeight = 0f;

    //    Token: 0x040031CF RID: 12751
    //	private static bool ResetSpecil = false;

    //    Token: 0x040031D0 RID: 12752
    //	private static Vector3 ResetSepcilPos = Vector3.zero;

    //    Token: 0x040031D1 RID: 12753
    //	private static PlayerCtrlManager.PlayerControlModel curControlModel = PlayerCtrlManager.PlayerControlModel.None;

    //    Token: 0x020007B0 RID: 1968
    //	private enum PlayerControlModel
    //    {
    //        Token: 0x040031D3 RID: 12755

    //        None,
    //        Token: 0x040031D4 RID: 12756

    //        Keyboard,
    //        Token: 0x040031D5 RID: 12757

    //        Mouse1,
    //        Token: 0x040031D6 RID: 12758

    //        Mouse2,
    //        Token: 0x040031D7 RID: 12759

    //        Auto
    //    }

    //    public delegate void void_fun_Agent(Agent agentObj);
}
