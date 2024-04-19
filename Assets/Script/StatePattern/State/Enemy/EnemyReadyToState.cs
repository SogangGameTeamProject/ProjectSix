using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �غ� ����
public class EnemyReadyToState : StateBase
{
    bool isPreparing = false;//�ൿ �غ� �� ����
    
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        isPreparing = true;//�ൿ �غ� ���� ture
        characterController.isCharging = true;//���� �غ� ���� true
        //���� �غ����� ������ �ൿ �������� ���� �κ�
        EnemyHUDController eHUD = GetComponent<EnemyHUDController>();
        eHUD.OnActionIcon((StateEnum)datas[0]);

        //�ൿ �غ� ���·� ��ȯ �� �ൿ �ൿ ����
        characterController.isStatusProcessing = false;
        characterController.TurnEnd();

        //�� ��� üũ
        while (true)
        {
            if (!isPreparing)
                break;
            yield return null;
        }
        //�ൿ ������ ���� �κ�
        eHUD.OffActionIcon();

        characterController.isCharging = false;//���� �غ� ���� false

        //�Ű� ���� ���� ���� �ൿ ���� ���� ����
        if (datas[0] != null)
            characterController.TransitionState((StateEnum)datas[0]);//�ൿ ����
    }

    //�ൿ �غ� ���¿��� ������ �Ǹ� isReady�� ���� true �ϴ� �Լ�
    public void TurnStart()
    {
        if(isPreparing == true && characterController.isAvailabilityOfAction)
            isPreparing = false;
    }
}
