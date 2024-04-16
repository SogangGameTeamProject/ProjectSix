using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �غ� ����
public class EnemyReadyToState : StateBase
{
    bool isPreparing = false;//�ൿ �غ� �� ����
    
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        characterController.AvailabilityOfAction = false;
        isPreparing = true;//�ൿ �غ� ���� ture

        yield return new WaitForSeconds(sateDelayTime);//�ൿ ���� �ĵ�����

        //�ൿ �غ� ���·� ��ȯ �� �ൿ �ൿ ����
        characterController.TurnEnd();

        //�� ��� üũ
        while (true)
        {
            if (!isPreparing)
                break;
            yield return null;
        }
        characterController.AvailabilityOfAction = true;
        //�Ű� ���� ���� ���� �ൿ ���� ���� ����
        if (datas[0] != null)
            characterController.TransitionState((StateEnum)datas[0]);//�ൿ ����
    }

    //�ൿ �غ� ���¿��� ������ �Ǹ� isReady�� ���� true �ϴ� �Լ�
    public void TurnStart()
    {
        if(isPreparing == true && !characterController.isDie)
            isPreparing = false;
            
    }
}
