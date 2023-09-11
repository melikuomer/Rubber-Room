using System;
using System.Collections;


namespace Abilities
{
    public class TriggerOnce : AbilityTrigger_Base {
        public override IEnumerator Trigger(Action action) {
            
            action.Invoke   ();
            yield return null;

            
        }
    }  

}