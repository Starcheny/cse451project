using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    public GameObject obj;
    public bool stopspawn = false;
    public float spawnDelay;
    public float spawnTime;
    public float time = 0;

    public int cur_num = 0;

    public int cur_wave = 0;

    public Text Timer;


    private bool start = false;

    private float time2 = 0;
    public int max_wave;
   void Start(){
    // if(时间夜晚)
        Timer.transform.position = new Vector3(Screen.width * 4 / 10, Screen.height * 19 / 20);
        Timer.rectTransform.sizeDelta = new Vector2(Screen.width * 4 / 25, Screen.height * 5 / 90);
        
        time2 = spawnTime;
   
   }
   

   void Update() {
        
        if (time2 >0)
        {
            
            Timer.text = "Time: " + Mathf.Round(time2); ;
            time2 -= Time.deltaTime;
        }
        else
        {
            start = true;
        }


        if (start)
        {
            if (time < spawnDelay + cur_wave)
            {
                
                time += Time.deltaTime;
                Timer.text = "Time: " + Mathf.Round(time) + "              Wave: " + cur_wave;
            }
            else
            {
                if (time < spawnDelay+2+cur_wave)
                {
                    time += Time.deltaTime;
                    Timer.text = "Coming!";
                }
                else
                {

                    Timer.text = "Wave: " + cur_wave;
                    
                    cur_wave += 1;
                    int num = cur_wave * 3 -  cur_num;

                    
                    for(int i =0;i<num;i++)
                    {
                        Instantiate(obj, new Vector3(UnityEngine.Random.Range(-20, -13), UnityEngine.Random.Range(4, 8), UnityEngine.Random.Range(-150, -70)), Quaternion.identity);
                        cur_num += 1;
                    }
                    time = 0;
                    if(cur_wave == max_wave)
                    {
                        start = false;
                    }
                }

            }
        }
        



    }
   
   public void delete()
    {
        cur_num -= 1;
    }


    public void stop_born()
    {
        start = false;
    }
}
