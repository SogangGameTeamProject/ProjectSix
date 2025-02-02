using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageHUD : MonoBehaviour
{
    private BattleManager _battleManager;//배틀 메니저

    public Text nowTurnInfoHUD;//현재 턴 표기하는 text오브젝트
    public Text stageRewardsHUD;//현재 스테이지 보상을 표기하는 Text오브젝트
    private int stageRewards = 0;//스테이지 보상
    private Coroutine runningCoroutine = null;//현재 실행 중인 코루틴
    public int increaseSpeed = 3;//스테이지 보상 증가 속도

    private void Start()
    {
        _battleManager = BattleManager.Instance;//배틀 매니저 초기화
    }

    private void Update()
    {
        //HUD 업데이트
        if (_battleManager)
        {
            nowTurnInfoHUD.text = (_battleManager.nowTurnCnt).ToString();//턴 정보 갱신

            //스테이지 보상 갱신 처리 부분
            int targetValue = _battleManager.stageRewards;
            if (stageRewards < targetValue && runningCoroutine == null)
                runningCoroutine = StartCoroutine(IncreaseStageRewards(targetValue, increaseSpeed));

            stageRewardsHUD.text = stageRewards.ToString();
        }
    }

    //스테이지 보상을 순차적으로 증가시키는 코루틴 함수
    IEnumerator IncreaseStageRewards(int targetValue, int increaseSpeed)
    {
        while(stageRewards < targetValue)
        {
            stageRewards+= increaseSpeed;
            if (stageRewards > targetValue)
                stageRewards = targetValue;
            yield return new WaitForFixedUpdate();
        }

        

        runningCoroutine = null;
    }
}
