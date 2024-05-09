using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBatteryGauge : MonoBehaviour
{
    private PlayerController _playerController;//�÷��̾� ��Ʈ�ѷ�

    public List<Image> batteryImageList;//��ư �̹��� ����Ʈ
    public float batteryInterval = 40;//���͸� ����
    public GameObject batteryPre;//���͸� ������
    public Sprite batteryOnImg;//���͸� ������ �� �̹���
    public Sprite batteryOffImg;//���͸� ������ �� �̹���


    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();//ĳ���� �Ŵ��� �ʱ�ȭ

        //�ִ� ���͸� �뷮 ��ŭ 

        // ��ư�� �� ������ �̿��� ó�� ��ư�� ��ġ ���
        float startX = -(_playerController.maxBattery - 1) * batteryInterval / 2f;
        //�÷��̾� ������ DB�� �������� ������ ��� ��ư ���� �� ��ġ
        for (int i = 0; i < _playerController.maxBattery; i++)
        {
            GameObject battery = Instantiate(batteryPre, transform);

            // ��ư�� ��ġ ���
            float posX = startX + i * batteryInterval;

            // battery�� RectTransform �����ͼ� ��ġ ����
            RectTransform rectTransform = battery.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(posX, rectTransform.anchoredPosition.y);

            //battery Image������Ʈ ����Ʈ�� �ֱ�
            batteryImageList.Add(battery.GetComponent<Image>());
        }
    }

    private void Update()
    {
        //���͸� �� ����
        if (_playerController)
        {
            for (int i = 0; i < _playerController.maxBattery; i++)
            {
                Sprite batteryImg = i < _playerController.nowBattery ? batteryOnImg : batteryOffImg;//���� ���͸� ��ġ�� ���� �̹��� ����
                batteryImageList[i].sprite = batteryImg;
            }
        }
    }
}
