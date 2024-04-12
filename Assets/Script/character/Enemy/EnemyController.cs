using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    //적이 사용할 상태에 대한 정보
    [System.Serializable]
    public class StateCondition
    {
        public StateEnum stateEnum; // 상태 열거형
        public float range; // 사거리, 0은 사거리 없음
        public float cooldown; // 쿨타임, 0은 쿨타임 없음
        public float nowCoolTIme;//현제 쿨타임
        public object paramater;//파라미터
    }

    public List<StateCondition> stateConditions; // 상태와 조건의 리스트


    //이벤트 등록
    private void OnEnable()
    {
        TurnEventBus.Subscribe(TurnEventType.EnemyTurn, TurnStart);
    }

    //이벤트 해제
    private void OnDisable()
    {
        TurnEventBus.Unsubscribe(TurnEventType.EnemyTurn, TurnStart);
    }

    protected override void Start()
    {
        base.Start();
        
    }

    private void Update()
    {
        //enemy턴이 되었을 때 행동을 하나 골라 실행 하는 코드
        if (isTurnReady)
        {
            // 상태 리스트에서 조건에 맞는 상태를 선택
            StateEnum selectStateEnum = SelectStateEnum();
            if (selectStateEnum > 0)
            {
                // 선택된 상태를 실행
                TransitionState(selectStateEnum);
            }
        }
    }

    //stateConditions리스트에서 사용가능 한 상태를 우선순위에 따라 찾아 해당 상태 열거형을 반환
    private StateEnum SelectStateEnum()
    {
        StateEnum stateEnum = 0;//사용할 상태 실행함수 이름

        //우선 순위에 따른 적 행동 선택
        foreach(StateCondition condition in stateConditions)
        {

        }

        return stateEnum;
    }

    //Enemy 턴 종료 처리
    public override void TurnEnd()
    {
        GameManager.Instance.GetComponent<BattleManager>().OnTurnOverEnemyCnt++;//턴종료된 적 카운트 ++
        base.TurnEnd();//턴 앤드 처리
        TurnEventBus.Publish(TurnEventType.TurnEnd);//턴종료 이벤트 발생
    }
}
