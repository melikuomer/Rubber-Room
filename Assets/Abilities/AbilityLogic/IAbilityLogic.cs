    using UnityEngine;
    using UnityEditor;
   using System.Linq;
using System;

using System.Reflection;
using UnityEditor.PackageManager;
using System.Collections;

namespace Abilities  {


    
    public interface IAbilityLogic {
    /*
    This interface is designed to do middleware logic between AbilityTrigger and AbilityEffects
    It should handle the projectile movement etc. 

    */        

        public IEnumerator DoLogic(Transform transform, float lerpDuration, Transform startMarker, Transform endMarker);

        
    }


    
    
}