using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject obj;
    public bool stopspawn = false;
    public float spawnDelay;
    public float spawnTime;
    private float time = 0;

    public int cur_num = 0;

    private int cur_wave = 1;
    private float stop_time = 0;
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
            if (cur_num < cur_wave*3)
            {
                if (stop_time < 3)
                {
                    stop_time += Time.deltaTime;
                }
                else
                {
                    Instantiate(obj, new Vector3(Random.Range(-20, -13), Random.Range(4, 8), Random.Range(-120, -90)), Quaternion.identity);
                    cur_num += 1;
                    stop_time = 0;

                }
                
            }
            
            
        }
   }

   void Update() {
        if (time < 20)
        {
            time += Time.deltaTime;
        } else {
            if (time < 30)
            {
                stopspawn = true;
                time += Time.deltaTime;
            }
            else
            {
                cur_wave += 1;
                stopspawn = false;
                time = 0;
            }
        }
   }

   public void delete()
    {
        cur_num -= 1;
    }
}
