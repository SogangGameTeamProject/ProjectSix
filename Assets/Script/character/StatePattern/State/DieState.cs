using System.Collections;
using UnityEngine;

public class DieState : StateBase
{
    protected override IEnumerator SateFuntion()
    {
        //ĳ���� ���� ��� ����
        Debug.Log(gameObject.name + " is Die");
        yield return base.SateFuntion();
    }
}

