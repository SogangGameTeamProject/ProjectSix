using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    private PlayerController _playerController;
    public StateEnum useState;//������ ���� ����� ����
    public int cost = 5;

    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    //������ ��� ó��
    public void ClickItem()
    {

        if(!_playerController.isStatusProcessing && _playerController.isTurnReady && _playerController.nowBattery >= cost)
        {
            _playerController.TransitionState(useState);
            _playerController.nowBattery -= cost;
        }
            
    }
}
