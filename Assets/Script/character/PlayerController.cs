using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterBase
{
    //�ൿ������ �ൿ ����
    public bool ActionExeToName(string actionName)
    {
        bool ron = false;//���� ����

        ActionInfo getAction = actionList.Find(x => x.actionName == actionName);//�׼Ǹ���Ʈ�� �Է¹��� �׼Ǹ�� ���� �׼��� ã��
        //nullüũ
        if (getAction != null)
        {

        }


        return ron;//���࿩�� ��ȯ
    }
}
