using UnityEngine;
using System;
using System.Collections;


namespace Abilities {
    interface IAbilityTrigger{
        IEnumerator Trigger(Action action);
    }


    class TriggerWhileActive : IAbilityTrigger {
        public IEnumerator Trigger(Action action) {
            while (true) {
                action.Invoke   ();
                yield return new WaitForSeconds(.25f);
            }
        }
    }

    public class TriggerOnce : IAbilityTrigger {
        public Enumerator enumerator
    }  

}