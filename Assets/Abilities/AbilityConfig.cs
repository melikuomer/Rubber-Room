// AbilityConfig.cs
using System;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Abilities/Create New Ability")]
    public class AbilityConfig : ScriptableObject
    {
        public TargetingType targetingType;
        public Vector3 defaultPosition;
        
        public ICollisionDetection collisionDetection;
        public IAbilityAnimation abilityAnimation;
        
        
        [Header("Effects"), SerializeReference]
        public AbilityEffects[] abilityEffects;


        [Header("Child Abilities")]
        public AbilityConfig[] childAbilities; // Configure child abilities in the Inspector
    }



}
