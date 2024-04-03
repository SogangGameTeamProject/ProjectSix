using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{


    //�÷��̾� �� ���� �� �� ������ ��ȯ �ϴ� �̺�Ʈ�� �߻� ��Ű�� �Լ�
    public void PlayerTurnEnd()
    {
        TurnEventBus.Publish(TurnEventType.EnemyTurn);
    }

    //
    private void OnGUI()
    {
        //����
        if(GUI.Button(new Rect(20, 40, 200, 30), "AppearsState"))
        {
            AppearsState();
        }

        //�̵� ����
        if (GUI.Button(new Rect(20, 80, 200, 30), "MoveLeft"))
        {
            MoveState(CharacterDirection.Left);
        }

        //�̵� ������
        if (GUI.Button(new Rect(20, 100, 200, 30), "MoveRight"))
        {
            MoveState(CharacterDirection.Right);
        }

        if (GUI.Button(new Rect(20, 140, 200, 30), "TurnaboutState"))
        {
            TurnaboutState();
        }

        if (GUI.Button(new Rect(20, 180, 200, 30), "HitState"))
        {
            HitState();
        }

        if (GUI.Button(new Rect(20, 220, 200, 30), "DieState"))
        {
            DieState();
        }
    }
}