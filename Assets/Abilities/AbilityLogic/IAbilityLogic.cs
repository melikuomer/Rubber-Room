    using UnityEngine;
    using UnityEditor;
   using System.Linq;
using System;

using System.Reflection;
using UnityEditor.PackageManager;

namespace Abilities  {


    
    public interface IAbilityLogic {
    /*
    This interface is designed to do middleware logic between AbilityTrigger and AbilityEffects
    It should handle the projectile movement etc. 

    */        

        public void DoLogic();

        
    }


    
    
}