using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    private GameManager gameManager;//���� �޴���

    public GameObject[] PlatformList;//�÷��� ����Ʈ
    //�������������� ���� ���� ������ ���� ���� ����
    public List<StageInfo> stageList;//�������� ������ ���� ����Ʈ
    public List<WaveInfo> nowStage;//���� �������� ������ ���� ����Ʈ
    public List<GameObject> onEnemysList = new List<GameObject>();//���� �ʵ����� ���� ����Ʈ
    public PlayerController onPlayer;//�ʵ����� �÷��̾� ������Ʈ
    private int nextWaveNum = 0;//���� ���̺� num

    private TurnEventType turnState;//���� �ϻ���
    public int nowTurnCnt = 0;//��� ��


    public int stageRewards {get;set;}//�������� ����

    //Ȱ��ȭ�� �̺�Ʈ ����
    private void OnEnable()
    {
        GameFlowEventBus.Subscribe(GameFlowType.Battle, BattleStart);//Battle �̺�Ʈ ����

        TurnEventBus.Subscribe(TurnEventType.TurnStart, TurnStart);//TurnStart �̺�Ʈ ����
        TurnEventBus.Subscribe(TurnEventType.PlayerTurn, PlayerTurn);//PlayerTurn �̺�Ʈ ����
        TurnEventBus.Subscribe(TurnEventType.EnemyTurn, EnemyTurn);//EnemyTurn �̺�Ʈ ����
        TurnEventBus.Subscribe(TurnEventType.TurnEnd, TurnEnd);//TurnEnd �̺�Ʈ ����
    }

    //��Ȱ��ȭ�� �̺�Ʈ ����
    private void OnDisable()
    {
        GameFlowEventBus.Unsubscribe(GameFlowType.Battle, BattleStart);//Battle �̺�Ʈ ����

        TurnEventBus.Unsubscribe(TurnEventType.TurnStart, TurnStart);//TurnStart �̺�Ʈ ����
        TurnEventBus.Unsubscribe(TurnEventType.PlayerTurn, PlayerTurn);//PlayerTurn �̺�Ʈ ����
        TurnEventBus.Unsubscribe(TurnEventType.EnemyTurn, EnemyTurn);//EnemyTurn �̺�Ʈ ����
        TurnEventBus.Unsubscribe(TurnEventType.TurnEnd, TurnEnd);//TurnEnd �̺�Ʈ ����
    }
    private void Reset()
    {
        
    }

    private void Update()
    {
        //���� �� ���� ó���� ���� �κ�
        //�÷��̾� �ൿ ���ο� ���� EnemyTurn�̺�Ʈ �߻�
        if(turnState == TurnEventType.PlayerTurn && onPlayer != null)
        {
            //�� ����ó�� �Ϸ� ���� ī��Ʈ�ϴ� �κ�
            int readyForEnemyCnt = 0;
            foreach(GameObject enemy in onEnemysList)
            {
                EnemyController eContoller = enemy.GetComponent<EnemyController>();
                if (!eContoller.isStatusProcessing)
                    readyForEnemyCnt++;
            }

            //�� ��ȯ ���� üũ
            if(!onPlayer.isTurnReady && !onPlayer.isStatusProcessing && onEnemysList.Count == readyForEnemyCnt)
            {
                TurnEventBus.Publish(TurnEventType.EnemyTurn);//�� ��ȯ �̺�Ʈ �߻�
            }
                
        }

        //�� �ൿ ���ο� ���� TurnEnd�̺�Ʈ �߻�
        if (turnState == TurnEventType.EnemyTurn && onPlayer != null)
        {

            //�� ����ó�� �Ϸ� ���� ī��Ʈ�ϴ� �κ�
            int readyForEnemyCnt = 0;
            foreach (GameObject enemy in onEnemysList)
            {
                EnemyController eContoller = enemy.GetComponent<EnemyController>();
                if (!eContoller.isStatusProcessing && !eContoller.isTurnReady)
                    readyForEnemyCnt++;
            }

            //�� ��ȯ ���� üũ
            if (!onPlayer.isStatusProcessing && onEnemysList.Count == readyForEnemyCnt)
                TurnEventBus.Publish(TurnEventType.TurnEnd);//�� ��ȯ �̺�Ʈ �߻�
        }
    }

    //�̺�Ʈ ó�� ���� �κ�
    //��Ʋ ���� �� �̺�Ʈ ó��
    public void BattleStart()
    {
        if(gameManager == null)
            gameManager = GameManager.Instance;
        //���� ���� �� �������� ���� �ʱ�ȭ �۾�
        nowTurnCnt = 0;
        nextWaveNum = 0;

        TurnEventBus. Publish(TurnEventType.TurnStart);//TurnStart �̺�Ʈ �߻�
    }


    //�� ���� �� �̺�Ʈ ó��
    public void TurnStart()
    {
        turnState = TurnEventType.TurnStart;
        Debug.Log(turnState);

        //Enemy ���� ���� Ȯ��
        if (nextWaveNum < nowStage.Count && onEnemysList.Count == 0)
        {
            //������ ���� ����Ʈ�� ���͵��� ��ȯ
            foreach (SpawnEnemyInfo enemy in nowStage[nextWaveNum].enemyInfoList)
            {
                int platformSIze = PlatformList.Length;
                //���� ��ġ�� ���� ���� ��ġ Ž��
                for (int i = (enemy.spawnPos < 0 ? 0 : platformSIze - 1);
                    (enemy.spawnPos < 0 ? i < platformSIze : i >= 0);
                    i += (enemy.spawnPos < 0 ? 1 : -1))
                {
                    //�ش� ��ġ�� ���� ���� ���� Ȯ��
                    if (GetOnPlatformObj(i) == null)
                    {
                        GameObject enemyPre = Instantiate(enemy.enemyPre, GetStandingPos(i), Quaternion.identity);
                        onEnemysList.Add(enemyPre);
                        //�� ���� �� �÷��̾ �ٶ󺸴� �������� ��ȯ ��Ű��
                        int targetIndex = GetPlatformIndexForObj(GameObject.FindGameObjectWithTag("Player"));//�÷��̾� ��ġ ��������
                        int thisIndex = i;//�ش� ��ü�� ��ġ ��������

                        //�ٷκ��� ���⿡ Ÿ���� ������ ���� ��ȯ
                        if (targetIndex < thisIndex)
                        {
                            enemyPre.transform.localScale = new Vector3(-1, 1, 1);
                        }
                        break;
                    }
                }
            }
            nextWaveNum++;//������ ������ ���̺� ��ȣ 1 ����
        }
        
        TurnEventBus.Publish(TurnEventType.PlayerTurn);//PlayerTurn �̺�Ʈ �߻�
    }

    //�÷��̾� �� ���� �� �̺�Ʈ ó��
    public void PlayerTurn()
    {
        turnState = TurnEventType.PlayerTurn;
        Debug.Log(turnState);
    }


    //���� ���� �� �̺�Ʈ ó��
    public void EnemyTurn()
    {
        turnState = TurnEventType.EnemyTurn;
        Debug.Log(turnState);
    }

    //�� ���� �� �̺�Ʈ ó��
    public void TurnEnd()
    {
        turnState = TurnEventType.TurnEnd;

        nowTurnCnt++;//�� ���� �� ��� �� +1
        TurnEventBus.Publish(TurnEventType.TurnStart);//TurnStart �̺�Ʈ �߻�
    }

    //���� �������� �� ����� ��ɵ�
    //Ư�� ������Ʈ�� ���� �÷��� �˻��Ͽ� index ��ȣ�� ��ȯ�ϴ� �Լ�. null�� �� -1�� ����
    public int GetPlatformIndexForObj(GameObject chracterObj)
    {
        int index = -1;

        //�ݺ������� �Է¹��� ���� ������Ʈ�� ���� �÷��� ���� Ž��
        for (int i = 0; i < PlatformList.Length; i++)
        {
            if (PlatformList[i].GetComponent<PlatformInfoManagement>().OnPlatformCharacter == chracterObj)
            {
                index = i;
                break;
            }
        }

        return index;
    }

    //Ư�� ��ġ�� �÷����ȿ� ĳ����obj�� ���� ��ȯ �Լ�
    public GameObject GetOnPlatformObj(int indexNum)
    {
        GameObject returnObj = null;//��ȯ�� ������Ʈ ��

        //�÷��� ����Ʈ�� ��ȿ�� �ε��� ������ üũ
        if (indexNum > -1 && indexNum < PlatformList.Length)
        {
            returnObj = PlatformList[indexNum].GetComponent<PlatformInfoManagement>().OnPlatformCharacter;
        }
        return returnObj;
    }

    //Ư�� ��ġ�� �÷����ȿ�  ���� ��ȯ �Լ�
    public Vector3 GetStandingPos(int indexNum)
    {
        Vector3 returnPos = Vector3.zero;//��ȯ�� ��ġ ��

        if (indexNum > -1 && indexNum < PlatformList.Length)
        {
            returnPos = PlatformList[indexNum].GetComponent<PlatformInfoManagement>().StandingPos;
        }

        return returnPos;
    }

    //Ư�� ��ġ Ÿ�Ͽ� ������ ������ �ο�
    public void GiveDamage(int index, int damage)
    {
        GameObject tartget = GetOnPlatformObj(index);//�������� �� ������Ʈ ��������

        //nullüũ
        if ((tartget))
        {
            tartget.GetComponent<CharacterController>().TransitionState(StateEnum.Hit, damage);//��� �ǰ� ���� �߻�
        }
    }
}
