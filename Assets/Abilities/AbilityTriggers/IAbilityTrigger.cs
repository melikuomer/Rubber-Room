//IAbilityTrigger.cs 

/*
    This Interface for how the ability is called. For some duration? Constantly? Once? etc.
*/

using System;
using System.Collections;


namespace Abilities
{
    public interface IAbilityTrigger{
        public  IEnumerator Trigger(Action action);
    }

}