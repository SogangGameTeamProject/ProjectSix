using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Ĩ ���� ��ư ����
public class InsertChipBtn : MonoBehaviour
{
    private GameManager _gameManager;//���� �޴���
    public CheepInfo chipInfo = null;// ����Ĩ ����
    private void Start()
    {
        _gameManager = GameManager.Instance;//���Ӹ޴��� �ʱ�ȭ
    }

    //Ĩ �κ��丮�� �߰��ϴ� �Լ�
    public void OnInsertChip()
    {

    }
}
