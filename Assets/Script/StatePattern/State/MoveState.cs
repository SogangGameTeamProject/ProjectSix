using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveState : StateBase
{
    private CharacterMovement moveController;//�̵� ���� ��Ʈ�ѷ�
    private CharacterDirection moveDirection { get; set; }//�̵� ����
    private float movePower = 30f;//�̵� �ӵ�

    protected override IEnumerator StateFuntion(params object[] datas)
    {
        moveDirection = (CharacterDirection)datas[0];//�Է� ���� ĳ���� �̵����� ����
        StartCoroutine(this.GetComponent<CharacterMovement>().StraightLineMovement((int)moveDirection, movePower, 1));//ĳ���� �����Ʈ�� ����Ͽ� �̵� ����
        yield return base.StateFuntion();
    }
}

