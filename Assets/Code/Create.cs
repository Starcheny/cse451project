using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
   public GameObject obj;
   public bool stopspawn = false;
   public float spawnDelay;
   public float spawnTime;
   void Start(){
    InvokeRepeating("SpawnObj",spawnTime,spawnDelay);
   
   }
   public void SpawnObj()
   {
        // Instantiate(obj,new Vector3(Random.Range(-2,-4),0,Random.Range(10,15)),Quaternion.identity);
        if(stopspawn) {
            CancelInvoke("SpawnObj");
        }else{
            Instantiate(obj,new Vector3(Random.Range(-2,-4),0,Random.Range(10,15)),Quaternion.identity);
        }
   }
}
