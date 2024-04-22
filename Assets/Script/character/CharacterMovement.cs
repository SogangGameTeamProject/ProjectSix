using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRbody = null;//ĳ���� ������ �ٵ�
    private Collider2D characterCol2D = null;//ĳ���� �ݶ��̴�
    private BattleManager _battleManager = null;//��Ʋ �޴���

    public Coroutine moveCoroutine = null;//�̵� ���� �ڷ�ƾ �۵� �� ������ ����

    public LayerMask platformLayer;//�÷��� ���̾� ��

    private void Start()
    {
        characterRbody = GetComponent<Rigidbody2D>();//������ �ٵ� �� �ʱ�ȭ
        characterCol2D = GetComponent<Collider2D>();//�ݶ��̴� �� �ʱ�ȭ
        _battleManager = BattleManager.Instance;//���� �޴��� �� �ʱ�ȭ
    }

    //Ÿ�� �� �̵� ���� �ڷ�ƾ moveDirX: �̵�����, movePower: �̵��ӵ�, moveSpaceDistance:�̵��Ÿ�(ĭ)
    public IEnumerator StraightLineMovement(int moveDirX, float movePower, int moveSpaceDistance)
    {
        int onPlatformIndex = -1;//�÷��� �ε��� ���� ����� ����
        //moveSaceNum��ŭ ĭ �̵��� �����ϴ� �ݺ���
        for (int i = 0; i < moveSpaceDistance; i++)
        {
            onPlatformIndex = _battleManager.GetPlatformIndexForObj(gameObject);//�ڽ��� ���� �÷��� �ε��� ��
            int moveIndex = onPlatformIndex + moveDirX;//�̵� �� �÷����� �ε��� ��
            
            Vector3 targetPlatformPos = _battleManager.GetStandingPos(moveIndex);//�̵��� �÷��� ������Ʈ ��
            
            GameObject targetPlatformOnObj = _battleManager.GetOnPlatformObj(moveIndex);//�÷��� ������ �ʱ�ȭ

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