using UnityEngine;
[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/ItemInfo", order = 1)]
public class ItemInfo : ScriptableObject
{
    public string itemName = "ItemName";//������ �̸�
    public int itemType = 0;//������ Ÿ�� 0: ���� 1: ��� 2: Ư��
    public Sprite itemImg = null;//������ �̹���
    public StateEnum state;//������ ���� ��
    public int price = 100;//������ ����
    public float offense = 1.0f;//���
    public int useCost = 0;//���� ���� �ڽ�Ʈ
    public string effectDescription;//ȿ�� ����
    public string storeDescription;//������ �� ������ ����
}
