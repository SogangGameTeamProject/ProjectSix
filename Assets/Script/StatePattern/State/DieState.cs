using System.Collections;
using UnityEngine;
//ĳ���� ����
public class DieState : StateBase
{
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        yield return new WaitForSeconds(sateDelayTime);//�ִϸ��̼� ����� ���� ������
        //ĳ���� ���� ��� ����
        Debug.Log(gameObject.name + " is Die");
        BattleManager.Instance.onEnemysList.Remove(gameObject);
        Destroy(gameObject);
        yield return null;
    }
}

