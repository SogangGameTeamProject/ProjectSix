using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    private CharacterController _characterController;
    public StateEnum useState;//������ ���� ����� ����

    private void Start()
    {
        _characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    //������ ��� ó��
    public void ClickItem()
    {
        if(!_characterController.isStatusProcessing)
            _characterController.TransitionState(useState);
    }
}
