using UnityEngine;
using System;
using System.Collections;


namespace Abilities
{
    
    [Serializable]
    public abstract class AbilityTrigger_Base : MonoBehaviour, IAbilityTrigger {
        

        public abstract IEnumerator Trigger(Action action);
        
    }

}