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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //cheep����Ʈ�� �������� Ĩ ��ư �����ϴ� �Լ�
    private void SetChipBtn()
    {

    }
}
