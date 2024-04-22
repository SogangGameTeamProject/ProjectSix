using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private GameManager _gameManager;//���� �޴���
    private BattleManager _battleManager;//��Ʋ �޴���
    private PlayerController _playerController;//�÷��̾� ��Ʈ�ѷ�

    //�Է� Ű ��
    [Header("Input Key Seting")]
    public KeyCode leftMoveKey;
    public KeyCode rightMoveKey;
    public KeyCode turnAboutKey;

    private void Start()
    {
        _gameManager = GameManager.Instance;//���� �޴��� ��������
        _battleManager = BattleManager.Instance;//��Ʋ �Ŵ��� ��������
        _playerController = this.GetComponent<PlayerController>();//�÷��̾� ��Ʈ�ѷ� �ʱ�ȭ
    }

    private void Update()
    {
        //�÷��̾� �� üũ �� �ൿ ���� ���� üũ
        if (_playerController.isTurnReady && _playerController.isAvailabilityOfAction)
        {
            
            //�̵� Ű �Է� ó��(�̵� Ű �ϳ��� �̵� + �Ϲ� ���� ó��)
            if (Input.GetKeyDown(leftMoveKey) || Input.GetKeyDown(rightMoveKey))
            {
                CharacterDirection moveDir = Input.GetKeyDown(leftMoveKey) ? CharacterDirection.Left : CharacterDirection.Right;//ĳ���� �̵� ����
                int onIndex = _battleManager.GetPlatformIndexForObj(this.gameObject);
                int nexIndex = onIndex + ((int)moveDir);//�̵��� �÷��� index
                //�̵� + ���� ���� üũ
                if (nexIndex >= 0 && nexIndex < _battleManager.PlatformList.Length)
                {
                    //�̵����� ���� üũ
                    if (_battleManager.GetOnPlatformObj(nexIndex) == null)
                    {
                        _playerController.isAvailabilityOfAction = false;
                        _playerController.TransitionState(StateEnum.Move, moveDir);
                    }
                        
                    //�ƴ� �� ���� ����
                    else if(moveDir == _playerController.direction)
                    {
                        _playerController.isAvailabilityOfAction = false;
                        _playerController.TransitionState(StateEnum.NormalAttack, 1.0f);
                    }
                        
                }
            }
            //�� ��ȯ Ű
            if (Input.GetKeyDown(turnAboutKey))
            {
                _playerController.isAvailabilityOfAction = false;
                _playerController.TransitionState(StateEnum.Turnabout);
            }
        }
    }
}
