using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCollider : Collider
{
    
    public float MyCustomProperty { get; set; }

    public CustomCollider()
    {
        
        MyCustomProperty = 10f;
    }

    // This method is called when the collider collides with another collider.
  
}

