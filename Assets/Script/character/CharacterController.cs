using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    protected GameManager gameManager = null;//���� �Ŵ����� ������ ������ ����
    protected BattleManager _battleManager = null;//��Ʋ �Ŵ��� ������ ����

    [Header("Player Status")]
    public CharacterStatus _characterStatusOriginal;//ĳ���� �������ͽ� �������� ���°�
    public CharacterStatus _characterStatus;//ĳ���� �������ͽ�
    //����ü�� ������Ƽ
    public int NowHp 
    {
        get
        {
            return _characterStatus.nowHp;
        }
        set
        {
            if (!isInvincibility)
            {
                _characterStatus.nowHp = value;
                //�ִ�ü�º��� �������ų� 0���� �۾����� ����
                if (_characterStatus.nowHp > _characterStatus.maxHp) _characterStatus.nowHp = _characterStatus.maxHp;
                else if (_characterStatus.nowHp < 0) _characterStatus.nowHp = 0;
            }
        }
    }
    
    public CharacterDirection direction { get; set; }//ĳ���Ͱ� �ٶ󺸴� ����
    public bool isTurnReady = false;//�� �غ� ����
    public bool isAvailabilityOfAction = true;//�ൿ ���� ����
    public bool isStatusProcessing = false;//���� ó�� ����
    public bool isCharging = false;//���� �غ� ����
    public bool isInvincibility = false;//���� ����
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
    
    protected virtual void Awake()
    {
        gameManager = GameManager.Instance;//���� �Ŵ��� �� �ʱ�ȭ
        _battleManager = BattleManager.Instance;//��Ʋ �Ŵ��� �� �ʱ�ȭ
        characterStateContext = new CharacterStateContext(this);//�������ý�Ʈ �ʱ�ȭ

        //ĳ���� ���°� �ʱ�ȭ
        _characterStatus = ScriptableObject.CreateInstance<CharacterStatus>();
        _characterStatus.maxHp = _characterStatusOriginal.maxHp;
        _characterStatus.nowHp = _characterStatusOriginal.nowHp;
        _characterStatus.offensePower = _characterStatusOriginal.offensePower;
        _characterStatus.maxBattery = _characterStatusOriginal.maxBattery;
        
    }

    protected virtual void Start()
    {
        direction = this.transform.localScale.x > 0 ? CharacterDirection.Right : CharacterDirection.Left;//ĳ���� ���� �� �ʱ�ȭ
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
        CharacterState state = _stateList.Find(state => state.stateEnum.Equals(stateEnum)).state;//���� ������ ���� ��������
        characterStateContext.Transition((CharacterState)state, datas);
    }
}
