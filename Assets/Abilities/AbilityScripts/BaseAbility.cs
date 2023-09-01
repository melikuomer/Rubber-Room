// BaseAbility.cs
using UnityEngine;
using System.Collections.Generic;
namespace Abilities
{
public class BaseAbility : IAbility
{
    protected List<BaseAbility> childAbilities;
    protected AbilityConfig abilityConfig;

    public BaseAbility(AbilityConfig config)
    {
        childAbilities = new List<BaseAbility>();
        abilityConfig = config;
    }

    public void AddChildAbility(BaseAbility childAbility)
    {
        childAbilities.Add(childAbility);
    }

    public TargetingType GetTargetingType()
    {
        return abilityConfig.targetingType;
    }

    public virtual void Activate(Transform targetTransform, Vector3 targetPosition)
    {
        abilityConfig.collisionDetection.CheckCollision(targetPosition);
        abilityConfig.abilityAnimation.PlayAnimation();
        
        foreach (var childAbility in childAbilities)
        {
            childAbility.Activate(targetTransform, targetPosition);
        }
    }
}
}

public enum TargetingType {
    Area,
    Other
}