using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState state;//���� ���� ���� ����Ǵ� ����


    public GameObject[] PlatformList;//�÷��� ����Ʈ

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
    public Vector3 GetStandingPos(int indexNum)
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