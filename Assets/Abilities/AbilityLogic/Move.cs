    using UnityEngine;
    using UnityEditor;
   using System.Linq;
using System;

using System.Reflection;
using UnityEditor.PackageManager;
using System.Collections;


namespace Abilities {
    public class Move : IAbilityLogic {
        public IEnumerator DoLogic ( Transform transform, float lerpDuration, Transform startMarker, Transform endMarker){
            float timeElapsed = 0.0f;

        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, t);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        // Ensure the object ends up exactly at the end position
        transform.position = endMarker.position;
        }
    }
}