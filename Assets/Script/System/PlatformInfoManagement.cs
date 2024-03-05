using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInfoManagement : MonoBehaviour
{
    public LayerMask characterLayer;//�÷������� �ö�� �� �ִ� ĳ������ ���̾� ��
    private GameObject onPlatformCharacter = null;//�ش� �÷����� �ִ� ĳ���� obj

    //onPlatformCharacter���� �����ϴ� ������Ƽ
    public GameObject OnPlatformCharacter
    {
        get
        {
            return onPlatformCharacter;
        }
        set
        {
            onPlatformCharacter = value;
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