using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �غ� ����
public class EnemyReadyToState : StateBase
{
    
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        characterController.isCharging = true;//���� �غ� ���� true
        //���� �غ����� ������ �ൿ �������� ���� �κ�
        EnemyHUDController eHUD = characterController.GetComponent<EnemyHUDController>();
        
        eHUD.OnActionIcon((StateEnum)datas[0]);

        //�ൿ �غ� ���·� ��ȯ �� �ൿ �ൿ ����
        characterController.isStatusProcessing = false;
        characterController.TurnEnd();
        //�� ��� üũ
        while (true)
        {
            //��¡ ���� �� ���� ����
            if (!characterController.isCharging && characterController.isAvailabilityOfAction)
                break;
            //���� �ൿ �Ұ� �ɰ�� ���� ���
            else if (!characterController.isAvailabilityOfAction)
            {
                characterController.isCharging = false;
                eHUD.OffActionIcon();
                yield break;
            }
                
            yield return null;
        }
        //�ൿ ������ ���� �κ�
        eHUD.OffActionIcon();

        characterController.isCharging = false;//���� �غ� ���� false

        //�Ű� ���� ���� ���� �ൿ ���� ���� ����
        if (datas[0] != null)
            characterController.TransitionState((StateEnum)datas[0]);//�ൿ ����
    }
}
