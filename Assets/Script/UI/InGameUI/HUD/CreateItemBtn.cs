using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateItemBtn : MonoBehaviour
{
    GameManager _gameManager;//���� �޴���
    private List<ItemInfo> itemList = new List<ItemInfo>();//�÷��̾ �������� ������ DB
    public float btnInterval = 40;//��ư ����
    public GameObject useItemBtnPre;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;//���� �޴��� ��������
        itemList = _gameManager.playerItemDB;//�÷��̾ �������� ������ DB ��������

        // ����� �������� �����ϱ� ���� ȭ�� �ʺ��� ���� �� ���
        float centerX = 0;
        // ��ư�� �� ������ �̿��� ó�� ��ư�� ��ġ ���
        float startX = centerX - (itemList.Count - 1) * btnInterval / 2f;
        //�÷��̾� ������ DB�� �������� ������ ��� ��ư ���� �� ��ġ
        for (int i = 0; i < itemList.Count; i++)
        {
            
            GameObject itemBtn = Instantiate(useItemBtnPre, transform);

            //item��� ��ư �� �ʱ�ȭ
            UseItem useItem = useItemBtnPre.GetComponent<UseItem>();
            if (useItem != null)
            {
                useItem.itemImg.sprite = itemList[i].itemImg;//������ �̹��� ����
                useItem.useState = itemList[i].state;//��� ���� ����
                useItem.useCost = itemList[i].useCost;//��� �ڽ�Ʈ ����
                useItem.offense = itemList[i].offense;//��� ��� ����
            }

            // ��ư�� ��ġ ���
            float posX = startX + i * btnInterval;

            // ��ư�� RectTransform �����ͼ� ��ġ ����
            RectTransform rectTransform = itemBtn.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(posX, rectTransform.anchoredPosition.y);

            
        }
    }
}
