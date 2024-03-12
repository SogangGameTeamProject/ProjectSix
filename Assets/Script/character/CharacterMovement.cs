using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRbody = null;//ĳ���� ������ �ٵ�
    private GameManager getGameManager = null;//���� �޴���

    Coroutine moveCoroutine = null;//�̵� ���� �ڷ�ƾ �۵� �� ������ ����

    private void Start()
    {
        characterRbody = GetComponent<Rigidbody2D>();//������ �ٵ� �� �ʱ�ȭ
        getGameManager = GameManager.Instance;//���� �޴��� �� �ʱ�ȭ
    }

    private void Update()
    {
        //�̵� �׽�Ʈ�� ���� Ű�Է�
        float getKeyH = Input.GetAxis("Horizontal");//Ű�Է� �ޱ�

        if (getKeyH != 0 && moveCoroutine == null)
        {
            Debug.Log("�̵� Ű �Է�: " + getKeyH);
            moveCoroutine = StartCoroutine(StraightLineMovement(getKeyH, 10, 1));
        }
    }

    //�̵� ���� �ڷ�ƾ
    IEnumerator StraightLineMovement(float moveDirX, float movePower, int moveSpaceNum)
    {
        PlatformInfoManagement parentPlatformInfo = null;//�÷��� �������� ������ ����
        int platformIndex = -1;//�÷��� �ε��� ���� ����� ����
        //moveSaceNum��ŭ ĭ �̵��� �����ϴ� �ݺ���
        for (int i = 0; i < moveSpaceNum; i++)
        {
            parentPlatformInfo = transform.parent.GetComponent<PlatformInfoManagement>();//�ڽ��� ���ִ� �÷����� ���� ������Ʈ�� ��������
            platformIndex = parentPlatformInfo.indexNum;//�ڽ��� ���� �÷��� �ε��� ��
            int moveIndex = platformIndex + (moveDirX > 0 ? 1 : -1);//�̵� �� �÷����� �ε��� ��
            Debug.Log("�ε��� ��: "+platformIndex + ", " + moveIndex);

            Vector3 targetPlatformPos = getGameManager.GetStandingPosj(moveIndex);//�̵��� �÷��� ������Ʈ ��
            GameObject targetPlatformOnObj = getGameManager.GetOnPlatformObj(moveIndex);//�÷��� ������ �ʱ�ȭ

            //�̵� ���� ���� üũ
            if (targetPlatformPos != Vector3.zero ? targetPlatformOnObj == null : false)
            {
                Debug.Log("����ó�� ����: " + transform.position.x + ", " + targetPlatformPos.x);

                //�������� �̵������� �� �ݺ���
                while (transform.position.x == targetPlatformPos.x)
                {
                    Debug.Log("While�� ����");
                    characterRbody.velocity = new Vector2(moveDirX * movePower, 0);//�̵� ����
                    Debug.Log(characterRbody.velocity);
                    yield return null;
                }
            }
            //�̵� �Ұ� �� �ݺ��� ���� ����
            else
                break;
        }
        Debug.Log("�ڷ�ƾ ����");
        moveCoroutine = null;//�ڷ�ƾ ����
        yield return null;
    }
}