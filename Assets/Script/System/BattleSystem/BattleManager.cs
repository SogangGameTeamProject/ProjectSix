using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<StageInfo> stageList;//�������� ������ ���� ����Ʈ

    public List<WaveInfo> nowStage;//���� �������� ������ ���� ����Ʈ
    private string turnState;

    //Ȱ��ȭ�� �̺�Ʈ ����
    private void OnEnable()
    {
        GameFlowEventBus.Subscribe(GameFlowType.BattleStart, BattleStart);//BattleStart �̺�Ʈ ����
        GameFlowEventBus.Subscribe(GameFlowType.BattleEnd, BattleEnd);//BattleEnd �̺�Ʈ ����

        TurnEventBus.Subscribe(TurnEventType.TurnStart, TurnStart);//TurnStart �̺�Ʈ ����
        TurnEventBus.Subscribe(TurnEventType.PlayerTurn, PlayerTurn);//PlayerTurn �̺�Ʈ ����
        TurnEventBus.Subscribe(TurnEventType.EnemyTurn, EnemyTurn);//EnemyTurn �̺�Ʈ ����
        TurnEventBus.Subscribe(TurnEventType.TurnEnd, TurnEnd);//TurnEnd �̺�Ʈ ����
    }

    //��Ȱ��ȭ�� �̺�Ʈ ����
    private void OnDisable()
    {
        GameFlowEventBus.Unsubscribe(GameFlowType.BattleStart, BattleStart);//BattleStart �̺�Ʈ ����
        GameFlowEventBus.Unsubscribe(GameFlowType.BattleEnd, BattleEnd);//BattleEnd �̺�Ʈ ����

        TurnEventBus.Unsubscribe(TurnEventType.TurnStart, TurnStart);//TurnStart �̺�Ʈ ����
        TurnEventBus.Unsubscribe(TurnEventType.PlayerTurn, PlayerTurn);//PlayerTurn �̺�Ʈ ����
        TurnEventBus.Unsubscribe(TurnEventType.EnemyTurn, EnemyTurn);//EnemyTurn �̺�Ʈ ����
        TurnEventBus.Unsubscribe(TurnEventType.TurnEnd, TurnEnd);//TurnEnd �̺�Ʈ ����
    }

    //��Ʋ ���� �� �̺�Ʈ ó��
    public void BattleStart()
    {


        TurnEventBus.Publish(TurnEventType.TurnStart);//TurnStart �̺�Ʈ �߻�
    }

    //��Ʋ ���� �� �̺�Ʈ ó��
    public void BattleEnd()
    {

    }

    //�� ���� �� �̺�Ʈ ó��
    public void TurnStart()
    {
        turnState = "TurnStart";
    }

    //�÷��̾� �� ���� �� �̺�Ʈ ó��
    public void PlayerTurn()
    {
        turnState = "PlayerTurn";
    }


    //���� ���� �� �̺�Ʈ ó��
    public void EnemyTurn()
    {
        turnState = "EnemyTurn";
    }

    //�� ���� �� �̺�Ʈ ó��
    public void TurnEnd()
    {
        turnState = "TurnEnd";
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "TURN STATUS: " + turnState);
    }
}
