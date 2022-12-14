using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenDoor {
    public class KeyItem : MonoBehaviour
{
   // Configuration
   public int id;
   public AudioSource pick;

   // Methods
   void OnTriggerEnter(Collider other) {
    PlayerController targetPlayer = other.GetComponent<PlayerController>();
    if(targetPlayer != null){
        targetPlayer.keyIdsObtained.Add(id);
        Destroy(gameObject);
        pick.Play();
    }
   } 
}
}