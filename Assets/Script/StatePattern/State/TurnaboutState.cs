using System.Collections;
using UnityEngine;
//ĳ���� ���� ��ȯ
public class TurnaboutState : StateBase
{
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        //���� ��ȯ ��� ����
        Vector3 thisLocalScale = this.transform.localScale;
        this.transform.localScale = new Vector3(thisLocalScale.x * -1, thisLocalScale.y, thisLocalScale.z);//���� �����Ͽ� x���� -1�� ���Ͽ� ���� ��ȯ ����
        this.GetComponent<CharacterController>().direction = this.transform.localScale.x > 0 ? CharacterDirection.Right : CharacterDirection.Left;

        yield return base.StateFuntion();
    }
}

