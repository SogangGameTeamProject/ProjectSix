using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �غ� ����
public class ReadyToState : StateBase
{
    bool isPreparing = false;//�ൿ �غ� �� ����

    protected override IEnumerator StateFuntion(params object[] datas)
    {
        characterController.AvailabilityOfAction = false;//�ൿ ���� ���� false ����
        isPreparing = true;//�ൿ �غ� ���� ture

        //�ൿ �غ� ���·� ��ȯ �� �ൿ �ൿ ����
        characterController.TurnEnd();

        //�� ��� üũ
        while (true)
        {
            if (!isPreparing)
                break;
            yield return null;
        }

        characterController.AvailabilityOfAction = true;//�ൿ ���� ���� true ����
        //�Ű� ���� ���� ���� �ൿ ���� ���� ����
        if (datas[0] != null)
            characterController.TransitionState((StateEnum)datas[0]);//�ൿ ����
        else
            yield return base.StateFuntion(datas);
    }

    //�ൿ �غ� ���¿��� ������ �Ǹ� isReady�� ���� true �ϴ� �Լ�
    private void StateReady()
    {
        Debug.Log("StateReady");
        if(isPreparing == true)
            isPreparing = false;
    }
}
