using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    private PlayerController _playerController;
    public StateEnum useState;//������ ���� ����� ����
    public float offense = 1f;//���
    public int useCost = 5;//��� �� ���� �ڽ�Ʈ

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();//�÷��̾� ��ü ��������
    }

    //������ ��� ó��
    public void ClickItem()
    {
        //������ ��� ���� ���� üũ
        if(!_playerController.isStatusProcessing && _playerController.isTurnReady && _playerController.nowBattery >= useCost)
        {
            _playerController.TransitionState(useState);//������ ���
            _playerController.nowBattery -= useCost;//�ڽ�Ʈ ����
        }  
    }
}
