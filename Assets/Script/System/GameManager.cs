using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //Ȱ��ȭ�� �̺�Ʈ ����
    private void OnEnable()
    {
        //�̺�Ʈ �߻� �� ȣ���� �Լ� ����
        GameFlowEventBus.Subscribe(GameFlowType.Start, GameStart);
        GameFlowEventBus.Subscribe(GameFlowType.Rest, GameRest);
        GameFlowEventBus.Subscribe(GameFlowType.Lose, GameLose);
        GameFlowEventBus.Subscribe(GameFlowType.Win, GameWin);
    }

    //��Ȱ��ȭ�� �̺�Ʈ ����
    private void OnDisable()
    {
        //�̺�Ʈ ����
        GameFlowEventBus.Unsubscribe(GameFlowType.Start, GameStart);
        GameFlowEventBus.Unsubscribe(GameFlowType.Rest, GameRest);
        GameFlowEventBus.Unsubscribe(GameFlowType.Lose, GameLose);
        GameFlowEventBus.Unsubscribe(GameFlowType.Win, GameWin);
    }

    private void Start()
    {
        
    }

    

    //���� ���۽� �̺�Ʈ ó��
    public void GameStart()
    {
        
    }

    //���׷��̵� �ܰ� �̺�Ʈ ó��
    public void GameRest()
    {
        
    }

    //���� �й�� �̺�Ʈ ó��
    public void GameLose()
    {
        Debug.Log("PlayerLose");
    }

    //���� �¸��� �̺�Ʈ ó��
    public void GameWin()
    {
        Debug.Log("PlayerWin");
    }
}