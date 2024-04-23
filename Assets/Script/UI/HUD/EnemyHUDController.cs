using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUDController : MonoBehaviour
{
    EnemyController _eController;//�� ��Ʈ�ѷ�
    public Image hpBar;//ü�¹� �̹��� ������Ʈ
    private float nowHp;//���� ü��
    public Image actionIcon;//�ൿ �������� ǥ���� �̹��� ������Ʈ
    private Coroutine runningCoroutine = null;

    //���� Ÿ�԰� ������ ������ ���� Ŭ����
    [System.Serializable]
    public class ActionInfo {
        public StateEnum stateEnum;
        public Sprite icon;
    }

    //�׼� ���� Ÿ���� �Է� ���� ����Ʈ(���� �غ�� stateEnum ���� ���� �ൿ �������� ���� ���� ���)
    public List<ActionInfo> actionList;

    private void Start()
    {
        _eController = GetComponent<EnemyController>();//�� ��Ʈ�ѷ� ��������
    }

    private void Update()
    {
        
        //���� ���� ���� HUD ������Ʈ
        if (_eController)
        {
            if (_eController.direction == CharacterDirection.Left)
                this.transform.GetChild(0).localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            //ü�� ���� �� ü���� ���������� ��ȭ ��Ű�� �ڷ�ƾ ����
            float targetHp = _eController.NowHp;//��ǥ ü��
            if (nowHp != targetHp && runningCoroutine == null)
                runningCoroutine = StartCoroutine(IncreaseHpGauge(targetHp, 0.001f));
        }
    }

    //Hud������Ʈ �ϴ� �Լ�
    //�÷��̾� ü�¹ٸ� ��ǥ ü�� ���� ���������� ��ȭ��Ű�� �ڷ�ƾ
    IEnumerator IncreaseHpGauge(float targetHp, float delay)
    {
        float maxHp = _eController.maxHp;//�ִ� ü�� ��������
        while (nowHp != targetHp)
        {
            nowHp += nowHp > targetHp ? -1 : 1;//���� ü�� ����
            hpBar.fillAmount = nowHp / maxHp;//�ִ�ü�¹� ����
            yield return new WaitForSeconds(delay);//����  ������ ��
        }

        runningCoroutine = null;
    }

    //���� �غ� �� �׼� ������ ���� �Լ�
    public void OnActionIcon(StateEnum state)
    {
        ActionInfo actionInfo = actionList.Find(actionList => actionList.stateEnum.Equals(state));
        if (actionInfo != null)
        {
            //������ �̹����������� ����
            if (actionInfo.icon != null)
            {
                actionIcon.sprite = actionInfo.icon;
                actionIcon.gameObject.SetActive(true);
            }
        }
    }

    //���� ���� �� �׼� ������ ���� �Լ�
    public void OffActionIcon()
    {
        actionIcon.gameObject.SetActive(false);//������ ��Ȱ��ȭ
    }
}
