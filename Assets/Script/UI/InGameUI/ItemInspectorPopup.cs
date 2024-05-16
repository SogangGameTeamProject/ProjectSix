using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInspectorPopup : MonoBehaviour
{
    public ItemInfo itemInfo;//������ ����
    public Text itemName;//������ �̸�
    public Text itemOffenseTxt;//������ ��ġ ��
    public Text itemOffense;//������ ��ġ
    public Text itemCoast;//������ �ڽ�Ʈ
    public Text itemEffect;//������ ȿ��
    // Start is called before the first frame update
    void Start()
    {
        //������ ���� ����
        itemName.text = itemInfo.itemName;//������ ��
        itemOffense.text = (itemInfo.offense).ToString();//������ ������
        //������ Ÿ�Կ� ���� ������ ��ġ ǥ��
        int itemType = itemInfo.itemType;// ������ Ÿ�� ��������
        string offenseTxt = null;//ǥ���� ��ġ ��
        int offense = (int)itemInfo.offense;//ǥ���� ��ġ
        switch (itemType)
        {
            case 0:
                offenseTxt = "������: ";
                offense = (int)(BattleManager.Instance.onPlayer._characterStatus.offensePower * itemInfo.offense);//������ ���
                break;
            case 1:
                offenseTxt = "���ӽð�: ";
                break;
            case 2:
                offenseTxt = "";
                break;
        }
        itemOffenseTxt.text = offenseTxt;//��ġ��
        itemOffense.text = offense.ToString();//��ġ
        itemCoast.text = (itemInfo.useCost).ToString();//��� �ڽ�Ʈ
        itemEffect.text = itemInfo.effectDescription;//������ ȿ��
    }
}
