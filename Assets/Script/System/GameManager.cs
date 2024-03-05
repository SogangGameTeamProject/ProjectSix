using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;//���� �޴��� �ν��Ͻ�ȭ�� ���� ���� ��
    public enum State
    {
        start, playerTurn, eneyTurn, lose, win, rest
    }

    public State state;//���� ���� ���� ����Ǵ� ����


    public GameObject[] PlatformList;//�÷��� ����Ʈ

    private void Awake()
    {
        state = State.start;//���� ���� �� start���°����� �ʱ�ȭ

        //�ν��Ͻ� �ʱ�ȭ
        if(instance == null)
            instance = this;
    }



    //���� �Ŵ��� �ν��Ͻ��� ������ �� �ִ� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
}