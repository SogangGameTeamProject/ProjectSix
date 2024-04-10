using System.Collections;
using UnityEngine;

public class StateBase : MonoBehaviour, CharacterState
{
    protected CharacterController characterController;//ĳ���� ��Ʈ�ѷ�
    protected GameManager _gameManager;//���� �޴���

    public void Handle(CharacterController characterController, params object[] datas)
    {
        //ĳ���� ��Ʈ�ѷ� �� �ʱ�ȭ
        if (!this.characterController)
            this.characterController = characterController;
        //ĳ���� �޴��� �� �ʱ�ȭ
        if (!this._gameManager)
            this._gameManager = GameManager.Instance;
        StartCoroutine(StateFuntion(datas));//��� ���� �ڷ�ƾ �Լ� ȣ��
    }

    //��� �޾� ����� ������ �κ�
    protected virtual IEnumerator StateFuntion(params object[] datas)
    {
        characterController.TurnEnd();//���� ���� �� �� ����
        yield return null;
    }
}
