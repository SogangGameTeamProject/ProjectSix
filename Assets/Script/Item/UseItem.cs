using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    private PlayerController _playerController;
    public Image itemImg;//������ �̹���
    public Text itemText;//�ڽ�Ʈ �ؽ�Ʈ
    public StateEnum useState;//������ ���� ����� ����
    public float offense = 1f;//���
    public int useCost = 5;//��� �� ���� �ڽ�Ʈ

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();//�÷��̾� ��ü ��������
    }

    private void Update()
    {
        itemText.text = useCost.ToString();//���� �ڽ�Ʈ ����
    }

    //������ ��� ó��
    public void ClickItem()
    {
        //������ ��� ���� ���� üũ
        if (_playerController)
        {
            if (!_playerController.isStatusProcessing && _playerController.isTurnReady && _playerController.nowBattery >= useCost)
            {
                _playerController.TransitionState(useState, offense);//������ ���
                _playerController.nowBattery -= useCost;//�ڽ�Ʈ ����
            }
        }
    }
}
