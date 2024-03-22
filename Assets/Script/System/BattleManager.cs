using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    //���� ���� ������ ������ ���� Ŭ����
    [System.Serializable]
    public class SpawnEnemyInfo
    {
        public GameObject enemyPre;//��ȯ�� ���� ������
        public int spawnIndex;//��ȯ�� Ÿ�� �ε��� ��

        //������

    }

    //���̺� ����
    [System.Serializable]
    public class WaveInfo
    {
        public int thisTurn;//�ش� ���̺갡 ���۵Ǵ� ��
        public List<SpawnEnemyInfo> enemyInfoList;//��ȯ�� Enemy���� �������� ������ �迭
    }

    public List<WaveInfo> waveList;//���� ���̺� ������ ������ ����Ʈ ��ü

    public TurnState currentState;//���� �� ���¸� �����ϴ� ����


    private void Start()
    {
        currentState = TurnState.TurnStart;//���� TurnStart���·� �ʱ�ȭ
    }

    private void Update()
    {
        switch (currentState)
        {
            case TurnState.TurnStart:
                // �� ���� �� �ʿ��� ������ ���⿡ �ۼ�

                currentState = TurnState.PlayerTurn;
                break;
            case TurnState.PlayerTurn:
                // �÷��̾� �� ���� �ʿ��� ������ ���⿡ �ۼ�
                
                currentState = TurnState.EnemyTurn;
                break;
            case TurnState.EnemyTurn:
                // �� �� ���� �ʿ��� ������ ���⿡ �ۼ�

                currentState = TurnState.TurnEnd;
                break;
            case TurnState.TurnEnd:
                // �� ���� �� �ʿ��� ������ ���⿡ �ۼ�

                currentState = TurnState.TurnStart;
                break;
        }
    }
}
