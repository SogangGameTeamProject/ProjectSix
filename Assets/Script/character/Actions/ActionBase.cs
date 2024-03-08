using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBase : MonoBehaviour
{
    Coroutine actionCoroutine;//�ൿ �� �۵��� �ڷ�ƾ�� ���� ����



    //�ൿ ���� ���� ���� üũ
    public bool RadyOrNot()
    {
        bool ron = false;//��ȯ�� �غ񿩺�



        return ron;
    }

    //�׼� �غ񿩺ο� ���� �׼� ����
    public bool ActionStart()
    {
        bool isAction = false;//���� ����
        if (RadyOrNot())
        {
            actionCoroutine = StartCoroutine(BeforAction());//�׼� ����
            isAction = true;//�׼� ���� ���� true
        }

        return isAction;//�׼� ���࿩�� ��ȯ
    }

    //��ų �������� ���� �κ�
    IEnumerator BeforAction()
    {
        actionCoroutine = StartCoroutine(ExeAction());
        yield return null;
    }

    //��ų ���� �κ�
    IEnumerator ExeAction()
    {
        actionCoroutine = StartCoroutine(AfterAction());
        yield return null;
    }

    //��ų �ĵ����� �κ�
    IEnumerator AfterAction()
    {
        actionCoroutine = null;
        yield return null;
    }
}
