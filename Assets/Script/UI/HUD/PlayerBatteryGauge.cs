using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBatteryGauge : MonoBehaviour
{
    private PlayerController _playerController;//��Ʋ�Ŵ���
    public Text maxBatteryGauge;
    public Text nowBatteryGauge;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();//ĳ���� �Ŵ��� �ʱ�ȭ
    }

    private void Update()
    {
        //���͸� �� ����
        if (_playerController)
        {
            if(maxBatteryGauge != null)
            {
                maxBatteryGauge.text = _playerController.maxBattery.ToString();
            }
            if(nowBatteryGauge != null)
            {
                nowBatteryGauge.text = _playerController.nowBattery.ToString();
            }
        }
    }
}
