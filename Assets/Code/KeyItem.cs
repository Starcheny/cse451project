using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyItem : MonoBehaviour
{//keyboardInput.eKey.wasPressedThisFrame
  public GameObject Instruction;
  public GameObject ThisTrigger;
  public GameObject Obj;
  public AudioSource pick;
  
  public bool Action =false;

  void Start(){
    Instruction.SetActive(false);
    ThisTrigger.SetActive(true);
    Obj.SetActive(true);
    //ThisTrigger.SetActive(true);

  }
  void OnTriggerEnter(Collider collision){
    if (collision.gameObject.name == "PlayerCapsule"){
        Instruction.SetActive(true);
        Action = true;
        Debug.Log(Action +"!"); 
    }
  }
  void OnTriggerExit(Collider collision){
   Instruction.SetActive(false);
   Action = false;

  }

  void Update(){
    //Debug.Log("before"+Action +"!"); 

    if(Input.GetKeyDown(KeyCode.E) && Action == true){
      Debug.Log("after"+Action +"!"); 

      //if(Action = true){
        GameVariables.KeyCount +=1;
        pick.Play();
        //Obj.SetActive(false);
        Destroy(Obj);
        Instruction.SetActive(false);
        Action = false;
        ThisTrigger.SetActive(false);


      //}
      
    }
  }
}
