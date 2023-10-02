// AbilityConfig.cs
using System;
using UnityEngine;
using UnityEditor;


using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

using System.Collections.Generic;


namespace Abilities
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Abilities/Create New Ability")]
    public class AbilityConfig : ScriptableObject
    {



         


        public InterfaceContainer<IAbilityTrigger> AbilityTrigger;
        
  
        public InterfaceContainerArray<IAbilityEffect> effects;

        
        public AbilityParticleConfig particleConfig;
       

        
        public TargetingType targetingType;
        public Vector3 defaultPosition;
        
        
        public ICollisionDetection collisionDetection;
        public IAbilityAnimation abilityAnimation;
        
        
        
 

        
        [Header("Child Abilities")]
        //TODO CHECK IF THE CHILD CONFIG IS SAME AS THIS CONFIG
        public AbilityConfig[] childAbilities; // Configure child abilities in the Inspector



        static private IEnumerable<Type> GetAssembliesOfType (Assembly assembly, Type selectedType){
           
        return  assembly.GetTypes().Where(type => selectedType.IsAssignableFrom(type) && type.IsClass );
    }
    }


}
