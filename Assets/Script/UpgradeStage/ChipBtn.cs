using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipBtn : MonoBehaviour
{
    private GameManager _gameManager;//���� �޴���
    public int chipID = -1;//���� �� �߰��� Ĩ ID
    public int chipIndex = -1;//������ Ĩ �ε��� ��
    private void Start()
    {
        _gameManager = GameManager.Instance;//���Ӹ޴��� �ʱ�ȭ
    }

    //Ĩ �κ��丮�� �߰��ϴ� �Լ�
    public void OnInsertChip()
    {

    }
    //Ĩ �κ��丮�� �����ϴ� �Լ�
    public void OnDelateChip()
    {
        _gameManager.SetCheepList(chipIndex, chipID);
    }
}
