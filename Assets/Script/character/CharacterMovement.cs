using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRbody = null;//ĳ���� ������ �ٵ�
    private Collider2D characterCol2D = null;//ĳ���� �ݶ��̴�
    private GameManager getGameManager = null;//���� �޴���

    Coroutine moveCoroutine = null;//�̵� ���� �ڷ�ƾ �۵� �� ������ ����

    private void Start()
    {
        characterRbody = GetComponent<Rigidbody2D>();//������ �ٵ� �� �ʱ�ȭ
        characterCol2D = GetComponent<Collider2D>();//�ݶ��̴� �� �ʱ�ȭ
        getGameManager = GameManager.Instance;//���� �޴��� �� �ʱ�ȭ
    }

    private void Update()
    {
        //�̵� �׽�Ʈ�� ���� Ű�Է�
        float getKeyH = Input.GetAxis("Horizontal");//Ű�Է� �ޱ�

        if (getKeyH != 0)
            Debug.Log("�̵��� ����: " + moveCoroutine != null);

        if (getKeyH != 0 && moveCoroutine == null)
        {
            Debug.Log("�̵� Ű �Է�: " + getKeyH);
            moveCoroutine = StartCoroutine(StraightLineMovement(getKeyH, 60, 1));
        }
    }

    //�̵� ���� �ڷ�ƾ
    public IEnumerator StraightLineMovement(float moveDirX, float movePower, int moveSpaceDistance)
    {
        PlatformInfoManagement parentPlatformInfo = null;//�÷��� �������� ������ ����
        int platformIndex = -1;//�÷��� �ε��� ���� ����� ����
        //moveSaceNum��ŭ ĭ �̵��� �����ϴ� �ݺ���
        for (int i = 0; i < moveSpaceDistance; i++)
        {
            parentPlatformInfo = transform.parent.GetComponent<PlatformInfoManagement>();//�ڽ��� ���ִ� �÷����� ���� ������Ʈ�� ��������
            platformIndex = parentPlatformInfo.indexNum;//�ڽ��� ���� �÷��� �ε��� ��
            int moveIndex = platformIndex + (moveDirX > 0 ? 1 : -1);//�̵� �� �÷����� �ε��� ��
            Debug.Log("�ε��� ��: "+platformIndex + ", " + moveIndex);

            Vector3 targetPlatformPos = getGameManager.GetStandingPos(moveIndex);//�̵��� �÷��� ������Ʈ ��
            GameObject targetPlatformOnObj = getGameManager.GetOnPlatformObj(moveIndex);//�÷��� ������ �ʱ�ȭ

            //�̵� ���� ���� üũ
            if (targetPlatformPos != Vector3.zero ? targetPlatformOnObj == null : false)
            {
                Debug.Log("����ó�� ����: " + transform.position.x + ", " + targetPlatformPos.x);
                characterCol2D.enabled = false;//�̵� �� �ݶ��̴� ��Ȱ��ȭ

                //�������� �̵������� �� �ݺ���
                while (moveDirX > 0 ? transform.position.x < targetPlatformPos.x : transform.position.x > targetPlatformPos.x)
                {
                    characterRbody.velocity = new Vector2(moveDirX * movePower, 0);//�̵� ����
                    Debug.Log(characterRbody.velocity);
                    yield return null;
                }
                characterRbody.velocity = Vector3.zero;//�̵� ����� �̵� �� zero�� �ʱ�ȭ
                characterCol2D.enabled = false;//�̵� ���� �� �ݶ��̴� Ȱ��ȭ
            }
            //�̵� �Ұ� �� �ݺ��� ���� ����
            else
                break;
        }
        
        moveCoroutine = null;//�ڷ�ƾ ����
        Debug.Log("�ڷ�ƾ ����: " + (moveCoroutine == null));
        yield return null;
    }
}