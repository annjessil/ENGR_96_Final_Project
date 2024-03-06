using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuff", menuName = "Buff System/Buff")]
public class Buff : ScriptableObject
{
    public string buffName;
    public float duration;
    public int speedBonus;
    public bool good; //if false subtract speedbonus from player speed
    // Add other properties as needed


}
