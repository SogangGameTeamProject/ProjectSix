using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    GameManager gameManager;//���� �޴���

    //�������������� ���� ���� ������ ���� ���� ����
    public List<StageInfo> stageList;//�������� ������ ���� ����Ʈ
    public List<WaveInfo> nowStage;//���� �������� ������ ���� ����Ʈ
    private List<GameObject> onEnemysList = new List<GameObject>();//���� �ʵ����� ���� ����Ʈ
    private int nextWaveNum = 0;//���� ���̺� num

    private string turnState;//���� �ϻ���
    private int nowTurnCnt = 0;//��� ��

    //enemyTurn ������ ���� ���� ����
    private bool isEnemyTurn = false;
    private int turnOverEnemyCnt = 0;//������� ���� ��
    

    //Ȱ��ȭ�� �̺�Ʈ ����
    private void OnEnable()
    {
        gameManager = GameManager.Instance;//���� �޴��� �� �ʱ�ȭ

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

    //
    public int OnTurnOverEnemyCnt
    {
        get
        {
            return turnOverEnemyCnt;
        }
        set
        {
            turnOverEnemyCnt += value;

            //Enemy �� ���� ī��Ʈ ���� �� �ʵ��� Enemy ���� �� ���� Enemy���� ������ �� ����� ��ȯ
            if (isEnemyTurn && (turnOverEnemyCnt == onEnemysList.Count))
            {
                TurnEventBus.Publish(TurnEventType.TurnEnd);//�� ���� �̺�Ʈ �߻�
            }
        }
    }

    //��Ʋ ���� �� �̺�Ʈ ó��
    public void BattleStart()
    {
        //���� ���� �� �������� ���� �ʱ�ȭ �۾�
        nowTurnCnt = 0;
        nextWaveNum = 0;

        TurnEventBus.Publish(TurnEventType.TurnStart);//TurnStart �̺�Ʈ �߻�
    }

    //���� ���� ó��

    //�� ���� �� �̺�Ʈ ó��
    public void TurnStart()
    {
        turnState = "TurnStart";
        Debug.Log(turnState);

        //������ ��ȯ�� ENemyList�� �ִ� �� üũ
        if (nextWaveNum < nowStage.Count)
        {
            //nowStage�� ���� ���� �ϸ��� ���� ��ȯ, �ʵ忡 ���Ͱ� ������ ���� ���̺� ��ȯ
            if (nowTurnCnt == nowStage[nextWaveNum].thisTurn)
            {
                //������ ���� ����Ʈ�� ���͵��� ��ȯ
                foreach (SpawnEnemyInfo enemy in nowStage[nextWaveNum].enemyInfoList)
                {
                    int platformSIze = gameManager.PlatformList.Length;
                    //���� ��ġ�� ���� ���� ��ġ Ž��
                    for (int i = (enemy.spawnPos < 0 ? 0 : platformSIze - 1); (enemy.spawnPos < 0 ? i < platformSIze : i >= 0); i += (enemy.spawnPos < 0 ? 1 : -1))
                    {
                        //�ش� ��ġ�� ���� ���� ���� Ȯ��
                        if (gameManager.GetOnPlatformObj(i) == null)
                        {
                            GameObject enemyPre = Instantiate(enemy.enemyPre, gameManager.GetStandingPos(i), Quaternion.identity);
                            onEnemysList.Add(enemyPre);
                            break;
                        }
                    }
                }
                nextWaveNum++;//������ ������ ���̺� ��ȣ 1 ����
            }
        }
        
        TurnEventBus.Publish(TurnEventType.PlayerTurn);//PlayerTurn �̺�Ʈ �߻�
    }

    //�÷��̾� �� ���� �� �̺�Ʈ ó��
    public void PlayerTurn()
    {
        turnState = "PlayerTurn";
        Debug.Log(turnState);
    }


    //���� ���� �� �̺�Ʈ ó��
    public void EnemyTurn()
    {
        isEnemyTurn = true;//���� ���� Ȱ��ȭ
        turnState = "EnemyTurn";
        turnOverEnemyCnt = 0;//���� ���� �� �Ͽ��� ī��Ʈ 0���� �ʱ�ȭ
        Debug.Log(turnState);
    }

    //�� ���� �� �̺�Ʈ ó��
    public void TurnEnd()
    {
        isEnemyTurn = false;//���� ���� ��Ȱ��ȭ
        turnState = "TurnEnd";
        Debug.Log(turnState);

        nowTurnCnt++;//�� ���� �� ��� �� +1
        TurnEventBus.Publish(TurnEventType.TurnStart);//TurnStart �̺�Ʈ �߻�
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "TURN STATUS: " + turnState);
    }
}
