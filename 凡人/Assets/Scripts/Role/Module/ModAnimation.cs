using System;
using System.Collections.Generic;
using NS_RoleBaseFun;
using UnityEngine;

public class ModAnimation : Module
{
    private CharacterController m_cCharacterController;

    public Animation _animation;

    //private ACTION_INDEX _defaultAni = ACTION_INDEX.AN_IDLE;

    private AnimationState m_cCurrentAniState;

    private string m_strLastAniName = string.Empty;

    //private MoveBase m_cCurrentMove;

    private float m_fCurrentAniLength;

    private float m_fCurrentMaxAniLength;

    public float m_fAniSpeed = 1f;

    private float m_fCurrentAniSpeed = 1f;

    //private AnimationSoundData.Data m_cCurrentSoundData;

    //private AniInfo.AniInfoNode m_cCurAniNode;

    //public ACTION_INDEX _curAniIndex;

    public int _curSoundIdx;

    public float AniSpeed = 1f;

    public bool EnableAnimationMove = true;

    private ModFight m_cModFight;

    private float m_fAniStartTime;

    private List<bool> m_lstIsEffect = new List<bool>();

    private List<bool> m_lstIsMove = new List<bool>();

    private List<int> m_lstNowEffect = new List<int>();

    private List<bool> m_lstSound = new List<bool>();

    private List<int> m_lstSoundID = new List<int>();

    private List<bool> m_lstSoundEndDes = new List<bool>();

    private float soundTimeCount;

    private string faceAniName;

    public ModAnimation(Role role, Animation ani, CharacterController cc) : base(role)
	{
		this.m_cCharacterController = cc;
		this._animation = ani;
		base.ModType = MODULE_TYPE.MT_MOTION;
	}

	public override bool Init()
	{
		base.Init();
		return true;
	}

	private ModFight modFight
	{
		get
		{
			if (this.m_cModFight == null)
			{
				//this.m_cModFight = (this._role.GetModule(MODULE_TYPE.MT_FIGHT) as ModFight);
			}
			return this.m_cModFight;
		}
	}

	//public ACTION_INDEX DefaultAni
	//{
	//	get
	//	{
	//		return this._defaultAni;
	//	}
	//	set
	//	{
	//		this._defaultAni = value;
	//	}
	//}

	//public float CurrentAniLength
	//{
	//	get
	//	{
	//		return this.m_fCurrentAniLength;
	//	}
	//}

	//public float MaxAniLength
	//{
	//	get
	//	{
	//		return this.m_fCurrentMaxAniLength;
	//	}
	//}

	//// Token: 0x17000408 RID: 1032
	//// (get) Token: 0x0600213F RID: 8511 RVA: 0x00017102 File Offset: 0x00015302
	//public AniInfo.AniInfoNode CurAniInfo
	//{
	//	get
	//	{
	//		return this.m_cCurAniNode;
	//	}
	//}

	//// Token: 0x17000409 RID: 1033
	//// (get) Token: 0x06002140 RID: 8512 RVA: 0x0001710A File Offset: 0x0001530A
	//public ACTION_INDEX CurAniIndex
	//{
	//	get
	//	{
	//		return this._curAniIndex;
	//	}
	//}

	//// Token: 0x1700040A RID: 1034
	//// (get) Token: 0x06002141 RID: 8513 RVA: 0x00017112 File Offset: 0x00015312
	//public AnimationState CurrentAniState
	//{
	//	get
	//	{
	//		return this.m_cCurrentAniState;
	//	}
	//}

	//// Token: 0x06002142 RID: 8514 RVA: 0x000E27C8 File Offset: 0x000E09C8
	//public void SetSpeed(float speed)
	//{
	//	this.m_fAniSpeed = speed;
	//	if (this._animation != null && this._animation[this.m_strLastAniName] != null)
	//	{
	//		this._animation[this.m_strLastAniName].speed = this.m_fAniSpeed * this.m_cCurAniNode.SpeedRateBase * this.m_fCurrentAniSpeed;
	//		Debug.Log(string.Concat(new object[]
	//		{
	//			this.m_strLastAniName,
	//			"  ",
	//			this.m_fAniSpeed,
	//			"  ....................................."
	//		}));
	//	}
	//}

	//// Token: 0x06002143 RID: 8515 RVA: 0x0001711A File Offset: 0x0001531A
	//public void SetCurSpeed(float speed)
	//{
	//	this.m_fCurrentAniSpeed = speed;
	//}

	//// Token: 0x06002144 RID: 8516 RVA: 0x000E2870 File Offset: 0x000E0A70
	//private long IndexToId(ACTION_INDEX actIdx, bool bDefHorse, bool bDefWeapon, bool bDefMesh)
	//{
	//	long nHorse = 99L;
	//	long nWeaponIndex = 999L;
	//	long nMeshIndex = 9999L;
	//	if (!bDefHorse)
	//	{
	//		nHorse = this._role.GetHorseIdx();
	//	}
	//	if (!bDefWeapon)
	//	{
	//		nWeaponIndex = this._role.GetWeaponIdx();
	//	}
	//	if (!bDefMesh)
	//	{
	//		nMeshIndex = this._role.GetMeshIdx();
	//	}
	//	return GameData.Instance.RoleData.GetAniId(nHorse, nWeaponIndex, nMeshIndex, (long)actIdx);
	//}

