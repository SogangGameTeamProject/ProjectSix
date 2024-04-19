using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
//ĳ���� �̵�
public class MoveState : StateBase
{
    private CharacterMovement moveController;//�̵� ���� ��Ʈ�ѷ�
    private CharacterDirection moveDirection { get; set; }//�̵� ����
    public float movePower = 30f;//�̵� �ӵ�

    protected override IEnumerator StateFuntion(params object[] datas)
    {
        CharacterMovement movement = GetComponent<CharacterMovement>();//ĳ���� �����Ʈ ��������
        moveDirection = (CharacterDirection)datas[0];//�Է� ���� ĳ���� �̵����� ����
        movement.moveCoroutine = StartCoroutine(movement.StraightLineMovement((int)moveDirection, movePower, 1));//ĳ���� �����Ʈ�� ����Ͽ� �̵� ����

        //�̵��� �� ���� ����
        while (movement.moveCoroutine != null)
        {
            yield return null;
        }

        yield return new WaitForSeconds(sateDelayTime);//�ִϸ��̼� ����� ���� ������
        characterController.TurnEnd();//���� ���� �� �� ����
        yield return base.StateFuntion(datas);
    }
}

