using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    private GameManager gameManager = null;//���� �Ŵ����� ������ ������ ����

    [Header("Player Status")]
    public int maxHp = 100;//�ִ�ü��
    private int nowHp;//���� ü��
    //����ü�� ������Ƽ
    public int NowHp 
    {
        get
        {
            return nowHp;
        }
        set
        {
            nowHp += value;
            //�ִ�ü�º��� �������ų� 0���� �۾����� ����
            if (nowHp > maxHp) nowHp = maxHp;
            else if(nowHp < 0) nowHp = 0;

        }
    }
    public int offensePower = 50;//���ݷ�

    public CharacterDirection direction { get; set; }//ĳ���Ͱ� �ٶ󺸴� ����
    public bool isTurnReady = false;//�� �غ� ����

    //ĳ���� �� ���µ��� ���� ����(appearsState: ����, forwardState: ����, turnState: ���� ��ȯ, hitState: �ǰ�, dieState: ���� ó��, attackState: ���� ó��
    private CharacterState appearsState, moveState, turnaboutState, hitState, dieState, normalAttackState;
    protected CharacterStateContext characterStateContext;//ĳ���� ���� ���ؽ�Ʈ

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;//���� �Ŵ��� �� �ʱ�ȭ

        characterStateContext = new CharacterStateContext(this);//�������ý�Ʈ �ʱ�ȭ
        nowHp = maxHp;//���� ü�� �ʱ�ȭ
        direction = this.transform.localScale.x > 0 ? CharacterDirection.Left : CharacterDirection.Right;//ĳ���� ���� �� �ʱ�ȭ

        //�� ���µ��� ����� ������ ������Ʈ�� �߰��ϴ� �κ�
        appearsState = gameObject.AddComponent<AppearsState>();
        moveState = gameObject.AddComponent<MoveState>();
        turnaboutState = gameObject.AddComponent<TurnaboutState>();
        hitState = gameObject.AddComponent<HitState>();
        dieState = gameObject.AddComponent<DieState>();
        normalAttackState = gameObject.AddComponent<NormalAttackState>();
    }
    //ĳ���� �� ���� ó��
    protected virtual void TurnStart()
    {
        isTurnReady = true;
    }

    //ĳ���� �� ���� ó��
    public virtual void TurnEnd()
    {
        isTurnReady = false;//�� ���� ó��
    }
    

    //�� ���º��� ȣ���ϴ� �Լ�
    //���� ���� ȣ�� �Լ�
    public void AppearsState()
    {
        characterStateContext.Transition(appearsState);
    }

    //���� ���� ȣ�� �Լ�
    public void MoveState(CharacterDirection direction)
    {
        this.GetComponent<MoveState>().moveDirection = direction;//�̵� ���Ⱚ ����
        characterStateContext.Transition(moveState);
    }

    //���� ��ȯ ���� ȣ�� �Լ�
    public void TurnaboutState()
    {
        characterStateContext.Transition(turnaboutState );
    }

    //�ǰ� ���� ȣ�� �Լ�
    public void HitState(int damage)
    {
        Debug.Log("isDamage" + damage);
        this.GetComponent<HitState>().hitDamage = damage;//�������� ����
        Debug.Log("HitDamage" + this.GetComponent<HitState>().hitDamage);
        characterStateContext.Transition(hitState);
    }

    //���� ���� ȣ�� �Լ�
    public void DieState()
    {
        characterStateContext.Transition(dieState);
    }


    //���� ���� ȣ�� �Լ�
    public void NormalAttackState()
    {
        characterStateContext.Transition(normalAttackState);
    }

    //���� ȣ�� �Լ� stateName: ȣ���� ���� �Լ� ��
    public void OnNameToState(string stateName)
    {
        // stateName�� ��ġ�ϴ� �Լ��� ã�� ����
        System.Reflection.MethodInfo method = GetType().GetMethod(stateName);
        if (method != null)
        {
            method.Invoke(this, null);
        }
    }
}