	//// Token: 0x06002145 RID: 8517 RVA: 0x000E28DC File Offset: 0x000E0ADC
	//public override void Process()
	//{
	//	if (this._animation == null)
	//	{
	//		return;
	//	}
	//	if (this.m_cCurrentAniState == null)
	//	{
	//		return;
	//	}
	//	if (this.m_fCurrentAniLength >= 0f)
	//	{
	//		this.m_fCurrentAniLength -= GameTime.deltaTime * this.m_cCurrentAniState.speed;
	//	}
	//	else if (this.m_fCurrentAniLength < 0f)
	//	{
	//		if (this.m_cCurrentAniState.wrapMode == WrapMode.Loop)
	//		{
	//			this.m_fCurrentAniLength = this.m_cCurrentAniState.length;
	//		}
	//		else
	//		{
	//			this.m_fCurrentAniLength = 0f;
	//		}
	//	}
	//	if (this._animation != null)
	//	{
	//		this.m_cCurrentAniState.speed = GameTime.timeScale * this.m_fCurrentAniSpeed * this.AniSpeed;
	//	}
	//	this.UpdateEffect();
	//	this.UpdateMove();
	//	this.UpdataSound();
	//}

	//// Token: 0x06002146 RID: 8518 RVA: 0x00017123 File Offset: 0x00015323
	//public float GetAniProgress()
	//{
	//	if (this.m_cCurrentAniState == null)
	//	{
	//		return 0f;
	//	}
	//	return 1f - this.m_fCurrentAniLength / this.m_cCurrentAniState.length;
	//}

	//// Token: 0x06002147 RID: 8519 RVA: 0x000E29C4 File Offset: 0x000E0BC4
	//private void UpdateAni()
	//{
	//	if (this.m_cCurrentAniState == null)
	//	{
	//		return;
	//	}
	//	if (this.m_cCurrentAniState.wrapMode == WrapMode.Loop && this.m_fCurrentAniLength < 0f)
	//	{
	//		this.m_fCurrentAniLength = this.m_fCurrentMaxAniLength;
	//	}
	//	if (this.m_cCurrentAniState.wrapMode == WrapMode.ClampForever && this.m_fCurrentAniLength < 0f)
	//	{
	//		this.m_fCurrentAniLength = 0f;
	//	}
	//	if (this.m_cCurrentAniState.wrapMode == WrapMode.Once && this.m_fCurrentAniLength < 0f)
	//	{
	//		this.m_cCurrentAniState = null;
	//		this.m_fAniSpeed = 0f;
	//		this._curAniIndex = ACTION_INDEX.AN_NONE;
	//		this.m_cCurAniNode = null;
	//		this._curSoundIdx = 0;
	//		this.m_fCurrentMaxAniLength = 0f;
	//		return;
	//	}
	//	this.m_cCurrentAniState.time = this.m_fCurrentMaxAniLength - this.m_fCurrentAniLength;
	//}

