// BaseAbility.cs
/*
    This class should not be inherited. Instead it should be contructed with an abilty Config.  
    This class' main job is to call injected components in a specific order
*/

using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.UIElements;
using System.Linq;
using System;
namespace Abilities
{
public class BaseAbility : IAbility 
{
    #region NotNamedForNow
    

    #endregion 
    protected AbilityConfig abilityConfig;

    protected List<BaseAbility> childAbilities = new();
    
    protected List<IAbilityEffect> abilityEffects = new();


    protected IAbilityTrigger abilityTrigger = null;
    public BaseAbility(AbilityConfig config)
    {
        abilityConfig = config;


        //Instantiate child abilities from the ability config
        foreach (var childConfig in abilityConfig.childAbilities){
            childAbilities.Add(new BaseAbility(childConfig));
        }

        LoadConfig();
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
        // abilityTrigger.Trigger(()=> {Debug.Log("sa");});

        // var hook = abilityConfig.particle.GetComponent<ColliderHook>();
        // hook.onCollisionEnter += OnCollide;
        // foreach (var childAbility in childAbilities)
        // {
        //     childAbility.Activate(targetTransform, targetPosition);
        // }
    }

    public void OnCollide(Collision other){
        foreach (var effect in abilityEffects){
            effect.Apply();

        }
    }


    public void LoadConfig(){
        Debug.Log(abilityConfig.AbilityTrigger.className);
        abilityTrigger = (IAbilityTrigger)Activator.CreateInstance(Type.GetType(abilityConfig.AbilityTrigger.className));


        foreach (var className  in abilityConfig.effects.classNames){
            object[] args = null;
            
            IAbilityEffect eff = (IAbilityEffect) Activator.CreateInstance(Type.GetType(className));

            

            abilityEffects.Add(eff);
        }
       
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