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
        if (characterController.NowHp == 0)
            gameObject.GetComponent<CharacterController>().TransitionState(StateEnum.Die);

        yield return null;
    }
}

