using System;
using UnityEngine;

namespace Abilities {



    public struct Target{

        public GameObject gameObject;
        public Vector3 position;

        public Target(GameObject gameObject, Vector3 position) {
            this.gameObject = gameObject;
            this.position = position;
        }
    }

    
}