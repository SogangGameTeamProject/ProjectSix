using System.Collections;
using UnityEngine;
//ĳ���� �ǰ�
public class DoubleDamageHitState : HitState
{
    public int DamageAmplification = 2;//������ ������
    protected override IEnumerator StateFuntion(params object[] datas)
    {
        int hitDamage = (int)datas[0] * 2;
        Debug.Log("double :"+hitDamage);

        yield return base.StateFuntion(hitDamage);
    }
}

