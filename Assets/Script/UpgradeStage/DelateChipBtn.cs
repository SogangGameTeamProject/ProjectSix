using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���� Ĩ ��ư ����
public class DelateChipBtn : MonoBehaviour
{
    private GameManager _gameManager;//���� �޴���
    public int chipIndex = -1;//������ Ĩ �ε��� ��
    private void Start()
    {
        _gameManager = GameManager.Instance;//���Ӹ޴��� �ʱ�ȭ
    }

    //Ĩ �κ��丮�� �����ϴ� �Լ�
    public void OnDelateChip()
    {
        if (chipIndex > 0 && chipIndex < _gameManager.cheepInventory.Count)
        {

        }
    }
}
