using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : MonoBehaviour
{
  public bool Action1 =false;
  public GameObject Instruction;
  public GameObject Instruction1;
  public GameObject ThisTrigger;
  public GameObject Obj;

void Start(){
    Instruction.SetActive(false);
    Instruction1.SetActive(false);
    ThisTrigger.SetActive(true);

  }
  void OnTriggerEnter(Collider collision){
    if (collision.gameObject.name == "PlayerCapsule" && GameVariables.KeyCount >0){
        Instruction.SetActive(true);
        Action1 = true;
        Debug.Log(Action1 +"!"); 
      
    }
     if (collision.gameObject.name == "PlayerCapsule" && GameVariables.KeyCount ==0){
        Instruction1.SetActive(true);
      
    }
  }
  void OnTriggerExit(Collider collision){
   Instruction.SetActive(false);
   Instruction1.SetActive(false);
   Action1 = false;
   Debug.Log(Action1 +"!");

  }

  void Update(){
    if(Input.GetKeyDown(KeyCode.E)  && Action1 == true){
       Debug.Log("door"+Action1 +"!"); 
      
        GameVariables.KeyCount --;
        Destroy(Obj);
        Instruction.SetActive(false);
        Instruction1.SetActive(false);
        Action1 = false;
        ThisTrigger.SetActive(false);
      
    }
  }

}
