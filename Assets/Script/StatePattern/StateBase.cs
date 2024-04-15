using System.Collections;
using UnityEngine;

public class StateBase : MonoBehaviour, CharacterState
{
    protected CharacterController characterController = null;//ĳ���� ��Ʈ�ѷ�
    protected GameManager _gameManager = null;//���� �޴���
    protected Animator _animator = null;//ĳ���� �ִϸ��̼�

    public void Handle(CharacterController characterController, params object[] datas)
    {
        //ĳ���� ��Ʈ�ѷ� �� �ʱ�ȭ
        if (!this.characterController)
            this.characterController = characterController;
        //ĳ���� �޴��� �� �ʱ�ȭ
        if (!this._gameManager)
            this._gameManager = GameManager.Instance;
        //ĳ���� �ִϸ����� ��������
        if (!this._animator)
            TryGetComponent<Animator>(out _animator);

        characterController.AvailabilityOfAction = false;//�ൿ ���� ���� false ����
        StartCoroutine(StateFuntion(datas));//��� ���� �ڷ�ƾ �Լ� ȣ��
    }

    //��� �޾� ����� ������ �κ�
    protected virtual IEnumerator StateFuntion(params object[] datas)
    {
        characterController.AvailabilityOfAction = true;//�ൿ ���� ���� true ����
        Debug.Log("AvailabilityOfAction: " + characterController.AvailabilityOfAction);
        yield return null;
    }
}
