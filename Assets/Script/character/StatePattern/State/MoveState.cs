using System.Collections;
using UnityEngine;

public class MoveState : StateBase
{
    private CharacterMovement moveController;//�̵� ���� ��Ʈ�ѷ�
    public CharacterDirection moveDirection { get; set; }//�̵� ����
    private float movePower = 30f;//�̵� �ӵ�

    protected override IEnumerator SateFuntion()
    {
        StartCoroutine(this.GetComponent<CharacterMovement>().StraightLineMovement((int)moveDirection, movePower, 1));//ĳ���� �����Ʈ�� ����Ͽ� �̵� ����
        yield return null;
    }
}

