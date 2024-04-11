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
            nowHp = value;
            //�ִ�ü�º��� �������ų� 0���� �۾����� ����
            if (nowHp > maxHp) nowHp = maxHp;
            else if(nowHp < 0) nowHp = 0;

        }
    }
    public int offensePower = 50;//���ݷ�
    
    public CharacterDirection direction { get; set; }//ĳ���Ͱ� �ٶ󺸴� ����
    public bool isTurnReady = false;//�� �غ� ����

    //���� ����
    [System.Serializable]
    public class StateInfo
    {
        public StateBase state;//����
        public string stateName;//���� ��
    }
    [SerializeField]
    public List<StateInfo> _stateList;//ĳ������ �� ���µ��� ���� ����Ʈ
    protected CharacterStateContext characterStateContext;//ĳ���� ���� ���ؽ�Ʈ

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;//���� �Ŵ��� �� �ʱ�ȭ

        characterStateContext = new CharacterStateContext(this);//�������ý�Ʈ �ʱ�ȭ
        nowHp = maxHp;//���� ü�� �ʱ�ȭ
        direction = this.transform.localScale.x > 0 ? CharacterDirection.Right : CharacterDirection.Left;//ĳ���� ���� �� �ʱ�ȭ
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
    

    //���¸����� ���� ȣ���ϴ� �Լ�
    public void TransitionState(string stateName, params object[] datas)
    {
        CharacterState state = _stateList.Find(state => state.stateName.Equals(stateName)).state;//���� ������ ���� ��������

        characterStateContext.Transition((CharacterState)state, datas);
    }
}
