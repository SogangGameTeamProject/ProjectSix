using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] PlatformList;//�÷��� ����Ʈ

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
        GameFlowEventBus.Publish(GameFlowType.Start);//���� ���� �̺�Ʈ �߻�
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

    //���� ���۽� �̺�Ʈ ó��
    public void GameStart()
    {
        GameFlowEventBus.Publish(GameFlowType.Battle);
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