	//// Token: 0x06002148 RID: 8520 RVA: 0x000E2AA8 File Offset: 0x000E0CA8
	//private void UpdateEffect()
	//{
	//	if (this.m_fCurrentAniLength <= 0f)
	//	{
	//		return;
	//	}
	//	if (this.m_cCurAniNode == null)
	//	{
	//		return;
	//	}
	//	for (int i = 0; i < this.m_cCurAniNode.AniEffectInfoList.Count; i++)
	//	{
	//		AniInfo.AniEffectInfo aniEffectInfo = this.m_cCurAniNode.AniEffectInfoList[i];
	//		if (aniEffectInfo.EffectId != 0)
	//		{
	//			if (this.m_cCurrentAniState.length - this.m_fCurrentAniLength >= aniEffectInfo.StartTime && !this.m_lstIsEffect[i])
	//			{
	//				this.m_lstIsEffect[i] = true;
	//				Transform transform = this._role.GetTrans();
	//				Vector3 vector = new Vector3(0f, 0f, 0f);
	//				Quaternion rot = Quaternion.Euler(vector);
	//				if (aniEffectInfo.BoneName != "0")
	//				{
	//					transform = RoleBaseFun.FindDescendants(this._role.GetTrans(), aniEffectInfo.BoneName);
	//				}
	//				else
	//				{
	//					rot = this._role.GetTrans().rotation;
	//				}
	//				if (transform == null)
	//				{
	//					transform = this._role.GetTrans();
	//				}
	//				Vector3 position = transform.position;
	//				int item = SingletonMono<EffectManager>.GetInstance().AddEffect(aniEffectInfo.EffectId, position, vector, position, rot, transform.gameObject, false);
	//				CEffectData effectInfo = Singleton<EffectTableManager>.GetInstance().GetEffectInfo(aniEffectInfo.EffectId);
	//				if (effectInfo.Type != 1)
	//				{
	//					this.m_lstNowEffect.Add(item);
	//				}
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06002149 RID: 8521 RVA: 0x000E2C2C File Offset: 0x000E0E2C
	//private void UpdateMove()
	//{
	//	if (!this.EnableAnimationMove)
	//	{
	//		return;
	//	}
	//	if (this.m_fCurrentAniLength <= 0f)
	//	{
	//		this.m_cCurrentMove = null;
	//		return;
	//	}
	//	if (this.m_cCurrentMove != null)
	//	{
	//		if (!this.m_cCurrentMove.Update())
	//		{
	//			this.m_cCurrentMove = null;
	//		}
	//	}
	//	if (this.m_cCurAniNode == null)
	//	{
	//		return;
	//	}
	//	if (this.m_lstIsMove.Count != this.m_cCurAniNode.AniMoveList.Count)
	//	{
	//		for (int i = 0; i < this.m_cCurAniNode.AniMoveList.Count; i++)
	//		{
	//			this.m_lstIsMove.Add(false);
	//		}
	//	}
	//	for (int j = 0; j < this.m_cCurAniNode.AniMoveList.Count; j++)
	//	{
	//		if (!this.m_lstIsMove[j])
	//		{
	//			AniInfo.AniMoveInfo aniMoveInfo = this.m_cCurAniNode.AniMoveList[j];
	//			if (aniMoveInfo.Distance != 0f || aniMoveInfo.Height != 0f)
	//			{
	//				float num = aniMoveInfo.StartTime * this.m_fCurrentMaxAniLength;
	//				float num2 = aniMoveInfo.EndTime * this.m_fCurrentMaxAniLength;
	//				float time = this.m_cCurrentAniState.time;
	//				if (num2 > num)
	//				{
	//					if (time >= num)
	//					{
	//						float num3 = 0f;
	//						if (aniMoveInfo.MoveType != 2)
	//						{
	//							num3 = Math.Abs(aniMoveInfo.Distance) / ((num2 - num) / this.m_cCurrentAniState.speed);
	//						}
	//						if (aniMoveInfo.MoveType == 0)
	//						{
	//							if (aniMoveInfo.Distance > 0f)
	//							{
	//								MoveBackForward moveBackForward = new MoveBackForward(this._role, this.m_cCharacterController);
	//								this.m_cCurrentMove = moveBackForward;
	//								if (this._role.modMFS.GetCurrentStateId() == CONTROL_STATE.HURT)
	//								{
	//									moveBackForward.ResetPhysicsMove(aniMoveInfo.Distance, num2 - num);
	//								}
	//								else
	//								{
	//									this.m_cCurrentMove.Reset(ACTION_INDEX.AN_NONE, num3);
	//									this.m_cCurrentMove.SwitchGravity(true);
	//									this.m_cCurrentMove.SetDistance(aniMoveInfo.Distance);
	//								}
	//								if (this._role.modMFS.GetCurrentStateId() == CONTROL_STATE.ATTACK)
	//								{
	//									if (this.modFight.TargetRole != null)
	//									{
	//										Vector3 from = this.modFight.TargetRole.GetPos() - this._role.GetPos();
	//										from.y = 0f;
	//										if (Vector3.Angle(from, this._role.GetTrans().forward) < 1f)
	//										{
	//											moveBackForward.OpenCorrect(true);
	//										}
	//									}
	//									else if (this.modFight.AttackDir == Vector3.zero)
	//									{
	//										moveBackForward.OpenCorrect(true);
	//									}
	//									else if (Vector3.Angle(this.modFight.AttackDir, this._role.GetTrans().forward) < 1f)
	//									{
	//										moveBackForward.OpenCorrect(true);
	//									}
	//								}
	//							}
	//							else if (aniMoveInfo.Distance < 0f)
	//							{
	//								MoveBackForward moveBackForward2 = new MoveBackForward(this._role, this.m_cCharacterController);
	//								this.m_cCurrentMove = moveBackForward2;
	//								if (this._role.modMFS.GetCurrentStateId() == CONTROL_STATE.HURT)
	//								{
	//									moveBackForward2.ResetPhysicsMove(aniMoveInfo.Distance, num2 - num);
	//								}
	//								else
	//								{
	//									this.m_cCurrentMove.Reset(ACTION_INDEX.AN_NONE, -num3);
	//									this.m_cCurrentMove.SwitchGravity(true);
	//									this.m_cCurrentMove.SetDistance(-aniMoveInfo.Distance);
	//								}
	//								if (this._role.modMFS.GetCurrentStateId() == CONTROL_STATE.ATTACK)
	//								{
	//									if (this.modFight.TargetRole != null)
	//									{
	//										Vector3 from2 = this.modFight.TargetRole.GetPos() - this._role.GetPos();
	//										from2.y = 0f;
	//										if (Vector3.Angle(from2, this._role.GetTrans().forward) < 1f)
	//										{
	//											moveBackForward2.OpenCorrect(true);
	//										}
	//									}
	//									else if (this.modFight.AttackDir == Vector3.zero)
	//									{
	//										moveBackForward2.OpenCorrect(true);
	//									}
	//									else if (Vector3.Angle(this.modFight.AttackDir, this._role.GetTrans().forward) < 1f)
	//									{
	//										moveBackForward2.OpenCorrect(true);
	//									}
	//								}
	//							}
	//						}
	//						else if (aniMoveInfo.MoveType == 1)
	//						{
	//							if (aniMoveInfo.Distance > 0f)
	//							{
	//								this.m_cCurrentMove = new MoveHorizontal(this._role, this.m_cCharacterController);
	//								this.m_cCurrentMove.Reset(ACTION_INDEX.AN_NONE, -num3);
	//								this.m_cCurrentMove.SetTargetPos(Vector3.zero);
	//								this.m_cCurrentMove.SwitchGravity(true);
	//								this.m_cCurrentMove.SetDistance(aniMoveInfo.Distance);
	//							}
	//							else
	//							{
	//								this.m_cCurrentMove = new MoveHorizontal(this._role, this.m_cCharacterController);
	//								this.m_cCurrentMove.Reset(ACTION_INDEX.AN_NONE, num3);
	//								this.m_cCurrentMove.SetTargetPos(Vector3.zero);
	//								this.m_cCurrentMove.SwitchGravity(true);
	//								this.m_cCurrentMove.SetDistance(-aniMoveInfo.Distance);
	//							}
	//						}
	//						else if (aniMoveInfo.MoveType == 2)
	//						{
	//							return;
	//						}
	//						this.m_lstIsMove[j] = true;
	//						break;
	//					}
	//					if (!this.m_lstIsMove[j])
	//					{
	//						this.m_cCurrentMove = null;
	//					}
	//				}
	//			}
	//		}
	//	}
	//}

