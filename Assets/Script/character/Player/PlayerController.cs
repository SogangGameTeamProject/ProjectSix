using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{

    //�̺�Ʈ ���
    private void OnEnable()
    {
        TurnEventBus.Subscribe(TurnEventType.PlayerTurn, TurnStart);
    }

    //�̺�Ʈ ����
    private void OnDisable()
    {
        TurnEventBus.Unsubscribe(TurnEventType.PlayerTurn, TurnStart);
    }

    protected override void Start()
    {
        base.Start();

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TurnEventBus.Publish(TurnEventType.TurnEnd);
        }
    }
    //�� ���� ó��
    public override void TurnStart()
    {
        base.TurnStart();
        //��Ʋ�޴����� onPlayer���� ������ �� �ʱ�ȭ
        if (_battleManager.onPlayer == null)
        {
            _battleManager.onPlayer = this;
            Debug.Log("�÷��̾� �� �ʱ�ȭ");
        }
            
        isAvailabilityOfAction = true;
    }

    //�÷��̾� �� ���� ó��
    public override void TurnEnd()
    {
        base.TurnEnd();
        TurnEventBus.Publish(TurnEventType.EnemyTurn);
    }
}