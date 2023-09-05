using UnityEngine;


    public static class Utils {

        // Returns null object with ZERO VECTOR when none is hit
        public static Abilities.Target GetTarget_FromMousePos(Camera camera){
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray , out hitInfo)){
                GameObject hitObject = hitInfo.collider.gameObject;
                Vector3 hitPoint = hitInfo.point;
                
                return new Abilities.Target(hitObject, hitPoint);
            }


            return new Abilities.Target(null, Vector3.zero);
        }
    
    }