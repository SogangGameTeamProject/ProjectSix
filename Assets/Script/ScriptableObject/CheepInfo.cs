using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CheepInfo", menuName = "ScriptableObjects/CheepInfo", order = 1)]
public class CheepInfo : ScriptableObject
{
    public int CheepID;//Ĩ ID
    public string CheepName;//Ĩ �̸�
    public string CheepEffectExplanationTxt;//Ĩȿ�� ���� �ؽ�Ʈ
    public Sprite CheepIcon;//Ĩ ������
    public CheepType cheepType;//������ Ĩ Ÿ��
}
