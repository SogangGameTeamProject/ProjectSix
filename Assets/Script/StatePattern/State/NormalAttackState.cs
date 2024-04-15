using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ĳ���� �Ϲݰ���
public class NormalAttackState : StateBase
{
    public float powerCoefficient = 1.0f;
    protected override IEnumerator StateFuntion(params object[] datas)
    {

        int thisDamage = (int)(characterController.offensePower * powerCoefficient);//����� ������ ���ϱ�

        CharacterDirection characterDir = characterController.direction;//ĳ���� ���Ⱑ������

        int onIndex = _gameManager.GetPlatformIndexForObj(this.gameObject);
        int attackIndex = onIndex + ((int)characterDir);//���� �� �÷��� index

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
