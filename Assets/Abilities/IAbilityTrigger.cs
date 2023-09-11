using System;
using System.Collections;


namespace Abilities
{
    public interface IAbilityTrigger{
        public  IEnumerator Trigger(Action action);
    }

}