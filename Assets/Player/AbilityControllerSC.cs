using System.Collections;
using System.Collections.Generic;
using Abilities;
using UnityEditor;
using UnityEngine;

public class AbilityControllerSC : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]private AbilityConfig config; 
    private IAbility ability;
    void Start()
    {
        ability = new DebugAbility(config);
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Q)){
            Target target = Utils.GetTarget_FromMousePos(Camera.main);
            ability.Activate(target);
        }
    }
}
