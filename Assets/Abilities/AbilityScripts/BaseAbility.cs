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

    public virtual void Activate(Target target)
    {
        // abilityConfig.collisionDetection.CheckCollision(targetPosition);
        // abilityConfig.abilityAnimation.PlayAnimation();
        
        // foreach (var childAbility in childAbilities)
        // {
        //     childAbility.Activate(targetTransform, targetPosition);
        // }
    }
}
}

public enum TargetingType {
    Area,
    Other
}


/************************************************************
JHIN Q SU 
RANGE ICINDEMI
LOOP
TARGETI TAKIP ET
DEGDIGINDE (ABSULTE (PROXIMITY) COLLISION DETECTION)
    HASAR VER
    RANGE ICINDE TARGET VAR MI && SEKEBILIYOMU 
    VARSA LOOP


CAITLYN ULTISI

RANGE ICINDEMI 
TARGETI TAKIP ET
BIR SEYE CARPARSA (STANDARD COLLISION DETECTION)
    HASAR VER

KARTHUS E SI 
    ALAN AC
    TICK 
        ALANDAKILERE HASAR VUR (CONTINOUS COLLISION DETECTION)
        BIR SURE BEKLE
        GOTO TICK

TEEMO ULTISI
    OBJE KUR
        DEBUFF AT (DOT)


VELKOZ Q SU
DUZ GIDEN ABILITY
    1 CHILD ABILITY


CAITLYN Q SU

    ADAMA CARPINDA
        CHILD ABILITY CAGIR

******************/