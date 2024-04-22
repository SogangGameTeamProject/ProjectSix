using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{
    private CharacterController _characterController;//��Ʋ�Ŵ���
    public Image playerHpHUD;//�÷��̾� ü�¹� 

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();//ĳ���� �Ŵ��� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if ((_characterController))
        {
            float maxHp = _characterController.maxHp;
            float nowHp = _characterController.NowHp;
            playerHpHUD.fillAmount = (nowHp / maxHp);
        }
        
    }
}
