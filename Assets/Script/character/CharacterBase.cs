using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour, CharacterStateInterface
{
    GameManager gameManager = null;//���� �Ŵ����� ������ ������ ����
    State gameState;//���� ���� ���¸� ���� �ϴ� ����

    private void Start()
    {
        gameManager = GameManager.Instance;//���� �Ŵ��� �� �ʱ�ȭ
    }
}
