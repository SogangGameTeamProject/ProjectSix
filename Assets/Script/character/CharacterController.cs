using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    GameManager gameManager = null;//���� �Ŵ����� ������ ������ ����
    GameState gameState;//���� ���� ���¸� ���� �ϴ� ����

    public int maxHp = 100;//�ִ�ü��
    public int nowHp { get; set; }//����ü��

    public int maxShild = 20;//�ִ� ��ȣ�� ��
    public int nowShild { get; set; }//���� ��ȣ�� ��

    public CharacterDirection direction { get; set; }//ĳ���Ͱ� �ٶ󺸴� ����

    //ĳ���� �� ���µ��� ���� ����(appearsState: ����, forwardState: ����, turnState: ���� ��ȯ, hitState: �ǰ�, dieState: ���� ó��
    private CharacterState appearsState, forwardState, turnState, hitState, dieState;
    private CharacterStateContext characterStateContext;//ĳ���� ���� ���ؽ�Ʈ

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;//���� �Ŵ��� �� �ʱ�ȭ

        characterStateContext = new CharacterStateContext(this);

        //�� ���µ��� ����� ������ ������Ʈ�� �߰��ϴ� �κ�
        appearsState = gameObject.GetComponent<CharacterAppearsState>();
        forwardState = gameObject.GetComponent<CharacterForwardState>();
        turnState = gameObject.GetComponent<CharacterTurnState>();
        hitState = gameObject.GetComponent<CharacterHitState>();
        dieState = gameObject.GetComponent<CharacterDieState>();
    }

    protected virtual void Update()
    {
        gameState = gameManager.state;//���� ���°� ����
    }

    //�� ���º��� ȣ���ϴ� �Լ�
    //���� ���� ȣ�� �Լ�
    public void AppearsState()
    {
        characterStateContext.Transition(appearsState);
    }

    //���� ���� ȣ�� �Լ�
    public void ForwardState()
    {
        characterStateContext.Transition(forwardState);
    }

    //���� ��ȯ ���� ȣ�� �Լ�
    public void TurnState()
    {
        characterStateContext.Transition(turnState);
    }

    //�ǰ� ���� ȣ�� �Լ�
    public void HitState()
    {
        characterStateContext.Transition(hitState);
    }

    //���� ���� ȣ�� �Լ�
    public void DieState()
    {
        characterStateContext.Transition(dieState);
    }
}
