using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheepBase : MonoBehaviour
{
    protected CharacterController _characterController = null;//ĳ���� ��Ʈ�ѷ�

    private void Start()
    {
        _characterController = transform.parent.parent.GetComponent<CharacterController>();//ĳ���� ��Ʈ�ѷ�
    }

    //Ĩ��� ������ �� �κ�
    public abstract void ActivateChipEffect();
}