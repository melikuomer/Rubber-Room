using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Abilities {


public class ParticleBase : MonoBehaviour
{

    public delegate void CollisionEventHook(Collision collision);



    public AbilityParticleConfig particleConfig;

    // Start is called before the first frame update
    void Start()
    {

        var logic = (IAbilityLogic)Activator.CreateInstance(Type.GetType(particleConfig.logic.className));
        StartCoroutine(logic.DoLogic(transform, 3f , transform, transform));

        
    }


    public void LoadConfig (AbilityParticleConfig config){
        particleConfig = config;
    }

    

    


}

}