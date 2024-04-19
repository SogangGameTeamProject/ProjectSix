using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : Singleton<BattleManager>
{
    public GameManager gameManager;//���� �޴���

    //�������������� ���� ���� ������ ���� ���� ����
    public List<StageInfo> stageList;//�������� ������ ���� ����Ʈ
    public List<WaveInfo> nowStage;//���� �������� ������ ���� ����Ʈ
    public List<GameObject> onEnemysList = new List<GameObject>();//���� �ʵ����� ���� ����Ʈ
    public PlayerController onPlayer;//�ʵ����� �÷��̾� ������Ʈ
    private int nextWaveNum = 0;//���� ���̺� num

    private TurnEventType turnState;//���� �ϻ���
    private int nowTurnCnt = 0;//��� ��

    //enemyTurn ������ ���� ���� ����
    private bool isEnemyTurn = false;
    private int turnOverEnemyCnt = 0;//������� ���� ��
    

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
            Debug.Log("�غ�� �� ��: "+readyForEnemyCnt);
            //�� ��ȯ ���� üũ
            if(!onPlayer.isTurnReady && !onPlayer.isStatusProcessing && onEnemysList.Count == readyForEnemyCnt)
                TurnEventBus.Publish(TurnEventType.EnemyTurn);//�� ��ȯ �̺�Ʈ �߻�
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
                Debug.Log(eContoller.isStatusProcessing + ", " + eContoller.isTurnReady);
            }
            Debug.Log("�غ�� �� ��: " + readyForEnemyCnt);
            //�� ��ȯ ���� üũ
            if (!onPlayer.isStatusProcessing && onEnemysList.Count == readyForEnemyCnt)
                TurnEventBus.Publish(TurnEventType.EnemyTurn);//�� ��ȯ �̺�Ʈ �߻�
        }
    }

    //Enemy �� ���� üũ�� ���� ������Ƽ
    public int OnTurnOverEnemyCnt
    {
        get
        {
            return turnOverEnemyCnt;
        }
        set
        {
            turnOverEnemyCnt = value;
        }
    }

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


    //���� ���� ó��

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
                int platformSIze = gameManager.PlatformList.Length;
                //���� ��ġ�� ���� ���� ��ġ Ž��
                for (int i = (enemy.spawnPos < 0 ? 0 : platformSIze - 1);
                    (enemy.spawnPos < 0 ? i < platformSIze : i >= 0);
                    i += (enemy.spawnPos < 0 ? 1 : -1))
                {
                    //�ش� ��ġ�� ���� ���� ���� Ȯ��
                    if (gameManager.GetOnPlatformObj(i) == null)
                    {
                        GameObject enemyPre = Instantiate(enemy.enemyPre, gameManager.GetStandingPos(i), Quaternion.identity);
                        onEnemysList.Add(enemyPre);
                        //�� ���� �� �÷��̾ �ٶ󺸴� �������� ��ȯ ��Ű��
                        int targetIndex = gameManager.GetPlatformIndexForObj(GameObject.FindGameObjectWithTag("Player"));//�÷��̾� ��ġ ��������
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
        isEnemyTurn = true;//���� ���� Ȱ��ȭ
        turnState = TurnEventType.EnemyTurn;
        turnOverEnemyCnt = 0;//���� ���� �� �Ͽ��� ī��Ʈ 0���� �ʱ�ȭ
        Debug.Log(turnState);
    }

    //�� ���� �� �̺�Ʈ ó��
    public void TurnEnd()
    {
        isEnemyTurn = false;//���� ���� ��Ȱ��ȭ
        turnState = TurnEventType.TurnEnd;

        nowTurnCnt++;//�� ���� �� ��� �� +1
        TurnEventBus.Publish(TurnEventType.TurnStart);//TurnStart �̺�Ʈ �߻�
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "TURN STATUS: " + turnState);
    }
}
