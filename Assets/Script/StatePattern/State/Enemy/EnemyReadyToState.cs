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

        //�ൿ �غ� ���·� ��ȯ �� �ൿ �ൿ ����
        characterController.TurnEnd();

        //�� ��� üũ
        while (true)
        {
            if (!isPreparing)
                break;
            Debug.Log("���� �غ� ��");
            yield return null;
        }
        Debug.Log("���� ����");
        //�Ű� ���� ���� ���� �ൿ ���� ���� ����
        if (datas[0] != null)
            characterController.TransitionState((StateEnum)datas[0]);//�ൿ ����
        else
            yield return base.StateFuntion(datas);

    }

    //�ൿ �غ� ���¿��� ������ �Ǹ� isReady�� ���� true �ϴ� �Լ�
    public void TurnStart()
    {
        Debug.Log("���� �غ� �Ϸ�");
        if(isPreparing == true)
            isPreparing = false;
            
    }
}
