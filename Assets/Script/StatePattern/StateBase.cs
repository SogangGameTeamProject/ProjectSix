using System.Collections;
using UnityEngine;

public abstract class StateBase : MonoBehaviour, CharacterState
{
    protected CharacterController characterController = null;//ĳ���� ��Ʈ�ѷ�
    protected GameManager _gameManager = null;//���� �޴���
    protected Animator _animator = null;//ĳ���� �ִϸ��̼�

    public string stateAniParamater = "";
    public float sateDelayTime = 0.5f;//���� ������ �ð�

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
        //ĳ���� �ൿ �ִϸ��̼� ���
        if (!string.IsNullOrEmpty(stateAniParamater) && this._animator)
            _animator.SetTrigger(stateAniParamater);
         
        characterController.isStatusProcessing = true;//ĳ���� ���� ó�� ��

        StartCoroutine(StateFuntion(datas));//��� ���� �ڷ�ƾ �Լ� ȣ��
    }

    //��� �޾� ����� ������ �κ�
    protected virtual IEnumerator StateFuntion(params object[] datas)
    {
        characterController.isStatusProcessing = false;//ĳ���� ���� ó�� ����
        yield return null;
    }
}
