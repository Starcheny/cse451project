using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OpenDoor {
    public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
        // State Tracking
        public List<int> keyIdsObtained;



        public Transform povOrigin;
        public Transform projectileOrigin;
        public GameObject projectfilePrefab;
        public float attackRange;


        




        //Methods
        void Awake(){
            instance = this;
            keyIdsObtained = new List<int>();
            
        }

        void OnSecondaryAttack()
        {
            if (this.gameObject.GetComponent<player_health>().number_of_bullet > 0)
            {
                GameObject projectile = Instantiate(projectfilePrefab, projectileOrigin.position, Quaternion.LookRotation(povOrigin.forward));
                projectile.transform.localScale = Vector3.one * 5f;
                projectile.GetComponent<Rigidbody>().AddForce(povOrigin.forward * 50f, ForceMode.Impulse);
                this.gameObject.GetComponent<player_health>().number_of_bullet -= 1;
            }
            
        }

        void Update() {
            Keyboard keyboardInput = Keyboard.current;
            Mouse mouseInput = Mouse.current;
            if(keyboardInput != null && mouseInput != null){
                //E KEY Interaction
                if(keyboardInput.eKey.wasPressedThisFrame) {
                    Vector2 mousePosition = mouseInput.position.ReadValue();

                    Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit, 2f)) {
                        //Debug : Test first-person interactions
                        print("Interacted with" + hit.transform.name + "from " + hit.distance + "m.");

                        //Door
                        Door targetDoor = hit.transform.GetComponent<Door>();
                        if(targetDoor){
                            targetDoor.Interact();
                        }
                    
                    }
                }



            }

            if (mouseInput.leftButton.wasPressedThisFrame)
            {
                OnSecondaryAttack();
            }




        }
}
}