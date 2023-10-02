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

        #region AssemblyStuff

         
        [NonSerialized]
        public static readonly Assembly assembly = Assembly.GetExecutingAssembly();
    
        public static readonly IEnumerable<Type> AbilityTriggers = GetAssembliesOfType(assembly, typeof(IAbilityTrigger));

         public static readonly IEnumerable<Type> AbilityEffects = GetAssembliesOfType(assembly, typeof(IAbilityEffect));


        #endregion

        public InterfaceContainer<IAbilityTrigger> trigger;
        
  
        public InterfaceContainerArray<IAbilityEffect> effects;

        
        [HideInInspector]
         public GameObject particle ;
 
        
        [HideInInspector]
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

[CustomEditor(typeof(AbilityConfig))]
public class AbilityConfigEditor : Editor
{


    
    Vector2 scrollPosition;
    int selectedDropdownIndex = 0;

    AbilityConfig abilityConfig;


    public void Awake() {
        abilityConfig = (AbilityConfig)target;

    }


    

    private void DrawList(List<int> indexes){
    
        
        
        GUILayout.Label("Custom List Editor", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
         GUILayout.Space(20);
        // Add Item Button

        // Dropdown menu
        selectedDropdownIndex = EditorGUILayout.Popup("Select Option", selectedDropdownIndex, AssemblyDatabase.AbilityEffects.Select(type => type.Name).ToArray());
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
            indexes[i]= EditorGUILayout.Popup("Effect: ",indexes[i], AssemblyDatabase.AbilityEffects.Select(type => type.Name).ToArray());

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
    public override void OnInspectorGUI(){
        DrawDefaultInspector();

        

        //abilityConfig.triggerIndex= EditorGUILayout.Popup("Trigger Type: ",abilityConfig.triggerIndex, AssemblyDatabase.AbilityTriggers.Select(type => type.Name).ToArray());


        //DrawList(abilityConfig.effectIndexes);

        //abilityConfig.particle = (GameObject) EditorGUILayout.ObjectField("Particle", abilityConfig.particle , typeof(GameObject), false);
       

        //abilityConfig.particleConfig  =(AbilityParticleConfig) EditorGUILayout.ObjectField("Particle Config",abilityConfig.particleConfig, typeof(AbilityParticleConfig), false);

        EditorGUI.indentLevel+=2;
        //AbilityParticleConfig.DrawScriptableObject(ref abilityConfig.particleConfig);
        EditorGUI.indentLevel-=2;


        // Display and edit the actions in the Inspector as needed
        // You can use SerializedProperty to make it more user-friendly.

       
    }
}

}
