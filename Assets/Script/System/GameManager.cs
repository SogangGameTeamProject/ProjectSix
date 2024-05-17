using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Rendering.CameraUI;

public class GameManager : Singleton<GameManager>
{
    public KeyCode reseKey;

    public List<int> stageLevel;//���� ���൵ �� �������� ���̵� ����
    public int nowProgress = 0;//���� ���൵
    public List<ItemData> itemDB;//������ DB
    public List<PlayerHaveItemData> playerItemDB;//�÷��̾� ���� ������ DB
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

    //������ ������ ���̽� ���� �Լ���
    //�� ���� �������� List<ItemData> �������� ����ϴ� �Լ� (number: ����� ������ ��)
    public List<PlayerHaveItemData> RandomOutputOfUnownedItems(int number)
    {
        List<PlayerHaveItemData> outputList = new List<PlayerHaveItemData>();//������ �̺��� ������ ����Ʈ
        List<PlayerHaveItemData> unownedItems = new List<PlayerHaveItemData>();//�̺��� ������ ����Ʈ
        //�̺��� �������� outputList�� �߰��ϴ� �ݺ���
        foreach (ItemData data in itemDB)
        {
            PlayerHaveItemData findData = playerItemDB.Find(item => item.itemId.Equals(data.itemId));//�÷��̾� �κ��丮�� ���� �������� ��������
            //�߰��� ������ ���� �� �� �ʱ�ȭ
            PlayerHaveItemData addData = new PlayerHaveItemData();
            addData.itemId = data.itemId;
            addData.itemLevel = 0;
            //������ ������ level�� �ִ����� üũ, �ִ��� ��� ��Ƽ��
            if (findData != null)
            {
                if (findData.itemLevel < data.itemInfo.Count - 1)
                    continue;
                addData.itemLevel = findData.itemLevel + 1;//���� ���� ���� �������� ��� ���� ������ ���������� ����
            }

            //������ ������ ���� �� �� �ʱ�ȭ


            //�̺��� �� ��� outputList�� �ش� ������ ����
            unownedItems.Add(addData);
        }

        //��� ���� ��ŭ outputList����Ʈ�� �������� ��� �߰�
        

        return outputList;
    }

    //���� �������� ��� List<itemInfo> �������� ����ϴ� �Լ�
    public List<ItemInfo> OutputOfHaveItems()
    {
        List<ItemInfo> outputList = new List<ItemInfo>();
        
        //playerItemDB�� ������ ���� itemDB�� ������ ������ ������ outputList�� ü��� �ݺ���
        for (int i = 0; i < playerItemDB.Count; i++)
        {
            //�÷��̾� ������ DB�� ������ ��� ������ ���ؼ� ������ ���� ������ outputList�� �߰�
            ItemData getItem = itemDB.Find(item => item.itemId.Equals(playerItemDB[i].itemId));
            outputList.Add(getItem.itemInfo[playerItemDB[i].itemLevel]);
        }
        
        return outputList;
    }
}