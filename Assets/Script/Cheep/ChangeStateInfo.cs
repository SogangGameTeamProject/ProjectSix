using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChangeStateInfo
{
    public StateEnum stateType;//변경할 상태 타입
    public StateBase chageState;//변경할 상태
}