	//// Token: 0x0600214A RID: 8522 RVA: 0x000E3194 File Offset: 0x000E1394
	//private void UpdataSound()
	//{
	//	if (this.m_cCurrentSoundData == null)
	//	{
	//		return;
	//	}
	//	if (this.m_lstSound.Count != this.m_cCurrentSoundData.SoundID.Length)
	//	{
	//		this.ResetSound();
	//	}
	//	this.soundTimeCount += GameTime.deltaTime * this.m_cCurrentAniState.speed;
	//	if (this.m_cCurrentAniState.wrapMode == WrapMode.Loop && this.soundTimeCount >= this.m_cCurrentAniState.length)
	//	{
	//		this.RemoveLastSound();
	//		this.ResetSound();
	//	}
	//	for (int i = 0; i < this.m_cCurrentSoundData.SoundID.Length; i++)
	//	{
	//		if (this.soundTimeCount >= this.m_cCurrentSoundData.StartTime[i] * this.m_cCurrentAniState.length && !this.m_lstSound[i])
	//		{
	//			int item = 0;
	//			AudioClip audioClip = SingletonMono<AudioManager>.GetInstance().GetAudioClip(this.m_cCurrentSoundData.SoundID[i]);
	//			if (audioClip != null)
	//			{
	//				if (audioClip.length < 1f)
	//				{
	//					ModVoice modVoice = this._role.GetModule(MODULE_TYPE.MT_VOICE) as ModVoice;
	//					modVoice.PlayOneShotSound(this.m_cCurrentSoundData.SoundID[i]);
	//				}
	//				else
	//				{
	//					SoundData soundData = SingletonMono<AudioManager>.GetInstance().PlaySound(SoundType.gameSound, base.Role.GetTrans(), this.m_cCurrentSoundData.SoundID[i], false);
	//					if (soundData != null)
	//					{
	//						item = soundData.soundIndex;
	//					}
	//				}
	//			}
	//			this.m_lstSoundID.Add(item);
	//			this.m_lstSoundEndDes.Add(this.m_cCurrentSoundData.EndDestroy[i]);
	//			this.m_lstSound[i] = true;
	//		}
	//	}
	//}

	//// Token: 0x0600214B RID: 8523 RVA: 0x000E333C File Offset: 0x000E153C
	//public AniInfo GetAniInfoByIdx(ACTION_INDEX actIdx)
	//{
	//	AniInfo aniInfoById = Singleton<AniInfoStaticManager>.GetInstance().GetAniInfoById(this.IndexToId(actIdx, false, false, false));
	//	if (aniInfoById == null)
	//	{
	//		aniInfoById = Singleton<AniInfoStaticManager>.GetInstance().GetAniInfoById(this.IndexToId(actIdx, true, false, false));
	//		if (aniInfoById == null)
	//		{
	//			aniInfoById = Singleton<AniInfoStaticManager>.GetInstance().GetAniInfoById(this.IndexToId(actIdx, true, true, false));
	//			if (aniInfoById == null)
	//			{
	//				aniInfoById = Singleton<AniInfoStaticManager>.GetInstance().GetAniInfoById(this.IndexToId(actIdx, true, false, true));
	//				if (aniInfoById == null)
	//				{
	//					aniInfoById = Singleton<AniInfoStaticManager>.GetInstance().GetAniInfoById(this.IndexToId(ACTION_INDEX.AN_DEFAULT, true, true, false));
	//					if (aniInfoById == null)
	//					{
	//						aniInfoById = Singleton<AniInfoStaticManager>.GetInstance().GetAniInfoById(this.IndexToId(actIdx, true, true, true));
	//					}
	//				}
	//			}
	//		}
	//	}
	//	return aniInfoById;
	//}

	//// Token: 0x0600214C RID: 8524 RVA: 0x000E33EC File Offset: 0x000E15EC
	//public AniInfo.AniInfoNode GetAniInfoNodeByIdx(ACTION_INDEX actIdx, int idx)
	//{
	//	AniInfo aniInfoByIdx = this.GetAniInfoByIdx(actIdx);
	//	if (aniInfoByIdx == null)
	//	{
	//		if (actIdx != ACTION_INDEX.AN_NONE)
	//		{
	//			Logger.Log(new object[]
	//			{
	//				actIdx + " aniNameInfo is missing!"
	//			});
	//		}
	//		return null;
	//	}
	//	if (aniInfoByIdx != null)
	//	{
	//		if (idx < 0 || idx >= aniInfoByIdx.AniNameList.Count)
	//		{
	//			idx = 0;
	//		}
	//		return aniInfoByIdx.AniNameList[idx];
	//	}
	//	return null;
	//}

