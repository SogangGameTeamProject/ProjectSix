using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageHUD : MonoBehaviour
{
    private BattleManager _battleManager;//��Ʋ �޴���

    public Text nowTurnInfoHUD;//���� �� ǥ���ϴ� text������Ʈ
    public Text stageRewardsHUD;//���� �������� ������ ǥ���ϴ� Text������Ʈ
    private int stageRewards = 0;//�� ����
    private Coroutine runningCoroutine = null;//���� ���� ���� �ڷ�ƾ

    private void Start()
    {
        _battleManager = BattleManager.Instance;//��Ʋ �Ŵ��� �ʱ�ȭ
    }

    private void Update()
    {
        //HUD ������Ʈ
        if (_battleManager)
        {
            nowTurnInfoHUD.text = (_battleManager.nowTurnCnt).ToString();//�� ���� ����

            //�������� ���� ���� ó�� �κ�
            int targetValue = _battleManager.stageRewards;
            if (stageRewards < targetValue && runningCoroutine == null)
                runningCoroutine = StartCoroutine(IncreaseStageRewards(targetValue, 0.01f));

            stageRewardsHUD.text = stageRewards.ToString();
        }
    }

    //�������� ������ 1�� ���������� ������Ű�� �ڷ�ƾ �Լ�
    IEnumerator IncreaseStageRewards(int targetValue, float delay)
    {
        while(stageRewards < targetValue)
        {
            stageRewards++;
            yield return new WaitForSeconds(delay);
        }

        runningCoroutine = null;
    }
}
