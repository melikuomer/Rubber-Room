using UnityEngine;
using System;
using System.Collections;


namespace Abilities
{
    public class  TriggerWhileActive : MonoBehaviour ,IAbilityTrigger{
        public IEnumerator Trigger(Action action) {
            while (true) {
                action.Invoke   ();
                yield return new WaitForSeconds(.25f);
            }
        }
    }
    // public static class TriggerWhileActive : IAbilityTrigger {

    //     public static IEnumerator Trigger(Action action) {
    //         while (true) {
    //             action.Invoke   ();
    //             yield return new WaitForSeconds(.25f);
    //         }
    //     }
    // }

}