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
                classNames= new();
            }

            [SerializeField, HideInInspector]
            public List<string> classNames;
        }

    
[CustomPropertyDrawer(typeof(InterfaceContainerArray<>))]
public class ContainerArrayDrawer: PropertyDrawer {



    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    Rect popupRect = new(position.x ,10 + position.y,position.width*.66f ,20) ;
    Rect buttonRect = new(position.x+popupRect.width+10, 10+ position.y,popupRect.width*.33f ,19.5f);
        //Interface Type to search in assemblies for 
        var interfaceType = property.FindPropertyRelative("interfaceType").stringValue;
        Type IType = Type.GetType(interfaceType);
        

        //Get all the assemblies which have the given type

        var map = AssemblyDatabase.GetObjectMap(IType);
        var keys = map.Keys.ToArray();
       
        EditorGUI.LabelField(popupRect,property.displayName);
        List<string> selectedStrings =  (List<string>)property.FindPropertyRelative("classNames").GetUnderlyingValue();
        if (GUI.Button(buttonRect,"Add Item"))
        {
            selectedStrings.Add("");
        }


        for (int i = 0; i < selectedStrings.Count; i++)
        {
            popupRect.y += popupRect.height * 1.2f;
            buttonRect.y += buttonRect.height *1.2f;
            string word = selectedStrings[i];
            if (selectedStrings[i] != ""){
            //TODO: put next three linex into a function in utils class. These handle the AssemblyQualifiedName to Standard name conversion
            int namespaceIndex = selectedStrings[i].IndexOf('.');
            int commaIndex = selectedStrings[i].IndexOf(',', namespaceIndex);
            word = selectedStrings[i].Substring(namespaceIndex + 1, commaIndex - namespaceIndex - 1).Trim();
            }
            

            var localindex =Array.IndexOf(keys, word);

            int selected = EditorGUI.Popup(popupRect,"Effect: ",localindex, keys);
            if(selected != -1 && selected != localindex){
             
                var stringProperty =property.FindPropertyRelative("classNames").GetArrayElementAtIndex(i);
                Type t = (Type)map.GetValueOrDefault(keys[selected]);
                stringProperty.stringValue = t.AssemblyQualifiedName;
            }
            // Remove Item Button
            if (GUI.Button(buttonRect,"Remove"))
            {
                selectedStrings.RemoveAt(i);
                i--; // Decrement index to avoid skipping the next item
            }


        }

        
        
    }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float height = base.GetPropertyHeight(property, label);

            // Add the extra height needed for your custom drawing
             return height + (property.FindPropertyRelative("classNames").arraySize * 25) + 25; // Adjust as needed
        }
    }



}


 
