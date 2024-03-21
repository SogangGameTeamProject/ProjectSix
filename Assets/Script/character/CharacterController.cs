using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private GameManager gameManager = null;//���� �Ŵ����� ������ ������ ����
    private GameState gameState;//���� ���� ���¸� ���� �Ŵ������� ������ ���� �ϴ� ����

    public CharacterTurnState turnState;

    public int maxHp = 100;//�ִ�ü��
    public int nowHp { get; set; }//����ü��

    public int maxShild = 20;//�ִ� ��ȣ�� ��
    public int nowShild { get; set; }//���� ��ȣ�� ��

    public CharacterDirection direction { get; set; }//ĳ���Ͱ� �ٶ󺸴� ����

    //ĳ���� �� ���µ��� ���� ����(appearsState: ����, forwardState: ����, turnState: ���� ��ȯ, hitState: �ǰ�, dieState: ���� ó��
    private CharacterState appearsState, forwardState, turnaboutState, hitState, dieState;
    private CharacterStateContext characterStateContext;//ĳ���� ���� ���ؽ�Ʈ

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;//���� �Ŵ��� �� �ʱ�ȭ

        characterStateContext = new CharacterStateContext(this);//�������ý�Ʈ �ʱ�ȭ
        nowHp = maxHp;//���� ü�� �ʱ�ȭ
        nowShild = maxShild;//���� ��ȣ�� �ʱ�ȭ

        //�� ���µ��� ����� ������ ������Ʈ�� �߰��ϴ� �κ�
        appearsState = gameObject.GetComponent<CharacterAppearsState>();
        forwardState = gameObject.GetComponent<CharacterForwardState>();
        turnaboutState = gameObject.GetComponent<CharacterTurnaboutState>();
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
    public void TurnaboutState()
    {
        characterStateContext.Transition(turnaboutState);
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
