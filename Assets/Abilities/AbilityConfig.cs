// AbilityConfig.cs
using System;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

using Object = UnityEngine.Object;

namespace Abilities
{
    [CreateAssetMenu(fileName = "AbilityConfig", menuName = "Abilities/Create New Ability")]
    public class AbilityConfig : ScriptableObject
    {

        public GameObject gameObject;
        public TargetingType targetingType;
        public Vector3 defaultPosition;
        
        public Type abilityTrigger;
        public ICollisionDetection collisionDetection;
        public IAbilityAnimation abilityAnimation;
        
        public IAbilityTrigger trigger;
        [Header("Effects"), SerializeReference]
        public AbilityEffects[] abilityEffects;


        [Header("Child Abilities")]
        public AbilityConfig[] childAbilities; // Configure child abilities in the Inspector
    }

[CustomEditor(typeof(AbilityConfig))]
public class ActionContainerEditor : Editor
{
    private SerializedProperty abilityTriggerProp;

         public Object selectedObject; // This will hold the selected object
        public string objectType; 

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
       AbilityConfig abilityConfig = (AbilityConfig)target;
        selectedObject = EditorGUILayout.ObjectField("Select Object:", selectedObject, typeof(IAbilityTrigger), true);

        if (selectedObject != null)
        {
            // Capture the type of the selected object
            objectType = selectedObject.GetType().ToString();
            EditorGUILayout.LabelField("Object Type:", objectType);
        }


        // Display and edit the actions in the Inspector as needed
        // You can use SerializedProperty to make it more user-friendly.

        DrawDefaultInspector();
    }
}

}
