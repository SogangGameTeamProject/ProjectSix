using System.Collections;
using UnityEngine;

public class DieState : StateBase
{
    protected override IEnumerator StateFuntion()
    {
        //ĳ���� ���� ��� ����
        Debug.Log(gameObject.name + " is Die");
        yield return null;
    }
}

