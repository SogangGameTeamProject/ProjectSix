using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ĳ���� ���� �� appears: ����, normal: �Ϲݻ���, invicible: ����, attack: ���� ��, death: ��������
public enum CharacterState
{
    appears, normal, invincible, attack, death
}

public class CharacterBase : MonoBehaviour, CharacterStateInterface
{
    GameManager gameManager = null;//���� �Ŵ����� ������ ������ ����
    GameState gameState;//���� ���� ���¸� ���� �ϴ� ����

    //ĳ���Ͱ� �ൿ�� �۾��� ���� ����
    [System.Serializable]
    public class ActionInfo
    {
        public string actionName;//�۾���
        public ActionBase action;//�ൿ ������Ʈ
        //������
        public ActionInfo(string actionName, ActionBase action)
        {
            this.actionName = actionName;
            this.action = action;
        }
    }
    public List<ActionInfo> actionList = new List<ActionInfo>();//�ൿ ����Ʈ ����

    public CharacterState state;//ĳ���� ���� ��
    public int maxHp = 100;//�ִ�ü��
    private int nowHp = 100;//����ü��
    public int maxShild = 20;//�ִ� ��ȣ�� ��
    private int nowShild = 20;//���� ��ȣ�� ��

    private void Start()
    {
        gameManager = GameManager.Instance;//���� �Ŵ��� �� �ʱ�ȭ
    }

    //ĳ���� �ǰ� ó��
    public void Hit()
    {

    }
}
