using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Abilities {


public class ColliderHook : MonoBehaviour
{

    public delegate void CollisionEventHook(Collision collision);

    public event CollisionEventHook onCollisionEnter;
    public event CollisionEventHook onCollisionExit;
    public event CollisionEventHook onCollisionStay;

    // Start is called before the first frame update
    void Start()
    {
        #if DEBUG
        if (onCollisionEnter == null && onCollisionExit == null && onCollisionStay == null )
        {
            Assert.IsTrue(true, "All values are null");
        }
        #endif
    }

    

    private void OnCollisionEnter(Collision other) {
        onCollisionEnter?.Invoke(other);
    }


    private void OnCollisionExit(Collision other){
        onCollisionExit?.Invoke(other);
    }


    private void OnCollisionStay(Collision other){
        onCollisionStay?.Invoke(other);
    }
}

}