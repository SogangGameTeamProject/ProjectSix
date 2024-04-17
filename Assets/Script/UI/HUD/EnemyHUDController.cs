using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUDController : MonoBehaviour
{
    EnemyController _eController;//�� ��Ʈ�ѷ�
    public Image hpBar;//ü�¹� �̹��� ������Ʈ

    private void Start()
    {
        _eController = transform.parent.GetComponent<EnemyController>();//�� ��Ʈ�ѷ� ��������
    }

    private void Update()
    {
        
        //���� ���� ���� HUD ������Ʈ
        if (_eController)
        {
            if (_eController.direction == CharacterDirection.Left)
                this.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            UpdateHealthBar(_eController.NowHp, _eController.maxHp);
        }
    }

    void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        hpBar.fillAmount = healthPercentage;
    }
}
