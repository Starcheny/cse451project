using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenDoor {
   public class Door : MonoBehaviour
{
     //Outlets
    Animator animator;

    //Configuration
        public GameObject requiredSender;
        public int keyIdRequired = -1;// default -1 means no key required.

    //Methods
    void Awake() {
    animator = GetComponent<Animator>();
}

    public void Interact(GameObject sender = null) {
        bool shoudOpen =false;
        //Is this a valid interaction?
            if(!requiredSender){
                shoudOpen = true;
            } else if(requiredSender == sender){
                shoudOpen = true;
            }
            
             //Check required key if other requirements met
            bool keyRequired = keyIdRequired >=0;
            bool keyMissing = !PlayerController.instance.keyIdsObtained.Contains(keyIdRequired);
            if(keyRequired && keyMissing){
                shoudOpen = false;
            }




        if(shoudOpen) {
                animator.SetTrigger("Open");
            }
}

}
 
}
