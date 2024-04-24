using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{
    private CharacterController _characterController;//��Ʋ�Ŵ���
    public Image hpBar;//�÷��̾� ü�¹� 
    private float nowHp = 0;//���� ü��
    private Coroutine runningCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();//ĳ���� �Ŵ��� �ʱ�ȭ
        //nowHp = _characterController.NowHp;//���� ü�� ���� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if ((_characterController))
        {
            float targetHp = _characterController.NowHp;//��ǥ ü��
            //ü�� ���� �� ü���� ���������� ��ȭ ��Ű�� �ڷ�ƾ ����
            if (nowHp != targetHp && runningCoroutine ==  null)
                runningCoroutine = StartCoroutine(IncreaseHpGauge(targetHp, 0.001f));
        }
        
    }

    //�÷��̾� ü�¹ٸ� ��ǥ ü�� ���� ���������� ��ȭ��Ű�� �ڷ�ƾ
    IEnumerator IncreaseHpGauge(float targetHp,  float delay)
    {
        float maxHp = _characterController.maxHp;//�ִ� ü�� ��������
        while (nowHp != targetHp)
        {
            nowHp += nowHp > targetHp ? -1 :  1;//���� ü�� ����
            hpBar.fillAmount  = nowHp  / maxHp;//�ִ�ü�¹� ����
            yield return new WaitForSeconds(delay);//����  ������ ��
        }

        runningCoroutine = null;
    }
}
