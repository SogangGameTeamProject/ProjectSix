using System.Collections;
using UnityEngine;

//Enemy  ��ü�� ���� �� �÷��̾��� ü�� ȸ��
public class RecoveHPWhenKillState : DieState
{
    public int recoveryLevel = 75;//ü�� ȸ�� ��ġ
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        //�÷��̾� ü�� ȸ��
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");//�÷��̾� ������Ʈ ��������
        if(playerObj != null)
        {
            CharacterController playerController = playerObj.GetComponent<CharacterController>();//ĳ���� ��Ʈ�ѷ� ��������

            playerController.NowHp += recoveryLevel;//ü�� ȸ��
        }
        

        yield return base.StateFuntion(datas);
    }
}