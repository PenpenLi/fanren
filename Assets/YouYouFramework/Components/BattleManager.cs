using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using YouYou;

public class BattleManager : YouYouBaseComponent
{
    public GameFormation PlayerFormation;
    public GameFormation FoeFormation;

    public int CurrentWave { get; private set; }

    public BattleEntity m_BattleEntity { get; private set; }

    public RoleCtrl ActiveRole { get; private set; }

    public RoleCtrl ActiveTarget { get; private set; }

    public float doActionMoveSpeed = 8f;

    public bool isUnitRunningToTarget = false;            //����Ƿ�Ϊ�ƶ���Ŀ��״̬
    public bool isUnitRunningBack = false;   //����Ƿ�Ϊ����
    public bool isWaitForPlayerToChooseSkill = false;            //���ѡ����UI�Ŀ���
    private float distanceToTarget;         //��ǰ�ж���λ������Ŀ��ľ���
    private float distanceToInitial;

    public bool IsAutoPlay; 

    public void StartGame()
    {
        // �����������
        PlayerFormation.ClearCharacters();
        PlayerFormation.isPlayerFormation = true;
        PlayerFormation.foeFormation = GameEntry.Battle.FoeFormation;
        //���õ�������
        FoeFormation.ClearCharacters();
        FoeFormation.isPlayerFormation = false;
        FoeFormation.foeFormation = GameEntry.Battle.PlayerFormation;


        CurrentWave = 0;
        m_BattleEntity = GameEntry.DataTable.DataTableManager.BattleDBModel.Get(GameEntry.Data.RuntimeDataManager.CurrBattleID);

        PlayerFormation.SetCharacters(GameEntry.Data.RuntimeDataManager.Team);//������� ����ֻ����һ�Σ�����ÿһ������Ҫ����

        NextWave();
        NewTurn();
    }

    public void NextWave()
    {
        if (m_BattleEntity != null)
        {
            string[] foes;
            List<RoleInfo> items = new List<RoleInfo>();
            string[] arr1 = m_BattleEntity.Role.Split('|');
            string[] arr2 = arr1[CurrentWave].Split(',');
            if (arr2.Length > 1)//�Ƿ����������
            {
                foes = arr2[Random.Range(0, arr2.Length)].Split('_');
            }
            else
            {
                foes = arr2[0].Split('_');
            }

            for (int i = 0; i < foes.Length; i++)//�������˽�ɫ
            {
                string[] arr3 = foes[i].Split('@');
                RoleEntity roleEntity = GameEntry.DataTable.DataTableManager.RoleDBModel.Get(arr3[0].ToInt());
                RoleInfo roleInfo = new RoleInfo();
                roleInfo.RoleId = roleEntity.Id;
                roleInfo.Level = arr3[1].ToInt();
                roleInfo.MaxHP = roleEntity.MaxHp;
                roleInfo.CurrHP = roleEntity.MaxHp;
                roleInfo.ShenFa = roleEntity.ShenFa;
                items.Add(roleInfo);
            }
            FoeFormation.SetCharacters(items);
            ++CurrentWave;
        }
    }

    public void NewTurn()
    {
        if (ActiveRole != null)
        {
            ActiveRole.currentTimeCount = 0;
        }

        RoleCtrl activatingCharacter = null;
        var maxTime = int.MinValue;
        List<RoleCtrl> characters = new List<RoleCtrl>();
        characters.AddRange(PlayerFormation.Characters.Values);//����ҽ�ɫ�����б�
        characters.AddRange(FoeFormation.Characters.Values);//�ѵ��˽�ɫ�����б�
        for (int i = 0; i < characters.Count; ++i)//��������
        {
            RoleCtrl character = characters[i] as RoleCtrl;
            if (character != null)
            {
                if (!character.IsDied)//�����ɫû������ 
                {
                    int spd = character.CurrRoleInfo.ShenFa;
                    character.currentTimeCount += spd;
                    if (character.currentTimeCount > maxTime)//�ٶȿ���ȳ���
                    {
                        maxTime = character.currentTimeCount;
                        activatingCharacter = character;
                    }
                }
                else
                {
                    character.currentTimeCount = 0;
                }
            }
        }
        ActiveRole = activatingCharacter;

        //ActiveCharacter.DecreaseBuffsTurn();//����Buff
        //ActiveCharacter.DecreaseSkillsTurn();//���ټ���CD
        ActiveRole.ResetStates();//����״̬
        if (!ActiveRole.IsDied)//�����ɫû��
        {
            //�ڸõ�λ�ŵ�����ʾ��Ч
            //thisPartical = Instantiate(partical_show) as GameObject;

            //thisPartical.SetParent(ActiveCharacter.bodyEffectContainer);

            if (ActiveRole.IsPlayerCharacter)//�ж���ɫ��������
            {
                if (IsAutoPlay)//�Ƿ��Զ�ģʽ
                {
                    //ActiveCharacter.RandomAction();//������Զ�ģʽ����ж�
                }
                else
                {
                    GameEntry.UI.OpenUIForm(UIFormId.Battle);//��������Ҫ��
                }
            }
            else
            {
                //ActiveCharacter.RandomAction();//����ǵ�������ж�
            }
        }
        else
        {
            NotifyEndAction(ActiveRole);//֪ͨ�����ж�
        }
    }

