using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
//ĳ���� �̵��� ������ �ο�
public class DamageWhenMovingState : MoveState
{
    public int damage = 10;//�̵� �� �Դ� ������

    protected override IEnumerator StateFuntion(params object[] datas)
    {
        //������ �ο�, �ּ� ü�� 1
        characterController.NowHp -= damage;
        if(characterController.NowHp == 0)
            characterController.NowHp = 1;

        yield return base.StateFuntion(datas);
    }
}

