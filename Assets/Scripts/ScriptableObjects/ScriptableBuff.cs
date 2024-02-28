using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableBuff : ScriptableObject
{
    // Start is called before the first frame update
   public float Duration; //duration of buff in seconds
    //duration is increasing each time buff is applied
   public bool IsDurationStacked; 
    //effect value is increasing every time buff is applied
   public bool IsEffectStacked;
   
   public abstract TimedBuff InitializeBuff(GameObject obj);
}
