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
                runningCoroutine = StartCoroutine(IncreaseHpGauge(targetHp, 10f));
        }
        
    }

    //�÷��̾� ü�¹ٸ� ��ǥ ü�� ���� ���������� ��ȭ��Ű�� �ڷ�ƾ
    IEnumerator IncreaseHpGauge(float targetHp,  float fillSpeed)
    {
        float maxHp = _characterController._characterStatus.maxHp;//�ִ� ü�� ��������
        float startHp = nowHp;
        while (true)
        {
            //���� äũ
            if ((startHp > targetHp && nowHp <= targetHp) || (startHp < targetHp && nowHp >= targetHp))
                break;
            nowHp += nowHp > targetHp ? -fillSpeed : fillSpeed;//���� ü�� ����
            hpBar.fillAmount  = nowHp  / maxHp;//�ִ�ü�¹� ����
            yield return new WaitForFixedUpdate();//����  ������ ��
        }
        //ü�¹� ������
        nowHp = targetHp;
        hpBar.fillAmount = nowHp / maxHp;

        runningCoroutine = null;
    }
}
