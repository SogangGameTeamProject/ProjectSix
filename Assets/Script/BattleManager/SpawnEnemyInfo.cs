using System.Collections;
using UnityEngine;

//���� ���� ������ ������ ���� Ŭ����
[System.Serializable]
public class SpawnEnemyInfo
{
    public GameObject enemyPre;//��ȯ�� ���� ������
    public int spawnPos;//��ȯ�� Ÿ�� ��ġ �� -1: ���� 1: ������

    //������
    public SpawnEnemyInfo(GameObject enemyPre, int spawnIndex)
    {
        this.enemyPre = enemyPre;
        this.spawnPos = spawnIndex;
    }
}
