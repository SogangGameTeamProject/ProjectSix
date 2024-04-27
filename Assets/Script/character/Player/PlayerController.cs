using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public int maxBattery = 10;
    public int nowBattery = 0;
    public int NowBattery
    {
        get
        {
            return nowBattery;
        }

        set
        {
            nowBattery = value;
            if(nowBattery > maxBattery)
                nowBattery = maxBattery;
        }
    }
    public int batteryRecoveryFigures = 1;
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

        nowBattery = maxBattery / 2;
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
        }
            
        isAvailabilityOfAction = true;
        NowBattery += batteryRecoveryFigures;
    }
}