    public void NotifyEndAction(RoleCtrl character)
    {
        if (character != ActiveRole)
        {
            return;
        }

        if (!PlayerFormation.IsAnyCharacterAlive())
        {
            ActiveRole = null;
            //������Ϸʧ��
            //StartCoroutine(LoseGameRoutine());
        }
        else if (!FoeFormation.IsAnyCharacterAlive())
        {
            //������һ��ս��
            ActiveRole = null;
            //if (CurrentWave >= CastedStage.waves.Length)
            //{
            //    StartCoroutine(WinGameRoutine());
            //    return;
            //}
            //StartCoroutine(MoveToNextWave());
        }
        else
        {
            NewTurn();
        }       
    }

    /// <summary>
    /// ��ʾ������Χ
    /// </summary>
    /// <param name="character"></param>
    public void ShowTargetScopesOrDoAction()
    {
        isWaitForPlayerToChooseSkill = true;

        var allyTeamFormation = ActiveRole.IsPlayerCharacter ? PlayerFormation : FoeFormation;//�Լ���Ӫ
        var foeTeamFormation = !ActiveRole.IsPlayerCharacter ? PlayerFormation : FoeFormation;//�ж���Ӫ
        allyTeamFormation.SetCharactersSelectable(false);
        foeTeamFormation.SetCharactersSelectable(false);
        //if (ActiveCharacter.Action == RoleCtrl.ACTION_ATTACK)
        //{
        foeTeamFormation.SetCharactersSelectable(true);
        //}           
        //else
        //{
        //    //switch (ActiveCharacter.SelectedSkill.CastedSkill.usageScope)
        //    //{
        //    //    case SkillUsageScope.Self:
        //    //        character.selectable = true;
        //    //        break;
        //    //    case SkillUsageScope.Ally:
        //    //        allyTeamFormation.SetCharactersSelectable(true);
        //    //        break;
        //    //    case SkillUsageScope.Enemy:
        //    //        foeTeamFormation.SetCharactersSelectable(true);
        //    //        break;
        //    //    case SkillUsageScope.All:
        //    //        allyTeamFormation.SetCharactersSelectable(true);
        //    //        foeTeamFormation.SetCharactersSelectable(true);
        //    //        break;
        //    //}
        //}
    }

