using System.Collections;
using UnityEngine;

public class AppearsState : StateBase
{
    protected override IEnumerator SateFuntion()
    {
        //ĳ���� ���� �� �ִϸ��̼� ��� ����
        Debug.Log(gameObject.name + " is Appears");
        yield return null;
    }
}
