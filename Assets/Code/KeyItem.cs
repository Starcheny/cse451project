using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
  void OnTriggerEnter(Collider collider){
    if (collider.gameObject.name == "PlayerCapsule"){
        GameVariables.KeyCount +=2;
        Destroy(gameObject);
    }
  }
}
