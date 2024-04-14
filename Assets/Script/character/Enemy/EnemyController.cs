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
        public float range; // ��Ÿ�, 99�� ��Ÿ� ����
        public float cooldown; // ��Ÿ��, 0 ��Ÿ�� ����
        public float nowCoolTIme;//���� ��Ÿ��
        public bool NeedToPrepare;//�Ķ����
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

    public override void TurnStart()
    {
        
        base.TurnStart();
        Debug.Log("-------------"+ AvailabilityOfAction);
        GetComponent<ReadyToState>().StateReady();
        //���� �غ����� �ൿ�� ������ ����
        if (AvailabilityOfAction)
        {
            StateEnum selectStateEnum = SelectState();//enemy���� �Ǿ��� �� �ൿ���� ���¸� �ص� ����
        }
        else
            TurnEnd();
        
    }

    //stateConditions����Ʈ���� ��밡�� �� ���¸� �켱������ ���� ã�� �ش� ���� �������� ��ȯ
    private StateEnum SelectState()
    {
        StateEnum stateEnum = 0;//����� ���� �����Լ� �̸�

        //������ ��Ÿ� ����ϱ�
        int distance = 99;//�÷��̾���� �Ÿ�
        int thisIndex = gameManager.GetPlatformIndexForObj(gameObject);//���� ��ġ �� ��������
        int countDistance = 0;//�÷��̾� ���� �Ÿ��� ī��Ʈ�� ���� ����Ǵ� ����
        //�÷��̾� ���� �Ÿ� ��������
        for (int i = thisIndex + (direction == CharacterDirection.Right ? 1: -1); direction == CharacterDirection.Right ? i < gameManager.PlatformList.Length : i >= 0; i += (direction == CharacterDirection.Right ? 1 : -1))
        {
            
            countDistance++;
            GameObject targetObj = gameManager.GetOnPlatformObj(i);
            if(targetObj != null)
            {
                //��λ� �÷��̾ ������ �Ÿ� ����
                if (targetObj.layer == LayerMask.NameToLayer("Player"))
                {
                    distance = countDistance;
                    break;
                }
            }
        }

        Debug.Log(distance);
        //�켱 ������ ���� �� �ൿ ����
        foreach (StateCondition condition in stateConditions)
        {
            //��ų ��� ���� ���� üũ
            if (condition.nowCoolTIme == 0 && condition.range >= distance)
            {
                Debug.Log("-------------NeedToPrepare: " + condition.NeedToPrepare);
                //�غ��ؾ��ϴ� ��ų������ ���� ���� ó��
                if (condition.NeedToPrepare)
                    TransitionState(StateEnum.ReadyToState, condition.stateEnum);//���� ����
                else
                    TransitionState(condition.stateEnum);//���� ����
                break;
            }
        }

        return stateEnum;
    }

    //Enemy �� ���� ó��
    public override void TurnEnd()
    {
        gameManager.GetComponent<BattleManager>().OnTurnOverEnemyCnt++;//������� �� ī��Ʈ ++
        base.TurnEnd();//�� �ص� ó��
    }
}
