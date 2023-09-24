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
    [CreateAssetMenu(fileName = "AbilityParticleConfig", menuName = "Abilities/Create New Particle")]
    public class AbilityParticleConfig : ScriptableObject
    {

        public GameObject particle; 
        public GameObject movementBehaviour;

        public GameObject CollisionBehaviour;

        public GameObject CollisionFilter;


        


        #region AssemblyStuff

         
        [NonSerialized]
        public static readonly Assembly assembly = Assembly.GetExecutingAssembly();
    


        #endregion

        
 



        static private IEnumerable<Type> GetAssembliesOfType (Assembly assembly, Type selectedType){
           
        return  assembly.GetTypes().Where(type => selectedType.IsAssignableFrom(type) && type.IsClass );
    }
    }

[CustomEditor(typeof(AbilityParticleConfig))]
public class AbilityParticleConfigEditor : Editor
{


    
    Vector2 scrollPosition;
    int selectedDropdownIndex = 0;




    public void Awake() {

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

    
    //EditorGUILayout.DropdownButton(AbilityConfig.AbilityTriggers.GetType().Name, "", "");

        // Display and edit the actions in the Inspector as needed
        // You can use SerializedProperty to make it more user-friendly.

       
    }
}

}
