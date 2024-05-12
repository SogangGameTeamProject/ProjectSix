using UnityEngine;
[CreateAssetMenu(fileName = "ItemInfo", menuName = "ScriptableObjects/ItemInfo", order = 1)]
public class ItemInfo : ScriptableObject
{
    public string itemName = "ItemName";//������ �̸�
    public Sprite itemImg = null;//������ �̹���
    public StateEnum state;//������ ���� ��
    public int price = 100;//������ ����
    public float offense = 1.0f;//���
    public int useCost = 0;//���� ���� �ڽ�Ʈ
    public int itemLevel = 0;//������ ��ȭ �ܰ�
}
