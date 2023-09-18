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

namespace Abilities
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Abilities/Create New Ability")]
    public class AbilityConfig : ScriptableObject
    {

        #region AssemblyStuff

         
        [NonSerialized]
        public static readonly Assembly assembly = Assembly.GetExecutingAssembly();
    
        public static readonly IEnumerable<Type> AbilityTriggers = GetAssembliesOfType(assembly, typeof(IAbilityTrigger));

        public static readonly IEnumerable<Type> AbilityEffects = GetAssembliesOfType(assembly, typeof(IAbilityEffect));

        [NonSerialized]
        public int triggerIndex =0;

    

        #endregion
        [HideInInspector]
        public List<int> effectIndexes = new(); 
        public GameObject gameObject;
        public TargetingType targetingType;
        public Vector3 defaultPosition;
        
        public Type abilityTrigger;
        public ICollisionDetection collisionDetection;
        public IAbilityAnimation abilityAnimation;
        
        public IAbilityTrigger trigger;
        
 


        [Header("Child Abilities")]
        //TODO CHECK IF THE CHILD CONFIG IS SAME AS THIS CONFIG
        public AbilityConfig[] childAbilities; // Configure child abilities in the Inspector



        static private IEnumerable<Type> GetAssembliesOfType (Assembly assembly, Type selectedType){
           
        return  assembly.GetTypes().Where(type => selectedType.IsAssignableFrom(type) && type.IsClass );
    }
    }

[CustomEditor(typeof(AbilityConfig))]
public class AbilityConfigEditor : Editor
{


    
    Vector2 scrollPosition;
    int selectedDropdownIndex = 0;




    public void Awake() {
       // AbilityConfig.assembly = Assembly.GetExecutingAssembly();
        //AbilityConfig.AbilityTriggers = GetAssembliesOfType(AbilityConfig.assembly, typeof(IAbilityTrigger));
        //AbilityConfig.AbilityEffects = GetAssembliesOfType(AbilityConfig.assembly, typeof(IAbilityEffect));
    }

    static private IEnumerable<Type> GetAssembliesOfType (Assembly assembly, Type selectedType){
           
        return  assembly.GetTypes().Where(type => selectedType.IsAssignableFrom(type) && type.IsClass );
    }
    
    private void DrawList(List<int> indexes){
        
        
        GUILayout.Label("Custom List Editor", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
         GUILayout.Space(20);
        // Add Item Button

        // Dropdown menu
        selectedDropdownIndex = EditorGUILayout.Popup("Select Option", selectedDropdownIndex, AbilityConfig.AbilityEffects.Select(type => type.Name).ToArray());
        if (GUILayout.Button("Add Item"))
        {
            indexes.Add(selectedDropdownIndex);
        }
        GUILayout.EndHorizontal();

        // Display list items
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        for (int i = 0; i < indexes.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            // Display item name
             GUILayout.Space(20);
            indexes[i]= EditorGUILayout.Popup("Effect: ",indexes[i], AbilityConfig.AbilityEffects.Select(type => type.Name).ToArray());

            // Remove Item Button
            if (GUILayout.Button("Remove"))
            {
                indexes.RemoveAt(i);
                i--; // Decrement index to avoid skipping the next item
            }

            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();
    }
        public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        AbilityConfig abilityConfig = (AbilityConfig)target;

           abilityConfig.triggerIndex= EditorGUILayout.Popup("Trigger Type: ",abilityConfig.triggerIndex, AbilityConfig.AbilityTriggers.Select(type => type.Name).ToArray());


        DrawList(abilityConfig.effectIndexes);
    
    //EditorGUILayout.DropdownButton(AbilityConfig.AbilityTriggers.GetType().Name, "", "");

        // Display and edit the actions in the Inspector as needed
        // You can use SerializedProperty to make it more user-friendly.

       
    }
}

}
