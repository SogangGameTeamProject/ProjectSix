using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackState : StateBase
{
    public float powerCoefficient = 1.0f;
    protected override IEnumerator StateFuntion()
    {
        
        int thisDamage = characterController.offensePower * (int)powerCoefficient;//����� ������ ���ϱ�

        CharacterDirection characterDir = characterController.direction;//ĳ���� ���Ⱑ������

        int onIndex = _gameManager.GetPlatformIndexForObj(this.gameObject);
        int attackIndex = onIndex + ((int)characterDir);//���� �� �÷��� index
        //���� ���� ����
        if (attackIndex >= 0 && attackIndex < _gameManager.PlatformList.Length)
        {
            //�ִϸ��̼� ó�� �κ�

            //������ ��� �κ�
            GameObject targetCharacter = _gameManager.GetOnPlatformObj(attackIndex);//���� ��ġ �÷����� ĳ���� ������Ʈ ��������
            if (targetCharacter != null)
            {
                Debug.Log("Attack: " + thisDamage);
                targetCharacter.GetComponent<CharacterController>().HitState(thisDamage);//���� ��� �ǰ� ó��
            }
        }

        yield return base.StateFuntion();
    }
}
