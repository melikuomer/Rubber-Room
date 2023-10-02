// AbilityConfig.cs
using System;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using Unity.VisualScripting.Antlr3.Runtime.Tree;


namespace Abilities
{
    [CreateAssetMenu(fileName = "AbilityParticleConfig", menuName = "Abilities/Create New Particle")]
    public partial class AbilityParticleConfig : ScriptableObject
    {

        
        public string nickname; 
        public GameObject particle; 

        
        
        public IAbilityLogic movementBehaviour;

   

        public InterfaceContainer<IAbilityLogic> logic = new();
        
        public GameObject CollisionBehaviour;

        public GameObject CollisionFilter;



    

        public static void DrawScriptableObject(ref AbilityParticleConfig obj){
        if(obj == null) return;
            
        foreach (var field in typeof(AbilityParticleConfig).GetFields(BindingFlags.Public
        | BindingFlags.Instance) ){
            // EditorGUILayout.BeginHorizontal();
            // EditorGUILayout.Space(10);
            var val = field.GetValue(obj);
           
            if (val is string){
                string value = (string) field.GetValue(obj);
                
                field.SetValue(obj, EditorGUILayout.TextField(field.Name, value));
            }else {
                    
                Object value = (Object) field.GetValue(obj);
                field.SetValue(obj, EditorGUILayout.ObjectField(field.Name, value, field.FieldType, false));
            }
            // EditorGUILayout.EndHorizontal();
        }
        // EditorGUILayout.Space(10);
    }

    }




 }
