using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelaxationSystem : MonoBehaviour
{
    public int recoveryHp;//ȸ�� ü��
    private GameManager _gameManager;//���� �޴���
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameManager.Instance;//���� �޴��� �� �ʱ�ȭ

        //ü�� ȸ�� ����
        if(_gameManager.playerStatus != null)
        {
            _gameManager.playerStatus.nowHp += recoveryHp;
            if (_gameManager.playerStatus.nowHp > _gameManager.playerStatus.maxHp)
                _gameManager.playerStatus.nowHp = _gameManager.playerStatus.maxHp;
        }
        
    }
}
