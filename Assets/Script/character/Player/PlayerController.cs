using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{


    //�÷��̾� �� ���� ó��
    public override void TurnEnd()
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
        if (GUI.Button(new Rect(20, 120, 200, 30), "MoveRight"))
        {
            MoveState(CharacterDirection.Right);
        }

        //�淮 ��ȯ
        if (GUI.Button(new Rect(20, 160, 200, 30), "TurnaboutState"))
        {
            TurnaboutState();
        }

        //�ǰ�
        if (GUI.Button(new Rect(20, 200, 200, 30), "HitState"))
        {
            HitState(50);
        }

        //����
        if (GUI.Button(new Rect(20, 240, 200, 30), "DieState"))
        {
            DieState();
        }

        //�� �� ���� ����
        if(GUI.Button(new Rect(20, 280, 200, 30), "Enemy TUrnEnd"))
        {
            TurnEventBus.Publish(TurnEventType.TurnEnd);
        }
    }
}