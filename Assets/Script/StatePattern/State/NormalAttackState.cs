using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackState : StateBase
{
    private float powerCoefficient = 1.0f;
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        powerCoefficient = (float)datas[0];
        int thisDamage = characterController.offensePower * (int)powerCoefficient;//����� ������ ���ϱ�

        CharacterDirection characterDir = characterController.direction;//ĳ���� ���Ⱑ������

        int onIndex = _gameManager.GetPlatformIndexForObj(this.gameObject);
        int attackIndex = onIndex + ((int)characterDir);//���� �� �÷��� index
        Debug.Log(attackIndex + ", " + (int)characterDir);
        //���� ���� ����
        if (attackIndex >= 0 && attackIndex < _gameManager.PlatformList.Length)
        {
            //�ִϸ��̼� ó�� �κ�

            //������ ��� �κ�
            _gameManager.GiveDamage(attackIndex, thisDamage);
        }

        yield return base.StateFuntion();
    }
}
