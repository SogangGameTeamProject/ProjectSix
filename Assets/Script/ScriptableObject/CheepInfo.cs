using UnityEngine;
[CreateAssetMenu(fileName = "CheepInfo", menuName = "ScriptableObjects/CheepInfo", order = 1)]
public class CheepInfo : ScriptableObject
{
    public int CheepID;//Ĩ ID
    public string CheepName;//Ĩ �̸�
    public StateEnum ApplyStateType;//������ ���� Ÿ��
    public StateBase ApplyState;//������ ����
}