	//// Token: 0x0600214D RID: 8525 RVA: 0x000E345C File Offset: 0x000E165C
	//public string GetAniNameByIdx(ACTION_INDEX aniIndex)
	//{
	//	AniInfo.AniInfoNode aniInfoNodeByIdx = this.GetAniInfoNodeByIdx(aniIndex);
	//	if (aniInfoNodeByIdx == null)
	//	{
	//		return null;
	//	}
	//	return aniInfoNodeByIdx.Name;
	//}

	//// Token: 0x0600214E RID: 8526 RVA: 0x00017154 File Offset: 0x00015354
	//public AniInfo.AniInfoNode GetAniInfoNodeByIdx(ACTION_INDEX actIdx)
	//{
	//	if (actIdx == ACTION_INDEX.AN_NONE)
	//	{
	//		return null;
	//	}
	//	return this.GetAniInfoNodeByIdx(actIdx, 0);
	//}

	//// Token: 0x0600214F RID: 8527 RVA: 0x000E3480 File Offset: 0x000E1680
	//public AniInfo.AniInfoNode GetAniInfoNodeRandom(ACTION_INDEX actIdx)
	//{
	//	AniInfo aniInfoByIdx = this.GetAniInfoByIdx(actIdx);
	//	if (aniInfoByIdx == null)
	//	{
	//		return null;
	//	}
	//	int num = UnityEngine.Random.Range(0, aniInfoByIdx.AniNameList.Count);
	//	if (aniInfoByIdx != null)
	//	{
	//		if (num < 0 || num >= aniInfoByIdx.AniNameList.Count)
	//		{
	//			num = 0;
	//		}
	//		return aniInfoByIdx.AniNameList[num];
	//	}
	//	return null;
	//}

	//// Token: 0x06002150 RID: 8528 RVA: 0x0000221B File Offset: 0x0000041B
	//private void PlayAniSound(int SoundIdx, bool bLoop)
	//{
	//}

	//// Token: 0x06002151 RID: 8529 RVA: 0x00017166 File Offset: 0x00015366
	//private void PlayAnimation(string aniName, bool isBlend, bool resetAnimation)
	//{
	//	this.PlayAnimation(aniName, isBlend, resetAnimation, this.GetCullingType());
	//}

	//// Token: 0x06002152 RID: 8530 RVA: 0x00017177 File Offset: 0x00015377
	//private void PlayAnimation(string aniName, bool isBlend, bool resetAnimation, AnimationCullingType act)
	//{
	//	this.PlayAnimation(aniName, isBlend, resetAnimation, act, 0.3f);
	//}

	//// Token: 0x06002153 RID: 8531 RVA: 0x000E34E0 File Offset: 0x000E16E0
	//private void PlayAnimation(string aniName, bool isBlend, bool resetAnimation, AnimationCullingType act, float fadeLength)
	//{
	//	if (aniName == null || aniName.Length == 0)
	//	{
	//		return;
	//	}
	//	this._animation.cullingType = act;
	//	if (isBlend)
	//	{
	//		if (this._animation.IsPlaying(this.m_strLastAniName))
	//		{
	//			this._animation[aniName].blendMode = AnimationBlendMode.Blend;
	//			this._animation[aniName].layer = -1;
	//			this._animation.Blend(aniName);
	//			this.faceAniName = aniName;
	//		}
	//	}
	//	else
	//	{
	//		if (this._animation[aniName].wrapMode == WrapMode.Once)
	//		{
	//			this._animation[aniName].wrapMode = WrapMode.ClampForever;
	//		}
	//		if (this._animation[aniName].wrapMode == WrapMode.ClampForever && this._animation[aniName].time >= this._animation[aniName].length)
	//		{
	//			this._animation[aniName].time = 0f;
	//		}
	//		this.m_cCurrentAniState = this.GetAnimationState(aniName);
	//		this.m_fAniStartTime = GameTime.time;
	//		this.m_fCurrentMaxAniLength = this.GetAnimationLength(aniName);
	//		this.m_cCurrentSoundData = Singleton<AnimationSoundData>.GetInstance().GetData(this.m_cCurAniNode.SoundIdx);
	//		if (this.m_strLastAniName != aniName || resetAnimation)
	//		{
	//			this.m_fCurrentAniLength = this.m_cCurrentAniState.length;
	//			this.ResetEffectAndMove();
	//			this.RemoveLastSound();
	//			this.ResetSound();
	//		}
	//		if (resetAnimation)
	//		{
	//			this._animation[aniName].time = 0f;
	//			this._animation.CrossFade(aniName, fadeLength);
	//		}
	//		else
	//		{
	//			this._animation.CrossFade(aniName, fadeLength);
	//			if (MovieManager.MovieMag.IsPlaying() && this._animation[aniName].wrapMode != WrapMode.Loop && this._animation.IsPlaying(this.faceAniName))
	//			{
	//				this._animation[this.GetAniNameByIdx(ACTION_INDEX.AN_IDLE)].wrapMode = WrapMode.Loop;
	//				this._animation.CrossFadeQueued(this.GetAniNameByIdx(ACTION_INDEX.AN_IDLE), fadeLength);
	//			}
	//		}
	//		this.m_strLastAniName = aniName;
	//	}
	//}

	//// Token: 0x06002154 RID: 8532 RVA: 0x00017189 File Offset: 0x00015389
	//public void PlayAnimationRandom(ACTION_INDEX actIdx)
	//{
	//	this.PlayAnimationRandom(actIdx, 1f, WrapMode.Once, false, false);
	//}

