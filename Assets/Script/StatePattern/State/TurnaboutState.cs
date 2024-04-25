using System.Collections;
using UnityEngine;
//ĳ���� ���� ��ȯ
public class TurnaboutState : StateBase
{
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        //���� ��ȯ ��� ����
        Vector3 thisLocalScale = characterController.transform.localScale;
        characterController.transform.localScale = new Vector3(thisLocalScale.x * -1, thisLocalScale.y, thisLocalScale.z);//���� �����Ͽ� x���� -1�� ���Ͽ� ���� ��ȯ ����
        characterController.direction = characterController.transform.localScale.x > 0 ? CharacterDirection.Right : CharacterDirection.Left;

        yield return new WaitForSeconds(sateDelayTime);//������ȯ �� ������

        characterController.TurnEnd();//���� ���� �� �� ����

        yield return base.StateFuntion(datas);
    }
}

