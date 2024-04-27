using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    protected GameManager gameManager = null;//���� �Ŵ����� ������ ������ ����
    protected BattleManager _battleManager = null;//��Ʋ �Ŵ��� ������ ����

    [Header("Player Status")]
    public CharacterStatus _characterStatus;
    public int maxHp;//�ִ�ü��
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
    public int offensePower;//���ݷ�
    
    public CharacterDirection direction { get; set; }//ĳ���Ͱ� �ٶ󺸴� ����
    public bool isTurnReady = false;//�� �غ� ����
    public bool isAvailabilityOfAction = true;//�ൿ ���� ����
    public bool isStatusProcessing = false;//���� ó�� ����
    public bool isCharging = false;//���� �غ� ����
    //���� ����
    [System.Serializable]
    public class StateInfo
    {
        public StateBase state;//����
        public StateEnum stateEnum;//���� ������
    }
    [SerializeField]
    public List<StateInfo> _stateList;//ĳ������ �� ���µ��� ���� ����Ʈ
    protected CharacterStateContext characterStateContext;//ĳ���� ���� ���ؽ�Ʈ
    protected virtual void Start()
    {
        gameManager = GameManager.Instance;//���� �Ŵ��� �� �ʱ�ȭ
        _battleManager = BattleManager.Instance;//��Ʋ �Ŵ��� �� �ʱ�ȭ
        characterStateContext = new CharacterStateContext(this);//�������ý�Ʈ �ʱ�ȭ
        
        direction = this.transform.localScale.x > 0 ? CharacterDirection.Right : CharacterDirection.Left;//ĳ���� ���� �� �ʱ�ȭ

        //ĳ���� �ɷ�ġ _characterStatus�� �������� �ʱ�ȭ
        maxHp = _characterStatus.maxHp;//�ִ�ü��
        nowHp = _characterStatus.nowHp;//����ü��
        offensePower = _characterStatus.offensePower;//���ݷ�
    }
    //ĳ���� �� ���� ó��
    public virtual void TurnStart()
    {
        isTurnReady = true;
    }

    //ĳ���� �� ���� ó��
    public virtual void TurnEnd()
    {
        isTurnReady = false;//�� ���� ó��
    }
    
    //���¸����� ���� ȣ���ϴ� �Լ�
    public void TransitionState(StateEnum stateEnum, params object[] datas)
    {
        Debug.Log(stateEnum + ", " + direction);
        CharacterState state = _stateList.Find(state => state.stateEnum.Equals(stateEnum)).state;//���� ������ ���� ��������
        
        characterStateContext.Transition((CharacterState)state, datas);
    }
}
