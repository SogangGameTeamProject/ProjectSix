using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRbody = null;//ĳ���� ������ �ٵ�
    private Collider2D characterCol2D = null;//ĳ���� �ݶ��̴�
    private GameManager getGameManager = null;//���� �޴���

    Coroutine moveCoroutine = null;//�̵� ���� �ڷ�ƾ �۵� �� ������ ����

    public LayerMask platformLayer;//�÷��� ���̾� ��

    private void Start()
    {
        characterRbody = GetComponent<Rigidbody2D>();//������ �ٵ� �� �ʱ�ȭ
        characterCol2D = GetComponent<Collider2D>();//�ݶ��̴� �� �ʱ�ȭ
        getGameManager = GameManager.Instance;//���� �޴��� �� �ʱ�ȭ
    }

    //Ÿ�� �� �̵� ���� �ڷ�ƾ moveDirX: �̵�����, movePower: �̵��ӵ�, moveSpaceDistance:�̵��Ÿ�(ĭ)
    public IEnumerator StraightLineMovement(int moveDirX, float movePower, int moveSpaceDistance)
    {
        PlatformInfoManagement onPlatformInfo = null;//�÷��� �������� ������ ����
        int onPlatformIndex = -1;//�÷��� �ε��� ���� ����� ����
        //moveSaceNum��ŭ ĭ �̵��� �����ϴ� �ݺ���
        for (int i = 0; i < moveSpaceDistance; i++)
        {
            RaycastHit2D onPlatform = Physics2D.Raycast(transform.position, Vector2.down, 1, platformLayer);//�����ɽ�Ʈ�� ���� �÷��� ���� ��������
            onPlatformInfo = onPlatform.collider.gameObject.GetComponent<PlatformInfoManagement>();//�ڽ��� ���ִ� �÷����� ���� ������Ʈ�� ��������
            onPlatformIndex = onPlatformInfo.indexNum;//�ڽ��� ���� �÷��� �ε��� ��
            int moveIndex = onPlatformIndex + moveDirX;//�̵� �� �÷����� �ε��� ��
            
            Vector3 targetPlatformPos = getGameManager.GetStandingPos(moveIndex);//�̵��� �÷��� ������Ʈ ��
            
            GameObject targetPlatformOnObj = getGameManager.GetOnPlatformObj(moveIndex);//�÷��� ������ �ʱ�ȭ

            //�̵� ���� ���� üũ
            if (targetPlatformPos != Vector3.zero ? targetPlatformOnObj == null : false)
            {
                //�������� �̵������� �� �ݺ���
                while (moveDirX > 0 ? transform.position.x < targetPlatformPos.x : transform.position.x > targetPlatformPos.x)
                {
                    characterRbody.velocity = new Vector2(moveDirX * movePower, 0);//�̵� ����
                    yield return null;
                }
                characterRbody.velocity = Vector3.zero;//�̵� ����� �̵� �� zero�� �ʱ�ȭ
                transform.position = new Vector3(targetPlatformPos.x, transform.position.y, transform.position.z);// �̵� �� ��ġ�� ����
            }
            //�̵� �Ұ� �� �ݺ��� ���� ����
            else
                break; 
        }
        
        moveCoroutine = null;//�ڷ�ƾ ����
    }
}