using UnityEngine;

namespace Abilities {


    class DebugAbility : BaseAbility{

        public DebugAbility(AbilityConfig config) : base (config){

        }

        public override void Activate (Target target) {
            Debug.Log("activated successfully at : " + target.position.ToString());
        }
    }
}