    public void OnUpdate()
    {
        //if (uiPauseGame.IsVisible())
        //{
        //    Time.timeScale = 0;
        //    return;
        //}

        //if (IsAutoPlay != isAutoPlayDirty)
        //{
        //    if (IsAutoPlay)
        //    {
        //        uiCharacterActionManager.Hide();
        //        if (ActiveCharacter != null)
        //            ActiveCharacter.RandomAction();
        //    }
        //    isAutoPlayDirty = IsAutoPlay;
        //}

        //Time.timeScale = !isEnding && IsSpeedMultiply ? 2 : 1;
        if (isWaitForPlayerToChooseSkill)
        {
            if (Input.GetMouseButtonDown(0) && ActiveRole != null && ActiveRole.IsPlayerCharacter)
            {
                Ray ray = GameEntry.Camera.MainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (!Physics.Raycast(ray, out hitInfo))
                {
                    return;
                }

                var targetCharacter = hitInfo.collider.GetComponent<RoleCtrl>();
                if (targetCharacter != null)
                {
                    if (ActiveRole.DoAction(targetCharacter))
                    {                        
                        ActiveTarget = targetCharacter;
                        PlayerFormation.SetCharactersSelectable(false);
                        FoeFormation.SetCharactersSelectable(false);
                        isWaitForPlayerToChooseSkill = false;
                    }
                }
            }
        }
        
        if (isUnitRunningToTarget)
        {
            distanceToTarget = Vector3.Distance(ActiveRole.transform.position, ActiveTarget.InitialTransform.position);           //��Ŀ��ľ��룬��Ҫʵʱ����
            //���⿿��Ŀ��ʱ����
            if (distanceToTarget < 1.6f)            
            {
                ActiveRole.ToIdle();
                //ֹͣ�ƶ�
                //�ر��ƶ�״̬
                isUnitRunningToTarget = false;
                //��ʼ����
                LaunchAttack();
            }
        }

        if (isUnitRunningBack)
        {
            distanceToInitial = Vector3.Distance(ActiveRole.transform.position, ActiveRole.InitialTransform.position);           //���ʼλ�õľ���
            if (distanceToInitial <1.1f)      
            {
                ActiveRole.ToIdle();
                //ֹͣ�ƶ�
                ////�ر��ƶ�״̬
                isUnitRunningBack = false;
                ////��������ʼλ�úͳ���
                ActiveRole.transform.rotation = ActiveRole.InitialTransform.rotation;

                ////������λ��ԭλ���ж�����������һ����λ
                //ToBattle();
            }
        }   
    }

    /// <summary>
    /// ��ǰ�ж���λִ�й�������
    /// </summary>
    public void LaunchAttack()
    {
        ////�洢�����ߺ͹���Ŀ������Խű�
        //UnitStats attackOwner = currentActUnit.GetComponent<UnitStats>();
        //UnitStats attackReceiver = currentActUnitTarget.GetComponent<UnitStats>();
        ////���ݹ��������˺�
        //attackData = (attackOwner.attack - attackReceiver.defense + Random.Range(-2, 2)) * attackDamageMultiplier;
        ////���Ź�������
        //ActiveCharacter.CurrRoleFSMMgr.ChangeState(RoleState.Attack);
        ////��ȡ������������
        //float attackAnimationTime = currentActUnit.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        //float damageAnimationTime = attackAnimationTime * 0.4f;
        float attackAnimationTime = 2;
        float damageAnimationTime = 2;
        //Debug.Log(currentActUnit.name + "ʹ�ü��ܣ�" + attackTypeName + "����" + currentActUnitTarget.name + "�����" + attackData + "���˺�");

        //�ڶ�������˺�ǰ����ӳ٣��˺��ڶ�������ȥ�͵ó��֣�
        //StartCoroutine(WaitForTakeDamage(damageAnimationTime));

        //��һ����λ�ж�ǰ��ʱ
        StartCoroutine(WaitForRunBack(attackAnimationTime));
    }

    /// <summary>
    /// ��ʱ���������������ڹ���غϲ�������
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForTakeDamage(float time)
    {
        yield return new WaitForSeconds(time);

        //�������߳����˺�
        //currentActUnitTarget.GetComponent<UnitStats>().ReceiveDamage(attackData);

        ////ʵ�����˺����岢���õ������ϣ�����λ�ú����ݵĿ��Ʒ���������Ľű��У�
        //GameObject thisText = Instantiate(bloodText) as GameObject;
        //thisText.transform.SetParent(GameObject.Find("BloodTextGroup").transform, false);

        //if (!currentActUnitTarget.GetComponent<UnitStats>().IsDead())
        //{
        //    currentActUnitTarget.GetComponent<Animator>().SetTrigger("TakeDamage");
        //}
        //else
        //{
        //    currentActUnitTarget.GetComponent<Animator>().SetTrigger("Dead");
        //}

    }

    IEnumerator WaitForRunBack(float time)
    {
        yield return new WaitForSeconds(time);
        //Զ�̵�λ����Ҫ�ܻ������ӳٺ�ֱ���¸���λ�ж�
        //if (currentActUnit.GetComponent<UnitStats>().attackType == 1)
        //{
        //    ToBattle();
        //}
        //else
        //{
        //    //��ʱ�����ܻ�״̬
        ActiveRole.MoveTo(ActiveRole.InitialTransform.position);
        isUnitRunningBack = true;
        //}
    }

    public override void Shutdown()
    {
       
    }
}
