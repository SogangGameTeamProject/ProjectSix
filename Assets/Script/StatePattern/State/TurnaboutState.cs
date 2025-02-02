using System.Collections;
using UnityEngine;
//캐릭터 방향 전환
public class TurnaboutState : StateBase
{
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        //방향 전환 기능 구현
        Vector3 thisLocalScale = characterController.transform.localScale;
        characterController.transform.localScale = new Vector3(thisLocalScale.x * -1, thisLocalScale.y, thisLocalScale.z);//로컬 스케일에 x값에 -1을 곱하여 방향 전환 구현
        characterController.direction = characterController.transform.localScale.x > 0 ? CharacterDirection.Right : CharacterDirection.Left;

        yield return new WaitForSeconds(sateDelayTime);//방향전환 후 딜레이

        characterController.TurnEnd();//상태 종료 시 턴 종료

        yield return base.StateFuntion(datas);
    }
}

