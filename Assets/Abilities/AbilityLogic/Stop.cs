
using System.Collections;
using UnityEngine;

namespace Abilities {
    public class Stop : IAbilityLogic {
        public IEnumerator DoLogic (Transform transform, float lerpDuration, Transform startMarker, Transform endMarker){
            Debug.Log("temp");
            yield return null;
        }
    }
}