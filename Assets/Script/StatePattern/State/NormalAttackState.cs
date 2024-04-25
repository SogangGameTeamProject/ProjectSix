using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ĳ���� �Ϲݰ���
public class NormalAttackState : StateBase
{
    public float powerCoefficient = 1.0f;
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        yield return new WaitForSeconds(sateDelayTime);//�ִϸ��̼� ����� ���� ������
        int thisDamage = (int)(characterController.offensePower * powerCoefficient);//����� ������ ���ϱ�

        CharacterDirection characterDir = characterController.direction;//ĳ���� ���Ⱑ������

        int onIndex = _battleManager.GetPlatformIndexForObj(characterController.gameObject);
        int attackIndex = onIndex + ((int)characterDir);//���� �� �÷��� index

        //���� ���� ����
        if (attackIndex >= 0 && attackIndex < _battleManager.PlatformList.Length)
        {
            //�ִϸ��̼� ó�� �κ�
            Debug.Log(attackIndex + ", " + attackIndex);
            //������ ��� �κ�
            _battleManager.GiveDamage(attackIndex, thisDamage);
        }

        characterController.TurnEnd();//���� ���� �� �� ����
        yield return base.StateFuntion(datas);
    }
}
