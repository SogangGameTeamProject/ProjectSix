using UnityEngine;

public class StateBase : MonoBehaviour, CharacterState
{
    private CharacterController characterController;

    public virtual void Handle(CharacterController characterController)
    {
        if (!this.characterController)
            this.characterController = characterController;

        //�ڽĿ��� override�Ͽ� �ۼ��Һκ�
        //ȣ�� �� ����� ������ �κ�
        
    }
}
