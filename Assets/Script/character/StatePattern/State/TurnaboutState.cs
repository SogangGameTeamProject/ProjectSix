using System.Collections;
using UnityEngine;

public class TurnaboutState : StateBase
{
    protected override IEnumerator StateFuntion()
    {
        //���� ��ȯ ��� ����
        Vector3 thisLocalScale = this.transform.localScale;
        this.transform.localScale = new Vector3(thisLocalScale.x * -1, thisLocalScale.y, thisLocalScale.z);//���� �����Ͽ� x���� -1�� ���Ͽ� ���� ��ȯ ����
        yield return base.StateFuntion();
    }
}

