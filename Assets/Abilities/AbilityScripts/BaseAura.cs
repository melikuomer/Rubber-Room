using UnityEngine;
using System.Collections.Generic;

namespace Abilities
{
    public class BaseAura : BaseAbility {
        public BaseAura(AbilityConfig config) : base (config){
           
         }
    }
    public class DamageAura : BaseAura {
        public DamageAura(AbilityConfig config): base (config) { }
    }
}

