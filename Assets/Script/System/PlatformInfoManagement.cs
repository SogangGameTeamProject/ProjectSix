using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInfoManagement : MonoBehaviour
{
    public int indexNum = 0;//�ش� �÷����� �÷��� ����Ʈ�� ���° ��ġ�� �ִ��� ��Ÿ���� �ε��� ��ȣ
    public LayerMask characterLayer;//�÷������� �ö�� �� �ִ� ĳ������ ���̾� ��
    private GameObject onPlatformCharacter = null;//�ش� �÷����� �ִ� ĳ���� obj
    public Transform standingObj = null;//�÷������� �� ��ġ

    //onPlatformCharacter ������Ƽ
    public GameObject OnPlatformCharacter
    {
        get
        {
            return onPlatformCharacter;
        }
    }

    //standingObj�� ��ġ�� ������Ƽ
    public Vector2 StandingPos
    {
        get
        {
            return standingObj.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ĳ���Ͱ� �÷����� ���ö� ó��
        if (((1 << collision.gameObject.layer) & characterLayer) != 0 ){
            onPlatformCharacter.transform.SetParent(transform);//onPlatformCharacter�� �ش� �÷����� �ڽ����� �ͼ�
            onPlatformCharacter = collision.gameObject;//onPlatformCharacter�� ���� ĳ���� obj�� ����
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //ĳ���Ͱ� �÷����� ������ ó��
        if (((1 << collision.gameObject.layer) & characterLayer) != 0)
        {
            onPlatformCharacter = null;//onPlatformCharacter �� null�� �ʱ�ȭ
        }
    }
}