using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
   public GameObject obj;
   public bool stopspawn = false;
   public float spawnDelay;
   public float spawnTime;
   public float time = 0;
   void Start(){
    // if(时间夜晚)
    InvokeRepeating("SpawnObj",spawnTime,spawnDelay);
   
   }
   public void SpawnObj()
   {
        // Instantiate(obj,new Vector3(Random.Range(-2,-4),0,Random.Range(10,15)),Quaternion.identity);
        if(stopspawn) {
            CancelInvoke("SpawnObj");
        }else{

            Instantiate(obj,new Vector3(Random.Range(-20,-13),Random.Range(4,8), Random.Range(-120, -90)),Quaternion.identity);
            
        }
   }

   void Update() {
    // if(time < 27)
    if(time < 120)
            {
                time += Time.deltaTime;
            } else
            {
                stopspawn = true;
            }
            // if (stopspawn)
            // {
            //     time = 10;
            // }

   }
}
