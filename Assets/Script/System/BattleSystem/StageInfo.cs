using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� ����
[System.Serializable]
public class StageInfo
{
    public List<WaveInfo> waveList;
    public int bestTurn;
    public int worstTurn;
    public int stageLevel;
}