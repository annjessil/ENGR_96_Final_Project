using Components;
using ScriptableObjects;
using UnityEngine;


public class TimedSpeedBuff : TimedBuff
{
   private readonly MovementComponent _movementComponent;

   public TimedSpeedBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj){
    _movementComponent = obj.GetComponent<MovementComponent>();
   }

   protected override void ApplyEffect(){
    ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff) Buff;
    _movementComponent.MovementSpeed += speedBuff.SpeedIncrease;
   }

   public override void End(){
    ScriptableSpeedBuff speedBuff = (ScriptableSpeedBuff) Buff;
    _movementComponent.MovementSpeed -= speedBuff.SpeedIncrease * EffectStacks;
    EffectStacks = 0;

   }

    protected override void ApplyTick(){
        //do nothing
    }

}
