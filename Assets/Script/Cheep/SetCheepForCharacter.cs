using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Ĩ�κ��丮�� �ִ� Ĩ������ �������� Ĩ����� �����ϴ� Ŭ����
public class SetCheepForCharacter : MonoBehaviour
{
    GameManager _gameManager = null;//���� �޴���
    CharacterController _chracterController = null;//ĳ���� ��Ʈ�ѷ�
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;//���� �޴��� �� �ʱ�ȭ
        _chracterController = GetComponent<CharacterController>();//ĳ���� ��Ʈ�ѷ� �� �ʱ�ȭ

        //nullüũ
        if(_gameManager != null && _chracterController != null)
        {
            //Ĩ �κ��丮�� Ĩ ������ �������� ���� Ÿ�Ժ� ���� ����
            

        }
    }

}
