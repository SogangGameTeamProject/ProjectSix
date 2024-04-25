using System.Collections;
using UnityEngine;
//ĳ���� �ǰ�
public class HitState : StateBase
{
    private int hitDamage { get; set; }//�ǰ� �� ����� ������

    protected override IEnumerator StateFuntion(params object[] datas)
    {
        hitDamage = (int)datas[0];
        //�ǰ� ó�� ��� ����
        characterController.NowHp -= hitDamage;//������ ���
        Debug.Log(gameObject.name + " is Hit, nowDamage: "+ hitDamage + " nowHp: " + characterController.NowHp);

        yield return new WaitForSeconds(sateDelayTime);//�ִϸ��̼� ����� ���� ������

        //ü���� 0�̸� ���� ó��
        if (characterController.NowHp == 0)
        {
            characterController.isAvailabilityOfAction = false;
            characterController.TransitionState(StateEnum.Die);
            yield break;
        }

        yield return base.StateFuntion(datas);
    }
}

