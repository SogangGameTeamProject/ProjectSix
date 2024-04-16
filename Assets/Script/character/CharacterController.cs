using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    protected GameManager gameManager = null;//게임 매니저를 가져와 저장할 변수

    [Header("Player Status")]
    public int maxHp = 100;//최대체력
    private int nowHp;//현재 체력
    //현재체력 프로퍼티
    public int NowHp 
    {
        get
        {
            return nowHp;
        }
        set
        {
            nowHp = value;
            //최대체력보다 높아지거나 0보다 작아지면 조정
            if (nowHp > maxHp) nowHp = maxHp;
            else if(nowHp < 0) nowHp = 0;

        }
    }
    public int offensePower = 50;//공격력
    
    public CharacterDirection direction { get; set; }//캐릭터가 바라보는 방향
    public bool isTurnReady = false;//턴 준비 여부
    public bool AvailabilityOfAction = true;//행동 가능 여부
    //상태 정보
    [System.Serializable]
    public class StateInfo
    {
        public StateBase state;//상태
        public StateEnum stateEnum;//상태 열거형
    }
    [SerializeField]
    public List<StateInfo> _stateList;//캐릭터의 각 상태들을 답을 리스트
    protected CharacterStateContext characterStateContext;//캐릭터 상태 콘텍스트
    public bool isDie = false;//죽음 여부
    protected virtual void Start()
    {
        gameManager = GameManager.Instance;//게임 매니저 값 초기화

        characterStateContext = new CharacterStateContext(this);//상태콘택스트 초기화
        nowHp = maxHp;//현재 체력 초기화
        direction = this.transform.localScale.x > 0 ? CharacterDirection.Right : CharacterDirection.Left;//캐릭터 방향 값 초기화
    }
    //캐릭터 턴 시작 처리
    public virtual void TurnStart()
    {
        //죽어있는 캐릭터는 턴 시작 처리 X
        if (isDie)
            return;
        isTurnReady = true;
    }

    //캐릭터 턴 종료 처리
    public virtual void TurnEnd()
    {
        isTurnReady = false;//턴 오버 처리
    }
    

    //상태명으로 상태 호출하는 함수
    public void TransitionState(StateEnum stateEnum, params object[] datas)
    {
        Debug.Log(stateEnum);
        CharacterState state = _stateList.Find(state => state.stateEnum.Equals(stateEnum)).state;//상태 명으로 상태 가져오기
        
        characterStateContext.Transition((CharacterState)state, datas);
    }
}
