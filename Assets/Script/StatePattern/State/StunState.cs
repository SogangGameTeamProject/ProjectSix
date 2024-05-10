using System.Collections;
using UnityEngine;
//ĳ���� �ǰ�
public class StunState : StateBase
{
    private int hitDamage { get; set; }//�ǰ� �� ����� ������
    private bool isStun = false;//���� ����
    int stunTurn = 0;//���� �ð�

    private void OnEnable()
    {
        TurnEventBus.Subscribe(TurnEventType.TurnEnd, TurnEnd);//TurnEnd �̺�Ʈ ����
    }

    private void OnDisable()
    {
        TurnEventBus.Unsubscribe(TurnEventType.TurnEnd, TurnEnd);//TurnEnd �̺�Ʈ ����
    }

    protected override IEnumerator StateFuntion(params object[] datas)
    {
        isStun = true;
        characterController.isAvailabilityOfAction = false;//�ൿ�Ұ� ���·� ��ȯ
        stunTurn = (int)datas[0];//���� �ð� ����
        characterController.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

        //���� ���·� ��ȯ �� �� ���� ó��
        characterController.isStatusProcessing = false;
        characterController.TurnEnd();


        while (stunTurn > 0)
        {
            yield return null;
        }

        characterController.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        isStun = false;
        characterController.isAvailabilityOfAction = true;//�ൿ���� ���·� ��ȯ
        yield return base.StateFuntion(datas);
    }

    //�� ���ῡ ���� ���� ����
    private void TurnEnd()
    {
        if (isStun)
        {
            Debug.Log("���� �ð� ���");
            stunTurn--;
        }
            
    }
}

