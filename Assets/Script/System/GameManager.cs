using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public KeyCode reseKey;

    public List<ItemInfo> itemDB;//������ DB
    public List<ItemInfo> playerItemDB;//�÷��̾ ������ ������ DB

    public int moneyHeld { get; set; }//���� ��

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(reseKey))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //���� ���۽� �̺�Ʈ ó��
    public void GameStart()
    {
        
    }

    //���׷��̵� �ܰ� �̺�Ʈ ó��
    public void GameRest()
    {
        
    }

    //���� �й�� �̺�Ʈ ó��
    public void GameLose()
    {
        Debug.Log("PlayerLose");
    }

    //���� �¸��� �̺�Ʈ ó��
    public void GameWin()
    {
        Debug.Log("PlayerWin");
    }
}