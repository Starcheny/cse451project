using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenDoor {
   public class Roomdoor : MonoBehaviour
{
     

    //Configuration
        public GameObject requiredSender;
        public int keyIdRequired = -1;// default -1 means no key required.




// void OnTriggerEnter(Collider collider){
//     if (collider.gameObject.name == "PlayerCapsule" && GameVariables.KeyCount >0){

//         GameVariables.KeyCount --;
//         Destroy(gameObject);
        
//     }
//   }



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
                Destroy(gameObject);;
            }
}

}
 
}
