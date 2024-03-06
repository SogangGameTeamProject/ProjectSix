using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    start, playerTurn, eneyTurn, lose, win, rest
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;//���� �޴��� �ν��Ͻ�ȭ�� ���� ���� ��
    

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

    //Ư�� ��ġ�� �÷����ȿ� ĳ����obj�� ���� ��ȯ �Լ�
    public GameObject GetOnPlatformObj(int indexNum)
    {
        GameObject returnObj = null;//��ȯ�� ������Ʈ ��

        //�÷��� ����Ʈ�� ��ȿ�� �ε��� ������ üũ
        if (indexNum > -1 && indexNum < PlatformList.Length)
        {
            returnObj = PlatformList[indexNum].GetComponent<PlatformInfoManagement>().OnPlatformCharacter;
        }

        return returnObj;
    }

    //Ư�� ��ġ�� �÷����ȿ�  ���� ��ȯ �Լ�
    public Vector2 GetStandingPosj(int indexNum)
    {
        Vector2 returnPos = Vector2.zero;//��ȯ�� ��ġ ��

        //�÷��� ����Ʈ�� ��ȿ�� �ε��� ������ üũ
        if (indexNum > -1 && indexNum < PlatformList.Length)
        {
            returnPos = PlatformList[indexNum].GetComponent<PlatformInfoManagement>().StandingPos;
        }

        return returnPos;
    }
}