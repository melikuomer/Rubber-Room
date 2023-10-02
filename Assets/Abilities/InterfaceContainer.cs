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
        public class InterfaceContainer<T> {
            // use Type.GetType(interfaceType) to get the type
            public string interfaceType ;
            public InterfaceContainer(){
                interfaceType = typeof(T).AssemblyQualifiedName;
            }

            // Selected class from the inspector
            public string className;
        }

    
[CustomPropertyDrawer(typeof(InterfaceContainer<>))]
public class ContainerDrawer: PropertyDrawer {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        //Interface Type to search in assemblies for 
        var interfaceType = property.FindPropertyRelative("interfaceType").stringValue;
        Type IType = Type.GetType(interfaceType);
        //Get all the assemblies which have the given type
        var map = AssemblyDatabase.GetObjectMap(IType);
        var keys = map.Keys.ToArray();
        //Get which class is selected. 
        var classNameProperty =  property.FindPropertyRelative("className");
        string className = (string)classNameProperty.GetUnderlyingValue();

        //Find the index of currently selected class

        string word = className;
        //TODO: put next three linex into a function in utils class. These handle the AssemblyQualifiedName to Standard name conversion
        if(word != ""){
            Debug.Log(word);
        int namespaceIndex = className.IndexOf('.');
        int commaIndex = className.IndexOf(',', namespaceIndex);
        word = className.Substring(namespaceIndex + 1, commaIndex - namespaceIndex - 1).Trim();
        }

        var localindex = Array.IndexOf(keys,word);

        
        //Draw popup window with the current index
        var index = EditorGUI.Popup( position,property.displayName, localindex,  keys);
        if(index != -1 && index != localindex){
            var type = (Type)map.GetValueOrDefault(keys[index]);
            classNameProperty.stringValue = type.AssemblyQualifiedName;
        }
        
    }
}



}


 