	//// Token: 0x06002155 RID: 8533 RVA: 0x0001719A File Offset: 0x0001539A
	//public void PlayAnimationRandom(ACTION_INDEX actIdx, float speed, WrapMode wrapMode, bool isBlend, bool resetAnimaton)
	//{
	//	this.PlayAnimationRandom(actIdx, speed, wrapMode, isBlend, resetAnimaton, 0.3f);
	//}

	//// Token: 0x06002156 RID: 8534 RVA: 0x000171AE File Offset: 0x000153AE
	//public void PlayAnimationRandom(ACTION_INDEX actIdx, float speed, WrapMode wrapMode, bool isBlend)
	//{
	//	this.PlayAnimationRandom(actIdx, speed, wrapMode, isBlend, false, 0.3f);
	//}

	//// Token: 0x06002157 RID: 8535 RVA: 0x000E370C File Offset: 0x000E190C
	//public void PlayAnimationRandom(ACTION_INDEX actIdx, float speed, WrapMode wrapMode, bool isBlend, bool resetAnimaton, float fadeLength)
	//{
	//	this.ResetValue();
	//	if (this._animation == null)
	//	{
	//		return;
	//	}
	//	AniInfo.AniInfoNode aniInfoNodeRandom = this.GetAniInfoNodeRandom(actIdx);
	//	if (aniInfoNodeRandom == null)
	//	{
	//		return;
	//	}
	//	if (!resetAnimaton && this.IsPlaying(actIdx))
	//	{
	//		return;
	//	}
	//	if (aniInfoNodeRandom != null && aniInfoNodeRandom.Name.Length != 0)
	//	{
	//		if (this._animation[aniInfoNodeRandom.Name] == null)
	//		{
	//			Logger.LogWarningOnce(new object[]
	//			{
	//				"Animation " + aniInfoNodeRandom.Name + " is missing!"
	//			});
	//			return;
	//		}
	//		this.m_fCurrentAniSpeed = speed * aniInfoNodeRandom.SpeedRateBase;
	//		this._animation[aniInfoNodeRandom.Name].speed = this.m_fCurrentAniSpeed * GameTime.timeScale * this.AniSpeed;
	//		this._animation[aniInfoNodeRandom.Name].wrapMode = wrapMode;
	//		this.m_cCurAniNode = aniInfoNodeRandom.Clone();
	//		this._curAniIndex = actIdx;
	//		this.PlayAnimation(aniInfoNodeRandom.Name, isBlend, resetAnimaton, this.GetCullingType(), fadeLength);
	//		int num = (wrapMode != WrapMode.Loop) ? 0 : 1;
	//	}
	//}

	//// Token: 0x06002158 RID: 8536 RVA: 0x000E3834 File Offset: 0x000E1A34
	//private void PlayCurrentAnimation(float speed, WrapMode wrapMode, bool isBlend, bool resetAnimaton, AnimationCullingType act, float fadeLength)
	//{
	//	if (this.m_cCurAniNode == null)
	//	{
	//		return;
	//	}
	//	if (this.m_cCurrentAniState == null || string.IsNullOrEmpty(this.m_strLastAniName))
	//	{
	//		return;
	//	}
	//	this.m_fCurrentAniSpeed = speed * this.m_cCurAniNode.SpeedRateBase;
	//	this._animation.cullingType = act;
	//	this._animation[this.m_strLastAniName].speed = this.m_fCurrentAniSpeed * GameTime.timeScale;
	//	this._animation[this.m_strLastAniName].wrapMode = wrapMode;
	//	this.ResetEffectAndMove();
	//	this.PlayAnimation(this.m_strLastAniName, isBlend, resetAnimaton, act, fadeLength);
	//}

	//// Token: 0x06002159 RID: 8537 RVA: 0x000171C1 File Offset: 0x000153C1
	//public void PlayAnimation(ACTION_INDEX actIdx)
	//{
	//	this.PlayAnimation(actIdx, WrapMode.Once);
	//}

	//// Token: 0x0600215A RID: 8538 RVA: 0x000171CB File Offset: 0x000153CB
	//public void PlayAnimation(ACTION_INDEX actIdx, float speed)
	//{
	//	this.PlayAnimation(actIdx, speed, WrapMode.Once, false, false);
	//}

	//// Token: 0x0600215B RID: 8539 RVA: 0x000171D8 File Offset: 0x000153D8
	//public void PlayAnimation(ACTION_INDEX actIdx, WrapMode wrapMode)
	//{
	//	this.PlayAnimation(actIdx, 1f, wrapMode, false, false);
	//}

	//// Token: 0x0600215C RID: 8540 RVA: 0x000171E9 File Offset: 0x000153E9
	//public void PlayAnimation(ACTION_INDEX actIdx, float speed, WrapMode wrapMode, bool isBlend, bool resetAnimation)
	//{
	//	this.PlayAnimation(actIdx, speed, wrapMode, isBlend, resetAnimation, this.GetCullingType());
	//}

	//// Token: 0x0600215D RID: 8541 RVA: 0x000171FE File Offset: 0x000153FE
	//public void PlayAnimation(ACTION_INDEX actIdx, float speed, WrapMode wrapMode, bool isBlend, bool resetAnimation, AnimationCullingType act)
	//{
	//	this.PlayAnimation(actIdx, speed, wrapMode, isBlend, resetAnimation, act, 0.3f);
	//}

