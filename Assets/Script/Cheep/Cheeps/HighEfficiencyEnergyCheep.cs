using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighEfficiencyEnergyCheep : CheepBase
{
    public int increasedRecoveryAmount = 1;//���� ȸ����
    public int maximumReductionAmount = 5;//���͸� �ִ�ġ ���ҷ�
    //��ȿ�� ������ Ĩ
    //���͸� ȸ���� ���� �� �ִ� ���͸��� ����
    public override void ActivateChipEffect()
    {
        PlayerController _playerController = transform.parent.parent.GetComponent<PlayerController>();
        //���͸� ȸ���� ���� �� �ִ� ���� ����
        if(_playerController != null)
        {
            _playerController.batteryRecoveryFigures += increasedRecoveryAmount;
            _playerController._characterStatus.maxBattery = maximumReductionAmount;
        }
    }
}
