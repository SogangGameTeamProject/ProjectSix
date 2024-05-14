using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSystem : MonoBehaviour
{
    public GameObject loseWindow;//�¸� ǥ��â

    //Ȱ��ȭ�� �̺�Ʈ ����
    private void OnEnable()
    {
        TurnEventBus.Subscribe(TurnEventType.Lose, Lose);//TurnStart �̺�Ʈ ����
    }

    //��Ȱ��ȭ�� �̺�Ʈ ����
    private void OnDisable()
    {
        TurnEventBus.Unsubscribe(TurnEventType.Lose, Lose);//TurnStart �̺�Ʈ ����
    }

    public void Lose()
    {
        loseWindow.SetActive(true);
    }
}