	//// Token: 0x0600215E RID: 8542 RVA: 0x000E38E4 File Offset: 0x000E1AE4
	//public void SetAnimationTime(ACTION_INDEX actIdx, float time)
	//{
	//	if (actIdx == ACTION_INDEX.AN_NONE)
	//	{
	//		return;
	//	}
	//	AniInfo.AniInfoNode aniInfoNodeRandom = this.GetAniInfoNodeRandom(actIdx);
	//	if (aniInfoNodeRandom == null || this._animation[aniInfoNodeRandom.Name] == null)
	//	{
	//		return;
	//	}
	//	this._animation[aniInfoNodeRandom.Name].time = time;
	//}

	//// Token: 0x0600215F RID: 8543 RVA: 0x000E393C File Offset: 0x000E1B3C
	//public void SetAnimationToEnd(ACTION_INDEX actIdx)
	//{
	//	float animationLength = this.GetAnimationLength(actIdx);
	//	this.SetAnimationTime(actIdx, animationLength);
	//}

	//// Token: 0x06002160 RID: 8544 RVA: 0x000E395C File Offset: 0x000E1B5C
	//public void PlayAnimation(ACTION_INDEX actIdx, float speed, WrapMode wrapMode, bool isBlend, bool resetAnimation, AnimationCullingType act, float fadeLength)
	//{
	//	if (this._animation == null)
	//	{
	//		return;
	//	}
	//	if (actIdx == ACTION_INDEX.AN_NONE)
	//	{
	//		return;
	//	}
	//	AniInfo.AniInfoNode aniInfoNodeRandom = this.GetAniInfoNodeRandom(actIdx);
	//	if (aniInfoNodeRandom == null)
	//	{
	//		Logger.LogWarningOnce(new object[]
	//		{
	//			string.Concat(new object[]
	//			{
	//				this._role._roleType.ToString(),
	//				" The Animation ",
	//				actIdx,
	//				" is None"
	//			})
	//		});
	//		return;
	//	}
	//	if (this._animation[aniInfoNodeRandom.Name] == null)
	//	{
	//		Logger.LogWarningOnce(new object[]
	//		{
	//			this._role._roleType.ToString() + " The Animation " + aniInfoNodeRandom.Name + " is None"
	//		});
	//		return;
	//	}
	//	this._animation.cullingType = act;
	//	this.m_fCurrentAniSpeed = speed * aniInfoNodeRandom.SpeedRateBase;
	//	this._animation[aniInfoNodeRandom.Name].speed = this.m_fCurrentAniSpeed * GameTime.timeScale * this.AniSpeed;
	//	this._animation[aniInfoNodeRandom.Name].wrapMode = wrapMode;
	//	this.m_cCurAniNode = aniInfoNodeRandom.Clone();
	//	this._curAniIndex = actIdx;
	//	this.PlayAnimation(aniInfoNodeRandom.Name, isBlend, resetAnimation, act, fadeLength);
	//	bool bLoop = wrapMode == WrapMode.Loop;
	//	this.PlayAniSound(aniInfoNodeRandom.SoundIdx, bLoop);
	//	foreach (Role role in this._role.rolePartsList)
	//	{
	//		RolePart rolePart = (RolePart)role;
	//		if (rolePart != null)
	//		{
	//			ModAnimation modAnimation = rolePart.GetModule(MODULE_TYPE.MT_MOTION) as ModAnimation;
	//			if (modAnimation != null)
	//			{
	//				modAnimation.PlayAnimation(actIdx, speed, wrapMode, isBlend, resetAnimation, act);
	//			}
	//		}
	//	}
	//}

	//// Token: 0x06002161 RID: 8545 RVA: 0x000E3B54 File Offset: 0x000E1D54
	//public bool IsPlaying(ACTION_INDEX actIdx)
	//{
	//	if (this._animation == null)
	//	{
	//		return false;
	//	}
	//	AniInfo aniInfoByIdx = this.GetAniInfoByIdx(actIdx);
	//	if (aniInfoByIdx == null)
	//	{
	//		return false;
	//	}
	//	foreach (AniInfo.AniInfoNode aniInfoNode in aniInfoByIdx.AniNameList)
	//	{
	//		if (this._animation == null)
	//		{
	//			return false;
	//		}
	//		if (this._animation.IsPlaying(aniInfoNode.Name))
	//		{
	//			if (this._animation[aniInfoNode.Name].wrapMode == WrapMode.ClampForever && this._animation[aniInfoNode.Name].time >= this._animation[aniInfoNode.Name].length)
	//			{
	//				return false;
	//			}
	//			return true;
	//		}
	//	}
	//	return false;
	//}

	//// Token: 0x06002162 RID: 8546 RVA: 0x0000221B File Offset: 0x0000041B
	//private void ResetValue()
	//{
	//}

	//// Token: 0x06002163 RID: 8547 RVA: 0x00017214 File Offset: 0x00015414
	//public bool IsPlayingFaceAni(string name)
	//{
	//	return this._animation.IsPlaying(name);
	//}

	//// Token: 0x06002164 RID: 8548 RVA: 0x00017222 File Offset: 0x00015422
	//public void StopAnimation()
	//{
	//	this.RemoveLastSound();
	//	this.m_cCurrentSoundData = null;
	//	this.StopEffectAndMove();
	//	if (this._animation != null)
	//	{
	//		this._animation.Stop();
	//	}
	//}

