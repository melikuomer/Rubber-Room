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
        var keys = AssemblyDatabase.GetObjectMap(IType).Keys.ToArray();
        //Get which class is selected. 
        var classNameProperty =  property.FindPropertyRelative("className");
        var className = classNameProperty.GetUnderlyingValue();

        //Find the index of currently selected class
        var localindex = Array.IndexOf(keys, className);
        
        //Draw popup window with the current index
        var index = EditorGUI.Popup( position,property.name, localindex,  keys);
        if(index != -1 && index != localindex){
            classNameProperty.stringValue = keys[index];
        }
        
    }
}



}


 
