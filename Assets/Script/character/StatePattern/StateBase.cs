using System.Collections;
using UnityEngine;

public class StateBase : MonoBehaviour, CharacterState
{
    protected CharacterController characterController;//ĳ���� ��Ʈ�ѷ�

    public void Handle(CharacterController characterController)
    {
        if (!this.characterController)
            this.characterController = characterController;

        StartCoroutine(SateFuntion());//��� ���� �ڷ�ƾ �Լ� ȣ��
    }

    //��� �޾� ����� ������ �κ�
    protected virtual IEnumerator SateFuntion()
    {
        yield return null;
    }
}
