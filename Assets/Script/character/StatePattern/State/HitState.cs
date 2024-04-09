using System.Collections;
using UnityEngine;

public class HitState : StateBase
{
    public int hitDamage { get; set; }//�ǰ� �� ����� ������

    protected override IEnumerator StateFuntion()
    {
        
        //�ǰ� ó�� ��� ����
        characterController.NowHp = -hitDamage;//������ ���
        Debug.Log(gameObject.name + " is Hit, nowDamage: "+ hitDamage + " nowHp: " + characterController.NowHp);
        if (characterController.NowHp == 0)
            gameObject.GetComponent<CharacterController>().DieState();
        yield return null;
    }
}

