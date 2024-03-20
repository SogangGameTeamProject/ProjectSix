using UnityEngine;

public class CharacterForwardState : StateBase
{
    private CharacterMovement moveController;//�̵� ���� ��Ʈ�ѷ�
    private CharacterDirection moveDirection;//�̵� ����
    private float moveFower = 30f;//�̵� �ӵ�
    public override void Handle(CharacterController characterController)
    {
        base.Handle(characterController);

        //�ش� ������ ��� ���� �κ�
        moveController = GetComponent<CharacterMovement>();//ĳ���� �̵� ���� ������Ʈ ��������
        moveDirection = characterController.direction;

        StartCoroutine(moveController.StraightLineMovement((int)moveDirection, moveFower, 1));//�̵� ���� �ڷ�ƾ ȣ��
        
    }
}