	//// Token: 0x06002165 RID: 8549 RVA: 0x000E3C58 File Offset: 0x000E1E58
	//private AnimationClip GetAnimationClip(string aniName)
	//{
	//	if (this._animation[aniName] == null)
	//	{
	//		Logger.LogWarningOnce(new object[]
	//		{
	//			"not find animation : " + aniName
	//		});
	//	}
	//	return this._animation[aniName].clip;
	//}

	//// Token: 0x06002166 RID: 8550 RVA: 0x000E3CA8 File Offset: 0x000E1EA8
	//public float GetAnimationLength(string aniName)
	//{
	//	if (this._animation == null)
	//	{
	//		return 0f;
	//	}
	//	if (this._animation[aniName] == null)
	//	{
	//		Logger.LogWarningOnce(new object[]
	//		{
	//			"not find animation : " + aniName
	//		});
	//		return 0f;
	//	}
	//	return this.GetAnimationClip(aniName).length;
	//}

	//// Token: 0x06002167 RID: 8551 RVA: 0x00017253 File Offset: 0x00015453
	//private AnimationState GetAnimationState(string aniName)
	//{
	//	if (this._animation[aniName] != null)
	//	{
	//		return this._animation[aniName];
	//	}
	//	return null;
	//}

	//// Token: 0x06002168 RID: 8552 RVA: 0x000E3D10 File Offset: 0x000E1F10
	//public float GetAnimationLength(ACTION_INDEX actIdx)
	//{
	//	string aniNameByIdx = this.GetAniNameByIdx(actIdx);
	//	if (aniNameByIdx == null)
	//	{
	//		return 0f;
	//	}
	//	return this.GetAnimationLength(aniNameByIdx);
	//}

	//// Token: 0x06002169 RID: 8553 RVA: 0x000E3D38 File Offset: 0x000E1F38
	//public float GetAnimationTime(ACTION_INDEX actIdx)
	//{
	//	string aniNameByIdx = this.GetAniNameByIdx(actIdx);
	//	if (aniNameByIdx == null)
	//	{
	//		return float.PositiveInfinity;
	//	}
	//	if (this._animation != null && this._animation[aniNameByIdx] != null)
	//	{
	//		return this._animation[aniNameByIdx].time;
	//	}
	//	return float.PositiveInfinity;
	//}

	//// Token: 0x0600216A RID: 8554 RVA: 0x000E3D98 File Offset: 0x000E1F98
	//private void ResetEffectAndMove()
	//{
	//	if (this.m_cCurAniNode == null)
	//	{
	//		return;
	//	}
	//	for (int i = 0; i < this.m_lstNowEffect.Count; i++)
	//	{
	//		SingletonMono<EffectManager>.GetInstance().Delete(this.m_lstNowEffect[i]);
	//	}
	//	this.m_lstNowEffect.Clear();
	//	this.m_cCurrentMove = null;
	//	this.m_lstIsMove.Clear();
	//	for (int j = 0; j < this.m_cCurAniNode.AniMoveList.Count; j++)
	//	{
	//		this.m_lstIsMove.Add(false);
	//	}
	//	this.m_lstIsEffect.Clear();
	//	for (int k = 0; k < this.m_cCurAniNode.AniEffectInfoList.Count; k++)
	//	{
	//		this.m_lstIsEffect.Add(false);
	//	}
	//}

	//// Token: 0x0600216B RID: 8555 RVA: 0x000E3E68 File Offset: 0x000E2068
	//private void ResetSound()
	//{
	//	this.soundTimeCount = 0f;
	//	this.m_lstSoundID.Clear();
	//	this.m_lstSoundEndDes.Clear();
	//	this.m_lstSound.Clear();
	//	if (this.m_cCurrentSoundData != null)
	//	{
	//		for (int i = 0; i < this.m_cCurrentSoundData.SoundID.Length; i++)
	//		{
	//			this.m_lstSound.Add(false);
	//		}
	//	}
	//}

	//// Token: 0x0600216C RID: 8556 RVA: 0x000E3ED8 File Offset: 0x000E20D8
	//private void RemoveLastSound()
	//{
	//	for (int i = 0; i < this.m_lstSoundID.Count; i++)
	//	{
	//		if (this.m_lstSoundID[i] > 0)
	//		{
	//			SingletonMono<AudioManager>.GetInstance().StopSound(this.m_lstSoundID[i], 1f);
	//		}
	//	}
	//	this.m_lstSoundID.Clear();
	//	this.m_lstSoundEndDes.Clear();
	//}

	//// Token: 0x0600216D RID: 8557 RVA: 0x000E3F4C File Offset: 0x000E214C
	//private void StopEffectAndMove()
	//{
	//	for (int i = 0; i < this.m_lstNowEffect.Count; i++)
	//	{
	//		SingletonMono<EffectManager>.GetInstance().Delete(this.m_lstNowEffect[i]);
	//	}
	//	this.m_lstNowEffect.Clear();
	//	this.m_cCurrentMove = null;
	//	if (this.m_cCurAniNode != null)
	//	{
	//		this.m_cCurAniNode = null;
	//	}
	//	this.m_lstIsMove.Clear();
	//}

	private AnimationCullingType GetCullingType()
	{
		if (base.Role._roleType == ROLE_TYPE.RT_NPC)
		{
			return AnimationCullingType.BasedOnUserBounds;
		}
		return AnimationCullingType.AlwaysAnimate;
	}
}
