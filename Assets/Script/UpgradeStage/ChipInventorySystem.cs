using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Ĩ����â UI ����
public class ChipInventorySystem : MonoBehaviour
{
    private GameManager _gameManager = null;//���� �޴���

    //���콺 ���� ���� Ĩ���� ǥ�ð��� ���� ����

    //Ĩ ��ư ������ ���� ���� ������
    private List<CheepInfo> notHeldChipList;//�̺��� Ĩ ����Ʈ
    private List<GameObject> notHeldChipBtnList;//�̺��� Ĩ ��ư ����Ʈ
    public GameObject InsertChipBtnPre;//
    private List<CheepInfo> heldChipList;//���� Ĩ ����Ʈ
    public List<GameObject> heldChipBtnList;//���� Ĩ ��ư ����Ʈ
    

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;//���Ӹ޴��� �ʱ�ȭ

        SetChipBtn();//��ư �ʱ�ȭ
    }

    //cheep����Ʈ�� �������� Ĩ ��ư �����ϴ� �Լ�
    private void SetChipBtn()
    {
        //���� Insert��ư �����
        while(notHeldChipBtnList.Count > 0)
        {
            Destroy(notHeldChipBtnList[0]);
            notHeldChipBtnList.RemoveAt(0);
        }

        heldChipList = notHeldChipList = _gameManager.cheepDataBase;//Ĩ ������ ��������

        List<int> cheepInventory = _gameManager.cheepInventory;//���� Ĩ ���� ��������



    }
}
