using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public KeyCode reseKey;

    public List<int> stageLevel;//���� ���൵ �� �������� ���̵� ����
    public int nowProgress = 0;//���� ���൵
    public List<ItemInfo> itemDB;//������ DB
    public List<ItemInfo> playerItemDB;//�÷��̾ ������ ������ DB

    public int moneyHeld { get; set; }//���� ��
    public CharacterStatus playerStatus = null;//�÷��̾� �������ͽ�

    //Ȱ��ȭ�� �̺�Ʈ ����
    private void OnEnable()
    {
        TurnEventBus.Subscribe(TurnEventType.StageClear, StageClear);//TurnStart �̺�Ʈ ����
    }

    //��Ȱ��ȭ�� �̺�Ʈ ����
    private void OnDisable()
    {
        TurnEventBus.Unsubscribe(TurnEventType.StageClear, StageClear);//TurnStart �̺�Ʈ ����
    }

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

    //�������� Ŭ���� �̺�Ʈ ó��
    public void StageClear()
    {
        //�������� Ŭ����� ĳ���� �������ͽ� �� �����ϱ�
        PlayerController player = BattleManager.Instance.onPlayer;
        if (player != null)
        {
            playerStatus = player._characterStatus;
        }

        nowProgress++;//���൵ ����
    }
}