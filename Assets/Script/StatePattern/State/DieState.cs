using System.Collections;
using UnityEngine;
//ĳ���� ����
public class DieState : StateBase
{
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        characterController.AvailabilityOfAction = false;//ĳ���� �ൿ �Ұ� ���·� ��ȯ
        yield return new WaitForSeconds(sateDelayTime);//�ִϸ��̼� ����� ���� ������
        //ĳ���� ���� ��� ����
        Debug.Log(gameObject.name + " is Die");
        _gameManager.GetComponent<BattleManager>().onEnemysList.Remove(gameObject);
        Destroy(gameObject);
        yield return null;
    }
}

