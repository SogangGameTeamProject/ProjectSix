using UnityEngine;
[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/ItemInfo", order = 1)]
public class ItemInfo : ScriptableObject
{
    public string itemName = "ItemName";//������ �̸�
    public Sprite itemImg = null;//������ �̹���
    public GameObject itemObj = null;//������ ������Ʈ
    public int price = 100;//������ ����
    public int useCost = 0;//���� ���� �ڽ�Ʈ
    public int itemLevel = 0;//������ ��ȭ �ܰ�
}
