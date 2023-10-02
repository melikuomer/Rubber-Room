// AbilityConfig.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


namespace Abilities
{
   
        [Serializable]
        public class InterfaceContainerArray<T> {
            // use Type.GetType(interfaceType) to get the type
            public string interfaceType ;
            public InterfaceContainerArray(){
                interfaceType = typeof(T).AssemblyQualifiedName;
            }

            [SerializeField, HideInInspector]
            public List<string> classNames;
        }

    
[CustomPropertyDrawer(typeof(InterfaceContainerArray<>))]
public class ContainerArrayDrawer: PropertyDrawer {
    Vector2 scrollPosition;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        //Interface Type to search in assemblies for 
        var interfaceType = property.FindPropertyRelative("interfaceType").stringValue;
        Type IType = Type.GetType(interfaceType);
        

        //Get all the assemblies which have the given type
        var keys = AssemblyDatabase.GetObjectMap(IType).Keys.ToArray();

        GUILayout.Label(property.displayName);
        List<string> selectedStrings =  (List<string>)property.FindPropertyRelative("classNames").GetUnderlyingValue();
        if (GUILayout.Button("Add Item"))
        {
            selectedStrings.Add("");
        }
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);
        for (int i = 0; i < selectedStrings.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            var localindex =Array.IndexOf(keys, selectedStrings[i]);
            // Display item name
             GUILayout.Space(20);
            int selected = EditorGUILayout.Popup("Effect: ",localindex, keys);
            if(selected != -1 && selected != localindex){
             
                var stringProperty =property.FindPropertyRelative("classNames").GetArrayElementAtIndex(i);
                stringProperty.stringValue = keys[selected];
            }
            // Remove Item Button
            if (GUILayout.Button("Remove"))
            {
                selectedStrings.RemoveAt(i);
                i--; // Decrement index to avoid skipping the next item
            }

            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();

        
        
    }
}



}


 
