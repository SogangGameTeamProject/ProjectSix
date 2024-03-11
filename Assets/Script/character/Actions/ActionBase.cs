using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBase : MonoBehaviour
{
    Coroutine actionCoroutine;//�ൿ �� �۵��� �ڷ�ƾ�� ���� ����

    public float beforTime = 0;//�ൿ ���� �ð�
    public float exeTime = 0;//�ൿ ���� �ð�
    public float afterTime = 0;//�ൿ �ĵ� �ð�
    public int coolTimeTurn = 0;//�ൿ ���뿡 �ʿ��� ��

    //�ൿ ���� ���� ���� üũ
    //�ڼ��� ������  �ڽĿ��� ����
    public virtual bool RadyOrNot()
    {
        return false;
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

    //�ൿ �������� ���� �κ�
    protected IEnumerator BeforAction()
    {
        //������ ����
        if (beforTime != 0)
            yield return new WaitForSeconds(beforTime);

        actionCoroutine = StartCoroutine(ExeAction());//��ų���� �ڷ�ƾ ȣ��
        yield return null;
    }

    //�ൿ ���� �κ�
    protected IEnumerator ExeAction()
    {
        //������ ����
        if (exeTime != 0)
            yield return new WaitForSeconds(exeTime);

        actionCoroutine = StartCoroutine(AfterAction());//��ų �ĵ����� ����
        yield return null;
    }

    //�ൿ �ĵ����� �κ�
    protected IEnumerator AfterAction()
    {
        //������ ����
        if (afterTime != 0)
            yield return new WaitForSeconds(afterTime);

        actionCoroutine = null;
        yield return null;
    }

    //�ൿ ��Ÿ�� ���� �κ�
    protected virtual IEnumerator ActionCool()
    {
        yield return null;
    }
}
