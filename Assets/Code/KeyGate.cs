using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : MonoBehaviour
{
void OnTriggerEnter(Collider collider){
    if (collider.gameObject.name == "PlayerCapsule" && GameVariables.KeyCount >0){

        GameVariables.KeyCount --;
        Destroy(gameObject);
        
    }
  }
}
