using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUDController : MonoBehaviour
{
    EnemyController _eController;//�� ��Ʈ�ѷ�
    public Image hpBar;//ü�¹� �̹��� ������Ʈ
    public Image actionIcon;//�ൿ �������� ǥ���� �̹��� ������Ʈ

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
            UpdateHealthBar(_eController.NowHp, _eController.maxHp);
        }
    }

    //Hud������Ʈ �ϴ� �Լ�
    void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        hpBar.fillAmount = healthPercentage;
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
