using System.Collections;
using UnityEngine;

//���� ��Ʈ Ĩ ��� ����(�׾��� ��Ȱ�ϴ� ���)��
public class ServeHartState : StateBase
{
    public int serveHartCnt = 1;//��Ȱ Ƚ��
    public float recoveryRate = 0.5f;//��Ȱ �� ü��ȸ�� ����
    public float respawnDelay = 0.3f;//������ �� ������
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        yield return new WaitForSeconds(sateDelayTime);//�ִϸ��̼� ����� ���� ������
        
        //��Ȱ ���� ���� üũ
        if (serveHartCnt > 0)
        {
            serveHartCnt--;//��Ȱ Ƚ�� ����
            characterController._characterStatus.nowHp = (int)(characterController._characterStatus.maxHp * recoveryRate);//ü�� ȸ��
            yield return new WaitForSeconds(respawnDelay);//������ �� ������ ����
            yield return base.StateFuntion(datas);
        }
        //�Ұ��� �� ���� ���� ȣ��
        else
        {
            characterController.TransitionState(StateEnum.Die);
        }

        yield return null;
    }
}