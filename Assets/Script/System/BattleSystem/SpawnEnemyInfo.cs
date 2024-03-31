using System.Collections;
using UnityEngine;

//���� ���� ������ ������ ���� Ŭ����
[System.Serializable]
public class SpawnEnemyInfo
{
    public GameObject enemyPre;//��ȯ�� ���� ������
    public int spawnIndex;//��ȯ�� Ÿ�� �ε��� ��

    //������
    public SpawnEnemyInfo(GameObject enemyPre, int spawnIndex)
    {
        this.enemyPre = enemyPre;
        this.spawnIndex = spawnIndex;
    }
}
