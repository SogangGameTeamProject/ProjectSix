using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    //���� ����� ���¿� ���� ����
    [System.Serializable]
    public class StateCondition
    {
        public StateEnum stateEnum; // ���� ������
        public float range; // ��Ÿ�, 0�� ��Ÿ� ����
        public float cooldown; // ��Ÿ��, 0�� ��Ÿ�� ����
        public float nowCoolTIme;//���� ��Ÿ��
        public object paramater;//�Ķ����
    }

    public List<StateCondition> stateConditions; // ���¿� ������ ����Ʈ


    //�̺�Ʈ ���
    private void OnEnable()
    {
        TurnEventBus.Subscribe(TurnEventType.EnemyTurn, TurnStart);
    }

    //�̺�Ʈ ����
    private void OnDisable()
    {
        TurnEventBus.Unsubscribe(TurnEventType.EnemyTurn, TurnStart);
    }

    protected override void Start()
    {
        base.Start();
        
    }

    private void Update()
    {
        //enemy���� �Ǿ��� �� �ൿ�� �ϳ� ��� ���� �ϴ� �ڵ�
        if (isTurnReady)
        {
            // ���� ����Ʈ���� ���ǿ� �´� ���¸� ����
            StateEnum selectStateEnum = SelectStateEnum();
            if (selectStateEnum > 0)
            {
                // ���õ� ���¸� ����
                TransitionState(selectStateEnum);
            }
        }
    }

    //stateConditions����Ʈ���� ��밡�� �� ���¸� �켱������ ���� ã�� �ش� ���� �������� ��ȯ
    private StateEnum SelectStateEnum()
    {
        StateEnum stateEnum = 0;//����� ���� �����Լ� �̸�

        //�켱 ������ ���� �� �ൿ ����
        foreach(StateCondition condition in stateConditions)
        {

        }

        return stateEnum;
    }

    //Enemy �� ���� ó��
    public override void TurnEnd()
    {
        GameManager.Instance.GetComponent<BattleManager>().OnTurnOverEnemyCnt++;//������� �� ī��Ʈ ++
        base.TurnEnd();//�� �ص� ó��
        TurnEventBus.Publish(TurnEventType.TurnEnd);//������ �̺�Ʈ �߻�
    }
}
