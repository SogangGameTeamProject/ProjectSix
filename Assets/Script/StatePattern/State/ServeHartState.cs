using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//���� ��Ʈ Ĩ ��� ����(�׾��� ��Ȱ�ϴ� ���)��
public class ServeHartState : DieState
{
    public int serveHartCnt = 1;//��Ȱ Ƚ��
    public float recoveryRate = 0.5f;//��Ȱ �� ü��ȸ�� ����
    public float respawnDelay = 0.3f;//������ �� ������

    public float deadDelay = 1.2f;//���� �� ������
    public string deadAniPara = "DieState";//���� �� ����� �ִ� �Ķ����
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        //��Ȱ ���� ���� üũ
        if (serveHartCnt > 0)
        {
            yield return new WaitForSeconds(sateDelayTime);//�ִϸ��̼� ����� ���� ������
            serveHartCnt--;//��Ȱ Ƚ�� ����
            characterController._characterStatus.nowHp = (int)(characterController._characterStatus.maxHp * recoveryRate);//ü�� ȸ��
            yield return new WaitForSeconds(respawnDelay);//������ �� ������ ����
            characterController.isStatusProcessing = false;//ĳ���� ���� ó�� ����
            yield break;
        }
        _animator.SetTrigger(deadAniPara);//���� �� �ִ� ���
        yield return new WaitForSeconds(deadDelay);//���� �� ������ ����

        //�Ұ��� �� ���� ���� ȣ��
        yield return base.StateFuntion(datas);
    }
}